namespace InetAnalytics.Controls.YouTube
{
	partial class ControlCommentList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCommentList));
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonPrevious = new System.Windows.Forms.ToolStripButton();
			this.labelPage = new System.Windows.Forms.ToolStripLabel();
			this.buttonNext = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.labelVideosPerPage = new System.Windows.Forms.ToolStripLabel();
			this.comboBoxCommentsPerPage = new System.Windows.Forms.ToolStripComboBox();
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panel = new System.Windows.Forms.Panel();
			this.controlComment = new InetAnalytics.Controls.YouTube.ControlCommentProperties();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderAuthor,
            this.columnHeaderTitle});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(0, 0);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(296, 271);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 4;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnItemSelectionChanged);
			// 
			// columnHeaderTime
			// 
			this.columnHeaderTime.Text = "Time";
			this.columnHeaderTime.Width = 120;
			// 
			// columnHeaderAuthor
			// 
			this.columnHeaderAuthor.Text = "Author";
			this.columnHeaderAuthor.Width = 120;
			// 
			// columnHeaderTitle
			// 
			this.columnHeaderTitle.Text = "Title";
			this.columnHeaderTitle.Width = 120;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Comment_16.png");
			// 
			// toolStrip
			// 
			this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonPrevious,
            this.labelPage,
            this.buttonNext,
            this.toolStripSeparator,
            this.labelVideosPerPage,
            this.comboBoxCommentsPerPage});
			this.toolStrip.Location = new System.Drawing.Point(0, 275);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(600, 25);
			this.toolStrip.TabIndex = 5;
			// 
			// buttonPrevious
			// 
			this.buttonPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonPrevious.Enabled = false;
			this.buttonPrevious.Image = global::InetAnalytics.Resources.ArrowBluePrevious_16;
			this.buttonPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonPrevious.Name = "buttonPrevious";
			this.buttonPrevious.Size = new System.Drawing.Size(23, 22);
			this.buttonPrevious.Text = "Back";
			this.buttonPrevious.Click += new System.EventHandler(this.OnPreviousClick);
			// 
			// labelPage
			// 
			this.labelPage.Name = "labelPage";
			this.labelPage.Size = new System.Drawing.Size(0, 22);
			// 
			// buttonNext
			// 
			this.buttonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonNext.Enabled = false;
			this.buttonNext.Image = global::InetAnalytics.Resources.ArrowBlueNext_16;
			this.buttonNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(23, 22);
			this.buttonNext.Text = "Next";
			this.buttonNext.Click += new System.EventHandler(this.OnNextClick);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// labelVideosPerPage
			// 
			this.labelVideosPerPage.Name = "labelVideosPerPage";
			this.labelVideosPerPage.Size = new System.Drawing.Size(94, 22);
			this.labelVideosPerPage.Text = "Videos per page:";
			// 
			// comboBoxCommentsPerPage
			// 
			this.comboBoxCommentsPerPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCommentsPerPage.Name = "comboBoxCommentsPerPage";
			this.comboBoxCommentsPerPage.Size = new System.Drawing.Size(75, 25);
			this.comboBoxCommentsPerPage.SelectedIndexChanged += new System.EventHandler(this.OnCommentsPerPageChanged);
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(4, 0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.listView);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.controlComment);
			this.splitContainer.Size = new System.Drawing.Size(592, 271);
			this.splitContainer.SplitterDistance = 296;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 6;
			this.splitContainer.UseTheme = false;
			// 
			// panel
			// 
			this.panel.Controls.Add(this.splitContainer);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
			this.panel.Size = new System.Drawing.Size(600, 275);
			this.panel.TabIndex = 7;
			// 
			// controlComment
			// 
			this.controlComment.AutoScroll = true;
			this.controlComment.Comment = null;
			this.controlComment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlComment.Location = new System.Drawing.Point(0, 0);
			this.controlComment.Name = "controlComment";
			this.controlComment.Size = new System.Drawing.Size(291, 271);
			this.controlComment.TabIndex = 0;
			// 
			// ControlCommentList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel);
			this.Controls.Add(this.toolStrip);
			this.Name = "ControlCommentList";
			this.Size = new System.Drawing.Size(600, 300);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonPrevious;
		private System.Windows.Forms.ToolStripLabel labelPage;
		private System.Windows.Forms.ToolStripButton buttonNext;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripLabel labelVideosPerPage;
		private System.Windows.Forms.ToolStripComboBox comboBoxCommentsPerPage;
		private System.Windows.Forms.ColumnHeader columnHeaderTime;
		private System.Windows.Forms.ColumnHeader columnHeaderAuthor;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private System.Windows.Forms.ColumnHeader columnHeaderTitle;
		private ControlCommentProperties controlComment;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Panel panel;
	}
}
