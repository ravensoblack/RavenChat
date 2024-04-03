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
    public partial class RazorChatDebug : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public String TextToSend;

        public RazorChatDebug()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ChattextBox.Text = "";
            client = new TcpClient();
            IPHostEntry host;
            host = Dns.GetHostEntry(textBoxHostname.Text);
            IPEndPoint IpEnd = new IPEndPoint(host.AddressList[0], int.Parse("10006"));
            try
            {
                client.Connect(IpEnd);

                if (client.Connected)
                {
                    ChattextBox.AppendText("Connected to server" + "\n");
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                    this.ChattextBox.Invoke(new MethodInvoker(delegate ()
                    {
                        ChattextBox.AppendText("Server:" + receive + "\n");
                    }));
                    receive = "";
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
                this.ChattextBox.Invoke(new MethodInvoker(delegate ()
                {
                    ChattextBox.AppendText("Client:" + TextToSend + "\n");
                }));
            }
            else
            {
                MessageBox.Show("Sending failed");
            }
            backgroundWorker2.CancelAsync();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // The authentication command will be "AUTHINFO username password syspass"
            TextToSend = "AUTHINFO " + textBoxUsername.Text + " " + textBoxPassword.Text + " " + textBoxSyspass.Text;
            backgroundWorker2.RunWorkerAsync();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            TextToSend = "QUIT";
            backgroundWorker2.RunWorkerAsync();
            client.Close();
        }

        private void TChatButton_Click(object sender, EventArgs e)
        {
            TextToSend = "CHAT MESSAGE NODE:1.Test message";
            backgroundWorker2.RunWorkerAsync();
        }

        private void SChatButton_Click(object sender, EventArgs e)
        {
            TextToSend = "CHAT START NODE:1";
            backgroundWorker2.RunWorkerAsync();
        }

        private void RazorChatDebug_Load(object sender, EventArgs e)
        {

        }
    }
}
