namespace InetAnalytics.Controls.Database
{
	partial class ControlTableProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlTableProperties));
			this.labelTitle = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.buttonSelectDatabase = new System.Windows.Forms.Button();
			this.labelDatabase = new System.Windows.Forms.Label();
			this.textBoxDatabase = new System.Windows.Forms.TextBox();
			this.checkBoxReadOnly = new System.Windows.Forms.CheckBox();
			this.buttonSelectTable = new System.Windows.Forms.Button();
			this.checkBoxDefaultDatabase = new System.Windows.Forms.CheckBox();
			this.textBoxSchema = new System.Windows.Forms.TextBox();
			this.textBoxNameDatabase = new System.Windows.Forms.TextBox();
			this.textBoxNameLocal = new System.Windows.Forms.TextBox();
			this.labelSchema = new System.Windows.Forms.Label();
			this.labelNameDatabase = new System.Windows.Forms.Label();
			this.labelNameLocal = new System.Windows.Forms.Label();
			this.tabPageFields = new System.Windows.Forms.TabPage();
			this.buttonSelectField = new System.Windows.Forms.Button();
			this.listViewFields = new System.Windows.Forms.ListView();
			this.columnHeaderLocalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDatabaseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLocalType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDatabaseType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderNullable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.labelFields = new System.Windows.Forms.Label();
			this.tabPageRelationship = new System.Windows.Forms.TabPage();
			this.buttonRelationshipProperties = new System.Windows.Forms.Button();
			this.listViewRelationships = new System.Windows.Forms.ListView();
			this.columnHeaderTableRight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderFieldLeft = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderFieldRight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labelRelationship = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageFields.SuspendLayout();
			this.tabPageRelationship.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(59, 29);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(63, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Table name";
			this.labelTitle.UseMnemonic = false;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageFields);
			this.tabControl.Controls.Add(this.tabPageRelationship);
			this.tabControl.Location = new System.Drawing.Point(3, 58);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(394, 289);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.buttonSelectDatabase);
			this.tabPageGeneral.Controls.Add(this.labelDatabase);
			this.tabPageGeneral.Controls.Add(this.textBoxDatabase);
			this.tabPageGeneral.Controls.Add(this.checkBoxReadOnly);
			this.tabPageGeneral.Controls.Add(this.buttonSelectTable);
			this.tabPageGeneral.Controls.Add(this.checkBoxDefaultDatabase);
			this.tabPageGeneral.Controls.Add(this.textBoxSchema);
			this.tabPageGeneral.Controls.Add(this.textBoxNameDatabase);
			this.tabPageGeneral.Controls.Add(this.textBoxNameLocal);
			this.tabPageGeneral.Controls.Add(this.labelSchema);
			this.tabPageGeneral.Controls.Add(this.labelNameDatabase);
			this.tabPageGeneral.Controls.Add(this.labelNameLocal);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(386, 263);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// buttonSelectDatabase
			// 
			this.buttonSelectDatabase.Enabled = false;
			this.buttonSelectDatabase.Location = new System.Drawing.Point(102, 191);
			this.buttonSelectDatabase.Name = "buttonSelectDatabase";
			this.buttonSelectDatabase.Size = new System.Drawing.Size(105, 23);
			this.buttonSelectDatabase.TabIndex = 11;
			this.buttonSelectDatabase.Text = "Select database...";
			this.buttonSelectDatabase.UseVisualStyleBackColor = true;
			this.buttonSelectDatabase.Click += new System.EventHandler(this.OnSelectDatabase);
			// 
			// labelDatabase
			// 
			this.labelDatabase.AutoSize = true;
			this.labelDatabase.Location = new System.Drawing.Point(10, 93);
			this.labelDatabase.Name = "labelDatabase";
			this.labelDatabase.Size = new System.Drawing.Size(56, 13);
			this.labelDatabase.TabIndex = 6;
			this.labelDatabase.Text = "D&atabase:";
			// 
			// textBoxDatabase
			// 
			this.textBoxDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDatabase.Location = new System.Drawing.Point(102, 90);
			this.textBoxDatabase.Name = "textBoxDatabase";
			this.textBoxDatabase.ReadOnly = true;
			this.textBoxDatabase.Size = new System.Drawing.Size(256, 20);
			this.textBoxDatabase.TabIndex = 7;
			// 
			// checkBoxReadOnly
			// 
			this.checkBoxReadOnly.AutoSize = true;
			this.checkBoxReadOnly.Enabled = false;
			this.checkBoxReadOnly.Location = new System.Drawing.Point(102, 139);
			this.checkBoxReadOnly.Name = "checkBoxReadOnly";
			this.checkBoxReadOnly.Size = new System.Drawing.Size(74, 17);
			this.checkBoxReadOnly.TabIndex = 9;
			this.checkBoxReadOnly.Text = "Read &only";
			this.checkBoxReadOnly.UseVisualStyleBackColor = true;
			// 
			// buttonSelectTable
			// 
			this.buttonSelectTable.Enabled = false;
			this.buttonSelectTable.Location = new System.Drawing.Point(102, 162);
			this.buttonSelectTable.Name = "buttonSelectTable";
			this.buttonSelectTable.Size = new System.Drawing.Size(105, 23);
			this.buttonSelectTable.TabIndex = 10;
			this.buttonSelectTable.Text = "Select table...";
			this.buttonSelectTable.UseVisualStyleBackColor = true;
			this.buttonSelectTable.Click += new System.EventHandler(this.OnSelectTable);
			// 
			// checkBoxDefaultDatabase
			// 
			this.checkBoxDefaultDatabase.AutoSize = true;
			this.checkBoxDefaultDatabase.Enabled = false;
			this.checkBoxDefaultDatabase.Location = new System.Drawing.Point(102, 116);
			this.checkBoxDefaultDatabase.Name = "checkBoxDefaultDatabase";
			this.checkBoxDefaultDatabase.Size = new System.Drawing.Size(132, 17);
			this.checkBoxDefaultDatabase.TabIndex = 8;
			this.checkBoxDefaultDatabase.Text = "&Uses default database";
			this.checkBoxDefaultDatabase.UseVisualStyleBackColor = true;
			this.checkBoxDefaultDatabase.CheckedChanged += new System.EventHandler(this.OnDefaultDatabaseChanged);
			// 
			// textBoxSchema
			// 
			this.textBoxSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSchema.Location = new System.Drawing.Point(102, 64);
			this.textBoxSchema.Name = "textBoxSchema";
			this.textBoxSchema.ReadOnly = true;
			this.textBoxSchema.Size = new System.Drawing.Size(256, 20);
			this.textBoxSchema.TabIndex = 5;
			// 
			// textBoxNameDatabase
			// 
			this.textBoxNameDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNameDatabase.Location = new System.Drawing.Point(102, 38);
			this.textBoxNameDatabase.Name = "textBoxNameDatabase";
			this.textBoxNameDatabase.ReadOnly = true;
			this.textBoxNameDatabase.Size = new System.Drawing.Size(256, 20);
			this.textBoxNameDatabase.TabIndex = 3;
			// 
			// textBoxNameLocal
			// 
			this.textBoxNameLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNameLocal.Location = new System.Drawing.Point(102, 12);
			this.textBoxNameLocal.Name = "textBoxNameLocal";
			this.textBoxNameLocal.ReadOnly = true;
			this.textBoxNameLocal.Size = new System.Drawing.Size(256, 20);
			this.textBoxNameLocal.TabIndex = 1;
			// 
			// labelSchema
			// 
			this.labelSchema.AutoSize = true;
			this.labelSchema.Location = new System.Drawing.Point(10, 67);
			this.labelSchema.Name = "labelSchema";
			this.labelSchema.Size = new System.Drawing.Size(49, 13);
			this.labelSchema.TabIndex = 4;
			this.labelSchema.Text = "&Schema:";
			// 
			// labelNameDatabase
			// 
			this.labelNameDatabase.AutoSize = true;
			this.labelNameDatabase.Location = new System.Drawing.Point(10, 41);
			this.labelNameDatabase.Name = "labelNameDatabase";
			this.labelNameDatabase.Size = new System.Drawing.Size(85, 13);
			this.labelNameDatabase.TabIndex = 2;
			this.labelNameDatabase.Text = "&Database name:";
			// 
			// labelNameLocal
			// 
			this.labelNameLocal.AutoSize = true;
			this.labelNameLocal.Location = new System.Drawing.Point(10, 15);
			this.labelNameLocal.Name = "labelNameLocal";
			this.labelNameLocal.Size = new System.Drawing.Size(65, 13);
			this.labelNameLocal.TabIndex = 0;
			this.labelNameLocal.Text = "&Local name:";
			// 
			// tabPageFields
			// 
			this.tabPageFields.Controls.Add(this.buttonSelectField);
			this.tabPageFields.Controls.Add(this.listViewFields);
			this.tabPageFields.Controls.Add(this.labelFields);
			this.tabPageFields.Location = new System.Drawing.Point(4, 22);
			this.tabPageFields.Name = "tabPageFields";
			this.tabPageFields.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageFields.Size = new System.Drawing.Size(386, 263);
			this.tabPageFields.TabIndex = 1;
			this.tabPageFields.Text = "Fields";
			this.tabPageFields.UseVisualStyleBackColor = true;
			// 
			// buttonSelectField
			// 
			this.buttonSelectField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonSelectField.Enabled = false;
			this.buttonSelectField.Location = new System.Drawing.Point(6, 234);
			this.buttonSelectField.Name = "buttonSelectField";
			this.buttonSelectField.Size = new System.Drawing.Size(95, 23);
			this.buttonSelectField.TabIndex = 2;
			this.buttonSelectField.Text = "&Select field...";
			this.buttonSelectField.UseVisualStyleBackColor = true;
			this.buttonSelectField.Click += new System.EventHandler(this.OnSelectField);
			// 
			// listViewFields
			// 
			this.listViewFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLocalName,
            this.columnHeaderDatabaseName,
            this.columnHeaderLocalType,
            this.columnHeaderDatabaseType,
            this.columnHeaderNullable});
			this.listViewFields.FullRowSelect = true;
			this.listViewFields.GridLines = true;
			this.listViewFields.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewFields.HideSelection = false;
			this.listViewFields.Location = new System.Drawing.Point(6, 26);
			this.listViewFields.MultiSelect = false;
			this.listViewFields.Name = "listViewFields";
			this.listViewFields.Size = new System.Drawing.Size(374, 202);
			this.listViewFields.SmallImageList = this.imageList;
			this.listViewFields.TabIndex = 1;
			this.listViewFields.UseCompatibleStateImageBehavior = false;
			this.listViewFields.View = System.Windows.Forms.View.Details;
			this.listViewFields.ItemActivate += new System.EventHandler(this.OnFieldProperties);
			this.listViewFields.SelectedIndexChanged += new System.EventHandler(this.OnSelectedFieldChanged);
			// 
			// columnHeaderLocalName
			// 
			this.columnHeaderLocalName.Text = "Local name";
			this.columnHeaderLocalName.Width = 100;
			// 
			// columnHeaderDatabaseName
			// 
			this.columnHeaderDatabaseName.Text = "Database name";
			this.columnHeaderDatabaseName.Width = 100;
			// 
			// columnHeaderLocalType
			// 
			this.columnHeaderLocalType.Text = "Local type";
			this.columnHeaderLocalType.Width = 80;
			// 
			// columnHeaderDatabaseType
			// 
			this.columnHeaderDatabaseType.Text = "Database type";
			this.columnHeaderDatabaseType.Width = 80;
			// 
			// columnHeaderNullable
			// 
			this.columnHeaderNullable.Text = "Nullable";
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Field");
			this.imageList.Images.SetKeyName(1, "FieldWarning");
			this.imageList.Images.SetKeyName(2, "Relationship");
			// 
			// labelFields
			// 
			this.labelFields.AutoSize = true;
			this.labelFields.Location = new System.Drawing.Point(3, 10);
			this.labelFields.Name = "labelFields";
			this.labelFields.Size = new System.Drawing.Size(277, 13);
			this.labelFields.TabIndex = 0;
			this.labelFields.Text = "Select a table field and change its database name below:";
			// 
			// tabPageRelationship
			// 
			this.tabPageRelationship.Controls.Add(this.buttonRelationshipProperties);
			this.tabPageRelationship.Controls.Add(this.listViewRelationships);
			this.tabPageRelationship.Controls.Add(this.labelRelationship);
			this.tabPageRelationship.Location = new System.Drawing.Point(4, 22);
			this.tabPageRelationship.Name = "tabPageRelationship";
			this.tabPageRelationship.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRelationship.Size = new System.Drawing.Size(386, 263);
			this.tabPageRelationship.TabIndex = 2;
			this.tabPageRelationship.Text = "Relationship";
			this.tabPageRelationship.UseVisualStyleBackColor = true;
			// 
			// buttonRelationshipProperties
			// 
			this.buttonRelationshipProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRelationshipProperties.Enabled = false;
			this.buttonRelationshipProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.buttonRelationshipProperties.Location = new System.Drawing.Point(6, 234);
			this.buttonRelationshipProperties.Name = "buttonRelationshipProperties";
			this.buttonRelationshipProperties.Size = new System.Drawing.Size(95, 23);
			this.buttonRelationshipProperties.TabIndex = 2;
			this.buttonRelationshipProperties.Text = "&Properties";
			this.buttonRelationshipProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRelationshipProperties.UseVisualStyleBackColor = true;
			this.buttonRelationshipProperties.Click += new System.EventHandler(this.OnRelationshipProperties);
			// 
			// listViewRelationships
			// 
			this.listViewRelationships.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewRelationships.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTableRight,
            this.columnHeaderFieldLeft,
            this.columnHeaderFieldRight});
			this.listViewRelationships.FullRowSelect = true;
			this.listViewRelationships.GridLines = true;
			this.listViewRelationships.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewRelationships.HideSelection = false;
			this.listViewRelationships.Location = new System.Drawing.Point(6, 26);
			this.listViewRelationships.MultiSelect = false;
			this.listViewRelationships.Name = "listViewRelationships";
			this.listViewRelationships.Size = new System.Drawing.Size(374, 202);
			this.listViewRelationships.SmallImageList = this.imageList;
			this.listViewRelationships.TabIndex = 1;
			this.listViewRelationships.UseCompatibleStateImageBehavior = false;
			this.listViewRelationships.View = System.Windows.Forms.View.Details;
			this.listViewRelationships.ItemActivate += new System.EventHandler(this.OnRelationshipProperties);
			this.listViewRelationships.SelectedIndexChanged += new System.EventHandler(this.OnRelationshipSelectionChanged);
			// 
			// columnHeaderTableRight
			// 
			this.columnHeaderTableRight.Text = "Remote table";
			this.columnHeaderTableRight.Width = 100;
			// 
			// columnHeaderFieldLeft
			// 
			this.columnHeaderFieldLeft.Text = "Local field";
			this.columnHeaderFieldLeft.Width = 80;
			// 
			// columnHeaderFieldRight
			// 
			this.columnHeaderFieldRight.Text = "Remote field";
			this.columnHeaderFieldRight.Width = 80;
			// 
			// labelRelationship
			// 
			this.labelRelationship.AutoSize = true;
			this.labelRelationship.Location = new System.Drawing.Point(3, 10);
			this.labelRelationship.Name = "labelRelationship";
			this.labelRelationship.Size = new System.Drawing.Size(283, 13);
			this.labelRelationship.TabIndex = 0;
			this.labelRelationship.Text = "This table matches the tables below on the following fields:";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.Table_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ControlTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlTable";
			this.Size = new System.Drawing.Size(400, 350);
			this.Controls.SetChildIndex(this.pictureBox, 0);
			this.Controls.SetChildIndex(this.labelTitle, 0);
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageFields.ResumeLayout(false);
			this.tabPageFields.PerformLayout();
			this.tabPageRelationship.ResumeLayout(false);
			this.tabPageRelationship.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelNameLocal;
		private System.Windows.Forms.Label labelNameDatabase;
		private System.Windows.Forms.TextBox textBoxNameLocal;
		private System.Windows.Forms.TextBox textBoxNameDatabase;
		private System.Windows.Forms.Label labelSchema;
		private System.Windows.Forms.TextBox textBoxSchema;
		private System.Windows.Forms.TabPage tabPageFields;
		private System.Windows.Forms.Label labelFields;
		private System.Windows.Forms.ListView listViewFields;
		private System.Windows.Forms.ColumnHeader columnHeaderLocalName;
		private System.Windows.Forms.ColumnHeader columnHeaderDatabaseName;
		private System.Windows.Forms.ColumnHeader columnHeaderLocalType;
		private System.Windows.Forms.ColumnHeader columnHeaderDatabaseType;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button buttonSelectField;
		private System.Windows.Forms.CheckBox checkBoxDefaultDatabase;
		private System.Windows.Forms.Button buttonSelectTable;
		private System.Windows.Forms.CheckBox checkBoxReadOnly;
		private System.Windows.Forms.ColumnHeader columnHeaderNullable;
		private System.Windows.Forms.TabPage tabPageRelationship;
		private System.Windows.Forms.Label labelRelationship;
		private System.Windows.Forms.ListView listViewRelationships;
		private System.Windows.Forms.ColumnHeader columnHeaderTableRight;
		private System.Windows.Forms.ColumnHeader columnHeaderFieldLeft;
		private System.Windows.Forms.ColumnHeader columnHeaderFieldRight;
		private System.Windows.Forms.Button buttonRelationshipProperties;
		private System.Windows.Forms.Label labelDatabase;
		private System.Windows.Forms.TextBox textBoxDatabase;
		private System.Windows.Forms.Button buttonSelectDatabase;
	}
}
