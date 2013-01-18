namespace YtAnalytics.Controls
{
	partial class ControlVideoList
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
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderPublished = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonPrevious = new System.Windows.Forms.ToolStripButton();
			this.labelPage = new System.Windows.Forms.ToolStripLabel();
			this.buttonNext = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.labelVideosPerPage = new System.Windows.Forms.ToolStripLabel();
			this.comboBoxVideosPerPage = new System.Windows.Forms.ToolStripComboBox();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderTitle,
            this.columnHeaderPublished,
            this.columnHeaderDuration});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(0, 0);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(600, 275);
			this.listView.TabIndex = 4;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemActivate += new System.EventHandler(this.OnItemActivate);
			this.listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnItemSelectionChanged);
			this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
			this.columnHeaderId.Width = 140;
			// 
			// columnHeaderTitle
			// 
			this.columnHeaderTitle.Text = "Title";
			this.columnHeaderTitle.Width = 140;
			// 
			// columnHeaderPublished
			// 
			this.columnHeaderPublished.Text = "Published";
			this.columnHeaderPublished.Width = 140;
			// 
			// columnHeaderDuration
			// 
			this.columnHeaderDuration.Text = "Duration";
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
            this.comboBoxVideosPerPage});
			this.toolStrip.Location = new System.Drawing.Point(0, 275);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(600, 25);
			this.toolStrip.TabIndex = 5;
			// 
			// buttonPrevious
			// 
			this.buttonPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonPrevious.Enabled = false;
			this.buttonPrevious.Image = global::YtAnalytics.Resources.ArrowPrevious_16;
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
			this.buttonNext.Image = global::YtAnalytics.Resources.ArrowNext_16;
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
			// comboBoxVideosPerPage
			// 
			this.comboBoxVideosPerPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxVideosPerPage.Name = "comboBoxVideosPerPage";
			this.comboBoxVideosPerPage.Size = new System.Drawing.Size(75, 25);
			this.comboBoxVideosPerPage.SelectedIndexChanged += new System.EventHandler(this.OnVideoPerPageChanged);
			// 
			// ControlVideoList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listView);
			this.Controls.Add(this.toolStrip);
			this.Name = "ControlVideoList";
			this.Size = new System.Drawing.Size(600, 300);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderTitle;
		private System.Windows.Forms.ColumnHeader columnHeaderPublished;
		private System.Windows.Forms.ColumnHeader columnHeaderDuration;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonPrevious;
		private System.Windows.Forms.ToolStripLabel labelPage;
		private System.Windows.Forms.ToolStripButton buttonNext;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripLabel labelVideosPerPage;
		private System.Windows.Forms.ToolStripComboBox comboBoxVideosPerPage;
	}
}
