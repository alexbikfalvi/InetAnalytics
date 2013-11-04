namespace InetAnalytics.Controls.Comments
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCommentProperties));
			this.labelTitle = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.textBoxGuid = new System.Windows.Forms.TextBox();
			this.labelGuid = new System.Windows.Forms.Label();
			this.labelTime = new System.Windows.Forms.Label();
			this.textBoxTime = new System.Windows.Forms.TextBox();
			this.textBoxText = new System.Windows.Forms.TextBox();
			this.textBoxUser = new System.Windows.Forms.TextBox();
			this.textBoxObject = new System.Windows.Forms.TextBox();
			this.labelText = new System.Windows.Forms.Label();
			this.labelUser = new System.Windows.Forms.Label();
			this.labelObject = new System.Windows.Forms.Label();
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
			this.labelTitle.Size = new System.Drawing.Size(110, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No comment selected";
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
			this.tabControl.TabIndex = 1;
			this.tabControl.Visible = false;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.textBoxGuid);
			this.tabPageGeneral.Controls.Add(this.labelGuid);
			this.tabPageGeneral.Controls.Add(this.labelTime);
			this.tabPageGeneral.Controls.Add(this.textBoxTime);
			this.tabPageGeneral.Controls.Add(this.textBoxText);
			this.tabPageGeneral.Controls.Add(this.textBoxUser);
			this.tabPageGeneral.Controls.Add(this.textBoxObject);
			this.tabPageGeneral.Controls.Add(this.labelText);
			this.tabPageGeneral.Controls.Add(this.labelUser);
			this.tabPageGeneral.Controls.Add(this.labelObject);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(386, 263);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// textBoxGuid
			// 
			this.textBoxGuid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxGuid.Location = new System.Drawing.Point(88, 84);
			this.textBoxGuid.Name = "textBoxGuid";
			this.textBoxGuid.ReadOnly = true;
			this.textBoxGuid.Size = new System.Drawing.Size(270, 20);
			this.textBoxGuid.TabIndex = 7;
			// 
			// labelGuid
			// 
			this.labelGuid.AutoSize = true;
			this.labelGuid.Location = new System.Drawing.Point(10, 87);
			this.labelGuid.Name = "labelGuid";
			this.labelGuid.Size = new System.Drawing.Size(37, 13);
			this.labelGuid.TabIndex = 6;
			this.labelGuid.Text = "GUID:";
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.Location = new System.Drawing.Point(10, 9);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(33, 13);
			this.labelTime.TabIndex = 0;
			this.labelTime.Text = "Time:";
			// 
			// textBoxTime
			// 
			this.textBoxTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTime.Location = new System.Drawing.Point(88, 6);
			this.textBoxTime.Name = "textBoxTime";
			this.textBoxTime.ReadOnly = true;
			this.textBoxTime.Size = new System.Drawing.Size(270, 20);
			this.textBoxTime.TabIndex = 1;
			// 
			// textBoxText
			// 
			this.textBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxText.Location = new System.Drawing.Point(88, 110);
			this.textBoxText.Multiline = true;
			this.textBoxText.Name = "textBoxText";
			this.textBoxText.ReadOnly = true;
			this.textBoxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxText.Size = new System.Drawing.Size(270, 147);
			this.textBoxText.TabIndex = 9;
			// 
			// textBoxUser
			// 
			this.textBoxUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUser.Location = new System.Drawing.Point(88, 58);
			this.textBoxUser.Name = "textBoxUser";
			this.textBoxUser.ReadOnly = true;
			this.textBoxUser.Size = new System.Drawing.Size(270, 20);
			this.textBoxUser.TabIndex = 5;
			// 
			// textBoxObject
			// 
			this.textBoxObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxObject.Location = new System.Drawing.Point(88, 32);
			this.textBoxObject.Name = "textBoxObject";
			this.textBoxObject.ReadOnly = true;
			this.textBoxObject.Size = new System.Drawing.Size(270, 20);
			this.textBoxObject.TabIndex = 3;
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Location = new System.Drawing.Point(10, 112);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(31, 13);
			this.labelText.TabIndex = 8;
			this.labelText.Text = "Text:";
			// 
			// labelUser
			// 
			this.labelUser.AutoSize = true;
			this.labelUser.Location = new System.Drawing.Point(10, 61);
			this.labelUser.Name = "labelUser";
			this.labelUser.Size = new System.Drawing.Size(32, 13);
			this.labelUser.TabIndex = 4;
			this.labelUser.Text = "User:";
			// 
			// labelObject
			// 
			this.labelObject.AutoSize = true;
			this.labelObject.Location = new System.Drawing.Point(10, 35);
			this.labelObject.Name = "labelObject";
			this.labelObject.Size = new System.Drawing.Size(41, 13);
			this.labelObject.TabIndex = 2;
			this.labelObject.Text = "Object:";
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
			this.copyValueToClipboardToolStripMenuItem.Image = global::InetAnalytics.Resources.Copy_16;
			this.copyValueToClipboardToolStripMenuItem.Name = "copyValueToClipboardToolStripMenuItem";
			this.copyValueToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.copyValueToClipboardToolStripMenuItem.Text = "Copy to clipboard";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.Comment_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ControlCommentProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlCommentProperties";
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
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.Label labelUser;
		private System.Windows.Forms.Label labelObject;
		private System.Windows.Forms.TextBox textBoxObject;
		private System.Windows.Forms.TextBox textBoxText;
		private System.Windows.Forms.TextBox textBoxUser;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem copyValueToClipboardToolStripMenuItem;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.TextBox textBoxTime;
		private System.Windows.Forms.TextBox textBoxGuid;
		private System.Windows.Forms.Label labelGuid;
	}
}
