namespace YtAnalytics.Controls.Spiders
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.progressListBox = new DotNetApi.Windows.Controls.ProgressListBox();
			this.panel = new System.Windows.Forms.Panel();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonFeeds = new System.Windows.Forms.ToolStripDropDownButton();
			this.checkedListFeeds = new DotNetApi.Windows.Controls.ToolStripDropDownCheckedList();
			this.labelProgress = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.log = new YtAnalytics.Controls.Log.ControlLogList();
			this.progressLegend = new DotNetApi.Windows.Controls.ProgressLegend();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.progressListBox);
			this.splitContainer.Panel1.Controls.Add(this.panel);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
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
			this.progressListBox.Location = new System.Drawing.Point(0, 82);
			this.progressListBox.Name = "progressListBox";
			this.progressListBox.ScrollAlwaysVisible = true;
			this.progressListBox.Size = new System.Drawing.Size(598, 141);
			this.progressListBox.TabIndex = 1;
			// 
			// panel
			// 
			this.panel.Controls.Add(this.toolStrip);
			this.panel.Controls.Add(this.labelProgress);
			this.panel.Controls.Add(this.progressBar);
			this.panel.Controls.Add(this.linkLabel);
			this.panel.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(598, 82);
			this.panel.TabIndex = 0;
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
			this.buttonStart.Image = global::YtAnalytics.Resources.PlayStart_16;
			this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(51, 22);
			this.buttonStart.Text = "St&art";
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonStop
			// 
			this.buttonStop.Image = global::YtAnalytics.Resources.PlayStop_16;
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
			this.buttonFeeds.Image = global::YtAnalytics.Resources.FileVideo_16;
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
			// labelProgress
			// 
			this.labelProgress.AutoSize = true;
			this.labelProgress.Location = new System.Drawing.Point(2, 47);
			this.labelProgress.Name = "labelProgress";
			this.labelProgress.Size = new System.Drawing.Size(50, 13);
			this.labelProgress.TabIndex = 8;
			this.labelProgress.Text = "Stopped.";
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(3, 63);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(592, 16);
			this.progressBar.TabIndex = 7;
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
			this.log.Size = new System.Drawing.Size(598, 169);
			this.log.TabIndex = 0;
			// 
			// progressLegend
			// 
			this.progressLegend.Items.AddRange(new DotNetApi.Windows.Controls.ProgressLegendItem[] {
            this.legendItemSuccess,
            this.legendItemFail,
            this.legendItemWarning,
            this.legendItemPending});
			// 
			// legendItemPending
			// 
			this.legendItemPending.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.legendItemPending.Text = "Pending";
			// 
			// legendItemSuccess
			// 
			this.legendItemSuccess.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.legendItemSuccess.Text = "Success";
			// 
			// legendItemFail
			// 
			this.legendItemFail.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.legendItemFail.Text = "Fail";
			// 
			// legendItemWarning
			// 
			this.legendItemWarning.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.legendItemWarning.Text = "Warning";
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
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private Log.ControlLogList log;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.LinkLabel linkLabel;
		private System.Windows.Forms.Label labelProgress;
		private System.Windows.Forms.ProgressBar progressBar;
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
	}
}
