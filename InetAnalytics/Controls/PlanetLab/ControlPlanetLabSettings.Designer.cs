namespace InetAnalytics.Controls.PlanetLab
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
			// If disposing the managed resources.
			if (disposing)
			{
				// Dispose the components.
				if (this.components != null)
				{
					this.components.Dispose();
				}
				// Dispose the forms.
				this.formPersonProperties.Dispose();
				this.formSelectPerson.Dispose();
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
			System.Security.SecureString secureString1 = new System.Security.SecureString();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPlanetLabSettings));
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.labelUsername = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxPassword = new DotNetApi.Windows.Controls.SecureTextBox();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.labelPerson = new System.Windows.Forms.Label();
			this.buttonProperties = new System.Windows.Forms.Button();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureUser = new System.Windows.Forms.PictureBox();
			this.panelPerson = new System.Windows.Forms.Panel();
			this.labelUrl = new System.Windows.Forms.Label();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelPhone = new System.Windows.Forms.Label();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.labelPersonTitle = new System.Windows.Forms.Label();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.labelLastName = new System.Windows.Forms.Label();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.labelFirstName = new System.Windows.Forms.Label();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.contextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureUser)).BeginInit();
			this.panelPerson.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Location = new System.Drawing.Point(91, 5);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(200, 20);
			this.textBoxUsername.TabIndex = 1;
			this.textBoxUsername.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// labelUsername
			// 
			this.labelUsername.AutoSize = true;
			this.labelUsername.Location = new System.Drawing.Point(3, 8);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(58, 13);
			this.labelUsername.TabIndex = 0;
			this.labelUsername.Text = "&Username:";
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(3, 34);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(56, 13);
			this.labelPassword.TabIndex = 2;
			this.labelPassword.Text = "&Password:";
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(312, 3);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(85, 23);
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
			this.textBoxPassword.TabIndex = 3;
			this.textBoxPassword.UseSystemPasswordChar = true;
			this.textBoxPassword.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "User");
			this.imageList.Images.SetKeyName(1, "UserStar");
			// 
			// labelPerson
			// 
			this.labelPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPerson.Location = new System.Drawing.Point(60, 57);
			this.labelPerson.Name = "labelPerson";
			this.labelPerson.Size = new System.Drawing.Size(337, 48);
			this.labelPerson.TabIndex = 5;
			this.labelPerson.Text = "There is no current PlanelLab account.";
			// 
			// buttonProperties
			// 
			this.buttonProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonProperties.Enabled = false;
			this.buttonProperties.Image = ((System.Drawing.Image)(resources.GetObject("buttonProperties.Image")));
			this.buttonProperties.Location = new System.Drawing.Point(6, 274);
			this.buttonProperties.Name = "buttonProperties";
			this.buttonProperties.Size = new System.Drawing.Size(85, 23);
			this.buttonProperties.TabIndex = 8;
			this.buttonProperties.Text = "&Properties";
			this.buttonProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonProperties.UseVisualStyleBackColor = true;
			this.buttonProperties.Click += new System.EventHandler(this.OnProperties);
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProperties});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(128, 26);
			// 
			// menuItemProperties
			// 
			this.menuItemProperties.Image = ((System.Drawing.Image)(resources.GetObject("menuItemProperties.Image")));
			this.menuItemProperties.Name = "menuItemProperties";
			this.menuItemProperties.Size = new System.Drawing.Size(127, 22);
			this.menuItemProperties.Text = "&Properties";
			this.menuItemProperties.Click += new System.EventHandler(this.OnProperties);
			// 
			// pictureUser
			// 
			this.pictureUser.ErrorImage = null;
			this.pictureUser.Image = global::InetAnalytics.Resources.UserQuestion_48;
			this.pictureUser.InitialImage = null;
			this.pictureUser.Location = new System.Drawing.Point(6, 57);
			this.pictureUser.Name = "pictureUser";
			this.pictureUser.Size = new System.Drawing.Size(48, 48);
			this.pictureUser.TabIndex = 9;
			this.pictureUser.TabStop = false;
			// 
			// panelPerson
			// 
			this.panelPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelPerson.AutoScroll = true;
			this.panelPerson.Controls.Add(this.labelUrl);
			this.panelPerson.Controls.Add(this.textBoxUrl);
			this.panelPerson.Controls.Add(this.labelEmail);
			this.panelPerson.Controls.Add(this.labelPhone);
			this.panelPerson.Controls.Add(this.textBoxEmail);
			this.panelPerson.Controls.Add(this.textBoxPhone);
			this.panelPerson.Controls.Add(this.labelPersonTitle);
			this.panelPerson.Controls.Add(this.textBoxTitle);
			this.panelPerson.Controls.Add(this.labelLastName);
			this.panelPerson.Controls.Add(this.textBoxLastName);
			this.panelPerson.Controls.Add(this.labelFirstName);
			this.panelPerson.Controls.Add(this.textBoxFirstName);
			this.panelPerson.Location = new System.Drawing.Point(0, 108);
			this.panelPerson.Name = "panelPerson";
			this.panelPerson.Size = new System.Drawing.Size(397, 160);
			this.panelPerson.TabIndex = 10;
			this.panelPerson.Visible = false;
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(3, 150);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(32, 13);
			this.labelUrl.TabIndex = 34;
			this.labelUrl.Text = "&URL:";
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Location = new System.Drawing.Point(111, 147);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.ReadOnly = true;
			this.textBoxUrl.Size = new System.Drawing.Size(250, 20);
			this.textBoxUrl.TabIndex = 35;
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Location = new System.Drawing.Point(3, 124);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(38, 13);
			this.labelEmail.TabIndex = 32;
			this.labelEmail.Text = "&E-mail:";
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Location = new System.Drawing.Point(3, 98);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(41, 13);
			this.labelPhone.TabIndex = 30;
			this.labelPhone.Text = "&Phone:";
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Location = new System.Drawing.Point(111, 121);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.ReadOnly = true;
			this.textBoxEmail.Size = new System.Drawing.Size(250, 20);
			this.textBoxEmail.TabIndex = 33;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Location = new System.Drawing.Point(111, 95);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.ReadOnly = true;
			this.textBoxPhone.Size = new System.Drawing.Size(250, 20);
			this.textBoxPhone.TabIndex = 31;
			// 
			// labelPersonTitle
			// 
			this.labelPersonTitle.AutoSize = true;
			this.labelPersonTitle.Location = new System.Drawing.Point(3, 60);
			this.labelPersonTitle.Name = "labelPersonTitle";
			this.labelPersonTitle.Size = new System.Drawing.Size(30, 13);
			this.labelPersonTitle.TabIndex = 28;
			this.labelPersonTitle.Text = "&Title:";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Location = new System.Drawing.Point(111, 57);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.ReadOnly = true;
			this.textBoxTitle.Size = new System.Drawing.Size(250, 20);
			this.textBoxTitle.TabIndex = 29;
			// 
			// labelLastName
			// 
			this.labelLastName.AutoSize = true;
			this.labelLastName.Location = new System.Drawing.Point(3, 34);
			this.labelLastName.Name = "labelLastName";
			this.labelLastName.Size = new System.Drawing.Size(59, 13);
			this.labelLastName.TabIndex = 26;
			this.labelLastName.Text = "&Last name:";
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.Location = new System.Drawing.Point(111, 31);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.ReadOnly = true;
			this.textBoxLastName.Size = new System.Drawing.Size(250, 20);
			this.textBoxLastName.TabIndex = 27;
			// 
			// labelFirstName
			// 
			this.labelFirstName.AutoSize = true;
			this.labelFirstName.Location = new System.Drawing.Point(3, 8);
			this.labelFirstName.Name = "labelFirstName";
			this.labelFirstName.Size = new System.Drawing.Size(58, 13);
			this.labelFirstName.TabIndex = 24;
			this.labelFirstName.Text = "&First name:";
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.Location = new System.Drawing.Point(111, 5);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.ReadOnly = true;
			this.textBoxFirstName.Size = new System.Drawing.Size(250, 20);
			this.textBoxFirstName.TabIndex = 25;
			// 
			// ControlPlanetLabSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.panelPerson);
			this.Controls.Add(this.pictureUser);
			this.Controls.Add(this.buttonProperties);
			this.Controls.Add(this.labelPerson);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labelUsername);
			this.Controls.Add(this.textBoxUsername);
			this.Name = "ControlPlanetLabSettings";
			this.Size = new System.Drawing.Size(400, 300);
			this.Controls.SetChildIndex(this.textBoxUsername, 0);
			this.Controls.SetChildIndex(this.labelUsername, 0);
			this.Controls.SetChildIndex(this.labelPassword, 0);
			this.Controls.SetChildIndex(this.buttonSave, 0);
			this.Controls.SetChildIndex(this.textBoxPassword, 0);
			this.Controls.SetChildIndex(this.labelPerson, 0);
			this.Controls.SetChildIndex(this.buttonProperties, 0);
			this.Controls.SetChildIndex(this.pictureUser, 0);
			this.Controls.SetChildIndex(this.panelPerson, 0);
			this.contextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureUser)).EndInit();
			this.panelPerson.ResumeLayout(false);
			this.panelPerson.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.Label labelUsername;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.Button buttonSave;
		private DotNetApi.Windows.Controls.SecureTextBox textBoxPassword;
		private System.Windows.Forms.Label labelPerson;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button buttonProperties;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
		private System.Windows.Forms.PictureBox pictureUser;
		private System.Windows.Forms.Panel panelPerson;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.TextBox textBoxUrl;
		private System.Windows.Forms.Label labelEmail;
		private System.Windows.Forms.Label labelPhone;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.TextBox textBoxPhone;
		private System.Windows.Forms.Label labelPersonTitle;
		private System.Windows.Forms.TextBox textBoxTitle;
		private System.Windows.Forms.Label labelLastName;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.Label labelFirstName;
		private System.Windows.Forms.TextBox textBoxFirstName;
	}
}
