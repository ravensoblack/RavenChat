using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// this should only display if Sysop doesn't leaves the login info blank on MainSettings
// add a setting to indicate whether they fill in the one on MainForm
// if they didn't, store in Settings, but then clear it from Settings before Saving them

namespace RazorChat
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SysopUsername = textSysopUsername.Text;
            Properties.Settings.Default.SysopPassword = textSysPassword.Text;
            Properties.Settings.Default.SystemPassword = textSysPassword.Text;

            if (Properties.Settings.Default.ConnectToBbs == "connecting")
            {
                if(Properties.Settings.Default.SysopUsername=="" || Properties.Settings.Default.SysopPassword=="" || Properties.Settings.Default.SystemPassword=="")
                {
                    Properties.Settings.Default.ConnectToBbs = "disconnected";
                }
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ConnectToBbs = "disconnected";
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.UsernameSavedOnMain==true)
            {
                textSysopUsername.Text = Properties.Settings.Default.SysopUsername;
            }
            if(Properties.Settings.Default.PasswordsSavedOnMain==true)
            {
                textPassword.Text = Properties.Settings.Default.SysopPassword;
                textSysPassword.Text = Properties.Settings.Default.SystemPassword;
            }
        }
    }
}
