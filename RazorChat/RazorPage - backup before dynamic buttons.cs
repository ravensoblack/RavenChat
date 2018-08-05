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

/* Node status lights:
 * Green: Ready for call
 * Yellow (or maybe Gray): User logged in
 * Red: Maintenance of some sort
 * */

namespace RazorChat
{
    // format: NODES:nodenumber,nodestatusnumber,useron,nodestatusdescription
    public struct Node
    {
        public string nodenumber, nodestatusnumber, useron, nodestatusdescription;
    }

    public partial class RazorPage : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public String TextToSend;

        public RazorPage()
        {
            InitializeComponent();
        }

        private void RazorPage_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.PagerEnabled = false;
            toolStrip1.BackColor = Color.Black;
            toolStripNodes.BackColor = Color.Black;

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
            Properties.Settings.Default.ConnectToBbs = "disconnected";
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
                            STW = new StreamWriter(client.GetStream());
                            STR = new StreamReader(client.GetStream());
                            STW.AutoFlush = true;
                            backgroundWorker1.RunWorkerAsync();
                            backgroundWorker2.WorkerSupportsCancellation = true;
                            timerGetStatus.Enabled = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                // Disconnect
                timerGetStatus.Enabled = false;
                TextToSend = "QUIT";
                backgroundWorker2.RunWorkerAsync();
                Properties.Settings.Default.ConnectToBbs = "disconnected";
                toolStripButtonConnect.Image = Properties.Resources.icons8_disconnected_nolan_50;
                Properties.Settings.Default.PagerEnabled = false;
                toolStripButtonEnablePager.Image = Properties.Resources.red_circle;
                toolStripButtonEnablePager.Text = "Enable Pager";
                enablePagerToolStripMenuItem.Text = "Enable Pager";

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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                    /*this.StatustextBox.Invoke(new MethodInvoker(delegate ()
                    {
                        StatustextBox.AppendText("Server:" + receive + "\n");
                    }));
                    receive = "";*/
                    if(receive.Substring(0, 5)=="PAGER")
                    {
                        setpagerstatus(receive.Split('.')[0]);
                        parsenodes(receive.Split('.')[1]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                STW.WriteLine(TextToSend);
                /*this.StatustextBox.Invoke(new MethodInvoker(delegate ()
                {
                    StatustextBox.AppendText("Client:" + TextToSend + "\n");
                }));*/
            }
            else
            {
                MessageBox.Show("Sending failed");
            }
            backgroundWorker2.CancelAsync();
        }

        private void timerGetStatus_Tick(object sender, EventArgs e)
        {
            TextToSend = "CHAT STATUS";
            backgroundWorker2.RunWorkerAsync();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frmAbout = new About();
            frmAbout.ShowDialog();
        }

        private void setpagerstatus(string pagerstring)
        {
            if (pagerstring.Split(':')[1] == "ENABLED")
            {
                if (Properties.Settings.Default.PagerEnabled == false)
                {
                    Properties.Settings.Default.PagerEnabled = true;
                    toolStripButtonEnablePager.Image = Properties.Resources.green_circle;
                    toolStripButtonEnablePager.Text = "Disable Pager";
                    this.contextMenuStrip1.Invoke(new MethodInvoker(delegate ()
                    {
                        enablePagerToolStripMenuItem.Text = "Disable Pager";
                    }));
                }
            }
            else
            {
                if (Properties.Settings.Default.PagerEnabled == true)
                {
                    Properties.Settings.Default.PagerEnabled = false;
                    toolStripButtonEnablePager.Image = Properties.Resources.red_circle;
                    toolStripButtonEnablePager.Text = "Enable Pager";
                    this.contextMenuStrip1.Invoke(new MethodInvoker(delegate ()
                    {
                        enablePagerToolStripMenuItem.Text = "Enable Pager";
                    }));
                }
            }
        }

        private void parsenodes(string nodestring)
        {
            char separator = '.';
            char nodeseparator = ';';
            char statseparator = ',';

            string[] tempstring = nodestring.Split(':');
            string[] nodestrings = tempstring[1].Split(nodeseparator);

            Node[] status = new Node[nodestrings.Length];
            // format: NODES:nodenumber,nodestatusnumber,useron,nodestatusdescription
            for (int i = 0; i < nodestrings.Length; i++)
            {
                status[i].nodenumber = nodestrings[i].Split(statseparator)[0];
                status[i].nodestatusnumber = nodestrings[i].Split(statseparator)[1];
                status[i].useron = nodestrings[i].Split(statseparator)[2];
                status[i].nodestatusdescription = nodestrings[i].Split(statseparator)[3];
                // visual node status
            }
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
            backgroundWorker2.RunWorkerAsync();
        }

        private void toolStripButtonEnablePager_Click(object sender, EventArgs e)
        {
            enablePagerToolStripMenuItem_Click(sender, e);
        }
    }
}
