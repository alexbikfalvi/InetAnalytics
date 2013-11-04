namespace InetAnalytics.Controls.Log
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonFilterType = new System.Windows.Forms.ToolStripDropDownButton();
			this.listTypes = new DotNetApi.Windows.Controls.ToolStripDropDownCheckedList();
			this.buttonLevel = new System.Windows.Forms.ToolStripDropDownButton();
			this.listLevels = new DotNetApi.Windows.Controls.ToolStripDropDownCheckedList();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.buttonCalendar = new System.Windows.Forms.ToolStripDropDownButton();
			this.calendar = new DotNetApi.Windows.Controls.ToolStripDropDownCalendar();
			this.controlLogEvent = new InetAnalytics.Controls.Log.ControlLogEventProperties();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.toolStrip.SuspendLayout();
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
			this.splitContainer.Panel2.Controls.Add(this.controlLogEvent);
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 200;
			this.splitContainer.TabIndex = 1;
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
			this.listView.Location = new System.Drawing.Point(0, 25);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(598, 173);
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
            this.buttonFilterType,
            this.buttonLevel,
            this.toolStripSeparator,
            this.buttonCalendar});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(598, 25);
			this.toolStrip.TabIndex = 2;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonFilterType
			// 
			this.buttonFilterType.DropDown = this.listTypes;
			this.buttonFilterType.Image = global::InetAnalytics.Resources.Filter_16;
			this.buttonFilterType.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonFilterType.Name = "buttonFilterType";
			this.buttonFilterType.Size = new System.Drawing.Size(104, 22);
			this.buttonFilterType.Text = "Filter by &type";
			// 
			// listTypes
			// 
			this.listTypes.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.listTypes.ListMinimumSize = new System.Drawing.Size(200, 200);
			this.listTypes.ListSize = new System.Drawing.Size(200, 200);
			this.listTypes.Name = "listTypes";
			this.listTypes.OwnerItem = this.buttonFilterType;
			this.listTypes.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
			this.listTypes.Size = new System.Drawing.Size(208, 205);
			this.listTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.EventTypeCheck);
			// 
			// buttonLevel
			// 
			this.buttonLevel.DropDown = this.listLevels;
			this.buttonLevel.Image = global::InetAnalytics.Resources.Filter_16;
			this.buttonLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonLevel.Name = "buttonLevel";
			this.buttonLevel.Size = new System.Drawing.Size(105, 22);
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
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonCalendar
			// 
			this.buttonCalendar.DropDown = this.calendar;
			this.buttonCalendar.Image = global::InetAnalytics.Resources.Calendar_16;
			this.buttonCalendar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonCalendar.Name = "buttonCalendar";
			this.buttonCalendar.Size = new System.Drawing.Size(89, 22);
			this.buttonCalendar.Text = "Log range";
			// 
			// calendar
			// 
			this.calendar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.calendar.Name = "calendar";
			this.calendar.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
			this.calendar.Size = new System.Drawing.Size(235, 167);
			// 
			// controlLogEvent
			// 
			this.controlLogEvent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLogEvent.Event = null;
			this.controlLogEvent.Location = new System.Drawing.Point(0, 0);
			this.controlLogEvent.Name = "controlLogEvent";
			this.controlLogEvent.Size = new System.Drawing.Size(598, 194);
			this.controlLogEvent.TabIndex = 0;
			// 
			// ControlLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlLog";
			this.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private ControlLogEventProperties controlLogEvent;
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
	}
}
