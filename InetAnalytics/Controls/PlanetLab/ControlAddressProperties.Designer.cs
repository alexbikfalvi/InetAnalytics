namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlAddressProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlAddressProperties));
			this.textBoxAddress = new System.Windows.Forms.TextBox();
			this.labelAddress = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.labelCountry = new System.Windows.Forms.Label();
			this.labelState = new System.Windows.Forms.Label();
			this.textBoxCountry = new System.Windows.Forms.TextBox();
			this.textBoxState = new System.Windows.Forms.TextBox();
			this.labelCity = new System.Windows.Forms.Label();
			this.textBoxCity = new System.Windows.Forms.TextBox();
			this.labelPostalCode = new System.Windows.Forms.Label();
			this.textBoxPostalCode = new System.Windows.Forms.TextBox();
			this.tabPageIdentifiers = new System.Windows.Forms.TabPage();
			this.labelAddressId = new System.Windows.Forms.Label();
			this.textBoxAddressId = new System.Windows.Forms.TextBox();
			this.tabPageTypes = new System.Windows.Forms.TabPage();
			this.buttonType = new System.Windows.Forms.Button();
			this.listViewTypes = new System.Windows.Forms.ListView();
			this.columnHeaderTypeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageIdentifiers.SuspendLayout();
			this.tabPageTypes.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxAddress
			// 
			this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxAddress.Location = new System.Drawing.Point(110, 6);
			this.textBoxAddress.Multiline = true;
			this.textBoxAddress.Name = "textBoxAddress";
			this.textBoxAddress.ReadOnly = true;
			this.textBoxAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxAddress.Size = new System.Drawing.Size(217, 100);
			this.textBoxAddress.TabIndex = 1;
			// 
			// labelAddress
			// 
			this.labelAddress.AutoSize = true;
			this.labelAddress.Location = new System.Drawing.Point(6, 9);
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(48, 13);
			this.labelAddress.TabIndex = 0;
			this.labelAddress.Text = "&Address:";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageIdentifiers);
			this.tabControl.Controls.Add(this.tabPageTypes);
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
			this.tabPageGeneral.Controls.Add(this.labelCountry);
			this.tabPageGeneral.Controls.Add(this.labelState);
			this.tabPageGeneral.Controls.Add(this.textBoxCountry);
			this.tabPageGeneral.Controls.Add(this.textBoxState);
			this.tabPageGeneral.Controls.Add(this.labelCity);
			this.tabPageGeneral.Controls.Add(this.textBoxCity);
			this.tabPageGeneral.Controls.Add(this.labelPostalCode);
			this.tabPageGeneral.Controls.Add(this.textBoxPostalCode);
			this.tabPageGeneral.Controls.Add(this.labelAddress);
			this.tabPageGeneral.Controls.Add(this.textBoxAddress);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(333, 313);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// labelCountry
			// 
			this.labelCountry.AutoSize = true;
			this.labelCountry.Location = new System.Drawing.Point(6, 193);
			this.labelCountry.Name = "labelCountry";
			this.labelCountry.Size = new System.Drawing.Size(46, 13);
			this.labelCountry.TabIndex = 8;
			this.labelCountry.Text = "C&ountry:";
			// 
			// labelState
			// 
			this.labelState.AutoSize = true;
			this.labelState.Location = new System.Drawing.Point(6, 167);
			this.labelState.Name = "labelState";
			this.labelState.Size = new System.Drawing.Size(35, 13);
			this.labelState.TabIndex = 6;
			this.labelState.Text = "&State:";
			// 
			// textBoxCountry
			// 
			this.textBoxCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCountry.Location = new System.Drawing.Point(110, 190);
			this.textBoxCountry.Name = "textBoxCountry";
			this.textBoxCountry.ReadOnly = true;
			this.textBoxCountry.Size = new System.Drawing.Size(217, 20);
			this.textBoxCountry.TabIndex = 9;
			// 
			// textBoxState
			// 
			this.textBoxState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxState.Location = new System.Drawing.Point(110, 164);
			this.textBoxState.Name = "textBoxState";
			this.textBoxState.ReadOnly = true;
			this.textBoxState.Size = new System.Drawing.Size(217, 20);
			this.textBoxState.TabIndex = 7;
			// 
			// labelCity
			// 
			this.labelCity.AutoSize = true;
			this.labelCity.Location = new System.Drawing.Point(6, 141);
			this.labelCity.Name = "labelCity";
			this.labelCity.Size = new System.Drawing.Size(27, 13);
			this.labelCity.TabIndex = 4;
			this.labelCity.Text = "&City:";
			// 
			// textBoxCity
			// 
			this.textBoxCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCity.Location = new System.Drawing.Point(110, 138);
			this.textBoxCity.Name = "textBoxCity";
			this.textBoxCity.ReadOnly = true;
			this.textBoxCity.Size = new System.Drawing.Size(217, 20);
			this.textBoxCity.TabIndex = 5;
			// 
			// labelPostalCode
			// 
			this.labelPostalCode.AutoSize = true;
			this.labelPostalCode.Location = new System.Drawing.Point(6, 115);
			this.labelPostalCode.Name = "labelPostalCode";
			this.labelPostalCode.Size = new System.Drawing.Size(66, 13);
			this.labelPostalCode.TabIndex = 2;
			this.labelPostalCode.Text = "&Postal code:";
			// 
			// textBoxPostalCode
			// 
			this.textBoxPostalCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPostalCode.Location = new System.Drawing.Point(110, 112);
			this.textBoxPostalCode.Name = "textBoxPostalCode";
			this.textBoxPostalCode.ReadOnly = true;
			this.textBoxPostalCode.Size = new System.Drawing.Size(217, 20);
			this.textBoxPostalCode.TabIndex = 3;
			// 
			// tabPageIdentifiers
			// 
			this.tabPageIdentifiers.AutoScroll = true;
			this.tabPageIdentifiers.Controls.Add(this.labelAddressId);
			this.tabPageIdentifiers.Controls.Add(this.textBoxAddressId);
			this.tabPageIdentifiers.Location = new System.Drawing.Point(4, 22);
			this.tabPageIdentifiers.Name = "tabPageIdentifiers";
			this.tabPageIdentifiers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIdentifiers.Size = new System.Drawing.Size(333, 313);
			this.tabPageIdentifiers.TabIndex = 1;
			this.tabPageIdentifiers.Text = "Identifiers";
			this.tabPageIdentifiers.UseVisualStyleBackColor = true;
			// 
			// labelAddressId
			// 
			this.labelAddressId.AutoSize = true;
			this.labelAddressId.Location = new System.Drawing.Point(6, 9);
			this.labelAddressId.Name = "labelAddressId";
			this.labelAddressId.Size = new System.Drawing.Size(62, 13);
			this.labelAddressId.TabIndex = 0;
			this.labelAddressId.Text = "&Address ID:";
			// 
			// textBoxAddressId
			// 
			this.textBoxAddressId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxAddressId.Location = new System.Drawing.Point(110, 6);
			this.textBoxAddressId.Name = "textBoxAddressId";
			this.textBoxAddressId.ReadOnly = true;
			this.textBoxAddressId.Size = new System.Drawing.Size(217, 20);
			this.textBoxAddressId.TabIndex = 1;
			// 
			// tabPageTypes
			// 
			this.tabPageTypes.Controls.Add(this.buttonType);
			this.tabPageTypes.Controls.Add(this.listViewTypes);
			this.tabPageTypes.Location = new System.Drawing.Point(4, 22);
			this.tabPageTypes.Name = "tabPageTypes";
			this.tabPageTypes.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTypes.Size = new System.Drawing.Size(333, 313);
			this.tabPageTypes.TabIndex = 4;
			this.tabPageTypes.Text = "Types";
			this.tabPageTypes.UseVisualStyleBackColor = true;
			// 
			// buttonType
			// 
			this.buttonType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonType.Enabled = false;
			this.buttonType.Location = new System.Drawing.Point(6, 284);
			this.buttonType.Name = "buttonType";
			this.buttonType.Size = new System.Drawing.Size(85, 23);
			this.buttonType.TabIndex = 2;
			this.buttonType.Text = "Properties...";
			this.buttonType.UseVisualStyleBackColor = true;
			this.buttonType.Click += new System.EventHandler(this.OnTypeProperties);
			// 
			// listViewTypes
			// 
			this.listViewTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTypeId,
            this.columnHeaderType});
			this.listViewTypes.FullRowSelect = true;
			this.listViewTypes.GridLines = true;
			this.listViewTypes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewTypes.HideSelection = false;
			this.listViewTypes.Location = new System.Drawing.Point(6, 6);
			this.listViewTypes.MultiSelect = false;
			this.listViewTypes.Name = "listViewTypes";
			this.listViewTypes.Size = new System.Drawing.Size(321, 272);
			this.listViewTypes.SmallImageList = this.imageList;
			this.listViewTypes.TabIndex = 1;
			this.listViewTypes.UseCompatibleStateImageBehavior = false;
			this.listViewTypes.View = System.Windows.Forms.View.Details;
			this.listViewTypes.ItemActivate += new System.EventHandler(this.OnTypeProperties);
			this.listViewTypes.SelectedIndexChanged += new System.EventHandler(this.OnTypeSelectionChanged);
			// 
			// columnHeaderTypeId
			// 
			this.columnHeaderTypeId.Text = "Type ID";
			this.columnHeaderTypeId.Width = 120;
			// 
			// columnHeaderType
			// 
			this.columnHeaderType.Text = "Type";
			this.columnHeaderType.Width = 120;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "ObjectSmallId");
			// 
			// ControlPlanetLabAddressProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Name = "ControlPlanetLabAddressProperties";
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageIdentifiers.ResumeLayout(false);
			this.tabPageIdentifiers.PerformLayout();
			this.tabPageTypes.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxAddress;
		private System.Windows.Forms.Label labelAddress;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelPostalCode;
		private System.Windows.Forms.TextBox textBoxPostalCode;
		private System.Windows.Forms.Label labelCity;
		private System.Windows.Forms.TextBox textBoxState;
		private System.Windows.Forms.TextBox textBoxCity;
		private System.Windows.Forms.TextBox textBoxCountry;
		private System.Windows.Forms.Label labelCountry;
		private System.Windows.Forms.Label labelState;
		private System.Windows.Forms.TabPage tabPageIdentifiers;
		private System.Windows.Forms.Label labelAddressId;
		private System.Windows.Forms.TextBox textBoxAddressId;
		private System.Windows.Forms.TabPage tabPageTypes;
		private System.Windows.Forms.ListView listViewTypes;
		private System.Windows.Forms.ColumnHeader columnHeaderTypeId;
		private System.Windows.Forms.Button buttonType;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ColumnHeader columnHeaderType;
	}
}
