namespace InetAnalytics.Controls.YouTube.Api2
{
	partial class ControlYtApi2VideosFeed
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
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelFeed = new DotNetApi.Windows.Controls.ThemeControl();
			this.videoList = new InetAnalytics.Controls.YouTube.ControlVideoList();
			this.viewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemApiV2Video = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemApiV2Author = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemApiV2Related = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemApiV2Response = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemWeb = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemYouTube = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemComment = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.panelQuery = new System.Windows.Forms.Panel();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.checkBoxView = new System.Windows.Forms.CheckBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.labelUrl = new System.Windows.Forms.Label();
			this.labelId = new System.Windows.Forms.Label();
			this.log = new InetControls.Controls.Log.ControlLogList();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelFeed.SuspendLayout();
			this.viewMenu.SuspendLayout();
			this.panelQuery.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.panelFeed);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 2;
			// 
			// panelFeed
			// 
			this.panelFeed.Controls.Add(this.videoList);
			this.panelFeed.Controls.Add(this.panelQuery);
			this.panelFeed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelFeed.Location = new System.Drawing.Point(0, 0);
			this.panelFeed.Name = "panelFeed";
			this.panelFeed.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelFeed.ShowBorder = true;
			this.panelFeed.ShowTitle = true;
			this.panelFeed.Size = new System.Drawing.Size(600, 225);
			this.panelFeed.TabIndex = 2;
			this.panelFeed.Title = "YouTube Video Feed";
			// 
			// videoList
			// 
			this.videoList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.videoList.FindNextEnabled = false;
			this.videoList.FindPreviousEnabled = false;
			this.videoList.Location = new System.Drawing.Point(1, 104);
			this.videoList.Name = "videoList";
			this.videoList.NextEnabled = false;
			this.videoList.PreviousEnabled = false;
			this.videoList.Size = new System.Drawing.Size(598, 120);
			this.videoList.TabIndex = 1;
			this.videoList.VideoContextMenu = this.viewMenu;
			this.videoList.PreviousClick += new System.EventHandler(this.OnNavigatePrevious);
			this.videoList.NextClick += new System.EventHandler(this.OnNavigateNext);
			this.videoList.FindPreviousClick += new System.EventHandler(this.OnFindPrevious);
			this.videoList.FindNextClick += new System.EventHandler(this.OnFindNext);
			this.videoList.VideoSelectionChanged += new System.EventHandler(this.OnVideoSelectedChanged);
			this.videoList.VideosPerPageChanged += new System.EventHandler(this.OnSearchChanged);
			this.videoList.ViewProfile += new InetCrawler.Events.StringEventHandler(this.OnViewProfile);
			// 
			// viewMenu
			// 
			this.viewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemApiV2Video,
            this.menuItemApiV2Author,
            this.menuItemApiV2Related,
            this.menuItemApiV2Response,
            this.menuItemWeb,
            this.toolStripSeparator1,
            this.menuItemYouTube,
            this.toolStripSeparator2,
            this.menuItemComment,
            this.toolStripSeparator3,
            this.menuItemProperties});
			this.viewMenu.Name = "viewMenu";
			this.viewMenu.Size = new System.Drawing.Size(168, 198);
			this.viewMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.OnViewMenuClosed);
			// 
			// menuItemApiV2Video
			// 
			this.menuItemApiV2Video.Image = global::InetAnalytics.Resources.FileVideo_16;
			this.menuItemApiV2Video.Name = "menuItemApiV2Video";
			this.menuItemApiV2Video.Size = new System.Drawing.Size(167, 22);
			this.menuItemApiV2Video.Text = "Video";
			this.menuItemApiV2Video.Click += new System.EventHandler(this.OnViewApiV2Video);
			// 
			// menuItemApiV2Author
			// 
			this.menuItemApiV2Author.Image = global::InetAnalytics.Resources.FileUser_16;
			this.menuItemApiV2Author.Name = "menuItemApiV2Author";
			this.menuItemApiV2Author.Size = new System.Drawing.Size(167, 22);
			this.menuItemApiV2Author.Text = "Author";
			this.menuItemApiV2Author.Click += new System.EventHandler(this.OnViewApiV2Author);
			// 
			// menuItemApiV2Related
			// 
			this.menuItemApiV2Related.Image = global::InetAnalytics.Resources.FolderClosedVideo_16;
			this.menuItemApiV2Related.Name = "menuItemApiV2Related";
			this.menuItemApiV2Related.Size = new System.Drawing.Size(167, 22);
			this.menuItemApiV2Related.Text = "Related videos";
			this.menuItemApiV2Related.Click += new System.EventHandler(this.OnViewApiV2Related);
			// 
			// menuItemApiV2Response
			// 
			this.menuItemApiV2Response.Image = global::InetAnalytics.Resources.FolderClosedVideo_16;
			this.menuItemApiV2Response.Name = "menuItemApiV2Response";
			this.menuItemApiV2Response.Size = new System.Drawing.Size(167, 22);
			this.menuItemApiV2Response.Text = "Response videos";
			this.menuItemApiV2Response.Click += new System.EventHandler(this.OnViewApiV2Responses);
			// 
			// menuItemWeb
			// 
			this.menuItemWeb.Image = global::InetAnalytics.Resources.GlobeBrowse_16;
			this.menuItemWeb.Name = "menuItemWeb";
			this.menuItemWeb.Size = new System.Drawing.Size(167, 22);
			this.menuItemWeb.Text = "Web statistics";
			this.menuItemWeb.Click += new System.EventHandler(this.OnViewWeb);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
			// 
			// menuItemYouTube
			// 
			this.menuItemYouTube.Image = global::InetAnalytics.Resources.Globe_16;
			this.menuItemYouTube.Name = "menuItemYouTube";
			this.menuItemYouTube.Size = new System.Drawing.Size(167, 22);
			this.menuItemYouTube.Text = "Open in YouTube";
			this.menuItemYouTube.Click += new System.EventHandler(this.OnOpenYouTube);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
			// 
			// menuItemComment
			// 
			this.menuItemComment.Image = global::InetAnalytics.Resources.CommentAdd_16;
			this.menuItemComment.Name = "menuItemComment";
			this.menuItemComment.Size = new System.Drawing.Size(167, 22);
			this.menuItemComment.Text = "Add comment";
			this.menuItemComment.Click += new System.EventHandler(this.OnComment);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
			// 
			// menuItemProperties
			// 
			this.menuItemProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.menuItemProperties.Name = "menuItemProperties";
			this.menuItemProperties.Size = new System.Drawing.Size(167, 22);
			this.menuItemProperties.Text = "Properties";
			this.menuItemProperties.Click += new System.EventHandler(this.OnViewProperties);
			// 
			// panelQuery
			// 
			this.panelQuery.Controls.Add(this.textBoxId);
			this.panelQuery.Controls.Add(this.checkBoxView);
			this.panelQuery.Controls.Add(this.buttonStart);
			this.panelQuery.Controls.Add(this.buttonStop);
			this.panelQuery.Controls.Add(this.linkLabel);
			this.panelQuery.Controls.Add(this.labelUrl);
			this.panelQuery.Controls.Add(this.labelId);
			this.panelQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelQuery.Location = new System.Drawing.Point(1, 22);
			this.panelQuery.Name = "panelQuery";
			this.panelQuery.Size = new System.Drawing.Size(598, 82);
			this.panelQuery.TabIndex = 0;
			// 
			// textBoxId
			// 
			this.textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxId.Location = new System.Drawing.Point(68, 4);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.Size = new System.Drawing.Size(335, 20);
			this.textBoxId.TabIndex = 1;
			this.textBoxId.TextChanged += new System.EventHandler(this.OnSearchChanged);
			// 
			// checkBoxView
			// 
			this.checkBoxView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxView.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBoxView.Enabled = false;
			this.checkBoxView.Location = new System.Drawing.Point(520, 28);
			this.checkBoxView.Name = "checkBoxView";
			this.checkBoxView.Size = new System.Drawing.Size(75, 23);
			this.checkBoxView.TabIndex = 4;
			this.checkBoxView.Text = "&View";
			this.checkBoxView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxView.UseVisualStyleBackColor = true;
			this.checkBoxView.CheckedChanged += new System.EventHandler(this.OnViewVideo);
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStart.Enabled = false;
			this.buttonStart.Image = global::InetAnalytics.Resources.PlayStart_16;
			this.buttonStart.Location = new System.Drawing.Point(439, 2);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 2;
			this.buttonStart.Text = "St&art";
			this.buttonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonStop
			// 
			this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::InetAnalytics.Resources.PlayStop_16;
			this.buttonStop.Location = new System.Drawing.Point(520, 2);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 3;
			this.buttonStop.Text = "St&op";
			this.buttonStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
			// 
			// linkLabel
			// 
			this.linkLabel.AutoSize = true;
			this.linkLabel.Location = new System.Drawing.Point(50, 33);
			this.linkLabel.Name = "linkLabel";
			this.linkLabel.Size = new System.Drawing.Size(0, 13);
			this.linkLabel.TabIndex = 6;
			this.linkLabel.UseMnemonic = false;
			this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnOpenLink);
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(3, 33);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(32, 13);
			this.labelUrl.TabIndex = 5;
			this.labelUrl.Text = "URL:";
			// 
			// labelId
			// 
			this.labelId.AutoSize = true;
			this.labelId.Location = new System.Drawing.Point(3, 7);
			this.labelId.Name = "labelId";
			this.labelId.Size = new System.Drawing.Size(21, 13);
			this.labelId.TabIndex = 0;
			this.labelId.Text = "&ID:";
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.log.ShowBorder = true;
			this.log.ShowTitle = true;
			this.log.Size = new System.Drawing.Size(600, 170);
			this.log.TabIndex = 0;
			this.log.Title = "Log";
			// 
			// ControlYtApi2VideosFeed
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlYtApi2VideosFeed";
			this.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelFeed.ResumeLayout(false);
			this.viewMenu.ResumeLayout(false);
			this.panelQuery.ResumeLayout(false);
			this.panelQuery.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private InetControls.Controls.Log.ControlLogList log;
		private System.Windows.Forms.Panel panelQuery;
		private System.Windows.Forms.Label labelId;
		private System.Windows.Forms.LinkLabel linkLabel;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.ContextMenuStrip viewMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Video;
		private System.Windows.Forms.ToolStripMenuItem menuItemWeb;
		private System.Windows.Forms.CheckBox checkBoxView;
		private ControlVideoList videoList;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItemYouTube;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Response;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Related;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
		private System.Windows.Forms.ToolStripMenuItem menuItemComment;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Author;
		private DotNetApi.Windows.Controls.ThemeControl panelFeed;

	}
}
