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
			this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.statusLabelMiddle = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelRight = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl = new DotNetApi.Windows.Controls.ThemeTabControl();
			this.tabPageNetwork = new System.Windows.Forms.TabPage();
			this.splitContainerNetwork = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.themeControlNetwork = new DotNetApi.Windows.Controls.ThemeControl();
			this.controlLogNetwork = new InetAnalytics.Controls.Log.ControlLogList();
			this.tabPageTraceroute = new System.Windows.Forms.TabPage();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripNetwork = new System.Windows.Forms.ToolStrip();
			this.statusLabelLeft = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelRun = new System.Windows.Forms.ToolStripStatusLabel();
			this.buttonRefreshInterfaces = new System.Windows.Forms.ToolStripButton();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeaderAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageDns = new System.Windows.Forms.TabPage();
			this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageNetwork.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerNetwork)).BeginInit();
			this.splitContainerNetwork.Panel1.SuspendLayout();
			this.splitContainerNetwork.Panel2.SuspendLayout();
			this.splitContainerNetwork.SuspendLayout();
			this.themeControlNetwork.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.toolStripNetwork.SuspendLayout();
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
			this.toolStripContainer.ContentPanel.Controls.Add(this.tabControl);
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
			// statusProgress
			// 
			this.statusProgress.Name = "statusProgress";
			this.statusProgress.Size = new System.Drawing.Size(100, 16);
			this.statusProgress.Visible = false;
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
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageNetwork);
			this.tabControl.Controls.Add(this.tabPageDns);
			this.tabControl.Controls.Add(this.tabPageTraceroute);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(784, 516);
			this.tabControl.TabIndex = 1;
			// 
			// tabPageNetwork
			// 
			this.tabPageNetwork.Controls.Add(this.splitContainerNetwork);
			this.tabPageNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabPageNetwork.Location = new System.Drawing.Point(2, 23);
			this.tabPageNetwork.Name = "tabPageNetwork";
			this.tabPageNetwork.Padding = new System.Windows.Forms.Padding(5);
			this.tabPageNetwork.Size = new System.Drawing.Size(780, 491);
			this.tabPageNetwork.TabIndex = 0;
			this.tabPageNetwork.Text = "Network";
			this.tabPageNetwork.UseVisualStyleBackColor = true;
			// 
			// splitContainerNetwork
			// 
			this.splitContainerNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerNetwork.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerNetwork.Location = new System.Drawing.Point(5, 5);
			this.splitContainerNetwork.Name = "splitContainerNetwork";
			this.splitContainerNetwork.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerNetwork.Panel1
			// 
			this.splitContainerNetwork.Panel1.Controls.Add(this.themeControlNetwork);
			this.splitContainerNetwork.Panel1Border = false;
			// 
			// splitContainerNetwork.Panel2
			// 
			this.splitContainerNetwork.Panel2.Controls.Add(this.controlLogNetwork);
			this.splitContainerNetwork.Panel2Border = false;
			this.splitContainerNetwork.Size = new System.Drawing.Size(770, 481);
			this.splitContainerNetwork.SplitterDistance = 310;
			this.splitContainerNetwork.SplitterWidth = 5;
			this.splitContainerNetwork.TabIndex = 0;
			this.splitContainerNetwork.UseTheme = false;
			// 
			// themeControlNetwork
			// 
			this.themeControlNetwork.Controls.Add(this.listView1);
			this.themeControlNetwork.Controls.Add(this.toolStripNetwork);
			this.themeControlNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
			this.themeControlNetwork.Location = new System.Drawing.Point(0, 0);
			this.themeControlNetwork.Name = "themeControlNetwork";
			this.themeControlNetwork.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.themeControlNetwork.ShowBorder = true;
			this.themeControlNetwork.ShowTitle = true;
			this.themeControlNetwork.Size = new System.Drawing.Size(770, 310);
			this.themeControlNetwork.TabIndex = 0;
			this.themeControlNetwork.Title = "Local Interfaces";
			// 
			// controlLogNetwork
			// 
			this.controlLogNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLogNetwork.Location = new System.Drawing.Point(0, 0);
			this.controlLogNetwork.Name = "controlLogNetwork";
			this.controlLogNetwork.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.controlLogNetwork.ShowBorder = true;
			this.controlLogNetwork.ShowTitle = true;
			this.controlLogNetwork.Size = new System.Drawing.Size(770, 166);
			this.controlLogNetwork.TabIndex = 0;
			this.controlLogNetwork.Title = "Event Log";
			// 
			// tabPageTraceroute
			// 
			this.tabPageTraceroute.Location = new System.Drawing.Point(2, 23);
			this.tabPageTraceroute.Name = "tabPageTraceroute";
			this.tabPageTraceroute.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTraceroute.Size = new System.Drawing.Size(780, 491);
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
			this.menuItemExit.Size = new System.Drawing.Size(134, 22);
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
			this.menuItemAbout.Size = new System.Drawing.Size(116, 22);
			this.menuItemAbout.Text = "&About...";
			// 
			// toolStripNetwork
			// 
			this.toolStripNetwork.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefreshInterfaces});
			this.toolStripNetwork.Location = new System.Drawing.Point(1, 23);
			this.toolStripNetwork.Name = "toolStripNetwork";
			this.toolStripNetwork.Size = new System.Drawing.Size(768, 25);
			this.toolStripNetwork.TabIndex = 0;
			this.toolStripNetwork.Text = "toolStrip1";
			// 
			// statusLabelLeft
			// 
			this.statusLabelLeft.Image = global::InetTraceroute.Resources.Information_16;
			this.statusLabelLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.statusLabelLeft.Name = "statusLabelLeft";
			this.statusLabelLeft.Size = new System.Drawing.Size(55, 17);
			this.statusLabelLeft.Text = "Ready";
			// 
			// statusLabelRun
			// 
			this.statusLabelRun.Image = global::InetTraceroute.Resources.RunConcurrentStop_16;
			this.statusLabelRun.Name = "statusLabelRun";
			this.statusLabelRun.Size = new System.Drawing.Size(135, 17);
			this.statusLabelRun.Text = "No background tasks";
			// 
			// buttonRefreshInterfaces
			// 
			this.buttonRefreshInterfaces.Image = global::InetTraceroute.Resources.Refresh_16;
			this.buttonRefreshInterfaces.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRefreshInterfaces.Name = "buttonRefreshInterfaces";
			this.buttonRefreshInterfaces.Size = new System.Drawing.Size(66, 22);
			this.buttonRefreshInterfaces.Text = "&Refresh";
			// 
			// listView1
			// 
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress,
            this.columnHeaderProtocol});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(1, 48);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(768, 261);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderAddress
			// 
			this.columnHeaderAddress.Text = "Address";
			this.columnHeaderAddress.Width = 160;
			// 
			// columnHeaderProtocol
			// 
			this.columnHeaderProtocol.Text = "Protocol";
			// 
			// tabPageDns
			// 
			this.tabPageDns.Location = new System.Drawing.Point(2, 23);
			this.tabPageDns.Name = "tabPageDns";
			this.tabPageDns.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDns.Size = new System.Drawing.Size(780, 491);
			this.tabPageDns.TabIndex = 2;
			this.tabPageDns.Text = "Name Resolution";
			this.tabPageDns.UseVisualStyleBackColor = true;
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
			this.tabPageNetwork.ResumeLayout(false);
			this.splitContainerNetwork.Panel1.ResumeLayout(false);
			this.splitContainerNetwork.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerNetwork)).EndInit();
			this.splitContainerNetwork.ResumeLayout(false);
			this.themeControlNetwork.ResumeLayout(false);
			this.themeControlNetwork.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStripNetwork.ResumeLayout(false);
			this.toolStripNetwork.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelLeft;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelMiddle;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelRight;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelRun;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem menuItemFile;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
		private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
		private System.Windows.Forms.ToolStripProgressBar statusProgress;
		private DotNetApi.Windows.Controls.ThemeTabControl tabControl;
		private System.Windows.Forms.TabPage tabPageNetwork;
		private System.Windows.Forms.TabPage tabPageTraceroute;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerNetwork;
		private InetAnalytics.Controls.Log.ControlLogList controlLogNetwork;
		private DotNetApi.Windows.Controls.ThemeControl themeControlNetwork;
		private System.Windows.Forms.ToolStrip toolStripNetwork;
		private System.Windows.Forms.ToolStripButton buttonRefreshInterfaces;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeaderAddress;
		private System.Windows.Forms.ColumnHeader columnHeaderProtocol;
		private System.Windows.Forms.TabPage tabPageDns;
	}
}

