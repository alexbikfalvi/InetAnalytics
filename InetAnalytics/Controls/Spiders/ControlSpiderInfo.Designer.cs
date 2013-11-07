namespace InetAnalytics.Controls.Spiders
{
	partial class ControlSpiderInfo
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
			this.linkLabelYtStandardFeeds = new System.Windows.Forms.LinkLabel();
			this.labelStandardFeeds = new System.Windows.Forms.Label();
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
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.labelTitle, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.labelDescription, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.linkLabelYtStandardFeeds, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.labelStandardFeeds, 1, 2);
			this.tableLayoutPanel.Location = new System.Drawing.Point(75, 42);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 4;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
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
			this.labelTitle.Size = new System.Drawing.Size(70, 20);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Spiders";
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.labelDescription, 2);
			this.labelDescription.Location = new System.Drawing.Point(3, 30);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(419, 39);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "The spiders are automated tools that allow you to collect or crawl data from the " +
    "Internet.\r\n\r\nTo begin, select a spider below:";
			// 
			// linkLabelYtStandardFeeds
			// 
			this.linkLabelYtStandardFeeds.AutoSize = true;
			this.linkLabelYtStandardFeeds.Location = new System.Drawing.Point(3, 75);
			this.linkLabelYtStandardFeeds.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelYtStandardFeeds.Name = "linkLabelYtStandardFeeds";
			this.linkLabelYtStandardFeeds.Size = new System.Drawing.Size(124, 13);
			this.linkLabelYtStandardFeeds.TabIndex = 12;
			this.linkLabelYtStandardFeeds.TabStop = true;
			this.linkLabelYtStandardFeeds.Text = "YouTube standard feeds";
			this.linkLabelYtStandardFeeds.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnStandardFeedsClick);
			// 
			// labelStandardFeeds
			// 
			this.labelStandardFeeds.AutoSize = true;
			this.labelStandardFeeds.Location = new System.Drawing.Point(133, 75);
			this.labelStandardFeeds.Margin = new System.Windows.Forms.Padding(3);
			this.labelStandardFeeds.Name = "labelStandardFeeds";
			this.labelStandardFeeds.Size = new System.Drawing.Size(481, 13);
			this.labelStandardFeeds.TabIndex = 13;
			this.labelStandardFeeds.Text = "Queries all standard feeds in the YouTuve API version 2, and determines which fee" +
    "ds are browsable.\r\n";
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::InetAnalytics.Resources.Cubes_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 41);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 6;
			this.pictureBoxIcon.TabStop = false;
			// 
			// ControlSpiderInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.pictureBoxIcon);
			this.Name = "ControlSpiderInfo";
			this.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.ShowBorder = true;
			this.ShowTitle = true;
			this.Size = new System.Drawing.Size(800, 600);
			this.Title = "Spiders";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.LinkLabel linkLabelYtStandardFeeds;
		private System.Windows.Forms.Label labelStandardFeeds;
	}
}
