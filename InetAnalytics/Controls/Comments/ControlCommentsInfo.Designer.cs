namespace InetAnalytics.Controls.Comments
{
	partial class ControlCommentsInfo
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
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.linkLabelYtVideos = new System.Windows.Forms.LinkLabel();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.linkLabelYtPlaylists = new System.Windows.Forms.LinkLabel();
			this.linkLabelYtUsers = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::InetAnalytics.Resources.Comments_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 41);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 0;
			this.pictureBoxIcon.TabStop = false;
			// 
			// linkLabelYtVideos
			// 
			this.linkLabelYtVideos.AutoSize = true;
			this.linkLabelYtVideos.Location = new System.Drawing.Point(3, 75);
			this.linkLabelYtVideos.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelYtVideos.Name = "linkLabelYtVideos";
			this.linkLabelYtVideos.Size = new System.Drawing.Size(85, 13);
			this.linkLabelYtVideos.TabIndex = 5;
			this.linkLabelYtVideos.TabStop = true;
			this.linkLabelYtVideos.Text = "YouTube videos";
			this.linkLabelYtVideos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnVideosClick);
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(3, 30);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(561, 39);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "You may use comments to annotate Internet data objects, such as videos, and use t" +
    "hem as reminders for later analyis.\r\n\r\nCurrently, you may add comment for the fo" +
    "llowing objects.";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(94, 20);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Comments";
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.Controls.Add(this.linkLabelYtPlaylists, 0, 4);
			this.tableLayoutPanel.Controls.Add(this.linkLabelYtUsers, 0, 3);
			this.tableLayoutPanel.Controls.Add(this.labelTitle, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.linkLabelYtVideos, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.labelDescription, 0, 1);
			this.tableLayoutPanel.Location = new System.Drawing.Point(75, 42);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 5;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(721, 554);
			this.tableLayoutPanel.TabIndex = 5;
			// 
			// linkLabelYtPlaylists
			// 
			this.linkLabelYtPlaylists.AutoSize = true;
			this.linkLabelYtPlaylists.Location = new System.Drawing.Point(3, 113);
			this.linkLabelYtPlaylists.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelYtPlaylists.Name = "linkLabelYtPlaylists";
			this.linkLabelYtPlaylists.Size = new System.Drawing.Size(90, 13);
			this.linkLabelYtPlaylists.TabIndex = 7;
			this.linkLabelYtPlaylists.TabStop = true;
			this.linkLabelYtPlaylists.Text = "YouTube playlists";
			this.linkLabelYtPlaylists.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnPlaylistsClick);
			// 
			// linkLabelYtUsers
			// 
			this.linkLabelYtUsers.AutoSize = true;
			this.linkLabelYtUsers.Location = new System.Drawing.Point(3, 94);
			this.linkLabelYtUsers.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelYtUsers.Name = "linkLabelYtUsers";
			this.linkLabelYtUsers.Size = new System.Drawing.Size(79, 13);
			this.linkLabelYtUsers.TabIndex = 6;
			this.linkLabelYtUsers.TabStop = true;
			this.linkLabelYtUsers.Text = "YouTube users";
			this.linkLabelYtUsers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnUsersClick);
			// 
			// ControlCommentsInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.pictureBoxIcon);
			this.Name = "ControlCommentsInfo";
			this.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.ShowBorder = true;
			this.ShowTitle = true;
			this.Size = new System.Drawing.Size(800, 600);
			this.Title = "Comments";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.LinkLabel linkLabelYtVideos;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.LinkLabel linkLabelYtPlaylists;
		private System.Windows.Forms.LinkLabel linkLabelYtUsers;
	}
}
