namespace RazorChat
{
    partial class RazorPage
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEnablePager = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStatus = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDebugPager = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enablePagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerGetStatus = new System.Windows.Forms.Timer(this.components);
            this.toolStripNodes = new System.Windows.Forms.ToolStrip();
            this.backgroundWorkerReceive = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSend = new System.ComponentModel.BackgroundWorker();
            this.toolStripButtonDebugChat = new System.Windows.Forms.ToolStripButton();
            this.debugChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonConnect,
            this.toolStripButtonEnablePager,
            this.toolStripButtonSettings,
            this.toolStripButtonStatus,
            this.toolStripButtonDebugPager,
            this.toolStripButtonDebugChat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonConnect
            // 
            this.toolStripButtonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConnect.Image = global::RazorChat.Properties.Resources.icons8_disconnected_nolan_50;
            this.toolStripButtonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConnect.Name = "toolStripButtonConnect";
            this.toolStripButtonConnect.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonConnect.Text = "Connect";
            this.toolStripButtonConnect.Click += new System.EventHandler(this.toolStripButtonConnect_Click);
            // 
            // toolStripButtonEnablePager
            // 
            this.toolStripButtonEnablePager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEnablePager.Enabled = false;
            this.toolStripButtonEnablePager.Image = global::RazorChat.Properties.Resources.red_circle;
            this.toolStripButtonEnablePager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEnablePager.Name = "toolStripButtonEnablePager";
            this.toolStripButtonEnablePager.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonEnablePager.Text = "Enable Pager";
            this.toolStripButtonEnablePager.Click += new System.EventHandler(this.toolStripButtonEnablePager_Click);
            // 
            // toolStripButtonSettings
            // 
            this.toolStripButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSettings.Image = global::RazorChat.Properties.Resources.icons8_settings_nolan_50;
            this.toolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSettings.Name = "toolStripButtonSettings";
            this.toolStripButtonSettings.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSettings.Text = "Settings";
            this.toolStripButtonSettings.Click += new System.EventHandler(this.toolStripButtonSettings_Click);
            // 
            // toolStripButtonStatus
            // 
            this.toolStripButtonStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStatus.Image = global::RazorChat.Properties.Resources.icons8_bug_nolan_50;
            this.toolStripButtonStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStatus.Name = "toolStripButtonStatus";
            this.toolStripButtonStatus.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonStatus.Text = "CHAT STATUS";
            this.toolStripButtonStatus.Visible = false;
            this.toolStripButtonStatus.Click += new System.EventHandler(this.toolStripButtonStatus_Click);
            // 
            // toolStripButtonDebugPager
            // 
            this.toolStripButtonDebugPager.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDebugPager.Image = global::RazorChat.Properties.Resources.icons8_bug_nolan_50;
            this.toolStripButtonDebugPager.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDebugPager.Name = "toolStripButtonDebugPager";
            this.toolStripButtonDebugPager.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonDebugPager.Text = "Debug Pager";
            this.toolStripButtonDebugPager.Visible = false;
            this.toolStripButtonDebugPager.Click += new System.EventHandler(this.toolStripButtonDebug_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.enablePagerToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.debugChatToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 136);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // enablePagerToolStripMenuItem
            // 
            this.enablePagerToolStripMenuItem.Enabled = false;
            this.enablePagerToolStripMenuItem.Name = "enablePagerToolStripMenuItem";
            this.enablePagerToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.enablePagerToolStripMenuItem.Text = "Enable Pager";
            this.enablePagerToolStripMenuItem.Click += new System.EventHandler(this.enablePagerToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.debugToolStripMenuItem.Text = "Debug Pager";
            this.debugToolStripMenuItem.Visible = false;
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // timerGetStatus
            // 
            this.timerGetStatus.Interval = 5000;
            this.timerGetStatus.Tick += new System.EventHandler(this.timerGetStatus_Tick);
            // 
            // toolStripNodes
            // 
            this.toolStripNodes.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripNodes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripNodes.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripNodes.Location = new System.Drawing.Point(0, 39);
            this.toolStripNodes.Name = "toolStripNodes";
            this.toolStripNodes.ShowItemToolTips = false;
            this.toolStripNodes.Size = new System.Drawing.Size(26, 142);
            this.toolStripNodes.TabIndex = 0;
            this.toolStripNodes.Text = "toolStrip2";
            // 
            // backgroundWorkerReceive
            // 
            this.backgroundWorkerReceive.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReceive_DoWork);
            this.backgroundWorkerReceive.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerReceive_ProgressChanged);
            this.backgroundWorkerReceive.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerReceive_RunWorkerCompleted);
            // 
            // backgroundWorkerSend
            // 
            this.backgroundWorkerSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSend_DoWork);
            // 
            // toolStripButtonDebugChat
            // 
            this.toolStripButtonDebugChat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDebugChat.Image = global::RazorChat.Properties.Resources.icons8_bug_nolan_50;
            this.toolStripButtonDebugChat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDebugChat.Name = "toolStripButtonDebugChat";
            this.toolStripButtonDebugChat.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonDebugChat.Text = "Debug Chat";
            this.toolStripButtonDebugChat.Visible = false;
            this.toolStripButtonDebugChat.Click += new System.EventHandler(this.toolStripButtonDebugChat_Click);
            // 
            // debugChatToolStripMenuItem
            // 
            this.debugChatToolStripMenuItem.Name = "debugChatToolStripMenuItem";
            this.debugChatToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.debugChatToolStripMenuItem.Text = "Debug Chat";
            this.debugChatToolStripMenuItem.Visible = false;
            this.debugChatToolStripMenuItem.Click += new System.EventHandler(this.debugChatToolStripMenuItem_Click);
            // 
            // RazorPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.toolStripNodes);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "RazorPage";
            this.Text = "RazorPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RazorPage_FormClosing);
            this.Load += new System.EventHandler(this.RazorPage_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonConnect;
        private System.Windows.Forms.ToolStripButton toolStripButtonSettings;
        private System.Windows.Forms.ToolStripButton toolStripButtonDebugPager;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.Timer timerGetStatus;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripNodes;
        private System.Windows.Forms.ToolStripButton toolStripButtonEnablePager;
        private System.Windows.Forms.ToolStripMenuItem enablePagerToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReceive;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSend;
        private System.Windows.Forms.ToolStripButton toolStripButtonStatus;
        private System.Windows.Forms.ToolStripButton toolStripButtonDebugChat;
        private System.Windows.Forms.ToolStripMenuItem debugChatToolStripMenuItem;
    }
}