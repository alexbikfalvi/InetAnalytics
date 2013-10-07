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
			// If disposing the managed resources.
			if (disposing)
			{
				// If the components are not null.
				if (components != null)
				{
					// Dispose the components.
					components.Dispose();
				}
				// Remove the slice event handler.
				this.slice.Changed -= this.OnSliceChanged;
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.splitContainerSlice = new System.Windows.Forms.SplitContainer();
			this.mapControl = new DotNetApi.Windows.Controls.MapControl();
			this.panel = new System.Windows.Forms.Panel();
			this.textBoxKey = new System.Windows.Forms.TextBox();
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
			this.controlLog = new YtAnalytics.Controls.Log.ControlLogList();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSlice)).BeginInit();
			this.splitContainerSlice.Panel2.SuspendLayout();
			this.splitContainerSlice.SuspendLayout();
			this.panel.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.splitContainerSlice);
			this.splitContainer.Panel1.Controls.Add(this.panel);
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.controlLog);
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.TabIndex = 2;
			// 
			// splitContainerSlice
			// 
			this.splitContainerSlice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainerSlice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerSlice.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerSlice.Location = new System.Drawing.Point(0, 129);
			this.splitContainerSlice.Name = "splitContainerSlice";
			// 
			// splitContainerSlice.Panel2
			// 
			this.splitContainerSlice.Panel2.Controls.Add(this.mapControl);
			this.splitContainerSlice.Size = new System.Drawing.Size(800, 296);
			this.splitContainerSlice.SplitterDistance = 266;
			this.splitContainerSlice.TabIndex = 2;
			// 
			// mapControl
			// 
			this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapControl.Location = new System.Drawing.Point(0, 0);
			this.mapControl.MapBounds = ((MapApi.MapRectangle)(resources.GetObject("mapControl.MapBounds")));
			this.mapControl.Name = "mapControl";
			this.mapControl.Size = new System.Drawing.Size(528, 294);
			this.mapControl.TabIndex = 0;
			// 
			// panel
			// 
			this.panel.AutoScroll = true;
			this.panel.Controls.Add(this.textBoxKey);
			this.panel.Controls.Add(this.labelKey);
			this.panel.Controls.Add(this.labelMaxNodes);
			this.panel.Controls.Add(this.labelExpires);
			this.panel.Controls.Add(this.textBoxMaxNodes);
			this.panel.Controls.Add(this.textBoxExpires);
			this.panel.Controls.Add(this.labelCreated);
			this.panel.Controls.Add(this.labelUrl);
			this.panel.Controls.Add(this.textBoxCreated);
			this.panel.Controls.Add(this.textBoxUrl);
			this.panel.Controls.Add(this.labelDescription);
			this.panel.Controls.Add(this.textBoxDescription);
			this.panel.Controls.Add(this.labelName);
			this.panel.Controls.Add(this.textBoxName);
			this.panel.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel.Location = new System.Drawing.Point(0, 25);
			this.panel.MaximumSize = new System.Drawing.Size(0, 104);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(800, 104);
			this.panel.TabIndex = 1;
			// 
			// textBoxKey
			// 
			this.textBoxKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxKey.Location = new System.Drawing.Point(432, 55);
			this.textBoxKey.Multiline = true;
			this.textBoxKey.Name = "textBoxKey";
			this.textBoxKey.ReadOnly = true;
			this.textBoxKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxKey.Size = new System.Drawing.Size(215, 42);
			this.textBoxKey.TabIndex = 13;
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
            this.buttonSetKey});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(800, 25);
			this.toolStrip.TabIndex = 0;
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
			this.buttonRemoveFromNodes.Image = global::YtAnalytics.Resources.NodeRemove_16;
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
			this.buttonSetKey.Image = global::YtAnalytics.Resources.KeyVertical_16;
			this.buttonSetKey.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSetKey.Name = "buttonSetKey";
			this.buttonSetKey.Size = new System.Drawing.Size(64, 22);
			this.buttonSetKey.Text = "Set &key";
			this.buttonSetKey.Click += new System.EventHandler(this.OnSetKey);
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
			// openFileDialog
			// 
			this.openFileDialog.Filter = "All files (*.*)|*.*";
			this.openFileDialog.Title = "Open Key File";
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
			this.splitContainerSlice.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerSlice)).EndInit();
			this.splitContainerSlice.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
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
		private System.Windows.Forms.SplitContainer splitContainerSlice;
		private DotNetApi.Windows.Controls.MapControl mapControl;
		private System.Windows.Forms.Panel panel;
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
		private System.Windows.Forms.TextBox textBoxKey;
		private System.Windows.Forms.Label labelKey;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton buttonSetKey;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}
