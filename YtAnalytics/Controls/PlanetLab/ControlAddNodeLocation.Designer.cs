namespace YtAnalytics.Controls.PlanetLab
{
	partial class ControlAddNodeLocation
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlAddNodeLocation));
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxFilterSite = new System.Windows.Forms.TextBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelFilterSite = new System.Windows.Forms.Label();
			this.labelStatus = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.mapControl = new DotNetApi.Windows.Controls.MapControl();
			this.listViewSites = new System.Windows.Forms.ListView();
			this.columnSliceId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSliceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSliceUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSliceDateCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSliceLastUpdated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSliceLatitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSliceLongitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageSite = new System.Windows.Forms.TabPage();
			this.tabPageNode = new System.Windows.Forms.TabPage();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labelFilterNode = new System.Windows.Forms.Label();
			this.textBoxFilterNode = new System.Windows.Forms.TextBox();
			this.buttonBack = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageSite.SuspendLayout();
			this.tabPageNode.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(207, 20);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Add PlanetLab node to slice";
			// 
			// textBoxFilterSite
			// 
			this.textBoxFilterSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFilterSite.Location = new System.Drawing.Point(99, 6);
			this.textBoxFilterSite.Name = "textBoxFilterSite";
			this.textBoxFilterSite.Size = new System.Drawing.Size(687, 20);
			this.textBoxFilterSite.TabIndex = 1;
			this.textBoxFilterSite.TextChanged += new System.EventHandler(this.OnSiteFilterTextChanged);
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.NodeAdd_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// labelFilterSite
			// 
			this.labelFilterSite.AutoSize = true;
			this.labelFilterSite.Location = new System.Drawing.Point(6, 9);
			this.labelFilterSite.Name = "labelFilterSite";
			this.labelFilterSite.Size = new System.Drawing.Size(87, 13);
			this.labelFilterSite.TabIndex = 0;
			this.labelFilterSite.Text = "&Search by name:";
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStatus.AutoEllipsis = true;
			this.labelStatus.Location = new System.Drawing.Point(165, 574);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(389, 23);
			this.labelStatus.TabIndex = 4;
			this.labelStatus.Text = "Ready.";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Location = new System.Drawing.Point(84, 574);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "C&ancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// buttonNext
			// 
			this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonNext.Enabled = false;
			this.buttonNext.Location = new System.Drawing.Point(641, 574);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(75, 23);
			this.buttonNext.TabIndex = 6;
			this.buttonNext.Text = "&Next";
			this.buttonNext.UseVisualStyleBackColor = true;
			this.buttonNext.Click += new System.EventHandler(this.OnNext);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(722, 574);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 7;
			this.buttonClose.Text = "&Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.OnClose);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRefresh.Image = global::YtAnalytics.Resources.Refresh_16;
			this.buttonRefresh.Location = new System.Drawing.Point(3, 574);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
			this.buttonRefresh.TabIndex = 2;
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefreshStarted);
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer.Location = new System.Drawing.Point(0, 32);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.mapControl);
			this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.listViewSites);
			this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer.Size = new System.Drawing.Size(792, 434);
			this.splitContainer.SplitterDistance = 298;
			this.splitContainer.TabIndex = 9;
			// 
			// mapControl
			// 
			this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapControl.Location = new System.Drawing.Point(0, 0);
			this.mapControl.MapBounds = ((MapApi.MapRectangle)(resources.GetObject("mapControl.MapBounds")));
			this.mapControl.Name = "mapControl";
			this.mapControl.Size = new System.Drawing.Size(790, 296);
			this.mapControl.TabIndex = 0;
			this.mapControl.MarkerClick += new System.EventHandler(this.OnMapMarkerClick);
			this.mapControl.MarkerDoubleClick += new System.EventHandler(this.OnMapMarkerDoubleClick);
			// 
			// listViewSites
			// 
			this.listViewSites.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSliceId,
            this.columnSliceName,
            this.columnSliceUrl,
            this.columnSliceDateCreated,
            this.columnSliceLastUpdated,
            this.columnSliceLatitude,
            this.columnSliceLongitude});
			this.listViewSites.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewSites.FullRowSelect = true;
			this.listViewSites.GridLines = true;
			this.listViewSites.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewSites.HideSelection = false;
			this.listViewSites.Location = new System.Drawing.Point(0, 0);
			this.listViewSites.Name = "listViewSites";
			this.listViewSites.Size = new System.Drawing.Size(790, 130);
			this.listViewSites.SmallImageList = this.imageList;
			this.listViewSites.TabIndex = 0;
			this.listViewSites.UseCompatibleStateImageBehavior = false;
			this.listViewSites.View = System.Windows.Forms.View.Details;
			this.listViewSites.ItemActivate += new System.EventHandler(this.OnSiteProperties);
			this.listViewSites.SelectedIndexChanged += new System.EventHandler(this.OnSiteSelectionChanged);
			// 
			// columnSliceId
			// 
			this.columnSliceId.Text = "ID";
			// 
			// columnSliceName
			// 
			this.columnSliceName.Text = "Name";
			this.columnSliceName.Width = 120;
			// 
			// columnSliceUrl
			// 
			this.columnSliceUrl.Text = "URL";
			this.columnSliceUrl.Width = 120;
			// 
			// columnSliceDateCreated
			// 
			this.columnSliceDateCreated.Text = "Date created";
			this.columnSliceDateCreated.Width = 120;
			// 
			// columnSliceLastUpdated
			// 
			this.columnSliceLastUpdated.Text = "Last updated";
			this.columnSliceLastUpdated.Width = 120;
			// 
			// columnSliceLatitude
			// 
			this.columnSliceLatitude.Text = "Latitude";
			this.columnSliceLatitude.Width = 100;
			// 
			// columnSliceLongitude
			// 
			this.columnSliceLongitude.Text = "Longitude";
			this.columnSliceLongitude.Width = 100;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Site");
			this.imageList.Images.SetKeyName(1, "NodeBoot");
			this.imageList.Images.SetKeyName(2, "NodeDisabled");
			this.imageList.Images.SetKeyName(3, "NodeSafeBoot");
			this.imageList.Images.SetKeyName(4, "NodeReinstall");
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl.Controls.Add(this.tabPageSite);
			this.tabControl.Controls.Add(this.tabPageNode);
			this.tabControl.Location = new System.Drawing.Point(0, 73);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(800, 495);
			this.tabControl.TabIndex = 0;
			this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.OnTabSelecting);
			// 
			// tabPageSite
			// 
			this.tabPageSite.Controls.Add(this.labelFilterSite);
			this.tabPageSite.Controls.Add(this.textBoxFilterSite);
			this.tabPageSite.Controls.Add(this.splitContainer);
			this.tabPageSite.Location = new System.Drawing.Point(4, 25);
			this.tabPageSite.Name = "tabPageSite";
			this.tabPageSite.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSite.Size = new System.Drawing.Size(792, 466);
			this.tabPageSite.TabIndex = 0;
			this.tabPageSite.Text = "Step 1. Select site";
			this.tabPageSite.UseVisualStyleBackColor = true;
			// 
			// tabPageNode
			// 
			this.tabPageNode.Controls.Add(this.listViewNodes);
			this.tabPageNode.Controls.Add(this.labelFilterNode);
			this.tabPageNode.Controls.Add(this.textBoxFilterNode);
			this.tabPageNode.Location = new System.Drawing.Point(4, 25);
			this.tabPageNode.Name = "tabPageNode";
			this.tabPageNode.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageNode.Size = new System.Drawing.Size(792, 466);
			this.tabPageNode.TabIndex = 1;
			this.tabPageNode.Text = "Step 2. Select node";
			this.tabPageNode.UseVisualStyleBackColor = true;
			// 
			// listViewNodes
			// 
			this.listViewNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
			this.listViewNodes.FullRowSelect = true;
			this.listViewNodes.GridLines = true;
			this.listViewNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewNodes.HideSelection = false;
			this.listViewNodes.Location = new System.Drawing.Point(0, 32);
			this.listViewNodes.Name = "listViewNodes";
			this.listViewNodes.Size = new System.Drawing.Size(792, 434);
			this.listViewNodes.SmallImageList = this.imageList;
			this.listViewNodes.TabIndex = 2;
			this.listViewNodes.UseCompatibleStateImageBehavior = false;
			this.listViewNodes.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Name";
			this.columnHeader2.Width = 120;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "URL";
			this.columnHeader3.Width = 120;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Date created";
			this.columnHeader4.Width = 120;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Last updated";
			this.columnHeader5.Width = 120;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Latitude";
			this.columnHeader6.Width = 100;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Longitude";
			this.columnHeader7.Width = 100;
			// 
			// labelFilterNode
			// 
			this.labelFilterNode.AutoSize = true;
			this.labelFilterNode.Location = new System.Drawing.Point(6, 9);
			this.labelFilterNode.Name = "labelFilterNode";
			this.labelFilterNode.Size = new System.Drawing.Size(87, 13);
			this.labelFilterNode.TabIndex = 0;
			this.labelFilterNode.Text = "&Search by name:";
			// 
			// textBoxFilterNode
			// 
			this.textBoxFilterNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFilterNode.Location = new System.Drawing.Point(99, 6);
			this.textBoxFilterNode.Name = "textBoxFilterNode";
			this.textBoxFilterNode.Size = new System.Drawing.Size(687, 20);
			this.textBoxFilterNode.TabIndex = 1;
			// 
			// buttonBack
			// 
			this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBack.Enabled = false;
			this.buttonBack.Location = new System.Drawing.Point(560, 574);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(75, 23);
			this.buttonBack.TabIndex = 5;
			this.buttonBack.Text = "&Back";
			this.buttonBack.UseVisualStyleBackColor = true;
			// 
			// ControlAddNodeLocation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.MinimumSize = new System.Drawing.Size(0, 230);
			this.Name = "ControlAddNodeLocation";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.pictureBox, 0);
			this.Controls.SetChildIndex(this.labelTitle, 0);
			this.Controls.SetChildIndex(this.buttonRefresh, 0);
			this.Controls.SetChildIndex(this.buttonClose, 0);
			this.Controls.SetChildIndex(this.buttonNext, 0);
			this.Controls.SetChildIndex(this.buttonCancel, 0);
			this.Controls.SetChildIndex(this.labelStatus, 0);
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.Controls.SetChildIndex(this.buttonBack, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tabPageSite.ResumeLayout(false);
			this.tabPageSite.PerformLayout();
			this.tabPageNode.ResumeLayout(false);
			this.tabPageNode.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxFilterSite;
		private System.Windows.Forms.Label labelFilterSite;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.SplitContainer splitContainer;
		private DotNetApi.Windows.Controls.MapControl mapControl;
		private System.Windows.Forms.ListView listViewSites;
		private System.Windows.Forms.ColumnHeader columnSliceId;
		private System.Windows.Forms.ColumnHeader columnSliceName;
		private System.Windows.Forms.ColumnHeader columnSliceUrl;
		private System.Windows.Forms.ColumnHeader columnSliceDateCreated;
		private System.Windows.Forms.ColumnHeader columnSliceLastUpdated;
		private System.Windows.Forms.ColumnHeader columnSliceLatitude;
		private System.Windows.Forms.ColumnHeader columnSliceLongitude;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageSite;
		private System.Windows.Forms.TabPage tabPageNode;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.Label labelFilterNode;
		private System.Windows.Forms.TextBox textBoxFilterNode;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ImageList imageList;
	}
}
