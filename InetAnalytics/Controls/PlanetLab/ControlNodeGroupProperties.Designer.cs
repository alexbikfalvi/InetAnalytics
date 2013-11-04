namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlNodeGroupProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlNodeGroupProperties));
			this.textBoxGroupName = new System.Windows.Forms.TextBox();
			this.labelGroupName = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.labelTagName = new System.Windows.Forms.Label();
			this.textBoxTagName = new System.Windows.Forms.TextBox();
			this.labelValue = new System.Windows.Forms.Label();
			this.textBoxValue = new System.Windows.Forms.TextBox();
			this.tabPageIdentifiers = new System.Windows.Forms.TabPage();
			this.labelTagTypeId = new System.Windows.Forms.Label();
			this.textBoxTagTypeId = new System.Windows.Forms.TextBox();
			this.labelNodeGroupId = new System.Windows.Forms.Label();
			this.textBoxNodeGroupId = new System.Windows.Forms.TextBox();
			this.tabPageNodes = new System.Windows.Forms.TabPage();
			this.buttonNode = new System.Windows.Forms.Button();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnHeaderNode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabPageConfigurationFiles = new System.Windows.Forms.TabPage();
			this.buttonConfigurationFile = new System.Windows.Forms.Button();
			this.listViewConfigurationFiles = new System.Windows.Forms.ListView();
			this.columnHeaderConfigurationFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageIdentifiers.SuspendLayout();
			this.tabPageNodes.SuspendLayout();
			this.tabPageConfigurationFiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxGroupName
			// 
			this.textBoxGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxGroupName.Location = new System.Drawing.Point(110, 6);
			this.textBoxGroupName.Name = "textBoxGroupName";
			this.textBoxGroupName.ReadOnly = true;
			this.textBoxGroupName.Size = new System.Drawing.Size(217, 20);
			this.textBoxGroupName.TabIndex = 1;
			// 
			// labelGroupName
			// 
			this.labelGroupName.AutoSize = true;
			this.labelGroupName.Location = new System.Drawing.Point(6, 9);
			this.labelGroupName.Name = "labelGroupName";
			this.labelGroupName.Size = new System.Drawing.Size(68, 13);
			this.labelGroupName.TabIndex = 0;
			this.labelGroupName.Text = "Group &name:";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageIdentifiers);
			this.tabControl.Controls.Add(this.tabPageNodes);
			this.tabControl.Controls.Add(this.tabPageConfigurationFiles);
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
			this.tabPageGeneral.Controls.Add(this.labelTagName);
			this.tabPageGeneral.Controls.Add(this.textBoxTagName);
			this.tabPageGeneral.Controls.Add(this.labelValue);
			this.tabPageGeneral.Controls.Add(this.textBoxValue);
			this.tabPageGeneral.Controls.Add(this.labelGroupName);
			this.tabPageGeneral.Controls.Add(this.textBoxGroupName);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(333, 313);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// labelTagName
			// 
			this.labelTagName.AutoSize = true;
			this.labelTagName.Location = new System.Drawing.Point(6, 61);
			this.labelTagName.Name = "labelTagName";
			this.labelTagName.Size = new System.Drawing.Size(58, 13);
			this.labelTagName.TabIndex = 4;
			this.labelTagName.Text = "&Tag name:";
			// 
			// textBoxTagName
			// 
			this.textBoxTagName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTagName.Location = new System.Drawing.Point(110, 58);
			this.textBoxTagName.Name = "textBoxTagName";
			this.textBoxTagName.ReadOnly = true;
			this.textBoxTagName.Size = new System.Drawing.Size(217, 20);
			this.textBoxTagName.TabIndex = 5;
			// 
			// labelValue
			// 
			this.labelValue.AutoSize = true;
			this.labelValue.Location = new System.Drawing.Point(6, 35);
			this.labelValue.Name = "labelValue";
			this.labelValue.Size = new System.Drawing.Size(37, 13);
			this.labelValue.TabIndex = 2;
			this.labelValue.Text = "&Value:";
			// 
			// textBoxValue
			// 
			this.textBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxValue.Location = new System.Drawing.Point(110, 32);
			this.textBoxValue.Name = "textBoxValue";
			this.textBoxValue.ReadOnly = true;
			this.textBoxValue.Size = new System.Drawing.Size(217, 20);
			this.textBoxValue.TabIndex = 3;
			// 
			// tabPageIdentifiers
			// 
			this.tabPageIdentifiers.AutoScroll = true;
			this.tabPageIdentifiers.Controls.Add(this.labelTagTypeId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxTagTypeId);
			this.tabPageIdentifiers.Controls.Add(this.labelNodeGroupId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxNodeGroupId);
			this.tabPageIdentifiers.Location = new System.Drawing.Point(4, 22);
			this.tabPageIdentifiers.Name = "tabPageIdentifiers";
			this.tabPageIdentifiers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIdentifiers.Size = new System.Drawing.Size(333, 313);
			this.tabPageIdentifiers.TabIndex = 1;
			this.tabPageIdentifiers.Text = "Identifiers";
			this.tabPageIdentifiers.UseVisualStyleBackColor = true;
			// 
			// labelTagTypeId
			// 
			this.labelTagTypeId.AutoSize = true;
			this.labelTagTypeId.Location = new System.Drawing.Point(6, 35);
			this.labelTagTypeId.Name = "labelTagTypeId";
			this.labelTagTypeId.Size = new System.Drawing.Size(66, 13);
			this.labelTagTypeId.TabIndex = 2;
			this.labelTagTypeId.Text = "&Tag type ID:";
			// 
			// textBoxTagTypeId
			// 
			this.textBoxTagTypeId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTagTypeId.Location = new System.Drawing.Point(110, 32);
			this.textBoxTagTypeId.Name = "textBoxTagTypeId";
			this.textBoxTagTypeId.ReadOnly = true;
			this.textBoxTagTypeId.Size = new System.Drawing.Size(217, 20);
			this.textBoxTagTypeId.TabIndex = 3;
			// 
			// labelNodeGroupId
			// 
			this.labelNodeGroupId.AutoSize = true;
			this.labelNodeGroupId.Location = new System.Drawing.Point(6, 9);
			this.labelNodeGroupId.Name = "labelNodeGroupId";
			this.labelNodeGroupId.Size = new System.Drawing.Size(80, 13);
			this.labelNodeGroupId.TabIndex = 0;
			this.labelNodeGroupId.Text = "&Node group ID:";
			// 
			// textBoxNodeGroupId
			// 
			this.textBoxNodeGroupId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNodeGroupId.Location = new System.Drawing.Point(110, 6);
			this.textBoxNodeGroupId.Name = "textBoxNodeGroupId";
			this.textBoxNodeGroupId.ReadOnly = true;
			this.textBoxNodeGroupId.Size = new System.Drawing.Size(217, 20);
			this.textBoxNodeGroupId.TabIndex = 1;
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
			// tabPageConfigurationFiles
			// 
			this.tabPageConfigurationFiles.Controls.Add(this.buttonConfigurationFile);
			this.tabPageConfigurationFiles.Controls.Add(this.listViewConfigurationFiles);
			this.tabPageConfigurationFiles.Location = new System.Drawing.Point(4, 22);
			this.tabPageConfigurationFiles.Name = "tabPageConfigurationFiles";
			this.tabPageConfigurationFiles.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageConfigurationFiles.Size = new System.Drawing.Size(333, 313);
			this.tabPageConfigurationFiles.TabIndex = 9;
			this.tabPageConfigurationFiles.Text = "Configuration files";
			this.tabPageConfigurationFiles.UseVisualStyleBackColor = true;
			// 
			// buttonConfigurationFile
			// 
			this.buttonConfigurationFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonConfigurationFile.Enabled = false;
			this.buttonConfigurationFile.Location = new System.Drawing.Point(6, 284);
			this.buttonConfigurationFile.Name = "buttonConfigurationFile";
			this.buttonConfigurationFile.Size = new System.Drawing.Size(85, 23);
			this.buttonConfigurationFile.TabIndex = 7;
			this.buttonConfigurationFile.Text = "Properties...";
			this.buttonConfigurationFile.UseVisualStyleBackColor = true;
			this.buttonConfigurationFile.Click += new System.EventHandler(this.OnConfigurationFileProperties);
			// 
			// listViewConfigurationFiles
			// 
			this.listViewConfigurationFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewConfigurationFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderConfigurationFile});
			this.listViewConfigurationFiles.FullRowSelect = true;
			this.listViewConfigurationFiles.GridLines = true;
			this.listViewConfigurationFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewConfigurationFiles.HideSelection = false;
			this.listViewConfigurationFiles.Location = new System.Drawing.Point(6, 6);
			this.listViewConfigurationFiles.MultiSelect = false;
			this.listViewConfigurationFiles.Name = "listViewConfigurationFiles";
			this.listViewConfigurationFiles.Size = new System.Drawing.Size(321, 272);
			this.listViewConfigurationFiles.SmallImageList = this.imageList;
			this.listViewConfigurationFiles.TabIndex = 6;
			this.listViewConfigurationFiles.UseCompatibleStateImageBehavior = false;
			this.listViewConfigurationFiles.View = System.Windows.Forms.View.Details;
			this.listViewConfigurationFiles.ItemActivate += new System.EventHandler(this.OnConfigurationFileProperties);
			this.listViewConfigurationFiles.SelectedIndexChanged += new System.EventHandler(this.OnConfigurationFileSelectionChanged);
			// 
			// columnHeaderConfigurationFile
			// 
			this.columnHeaderConfigurationFile.Text = "File ID";
			this.columnHeaderConfigurationFile.Width = 240;
			// 
			// ControlNodeGroupProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Name = "ControlNodeGroupProperties";
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageIdentifiers.ResumeLayout(false);
			this.tabPageIdentifiers.PerformLayout();
			this.tabPageNodes.ResumeLayout(false);
			this.tabPageConfigurationFiles.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxGroupName;
		private System.Windows.Forms.Label labelGroupName;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelValue;
		private System.Windows.Forms.TextBox textBoxValue;
		private System.Windows.Forms.Label labelTagName;
		private System.Windows.Forms.TextBox textBoxTagName;
		private System.Windows.Forms.TabPage tabPageIdentifiers;
		private System.Windows.Forms.Label labelNodeGroupId;
		private System.Windows.Forms.TextBox textBoxNodeGroupId;
		private System.Windows.Forms.TextBox textBoxTagTypeId;
		private System.Windows.Forms.Label labelTagTypeId;
		private System.Windows.Forms.TabPage tabPageNodes;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderNode;
		private System.Windows.Forms.Button buttonNode;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.TabPage tabPageConfigurationFiles;
		private System.Windows.Forms.ListView listViewConfigurationFiles;
		private System.Windows.Forms.ColumnHeader columnHeaderConfigurationFile;
		private System.Windows.Forms.Button buttonConfigurationFile;
	}
}
