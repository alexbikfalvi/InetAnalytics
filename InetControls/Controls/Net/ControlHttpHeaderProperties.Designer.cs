namespace InetCommon.Controls.Net
{
	partial class ControlHttpHeader
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlHttpHeader));
			this.labelHeader = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageValue = new System.Windows.Forms.TabPage();
			this.textBoxValue = new System.Windows.Forms.TextBox();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyValueToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tabControl.SuspendLayout();
			this.tabPageValue.SuspendLayout();
			this.contextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelHeader
			// 
			this.labelHeader.AutoSize = true;
			this.labelHeader.Location = new System.Drawing.Point(59, 29);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(72, 13);
			this.labelHeader.TabIndex = 0;
			this.labelHeader.Text = "HTTP header";
			this.labelHeader.UseMnemonic = false;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageValue);
			this.tabControl.Location = new System.Drawing.Point(3, 58);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(394, 289);
			this.tabControl.TabIndex = 1;
			// 
			// tabPageValue
			// 
			this.tabPageValue.Controls.Add(this.textBoxValue);
			this.tabPageValue.Location = new System.Drawing.Point(4, 22);
			this.tabPageValue.Name = "tabPageValue";
			this.tabPageValue.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageValue.Size = new System.Drawing.Size(386, 263);
			this.tabPageValue.TabIndex = 0;
			this.tabPageValue.Text = "Value";
			this.tabPageValue.UseVisualStyleBackColor = true;
			// 
			// textBoxValue
			// 
			this.textBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxValue.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxValue.Location = new System.Drawing.Point(6, 6);
			this.textBoxValue.Multiline = true;
			this.textBoxValue.Name = "textBoxValue";
			this.textBoxValue.ReadOnly = true;
			this.textBoxValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxValue.Size = new System.Drawing.Size(374, 251);
			this.textBoxValue.TabIndex = 9;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "EventBrown_16.png");
			this.imageList.Images.SetKeyName(1, "Information_16.png");
			this.imageList.Images.SetKeyName(2, "Success_16.png");
			this.imageList.Images.SetKeyName(3, "Error_16.png");
			this.imageList.Images.SetKeyName(4, "Canceled_16.png");
			this.imageList.Images.SetKeyName(5, "Warning_16.png");
			this.imageList.Images.SetKeyName(6, "Stop_16.png");
			this.imageList.Images.SetKeyName(7, "SuccessWarning_16.png");
			this.imageList.Images.SetKeyName(8, "ErrorWarning_16.png");
			this.imageList.Images.SetKeyName(9, "XmlNamespace_16.png");
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyValueToClipboardToolStripMenuItem});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(170, 26);
			// 
			// copyValueToClipboardToolStripMenuItem
			// 
			this.copyValueToClipboardToolStripMenuItem.Image = global::InetCommon.Resources.Copy_16;
			this.copyValueToClipboardToolStripMenuItem.Name = "copyValueToClipboardToolStripMenuItem";
			this.copyValueToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.copyValueToClipboardToolStripMenuItem.Text = "Copy to clipboard";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetCommon.Resources.Header_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ControlHttpHeader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelHeader);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlHttpHeader";
			this.Size = new System.Drawing.Size(400, 350);
			this.tabControl.ResumeLayout(false);
			this.tabPageValue.ResumeLayout(false);
			this.tabPageValue.PerformLayout();
			this.contextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelHeader;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageValue;
		private System.Windows.Forms.TextBox textBoxValue;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem copyValueToClipboardToolStripMenuItem;
	}
}
