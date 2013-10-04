namespace YtAnalytics.Controls.PlanetLab
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSlice));
			this.splitContainer = new System.Windows.Forms.SplitContainer();
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
			this.controlLog = new YtAnalytics.Controls.Log.ControlLogList();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.contextMenuAddToNodes.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.controlLog);
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.TabIndex = 2;
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefresh,
            this.buttonCancel,
            this.separator1,
            this.buttonAddToNodes,
            this.buttonRemoveFromNodes});
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
			// buttonAddToNodes
			// 
			this.buttonAddToNodes.DropDown = this.contextMenuAddToNodes;
			this.buttonAddToNodes.Enabled = false;
			this.buttonAddToNodes.Image = global::YtAnalytics.Resources.NodeAdd_16;
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
			this.contextMenuAddToNodes.Size = new System.Drawing.Size(203, 92);
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
			this.buttonRemoveFromNodes.Image = global::YtAnalytics.Resources.NodeRemove_16;
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
			this.controlLog.Size = new System.Drawing.Size(798, 169);
			this.controlLog.TabIndex = 0;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "GlobeObject");
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
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.contextMenuAddToNodes.ResumeLayout(false);
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
		private Log.ControlLogList controlLog;
		private System.Windows.Forms.ToolStripButton buttonRemoveFromNodes;
		private System.Windows.Forms.ToolStripDropDownButton buttonAddToNodes;
		private System.Windows.Forms.ContextMenuStrip contextMenuAddToNodes;
		private System.Windows.Forms.ToolStripMenuItem itemSelectNodesLocation;
		private System.Windows.Forms.ToolStripMenuItem itemSelectNodesState;
		private System.Windows.Forms.ToolStripMenuItem itemSelectNodesSlice;
	}
}
