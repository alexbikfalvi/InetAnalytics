namespace YtAnalytics.Controls.Comments
{
	partial class ControlComments
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlComments));
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCommenter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonAdd = new System.Windows.Forms.ToolStripButton();
			this.buttonRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonView = new System.Windows.Forms.ToolStripDropDownButton();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonImport = new System.Windows.Forms.ToolStripButton();
			this.buttonExport = new System.Windows.Forms.ToolStripButton();
			this.controlComment = new YtAnalytics.Controls.Comments.ControlCommentProperties();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.listView);
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.controlComment);
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 200;
			this.splitContainer.TabIndex = 2;
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderItem,
            this.columnHeaderCommenter,
            this.columnHeaderText});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(0, 25);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(598, 173);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 0;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemActivate += new System.EventHandler(this.OnViewComment);
			this.listView.SelectedIndexChanged += new System.EventHandler(this.OnCommentSelectionChanged);
			this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
			// 
			// columnHeaderTime
			// 
			this.columnHeaderTime.Text = "Time";
			this.columnHeaderTime.Width = 120;
			// 
			// columnHeaderItem
			// 
			this.columnHeaderItem.Text = "Item";
			this.columnHeaderItem.Width = 120;
			// 
			// columnHeaderCommenter
			// 
			this.columnHeaderCommenter.Text = "Commenter";
			this.columnHeaderCommenter.Width = 120;
			// 
			// columnHeaderText
			// 
			this.columnHeaderText.Text = "Text";
			this.columnHeaderText.Width = 180;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Comment_16.png");
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAdd,
            this.buttonRemove,
            this.toolStripSeparator1,
            this.buttonView,
            this.toolStripSeparator2,
            this.buttonImport,
            this.buttonExport});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(598, 25);
			this.toolStrip.TabIndex = 2;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonAdd
			// 
			this.buttonAdd.Image = global::YtAnalytics.Resources.CommentAdd_16;
			this.buttonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(104, 22);
			this.buttonAdd.Text = "&Add comment";
			this.buttonAdd.Click += new System.EventHandler(this.OnAdd);
			// 
			// buttonRemove
			// 
			this.buttonRemove.Enabled = false;
			this.buttonRemove.Image = global::YtAnalytics.Resources.CommentRemove_16;
			this.buttonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(125, 22);
			this.buttonRemove.Text = "&Remove comment";
			this.buttonRemove.Click += new System.EventHandler(this.OnRemove);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonView
			// 
			this.buttonView.DropDown = this.contextMenu;
			this.buttonView.Enabled = false;
			this.buttonView.Image = global::YtAnalytics.Resources.View_16;
			this.buttonView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonView.Name = "buttonView";
			this.buttonView.Size = new System.Drawing.Size(61, 22);
			this.buttonView.Text = "&View";
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProperties});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.OwnerItem = this.buttonView;
			this.contextMenu.Size = new System.Drawing.Size(128, 26);
			// 
			// menuItemProperties
			// 
			this.menuItemProperties.Image = global::YtAnalytics.Resources.Comment_16;
			this.menuItemProperties.Name = "menuItemProperties";
			this.menuItemProperties.Size = new System.Drawing.Size(127, 22);
			this.menuItemProperties.Text = "Properties";
			this.menuItemProperties.Click += new System.EventHandler(this.OnViewComment);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonImport
			// 
			this.buttonImport.Image = global::YtAnalytics.Resources.Import_16;
			this.buttonImport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(63, 22);
			this.buttonImport.Text = "I&mport";
			this.buttonImport.Click += new System.EventHandler(this.OnImport);
			// 
			// buttonExport
			// 
			this.buttonExport.Enabled = false;
			this.buttonExport.Image = global::YtAnalytics.Resources.Export_16;
			this.buttonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(60, 22);
			this.buttonExport.Text = "E&xport";
			this.buttonExport.Click += new System.EventHandler(this.OnExport);
			// 
			// controlComment
			// 
			this.controlComment.Comment = null;
			this.controlComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlComment.Location = new System.Drawing.Point(0, 0);
			this.controlComment.Name = "controlComment";
			this.controlComment.Size = new System.Drawing.Size(598, 194);
			this.controlComment.TabIndex = 0;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Comment XML file|*.xml";
			this.openFileDialog.ShowReadOnly = true;
			this.openFileDialog.Title = "Import Comment File";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Comment XML file|*.xml";
			this.saveFileDialog.Title = "Export Comment File";
			// 
			// ControlComments
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlComments";
			this.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ToolStrip toolStrip;
		private ControlCommentProperties controlComment;
		private System.Windows.Forms.ToolStripButton buttonAdd;
		private System.Windows.Forms.ToolStripButton buttonRemove;
		private System.Windows.Forms.ColumnHeader columnHeaderTime;
		private System.Windows.Forms.ColumnHeader columnHeaderItem;
		private System.Windows.Forms.ColumnHeader columnHeaderCommenter;
		private System.Windows.Forms.ColumnHeader columnHeaderText;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemProperties;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripDropDownButton buttonView;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton buttonImport;
		private System.Windows.Forms.ToolStripButton buttonExport;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
	}
}
