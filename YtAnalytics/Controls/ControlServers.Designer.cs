namespace YtAnalytics.Controls
{
	partial class ControlServers
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
			this.items.Clear();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlServers));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonAdd = new System.Windows.Forms.ToolStripButton();
			this.buttonRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonPrimary = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonConnect = new System.Windows.Forms.ToolStripButton();
			this.buttonDisconnect = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonChangePassword = new System.Windows.Forms.ToolStripButton();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeadeVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.log = new YtAnalytics.Controls.ControlLogList();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemPrimary = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemChangePassword = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAdd,
            this.buttonRemove,
            this.toolStripSeparator1,
            this.buttonPrimary,
            this.toolStripSeparator2,
            this.buttonConnect,
            this.buttonDisconnect,
            this.toolStripSeparator5,
            this.buttonChangePassword});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// buttonAdd
			// 
			this.buttonAdd.Image = global::YtAnalytics.Resources.ServerAdd_16;
			this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(83, 22);
			this.buttonAdd.Text = "&Add server";
			this.buttonAdd.Click += new System.EventHandler(this.OnAdd);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Enabled = false;
			this.buttonRemove.Image = global::YtAnalytics.Resources.ServerRemove_16;
			this.buttonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(104, 22);
			this.buttonRemove.Text = "&Remove server";
			this.buttonRemove.Click += new System.EventHandler(this.OnRemove);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonPrimary
			// 
			this.buttonPrimary.Enabled = false;
			this.buttonPrimary.Image = global::YtAnalytics.Resources.ServerStar_16;
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
			// buttonConnect
			// 
			this.buttonConnect.Enabled = false;
			this.buttonConnect.Image = global::YtAnalytics.Resources.Connect_16;
			this.buttonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(72, 22);
			this.buttonConnect.Text = "&Connect";
			this.buttonConnect.Click += new System.EventHandler(this.OnConnect);
			// 
			// buttonDisconnect
			// 
			this.buttonDisconnect.Enabled = false;
			this.buttonDisconnect.Image = global::YtAnalytics.Resources.Disconnect_16;
			this.buttonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonDisconnect.Name = "buttonDisconnect";
			this.buttonDisconnect.Size = new System.Drawing.Size(86, 22);
			this.buttonDisconnect.Text = "&Disconnect";
			this.buttonDisconnect.Click += new System.EventHandler(this.OnDisconnect);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonChangePassword
			// 
			this.buttonChangePassword.Image = global::YtAnalytics.Resources.PasswordChange_16;
			this.buttonChangePassword.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonChangePassword.Name = "buttonChangePassword";
			this.buttonChangePassword.Size = new System.Drawing.Size(121, 22);
			this.buttonChangePassword.Text = "Cha&nge password";
			this.buttonChangePassword.Click += new System.EventHandler(this.OnChangePassword);
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
			this.splitContainer.Panel1.Controls.Add(this.listView);
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.TabIndex = 1;
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderType,
            this.columnHeaderStatus,
            this.columnHeadeVersion,
            this.columnHeaderId});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(0, 25);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(798, 398);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 1;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemActivate += new System.EventHandler(this.OnProperties);
			this.listView.SelectedIndexChanged += new System.EventHandler(this.OnServerSelectionChanged);
			this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 180;
			// 
			// columnHeaderType
			// 
			this.columnHeaderType.Text = "Type";
			this.columnHeaderType.Width = 120;
			// 
			// columnHeaderStatus
			// 
			this.columnHeaderStatus.Text = "Status";
			this.columnHeaderStatus.Width = 120;
			// 
			// columnHeadeVersion
			// 
			this.columnHeadeVersion.Text = "Version";
			this.columnHeadeVersion.Width = 120;
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
			this.columnHeaderId.Width = 180;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "ServerDown");
			this.imageList.Images.SetKeyName(1, "ServerUp");
			this.imageList.Images.SetKeyName(2, "ServerWarning");
			this.imageList.Images.SetKeyName(3, "ServerBusy");
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(798, 169);
			this.log.TabIndex = 0;
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPrimary,
            this.toolStripSeparator3,
            this.menuItemConnect,
            this.menuItemDisconnect,
            this.toolStripSeparator4,
            this.menuItemChangePassword,
            this.toolStripSeparator6,
            this.menuItemProperties});
			this.contextMenu.Name = "contextMenuStrip";
			this.contextMenu.Size = new System.Drawing.Size(169, 154);
			// 
			// menuItemPrimary
			// 
			this.menuItemPrimary.Image = global::YtAnalytics.Resources.ServerStar_16;
			this.menuItemPrimary.Name = "menuItemPrimary";
			this.menuItemPrimary.Size = new System.Drawing.Size(168, 22);
			this.menuItemPrimary.Text = "Make primary";
			this.menuItemPrimary.Click += new System.EventHandler(this.OnMakePrimary);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
			// 
			// menuItemConnect
			// 
			this.menuItemConnect.Image = global::YtAnalytics.Resources.Connect_16;
			this.menuItemConnect.Name = "menuItemConnect";
			this.menuItemConnect.Size = new System.Drawing.Size(168, 22);
			this.menuItemConnect.Text = "Connect";
			this.menuItemConnect.Click += new System.EventHandler(this.OnConnect);
			// 
			// menuItemDisconnect
			// 
			this.menuItemDisconnect.Image = global::YtAnalytics.Resources.Disconnect_16;
			this.menuItemDisconnect.Name = "menuItemDisconnect";
			this.menuItemDisconnect.Size = new System.Drawing.Size(168, 22);
			this.menuItemDisconnect.Text = "Disconnect";
			this.menuItemDisconnect.Click += new System.EventHandler(this.OnDisconnect);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
			// 
			// menuItemChangePassword
			// 
			this.menuItemChangePassword.Image = global::YtAnalytics.Resources.PasswordChange_16;
			this.menuItemChangePassword.Name = "menuItemChangePassword";
			this.menuItemChangePassword.Size = new System.Drawing.Size(168, 22);
			this.menuItemChangePassword.Text = "Change password";
			this.menuItemChangePassword.Click += new System.EventHandler(this.OnChangePassword);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(165, 6);
			// 
			// menuItemProperties
			// 
			this.menuItemProperties.Image = global::YtAnalytics.Resources.Properties_16;
			this.menuItemProperties.Name = "menuItemProperties";
			this.menuItemProperties.Size = new System.Drawing.Size(168, 22);
			this.menuItemProperties.Text = "Properties";
			this.menuItemProperties.Click += new System.EventHandler(this.OnProperties);
			// 
			// ControlServers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlServers";
			this.Size = new System.Drawing.Size(800, 600);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.SplitContainer splitContainer;
		private ControlLogList log;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderType;
		private System.Windows.Forms.ColumnHeader columnHeaderStatus;
		private System.Windows.Forms.ColumnHeader columnHeadeVersion;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripButton buttonAdd;
		private System.Windows.Forms.ToolStripButton buttonRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton buttonPrimary;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton buttonConnect;
		private System.Windows.Forms.ToolStripButton buttonDisconnect;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemPrimary;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuItemConnect;
		private System.Windows.Forms.ToolStripMenuItem menuItemDisconnect;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton buttonChangePassword;
		private System.Windows.Forms.ToolStripMenuItem menuItemChangePassword;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
	}
}
