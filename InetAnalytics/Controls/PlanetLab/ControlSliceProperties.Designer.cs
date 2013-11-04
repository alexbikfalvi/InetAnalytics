namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlSliceProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSliceProperties));
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.labelMaxNodes = new System.Windows.Forms.Label();
			this.labelExpires = new System.Windows.Forms.Label();
			this.textBoxMaxNodes = new System.Windows.Forms.TextBox();
			this.textBoxExpires = new System.Windows.Forms.TextBox();
			this.labelCreated = new System.Windows.Forms.Label();
			this.labelUrl = new System.Windows.Forms.Label();
			this.textBoxCreated = new System.Windows.Forms.TextBox();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.labelInstantiation = new System.Windows.Forms.Label();
			this.textBoxInstantiation = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.tabPageIdentifiers = new System.Windows.Forms.TabPage();
			this.labelCreatorPersonId = new System.Windows.Forms.Label();
			this.textBoxCreatorPersonId = new System.Windows.Forms.TextBox();
			this.labelPeerSliceId = new System.Windows.Forms.Label();
			this.labelPeerId = new System.Windows.Forms.Label();
			this.labelSiteId = new System.Windows.Forms.Label();
			this.textBoxPeerSliceId = new System.Windows.Forms.TextBox();
			this.textBoxPeerId = new System.Windows.Forms.TextBox();
			this.textBoxSiteId = new System.Windows.Forms.TextBox();
			this.labelSliceId = new System.Windows.Forms.Label();
			this.textBoxSliceId = new System.Windows.Forms.TextBox();
			this.tabPageNodes = new System.Windows.Forms.TabPage();
			this.buttonNode = new System.Windows.Forms.Button();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnHeaderNode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabPagePersons = new System.Windows.Forms.TabPage();
			this.buttonPerson = new System.Windows.Forms.Button();
			this.listViewPersons = new System.Windows.Forms.ListView();
			this.columnHeaderPerson = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageIdentifiers.SuspendLayout();
			this.tabPageNodes.SuspendLayout();
			this.tabPagePersons.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Location = new System.Drawing.Point(110, 6);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.ReadOnly = true;
			this.textBoxName.Size = new System.Drawing.Size(217, 20);
			this.textBoxName.TabIndex = 1;
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
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageIdentifiers);
			this.tabControl.Controls.Add(this.tabPageNodes);
			this.tabControl.Controls.Add(this.tabPagePersons);
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
			this.tabPageGeneral.Controls.Add(this.labelMaxNodes);
			this.tabPageGeneral.Controls.Add(this.labelExpires);
			this.tabPageGeneral.Controls.Add(this.textBoxMaxNodes);
			this.tabPageGeneral.Controls.Add(this.textBoxExpires);
			this.tabPageGeneral.Controls.Add(this.labelCreated);
			this.tabPageGeneral.Controls.Add(this.labelUrl);
			this.tabPageGeneral.Controls.Add(this.textBoxCreated);
			this.tabPageGeneral.Controls.Add(this.textBoxUrl);
			this.tabPageGeneral.Controls.Add(this.labelInstantiation);
			this.tabPageGeneral.Controls.Add(this.textBoxInstantiation);
			this.tabPageGeneral.Controls.Add(this.labelDescription);
			this.tabPageGeneral.Controls.Add(this.textBoxDescription);
			this.tabPageGeneral.Controls.Add(this.labelName);
			this.tabPageGeneral.Controls.Add(this.textBoxName);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(333, 313);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// labelMaxNodes
			// 
			this.labelMaxNodes.AutoSize = true;
			this.labelMaxNodes.Location = new System.Drawing.Point(6, 189);
			this.labelMaxNodes.Name = "labelMaxNodes";
			this.labelMaxNodes.Size = new System.Drawing.Size(86, 13);
			this.labelMaxNodes.TabIndex = 12;
			this.labelMaxNodes.Text = "&Maximum nodes:";
			// 
			// labelExpires
			// 
			this.labelExpires.AutoSize = true;
			this.labelExpires.Location = new System.Drawing.Point(6, 151);
			this.labelExpires.Name = "labelExpires";
			this.labelExpires.Size = new System.Drawing.Size(44, 13);
			this.labelExpires.TabIndex = 10;
			this.labelExpires.Text = "&Expires:";
			// 
			// textBoxMaxNodes
			// 
			this.textBoxMaxNodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMaxNodes.Location = new System.Drawing.Point(110, 186);
			this.textBoxMaxNodes.Name = "textBoxMaxNodes";
			this.textBoxMaxNodes.ReadOnly = true;
			this.textBoxMaxNodes.Size = new System.Drawing.Size(217, 20);
			this.textBoxMaxNodes.TabIndex = 13;
			// 
			// textBoxExpires
			// 
			this.textBoxExpires.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxExpires.Location = new System.Drawing.Point(110, 148);
			this.textBoxExpires.Name = "textBoxExpires";
			this.textBoxExpires.ReadOnly = true;
			this.textBoxExpires.Size = new System.Drawing.Size(217, 20);
			this.textBoxExpires.TabIndex = 11;
			// 
			// labelCreated
			// 
			this.labelCreated.AutoSize = true;
			this.labelCreated.Location = new System.Drawing.Point(6, 125);
			this.labelCreated.Name = "labelCreated";
			this.labelCreated.Size = new System.Drawing.Size(47, 13);
			this.labelCreated.TabIndex = 8;
			this.labelCreated.Text = "&Created:";
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(6, 87);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(32, 13);
			this.labelUrl.TabIndex = 6;
			this.labelUrl.Text = "&URL:";
			// 
			// textBoxCreated
			// 
			this.textBoxCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCreated.Location = new System.Drawing.Point(110, 122);
			this.textBoxCreated.Name = "textBoxCreated";
			this.textBoxCreated.ReadOnly = true;
			this.textBoxCreated.Size = new System.Drawing.Size(217, 20);
			this.textBoxCreated.TabIndex = 9;
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUrl.Location = new System.Drawing.Point(110, 84);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.ReadOnly = true;
			this.textBoxUrl.Size = new System.Drawing.Size(217, 20);
			this.textBoxUrl.TabIndex = 7;
			// 
			// labelInstantiation
			// 
			this.labelInstantiation.AutoSize = true;
			this.labelInstantiation.Location = new System.Drawing.Point(6, 61);
			this.labelInstantiation.Name = "labelInstantiation";
			this.labelInstantiation.Size = new System.Drawing.Size(67, 13);
			this.labelInstantiation.TabIndex = 4;
			this.labelInstantiation.Text = "&Instantiation:";
			// 
			// textBoxInstantiation
			// 
			this.textBoxInstantiation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInstantiation.Location = new System.Drawing.Point(110, 58);
			this.textBoxInstantiation.Name = "textBoxInstantiation";
			this.textBoxInstantiation.ReadOnly = true;
			this.textBoxInstantiation.Size = new System.Drawing.Size(217, 20);
			this.textBoxInstantiation.TabIndex = 5;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(6, 35);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(63, 13);
			this.labelDescription.TabIndex = 2;
			this.labelDescription.Text = "&Description:";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDescription.Location = new System.Drawing.Point(110, 32);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.Size = new System.Drawing.Size(217, 20);
			this.textBoxDescription.TabIndex = 3;
			// 
			// tabPageIdentifiers
			// 
			this.tabPageIdentifiers.AutoScroll = true;
			this.tabPageIdentifiers.Controls.Add(this.labelCreatorPersonId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxCreatorPersonId);
			this.tabPageIdentifiers.Controls.Add(this.labelPeerSliceId);
			this.tabPageIdentifiers.Controls.Add(this.labelPeerId);
			this.tabPageIdentifiers.Controls.Add(this.labelSiteId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxPeerSliceId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxPeerId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxSiteId);
			this.tabPageIdentifiers.Controls.Add(this.labelSliceId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxSliceId);
			this.tabPageIdentifiers.Location = new System.Drawing.Point(4, 22);
			this.tabPageIdentifiers.Name = "tabPageIdentifiers";
			this.tabPageIdentifiers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIdentifiers.Size = new System.Drawing.Size(333, 313);
			this.tabPageIdentifiers.TabIndex = 1;
			this.tabPageIdentifiers.Text = "Identifiers";
			this.tabPageIdentifiers.UseVisualStyleBackColor = true;
			// 
			// labelCreatorPersonId
			// 
			this.labelCreatorPersonId.AutoSize = true;
			this.labelCreatorPersonId.Location = new System.Drawing.Point(6, 113);
			this.labelCreatorPersonId.Name = "labelCreatorPersonId";
			this.labelCreatorPersonId.Size = new System.Drawing.Size(93, 13);
			this.labelCreatorPersonId.TabIndex = 9;
			this.labelCreatorPersonId.Text = "&Creator person ID:";
			// 
			// textBoxCreatorPersonId
			// 
			this.textBoxCreatorPersonId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCreatorPersonId.Location = new System.Drawing.Point(110, 110);
			this.textBoxCreatorPersonId.Name = "textBoxCreatorPersonId";
			this.textBoxCreatorPersonId.ReadOnly = true;
			this.textBoxCreatorPersonId.Size = new System.Drawing.Size(217, 20);
			this.textBoxCreatorPersonId.TabIndex = 8;
			// 
			// labelPeerSliceId
			// 
			this.labelPeerSliceId.AutoSize = true;
			this.labelPeerSliceId.Location = new System.Drawing.Point(6, 87);
			this.labelPeerSliceId.Name = "labelPeerSliceId";
			this.labelPeerSliceId.Size = new System.Drawing.Size(70, 13);
			this.labelPeerSliceId.TabIndex = 6;
			this.labelPeerSliceId.Text = "Pee&r slice ID:";
			// 
			// labelPeerId
			// 
			this.labelPeerId.AutoSize = true;
			this.labelPeerId.Location = new System.Drawing.Point(6, 61);
			this.labelPeerId.Name = "labelPeerId";
			this.labelPeerId.Size = new System.Drawing.Size(46, 13);
			this.labelPeerId.TabIndex = 4;
			this.labelPeerId.Text = "&Peer ID:";
			// 
			// labelSiteId
			// 
			this.labelSiteId.AutoSize = true;
			this.labelSiteId.Location = new System.Drawing.Point(6, 35);
			this.labelSiteId.Name = "labelSiteId";
			this.labelSiteId.Size = new System.Drawing.Size(42, 13);
			this.labelSiteId.TabIndex = 2;
			this.labelSiteId.Text = "Si&te ID:";
			// 
			// textBoxPeerSliceId
			// 
			this.textBoxPeerSliceId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPeerSliceId.Location = new System.Drawing.Point(110, 84);
			this.textBoxPeerSliceId.Name = "textBoxPeerSliceId";
			this.textBoxPeerSliceId.ReadOnly = true;
			this.textBoxPeerSliceId.Size = new System.Drawing.Size(217, 20);
			this.textBoxPeerSliceId.TabIndex = 7;
			// 
			// textBoxPeerId
			// 
			this.textBoxPeerId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPeerId.Location = new System.Drawing.Point(110, 58);
			this.textBoxPeerId.Name = "textBoxPeerId";
			this.textBoxPeerId.ReadOnly = true;
			this.textBoxPeerId.Size = new System.Drawing.Size(217, 20);
			this.textBoxPeerId.TabIndex = 5;
			// 
			// textBoxSiteId
			// 
			this.textBoxSiteId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSiteId.Location = new System.Drawing.Point(110, 32);
			this.textBoxSiteId.Name = "textBoxSiteId";
			this.textBoxSiteId.ReadOnly = true;
			this.textBoxSiteId.Size = new System.Drawing.Size(217, 20);
			this.textBoxSiteId.TabIndex = 3;
			// 
			// labelSliceId
			// 
			this.labelSliceId.AutoSize = true;
			this.labelSliceId.Location = new System.Drawing.Point(6, 9);
			this.labelSliceId.Name = "labelSliceId";
			this.labelSliceId.Size = new System.Drawing.Size(47, 13);
			this.labelSliceId.TabIndex = 0;
			this.labelSliceId.Text = "&Slice ID:";
			// 
			// textBoxSliceId
			// 
			this.textBoxSliceId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSliceId.Location = new System.Drawing.Point(110, 6);
			this.textBoxSliceId.Name = "textBoxSliceId";
			this.textBoxSliceId.ReadOnly = true;
			this.textBoxSliceId.Size = new System.Drawing.Size(217, 20);
			this.textBoxSliceId.TabIndex = 1;
			// 
			// tabPageNodes
			// 
			this.tabPageNodes.Controls.Add(this.buttonNode);
			this.tabPageNodes.Controls.Add(this.listViewNodes);
			this.tabPageNodes.Location = new System.Drawing.Point(4, 22);
			this.tabPageNodes.Name = "tabPageNodes";
			this.tabPageNodes.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageNodes.Size = new System.Drawing.Size(333, 313);
			this.tabPageNodes.TabIndex = 4;
			this.tabPageNodes.Text = "Nodes";
			this.tabPageNodes.UseVisualStyleBackColor = true;
			// 
			// buttonNode
			// 
			this.buttonNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonNode.Enabled = false;
			this.buttonNode.Location = new System.Drawing.Point(6, 284);
			this.buttonNode.Name = "buttonNode";
			this.buttonNode.Size = new System.Drawing.Size(85, 23);
			this.buttonNode.TabIndex = 2;
			this.buttonNode.Text = "Properties...";
			this.buttonNode.UseVisualStyleBackColor = true;
			this.buttonNode.Click += new System.EventHandler(this.OnNodeProperties);
			// 
			// listViewNodes
			// 
			this.listViewNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNode});
			this.listViewNodes.FullRowSelect = true;
			this.listViewNodes.GridLines = true;
			this.listViewNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewNodes.HideSelection = false;
			this.listViewNodes.Location = new System.Drawing.Point(6, 6);
			this.listViewNodes.MultiSelect = false;
			this.listViewNodes.Name = "listViewNodes";
			this.listViewNodes.Size = new System.Drawing.Size(321, 272);
			this.listViewNodes.SmallImageList = this.imageList;
			this.listViewNodes.TabIndex = 1;
			this.listViewNodes.UseCompatibleStateImageBehavior = false;
			this.listViewNodes.View = System.Windows.Forms.View.Details;
			this.listViewNodes.ItemActivate += new System.EventHandler(this.OnNodeProperties);
			this.listViewNodes.SelectedIndexChanged += new System.EventHandler(this.OnNodeSelectionChanged);
			// 
			// columnHeaderNode
			// 
			this.columnHeaderNode.Text = "Node ID";
			this.columnHeaderNode.Width = 240;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "ObjectSmallId");
			// 
			// tabPagePersons
			// 
			this.tabPagePersons.Controls.Add(this.buttonPerson);
			this.tabPagePersons.Controls.Add(this.listViewPersons);
			this.tabPagePersons.Location = new System.Drawing.Point(4, 22);
			this.tabPagePersons.Name = "tabPagePersons";
			this.tabPagePersons.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePersons.Size = new System.Drawing.Size(333, 313);
			this.tabPagePersons.TabIndex = 3;
			this.tabPagePersons.Text = "Persons";
			this.tabPagePersons.UseVisualStyleBackColor = true;
			// 
			// buttonPerson
			// 
			this.buttonPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonPerson.Enabled = false;
			this.buttonPerson.Location = new System.Drawing.Point(6, 284);
			this.buttonPerson.Name = "buttonPerson";
			this.buttonPerson.Size = new System.Drawing.Size(85, 23);
			this.buttonPerson.TabIndex = 1;
			this.buttonPerson.Text = "Properties...";
			this.buttonPerson.UseVisualStyleBackColor = true;
			this.buttonPerson.Click += new System.EventHandler(this.OnPersonProperties);
			// 
			// listViewPersons
			// 
			this.listViewPersons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewPersons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPerson});
			this.listViewPersons.FullRowSelect = true;
			this.listViewPersons.GridLines = true;
			this.listViewPersons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewPersons.HideSelection = false;
			this.listViewPersons.Location = new System.Drawing.Point(6, 6);
			this.listViewPersons.MultiSelect = false;
			this.listViewPersons.Name = "listViewPersons";
			this.listViewPersons.Size = new System.Drawing.Size(321, 272);
			this.listViewPersons.SmallImageList = this.imageList;
			this.listViewPersons.TabIndex = 0;
			this.listViewPersons.UseCompatibleStateImageBehavior = false;
			this.listViewPersons.View = System.Windows.Forms.View.Details;
			this.listViewPersons.ItemActivate += new System.EventHandler(this.OnPersonProperties);
			this.listViewPersons.SelectedIndexChanged += new System.EventHandler(this.OnPersonSelectionChanged);
			// 
			// columnHeaderPerson
			// 
			this.columnHeaderPerson.Text = "Person ID";
			this.columnHeaderPerson.Width = 240;
			// 
			// ControlPlanetLabSliceProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Name = "ControlPlanetLabSliceProperties";
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageIdentifiers.ResumeLayout(false);
			this.tabPageIdentifiers.PerformLayout();
			this.tabPageNodes.ResumeLayout(false);
			this.tabPagePersons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Label labelInstantiation;
		private System.Windows.Forms.TextBox textBoxUrl;
		private System.Windows.Forms.TextBox textBoxInstantiation;
		private System.Windows.Forms.TextBox textBoxCreated;
		private System.Windows.Forms.Label labelCreated;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.TextBox textBoxMaxNodes;
		private System.Windows.Forms.TextBox textBoxExpires;
		private System.Windows.Forms.Label labelExpires;
		private System.Windows.Forms.Label labelMaxNodes;
		private System.Windows.Forms.TabPage tabPageIdentifiers;
		private System.Windows.Forms.Label labelSliceId;
		private System.Windows.Forms.TextBox textBoxSliceId;
		private System.Windows.Forms.TextBox textBoxSiteId;
		private System.Windows.Forms.TextBox textBoxPeerId;
		private System.Windows.Forms.TextBox textBoxPeerSliceId;
		private System.Windows.Forms.Label labelSiteId;
		private System.Windows.Forms.Label labelPeerId;
		private System.Windows.Forms.Label labelPeerSliceId;
		private System.Windows.Forms.TabPage tabPagePersons;
		private System.Windows.Forms.ListView listViewPersons;
		private System.Windows.Forms.ColumnHeader columnHeaderPerson;
		private System.Windows.Forms.Button buttonPerson;
		private System.Windows.Forms.TabPage tabPageNodes;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderNode;
		private System.Windows.Forms.Button buttonNode;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Label labelCreatorPersonId;
		private System.Windows.Forms.TextBox textBoxCreatorPersonId;
	}
}
