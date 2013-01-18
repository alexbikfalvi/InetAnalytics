namespace YtAnalytics.Controls
{
	partial class ControlYtApi2
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
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.linkLabelVideoFeeds = new System.Windows.Forms.LinkLabel();
			this.linkLabelUserPlaylistsFeed = new System.Windows.Forms.LinkLabel();
			this.linkLabelUserSubscriptionsFeed = new System.Windows.Forms.LinkLabel();
			this.linkLabelVideoCommentsFeed = new System.Windows.Forms.LinkLabel();
			this.linkLabelUserProfileEntry = new System.Windows.Forms.LinkLabel();
			this.linkLabelUserContactsFeed = new System.Windows.Forms.LinkLabel();
			this.labelCategories = new System.Windows.Forms.Label();
			this.linkLabelCategories = new System.Windows.Forms.LinkLabel();
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.labelTitle, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.labelDescription, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.linkLabelVideoFeeds, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.linkLabelUserPlaylistsFeed, 0, 3);
			this.tableLayoutPanel.Controls.Add(this.linkLabelUserSubscriptionsFeed, 0, 4);
			this.tableLayoutPanel.Controls.Add(this.linkLabelVideoCommentsFeed, 0, 5);
			this.tableLayoutPanel.Controls.Add(this.linkLabelUserProfileEntry, 0, 6);
			this.tableLayoutPanel.Controls.Add(this.linkLabelUserContactsFeed, 0, 7);
			this.tableLayoutPanel.Controls.Add(this.labelCategories, 0, 8);
			this.tableLayoutPanel.Controls.Add(this.linkLabelCategories, 0, 9);
			this.tableLayoutPanel.Location = new System.Drawing.Point(74, 20);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 11;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(885, 387);
			this.tableLayoutPanel.TabIndex = 5;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(196, 20);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "YouTube API Version 2";
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(3, 30);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(581, 39);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "This is the old and current version of the YouTube API.\r\n\r\nYouTube information is" +
    " organized in XML feeds. You can retrieve the following types of feeds from the " +
    "YouTube Data API:\r\n";
			// 
			// linkLabelVideoFeeds
			// 
			this.linkLabelVideoFeeds.AutoSize = true;
			this.linkLabelVideoFeeds.Location = new System.Drawing.Point(3, 75);
			this.linkLabelVideoFeeds.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelVideoFeeds.Name = "linkLabelVideoFeeds";
			this.linkLabelVideoFeeds.Size = new System.Drawing.Size(63, 13);
			this.linkLabelVideoFeeds.TabIndex = 5;
			this.linkLabelVideoFeeds.TabStop = true;
			this.linkLabelVideoFeeds.Text = "Video feeds";
			this.linkLabelVideoFeeds.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnVideoFeedsClick);
			// 
			// linkLabelUserPlaylistsFeed
			// 
			this.linkLabelUserPlaylistsFeed.AutoSize = true;
			this.linkLabelUserPlaylistsFeed.Location = new System.Drawing.Point(3, 94);
			this.linkLabelUserPlaylistsFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelUserPlaylistsFeed.Name = "linkLabelUserPlaylistsFeed";
			this.linkLabelUserPlaylistsFeed.Size = new System.Drawing.Size(99, 13);
			this.linkLabelUserPlaylistsFeed.TabIndex = 6;
			this.linkLabelUserPlaylistsFeed.TabStop = true;
			this.linkLabelUserPlaylistsFeed.Text = "User\'s playlists feed";
			this.linkLabelUserPlaylistsFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnUserPlaylistsFeedClick);
			// 
			// linkLabelUserSubscriptionsFeed
			// 
			this.linkLabelUserSubscriptionsFeed.AutoSize = true;
			this.linkLabelUserSubscriptionsFeed.Location = new System.Drawing.Point(3, 113);
			this.linkLabelUserSubscriptionsFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelUserSubscriptionsFeed.Name = "linkLabelUserSubscriptionsFeed";
			this.linkLabelUserSubscriptionsFeed.Size = new System.Drawing.Size(124, 13);
			this.linkLabelUserSubscriptionsFeed.TabIndex = 7;
			this.linkLabelUserSubscriptionsFeed.TabStop = true;
			this.linkLabelUserSubscriptionsFeed.Text = "User\'s subscriptions feed";
			this.linkLabelUserSubscriptionsFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnUserSubscriptionsFeedClick);
			// 
			// linkLabelVideoCommentsFeed
			// 
			this.linkLabelVideoCommentsFeed.AutoSize = true;
			this.linkLabelVideoCommentsFeed.Location = new System.Drawing.Point(3, 132);
			this.linkLabelVideoCommentsFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelVideoCommentsFeed.Name = "linkLabelVideoCommentsFeed";
			this.linkLabelVideoCommentsFeed.Size = new System.Drawing.Size(109, 13);
			this.linkLabelVideoCommentsFeed.TabIndex = 8;
			this.linkLabelVideoCommentsFeed.TabStop = true;
			this.linkLabelVideoCommentsFeed.Text = "Video comments feed";
			this.linkLabelVideoCommentsFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnVideoCommentsFeedClick);
			// 
			// linkLabelUserProfileEntry
			// 
			this.linkLabelUserProfileEntry.AutoSize = true;
			this.linkLabelUserProfileEntry.Location = new System.Drawing.Point(3, 151);
			this.linkLabelUserProfileEntry.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelUserProfileEntry.Name = "linkLabelUserProfileEntry";
			this.linkLabelUserProfileEntry.Size = new System.Drawing.Size(86, 13);
			this.linkLabelUserProfileEntry.TabIndex = 9;
			this.linkLabelUserProfileEntry.TabStop = true;
			this.linkLabelUserProfileEntry.Text = "User profile entry";
			this.linkLabelUserProfileEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnUserProfileEntryClick);
			// 
			// linkLabelUserContactsFeed
			// 
			this.linkLabelUserContactsFeed.AutoSize = true;
			this.linkLabelUserContactsFeed.Location = new System.Drawing.Point(3, 170);
			this.linkLabelUserContactsFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelUserContactsFeed.Name = "linkLabelUserContactsFeed";
			this.linkLabelUserContactsFeed.Size = new System.Drawing.Size(104, 13);
			this.linkLabelUserContactsFeed.TabIndex = 10;
			this.linkLabelUserContactsFeed.TabStop = true;
			this.linkLabelUserContactsFeed.Text = "User\'s contacts feed";
			this.linkLabelUserContactsFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnUserContactsFeedClick);
			// 
			// labelCategories
			// 
			this.labelCategories.AutoSize = true;
			this.labelCategories.Location = new System.Drawing.Point(3, 186);
			this.labelCategories.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelCategories.Name = "labelCategories";
			this.labelCategories.Size = new System.Drawing.Size(559, 26);
			this.labelCategories.TabIndex = 11;
			this.labelCategories.Text = "\r\nYouTube classifies the videos according to a list of categories. These categori" +
    "es are available only in some countries.";
			// 
			// linkLabelCategories
			// 
			this.linkLabelCategories.AutoSize = true;
			this.linkLabelCategories.Location = new System.Drawing.Point(3, 218);
			this.linkLabelCategories.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelCategories.Name = "linkLabelCategories";
			this.linkLabelCategories.Size = new System.Drawing.Size(57, 13);
			this.linkLabelCategories.TabIndex = 12;
			this.linkLabelCategories.TabStop = true;
			this.linkLabelCategories.Text = "Categories";
			this.linkLabelCategories.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnCategoriesClick);
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::YtAnalytics.Resources.ServerBrowse_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 20);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 0;
			this.pictureBoxIcon.TabStop = false;
			// 
			// ControlYtApi2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.pictureBoxIcon);
			this.Name = "ControlYtApi2";
			this.Size = new System.Drawing.Size(962, 410);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.LinkLabel linkLabelVideoFeeds;
		private System.Windows.Forms.LinkLabel linkLabelUserPlaylistsFeed;
		private System.Windows.Forms.LinkLabel linkLabelUserSubscriptionsFeed;
		private System.Windows.Forms.LinkLabel linkLabelVideoCommentsFeed;
		private System.Windows.Forms.LinkLabel linkLabelUserProfileEntry;
		private System.Windows.Forms.LinkLabel linkLabelUserContactsFeed;
		private System.Windows.Forms.Label labelCategories;
		private System.Windows.Forms.LinkLabel linkLabelCategories;
	}
}
