namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlConfigurationFileProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlConfigurationFileProperties));
			this.textBoxSource = new System.Windows.Forms.TextBox();
			this.labelSource = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
			this.labelOwner = new System.Windows.Forms.Label();
			this.labelGroup = new System.Windows.Forms.Label();
			this.textBoxOwner = new System.Windows.Forms.TextBox();
			this.textBoxGroup = new System.Windows.Forms.TextBox();
			this.labelPermissions = new System.Windows.Forms.Label();
			this.textBoxPermissions = new System.Windows.Forms.TextBox();
			this.labelDestination = new System.Windows.Forms.Label();
			this.textBoxDestination = new System.Windows.Forms.TextBox();
			this.tabPageIdentifiers = new System.Windows.Forms.TabPage();
			this.labelConfiguarationFileId = new System.Windows.Forms.Label();
			this.textBoxConfigurationFileId = new System.Windows.Forms.TextBox();
			this.tabPageCommands = new System.Windows.Forms.TabPage();
			this.labelError = new System.Windows.Forms.Label();
			this.textBoxError = new System.Windows.Forms.TextBox();
			this.labelPostinstall = new System.Windows.Forms.Label();
			this.textBoxPostinstall = new System.Windows.Forms.TextBox();
			this.labelPreinstall = new System.Windows.Forms.Label();
			this.textBoxPreinstall = new System.Windows.Forms.TextBox();
			this.tabPageNodes = new System.Windows.Forms.TabPage();
			this.buttonNode = new System.Windows.Forms.Button();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnHeaderNode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabPageNodeGroups = new System.Windows.Forms.TabPage();
			this.buttonNodeGroup = new System.Windows.Forms.Button();
			this.listViewNodeGroups = new System.Windows.Forms.ListView();
			this.columnHeaderNodeGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.checkBoxAlwaysUpdate = new System.Windows.Forms.CheckBox();
			this.checkBoxIgnoreCommandErrors = new System.Windows.Forms.CheckBox();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageIdentifiers.SuspendLayout();
			this.tabPageCommands.SuspendLayout();
			this.tabPageNodes.SuspendLayout();
			this.tabPageNodeGroups.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxSource
			// 
			this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSource.Location = new System.Drawing.Point(110, 6);
			this.textBoxSource.Name = "textBoxSource";
			this.textBoxSource.ReadOnly = true;
			this.textBoxSource.Size = new System.Drawing.Size(217, 20);
			this.textBoxSource.TabIndex = 1;
			// 
			// labelSource
			// 
			this.labelSource.AutoSize = true;
			this.labelSource.Location = new System.Drawing.Point(6, 9);
			this.labelSource.Name = "labelSource";
			this.labelSource.Size = new System.Drawing.Size(44, 13);
			this.labelSource.TabIndex = 0;
			this.labelSource.Text = "&Source:";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageCommands);
			this.tabControl.Controls.Add(this.tabPageIdentifiers);
			this.tabControl.Controls.Add(this.tabPageNodes);
			this.tabControl.Controls.Add(this.tabPageNodeGroups);
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
			this.tabPageGeneral.Controls.Add(this.checkBoxIgnoreCommandErrors);
			this.tabPageGeneral.Controls.Add(this.checkBoxAlwaysUpdate);
			this.tabPageGeneral.Controls.Add(this.checkBoxEnabled);
			this.tabPageGeneral.Controls.Add(this.labelOwner);
			this.tabPageGeneral.Controls.Add(this.labelGroup);
			this.tabPageGeneral.Controls.Add(this.textBoxOwner);
			this.tabPageGeneral.Controls.Add(this.textBoxGroup);
			this.tabPageGeneral.Controls.Add(this.labelPermissions);
			this.tabPageGeneral.Controls.Add(this.textBoxPermissions);
			this.tabPageGeneral.Controls.Add(this.labelDestination);
			this.tabPageGeneral.Controls.Add(this.textBoxDestination);
			this.tabPageGeneral.Controls.Add(this.labelSource);
			this.tabPageGeneral.Controls.Add(this.textBoxSource);
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
			this.checkBoxEnabled.AutoSize = true;
			this.checkBoxEnabled.Enabled = false;
			this.checkBoxEnabled.Location = new System.Drawing.Point(110, 148);
			this.checkBoxEnabled.Name = "checkBoxEnabled";
			this.checkBoxEnabled.Size = new System.Drawing.Size(65, 17);
			this.checkBoxEnabled.TabIndex = 10;
			this.checkBoxEnabled.Text = "&Enabled";
			this.checkBoxEnabled.UseVisualStyleBackColor = true;
			// 
			// labelOwner
			// 
			this.labelOwner.AutoSize = true;
			this.labelOwner.Location = new System.Drawing.Point(6, 125);
			this.labelOwner.Name = "labelOwner";
			this.labelOwner.Size = new System.Drawing.Size(41, 13);
			this.labelOwner.TabIndex = 8;
			this.labelOwner.Text = "&Owner:";
			// 
			// labelGroup
			// 
			this.labelGroup.AutoSize = true;
			this.labelGroup.Location = new System.Drawing.Point(6, 99);
			this.labelGroup.Name = "labelGroup";
			this.labelGroup.Size = new System.Drawing.Size(39, 13);
			this.labelGroup.TabIndex = 6;
			this.labelGroup.Text = "&Group:";
			// 
			// textBoxOwner
			// 
			this.textBoxOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxOwner.Location = new System.Drawing.Point(110, 122);
			this.textBoxOwner.Name = "textBoxOwner";
			this.textBoxOwner.ReadOnly = true;
			this.textBoxOwner.Size = new System.Drawing.Size(217, 20);
			this.textBoxOwner.TabIndex = 9;
			// 
			// textBoxGroup
			// 
			this.textBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxGroup.Location = new System.Drawing.Point(110, 96);
			this.textBoxGroup.Name = "textBoxGroup";
			this.textBoxGroup.ReadOnly = true;
			this.textBoxGroup.Size = new System.Drawing.Size(217, 20);
			this.textBoxGroup.TabIndex = 7;
			// 
			// labelPermissions
			// 
			this.labelPermissions.AutoSize = true;
			this.labelPermissions.Location = new System.Drawing.Point(6, 73);
			this.labelPermissions.Name = "labelPermissions";
			this.labelPermissions.Size = new System.Drawing.Size(65, 13);
			this.labelPermissions.TabIndex = 4;
			this.labelPermissions.Text = "&Permissions:";
			// 
			// textBoxPermissions
			// 
			this.textBoxPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPermissions.Location = new System.Drawing.Point(110, 70);
			this.textBoxPermissions.Name = "textBoxPermissions";
			this.textBoxPermissions.ReadOnly = true;
			this.textBoxPermissions.Size = new System.Drawing.Size(217, 20);
			this.textBoxPermissions.TabIndex = 5;
			// 
			// labelDestination
			// 
			this.labelDestination.AutoSize = true;
			this.labelDestination.Location = new System.Drawing.Point(6, 35);
			this.labelDestination.Name = "labelDestination";
			this.labelDestination.Size = new System.Drawing.Size(63, 13);
			this.labelDestination.TabIndex = 2;
			this.labelDestination.Text = "&Destination:";
			// 
			// textBoxDestination
			// 
			this.textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDestination.Location = new System.Drawing.Point(110, 32);
			this.textBoxDestination.Name = "textBoxDestination";
			this.textBoxDestination.ReadOnly = true;
			this.textBoxDestination.Size = new System.Drawing.Size(217, 20);
			this.textBoxDestination.TabIndex = 3;
			// 
			// tabPageIdentifiers
			// 
			this.tabPageIdentifiers.AutoScroll = true;
			this.tabPageIdentifiers.Controls.Add(this.labelConfiguarationFileId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxConfigurationFileId);
			this.tabPageIdentifiers.Location = new System.Drawing.Point(4, 22);
			this.tabPageIdentifiers.Name = "tabPageIdentifiers";
			this.tabPageIdentifiers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIdentifiers.Size = new System.Drawing.Size(333, 313);
			this.tabPageIdentifiers.TabIndex = 1;
			this.tabPageIdentifiers.Text = "Identifiers";
			this.tabPageIdentifiers.UseVisualStyleBackColor = true;
			// 
			// labelConfiguarationFileId
			// 
			this.labelConfiguarationFileId.AutoSize = true;
			this.labelConfiguarationFileId.Location = new System.Drawing.Point(6, 9);
			this.labelConfiguarationFileId.Name = "labelConfiguarationFileId";
			this.labelConfiguarationFileId.Size = new System.Drawing.Size(102, 13);
			this.labelConfiguarationFileId.TabIndex = 0;
			this.labelConfiguarationFileId.Text = "&Configuration file ID:";
			// 
			// textBoxConfigurationFileId
			// 
			this.textBoxConfigurationFileId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxConfigurationFileId.Location = new System.Drawing.Point(139, 6);
			this.textBoxConfigurationFileId.Name = "textBoxConfigurationFileId";
			this.textBoxConfigurationFileId.ReadOnly = true;
			this.textBoxConfigurationFileId.Size = new System.Drawing.Size(188, 20);
			this.textBoxConfigurationFileId.TabIndex = 1;
			// 
			// tabPageCommands
			// 
			this.tabPageCommands.Controls.Add(this.labelError);
			this.tabPageCommands.Controls.Add(this.textBoxError);
			this.tabPageCommands.Controls.Add(this.labelPostinstall);
			this.tabPageCommands.Controls.Add(this.textBoxPostinstall);
			this.tabPageCommands.Controls.Add(this.labelPreinstall);
			this.tabPageCommands.Controls.Add(this.textBoxPreinstall);
			this.tabPageCommands.Location = new System.Drawing.Point(4, 40);
			this.tabPageCommands.Name = "tabPageCommands";
			this.tabPageCommands.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCommands.Size = new System.Drawing.Size(333, 295);
			this.tabPageCommands.TabIndex = 2;
			this.tabPageCommands.Text = "Commands";
			this.tabPageCommands.UseVisualStyleBackColor = true;
			// 
			// labelError
			// 
			this.labelError.AutoSize = true;
			this.labelError.Location = new System.Drawing.Point(6, 180);
			this.labelError.Name = "labelError";
			this.labelError.Size = new System.Drawing.Size(81, 13);
			this.labelError.TabIndex = 4;
			this.labelError.Text = "&Error command:";
			// 
			// textBoxError
			// 
			this.textBoxError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxError.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxError.Location = new System.Drawing.Point(139, 178);
			this.textBoxError.Multiline = true;
			this.textBoxError.Name = "textBoxError";
			this.textBoxError.ReadOnly = true;
			this.textBoxError.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textBoxError.Size = new System.Drawing.Size(188, 80);
			this.textBoxError.TabIndex = 5;
			this.textBoxError.WordWrap = false;
			// 
			// labelPostinstall
			// 
			this.labelPostinstall.AutoSize = true;
			this.labelPostinstall.Location = new System.Drawing.Point(6, 94);
			this.labelPostinstall.Name = "labelPostinstall";
			this.labelPostinstall.Size = new System.Drawing.Size(106, 13);
			this.labelPostinstall.TabIndex = 2;
			this.labelPostinstall.Text = "P&ostinstall command:";
			// 
			// textBoxPostinstall
			// 
			this.textBoxPostinstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPostinstall.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPostinstall.Location = new System.Drawing.Point(139, 92);
			this.textBoxPostinstall.Multiline = true;
			this.textBoxPostinstall.Name = "textBoxPostinstall";
			this.textBoxPostinstall.ReadOnly = true;
			this.textBoxPostinstall.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textBoxPostinstall.Size = new System.Drawing.Size(188, 80);
			this.textBoxPostinstall.TabIndex = 3;
			this.textBoxPostinstall.WordWrap = false;
			// 
			// labelPreinstall
			// 
			this.labelPreinstall.AutoSize = true;
			this.labelPreinstall.Location = new System.Drawing.Point(6, 9);
			this.labelPreinstall.Name = "labelPreinstall";
			this.labelPreinstall.Size = new System.Drawing.Size(101, 13);
			this.labelPreinstall.TabIndex = 0;
			this.labelPreinstall.Text = "&Preinstall command:";
			// 
			// textBoxPreinstall
			// 
			this.textBoxPreinstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPreinstall.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPreinstall.Location = new System.Drawing.Point(139, 6);
			this.textBoxPreinstall.Multiline = true;
			this.textBoxPreinstall.Name = "textBoxPreinstall";
			this.textBoxPreinstall.ReadOnly = true;
			this.textBoxPreinstall.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.textBoxPreinstall.Size = new System.Drawing.Size(188, 80);
			this.textBoxPreinstall.TabIndex = 1;
			this.textBoxPreinstall.WordWrap = false;
			// 
			// tabPageNodes
			// 
			this.tabPageNodes.Controls.Add(this.buttonNode);
			this.tabPageNodes.Controls.Add(this.listViewNodes);
			this.tabPageNodes.Location = new System.Drawing.Point(4, 40);
			this.tabPageNodes.Name = "tabPageNodes";
			this.tabPageNodes.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageNodes.Size = new System.Drawing.Size(333, 295);
			this.tabPageNodes.TabIndex = 4;
			this.tabPageNodes.Text = "Nodes";
			this.tabPageNodes.UseVisualStyleBackColor = true;
			// 
			// buttonNode
			// 
			this.buttonNode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonNode.Enabled = false;
			this.buttonNode.Location = new System.Drawing.Point(6, 266);
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
			this.listViewNodes.Size = new System.Drawing.Size(321, 254);
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
			// tabPageNodeGroups
			// 
			this.tabPageNodeGroups.Controls.Add(this.buttonNodeGroup);
			this.tabPageNodeGroups.Controls.Add(this.listViewNodeGroups);
			this.tabPageNodeGroups.Location = new System.Drawing.Point(4, 22);
			this.tabPageNodeGroups.Name = "tabPageNodeGroups";
			this.tabPageNodeGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageNodeGroups.Size = new System.Drawing.Size(333, 313);
			this.tabPageNodeGroups.TabIndex = 7;
			this.tabPageNodeGroups.Text = "Node groups";
			this.tabPageNodeGroups.UseVisualStyleBackColor = true;
			// 
			// buttonNodeGroup
			// 
			this.buttonNodeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonNodeGroup.Enabled = false;
			this.buttonNodeGroup.Location = new System.Drawing.Point(6, 284);
			this.buttonNodeGroup.Name = "buttonNodeGroup";
			this.buttonNodeGroup.Size = new System.Drawing.Size(85, 23);
			this.buttonNodeGroup.TabIndex = 5;
			this.buttonNodeGroup.Text = "Properties...";
			this.buttonNodeGroup.UseVisualStyleBackColor = true;
			this.buttonNodeGroup.Click += new System.EventHandler(this.OnNodeGroupProperties);
			// 
			// listViewNodeGroups
			// 
			this.listViewNodeGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewNodeGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNodeGroup});
			this.listViewNodeGroups.FullRowSelect = true;
			this.listViewNodeGroups.GridLines = true;
			this.listViewNodeGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewNodeGroups.HideSelection = false;
			this.listViewNodeGroups.Location = new System.Drawing.Point(6, 6);
			this.listViewNodeGroups.MultiSelect = false;
			this.listViewNodeGroups.Name = "listViewNodeGroups";
			this.listViewNodeGroups.Size = new System.Drawing.Size(321, 272);
			this.listViewNodeGroups.SmallImageList = this.imageList;
			this.listViewNodeGroups.TabIndex = 4;
			this.listViewNodeGroups.UseCompatibleStateImageBehavior = false;
			this.listViewNodeGroups.View = System.Windows.Forms.View.Details;
			this.listViewNodeGroups.ItemActivate += new System.EventHandler(this.OnNodeGroupProperties);
			this.listViewNodeGroups.SelectedIndexChanged += new System.EventHandler(this.OnNodeGroupSelectionChanged);
			// 
			// columnHeaderNodeGroup
			// 
			this.columnHeaderNodeGroup.Text = "Node group ID";
			this.columnHeaderNodeGroup.Width = 240;
			// 
			// checkBoxAlwaysUpdate
			// 
			this.checkBoxAlwaysUpdate.AutoSize = true;
			this.checkBoxAlwaysUpdate.Enabled = false;
			this.checkBoxAlwaysUpdate.Location = new System.Drawing.Point(110, 171);
			this.checkBoxAlwaysUpdate.Name = "checkBoxAlwaysUpdate";
			this.checkBoxAlwaysUpdate.Size = new System.Drawing.Size(95, 17);
			this.checkBoxAlwaysUpdate.TabIndex = 11;
			this.checkBoxAlwaysUpdate.Text = "&Always update";
			this.checkBoxAlwaysUpdate.UseVisualStyleBackColor = true;
			// 
			// checkBoxIgnoreCommandErrors
			// 
			this.checkBoxIgnoreCommandErrors.AutoSize = true;
			this.checkBoxIgnoreCommandErrors.Enabled = false;
			this.checkBoxIgnoreCommandErrors.Location = new System.Drawing.Point(110, 194);
			this.checkBoxIgnoreCommandErrors.Name = "checkBoxIgnoreCommandErrors";
			this.checkBoxIgnoreCommandErrors.Size = new System.Drawing.Size(134, 17);
			this.checkBoxIgnoreCommandErrors.TabIndex = 12;
			this.checkBoxIgnoreCommandErrors.Text = "&Ignore command errors";
			this.checkBoxIgnoreCommandErrors.UseVisualStyleBackColor = true;
			// 
			// ControlConfigurationFileProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Name = "ControlConfigurationFileProperties";
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageIdentifiers.ResumeLayout(false);
			this.tabPageIdentifiers.PerformLayout();
			this.tabPageCommands.ResumeLayout(false);
			this.tabPageCommands.PerformLayout();
			this.tabPageNodes.ResumeLayout(false);
			this.tabPageNodeGroups.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxSource;
		private System.Windows.Forms.Label labelSource;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelDestination;
		private System.Windows.Forms.TextBox textBoxDestination;
		private System.Windows.Forms.Label labelPermissions;
		private System.Windows.Forms.TextBox textBoxGroup;
		private System.Windows.Forms.TextBox textBoxPermissions;
		private System.Windows.Forms.TextBox textBoxOwner;
		private System.Windows.Forms.Label labelOwner;
		private System.Windows.Forms.Label labelGroup;
		private System.Windows.Forms.TabPage tabPageIdentifiers;
		private System.Windows.Forms.Label labelConfiguarationFileId;
		private System.Windows.Forms.TextBox textBoxConfigurationFileId;
		private System.Windows.Forms.TabPage tabPageCommands;
		private System.Windows.Forms.Label labelPreinstall;
		private System.Windows.Forms.TextBox textBoxPreinstall;
		private System.Windows.Forms.Label labelPostinstall;
		private System.Windows.Forms.TextBox textBoxPostinstall;
		private System.Windows.Forms.TabPage tabPageNodes;
		private System.Windows.Forms.TabPage tabPageNodeGroups;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderNode;
		private System.Windows.Forms.Button buttonNode;
		private System.Windows.Forms.ListView listViewNodeGroups;
		private System.Windows.Forms.ColumnHeader columnHeaderNodeGroup;
		private System.Windows.Forms.Button buttonNodeGroup;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Label labelError;
		private System.Windows.Forms.TextBox textBoxError;
		private System.Windows.Forms.CheckBox checkBoxEnabled;
		private System.Windows.Forms.CheckBox checkBoxIgnoreCommandErrors;
		private System.Windows.Forms.CheckBox checkBoxAlwaysUpdate;
	}
}
