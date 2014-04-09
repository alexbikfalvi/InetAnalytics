namespace InetAnalytics.Controls.YouTube.Api2
{
	partial class ControlYtApi2CommentsFeed
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
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelFeed = new DotNetApi.Windows.Controls.ThemeControl();
			this.commentsList = new InetAnalytics.Controls.YouTube.ControlCommentList();
			this.panelQuery = new System.Windows.Forms.Panel();
			this.textBoxVideo = new System.Windows.Forms.TextBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.labelUrl = new System.Windows.Forms.Label();
			this.labelVideo = new System.Windows.Forms.Label();
			this.log = new InetControls.Controls.Log.ControlLogList();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelFeed.SuspendLayout();
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
			this.panelFeed.Controls.Add(this.commentsList);
			this.panelFeed.Controls.Add(this.panelQuery);
			this.panelFeed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelFeed.Location = new System.Drawing.Point(0, 0);
			this.panelFeed.Name = "panelFeed";
			this.panelFeed.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelFeed.ShowBorder = true;
			this.panelFeed.ShowTitle = true;
			this.panelFeed.Size = new System.Drawing.Size(600, 225);
			this.panelFeed.TabIndex = 2;
			this.panelFeed.Title = "YouTube Video Comments Feed";
			// 
			// commentsList
			// 
			this.commentsList.CountPerPage = null;
			this.commentsList.CountStart = null;
			this.commentsList.CountTotal = null;
			this.commentsList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.commentsList.Location = new System.Drawing.Point(1, 104);
			this.commentsList.Name = "commentsList";
			this.commentsList.Next = false;
			this.commentsList.Previous = false;
			this.commentsList.Size = new System.Drawing.Size(598, 120);
			this.commentsList.TabIndex = 1;
			this.commentsList.PreviousClick += new System.EventHandler(this.OnNavigatePrevious);
			this.commentsList.NextClick += new System.EventHandler(this.OnNavigateNext);
			this.commentsList.CommentsPerPageChanged += new System.EventHandler(this.OnSearchChanged);
			// 
			// panelQuery
			// 
			this.panelQuery.Controls.Add(this.textBoxVideo);
			this.panelQuery.Controls.Add(this.buttonStart);
			this.panelQuery.Controls.Add(this.buttonStop);
			this.panelQuery.Controls.Add(this.linkLabel);
			this.panelQuery.Controls.Add(this.labelUrl);
			this.panelQuery.Controls.Add(this.labelVideo);
			this.panelQuery.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelQuery.Location = new System.Drawing.Point(1, 22);
			this.panelQuery.Name = "panelQuery";
			this.panelQuery.Size = new System.Drawing.Size(598, 82);
			this.panelQuery.TabIndex = 0;
			// 
			// textBoxVideo
			// 
			this.textBoxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxVideo.Location = new System.Drawing.Point(53, 4);
			this.textBoxVideo.Name = "textBoxVideo";
			this.textBoxVideo.Size = new System.Drawing.Size(350, 20);
			this.textBoxVideo.TabIndex = 1;
			this.textBoxVideo.TextChanged += new System.EventHandler(this.OnSearchChanged);
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
			// labelVideo
			// 
			this.labelVideo.AutoSize = true;
			this.labelVideo.Location = new System.Drawing.Point(3, 7);
			this.labelVideo.Name = "labelVideo";
			this.labelVideo.Size = new System.Drawing.Size(37, 13);
			this.labelVideo.TabIndex = 0;
			this.labelVideo.Text = "&Video:";
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
			// ControlYtApi2CommentsFeed
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlYtApi2CommentsFeed";
			this.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelFeed.ResumeLayout(false);
			this.panelQuery.ResumeLayout(false);
			this.panelQuery.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private InetControls.Controls.Log.ControlLogList log;
		private System.Windows.Forms.Panel panelQuery;
		private System.Windows.Forms.Label labelVideo;
		private System.Windows.Forms.LinkLabel linkLabel;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.TextBox textBoxVideo;
		private ControlCommentList commentsList;
		private DotNetApi.Windows.Controls.ThemeControl panelFeed;

	}
}
