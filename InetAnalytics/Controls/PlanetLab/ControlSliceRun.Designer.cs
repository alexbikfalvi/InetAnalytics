namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlSliceRun
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
				// Dispose the nodes.
				this.OnDisposeNodes();
				// Remove the slice event handler.
				this.slice.Changed -= this.OnSliceChanged;
				// Dispose the forms.
				this.formNodeProperties.Dispose();
				this.formSiteProperties.Dispose();
				this.formAddCommand.Dispose();
				this.formRunInformation.Dispose();
				// Dispose the manager history.
				this.managerHistory.Dispose();
				// Dispose the wait handles.
				this.toolWait.WaitOne();
				this.toolWait.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSliceRun));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelRun = new DotNetApi.Windows.Controls.ThemeControl();
			this.tabControl = new DotNetApi.Windows.Controls.ThemeTabControl();
			this.tabPageNodes = new System.Windows.Forms.TabPage();
			this.splitContainerNodes = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderHostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStripNodes = new System.Windows.Forms.ToolStrip();
			this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
			this.buttonCancel = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonNodesSelectAll = new System.Windows.Forms.ToolStripButton();
			this.buttonNodesClearAll = new System.Windows.Forms.ToolStripButton();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonProperties = new System.Windows.Forms.ToolStripDropDownButton();
			this.buttonNodeProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonSiteProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.numericUpDownNodesRetries = new System.Windows.Forms.NumericUpDown();
			this.labelNodesRetries = new System.Windows.Forms.Label();
			this.toolStripConfig = new System.Windows.Forms.ToolStrip();
			this.buttonConfigSave = new System.Windows.Forms.ToolStripButton();
			this.buttonConfigUndo = new System.Windows.Forms.ToolStripButton();
			this.numericUpDownNodesParallel = new System.Windows.Forms.NumericUpDown();
			this.labelNodesParallel = new System.Windows.Forms.Label();
			this.checkBoxNodesSite = new System.Windows.Forms.CheckBox();
			this.checkBoxNodesBoot = new System.Windows.Forms.CheckBox();
			this.checkBoxNodesUpdate = new System.Windows.Forms.CheckBox();
			this.tabPageCommands = new System.Windows.Forms.TabPage();
			this.splitContainerCommands = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.listCommands = new InetAnalytics.Controls.PlanetLab.Commands.CommandListBox();
			this.toolStripCommands = new System.Windows.Forms.ToolStrip();
			this.buttonAddCommand = new System.Windows.Forms.ToolStripButton();
			this.buttonRemoveCommand = new System.Windows.Forms.ToolStripButton();
			this.controlCommand = new InetAnalytics.Controls.PlanetLab.ControlCommand();
			this.tabPageProgress = new System.Windows.Forms.TabPage();
			this.listProgress = new DotNetApi.Windows.Controls.ProgressListBox();
			this.progress = new DotNetApi.Windows.Controls.NotificationPanel();
			this.tabPageResults = new System.Windows.Forms.TabPage();
			this.splitContainerProgress = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.listViewResults = new System.Windows.Forms.ListView();
			this.columnHeaderCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderExitStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.controlResult = new InetAnalytics.Controls.PlanetLab.Commands.ControlCommandResult();
			this.tableResults = new System.Windows.Forms.TableLayoutPanel();
			this.comboBoxNodes = new System.Windows.Forms.ComboBox();
			this.labelResults = new System.Windows.Forms.Label();
			this.tabPageTools = new System.Windows.Forms.TabPage();
			this.controlMethods = new InetAnalytics.Controls.Tools.ControlMethods();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonPause = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.controlLog = new InetAnalytics.Controls.Log.ControlLogList();
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.contextMenuNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemNodeProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSiteProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.progressLegend = new DotNetApi.Windows.Controls.ProgressLegend();
			this.progressLegendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.progressLegendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.progressLegendItemError = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.progressLegendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelRun.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageNodes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerNodes)).BeginInit();
			this.splitContainerNodes.Panel1.SuspendLayout();
			this.splitContainerNodes.Panel2.SuspendLayout();
			this.splitContainerNodes.SuspendLayout();
			this.toolStripNodes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNodesRetries)).BeginInit();
			this.toolStripConfig.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNodesParallel)).BeginInit();
			this.tabPageCommands.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerCommands)).BeginInit();
			this.splitContainerCommands.Panel1.SuspendLayout();
			this.splitContainerCommands.Panel2.SuspendLayout();
			this.splitContainerCommands.SuspendLayout();
			this.toolStripCommands.SuspendLayout();
			this.tabPageProgress.SuspendLayout();
			this.tabPageResults.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerProgress)).BeginInit();
			this.splitContainerProgress.Panel1.SuspendLayout();
			this.splitContainerProgress.Panel2.SuspendLayout();
			this.splitContainerProgress.SuspendLayout();
			this.tableResults.SuspendLayout();
			this.tabPageTools.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.contextMenuNodes.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.panelRun);
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
			// panelRun
			// 
			this.panelRun.Controls.Add(this.tabControl);
			this.panelRun.Controls.Add(this.toolStrip);
			this.panelRun.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRun.Location = new System.Drawing.Point(0, 0);
			this.panelRun.Name = "panelRun";
			this.panelRun.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.panelRun.ShowBorder = true;
			this.panelRun.ShowTitle = true;
			this.panelRun.Size = new System.Drawing.Size(800, 425);
			this.panelRun.TabIndex = 1;
			this.panelRun.Title = "Run on PlanetLab Slice";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageNodes);
			this.tabControl.Controls.Add(this.tabPageCommands);
			this.tabControl.Controls.Add(this.tabPageProgress);
			this.tabControl.Controls.Add(this.tabPageResults);
			this.tabControl.Controls.Add(this.tabPageTools);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(1, 48);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(798, 376);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageNodes
			// 
			this.tabPageNodes.Controls.Add(this.splitContainerNodes);
			this.tabPageNodes.Location = new System.Drawing.Point(2, 23);
			this.tabPageNodes.Name = "tabPageNodes";
			this.tabPageNodes.Padding = new System.Windows.Forms.Padding(5);
			this.tabPageNodes.Size = new System.Drawing.Size(794, 351);
			this.tabPageNodes.TabIndex = 0;
			this.tabPageNodes.Text = "Nodes";
			this.tabPageNodes.UseVisualStyleBackColor = true;
			// 
			// splitContainerNodes
			// 
			this.splitContainerNodes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerNodes.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerNodes.Location = new System.Drawing.Point(5, 5);
			this.splitContainerNodes.Name = "splitContainerNodes";
			// 
			// splitContainerNodes.Panel1
			// 
			this.splitContainerNodes.Panel1.Controls.Add(this.listViewNodes);
			this.splitContainerNodes.Panel1.Controls.Add(this.toolStripNodes);
			this.splitContainerNodes.Panel1.Padding = new System.Windows.Forms.Padding(1);
			// 
			// splitContainerNodes.Panel2
			// 
			this.splitContainerNodes.Panel2.AutoScroll = true;
			this.splitContainerNodes.Panel2.Controls.Add(this.numericUpDownNodesRetries);
			this.splitContainerNodes.Panel2.Controls.Add(this.labelNodesRetries);
			this.splitContainerNodes.Panel2.Controls.Add(this.toolStripConfig);
			this.splitContainerNodes.Panel2.Controls.Add(this.numericUpDownNodesParallel);
			this.splitContainerNodes.Panel2.Controls.Add(this.labelNodesParallel);
			this.splitContainerNodes.Panel2.Controls.Add(this.checkBoxNodesSite);
			this.splitContainerNodes.Panel2.Controls.Add(this.checkBoxNodesBoot);
			this.splitContainerNodes.Panel2.Controls.Add(this.checkBoxNodesUpdate);
			this.splitContainerNodes.Panel2.Padding = new System.Windows.Forms.Padding(1);
			this.splitContainerNodes.Size = new System.Drawing.Size(784, 341);
			this.splitContainerNodes.SplitterDistance = 398;
			this.splitContainerNodes.SplitterWidth = 5;
			this.splitContainerNodes.TabIndex = 0;
			this.splitContainerNodes.UseTheme = false;
			// 
			// listViewNodes
			// 
			this.listViewNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewNodes.CheckBoxes = true;
			this.listViewNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderHostname,
            this.columnHeaderSite,
            this.columnHeaderState});
			this.listViewNodes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewNodes.FullRowSelect = true;
			this.listViewNodes.GridLines = true;
			this.listViewNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewNodes.HideSelection = false;
			this.listViewNodes.Location = new System.Drawing.Point(1, 26);
			this.listViewNodes.MultiSelect = false;
			this.listViewNodes.Name = "listViewNodes";
			this.listViewNodes.Size = new System.Drawing.Size(396, 314);
			this.listViewNodes.SmallImageList = this.imageList;
			this.listViewNodes.TabIndex = 1;
			this.listViewNodes.UseCompatibleStateImageBehavior = false;
			this.listViewNodes.View = System.Windows.Forms.View.Details;
			this.listViewNodes.ItemActivate += new System.EventHandler(this.OnNodeProperties);
			this.listViewNodes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnNodeCheckChanged);
			this.listViewNodes.SelectedIndexChanged += new System.EventHandler(this.OnNodeSelectionChanged);
			this.listViewNodes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnNodesMouseClick);
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
			this.columnHeaderId.Width = 120;
			// 
			// columnHeaderHostname
			// 
			this.columnHeaderHostname.Text = "Hostname";
			this.columnHeaderHostname.Width = 180;
			// 
			// columnHeaderSite
			// 
			this.columnHeaderSite.Text = "Site";
			this.columnHeaderSite.Width = 180;
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
			this.imageList.Images.SetKeyName(5, "Success");
			this.imageList.Images.SetKeyName(6, "Warning");
			this.imageList.Images.SetKeyName(7, "Error");
			// 
			// toolStripNodes
			// 
			this.toolStripNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefresh,
            this.buttonCancel,
            this.separator1,
            this.buttonNodesSelectAll,
            this.buttonNodesClearAll,
            this.separator2,
            this.buttonProperties});
			this.toolStripNodes.Location = new System.Drawing.Point(1, 1);
			this.toolStripNodes.Name = "toolStripNodes";
			this.toolStripNodes.Size = new System.Drawing.Size(396, 25);
			this.toolStripNodes.TabIndex = 2;
			this.toolStripNodes.Text = "toolStrip1";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Image = global::InetAnalytics.Resources.Refresh_16;
			this.buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(66, 22);
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefresh);
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
			// buttonNodesSelectAll
			// 
			this.buttonNodesSelectAll.Enabled = false;
			this.buttonNodesSelectAll.Image = global::InetAnalytics.Resources.SelectAll_16;
			this.buttonNodesSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonNodesSelectAll.Name = "buttonNodesSelectAll";
			this.buttonNodesSelectAll.Size = new System.Drawing.Size(73, 22);
			this.buttonNodesSelectAll.Text = "&Select all";
			this.buttonNodesSelectAll.Click += new System.EventHandler(this.OnSelectAllNodes);
			// 
			// buttonNodesClearAll
			// 
			this.buttonNodesClearAll.Enabled = false;
			this.buttonNodesClearAll.Image = global::InetAnalytics.Resources.ClearAll_16;
			this.buttonNodesClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonNodesClearAll.Name = "buttonNodesClearAll";
			this.buttonNodesClearAll.Size = new System.Drawing.Size(69, 22);
			this.buttonNodesClearAll.Text = "&Clear all";
			this.buttonNodesClearAll.Click += new System.EventHandler(this.OnClearAllNodes);
			// 
			// separator2
			// 
			this.separator2.Name = "separator2";
			this.separator2.Size = new System.Drawing.Size(6, 25);
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
			// numericUpDownNodesRetries
			// 
			this.numericUpDownNodesRetries.Location = new System.Drawing.Point(10, 156);
			this.numericUpDownNodesRetries.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDownNodesRetries.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownNodesRetries.Name = "numericUpDownNodesRetries";
			this.numericUpDownNodesRetries.Size = new System.Drawing.Size(150, 20);
			this.numericUpDownNodesRetries.TabIndex = 7;
			this.numericUpDownNodesRetries.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// labelNodesRetries
			// 
			this.labelNodesRetries.AutoSize = true;
			this.labelNodesRetries.Location = new System.Drawing.Point(7, 140);
			this.labelNodesRetries.Name = "labelNodesRetries";
			this.labelNodesRetries.Size = new System.Drawing.Size(260, 13);
			this.labelNodesRetries.TabIndex = 6;
			this.labelNodesRetries.Text = "If a command fails, &retry the following number of times:";
			// 
			// toolStripConfig
			// 
			this.toolStripConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonConfigSave,
            this.buttonConfigUndo});
			this.toolStripConfig.Location = new System.Drawing.Point(1, 1);
			this.toolStripConfig.Name = "toolStripConfig";
			this.toolStripConfig.Size = new System.Drawing.Size(379, 25);
			this.toolStripConfig.TabIndex = 5;
			this.toolStripConfig.Text = "toolStrip1";
			// 
			// buttonConfigSave
			// 
			this.buttonConfigSave.Enabled = false;
			this.buttonConfigSave.Image = global::InetAnalytics.Resources.Save_16;
			this.buttonConfigSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonConfigSave.Name = "buttonConfigSave";
			this.buttonConfigSave.Size = new System.Drawing.Size(51, 22);
			this.buttonConfigSave.Text = "&Save";
			this.buttonConfigSave.Click += new System.EventHandler(this.OnSaveConfiguration);
			// 
			// buttonConfigUndo
			// 
			this.buttonConfigUndo.Enabled = false;
			this.buttonConfigUndo.Image = global::InetAnalytics.Resources.UndoLarge_16;
			this.buttonConfigUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonConfigUndo.Name = "buttonConfigUndo";
			this.buttonConfigUndo.Size = new System.Drawing.Size(56, 22);
			this.buttonConfigUndo.Text = "&Undo";
			this.buttonConfigUndo.Click += new System.EventHandler(this.OnLoadConfiguration);
			// 
			// numericUpDownNodesParallel
			// 
			this.numericUpDownNodesParallel.Location = new System.Drawing.Point(10, 117);
			this.numericUpDownNodesParallel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDownNodesParallel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownNodesParallel.Name = "numericUpDownNodesParallel";
			this.numericUpDownNodesParallel.Size = new System.Drawing.Size(150, 20);
			this.numericUpDownNodesParallel.TabIndex = 4;
			this.numericUpDownNodesParallel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownNodesParallel.ValueChanged += new System.EventHandler(this.OnConfigurationChanged);
			// 
			// labelNodesParallel
			// 
			this.labelNodesParallel.AutoSize = true;
			this.labelNodesParallel.Location = new System.Drawing.Point(7, 101);
			this.labelNodesParallel.Name = "labelNodesParallel";
			this.labelNodesParallel.Size = new System.Drawing.Size(308, 13);
			this.labelNodesParallel.TabIndex = 3;
			this.labelNodesParallel.Text = "Run the commands in &parallel on the following number of nodes:";
			// 
			// checkBoxNodesSite
			// 
			this.checkBoxNodesSite.AutoSize = true;
			this.checkBoxNodesSite.Location = new System.Drawing.Point(10, 81);
			this.checkBoxNodesSite.Name = "checkBoxNodesSite";
			this.checkBoxNodesSite.Size = new System.Drawing.Size(199, 17);
			this.checkBoxNodesSite.TabIndex = 2;
			this.checkBoxNodesSite.Text = "Use a &single PlanetLab node per site";
			this.checkBoxNodesSite.UseVisualStyleBackColor = true;
			this.checkBoxNodesSite.CheckedChanged += new System.EventHandler(this.OnConfigurationChanged);
			// 
			// checkBoxNodesBoot
			// 
			this.checkBoxNodesBoot.AutoSize = true;
			this.checkBoxNodesBoot.Location = new System.Drawing.Point(10, 58);
			this.checkBoxNodesBoot.Name = "checkBoxNodesBoot";
			this.checkBoxNodesBoot.Size = new System.Drawing.Size(268, 17);
			this.checkBoxNodesBoot.TabIndex = 1;
			this.checkBoxNodesBoot.Text = "Only use the PlanetLab nodes that are in &boot state";
			this.checkBoxNodesBoot.UseVisualStyleBackColor = true;
			this.checkBoxNodesBoot.CheckedChanged += new System.EventHandler(this.OnConfigurationChanged);
			// 
			// checkBoxNodesUpdate
			// 
			this.checkBoxNodesUpdate.AutoSize = true;
			this.checkBoxNodesUpdate.Location = new System.Drawing.Point(10, 35);
			this.checkBoxNodesUpdate.Name = "checkBoxNodesUpdate";
			this.checkBoxNodesUpdate.Size = new System.Drawing.Size(267, 17);
			this.checkBoxNodesUpdate.TabIndex = 0;
			this.checkBoxNodesUpdate.Text = "&Update the PlanetLab nodes information before run";
			this.checkBoxNodesUpdate.UseVisualStyleBackColor = true;
			this.checkBoxNodesUpdate.CheckedChanged += new System.EventHandler(this.OnConfigurationChanged);
			// 
			// tabPageCommands
			// 
			this.tabPageCommands.Controls.Add(this.splitContainerCommands);
			this.tabPageCommands.Location = new System.Drawing.Point(2, 23);
			this.tabPageCommands.Name = "tabPageCommands";
			this.tabPageCommands.Padding = new System.Windows.Forms.Padding(5);
			this.tabPageCommands.Size = new System.Drawing.Size(794, 351);
			this.tabPageCommands.TabIndex = 1;
			this.tabPageCommands.Text = "Commands";
			this.tabPageCommands.UseVisualStyleBackColor = true;
			// 
			// splitContainerCommands
			// 
			this.splitContainerCommands.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerCommands.Location = new System.Drawing.Point(5, 5);
			this.splitContainerCommands.Name = "splitContainerCommands";
			// 
			// splitContainerCommands.Panel1
			// 
			this.splitContainerCommands.Panel1.Controls.Add(this.listCommands);
			this.splitContainerCommands.Panel1.Controls.Add(this.toolStripCommands);
			this.splitContainerCommands.Panel1.Padding = new System.Windows.Forms.Padding(1);
			// 
			// splitContainerCommands.Panel2
			// 
			this.splitContainerCommands.Panel2.Controls.Add(this.controlCommand);
			this.splitContainerCommands.Panel2Border = false;
			this.splitContainerCommands.Size = new System.Drawing.Size(784, 341);
			this.splitContainerCommands.SplitterDistance = 392;
			this.splitContainerCommands.SplitterWidth = 5;
			this.splitContainerCommands.TabIndex = 0;
			this.splitContainerCommands.UseTheme = false;
			// 
			// listCommands
			// 
			this.listCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listCommands.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listCommands.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listCommands.FormattingEnabled = true;
			this.listCommands.IntegralHeight = false;
			this.listCommands.ItemHeight = 48;
			this.listCommands.Location = new System.Drawing.Point(1, 26);
			this.listCommands.Name = "listCommands";
			this.listCommands.Size = new System.Drawing.Size(390, 314);
			this.listCommands.TabIndex = 0;
			this.listCommands.SelectedIndexChanged += new System.EventHandler(this.OnCommandSelectionChanged);
			// 
			// toolStripCommands
			// 
			this.toolStripCommands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAddCommand,
            this.buttonRemoveCommand});
			this.toolStripCommands.Location = new System.Drawing.Point(1, 1);
			this.toolStripCommands.Name = "toolStripCommands";
			this.toolStripCommands.Size = new System.Drawing.Size(390, 25);
			this.toolStripCommands.TabIndex = 1;
			this.toolStripCommands.Text = "toolStrip1";
			// 
			// buttonAddCommand
			// 
			this.buttonAddCommand.Image = global::InetAnalytics.Resources.ScriptLargeAdd_16;
			this.buttonAddCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAddCommand.Name = "buttonAddCommand";
			this.buttonAddCommand.Size = new System.Drawing.Size(107, 22);
			this.buttonAddCommand.Text = "&Add command";
			this.buttonAddCommand.Click += new System.EventHandler(this.OnAddCommand);
			// 
			// buttonRemoveCommand
			// 
			this.buttonRemoveCommand.Enabled = false;
			this.buttonRemoveCommand.Image = global::InetAnalytics.Resources.ScriptLargeRemove_16;
			this.buttonRemoveCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemoveCommand.Name = "buttonRemoveCommand";
			this.buttonRemoveCommand.Size = new System.Drawing.Size(128, 22);
			this.buttonRemoveCommand.Text = "&Remove command";
			this.buttonRemoveCommand.Click += new System.EventHandler(this.OnRemoveCommand);
			// 
			// controlCommand
			// 
			this.controlCommand.Command = null;
			this.controlCommand.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlCommand.HideSave = false;
			this.controlCommand.Location = new System.Drawing.Point(0, 0);
			this.controlCommand.Name = "controlCommand";
			this.controlCommand.Size = new System.Drawing.Size(387, 341);
			this.controlCommand.TabIndex = 0;
			this.controlCommand.CommandSaved += new System.EventHandler(this.OnCommandSaved);
			// 
			// tabPageProgress
			// 
			this.tabPageProgress.Controls.Add(this.listProgress);
			this.tabPageProgress.Controls.Add(this.progress);
			this.tabPageProgress.Location = new System.Drawing.Point(2, 23);
			this.tabPageProgress.Name = "tabPageProgress";
			this.tabPageProgress.Padding = new System.Windows.Forms.Padding(5);
			this.tabPageProgress.Size = new System.Drawing.Size(794, 351);
			this.tabPageProgress.TabIndex = 4;
			this.tabPageProgress.Text = "Progress";
			this.tabPageProgress.UseVisualStyleBackColor = true;
			// 
			// listProgress
			// 
			this.listProgress.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listProgress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listProgress.FormattingEnabled = true;
			this.listProgress.IntegralHeight = false;
			this.listProgress.ItemHeight = 48;
			this.listProgress.Location = new System.Drawing.Point(5, 69);
			this.listProgress.Name = "listProgress";
			this.listProgress.Size = new System.Drawing.Size(784, 277);
			this.listProgress.TabIndex = 3;
			// 
			// progress
			// 
			this.progress.Dock = System.Windows.Forms.DockStyle.Top;
			this.progress.Image = global::InetAnalytics.Resources.Globe_48;
			this.progress.Location = new System.Drawing.Point(5, 5);
			this.progress.MaximumSize = new System.Drawing.Size(0, 64);
			this.progress.Message = "Select the PlanetLab nodes and the commands you want to run and click Start.";
			this.progress.MinimumSize = new System.Drawing.Size(0, 64);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(784, 64);
			this.progress.TabIndex = 2;
			// 
			// tabPageResults
			// 
			this.tabPageResults.Controls.Add(this.splitContainerProgress);
			this.tabPageResults.Controls.Add(this.tableResults);
			this.tabPageResults.Location = new System.Drawing.Point(2, 23);
			this.tabPageResults.Name = "tabPageResults";
			this.tabPageResults.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageResults.Size = new System.Drawing.Size(794, 351);
			this.tabPageResults.TabIndex = 3;
			this.tabPageResults.Text = "Results";
			this.tabPageResults.UseVisualStyleBackColor = true;
			// 
			// splitContainerProgress
			// 
			this.splitContainerProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerProgress.Location = new System.Drawing.Point(3, 30);
			this.splitContainerProgress.Name = "splitContainerProgress";
			// 
			// splitContainerProgress.Panel1
			// 
			this.splitContainerProgress.Panel1.Controls.Add(this.listViewResults);
			this.splitContainerProgress.Panel1.Padding = new System.Windows.Forms.Padding(1);
			// 
			// splitContainerProgress.Panel2
			// 
			this.splitContainerProgress.Panel2.Controls.Add(this.controlResult);
			this.splitContainerProgress.Panel2.Padding = new System.Windows.Forms.Padding(1);
			this.splitContainerProgress.Size = new System.Drawing.Size(788, 318);
			this.splitContainerProgress.SplitterDistance = 394;
			this.splitContainerProgress.SplitterWidth = 5;
			this.splitContainerProgress.TabIndex = 0;
			this.splitContainerProgress.UseTheme = false;
			// 
			// listViewResults
			// 
			this.listViewResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCommand,
            this.columnHeaderExitStatus,
            this.columnHeaderDuration});
			this.listViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewResults.FullRowSelect = true;
			this.listViewResults.GridLines = true;
			this.listViewResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewResults.HideSelection = false;
			this.listViewResults.Location = new System.Drawing.Point(1, 1);
			this.listViewResults.MultiSelect = false;
			this.listViewResults.Name = "listViewResults";
			this.listViewResults.Size = new System.Drawing.Size(392, 316);
			this.listViewResults.SmallImageList = this.imageList;
			this.listViewResults.TabIndex = 0;
			this.listViewResults.UseCompatibleStateImageBehavior = false;
			this.listViewResults.View = System.Windows.Forms.View.Details;
			this.listViewResults.SelectedIndexChanged += new System.EventHandler(this.OnSelectedCommandChanged);
			// 
			// columnHeaderCommand
			// 
			this.columnHeaderCommand.Text = "Command";
			this.columnHeaderCommand.Width = 200;
			// 
			// columnHeaderExitStatus
			// 
			this.columnHeaderExitStatus.Text = "Exit status";
			this.columnHeaderExitStatus.Width = 100;
			// 
			// columnHeaderDuration
			// 
			this.columnHeaderDuration.Text = "Duration";
			this.columnHeaderDuration.Width = 100;
			// 
			// controlResult
			// 
			this.controlResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlResult.Location = new System.Drawing.Point(1, 1);
			this.controlResult.Name = "controlResult";
			this.controlResult.Result = null;
			this.controlResult.Size = new System.Drawing.Size(387, 316);
			this.controlResult.TabIndex = 0;
			// 
			// tableResults
			// 
			this.tableResults.AutoSize = true;
			this.tableResults.ColumnCount = 2;
			this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableResults.Controls.Add(this.comboBoxNodes, 1, 0);
			this.tableResults.Controls.Add(this.labelResults, 0, 0);
			this.tableResults.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableResults.Location = new System.Drawing.Point(3, 3);
			this.tableResults.Name = "tableResults";
			this.tableResults.RowCount = 1;
			this.tableResults.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableResults.Size = new System.Drawing.Size(788, 27);
			this.tableResults.TabIndex = 4;
			// 
			// comboBoxNodes
			// 
			this.comboBoxNodes.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboBoxNodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxNodes.FormattingEnabled = true;
			this.comboBoxNodes.Location = new System.Drawing.Point(76, 3);
			this.comboBoxNodes.Name = "comboBoxNodes";
			this.comboBoxNodes.Size = new System.Drawing.Size(709, 21);
			this.comboBoxNodes.TabIndex = 1;
			this.comboBoxNodes.SelectedIndexChanged += new System.EventHandler(this.OnResultsNodeChanged);
			// 
			// labelResults
			// 
			this.labelResults.AutoSize = true;
			this.labelResults.Location = new System.Drawing.Point(3, 0);
			this.labelResults.Name = "labelResults";
			this.labelResults.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.labelResults.Size = new System.Drawing.Size(67, 19);
			this.labelResults.TabIndex = 0;
			this.labelResults.Text = "&Select node:";
			// 
			// tabPageTools
			// 
			this.tabPageTools.Controls.Add(this.controlMethods);
			this.tabPageTools.Location = new System.Drawing.Point(2, 23);
			this.tabPageTools.Name = "tabPageTools";
			this.tabPageTools.Padding = new System.Windows.Forms.Padding(5);
			this.tabPageTools.Size = new System.Drawing.Size(794, 351);
			this.tabPageTools.TabIndex = 5;
			this.tabPageTools.Text = "Tools";
			this.tabPageTools.UseVisualStyleBackColor = true;
			// 
			// controlMethods
			// 
			this.controlMethods.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlMethods.Enabled = false;
			this.controlMethods.Location = new System.Drawing.Point(5, 5);
			this.controlMethods.Name = "controlMethods";
			this.controlMethods.Size = new System.Drawing.Size(784, 341);
			this.controlMethods.TabIndex = 0;
			this.controlMethods.Changed += new System.EventHandler(this.OnMethodsChanged);
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonStart,
            this.buttonPause,
            this.buttonStop});
			this.toolStrip.Location = new System.Drawing.Point(1, 23);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonStart
			// 
			this.buttonStart.Enabled = false;
			this.buttonStart.Image = global::InetAnalytics.Resources.PlayStart_16;
			this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(51, 22);
			this.buttonStart.Text = "St&art";
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonPause
			// 
			this.buttonPause.Enabled = false;
			this.buttonPause.Image = global::InetAnalytics.Resources.PlayPause_16;
			this.buttonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonPause.Name = "buttonPause";
			this.buttonPause.Size = new System.Drawing.Size(58, 22);
			this.buttonPause.Text = "&Pause";
			this.buttonPause.Click += new System.EventHandler(this.OnPause);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::InetAnalytics.Resources.PlayStop_16;
			this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(51, 22);
			this.buttonStop.Text = "St&op";
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
			// 
			// controlLog
			// 
			this.controlLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLog.Location = new System.Drawing.Point(0, 0);
			this.controlLog.Name = "controlLog";
			this.controlLog.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
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
			// contextMenuNodes
			// 
			this.contextMenuNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNodeProperties,
            this.menuItemSiteProperties});
			this.contextMenuNodes.Name = "contextMenu";
			this.contextMenuNodes.Size = new System.Drawing.Size(160, 48);
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
			// progressLegend
			// 
			this.progressLegend.Items.AddRange(new DotNetApi.Windows.Controls.ProgressLegendItem[] {
            this.progressLegendItemSuccess,
            this.progressLegendItemWarning,
            this.progressLegendItemError,
            this.progressLegendItemPending});
			// 
			// progressLegendItemSuccess
			// 
			this.progressLegendItemSuccess.Color = System.Drawing.Color.ForestGreen;
			this.progressLegendItemSuccess.Text = "Success";
			// 
			// progressLegendItemWarning
			// 
			this.progressLegendItemWarning.Color = System.Drawing.Color.Gold;
			this.progressLegendItemWarning.Text = "Warning";
			// 
			// progressLegendItemError
			// 
			this.progressLegendItemError.Color = System.Drawing.Color.DarkRed;
			this.progressLegendItemError.Text = "Error";
			// 
			// progressLegendItemPending
			// 
			this.progressLegendItemPending.Color = System.Drawing.Color.LightGray;
			this.progressLegendItemPending.Text = "Pending";
			// 
			// ControlSliceRun
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlSliceRun";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelRun.ResumeLayout(false);
			this.panelRun.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageNodes.ResumeLayout(false);
			this.splitContainerNodes.Panel1.ResumeLayout(false);
			this.splitContainerNodes.Panel1.PerformLayout();
			this.splitContainerNodes.Panel2.ResumeLayout(false);
			this.splitContainerNodes.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerNodes)).EndInit();
			this.splitContainerNodes.ResumeLayout(false);
			this.toolStripNodes.ResumeLayout(false);
			this.toolStripNodes.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNodesRetries)).EndInit();
			this.toolStripConfig.ResumeLayout(false);
			this.toolStripConfig.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNodesParallel)).EndInit();
			this.tabPageCommands.ResumeLayout(false);
			this.splitContainerCommands.Panel1.ResumeLayout(false);
			this.splitContainerCommands.Panel1.PerformLayout();
			this.splitContainerCommands.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerCommands)).EndInit();
			this.splitContainerCommands.ResumeLayout(false);
			this.toolStripCommands.ResumeLayout(false);
			this.toolStripCommands.PerformLayout();
			this.tabPageProgress.ResumeLayout(false);
			this.tabPageResults.ResumeLayout(false);
			this.tabPageResults.PerformLayout();
			this.splitContainerProgress.Panel1.ResumeLayout(false);
			this.splitContainerProgress.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerProgress)).EndInit();
			this.splitContainerProgress.ResumeLayout(false);
			this.tableResults.ResumeLayout(false);
			this.tableResults.PerformLayout();
			this.tabPageTools.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.contextMenuNodes.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemPending;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemSuccess;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemFail;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemWarning;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ImageList imageList;
		private Log.ControlLogList controlLog;
		private DotNetApi.Windows.Controls.ThemeControl panelRun;
		private DotNetApi.Windows.Controls.ThemeTabControl tabControl;
		private System.Windows.Forms.TabPage tabPageNodes;
		private System.Windows.Forms.TabPage tabPageCommands;
		private System.Windows.Forms.TabPage tabPageResults;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerNodes;
		private System.Windows.Forms.CheckBox checkBoxNodesBoot;
		private System.Windows.Forms.CheckBox checkBoxNodesUpdate;
		private System.Windows.Forms.CheckBox checkBoxNodesSite;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderHostname;
		private System.Windows.Forms.NumericUpDown numericUpDownNodesParallel;
		private System.Windows.Forms.Label labelNodesParallel;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerCommands;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private System.Windows.Forms.ToolStripButton buttonPause;
		private Commands.CommandListBox listCommands;
		private ControlCommand controlCommand;
		private System.Windows.Forms.ColumnHeader columnHeaderSite;
		private System.Windows.Forms.ToolStrip toolStripConfig;
		private System.Windows.Forms.ToolStripButton buttonConfigSave;
		private System.Windows.Forms.ToolStripButton buttonConfigUndo;
		private System.Windows.Forms.ContextMenuStrip contextMenuNodes;
		private System.Windows.Forms.ToolStripMenuItem menuItemNodeProperties;
		private System.Windows.Forms.ToolStripMenuItem menuItemSiteProperties;
		private System.Windows.Forms.ToolStrip toolStripNodes;
		private System.Windows.Forms.ToolStripButton buttonNodesSelectAll;
		private System.Windows.Forms.ToolStripButton buttonNodesClearAll;
		private System.Windows.Forms.TabPage tabPageProgress;
		private DotNetApi.Windows.Controls.ProgressLegend progressLegend;
		private DotNetApi.Windows.Controls.ProgressLegendItem progressLegendItemPending;
		private DotNetApi.Windows.Controls.ProgressLegendItem progressLegendItemSuccess;
		private DotNetApi.Windows.Controls.ProgressLegendItem progressLegendItemWarning;
		private DotNetApi.Windows.Controls.ProgressLegendItem progressLegendItemError;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripDropDownButton buttonProperties;
		private System.Windows.Forms.ToolStripMenuItem buttonNodeProperties;
		private System.Windows.Forms.ToolStripMenuItem buttonSiteProperties;
		private System.Windows.Forms.ToolStripButton buttonRefresh;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripButton buttonCancel;
		private System.Windows.Forms.ToolStrip toolStripCommands;
		private System.Windows.Forms.ToolStripButton buttonAddCommand;
		private System.Windows.Forms.ToolStripButton buttonRemoveCommand;
		private System.Windows.Forms.ColumnHeader columnHeaderState;
		private DotNetApi.Windows.Controls.NotificationPanel progress;
		private DotNetApi.Windows.Controls.ProgressListBox listProgress;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerProgress;
		private System.Windows.Forms.TableLayoutPanel tableResults;
		private System.Windows.Forms.ComboBox comboBoxNodes;
		private System.Windows.Forms.Label labelResults;
		private System.Windows.Forms.ListView listViewResults;
		private System.Windows.Forms.ColumnHeader columnHeaderCommand;
		private System.Windows.Forms.ColumnHeader columnHeaderExitStatus;
		private System.Windows.Forms.ColumnHeader columnHeaderDuration;
		private Commands.ControlCommandResult controlResult;
		private System.Windows.Forms.NumericUpDown numericUpDownNodesRetries;
		private System.Windows.Forms.Label labelNodesRetries;
		private System.Windows.Forms.TabPage tabPageTools;
		private Tools.ControlMethods controlMethods;
	}
}
