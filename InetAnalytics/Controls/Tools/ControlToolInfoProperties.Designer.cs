namespace InetAnalytics.Controls.Tools
{
	partial class ControlToolInfoProperties
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
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelId = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.labelDesciption = new System.Windows.Forms.Label();
			this.textBoxVersion = new System.Windows.Forms.TextBox();
			this.labelVersion = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(59, 29);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(84, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No tool selected";
			this.labelTitle.UseMnemonic = false;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDescription.Location = new System.Drawing.Point(82, 84);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxDescription.Size = new System.Drawing.Size(245, 223);
			this.textBoxDescription.TabIndex = 7;
			// 
			// textBoxId
			// 
			this.textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxId.Location = new System.Drawing.Point(82, 32);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.ReadOnly = true;
			this.textBoxId.Size = new System.Drawing.Size(245, 20);
			this.textBoxId.TabIndex = 3;
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Location = new System.Drawing.Point(82, 6);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.ReadOnly = true;
			this.textBoxName.Size = new System.Drawing.Size(245, 20);
			this.textBoxName.TabIndex = 1;
			// 
			// labelId
			// 
			this.labelId.AutoSize = true;
			this.labelId.Location = new System.Drawing.Point(6, 35);
			this.labelId.Name = "labelId";
			this.labelId.Size = new System.Drawing.Size(21, 13);
			this.labelId.TabIndex = 2;
			this.labelId.Text = "&ID:";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(6, 9);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(38, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "&Name:";
			// 
			// labelDesciption
			// 
			this.labelDesciption.AutoSize = true;
			this.labelDesciption.Location = new System.Drawing.Point(6, 87);
			this.labelDesciption.Name = "labelDesciption";
			this.labelDesciption.Size = new System.Drawing.Size(63, 13);
			this.labelDesciption.TabIndex = 6;
			this.labelDesciption.Text = "Description:";
			// 
			// textBoxVersion
			// 
			this.textBoxVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxVersion.Location = new System.Drawing.Point(82, 58);
			this.textBoxVersion.Name = "textBoxVersion";
			this.textBoxVersion.ReadOnly = true;
			this.textBoxVersion.Size = new System.Drawing.Size(245, 20);
			this.textBoxVersion.TabIndex = 5;
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(6, 61);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(45, 13);
			this.labelVersion.TabIndex = 4;
			this.labelVersion.Text = "&Version:";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.PickAxeLarge_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Location = new System.Drawing.Point(6, 58);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(341, 339);
			this.tabControl.TabIndex = 0;
			this.tabControl.Visible = false;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.labelName);
			this.tabPageGeneral.Controls.Add(this.labelId);
			this.tabPageGeneral.Controls.Add(this.labelVersion);
			this.tabPageGeneral.Controls.Add(this.textBoxName);
			this.tabPageGeneral.Controls.Add(this.textBoxVersion);
			this.tabPageGeneral.Controls.Add(this.textBoxId);
			this.tabPageGeneral.Controls.Add(this.textBoxDescription);
			this.tabPageGeneral.Controls.Add(this.labelDesciption);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(333, 313);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// ControlToolProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlToolProperties";
			this.Size = new System.Drawing.Size(350, 400);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelId;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelDesciption;
		private System.Windows.Forms.TextBox textBoxVersion;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
	}
}
