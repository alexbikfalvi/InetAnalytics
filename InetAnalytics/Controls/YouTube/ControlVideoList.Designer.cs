namespace InetAnalytics.Controls.YouTube
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
			this.buttonPreviousVideos = new System.Windows.Forms.ToolStripButton();
			this.labelVideos = new System.Windows.Forms.ToolStripLabel();
			this.buttonNextVideos = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.labelVideosPerPage = new System.Windows.Forms.ToolStripLabel();
			this.comboBoxVideosPerPage = new System.Windows.Forms.ToolStripComboBox();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonFindPrevious = new System.Windows.Forms.ToolStripButton();
			this.buttonFindNext = new System.Windows.Forms.ToolStripButton();
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
            this.buttonPreviousVideos,
            this.labelVideos,
            this.buttonNextVideos,
            this.separator1,
            this.labelVideosPerPage,
            this.comboBoxVideosPerPage,
            this.separator2,
            this.buttonFindPrevious,
            this.buttonFindNext});
			this.toolStrip.Location = new System.Drawing.Point(0, 275);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(600, 25);
			this.toolStrip.TabIndex = 5;
			// 
			// buttonPreviousVideos
			// 
			this.buttonPreviousVideos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonPreviousVideos.Enabled = false;
			this.buttonPreviousVideos.Image = global::InetAnalytics.Resources.ArrowBluePrevious_16;
			this.buttonPreviousVideos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonPreviousVideos.Name = "buttonPreviousVideos";
			this.buttonPreviousVideos.Size = new System.Drawing.Size(23, 22);
			this.buttonPreviousVideos.Text = "Previous videos";
			this.buttonPreviousVideos.Click += new System.EventHandler(this.OnPreviousClick);
			// 
			// labelVideos
			// 
			this.labelVideos.Name = "labelVideos";
			this.labelVideos.Size = new System.Drawing.Size(0, 22);
			// 
			// buttonNextVideos
			// 
			this.buttonNextVideos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonNextVideos.Enabled = false;
			this.buttonNextVideos.Image = global::InetAnalytics.Resources.ArrowBlueNext_16;
			this.buttonNextVideos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonNextVideos.Name = "buttonNextVideos";
			this.buttonNextVideos.Size = new System.Drawing.Size(23, 22);
			this.buttonNextVideos.Text = "Next videos";
			this.buttonNextVideos.Click += new System.EventHandler(this.OnNextClick);
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(6, 25);
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
			// separator2
			// 
			this.separator2.Name = "separator2";
			this.separator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonFindPrevious
			// 
			this.buttonFindPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonFindPrevious.Enabled = false;
			this.buttonFindPrevious.Image = global::InetAnalytics.Resources.FindPrevious_16;
			this.buttonFindPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonFindPrevious.Name = "buttonFindPrevious";
			this.buttonFindPrevious.Size = new System.Drawing.Size(23, 22);
			this.buttonFindPrevious.Text = "Find previous";
			this.buttonFindPrevious.Click += new System.EventHandler(this.OnFindPreviousClick);
			// 
			// buttonFindNext
			// 
			this.buttonFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonFindNext.Enabled = false;
			this.buttonFindNext.Image = global::InetAnalytics.Resources.FindNext_16;
			this.buttonFindNext.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonFindNext.Name = "buttonFindNext";
			this.buttonFindNext.Size = new System.Drawing.Size(23, 22);
			this.buttonFindNext.Text = "Find next";
			this.buttonFindNext.Click += new System.EventHandler(this.OnFindNextClick);
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
		private System.Windows.Forms.ToolStripButton buttonPreviousVideos;
		private System.Windows.Forms.ToolStripLabel labelVideos;
		private System.Windows.Forms.ToolStripButton buttonNextVideos;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripLabel labelVideosPerPage;
		private System.Windows.Forms.ToolStripComboBox comboBoxVideosPerPage;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripButton buttonFindPrevious;
		private System.Windows.Forms.ToolStripButton buttonFindNext;
	}
}
