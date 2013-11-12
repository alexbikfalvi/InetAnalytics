namespace InetAnalytics.Controls.YouTube.Api2
{
	partial class ControlYtApi2Profile
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
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.label = new System.Windows.Forms.ToolStripLabel();
			this.textBox = new System.Windows.Forms.ToolStripTextBox();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.buttonView = new System.Windows.Forms.ToolStripDropDownButton();
			this.menuItemUploads = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemFavorites = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemPlaylists = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemYouTube = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonComment = new System.Windows.Forms.ToolStripButton();
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelProfile = new DotNetApi.Windows.Controls.ThemeControl();
			this.controlProfile = new InetAnalytics.Controls.YouTube.ControlProfileProperties();
			this.log = new InetAnalytics.Controls.Log.ControlLogList();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelProfile.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label,
            this.textBox,
            this.buttonStart,
            this.buttonStop,
            this.toolStripSeparator,
            this.buttonView,
            this.toolStripSeparator3,
            this.buttonComment});
			this.toolStrip.Location = new System.Drawing.Point(1, 22);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// label
			// 
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(83, 22);
			this.label.Text = "User identifier:";
			// 
			// textBox
			// 
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(160, 25);
			this.textBox.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// buttonStart
			// 
			this.buttonStart.Enabled = false;
			this.buttonStart.Image = global::InetAnalytics.Resources.PlayStart_16;
			this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(51, 22);
			this.buttonStart.Text = "St&art";
			this.buttonStart.Click += new System.EventHandler(this.Start);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::InetAnalytics.Resources.PlayStop_16;
			this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(51, 22);
			this.buttonStop.Text = "St&op";
			this.buttonStop.Click += new System.EventHandler(this.Stop);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonView
			// 
			this.buttonView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUploads,
            this.menuItemFavorites,
            this.menuItemPlaylists,
            this.toolStripSeparator1,
            this.menuItemYouTube});
			this.buttonView.Enabled = false;
			this.buttonView.Image = global::InetAnalytics.Resources.View_16;
			this.buttonView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonView.Name = "buttonView";
			this.buttonView.Size = new System.Drawing.Size(61, 22);
			this.buttonView.Text = "&View";
			// 
			// menuItemUploads
			// 
			this.menuItemUploads.Image = global::InetAnalytics.Resources.FolderClosedVideo_16;
			this.menuItemUploads.Name = "menuItemUploads";
			this.menuItemUploads.Size = new System.Drawing.Size(167, 22);
			this.menuItemUploads.Text = "Uploaded videos";
			this.menuItemUploads.Click += new System.EventHandler(this.OnViewApiV2Uploads);
			// 
			// menuItemFavorites
			// 
			this.menuItemFavorites.Image = global::InetAnalytics.Resources.FolderClosedVideo_16;
			this.menuItemFavorites.Name = "menuItemFavorites";
			this.menuItemFavorites.Size = new System.Drawing.Size(167, 22);
			this.menuItemFavorites.Text = "Favorited videos";
			this.menuItemFavorites.Click += new System.EventHandler(this.OnViewApiV2Favorites);
			// 
			// menuItemPlaylists
			// 
			this.menuItemPlaylists.Image = global::InetAnalytics.Resources.FolderClosedPlayBlue_16;
			this.menuItemPlaylists.Name = "menuItemPlaylists";
			this.menuItemPlaylists.Size = new System.Drawing.Size(167, 22);
			this.menuItemPlaylists.Text = "Playlists";
			this.menuItemPlaylists.Click += new System.EventHandler(this.OnViewApiV2Playlists);
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
			this.menuItemYouTube.Click += new System.EventHandler(this.OnOpenYouTubeClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonComment
			// 
			this.buttonComment.Enabled = false;
			this.buttonComment.Image = global::InetAnalytics.Resources.CommentAdd_16;
			this.buttonComment.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonComment.Name = "buttonComment";
			this.buttonComment.Size = new System.Drawing.Size(104, 22);
			this.buttonComment.Text = "Add &comment";
			this.buttonComment.Click += new System.EventHandler(this.OnCommentClick);
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
			this.splitContainer.Panel1.Controls.Add(this.panelProfile);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 1;
			// 
			// panelProfile
			// 
			this.panelProfile.Controls.Add(this.controlProfile);
			this.panelProfile.Controls.Add(this.toolStrip);
			this.panelProfile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelProfile.Location = new System.Drawing.Point(0, 0);
			this.panelProfile.Name = "panelProfile";
			this.panelProfile.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelProfile.ShowBorder = true;
			this.panelProfile.ShowTitle = true;
			this.panelProfile.Size = new System.Drawing.Size(800, 425);
			this.panelProfile.TabIndex = 2;
			this.panelProfile.Title = "YouTube User Profile";
			// 
			// controlProfile
			// 
			this.controlProfile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlProfile.Location = new System.Drawing.Point(1, 47);
			this.controlProfile.Name = "controlProfile";
			this.controlProfile.Profile = null;
			this.controlProfile.Size = new System.Drawing.Size(798, 377);
			this.controlProfile.TabIndex = 1;
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.log.ShowBorder = true;
			this.log.ShowTitle = true;
			this.log.Size = new System.Drawing.Size(800, 170);
			this.log.TabIndex = 0;
			this.log.Title = "Log";
			// 
			// ControlYtApi2Profile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlYtApi2Profile";
			this.Size = new System.Drawing.Size(800, 600);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelProfile.ResumeLayout(false);
			this.panelProfile.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripLabel label;
		private System.Windows.Forms.ToolStripTextBox textBox;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private Log.ControlLogList log;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripDropDownButton buttonView;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItemYouTube;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton buttonComment;
		private ControlProfileProperties controlProfile;
		private System.Windows.Forms.ToolStripMenuItem menuItemUploads;
		private System.Windows.Forms.ToolStripMenuItem menuItemFavorites;
		private System.Windows.Forms.ToolStripMenuItem menuItemPlaylists;
		private DotNetApi.Windows.Controls.ThemeControl panelProfile;
	}
}
