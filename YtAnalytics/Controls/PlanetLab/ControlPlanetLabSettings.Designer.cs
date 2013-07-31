namespace YtAnalytics.Controls.PlanetLab
{
	partial class ControlPlanetLabSettings
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
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.labelUsername = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxPassword = new DotNetApi.Windows.Controls.SecureTextBox();
			this.SuspendLayout();
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(91, 5);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(200, 20);
			this.textBoxUsername.TabIndex = 0;
			this.textBoxUsername.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// labelUsername
			// 
			this.labelUsername.AutoSize = true;
			this.labelUsername.Location = new System.Drawing.Point(3, 8);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(58, 13);
			this.labelUsername.TabIndex = 1;
			this.labelUsername.Text = "&Username:";
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(3, 34);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(56, 13);
			this.labelPassword.TabIndex = 3;
			this.labelPassword.Text = "&Password:";
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(322, 3);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "&Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.OnSave);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(91, 31);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.SecureText = secureString1;
			this.textBoxPassword.Size = new System.Drawing.Size(200, 20);
			this.textBoxPassword.TabIndex = 5;
			this.textBoxPassword.UseSystemPasswordChar = true;
			this.textBoxPassword.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// ControlPlanetLabSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labelUsername);
			this.Controls.Add(this.textBoxUsername);
			this.Name = "ControlPlanetLabSettings";
			this.Size = new System.Drawing.Size(400, 300);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.Label labelUsername;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.Button buttonSave;
		private DotNetApi.Windows.Controls.SecureTextBox textBoxPassword;
	}
}
