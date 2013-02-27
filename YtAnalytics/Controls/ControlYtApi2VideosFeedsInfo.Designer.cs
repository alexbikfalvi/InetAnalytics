namespace YtAnalytics.Controls
{
	partial class ControlYtApi2VideosFeedsInfo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlYtApi2VideosFeedsInfo));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelDescription1 = new System.Windows.Forms.Label();
			this.linkLabelVideoEntry = new System.Windows.Forms.LinkLabel();
			this.linkLabelStandardFeed = new System.Windows.Forms.LinkLabel();
			this.linkLabelVideoComments = new System.Windows.Forms.LinkLabel();
			this.linkLabelRelatedVideosFeed = new System.Windows.Forms.LinkLabel();
			this.labelDescription2 = new System.Windows.Forms.Label();
			this.linkLabelResponseVideosFeed = new System.Windows.Forms.LinkLabel();
			this.linkLabelSearchFeed = new System.Windows.Forms.LinkLabel();
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
			this.tableLayoutPanel.Controls.Add(this.linkLabelVideoEntry, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.linkLabelStandardFeed, 0, 6);
			this.tableLayoutPanel.Controls.Add(this.linkLabelVideoComments, 0, 3);
			this.tableLayoutPanel.Controls.Add(this.linkLabelRelatedVideosFeed, 0, 6);
			this.tableLayoutPanel.Controls.Add(this.labelDescription2, 0, 4);
			this.tableLayoutPanel.Controls.Add(this.linkLabelResponseVideosFeed, 0, 7);
			this.tableLayoutPanel.Controls.Add(this.linkLabelSearchFeed, 0, 5);
			this.tableLayoutPanel.Location = new System.Drawing.Point(74, 20);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 8;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(723, 577);
			this.tableLayoutPanel.TabIndex = 7;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(110, 20);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Video Feeds";
			// 
			// labelDescription1
			// 
			this.labelDescription1.AutoSize = true;
			this.labelDescription1.Location = new System.Drawing.Point(3, 30);
			this.labelDescription1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription1.Name = "labelDescription1";
			this.labelDescription1.Size = new System.Drawing.Size(687, 39);
			this.labelDescription1.TabIndex = 4;
			this.labelDescription1.Text = resources.GetString("labelDescription1.Text");
			// 
			// linkLabelVideoEntry
			// 
			this.linkLabelVideoEntry.AutoSize = true;
			this.linkLabelVideoEntry.Location = new System.Drawing.Point(3, 75);
			this.linkLabelVideoEntry.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelVideoEntry.Name = "linkLabelVideoEntry";
			this.linkLabelVideoEntry.Size = new System.Drawing.Size(60, 13);
			this.linkLabelVideoEntry.TabIndex = 12;
			this.linkLabelVideoEntry.TabStop = true;
			this.linkLabelVideoEntry.Text = "Video entry";
			this.linkLabelVideoEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnVideoClick);
			// 
			// linkLabelStandardFeed
			// 
			this.linkLabelStandardFeed.AutoSize = true;
			this.linkLabelStandardFeed.Location = new System.Drawing.Point(3, 161);
			this.linkLabelStandardFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelStandardFeed.Name = "linkLabelStandardFeed";
			this.linkLabelStandardFeed.Size = new System.Drawing.Size(74, 13);
			this.linkLabelStandardFeed.TabIndex = 5;
			this.linkLabelStandardFeed.TabStop = true;
			this.linkLabelStandardFeed.Text = "Standard feed";
			this.linkLabelStandardFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnStandardFeedClick);
			// 
			// linkLabelVideoComments
			// 
			this.linkLabelVideoComments.AutoSize = true;
			this.linkLabelVideoComments.Location = new System.Drawing.Point(3, 94);
			this.linkLabelVideoComments.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelVideoComments.Name = "linkLabelVideoComments";
			this.linkLabelVideoComments.Size = new System.Drawing.Size(85, 13);
			this.linkLabelVideoComments.TabIndex = 9;
			this.linkLabelVideoComments.TabStop = true;
			this.linkLabelVideoComments.Text = "Video comments";
			this.linkLabelVideoComments.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnVideoCommentsClick);
			// 
			// linkLabelRelatedVideosFeed
			// 
			this.linkLabelRelatedVideosFeed.AutoSize = true;
			this.linkLabelRelatedVideosFeed.Location = new System.Drawing.Point(3, 180);
			this.linkLabelRelatedVideosFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelRelatedVideosFeed.Name = "linkLabelRelatedVideosFeed";
			this.linkLabelRelatedVideosFeed.Size = new System.Drawing.Size(102, 13);
			this.linkLabelRelatedVideosFeed.TabIndex = 7;
			this.linkLabelRelatedVideosFeed.TabStop = true;
			this.linkLabelRelatedVideosFeed.Text = "Related videos feed";
			this.linkLabelRelatedVideosFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnRelatedVideosFeedClick);
			// 
			// labelDescription2
			// 
			this.labelDescription2.AutoSize = true;
			this.labelDescription2.Location = new System.Drawing.Point(3, 110);
			this.labelDescription2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription2.Name = "labelDescription2";
			this.labelDescription2.Size = new System.Drawing.Size(382, 26);
			this.labelDescription2.TabIndex = 11;
			this.labelDescription2.Text = "\r\nYou can retrieve the following types of video feeds from the YouTube Data API:";
			// 
			// linkLabelResponseVideosFeed
			// 
			this.linkLabelResponseVideosFeed.AutoSize = true;
			this.linkLabelResponseVideosFeed.Location = new System.Drawing.Point(3, 199);
			this.linkLabelResponseVideosFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelResponseVideosFeed.Name = "linkLabelResponseVideosFeed";
			this.linkLabelResponseVideosFeed.Size = new System.Drawing.Size(113, 13);
			this.linkLabelResponseVideosFeed.TabIndex = 8;
			this.linkLabelResponseVideosFeed.TabStop = true;
			this.linkLabelResponseVideosFeed.Text = "Response videos feed";
			this.linkLabelResponseVideosFeed.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnResponseVideosFeedClick);
			// 
			// linkLabelSearchFeed
			// 
			this.linkLabelSearchFeed.AutoSize = true;
			this.linkLabelSearchFeed.Location = new System.Drawing.Point(3, 142);
			this.linkLabelSearchFeed.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelSearchFeed.Name = "linkLabelSearchFeed";
			this.linkLabelSearchFeed.Size = new System.Drawing.Size(65, 13);
			this.linkLabelSearchFeed.TabIndex = 6;
			this.linkLabelSearchFeed.TabStop = true;
			this.linkLabelSearchFeed.Text = "Search feed";
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::YtAnalytics.Resources.FolderOpenXml_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 20);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 6;
			this.pictureBoxIcon.TabStop = false;
			// 
			// ControlYtApi2VideosGlobal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.pictureBoxIcon);
			this.Name = "ControlYtApi2VideosGlobal";
			this.Size = new System.Drawing.Size(800, 600);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelDescription1;
		private System.Windows.Forms.LinkLabel linkLabelRelatedVideosFeed;
		private System.Windows.Forms.LinkLabel linkLabelVideoComments;
		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.Label labelDescription2;
		private System.Windows.Forms.LinkLabel linkLabelVideoEntry;
		private System.Windows.Forms.LinkLabel linkLabelStandardFeed;
		private System.Windows.Forms.LinkLabel linkLabelSearchFeed;
		private System.Windows.Forms.LinkLabel linkLabelResponseVideosFeed;
	}
}
