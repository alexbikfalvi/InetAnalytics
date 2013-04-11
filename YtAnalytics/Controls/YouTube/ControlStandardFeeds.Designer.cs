namespace YtAnalytics.Controls.YouTube
{
	partial class ControlStandardFeeds
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
			if (disposing && (this.components != null))
			{
				// Dispose the components.
				this.components.Dispose();
			}
			// Call the base class function.
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// ControlStandardFeeds
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.DoubleBuffered = true;
			this.Name = "ControlStandardFeeds";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
			this.MouseLeave += new System.EventHandler(this.OnMouseLeave);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
			this.Resize += new System.EventHandler(this.OnResize);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
