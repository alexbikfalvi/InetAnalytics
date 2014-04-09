namespace InetControls.Controls.Net
{
	partial class ControlNetworkInterfaceProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlNetworkInterfaceProperties));
			this.labelTitle = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.checkBoxSupportsMulticast = new System.Windows.Forms.CheckBox();
			this.checkBoxReceiveOnly = new System.Windows.Forms.CheckBox();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.labelId = new System.Windows.Forms.Label();
			this.labelSpeed = new System.Windows.Forms.Label();
			this.textBoxSpeed = new System.Windows.Forms.TextBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxStatus = new System.Windows.Forms.TextBox();
			this.textBoxType = new System.Windows.Forms.TextBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.labelType = new System.Windows.Forms.Label();
			this.tabPageIpAddresses = new System.Windows.Forms.TabPage();
			this.labelGatewayAddresses = new System.Windows.Forms.Label();
			this.listBoxGatewayAddresses = new System.Windows.Forms.ListBox();
			this.labelAnycastAddresses = new System.Windows.Forms.Label();
			this.listBoxAnycastAddresses = new System.Windows.Forms.ListBox();
			this.labelMulticastAddresses = new System.Windows.Forms.Label();
			this.listBoxMulticastAddresses = new System.Windows.Forms.ListBox();
			this.listBoxUnicastAddresses = new System.Windows.Forms.ListBox();
			this.labelUnicastAddresses = new System.Windows.Forms.Label();
			this.tabPageIpServers = new System.Windows.Forms.TabPage();
			this.labelDhcpServers = new System.Windows.Forms.Label();
			this.checkBoxDynamicDns = new System.Windows.Forms.CheckBox();
			this.checkBoxDnsEnabled = new System.Windows.Forms.CheckBox();
			this.listBoxDhcpServers = new System.Windows.Forms.ListBox();
			this.labelDnsSuffix = new System.Windows.Forms.Label();
			this.textBoxDnsSuffix = new System.Windows.Forms.TextBox();
			this.labelWinsServers = new System.Windows.Forms.Label();
			this.listBoxWinsServers = new System.Windows.Forms.ListBox();
			this.labelDnsServers = new System.Windows.Forms.Label();
			this.listBoxDnsServers = new System.Windows.Forms.ListBox();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyValueToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageIpAddresses.SuspendLayout();
			this.tabPageIpServers.SuspendLayout();
			this.contextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(59, 29);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(149, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No network interface selected";
			this.labelTitle.UseMnemonic = false;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageIpAddresses);
			this.tabControl.Controls.Add(this.tabPageIpServers);
			this.tabControl.Location = new System.Drawing.Point(3, 58);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(394, 289);
			this.tabControl.TabIndex = 1;
			this.tabControl.Visible = false;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.checkBoxSupportsMulticast);
			this.tabPageGeneral.Controls.Add(this.checkBoxReceiveOnly);
			this.tabPageGeneral.Controls.Add(this.textBoxId);
			this.tabPageGeneral.Controls.Add(this.labelId);
			this.tabPageGeneral.Controls.Add(this.labelSpeed);
			this.tabPageGeneral.Controls.Add(this.textBoxSpeed);
			this.tabPageGeneral.Controls.Add(this.textBoxDescription);
			this.tabPageGeneral.Controls.Add(this.labelDescription);
			this.tabPageGeneral.Controls.Add(this.labelName);
			this.tabPageGeneral.Controls.Add(this.textBoxName);
			this.tabPageGeneral.Controls.Add(this.textBoxStatus);
			this.tabPageGeneral.Controls.Add(this.textBoxType);
			this.tabPageGeneral.Controls.Add(this.labelStatus);
			this.tabPageGeneral.Controls.Add(this.labelType);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(386, 263);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// checkBoxSupportsMulticast
			// 
			this.checkBoxSupportsMulticast.AutoSize = true;
			this.checkBoxSupportsMulticast.Enabled = false;
			this.checkBoxSupportsMulticast.Location = new System.Drawing.Point(88, 185);
			this.checkBoxSupportsMulticast.Name = "checkBoxSupportsMulticast";
			this.checkBoxSupportsMulticast.Size = new System.Drawing.Size(112, 17);
			this.checkBoxSupportsMulticast.TabIndex = 13;
			this.checkBoxSupportsMulticast.Text = "Supports multicast";
			this.checkBoxSupportsMulticast.UseVisualStyleBackColor = true;
			// 
			// checkBoxReceiveOnly
			// 
			this.checkBoxReceiveOnly.AutoSize = true;
			this.checkBoxReceiveOnly.Enabled = false;
			this.checkBoxReceiveOnly.Location = new System.Drawing.Point(88, 162);
			this.checkBoxReceiveOnly.Name = "checkBoxReceiveOnly";
			this.checkBoxReceiveOnly.Size = new System.Drawing.Size(88, 17);
			this.checkBoxReceiveOnly.TabIndex = 12;
			this.checkBoxReceiveOnly.Text = "Receive only";
			this.checkBoxReceiveOnly.UseVisualStyleBackColor = true;
			// 
			// textBoxId
			// 
			this.textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxId.Location = new System.Drawing.Point(88, 136);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.ReadOnly = true;
			this.textBoxId.Size = new System.Drawing.Size(270, 20);
			this.textBoxId.TabIndex = 11;
			// 
			// labelId
			// 
			this.labelId.AutoSize = true;
			this.labelId.Location = new System.Drawing.Point(10, 139);
			this.labelId.Name = "labelId";
			this.labelId.Size = new System.Drawing.Size(50, 13);
			this.labelId.TabIndex = 10;
			this.labelId.Text = "&Identifier:";
			// 
			// labelSpeed
			// 
			this.labelSpeed.AutoSize = true;
			this.labelSpeed.Location = new System.Drawing.Point(10, 113);
			this.labelSpeed.Name = "labelSpeed";
			this.labelSpeed.Size = new System.Drawing.Size(41, 13);
			this.labelSpeed.TabIndex = 8;
			this.labelSpeed.Text = "Sp&eed:";
			// 
			// textBoxSpeed
			// 
			this.textBoxSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSpeed.Location = new System.Drawing.Point(88, 110);
			this.textBoxSpeed.Name = "textBoxSpeed";
			this.textBoxSpeed.ReadOnly = true;
			this.textBoxSpeed.Size = new System.Drawing.Size(270, 20);
			this.textBoxSpeed.TabIndex = 9;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDescription.Location = new System.Drawing.Point(88, 84);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.Size = new System.Drawing.Size(270, 20);
			this.textBoxDescription.TabIndex = 7;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(10, 87);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(63, 13);
			this.labelDescription.TabIndex = 6;
			this.labelDescription.Text = "&Description:";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(10, 9);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(38, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "&Name:";
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Location = new System.Drawing.Point(88, 6);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.ReadOnly = true;
			this.textBoxName.Size = new System.Drawing.Size(270, 20);
			this.textBoxName.TabIndex = 1;
			// 
			// textBoxStatus
			// 
			this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxStatus.Location = new System.Drawing.Point(88, 58);
			this.textBoxStatus.Name = "textBoxStatus";
			this.textBoxStatus.ReadOnly = true;
			this.textBoxStatus.Size = new System.Drawing.Size(270, 20);
			this.textBoxStatus.TabIndex = 5;
			// 
			// textBoxType
			// 
			this.textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxType.Location = new System.Drawing.Point(88, 32);
			this.textBoxType.Name = "textBoxType";
			this.textBoxType.ReadOnly = true;
			this.textBoxType.Size = new System.Drawing.Size(270, 20);
			this.textBoxType.TabIndex = 3;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Location = new System.Drawing.Point(10, 61);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(40, 13);
			this.labelStatus.TabIndex = 4;
			this.labelStatus.Text = "&Status:";
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(10, 35);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(34, 13);
			this.labelType.TabIndex = 2;
			this.labelType.Text = "&Type:";
			// 
			// tabPageIpAddresses
			// 
			this.tabPageIpAddresses.Controls.Add(this.labelGatewayAddresses);
			this.tabPageIpAddresses.Controls.Add(this.listBoxGatewayAddresses);
			this.tabPageIpAddresses.Controls.Add(this.labelAnycastAddresses);
			this.tabPageIpAddresses.Controls.Add(this.listBoxAnycastAddresses);
			this.tabPageIpAddresses.Controls.Add(this.labelMulticastAddresses);
			this.tabPageIpAddresses.Controls.Add(this.listBoxMulticastAddresses);
			this.tabPageIpAddresses.Controls.Add(this.listBoxUnicastAddresses);
			this.tabPageIpAddresses.Controls.Add(this.labelUnicastAddresses);
			this.tabPageIpAddresses.Location = new System.Drawing.Point(4, 22);
			this.tabPageIpAddresses.Name = "tabPageIpAddresses";
			this.tabPageIpAddresses.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIpAddresses.Size = new System.Drawing.Size(386, 263);
			this.tabPageIpAddresses.TabIndex = 1;
			this.tabPageIpAddresses.Text = "IP addresses";
			this.tabPageIpAddresses.UseVisualStyleBackColor = true;
			// 
			// labelGatewayAddresses
			// 
			this.labelGatewayAddresses.AutoSize = true;
			this.labelGatewayAddresses.Location = new System.Drawing.Point(10, 192);
			this.labelGatewayAddresses.Name = "labelGatewayAddresses";
			this.labelGatewayAddresses.Size = new System.Drawing.Size(103, 13);
			this.labelGatewayAddresses.TabIndex = 6;
			this.labelGatewayAddresses.Text = "&Gateway addresses:";
			// 
			// listBoxGatewayAddresses
			// 
			this.listBoxGatewayAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxGatewayAddresses.FormattingEnabled = true;
			this.listBoxGatewayAddresses.Location = new System.Drawing.Point(130, 192);
			this.listBoxGatewayAddresses.Name = "listBoxGatewayAddresses";
			this.listBoxGatewayAddresses.Size = new System.Drawing.Size(250, 56);
			this.listBoxGatewayAddresses.TabIndex = 7;
			// 
			// labelAnycastAddresses
			// 
			this.labelAnycastAddresses.AutoSize = true;
			this.labelAnycastAddresses.Location = new System.Drawing.Point(10, 130);
			this.labelAnycastAddresses.Name = "labelAnycastAddresses";
			this.labelAnycastAddresses.Size = new System.Drawing.Size(99, 13);
			this.labelAnycastAddresses.TabIndex = 4;
			this.labelAnycastAddresses.Text = "&Anycast addresses:";
			// 
			// listBoxAnycastAddresses
			// 
			this.listBoxAnycastAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxAnycastAddresses.FormattingEnabled = true;
			this.listBoxAnycastAddresses.Location = new System.Drawing.Point(130, 130);
			this.listBoxAnycastAddresses.Name = "listBoxAnycastAddresses";
			this.listBoxAnycastAddresses.Size = new System.Drawing.Size(250, 56);
			this.listBoxAnycastAddresses.TabIndex = 5;
			// 
			// labelMulticastAddresses
			// 
			this.labelMulticastAddresses.AutoSize = true;
			this.labelMulticastAddresses.Location = new System.Drawing.Point(10, 68);
			this.labelMulticastAddresses.Name = "labelMulticastAddresses";
			this.labelMulticastAddresses.Size = new System.Drawing.Size(103, 13);
			this.labelMulticastAddresses.TabIndex = 2;
			this.labelMulticastAddresses.Text = "&Multicast addresses:";
			// 
			// listBoxMulticastAddresses
			// 
			this.listBoxMulticastAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxMulticastAddresses.FormattingEnabled = true;
			this.listBoxMulticastAddresses.Location = new System.Drawing.Point(130, 68);
			this.listBoxMulticastAddresses.Name = "listBoxMulticastAddresses";
			this.listBoxMulticastAddresses.Size = new System.Drawing.Size(250, 56);
			this.listBoxMulticastAddresses.TabIndex = 3;
			// 
			// listBoxUnicastAddresses
			// 
			this.listBoxUnicastAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxUnicastAddresses.FormattingEnabled = true;
			this.listBoxUnicastAddresses.Location = new System.Drawing.Point(130, 6);
			this.listBoxUnicastAddresses.Name = "listBoxUnicastAddresses";
			this.listBoxUnicastAddresses.Size = new System.Drawing.Size(250, 56);
			this.listBoxUnicastAddresses.TabIndex = 1;
			// 
			// labelUnicastAddresses
			// 
			this.labelUnicastAddresses.AutoSize = true;
			this.labelUnicastAddresses.Location = new System.Drawing.Point(10, 6);
			this.labelUnicastAddresses.Name = "labelUnicastAddresses";
			this.labelUnicastAddresses.Size = new System.Drawing.Size(97, 13);
			this.labelUnicastAddresses.TabIndex = 0;
			this.labelUnicastAddresses.Text = "&Unicast addresses:";
			// 
			// tabPageIpServers
			// 
			this.tabPageIpServers.Controls.Add(this.labelDhcpServers);
			this.tabPageIpServers.Controls.Add(this.checkBoxDynamicDns);
			this.tabPageIpServers.Controls.Add(this.checkBoxDnsEnabled);
			this.tabPageIpServers.Controls.Add(this.listBoxDhcpServers);
			this.tabPageIpServers.Controls.Add(this.labelDnsSuffix);
			this.tabPageIpServers.Controls.Add(this.textBoxDnsSuffix);
			this.tabPageIpServers.Controls.Add(this.labelWinsServers);
			this.tabPageIpServers.Controls.Add(this.listBoxWinsServers);
			this.tabPageIpServers.Controls.Add(this.labelDnsServers);
			this.tabPageIpServers.Controls.Add(this.listBoxDnsServers);
			this.tabPageIpServers.Location = new System.Drawing.Point(4, 22);
			this.tabPageIpServers.Name = "tabPageIpServers";
			this.tabPageIpServers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIpServers.Size = new System.Drawing.Size(386, 263);
			this.tabPageIpServers.TabIndex = 2;
			this.tabPageIpServers.Text = "IP servers";
			this.tabPageIpServers.UseVisualStyleBackColor = true;
			// 
			// labelDhcpServers
			// 
			this.labelDhcpServers.AutoSize = true;
			this.labelDhcpServers.Location = new System.Drawing.Point(10, 140);
			this.labelDhcpServers.Name = "labelDhcpServers";
			this.labelDhcpServers.Size = new System.Drawing.Size(77, 13);
			this.labelDhcpServers.TabIndex = 6;
			this.labelDhcpServers.Text = "D&HCP servers:";
			// 
			// checkBoxDynamicDns
			// 
			this.checkBoxDynamicDns.AutoSize = true;
			this.checkBoxDynamicDns.Enabled = false;
			this.checkBoxDynamicDns.Location = new System.Drawing.Point(130, 117);
			this.checkBoxDynamicDns.Name = "checkBoxDynamicDns";
			this.checkBoxDynamicDns.Size = new System.Drawing.Size(93, 17);
			this.checkBoxDynamicDns.TabIndex = 5;
			this.checkBoxDynamicDns.Text = "Dynamic DNS";
			this.checkBoxDynamicDns.UseVisualStyleBackColor = true;
			// 
			// checkBoxDnsEnabled
			// 
			this.checkBoxDnsEnabled.AutoSize = true;
			this.checkBoxDnsEnabled.Enabled = false;
			this.checkBoxDnsEnabled.Location = new System.Drawing.Point(130, 94);
			this.checkBoxDnsEnabled.Name = "checkBoxDnsEnabled";
			this.checkBoxDnsEnabled.Size = new System.Drawing.Size(100, 17);
			this.checkBoxDnsEnabled.TabIndex = 4;
			this.checkBoxDnsEnabled.Text = "DNS is enabled";
			this.checkBoxDnsEnabled.UseVisualStyleBackColor = true;
			// 
			// listBoxDhcpServers
			// 
			this.listBoxDhcpServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxDhcpServers.FormattingEnabled = true;
			this.listBoxDhcpServers.Location = new System.Drawing.Point(130, 140);
			this.listBoxDhcpServers.Name = "listBoxDhcpServers";
			this.listBoxDhcpServers.Size = new System.Drawing.Size(250, 56);
			this.listBoxDhcpServers.TabIndex = 7;
			// 
			// labelDnsSuffix
			// 
			this.labelDnsSuffix.AutoSize = true;
			this.labelDnsSuffix.Location = new System.Drawing.Point(10, 71);
			this.labelDnsSuffix.Name = "labelDnsSuffix";
			this.labelDnsSuffix.Size = new System.Drawing.Size(60, 13);
			this.labelDnsSuffix.TabIndex = 2;
			this.labelDnsSuffix.Text = "D&NS suffix:";
			// 
			// textBoxDnsSuffix
			// 
			this.textBoxDnsSuffix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDnsSuffix.Location = new System.Drawing.Point(130, 68);
			this.textBoxDnsSuffix.Name = "textBoxDnsSuffix";
			this.textBoxDnsSuffix.ReadOnly = true;
			this.textBoxDnsSuffix.Size = new System.Drawing.Size(250, 20);
			this.textBoxDnsSuffix.TabIndex = 3;
			// 
			// labelWinsServers
			// 
			this.labelWinsServers.AutoSize = true;
			this.labelWinsServers.Location = new System.Drawing.Point(10, 202);
			this.labelWinsServers.Name = "labelWinsServers";
			this.labelWinsServers.Size = new System.Drawing.Size(76, 13);
			this.labelWinsServers.TabIndex = 8;
			this.labelWinsServers.Text = "&WINS servers:";
			// 
			// listBoxWinsServers
			// 
			this.listBoxWinsServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxWinsServers.FormattingEnabled = true;
			this.listBoxWinsServers.Location = new System.Drawing.Point(130, 202);
			this.listBoxWinsServers.Name = "listBoxWinsServers";
			this.listBoxWinsServers.Size = new System.Drawing.Size(250, 56);
			this.listBoxWinsServers.TabIndex = 9;
			// 
			// labelDnsServers
			// 
			this.labelDnsServers.AutoSize = true;
			this.labelDnsServers.Location = new System.Drawing.Point(10, 6);
			this.labelDnsServers.Name = "labelDnsServers";
			this.labelDnsServers.Size = new System.Drawing.Size(70, 13);
			this.labelDnsServers.TabIndex = 0;
			this.labelDnsServers.Text = "&DNS servers:";
			// 
			// listBoxDnsServers
			// 
			this.listBoxDnsServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxDnsServers.FormattingEnabled = true;
			this.listBoxDnsServers.Location = new System.Drawing.Point(130, 6);
			this.listBoxDnsServers.Name = "listBoxDnsServers";
			this.listBoxDnsServers.Size = new System.Drawing.Size(250, 56);
			this.listBoxDnsServers.TabIndex = 1;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "EventBrown_16.png");
			this.imageList.Images.SetKeyName(1, "Information_16.png");
			this.imageList.Images.SetKeyName(2, "Success_16.png");
			this.imageList.Images.SetKeyName(3, "Error_16.png");
			this.imageList.Images.SetKeyName(4, "Canceled_16.png");
			this.imageList.Images.SetKeyName(5, "Warning_16.png");
			this.imageList.Images.SetKeyName(6, "Stop_16.png");
			this.imageList.Images.SetKeyName(7, "SuccessWarning_16.png");
			this.imageList.Images.SetKeyName(8, "ErrorWarning_16.png");
			this.imageList.Images.SetKeyName(9, "XmlNamespace_16.png");
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyValueToClipboardToolStripMenuItem});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(170, 26);
			// 
			// copyValueToClipboardToolStripMenuItem
			// 
			this.copyValueToClipboardToolStripMenuItem.Image = global::InetControls.Resources.Copy_16;
			this.copyValueToClipboardToolStripMenuItem.Name = "copyValueToClipboardToolStripMenuItem";
			this.copyValueToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.copyValueToClipboardToolStripMenuItem.Text = "Copy to clipboard";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetControls.Resources.NetworkInterface_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ControlNetworkInterfaceProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlNetworkInterfaceProperties";
			this.Size = new System.Drawing.Size(400, 350);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageIpAddresses.ResumeLayout(false);
			this.tabPageIpAddresses.PerformLayout();
			this.tabPageIpServers.ResumeLayout(false);
			this.tabPageIpServers.PerformLayout();
			this.contextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.TextBox textBoxType;
		private System.Windows.Forms.TextBox textBoxStatus;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem copyValueToClipboardToolStripMenuItem;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelSpeed;
		private System.Windows.Forms.TextBox textBoxSpeed;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.Label labelId;
		private System.Windows.Forms.CheckBox checkBoxSupportsMulticast;
		private System.Windows.Forms.CheckBox checkBoxReceiveOnly;
		private System.Windows.Forms.TabPage tabPageIpAddresses;
		private System.Windows.Forms.Label labelUnicastAddresses;
		private System.Windows.Forms.ListBox listBoxUnicastAddresses;
		private System.Windows.Forms.Label labelMulticastAddresses;
		private System.Windows.Forms.ListBox listBoxMulticastAddresses;
		private System.Windows.Forms.Label labelAnycastAddresses;
		private System.Windows.Forms.ListBox listBoxAnycastAddresses;
		private System.Windows.Forms.TabPage tabPageIpServers;
		private System.Windows.Forms.Label labelDnsServers;
		private System.Windows.Forms.ListBox listBoxDnsServers;
		private System.Windows.Forms.Label labelWinsServers;
		private System.Windows.Forms.ListBox listBoxWinsServers;
		private System.Windows.Forms.Label labelDnsSuffix;
		private System.Windows.Forms.TextBox textBoxDnsSuffix;
		private System.Windows.Forms.Label labelGatewayAddresses;
		private System.Windows.Forms.ListBox listBoxGatewayAddresses;
		private System.Windows.Forms.Label labelDhcpServers;
		private System.Windows.Forms.CheckBox checkBoxDynamicDns;
		private System.Windows.Forms.CheckBox checkBoxDnsEnabled;
		private System.Windows.Forms.ListBox listBoxDhcpServers;
	}
}
