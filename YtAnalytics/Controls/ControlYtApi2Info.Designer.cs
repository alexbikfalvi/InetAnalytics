namespace YtAnalytics.Controls
{
	partial class ControlYtApi2Info
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
			this.linkLabelVideosGlobal = new System.Windows.Forms.LinkLabel();
			this.linkLabelVideosUser = new System.Windows.Forms.LinkLabel();
			this.linkLabelCategories = new System.Windows.Forms.LinkLabel();
			this.labelCategories = new System.Windows.Forms.Label();
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
			this.tableLayoutPanel.Controls.Add(this.linkLabelVideosGlobal, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.linkLabelVideosUser, 0, 3);
			this.tableLayoutPanel.Controls.Add(this.linkLabelCategories, 0, 5);
			this.tableLayoutPanel.Controls.Add(this.labelCategories, 0, 4);
			this.tableLayoutPanel.Location = new System.Drawing.Point(74, 20);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 7;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(723, 577);
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
			// linkLabelVideosGlobal
			// 
			this.linkLabelVideosGlobal.AutoSize = true;
			this.linkLabelVideosGlobal.Location = new System.Drawing.Point(3, 75);
			this.linkLabelVideosGlobal.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelVideosGlobal.Name = "linkLabelVideosGlobal";
			this.linkLabelVideosGlobal.Size = new System.Drawing.Size(170, 13);
			this.linkLabelVideosGlobal.TabIndex = 5;
			this.linkLabelVideosGlobal.TabStop = true;
			this.linkLabelVideosGlobal.Text = "Global video feeds and information";
			this.linkLabelVideosGlobal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnVideosGlobalClick);
			// 
			// linkLabelVideosUser
			// 
			this.linkLabelVideosUser.AutoSize = true;
			this.linkLabelVideosUser.Location = new System.Drawing.Point(3, 94);
			this.linkLabelVideosUser.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelVideosUser.Name = "linkLabelVideosUser";
			this.linkLabelVideosUser.Size = new System.Drawing.Size(179, 13);
			this.linkLabelVideosUser.TabIndex = 6;
			this.linkLabelVideosUser.TabStop = true;
			this.linkLabelVideosUser.Text = "Per user video feeds and information";
			this.linkLabelVideosUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnVideosUserClick);
			// 
			// linkLabelCategories
			// 
			this.linkLabelCategories.AutoSize = true;
			this.linkLabelCategories.Location = new System.Drawing.Point(3, 142);
			this.linkLabelCategories.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelCategories.Name = "linkLabelCategories";
			this.linkLabelCategories.Size = new System.Drawing.Size(57, 13);
			this.linkLabelCategories.TabIndex = 12;
			this.linkLabelCategories.TabStop = true;
			this.linkLabelCategories.Text = "Categories";
			this.linkLabelCategories.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnCategoriesClick);
			// 
			// labelCategories
			// 
			this.labelCategories.AutoSize = true;
			this.labelCategories.Location = new System.Drawing.Point(3, 110);
			this.labelCategories.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelCategories.Name = "labelCategories";
			this.labelCategories.Size = new System.Drawing.Size(559, 26);
			this.labelCategories.TabIndex = 11;
			this.labelCategories.Text = "\r\nYouTube classifies the videos according to a list of categories. These categori" +
    "es are available only in some countries.";
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
			this.Size = new System.Drawing.Size(800, 600);
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
		private System.Windows.Forms.LinkLabel linkLabelVideosGlobal;
		private System.Windows.Forms.LinkLabel linkLabelVideosUser;
		private System.Windows.Forms.Label labelCategories;
		private System.Windows.Forms.LinkLabel linkLabelCategories;
	}
}
