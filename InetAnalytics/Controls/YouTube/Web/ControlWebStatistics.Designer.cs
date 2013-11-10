namespace InetAnalytics.Controls.YouTube.Web
{
	partial class ControlWebStatistics
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlWebStatistics));
			this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.splitContainerChart = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.label = new System.Windows.Forms.ToolStripLabel();
			this.textBox = new System.Windows.Forms.ToolStripTextBox();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.buttonChart = new System.Windows.Forms.ToolStripDropDownButton();
			this.menuItemViews = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemLikes = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemDislikes = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemFavorites = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemComments = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemPopularity = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonDiscovery = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonComment = new System.Windows.Forms.ToolStripButton();
			this.listViewDiscovery = new System.Windows.Forms.ListView();
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderExtra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.panelChart = new DotNetApi.Windows.Controls.ThemeControl();
			this.log = new InetAnalytics.Controls.Log.ControlLogList();
			((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerChart)).BeginInit();
			this.splitContainerChart.Panel1.SuspendLayout();
			this.splitContainerChart.Panel2.SuspendLayout();
			this.splitContainerChart.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.panelChart.SuspendLayout();
			this.SuspendLayout();
			// 
			// chart
			// 
			chartArea1.Name = "ChartArea";
			this.chart.ChartAreas.Add(chartArea1);
			this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chart.Location = new System.Drawing.Point(0, 0);
			this.chart.Name = "chart";
			this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
			this.chart.Size = new System.Drawing.Size(600, 121);
			this.chart.TabIndex = 2;
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
			this.splitContainer.Panel1.Controls.Add(this.panelChart);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 3;
			// 
			// splitContainerChart
			// 
			this.splitContainerChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerChart.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerChart.Location = new System.Drawing.Point(0, 22);
			this.splitContainerChart.Name = "splitContainerChart";
			this.splitContainerChart.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerChart.Panel1
			// 
			this.splitContainerChart.Panel1.Controls.Add(this.toolStrip);
			this.splitContainerChart.Panel1.Controls.Add(this.chart);
			// 
			// splitContainerChart.Panel2
			// 
			this.splitContainerChart.Panel2.Controls.Add(this.listViewDiscovery);
			this.splitContainerChart.Size = new System.Drawing.Size(600, 203);
			this.splitContainerChart.SplitterDistance = 121;
			this.splitContainerChart.SplitterWidth = 5;
			this.splitContainerChart.TabIndex = 3;
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label,
            this.textBox,
            this.buttonStart,
            this.buttonStop,
            this.toolStripSeparator,
            this.buttonChart,
            this.toolStripSeparator1,
            this.buttonDiscovery,
            this.toolStripSeparator2,
            this.buttonComment});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(600, 25);
			this.toolStrip.TabIndex = 2;
			// 
			// label
			// 
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(90, 22);
			this.label.Text = "Video identifier:";
			// 
			// textBox
			// 
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(100, 25);
			this.textBox.TextChanged += new System.EventHandler(this.OnVideoChanged);
			// 
			// buttonStart
			// 
			this.buttonStart.Enabled = false;
			this.buttonStart.Image = global::InetAnalytics.Resources.PlayStart_16;
			this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(51, 22);
			this.buttonStart.Text = "St&art";
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::InetAnalytics.Resources.PlayStop_16;
			this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(51, 22);
			this.buttonStop.Text = "St&op";
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonChart
			// 
			this.buttonChart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemViews,
            this.menuItemLikes,
            this.menuItemDislikes,
            this.menuItemFavorites,
            this.menuItemComments,
            this.toolStripSeparator3,
            this.menuItemPopularity});
			this.buttonChart.Image = global::InetAnalytics.Resources.GraphLine_16;
			this.buttonChart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonChart.Name = "buttonChart";
			this.buttonChart.Size = new System.Drawing.Size(93, 22);
			this.buttonChart.Text = "Select data";
			// 
			// menuItemViews
			// 
			this.menuItemViews.Enabled = false;
			this.menuItemViews.Name = "menuItemViews";
			this.menuItemViews.Size = new System.Drawing.Size(167, 22);
			this.menuItemViews.Text = "Views count";
			this.menuItemViews.Click += new System.EventHandler(this.OnChartViewsCount);
			// 
			// menuItemLikes
			// 
			this.menuItemLikes.Enabled = false;
			this.menuItemLikes.Name = "menuItemLikes";
			this.menuItemLikes.Size = new System.Drawing.Size(167, 22);
			this.menuItemLikes.Text = "Likes count";
			this.menuItemLikes.Click += new System.EventHandler(this.OnChartLikesCount);
			// 
			// menuItemDislikes
			// 
			this.menuItemDislikes.Enabled = false;
			this.menuItemDislikes.Name = "menuItemDislikes";
			this.menuItemDislikes.Size = new System.Drawing.Size(167, 22);
			this.menuItemDislikes.Text = "Dislikes count";
			this.menuItemDislikes.Click += new System.EventHandler(this.OnChartDislikesCount);
			// 
			// menuItemFavorites
			// 
			this.menuItemFavorites.Enabled = false;
			this.menuItemFavorites.Name = "menuItemFavorites";
			this.menuItemFavorites.Size = new System.Drawing.Size(167, 22);
			this.menuItemFavorites.Text = "Favories count";
			this.menuItemFavorites.Click += new System.EventHandler(this.OnChartFavoritesCount);
			// 
			// menuItemComments
			// 
			this.menuItemComments.Enabled = false;
			this.menuItemComments.Name = "menuItemComments";
			this.menuItemComments.Size = new System.Drawing.Size(167, 22);
			this.menuItemComments.Text = "Comments count";
			this.menuItemComments.Click += new System.EventHandler(this.OnChartCommentsCount);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
			// 
			// menuItemPopularity
			// 
			this.menuItemPopularity.Enabled = false;
			this.menuItemPopularity.Name = "menuItemPopularity";
			this.menuItemPopularity.Size = new System.Drawing.Size(167, 22);
			this.menuItemPopularity.Text = "Popularity";
			this.menuItemPopularity.Click += new System.EventHandler(this.OnChartPopularity);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonDiscovery
			// 
			this.buttonDiscovery.Enabled = false;
			this.buttonDiscovery.Image = global::InetAnalytics.Resources.HotSpot_16;
			this.buttonDiscovery.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonDiscovery.Name = "buttonDiscovery";
			this.buttonDiscovery.Size = new System.Drawing.Size(78, 22);
			this.buttonDiscovery.Text = "&Discovery";
			this.buttonDiscovery.Click += new System.EventHandler(this.OnDiscoveryEventClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonComment
			// 
			this.buttonComment.Enabled = false;
			this.buttonComment.Image = global::InetAnalytics.Resources.CommentAdd_16;
			this.buttonComment.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonComment.Name = "buttonComment";
			this.buttonComment.Size = new System.Drawing.Size(104, 22);
			this.buttonComment.Text = "Add &comment";
			this.buttonComment.Click += new System.EventHandler(this.OnComment);
			// 
			// listViewDiscovery
			// 
			this.listViewDiscovery.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewDiscovery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderDate,
            this.columnHeaderType,
            this.columnHeaderExtra});
			this.listViewDiscovery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewDiscovery.FullRowSelect = true;
			this.listViewDiscovery.GridLines = true;
			this.listViewDiscovery.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewDiscovery.HideSelection = false;
			this.listViewDiscovery.Location = new System.Drawing.Point(0, 0);
			this.listViewDiscovery.MultiSelect = false;
			this.listViewDiscovery.Name = "listViewDiscovery";
			this.listViewDiscovery.Size = new System.Drawing.Size(600, 77);
			this.listViewDiscovery.SmallImageList = this.imageList;
			this.listViewDiscovery.TabIndex = 0;
			this.listViewDiscovery.UseCompatibleStateImageBehavior = false;
			this.listViewDiscovery.View = System.Windows.Forms.View.Details;
			this.listViewDiscovery.ItemActivate += new System.EventHandler(this.OnDiscoveryEventClick);
			this.listViewDiscovery.SelectedIndexChanged += new System.EventHandler(this.OnSelectedDiscoveryEventChanged);
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			// 
			// columnHeaderDate
			// 
			this.columnHeaderDate.Text = "Date/Time";
			this.columnHeaderDate.Width = 120;
			// 
			// columnHeaderType
			// 
			this.columnHeaderType.Text = "Type";
			this.columnHeaderType.Width = 180;
			// 
			// columnHeaderExtra
			// 
			this.columnHeaderExtra.Text = "Data";
			this.columnHeaderExtra.Width = 180;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "HotSpot_16.png");
			// 
			// panelChart
			// 
			this.panelChart.Controls.Add(this.splitContainerChart);
			this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelChart.Location = new System.Drawing.Point(0, 0);
			this.panelChart.Name = "panelChart";
			this.panelChart.Padding = new System.Windows.Forms.Padding(0, 22, 0, 0);
			this.panelChart.ShowTitle = true;
			this.panelChart.Size = new System.Drawing.Size(600, 225);
			this.panelChart.TabIndex = 4;
			this.panelChart.Title = "YouTube Web Statistics";
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.log.ShowBorder = true;
			this.log.ShowTitle = true;
			this.log.Size = new System.Drawing.Size(600, 170);
			this.log.TabIndex = 0;
			this.log.Title = "Log";
			// 
			// ControlWebStatistics
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlWebStatistics";
			this.Size = new System.Drawing.Size(600, 400);
			((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.splitContainerChart.Panel1.ResumeLayout(false);
			this.splitContainerChart.Panel1.PerformLayout();
			this.splitContainerChart.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerChart)).EndInit();
			this.splitContainerChart.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.panelChart.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart;
		private Log.ControlLogList log;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripLabel label;
		private System.Windows.Forms.ToolStripTextBox textBox;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripDropDownButton buttonChart;
		private System.Windows.Forms.ToolStripMenuItem menuItemViews;
		private System.Windows.Forms.ToolStripMenuItem menuItemLikes;
		private System.Windows.Forms.ToolStripMenuItem menuItemDislikes;
		private System.Windows.Forms.ToolStripMenuItem menuItemFavorites;
		private System.Windows.Forms.ToolStripMenuItem menuItemComments;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerChart;
		private System.Windows.Forms.ListView listViewDiscovery;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderType;
		private System.Windows.Forms.ColumnHeader columnHeaderExtra;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem menuItemPopularity;
		private System.Windows.Forms.ColumnHeader columnHeaderDate;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton buttonDiscovery;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton buttonComment;
		private DotNetApi.Windows.Controls.ThemeControl panelChart;
	}
}
