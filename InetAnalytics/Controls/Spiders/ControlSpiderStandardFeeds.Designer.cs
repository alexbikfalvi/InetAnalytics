namespace InetAnalytics.Controls.Spiders
{
	partial class ControlSpiderStandardFeeds
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
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.progressListBox = new DotNetApi.Windows.Controls.ProgressListBox();
			this.panel = new System.Windows.Forms.Panel();
			this.progressBox = new DotNetApi.Windows.Controls.ProgressBox();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonFeeds = new System.Windows.Forms.ToolStripDropDownButton();
			this.checkedListFeeds = new DotNetApi.Windows.Controls.ToolStripDropDownCheckedList();
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.log = new InetAnalytics.Controls.Log.ControlLogList();
			this.progressLegend = new DotNetApi.Windows.Controls.ProgressLegend();
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.progressInfo = new DotNetApi.Windows.Controls.ProgressInfo();
			this.panelSpider = new DotNetApi.Windows.Controls.ThemePanel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.panelSpider.SuspendLayout();
			this.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.panelSpider);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 2;
			// 
			// progressListBox
			// 
			this.progressListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.progressListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.progressListBox.FormattingEnabled = true;
			this.progressListBox.IntegralHeight = false;
			this.progressListBox.ItemHeight = 48;
			this.progressListBox.Location = new System.Drawing.Point(1, 104);
			this.progressListBox.Name = "progressListBox";
			this.progressListBox.ScrollAlwaysVisible = true;
			this.progressListBox.Size = new System.Drawing.Size(598, 120);
			this.progressListBox.TabIndex = 1;
			// 
			// panel
			// 
			this.panel.Controls.Add(this.progressBox);
			this.panel.Controls.Add(this.toolStrip);
			this.panel.Controls.Add(this.linkLabel);
			this.panel.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel.Location = new System.Drawing.Point(1, 22);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(598, 82);
			this.panel.TabIndex = 0;
			// 
			// progressBox
			// 
			this.progressBox.ColorProgressBorder = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.progressBox.ColorProgressDefault = System.Drawing.SystemColors.ControlLightLight;
			this.progressBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressBox.Location = new System.Drawing.Point(0, 25);
			this.progressBox.Name = "progressBox";
			this.progressBox.Padding = new System.Windows.Forms.Padding(4);
			this.progressBox.Progress = null;
			this.progressBox.ProgressHeight = 12;
			this.progressBox.Size = new System.Drawing.Size(598, 57);
			this.progressBox.TabIndex = 10;
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonStart,
            this.buttonStop,
            this.toolStripSeparator1,
            this.buttonFeeds});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(598, 25);
			this.toolStrip.TabIndex = 9;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonStart
			// 
			this.buttonStart.Image = global::InetAnalytics.Resources.PlayStart_16;
			this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(51, 22);
			this.buttonStart.Text = "St&art";
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonStop
			// 
			this.buttonStop.Image = global::InetAnalytics.Resources.PlayStop_16;
			this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(51, 22);
			this.buttonStop.Text = "St&op";
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonFeeds
			// 
			this.buttonFeeds.DropDown = this.checkedListFeeds;
			this.buttonFeeds.Image = global::InetAnalytics.Resources.FileVideo_16;
			this.buttonFeeds.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonFeeds.Name = "buttonFeeds";
			this.buttonFeeds.Size = new System.Drawing.Size(66, 22);
			this.buttonFeeds.Text = "&Feeds";
			// 
			// checkedListFeeds
			// 
			this.checkedListFeeds.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.checkedListFeeds.ListMinimumSize = new System.Drawing.Size(200, 200);
			this.checkedListFeeds.ListSize = new System.Drawing.Size(200, 200);
			this.checkedListFeeds.Name = "checkedListFeeds";
			this.checkedListFeeds.OwnerItem = this.buttonFeeds;
			this.checkedListFeeds.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
			this.checkedListFeeds.Size = new System.Drawing.Size(208, 205);
			this.checkedListFeeds.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnFeedCheck);
			// 
			// linkLabel
			// 
			this.linkLabel.AutoSize = true;
			this.linkLabel.Location = new System.Drawing.Point(50, 33);
			this.linkLabel.Name = "linkLabel";
			this.linkLabel.Size = new System.Drawing.Size(0, 13);
			this.linkLabel.TabIndex = 6;
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
			// progressLegend
			// 
			this.progressLegend.Items.AddRange(new DotNetApi.Windows.Controls.ProgressLegendItem[] {
            this.legendItemSuccess,
            this.legendItemWarning,
            this.legendItemFail,
            this.legendItemPending});
			// 
			// legendItemSuccess
			// 
			this.legendItemSuccess.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.legendItemSuccess.Text = "Success";
			// 
			// legendItemWarning
			// 
			this.legendItemWarning.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.legendItemWarning.Text = "Warning";
			// 
			// legendItemFail
			// 
			this.legendItemFail.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.legendItemFail.Text = "Fail";
			// 
			// legendItemPending
			// 
			this.legendItemPending.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.legendItemPending.Text = "Pending";
			// 
			// progressInfo
			// 
			this.progressInfo.Count = 0;
			this.progressInfo.Default = 0;
			this.progressInfo.Legend = this.progressLegend;
			// 
			// panelSpider
			// 
			this.panelSpider.Controls.Add(this.progressListBox);
			this.panelSpider.Controls.Add(this.panel);
			this.panelSpider.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelSpider.Location = new System.Drawing.Point(0, 0);
			this.panelSpider.Name = "panelSpider";
			this.panelSpider.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelSpider.ShowBorder = true;
			this.panelSpider.ShowTitle = true;
			this.panelSpider.Size = new System.Drawing.Size(600, 225);
			this.panelSpider.TabIndex = 11;
			this.panelSpider.Title = "Standard Feeds Spider";
			// 
			// ControlSpiderStandardFeeds
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlSpiderStandardFeeds";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.panelSpider.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private Log.ControlLogList log;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.LinkLabel linkLabel;
		private DotNetApi.Windows.Controls.ProgressListBox progressListBox;
		private DotNetApi.Windows.Controls.ProgressLegend progressLegend;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemPending;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemSuccess;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemFail;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemWarning;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripDropDownButton buttonFeeds;
		private DotNetApi.Windows.Controls.ToolStripDropDownCheckedList checkedListFeeds;
		private DotNetApi.Windows.Controls.ProgressBox progressBox;
		private DotNetApi.Windows.Controls.ProgressInfo progressInfo;
		private DotNetApi.Windows.Controls.ThemePanel panelSpider;
	}
}
