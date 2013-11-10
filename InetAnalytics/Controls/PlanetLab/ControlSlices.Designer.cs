namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlSlices
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
				// Dispose the slices.
				this.OnDisposeSlices();
				// If the components are not null.
				if (this.components != null)
				{
					// Dispose the components.
					this.components.Dispose();
				}
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSlices));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelSlices = new DotNetApi.Windows.Controls.ThemeControl();
			this.listViewSlices = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderExpires = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderNodes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderMaximum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
			this.buttonCancel = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonProperties = new System.Windows.Forms.ToolStripButton();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonAddSlice = new System.Windows.Forms.ToolStripButton();
			this.buttonRemoveSlice = new System.Windows.Forms.ToolStripButton();
			this.separator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonAddToNodes = new System.Windows.Forms.ToolStripDropDownButton();
			this.contextMenuAddToNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.itemSelectNodesLocation = new System.Windows.Forms.ToolStripMenuItem();
			this.itemSelectNodesState = new System.Windows.Forms.ToolStripMenuItem();
			this.itemSelectNodesSlice = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonRemoveFromNodes = new System.Windows.Forms.ToolStripButton();
			this.controlLog = new InetAnalytics.Controls.Log.ControlLogList();
			this.menuItemAddToNodes = new System.Windows.Forms.ToolStripMenuItem();
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemRemoveFromNodes = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelSlices.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.panelSlices);
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
			// panelSlices
			// 
			this.panelSlices.Controls.Add(this.listViewSlices);
			this.panelSlices.Controls.Add(this.toolStrip);
			this.panelSlices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelSlices.Location = new System.Drawing.Point(0, 0);
			this.panelSlices.Name = "panelSlices";
			this.panelSlices.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelSlices.ShowBorder = true;
			this.panelSlices.ShowTitle = true;
			this.panelSlices.Size = new System.Drawing.Size(800, 425);
			this.panelSlices.TabIndex = 11;
			this.panelSlices.Title = "PlanetLab Slices";
			// 
			// listViewSlices
			// 
			this.listViewSlices.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewSlices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderName,
            this.columnHeaderCreated,
            this.columnHeaderExpires,
            this.columnHeaderNodes,
            this.columnHeaderMaximum});
			this.listViewSlices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewSlices.FullRowSelect = true;
			this.listViewSlices.GridLines = true;
			this.listViewSlices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewSlices.HideSelection = false;
			this.listViewSlices.Location = new System.Drawing.Point(1, 47);
			this.listViewSlices.Name = "listViewSlices";
			this.listViewSlices.Size = new System.Drawing.Size(798, 377);
			this.listViewSlices.SmallImageList = this.imageList;
			this.listViewSlices.TabIndex = 10;
			this.listViewSlices.UseCompatibleStateImageBehavior = false;
			this.listViewSlices.View = System.Windows.Forms.View.Details;
			this.listViewSlices.ItemActivate += new System.EventHandler(this.OnProperties);
			this.listViewSlices.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
			this.listViewSlices.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
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
			// columnHeaderCreated
			// 
			this.columnHeaderCreated.Text = "Created";
			this.columnHeaderCreated.Width = 120;
			// 
			// columnHeaderExpires
			// 
			this.columnHeaderExpires.Text = "Expires";
			this.columnHeaderExpires.Width = 120;
			// 
			// columnHeaderNodes
			// 
			this.columnHeaderNodes.Text = "Nodes";
			this.columnHeaderNodes.Width = 80;
			// 
			// columnHeaderMaximum
			// 
			this.columnHeaderMaximum.Text = "Maximum";
			this.columnHeaderMaximum.Width = 80;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "GlobeObject");
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefresh,
            this.buttonCancel,
            this.separator1,
            this.buttonProperties,
            this.separator2,
            this.buttonAddSlice,
            this.buttonRemoveSlice,
            this.separator3,
            this.buttonAddToNodes,
            this.buttonRemoveFromNodes});
			this.toolStrip.Location = new System.Drawing.Point(1, 22);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
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
			// buttonAddSlice
			// 
			this.buttonAddSlice.Image = global::InetAnalytics.Resources.ObjectSmallAdd_16;
			this.buttonAddSlice.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAddSlice.Name = "buttonAddSlice";
			this.buttonAddSlice.Size = new System.Drawing.Size(75, 22);
			this.buttonAddSlice.Text = "&Add slice";
			this.buttonAddSlice.Click += new System.EventHandler(this.OnAddSlice);
			// 
			// buttonRemoveSlice
			// 
			this.buttonRemoveSlice.Enabled = false;
			this.buttonRemoveSlice.Image = global::InetAnalytics.Resources.ObjectSmallRemove_16;
			this.buttonRemoveSlice.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemoveSlice.Name = "buttonRemoveSlice";
			this.buttonRemoveSlice.Size = new System.Drawing.Size(96, 22);
			this.buttonRemoveSlice.Text = "R&emove slice";
			this.buttonRemoveSlice.Click += new System.EventHandler(this.OnRemoveSlice);
			// 
			// separator3
			// 
			this.separator3.Name = "separator3";
			this.separator3.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonAddToNodes
			// 
			this.buttonAddToNodes.DropDown = this.contextMenuAddToNodes;
			this.buttonAddToNodes.Enabled = false;
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
			this.contextMenuAddToNodes.OwnerItem = this.menuItemAddToNodes;
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
			// menuItemAddToNodes
			// 
			this.menuItemAddToNodes.DropDown = this.contextMenuAddToNodes;
			this.menuItemAddToNodes.Image = global::InetAnalytics.Resources.NodeAdd_16;
			this.menuItemAddToNodes.Name = "menuItemAddToNodes";
			this.menuItemAddToNodes.Size = new System.Drawing.Size(181, 22);
			this.menuItemAddToNodes.Text = "&Add to nodes";
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
            this.menuItemAddToNodes,
            this.menuItemRemoveFromNodes,
            this.toolStripSeparator1,
            this.menuItemProperties});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(182, 76);
			// 
			// menuItemRemoveFromNodes
			// 
			this.menuItemRemoveFromNodes.Image = global::InetAnalytics.Resources.NodeRemove_16;
			this.menuItemRemoveFromNodes.Name = "menuItemRemoveFromNodes";
			this.menuItemRemoveFromNodes.Size = new System.Drawing.Size(181, 22);
			this.menuItemRemoveFromNodes.Text = "&Remove from nodes";
			this.menuItemRemoveFromNodes.Click += new System.EventHandler(this.OnRemoveFromNodes);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
			// 
			// menuItemProperties
			// 
			this.menuItemProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.menuItemProperties.Name = "menuItemProperties";
			this.menuItemProperties.Size = new System.Drawing.Size(181, 22);
			this.menuItemProperties.Text = "&Properties";
			this.menuItemProperties.Click += new System.EventHandler(this.OnProperties);
			// 
			// ControlSlices
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlSlices";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelSlices.ResumeLayout(false);
			this.panelSlices.PerformLayout();
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
		private System.Windows.Forms.ToolStripButton buttonProperties;
		private Log.ControlLogList controlLog;
		private System.Windows.Forms.ListView listViewSlices;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderCreated;
		private System.Windows.Forms.ColumnHeader columnHeaderExpires;
		private System.Windows.Forms.ColumnHeader columnHeaderNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderMaximum;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripButton buttonAddSlice;
		private System.Windows.Forms.ToolStripButton buttonRemoveSlice;
		private System.Windows.Forms.ToolStripSeparator separator3;
		private System.Windows.Forms.ToolStripButton buttonRemoveFromNodes;
		private System.Windows.Forms.ToolStripDropDownButton buttonAddToNodes;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemAddToNodes;
		private System.Windows.Forms.ToolStripMenuItem menuItemRemoveFromNodes;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
		private System.Windows.Forms.ContextMenuStrip contextMenuAddToNodes;
		private System.Windows.Forms.ToolStripMenuItem itemSelectNodesLocation;
		private System.Windows.Forms.ToolStripMenuItem itemSelectNodesState;
		private System.Windows.Forms.ToolStripMenuItem itemSelectNodesSlice;
		private DotNetApi.Windows.Controls.ThemeControl panelSlices;
	}
}
