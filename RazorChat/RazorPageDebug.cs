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

namespace RazorChat
{
    // format: NODES:nodenumber,nodestatusnumber,useron,nodestatusdescription
    public struct NodeDebug
    {
        public string nodenumber, nodestatusnumber, useron, nodestatusdescription;
    }

    public partial class RazorPageDebug : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public String TextToSend;

        public RazorPageDebug()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            StatustextBox.Text = "";
            client = new TcpClient();
            IPHostEntry host;
            host = Dns.GetHostEntry(HostNametextBox.Text);
            IPEndPoint IpEnd = new IPEndPoint(host.AddressList[0], int.Parse("10005"));
            try
            {
                client.Connect(IpEnd);

                if (client.Connected)
                {
                    StatustextBox.AppendText("Connected to server" + "\n");
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;
                    //timerGetStatus.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                    this.StatustextBox.Invoke(new MethodInvoker(delegate ()
                        {
                            StatustextBox.AppendText("Server:" + receive + "\n");
                        }));
                    if (receive.Substring(0, 5) == "PAGER")
                    {
                        //setpagerstatus(receive.Split('.')[0]);
                        //parsenodes(receive.Split('.')[1]);
                    }
                    receive = "";
                }
                catch(Exception ex)
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
                this.StatustextBox.Invoke(new MethodInvoker(delegate ()
                {
                    StatustextBox.AppendText("Client:" + TextToSend + "\n");
                }));
            }
            else
            {
                MessageBox.Show("Sending failed");
            }
            backgroundWorker2.CancelAsync();
        }

        private void PEnableButton_Click(object sender, EventArgs e)
        {
            TextToSend = "PAGE ENABLE";
            backgroundWorker2.RunWorkerAsync();
        }

        private void PDisableButton_Click(object sender, EventArgs e)
        {
            TextToSend = "PAGE DISABLE";
            backgroundWorker2.RunWorkerAsync();
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            timerGetStatus.Enabled = false;
            TextToSend = "QUIT";
            backgroundWorker2.RunWorkerAsync();
            client.Close();
        }

        private void CStatusButton_Click(object sender, EventArgs e)
        {
            TextToSend = "CHAT STATUS";
            backgroundWorker2.RunWorkerAsync();
        }

        private void timerGetStatus_Tick(object sender, EventArgs e)
        {
            TextToSend = "CHAT STATUS";
            backgroundWorker2.RunWorkerAsync();
        }

        private void setpagerstatus(string pagerstring)
        {
            if(pagerstring.Split(':')[1]=="ENABLED")
            {
                Properties.Settings.Default.PagerEnabled = true;
                // set visual indicator
            }
            else
            {
                Properties.Settings.Default.PagerEnabled = false;
                // set visual indicator
            }
        }

        private void parsenodes(string nodestring)
        {
            char separator = '.';
            char nodeseparator = ';';
            char statseparator = ',';

            string[] tempstring = nodestring.Split(':');
            string[] nodestrings = tempstring[1].Split(nodeseparator);

            NodeDebug[] status = new NodeDebug[nodestrings.Length];
            // format: NODES:nodenumber,nodestatusnumber,useron,nodestatusdescription
            for (int i=0; i<nodestrings.Length; i++)
            {
                status[i].nodenumber = nodestrings[i].Split(statseparator)[0];
                status[i].nodestatusnumber = nodestrings[i].Split(statseparator)[1];
                status[i].useron = nodestrings[i].Split(statseparator)[2];
                status[i].nodestatusdescription = nodestrings[i].Split(statseparator)[3];
                // visual node status
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // The authentication command will be "AUTHINFO username password syspass"
            TextToSend = "AUTHINFO " + textBoxUsername.Text + " " + textBoxPassword.Text + " " + textBoxSyspass.Text;
            backgroundWorker2.RunWorkerAsync();
        }

        private void RazorPageDebug_Load(object sender, EventArgs e)
        {

        }
    }
}
