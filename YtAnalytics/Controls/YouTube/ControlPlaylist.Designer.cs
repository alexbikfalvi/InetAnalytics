namespace YtAnalytics.Controls.YouTube
{
	partial class ControlPlaylist
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
			this.textBoxPublished = new System.Windows.Forms.TextBox();
			this.labelPublished = new System.Windows.Forms.Label();
			this.textBoxUpdated = new System.Windows.Forms.TextBox();
			this.labelUpdated = new System.Windows.Forms.Label();
			this.textBoxAuthor = new System.Windows.Forms.TextBox();
			this.labelAuthor = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.labelId = new System.Windows.Forms.Label();
			this.textBoxSummary = new System.Windows.Forms.TextBox();
			this.labelSummary = new System.Windows.Forms.Label();
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.labelCount = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitle.AutoEllipsis = true;
			this.labelTitle.Location = new System.Drawing.Point(64, 10);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(333, 48);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No playlist selected";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelTitle.UseMnemonic = false;
			// 
			// textBoxPublished
			// 
			this.textBoxPublished.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPublished.Location = new System.Drawing.Point(80, 36);
			this.textBoxPublished.Name = "textBoxPublished";
			this.textBoxPublished.ReadOnly = true;
			this.textBoxPublished.Size = new System.Drawing.Size(300, 20);
			this.textBoxPublished.TabIndex = 4;
			// 
			// labelPublished
			// 
			this.labelPublished.AutoSize = true;
			this.labelPublished.Location = new System.Drawing.Point(6, 39);
			this.labelPublished.Name = "labelPublished";
			this.labelPublished.Size = new System.Drawing.Size(56, 13);
			this.labelPublished.TabIndex = 3;
			this.labelPublished.Text = "Published:";
			// 
			// textBoxUpdated
			// 
			this.textBoxUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUpdated.Location = new System.Drawing.Point(80, 62);
			this.textBoxUpdated.Name = "textBoxUpdated";
			this.textBoxUpdated.ReadOnly = true;
			this.textBoxUpdated.Size = new System.Drawing.Size(300, 20);
			this.textBoxUpdated.TabIndex = 6;
			// 
			// labelUpdated
			// 
			this.labelUpdated.AutoSize = true;
			this.labelUpdated.Location = new System.Drawing.Point(6, 65);
			this.labelUpdated.Name = "labelUpdated";
			this.labelUpdated.Size = new System.Drawing.Size(51, 13);
			this.labelUpdated.TabIndex = 5;
			this.labelUpdated.Text = "Updated:";
			// 
			// textBoxAuthor
			// 
			this.textBoxAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxAuthor.Location = new System.Drawing.Point(80, 88);
			this.textBoxAuthor.Name = "textBoxAuthor";
			this.textBoxAuthor.ReadOnly = true;
			this.textBoxAuthor.Size = new System.Drawing.Size(300, 20);
			this.textBoxAuthor.TabIndex = 8;
			// 
			// labelAuthor
			// 
			this.labelAuthor.AutoSize = true;
			this.labelAuthor.Location = new System.Drawing.Point(6, 91);
			this.labelAuthor.Name = "labelAuthor";
			this.labelAuthor.Size = new System.Drawing.Size(41, 13);
			this.labelAuthor.TabIndex = 7;
			this.labelAuthor.Text = "Author:";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.FilePlay_48;
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			// 
			// textBoxId
			// 
			this.textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxId.Location = new System.Drawing.Point(80, 10);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.ReadOnly = true;
			this.textBoxId.Size = new System.Drawing.Size(300, 20);
			this.textBoxId.TabIndex = 2;
			// 
			// labelId
			// 
			this.labelId.AutoSize = true;
			this.labelId.Location = new System.Drawing.Point(6, 13);
			this.labelId.Name = "labelId";
			this.labelId.Size = new System.Drawing.Size(21, 13);
			this.labelId.TabIndex = 1;
			this.labelId.Text = "ID:";
			// 
			// textBoxSummary
			// 
			this.textBoxSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSummary.Location = new System.Drawing.Point(80, 114);
			this.textBoxSummary.Name = "textBoxSummary";
			this.textBoxSummary.ReadOnly = true;
			this.textBoxSummary.Size = new System.Drawing.Size(300, 20);
			this.textBoxSummary.TabIndex = 10;
			// 
			// labelSummary
			// 
			this.labelSummary.AutoSize = true;
			this.labelSummary.Location = new System.Drawing.Point(6, 117);
			this.labelSummary.Name = "labelSummary";
			this.labelSummary.Size = new System.Drawing.Size(53, 13);
			this.labelSummary.TabIndex = 9;
			this.labelSummary.Text = "Summary:";
			// 
			// textBoxCount
			// 
			this.textBoxCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCount.Location = new System.Drawing.Point(80, 140);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.ReadOnly = true;
			this.textBoxCount.Size = new System.Drawing.Size(300, 20);
			this.textBoxCount.TabIndex = 12;
			// 
			// labelCount
			// 
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new System.Drawing.Point(6, 143);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(58, 13);
			this.labelCount.TabIndex = 11;
			this.labelCount.Text = "Count hint:";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Location = new System.Drawing.Point(3, 64);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(394, 283);
			this.tabControl.TabIndex = 13;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.labelCount);
			this.tabPageGeneral.Controls.Add(this.textBoxCount);
			this.tabPageGeneral.Controls.Add(this.labelSummary);
			this.tabPageGeneral.Controls.Add(this.textBoxSummary);
			this.tabPageGeneral.Controls.Add(this.labelId);
			this.tabPageGeneral.Controls.Add(this.textBoxId);
			this.tabPageGeneral.Controls.Add(this.labelAuthor);
			this.tabPageGeneral.Controls.Add(this.textBoxAuthor);
			this.tabPageGeneral.Controls.Add(this.labelUpdated);
			this.tabPageGeneral.Controls.Add(this.textBoxUpdated);
			this.tabPageGeneral.Controls.Add(this.labelPublished);
			this.tabPageGeneral.Controls.Add(this.textBoxPublished);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(386, 257);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// ControlPlaylist
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlPlaylist";
			this.Size = new System.Drawing.Size(400, 350);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.ResumeLayout(false);

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
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.Label labelId;
		private System.Windows.Forms.TextBox textBoxSummary;
		private System.Windows.Forms.Label labelSummary;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.Label labelCount;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
	}
}
