namespace YtAnalytics.Controls
{
	partial class ControlAddComment
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
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxText = new System.Windows.Forms.TextBox();
			this.textBoxCommenter = new System.Windows.Forms.TextBox();
			this.textBoxItem = new System.Windows.Forms.TextBox();
			this.labelText = new System.Windows.Forms.Label();
			this.labelCommenter = new System.Windows.Forms.Label();
			this.labelItem = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.CommentAdd_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(108, 20);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Add comment";
			// 
			// textBoxText
			// 
			this.textBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxText.Location = new System.Drawing.Point(99, 126);
			this.textBoxText.Multiline = true;
			this.textBoxText.Name = "textBoxText";
			this.textBoxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxText.Size = new System.Drawing.Size(270, 161);
			this.textBoxText.TabIndex = 6;
			this.textBoxText.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// textBoxCommenter
			// 
			this.textBoxCommenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCommenter.Location = new System.Drawing.Point(99, 100);
			this.textBoxCommenter.Name = "textBoxCommenter";
			this.textBoxCommenter.Size = new System.Drawing.Size(270, 20);
			this.textBoxCommenter.TabIndex = 4;
			this.textBoxCommenter.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// textBoxItem
			// 
			this.textBoxItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxItem.Location = new System.Drawing.Point(99, 74);
			this.textBoxItem.Name = "textBoxItem";
			this.textBoxItem.Size = new System.Drawing.Size(270, 20);
			this.textBoxItem.TabIndex = 2;
			this.textBoxItem.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Location = new System.Drawing.Point(17, 128);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(31, 13);
			this.labelText.TabIndex = 5;
			this.labelText.Text = "&Text:";
			// 
			// labelCommenter
			// 
			this.labelCommenter.AutoSize = true;
			this.labelCommenter.Location = new System.Drawing.Point(17, 103);
			this.labelCommenter.Name = "labelCommenter";
			this.labelCommenter.Size = new System.Drawing.Size(63, 13);
			this.labelCommenter.TabIndex = 3;
			this.labelCommenter.Text = "&Commenter:";
			// 
			// labelItem
			// 
			this.labelItem.AutoSize = true;
			this.labelItem.Location = new System.Drawing.Point(17, 77);
			this.labelItem.Name = "labelItem";
			this.labelItem.Size = new System.Drawing.Size(30, 13);
			this.labelItem.TabIndex = 1;
			this.labelItem.Text = "&Item:";
			// 
			// ControlAddComment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBoxText);
			this.Controls.Add(this.textBoxCommenter);
			this.Controls.Add(this.textBoxItem);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.labelCommenter);
			this.Controls.Add(this.labelItem);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlAddComment";
			this.Size = new System.Drawing.Size(400, 290);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxText;
		private System.Windows.Forms.TextBox textBoxCommenter;
		private System.Windows.Forms.TextBox textBoxItem;
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.Label labelCommenter;
		private System.Windows.Forms.Label labelItem;
	}
}
