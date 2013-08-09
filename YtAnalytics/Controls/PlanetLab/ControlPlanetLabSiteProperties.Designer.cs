namespace YtAnalytics.Controls.PlanetLab
{
	partial class ControlPlanetLabSiteProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPlanetLabSiteProperties));
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.checkBoxIsEnabled = new System.Windows.Forms.CheckBox();
			this.checkBoxIsPublic = new System.Windows.Forms.CheckBox();
			this.labelMaxSlivers = new System.Windows.Forms.Label();
			this.labelMaxSlices = new System.Windows.Forms.Label();
			this.textBoxMaxSlivers = new System.Windows.Forms.TextBox();
			this.textBoxMaxSlices = new System.Windows.Forms.TextBox();
			this.labelLastUpdated = new System.Windows.Forms.Label();
			this.labelDateCreated = new System.Windows.Forms.Label();
			this.textBoxLastUpdated = new System.Windows.Forms.TextBox();
			this.labelLoginBase = new System.Windows.Forms.Label();
			this.textBoxLoginBase = new System.Windows.Forms.TextBox();
			this.textBoxDateCreated = new System.Windows.Forms.TextBox();
			this.labelUrl = new System.Windows.Forms.Label();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.labelAbbreviatedName = new System.Windows.Forms.Label();
			this.textBoxAbbreviatedName = new System.Windows.Forms.TextBox();
			this.tabPageIdentifiers = new System.Windows.Forms.TabPage();
			this.labelPeerSiteId = new System.Windows.Forms.Label();
			this.labelExtConsortiumId = new System.Windows.Forms.Label();
			this.labelPeerId = new System.Windows.Forms.Label();
			this.textBoxPeerSiteId = new System.Windows.Forms.TextBox();
			this.textBoxExtConsortiumId = new System.Windows.Forms.TextBox();
			this.textBoxPeerId = new System.Windows.Forms.TextBox();
			this.labelSiteId = new System.Windows.Forms.Label();
			this.textBoxSiteId = new System.Windows.Forms.TextBox();
			this.tabPageLocation = new System.Windows.Forms.TabPage();
			this.worldMap = new DotNetApi.Windows.Controls.GeoWorldMap();
			this.labelLongitude = new System.Windows.Forms.Label();
			this.textBoxLongitude = new System.Windows.Forms.TextBox();
			this.labelLatitude = new System.Windows.Forms.Label();
			this.textBoxLatitude = new System.Windows.Forms.TextBox();
			this.tabPageNodes = new System.Windows.Forms.TabPage();
			this.buttonNode = new System.Windows.Forms.Button();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnHeaderNode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabPagePcus = new System.Windows.Forms.TabPage();
			this.buttonPcu = new System.Windows.Forms.Button();
			this.listViewPcus = new System.Windows.Forms.ListView();
			this.columnHeaderPcu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPagePersons = new System.Windows.Forms.TabPage();
			this.buttonPerson = new System.Windows.Forms.Button();
			this.listViewPersons = new System.Windows.Forms.ListView();
			this.columnHeaderPerson = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageSlices = new System.Windows.Forms.TabPage();
			this.buttonSlice = new System.Windows.Forms.Button();
			this.listViewSlices = new System.Windows.Forms.ListView();
			this.columnHeaderSlice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageAddresses = new System.Windows.Forms.TabPage();
			this.buttonAddress = new System.Windows.Forms.Button();
			this.listViewAddresses = new System.Windows.Forms.ListView();
			this.columnHeaderAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageTags = new System.Windows.Forms.TabPage();
			this.buttonTag = new System.Windows.Forms.Button();
			this.listViewTags = new System.Windows.Forms.ListView();
			this.columnHeaderTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageIdentifiers.SuspendLayout();
			this.tabPageLocation.SuspendLayout();
			this.tabPageNodes.SuspendLayout();
			this.tabPagePcus.SuspendLayout();
			this.tabPagePersons.SuspendLayout();
			this.tabPageSlices.SuspendLayout();
			this.tabPageAddresses.SuspendLayout();
			this.tabPageTags.SuspendLayout();
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
			this.tabControl.Controls.Add(this.tabPageLocation);
			this.tabControl.Controls.Add(this.tabPageNodes);
			this.tabControl.Controls.Add(this.tabPagePcus);
			this.tabControl.Controls.Add(this.tabPagePersons);
			this.tabControl.Controls.Add(this.tabPageSlices);
			this.tabControl.Controls.Add(this.tabPageAddresses);
			this.tabControl.Controls.Add(this.tabPageTags);
			this.tabControl.Location = new System.Drawing.Point(6, 58);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(341, 339);
			this.tabControl.TabIndex = 0;
			this.tabControl.Visible = false;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.AutoScroll = true;
			this.tabPageGeneral.Controls.Add(this.checkBoxIsEnabled);
			this.tabPageGeneral.Controls.Add(this.checkBoxIsPublic);
			this.tabPageGeneral.Controls.Add(this.labelMaxSlivers);
			this.tabPageGeneral.Controls.Add(this.labelMaxSlices);
			this.tabPageGeneral.Controls.Add(this.textBoxMaxSlivers);
			this.tabPageGeneral.Controls.Add(this.textBoxMaxSlices);
			this.tabPageGeneral.Controls.Add(this.labelLastUpdated);
			this.tabPageGeneral.Controls.Add(this.labelDateCreated);
			this.tabPageGeneral.Controls.Add(this.textBoxLastUpdated);
			this.tabPageGeneral.Controls.Add(this.labelLoginBase);
			this.tabPageGeneral.Controls.Add(this.textBoxLoginBase);
			this.tabPageGeneral.Controls.Add(this.textBoxDateCreated);
			this.tabPageGeneral.Controls.Add(this.labelUrl);
			this.tabPageGeneral.Controls.Add(this.textBoxUrl);
			this.tabPageGeneral.Controls.Add(this.labelAbbreviatedName);
			this.tabPageGeneral.Controls.Add(this.textBoxAbbreviatedName);
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
			// checkBoxIsEnabled
			// 
			this.checkBoxIsEnabled.AutoSize = true;
			this.checkBoxIsEnabled.Enabled = false;
			this.checkBoxIsEnabled.Location = new System.Drawing.Point(110, 261);
			this.checkBoxIsEnabled.Name = "checkBoxIsEnabled";
			this.checkBoxIsEnabled.Size = new System.Drawing.Size(65, 17);
			this.checkBoxIsEnabled.TabIndex = 17;
			this.checkBoxIsEnabled.Text = "Enabled";
			this.checkBoxIsEnabled.UseVisualStyleBackColor = true;
			// 
			// checkBoxIsPublic
			// 
			this.checkBoxIsPublic.AutoSize = true;
			this.checkBoxIsPublic.Enabled = false;
			this.checkBoxIsPublic.Location = new System.Drawing.Point(110, 238);
			this.checkBoxIsPublic.Name = "checkBoxIsPublic";
			this.checkBoxIsPublic.Size = new System.Drawing.Size(55, 17);
			this.checkBoxIsPublic.TabIndex = 16;
			this.checkBoxIsPublic.Text = "Public";
			this.checkBoxIsPublic.UseVisualStyleBackColor = true;
			// 
			// labelMaxSlivers
			// 
			this.labelMaxSlivers.AutoSize = true;
			this.labelMaxSlivers.Location = new System.Drawing.Point(6, 215);
			this.labelMaxSlivers.Name = "labelMaxSlivers";
			this.labelMaxSlivers.Size = new System.Drawing.Size(86, 13);
			this.labelMaxSlivers.TabIndex = 14;
			this.labelMaxSlivers.Text = "Maxi&mum slivers:";
			// 
			// labelMaxSlices
			// 
			this.labelMaxSlices.AutoSize = true;
			this.labelMaxSlices.Location = new System.Drawing.Point(6, 189);
			this.labelMaxSlices.Name = "labelMaxSlices";
			this.labelMaxSlices.Size = new System.Drawing.Size(83, 13);
			this.labelMaxSlices.TabIndex = 12;
			this.labelMaxSlices.Text = "Ma&ximum slices:";
			// 
			// textBoxMaxSlivers
			// 
			this.textBoxMaxSlivers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMaxSlivers.Location = new System.Drawing.Point(110, 212);
			this.textBoxMaxSlivers.Name = "textBoxMaxSlivers";
			this.textBoxMaxSlivers.ReadOnly = true;
			this.textBoxMaxSlivers.Size = new System.Drawing.Size(217, 20);
			this.textBoxMaxSlivers.TabIndex = 15;
			// 
			// textBoxMaxSlices
			// 
			this.textBoxMaxSlices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMaxSlices.Location = new System.Drawing.Point(110, 186);
			this.textBoxMaxSlices.Name = "textBoxMaxSlices";
			this.textBoxMaxSlices.ReadOnly = true;
			this.textBoxMaxSlices.Size = new System.Drawing.Size(217, 20);
			this.textBoxMaxSlices.TabIndex = 13;
			// 
			// labelLastUpdated
			// 
			this.labelLastUpdated.AutoSize = true;
			this.labelLastUpdated.Location = new System.Drawing.Point(6, 151);
			this.labelLastUpdated.Name = "labelLastUpdated";
			this.labelLastUpdated.Size = new System.Drawing.Size(72, 13);
			this.labelLastUpdated.TabIndex = 10;
			this.labelLastUpdated.Text = "Last up&dated:";
			// 
			// labelDateCreated
			// 
			this.labelDateCreated.AutoSize = true;
			this.labelDateCreated.Location = new System.Drawing.Point(6, 125);
			this.labelDateCreated.Name = "labelDateCreated";
			this.labelDateCreated.Size = new System.Drawing.Size(72, 13);
			this.labelDateCreated.TabIndex = 8;
			this.labelDateCreated.Text = "Date &created:";
			// 
			// textBoxLastUpdated
			// 
			this.textBoxLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLastUpdated.Location = new System.Drawing.Point(110, 148);
			this.textBoxLastUpdated.Name = "textBoxLastUpdated";
			this.textBoxLastUpdated.ReadOnly = true;
			this.textBoxLastUpdated.Size = new System.Drawing.Size(217, 20);
			this.textBoxLastUpdated.TabIndex = 11;
			// 
			// labelLoginBase
			// 
			this.labelLoginBase.AutoSize = true;
			this.labelLoginBase.Location = new System.Drawing.Point(6, 87);
			this.labelLoginBase.Name = "labelLoginBase";
			this.labelLoginBase.Size = new System.Drawing.Size(62, 13);
			this.labelLoginBase.TabIndex = 6;
			this.labelLoginBase.Text = "&Login base:";
			// 
			// textBoxLoginBase
			// 
			this.textBoxLoginBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLoginBase.Location = new System.Drawing.Point(110, 84);
			this.textBoxLoginBase.Name = "textBoxLoginBase";
			this.textBoxLoginBase.ReadOnly = true;
			this.textBoxLoginBase.Size = new System.Drawing.Size(217, 20);
			this.textBoxLoginBase.TabIndex = 7;
			// 
			// textBoxDateCreated
			// 
			this.textBoxDateCreated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDateCreated.Location = new System.Drawing.Point(110, 122);
			this.textBoxDateCreated.Name = "textBoxDateCreated";
			this.textBoxDateCreated.ReadOnly = true;
			this.textBoxDateCreated.Size = new System.Drawing.Size(217, 20);
			this.textBoxDateCreated.TabIndex = 9;
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(6, 61);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(32, 13);
			this.labelUrl.TabIndex = 4;
			this.labelUrl.Text = "&URL:";
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUrl.Location = new System.Drawing.Point(110, 58);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.ReadOnly = true;
			this.textBoxUrl.Size = new System.Drawing.Size(217, 20);
			this.textBoxUrl.TabIndex = 5;
			// 
			// labelAbbreviatedName
			// 
			this.labelAbbreviatedName.AutoSize = true;
			this.labelAbbreviatedName.Location = new System.Drawing.Point(6, 35);
			this.labelAbbreviatedName.Name = "labelAbbreviatedName";
			this.labelAbbreviatedName.Size = new System.Drawing.Size(96, 13);
			this.labelAbbreviatedName.TabIndex = 2;
			this.labelAbbreviatedName.Text = "&Abbreviated name:";
			// 
			// textBoxAbbreviatedName
			// 
			this.textBoxAbbreviatedName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxAbbreviatedName.Location = new System.Drawing.Point(110, 32);
			this.textBoxAbbreviatedName.Name = "textBoxAbbreviatedName";
			this.textBoxAbbreviatedName.ReadOnly = true;
			this.textBoxAbbreviatedName.Size = new System.Drawing.Size(217, 20);
			this.textBoxAbbreviatedName.TabIndex = 3;
			// 
			// tabPageIdentifiers
			// 
			this.tabPageIdentifiers.AutoScroll = true;
			this.tabPageIdentifiers.Controls.Add(this.labelPeerSiteId);
			this.tabPageIdentifiers.Controls.Add(this.labelExtConsortiumId);
			this.tabPageIdentifiers.Controls.Add(this.labelPeerId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxPeerSiteId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxExtConsortiumId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxPeerId);
			this.tabPageIdentifiers.Controls.Add(this.labelSiteId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxSiteId);
			this.tabPageIdentifiers.Location = new System.Drawing.Point(4, 22);
			this.tabPageIdentifiers.Name = "tabPageIdentifiers";
			this.tabPageIdentifiers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIdentifiers.Size = new System.Drawing.Size(333, 313);
			this.tabPageIdentifiers.TabIndex = 1;
			this.tabPageIdentifiers.Text = "Identifiers";
			this.tabPageIdentifiers.UseVisualStyleBackColor = true;
			// 
			// labelPeerSiteId
			// 
			this.labelPeerSiteId.AutoSize = true;
			this.labelPeerSiteId.Location = new System.Drawing.Point(6, 87);
			this.labelPeerSiteId.Name = "labelPeerSiteId";
			this.labelPeerSiteId.Size = new System.Drawing.Size(65, 13);
			this.labelPeerSiteId.TabIndex = 6;
			this.labelPeerSiteId.Text = "Pee&r site ID:";
			// 
			// labelExtConsortiumId
			// 
			this.labelExtConsortiumId.AutoSize = true;
			this.labelExtConsortiumId.Location = new System.Drawing.Point(6, 61);
			this.labelExtConsortiumId.Name = "labelExtConsortiumId";
			this.labelExtConsortiumId.Size = new System.Drawing.Size(116, 13);
			this.labelExtConsortiumId.TabIndex = 4;
			this.labelExtConsortiumId.Text = "&External consortium ID:";
			// 
			// labelPeerId
			// 
			this.labelPeerId.AutoSize = true;
			this.labelPeerId.Location = new System.Drawing.Point(6, 35);
			this.labelPeerId.Name = "labelPeerId";
			this.labelPeerId.Size = new System.Drawing.Size(46, 13);
			this.labelPeerId.TabIndex = 2;
			this.labelPeerId.Text = "&Peer ID:";
			// 
			// textBoxPeerSiteId
			// 
			this.textBoxPeerSiteId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPeerSiteId.Location = new System.Drawing.Point(139, 84);
			this.textBoxPeerSiteId.Name = "textBoxPeerSiteId";
			this.textBoxPeerSiteId.ReadOnly = true;
			this.textBoxPeerSiteId.Size = new System.Drawing.Size(188, 20);
			this.textBoxPeerSiteId.TabIndex = 7;
			// 
			// textBoxExtConsortiumId
			// 
			this.textBoxExtConsortiumId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxExtConsortiumId.Location = new System.Drawing.Point(139, 58);
			this.textBoxExtConsortiumId.Name = "textBoxExtConsortiumId";
			this.textBoxExtConsortiumId.ReadOnly = true;
			this.textBoxExtConsortiumId.Size = new System.Drawing.Size(188, 20);
			this.textBoxExtConsortiumId.TabIndex = 5;
			// 
			// textBoxPeerId
			// 
			this.textBoxPeerId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPeerId.Location = new System.Drawing.Point(139, 32);
			this.textBoxPeerId.Name = "textBoxPeerId";
			this.textBoxPeerId.ReadOnly = true;
			this.textBoxPeerId.Size = new System.Drawing.Size(188, 20);
			this.textBoxPeerId.TabIndex = 3;
			// 
			// labelSiteId
			// 
			this.labelSiteId.AutoSize = true;
			this.labelSiteId.Location = new System.Drawing.Point(6, 9);
			this.labelSiteId.Name = "labelSiteId";
			this.labelSiteId.Size = new System.Drawing.Size(42, 13);
			this.labelSiteId.TabIndex = 0;
			this.labelSiteId.Text = "&Site ID:";
			// 
			// textBoxSiteId
			// 
			this.textBoxSiteId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSiteId.Location = new System.Drawing.Point(139, 6);
			this.textBoxSiteId.Name = "textBoxSiteId";
			this.textBoxSiteId.ReadOnly = true;
			this.textBoxSiteId.Size = new System.Drawing.Size(188, 20);
			this.textBoxSiteId.TabIndex = 1;
			// 
			// tabPageLocation
			// 
			this.tabPageLocation.Controls.Add(this.worldMap);
			this.tabPageLocation.Controls.Add(this.labelLongitude);
			this.tabPageLocation.Controls.Add(this.textBoxLongitude);
			this.tabPageLocation.Controls.Add(this.labelLatitude);
			this.tabPageLocation.Controls.Add(this.textBoxLatitude);
			this.tabPageLocation.Location = new System.Drawing.Point(4, 22);
			this.tabPageLocation.Name = "tabPageLocation";
			this.tabPageLocation.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLocation.Size = new System.Drawing.Size(333, 313);
			this.tabPageLocation.TabIndex = 2;
			this.tabPageLocation.Text = "Location";
			this.tabPageLocation.UseVisualStyleBackColor = true;
			// 
			// worldMap
			// 
			this.worldMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.worldMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.worldMap.ColorGridMajor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.worldMap.ColorGridMinor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.worldMap.GridMajor = true;
			this.worldMap.GridMinor = true;
			this.worldMap.Location = new System.Drawing.Point(6, 93);
			this.worldMap.Name = "worldMap";
			this.worldMap.ShowMarkers = true;
			this.worldMap.Size = new System.Drawing.Size(321, 214);
			this.worldMap.TabIndex = 4;
			// 
			// labelLongitude
			// 
			this.labelLongitude.AutoSize = true;
			this.labelLongitude.Location = new System.Drawing.Point(7, 35);
			this.labelLongitude.Name = "labelLongitude";
			this.labelLongitude.Size = new System.Drawing.Size(57, 13);
			this.labelLongitude.TabIndex = 2;
			this.labelLongitude.Text = "L&ongitude:";
			// 
			// textBoxLongitude
			// 
			this.textBoxLongitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLongitude.Location = new System.Drawing.Point(110, 32);
			this.textBoxLongitude.Name = "textBoxLongitude";
			this.textBoxLongitude.ReadOnly = true;
			this.textBoxLongitude.Size = new System.Drawing.Size(217, 20);
			this.textBoxLongitude.TabIndex = 3;
			// 
			// labelLatitude
			// 
			this.labelLatitude.AutoSize = true;
			this.labelLatitude.Location = new System.Drawing.Point(6, 9);
			this.labelLatitude.Name = "labelLatitude";
			this.labelLatitude.Size = new System.Drawing.Size(48, 13);
			this.labelLatitude.TabIndex = 0;
			this.labelLatitude.Text = "L&atitude:";
			// 
			// textBoxLatitude
			// 
			this.textBoxLatitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLatitude.Location = new System.Drawing.Point(110, 6);
			this.textBoxLatitude.Name = "textBoxLatitude";
			this.textBoxLatitude.ReadOnly = true;
			this.textBoxLatitude.Size = new System.Drawing.Size(217, 20);
			this.textBoxLatitude.TabIndex = 1;
			// 
			// tabPageNodes
			// 
			this.tabPageNodes.Controls.Add(this.buttonNode);
			this.tabPageNodes.Controls.Add(this.listViewNodes);
			this.tabPageNodes.Location = new System.Drawing.Point(4, 22);
			this.tabPageNodes.Name = "tabPageNodes";
			this.tabPageNodes.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageNodes.Size = new System.Drawing.Size(333, 313);
			this.tabPageNodes.TabIndex = 3;
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
			this.buttonNode.TabIndex = 1;
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
			this.listViewNodes.TabIndex = 0;
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
			// tabPagePcus
			// 
			this.tabPagePcus.Controls.Add(this.buttonPcu);
			this.tabPagePcus.Controls.Add(this.listViewPcus);
			this.tabPagePcus.Location = new System.Drawing.Point(4, 22);
			this.tabPagePcus.Name = "tabPagePcus";
			this.tabPagePcus.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePcus.Size = new System.Drawing.Size(333, 313);
			this.tabPagePcus.TabIndex = 4;
			this.tabPagePcus.Text = "PCUs";
			this.tabPagePcus.UseVisualStyleBackColor = true;
			// 
			// buttonPcu
			// 
			this.buttonPcu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonPcu.Enabled = false;
			this.buttonPcu.Location = new System.Drawing.Point(6, 284);
			this.buttonPcu.Name = "buttonPcu";
			this.buttonPcu.Size = new System.Drawing.Size(85, 23);
			this.buttonPcu.TabIndex = 2;
			this.buttonPcu.Text = "Properties...";
			this.buttonPcu.UseVisualStyleBackColor = true;
			this.buttonPcu.Click += new System.EventHandler(this.OnPcuProperties);
			// 
			// listViewPcus
			// 
			this.listViewPcus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewPcus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPcu});
			this.listViewPcus.FullRowSelect = true;
			this.listViewPcus.GridLines = true;
			this.listViewPcus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewPcus.HideSelection = false;
			this.listViewPcus.Location = new System.Drawing.Point(6, 6);
			this.listViewPcus.MultiSelect = false;
			this.listViewPcus.Name = "listViewPcus";
			this.listViewPcus.Size = new System.Drawing.Size(321, 272);
			this.listViewPcus.SmallImageList = this.imageList;
			this.listViewPcus.TabIndex = 1;
			this.listViewPcus.UseCompatibleStateImageBehavior = false;
			this.listViewPcus.View = System.Windows.Forms.View.Details;
			this.listViewPcus.ItemActivate += new System.EventHandler(this.OnPcuProperties);
			this.listViewPcus.SelectedIndexChanged += new System.EventHandler(this.OnPcuSelectionChanged);
			// 
			// columnHeaderPcu
			// 
			this.columnHeaderPcu.Text = "PCU ID";
			this.columnHeaderPcu.Width = 240;
			// 
			// tabPagePersons
			// 
			this.tabPagePersons.Controls.Add(this.buttonPerson);
			this.tabPagePersons.Controls.Add(this.listViewPersons);
			this.tabPagePersons.Location = new System.Drawing.Point(4, 22);
			this.tabPagePersons.Name = "tabPagePersons";
			this.tabPagePersons.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePersons.Size = new System.Drawing.Size(333, 313);
			this.tabPagePersons.TabIndex = 5;
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
			this.buttonPerson.TabIndex = 3;
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
			this.listViewPersons.TabIndex = 2;
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
			// tabPageSlices
			// 
			this.tabPageSlices.Controls.Add(this.buttonSlice);
			this.tabPageSlices.Controls.Add(this.listViewSlices);
			this.tabPageSlices.Location = new System.Drawing.Point(4, 22);
			this.tabPageSlices.Name = "tabPageSlices";
			this.tabPageSlices.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSlices.Size = new System.Drawing.Size(333, 313);
			this.tabPageSlices.TabIndex = 6;
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
			this.buttonSlice.TabIndex = 4;
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
			this.listViewSlices.TabIndex = 3;
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
			// tabPageAddresses
			// 
			this.tabPageAddresses.Controls.Add(this.buttonAddress);
			this.tabPageAddresses.Controls.Add(this.listViewAddresses);
			this.tabPageAddresses.Location = new System.Drawing.Point(4, 22);
			this.tabPageAddresses.Name = "tabPageAddresses";
			this.tabPageAddresses.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAddresses.Size = new System.Drawing.Size(333, 313);
			this.tabPageAddresses.TabIndex = 7;
			this.tabPageAddresses.Text = "Addresses";
			this.tabPageAddresses.UseVisualStyleBackColor = true;
			// 
			// buttonAddress
			// 
			this.buttonAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAddress.Enabled = false;
			this.buttonAddress.Location = new System.Drawing.Point(6, 284);
			this.buttonAddress.Name = "buttonAddress";
			this.buttonAddress.Size = new System.Drawing.Size(85, 23);
			this.buttonAddress.TabIndex = 5;
			this.buttonAddress.Text = "Properties...";
			this.buttonAddress.UseVisualStyleBackColor = true;
			this.buttonAddress.Click += new System.EventHandler(this.OnAddressProperties);
			// 
			// listViewAddresses
			// 
			this.listViewAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewAddresses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress});
			this.listViewAddresses.FullRowSelect = true;
			this.listViewAddresses.GridLines = true;
			this.listViewAddresses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewAddresses.HideSelection = false;
			this.listViewAddresses.Location = new System.Drawing.Point(6, 6);
			this.listViewAddresses.MultiSelect = false;
			this.listViewAddresses.Name = "listViewAddresses";
			this.listViewAddresses.Size = new System.Drawing.Size(321, 272);
			this.listViewAddresses.SmallImageList = this.imageList;
			this.listViewAddresses.TabIndex = 4;
			this.listViewAddresses.UseCompatibleStateImageBehavior = false;
			this.listViewAddresses.View = System.Windows.Forms.View.Details;
			this.listViewAddresses.ItemActivate += new System.EventHandler(this.OnAddressProperties);
			this.listViewAddresses.SelectedIndexChanged += new System.EventHandler(this.OnAddressSelectionChanged);
			// 
			// columnHeaderAddress
			// 
			this.columnHeaderAddress.Text = "Address ID";
			this.columnHeaderAddress.Width = 240;
			// 
			// tabPageTags
			// 
			this.tabPageTags.Controls.Add(this.buttonTag);
			this.tabPageTags.Controls.Add(this.listViewTags);
			this.tabPageTags.Location = new System.Drawing.Point(4, 22);
			this.tabPageTags.Name = "tabPageTags";
			this.tabPageTags.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTags.Size = new System.Drawing.Size(333, 313);
			this.tabPageTags.TabIndex = 8;
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
			this.buttonTag.TabIndex = 6;
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
			this.listViewTags.TabIndex = 5;
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
			// ControlPlanetLabSiteProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Name = "ControlPlanetLabSiteProperties";
			this.Size = new System.Drawing.Size(350, 400);
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageIdentifiers.ResumeLayout(false);
			this.tabPageIdentifiers.PerformLayout();
			this.tabPageLocation.ResumeLayout(false);
			this.tabPageLocation.PerformLayout();
			this.tabPageNodes.ResumeLayout(false);
			this.tabPagePcus.ResumeLayout(false);
			this.tabPagePersons.ResumeLayout(false);
			this.tabPageSlices.ResumeLayout(false);
			this.tabPageAddresses.ResumeLayout(false);
			this.tabPageTags.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelAbbreviatedName;
		private System.Windows.Forms.TextBox textBoxAbbreviatedName;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.TextBox textBoxDateCreated;
		private System.Windows.Forms.TextBox textBoxUrl;
		private System.Windows.Forms.TextBox textBoxLoginBase;
		private System.Windows.Forms.Label labelLoginBase;
		private System.Windows.Forms.TextBox textBoxLastUpdated;
		private System.Windows.Forms.Label labelLastUpdated;
		private System.Windows.Forms.Label labelDateCreated;
		private System.Windows.Forms.TextBox textBoxMaxSlivers;
		private System.Windows.Forms.TextBox textBoxMaxSlices;
		private System.Windows.Forms.Label labelMaxSlices;
		private System.Windows.Forms.Label labelMaxSlivers;
		private System.Windows.Forms.CheckBox checkBoxIsEnabled;
		private System.Windows.Forms.CheckBox checkBoxIsPublic;
		private System.Windows.Forms.TabPage tabPageIdentifiers;
		private System.Windows.Forms.Label labelSiteId;
		private System.Windows.Forms.TextBox textBoxSiteId;
		private System.Windows.Forms.TextBox textBoxPeerId;
		private System.Windows.Forms.TextBox textBoxExtConsortiumId;
		private System.Windows.Forms.TextBox textBoxPeerSiteId;
		private System.Windows.Forms.Label labelPeerId;
		private System.Windows.Forms.Label labelExtConsortiumId;
		private System.Windows.Forms.Label labelPeerSiteId;
		private System.Windows.Forms.TabPage tabPageLocation;
		private System.Windows.Forms.Label labelLatitude;
		private System.Windows.Forms.TextBox textBoxLatitude;
		private System.Windows.Forms.Label labelLongitude;
		private System.Windows.Forms.TextBox textBoxLongitude;
		private DotNetApi.Windows.Controls.GeoWorldMap worldMap;
		private System.Windows.Forms.TabPage tabPageNodes;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderNode;
		private System.Windows.Forms.Button buttonNode;
		private System.Windows.Forms.TabPage tabPagePcus;
		private System.Windows.Forms.TabPage tabPagePersons;
		private System.Windows.Forms.TabPage tabPageSlices;
		private System.Windows.Forms.TabPage tabPageAddresses;
		private System.Windows.Forms.TabPage tabPageTags;
		private System.Windows.Forms.ListView listViewPcus;
		private System.Windows.Forms.ColumnHeader columnHeaderPcu;
		private System.Windows.Forms.Button buttonPcu;
		private System.Windows.Forms.Button buttonPerson;
		private System.Windows.Forms.ListView listViewPersons;
		private System.Windows.Forms.ColumnHeader columnHeaderPerson;
		private System.Windows.Forms.Button buttonSlice;
		private System.Windows.Forms.ListView listViewSlices;
		private System.Windows.Forms.ColumnHeader columnHeaderSlice;
		private System.Windows.Forms.ListView listViewAddresses;
		private System.Windows.Forms.ColumnHeader columnHeaderAddress;
		private System.Windows.Forms.Button buttonAddress;
		private System.Windows.Forms.ListView listViewTags;
		private System.Windows.Forms.ColumnHeader columnHeaderTag;
		private System.Windows.Forms.Button buttonTag;
		private System.Windows.Forms.ImageList imageList;
	}
}
