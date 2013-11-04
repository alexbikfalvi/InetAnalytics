namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlInterfaceProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlInterfaceProperties));
			this.textBoxHostname = new System.Windows.Forms.TextBox();
			this.labelHostname = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.checkBoxIsPrimary = new System.Windows.Forms.CheckBox();
			this.labelMethod = new System.Windows.Forms.Label();
			this.labelBroadcast = new System.Windows.Forms.Label();
			this.textBoxMethod = new System.Windows.Forms.TextBox();
			this.textBoxBroadcast = new System.Windows.Forms.TextBox();
			this.labelType = new System.Windows.Forms.Label();
			this.labelNetwork = new System.Windows.Forms.Label();
			this.textBoxType = new System.Windows.Forms.TextBox();
			this.textBoxNetmask = new System.Windows.Forms.TextBox();
			this.labelLastUpdated = new System.Windows.Forms.Label();
			this.labelIp = new System.Windows.Forms.Label();
			this.textBoxLastUpdated = new System.Windows.Forms.TextBox();
			this.textBoxIp = new System.Windows.Forms.TextBox();
			this.labelMac = new System.Windows.Forms.Label();
			this.textBoxMac = new System.Windows.Forms.TextBox();
			this.labelNetmask = new System.Windows.Forms.Label();
			this.textBoxNetwork = new System.Windows.Forms.TextBox();
			this.tabPageAdditional = new System.Windows.Forms.TabPage();
			this.labelGateway = new System.Windows.Forms.Label();
			this.textBoxGateway = new System.Windows.Forms.TextBox();
			this.labelBandwidthLimit = new System.Windows.Forms.Label();
			this.textBoxBandwidthLimit = new System.Windows.Forms.TextBox();
			this.labelLastDns2 = new System.Windows.Forms.Label();
			this.textBoxDns2 = new System.Windows.Forms.TextBox();
			this.labelDns1 = new System.Windows.Forms.Label();
			this.textBoxDns1 = new System.Windows.Forms.TextBox();
			this.tabPageIdentifiers = new System.Windows.Forms.TabPage();
			this.labelInterfaceId = new System.Windows.Forms.Label();
			this.textBoxInterfaceId = new System.Windows.Forms.TextBox();
			this.labelNodeId = new System.Windows.Forms.Label();
			this.textBoxNodeId = new System.Windows.Forms.TextBox();
			this.tabPageInterfaceTags = new System.Windows.Forms.TabPage();
			this.buttonInterfaceTag = new System.Windows.Forms.Button();
			this.listViewInterfaceTags = new System.Windows.Forms.ListView();
			this.columnHeaderInterfaceTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageAdditional.SuspendLayout();
			this.tabPageIdentifiers.SuspendLayout();
			this.tabPageInterfaceTags.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxHostname
			// 
			this.textBoxHostname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxHostname.Location = new System.Drawing.Point(110, 32);
			this.textBoxHostname.Name = "textBoxHostname";
			this.textBoxHostname.ReadOnly = true;
			this.textBoxHostname.Size = new System.Drawing.Size(217, 20);
			this.textBoxHostname.TabIndex = 3;
			// 
			// labelHostname
			// 
			this.labelHostname.AutoSize = true;
			this.labelHostname.Location = new System.Drawing.Point(6, 35);
			this.labelHostname.Name = "labelHostname";
			this.labelHostname.Size = new System.Drawing.Size(58, 13);
			this.labelHostname.TabIndex = 2;
			this.labelHostname.Text = "&Hostname:";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageAdditional);
			this.tabControl.Controls.Add(this.tabPageIdentifiers);
			this.tabControl.Controls.Add(this.tabPageInterfaceTags);
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
			this.tabPageGeneral.Controls.Add(this.checkBoxIsPrimary);
			this.tabPageGeneral.Controls.Add(this.labelMethod);
			this.tabPageGeneral.Controls.Add(this.labelBroadcast);
			this.tabPageGeneral.Controls.Add(this.textBoxMethod);
			this.tabPageGeneral.Controls.Add(this.textBoxBroadcast);
			this.tabPageGeneral.Controls.Add(this.labelType);
			this.tabPageGeneral.Controls.Add(this.labelNetwork);
			this.tabPageGeneral.Controls.Add(this.textBoxType);
			this.tabPageGeneral.Controls.Add(this.textBoxNetmask);
			this.tabPageGeneral.Controls.Add(this.labelLastUpdated);
			this.tabPageGeneral.Controls.Add(this.labelIp);
			this.tabPageGeneral.Controls.Add(this.textBoxLastUpdated);
			this.tabPageGeneral.Controls.Add(this.textBoxIp);
			this.tabPageGeneral.Controls.Add(this.labelMac);
			this.tabPageGeneral.Controls.Add(this.textBoxMac);
			this.tabPageGeneral.Controls.Add(this.labelNetmask);
			this.tabPageGeneral.Controls.Add(this.textBoxNetwork);
			this.tabPageGeneral.Controls.Add(this.labelHostname);
			this.tabPageGeneral.Controls.Add(this.textBoxHostname);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(333, 313);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// checkBoxIsPrimary
			// 
			this.checkBoxIsPrimary.AutoSize = true;
			this.checkBoxIsPrimary.Enabled = false;
			this.checkBoxIsPrimary.Location = new System.Drawing.Point(110, 252);
			this.checkBoxIsPrimary.Name = "checkBoxIsPrimary";
			this.checkBoxIsPrimary.Size = new System.Drawing.Size(70, 17);
			this.checkBoxIsPrimary.TabIndex = 18;
			this.checkBoxIsPrimary.Text = "Is p&rimary";
			this.checkBoxIsPrimary.UseVisualStyleBackColor = true;
			// 
			// labelMethod
			// 
			this.labelMethod.AutoSize = true;
			this.labelMethod.Location = new System.Drawing.Point(7, 191);
			this.labelMethod.Name = "labelMethod";
			this.labelMethod.Size = new System.Drawing.Size(72, 13);
			this.labelMethod.TabIndex = 14;
			this.labelMethod.Text = "&Configuration:";
			// 
			// labelBroadcast
			// 
			this.labelBroadcast.AutoSize = true;
			this.labelBroadcast.Location = new System.Drawing.Point(6, 165);
			this.labelBroadcast.Name = "labelBroadcast";
			this.labelBroadcast.Size = new System.Drawing.Size(98, 13);
			this.labelBroadcast.TabIndex = 12;
			this.labelBroadcast.Text = "&Broadcast address:";
			// 
			// textBoxMethod
			// 
			this.textBoxMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMethod.Location = new System.Drawing.Point(110, 188);
			this.textBoxMethod.Name = "textBoxMethod";
			this.textBoxMethod.ReadOnly = true;
			this.textBoxMethod.Size = new System.Drawing.Size(217, 20);
			this.textBoxMethod.TabIndex = 15;
			// 
			// textBoxBroadcast
			// 
			this.textBoxBroadcast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxBroadcast.Location = new System.Drawing.Point(110, 162);
			this.textBoxBroadcast.Name = "textBoxBroadcast";
			this.textBoxBroadcast.ReadOnly = true;
			this.textBoxBroadcast.Size = new System.Drawing.Size(217, 20);
			this.textBoxBroadcast.TabIndex = 13;
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(6, 9);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(34, 13);
			this.labelType.TabIndex = 0;
			this.labelType.Text = "&Type:";
			// 
			// labelNetwork
			// 
			this.labelNetwork.AutoSize = true;
			this.labelNetwork.Location = new System.Drawing.Point(6, 139);
			this.labelNetwork.Name = "labelNetwork";
			this.labelNetwork.Size = new System.Drawing.Size(90, 13);
			this.labelNetwork.TabIndex = 10;
			this.labelNetwork.Text = "&Network address:";
			// 
			// textBoxType
			// 
			this.textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxType.Location = new System.Drawing.Point(110, 6);
			this.textBoxType.Name = "textBoxType";
			this.textBoxType.ReadOnly = true;
			this.textBoxType.Size = new System.Drawing.Size(217, 20);
			this.textBoxType.TabIndex = 1;
			// 
			// textBoxNetmask
			// 
			this.textBoxNetmask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNetmask.Location = new System.Drawing.Point(110, 110);
			this.textBoxNetmask.Name = "textBoxNetmask";
			this.textBoxNetmask.ReadOnly = true;
			this.textBoxNetmask.Size = new System.Drawing.Size(217, 20);
			this.textBoxNetmask.TabIndex = 9;
			// 
			// labelLastUpdated
			// 
			this.labelLastUpdated.AutoSize = true;
			this.labelLastUpdated.Location = new System.Drawing.Point(6, 229);
			this.labelLastUpdated.Name = "labelLastUpdated";
			this.labelLastUpdated.Size = new System.Drawing.Size(72, 13);
			this.labelLastUpdated.TabIndex = 16;
			this.labelLastUpdated.Text = "Last up&dated:";
			// 
			// labelIp
			// 
			this.labelIp.AutoSize = true;
			this.labelIp.Location = new System.Drawing.Point(6, 87);
			this.labelIp.Name = "labelIp";
			this.labelIp.Size = new System.Drawing.Size(60, 13);
			this.labelIp.TabIndex = 6;
			this.labelIp.Text = "&IP address:";
			// 
			// textBoxLastUpdated
			// 
			this.textBoxLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLastUpdated.Location = new System.Drawing.Point(110, 226);
			this.textBoxLastUpdated.Name = "textBoxLastUpdated";
			this.textBoxLastUpdated.ReadOnly = true;
			this.textBoxLastUpdated.Size = new System.Drawing.Size(217, 20);
			this.textBoxLastUpdated.TabIndex = 17;
			// 
			// textBoxIp
			// 
			this.textBoxIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxIp.Location = new System.Drawing.Point(110, 84);
			this.textBoxIp.Name = "textBoxIp";
			this.textBoxIp.ReadOnly = true;
			this.textBoxIp.Size = new System.Drawing.Size(217, 20);
			this.textBoxIp.TabIndex = 7;
			// 
			// labelMac
			// 
			this.labelMac.AutoSize = true;
			this.labelMac.Location = new System.Drawing.Point(6, 61);
			this.labelMac.Name = "labelMac";
			this.labelMac.Size = new System.Drawing.Size(33, 13);
			this.labelMac.TabIndex = 4;
			this.labelMac.Text = "&MAC:";
			// 
			// textBoxMac
			// 
			this.textBoxMac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMac.Location = new System.Drawing.Point(110, 58);
			this.textBoxMac.Name = "textBoxMac";
			this.textBoxMac.ReadOnly = true;
			this.textBoxMac.Size = new System.Drawing.Size(217, 20);
			this.textBoxMac.TabIndex = 5;
			// 
			// labelNetmask
			// 
			this.labelNetmask.AutoSize = true;
			this.labelNetmask.Location = new System.Drawing.Point(6, 113);
			this.labelNetmask.Name = "labelNetmask";
			this.labelNetmask.Size = new System.Drawing.Size(78, 13);
			this.labelNetmask.TabIndex = 8;
			this.labelNetmask.Text = "Network mas&k:";
			// 
			// textBoxNetwork
			// 
			this.textBoxNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNetwork.Location = new System.Drawing.Point(110, 136);
			this.textBoxNetwork.Name = "textBoxNetwork";
			this.textBoxNetwork.ReadOnly = true;
			this.textBoxNetwork.Size = new System.Drawing.Size(217, 20);
			this.textBoxNetwork.TabIndex = 11;
			// 
			// tabPageAdditional
			// 
			this.tabPageAdditional.Controls.Add(this.labelGateway);
			this.tabPageAdditional.Controls.Add(this.textBoxGateway);
			this.tabPageAdditional.Controls.Add(this.labelBandwidthLimit);
			this.tabPageAdditional.Controls.Add(this.textBoxBandwidthLimit);
			this.tabPageAdditional.Controls.Add(this.labelLastDns2);
			this.tabPageAdditional.Controls.Add(this.textBoxDns2);
			this.tabPageAdditional.Controls.Add(this.labelDns1);
			this.tabPageAdditional.Controls.Add(this.textBoxDns1);
			this.tabPageAdditional.Location = new System.Drawing.Point(4, 22);
			this.tabPageAdditional.Name = "tabPageAdditional";
			this.tabPageAdditional.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAdditional.Size = new System.Drawing.Size(333, 313);
			this.tabPageAdditional.TabIndex = 2;
			this.tabPageAdditional.Text = "Additional";
			this.tabPageAdditional.UseVisualStyleBackColor = true;
			// 
			// labelGateway
			// 
			this.labelGateway.AutoSize = true;
			this.labelGateway.Location = new System.Drawing.Point(6, 9);
			this.labelGateway.Name = "labelGateway";
			this.labelGateway.Size = new System.Drawing.Size(52, 13);
			this.labelGateway.TabIndex = 0;
			this.labelGateway.Text = "&Gateway:";
			// 
			// textBoxGateway
			// 
			this.textBoxGateway.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxGateway.Location = new System.Drawing.Point(110, 6);
			this.textBoxGateway.Name = "textBoxGateway";
			this.textBoxGateway.ReadOnly = true;
			this.textBoxGateway.Size = new System.Drawing.Size(217, 20);
			this.textBoxGateway.TabIndex = 1;
			// 
			// labelBandwidthLimit
			// 
			this.labelBandwidthLimit.AutoSize = true;
			this.labelBandwidthLimit.Location = new System.Drawing.Point(6, 99);
			this.labelBandwidthLimit.Name = "labelBandwidthLimit";
			this.labelBandwidthLimit.Size = new System.Drawing.Size(80, 13);
			this.labelBandwidthLimit.TabIndex = 6;
			this.labelBandwidthLimit.Text = "&Bandwidth limit:";
			// 
			// textBoxBandwidthLimit
			// 
			this.textBoxBandwidthLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxBandwidthLimit.Location = new System.Drawing.Point(110, 96);
			this.textBoxBandwidthLimit.Name = "textBoxBandwidthLimit";
			this.textBoxBandwidthLimit.ReadOnly = true;
			this.textBoxBandwidthLimit.Size = new System.Drawing.Size(217, 20);
			this.textBoxBandwidthLimit.TabIndex = 7;
			// 
			// labelLastDns2
			// 
			this.labelLastDns2.AutoSize = true;
			this.labelLastDns2.Location = new System.Drawing.Point(6, 61);
			this.labelLastDns2.Name = "labelLastDns2";
			this.labelLastDns2.Size = new System.Drawing.Size(74, 13);
			this.labelLastDns2.TabIndex = 4;
			this.labelLastDns2.Text = "D&NS server 2:";
			// 
			// textBoxDns2
			// 
			this.textBoxDns2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDns2.Location = new System.Drawing.Point(110, 58);
			this.textBoxDns2.Name = "textBoxDns2";
			this.textBoxDns2.ReadOnly = true;
			this.textBoxDns2.Size = new System.Drawing.Size(217, 20);
			this.textBoxDns2.TabIndex = 5;
			// 
			// labelDns1
			// 
			this.labelDns1.AutoSize = true;
			this.labelDns1.Location = new System.Drawing.Point(6, 35);
			this.labelDns1.Name = "labelDns1";
			this.labelDns1.Size = new System.Drawing.Size(74, 13);
			this.labelDns1.TabIndex = 2;
			this.labelDns1.Text = "&DNS server 1:";
			// 
			// textBoxDns1
			// 
			this.textBoxDns1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDns1.Location = new System.Drawing.Point(110, 32);
			this.textBoxDns1.Name = "textBoxDns1";
			this.textBoxDns1.ReadOnly = true;
			this.textBoxDns1.Size = new System.Drawing.Size(217, 20);
			this.textBoxDns1.TabIndex = 3;
			// 
			// tabPageIdentifiers
			// 
			this.tabPageIdentifiers.AutoScroll = true;
			this.tabPageIdentifiers.Controls.Add(this.labelInterfaceId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxInterfaceId);
			this.tabPageIdentifiers.Controls.Add(this.labelNodeId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxNodeId);
			this.tabPageIdentifiers.Location = new System.Drawing.Point(4, 22);
			this.tabPageIdentifiers.Name = "tabPageIdentifiers";
			this.tabPageIdentifiers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIdentifiers.Size = new System.Drawing.Size(333, 313);
			this.tabPageIdentifiers.TabIndex = 1;
			this.tabPageIdentifiers.Text = "Identifiers";
			this.tabPageIdentifiers.UseVisualStyleBackColor = true;
			// 
			// labelInterfaceId
			// 
			this.labelInterfaceId.AutoSize = true;
			this.labelInterfaceId.Location = new System.Drawing.Point(6, 9);
			this.labelInterfaceId.Name = "labelInterfaceId";
			this.labelInterfaceId.Size = new System.Drawing.Size(66, 13);
			this.labelInterfaceId.TabIndex = 0;
			this.labelInterfaceId.Text = "&Interface ID:";
			// 
			// textBoxInterfaceId
			// 
			this.textBoxInterfaceId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInterfaceId.Location = new System.Drawing.Point(110, 6);
			this.textBoxInterfaceId.Name = "textBoxInterfaceId";
			this.textBoxInterfaceId.ReadOnly = true;
			this.textBoxInterfaceId.Size = new System.Drawing.Size(217, 20);
			this.textBoxInterfaceId.TabIndex = 1;
			// 
			// labelNodeId
			// 
			this.labelNodeId.AutoSize = true;
			this.labelNodeId.Location = new System.Drawing.Point(6, 35);
			this.labelNodeId.Name = "labelNodeId";
			this.labelNodeId.Size = new System.Drawing.Size(50, 13);
			this.labelNodeId.TabIndex = 2;
			this.labelNodeId.Text = "&Node ID:";
			// 
			// textBoxNodeId
			// 
			this.textBoxNodeId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNodeId.Location = new System.Drawing.Point(110, 32);
			this.textBoxNodeId.Name = "textBoxNodeId";
			this.textBoxNodeId.ReadOnly = true;
			this.textBoxNodeId.Size = new System.Drawing.Size(217, 20);
			this.textBoxNodeId.TabIndex = 3;
			// 
			// tabPageInterfaceTags
			// 
			this.tabPageInterfaceTags.Controls.Add(this.buttonInterfaceTag);
			this.tabPageInterfaceTags.Controls.Add(this.listViewInterfaceTags);
			this.tabPageInterfaceTags.Location = new System.Drawing.Point(4, 22);
			this.tabPageInterfaceTags.Name = "tabPageInterfaceTags";
			this.tabPageInterfaceTags.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageInterfaceTags.Size = new System.Drawing.Size(333, 313);
			this.tabPageInterfaceTags.TabIndex = 5;
			this.tabPageInterfaceTags.Text = "Node tags";
			this.tabPageInterfaceTags.UseVisualStyleBackColor = true;
			// 
			// buttonInterfaceTag
			// 
			this.buttonInterfaceTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonInterfaceTag.Enabled = false;
			this.buttonInterfaceTag.Location = new System.Drawing.Point(6, 284);
			this.buttonInterfaceTag.Name = "buttonInterfaceTag";
			this.buttonInterfaceTag.Size = new System.Drawing.Size(85, 23);
			this.buttonInterfaceTag.TabIndex = 1;
			this.buttonInterfaceTag.Text = "Properties...";
			this.buttonInterfaceTag.UseVisualStyleBackColor = true;
			this.buttonInterfaceTag.Click += new System.EventHandler(this.OnInterfaceTagProperties);
			// 
			// listViewInterfaceTags
			// 
			this.listViewInterfaceTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewInterfaceTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderInterfaceTag});
			this.listViewInterfaceTags.FullRowSelect = true;
			this.listViewInterfaceTags.GridLines = true;
			this.listViewInterfaceTags.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewInterfaceTags.HideSelection = false;
			this.listViewInterfaceTags.Location = new System.Drawing.Point(6, 6);
			this.listViewInterfaceTags.MultiSelect = false;
			this.listViewInterfaceTags.Name = "listViewInterfaceTags";
			this.listViewInterfaceTags.Size = new System.Drawing.Size(321, 272);
			this.listViewInterfaceTags.SmallImageList = this.imageList;
			this.listViewInterfaceTags.TabIndex = 0;
			this.listViewInterfaceTags.UseCompatibleStateImageBehavior = false;
			this.listViewInterfaceTags.View = System.Windows.Forms.View.Details;
			this.listViewInterfaceTags.ItemActivate += new System.EventHandler(this.OnInterfaceTagProperties);
			this.listViewInterfaceTags.SelectedIndexChanged += new System.EventHandler(this.OnInterfaceTagSelectionChanged);
			// 
			// columnHeaderInterfaceTag
			// 
			this.columnHeaderInterfaceTag.Text = "Interface tag ID";
			this.columnHeaderInterfaceTag.Width = 240;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "ObjectSmallId");
			// 
			// ControlInterfaceProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Name = "ControlInterfaceProperties";
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageAdditional.ResumeLayout(false);
			this.tabPageAdditional.PerformLayout();
			this.tabPageIdentifiers.ResumeLayout(false);
			this.tabPageIdentifiers.PerformLayout();
			this.tabPageInterfaceTags.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxHostname;
		private System.Windows.Forms.Label labelHostname;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelNetmask;
		private System.Windows.Forms.TextBox textBoxNetwork;
		private System.Windows.Forms.Label labelMac;
		private System.Windows.Forms.TextBox textBoxIp;
		private System.Windows.Forms.TextBox textBoxMac;
		private System.Windows.Forms.TextBox textBoxLastUpdated;
		private System.Windows.Forms.Label labelLastUpdated;
		private System.Windows.Forms.Label labelIp;
		private System.Windows.Forms.TextBox textBoxType;
		private System.Windows.Forms.TextBox textBoxNetmask;
		private System.Windows.Forms.Label labelNetwork;
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.TabPage tabPageIdentifiers;
		private System.Windows.Forms.Label labelNodeId;
		private System.Windows.Forms.TextBox textBoxNodeId;
		private System.Windows.Forms.TextBox textBoxInterfaceId;
		private System.Windows.Forms.Label labelInterfaceId;
		private System.Windows.Forms.TabPage tabPageAdditional;
		private System.Windows.Forms.Label labelDns1;
		private System.Windows.Forms.TextBox textBoxDns1;
		private System.Windows.Forms.Label labelLastDns2;
		private System.Windows.Forms.TextBox textBoxDns2;
		private System.Windows.Forms.TabPage tabPageInterfaceTags;
		private System.Windows.Forms.Button buttonInterfaceTag;
		private System.Windows.Forms.ListView listViewInterfaceTags;
		private System.Windows.Forms.ColumnHeader columnHeaderInterfaceTag;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.TextBox textBoxBroadcast;
		private System.Windows.Forms.TextBox textBoxMethod;
		private System.Windows.Forms.Label labelBroadcast;
		private System.Windows.Forms.Label labelMethod;
		private System.Windows.Forms.Label labelBandwidthLimit;
		private System.Windows.Forms.TextBox textBoxBandwidthLimit;
		private System.Windows.Forms.CheckBox checkBoxIsPrimary;
		private System.Windows.Forms.TextBox textBoxGateway;
		private System.Windows.Forms.Label labelGateway;
	}
}
