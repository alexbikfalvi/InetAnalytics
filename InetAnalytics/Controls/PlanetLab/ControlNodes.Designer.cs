namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlNodes
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
				// Dispose the nodes list.
				this.OnDisposeNodes();
				// Remove the nodes list event handler.
				this.crawler.PlanetLab.Nodes.Cleared -= this.OnNodesCleared;
				this.crawler.PlanetLab.Nodes.Updated -= this.OnNodesUpdated;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlNodes));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.miniToolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
			this.buttonCancel = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonProperties = new System.Windows.Forms.ToolStripButton();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonFilter = new System.Windows.Forms.ToolStripDropDownButton();
			this.menuItemInvertFilter = new System.Windows.Forms.ToolStripMenuItem();
			this.separator5 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemFilterState = new System.Windows.Forms.ToolStripMenuItem();
			this.stateFilter = new DotNetApi.Windows.Controls.ToolStripDropDownCheckedList();
			this.labelFilter = new System.Windows.Forms.ToolStripLabel();
			this.textBoxFilter = new System.Windows.Forms.ToolStripTextBox();
			this.buttonClear = new System.Windows.Forms.ToolStripButton();
			this.separator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonExport = new System.Windows.Forms.ToolStripDropDownButton();
			this.menuItemExportListCsv = new System.Windows.Forms.ToolStripMenuItem();
			this.separator4 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemExportListIp = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderHostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderBootState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDateCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLastUpdated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panelNodes = new DotNetApi.Windows.Controls.ThemeControl();
			this.contextMenu.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.panelNodes.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "NodeLarge");
			this.imageList.Images.SetKeyName(1, "NodeBoot");
			this.imageList.Images.SetKeyName(2, "NodeSafeBoot");
			this.imageList.Images.SetKeyName(3, "NodeReinstall");
			this.imageList.Images.SetKeyName(4, "NodeDisabled");
			this.imageList.Images.SetKeyName(5, "NodeUnknown");
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
			// miniToolStrip
			// 
			this.miniToolStrip.AutoSize = false;
			this.miniToolStrip.CanOverflow = false;
			this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.miniToolStrip.Location = new System.Drawing.Point(494, 3);
			this.miniToolStrip.Name = "miniToolStrip";
			this.miniToolStrip.Size = new System.Drawing.Size(598, 25);
			this.miniToolStrip.TabIndex = 9;
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
            this.separator5,
            this.menuItemFilterState});
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
			this.menuItemInvertFilter.Size = new System.Drawing.Size(131, 22);
			this.menuItemInvertFilter.Text = "Invert filter";
			this.menuItemInvertFilter.CheckedChanged += new System.EventHandler(this.OnFilterChanged);
			// 
			// separator5
			// 
			this.separator5.Name = "separator5";
			this.separator5.Size = new System.Drawing.Size(128, 6);
			// 
			// menuItemFilterState
			// 
			this.menuItemFilterState.DropDown = this.stateFilter;
			this.menuItemFilterState.Name = "menuItemFilterState";
			this.menuItemFilterState.Size = new System.Drawing.Size(131, 22);
			this.menuItemFilterState.Text = "Filter state";
			// 
			// stateFilter
			// 
			this.stateFilter.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.stateFilter.ListMinimumSize = new System.Drawing.Size(200, 200);
			this.stateFilter.ListSize = new System.Drawing.Size(200, 200);
			this.stateFilter.Name = "checkedListFilter";
			this.stateFilter.OwnerItem = this.menuItemFilterState;
			this.stateFilter.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
			this.stateFilter.Size = new System.Drawing.Size(208, 205);
			this.stateFilter.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnStateFilterCheck);
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
            this.menuItemExportListIp});
			this.buttonExport.Image = global::InetAnalytics.Resources.Export_16;
			this.buttonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(69, 22);
			this.buttonExport.Text = "&Export";
			// 
			// menuItemExportListCsv
			// 
			this.menuItemExportListCsv.Name = "menuItemExportListCsv";
			this.menuItemExportListCsv.Size = new System.Drawing.Size(175, 22);
			this.menuItemExportListCsv.Text = "Nodes list as CSV";
			this.menuItemExportListCsv.Click += new System.EventHandler(this.OnExportListCsv);
			// 
			// separator4
			// 
			this.separator4.Name = "separator4";
			this.separator4.Size = new System.Drawing.Size(172, 6);
			// 
			// menuItemExportListIp
			// 
			this.menuItemExportListIp.Name = "menuItemExportListIp";
			this.menuItemExportListIp.Size = new System.Drawing.Size(175, 22);
			this.menuItemExportListIp.Text = "Nodes IP addresses";
			this.menuItemExportListIp.Click += new System.EventHandler(this.OnExportListIp);
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
			// listViewNodes
			// 
			this.listViewNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderHostname,
            this.columnHeaderBootState,
            this.columnHeaderModel,
            this.columnHeaderVersion,
            this.columnHeaderDateCreated,
            this.columnHeaderLastUpdated,
            this.columnHeaderType});
			this.listViewNodes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewNodes.FullRowSelect = true;
			this.listViewNodes.GridLines = true;
			this.listViewNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewNodes.HideSelection = false;
			this.listViewNodes.Location = new System.Drawing.Point(1, 47);
			this.listViewNodes.Name = "listViewNodes";
			this.listViewNodes.Size = new System.Drawing.Size(598, 352);
			this.listViewNodes.SmallImageList = this.imageList;
			this.listViewNodes.TabIndex = 0;
			this.listViewNodes.UseCompatibleStateImageBehavior = false;
			this.listViewNodes.View = System.Windows.Forms.View.Details;
			this.listViewNodes.ItemActivate += new System.EventHandler(this.OnProperties);
			this.listViewNodes.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
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
			// columnHeaderBootState
			// 
			this.columnHeaderBootState.Text = "Boot state";
			// 
			// columnHeaderModel
			// 
			this.columnHeaderModel.Text = "Model";
			this.columnHeaderModel.Width = 120;
			// 
			// columnHeaderVersion
			// 
			this.columnHeaderVersion.Text = "Version";
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
			// columnHeaderType
			// 
			this.columnHeaderType.Text = "Type";
			// 
			// panelNodes
			// 
			this.panelNodes.Controls.Add(this.listViewNodes);
			this.panelNodes.Controls.Add(this.toolStrip);
			this.panelNodes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelNodes.Location = new System.Drawing.Point(0, 0);
			this.panelNodes.Name = "panelNodes";
			this.panelNodes.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelNodes.ShowBorder = true;
			this.panelNodes.ShowTitle = true;
			this.panelNodes.Size = new System.Drawing.Size(600, 400);
			this.panelNodes.TabIndex = 10;
			this.panelNodes.Title = "PlanetLab Nodes";
			// 
			// ControlNodes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelNodes);
			this.Enabled = false;
			this.Name = "ControlNodes";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.panelNodes, 0);
			this.contextMenu.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.panelNodes.ResumeLayout(false);
			this.panelNodes.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemPending;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemSuccess;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemFail;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemWarning;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
		private System.Windows.Forms.ToolStrip miniToolStrip;
		private System.Windows.Forms.ToolStripButton buttonRefresh;
		private System.Windows.Forms.ToolStripButton buttonCancel;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripButton buttonProperties;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripDropDownButton buttonFilter;
		private System.Windows.Forms.ToolStripMenuItem menuItemInvertFilter;
		private System.Windows.Forms.ToolStripLabel labelFilter;
		private System.Windows.Forms.ToolStripTextBox textBoxFilter;
		private System.Windows.Forms.ToolStripButton buttonClear;
		private System.Windows.Forms.ToolStripSeparator separator3;
		private System.Windows.Forms.ToolStripDropDownButton buttonExport;
		private System.Windows.Forms.ToolStripMenuItem menuItemExportListCsv;
		private System.Windows.Forms.ToolStripSeparator separator4;
		private System.Windows.Forms.ToolStripMenuItem menuItemExportListIp;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderHostname;
		private System.Windows.Forms.ColumnHeader columnHeaderBootState;
		private System.Windows.Forms.ColumnHeader columnHeaderModel;
		private System.Windows.Forms.ColumnHeader columnHeaderDateCreated;
		private System.Windows.Forms.ColumnHeader columnHeaderLastUpdated;
		private System.Windows.Forms.ColumnHeader columnHeaderType;
		private System.Windows.Forms.ColumnHeader columnHeaderVersion;
		private DotNetApi.Windows.Controls.ToolStripDropDownCheckedList stateFilter;
		private System.Windows.Forms.ToolStripSeparator separator5;
		private System.Windows.Forms.ToolStripMenuItem menuItemFilterState;
		private DotNetApi.Windows.Controls.ThemeControl panelNodes;
	}
}
