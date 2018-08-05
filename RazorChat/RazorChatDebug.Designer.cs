namespace RazorChat
{
    partial class RazorChatDebug
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
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.PEnableButton = new System.Windows.Forms.Button();
            this.PDisableButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.HostNametextBox = new System.Windows.Forms.TextBox();
            this.StatustextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.CStatusButton = new System.Windows.Forms.Button();
            this.timerGetStatus = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSyspass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(13, 13);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(98, 23);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(13, 43);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(98, 23);
            this.DisconnectButton.TabIndex = 1;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // PEnableButton
            // 
            this.PEnableButton.Location = new System.Drawing.Point(205, 12);
            this.PEnableButton.Name = "PEnableButton";
            this.PEnableButton.Size = new System.Drawing.Size(98, 23);
            this.PEnableButton.TabIndex = 2;
            this.PEnableButton.Text = "PAGE ENABLE";
            this.PEnableButton.UseVisualStyleBackColor = true;
            this.PEnableButton.Click += new System.EventHandler(this.PEnableButton_Click);
            // 
            // PDisableButton
            // 
            this.PDisableButton.Location = new System.Drawing.Point(205, 42);
            this.PDisableButton.Name = "PDisableButton";
            this.PDisableButton.Size = new System.Drawing.Size(97, 23);
            this.PDisableButton.TabIndex = 3;
            this.PDisableButton.Text = "PAGE DISABLE";
            this.PDisableButton.UseVisualStyleBackColor = true;
            this.PDisableButton.Click += new System.EventHandler(this.PDisableButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Host";
            // 
            // HostNametextBox
            // 
            this.HostNametextBox.Location = new System.Drawing.Point(118, 45);
            this.HostNametextBox.Name = "HostNametextBox";
            this.HostNametextBox.Size = new System.Drawing.Size(81, 20);
            this.HostNametextBox.TabIndex = 5;
            this.HostNametextBox.Text = "bbs";
            // 
            // StatustextBox
            // 
            this.StatustextBox.Location = new System.Drawing.Point(12, 168);
            this.StatustextBox.Multiline = true;
            this.StatustextBox.Name = "StatustextBox";
            this.StatustextBox.Size = new System.Drawing.Size(290, 199);
            this.StatustextBox.TabIndex = 6;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // CStatusButton
            // 
            this.CStatusButton.Location = new System.Drawing.Point(205, 72);
            this.CStatusButton.Name = "CStatusButton";
            this.CStatusButton.Size = new System.Drawing.Size(97, 23);
            this.CStatusButton.TabIndex = 7;
            this.CStatusButton.Text = "CHAT STATUS";
            this.CStatusButton.UseVisualStyleBackColor = true;
            this.CStatusButton.Click += new System.EventHandler(this.CStatusButton_Click);
            // 
            // timerGetStatus
            // 
            this.timerGetStatus.Interval = 15000;
            this.timerGetStatus.Tick += new System.EventHandler(this.timerGetStatus_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Username";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(118, 74);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(81, 20);
            this.textBoxUsername.TabIndex = 9;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(118, 103);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(81, 20);
            this.textBoxPassword.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password";
            // 
            // textBoxSyspass
            // 
            this.textBoxSyspass.Location = new System.Drawing.Point(118, 130);
            this.textBoxSyspass.Name = "textBoxSyspass";
            this.textBoxSyspass.Size = new System.Drawing.Size(81, 20);
            this.textBoxSyspass.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Syspass";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(206, 101);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(96, 23);
            this.LoginButton.TabIndex = 15;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RazorChatDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 379);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSyspass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CStatusButton);
            this.Controls.Add(this.StatustextBox);
            this.Controls.Add(this.HostNametextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PDisableButton);
            this.Controls.Add(this.PEnableButton);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Name = "RazorChatDebug";
            this.Text = "RazorChat debug";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Button PEnableButton;
        private System.Windows.Forms.Button PDisableButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HostNametextBox;
        private System.Windows.Forms.TextBox StatustextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button CStatusButton;
        private System.Windows.Forms.Timer timerGetStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSyspass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LoginButton;
    }
}

