using InetCrawler;

namespace InetAnalytics.Forms
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
			// If disposing the managed resources.
			if (disposing)
			{
				// Remove the network availability event handler.
				Crawler.Network.NetworkChanged -= this.OnNetworkStatusChanged;

				// Dispose the components.
				if (components != null)
				{
					components.Dispose();
				}
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
			this.statusLabelLeft = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelMiddle = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelRight = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelConnection = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.sideMenu = new DotNetApi.Windows.Controls.SideMenu();
			this.controlSideComments = new DotNetApi.Windows.Controls.SideTreeView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.controlSideConfiguration = new DotNetApi.Windows.Controls.SideTreeView();
			this.controlSideTesting = new DotNetApi.Windows.Controls.SideTreeView();
			this.controlSideSpiders = new DotNetApi.Windows.Controls.SideTreeView();
			this.controlSideYouTube = new DotNetApi.Windows.Controls.SideTreeView();
			this.controlSideTasks = new DotNetApi.Windows.Controls.SideTreeView();
			this.controlSideDatabase = new DotNetApi.Windows.Controls.SideTreeView();
			this.controlSideToolbox = new DotNetApi.Windows.Controls.SideTreeView();
			this.controlSidePlanetLab = new DotNetApi.Windows.Controls.SideTreeView();
			this.sideMenuItemPlanetLab = new DotNetApi.Windows.Controls.SideMenuItem();
			this.sideMenuItemToolbox = new DotNetApi.Windows.Controls.SideMenuItem();
			this.sideMenuItemDatabase = new DotNetApi.Windows.Controls.SideMenuItem();
			this.sideMenuItemTasks = new DotNetApi.Windows.Controls.SideMenuItem();
			this.sideMenuItemYouTube = new DotNetApi.Windows.Controls.SideMenuItem();
			this.sideMenuItemTesting = new DotNetApi.Windows.Controls.SideMenuItem();
			this.sideMenuItemSpiders = new DotNetApi.Windows.Controls.SideMenuItem();
			this.sideMenuItemConfiguration = new DotNetApi.Windows.Controls.SideMenuItem();
			this.sideMenuItemComments = new DotNetApi.Windows.Controls.SideMenuItem();
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
			this.controlSideLog = new InetAnalytics.Controls.ControlSideCalendar();
			this.sideMenuItemLog = new DotNetApi.Windows.Controls.SideMenuItem();
			this.toolTipNetworkStatus = new InetAnalytics.Controls.Net.NetworkStatusToolTip(this.components);
			this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.statusStrip.SuspendLayout();
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
			this.toolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(5);
			this.toolStripContainer.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1008, 536);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new System.Drawing.Size(1008, 582);
			this.toolStripContainer.TabIndex = 0;
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
            this.statusLabelMiddle,
            this.statusLabelRight,
            this.statusLabelConnection});
			this.statusStrip.Location = new System.Drawing.Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.ShowItemToolTips = true;
			this.statusStrip.Size = new System.Drawing.Size(1008, 22);
			this.statusStrip.TabIndex = 0;
			// 
			// statusLabelLeft
			// 
			this.statusLabelLeft.Image = global::InetAnalytics.Resources.Information_16;
			this.statusLabelLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.statusLabelLeft.Name = "statusLabelLeft";
			this.statusLabelLeft.Size = new System.Drawing.Size(55, 17);
			this.statusLabelLeft.Text = "Ready";
			// 
			// statusLabelMiddle
			// 
			this.statusLabelMiddle.Name = "statusLabelMiddle";
			this.statusLabelMiddle.Size = new System.Drawing.Size(857, 17);
			this.statusLabelMiddle.Spring = true;
			// 
			// statusLabelRight
			// 
			this.statusLabelRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.statusLabelRight.Name = "statusLabelRight";
			this.statusLabelRight.Size = new System.Drawing.Size(0, 17);
			// 
			// statusLabelConnection
			// 
			this.statusLabelConnection.Image = global::InetAnalytics.Resources.ConnectionSuccess_16;
			this.statusLabelConnection.Name = "statusLabelConnection";
			this.statusLabelConnection.Size = new System.Drawing.Size(81, 17);
			this.statusLabelConnection.Text = "Connected";
			this.statusLabelConnection.MouseEnter += new System.EventHandler(this.OnNetworkStatusEnter);
			this.statusLabelConnection.MouseLeave += new System.EventHandler(this.OnNetworkStatusLeave);
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.Location = new System.Drawing.Point(5, 5);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.sideMenu);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.labelNotAvailable);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(998, 526);
			this.splitContainer.SplitterDistance = 246;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 0;
			// 
			// sideMenu
			// 
			this.sideMenu.Controls.Add(this.controlSideLog);
			this.sideMenu.Controls.Add(this.controlSideComments);
			this.sideMenu.Controls.Add(this.controlSideConfiguration);
			this.sideMenu.Controls.Add(this.controlSideTesting);
			this.sideMenu.Controls.Add(this.controlSideSpiders);
			this.sideMenu.Controls.Add(this.controlSideYouTube);
			this.sideMenu.Controls.Add(this.controlSideTasks);
			this.sideMenu.Controls.Add(this.controlSideDatabase);
			this.sideMenu.Controls.Add(this.controlSideToolbox);
			this.sideMenu.Controls.Add(this.controlSidePlanetLab);
			this.sideMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sideMenu.ItemHeight = 48;
			this.sideMenu.Items.AddRange(new DotNetApi.Windows.Controls.SideMenuItem[] {
            this.sideMenuItemPlanetLab,
            this.sideMenuItemToolbox,
            this.sideMenuItemDatabase,
            this.sideMenuItemTasks,
            this.sideMenuItemYouTube,
            this.sideMenuItemTesting,
            this.sideMenuItemSpiders,
            this.sideMenuItemConfiguration,
            this.sideMenuItemLog,
            this.sideMenuItemComments});
			this.sideMenu.Location = new System.Drawing.Point(0, 0);
			this.sideMenu.MinimizedItemWidth = 25;
			this.sideMenu.MinimumPanelHeight = 50;
			this.sideMenu.Name = "sideMenu";
			this.sideMenu.Padding = new System.Windows.Forms.Padding(0, 22, 0, 440);
			this.sideMenu.SelectedIndex = 0;
			this.sideMenu.SelectedItem = this.sideMenuItemPlanetLab;
			this.sideMenu.Size = new System.Drawing.Size(246, 526);
			this.sideMenu.TabIndex = 0;
			this.sideMenu.Title = "";
			this.sideMenu.VisibleItems = 8;
			// 
			// controlSideComments
			// 
			this.controlSideComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.controlSideComments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSideComments.FullRowSelect = true;
			this.controlSideComments.HideSelection = false;
			this.controlSideComments.ImageIndex = 0;
			this.controlSideComments.ImageList = this.imageList;
			this.controlSideComments.ItemHeight = 20;
			this.controlSideComments.Location = new System.Drawing.Point(0, 22);
			this.controlSideComments.Name = "controlSideComments";
			this.controlSideComments.SelectedImageIndex = 0;
			this.controlSideComments.ShowLines = false;
			this.controlSideComments.ShowRootLines = false;
			this.controlSideComments.Size = new System.Drawing.Size(246, 64);
			this.controlSideComments.TabIndex = 3;
			this.controlSideComments.Visible = false;
			this.controlSideComments.ControlChanged += new DotNetApi.Windows.Controls.ControlChangedEventHandler(this.OnControlChanged);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "ServerBrowse");
			this.imageList.Images.SetKeyName(1, "ServerDatabase");
			this.imageList.Images.SetKeyName(2, "ServersDatabase");
			this.imageList.Images.SetKeyName(3, "ServerCube");
			this.imageList.Images.SetKeyName(4, "ServerTask");
			this.imageList.Images.SetKeyName(5, "ServersCube");
			this.imageList.Images.SetKeyName(6, "ServersGlobe");
			this.imageList.Images.SetKeyName(7, "ServerToolbox");
			this.imageList.Images.SetKeyName(8, "File");
			this.imageList.Images.SetKeyName(9, "FileXml");
			this.imageList.Images.SetKeyName(10, "FileVideo");
			this.imageList.Images.SetKeyName(11, "FileUser");
			this.imageList.Images.SetKeyName(12, "FileComment");
			this.imageList.Images.SetKeyName(13, "FileGraphLine");
			this.imageList.Images.SetKeyName(14, "GlobeBrowse");
			this.imageList.Images.SetKeyName(15, "Categories");
			this.imageList.Images.SetKeyName(16, "Comments");
			this.imageList.Images.SetKeyName(17, "CommentVideo");
			this.imageList.Images.SetKeyName(18, "CommentUser");
			this.imageList.Images.SetKeyName(19, "CommentPlay");
			this.imageList.Images.SetKeyName(20, "Settings");
			this.imageList.Images.SetKeyName(21, "ServerDown");
			this.imageList.Images.SetKeyName(22, "ServerUp");
			this.imageList.Images.SetKeyName(23, "ServerWarning");
			this.imageList.Images.SetKeyName(24, "ServerBusy");
			this.imageList.Images.SetKeyName(25, "Log");
			this.imageList.Images.SetKeyName(26, "QueryDatabase");
			this.imageList.Images.SetKeyName(27, "Cube");
			this.imageList.Images.SetKeyName(28, "Cubes");
			this.imageList.Images.SetKeyName(29, "GlobeSettings");
			this.imageList.Images.SetKeyName(30, "GlobeSchema");
			this.imageList.Images.SetKeyName(31, "GlobeObject");
			this.imageList.Images.SetKeyName(32, "GlobeConsole");
			this.imageList.Images.SetKeyName(33, "GlobeNode");
			this.imageList.Images.SetKeyName(34, "GlobeTask");
			this.imageList.Images.SetKeyName(35, "TestGlobeGoto");
			this.imageList.Images.SetKeyName(36, "TestConnectGoto");
			this.imageList.Images.SetKeyName(37, "FolderClosed");
			this.imageList.Images.SetKeyName(38, "FolderClosedClock");
			this.imageList.Images.SetKeyName(39, "FolderClosedComment");
			this.imageList.Images.SetKeyName(40, "FolderClosedGlobe");
			this.imageList.Images.SetKeyName(41, "FolderClosedPlayBlue");
			this.imageList.Images.SetKeyName(42, "FolderClosedPlayGreen");
			this.imageList.Images.SetKeyName(43, "FolderClosedTask");
			this.imageList.Images.SetKeyName(44, "FolderClosedUser");
			this.imageList.Images.SetKeyName(45, "FolderClosedVideo");
			this.imageList.Images.SetKeyName(46, "FolderClosedXml");
			this.imageList.Images.SetKeyName(47, "FolderOpen");
			this.imageList.Images.SetKeyName(48, "FolderOpenClock");
			this.imageList.Images.SetKeyName(49, "FolderOpenComment");
			this.imageList.Images.SetKeyName(50, "FolderOpenGlobe");
			this.imageList.Images.SetKeyName(51, "FolderOpenPlayBlue");
			this.imageList.Images.SetKeyName(52, "FolderOpenPlayGreen");
			this.imageList.Images.SetKeyName(53, "FolderOpenTask");
			this.imageList.Images.SetKeyName(54, "FolderOpenUser");
			this.imageList.Images.SetKeyName(55, "FolderOpenVideo");
			this.imageList.Images.SetKeyName(56, "FolderOpenXml");
			// 
			// controlSideConfiguration
			// 
			this.controlSideConfiguration.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.controlSideConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSideConfiguration.FullRowSelect = true;
			this.controlSideConfiguration.HideSelection = false;
			this.controlSideConfiguration.ImageIndex = 0;
			this.controlSideConfiguration.ImageList = this.imageList;
			this.controlSideConfiguration.ItemHeight = 20;
			this.controlSideConfiguration.Location = new System.Drawing.Point(0, 22);
			this.controlSideConfiguration.Name = "controlSideConfiguration";
			this.controlSideConfiguration.SelectedImageIndex = 0;
			this.controlSideConfiguration.ShowLines = false;
			this.controlSideConfiguration.ShowRootLines = false;
			this.controlSideConfiguration.Size = new System.Drawing.Size(246, 64);
			this.controlSideConfiguration.TabIndex = 1;
			this.controlSideConfiguration.Visible = false;
			this.controlSideConfiguration.ControlChanged += new DotNetApi.Windows.Controls.ControlChangedEventHandler(this.OnControlChanged);
			// 
			// controlSideTesting
			// 
			this.controlSideTesting.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.controlSideTesting.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSideTesting.FullRowSelect = true;
			this.controlSideTesting.HideSelection = false;
			this.controlSideTesting.ImageIndex = 0;
			this.controlSideTesting.ImageList = this.imageList;
			this.controlSideTesting.ItemHeight = 20;
			this.controlSideTesting.Location = new System.Drawing.Point(0, 22);
			this.controlSideTesting.Name = "controlSideTesting";
			this.controlSideTesting.SelectedImageIndex = 0;
			this.controlSideTesting.ShowLines = false;
			this.controlSideTesting.ShowRootLines = false;
			this.controlSideTesting.Size = new System.Drawing.Size(246, 64);
			this.controlSideTesting.TabIndex = 6;
			this.controlSideTesting.Visible = false;
			this.controlSideTesting.ControlChanged += new DotNetApi.Windows.Controls.ControlChangedEventHandler(this.OnControlChanged);
			// 
			// controlSideSpiders
			// 
			this.controlSideSpiders.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.controlSideSpiders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSideSpiders.FullRowSelect = true;
			this.controlSideSpiders.HideSelection = false;
			this.controlSideSpiders.ImageIndex = 0;
			this.controlSideSpiders.ImageList = this.imageList;
			this.controlSideSpiders.ItemHeight = 20;
			this.controlSideSpiders.Location = new System.Drawing.Point(0, 22);
			this.controlSideSpiders.Name = "controlSideSpiders";
			this.controlSideSpiders.SelectedImageIndex = 0;
			this.controlSideSpiders.ShowLines = false;
			this.controlSideSpiders.ShowRootLines = false;
			this.controlSideSpiders.Size = new System.Drawing.Size(246, 64);
			this.controlSideSpiders.TabIndex = 5;
			this.controlSideSpiders.Visible = false;
			this.controlSideSpiders.ControlChanged += new DotNetApi.Windows.Controls.ControlChangedEventHandler(this.OnControlChanged);
			// 
			// controlSideYouTube
			// 
			this.controlSideYouTube.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.controlSideYouTube.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSideYouTube.FullRowSelect = true;
			this.controlSideYouTube.HideSelection = false;
			this.controlSideYouTube.ImageIndex = 0;
			this.controlSideYouTube.ImageList = this.imageList;
			this.controlSideYouTube.ItemHeight = 20;
			this.controlSideYouTube.Location = new System.Drawing.Point(0, 22);
			this.controlSideYouTube.Name = "controlSideYouTube";
			this.controlSideYouTube.SelectedImageIndex = 0;
			this.controlSideYouTube.ShowLines = false;
			this.controlSideYouTube.ShowRootLines = false;
			this.controlSideYouTube.Size = new System.Drawing.Size(246, 64);
			this.controlSideYouTube.TabIndex = 0;
			this.controlSideYouTube.Visible = false;
			this.controlSideYouTube.ControlChanged += new DotNetApi.Windows.Controls.ControlChangedEventHandler(this.OnControlChanged);
			// 
			// controlSideTasks
			// 
			this.controlSideTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.controlSideTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSideTasks.FullRowSelect = true;
			this.controlSideTasks.HideSelection = false;
			this.controlSideTasks.ImageIndex = 0;
			this.controlSideTasks.ImageList = this.imageList;
			this.controlSideTasks.ItemHeight = 20;
			this.controlSideTasks.Location = new System.Drawing.Point(0, 22);
			this.controlSideTasks.Name = "controlSideTasks";
			this.controlSideTasks.SelectedImageIndex = 0;
			this.controlSideTasks.ShowLines = false;
			this.controlSideTasks.ShowRootLines = false;
			this.controlSideTasks.Size = new System.Drawing.Size(246, 64);
			this.controlSideTasks.TabIndex = 8;
			this.controlSideTasks.Visible = false;
			this.controlSideTasks.ControlChanged += new DotNetApi.Windows.Controls.ControlChangedEventHandler(this.OnControlChanged);
			// 
			// controlSideDatabase
			// 
			this.controlSideDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.controlSideDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSideDatabase.FullRowSelect = true;
			this.controlSideDatabase.HideSelection = false;
			this.controlSideDatabase.ImageIndex = 0;
			this.controlSideDatabase.ImageList = this.imageList;
			this.controlSideDatabase.ItemHeight = 20;
			this.controlSideDatabase.Location = new System.Drawing.Point(0, 22);
			this.controlSideDatabase.Name = "controlSideDatabase";
			this.controlSideDatabase.SelectedImageIndex = 0;
			this.controlSideDatabase.ShowLines = false;
			this.controlSideDatabase.ShowRootLines = false;
			this.controlSideDatabase.Size = new System.Drawing.Size(246, 64);
			this.controlSideDatabase.TabIndex = 4;
			this.controlSideDatabase.Visible = false;
			this.controlSideDatabase.ControlChanged += new DotNetApi.Windows.Controls.ControlChangedEventHandler(this.OnControlChanged);
			// 
			// controlSideToolbox
			// 
			this.controlSideToolbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.controlSideToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSideToolbox.FullRowSelect = true;
			this.controlSideToolbox.HideSelection = false;
			this.controlSideToolbox.ImageIndex = 0;
			this.controlSideToolbox.ImageList = this.imageList;
			this.controlSideToolbox.ItemHeight = 20;
			this.controlSideToolbox.Location = new System.Drawing.Point(0, 22);
			this.controlSideToolbox.Name = "controlSideToolbox";
			this.controlSideToolbox.SelectedImageIndex = 0;
			this.controlSideToolbox.ShowLines = false;
			this.controlSideToolbox.ShowRootLines = false;
			this.controlSideToolbox.Size = new System.Drawing.Size(246, 64);
			this.controlSideToolbox.TabIndex = 9;
			this.controlSideToolbox.Visible = false;
			this.controlSideToolbox.ControlChanged += new DotNetApi.Windows.Controls.ControlChangedEventHandler(this.OnControlChanged);
			// 
			// controlSidePlanetLab
			// 
			this.controlSidePlanetLab.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.controlSidePlanetLab.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSidePlanetLab.FullRowSelect = true;
			this.controlSidePlanetLab.HideSelection = false;
			this.controlSidePlanetLab.ImageIndex = 0;
			this.controlSidePlanetLab.ImageList = this.imageList;
			this.controlSidePlanetLab.ItemHeight = 20;
			this.controlSidePlanetLab.Location = new System.Drawing.Point(0, 22);
			this.controlSidePlanetLab.Name = "controlSidePlanetLab";
			this.controlSidePlanetLab.SelectedImageIndex = 0;
			this.controlSidePlanetLab.ShowLines = false;
			this.controlSidePlanetLab.ShowRootLines = false;
			this.controlSidePlanetLab.Size = new System.Drawing.Size(246, 64);
			this.controlSidePlanetLab.TabIndex = 7;
			this.controlSidePlanetLab.Visible = false;
			this.controlSidePlanetLab.ControlChanged += new DotNetApi.Windows.Controls.ControlChangedEventHandler(this.OnControlChanged);
			// 
			// sideMenuItemPlanetLab
			// 
			this.sideMenuItemPlanetLab.Control = this.controlSidePlanetLab;
			this.sideMenuItemPlanetLab.ImageLarge = global::InetAnalytics.Resources.GlobeLab_32;
			this.sideMenuItemPlanetLab.ImageSmall = global::InetAnalytics.Resources.GlobeLab_16;
			this.sideMenuItemPlanetLab.Index = -1;
			this.sideMenuItemPlanetLab.Text = "PlanetLab";
			// 
			// sideMenuItemToolbox
			// 
			this.sideMenuItemToolbox.Control = this.controlSideToolbox;
			this.sideMenuItemToolbox.ImageLarge = global::InetAnalytics.Resources.ServersToolbox_32;
			this.sideMenuItemToolbox.ImageSmall = global::InetAnalytics.Resources.ServersToolbox_16;
			this.sideMenuItemToolbox.Index = -1;
			this.sideMenuItemToolbox.Text = "Toolbox";
			// 
			// sideMenuItemDatabase
			// 
			this.sideMenuItemDatabase.Control = this.controlSideDatabase;
			this.sideMenuItemDatabase.ImageLarge = global::InetAnalytics.Resources.ServersDatabase_32;
			this.sideMenuItemDatabase.ImageSmall = global::InetAnalytics.Resources.ServersDatabase_16;
			this.sideMenuItemDatabase.Index = -1;
			this.sideMenuItemDatabase.Text = "Database";
			// 
			// sideMenuItemTasks
			// 
			this.sideMenuItemTasks.Control = this.controlSideTasks;
			this.sideMenuItemTasks.ImageLarge = global::InetAnalytics.Resources.ServerTask_32;
			this.sideMenuItemTasks.ImageSmall = global::InetAnalytics.Resources.ServerTask_16;
			this.sideMenuItemTasks.Index = -1;
			this.sideMenuItemTasks.Text = "Tasks";
			// 
			// sideMenuItemYouTube
			// 
			this.sideMenuItemYouTube.Control = this.controlSideYouTube;
			this.sideMenuItemYouTube.ImageLarge = global::InetAnalytics.Resources.ServersVideo_32;
			this.sideMenuItemYouTube.ImageSmall = global::InetAnalytics.Resources.ServersVideo_16;
			this.sideMenuItemYouTube.Index = -1;
			this.sideMenuItemYouTube.Text = "YouTube";
			// 
			// sideMenuItemTesting
			// 
			this.sideMenuItemTesting.Control = this.controlSideTesting;
			this.sideMenuItemTesting.ImageLarge = global::InetAnalytics.Resources.TestsLarge_32;
			this.sideMenuItemTesting.ImageSmall = global::InetAnalytics.Resources.TestsLarge_16;
			this.sideMenuItemTesting.Index = -1;
			this.sideMenuItemTesting.Text = "Testing";
			// 
			// sideMenuItemSpiders
			// 
			this.sideMenuItemSpiders.Control = this.controlSideSpiders;
			this.sideMenuItemSpiders.ImageLarge = global::InetAnalytics.Resources.ServersCube_32;
			this.sideMenuItemSpiders.ImageSmall = global::InetAnalytics.Resources.ServersCube_16;
			this.sideMenuItemSpiders.Index = -1;
			this.sideMenuItemSpiders.Text = "Spiders";
			// 
			// sideMenuItemConfiguration
			// 
			this.sideMenuItemConfiguration.Control = this.controlSideConfiguration;
			this.sideMenuItemConfiguration.ImageLarge = global::InetAnalytics.Resources.ConfigurationSettings_32;
			this.sideMenuItemConfiguration.ImageSmall = global::InetAnalytics.Resources.ConfigurationSettings_16;
			this.sideMenuItemConfiguration.Index = -1;
			this.sideMenuItemConfiguration.Text = "Configuration";
			// 
			// sideMenuItemComments
			// 
			this.sideMenuItemComments.Control = this.controlSideComments;
			this.sideMenuItemComments.ImageLarge = global::InetAnalytics.Resources.Comments_32;
			this.sideMenuItemComments.ImageSmall = global::InetAnalytics.Resources.Comments_16;
			this.sideMenuItemComments.Index = -1;
			this.sideMenuItemComments.Text = "Comments";
			// 
			// labelNotAvailable
			// 
			this.labelNotAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelNotAvailable.Location = new System.Drawing.Point(0, 0);
			this.labelNotAvailable.Name = "labelNotAvailable";
			this.labelNotAvailable.Size = new System.Drawing.Size(747, 526);
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
			this.menuItemApi2.Image = global::InetAnalytics.Resources.ServerBrowse_16;
			this.menuItemApi2.Name = "menuItemApi2";
			this.menuItemApi2.Size = new System.Drawing.Size(191, 22);
			this.menuItemApi2.Text = "APIv2 information";
			// 
			// menuItemApiV2Related
			// 
			this.menuItemApiV2Related.Image = global::InetAnalytics.Resources.ServerBrowse_16;
			this.menuItemApiV2Related.Name = "menuItemApiV2Related";
			this.menuItemApiV2Related.Size = new System.Drawing.Size(191, 22);
			this.menuItemApiV2Related.Text = "APIv2 related videos";
			// 
			// menuItemApiV2Responses
			// 
			this.menuItemApiV2Responses.Image = global::InetAnalytics.Resources.ServerBrowse_16;
			this.menuItemApiV2Responses.Name = "menuItemApiV2Responses";
			this.menuItemApiV2Responses.Size = new System.Drawing.Size(191, 22);
			this.menuItemApiV2Responses.Text = "APIv2 response videos";
			// 
			// menuItemApi3
			// 
			this.menuItemApi3.Image = global::InetAnalytics.Resources.ServerBrowse_16;
			this.menuItemApi3.Name = "menuItemApi3";
			this.menuItemApi3.Size = new System.Drawing.Size(191, 22);
			this.menuItemApi3.Text = "APIv3 information";
			// 
			// menuItemWeb
			// 
			this.menuItemWeb.Image = global::InetAnalytics.Resources.GlobeBrowse_16;
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
			this.menuItemYouTube.Image = global::InetAnalytics.Resources.Globe_16;
			this.menuItemYouTube.Name = "menuItemYouTube";
			this.menuItemYouTube.Size = new System.Drawing.Size(191, 22);
			this.menuItemYouTube.Text = "Open in YouTube";
			// 
			// controlSideLog
			// 
			this.controlSideLog.AutoScroll = true;
			this.controlSideLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlSideLog.Location = new System.Drawing.Point(0, 22);
			this.controlSideLog.Name = "controlSideLog";
			this.controlSideLog.Size = new System.Drawing.Size(246, 64);
			this.controlSideLog.TabIndex = 2;
			this.controlSideLog.Visible = false;
			this.controlSideLog.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.OnLogDateChanged);
			this.controlSideLog.DateRefresh += new System.Windows.Forms.DateRangeEventHandler(this.OnLogDateRefresh);
			this.controlSideLog.ControlChanged += new DotNetApi.Windows.Controls.ControlChangedEventHandler(this.OnControlChanged);
			// 
			// sideMenuItemLog
			// 
			this.sideMenuItemLog.Control = this.controlSideLog;
			this.sideMenuItemLog.ImageLarge = global::InetAnalytics.Resources.Log_32;
			this.sideMenuItemLog.ImageSmall = global::InetAnalytics.Resources.Log_16;
			this.sideMenuItemLog.Index = -1;
			this.sideMenuItemLog.Text = "Log";
			// 
			// toolTipNetworkStatus
			// 
			this.toolTipNetworkStatus.OwnerDraw = true;
			this.toolTipNetworkStatus.ToolTipTitle = "Network Status";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 582);
			this.Controls.Add(this.toolStripContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "FormMain";
			this.Text = "Internet Analytics";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.PerformLayout();
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
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
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private DotNetApi.Windows.Controls.SideMenu sideMenu;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripMenuItem menuItemFile;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.Label labelNotAvailable;
		private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
		private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
		private Controls.ControlSideCalendar controlSideLog;
		private DotNetApi.Windows.Controls.SideTreeView controlSideConfiguration;
		private DotNetApi.Windows.Controls.SideTreeView controlSideYouTube;
		private System.Windows.Forms.ContextMenuStrip menuViewVideo;
		private System.Windows.Forms.ToolStripMenuItem menuItemApi2;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Related;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Responses;
		private System.Windows.Forms.ToolStripMenuItem menuItemApi3;
		private System.Windows.Forms.ToolStripMenuItem menuItemWeb;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItemYouTube;
		private DotNetApi.Windows.Controls.SideTreeView controlSideComments;
		private DotNetApi.Windows.Controls.SideTreeView controlSideDatabase;
		private DotNetApi.Windows.Controls.SideTreeView controlSideSpiders;
		private DotNetApi.Windows.Controls.SideTreeView controlSideTesting;
		private DotNetApi.Windows.Controls.SideTreeView controlSidePlanetLab;
		private DotNetApi.Windows.Controls.SideMenuItem sideMenuItemYouTube;
		private DotNetApi.Windows.Controls.SideMenuItem sideMenuItemDatabase;
		private DotNetApi.Windows.Controls.SideMenuItem sideMenuItemSpiders;
		private DotNetApi.Windows.Controls.SideMenuItem sideMenuItemPlanetLab;
		private DotNetApi.Windows.Controls.SideMenuItem sideMenuItemTesting;
		private DotNetApi.Windows.Controls.SideMenuItem sideMenuItemConfiguration;
		private DotNetApi.Windows.Controls.SideMenuItem sideMenuItemLog;
		private DotNetApi.Windows.Controls.SideMenuItem sideMenuItemComments;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelLeft;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelMiddle;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelRight;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelConnection;
		private InetAnalytics.Controls.Net.NetworkStatusToolTip toolTipNetworkStatus;
		private DotNetApi.Windows.Controls.SideMenuItem sideMenuItemTasks;
		private DotNetApi.Windows.Controls.SideTreeView controlSideTasks;
		private DotNetApi.Windows.Controls.SideMenuItem sideMenuItemToolbox;
		private DotNetApi.Windows.Controls.SideTreeView controlSideToolbox;
	}
}

