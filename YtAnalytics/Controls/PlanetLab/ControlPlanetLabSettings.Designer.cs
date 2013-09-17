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
			System.Security.SecureString secureString1 = new System.Security.SecureString();
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
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.buttonSave = new System.Windows.Forms.Button();
			this.labelValidation = new System.Windows.Forms.Label();
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
			this.buttonValidate.Location = new System.Drawing.Point(322, 3);
			this.buttonValidate.Name = "buttonValidate";
			this.buttonValidate.Size = new System.Drawing.Size(75, 23);
			this.buttonValidate.TabIndex = 4;
			this.buttonValidate.Text = "&Validate";
			this.buttonValidate.UseVisualStyleBackColor = true;
			this.buttonValidate.Click += new System.EventHandler(this.OnValidate);
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
			// listView
			// 
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderFirstName,
            this.columnHeaderLastName});
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
			this.listView.View = System.Windows.Forms.View.Tile;
			this.listView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnAccountChanged);
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
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
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "User_32.png");
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(322, 274);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
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
			this.labelValidation.Size = new System.Drawing.Size(337, 13);
			this.labelValidation.TabIndex = 5;
			this.labelValidation.Text = "To validate your credentials, &select your PlanetLab account and save:";
			// 
			// ControlPlanetLabSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
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
	}
}
