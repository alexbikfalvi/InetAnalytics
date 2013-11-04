namespace InetAnalytics.Controls.YouTube
{
	partial class ControlCommentProperties
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
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.textBoxPublished = new System.Windows.Forms.TextBox();
			this.labelPublished = new System.Windows.Forms.Label();
			this.textBoxUpdated = new System.Windows.Forms.TextBox();
			this.labelUpdated = new System.Windows.Forms.Label();
			this.textBoxAuthor = new System.Windows.Forms.TextBox();
			this.labelAuthor = new System.Windows.Forms.Label();
			this.checkBoxSpam = new System.Windows.Forms.CheckBox();
			this.textBoxComment = new System.Windows.Forms.TextBox();
			this.labelComment = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitle.AutoEllipsis = true;
			this.labelTitle.Location = new System.Drawing.Point(48, 10);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(249, 32);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No comment selected";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.Comment_32;
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			// 
			// textBoxPublished
			// 
			this.textBoxPublished.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPublished.Location = new System.Drawing.Point(84, 46);
			this.textBoxPublished.Name = "textBoxPublished";
			this.textBoxPublished.ReadOnly = true;
			this.textBoxPublished.Size = new System.Drawing.Size(213, 20);
			this.textBoxPublished.TabIndex = 2;
			// 
			// labelPublished
			// 
			this.labelPublished.AutoSize = true;
			this.labelPublished.Location = new System.Drawing.Point(10, 49);
			this.labelPublished.Name = "labelPublished";
			this.labelPublished.Size = new System.Drawing.Size(56, 13);
			this.labelPublished.TabIndex = 1;
			this.labelPublished.Text = "Published:";
			// 
			// textBoxUpdated
			// 
			this.textBoxUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUpdated.Location = new System.Drawing.Point(84, 72);
			this.textBoxUpdated.Name = "textBoxUpdated";
			this.textBoxUpdated.ReadOnly = true;
			this.textBoxUpdated.Size = new System.Drawing.Size(213, 20);
			this.textBoxUpdated.TabIndex = 4;
			// 
			// labelUpdated
			// 
			this.labelUpdated.AutoSize = true;
			this.labelUpdated.Location = new System.Drawing.Point(10, 75);
			this.labelUpdated.Name = "labelUpdated";
			this.labelUpdated.Size = new System.Drawing.Size(51, 13);
			this.labelUpdated.TabIndex = 3;
			this.labelUpdated.Text = "Updated:";
			// 
			// textBoxAuthor
			// 
			this.textBoxAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxAuthor.Location = new System.Drawing.Point(84, 98);
			this.textBoxAuthor.Name = "textBoxAuthor";
			this.textBoxAuthor.ReadOnly = true;
			this.textBoxAuthor.Size = new System.Drawing.Size(213, 20);
			this.textBoxAuthor.TabIndex = 6;
			// 
			// labelAuthor
			// 
			this.labelAuthor.AutoSize = true;
			this.labelAuthor.Location = new System.Drawing.Point(10, 101);
			this.labelAuthor.Name = "labelAuthor";
			this.labelAuthor.Size = new System.Drawing.Size(41, 13);
			this.labelAuthor.TabIndex = 5;
			this.labelAuthor.Text = "Author:";
			// 
			// checkBoxSpam
			// 
			this.checkBoxSpam.AutoSize = true;
			this.checkBoxSpam.Enabled = false;
			this.checkBoxSpam.Location = new System.Drawing.Point(84, 124);
			this.checkBoxSpam.Name = "checkBoxSpam";
			this.checkBoxSpam.Size = new System.Drawing.Size(104, 17);
			this.checkBoxSpam.TabIndex = 7;
			this.checkBoxSpam.Text = "Marked as spam";
			this.checkBoxSpam.UseVisualStyleBackColor = true;
			// 
			// textBoxComment
			// 
			this.textBoxComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxComment.Location = new System.Drawing.Point(84, 147);
			this.textBoxComment.Multiline = true;
			this.textBoxComment.Name = "textBoxComment";
			this.textBoxComment.ReadOnly = true;
			this.textBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxComment.Size = new System.Drawing.Size(213, 50);
			this.textBoxComment.TabIndex = 9;
			// 
			// labelComment
			// 
			this.labelComment.AutoSize = true;
			this.labelComment.Location = new System.Drawing.Point(10, 150);
			this.labelComment.Name = "labelComment";
			this.labelComment.Size = new System.Drawing.Size(54, 13);
			this.labelComment.TabIndex = 8;
			this.labelComment.Text = "Comment:";
			// 
			// ControlComment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.labelComment);
			this.Controls.Add(this.textBoxComment);
			this.Controls.Add(this.checkBoxSpam);
			this.Controls.Add(this.labelAuthor);
			this.Controls.Add(this.textBoxAuthor);
			this.Controls.Add(this.labelUpdated);
			this.Controls.Add(this.textBoxUpdated);
			this.Controls.Add(this.labelPublished);
			this.Controls.Add(this.textBoxPublished);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlComment";
			this.Size = new System.Drawing.Size(300, 200);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.TextBox textBoxPublished;
		private System.Windows.Forms.Label labelPublished;
		private System.Windows.Forms.TextBox textBoxUpdated;
		private System.Windows.Forms.Label labelUpdated;
		private System.Windows.Forms.TextBox textBoxAuthor;
		private System.Windows.Forms.Label labelAuthor;
		private System.Windows.Forms.CheckBox checkBoxSpam;
		private System.Windows.Forms.TextBox textBoxComment;
		private System.Windows.Forms.Label labelComment;
	}
}
