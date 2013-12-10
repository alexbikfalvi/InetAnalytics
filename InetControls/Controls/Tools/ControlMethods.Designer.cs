namespace InetAnalytics.Controls.Tools
{
	partial class ControlMethods
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlMethods));
			this.listViewMethods = new System.Windows.Forms.ListView();
			this.columnHeaderMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderTool = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonAdd = new System.Windows.Forms.ToolStripButton();
			this.buttonRemove = new System.Windows.Forms.ToolStripButton();
			this.toolSplitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.toolSplitContainer)).BeginInit();
			this.toolSplitContainer.Panel1.SuspendLayout();
			this.toolSplitContainer.Panel2.SuspendLayout();
			this.toolSplitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// listViewMethods
			// 
			this.listViewMethods.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewMethods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMethod,
            this.columnHeaderTool,
            this.columnHeaderVersion});
			this.listViewMethods.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewMethods.FullRowSelect = true;
			this.listViewMethods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewMethods.HideSelection = false;
			this.listViewMethods.Location = new System.Drawing.Point(1, 26);
			this.listViewMethods.MultiSelect = false;
			this.listViewMethods.Name = "listViewMethods";
			this.listViewMethods.Size = new System.Drawing.Size(448, 223);
			this.listViewMethods.SmallImageList = this.imageList;
			this.listViewMethods.TabIndex = 5;
			this.listViewMethods.UseCompatibleStateImageBehavior = false;
			this.listViewMethods.View = System.Windows.Forms.View.Details;
			this.listViewMethods.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
			// 
			// columnHeaderMethod
			// 
			this.columnHeaderMethod.Text = "Method";
			this.columnHeaderMethod.Width = 200;
			// 
			// columnHeaderTool
			// 
			this.columnHeaderTool.Text = "Tool";
			this.columnHeaderTool.Width = 120;
			// 
			// columnHeaderVersion
			// 
			this.columnHeaderVersion.Text = "Version";
			this.columnHeaderVersion.Width = 120;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxDescription.Location = new System.Drawing.Point(1, 1);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescription.Size = new System.Drawing.Size(448, 93);
			this.textBoxDescription.TabIndex = 0;
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAdd,
            this.buttonRemove});
			this.toolStrip.Location = new System.Drawing.Point(1, 1);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(448, 25);
			this.toolStrip.TabIndex = 7;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonAdd
			// 
			this.buttonAdd.Image = global::InetAnalytics.Resources.CubeAdd_16;
			this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(94, 22);
			this.buttonAdd.Text = "&Add method";
			this.buttonAdd.Click += new System.EventHandler(this.OnAdd);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Enabled = false;
			this.buttonRemove.Image = global::InetAnalytics.Resources.CubeRemove_16;
			this.buttonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(115, 22);
			this.buttonRemove.Text = "&Remove method";
			this.buttonRemove.Click += new System.EventHandler(this.OnRemove);
			// 
			// toolSplitContainer
			// 
			this.toolSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.toolSplitContainer.Name = "toolSplitContainer";
			this.toolSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// toolSplitContainer.Panel1
			// 
			this.toolSplitContainer.Panel1.Controls.Add(this.listViewMethods);
			this.toolSplitContainer.Panel1.Controls.Add(this.toolStrip);
			this.toolSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(1);
			// 
			// toolSplitContainer.Panel2
			// 
			this.toolSplitContainer.Panel2.Controls.Add(this.textBoxDescription);
			this.toolSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(1);
			this.toolSplitContainer.Size = new System.Drawing.Size(450, 350);
			this.toolSplitContainer.SplitterDistance = 250;
			this.toolSplitContainer.SplitterWidth = 5;
			this.toolSplitContainer.TabIndex = 8;
			this.toolSplitContainer.UseTheme = false;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Cube");
			// 
			// ControlMethods
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolSplitContainer);
			this.Enabled = false;
			this.Name = "ControlMethods";
			this.Size = new System.Drawing.Size(450, 350);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.toolSplitContainer.Panel1.ResumeLayout(false);
			this.toolSplitContainer.Panel1.PerformLayout();
			this.toolSplitContainer.Panel2.ResumeLayout(false);
			this.toolSplitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.toolSplitContainer)).EndInit();
			this.toolSplitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listViewMethods;
		private System.Windows.Forms.ColumnHeader columnHeaderMethod;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.ColumnHeader columnHeaderTool;
		private System.Windows.Forms.ColumnHeader columnHeaderVersion;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonAdd;
		private System.Windows.Forms.ToolStripButton buttonRemove;
		private DotNetApi.Windows.Controls.ToolSplitContainer toolSplitContainer;
		private System.Windows.Forms.ImageList imageList;
	}
}
