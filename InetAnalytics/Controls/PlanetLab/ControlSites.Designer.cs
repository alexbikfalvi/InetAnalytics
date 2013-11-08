namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlSites
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
				// Dispose the sites list.
				this.OnDisposeSites();
				// Remove the sites list event handler.
				this.crawler.Config.PlanetLab.Sites.Cleared -= this.OnSitesCleared;
				this.crawler.Config.PlanetLab.Sites.Updated -= this.OnSitesUpdated;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSites));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.mapControl = new DotNetApi.Windows.Controls.MapControl();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
			this.buttonCancel = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonProperties = new System.Windows.Forms.ToolStripButton();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonFilter = new System.Windows.Forms.ToolStripDropDownButton();
			this.menuItemInvertFilter = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemFilterNodes = new System.Windows.Forms.ToolStripMenuItem();
			this.labelFilter = new System.Windows.Forms.ToolStripLabel();
			this.textBoxFilter = new System.Windows.Forms.ToolStripTextBox();
			this.buttonClear = new System.Windows.Forms.ToolStripButton();
			this.separator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonExport = new System.Windows.Forms.ToolStripDropDownButton();
			this.menuItemExportListCsv = new System.Windows.Forms.ToolStripMenuItem();
			this.separator4 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemExportMap = new System.Windows.Forms.ToolStripMenuItem();
			this.panelList = new DotNetApi.Windows.Controls.ThemePanel();
			this.listViewSites = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderNodes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDateCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLastUpdated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLatitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLongitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.panelMap = new DotNetApi.Windows.Controls.ThemePanel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.panelList.SuspendLayout();
			this.contextMenu.SuspendLayout();
			this.panelMap.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.panelMap);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.panelList);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 274;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 2;
			// 
			// mapControl
			// 
			this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapControl.Location = new System.Drawing.Point(1, 47);
			this.mapControl.MapBounds = ((MapApi.MapRectangle)(resources.GetObject("mapControl.MapBounds")));
			this.mapControl.Name = "mapControl";
			this.mapControl.Size = new System.Drawing.Size(598, 226);
			this.mapControl.TabIndex = 10;
			this.mapControl.MarkerClick += new System.EventHandler(this.OnMapMarkerClick);
			this.mapControl.MarkerDoubleClick += new System.EventHandler(this.OnMapMarkerDoubleClick);
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefresh,
            this.buttonCancel,
            this.separator1,
            this.buttonProperties,
            this.separator2,
            this.buttonFilter,
            this.labelFilter,
            this.textBoxFilter,
            this.buttonClear,
            this.separator3,
            this.buttonExport});
			this.toolStrip.Location = new System.Drawing.Point(1, 22);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(598, 25);
			this.toolStrip.TabIndex = 9;
			this.toolStrip.Text = "toolStrip1";
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
			// buttonProperties
			// 
			this.buttonProperties.Enabled = false;
			this.buttonProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.buttonProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonProperties.Name = "buttonProperties";
			this.buttonProperties.Size = new System.Drawing.Size(80, 22);
			this.buttonProperties.Text = "&Properties";
			this.buttonProperties.Click += new System.EventHandler(this.OnProperties);
			// 
			// separator2
			// 
			this.separator2.Name = "separator2";
			this.separator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonFilter
			// 
			this.buttonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemInvertFilter,
            this.menuItemFilterNodes});
			this.buttonFilter.Image = global::InetAnalytics.Resources.Filter_16;
			this.buttonFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.Size = new System.Drawing.Size(29, 22);
			this.buttonFilter.Text = "&Filter";
			// 
			// menuItemInvertFilter
			// 
			this.menuItemInvertFilter.CheckOnClick = true;
			this.menuItemInvertFilter.Name = "menuItemInvertFilter";
			this.menuItemInvertFilter.Size = new System.Drawing.Size(159, 22);
			this.menuItemInvertFilter.Text = "Invert filter";
			this.menuItemInvertFilter.CheckedChanged += new System.EventHandler(this.OnFilterChanged);
			// 
			// menuItemFilterNodes
			// 
			this.menuItemFilterNodes.CheckOnClick = true;
			this.menuItemFilterNodes.Name = "menuItemFilterNodes";
			this.menuItemFilterNodes.Size = new System.Drawing.Size(159, 22);
			this.menuItemFilterNodes.Text = "Sites with nodes";
			this.menuItemFilterNodes.CheckedChanged += new System.EventHandler(this.OnFilterChanged);
			// 
			// labelFilter
			// 
			this.labelFilter.Name = "labelFilter";
			this.labelFilter.Size = new System.Drawing.Size(36, 22);
			this.labelFilter.Text = "Filter:";
			// 
			// textBoxFilter
			// 
			this.textBoxFilter.Name = "textBoxFilter";
			this.textBoxFilter.Size = new System.Drawing.Size(100, 25);
			this.textBoxFilter.TextChanged += new System.EventHandler(this.OnFilterTextChanged);
			// 
			// buttonClear
			// 
			this.buttonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.buttonClear.Enabled = false;
			this.buttonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(38, 22);
			this.buttonClear.Text = "C&lear";
			this.buttonClear.Click += new System.EventHandler(this.OnFilterClear);
			// 
			// separator3
			// 
			this.separator3.Name = "separator3";
			this.separator3.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonExport
			// 
			this.buttonExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExportListCsv,
            this.separator4,
            this.menuItemExportMap});
			this.buttonExport.Image = global::InetAnalytics.Resources.Export_16;
			this.buttonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(69, 22);
			this.buttonExport.Text = "&Export";
			// 
			// menuItemExportListCsv
			// 
			this.menuItemExportListCsv.Name = "menuItemExportListCsv";
			this.menuItemExportListCsv.Size = new System.Drawing.Size(154, 22);
			this.menuItemExportListCsv.Text = "Sites list as CSV";
			this.menuItemExportListCsv.Click += new System.EventHandler(this.OnExportListCsv);
			// 
			// separator4
			// 
			this.separator4.Name = "separator4";
			this.separator4.Size = new System.Drawing.Size(151, 6);
			// 
			// menuItemExportMap
			// 
			this.menuItemExportMap.Name = "menuItemExportMap";
			this.menuItemExportMap.Size = new System.Drawing.Size(154, 22);
			this.menuItemExportMap.Text = "Sites map";
			this.menuItemExportMap.Click += new System.EventHandler(this.OnExportMap);
			// 
			// panelList
			// 
			this.panelList.Controls.Add(this.listViewSites);
			this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelList.Location = new System.Drawing.Point(0, 0);
			this.panelList.Name = "panelList";
			this.panelList.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelList.ShowBorder = true;
			this.panelList.ShowTitle = true;
			this.panelList.Size = new System.Drawing.Size(600, 121);
			this.panelList.TabIndex = 1;
			this.panelList.Title = "Sites List";
			// 
			// listViewSites
			// 
			this.listViewSites.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderName,
            this.columnHeaderUrl,
            this.columnHeaderNodes,
            this.columnHeaderDateCreated,
            this.columnHeaderLastUpdated,
            this.columnHeaderLatitude,
            this.columnHeaderLongitude});
			this.listViewSites.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewSites.FullRowSelect = true;
			this.listViewSites.GridLines = true;
			this.listViewSites.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewSites.HideSelection = false;
			this.listViewSites.Location = new System.Drawing.Point(1, 22);
			this.listViewSites.Name = "listViewSites";
			this.listViewSites.Size = new System.Drawing.Size(598, 98);
			this.listViewSites.SmallImageList = this.imageList;
			this.listViewSites.TabIndex = 0;
			this.listViewSites.UseCompatibleStateImageBehavior = false;
			this.listViewSites.View = System.Windows.Forms.View.Details;
			this.listViewSites.ItemActivate += new System.EventHandler(this.OnProperties);
			this.listViewSites.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
			this.listViewSites.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 120;
			// 
			// columnHeaderUrl
			// 
			this.columnHeaderUrl.Text = "URL";
			this.columnHeaderUrl.Width = 120;
			// 
			// columnHeaderNodes
			// 
			this.columnHeaderNodes.Text = "Nodes";
			// 
			// columnHeaderDateCreated
			// 
			this.columnHeaderDateCreated.Text = "Date created";
			this.columnHeaderDateCreated.Width = 120;
			// 
			// columnHeaderLastUpdated
			// 
			this.columnHeaderLastUpdated.Text = "Last updated";
			this.columnHeaderLastUpdated.Width = 120;
			// 
			// columnHeaderLatitude
			// 
			this.columnHeaderLatitude.Text = "Latitude";
			this.columnHeaderLatitude.Width = 100;
			// 
			// columnHeaderLongitude
			// 
			this.columnHeaderLongitude.Text = "Longitude";
			this.columnHeaderLongitude.Width = 100;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "SchemaView");
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
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProperties});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(128, 26);
			// 
			// menuItemProperties
			// 
			this.menuItemProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.menuItemProperties.Name = "menuItemProperties";
			this.menuItemProperties.Size = new System.Drawing.Size(127, 22);
			this.menuItemProperties.Text = "&Properties";
			this.menuItemProperties.Click += new System.EventHandler(this.OnProperties);
			// 
			// panelMap
			// 
			this.panelMap.Controls.Add(this.mapControl);
			this.panelMap.Controls.Add(this.toolStrip);
			this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMap.Location = new System.Drawing.Point(0, 0);
			this.panelMap.Name = "panelMap";
			this.panelMap.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelMap.ShowBorder = true;
			this.panelMap.ShowTitle = true;
			this.panelMap.Size = new System.Drawing.Size(600, 274);
			this.panelMap.TabIndex = 11;
			this.panelMap.Title = "Sites Map";
			// 
			// ControlSites
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlSites";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.panelList.ResumeLayout(false);
			this.contextMenu.ResumeLayout(false);
			this.panelMap.ResumeLayout(false);
			this.panelMap.PerformLayout();
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
		private System.Windows.Forms.ListView listViewSites;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderUrl;
		private System.Windows.Forms.ColumnHeader columnHeaderDateCreated;
		private System.Windows.Forms.ColumnHeader columnHeaderLastUpdated;
		private System.Windows.Forms.ColumnHeader columnHeaderLatitude;
		private System.Windows.Forms.ColumnHeader columnHeaderLongitude;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripButton buttonProperties;
		private System.Windows.Forms.ToolStripLabel labelFilter;
		private System.Windows.Forms.ToolStripTextBox textBoxFilter;
		private System.Windows.Forms.ToolStripButton buttonClear;
		private DotNetApi.Windows.Controls.MapControl mapControl;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
		private System.Windows.Forms.ColumnHeader columnHeaderNodes;
		private System.Windows.Forms.ToolStripDropDownButton buttonFilter;
		private System.Windows.Forms.ToolStripMenuItem menuItemFilterNodes;
		private System.Windows.Forms.ToolStripMenuItem menuItemInvertFilter;
		private System.Windows.Forms.ToolStripSeparator separator3;
		private System.Windows.Forms.ToolStripDropDownButton buttonExport;
		private System.Windows.Forms.ToolStripMenuItem menuItemExportListCsv;
		private System.Windows.Forms.ToolStripMenuItem menuItemExportMap;
		private System.Windows.Forms.ToolStripSeparator separator4;
		private DotNetApi.Windows.Controls.ThemePanel panelList;
		private DotNetApi.Windows.Controls.ThemePanel panelMap;
	}
}
