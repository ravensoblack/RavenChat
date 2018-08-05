namespace RazorChat
{
    partial class MainSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textSysopUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textSysPassword = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textHost = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.checkBoxVisualPaging = new System.Windows.Forms.CheckBox();
            this.checkBoxAudioPaging = new System.Windows.Forms.CheckBox();
            this.checkBoxExternalPaging = new System.Windows.Forms.CheckBox();
            this.comboBoxAudioFile = new System.Windows.Forms.ComboBox();
            this.textBoxExtPageCommand = new System.Windows.Forms.TextBox();
            this.buttonDisplayInfo = new System.Windows.Forms.Button();
            this.buttonPlayAudioFile = new System.Windows.Forms.Button();
            this.buttonRevealSysPassword = new System.Windows.Forms.Button();
            this.buttonRevealPassword = new System.Windows.Forms.Button();
            this.textBoxExtPageOptions = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sysop username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "System password";
            // 
            // textSysopUsername
            // 
            this.textSysopUsername.Location = new System.Drawing.Point(335, 13);
            this.textSysopUsername.Name = "textSysopUsername";
            this.textSysopUsername.Size = new System.Drawing.Size(100, 20);
            this.textSysopUsername.TabIndex = 3;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(336, 39);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(100, 20);
            this.textPassword.TabIndex = 4;
            // 
            // textSysPassword
            // 
            this.textSysPassword.Location = new System.Drawing.Point(336, 65);
            this.textSysPassword.Name = "textSysPassword";
            this.textSysPassword.PasswordChar = '*';
            this.textSysPassword.Size = new System.Drawing.Size(100, 20);
            this.textSysPassword.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(120, 160);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(278, 160);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "BBS host/IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Port";
            // 
            // textHost
            // 
            this.textHost.Location = new System.Drawing.Point(109, 13);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(100, 20);
            this.textHost.TabIndex = 1;
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(109, 39);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(100, 20);
            this.textPort.TabIndex = 2;
            // 
            // checkBoxVisualPaging
            // 
            this.checkBoxVisualPaging.AutoSize = true;
            this.checkBoxVisualPaging.Enabled = false;
            this.checkBoxVisualPaging.Location = new System.Drawing.Point(15, 80);
            this.checkBoxVisualPaging.Name = "checkBoxVisualPaging";
            this.checkBoxVisualPaging.Size = new System.Drawing.Size(89, 17);
            this.checkBoxVisualPaging.TabIndex = 6;
            this.checkBoxVisualPaging.Text = "Visual paging";
            this.checkBoxVisualPaging.UseVisualStyleBackColor = true;
            // 
            // checkBoxAudioPaging
            // 
            this.checkBoxAudioPaging.AutoSize = true;
            this.checkBoxAudioPaging.Location = new System.Drawing.Point(15, 104);
            this.checkBoxAudioPaging.Name = "checkBoxAudioPaging";
            this.checkBoxAudioPaging.Size = new System.Drawing.Size(88, 17);
            this.checkBoxAudioPaging.TabIndex = 7;
            this.checkBoxAudioPaging.Text = "Audio paging";
            this.checkBoxAudioPaging.UseVisualStyleBackColor = true;
            this.checkBoxAudioPaging.CheckedChanged += new System.EventHandler(this.checkBoxAudioPaging_CheckedChanged);
            // 
            // checkBoxExternalPaging
            // 
            this.checkBoxExternalPaging.AutoSize = true;
            this.checkBoxExternalPaging.Location = new System.Drawing.Point(15, 128);
            this.checkBoxExternalPaging.Name = "checkBoxExternalPaging";
            this.checkBoxExternalPaging.Size = new System.Drawing.Size(155, 17);
            this.checkBoxExternalPaging.TabIndex = 8;
            this.checkBoxExternalPaging.Text = "External paging/notification";
            this.checkBoxExternalPaging.UseVisualStyleBackColor = true;
            this.checkBoxExternalPaging.CheckedChanged += new System.EventHandler(this.checkBoxExternalPaging_CheckedChanged);
            // 
            // comboBoxAudioFile
            // 
            this.comboBoxAudioFile.Enabled = false;
            this.comboBoxAudioFile.FormattingEnabled = true;
            this.comboBoxAudioFile.Location = new System.Drawing.Point(133, 101);
            this.comboBoxAudioFile.MaxDropDownItems = 21;
            this.comboBoxAudioFile.Name = "comboBoxAudioFile";
            this.comboBoxAudioFile.Size = new System.Drawing.Size(260, 21);
            this.comboBoxAudioFile.TabIndex = 9;
            // 
            // textBoxExtPageCommand
            // 
            this.textBoxExtPageCommand.Enabled = false;
            this.textBoxExtPageCommand.Location = new System.Drawing.Point(176, 128);
            this.textBoxExtPageCommand.Name = "textBoxExtPageCommand";
            this.textBoxExtPageCommand.Size = new System.Drawing.Size(105, 20);
            this.textBoxExtPageCommand.TabIndex = 10;
            this.toolTip1.SetToolTip(this.textBoxExtPageCommand, "Command");
            // 
            // buttonDisplayInfo
            // 
            this.buttonDisplayInfo.BackgroundImage = global::RazorChat.Properties.Resources.icons8_info_win10_50;
            this.buttonDisplayInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDisplayInfo.Location = new System.Drawing.Point(400, 124);
            this.buttonDisplayInfo.Name = "buttonDisplayInfo";
            this.buttonDisplayInfo.Size = new System.Drawing.Size(23, 23);
            this.buttonDisplayInfo.TabIndex = 16;
            this.buttonDisplayInfo.UseVisualStyleBackColor = true;
            this.buttonDisplayInfo.Click += new System.EventHandler(this.buttonDisplayInfo_Click);
            // 
            // buttonPlayAudioFile
            // 
            this.buttonPlayAudioFile.BackgroundImage = global::RazorChat.Properties.Resources.icons8_play_win10_50;
            this.buttonPlayAudioFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlayAudioFile.Enabled = false;
            this.buttonPlayAudioFile.Location = new System.Drawing.Point(400, 98);
            this.buttonPlayAudioFile.Name = "buttonPlayAudioFile";
            this.buttonPlayAudioFile.Size = new System.Drawing.Size(23, 23);
            this.buttonPlayAudioFile.TabIndex = 15;
            this.buttonPlayAudioFile.UseVisualStyleBackColor = true;
            this.buttonPlayAudioFile.Click += new System.EventHandler(this.buttonPlayAudioFile_Click);
            // 
            // buttonRevealSysPassword
            // 
            this.buttonRevealSysPassword.BackgroundImage = global::RazorChat.Properties.Resources.icons8_eye_win10_50;
            this.buttonRevealSysPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRevealSysPassword.Location = new System.Drawing.Point(442, 65);
            this.buttonRevealSysPassword.Name = "buttonRevealSysPassword";
            this.buttonRevealSysPassword.Size = new System.Drawing.Size(23, 23);
            this.buttonRevealSysPassword.TabIndex = 14;
            this.buttonRevealSysPassword.UseVisualStyleBackColor = true;
            this.buttonRevealSysPassword.Click += new System.EventHandler(this.buttonRevealSysPassword_Click);
            // 
            // buttonRevealPassword
            // 
            this.buttonRevealPassword.BackgroundImage = global::RazorChat.Properties.Resources.icons8_eye_win10_50;
            this.buttonRevealPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRevealPassword.Location = new System.Drawing.Point(442, 37);
            this.buttonRevealPassword.Name = "buttonRevealPassword";
            this.buttonRevealPassword.Size = new System.Drawing.Size(23, 23);
            this.buttonRevealPassword.TabIndex = 13;
            this.buttonRevealPassword.UseVisualStyleBackColor = true;
            this.buttonRevealPassword.Click += new System.EventHandler(this.buttonRevealPassword_Click);
            // 
            // textBoxExtPageOptions
            // 
            this.textBoxExtPageOptions.Enabled = false;
            this.textBoxExtPageOptions.Location = new System.Drawing.Point(287, 127);
            this.textBoxExtPageOptions.Name = "textBoxExtPageOptions";
            this.textBoxExtPageOptions.Size = new System.Drawing.Size(105, 20);
            this.textBoxExtPageOptions.TabIndex = 11;
            this.toolTip1.SetToolTip(this.textBoxExtPageOptions, "Arguments: %t is Title, %m is Message");
            // 
            // MainSettings
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(478, 193);
            this.Controls.Add(this.textBoxExtPageOptions);
            this.Controls.Add(this.buttonDisplayInfo);
            this.Controls.Add(this.textBoxExtPageCommand);
            this.Controls.Add(this.buttonPlayAudioFile);
            this.Controls.Add(this.comboBoxAudioFile);
            this.Controls.Add(this.checkBoxExternalPaging);
            this.Controls.Add(this.checkBoxAudioPaging);
            this.Controls.Add(this.checkBoxVisualPaging);
            this.Controls.Add(this.buttonRevealSysPassword);
            this.Controls.Add(this.buttonRevealPassword);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.textHost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textSysPassword);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textSysopUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainSettings";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.MainSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textSysopUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textSysPassword;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textHost;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Button buttonRevealPassword;
        private System.Windows.Forms.Button buttonRevealSysPassword;
        private System.Windows.Forms.CheckBox checkBoxVisualPaging;
        private System.Windows.Forms.CheckBox checkBoxAudioPaging;
        private System.Windows.Forms.CheckBox checkBoxExternalPaging;
        private System.Windows.Forms.ComboBox comboBoxAudioFile;
        private System.Windows.Forms.Button buttonPlayAudioFile;
        private System.Windows.Forms.TextBox textBoxExtPageCommand;
        private System.Windows.Forms.Button buttonDisplayInfo;
        private System.Windows.Forms.TextBox textBoxExtPageOptions;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}