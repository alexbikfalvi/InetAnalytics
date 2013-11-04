namespace InetAnalytics.Controls.Database
{
	partial class ControlServer
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
			// Clear the items such that database events do not call handles on disposed components.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlServer));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonConnect = new System.Windows.Forms.ToolStripButton();
			this.buttonDisconnect = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonPrimary = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonChangePassword = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonProperties = new System.Windows.Forms.ToolStripButton();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.panel = new System.Windows.Forms.Panel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageDatabase = new System.Windows.Forms.TabPage();
			this.buttonDatabaseSelect = new System.Windows.Forms.Button();
			this.listViewDatabases = new System.Windows.Forms.ListView();
			this.columnHeaderDatabaseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDatabaseId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDatabaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
			this.buttonDatabaseRefresh = new System.Windows.Forms.Button();
			this.labelDatabaseSelect = new System.Windows.Forms.Label();
			this.buttonDatabaseProperties = new System.Windows.Forms.Button();
			this.textBoxDatabase = new System.Windows.Forms.TextBox();
			this.labelDatabaseCurrent = new System.Windows.Forms.Label();
			this.labelDatabaseTitle = new System.Windows.Forms.Label();
			this.pictureBoxDatabase = new System.Windows.Forms.PictureBox();
			this.tabPageTables = new System.Windows.Forms.TabPage();
			this.buttonTableProperties = new System.Windows.Forms.Button();
			this.listViewTables = new System.Windows.Forms.ListView();
			this.columnHeaderTableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderTableFields = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
			this.labelTablesSelect = new System.Windows.Forms.Label();
			this.labelTablesTitle = new System.Windows.Forms.Label();
			this.pictureBoxTables = new System.Windows.Forms.PictureBox();
			this.tabPageRelationships = new System.Windows.Forms.TabPage();
			this.buttonRelationshipProperties = new System.Windows.Forms.Button();
			this.labelRelationshipSelect = new System.Windows.Forms.Label();
			this.listViewRelationships = new System.Windows.Forms.ListView();
			this.columnHeaderLeftTable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLeftField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderRightTable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderRightField = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labelRelationships = new System.Windows.Forms.Label();
			this.pictureBoxRelationships = new System.Windows.Forms.PictureBox();
			this.labelPrimary = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.log = new InetAnalytics.Controls.Log.ControlLogList();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageDatabase.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatabase)).BeginInit();
			this.tabPageTables.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTables)).BeginInit();
			this.tabPageRelationships.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxRelationships)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonConnect,
            this.buttonDisconnect,
            this.toolStripSeparator1,
            this.buttonPrimary,
            this.toolStripSeparator2,
            this.buttonChangePassword,
            this.toolStripSeparator3,
            this.buttonProperties});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// buttonConnect
			// 
			this.buttonConnect.Enabled = false;
			this.buttonConnect.Image = global::InetAnalytics.Resources.Connect_16;
			this.buttonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(72, 22);
			this.buttonConnect.Text = "&Connect";
			this.buttonConnect.Click += new System.EventHandler(this.OnConnect);
			// 
			// buttonDisconnect
			// 
			this.buttonDisconnect.Enabled = false;
			this.buttonDisconnect.Image = global::InetAnalytics.Resources.Disconnect_16;
			this.buttonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonDisconnect.Name = "buttonDisconnect";
			this.buttonDisconnect.Size = new System.Drawing.Size(86, 22);
			this.buttonDisconnect.Text = "&Disconnect";
			this.buttonDisconnect.Click += new System.EventHandler(this.OnDisconnect);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonPrimary
			// 
			this.buttonPrimary.Enabled = false;
			this.buttonPrimary.Image = global::InetAnalytics.Resources.ServerStar_16;
			this.buttonPrimary.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonPrimary.Name = "buttonPrimary";
			this.buttonPrimary.Size = new System.Drawing.Size(100, 22);
			this.buttonPrimary.Text = "Make &primary";
			this.buttonPrimary.Click += new System.EventHandler(this.OnMakePrimary);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonChangePassword
			// 
			this.buttonChangePassword.Image = global::InetAnalytics.Resources.PasswordChange_16;
			this.buttonChangePassword.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonChangePassword.Name = "buttonChangePassword";
			this.buttonChangePassword.Size = new System.Drawing.Size(121, 22);
			this.buttonChangePassword.Text = "Cha&nge password";
			this.buttonChangePassword.Click += new System.EventHandler(this.OnChangePassword);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonProperties
			// 
			this.buttonProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.buttonProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonProperties.Name = "buttonProperties";
			this.buttonProperties.Size = new System.Drawing.Size(80, 22);
			this.buttonProperties.Text = "P&roperties";
			this.buttonProperties.Click += new System.EventHandler(this.OnProperties);
			// 
			// splitContainer
			// 
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.panel);
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.TabIndex = 1;
			// 
			// panel
			// 
			this.panel.AutoScroll = true;
			this.panel.Controls.Add(this.tabControl);
			this.panel.Controls.Add(this.labelPrimary);
			this.panel.Controls.Add(this.labelName);
			this.panel.Controls.Add(this.pictureBox);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 25);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(798, 398);
			this.panel.TabIndex = 0;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageDatabase);
			this.tabControl.Controls.Add(this.tabPageTables);
			this.tabControl.Controls.Add(this.tabPageRelationships);
			this.tabControl.Location = new System.Drawing.Point(10, 64);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(780, 325);
			this.tabControl.TabIndex = 2;
			// 
			// tabPageDatabase
			// 
			this.tabPageDatabase.Controls.Add(this.buttonDatabaseSelect);
			this.tabPageDatabase.Controls.Add(this.listViewDatabases);
			this.tabPageDatabase.Controls.Add(this.buttonDatabaseRefresh);
			this.tabPageDatabase.Controls.Add(this.labelDatabaseSelect);
			this.tabPageDatabase.Controls.Add(this.buttonDatabaseProperties);
			this.tabPageDatabase.Controls.Add(this.textBoxDatabase);
			this.tabPageDatabase.Controls.Add(this.labelDatabaseCurrent);
			this.tabPageDatabase.Controls.Add(this.labelDatabaseTitle);
			this.tabPageDatabase.Controls.Add(this.pictureBoxDatabase);
			this.tabPageDatabase.Location = new System.Drawing.Point(4, 22);
			this.tabPageDatabase.Name = "tabPageDatabase";
			this.tabPageDatabase.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDatabase.Size = new System.Drawing.Size(772, 299);
			this.tabPageDatabase.TabIndex = 0;
			this.tabPageDatabase.Text = "Database";
			this.tabPageDatabase.UseVisualStyleBackColor = true;
			// 
			// buttonDatabaseSelect
			// 
			this.buttonDatabaseSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDatabaseSelect.Enabled = false;
			this.buttonDatabaseSelect.Location = new System.Drawing.Point(651, 111);
			this.buttonDatabaseSelect.Name = "buttonDatabaseSelect";
			this.buttonDatabaseSelect.Size = new System.Drawing.Size(95, 23);
			this.buttonDatabaseSelect.TabIndex = 7;
			this.buttonDatabaseSelect.Text = "Make current";
			this.buttonDatabaseSelect.UseVisualStyleBackColor = true;
			this.buttonDatabaseSelect.Click += new System.EventHandler(this.OnDatabaseSelect);
			// 
			// listViewDatabases
			// 
			this.listViewDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewDatabases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDatabaseName,
            this.columnHeaderDatabaseId,
            this.columnHeaderDatabaseDate});
			this.listViewDatabases.FullRowSelect = true;
			this.listViewDatabases.GridLines = true;
			this.listViewDatabases.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewDatabases.HideSelection = false;
			this.listViewDatabases.Location = new System.Drawing.Point(155, 81);
			this.listViewDatabases.MultiSelect = false;
			this.listViewDatabases.Name = "listViewDatabases";
			this.listViewDatabases.Size = new System.Drawing.Size(490, 212);
			this.listViewDatabases.SmallImageList = this.imageListSmall;
			this.listViewDatabases.TabIndex = 5;
			this.listViewDatabases.UseCompatibleStateImageBehavior = false;
			this.listViewDatabases.View = System.Windows.Forms.View.Details;
			this.listViewDatabases.ItemActivate += new System.EventHandler(this.OnDatabaseProperties);
			this.listViewDatabases.SelectedIndexChanged += new System.EventHandler(this.OnDatabaseSelectionChanged);
			// 
			// columnHeaderDatabaseName
			// 
			this.columnHeaderDatabaseName.Text = "Name";
			this.columnHeaderDatabaseName.Width = 180;
			// 
			// columnHeaderDatabaseId
			// 
			this.columnHeaderDatabaseId.Text = "ID";
			// 
			// columnHeaderDatabaseDate
			// 
			this.columnHeaderDatabaseDate.Text = "Creation date";
			this.columnHeaderDatabaseDate.Width = 180;
			// 
			// imageListSmall
			// 
			this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
			this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListSmall.Images.SetKeyName(0, "Database");
			this.imageListSmall.Images.SetKeyName(1, "DatabaseStar");
			this.imageListSmall.Images.SetKeyName(2, "TableSuccess");
			this.imageListSmall.Images.SetKeyName(3, "TableWarning");
			this.imageListSmall.Images.SetKeyName(4, "Relationship");
			// 
			// buttonDatabaseRefresh
			// 
			this.buttonDatabaseRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDatabaseRefresh.Image = global::InetAnalytics.Resources.Refresh_16;
			this.buttonDatabaseRefresh.Location = new System.Drawing.Point(651, 82);
			this.buttonDatabaseRefresh.Name = "buttonDatabaseRefresh";
			this.buttonDatabaseRefresh.Size = new System.Drawing.Size(95, 23);
			this.buttonDatabaseRefresh.TabIndex = 6;
			this.buttonDatabaseRefresh.Text = "Refresh";
			this.buttonDatabaseRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonDatabaseRefresh.UseVisualStyleBackColor = true;
			this.buttonDatabaseRefresh.Click += new System.EventHandler(this.OnRefreshDatabases);
			// 
			// labelDatabaseSelect
			// 
			this.labelDatabaseSelect.AutoSize = true;
			this.labelDatabaseSelect.Location = new System.Drawing.Point(17, 87);
			this.labelDatabaseSelect.Name = "labelDatabaseSelect";
			this.labelDatabaseSelect.Size = new System.Drawing.Size(96, 13);
			this.labelDatabaseSelect.TabIndex = 4;
			this.labelDatabaseSelect.Text = "Select a database:";
			// 
			// buttonDatabaseProperties
			// 
			this.buttonDatabaseProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDatabaseProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.buttonDatabaseProperties.Location = new System.Drawing.Point(651, 53);
			this.buttonDatabaseProperties.Name = "buttonDatabaseProperties";
			this.buttonDatabaseProperties.Size = new System.Drawing.Size(95, 23);
			this.buttonDatabaseProperties.TabIndex = 3;
			this.buttonDatabaseProperties.Text = "Properties";
			this.buttonDatabaseProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonDatabaseProperties.UseVisualStyleBackColor = true;
			this.buttonDatabaseProperties.Click += new System.EventHandler(this.OnDatabaseProperties);
			// 
			// textBoxDatabase
			// 
			this.textBoxDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDatabase.Location = new System.Drawing.Point(155, 55);
			this.textBoxDatabase.Name = "textBoxDatabase";
			this.textBoxDatabase.Size = new System.Drawing.Size(490, 20);
			this.textBoxDatabase.TabIndex = 2;
			// 
			// labelDatabaseCurrent
			// 
			this.labelDatabaseCurrent.AutoSize = true;
			this.labelDatabaseCurrent.Location = new System.Drawing.Point(17, 58);
			this.labelDatabaseCurrent.Name = "labelDatabaseCurrent";
			this.labelDatabaseCurrent.Size = new System.Drawing.Size(122, 13);
			this.labelDatabaseCurrent.TabIndex = 1;
			this.labelDatabaseCurrent.Text = "The current database is:";
			// 
			// labelDatabaseTitle
			// 
			this.labelDatabaseTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDatabaseTitle.Location = new System.Drawing.Point(59, 20);
			this.labelDatabaseTitle.Name = "labelDatabaseTitle";
			this.labelDatabaseTitle.Size = new System.Drawing.Size(707, 32);
			this.labelDatabaseTitle.TabIndex = 0;
			this.labelDatabaseTitle.Text = "Use this tab to select the SQL database you want to use for storing the YouTube d" +
    "ata.";
			this.labelDatabaseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBoxDatabase
			// 
			this.pictureBoxDatabase.Image = global::InetAnalytics.Resources.Database_32;
			this.pictureBoxDatabase.Location = new System.Drawing.Point(20, 20);
			this.pictureBoxDatabase.Name = "pictureBoxDatabase";
			this.pictureBoxDatabase.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxDatabase.TabIndex = 1;
			this.pictureBoxDatabase.TabStop = false;
			// 
			// tabPageTables
			// 
			this.tabPageTables.Controls.Add(this.buttonTableProperties);
			this.tabPageTables.Controls.Add(this.listViewTables);
			this.tabPageTables.Controls.Add(this.labelTablesSelect);
			this.tabPageTables.Controls.Add(this.labelTablesTitle);
			this.tabPageTables.Controls.Add(this.pictureBoxTables);
			this.tabPageTables.Location = new System.Drawing.Point(4, 22);
			this.tabPageTables.Name = "tabPageTables";
			this.tabPageTables.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTables.Size = new System.Drawing.Size(772, 299);
			this.tabPageTables.TabIndex = 1;
			this.tabPageTables.Text = "Tables";
			this.tabPageTables.UseVisualStyleBackColor = true;
			// 
			// buttonTableProperties
			// 
			this.buttonTableProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonTableProperties.Enabled = false;
			this.buttonTableProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.buttonTableProperties.Location = new System.Drawing.Point(651, 55);
			this.buttonTableProperties.Name = "buttonTableProperties";
			this.buttonTableProperties.Size = new System.Drawing.Size(95, 23);
			this.buttonTableProperties.TabIndex = 8;
			this.buttonTableProperties.Text = "Configure";
			this.buttonTableProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonTableProperties.UseVisualStyleBackColor = true;
			this.buttonTableProperties.Click += new System.EventHandler(this.OnTableProperties);
			// 
			// listViewTables
			// 
			this.listViewTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTableName,
            this.columnHeaderTableFields});
			this.listViewTables.FullRowSelect = true;
			this.listViewTables.GridLines = true;
			this.listViewTables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewTables.HideSelection = false;
			this.listViewTables.LargeImageList = this.imageListLarge;
			this.listViewTables.Location = new System.Drawing.Point(155, 55);
			this.listViewTables.MultiSelect = false;
			this.listViewTables.Name = "listViewTables";
			this.listViewTables.Size = new System.Drawing.Size(490, 238);
			this.listViewTables.SmallImageList = this.imageListSmall;
			this.listViewTables.TabIndex = 7;
			this.listViewTables.UseCompatibleStateImageBehavior = false;
			this.listViewTables.View = System.Windows.Forms.View.Tile;
			this.listViewTables.ItemActivate += new System.EventHandler(this.OnTableProperties);
			this.listViewTables.SelectedIndexChanged += new System.EventHandler(this.OnTableSelectionChanged);
			// 
			// imageListLarge
			// 
			this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
			this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListLarge.Images.SetKeyName(0, "Database");
			this.imageListLarge.Images.SetKeyName(1, "DatabaseStar");
			this.imageListLarge.Images.SetKeyName(2, "TableSuccess");
			this.imageListLarge.Images.SetKeyName(3, "TableWarning");
			// 
			// labelTablesSelect
			// 
			this.labelTablesSelect.AutoSize = true;
			this.labelTablesSelect.Location = new System.Drawing.Point(17, 60);
			this.labelTablesSelect.Name = "labelTablesSelect";
			this.labelTablesSelect.Size = new System.Drawing.Size(75, 13);
			this.labelTablesSelect.TabIndex = 6;
			this.labelTablesSelect.Text = "Select a table:";
			// 
			// labelTablesTitle
			// 
			this.labelTablesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTablesTitle.Location = new System.Drawing.Point(58, 20);
			this.labelTablesTitle.Name = "labelTablesTitle";
			this.labelTablesTitle.Size = new System.Drawing.Size(707, 32);
			this.labelTablesTitle.TabIndex = 2;
			this.labelTablesTitle.Text = "Use this tab to configure the SQL tables storing the YouTube data. Select one of " +
    "the available tables, and map it to a database tables.";
			this.labelTablesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBoxTables
			// 
			this.pictureBoxTables.Image = global::InetAnalytics.Resources.Table_32;
			this.pictureBoxTables.Location = new System.Drawing.Point(20, 20);
			this.pictureBoxTables.Name = "pictureBoxTables";
			this.pictureBoxTables.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxTables.TabIndex = 3;
			this.pictureBoxTables.TabStop = false;
			// 
			// tabPageRelationships
			// 
			this.tabPageRelationships.Controls.Add(this.buttonRelationshipProperties);
			this.tabPageRelationships.Controls.Add(this.labelRelationshipSelect);
			this.tabPageRelationships.Controls.Add(this.listViewRelationships);
			this.tabPageRelationships.Controls.Add(this.labelRelationships);
			this.tabPageRelationships.Controls.Add(this.pictureBoxRelationships);
			this.tabPageRelationships.Location = new System.Drawing.Point(4, 22);
			this.tabPageRelationships.Name = "tabPageRelationships";
			this.tabPageRelationships.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRelationships.Size = new System.Drawing.Size(772, 299);
			this.tabPageRelationships.TabIndex = 2;
			this.tabPageRelationships.Text = "Relationships";
			this.tabPageRelationships.UseVisualStyleBackColor = true;
			// 
			// buttonRelationshipProperties
			// 
			this.buttonRelationshipProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRelationshipProperties.Enabled = false;
			this.buttonRelationshipProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.buttonRelationshipProperties.Location = new System.Drawing.Point(651, 55);
			this.buttonRelationshipProperties.Name = "buttonRelationshipProperties";
			this.buttonRelationshipProperties.Size = new System.Drawing.Size(95, 23);
			this.buttonRelationshipProperties.TabIndex = 10;
			this.buttonRelationshipProperties.Text = "Configure";
			this.buttonRelationshipProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRelationshipProperties.UseVisualStyleBackColor = true;
			this.buttonRelationshipProperties.Click += new System.EventHandler(this.OnRelationshipProperties);
			// 
			// labelRelationshipSelect
			// 
			this.labelRelationshipSelect.AutoSize = true;
			this.labelRelationshipSelect.Location = new System.Drawing.Point(17, 60);
			this.labelRelationshipSelect.Name = "labelRelationshipSelect";
			this.labelRelationshipSelect.Size = new System.Drawing.Size(105, 13);
			this.labelRelationshipSelect.TabIndex = 9;
			this.labelRelationshipSelect.Text = "Select a relationship:";
			// 
			// listViewRelationships
			// 
			this.listViewRelationships.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewRelationships.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLeftTable,
            this.columnHeaderLeftField,
            this.columnHeaderRightTable,
            this.columnHeaderRightField});
			this.listViewRelationships.FullRowSelect = true;
			this.listViewRelationships.GridLines = true;
			this.listViewRelationships.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewRelationships.HideSelection = false;
			this.listViewRelationships.LargeImageList = this.imageListLarge;
			this.listViewRelationships.Location = new System.Drawing.Point(155, 55);
			this.listViewRelationships.MultiSelect = false;
			this.listViewRelationships.Name = "listViewRelationships";
			this.listViewRelationships.Size = new System.Drawing.Size(490, 238);
			this.listViewRelationships.SmallImageList = this.imageListSmall;
			this.listViewRelationships.TabIndex = 8;
			this.listViewRelationships.UseCompatibleStateImageBehavior = false;
			this.listViewRelationships.View = System.Windows.Forms.View.Details;
			this.listViewRelationships.ItemActivate += new System.EventHandler(this.OnRelationshipProperties);
			this.listViewRelationships.SelectedIndexChanged += new System.EventHandler(this.OnRelationshipSelectionChanged);
			// 
			// columnHeaderLeftTable
			// 
			this.columnHeaderLeftTable.Text = "Left table";
			this.columnHeaderLeftTable.Width = 120;
			// 
			// columnHeaderLeftField
			// 
			this.columnHeaderLeftField.Text = "Left field";
			this.columnHeaderLeftField.Width = 80;
			// 
			// columnHeaderRightTable
			// 
			this.columnHeaderRightTable.Text = "Right table";
			this.columnHeaderRightTable.Width = 120;
			// 
			// columnHeaderRightField
			// 
			this.columnHeaderRightField.Text = "Right field";
			this.columnHeaderRightField.Width = 80;
			// 
			// labelRelationships
			// 
			this.labelRelationships.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelRelationships.Location = new System.Drawing.Point(58, 20);
			this.labelRelationships.Name = "labelRelationships";
			this.labelRelationships.Size = new System.Drawing.Size(707, 32);
			this.labelRelationships.TabIndex = 4;
			this.labelRelationships.Text = "Use this tab to configure the relationships between the database tables.";
			this.labelRelationships.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBoxRelationships
			// 
			this.pictureBoxRelationships.Image = global::InetAnalytics.Resources.Relationship_32;
			this.pictureBoxRelationships.Location = new System.Drawing.Point(20, 20);
			this.pictureBoxRelationships.Name = "pictureBoxRelationships";
			this.pictureBoxRelationships.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxRelationships.TabIndex = 5;
			this.pictureBoxRelationships.TabStop = false;
			// 
			// labelPrimary
			// 
			this.labelPrimary.AutoSize = true;
			this.labelPrimary.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.labelPrimary.Location = new System.Drawing.Point(65, 37);
			this.labelPrimary.Name = "labelPrimary";
			this.labelPrimary.Size = new System.Drawing.Size(73, 13);
			this.labelPrimary.TabIndex = 1;
			this.labelPrimary.Text = "Primary server";
			this.labelPrimary.UseMnemonic = false;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelName.Location = new System.Drawing.Point(64, 16);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(99, 20);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Server name";
			this.labelName.UseMnemonic = false;
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.ServerDown_48;
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(798, 169);
			this.log.TabIndex = 0;
			// 
			// ControlServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlServer";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageDatabase.ResumeLayout(false);
			this.tabPageDatabase.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatabase)).EndInit();
			this.tabPageTables.ResumeLayout(false);
			this.tabPageTables.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTables)).EndInit();
			this.tabPageRelationships.ResumeLayout(false);
			this.tabPageRelationships.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxRelationships)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.SplitContainer splitContainer;
		private Log.ControlLogList log;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton buttonPrimary;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton buttonConnect;
		private System.Windows.Forms.ToolStripButton buttonDisconnect;
		private System.Windows.Forms.ToolStripButton buttonChangePassword;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton buttonProperties;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelPrimary;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageDatabase;
		private System.Windows.Forms.PictureBox pictureBoxDatabase;
		private System.Windows.Forms.Label labelDatabaseTitle;
		private System.Windows.Forms.Label labelDatabaseCurrent;
		private System.Windows.Forms.Button buttonDatabaseProperties;
		private System.Windows.Forms.TextBox textBoxDatabase;
		private System.Windows.Forms.Label labelDatabaseSelect;
		private System.Windows.Forms.Button buttonDatabaseRefresh;
		private System.Windows.Forms.ListView listViewDatabases;
		private System.Windows.Forms.ColumnHeader columnHeaderDatabaseName;
		private System.Windows.Forms.ColumnHeader columnHeaderDatabaseId;
		private System.Windows.Forms.ColumnHeader columnHeaderDatabaseDate;
		private System.Windows.Forms.ImageList imageListSmall;
		private System.Windows.Forms.Button buttonDatabaseSelect;
		private System.Windows.Forms.TabPage tabPageTables;
		private System.Windows.Forms.Label labelTablesTitle;
		private System.Windows.Forms.PictureBox pictureBoxTables;
		private System.Windows.Forms.ListView listViewTables;
		private System.Windows.Forms.Label labelTablesSelect;
		private System.Windows.Forms.Button buttonTableProperties;
		private System.Windows.Forms.ImageList imageListLarge;
		private System.Windows.Forms.ColumnHeader columnHeaderTableName;
		private System.Windows.Forms.ColumnHeader columnHeaderTableFields;
		private System.Windows.Forms.TabPage tabPageRelationships;
		private System.Windows.Forms.Label labelRelationships;
		private System.Windows.Forms.PictureBox pictureBoxRelationships;
		private System.Windows.Forms.Button buttonRelationshipProperties;
		private System.Windows.Forms.Label labelRelationshipSelect;
		private System.Windows.Forms.ListView listViewRelationships;
		private System.Windows.Forms.ColumnHeader columnHeaderLeftTable;
		private System.Windows.Forms.ColumnHeader columnHeaderLeftField;
		private System.Windows.Forms.ColumnHeader columnHeaderRightTable;
		private System.Windows.Forms.ColumnHeader columnHeaderRightField;
	}
}
