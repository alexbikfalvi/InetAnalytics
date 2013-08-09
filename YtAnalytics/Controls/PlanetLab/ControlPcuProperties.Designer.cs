namespace YtAnalytics.Controls.PlanetLab
{
	partial class ControlPcuProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPcuProperties));
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxHostname = new System.Windows.Forms.TextBox();
			this.labelHostname = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.labelNodes = new System.Windows.Forms.Label();
			this.labelIp = new System.Windows.Forms.Label();
			this.textBoxNotes = new System.Windows.Forms.TextBox();
			this.textBoxIp = new System.Windows.Forms.TextBox();
			this.labelPassword = new System.Windows.Forms.Label();
			this.labelUsername = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.labelLastUpdated = new System.Windows.Forms.Label();
			this.labelProtocol = new System.Windows.Forms.Label();
			this.textBoxLastUpdated = new System.Windows.Forms.TextBox();
			this.textBoxProtocol = new System.Windows.Forms.TextBox();
			this.labelModel = new System.Windows.Forms.Label();
			this.textBoxModel = new System.Windows.Forms.TextBox();
			this.tabPageIdentifiers = new System.Windows.Forms.TabPage();
			this.labelSiteId = new System.Windows.Forms.Label();
			this.textBoxSiteId = new System.Windows.Forms.TextBox();
			this.labelPcuId = new System.Windows.Forms.Label();
			this.textBoxPcuId = new System.Windows.Forms.TextBox();
			this.tabPageStatus = new System.Windows.Forms.TabPage();
			this.labelPorts = new System.Windows.Forms.Label();
			this.listBoxPorts = new System.Windows.Forms.ListBox();
			this.tabPageNodes = new System.Windows.Forms.TabPage();
			this.buttonNode = new System.Windows.Forms.Button();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnHeaderNode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageIdentifiers.SuspendLayout();
			this.tabPageStatus.SuspendLayout();
			this.tabPageNodes.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(59, 29);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(89, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No PCU selected";
			this.labelTitle.UseMnemonic = false;
			// 
			// textBoxHostname
			// 
			this.textBoxHostname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxHostname.Location = new System.Drawing.Point(110, 6);
			this.textBoxHostname.Name = "textBoxHostname";
			this.textBoxHostname.ReadOnly = true;
			this.textBoxHostname.Size = new System.Drawing.Size(217, 20);
			this.textBoxHostname.TabIndex = 1;
			// 
			// labelHostname
			// 
			this.labelHostname.AutoSize = true;
			this.labelHostname.Location = new System.Drawing.Point(6, 9);
			this.labelHostname.Name = "labelHostname";
			this.labelHostname.Size = new System.Drawing.Size(58, 13);
			this.labelHostname.TabIndex = 0;
			this.labelHostname.Text = "&Hostname:";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.GlobePower_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageIdentifiers);
			this.tabControl.Controls.Add(this.tabPageStatus);
			this.tabControl.Controls.Add(this.tabPageNodes);
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
			this.tabPageGeneral.Controls.Add(this.labelNodes);
			this.tabPageGeneral.Controls.Add(this.labelIp);
			this.tabPageGeneral.Controls.Add(this.textBoxNotes);
			this.tabPageGeneral.Controls.Add(this.textBoxIp);
			this.tabPageGeneral.Controls.Add(this.labelPassword);
			this.tabPageGeneral.Controls.Add(this.labelUsername);
			this.tabPageGeneral.Controls.Add(this.textBoxPassword);
			this.tabPageGeneral.Controls.Add(this.textBoxUsername);
			this.tabPageGeneral.Controls.Add(this.labelLastUpdated);
			this.tabPageGeneral.Controls.Add(this.labelProtocol);
			this.tabPageGeneral.Controls.Add(this.textBoxLastUpdated);
			this.tabPageGeneral.Controls.Add(this.textBoxProtocol);
			this.tabPageGeneral.Controls.Add(this.labelModel);
			this.tabPageGeneral.Controls.Add(this.textBoxModel);
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
			// labelNodes
			// 
			this.labelNodes.AutoSize = true;
			this.labelNodes.Location = new System.Drawing.Point(6, 239);
			this.labelNodes.Name = "labelNodes";
			this.labelNodes.Size = new System.Drawing.Size(38, 13);
			this.labelNodes.TabIndex = 14;
			this.labelNodes.Text = "&Notes:";
			// 
			// labelIp
			// 
			this.labelIp.AutoSize = true;
			this.labelIp.Location = new System.Drawing.Point(6, 201);
			this.labelIp.Name = "labelIp";
			this.labelIp.Size = new System.Drawing.Size(20, 13);
			this.labelIp.TabIndex = 12;
			this.labelIp.Text = "&IP:";
			// 
			// textBoxNotes
			// 
			this.textBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNotes.Location = new System.Drawing.Point(110, 236);
			this.textBoxNotes.Multiline = true;
			this.textBoxNotes.Name = "textBoxNotes";
			this.textBoxNotes.ReadOnly = true;
			this.textBoxNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxNotes.Size = new System.Drawing.Size(217, 71);
			this.textBoxNotes.TabIndex = 15;
			// 
			// textBoxIp
			// 
			this.textBoxIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxIp.Location = new System.Drawing.Point(110, 198);
			this.textBoxIp.Name = "textBoxIp";
			this.textBoxIp.ReadOnly = true;
			this.textBoxIp.Size = new System.Drawing.Size(217, 20);
			this.textBoxIp.TabIndex = 13;
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(6, 99);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(56, 13);
			this.labelPassword.TabIndex = 6;
			this.labelPassword.Text = "&Password:";
			// 
			// labelUsername
			// 
			this.labelUsername.AutoSize = true;
			this.labelUsername.Location = new System.Drawing.Point(6, 73);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(58, 13);
			this.labelUsername.TabIndex = 4;
			this.labelUsername.Text = "&Username:";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPassword.Location = new System.Drawing.Point(110, 96);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.ReadOnly = true;
			this.textBoxPassword.Size = new System.Drawing.Size(217, 20);
			this.textBoxPassword.TabIndex = 7;
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUsername.Location = new System.Drawing.Point(110, 70);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.ReadOnly = true;
			this.textBoxUsername.Size = new System.Drawing.Size(217, 20);
			this.textBoxUsername.TabIndex = 5;
			// 
			// labelLastUpdated
			// 
			this.labelLastUpdated.AutoSize = true;
			this.labelLastUpdated.Location = new System.Drawing.Point(6, 137);
			this.labelLastUpdated.Name = "labelLastUpdated";
			this.labelLastUpdated.Size = new System.Drawing.Size(72, 13);
			this.labelLastUpdated.TabIndex = 8;
			this.labelLastUpdated.Text = "Last up&dated:";
			// 
			// labelProtocol
			// 
			this.labelProtocol.AutoSize = true;
			this.labelProtocol.Location = new System.Drawing.Point(6, 175);
			this.labelProtocol.Name = "labelProtocol";
			this.labelProtocol.Size = new System.Drawing.Size(49, 13);
			this.labelProtocol.TabIndex = 10;
			this.labelProtocol.Text = "P&rotocol:";
			// 
			// textBoxLastUpdated
			// 
			this.textBoxLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLastUpdated.Location = new System.Drawing.Point(110, 134);
			this.textBoxLastUpdated.Name = "textBoxLastUpdated";
			this.textBoxLastUpdated.ReadOnly = true;
			this.textBoxLastUpdated.Size = new System.Drawing.Size(217, 20);
			this.textBoxLastUpdated.TabIndex = 9;
			// 
			// textBoxProtocol
			// 
			this.textBoxProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxProtocol.Location = new System.Drawing.Point(110, 172);
			this.textBoxProtocol.Name = "textBoxProtocol";
			this.textBoxProtocol.ReadOnly = true;
			this.textBoxProtocol.Size = new System.Drawing.Size(217, 20);
			this.textBoxProtocol.TabIndex = 11;
			// 
			// labelModel
			// 
			this.labelModel.AutoSize = true;
			this.labelModel.Location = new System.Drawing.Point(6, 35);
			this.labelModel.Name = "labelModel";
			this.labelModel.Size = new System.Drawing.Size(39, 13);
			this.labelModel.TabIndex = 2;
			this.labelModel.Text = "&Model:";
			// 
			// textBoxModel
			// 
			this.textBoxModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxModel.Location = new System.Drawing.Point(110, 32);
			this.textBoxModel.Name = "textBoxModel";
			this.textBoxModel.ReadOnly = true;
			this.textBoxModel.Size = new System.Drawing.Size(217, 20);
			this.textBoxModel.TabIndex = 3;
			// 
			// tabPageIdentifiers
			// 
			this.tabPageIdentifiers.AutoScroll = true;
			this.tabPageIdentifiers.Controls.Add(this.labelSiteId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxSiteId);
			this.tabPageIdentifiers.Controls.Add(this.labelPcuId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxPcuId);
			this.tabPageIdentifiers.Location = new System.Drawing.Point(4, 22);
			this.tabPageIdentifiers.Name = "tabPageIdentifiers";
			this.tabPageIdentifiers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIdentifiers.Size = new System.Drawing.Size(333, 313);
			this.tabPageIdentifiers.TabIndex = 1;
			this.tabPageIdentifiers.Text = "Identifiers";
			this.tabPageIdentifiers.UseVisualStyleBackColor = true;
			// 
			// labelSiteId
			// 
			this.labelSiteId.AutoSize = true;
			this.labelSiteId.Location = new System.Drawing.Point(6, 35);
			this.labelSiteId.Name = "labelSiteId";
			this.labelSiteId.Size = new System.Drawing.Size(42, 13);
			this.labelSiteId.TabIndex = 2;
			this.labelSiteId.Text = "&Site ID:";
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
			// labelPcuId
			// 
			this.labelPcuId.AutoSize = true;
			this.labelPcuId.Location = new System.Drawing.Point(6, 9);
			this.labelPcuId.Name = "labelPcuId";
			this.labelPcuId.Size = new System.Drawing.Size(46, 13);
			this.labelPcuId.TabIndex = 0;
			this.labelPcuId.Text = "&PCU ID:";
			// 
			// textBoxPcuId
			// 
			this.textBoxPcuId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPcuId.Location = new System.Drawing.Point(110, 6);
			this.textBoxPcuId.Name = "textBoxPcuId";
			this.textBoxPcuId.ReadOnly = true;
			this.textBoxPcuId.Size = new System.Drawing.Size(217, 20);
			this.textBoxPcuId.TabIndex = 1;
			// 
			// tabPageStatus
			// 
			this.tabPageStatus.Controls.Add(this.labelPorts);
			this.tabPageStatus.Controls.Add(this.listBoxPorts);
			this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
			this.tabPageStatus.Name = "tabPageStatus";
			this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStatus.Size = new System.Drawing.Size(333, 313);
			this.tabPageStatus.TabIndex = 2;
			this.tabPageStatus.Text = "Status";
			this.tabPageStatus.UseVisualStyleBackColor = true;
			// 
			// labelPorts
			// 
			this.labelPorts.AutoSize = true;
			this.labelPorts.Location = new System.Drawing.Point(6, 9);
			this.labelPorts.Name = "labelPorts";
			this.labelPorts.Size = new System.Drawing.Size(34, 13);
			this.labelPorts.TabIndex = 0;
			this.labelPorts.Text = "Port&s:";
			// 
			// listBoxPorts
			// 
			this.listBoxPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxPorts.FormattingEnabled = true;
			this.listBoxPorts.IntegralHeight = false;
			this.listBoxPorts.Location = new System.Drawing.Point(139, 6);
			this.listBoxPorts.Name = "listBoxPorts";
			this.listBoxPorts.Size = new System.Drawing.Size(188, 301);
			this.listBoxPorts.TabIndex = 1;
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
			// ControlPlanetLabPcuProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlPlanetLabPcuProperties";
			this.Size = new System.Drawing.Size(350, 400);
			this.Controls.SetChildIndex(this.pictureBox, 0);
			this.Controls.SetChildIndex(this.labelTitle, 0);
			this.Controls.SetChildIndex(this.tabControl, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageIdentifiers.ResumeLayout(false);
			this.tabPageIdentifiers.PerformLayout();
			this.tabPageStatus.ResumeLayout(false);
			this.tabPageStatus.PerformLayout();
			this.tabPageNodes.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.TextBox textBoxHostname;
		private System.Windows.Forms.Label labelHostname;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelModel;
		private System.Windows.Forms.TextBox textBoxProtocol;
		private System.Windows.Forms.TextBox textBoxModel;
		private System.Windows.Forms.TextBox textBoxLastUpdated;
		private System.Windows.Forms.Label labelLastUpdated;
		private System.Windows.Forms.Label labelProtocol;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.Label labelUsername;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.TabPage tabPageIdentifiers;
		private System.Windows.Forms.Label labelPcuId;
		private System.Windows.Forms.TextBox textBoxPcuId;
		private System.Windows.Forms.TextBox textBoxSiteId;
		private System.Windows.Forms.Label labelSiteId;
		private System.Windows.Forms.TabPage tabPageNodes;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderNode;
		private System.Windows.Forms.Button buttonNode;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.TextBox textBoxIp;
		private System.Windows.Forms.TextBox textBoxNotes;
		private System.Windows.Forms.Label labelIp;
		private System.Windows.Forms.Label labelNodes;
		private System.Windows.Forms.TabPage tabPageStatus;
		private System.Windows.Forms.Label labelPorts;
		private System.Windows.Forms.ListBox listBoxPorts;
	}
}
