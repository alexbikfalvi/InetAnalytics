namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlSlice
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
				// Dispose the tasks.
				this.OnDisposeTasks();
				// Dispose the nodes.
				this.OnDisposeNodes();
				// Remove the slice event handler.
				this.slice.Changed -= this.OnSliceChanged;
				// If the components are not null.
				if (components != null)
				{
					// Dispose the components.
					components.Dispose();
				}
			}
			// Call the base class method.
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSlice));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelSlice = new DotNetApi.Windows.Controls.ThemeControl();
			this.panelNodes = new System.Windows.Forms.Panel();
			this.splitContainerSlice = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderHostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.mapControl = new DotNetApi.Windows.Controls.MapControl();
			this.panelInformation = new System.Windows.Forms.Panel();
			this.linkLabelKey = new System.Windows.Forms.LinkLabel();
			this.labelKey = new System.Windows.Forms.Label();
			this.labelMaxNodes = new System.Windows.Forms.Label();
			this.labelExpires = new System.Windows.Forms.Label();
			this.textBoxMaxNodes = new System.Windows.Forms.TextBox();
			this.textBoxExpires = new System.Windows.Forms.TextBox();
			this.labelCreated = new System.Windows.Forms.Label();
			this.labelUrl = new System.Windows.Forms.Label();
			this.textBoxCreated = new System.Windows.Forms.TextBox();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
			this.buttonCancel = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonAddToNodes = new System.Windows.Forms.ToolStripDropDownButton();
			this.contextMenuAddToNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.itemSelectNodesLocation = new System.Windows.Forms.ToolStripMenuItem();
			this.itemSelectNodesState = new System.Windows.Forms.ToolStripMenuItem();
			this.itemSelectNodesSlice = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonRemoveFromNodes = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonSetKey = new System.Windows.Forms.ToolStripButton();
			this.buttonRenew = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonConnect = new System.Windows.Forms.ToolStripButton();
			this.buttonDisconnect = new System.Windows.Forms.ToolStripButton();
			this.buttonProperties = new System.Windows.Forms.ToolStripDropDownButton();
			this.buttonNodeProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonSiteProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.controlLog = new InetAnalytics.Controls.Log.ControlLogList();
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemNodeProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSiteProperties = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelSlice.SuspendLayout();
			this.panelNodes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSlice)).BeginInit();
			this.splitContainerSlice.Panel1.SuspendLayout();
			this.splitContainerSlice.Panel2.SuspendLayout();
			this.splitContainerSlice.SuspendLayout();
			this.panelInformation.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.contextMenuAddToNodes.SuspendLayout();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.panelSlice);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.controlLog);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 2;
			// 
			// panelSlice
			// 
			this.panelSlice.Controls.Add(this.panelNodes);
			this.panelSlice.Controls.Add(this.panelInformation);
			this.panelSlice.Controls.Add(this.toolStrip);
			this.panelSlice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelSlice.Location = new System.Drawing.Point(0, 0);
			this.panelSlice.Name = "panelSlice";
			this.panelSlice.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelSlice.ShowBorder = true;
			this.panelSlice.ShowTitle = true;
			this.panelSlice.Size = new System.Drawing.Size(800, 425);
			this.panelSlice.TabIndex = 1;
			this.panelSlice.Title = "PlanetLab Slice";
			// 
			// panelNodes
			// 
			this.panelNodes.Controls.Add(this.splitContainerSlice);
			this.panelNodes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelNodes.Location = new System.Drawing.Point(1, 151);
			this.panelNodes.Name = "panelNodes";
			this.panelNodes.Padding = new System.Windows.Forms.Padding(4);
			this.panelNodes.Size = new System.Drawing.Size(798, 273);
			this.panelNodes.TabIndex = 3;
			// 
			// splitContainerSlice
			// 
			this.splitContainerSlice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerSlice.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerSlice.Location = new System.Drawing.Point(4, 4);
			this.splitContainerSlice.Name = "splitContainerSlice";
			// 
			// splitContainerSlice.Panel1
			// 
			this.splitContainerSlice.Panel1.Controls.Add(this.listViewNodes);
			// 
			// splitContainerSlice.Panel2
			// 
			this.splitContainerSlice.Panel2.Controls.Add(this.mapControl);
			this.splitContainerSlice.Size = new System.Drawing.Size(790, 265);
			this.splitContainerSlice.SplitterDistance = 266;
			this.splitContainerSlice.SplitterWidth = 5;
			this.splitContainerSlice.TabIndex = 2;
			this.splitContainerSlice.UseTheme = false;
			// 
			// listViewNodes
			// 
			this.listViewNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderHostname,
            this.columnHeaderState});
			this.listViewNodes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewNodes.FullRowSelect = true;
			this.listViewNodes.GridLines = true;
			this.listViewNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewNodes.HideSelection = false;
			this.listViewNodes.Location = new System.Drawing.Point(0, 0);
			this.listViewNodes.MultiSelect = false;
			this.listViewNodes.Name = "listViewNodes";
			this.listViewNodes.Size = new System.Drawing.Size(266, 265);
			this.listViewNodes.SmallImageList = this.imageList;
			this.listViewNodes.TabIndex = 0;
			this.listViewNodes.UseCompatibleStateImageBehavior = false;
			this.listViewNodes.View = System.Windows.Forms.View.Details;
			this.listViewNodes.ItemActivate += new System.EventHandler(this.OnNodeProperties);
			this.listViewNodes.SelectedIndexChanged += new System.EventHandler(this.OnNodeSelectionChanged);
			this.listViewNodes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
			// 
			// columnHeaderHostname
			// 
			this.columnHeaderHostname.Text = "Hostname";
			this.columnHeaderHostname.Width = 120;
			// 
			// columnHeaderState
			// 
			this.columnHeaderState.Text = "State";
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "NodeUnknown");
			this.imageList.Images.SetKeyName(1, "NodeBoot");
			this.imageList.Images.SetKeyName(2, "NodeSafeBoot");
			this.imageList.Images.SetKeyName(3, "NodeReinstall");
			this.imageList.Images.SetKeyName(4, "NodeDisabled");
			// 
			// mapControl
			// 
			this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapControl.Location = new System.Drawing.Point(0, 0);
			this.mapControl.Name = "mapControl";
			this.mapControl.Size = new System.Drawing.Size(519, 265);
			this.mapControl.TabIndex = 0;
			this.mapControl.MarkerClick += new System.EventHandler(this.OnMapMarkerClick);
			this.mapControl.MarkerDoubleClick += new System.EventHandler(this.OnMapMarkerDoubleClick);
			// 
			// panelInformation
			// 
			this.panelInformation.AutoScroll = true;
			this.panelInformation.Controls.Add(this.linkLabelKey);
			this.panelInformation.Controls.Add(this.labelKey);
			this.panelInformation.Controls.Add(this.labelMaxNodes);
			this.panelInformation.Controls.Add(this.labelExpires);
			this.panelInformation.Controls.Add(this.textBoxMaxNodes);
			this.panelInformation.Controls.Add(this.textBoxExpires);
			this.panelInformation.Controls.Add(this.labelCreated);
			this.panelInformation.Controls.Add(this.labelUrl);
			this.panelInformation.Controls.Add(this.textBoxCreated);
			this.panelInformation.Controls.Add(this.textBoxUrl);
			this.panelInformation.Controls.Add(this.labelDescription);
			this.panelInformation.Controls.Add(this.textBoxDescription);
			this.panelInformation.Controls.Add(this.labelName);
			this.panelInformation.Controls.Add(this.textBoxName);
			this.panelInformation.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelInformation.Location = new System.Drawing.Point(1, 47);
			this.panelInformation.MaximumSize = new System.Drawing.Size(0, 104);
			this.panelInformation.Name = "panelInformation";
			this.panelInformation.Size = new System.Drawing.Size(798, 104);
			this.panelInformation.TabIndex = 1;
			// 
			// linkLabelKey
			// 
			this.linkLabelKey.AutoSize = true;
			this.linkLabelKey.Location = new System.Drawing.Point(429, 58);
			this.linkLabelKey.Name = "linkLabelKey";
			this.linkLabelKey.Size = new System.Drawing.Size(50, 13);
			this.linkLabelKey.TabIndex = 13;
			this.linkLabelKey.TabStop = true;
			this.linkLabelKey.Text = "View key";
			this.linkLabelKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnShowKey);
			// 
			// labelKey
			// 
			this.labelKey.AutoSize = true;
			this.labelKey.Location = new System.Drawing.Point(328, 58);
			this.labelKey.Name = "labelKey";
			this.labelKey.Size = new System.Drawing.Size(28, 13);
			this.labelKey.TabIndex = 12;
			this.labelKey.Text = "&Key:";
			// 
			// labelMaxNodes
			// 
			this.labelMaxNodes.AutoSize = true;
			this.labelMaxNodes.Location = new System.Drawing.Point(3, 84);
			this.labelMaxNodes.Name = "labelMaxNodes";
			this.labelMaxNodes.Size = new System.Drawing.Size(86, 13);
			this.labelMaxNodes.TabIndex = 6;
			this.labelMaxNodes.Text = "&Maximum nodes:";
			// 
			// labelExpires
			// 
			this.labelExpires.AutoSize = true;
			this.labelExpires.Location = new System.Drawing.Point(328, 32);
			this.labelExpires.Name = "labelExpires";
			this.labelExpires.Size = new System.Drawing.Size(44, 13);
			this.labelExpires.TabIndex = 10;
			this.labelExpires.Text = "&Expires:";
			// 
			// textBoxMaxNodes
			// 
			this.textBoxMaxNodes.Location = new System.Drawing.Point(107, 81);
			this.textBoxMaxNodes.Name = "textBoxMaxNodes";
			this.textBoxMaxNodes.ReadOnly = true;
			this.textBoxMaxNodes.Size = new System.Drawing.Size(215, 20);
			this.textBoxMaxNodes.TabIndex = 7;
			// 
			// textBoxExpires
			// 
			this.textBoxExpires.Location = new System.Drawing.Point(432, 29);
			this.textBoxExpires.Name = "textBoxExpires";
			this.textBoxExpires.ReadOnly = true;
			this.textBoxExpires.Size = new System.Drawing.Size(215, 20);
			this.textBoxExpires.TabIndex = 11;
			// 
			// labelCreated
			// 
			this.labelCreated.AutoSize = true;
			this.labelCreated.Location = new System.Drawing.Point(328, 6);
			this.labelCreated.Name = "labelCreated";
			this.labelCreated.Size = new System.Drawing.Size(47, 13);
			this.labelCreated.TabIndex = 8;
			this.labelCreated.Text = "&Created:";
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(3, 58);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(32, 13);
			this.labelUrl.TabIndex = 4;
			this.labelUrl.Text = "&URL:";
			// 
			// textBoxCreated
			// 
			this.textBoxCreated.Location = new System.Drawing.Point(432, 3);
			this.textBoxCreated.Name = "textBoxCreated";
			this.textBoxCreated.ReadOnly = true;
			this.textBoxCreated.Size = new System.Drawing.Size(215, 20);
			this.textBoxCreated.TabIndex = 9;
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Location = new System.Drawing.Point(107, 55);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.ReadOnly = true;
			this.textBoxUrl.Size = new System.Drawing.Size(215, 20);
			this.textBoxUrl.TabIndex = 5;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(3, 32);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(63, 13);
			this.labelDescription.TabIndex = 2;
			this.labelDescription.Text = "&Description:";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Location = new System.Drawing.Point(107, 29);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.Size = new System.Drawing.Size(215, 20);
			this.textBoxDescription.TabIndex = 3;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(3, 6);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(38, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "&Name:";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(107, 3);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.ReadOnly = true;
			this.textBoxName.Size = new System.Drawing.Size(215, 20);
			this.textBoxName.TabIndex = 1;
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefresh,
            this.buttonCancel,
            this.separator1,
            this.buttonAddToNodes,
            this.buttonRemoveFromNodes,
            this.toolStripSeparator1,
            this.buttonSetKey,
            this.buttonRenew,
            this.toolStripSeparator2,
            this.buttonConnect,
            this.buttonDisconnect,
            this.buttonProperties});
			this.toolStrip.Location = new System.Drawing.Point(1, 22);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Image = global::InetAnalytics.Resources.Refresh_16;
			this.buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(66, 22);
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefreshSlice);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(47, 22);
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonAddToNodes
			// 
			this.buttonAddToNodes.DropDown = this.contextMenuAddToNodes;
			this.buttonAddToNodes.Image = global::InetAnalytics.Resources.NodeAdd_16;
			this.buttonAddToNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAddToNodes.Name = "buttonAddToNodes";
			this.buttonAddToNodes.Size = new System.Drawing.Size(107, 22);
			this.buttonAddToNodes.Text = "A&dd to nodes";
			// 
			// contextMenuAddToNodes
			// 
			this.contextMenuAddToNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemSelectNodesLocation,
            this.itemSelectNodesState,
            this.itemSelectNodesSlice});
			this.contextMenuAddToNodes.Name = "contextMenuAddToNodes";
			this.contextMenuAddToNodes.OwnerItem = this.buttonAddToNodes;
			this.contextMenuAddToNodes.Size = new System.Drawing.Size(203, 70);
			// 
			// itemSelectNodesLocation
			// 
			this.itemSelectNodesLocation.Name = "itemSelectNodesLocation";
			this.itemSelectNodesLocation.Size = new System.Drawing.Size(202, 22);
			this.itemSelectNodesLocation.Text = "Select nodes by location";
			this.itemSelectNodesLocation.Click += new System.EventHandler(this.OnAddToNodesLocation);
			// 
			// itemSelectNodesState
			// 
			this.itemSelectNodesState.Name = "itemSelectNodesState";
			this.itemSelectNodesState.Size = new System.Drawing.Size(202, 22);
			this.itemSelectNodesState.Text = "Select nodes by state";
			this.itemSelectNodesState.Click += new System.EventHandler(this.OnAddToNodesState);
			// 
			// itemSelectNodesSlice
			// 
			this.itemSelectNodesSlice.Name = "itemSelectNodesSlice";
			this.itemSelectNodesSlice.Size = new System.Drawing.Size(202, 22);
			this.itemSelectNodesSlice.Text = "Select nodes by slice";
			this.itemSelectNodesSlice.Click += new System.EventHandler(this.OnAddToNodesSlice);
			// 
			// buttonRemoveFromNodes
			// 
			this.buttonRemoveFromNodes.Enabled = false;
			this.buttonRemoveFromNodes.Image = global::InetAnalytics.Resources.NodeRemove_16;
			this.buttonRemoveFromNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemoveFromNodes.Name = "buttonRemoveFromNodes";
			this.buttonRemoveFromNodes.Size = new System.Drawing.Size(134, 22);
			this.buttonRemoveFromNodes.Text = "Remo&ve from nodes";
			this.buttonRemoveFromNodes.Click += new System.EventHandler(this.OnRemoveFromNodes);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonSetKey
			// 
			this.buttonSetKey.Image = global::InetAnalytics.Resources.KeyVertical_16;
			this.buttonSetKey.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSetKey.Name = "buttonSetKey";
			this.buttonSetKey.Size = new System.Drawing.Size(64, 22);
			this.buttonSetKey.Text = "Set &key";
			this.buttonSetKey.Click += new System.EventHandler(this.OnSetKey);
			// 
			// buttonRenew
			// 
			this.buttonRenew.Image = global::InetAnalytics.Resources.ClockNew_16;
			this.buttonRenew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRenew.Name = "buttonRenew";
			this.buttonRenew.Size = new System.Drawing.Size(62, 22);
			this.buttonRenew.Text = "Rene&w";
			this.buttonRenew.Click += new System.EventHandler(this.OnRenew);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonConnect
			// 
			this.buttonConnect.Enabled = false;
			this.buttonConnect.Image = global::InetAnalytics.Resources.ConsoleConnect_16;
			this.buttonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(72, 22);
			this.buttonConnect.Text = "C&onnect";
			this.buttonConnect.Click += new System.EventHandler(this.OnConnect);
			// 
			// buttonDisconnect
			// 
			this.buttonDisconnect.Enabled = false;
			this.buttonDisconnect.Image = global::InetAnalytics.Resources.ConsoleDisconnect_16;
			this.buttonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonDisconnect.Name = "buttonDisconnect";
			this.buttonDisconnect.Size = new System.Drawing.Size(86, 22);
			this.buttonDisconnect.Text = "&Disconnect";
			this.buttonDisconnect.Click += new System.EventHandler(this.OnDisconnect);
			// 
			// buttonProperties
			// 
			this.buttonProperties.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonNodeProperties,
            this.buttonSiteProperties});
			this.buttonProperties.Enabled = false;
			this.buttonProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.buttonProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonProperties.Name = "buttonProperties";
			this.buttonProperties.Size = new System.Drawing.Size(89, 22);
			this.buttonProperties.Text = "&Properties";
			// 
			// buttonNodeProperties
			// 
			this.buttonNodeProperties.Name = "buttonNodeProperties";
			this.buttonNodeProperties.Size = new System.Drawing.Size(159, 22);
			this.buttonNodeProperties.Text = "Node properties";
			this.buttonNodeProperties.Click += new System.EventHandler(this.OnNodeProperties);
			// 
			// buttonSiteProperties
			// 
			this.buttonSiteProperties.Name = "buttonSiteProperties";
			this.buttonSiteProperties.Size = new System.Drawing.Size(159, 22);
			this.buttonSiteProperties.Text = "Site properties";
			this.buttonSiteProperties.Click += new System.EventHandler(this.OnSiteProperties);
			// 
			// controlLog
			// 
			this.controlLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLog.Location = new System.Drawing.Point(0, 0);
			this.controlLog.Name = "controlLog";
			this.controlLog.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.controlLog.ShowBorder = true;
			this.controlLog.ShowTitle = true;
			this.controlLog.Size = new System.Drawing.Size(800, 170);
			this.controlLog.TabIndex = 0;
			this.controlLog.Title = "Log";
			// 
			// legendItemSuccess
			// 
			this.legendItemSuccess.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.legendItemSuccess.Text = "Success";
			// 
			// legendItemFail
			// 
			this.legendItemFail.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.legendItemFail.Text = "Fail";
			// 
			// legendItemWarning
			// 
			this.legendItemWarning.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.legendItemWarning.Text = "Warning";
			// 
			// legendItemPending
			// 
			this.legendItemPending.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.legendItemPending.Text = "Pending";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "All files (*.*)|*.*";
			this.openFileDialog.Title = "Open Key File";
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemConnect,
            this.menuItemDisconnect,
            this.toolStripSeparator3,
            this.menuItemNodeProperties,
            this.menuItemSiteProperties});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(160, 98);
			// 
			// menuItemConnect
			// 
			this.menuItemConnect.Image = global::InetAnalytics.Resources.ConsoleConnect_16;
			this.menuItemConnect.Name = "menuItemConnect";
			this.menuItemConnect.Size = new System.Drawing.Size(159, 22);
			this.menuItemConnect.Text = "&Connect";
			this.menuItemConnect.Click += new System.EventHandler(this.OnConnect);
			// 
			// menuItemDisconnect
			// 
			this.menuItemDisconnect.Image = global::InetAnalytics.Resources.ConsoleDisconnect_16;
			this.menuItemDisconnect.Name = "menuItemDisconnect";
			this.menuItemDisconnect.Size = new System.Drawing.Size(159, 22);
			this.menuItemDisconnect.Text = "&Disconnect";
			this.menuItemDisconnect.Click += new System.EventHandler(this.OnDisconnect);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
			// 
			// menuItemNodeProperties
			// 
			this.menuItemNodeProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.menuItemNodeProperties.Name = "menuItemNodeProperties";
			this.menuItemNodeProperties.Size = new System.Drawing.Size(159, 22);
			this.menuItemNodeProperties.Text = "Node pr&operties";
			this.menuItemNodeProperties.Click += new System.EventHandler(this.OnNodeProperties);
			// 
			// menuItemSiteProperties
			// 
			this.menuItemSiteProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.menuItemSiteProperties.Name = "menuItemSiteProperties";
			this.menuItemSiteProperties.Size = new System.Drawing.Size(159, 22);
			this.menuItemSiteProperties.Text = "Site prop&erties";
			this.menuItemSiteProperties.Click += new System.EventHandler(this.OnSiteProperties);
			// 
			// ControlSlice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlSlice";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelSlice.ResumeLayout(false);
			this.panelSlice.PerformLayout();
			this.panelNodes.ResumeLayout(false);
			this.splitContainerSlice.Panel1.ResumeLayout(false);
			this.splitContainerSlice.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSlice)).EndInit();
			this.splitContainerSlice.ResumeLayout(false);
			this.panelInformation.ResumeLayout(false);
			this.panelInformation.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.contextMenuAddToNodes.ResumeLayout(false);
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemPending;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemSuccess;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemFail;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemWarning;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonRefresh;
		private System.Windows.Forms.ToolStripButton buttonCancel;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private Log.ControlLogList controlLog;
		private System.Windows.Forms.ToolStripButton buttonRemoveFromNodes;
		private System.Windows.Forms.ToolStripDropDownButton buttonAddToNodes;
		private System.Windows.Forms.ContextMenuStrip contextMenuAddToNodes;
		private System.Windows.Forms.ToolStripMenuItem itemSelectNodesLocation;
		private System.Windows.Forms.ToolStripMenuItem itemSelectNodesState;
		private System.Windows.Forms.ToolStripMenuItem itemSelectNodesSlice;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerSlice;
		private DotNetApi.Windows.Controls.MapControl mapControl;
		private System.Windows.Forms.Panel panelInformation;
		private System.Windows.Forms.Label labelMaxNodes;
		private System.Windows.Forms.Label labelExpires;
		private System.Windows.Forms.TextBox textBoxMaxNodes;
		private System.Windows.Forms.TextBox textBoxExpires;
		private System.Windows.Forms.Label labelCreated;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.TextBox textBoxCreated;
		private System.Windows.Forms.TextBox textBoxUrl;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton buttonSetKey;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.LinkLabel linkLabelKey;
		private System.Windows.Forms.Label labelKey;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderHostname;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton buttonConnect;
		private System.Windows.Forms.ToolStripButton buttonDisconnect;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemConnect;
		private System.Windows.Forms.ToolStripMenuItem menuItemDisconnect;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuItemNodeProperties;
		private System.Windows.Forms.ToolStripDropDownButton buttonProperties;
		private System.Windows.Forms.ToolStripMenuItem menuItemSiteProperties;
		private System.Windows.Forms.ToolStripMenuItem buttonNodeProperties;
		private System.Windows.Forms.ToolStripMenuItem buttonSiteProperties;
		private System.Windows.Forms.ColumnHeader columnHeaderState;
		private System.Windows.Forms.ToolStripButton buttonRenew;
		private DotNetApi.Windows.Controls.ThemeControl panelSlice;
		private System.Windows.Forms.Panel panelNodes;
	}
}
