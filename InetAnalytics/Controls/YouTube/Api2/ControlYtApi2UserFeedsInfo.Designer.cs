namespace InetAnalytics.Controls.YouTube.Api2
{
	partial class ControlYtApi2UserFeedsInfo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlYtApi2UserFeedsInfo));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelDescription1 = new System.Windows.Forms.Label();
			this.linkLabelUserEntry = new System.Windows.Forms.LinkLabel();
			this.linkLabelPlaylistsFeed = new System.Windows.Forms.LinkLabel();
			this.linkLabelPlaylistFeed = new System.Windows.Forms.LinkLabel();
			this.labelDescription2 = new System.Windows.Forms.Label();
			this.linkLabelUploadsFeed = new System.Windows.Forms.LinkLabel();
			this.linkLabelFavoritesFeed = new System.Windows.Forms.LinkLabel();
			this.labelDescription3 = new System.Windows.Forms.Label();
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
			this.tableLayoutPanel.Controls.Add(this.labelDescription1, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.linkLabelUserEntry, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.linkLabelPlaylistsFeed, 0, 6);
			this.tableLayoutPanel.Controls.Add(this.linkLabelPlaylistFeed, 0, 7);
			this.tableLayoutPanel.Controls.Add(this.labelDescription2, 0, 3);
			this.tableLayoutPanel.Controls.Add(this.linkLabelUploadsFeed, 0, 4);
			this.tableLayoutPanel.Controls.Add(this.linkLabelFavoritesFeed, 0, 5);
			this.tableLayoutPanel.Controls.Add(this.labelDescription3, 0, 7);
			this.tableLayoutPanel.Location = new System.Drawing.Point(75, 42);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 10;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(721, 554);
			this.tableLayoutPanel.TabIndex = 7;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(153, 20);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "User Video Feeds";
			// 
			// labelDescription1
			// 
			this.labelDescription1.AutoSize = true;
			this.labelDescription1.Location = new System.Drawing.Point(3, 30);
			this.labelDescription1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription1.Name = "labelDescription1";
			this.labelDescription1.Size = new System.Drawing.Size(705, 52);
			this.labelDescription1.TabIndex = 4;
			this.labelDescription1.Text = resources.GetString("labelDescription1.Text");
			// 
			// linkLabelUserEntry
			// 
			this.linkLabelUserEntry.AutoSize = true;
			this.linkLabelUserEntry.Location = new System.Drawing.Point(3, 88);
			this.linkLabelUserEntry.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelUserEntry.Name = "linkLabelUserEntry";
			this.linkLabelUserEntry.Size = new System.Drawing.Size(55, 13);
			this.linkLabelUserEntry.TabIndex = 12;
			this.linkLabelUserEntry.TabStop = true;
			this.linkLabelUserEntry.Text = "User entry";
			this.linkLabelUserEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnUserClick);
			// 
			// linkLabelPlaylistsFeed
			// 
			this.linkLabelPlaylistsFeed.AutoSize = true;
			this.linkLabelPlaylistsFeed.Location = new System.Drawing.Point(3, 174);
			this.linkLabelPlaylistsFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelPlaylistsFeed.Name = "linkLabelPlaylistsFeed";
			this.linkLabelPlaylistsFeed.Size = new System.Drawing.Size(68, 13);
			this.linkLabelPlaylistsFeed.TabIndex = 7;
			this.linkLabelPlaylistsFeed.TabStop = true;
			this.linkLabelPlaylistsFeed.Text = "Playlists feed";
			this.linkLabelPlaylistsFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnPlaylistsFeedClick);
			// 
			// linkLabelPlaylistFeed
			// 
			this.linkLabelPlaylistFeed.AutoSize = true;
			this.linkLabelPlaylistFeed.Location = new System.Drawing.Point(3, 222);
			this.linkLabelPlaylistFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelPlaylistFeed.Name = "linkLabelPlaylistFeed";
			this.linkLabelPlaylistFeed.Size = new System.Drawing.Size(63, 13);
			this.linkLabelPlaylistFeed.TabIndex = 8;
			this.linkLabelPlaylistFeed.TabStop = true;
			this.linkLabelPlaylistFeed.Text = "Playlist feed";
			this.linkLabelPlaylistFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnPlaylistFeedClick);
			// 
			// labelDescription2
			// 
			this.labelDescription2.AutoSize = true;
			this.labelDescription2.Location = new System.Drawing.Point(3, 104);
			this.labelDescription2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription2.Name = "labelDescription2";
			this.labelDescription2.Size = new System.Drawing.Size(462, 26);
			this.labelDescription2.TabIndex = 11;
			this.labelDescription2.Text = "\r\nFor a given user, you can retrieve the following types of video feeds from the " +
    "YouTube Data API:";
			// 
			// linkLabelUploadsFeed
			// 
			this.linkLabelUploadsFeed.AutoSize = true;
			this.linkLabelUploadsFeed.Location = new System.Drawing.Point(3, 136);
			this.linkLabelUploadsFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelUploadsFeed.Name = "linkLabelUploadsFeed";
			this.linkLabelUploadsFeed.Size = new System.Drawing.Size(70, 13);
			this.linkLabelUploadsFeed.TabIndex = 6;
			this.linkLabelUploadsFeed.TabStop = true;
			this.linkLabelUploadsFeed.Text = "Uploads feed";
			this.linkLabelUploadsFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnUploadsFeedClick);
			// 
			// linkLabelFavoritesFeed
			// 
			this.linkLabelFavoritesFeed.AutoSize = true;
			this.linkLabelFavoritesFeed.Location = new System.Drawing.Point(3, 155);
			this.linkLabelFavoritesFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelFavoritesFeed.Name = "linkLabelFavoritesFeed";
			this.linkLabelFavoritesFeed.Size = new System.Drawing.Size(74, 13);
			this.linkLabelFavoritesFeed.TabIndex = 5;
			this.linkLabelFavoritesFeed.TabStop = true;
			this.linkLabelFavoritesFeed.Text = "Favorites feed";
			this.linkLabelFavoritesFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnFavoritesFeedClick);
			// 
			// labelDescription3
			// 
			this.labelDescription3.AutoSize = true;
			this.labelDescription3.Location = new System.Drawing.Point(3, 190);
			this.labelDescription3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription3.Name = "labelDescription3";
			this.labelDescription3.Size = new System.Drawing.Size(473, 26);
			this.labelDescription3.TabIndex = 13;
			this.labelDescription3.Text = "\r\nFor a given playlist, you can retrieve the following types of video feeds from " +
    "the YouTube Data API:";
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::InetAnalytics.Resources.FolderOpenUser_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 41);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 6;
			this.pictureBoxIcon.TabStop = false;
			// 
			// ControlYtApi2UserFeedsInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.pictureBoxIcon);
			this.Enabled = false;
			this.Name = "ControlYtApi2UserFeedsInfo";
			this.ShowBorder = true;
			this.ShowTitle = true;
			this.Size = new System.Drawing.Size(800, 600);
			this.Title = "YouTube User Video Feeds";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelDescription1;
		private System.Windows.Forms.LinkLabel linkLabelPlaylistsFeed;
		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.Label labelDescription2;
		private System.Windows.Forms.LinkLabel linkLabelUserEntry;
		private System.Windows.Forms.LinkLabel linkLabelFavoritesFeed;
		private System.Windows.Forms.LinkLabel linkLabelUploadsFeed;
		private System.Windows.Forms.LinkLabel linkLabelPlaylistFeed;
		private System.Windows.Forms.Label labelDescription3;
	}
}
