﻿namespace InetTraceroute.Controls.Log
{
	partial class ControlLog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlLog));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelEvents = new DotNetApi.Windows.Controls.ThemeControl();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
			this.buttonCalendar = new System.Windows.Forms.ToolStripDropDownButton();
			this.calendar = new DotNetApi.Windows.Controls.ToolStripDropDownCalendar();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.buttonFilterType = new System.Windows.Forms.ToolStripDropDownButton();
			this.listTypes = new DotNetApi.Windows.Controls.ToolStripDropDownCheckedList();
			this.buttonLevel = new System.Windows.Forms.ToolStripDropDownButton();
			this.listLevels = new DotNetApi.Windows.Controls.ToolStripDropDownCheckedList();
			this.panelEvent = new DotNetApi.Windows.Controls.ThemeControl();
			this.controlLogEvent = new InetControls.Controls.Log.ControlLogEventProperties();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelEvents.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.panelEvent.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.panelEvents);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.panelEvent);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 350;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 1;
			this.splitContainer.UseTheme = false;
			// 
			// panelEvents
			// 
			this.panelEvents.Controls.Add(this.listView);
			this.panelEvents.Controls.Add(this.toolStrip);
			this.panelEvents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelEvents.Location = new System.Drawing.Point(0, 0);
			this.panelEvents.Name = "panelEvents";
			this.panelEvents.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.panelEvents.ShowBorder = true;
			this.panelEvents.ShowTitle = true;
			this.panelEvents.Size = new System.Drawing.Size(350, 400);
			this.panelEvents.TabIndex = 3;
			this.panelEvents.Title = "Events";
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTimestamp,
            this.columnHeaderSource,
            this.columnHeaderDescription});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(1, 48);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(348, 351);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 0;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemActivate += new System.EventHandler(this.ItemActivate);
			this.listView.SelectedIndexChanged += new System.EventHandler(this.EventSelectionChanged);
			// 
			// columnHeaderTimestamp
			// 
			this.columnHeaderTimestamp.Text = "Date/Time";
			this.columnHeaderTimestamp.Width = 120;
			// 
			// columnHeaderSource
			// 
			this.columnHeaderSource.Text = "Source";
			this.columnHeaderSource.Width = 120;
			// 
			// columnHeaderDescription
			// 
			this.columnHeaderDescription.Text = "Description";
			this.columnHeaderDescription.Width = 200;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Information_16.png");
			this.imageList.Images.SetKeyName(1, "Success_16.png");
			this.imageList.Images.SetKeyName(2, "Error_16.png");
			this.imageList.Images.SetKeyName(3, "Canceled_16.png");
			this.imageList.Images.SetKeyName(4, "Warning_16.png");
			this.imageList.Images.SetKeyName(5, "Stop_16.png");
			this.imageList.Images.SetKeyName(6, "SuccessWarning_16.png");
			this.imageList.Images.SetKeyName(7, "ErrorWarning_16.png");
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefresh,
            this.buttonCalendar,
            this.toolStripSeparator,
            this.buttonFilterType,
            this.buttonLevel});
			this.toolStrip.Location = new System.Drawing.Point(1, 23);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(348, 25);
			this.toolStrip.TabIndex = 2;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Image = global::InetTraceroute.Resources.Refresh_16;
			this.buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(66, 22);
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefresh);
			// 
			// buttonCalendar
			// 
			this.buttonCalendar.DropDown = this.calendar;
			this.buttonCalendar.Image = global::InetTraceroute.Resources.Calendar_16;
			this.buttonCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonCalendar.Name = "buttonCalendar";
			this.buttonCalendar.Size = new System.Drawing.Size(89, 22);
			this.buttonCalendar.Text = "Log range";
			// 
			// calendar
			// 
			this.calendar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.calendar.Name = "calendar";
			this.calendar.OwnerItem = this.buttonCalendar;
			this.calendar.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
			this.calendar.Size = new System.Drawing.Size(186, 160);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonFilterType
			// 
			this.buttonFilterType.DropDown = this.listTypes;
			this.buttonFilterType.Image = global::InetTraceroute.Resources.Filter_16;
			this.buttonFilterType.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonFilterType.Name = "buttonFilterType";
			this.buttonFilterType.Size = new System.Drawing.Size(104, 22);
			this.buttonFilterType.Text = "Filter by &type";
			// 
			// listTypes
			// 
			this.listTypes.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.listTypes.ListMinimumSize = new System.Drawing.Size(300, 200);
			this.listTypes.ListSize = new System.Drawing.Size(300, 200);
			this.listTypes.Name = "listTypes";
			this.listTypes.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
			this.listTypes.Size = new System.Drawing.Size(308, 227);
			this.listTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.EventTypeCheck);
			// 
			// buttonLevel
			// 
			this.buttonLevel.DropDown = this.listLevels;
			this.buttonLevel.Image = global::InetTraceroute.Resources.Filter_16;
			this.buttonLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonLevel.Name = "buttonLevel";
			this.buttonLevel.Size = new System.Drawing.Size(105, 20);
			this.buttonLevel.Text = "Filter by &level";
			// 
			// listLevels
			// 
			this.listLevels.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.listLevels.ListMinimumSize = new System.Drawing.Size(200, 200);
			this.listLevels.ListSize = new System.Drawing.Size(200, 200);
			this.listLevels.Name = "listTypes";
			this.listLevels.OwnerItem = this.buttonLevel;
			this.listLevels.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
			this.listLevels.Size = new System.Drawing.Size(208, 205);
			this.listLevels.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.EventLevelCheck);
			// 
			// panelEvent
			// 
			this.panelEvent.Controls.Add(this.controlLogEvent);
			this.panelEvent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelEvent.Location = new System.Drawing.Point(0, 0);
			this.panelEvent.Name = "panelEvent";
			this.panelEvent.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.panelEvent.ShowBorder = true;
			this.panelEvent.ShowTitle = true;
			this.panelEvent.Size = new System.Drawing.Size(245, 400);
			this.panelEvent.TabIndex = 1;
			this.panelEvent.Title = "Event Information";
			// 
			// controlLogEvent
			// 
			this.controlLogEvent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLogEvent.Event = null;
			this.controlLogEvent.Location = new System.Drawing.Point(1, 23);
			this.controlLogEvent.Name = "controlLogEvent";
			this.controlLogEvent.Padding = new System.Windows.Forms.Padding(1);
			this.controlLogEvent.Size = new System.Drawing.Size(243, 376);
			this.controlLogEvent.TabIndex = 0;
			// 
			// ControlLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlLog";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelEvents.ResumeLayout(false);
			this.panelEvents.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.panelEvent.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private InetControls.Controls.Log.ControlLogEventProperties controlLogEvent;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderTimestamp;
		private System.Windows.Forms.ColumnHeader columnHeaderDescription;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ColumnHeader columnHeaderSource;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripDropDownButton buttonFilterType;
		private System.Windows.Forms.ToolStripDropDownButton buttonLevel;
		private DotNetApi.Windows.Controls.ToolStripDropDownCheckedList listTypes;
		private DotNetApi.Windows.Controls.ToolStripDropDownCheckedList listLevels;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripDropDownButton buttonCalendar;
		private DotNetApi.Windows.Controls.ToolStripDropDownCalendar calendar;
		private DotNetApi.Windows.Controls.ThemeControl panelEvents;
		private DotNetApi.Windows.Controls.ThemeControl panelEvent;
		private System.Windows.Forms.ToolStripButton buttonRefresh;
	}
}
