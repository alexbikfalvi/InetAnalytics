namespace YtAnalytics.Controls
{
	partial class ControlServerProperties
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.checkBoxPrimary = new System.Windows.Forms.CheckBox();
			this.labelPassword = new System.Windows.Forms.Label();
			this.labelUsername = new System.Windows.Forms.Label();
			this.labelDataSource = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.textBoxDataSource = new System.Windows.Forms.TextBox();
			this.textBoxType = new System.Windows.Forms.TextBox();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelType = new System.Windows.Forms.Label();
			this.labelId = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(59, 29);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(67, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Server name";
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
			this.tabControl.TabIndex = 0;
			this.tabControl.Visible = false;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.checkBoxPrimary);
			this.tabPageGeneral.Controls.Add(this.labelPassword);
			this.tabPageGeneral.Controls.Add(this.labelUsername);
			this.tabPageGeneral.Controls.Add(this.labelDataSource);
			this.tabPageGeneral.Controls.Add(this.textBoxPassword);
			this.tabPageGeneral.Controls.Add(this.textBoxUsername);
			this.tabPageGeneral.Controls.Add(this.textBoxDataSource);
			this.tabPageGeneral.Controls.Add(this.textBoxType);
			this.tabPageGeneral.Controls.Add(this.textBoxId);
			this.tabPageGeneral.Controls.Add(this.textBoxName);
			this.tabPageGeneral.Controls.Add(this.labelType);
			this.tabPageGeneral.Controls.Add(this.labelId);
			this.tabPageGeneral.Controls.Add(this.labelName);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(386, 263);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// checkBoxPrimary
			// 
			this.checkBoxPrimary.AutoSize = true;
			this.checkBoxPrimary.Enabled = false;
			this.checkBoxPrimary.Location = new System.Drawing.Point(88, 169);
			this.checkBoxPrimary.Name = "checkBoxPrimary";
			this.checkBoxPrimary.Size = new System.Drawing.Size(92, 17);
			this.checkBoxPrimary.TabIndex = 12;
			this.checkBoxPrimary.Text = "P&rimary server";
			this.checkBoxPrimary.UseVisualStyleBackColor = true;
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(10, 145);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(56, 13);
			this.labelPassword.TabIndex = 10;
			this.labelPassword.Text = "&Password:";
			// 
			// labelUsername
			// 
			this.labelUsername.AutoSize = true;
			this.labelUsername.Location = new System.Drawing.Point(10, 119);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(58, 13);
			this.labelUsername.TabIndex = 8;
			this.labelUsername.Text = "&Username:";
			// 
			// labelDataSource
			// 
			this.labelDataSource.AutoSize = true;
			this.labelDataSource.Location = new System.Drawing.Point(10, 93);
			this.labelDataSource.Name = "labelDataSource";
			this.labelDataSource.Size = new System.Drawing.Size(41, 13);
			this.labelDataSource.TabIndex = 6;
			this.labelDataSource.Text = "&Server:";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPassword.Location = new System.Drawing.Point(88, 142);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(270, 20);
			this.textBoxPassword.TabIndex = 11;
			this.textBoxPassword.UseSystemPasswordChar = true;
			this.textBoxPassword.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUsername.Location = new System.Drawing.Point(88, 116);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(270, 20);
			this.textBoxUsername.TabIndex = 9;
			this.textBoxUsername.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// textBoxDataSource
			// 
			this.textBoxDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDataSource.Location = new System.Drawing.Point(88, 90);
			this.textBoxDataSource.Name = "textBoxDataSource";
			this.textBoxDataSource.Size = new System.Drawing.Size(270, 20);
			this.textBoxDataSource.TabIndex = 7;
			this.textBoxDataSource.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// textBoxType
			// 
			this.textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxType.Location = new System.Drawing.Point(88, 64);
			this.textBoxType.Name = "textBoxType";
			this.textBoxType.ReadOnly = true;
			this.textBoxType.Size = new System.Drawing.Size(270, 20);
			this.textBoxType.TabIndex = 5;
			// 
			// textBoxId
			// 
			this.textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxId.Location = new System.Drawing.Point(88, 38);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.ReadOnly = true;
			this.textBoxId.Size = new System.Drawing.Size(270, 20);
			this.textBoxId.TabIndex = 3;
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Location = new System.Drawing.Point(88, 12);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(270, 20);
			this.textBoxName.TabIndex = 1;
			this.textBoxName.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(10, 67);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(34, 13);
			this.labelType.TabIndex = 4;
			this.labelType.Text = "&Type:";
			// 
			// labelId
			// 
			this.labelId.AutoSize = true;
			this.labelId.Location = new System.Drawing.Point(10, 41);
			this.labelId.Name = "labelId";
			this.labelId.Size = new System.Drawing.Size(21, 13);
			this.labelId.TabIndex = 2;
			this.labelId.Text = "I&D:";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(10, 15);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(38, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "&Name:";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.ServerDatabase_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ControlServerProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlServerProperties";
			this.Size = new System.Drawing.Size(400, 350);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
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
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.Label labelId;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.TextBox textBoxType;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.TextBox textBoxDataSource;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.Label labelUsername;
		private System.Windows.Forms.Label labelDataSource;
		private System.Windows.Forms.CheckBox checkBoxPrimary;
	}
}
