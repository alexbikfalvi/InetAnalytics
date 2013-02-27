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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxText = new System.Windows.Forms.TextBox();
			this.textBoxUser = new System.Windows.Forms.TextBox();
			this.textBoxObject = new System.Windows.Forms.TextBox();
			this.labelText = new System.Windows.Forms.Label();
			this.labelUser = new System.Windows.Forms.Label();
			this.labelObject = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::YtAnalytics.Resources.CommentAdd_48;
			this.pictureBox1.Location = new System.Drawing.Point(20, 20);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(48, 48);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
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
			// textBoxUser
			// 
			this.textBoxUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUser.Location = new System.Drawing.Point(99, 100);
			this.textBoxUser.Name = "textBoxUser";
			this.textBoxUser.Size = new System.Drawing.Size(270, 20);
			this.textBoxUser.TabIndex = 4;
			this.textBoxUser.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// textBoxObject
			// 
			this.textBoxObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxObject.Location = new System.Drawing.Point(99, 74);
			this.textBoxObject.Name = "textBoxObject";
			this.textBoxObject.Size = new System.Drawing.Size(270, 20);
			this.textBoxObject.TabIndex = 2;
			this.textBoxObject.TextChanged += new System.EventHandler(this.OnInputChanged);
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
			// labelUser
			// 
			this.labelUser.AutoSize = true;
			this.labelUser.Location = new System.Drawing.Point(17, 103);
			this.labelUser.Name = "labelUser";
			this.labelUser.Size = new System.Drawing.Size(32, 13);
			this.labelUser.TabIndex = 3;
			this.labelUser.Text = "&User:";
			// 
			// labelObject
			// 
			this.labelObject.AutoSize = true;
			this.labelObject.Location = new System.Drawing.Point(17, 77);
			this.labelObject.Name = "labelObject";
			this.labelObject.Size = new System.Drawing.Size(41, 13);
			this.labelObject.TabIndex = 1;
			this.labelObject.Text = "&Object:";
			// 
			// ControlAddComment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBoxText);
			this.Controls.Add(this.textBoxUser);
			this.Controls.Add(this.textBoxObject);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.labelUser);
			this.Controls.Add(this.labelObject);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox1);
			this.Name = "ControlAddComment";
			this.Size = new System.Drawing.Size(400, 290);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxText;
		private System.Windows.Forms.TextBox textBoxUser;
		private System.Windows.Forms.TextBox textBoxObject;
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.Label labelUser;
		private System.Windows.Forms.Label labelObject;
	}
}
