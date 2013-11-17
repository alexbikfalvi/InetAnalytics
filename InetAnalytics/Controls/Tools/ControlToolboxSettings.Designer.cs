namespace InetAnalytics.Controls.Tools
{
	partial class ControlToolboxSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlToolboxSettings));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonAdd = new System.Windows.Forms.ToolStripButton();
			this.buttonRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAdd,
            this.buttonRemove});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(600, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonAdd
			// 
			this.buttonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
			this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(23, 22);
			this.buttonAdd.Text = "toolStripButton1";
			// 
			// buttonRemove
			// 
			this.buttonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
			this.buttonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(23, 22);
			this.buttonRemove.Text = "toolStripButton1";
			// 
			// ControlToolboxSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolStrip);
			this.Name = "ControlToolboxSettings";
			this.Size = new System.Drawing.Size(600, 400);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonAdd;
		private System.Windows.Forms.ToolStripButton buttonRemove;
	}
}
