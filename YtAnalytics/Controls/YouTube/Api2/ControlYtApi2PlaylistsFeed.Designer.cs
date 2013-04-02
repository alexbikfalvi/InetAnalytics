namespace YtAnalytics.Controls.YouTube.Api2
{
	partial class ControlYtApi2PlaylistsFeed
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.panel = new System.Windows.Forms.Panel();
			this.textBoxUser = new System.Windows.Forms.TextBox();
			this.checkBoxView = new System.Windows.Forms.CheckBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.labelUrl = new System.Windows.Forms.Label();
			this.labelUser = new System.Windows.Forms.Label();
			this.menuItemApiV2Author = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemApiV2Playlist = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemYouTube = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemComment = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.viewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.playlistsList = new YtAnalytics.Controls.YouTube.ControlPlaylistList();
			this.log = new YtAnalytics.Controls.Log.ControlLogList();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel.SuspendLayout();
			this.viewMenu.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.playlistsList);
			this.splitContainer.Panel1.Controls.Add(this.panel);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
			this.splitContainer.TabIndex = 2;
			// 
			// panel
			// 
			this.panel.Controls.Add(this.textBoxUser);
			this.panel.Controls.Add(this.checkBoxView);
			this.panel.Controls.Add(this.buttonStart);
			this.panel.Controls.Add(this.buttonStop);
			this.panel.Controls.Add(this.linkLabel);
			this.panel.Controls.Add(this.labelUrl);
			this.panel.Controls.Add(this.labelUser);
			this.panel.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(598, 82);
			this.panel.TabIndex = 0;
			// 
			// textBoxUser
			// 
			this.textBoxUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUser.Location = new System.Drawing.Point(53, 4);
			this.textBoxUser.Name = "textBoxUser";
			this.textBoxUser.Size = new System.Drawing.Size(350, 20);
			this.textBoxUser.TabIndex = 1;
			this.textBoxUser.TextChanged += new System.EventHandler(this.OnSearchChanged);
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
			this.checkBoxView.CheckedChanged += new System.EventHandler(this.OnViewPlaylist);
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStart.Enabled = false;
			this.buttonStart.Image = global::YtAnalytics.Resources.PlayStart_16;
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
			this.buttonStop.Image = global::YtAnalytics.Resources.PlayStop_16;
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
			// labelUser
			// 
			this.labelUser.AutoSize = true;
			this.labelUser.Location = new System.Drawing.Point(3, 7);
			this.labelUser.Name = "labelUser";
			this.labelUser.Size = new System.Drawing.Size(32, 13);
			this.labelUser.TabIndex = 0;
			this.labelUser.Text = "&User:";
			// 
			// menuItemApiV2Author
			// 
			this.menuItemApiV2Author.Image = global::YtAnalytics.Resources.FileUser_16;
			this.menuItemApiV2Author.Name = "menuItemApiV2Author";
			this.menuItemApiV2Author.Size = new System.Drawing.Size(167, 22);
			this.menuItemApiV2Author.Text = "Author";
			this.menuItemApiV2Author.Click += new System.EventHandler(this.OnViewAuthor);
			// 
			// menuItemApiV2Playlist
			// 
			this.menuItemApiV2Playlist.Image = global::YtAnalytics.Resources.FolderClosedVideo_16;
			this.menuItemApiV2Playlist.Name = "menuItemApiV2Playlist";
			this.menuItemApiV2Playlist.Size = new System.Drawing.Size(167, 22);
			this.menuItemApiV2Playlist.Text = "Playlist videos";
			this.menuItemApiV2Playlist.Click += new System.EventHandler(this.OnViewVideos);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
			// 
			// menuItemYouTube
			// 
			this.menuItemYouTube.Image = global::YtAnalytics.Resources.Globe_16;
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
			this.menuItemComment.Image = global::YtAnalytics.Resources.CommentAdd_16;
			this.menuItemComment.Name = "menuItemComment";
			this.menuItemComment.Size = new System.Drawing.Size(167, 22);
			this.menuItemComment.Text = "Add comment";
			this.menuItemComment.Click += new System.EventHandler(this.OnAddComment);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
			// 
			// menuItemProperties
			// 
			this.menuItemProperties.Image = global::YtAnalytics.Resources.Properties_16;
			this.menuItemProperties.Name = "menuItemProperties";
			this.menuItemProperties.Size = new System.Drawing.Size(167, 22);
			this.menuItemProperties.Text = "Properties";
			this.menuItemProperties.Click += new System.EventHandler(this.OnViewProperties);
			// 
			// viewMenu
			// 
			this.viewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemApiV2Author,
            this.menuItemApiV2Playlist,
            this.toolStripSeparator1,
            this.menuItemYouTube,
            this.toolStripSeparator2,
            this.menuItemComment,
            this.toolStripSeparator3,
            this.menuItemProperties});
			this.viewMenu.Name = "viewMenu";
			this.viewMenu.Size = new System.Drawing.Size(168, 132);
			this.viewMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.OnViewMenuClosed);
			// 
			// playlistsList
			// 
			this.playlistsList.CountPerPage = null;
			this.playlistsList.CountStart = null;
			this.playlistsList.CountTotal = null;
			this.playlistsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.playlistsList.Location = new System.Drawing.Point(0, 82);
			this.playlistsList.Name = "playlistsList";
			this.playlistsList.Next = false;
			this.playlistsList.PlaylistContextMenu = this.viewMenu;
			this.playlistsList.Previous = false;
			this.playlistsList.Size = new System.Drawing.Size(598, 141);
			this.playlistsList.TabIndex = 1;
			this.playlistsList.PreviousClick += new System.EventHandler(this.OnNavigatePrevious);
			this.playlistsList.NextClick += new System.EventHandler(this.OnNavigateNext);
			this.playlistsList.PlaylistSelectionChanged += new System.EventHandler(this.OnSelectionChanged);
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(598, 169);
			this.log.TabIndex = 0;
			// 
			// ControlYtApi2PlaylistsFeed
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlYtApi2PlaylistsFeed";
			this.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.viewMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private Log.ControlLogList log;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Label labelUser;
		private System.Windows.Forms.LinkLabel linkLabel;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.CheckBox checkBoxView;
		private System.Windows.Forms.TextBox textBoxUser;
		private ControlPlaylistList playlistsList;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Author;
		private System.Windows.Forms.ToolStripMenuItem menuItemApiV2Playlist;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItemYouTube;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuItemComment;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
		private System.Windows.Forms.ContextMenuStrip viewMenu;

	}
}
