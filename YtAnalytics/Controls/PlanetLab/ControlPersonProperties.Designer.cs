namespace YtAnalytics.Controls.PlanetLab
{
	partial class ControlPersonProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPersonProperties));
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.labelFirstName = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
			this.labelBio = new System.Windows.Forms.Label();
			this.labelUrl = new System.Windows.Forms.Label();
			this.textBoxBio = new System.Windows.Forms.TextBox();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelPhone = new System.Windows.Forms.Label();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.labelPersonTitle = new System.Windows.Forms.Label();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.labelLastName = new System.Windows.Forms.Label();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.tabPageIdentifiers = new System.Windows.Forms.TabPage();
			this.labelPeerId = new System.Windows.Forms.Label();
			this.labelPeerPersonId = new System.Windows.Forms.Label();
			this.textBoxPeerId = new System.Windows.Forms.TextBox();
			this.textBoxPeerPersonId = new System.Windows.Forms.TextBox();
			this.labelPersonId = new System.Windows.Forms.Label();
			this.textBoxPersonId = new System.Windows.Forms.TextBox();
			this.tabPageRoles = new System.Windows.Forms.TabPage();
			this.buttonRole = new System.Windows.Forms.Button();
			this.listViewRoles = new System.Windows.Forms.ListView();
			this.columnHeaderRoleId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderRoleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabPageKeys = new System.Windows.Forms.TabPage();
			this.buttonKey = new System.Windows.Forms.Button();
			this.listViewKeys = new System.Windows.Forms.ListView();
			this.columnHeaderKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageSlices = new System.Windows.Forms.TabPage();
			this.buttonSlice = new System.Windows.Forms.Button();
			this.listViewSlices = new System.Windows.Forms.ListView();
			this.columnHeaderSlice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageSites = new System.Windows.Forms.TabPage();
			this.buttonSite = new System.Windows.Forms.Button();
			this.listViewSites = new System.Windows.Forms.ListView();
			this.columnHeaderSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageTags = new System.Windows.Forms.TabPage();
			this.buttonTag = new System.Windows.Forms.Button();
			this.listViewTags = new System.Windows.Forms.ListView();
			this.columnHeaderTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageIdentifiers.SuspendLayout();
			this.tabPageRoles.SuspendLayout();
			this.tabPageKeys.SuspendLayout();
			this.tabPageSlices.SuspendLayout();
			this.tabPageSites.SuspendLayout();
			this.tabPageTags.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFirstName.Location = new System.Drawing.Point(110, 6);
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.ReadOnly = true;
			this.textBoxFirstName.Size = new System.Drawing.Size(217, 20);
			this.textBoxFirstName.TabIndex = 1;
			// 
			// labelFirstName
			// 
			this.labelFirstName.AutoSize = true;
			this.labelFirstName.Location = new System.Drawing.Point(6, 9);
			this.labelFirstName.Name = "labelFirstName";
			this.labelFirstName.Size = new System.Drawing.Size(58, 13);
			this.labelFirstName.TabIndex = 0;
			this.labelFirstName.Text = "&First name:";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageIdentifiers);
			this.tabControl.Controls.Add(this.tabPageRoles);
			this.tabControl.Controls.Add(this.tabPageKeys);
			this.tabControl.Controls.Add(this.tabPageSlices);
			this.tabControl.Controls.Add(this.tabPageSites);
			this.tabControl.Controls.Add(this.tabPageTags);
			this.tabControl.Location = new System.Drawing.Point(6, 58);
			this.tabControl.Multiline = true;
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(341, 339);
			this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
			this.tabControl.TabIndex = 0;
			this.tabControl.Visible = false;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.AutoScroll = true;
			this.tabPageGeneral.Controls.Add(this.checkBoxEnabled);
			this.tabPageGeneral.Controls.Add(this.labelBio);
			this.tabPageGeneral.Controls.Add(this.labelUrl);
			this.tabPageGeneral.Controls.Add(this.textBoxBio);
			this.tabPageGeneral.Controls.Add(this.textBoxUrl);
			this.tabPageGeneral.Controls.Add(this.labelEmail);
			this.tabPageGeneral.Controls.Add(this.labelPhone);
			this.tabPageGeneral.Controls.Add(this.textBoxEmail);
			this.tabPageGeneral.Controls.Add(this.textBoxPhone);
			this.tabPageGeneral.Controls.Add(this.labelPersonTitle);
			this.tabPageGeneral.Controls.Add(this.textBoxTitle);
			this.tabPageGeneral.Controls.Add(this.labelLastName);
			this.tabPageGeneral.Controls.Add(this.textBoxLastName);
			this.tabPageGeneral.Controls.Add(this.labelFirstName);
			this.tabPageGeneral.Controls.Add(this.textBoxFirstName);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(333, 313);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// checkBoxEnabled
			// 
			this.checkBoxEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxEnabled.AutoSize = true;
			this.checkBoxEnabled.Enabled = false;
			this.checkBoxEnabled.Location = new System.Drawing.Point(110, 290);
			this.checkBoxEnabled.Name = "checkBoxEnabled";
			this.checkBoxEnabled.Size = new System.Drawing.Size(75, 17);
			this.checkBoxEnabled.TabIndex = 18;
			this.checkBoxEnabled.Text = "Is e&nabled";
			this.checkBoxEnabled.UseVisualStyleBackColor = true;
			// 
			// labelBio
			// 
			this.labelBio.AutoSize = true;
			this.labelBio.Location = new System.Drawing.Point(6, 189);
			this.labelBio.Name = "labelBio";
			this.labelBio.Size = new System.Drawing.Size(25, 13);
			this.labelBio.TabIndex = 12;
			this.labelBio.Text = "&Bio:";
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(6, 151);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(32, 13);
			this.labelUrl.TabIndex = 10;
			this.labelUrl.Text = "&URL:";
			// 
			// textBoxBio
			// 
			this.textBoxBio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxBio.Location = new System.Drawing.Point(110, 186);
			this.textBoxBio.Multiline = true;
			this.textBoxBio.Name = "textBoxBio";
			this.textBoxBio.ReadOnly = true;
			this.textBoxBio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxBio.Size = new System.Drawing.Size(217, 98);
			this.textBoxBio.TabIndex = 13;
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUrl.Location = new System.Drawing.Point(110, 148);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.ReadOnly = true;
			this.textBoxUrl.Size = new System.Drawing.Size(217, 20);
			this.textBoxUrl.TabIndex = 11;
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Location = new System.Drawing.Point(6, 125);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(38, 13);
			this.labelEmail.TabIndex = 8;
			this.labelEmail.Text = "&E-mail:";
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Location = new System.Drawing.Point(6, 99);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(41, 13);
			this.labelPhone.TabIndex = 6;
			this.labelPhone.Text = "&Phone:";
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxEmail.Location = new System.Drawing.Point(110, 122);
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.ReadOnly = true;
			this.textBoxEmail.Size = new System.Drawing.Size(217, 20);
			this.textBoxEmail.TabIndex = 9;
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPhone.Location = new System.Drawing.Point(110, 96);
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.ReadOnly = true;
			this.textBoxPhone.Size = new System.Drawing.Size(217, 20);
			this.textBoxPhone.TabIndex = 7;
			// 
			// labelPersonTitle
			// 
			this.labelPersonTitle.AutoSize = true;
			this.labelPersonTitle.Location = new System.Drawing.Point(6, 61);
			this.labelPersonTitle.Name = "labelPersonTitle";
			this.labelPersonTitle.Size = new System.Drawing.Size(30, 13);
			this.labelPersonTitle.TabIndex = 4;
			this.labelPersonTitle.Text = "&Title:";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTitle.Location = new System.Drawing.Point(110, 58);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.ReadOnly = true;
			this.textBoxTitle.Size = new System.Drawing.Size(217, 20);
			this.textBoxTitle.TabIndex = 5;
			// 
			// labelLastName
			// 
			this.labelLastName.AutoSize = true;
			this.labelLastName.Location = new System.Drawing.Point(6, 35);
			this.labelLastName.Name = "labelLastName";
			this.labelLastName.Size = new System.Drawing.Size(59, 13);
			this.labelLastName.TabIndex = 2;
			this.labelLastName.Text = "&Last name:";
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLastName.Location = new System.Drawing.Point(110, 32);
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.ReadOnly = true;
			this.textBoxLastName.Size = new System.Drawing.Size(217, 20);
			this.textBoxLastName.TabIndex = 3;
			// 
			// tabPageIdentifiers
			// 
			this.tabPageIdentifiers.AutoScroll = true;
			this.tabPageIdentifiers.Controls.Add(this.labelPeerId);
			this.tabPageIdentifiers.Controls.Add(this.labelPeerPersonId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxPeerId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxPeerPersonId);
			this.tabPageIdentifiers.Controls.Add(this.labelPersonId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxPersonId);
			this.tabPageIdentifiers.Location = new System.Drawing.Point(4, 22);
			this.tabPageIdentifiers.Name = "tabPageIdentifiers";
			this.tabPageIdentifiers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIdentifiers.Size = new System.Drawing.Size(333, 313);
			this.tabPageIdentifiers.TabIndex = 1;
			this.tabPageIdentifiers.Text = "Identifiers";
			this.tabPageIdentifiers.UseVisualStyleBackColor = true;
			// 
			// labelPeerId
			// 
			this.labelPeerId.AutoSize = true;
			this.labelPeerId.Location = new System.Drawing.Point(6, 35);
			this.labelPeerId.Name = "labelPeerId";
			this.labelPeerId.Size = new System.Drawing.Size(46, 13);
			this.labelPeerId.TabIndex = 4;
			this.labelPeerId.Text = "P&eer ID:";
			// 
			// labelPeerPersonId
			// 
			this.labelPeerPersonId.AutoSize = true;
			this.labelPeerPersonId.Location = new System.Drawing.Point(6, 61);
			this.labelPeerPersonId.Name = "labelPeerPersonId";
			this.labelPeerPersonId.Size = new System.Drawing.Size(81, 13);
			this.labelPeerPersonId.TabIndex = 2;
			this.labelPeerPersonId.Text = "Peer per&son ID:";
			// 
			// textBoxPeerId
			// 
			this.textBoxPeerId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPeerId.Location = new System.Drawing.Point(110, 32);
			this.textBoxPeerId.Name = "textBoxPeerId";
			this.textBoxPeerId.ReadOnly = true;
			this.textBoxPeerId.Size = new System.Drawing.Size(217, 20);
			this.textBoxPeerId.TabIndex = 5;
			// 
			// textBoxPeerPersonId
			// 
			this.textBoxPeerPersonId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPeerPersonId.Location = new System.Drawing.Point(110, 58);
			this.textBoxPeerPersonId.Name = "textBoxPeerPersonId";
			this.textBoxPeerPersonId.ReadOnly = true;
			this.textBoxPeerPersonId.Size = new System.Drawing.Size(217, 20);
			this.textBoxPeerPersonId.TabIndex = 3;
			// 
			// labelPersonId
			// 
			this.labelPersonId.AutoSize = true;
			this.labelPersonId.Location = new System.Drawing.Point(6, 9);
			this.labelPersonId.Name = "labelPersonId";
			this.labelPersonId.Size = new System.Drawing.Size(57, 13);
			this.labelPersonId.TabIndex = 0;
			this.labelPersonId.Text = "&Person ID:";
			// 
			// textBoxPersonId
			// 
			this.textBoxPersonId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPersonId.Location = new System.Drawing.Point(110, 6);
			this.textBoxPersonId.Name = "textBoxPersonId";
			this.textBoxPersonId.ReadOnly = true;
			this.textBoxPersonId.Size = new System.Drawing.Size(217, 20);
			this.textBoxPersonId.TabIndex = 1;
			// 
			// tabPageRoles
			// 
			this.tabPageRoles.Controls.Add(this.buttonRole);
			this.tabPageRoles.Controls.Add(this.listViewRoles);
			this.tabPageRoles.Location = new System.Drawing.Point(4, 22);
			this.tabPageRoles.Name = "tabPageRoles";
			this.tabPageRoles.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRoles.Size = new System.Drawing.Size(333, 313);
			this.tabPageRoles.TabIndex = 4;
			this.tabPageRoles.Text = "Roles";
			this.tabPageRoles.UseVisualStyleBackColor = true;
			// 
			// buttonRole
			// 
			this.buttonRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRole.Enabled = false;
			this.buttonRole.Location = new System.Drawing.Point(6, 284);
			this.buttonRole.Name = "buttonRole";
			this.buttonRole.Size = new System.Drawing.Size(85, 23);
			this.buttonRole.TabIndex = 2;
			this.buttonRole.Text = "Properties...";
			this.buttonRole.UseVisualStyleBackColor = true;
			this.buttonRole.Click += new System.EventHandler(this.OnRoleProperties);
			// 
			// listViewRoles
			// 
			this.listViewRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRoleId,
            this.columnHeaderRoleName});
			this.listViewRoles.FullRowSelect = true;
			this.listViewRoles.GridLines = true;
			this.listViewRoles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewRoles.HideSelection = false;
			this.listViewRoles.Location = new System.Drawing.Point(6, 6);
			this.listViewRoles.MultiSelect = false;
			this.listViewRoles.Name = "listViewRoles";
			this.listViewRoles.Size = new System.Drawing.Size(321, 272);
			this.listViewRoles.SmallImageList = this.imageList;
			this.listViewRoles.TabIndex = 1;
			this.listViewRoles.UseCompatibleStateImageBehavior = false;
			this.listViewRoles.View = System.Windows.Forms.View.Details;
			this.listViewRoles.ItemActivate += new System.EventHandler(this.OnRoleProperties);
			this.listViewRoles.SelectedIndexChanged += new System.EventHandler(this.OnRoleSelectionChanged);
			// 
			// columnHeaderRoleId
			// 
			this.columnHeaderRoleId.Text = "Role ID";
			this.columnHeaderRoleId.Width = 120;
			// 
			// columnHeaderRoleName
			// 
			this.columnHeaderRoleName.Text = "Role name";
			this.columnHeaderRoleName.Width = 120;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "ObjectSmallId");
			// 
			// tabPageKeys
			// 
			this.tabPageKeys.Controls.Add(this.buttonKey);
			this.tabPageKeys.Controls.Add(this.listViewKeys);
			this.tabPageKeys.Location = new System.Drawing.Point(4, 22);
			this.tabPageKeys.Name = "tabPageKeys";
			this.tabPageKeys.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageKeys.Size = new System.Drawing.Size(333, 313);
			this.tabPageKeys.TabIndex = 3;
			this.tabPageKeys.Text = "Keys";
			this.tabPageKeys.UseVisualStyleBackColor = true;
			// 
			// buttonKey
			// 
			this.buttonKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonKey.Enabled = false;
			this.buttonKey.Location = new System.Drawing.Point(6, 284);
			this.buttonKey.Name = "buttonKey";
			this.buttonKey.Size = new System.Drawing.Size(85, 23);
			this.buttonKey.TabIndex = 1;
			this.buttonKey.Text = "Properties...";
			this.buttonKey.UseVisualStyleBackColor = true;
			this.buttonKey.Click += new System.EventHandler(this.OnKeyProperties);
			// 
			// listViewKeys
			// 
			this.listViewKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderKey});
			this.listViewKeys.FullRowSelect = true;
			this.listViewKeys.GridLines = true;
			this.listViewKeys.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewKeys.HideSelection = false;
			this.listViewKeys.Location = new System.Drawing.Point(6, 6);
			this.listViewKeys.MultiSelect = false;
			this.listViewKeys.Name = "listViewKeys";
			this.listViewKeys.Size = new System.Drawing.Size(321, 272);
			this.listViewKeys.SmallImageList = this.imageList;
			this.listViewKeys.TabIndex = 0;
			this.listViewKeys.UseCompatibleStateImageBehavior = false;
			this.listViewKeys.View = System.Windows.Forms.View.Details;
			this.listViewKeys.ItemActivate += new System.EventHandler(this.OnKeyProperties);
			this.listViewKeys.SelectedIndexChanged += new System.EventHandler(this.OnKeySelectionChanged);
			// 
			// columnHeaderKey
			// 
			this.columnHeaderKey.Text = "Key ID";
			this.columnHeaderKey.Width = 240;
			// 
			// tabPageSlices
			// 
			this.tabPageSlices.Controls.Add(this.buttonSlice);
			this.tabPageSlices.Controls.Add(this.listViewSlices);
			this.tabPageSlices.Location = new System.Drawing.Point(4, 22);
			this.tabPageSlices.Name = "tabPageSlices";
			this.tabPageSlices.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSlices.Size = new System.Drawing.Size(333, 313);
			this.tabPageSlices.TabIndex = 7;
			this.tabPageSlices.Text = "Slices";
			this.tabPageSlices.UseVisualStyleBackColor = true;
			// 
			// buttonSlice
			// 
			this.buttonSlice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSlice.Enabled = false;
			this.buttonSlice.Location = new System.Drawing.Point(6, 284);
			this.buttonSlice.Name = "buttonSlice";
			this.buttonSlice.Size = new System.Drawing.Size(85, 23);
			this.buttonSlice.TabIndex = 3;
			this.buttonSlice.Text = "Properties...";
			this.buttonSlice.UseVisualStyleBackColor = true;
			this.buttonSlice.Click += new System.EventHandler(this.OnSliceProperties);
			// 
			// listViewSlices
			// 
			this.listViewSlices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewSlices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSlice});
			this.listViewSlices.FullRowSelect = true;
			this.listViewSlices.GridLines = true;
			this.listViewSlices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewSlices.HideSelection = false;
			this.listViewSlices.Location = new System.Drawing.Point(6, 6);
			this.listViewSlices.MultiSelect = false;
			this.listViewSlices.Name = "listViewSlices";
			this.listViewSlices.Size = new System.Drawing.Size(321, 272);
			this.listViewSlices.SmallImageList = this.imageList;
			this.listViewSlices.TabIndex = 2;
			this.listViewSlices.UseCompatibleStateImageBehavior = false;
			this.listViewSlices.View = System.Windows.Forms.View.Details;
			this.listViewSlices.ItemActivate += new System.EventHandler(this.OnSliceProperties);
			this.listViewSlices.SelectedIndexChanged += new System.EventHandler(this.OnSliceSelectionChanged);
			// 
			// columnHeaderSlice
			// 
			this.columnHeaderSlice.Text = "Slice ID";
			this.columnHeaderSlice.Width = 240;
			// 
			// tabPageSites
			// 
			this.tabPageSites.Controls.Add(this.buttonSite);
			this.tabPageSites.Controls.Add(this.listViewSites);
			this.tabPageSites.Location = new System.Drawing.Point(4, 22);
			this.tabPageSites.Name = "tabPageSites";
			this.tabPageSites.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSites.Size = new System.Drawing.Size(333, 313);
			this.tabPageSites.TabIndex = 6;
			this.tabPageSites.Text = "Sites";
			this.tabPageSites.UseVisualStyleBackColor = true;
			// 
			// buttonSite
			// 
			this.buttonSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSite.Enabled = false;
			this.buttonSite.Location = new System.Drawing.Point(6, 284);
			this.buttonSite.Name = "buttonSite";
			this.buttonSite.Size = new System.Drawing.Size(85, 23);
			this.buttonSite.TabIndex = 4;
			this.buttonSite.Text = "Properties...";
			this.buttonSite.UseVisualStyleBackColor = true;
			this.buttonSite.Click += new System.EventHandler(this.OnSiteProperties);
			// 
			// listViewSites
			// 
			this.listViewSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSite});
			this.listViewSites.FullRowSelect = true;
			this.listViewSites.GridLines = true;
			this.listViewSites.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewSites.HideSelection = false;
			this.listViewSites.Location = new System.Drawing.Point(6, 6);
			this.listViewSites.MultiSelect = false;
			this.listViewSites.Name = "listViewSites";
			this.listViewSites.Size = new System.Drawing.Size(321, 272);
			this.listViewSites.SmallImageList = this.imageList;
			this.listViewSites.TabIndex = 3;
			this.listViewSites.UseCompatibleStateImageBehavior = false;
			this.listViewSites.View = System.Windows.Forms.View.Details;
			this.listViewSites.ItemActivate += new System.EventHandler(this.OnSiteProperties);
			this.listViewSites.SelectedIndexChanged += new System.EventHandler(this.OnSiteSelectionChanged);
			// 
			// columnHeaderSite
			// 
			this.columnHeaderSite.Text = "Site ID";
			this.columnHeaderSite.Width = 240;
			// 
			// tabPageTags
			// 
			this.tabPageTags.Controls.Add(this.buttonTag);
			this.tabPageTags.Controls.Add(this.listViewTags);
			this.tabPageTags.Location = new System.Drawing.Point(4, 22);
			this.tabPageTags.Name = "tabPageTags";
			this.tabPageTags.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTags.Size = new System.Drawing.Size(333, 313);
			this.tabPageTags.TabIndex = 5;
			this.tabPageTags.Text = "Tags";
			this.tabPageTags.UseVisualStyleBackColor = true;
			// 
			// buttonTag
			// 
			this.buttonTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonTag.Enabled = false;
			this.buttonTag.Location = new System.Drawing.Point(6, 284);
			this.buttonTag.Name = "buttonTag";
			this.buttonTag.Size = new System.Drawing.Size(85, 23);
			this.buttonTag.TabIndex = 3;
			this.buttonTag.Text = "Properties...";
			this.buttonTag.UseVisualStyleBackColor = true;
			this.buttonTag.Click += new System.EventHandler(this.OnTagProperties);
			// 
			// listViewTags
			// 
			this.listViewTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTag});
			this.listViewTags.FullRowSelect = true;
			this.listViewTags.GridLines = true;
			this.listViewTags.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewTags.HideSelection = false;
			this.listViewTags.Location = new System.Drawing.Point(6, 6);
			this.listViewTags.MultiSelect = false;
			this.listViewTags.Name = "listViewTags";
			this.listViewTags.Size = new System.Drawing.Size(321, 272);
			this.listViewTags.SmallImageList = this.imageList;
			this.listViewTags.TabIndex = 2;
			this.listViewTags.UseCompatibleStateImageBehavior = false;
			this.listViewTags.View = System.Windows.Forms.View.Details;
			this.listViewTags.ItemActivate += new System.EventHandler(this.OnTagProperties);
			this.listViewTags.SelectedIndexChanged += new System.EventHandler(this.OnTagSelectionChanged);
			// 
			// columnHeaderTag
			// 
			this.columnHeaderTag.Text = "Tag ID";
			this.columnHeaderTag.Width = 240;
			// 
			// ControlPlanetLabPersonProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Name = "ControlPlanetLabPersonProperties";
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageIdentifiers.ResumeLayout(false);
			this.tabPageIdentifiers.PerformLayout();
			this.tabPageRoles.ResumeLayout(false);
			this.tabPageKeys.ResumeLayout(false);
			this.tabPageSlices.ResumeLayout(false);
			this.tabPageSites.ResumeLayout(false);
			this.tabPageTags.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxFirstName;
		private System.Windows.Forms.Label labelFirstName;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelLastName;
		private System.Windows.Forms.TextBox textBoxLastName;
		private System.Windows.Forms.Label labelPersonTitle;
		private System.Windows.Forms.TextBox textBoxPhone;
		private System.Windows.Forms.TextBox textBoxTitle;
		private System.Windows.Forms.TextBox textBoxEmail;
		private System.Windows.Forms.Label labelEmail;
		private System.Windows.Forms.Label labelPhone;
		private System.Windows.Forms.TextBox textBoxBio;
		private System.Windows.Forms.TextBox textBoxUrl;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.Label labelBio;
		private System.Windows.Forms.TabPage tabPageIdentifiers;
		private System.Windows.Forms.Label labelPersonId;
		private System.Windows.Forms.TextBox textBoxPersonId;
		private System.Windows.Forms.TextBox textBoxPeerPersonId;
		private System.Windows.Forms.TextBox textBoxPeerId;
		private System.Windows.Forms.Label labelPeerPersonId;
		private System.Windows.Forms.Label labelPeerId;
		private System.Windows.Forms.TabPage tabPageKeys;
		private System.Windows.Forms.ListView listViewKeys;
		private System.Windows.Forms.ColumnHeader columnHeaderKey;
		private System.Windows.Forms.Button buttonKey;
		private System.Windows.Forms.TabPage tabPageRoles;
		private System.Windows.Forms.TabPage tabPageTags;
		private System.Windows.Forms.TabPage tabPageSites;
		private System.Windows.Forms.ListView listViewRoles;
		private System.Windows.Forms.ColumnHeader columnHeaderRoleId;
		private System.Windows.Forms.Button buttonRole;
		private System.Windows.Forms.Button buttonTag;
		private System.Windows.Forms.ListView listViewTags;
		private System.Windows.Forms.ColumnHeader columnHeaderTag;
		private System.Windows.Forms.Button buttonSite;
		private System.Windows.Forms.ListView listViewSites;
		private System.Windows.Forms.ColumnHeader columnHeaderSite;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.CheckBox checkBoxEnabled;
		private System.Windows.Forms.ColumnHeader columnHeaderRoleName;
		private System.Windows.Forms.TabPage tabPageSlices;
		private System.Windows.Forms.Button buttonSlice;
		private System.Windows.Forms.ListView listViewSlices;
		private System.Windows.Forms.ColumnHeader columnHeaderSlice;
	}
}
