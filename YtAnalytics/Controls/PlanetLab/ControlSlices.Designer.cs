namespace YtAnalytics.Controls.PlanetLab
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
			if (disposing && (components != null))
			{
				components.Dispose();
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
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
			this.buttonAddNode = new System.Windows.Forms.ToolStripDropDownButton();
			this.addNodeByLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addNodeByStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addNodeBySliceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonRemoveNode = new System.Windows.Forms.ToolStripButton();
			this.controlLog = new YtAnalytics.Controls.Log.ControlLogList();
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.listViewSlices);
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.controlLog);
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.TabIndex = 2;
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
			this.listViewSlices.Location = new System.Drawing.Point(0, 25);
			this.listViewSlices.Name = "listViewSlices";
			this.listViewSlices.Size = new System.Drawing.Size(798, 398);
			this.listViewSlices.SmallImageList = this.imageList;
			this.listViewSlices.TabIndex = 10;
			this.listViewSlices.UseCompatibleStateImageBehavior = false;
			this.listViewSlices.View = System.Windows.Forms.View.Details;
			this.listViewSlices.ItemActivate += new System.EventHandler(this.OnProperties);
			this.listViewSlices.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
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
            this.buttonAddNode,
            this.buttonRemoveNode});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 9;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Image = global::YtAnalytics.Resources.Refresh_16;
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
			this.buttonProperties.Image = global::YtAnalytics.Resources.Properties_16;
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
			this.buttonAddSlice.Image = global::YtAnalytics.Resources.ObjectSmallAdd_16;
			this.buttonAddSlice.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAddSlice.Name = "buttonAddSlice";
			this.buttonAddSlice.Size = new System.Drawing.Size(75, 22);
			this.buttonAddSlice.Text = "&Add slice";
			this.buttonAddSlice.Click += new System.EventHandler(this.OnAddSlice);
			// 
			// buttonRemoveSlice
			// 
			this.buttonRemoveSlice.Enabled = false;
			this.buttonRemoveSlice.Image = global::YtAnalytics.Resources.ObjectSmallRemove_16;
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
			// buttonAddNode
			// 
			this.buttonAddNode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeByLocationToolStripMenuItem,
            this.addNodeByStateToolStripMenuItem,
            this.addNodeBySliceToolStripMenuItem});
			this.buttonAddNode.Enabled = false;
			this.buttonAddNode.Image = global::YtAnalytics.Resources.NodeAdd_16;
			this.buttonAddNode.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAddNode.Name = "buttonAddNode";
			this.buttonAddNode.Size = new System.Drawing.Size(88, 22);
			this.buttonAddNode.Text = "A&dd node";
			// 
			// addNodeByLocationToolStripMenuItem
			// 
			this.addNodeByLocationToolStripMenuItem.Name = "addNodeByLocationToolStripMenuItem";
			this.addNodeByLocationToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.addNodeByLocationToolStripMenuItem.Text = "Add node by location";
			this.addNodeByLocationToolStripMenuItem.Click += new System.EventHandler(this.OnAddNodeLocation);
			// 
			// addNodeByStateToolStripMenuItem
			// 
			this.addNodeByStateToolStripMenuItem.Name = "addNodeByStateToolStripMenuItem";
			this.addNodeByStateToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.addNodeByStateToolStripMenuItem.Text = "Add node by state";
			this.addNodeByStateToolStripMenuItem.Click += new System.EventHandler(this.OnAddNodeState);
			// 
			// addNodeBySliceToolStripMenuItem
			// 
			this.addNodeBySliceToolStripMenuItem.Name = "addNodeBySliceToolStripMenuItem";
			this.addNodeBySliceToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.addNodeBySliceToolStripMenuItem.Text = "Add node by slice";
			this.addNodeBySliceToolStripMenuItem.Click += new System.EventHandler(this.OnAddNodeSlice);
			// 
			// buttonRemoveNode
			// 
			this.buttonRemoveNode.Enabled = false;
			this.buttonRemoveNode.Image = global::YtAnalytics.Resources.NodeRemove_16;
			this.buttonRemoveNode.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemoveNode.Name = "buttonRemoveNode";
			this.buttonRemoveNode.Size = new System.Drawing.Size(100, 22);
			this.buttonRemoveNode.Text = "Remo&ve node";
			this.buttonRemoveNode.Click += new System.EventHandler(this.OnRemoveNode);
			// 
			// controlLog
			// 
			this.controlLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLog.Location = new System.Drawing.Point(0, 0);
			this.controlLog.Name = "controlLog";
			this.controlLog.Size = new System.Drawing.Size(798, 169);
			this.controlLog.TabIndex = 0;
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
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
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
		private System.Windows.Forms.ToolStripButton buttonRemoveNode;
		private System.Windows.Forms.ToolStripDropDownButton buttonAddNode;
		private System.Windows.Forms.ToolStripMenuItem addNodeByLocationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addNodeByStateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addNodeBySliceToolStripMenuItem;
	}
}
