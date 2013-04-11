namespace YtAnalytics.Controls.Spiders
{
	partial class ControlSpiderStandardFeeds
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSpiderStandardFeeds));
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.progressListBox1 = new DotNetApi.Windows.Controls.ProgressListBox();
			this.itemTopRated = new DotNetApi.Windows.Controls.ProgressListBoxItem();
			this.itemTopFavorites = new DotNetApi.Windows.Controls.ProgressListBoxItem();
			this.panel = new System.Windows.Forms.Panel();
			this.labelProgress = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.log = new YtAnalytics.Controls.Log.ControlLogList();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.progressListBox1);
			this.splitContainer.Panel1.Controls.Add(this.panel);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
			this.splitContainer.TabIndex = 2;
			// 
			// progressListBox1
			// 
			this.progressListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.progressListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.progressListBox1.FormattingEnabled = true;
			this.progressListBox1.IntegralHeight = false;
			this.progressListBox1.ItemHeight = 48;
			this.progressListBox1.Items.AddRange(new DotNetApi.Windows.Controls.ProgressListBoxItem[] {
            this.itemTopRated,
            this.itemTopFavorites});
			this.progressListBox1.Location = new System.Drawing.Point(0, 82);
			this.progressListBox1.Name = "progressListBox1";
			this.progressListBox1.Size = new System.Drawing.Size(598, 141);
			this.progressListBox1.TabIndex = 1;
			// 
			// itemTopRated
			// 
			this.itemTopRated.Text = "Top rated";
			// 
			// itemTopFavorites
			// 
			this.itemTopFavorites.Text = "Top favorites";
			// 
			// panel
			// 
			this.panel.Controls.Add(this.labelProgress);
			this.panel.Controls.Add(this.progressBar);
			this.panel.Controls.Add(this.buttonStart);
			this.panel.Controls.Add(this.buttonStop);
			this.panel.Controls.Add(this.linkLabel);
			this.panel.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(598, 82);
			this.panel.TabIndex = 0;
			// 
			// labelProgress
			// 
			this.labelProgress.AutoSize = true;
			this.labelProgress.Location = new System.Drawing.Point(2, 47);
			this.labelProgress.Name = "labelProgress";
			this.labelProgress.Size = new System.Drawing.Size(50, 13);
			this.labelProgress.TabIndex = 8;
			this.labelProgress.Text = "Stopped.";
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(3, 63);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(592, 16);
			this.progressBar.TabIndex = 7;
			// 
			// buttonStart
			// 
			this.buttonStart.Image = global::YtAnalytics.Resources.PlayStart_16;
			this.buttonStart.Location = new System.Drawing.Point(3, 3);
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
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::YtAnalytics.Resources.PlayStop_16;
			this.buttonStop.Location = new System.Drawing.Point(84, 3);
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
			this.imageList.Images.SetKeyName(0, "Feed");
			this.imageList.Images.SetKeyName(1, "FeedQuestion");
			this.imageList.Images.SetKeyName(2, "FeedSuccess");
			this.imageList.Images.SetKeyName(3, "FeedWarning");
			this.imageList.Images.SetKeyName(4, "FeedError");
			// 
			// ControlSpiderStandardFeeds
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlSpiderStandardFeeds";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private Log.ControlLogList log;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.LinkLabel linkLabel;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Label labelProgress;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.ImageList imageList;
		private DotNetApi.Windows.Controls.ProgressListBox progressListBox1;
		private DotNetApi.Windows.Controls.ProgressListBoxItem itemTopRated;
		private DotNetApi.Windows.Controls.ProgressListBoxItem itemTopFavorites;
	}
}
