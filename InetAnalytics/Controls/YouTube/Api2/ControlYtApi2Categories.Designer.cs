﻿namespace InetAnalytics.Controls.YouTube.Api2
{
	partial class ControlYtApi2Categories
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlYtApi2Categories));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
			this.buttonCancel = new System.Windows.Forms.ToolStripButton();
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelCategories = new DotNetApi.Windows.Controls.ThemeControl();
			this.panelSplitContainer = new System.Windows.Forms.Panel();
			this.splitContainerUp = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderTerm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderAssignable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDeprecated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.controlCategory = new InetAnalytics.Controls.YouTube.ControlCategoryProperties();
			this.log = new InetControls.Controls.Log.ControlLogList();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelCategories.SuspendLayout();
			this.panelSplitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerUp)).BeginInit();
			this.splitContainerUp.Panel1.SuspendLayout();
			this.splitContainerUp.Panel2.SuspendLayout();
			this.splitContainerUp.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefresh,
            this.buttonCancel});
			this.toolStrip.Location = new System.Drawing.Point(1, 22);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Image = global::InetAnalytics.Resources.Refresh_16;
			this.buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(66, 22);
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefresh);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Enabled = false;
			this.buttonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(47, 22);
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.panelCategories);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 1;
			// 
			// panelCategories
			// 
			this.panelCategories.Controls.Add(this.panelSplitContainer);
			this.panelCategories.Controls.Add(this.toolStrip);
			this.panelCategories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelCategories.Location = new System.Drawing.Point(0, 0);
			this.panelCategories.Name = "panelCategories";
			this.panelCategories.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelCategories.ShowBorder = true;
			this.panelCategories.ShowTitle = true;
			this.panelCategories.Size = new System.Drawing.Size(800, 425);
			this.panelCategories.TabIndex = 5;
			this.panelCategories.Title = "YouTube Video Categories";
			// 
			// panelSplitContainer
			// 
			this.panelSplitContainer.Controls.Add(this.splitContainerUp);
			this.panelSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelSplitContainer.Location = new System.Drawing.Point(1, 47);
			this.panelSplitContainer.Name = "panelSplitContainer";
			this.panelSplitContainer.Padding = new System.Windows.Forms.Padding(4);
			this.panelSplitContainer.Size = new System.Drawing.Size(798, 377);
			this.panelSplitContainer.TabIndex = 8;
			// 
			// splitContainerUp
			// 
			this.splitContainerUp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerUp.Location = new System.Drawing.Point(4, 4);
			this.splitContainerUp.Name = "splitContainerUp";
			// 
			// splitContainerUp.Panel1
			// 
			this.splitContainerUp.Panel1.Controls.Add(this.listView);
			// 
			// splitContainerUp.Panel2
			// 
			this.splitContainerUp.Panel2.Controls.Add(this.controlCategory);
			this.splitContainerUp.Size = new System.Drawing.Size(790, 369);
			this.splitContainerUp.SplitterDistance = 443;
			this.splitContainerUp.SplitterWidth = 5;
			this.splitContainerUp.TabIndex = 7;
			this.splitContainerUp.UseTheme = false;
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTerm,
            this.columnHeaderLabel,
            this.columnHeaderAssignable,
            this.columnHeaderDeprecated});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(0, 0);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(443, 369);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 4;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.SelectedIndexChanged += new System.EventHandler(this.OnSelectedCategoryChanged);
			// 
			// columnHeaderTerm
			// 
			this.columnHeaderTerm.Text = "Term";
			this.columnHeaderTerm.Width = 120;
			// 
			// columnHeaderLabel
			// 
			this.columnHeaderLabel.Text = "Label";
			this.columnHeaderLabel.Width = 120;
			// 
			// columnHeaderAssignable
			// 
			this.columnHeaderAssignable.Text = "Assignable";
			this.columnHeaderAssignable.Width = 80;
			// 
			// columnHeaderDeprecated
			// 
			this.columnHeaderDeprecated.Text = "Deprecated";
			this.columnHeaderDeprecated.Width = 80;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Category");
			// 
			// controlCategory
			// 
			this.controlCategory.Catergory = null;
			this.controlCategory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlCategory.Location = new System.Drawing.Point(0, 0);
			this.controlCategory.Name = "controlCategory";
			this.controlCategory.Size = new System.Drawing.Size(342, 369);
			this.controlCategory.TabIndex = 0;
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.log.ShowBorder = true;
			this.log.ShowTitle = true;
			this.log.Size = new System.Drawing.Size(800, 170);
			this.log.TabIndex = 0;
			this.log.Title = "Log";
			// 
			// ControlYtApi2Categories
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlYtApi2Categories";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelCategories.ResumeLayout(false);
			this.panelCategories.PerformLayout();
			this.panelSplitContainer.ResumeLayout(false);
			this.splitContainerUp.Panel1.ResumeLayout(false);
			this.splitContainerUp.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerUp)).EndInit();
			this.splitContainerUp.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private InetControls.Controls.Log.ControlLogList log;
		private System.Windows.Forms.ToolStripButton buttonRefresh;
		private System.Windows.Forms.ToolStripButton buttonCancel;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerUp;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderTerm;
		private System.Windows.Forms.ColumnHeader columnHeaderLabel;
		private System.Windows.Forms.ColumnHeader columnHeaderAssignable;
		private System.Windows.Forms.ColumnHeader columnHeaderDeprecated;
		private System.Windows.Forms.ImageList imageList;
		private ControlCategoryProperties controlCategory;
		private DotNetApi.Windows.Controls.ThemeControl panelCategories;
		private System.Windows.Forms.Panel panelSplitContainer;
	}
}
