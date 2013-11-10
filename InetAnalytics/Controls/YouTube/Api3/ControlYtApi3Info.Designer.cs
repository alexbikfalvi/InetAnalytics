namespace InetAnalytics.Controls.YouTube.Api3
{
	partial class ControlYtApi3Info
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
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 42);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(196, 20);
			this.labelTitle.TabIndex = 3;
			this.labelTitle.Text = "YouTube API Version 3";
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::InetAnalytics.Resources.ServerVideo_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 41);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 2;
			this.pictureBoxIcon.TabStop = false;
			// 
			// ControlYtApi3Info
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBoxIcon);
			this.Name = "ControlYtApi3Info";
			this.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.ShowBorder = true;
			this.ShowTitle = true;
			this.Size = new System.Drawing.Size(800, 600);
			this.Title = "YouTube API Version 3";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBoxIcon;
	}
}
