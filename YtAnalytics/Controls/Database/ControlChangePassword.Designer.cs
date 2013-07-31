namespace YtAnalytics.Controls.Database
{
	partial class ControlChangePassword
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
			System.Security.SecureString secureString1 = new System.Security.SecureString();
			System.Security.SecureString secureString2 = new System.Security.SecureString();
			System.Security.SecureString secureString3 = new System.Security.SecureString();
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelConfirm = new System.Windows.Forms.Label();
			this.labelNew = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelOld = new System.Windows.Forms.Label();
			this.textBoxOld = new DotNetApi.Windows.Controls.SecureTextBox();
			this.textBoxNew = new DotNetApi.Windows.Controls.SecureTextBox();
			this.textBoxConfirm = new DotNetApi.Windows.Controls.SecureTextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(137, 20);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Change password";
			// 
			// labelConfirm
			// 
			this.labelConfirm.AutoSize = true;
			this.labelConfirm.Location = new System.Drawing.Point(17, 128);
			this.labelConfirm.Name = "labelConfirm";
			this.labelConfirm.Size = new System.Drawing.Size(116, 13);
			this.labelConfirm.TabIndex = 5;
			this.labelConfirm.Text = "&Confirm new password:";
			// 
			// labelNew
			// 
			this.labelNew.AutoSize = true;
			this.labelNew.Location = new System.Drawing.Point(17, 102);
			this.labelNew.Name = "labelNew";
			this.labelNew.Size = new System.Drawing.Size(80, 13);
			this.labelNew.TabIndex = 3;
			this.labelNew.Text = "&New password:";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.PasswordChange_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// labelOld
			// 
			this.labelOld.AutoSize = true;
			this.labelOld.Location = new System.Drawing.Point(17, 76);
			this.labelOld.Name = "labelOld";
			this.labelOld.Size = new System.Drawing.Size(74, 13);
			this.labelOld.TabIndex = 1;
			this.labelOld.Text = "&Old password:";
			// 
			// textBoxOld
			// 
			this.textBoxOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxOld.Location = new System.Drawing.Point(158, 73);
			this.textBoxOld.Name = "textBoxOld";
			this.textBoxOld.SecureText = secureString1;
			this.textBoxOld.Size = new System.Drawing.Size(211, 20);
			this.textBoxOld.TabIndex = 9;
			this.textBoxOld.UseSystemPasswordChar = true;
			this.textBoxOld.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// textBoxNew
			// 
			this.textBoxNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNew.Location = new System.Drawing.Point(158, 99);
			this.textBoxNew.Name = "textBoxNew";
			this.textBoxNew.SecureText = secureString2;
			this.textBoxNew.Size = new System.Drawing.Size(211, 20);
			this.textBoxNew.TabIndex = 10;
			this.textBoxNew.UseSystemPasswordChar = true;
			this.textBoxNew.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// textBoxConfirm
			// 
			this.textBoxConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxConfirm.Location = new System.Drawing.Point(158, 125);
			this.textBoxConfirm.Name = "textBoxConfirm";
			this.textBoxConfirm.SecureText = secureString3;
			this.textBoxConfirm.Size = new System.Drawing.Size(211, 20);
			this.textBoxConfirm.TabIndex = 11;
			this.textBoxConfirm.UseSystemPasswordChar = true;
			this.textBoxConfirm.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// ControlChangePassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.textBoxConfirm);
			this.Controls.Add(this.textBoxNew);
			this.Controls.Add(this.textBoxOld);
			this.Controls.Add(this.labelOld);
			this.Controls.Add(this.labelConfirm);
			this.Controls.Add(this.labelNew);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.MinimumSize = new System.Drawing.Size(0, 170);
			this.Name = "ControlChangePassword";
			this.Size = new System.Drawing.Size(400, 170);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelConfirm;
		private System.Windows.Forms.Label labelNew;
		private System.Windows.Forms.Label labelOld;
		private DotNetApi.Windows.Controls.SecureTextBox textBoxOld;
		private DotNetApi.Windows.Controls.SecureTextBox textBoxNew;
		private DotNetApi.Windows.Controls.SecureTextBox textBoxConfirm;
	}
}
