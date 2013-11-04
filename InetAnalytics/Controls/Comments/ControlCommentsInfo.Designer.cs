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
			this.linkLabelVideos = new System.Windows.Forms.LinkLabel();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.linkLabelUsers = new System.Windows.Forms.LinkLabel();
			this.linkLabelPlaylists = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::InetAnalytics.Resources.Comments_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 20);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 0;
			this.pictureBoxIcon.TabStop = false;
			// 
			// linkLabelVideos
			// 
			this.linkLabelVideos.AutoSize = true;
			this.linkLabelVideos.Location = new System.Drawing.Point(3, 75);
			this.linkLabelVideos.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelVideos.Name = "linkLabelVideos";
			this.linkLabelVideos.Size = new System.Drawing.Size(39, 13);
			this.linkLabelVideos.TabIndex = 5;
			this.linkLabelVideos.TabStop = true;
			this.linkLabelVideos.Text = "Videos";
			this.linkLabelVideos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnVideosClick);
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(3, 30);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(589, 39);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "You may use comments to annotate YouTube analytics objects, such as videos, and u" +
    "se them as reminders for later analyis.\r\n\r\nCurrently, you may add comment for th" +
    "e following objects.";
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
			this.tableLayoutPanel.Controls.Add(this.linkLabelPlaylists, 0, 4);
			this.tableLayoutPanel.Controls.Add(this.linkLabelUsers, 0, 3);
			this.tableLayoutPanel.Controls.Add(this.labelTitle, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.linkLabelVideos, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.labelDescription, 0, 1);
			this.tableLayoutPanel.Location = new System.Drawing.Point(74, 20);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 5;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(885, 387);
			this.tableLayoutPanel.TabIndex = 5;
			// 
			// linkLabelUsers
			// 
			this.linkLabelUsers.AutoSize = true;
			this.linkLabelUsers.Location = new System.Drawing.Point(3, 94);
			this.linkLabelUsers.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelUsers.Name = "linkLabelUsers";
			this.linkLabelUsers.Size = new System.Drawing.Size(34, 13);
			this.linkLabelUsers.TabIndex = 6;
			this.linkLabelUsers.TabStop = true;
			this.linkLabelUsers.Text = "Users";
			this.linkLabelUsers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnUsersClick);
			// 
			// linkLabelPlaylists
			// 
			this.linkLabelPlaylists.AutoSize = true;
			this.linkLabelPlaylists.Location = new System.Drawing.Point(3, 113);
			this.linkLabelPlaylists.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelPlaylists.Name = "linkLabelPlaylists";
			this.linkLabelPlaylists.Size = new System.Drawing.Size(44, 13);
			this.linkLabelPlaylists.TabIndex = 7;
			this.linkLabelPlaylists.TabStop = true;
			this.linkLabelPlaylists.Text = "Playlists";
			this.linkLabelPlaylists.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnPlaylistsClick);
			// 
			// ControlCommentsInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.pictureBoxIcon);
			this.Name = "ControlCommentsInfo";
			this.Size = new System.Drawing.Size(962, 410);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.LinkLabel linkLabelVideos;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.LinkLabel linkLabelPlaylists;
		private System.Windows.Forms.LinkLabel linkLabelUsers;
	}
}
