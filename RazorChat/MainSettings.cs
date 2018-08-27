using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RazorChat
{
    public partial class MainSettings : Form
    {
        public MainSettings()
        {
            InitializeComponent();
        }

        private void MainSettings_Load(object sender, EventArgs e)
        {
            // populate audio file dropdown
            var audiofiles = typeof(Properties.Resources)
                .GetProperties(System.Reflection.BindingFlags.Static |
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public)
                .Where(p => p.PropertyType == typeof(UnmanagedMemoryStream))
                .Select(x => new { Name = x.Name, Audio = x.GetValue(null, null) })
                .ToList();
            for(int i=0; i<audiofiles.Count; i++)
            {
                comboBoxAudioFile.Items.Add(audiofiles[i].Name);
            }

            textHost.Text = Properties.Settings.Default.BbsHostOrIp;
            textPagerPort.Text = Properties.Settings.Default.PagerPort;
            textChatPort.Text = Properties.Settings.Default.ChatPort;
            // don't fill in username if it wasn't filled in here originally
            if (Properties.Settings.Default.UsernameSavedOnMain==true)
            {
                textSysopUsername.Text = Properties.Settings.Default.SysopUsername;
            }
            // don't fill in passwords if they weren't filled in here originally
            if (Properties.Settings.Default.PasswordsSavedOnMain==true)
            {
                textPassword.Text = Properties.Settings.Default.SysopPassword;
                textSysPassword.Text = Properties.Settings.Default.SystemPassword;
            }
            checkBoxVisualPaging.Checked = Properties.Settings.Default.VisualPagingEnabled;
            checkBoxAudioPaging.Checked = Properties.Settings.Default.AudioPagingEnabled;
            checkBoxExternalPaging.Checked = Properties.Settings.Default.ExternalPagingEnabled;
            comboBoxAudioFile.Text = Properties.Settings.Default.AudioPageFile;
            textBoxExtPageCommand.Text = Properties.Settings.Default.ExternalPageCommand;
            textBoxExtPageOptions.Text = Properties.Settings.Default.ExternalPageOptions;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // set UsernameSavedOnMain false if it was left blank
            if(textSysopUsername.Text=="")
            {
                Properties.Settings.Default.UsernameSavedOnMain = false;
            }
            else
            {
                Properties.Settings.Default.UsernameSavedOnMain = true;
            }
            // set PasswordsSavedOnMain false if either field is left blank
            if(textPassword.Text=="" || textSysPassword.Text=="")
            {
                Properties.Settings.Default.PasswordsSavedOnMain = false;
            }
            else
            {
                Properties.Settings.Default.PasswordsSavedOnMain = true;
            }
            // fill in the default port if left blank
            Properties.Settings.Default.BbsHostOrIp = textHost.Text;
            if (textPagerPort.Text != "")
            {
                Properties.Settings.Default.PagerPort = textPagerPort.Text;
            }
            else
            {
                Properties.Settings.Default.PagerPort = "10005";
            }
            if(textChatPort.Text != "")
            {
                Properties.Settings.Default.ChatPort = textChatPort.Text;
            }
            else
            {
                Properties.Settings.Default.ChatPort = "10006";
            }
            Properties.Settings.Default.SysopUsername = textSysopUsername.Text;
            Properties.Settings.Default.SysopPassword = textPassword.Text;
            Properties.Settings.Default.SystemPassword = textSysPassword.Text;
            Properties.Settings.Default.VisualPagingEnabled = checkBoxVisualPaging.Checked;
            Properties.Settings.Default.AudioPagingEnabled = checkBoxAudioPaging.Checked;
            Properties.Settings.Default.ExternalPagingEnabled = checkBoxExternalPaging.Checked;
            Properties.Settings.Default.AudioPageFile = comboBoxAudioFile.Text;
            Properties.Settings.Default.ExternalPageCommand = textBoxExtPageCommand.Text;
            Properties.Settings.Default.ExternalPageOptions = textBoxExtPageOptions.Text;

            if(Properties.Settings.Default.ConnectToBbs=="connecting")
            {
                if(Properties.Settings.Default.BbsHostOrIp=="" || Properties.Settings.Default.PagerPort=="")
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

        private void buttonRevealPassword_Click(object sender, EventArgs e)
        {
            if (textPassword.PasswordChar == '*')
            {
                textPassword.PasswordChar = '\0';
                buttonRevealPassword.BackgroundImage = Properties.Resources.icons8_invisible_win10_50;
            }
            else
            {
                textPassword.PasswordChar = '*';
                buttonRevealPassword.BackgroundImage = Properties.Resources.icons8_eye_win10_50;
            }
        }

        private void buttonRevealSysPassword_Click(object sender, EventArgs e)
        {
            if (textSysPassword.PasswordChar == '*')
            {
                textSysPassword.PasswordChar = '\0';
                buttonRevealSysPassword.BackgroundImage = Properties.Resources.icons8_invisible_win10_50;
            }
            else
            {
                textSysPassword.PasswordChar = '*';
                buttonRevealSysPassword.BackgroundImage = Properties.Resources.icons8_eye_win10_50;
            }
        }

        private void buttonPlayAudioFile_Click(object sender, EventArgs e)
        {
            var audioresource = Properties.Resources.ResourceManager.GetObject(comboBoxAudioFile.Text);
            Stream str = (Stream)audioresource;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        private void checkBoxAudioPaging_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAudioPaging.Checked==true)
            {
                comboBoxAudioFile.Enabled = true;
                buttonPlayAudioFile.Enabled = true;
            }
            else
            {
                comboBoxAudioFile.Enabled = false;
                buttonPlayAudioFile.Enabled = false;
            }
        }

        private void checkBoxExternalPaging_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxExternalPaging.Checked==true)
            {
                textBoxExtPageCommand.Enabled = true;
                textBoxExtPageOptions.Enabled = true;
            }
            else
            {
                textBoxExtPageCommand.Enabled = false;
                textBoxExtPageOptions.Enabled = false;
            }
        }

        private void buttonDisplayInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The first command box should point to an executable that can pass " +
                "notification messages on the command line to your external notifier. The second " +
                "box should contain the command line arguments to pass to the notifier. In your " +
                "arguments, %t will be replaced by the title Razorpage & %m will be replaced by " +
                "a message like 'Razor paging from node 1'. Depending on your what your " +
                "notification setup is, it may be helpful to reverse the title & message " +
                "(send the message as the title & vice versa).");
        }
    }
}
