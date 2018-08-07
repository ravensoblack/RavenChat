using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace RazorChat
{
    // format: NODES:nodenumber,nodestatusnumber,useron,nodestatusdescription
    public struct Node
    {
        public string nodenumber, nodestatusnumber, useron, nodestatusdescription;
        //public bool paged;
    }

    public partial class RazorPage : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public String TextToSend;
        public Node[] status;
        public Node[] prevstatus;
        public bool clientauthenticated = false;
        Timer[] timerFlashnodes;
        public bool[] statusnodepaged;

        public RazorPage()
        {
            InitializeComponent();
        }

        private void RazorPage_Load(object sender, EventArgs e)
        {
            initnodedisplay("init");

            // currently only takes a single command line argument, debug
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                if (args[1] == "debug")
                {
                    debugToolStripMenuItem.Visible = true;
                    toolStripButtonDebug.Visible = true;
                }
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.ConnectToBbs!="connected")
            {
                // Connect
                Properties.Settings.Default.ConnectToBbs = "connecting";
                // display Settings form if the host or port info are missing
                if (Properties.Settings.Default.BbsHostOrIp == "" || Properties.Settings.Default.ChatPort == "")
                {
                    MainSettings frmSettings = new MainSettings();
                    frmSettings.ShowDialog();
                }
                // make sure user didn't cancel out of the settings
                if (Properties.Settings.Default.ConnectToBbs == "connecting")
                {
                    // display the Login form if login info is missing
                    if (Properties.Settings.Default.SysopUsername == "" || Properties.Settings.Default.SysopPassword == "" || Properties.Settings.Default.SystemPassword == "")
                    {
                        LoginForm frmLogin = new LoginForm();
                        frmLogin.ShowDialog();
                    }
                }
                // make sure user didn't cancel out of the login
                if (Properties.Settings.Default.ConnectToBbs == "connecting")
                {
                    client = new TcpClient();
                    IPHostEntry host;
                    host = Dns.GetHostEntry(Properties.Settings.Default.BbsHostOrIp);
                    IPEndPoint IpEnd = new IPEndPoint(host.AddressList[0], int.Parse(Properties.Settings.Default.ChatPort));
                    try
                    {
                        client.Connect(IpEnd);

                        if (client.Connected)
                        {
                            Properties.Settings.Default.ConnectToBbs = "connected";
                            toolStripButtonConnect.Image = Properties.Resources.icons8_connected_nolan_50;
                            toolStripButtonConnect.Text = "Disconnect";
                            connectToolStripMenuItem.Text = "Disconnect";
                            enablePagerToolStripMenuItem.Enabled = true;
                            toolStripButtonEnablePager.Enabled = true;
                            STW = new StreamWriter(client.GetStream());
                            STR = new StreamReader(client.GetStream());
                            STW.AutoFlush = true;
                            backgroundWorkerReceive.RunWorkerAsync();
                            backgroundWorkerSend.WorkerSupportsCancellation = true;
                            backgroundWorkerReceive.WorkerReportsProgress = true;
                            timerGetStatus.Start();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("from Connect: " + ex.Message.ToString());
                    }
                }
            }
            else
            {
                // Disconnect
                timerGetStatus.Stop();
                TextToSend = "QUIT";
                backgroundWorkerSend.RunWorkerAsync();
                Properties.Settings.Default.ConnectToBbs = "disconnected";
                Properties.Settings.Default.PagerEnabled = false;
                clientauthenticated = false;

                // reset nodes back to the disconnected display
                initnodedisplay("disconnect");

                client.Close();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainSettings frmSettings = new MainSettings();
            frmSettings.ShowDialog();
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RazorChatDebug debugForm = new RazorChatDebug();
            debugForm.Show();
        }

        private void toolStripButtonConnect_Click(object sender, EventArgs e)
        {
            // call the Connect popup menu function
            connectToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonSettings_Click(object sender, EventArgs e)
        {
            // call the Settings popup menu function
            settingsToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButtonDebug_Click(object sender, EventArgs e)
        {
            // call the Debug popup menu function
            debugToolStripMenuItem_Click(sender, e);
        }

        private void RazorPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // blank username before saving, if it wasn't filled on MainSettings
            if (Properties.Settings.Default.UsernameSavedOnMain == false)
            {
                Properties.Settings.Default.SysopUsername = "";
            }
            // blank passwords before saving, if they weren't filled on MainSettings
            if (Properties.Settings.Default.PasswordsSavedOnMain == false)
            {
                Properties.Settings.Default.SysopPassword = "";
                Properties.Settings.Default.SystemPassword = "";
            }
            Properties.Settings.Default.Save();
        }

        private void timerGetStatus_Tick(object sender, EventArgs e)
        {
            if (!clientauthenticated)
            {
                // The authentication command will be "AUTHINFO username password syspass"
                TextToSend = "AUTHINFO " + Properties.Settings.Default.SysopUsername + " " +
                    Properties.Settings.Default.SysopPassword + " " +
                    Properties.Settings.Default.SystemPassword;
                clientauthenticated = true;
            }
            else
            {
                TextToSend = "CHAT STATUS";
            }
            backgroundWorkerSend.RunWorkerAsync();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frmAbout = new About();
            frmAbout.ShowDialog();
        }

        void tsb_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null && tsb.Tag != null)
            {
                //MessageBox.Show(String.Format("Hello, I'm the {0} button", tsb.Tag.ToString()) + ". name: " + tsb.Name);
            }
        }

        private bool setpagerstatus(string pagerstring)
        {
            if (pagerstring.Split(':')[1] == "ENABLED")
            {
                if (Properties.Settings.Default.PagerEnabled == false)
                {
                    Properties.Settings.Default.PagerEnabled = true;
                    toolStripButtonEnablePager.Image = Properties.Resources.green_circle;
                    toolStripButtonEnablePager.Text = "Disable Pager";
                    //this.contextMenuStrip1.Invoke(new MethodInvoker(delegate ()
                    //{
                        enablePagerToolStripMenuItem.Text = "Disable Pager";
                    //}));
                }
                return true;
            }
            else
            {
                if (Properties.Settings.Default.PagerEnabled == true)
                {
                    Properties.Settings.Default.PagerEnabled = false;
                    toolStripButtonEnablePager.Image = Properties.Resources.red_circle;
                    toolStripButtonEnablePager.Text = "Enable Pager";
                    //this.contextMenuStrip1.Invoke(new MethodInvoker(delegate ()
                    //{
                        enablePagerToolStripMenuItem.Text = "Enable Pager";
                    //}));
                }
                return false;
            }
        }

        private void parsenodes(string nodestring)
        {
            char separator = '.';
            char nodeseparator = ';';
            char statseparator = ',';

            string[] tempstring = nodestring.Split(':');
            string[] nodestrings = tempstring[1].Split(nodeseparator);

            status = new Node[nodestrings.Length];
            if (statusnodepaged == null)
            {
                statusnodepaged = new bool[nodestrings.Length];
            }
            // format: NODES:nodenumber,nodestatusnumber,useron,nodestatusdescription
            for (int i = 0; i < nodestrings.Length; i++)
            {
                status[i].nodenumber = nodestrings[i].Split(statseparator)[0];
                status[i].nodestatusnumber = nodestrings[i].Split(statseparator)[1];
                status[i].useron = nodestrings[i].Split(statseparator)[2];
                status[i].nodestatusdescription = nodestrings[i].Split(statseparator)[3];

                /* Node status lights:
                 * Green: Ready for call
                 * Yellow (or maybe Gray): User logged in
                 * Red: Maintenance of some sort
                 * */
                // visual node status
                if(prevstatus==null)
                {
                    prevstatus = new Node[nodestrings.Length];
                }
                if (status[i].nodestatusnumber != prevstatus[i].nodestatusnumber)
                {
                    var toolstrip1Items = toolStripNodes as ToolStrip;
                    var btnNode = toolstrip1Items.Items.Find("nodebutton" + i, true);
                    switch (status[i].nodestatusnumber)
                    {
                        case "0":
                            btnNode[0].Image = Properties.Resources.green_circle;
                            btnNode[0].ForeColor = Color.Black;
                            break;
                        case "1":
                            btnNode[0].Image = Properties.Resources.yellow_circle;
                            btnNode[0].ForeColor = Color.Black;
                            break;
                        case "3":
                            btnNode[0].Image = Properties.Resources.yellow_circle;
                            btnNode[0].ForeColor = Color.Black;
                            break;
                        default:
                            btnNode[0].Image = Properties.Resources.red_circle;
                            break;
                    }
                }
                if (status[i].useron != prevstatus[i].useron||status[i].nodestatusdescription!=prevstatus[i].nodestatusdescription)
                {
                    Label nodelabel = this.Controls.Find("nodelabel" + i, true).FirstOrDefault() as Label;
                    if(status[i].useron!="")
                    {
                        nodelabel.Text = status[i].useron + " ";
                    }
                    nodelabel.Text += status[i].nodestatusdescription;
                }
            }
            Properties.Settings.Default.NumberOfNodes = nodestrings.Length;
            prevstatus = status;
        }

        private void enablePagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // send PAGE ENABLE/PAGE DISABLE
            if (Properties.Settings.Default.PagerEnabled == false)
            {
                TextToSend = "PAGE ENABLE";
            }
            else
            {
                TextToSend = "PAGE DISABLE";
            }
            backgroundWorkerSend.RunWorkerAsync();
        }

        private void toolStripButtonEnablePager_Click(object sender, EventArgs e)
        {
            enablePagerToolStripMenuItem_Click(sender, e);
        }

        private string getpagerstatus(string pagerstring)
        {
            string nodepaged = "";
            if(pagerstring!="")
            {
                nodepaged = pagerstring.Split(':')[1];
            }
            return nodepaged;
        }

        private string getpaginguser(int nodepaged)
        {
            return status[nodepaged].useron;
        }

        private void initnodedisplay(string initstatus)
        {
            // initstatus will be either init or disconnect
            // default window size 300, 220
            Properties.Settings.Default.PagerEnabled = false;
            Properties.Settings.Default.ConnectToBbs = "disconnected";
            toolStrip1.BackColor = Color.Black;
            toolStripNodes.BackColor = Color.Black;

            int ylocation = 48;
            if (initstatus == "init")
            {
                for (int i = 0; i < Properties.Settings.Default.NumberOfNodes; i++)
                {
                    ToolStripButton tsb = new ToolStripButton();
                    tsb.Text = (i + 1).ToString();
                    tsb.Tag = i;
                    tsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
                    tsb.BackColor = Color.Black;
                    tsb.ForeColor = Color.White;
                    tsb.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
                    tsb.Image = Properties.Resources.black_circle;
                    tsb.Name = "nodebutton" + i;
                    tsb.Click += new EventHandler(tsb_Click);
                    toolStripNodes.Items.Add(tsb);

                    Label nodelabel = new Label();
                    nodelabel.Text = "";
                    nodelabel.Name = "nodelabel" + i;
                    nodelabel.ForeColor = Color.White;
                    nodelabel.Location = new Point(40, ylocation);
                    nodelabel.AutoSize = true;
                    this.Controls.Add(nodelabel);
                    ylocation += 30;
                }
                // init timers to flash node buttons
                timerFlashnodes = new Timer[Properties.Settings.Default.NumberOfNodes];
                for (int i = 0; i < Properties.Settings.Default.NumberOfNodes; i++)
                {
                    timerFlashnodes[i] = new Timer();
                    timerFlashnodes[i].Enabled = false;
                    timerFlashnodes[i].Interval = 1000;
                    timerFlashnodes[i].Tick += this.timerFlashNode_Tick;
                }
            }
            else
            {
                toolStripButtonConnect.Image = Properties.Resources.icons8_disconnected_nolan_50;
                toolStripButtonEnablePager.Image = Properties.Resources.red_circle;
                toolStripButtonEnablePager.Text = "Enable Pager";
                enablePagerToolStripMenuItem.Text = "Enable Pager";
                enablePagerToolStripMenuItem.Enabled = false;
                toolStripButtonEnablePager.Enabled = false;

                for (int i = 0; i < Properties.Settings.Default.NumberOfNodes; i++)
                {
                    var toolstrip1Items = toolStripNodes as ToolStrip;
                    var btnNode = toolstrip1Items.Items.Find("nodebutton" + i, true);
                    btnNode[0].Image = Properties.Resources.black_circle;
                    btnNode[0].ForeColor = Color.White;
                    Label nodelabel = this.Controls.Find("nodelabel" + i, true).FirstOrDefault() as Label;
                    nodelabel.Text = "";
                }
            }
        }

        private void StartFlashNode(int nodepaged)
        {
            // visual page
            if (Properties.Settings.Default.VisualPagingEnabled == true)
            {
                FlashWindow.Start(this);
            }
            // all pages should flash the node button
            // this is currently failing if multiple nodes should flash for pages
            timerFlashnodes[nodepaged].Start();
        }

        private void StopFlashNode(int nodeclicked)
        {

        }

        private void timerFlashNode_Tick(object sender, EventArgs e)
        {
            for(int i=0; i<statusnodepaged.Length; i++)
            {
                var toolstrip1Items = toolStripNodes as ToolStrip;
                var btnNode = toolstrip1Items.Items.Find("nodebutton" + i, true);
                if (statusnodepaged[i] == true)
                {
                    if (btnNode[0].Tag.ToString() == "Blue")
                    {
                        btnNode[0].Tag = "Yellow";
                        btnNode[0].Image = Properties.Resources.yellow_circle;
                    }
                    else
                    {
                        btnNode[0].Tag = "Blue";
                        btnNode[0].Image = Properties.Resources.blue_circle;
                    }
                }
            }
        }

        private void processreceive(string localreceive)
        {
            // from DoWork
            // processes received data
            if (localreceive.Substring(0, 5) == "PAGER")
            {
                bool pagerstatus;
                pagerstatus = setpagerstatus(localreceive.Split('.')[0]);
                if (pagerstatus == true)
                {
                    // check for page
                    string nodepagedstring = getpagerstatus(localreceive.Split('.')[1]);
                    if (nodepagedstring != "")
                    {
                        // switch paging node to blue
                        int nodepaged = int.Parse(nodepagedstring) - 1;
                        statusnodepaged[nodepaged] = true;
                        string paginguser = getpaginguser(nodepaged);
                        StartFlashNode(nodepaged);
                        if (Properties.Settings.Default.AudioPagingEnabled == true)
                        {
                            // do audio page
                            var audioresource = Properties.Resources.ResourceManager.GetObject(Properties.Settings.Default.AudioPageFile);
                            Stream str = (Stream)audioresource;
                            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                            snd.Play();
                        }
                        if (Properties.Settings.Default.ExternalPagingEnabled == true)
                        {
                            // do external paging
                            // interpret %t as Title (RazorPage) & %m as Message (like Razor paging from node 1)
                            
                            // we're currently getting 2 of these per page
                            string cmdargs = "";
                            string pagemsg = paginguser + " paging from node " + (nodepaged + 1).ToString();
                            cmdargs = Properties.Settings.Default.ExternalPageOptions;
                            cmdargs = cmdargs.Replace("%t", "RazorPage");
                            cmdargs = cmdargs.Replace("%m", pagemsg);
                            Process externalpagecmd = new Process();
                            externalpagecmd.StartInfo.FileName = Properties.Settings.Default.ExternalPageCommand;
                            externalpagecmd.StartInfo.Arguments = cmdargs;
                            externalpagecmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            externalpagecmd.Start();
                        }
                    }
                }
                parsenodes(localreceive.Split('.')[2]);
            }
        }

        private void backgroundWorkerReceive_DoWork(object sender, DoWorkEventArgs e)
        {
            // started as backgroundWorker1
            while (client.Connected)
            {
                // receives data
                try
                {
                    BackgroundWorker worker = (BackgroundWorker)sender;
                    while (!worker.CancellationPending)
                    {
                        receive = STR.ReadLine();
                        worker.ReportProgress(0, "AN OBJECT TO PASS TO THE UI-THREAD");
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("from Background1: " + ex.Message.ToString());
                }
            }
        }

        private void backgroundWorkerReceive_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            processreceive(receive);
        }

        void backgroundWorkerReceive_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                processreceive(e.Result.ToString());
                backgroundWorkerReceive.RunWorkerAsync();
            }
        }

        private void backgroundWorkerSend_DoWork(object sender, DoWorkEventArgs e)
        {
            // started as backgroundWorker2
            // sends data
            if (client.Connected)
            {
                STW.WriteLine(TextToSend);
            }
            else
            {
                MessageBox.Show("Sending failed");
            }
            backgroundWorkerSend.CancelAsync();
        }
    }
}
