namespace YtAnalytics.Controls.YouTube
{
	partial class ControlHistoryDiscoveryEvent
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlHistoryDiscoveryEvent));
			this.labelTitle = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.labelTime = new System.Windows.Forms.Label();
			this.textBoxTime = new System.Windows.Forms.TextBox();
			this.textBoxData = new System.Windows.Forms.TextBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.textBoxType = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelData = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelType = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyValueToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.contextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(59, 29);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(94, 13);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "No event selected";
			this.labelTitle.UseMnemonic = false;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Location = new System.Drawing.Point(3, 58);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(394, 289);
			this.tabControl.TabIndex = 2;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.labelTime);
			this.tabPageGeneral.Controls.Add(this.textBoxTime);
			this.tabPageGeneral.Controls.Add(this.textBoxData);
			this.tabPageGeneral.Controls.Add(this.textBoxDescription);
			this.tabPageGeneral.Controls.Add(this.textBoxType);
			this.tabPageGeneral.Controls.Add(this.textBoxName);
			this.tabPageGeneral.Controls.Add(this.labelData);
			this.tabPageGeneral.Controls.Add(this.labelDescription);
			this.tabPageGeneral.Controls.Add(this.labelType);
			this.tabPageGeneral.Controls.Add(this.labelName);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(386, 263);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.Location = new System.Drawing.Point(10, 41);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(33, 13);
			this.labelTime.TabIndex = 11;
			this.labelTime.Text = "Time:";
			// 
			// textBoxTime
			// 
			this.textBoxTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTime.Location = new System.Drawing.Point(88, 38);
			this.textBoxTime.Name = "textBoxTime";
			this.textBoxTime.ReadOnly = true;
			this.textBoxTime.Size = new System.Drawing.Size(270, 20);
			this.textBoxTime.TabIndex = 10;
			// 
			// textBoxData
			// 
			this.textBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxData.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxData.Location = new System.Drawing.Point(88, 116);
			this.textBoxData.Multiline = true;
			this.textBoxData.Name = "textBoxData";
			this.textBoxData.ReadOnly = true;
			this.textBoxData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxData.Size = new System.Drawing.Size(270, 141);
			this.textBoxData.TabIndex = 9;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDescription.Location = new System.Drawing.Point(88, 90);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.Size = new System.Drawing.Size(270, 20);
			this.textBoxDescription.TabIndex = 5;
			// 
			// textBoxType
			// 
			this.textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxType.Location = new System.Drawing.Point(88, 64);
			this.textBoxType.Name = "textBoxType";
			this.textBoxType.ReadOnly = true;
			this.textBoxType.Size = new System.Drawing.Size(270, 20);
			this.textBoxType.TabIndex = 3;
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Location = new System.Drawing.Point(88, 12);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.ReadOnly = true;
			this.textBoxName.Size = new System.Drawing.Size(270, 20);
			this.textBoxName.TabIndex = 1;
			// 
			// labelData
			// 
			this.labelData.AutoSize = true;
			this.labelData.Location = new System.Drawing.Point(10, 118);
			this.labelData.Name = "labelData";
			this.labelData.Size = new System.Drawing.Size(33, 13);
			this.labelData.TabIndex = 8;
			this.labelData.Text = "Data:";
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(10, 93);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(63, 13);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "Description:";
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(10, 67);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(34, 13);
			this.labelType.TabIndex = 2;
			this.labelType.Text = "Type:";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(10, 15);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(38, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Name:";
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
			this.copyValueToClipboardToolStripMenuItem.Image = global::YtAnalytics.Resources.Copy_16;
			this.copyValueToClipboardToolStripMenuItem.Name = "copyValueToClipboardToolStripMenuItem";
			this.copyValueToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.copyValueToClipboardToolStripMenuItem.Text = "Copy to clipboard";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.HotSpot_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ControlHistoryDiscoveryEvent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlHistoryDiscoveryEvent";
			this.Size = new System.Drawing.Size(400, 350);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.contextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelData;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxType;
		private System.Windows.Forms.TextBox textBoxData;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem copyValueToClipboardToolStripMenuItem;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.TextBox textBoxTime;
	}
}
