namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlPlanetLabPersons
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPlanetLabPersons));
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.labelUsername = new System.Windows.Forms.Label();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelSelect = new System.Windows.Forms.Label();
			this.buttonSelect = new System.Windows.Forms.Button();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonProperties = new System.Windows.Forms.Button();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUsername.Location = new System.Drawing.Point(91, 5);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.ReadOnly = true;
			this.textBoxUsername.Size = new System.Drawing.Size(506, 20);
			this.textBoxUsername.TabIndex = 1;
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
			this.listView.Location = new System.Drawing.Point(3, 55);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(594, 213);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 6;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemActivate += new System.EventHandler(this.OnProperties);
			this.listView.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
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
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(512, 274);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(85, 23);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// labelSelect
			// 
			this.labelSelect.AutoSize = true;
			this.labelSelect.Location = new System.Drawing.Point(3, 39);
			this.labelSelect.Name = "labelSelect";
			this.labelSelect.Size = new System.Drawing.Size(368, 13);
			this.labelSelect.TabIndex = 5;
			this.labelSelect.Text = "Select the PlanetLab account you want to use with the specified credentials:";
			// 
			// buttonSelect
			// 
			this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelect.Enabled = false;
			this.buttonSelect.Location = new System.Drawing.Point(421, 274);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(85, 23);
			this.buttonSelect.TabIndex = 8;
			this.buttonSelect.Text = "&Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Click += new System.EventHandler(this.OnSelect);
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
			// buttonProperties
			// 
			this.buttonProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonProperties.Enabled = false;
			this.buttonProperties.Image = ((System.Drawing.Image)(resources.GetObject("buttonProperties.Image")));
			this.buttonProperties.Location = new System.Drawing.Point(3, 274);
			this.buttonProperties.Name = "buttonProperties";
			this.buttonProperties.Size = new System.Drawing.Size(85, 23);
			this.buttonProperties.TabIndex = 9;
			this.buttonProperties.Text = "&Properties";
			this.buttonProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonProperties.UseVisualStyleBackColor = true;
			// 
			// ControlPlanetLabPersons
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.buttonProperties);
			this.Controls.Add(this.buttonSelect);
			this.Controls.Add(this.labelSelect);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.listView);
			this.Controls.Add(this.labelUsername);
			this.Controls.Add(this.textBoxUsername);
			this.Name = "ControlPlanetLabPersons";
			this.Size = new System.Drawing.Size(600, 300);
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.Label labelUsername;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderFirstName;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ColumnHeader columnHeaderLastName;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.Label labelSelect;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button buttonSelect;
		private System.Windows.Forms.ColumnHeader columnHeaderEnabled;
		private System.Windows.Forms.ColumnHeader columnHeaderPhone;
		private System.Windows.Forms.ColumnHeader columnHeaderEmail;
		private System.Windows.Forms.ColumnHeader columnHeaderUrl;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
		private System.Windows.Forms.Button buttonProperties;
	}
}
