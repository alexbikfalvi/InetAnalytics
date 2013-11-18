namespace InetAnalytics.Controls.Tools
{
	partial class ControlToolboxSettings
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
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonAdd = new System.Windows.Forms.ToolStripButton();
			this.buttonRemove = new System.Windows.Forms.ToolStripButton();
			this.separator = new System.Windows.Forms.ToolStripSeparator();
			this.buttonProperties = new System.Windows.Forms.ToolStripButton();
			this.listView = new System.Windows.Forms.ListView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderVendor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderProduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAdd,
            this.buttonRemove,
            this.separator,
            this.buttonProperties});
			this.toolStrip.Location = new System.Drawing.Point(1, 1);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(598, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonAdd
			// 
			this.buttonAdd.Image = global::InetAnalytics.Resources.ToolboxAdd_16;
			this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(73, 22);
			this.buttonAdd.Text = "Add tool";
			this.buttonAdd.Click += new System.EventHandler(this.OnAdd);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Enabled = false;
			this.buttonRemove.Image = global::InetAnalytics.Resources.ToolboxRemove_16;
			this.buttonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(94, 22);
			this.buttonRemove.Text = "Remove tool";
			this.buttonRemove.Click += new System.EventHandler(this.OnRemove);
			// 
			// separator
			// 
			this.separator.Name = "separator";
			this.separator.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonProperties
			// 
			this.buttonProperties.Enabled = false;
			this.buttonProperties.Image = global::InetAnalytics.Resources.Properties_16;
			this.buttonProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonProperties.Name = "buttonProperties";
			this.buttonProperties.Size = new System.Drawing.Size(80, 22);
			this.buttonProperties.Text = "Properties";
			this.buttonProperties.Click += new System.EventHandler(this.OnProperties);
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderVendor,
            this.columnHeaderProduct,
            this.columnHeaderVersion});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(1, 26);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(598, 373);
			this.listView.TabIndex = 1;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 150;
			// 
			// columnHeaderVendor
			// 
			this.columnHeaderVendor.Text = "Vendor";
			this.columnHeaderVendor.Width = 120;
			// 
			// columnHeaderProduct
			// 
			this.columnHeaderProduct.Text = "Product";
			this.columnHeaderProduct.Width = 120;
			// 
			// columnHeaderVersion
			// 
			this.columnHeaderVersion.Text = "Version";
			this.columnHeaderVersion.Width = 120;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Toolbox library files (*.dll)|*.dll";
			this.openFileDialog.Title = "Load Toolbox Library";
			// 
			// ControlToolboxSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listView);
			this.Controls.Add(this.toolStrip);
			this.Enabled = false;
			this.Name = "ControlToolboxSettings";
			this.Padding = new System.Windows.Forms.Padding(1);
			this.ShowBorder = true;
			this.Size = new System.Drawing.Size(600, 400);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonAdd;
		private System.Windows.Forms.ToolStripButton buttonRemove;
		private System.Windows.Forms.ToolStripSeparator separator;
		private System.Windows.Forms.ToolStripButton buttonProperties;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderVendor;
		private System.Windows.Forms.ColumnHeader columnHeaderProduct;
		private System.Windows.Forms.ColumnHeader columnHeaderVersion;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}
