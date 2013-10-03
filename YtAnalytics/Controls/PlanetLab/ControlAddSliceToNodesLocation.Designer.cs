namespace YtAnalytics.Controls.PlanetLab
{
	partial class ControlAddSliceToNodesLocation
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlAddSliceToNodesLocation));
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.buttonBack = new System.Windows.Forms.Button();
			this.wizard = new DotNetApi.Windows.Controls.WizardControl();
			this.wizardPageSite = new DotNetApi.Windows.Controls.WizardPage();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.mapControl = new DotNetApi.Windows.Controls.MapControl();
			this.listViewSites = new System.Windows.Forms.ListView();
			this.columnSiteId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSiteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSiteUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSiteDateCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSiteLastUpdated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSiteLatitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnSiteLongitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textBoxFilterSite = new System.Windows.Forms.TextBox();
			this.labelFilterSite = new System.Windows.Forms.Label();
			this.wizardPageNode = new DotNetApi.Windows.Controls.WizardPage();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnNodeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeHostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeBootState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeDateCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeLastUpdated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textBoxFilterNode = new System.Windows.Forms.TextBox();
			this.labelFilterNode = new System.Windows.Forms.Label();
			this.labelSubtitle = new System.Windows.Forms.Label();
			this.buttonClearAll = new System.Windows.Forms.Button();
			this.buttonSelectAll = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.wizard.SuspendLayout();
			this.wizardPageSite.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.wizardPageNode.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 28);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(215, 20);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Add PlanetLab slice to nodes";
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
			this.buttonNext.Text = "&Select";
			this.buttonNext.UseVisualStyleBackColor = true;
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
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefresh);
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
			this.imageList.Images.SetKeyName(5, "NodeUnknown");
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
			// wizard
			// 
			this.wizard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.wizard.BackButton = this.buttonBack;
			this.wizard.Controls.Add(this.wizardPageSite);
			this.wizard.Controls.Add(this.wizardPageNode);
			this.wizard.Location = new System.Drawing.Point(0, 73);
			this.wizard.Name = "wizard";
			this.wizard.NextButton = this.buttonNext;
			this.wizard.Padding = new System.Windows.Forms.Padding(3);
			this.wizard.Pages.AddRange(new DotNetApi.Windows.Controls.WizardPage[] {
            this.wizardPageSite,
            this.wizardPageNode});
			this.wizard.SelectedIndex = 1;
			this.wizard.Size = new System.Drawing.Size(800, 495);
			this.wizard.StatusLabel = this.labelStatus;
			this.wizard.TabIndex = 8;
			this.wizard.TitleLabel = this.labelSubtitle;
			this.wizard.PageChanged += new System.EventHandler(this.OnWizardPageChanged);
			this.wizard.Finished += new System.EventHandler(this.OnWizardFinished);
			// 
			// wizardPageSite
			// 
			this.wizardPageSite.BackEnabled = true;
			this.wizardPageSite.Controls.Add(this.splitContainer);
			this.wizardPageSite.Controls.Add(this.textBoxFilterSite);
			this.wizardPageSite.Controls.Add(this.labelFilterSite);
			this.wizardPageSite.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPageSite.Location = new System.Drawing.Point(0, 0);
			this.wizardPageSite.Name = "wizardPageSite";
			this.wizardPageSite.Padding = new System.Windows.Forms.Padding(3);
			this.wizardPageSite.Size = new System.Drawing.Size(800, 495);
			this.wizardPageSite.Status = "Ready.";
			this.wizardPageSite.TabIndex = 0;
			this.wizardPageSite.Title = "Select site";
			this.wizardPageSite.Visible = false;
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer.Location = new System.Drawing.Point(6, 32);
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
			this.splitContainer.Size = new System.Drawing.Size(788, 463);
			this.splitContainer.SplitterDistance = 317;
			this.splitContainer.TabIndex = 10;
			// 
			// mapControl
			// 
			this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapControl.Location = new System.Drawing.Point(0, 0);
			this.mapControl.MapBounds = ((MapApi.MapRectangle)(resources.GetObject("mapControl.MapBounds")));
			this.mapControl.Name = "mapControl";
			this.mapControl.Size = new System.Drawing.Size(786, 315);
			this.mapControl.TabIndex = 0;
			this.mapControl.MarkerClick += new System.EventHandler(this.OnMapMarkerClick);
			this.mapControl.MarkerDoubleClick += new System.EventHandler(this.OnMapMarkerDoubleClick);
			// 
			// listViewSites
			// 
			this.listViewSites.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSiteId,
            this.columnSiteName,
            this.columnSiteUrl,
            this.columnSiteDateCreated,
            this.columnSiteLastUpdated,
            this.columnSiteLatitude,
            this.columnSiteLongitude});
			this.listViewSites.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewSites.FullRowSelect = true;
			this.listViewSites.GridLines = true;
			this.listViewSites.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewSites.HideSelection = false;
			this.listViewSites.Location = new System.Drawing.Point(0, 0);
			this.listViewSites.Name = "listViewSites";
			this.listViewSites.Size = new System.Drawing.Size(786, 140);
			this.listViewSites.SmallImageList = this.imageList;
			this.listViewSites.TabIndex = 0;
			this.listViewSites.UseCompatibleStateImageBehavior = false;
			this.listViewSites.View = System.Windows.Forms.View.Details;
			this.listViewSites.ItemActivate += new System.EventHandler(this.OnSiteProperties);
			this.listViewSites.SelectedIndexChanged += new System.EventHandler(this.OnSiteSelectionChanged);
			// 
			// columnSiteId
			// 
			this.columnSiteId.Text = "ID";
			// 
			// columnSiteName
			// 
			this.columnSiteName.Text = "Name";
			this.columnSiteName.Width = 120;
			// 
			// columnSiteUrl
			// 
			this.columnSiteUrl.Text = "URL";
			this.columnSiteUrl.Width = 120;
			// 
			// columnSiteDateCreated
			// 
			this.columnSiteDateCreated.Text = "Date created";
			this.columnSiteDateCreated.Width = 120;
			// 
			// columnSiteLastUpdated
			// 
			this.columnSiteLastUpdated.Text = "Last updated";
			this.columnSiteLastUpdated.Width = 120;
			// 
			// columnSiteLatitude
			// 
			this.columnSiteLatitude.Text = "Latitude";
			this.columnSiteLatitude.Width = 100;
			// 
			// columnSiteLongitude
			// 
			this.columnSiteLongitude.Text = "Longitude";
			this.columnSiteLongitude.Width = 100;
			// 
			// textBoxFilterSite
			// 
			this.textBoxFilterSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFilterSite.Location = new System.Drawing.Point(99, 6);
			this.textBoxFilterSite.Name = "textBoxFilterSite";
			this.textBoxFilterSite.Size = new System.Drawing.Size(695, 20);
			this.textBoxFilterSite.TabIndex = 2;
			this.textBoxFilterSite.TextChanged += new System.EventHandler(this.OnSiteFilterTextChanged);
			// 
			// labelFilterSite
			// 
			this.labelFilterSite.AutoSize = true;
			this.labelFilterSite.Location = new System.Drawing.Point(6, 9);
			this.labelFilterSite.Name = "labelFilterSite";
			this.labelFilterSite.Size = new System.Drawing.Size(87, 13);
			this.labelFilterSite.TabIndex = 1;
			this.labelFilterSite.Text = "&Search by name:";
			// 
			// wizardPageNode
			// 
			this.wizardPageNode.BackEnabled = true;
			this.wizardPageNode.Controls.Add(this.buttonClearAll);
			this.wizardPageNode.Controls.Add(this.buttonSelectAll);
			this.wizardPageNode.Controls.Add(this.listViewNodes);
			this.wizardPageNode.Controls.Add(this.textBoxFilterNode);
			this.wizardPageNode.Controls.Add(this.labelFilterNode);
			this.wizardPageNode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wizardPageNode.Location = new System.Drawing.Point(0, 0);
			this.wizardPageNode.Name = "wizardPageNode";
			this.wizardPageNode.NextText = "&Select";
			this.wizardPageNode.Padding = new System.Windows.Forms.Padding(3);
			this.wizardPageNode.Size = new System.Drawing.Size(800, 495);
			this.wizardPageNode.Status = "Ready.";
			this.wizardPageNode.TabIndex = 1;
			this.wizardPageNode.Title = "Select node";
			this.wizardPageNode.Visible = false;
			// 
			// listViewNodes
			// 
			this.listViewNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewNodes.CheckBoxes = true;
			this.listViewNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNodeId,
            this.columnNodeHostname,
            this.columnNodeBootState,
            this.columnNodeModel,
            this.columnNodeVersion,
            this.columnNodeDateCreated,
            this.columnNodeLastUpdated,
            this.columnNodeType});
			this.listViewNodes.FullRowSelect = true;
			this.listViewNodes.GridLines = true;
			this.listViewNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewNodes.HideSelection = false;
			this.listViewNodes.Location = new System.Drawing.Point(6, 61);
			this.listViewNodes.Name = "listViewNodes";
			this.listViewNodes.Size = new System.Drawing.Size(788, 434);
			this.listViewNodes.SmallImageList = this.imageList;
			this.listViewNodes.TabIndex = 3;
			this.listViewNodes.UseCompatibleStateImageBehavior = false;
			this.listViewNodes.View = System.Windows.Forms.View.Details;
			this.listViewNodes.ItemActivate += new System.EventHandler(this.OnNodeProperties);
			this.listViewNodes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnNodeChecked);
			// 
			// columnNodeId
			// 
			this.columnNodeId.Text = "ID";
			this.columnNodeId.Width = 80;
			// 
			// columnNodeHostname
			// 
			this.columnNodeHostname.Text = "Hostname";
			this.columnNodeHostname.Width = 120;
			// 
			// columnNodeBootState
			// 
			this.columnNodeBootState.Text = "Boot state";
			// 
			// columnNodeModel
			// 
			this.columnNodeModel.Text = "Model";
			this.columnNodeModel.Width = 120;
			// 
			// columnNodeVersion
			// 
			this.columnNodeVersion.Text = "Version";
			// 
			// columnNodeDateCreated
			// 
			this.columnNodeDateCreated.Text = "Date created";
			this.columnNodeDateCreated.Width = 120;
			// 
			// columnNodeLastUpdated
			// 
			this.columnNodeLastUpdated.Text = "Last updated";
			this.columnNodeLastUpdated.Width = 120;
			// 
			// columnNodeType
			// 
			this.columnNodeType.Text = "Type";
			this.columnNodeType.Width = 120;
			// 
			// textBoxFilterNode
			// 
			this.textBoxFilterNode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFilterNode.Location = new System.Drawing.Point(99, 6);
			this.textBoxFilterNode.Name = "textBoxFilterNode";
			this.textBoxFilterNode.Size = new System.Drawing.Size(695, 20);
			this.textBoxFilterNode.TabIndex = 2;
			this.textBoxFilterNode.TextChanged += new System.EventHandler(this.OnNodeFilterTextChanged);
			// 
			// labelFilterNode
			// 
			this.labelFilterNode.AutoSize = true;
			this.labelFilterNode.Location = new System.Drawing.Point(6, 9);
			this.labelFilterNode.Name = "labelFilterNode";
			this.labelFilterNode.Size = new System.Drawing.Size(87, 13);
			this.labelFilterNode.TabIndex = 1;
			this.labelFilterNode.Text = "&Search by name:";
			// 
			// labelSubtitle
			// 
			this.labelSubtitle.AutoSize = true;
			this.labelSubtitle.ForeColor = System.Drawing.Color.Gray;
			this.labelSubtitle.Location = new System.Drawing.Point(76, 48);
			this.labelSubtitle.Name = "labelSubtitle";
			this.labelSubtitle.Size = new System.Drawing.Size(122, 13);
			this.labelSubtitle.TabIndex = 9;
			this.labelSubtitle.Text = "Step 2 of 2: Select node";
			// 
			// buttonClearAll
			// 
			this.buttonClearAll.Enabled = false;
			this.buttonClearAll.Location = new System.Drawing.Point(87, 32);
			this.buttonClearAll.Name = "buttonClearAll";
			this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
			this.buttonClearAll.TabIndex = 7;
			this.buttonClearAll.Text = "Cl&ear all";
			this.buttonClearAll.UseVisualStyleBackColor = true;
			this.buttonClearAll.Click += new System.EventHandler(this.OnClearAll);
			// 
			// buttonSelectAll
			// 
			this.buttonSelectAll.Enabled = false;
			this.buttonSelectAll.Location = new System.Drawing.Point(6, 32);
			this.buttonSelectAll.Name = "buttonSelectAll";
			this.buttonSelectAll.Size = new System.Drawing.Size(75, 23);
			this.buttonSelectAll.TabIndex = 6;
			this.buttonSelectAll.Text = "Select &all";
			this.buttonSelectAll.UseVisualStyleBackColor = true;
			this.buttonSelectAll.Click += new System.EventHandler(this.OnSelectAll);
			// 
			// ControlAddSliceToNodesLocation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.labelSubtitle);
			this.Controls.Add(this.wizard);
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.MinimumSize = new System.Drawing.Size(0, 230);
			this.Name = "ControlAddSliceToNodesLocation";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.pictureBox, 0);
			this.Controls.SetChildIndex(this.labelTitle, 0);
			this.Controls.SetChildIndex(this.buttonRefresh, 0);
			this.Controls.SetChildIndex(this.buttonClose, 0);
			this.Controls.SetChildIndex(this.buttonNext, 0);
			this.Controls.SetChildIndex(this.buttonCancel, 0);
			this.Controls.SetChildIndex(this.labelStatus, 0);
			this.Controls.SetChildIndex(this.buttonBack, 0);
			this.Controls.SetChildIndex(this.wizard, 0);
			this.Controls.SetChildIndex(this.labelSubtitle, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.wizard.ResumeLayout(false);
			this.wizardPageSite.ResumeLayout(false);
			this.wizardPageSite.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.wizardPageNode.ResumeLayout(false);
			this.wizardPageNode.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.ImageList imageList;
		private DotNetApi.Windows.Controls.WizardControl wizard;
		private DotNetApi.Windows.Controls.WizardPage wizardPageSite;
		private DotNetApi.Windows.Controls.WizardPage wizardPageNode;
		private System.Windows.Forms.Label labelSubtitle;
		private System.Windows.Forms.SplitContainer splitContainer;
		private DotNetApi.Windows.Controls.MapControl mapControl;
		private System.Windows.Forms.ListView listViewSites;
		private System.Windows.Forms.ColumnHeader columnSiteId;
		private System.Windows.Forms.ColumnHeader columnSiteName;
		private System.Windows.Forms.ColumnHeader columnSiteUrl;
		private System.Windows.Forms.ColumnHeader columnSiteDateCreated;
		private System.Windows.Forms.ColumnHeader columnSiteLastUpdated;
		private System.Windows.Forms.ColumnHeader columnSiteLatitude;
		private System.Windows.Forms.ColumnHeader columnSiteLongitude;
		private System.Windows.Forms.TextBox textBoxFilterSite;
		private System.Windows.Forms.Label labelFilterSite;
		private System.Windows.Forms.Label labelFilterNode;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnNodeId;
		private System.Windows.Forms.ColumnHeader columnNodeHostname;
		private System.Windows.Forms.ColumnHeader columnNodeModel;
		private System.Windows.Forms.ColumnHeader columnNodeVersion;
		private System.Windows.Forms.ColumnHeader columnNodeDateCreated;
		private System.Windows.Forms.ColumnHeader columnNodeLastUpdated;
		private System.Windows.Forms.ColumnHeader columnNodeBootState;
		private System.Windows.Forms.TextBox textBoxFilterNode;
		private System.Windows.Forms.ColumnHeader columnNodeType;
		private System.Windows.Forms.Button buttonClearAll;
		private System.Windows.Forms.Button buttonSelectAll;
	}
}
