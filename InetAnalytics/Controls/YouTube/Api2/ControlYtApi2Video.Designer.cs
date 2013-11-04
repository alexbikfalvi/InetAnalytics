namespace InetAnalytics.Controls.YouTube.Api2
{
	partial class ControlYtApi2Video
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
			this.menuItemAuthor = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemRelated = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemResponse = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemWeb = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemYouTube = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonComment = new System.Windows.Forms.ToolStripButton();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.controlVideo = new InetAnalytics.Controls.YouTube.ControlVideoProperties();
			this.log = new InetAnalytics.Controls.Log.ControlLogList();
			this.menuItemComments = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
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
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// label
			// 
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(90, 22);
			this.label.Text = "Video identifier:";
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
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::InetAnalytics.Resources.PlayStop_16;
			this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(51, 22);
			this.buttonStop.Text = "St&op";
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonView
			// 
			this.buttonView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAuthor,
            this.menuItemComments,
            this.menuItemRelated,
            this.menuItemResponse,
            this.toolStripSeparator1,
            this.menuItemWeb,
            this.toolStripSeparator2,
            this.menuItemYouTube});
			this.buttonView.Enabled = false;
			this.buttonView.Image = global::InetAnalytics.Resources.View_16;
			this.buttonView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonView.Name = "buttonView";
			this.buttonView.Size = new System.Drawing.Size(61, 22);
			this.buttonView.Text = "&View";
			// 
			// menuItemAuthor
			// 
			this.menuItemAuthor.Image = global::InetAnalytics.Resources.FileUser_16;
			this.menuItemAuthor.Name = "menuItemAuthor";
			this.menuItemAuthor.Size = new System.Drawing.Size(167, 22);
			this.menuItemAuthor.Text = "Author";
			this.menuItemAuthor.Click += new System.EventHandler(this.OnViewAuthorClick);
			// 
			// menuItemRelated
			// 
			this.menuItemRelated.Image = global::InetAnalytics.Resources.FolderClosedVideo_16;
			this.menuItemRelated.Name = "menuItemRelated";
			this.menuItemRelated.Size = new System.Drawing.Size(167, 22);
			this.menuItemRelated.Text = "Related videos";
			this.menuItemRelated.Click += new System.EventHandler(this.OnViewRelatedVideosClick);
			// 
			// menuItemResponse
			// 
			this.menuItemResponse.Image = global::InetAnalytics.Resources.FolderClosedVideo_16;
			this.menuItemResponse.Name = "menuItemResponse";
			this.menuItemResponse.Size = new System.Drawing.Size(167, 22);
			this.menuItemResponse.Text = "Response videos";
			this.menuItemResponse.Click += new System.EventHandler(this.OnViewResponseVideosClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
			// 
			// menuItemWeb
			// 
			this.menuItemWeb.Image = global::InetAnalytics.Resources.ServerWeb_16;
			this.menuItemWeb.Name = "menuItemWeb";
			this.menuItemWeb.Size = new System.Drawing.Size(167, 22);
			this.menuItemWeb.Text = "Web statistics";
			this.menuItemWeb.Click += new System.EventHandler(this.OnWebStatisticsClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
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
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.controlVideo);
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.TabIndex = 1;
			// 
			// controlVideo
			// 
			this.controlVideo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlVideo.Location = new System.Drawing.Point(0, 25);
			this.controlVideo.Name = "controlVideo";
			this.controlVideo.Size = new System.Drawing.Size(798, 398);
			this.controlVideo.TabIndex = 0;
			this.controlVideo.Video = null;
			this.controlVideo.ViewProfile += new InetAnalytics.Events.StringEventHandler(this.OnViewProfile);
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(798, 169);
			this.log.TabIndex = 0;
			// 
			// menuItemComments
			// 
			this.menuItemComments.Image = global::InetAnalytics.Resources.FolderClosedComment_16;
			this.menuItemComments.Name = "menuItemComments";
			this.menuItemComments.Size = new System.Drawing.Size(167, 22);
			this.menuItemComments.Text = "Comments";
			this.menuItemComments.Click += new System.EventHandler(this.OnViewCommentsClick);
			// 
			// ControlInetApi.YouTube2Video
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlInetApi.YouTube2Video";
			this.Size = new System.Drawing.Size(800, 600);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripLabel label;
		private System.Windows.Forms.ToolStripTextBox textBox;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private System.Windows.Forms.SplitContainer splitContainer;
		private Log.ControlLogList log;
		private ControlVideoProperties controlVideo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripDropDownButton buttonView;
		private System.Windows.Forms.ToolStripMenuItem menuItemRelated;
		private System.Windows.Forms.ToolStripMenuItem menuItemResponse;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem menuItemWeb;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem menuItemYouTube;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton buttonComment;
		private System.Windows.Forms.ToolStripMenuItem menuItemAuthor;
		private System.Windows.Forms.ToolStripMenuItem menuItemComments;
	}
}
