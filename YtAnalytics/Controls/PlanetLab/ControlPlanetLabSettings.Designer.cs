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
			this.components = new System.ComponentModel.Container();
			System.Security.SecureString secureString3 = new System.Security.SecureString();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPlanetLabSettings));
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.labelUsername = new System.Windows.Forms.Label();
			this.labelPassword = new System.Windows.Forms.Label();
			this.buttonValidate = new System.Windows.Forms.Button();
			this.textBoxPassword = new DotNetApi.Windows.Controls.SecureTextBox();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.buttonSave = new System.Windows.Forms.Button();
			this.labelValidation = new System.Windows.Forms.Label();
			this.buttonProperties = new System.Windows.Forms.Button();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu.SuspendLayout();
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
			// buttonValidate
			// 
			this.buttonValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonValidate.Location = new System.Drawing.Point(312, 3);
			this.buttonValidate.Name = "buttonValidate";
			this.buttonValidate.Size = new System.Drawing.Size(85, 23);
			this.buttonValidate.TabIndex = 4;
			this.buttonValidate.Text = "&Validate";
			this.buttonValidate.UseVisualStyleBackColor = true;
			this.buttonValidate.Click += new System.EventHandler(this.OnValidate);
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(91, 31);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.SecureText = secureString3;
			this.textBoxPassword.Size = new System.Drawing.Size(200, 20);
			this.textBoxPassword.TabIndex = 3;
			this.textBoxPassword.UseSystemPasswordChar = true;
			this.textBoxPassword.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// listView
			// 
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderFirstName,
            this.columnHeaderLastName,
            this.columnHeaderEnabled,
            this.columnHeaderPhone,
            this.columnHeaderEmail,
            this.columnHeaderUrl});
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(3, 76);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(394, 192);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 6;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemActivate += new System.EventHandler(this.OnProperties);
			this.listView.SelectedIndexChanged += new System.EventHandler(this.OnAccountSelectionChanged);
			this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
			this.columnHeaderId.Width = 80;
			// 
			// columnHeaderFirstName
			// 
			this.columnHeaderFirstName.Text = "First name";
			this.columnHeaderFirstName.Width = 120;
			// 
			// columnHeaderLastName
			// 
			this.columnHeaderLastName.Text = "Last name";
			this.columnHeaderLastName.Width = 120;
			// 
			// columnHeaderEnabled
			// 
			this.columnHeaderEnabled.Text = "Enabled";
			// 
			// columnHeaderPhone
			// 
			this.columnHeaderPhone.Text = "Phone";
			this.columnHeaderPhone.Width = 120;
			// 
			// columnHeaderEmail
			// 
			this.columnHeaderEmail.Text = "Email";
			this.columnHeaderEmail.Width = 120;
			// 
			// columnHeaderUrl
			// 
			this.columnHeaderUrl.Text = "URL";
			this.columnHeaderUrl.Width = 120;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "User");
			this.imageList.Images.SetKeyName(1, "UserStar");
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(312, 274);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(85, 23);
			this.buttonSave.TabIndex = 7;
			this.buttonSave.Text = "&Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.OnSave);
			// 
			// labelValidation
			// 
			this.labelValidation.AutoSize = true;
			this.labelValidation.Location = new System.Drawing.Point(3, 60);
			this.labelValidation.Name = "labelValidation";
			this.labelValidation.Size = new System.Drawing.Size(372, 13);
			this.labelValidation.TabIndex = 5;
			this.labelValidation.Text = "To validate your credentials, &select your default PlanetLab account and save:";
			// 
			// buttonProperties
			// 
			this.buttonProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonProperties.Enabled = false;
			this.buttonProperties.Image = global::YtAnalytics.Resources.Properties_16;
			this.buttonProperties.Location = new System.Drawing.Point(221, 274);
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
			this.menuItemProperties.Image = global::YtAnalytics.Resources.Properties_16;
			this.menuItemProperties.Name = "menuItemProperties";
			this.menuItemProperties.Size = new System.Drawing.Size(152, 22);
			this.menuItemProperties.Text = "&Properties";
			this.menuItemProperties.Click += new System.EventHandler(this.OnProperties);
			// 
			// ControlPlanetLabSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.buttonProperties);
			this.Controls.Add(this.labelValidation);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.listView);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.buttonValidate);
			this.Controls.Add(this.labelPassword);
			this.Controls.Add(this.labelUsername);
			this.Controls.Add(this.textBoxUsername);
			this.Name = "ControlPlanetLabSettings";
			this.Size = new System.Drawing.Size(400, 300);
			this.Controls.SetChildIndex(this.textBoxUsername, 0);
			this.Controls.SetChildIndex(this.labelUsername, 0);
			this.Controls.SetChildIndex(this.labelPassword, 0);
			this.Controls.SetChildIndex(this.buttonValidate, 0);
			this.Controls.SetChildIndex(this.textBoxPassword, 0);
			this.Controls.SetChildIndex(this.listView, 0);
			this.Controls.SetChildIndex(this.buttonSave, 0);
			this.Controls.SetChildIndex(this.labelValidation, 0);
			this.Controls.SetChildIndex(this.buttonProperties, 0);
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.Label labelUsername;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.Button buttonValidate;
		private DotNetApi.Windows.Controls.SecureTextBox textBoxPassword;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderFirstName;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.ColumnHeader columnHeaderLastName;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.Label labelValidation;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button buttonProperties;
		private System.Windows.Forms.ColumnHeader columnHeaderEnabled;
		private System.Windows.Forms.ColumnHeader columnHeaderPhone;
		private System.Windows.Forms.ColumnHeader columnHeaderEmail;
		private System.Windows.Forms.ColumnHeader columnHeaderUrl;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
	}
}
