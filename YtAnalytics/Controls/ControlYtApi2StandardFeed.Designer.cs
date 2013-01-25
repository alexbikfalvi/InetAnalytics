namespace YtAnalytics.Controls
{
	partial class ControlYtApi2StandardFeed
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlYtApi2StandardFeed));
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.videoList = new YtAnalytics.Controls.ControlVideoList();
			this.viewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemApi2 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemApiV2Related = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemApiV2Responses = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemApi3 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemWeb = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemYouTube = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemComment = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.panel = new System.Windows.Forms.Panel();
			this.buttonRefreshCategories = new System.Windows.Forms.Button();
			this.checkBoxView = new System.Windows.Forms.CheckBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.labelUrl = new System.Windows.Forms.Label();
			this.labelRegion = new System.Windows.Forms.Label();
			this.labelTime = new System.Windows.Forms.Label();
			this.labelCategory = new System.Windows.Forms.Label();
			this.labelFeed = new System.Windows.Forms.Label();
			this.comboBoxRegion = new System.Windows.Forms.ComboBox();
			this.comboBoxCategory = new System.Windows.Forms.ComboBox();
			this.comboBoxTime = new System.Windows.Forms.ComboBox();
			this.comboBoxFeed = new System.Windows.Forms.ComboBox();
			this.log = new YtAnalytics.Controls.ControlLogList();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.viewMenu.SuspendLayout();
			this.panel.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.videoList);
			this.splitContainer.Panel1.Controls.Add(this.panel);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
			this.splitContainer.TabIndex = 2;
			// 
			// videoList
			// 
			this.videoList.CountPerPage = null;
			this.videoList.CountStart = null;
			this.videoList.CountTotal = null;
			this.videoList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.videoList.Location = new System.Drawing.Point(0, 82);
			this.videoList.Name = "videoList";
			this.videoList.Next = false;
			this.videoList.Previous = false;
			this.videoList.Size = new System.Drawing.Size(598, 141);
			this.videoList.TabIndex = 1;
			this.videoList.VideoContextMenu = this.viewMenu;
			this.videoList.PreviousClick += new System.EventHandler(this.OnNavigatePrevious);
			this.videoList.NextClick += new System.EventHandler(this.OnNavigateNext);
			this.videoList.VideoSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnVideoSelectedChanged);
			this.videoList.VideosPerPageChanged += new System.EventHandler(this.OnSelectionChanged);
			this.videoList.ViewProfile += new YtAnalytics.Controls.ViewProfileIdEventHandler(this.OnViewProfile);
			// 
			// viewMenu
			// 
			this.viewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemApi2,
            this.menuItemApiV2Related,
            this.menuItemApiV2Responses,
            this.menuItemApi3,
            this.menuItemWeb,
            this.toolStripSeparator1,
            this.menuItemYouTube,
            this.toolStripSeparator2,
            this.menuItemComment,
            this.toolStripSeparator3,
            this.menuItemProperties});
			this.viewMenu.Name = "viewMenu";
			this.viewMenu.Size = new System.Drawing.Size(192, 198);
			this.viewMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.OnViewMenuClosed);
			// 
			// menuItemApi2
			// 
			this.menuItemApi2.Image = global::YtAnalytics.Resources.ServerBrowse_16;
			this.menuItemApi2.Name = "menuItemApi2";
			this.menuItemApi2.Size = new System.Drawing.Size(191, 22);
			this.menuItemApi2.Text = "APIv2 information";
			this.menuItemApi2.Click += new System.EventHandler(this.OnViewApiV2Entry);
			// 
			// menuItemApiV2Related
			// 
			this.menuItemApiV2Related.Image = global::YtAnalytics.Resources.ServerBrowse_16;
			this.menuItemApiV2Related.Name = "menuItemApiV2Related";
			this.menuItemApiV2Related.Size = new System.Drawing.Size(191, 22);
			this.menuItemApiV2Related.Text = "APIv2 related videos";
			this.menuItemApiV2Related.Click += new System.EventHandler(this.OnViewApiV2Related);
			// 
			// menuItemApiV2Responses
			// 
			this.menuItemApiV2Responses.Image = global::YtAnalytics.Resources.ServerBrowse_16;
			this.menuItemApiV2Responses.Name = "menuItemApiV2Responses";
			this.menuItemApiV2Responses.Size = new System.Drawing.Size(191, 22);
			this.menuItemApiV2Responses.Text = "APIv2 response videos";
			this.menuItemApiV2Responses.Click += new System.EventHandler(this.OnViewApiV2Responses);
			// 
			// menuItemApi3
			// 
			this.menuItemApi3.Image = global::YtAnalytics.Resources.ServerBrowse_16;
			this.menuItemApi3.Name = "menuItemApi3";
			this.menuItemApi3.Size = new System.Drawing.Size(191, 22);
			this.menuItemApi3.Text = "APIv3 information";
			this.menuItemApi3.Click += new System.EventHandler(this.OnViewApiV3Entry);
			// 
			// menuItemWeb
			// 
			this.menuItemWeb.Image = global::YtAnalytics.Resources.GlobeBrowse_16;
			this.menuItemWeb.Name = "menuItemWeb";
			this.menuItemWeb.Size = new System.Drawing.Size(191, 22);
			this.menuItemWeb.Text = "Web statistics";
			this.menuItemWeb.Click += new System.EventHandler(this.OnViewWeb);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
			// 
			// menuItemYouTube
			// 
			this.menuItemYouTube.Image = global::YtAnalytics.Resources.Globe_16;
			this.menuItemYouTube.Name = "menuItemYouTube";
			this.menuItemYouTube.Size = new System.Drawing.Size(191, 22);
			this.menuItemYouTube.Text = "Open in YouTube";
			this.menuItemYouTube.Click += new System.EventHandler(this.OnOpenYouTube);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
			// 
			// menuItemComment
			// 
			this.menuItemComment.Image = global::YtAnalytics.Resources.CommentAdd_16;
			this.menuItemComment.Name = "menuItemComment";
			this.menuItemComment.Size = new System.Drawing.Size(191, 22);
			this.menuItemComment.Text = "Add comment";
			this.menuItemComment.Click += new System.EventHandler(this.OnComment);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
			// 
			// menuItemProperties
			// 
			this.menuItemProperties.Image = global::YtAnalytics.Resources.Properties_16;
			this.menuItemProperties.Name = "menuItemProperties";
			this.menuItemProperties.Size = new System.Drawing.Size(191, 22);
			this.menuItemProperties.Text = "Properties";
			this.menuItemProperties.Click += new System.EventHandler(this.OnViewProperties);
			// 
			// panel
			// 
			this.panel.Controls.Add(this.buttonRefreshCategories);
			this.panel.Controls.Add(this.checkBoxView);
			this.panel.Controls.Add(this.buttonStart);
			this.panel.Controls.Add(this.buttonStop);
			this.panel.Controls.Add(this.linkLabel);
			this.panel.Controls.Add(this.labelUrl);
			this.panel.Controls.Add(this.labelRegion);
			this.panel.Controls.Add(this.labelTime);
			this.panel.Controls.Add(this.labelCategory);
			this.panel.Controls.Add(this.labelFeed);
			this.panel.Controls.Add(this.comboBoxRegion);
			this.panel.Controls.Add(this.comboBoxCategory);
			this.panel.Controls.Add(this.comboBoxTime);
			this.panel.Controls.Add(this.comboBoxFeed);
			this.panel.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(598, 82);
			this.panel.TabIndex = 0;
			// 
			// buttonRefreshCategories
			// 
			this.buttonRefreshCategories.Image = global::YtAnalytics.Resources.Refresh_16;
			this.buttonRefreshCategories.Location = new System.Drawing.Point(393, 2);
			this.buttonRefreshCategories.Name = "buttonRefreshCategories";
			this.buttonRefreshCategories.Size = new System.Drawing.Size(23, 23);
			this.buttonRefreshCategories.TabIndex = 6;
			this.buttonRefreshCategories.UseVisualStyleBackColor = true;
			this.buttonRefreshCategories.Click += new System.EventHandler(this.OnBeginRefreshCategories);
			// 
			// checkBoxView
			// 
			this.checkBoxView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxView.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBoxView.Enabled = false;
			this.checkBoxView.Location = new System.Drawing.Point(520, 28);
			this.checkBoxView.Name = "checkBoxView";
			this.checkBoxView.Size = new System.Drawing.Size(75, 23);
			this.checkBoxView.TabIndex = 13;
			this.checkBoxView.Text = "&View";
			this.checkBoxView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxView.UseVisualStyleBackColor = true;
			this.checkBoxView.CheckedChanged += new System.EventHandler(this.OnViewVideo);
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStart.Image = global::YtAnalytics.Resources.PlayStart_16;
			this.buttonStart.Location = new System.Drawing.Point(439, 2);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 11;
			this.buttonStart.Text = "St&art";
			this.buttonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonStop
			// 
			this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::YtAnalytics.Resources.PlayStop_16;
			this.buttonStop.Location = new System.Drawing.Point(520, 2);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 12;
			this.buttonStop.Text = "St&op";
			this.buttonStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
			// 
			// linkLabel
			// 
			this.linkLabel.AutoSize = true;
			this.linkLabel.Location = new System.Drawing.Point(68, 60);
			this.linkLabel.Name = "linkLabel";
			this.linkLabel.Size = new System.Drawing.Size(0, 13);
			this.linkLabel.TabIndex = 10;
			this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnOpenLink);
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(3, 60);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(32, 13);
			this.labelUrl.TabIndex = 9;
			this.labelUrl.Text = "URL:";
			// 
			// labelRegion
			// 
			this.labelRegion.AutoSize = true;
			this.labelRegion.Location = new System.Drawing.Point(198, 33);
			this.labelRegion.Name = "labelRegion";
			this.labelRegion.Size = new System.Drawing.Size(44, 13);
			this.labelRegion.TabIndex = 7;
			this.labelRegion.Text = "Region:";
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.Location = new System.Drawing.Point(3, 33);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(33, 13);
			this.labelTime.TabIndex = 2;
			this.labelTime.Text = "Time:";
			// 
			// labelCategory
			// 
			this.labelCategory.AutoSize = true;
			this.labelCategory.Location = new System.Drawing.Point(198, 6);
			this.labelCategory.Name = "labelCategory";
			this.labelCategory.Size = new System.Drawing.Size(52, 13);
			this.labelCategory.TabIndex = 4;
			this.labelCategory.Text = "Category:";
			// 
			// labelFeed
			// 
			this.labelFeed.AutoSize = true;
			this.labelFeed.Location = new System.Drawing.Point(3, 6);
			this.labelFeed.Name = "labelFeed";
			this.labelFeed.Size = new System.Drawing.Size(34, 13);
			this.labelFeed.TabIndex = 0;
			this.labelFeed.Text = "Feed:";
			// 
			// comboBoxRegion
			// 
			this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxRegion.FormattingEnabled = true;
			this.comboBoxRegion.Location = new System.Drawing.Point(266, 30);
			this.comboBoxRegion.Name = "comboBoxRegion";
			this.comboBoxRegion.Size = new System.Drawing.Size(121, 21);
			this.comboBoxRegion.TabIndex = 8;
			this.comboBoxRegion.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
			// 
			// comboBoxCategory
			// 
			this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCategory.FormattingEnabled = true;
			this.comboBoxCategory.Location = new System.Drawing.Point(266, 3);
			this.comboBoxCategory.Name = "comboBoxCategory";
			this.comboBoxCategory.Size = new System.Drawing.Size(121, 21);
			this.comboBoxCategory.TabIndex = 5;
			this.comboBoxCategory.DropDown += new System.EventHandler(this.OnOpenCategories);
			this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
			// 
			// comboBoxTime
			// 
			this.comboBoxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTime.FormattingEnabled = true;
			this.comboBoxTime.Location = new System.Drawing.Point(71, 30);
			this.comboBoxTime.Name = "comboBoxTime";
			this.comboBoxTime.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTime.TabIndex = 3;
			this.comboBoxTime.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
			// 
			// comboBoxFeed
			// 
			this.comboBoxFeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFeed.FormattingEnabled = true;
			this.comboBoxFeed.Location = new System.Drawing.Point(71, 3);
			this.comboBoxFeed.Name = "comboBoxFeed";
			this.comboBoxFeed.Size = new System.Drawing.Size(121, 21);
			this.comboBoxFeed.TabIndex = 1;
			this.comboBoxFeed.SelectedIndexChanged += new System.EventHandler(this.OnFeedChanged);
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(598, 169);
			this.log.TabIndex = 0;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Video");
			// 
			// ControlYtApi2StandardFeed
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlYtApi2StandardFeed";
			this.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.viewMenu.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private ControlLogList log;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.ComboBox comboBoxCategory;
		private System.Windows.Forms.ComboBox comboBoxTime;
		private System.Windows.Forms.ComboBox comboBoxFeed;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.Label labelCategory;
		private System.Windows.Forms.Label labelFeed;
		private System.Windows.Forms.ComboBox comboBoxRegion;
		private System.Windows.Forms.Label labelRegion;
		private System.Windows.Forms.LinkLabel linkLabel;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.ContextMenuStrip viewMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemApi2;
		private System.Windows.Forms.ToolStripMenuItem menuItemApi3;
		private System.Windows.Forms.ToolStripMenuItem menuItemWeb;
		private System.Windows.Forms.CheckBox checkBoxView;
		private ControlVideoList videoList;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItemYouTube;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Related;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Responses;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
		private System.Windows.Forms.Button buttonRefreshCategories;
		private System.Windows.Forms.ToolStripMenuItem menuItemComment;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

	}
}
