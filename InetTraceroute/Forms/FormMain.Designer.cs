namespace InetTraceroute.Forms
{
	partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.statusLabelLeft = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelMiddle = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelRight = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelRun = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl = new DotNetApi.Windows.Controls.ThemeTabControl();
			this.tabPageNetwork = new System.Windows.Forms.TabPage();
			this.tabPageTraceroute = new System.Windows.Forms.TabPage();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.toolSplitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.controlLog = new InetAnalytics.Controls.Log.ControlLogList();
			this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.toolSplitContainer)).BeginInit();
			this.toolSplitContainer.Panel1.SuspendLayout();
			this.toolSplitContainer.Panel2.SuspendLayout();
			this.toolSplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer
			// 
			// 
			// toolStripContainer.BottomToolStripPanel
			// 
			this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
			// 
			// toolStripContainer.ContentPanel
			// 
			this.toolStripContainer.ContentPanel.Controls.Add(this.toolSplitContainer);
			this.toolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(5);
			this.toolStripContainer.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(784, 516);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new System.Drawing.Size(784, 562);
			this.toolStripContainer.TabIndex = 0;
			this.toolStripContainer.Text = "toolStripContainer1";
			// 
			// toolStripContainer.TopToolStripPanel
			// 
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
			// 
			// statusStrip
			// 
			this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelLeft,
            this.statusProgress,
            this.statusLabelMiddle,
            this.statusLabelRight,
            this.statusLabelRun});
			this.statusStrip.Location = new System.Drawing.Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.ShowItemToolTips = true;
			this.statusStrip.Size = new System.Drawing.Size(784, 22);
			this.statusStrip.TabIndex = 1;
			// 
			// statusLabelLeft
			// 
			this.statusLabelLeft.Image = global::InetTraceroute.Resources.Information_16;
			this.statusLabelLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.statusLabelLeft.Name = "statusLabelLeft";
			this.statusLabelLeft.Size = new System.Drawing.Size(55, 17);
			this.statusLabelLeft.Text = "Ready";
			// 
			// statusLabelMiddle
			// 
			this.statusLabelMiddle.Name = "statusLabelMiddle";
			this.statusLabelMiddle.Size = new System.Drawing.Size(579, 17);
			this.statusLabelMiddle.Spring = true;
			// 
			// statusLabelRight
			// 
			this.statusLabelRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.statusLabelRight.Name = "statusLabelRight";
			this.statusLabelRight.Size = new System.Drawing.Size(0, 17);
			// 
			// statusLabelRun
			// 
			this.statusLabelRun.Image = global::InetTraceroute.Resources.RunConcurrentStop_16;
			this.statusLabelRun.Name = "statusLabelRun";
			this.statusLabelRun.Size = new System.Drawing.Size(135, 17);
			this.statusLabelRun.Text = "No background tasks";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageNetwork);
			this.tabControl.Controls.Add(this.tabPageTraceroute);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(774, 326);
			this.tabControl.TabIndex = 0;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.OnTabChanged);
			// 
			// tabPageNetwork
			// 
			this.tabPageNetwork.Location = new System.Drawing.Point(2, 23);
			this.tabPageNetwork.Name = "tabPageNetwork";
			this.tabPageNetwork.Padding = new System.Windows.Forms.Padding(5);
			this.tabPageNetwork.Size = new System.Drawing.Size(770, 301);
			this.tabPageNetwork.TabIndex = 0;
			this.tabPageNetwork.Text = "Network";
			this.tabPageNetwork.UseVisualStyleBackColor = true;
			// 
			// tabPageTraceroute
			// 
			this.tabPageTraceroute.Location = new System.Drawing.Point(2, 23);
			this.tabPageTraceroute.Name = "tabPageTraceroute";
			this.tabPageTraceroute.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTraceroute.Size = new System.Drawing.Size(572, 383);
			this.tabPageTraceroute.TabIndex = 1;
			this.tabPageTraceroute.Text = "Traceroute";
			this.tabPageTraceroute.UseVisualStyleBackColor = true;
			// 
			// menuStrip
			// 
			this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemHelp});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(784, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// menuItemFile
			// 
			this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExit});
			this.menuItemFile.Name = "menuItemFile";
			this.menuItemFile.Size = new System.Drawing.Size(37, 20);
			this.menuItemFile.Text = "&File";
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.menuItemExit.Size = new System.Drawing.Size(152, 22);
			this.menuItemExit.Text = "&Exit";
			this.menuItemExit.Click += new System.EventHandler(this.OnExit);
			// 
			// menuItemHelp
			// 
			this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
			this.menuItemHelp.Name = "menuItemHelp";
			this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
			this.menuItemHelp.Text = "&Help";
			// 
			// menuItemAbout
			// 
			this.menuItemAbout.Name = "menuItemAbout";
			this.menuItemAbout.Size = new System.Drawing.Size(152, 22);
			this.menuItemAbout.Text = "&About...";
			// 
			// statusProgress
			// 
			this.statusProgress.Name = "statusProgress";
			this.statusProgress.Size = new System.Drawing.Size(100, 16);
			this.statusProgress.Visible = false;
			// 
			// toolSplitContainer
			// 
			this.toolSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.toolSplitContainer.Location = new System.Drawing.Point(5, 5);
			this.toolSplitContainer.Name = "toolSplitContainer";
			this.toolSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// toolSplitContainer.Panel1
			// 
			this.toolSplitContainer.Panel1.Controls.Add(this.tabControl);
			// 
			// toolSplitContainer.Panel2
			// 
			this.toolSplitContainer.Panel2.Controls.Add(this.controlLog);
			this.toolSplitContainer.Panel2Border = false;
			this.toolSplitContainer.Size = new System.Drawing.Size(774, 506);
			this.toolSplitContainer.SplitterDistance = 326;
			this.toolSplitContainer.SplitterWidth = 5;
			this.toolSplitContainer.TabIndex = 1;
			// 
			// controlLog
			// 
			this.controlLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLog.Location = new System.Drawing.Point(0, 0);
			this.controlLog.Name = "controlLog";
			this.controlLog.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.controlLog.ShowBorder = true;
			this.controlLog.ShowTitle = true;
			this.controlLog.Size = new System.Drawing.Size(774, 175);
			this.controlLog.TabIndex = 0;
			this.controlLog.Title = "Event Log";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.toolStripContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "FormMain";
			this.Text = "Internet Traceroute";
			this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.PerformLayout();
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolSplitContainer.Panel1.ResumeLayout(false);
			this.toolSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.toolSplitContainer)).EndInit();
			this.toolSplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelLeft;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelMiddle;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelRight;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelRun;
		private DotNetApi.Windows.Controls.ThemeTabControl tabControl;
		private System.Windows.Forms.TabPage tabPageNetwork;
		private System.Windows.Forms.TabPage tabPageTraceroute;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem menuItemFile;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
		private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
		private System.Windows.Forms.ToolStripProgressBar statusProgress;
		private DotNetApi.Windows.Controls.ToolSplitContainer toolSplitContainer;
		private InetAnalytics.Controls.Log.ControlLogList controlLog;
	}
}

