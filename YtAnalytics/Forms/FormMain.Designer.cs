namespace YtAnalytics.Forms
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.sideMenu = new DotNetApi.Windows.Controls.SideMenu();
			this.controlPanelLog = new YtAnalytics.Controls.ControlSideLog();
			this.controlPanelComments = new YtAnalytics.Controls.ControlSideTree();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.controlPanelConfiguration = new YtAnalytics.Controls.ControlSideTree();
			this.controlPanelDatabase = new YtAnalytics.Controls.ControlSideTree();
			this.controlPanelBrowser = new YtAnalytics.Controls.ControlSideTree();
			this.labelNotAvailable = new System.Windows.Forms.Label();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewVideo = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemApi2 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemApiV2Related = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemApiV2Responses = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemApi3 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemWeb = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemYouTube = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.sideMenu.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.menuViewVideo.SuspendLayout();
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
			this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer);
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1008, 528);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new System.Drawing.Size(1008, 574);
			this.toolStripContainer.TabIndex = 0;
			// 
			// toolStripContainer.TopToolStripPanel
			// 
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
			// 
			// statusStrip
			// 
			this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip.Location = new System.Drawing.Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1008, 22);
			this.statusStrip.TabIndex = 0;
			// 
			// splitContainer
			// 
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.sideMenu);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.labelNotAvailable);
			this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(4);
			this.splitContainer.Size = new System.Drawing.Size(1008, 528);
			this.splitContainer.SplitterDistance = 246;
			this.splitContainer.TabIndex = 0;
			// 
			// sideMenu
			// 
			this.sideMenu.Controls.Add(this.controlPanelLog);
			this.sideMenu.Controls.Add(this.controlPanelComments);
			this.sideMenu.Controls.Add(this.controlPanelConfiguration);
			this.sideMenu.Controls.Add(this.controlPanelDatabase);
			this.sideMenu.Controls.Add(this.controlPanelBrowser);
			this.sideMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sideMenu.HiddenItems = 0;
			this.sideMenu.ItemHeight = 48;
			this.sideMenu.Location = new System.Drawing.Point(0, 0);
			this.sideMenu.MinimizedItems = 0;
			this.sideMenu.MinimizedItemWidth = 25;
			this.sideMenu.MinimumPanelHeight = 50;
			this.sideMenu.Name = "sideMenu";
			this.sideMenu.Padding = new System.Windows.Forms.Padding(0, 28, 0, 56);
			this.sideMenu.SelectedItem = null;
			this.sideMenu.Size = new System.Drawing.Size(244, 526);
			this.sideMenu.TabIndex = 0;
			this.sideMenu.VisibleItems = 0;
			// 
			// controlPanelLog
			// 
			this.controlPanelLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlPanelLog.Location = new System.Drawing.Point(0, 28);
			this.controlPanelLog.Name = "controlPanelLog";
			this.controlPanelLog.Size = new System.Drawing.Size(244, 442);
			this.controlPanelLog.TabIndex = 2;
			this.controlPanelLog.Visible = false;
			this.controlPanelLog.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.OnLogDateChanged);
			this.controlPanelLog.ControlChanged += new System.Windows.Forms.ControlEventHandler(this.OnControlChanged);
			// 
			// controlPanelComments
			// 
			this.controlPanelComments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlPanelComments.ImageList = this.imageList;
			this.controlPanelComments.Location = new System.Drawing.Point(0, 28);
			this.controlPanelComments.Name = "controlPanelComments";
			this.controlPanelComments.SelectedNode = null;
			this.controlPanelComments.Size = new System.Drawing.Size(244, 442);
			this.controlPanelComments.TabIndex = 3;
			this.controlPanelComments.Visible = false;
			this.controlPanelComments.ControlChanged += new System.Windows.Forms.ControlEventHandler(this.OnControlChanged);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "ServerBrowse");
			this.imageList.Images.SetKeyName(1, "ServerDatabase");
			this.imageList.Images.SetKeyName(2, "ServersDatabase");
			this.imageList.Images.SetKeyName(3, "FolderClosed");
			this.imageList.Images.SetKeyName(4, "FolderClosedXml");
			this.imageList.Images.SetKeyName(5, "FolderClosedVideo");
			this.imageList.Images.SetKeyName(6, "FolderClosedUser");
			this.imageList.Images.SetKeyName(7, "FolderClosedComment");
			this.imageList.Images.SetKeyName(8, "FolderClosedPlay");
			this.imageList.Images.SetKeyName(9, "FolderOpen");
			this.imageList.Images.SetKeyName(10, "FolderOpenXml");
			this.imageList.Images.SetKeyName(11, "FolderOpenVideo");
			this.imageList.Images.SetKeyName(12, "FolderOpenUser");
			this.imageList.Images.SetKeyName(13, "FolderOpenComment");
			this.imageList.Images.SetKeyName(14, "FolderOpenPlay");
			this.imageList.Images.SetKeyName(15, "File");
			this.imageList.Images.SetKeyName(16, "FileXml");
			this.imageList.Images.SetKeyName(17, "FileVideo");
			this.imageList.Images.SetKeyName(18, "FileUser");
			this.imageList.Images.SetKeyName(19, "FileComment");
			this.imageList.Images.SetKeyName(20, "FileGraphLine");
			this.imageList.Images.SetKeyName(21, "GlobeBrowse");
			this.imageList.Images.SetKeyName(22, "Categories");
			this.imageList.Images.SetKeyName(23, "Comments");
			this.imageList.Images.SetKeyName(24, "CommentVideo");
			this.imageList.Images.SetKeyName(25, "CommentUser");
			this.imageList.Images.SetKeyName(26, "CommentPlay");
			this.imageList.Images.SetKeyName(27, "Settings");
			// 
			// controlPanelConfiguration
			// 
			this.controlPanelConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlPanelConfiguration.ImageList = this.imageList;
			this.controlPanelConfiguration.Location = new System.Drawing.Point(0, 28);
			this.controlPanelConfiguration.Name = "controlPanelConfiguration";
			this.controlPanelConfiguration.SelectedNode = null;
			this.controlPanelConfiguration.Size = new System.Drawing.Size(244, 442);
			this.controlPanelConfiguration.TabIndex = 1;
			this.controlPanelConfiguration.Visible = false;
			this.controlPanelConfiguration.ControlChanged += new System.Windows.Forms.ControlEventHandler(this.OnControlChanged);
			// 
			// controlPanelDatabase
			// 
			this.controlPanelDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlPanelDatabase.ImageList = this.imageList;
			this.controlPanelDatabase.Location = new System.Drawing.Point(0, 28);
			this.controlPanelDatabase.Name = "controlPanelDatabase";
			this.controlPanelDatabase.SelectedNode = null;
			this.controlPanelDatabase.Size = new System.Drawing.Size(244, 442);
			this.controlPanelDatabase.TabIndex = 4;
			this.controlPanelDatabase.Visible = false;
			this.controlPanelDatabase.ControlChanged += new System.Windows.Forms.ControlEventHandler(this.OnControlChanged);
			// 
			// controlPanelBrowser
			// 
			this.controlPanelBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlPanelBrowser.ImageList = this.imageList;
			this.controlPanelBrowser.Location = new System.Drawing.Point(0, 28);
			this.controlPanelBrowser.Name = "controlPanelBrowser";
			this.controlPanelBrowser.SelectedNode = null;
			this.controlPanelBrowser.Size = new System.Drawing.Size(244, 442);
			this.controlPanelBrowser.TabIndex = 0;
			this.controlPanelBrowser.Visible = false;
			this.controlPanelBrowser.ControlChanged += new System.Windows.Forms.ControlEventHandler(this.OnControlChanged);
			// 
			// labelNotAvailable
			// 
			this.labelNotAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelNotAvailable.Location = new System.Drawing.Point(4, 4);
			this.labelNotAvailable.Name = "labelNotAvailable";
			this.labelNotAvailable.Size = new System.Drawing.Size(748, 518);
			this.labelNotAvailable.TabIndex = 0;
			this.labelNotAvailable.Text = "Feature not available";
			this.labelNotAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// menuStrip
			// 
			this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemHelp});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1008, 24);
			this.menuStrip.TabIndex = 0;
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
			this.menuItemExit.Text = "E&xit";
			this.menuItemExit.Click += new System.EventHandler(this.Close);
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
			this.menuItemAbout.Click += new System.EventHandler(this.OpenAboutForm);
			// 
			// menuViewVideo
			// 
			this.menuViewVideo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemApi2,
            this.menuItemApiV2Related,
            this.menuItemApiV2Responses,
            this.menuItemApi3,
            this.menuItemWeb,
            this.toolStripSeparator1,
            this.menuItemYouTube});
			this.menuViewVideo.Name = "viewMenu";
			this.menuViewVideo.Size = new System.Drawing.Size(192, 142);
			// 
			// menuItemApi2
			// 
			this.menuItemApi2.Image = global::YtAnalytics.Resources.ServerBrowse_16;
			this.menuItemApi2.Name = "menuItemApi2";
			this.menuItemApi2.Size = new System.Drawing.Size(191, 22);
			this.menuItemApi2.Text = "APIv2 information";
			// 
			// menuItemApiV2Related
			// 
			this.menuItemApiV2Related.Image = global::YtAnalytics.Resources.ServerBrowse_16;
			this.menuItemApiV2Related.Name = "menuItemApiV2Related";
			this.menuItemApiV2Related.Size = new System.Drawing.Size(191, 22);
			this.menuItemApiV2Related.Text = "APIv2 related videos";
			// 
			// menuItemApiV2Responses
			// 
			this.menuItemApiV2Responses.Image = global::YtAnalytics.Resources.ServerBrowse_16;
			this.menuItemApiV2Responses.Name = "menuItemApiV2Responses";
			this.menuItemApiV2Responses.Size = new System.Drawing.Size(191, 22);
			this.menuItemApiV2Responses.Text = "APIv2 response videos";
			// 
			// menuItemApi3
			// 
			this.menuItemApi3.Image = global::YtAnalytics.Resources.ServerBrowse_16;
			this.menuItemApi3.Name = "menuItemApi3";
			this.menuItemApi3.Size = new System.Drawing.Size(191, 22);
			this.menuItemApi3.Text = "APIv3 information";
			// 
			// menuItemWeb
			// 
			this.menuItemWeb.Image = global::YtAnalytics.Resources.GlobeBrowse_16;
			this.menuItemWeb.Name = "menuItemWeb";
			this.menuItemWeb.Size = new System.Drawing.Size(191, 22);
			this.menuItemWeb.Text = "Web statistics";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
			// 
			// menuItemYouTube
			// 
			this.menuItemYouTube.Image = global::YtAnalytics.Resources.Globe_16;
			this.menuItemYouTube.Name = "menuItemYouTube";
			this.menuItemYouTube.Size = new System.Drawing.Size(191, 22);
			this.menuItemYouTube.Text = "Open in YouTube";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 574);
			this.Controls.Add(this.toolStripContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "FormMain";
			this.Text = "YouTube Analytics";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.PerformLayout();
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.sideMenu.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.menuViewVideo.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.SplitContainer splitContainer;
		private DotNetApi.Windows.Controls.SideMenu sideMenu;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripMenuItem menuItemFile;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.Label labelNotAvailable;
		private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
		private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
		private Controls.ControlSideLog controlPanelLog;
		private Controls.ControlSideTree controlPanelConfiguration;
		private Controls.ControlSideTree controlPanelBrowser;
		private System.Windows.Forms.ContextMenuStrip menuViewVideo;
		private System.Windows.Forms.ToolStripMenuItem menuItemApi2;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Related;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Responses;
		private System.Windows.Forms.ToolStripMenuItem menuItemApi3;
		private System.Windows.Forms.ToolStripMenuItem menuItemWeb;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItemYouTube;
		private Controls.ControlSideTree controlPanelComments;
		private Controls.ControlSideTree controlPanelDatabase;
	}
}

