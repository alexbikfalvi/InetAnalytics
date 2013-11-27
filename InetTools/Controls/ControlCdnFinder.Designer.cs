namespace InetTools.Controls
{
	partial class ControlCdnFinder
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCdnFinder));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelTool = new DotNetApi.Windows.Controls.ThemeControl();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderResources = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.labelServer = new System.Windows.Forms.ToolStripLabel();
			this.textBoxUrl = new System.Windows.Forms.ToolStripTextBox();
			this.buttonSettings = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonOpen = new System.Windows.Forms.ToolStripButton();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.separator3 = new System.Windows.Forms.ToolStripSeparator();
			this.controlLog = new InetAnalytics.Controls.Log.ControlLogList();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.splitContainerDomains = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelDomains = new System.Windows.Forms.Panel();
			this.panelDomain = new System.Windows.Forms.Panel();
			this.listViewResources = new System.Windows.Forms.ListView();
			this.columnHeaderHostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCdn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderIsBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelTool.SuspendLayout();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDomains)).BeginInit();
			this.splitContainerDomains.Panel1.SuspendLayout();
			this.splitContainerDomains.Panel2.SuspendLayout();
			this.splitContainerDomains.SuspendLayout();
			this.panelDomains.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.panelTool);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.controlLog);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 3;
			// 
			// panelTool
			// 
			this.panelTool.Controls.Add(this.panelDomains);
			this.panelTool.Controls.Add(this.toolStrip);
			this.panelTool.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTool.Location = new System.Drawing.Point(0, 0);
			this.panelTool.Name = "panelTool";
			this.panelTool.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelTool.ShowBorder = true;
			this.panelTool.ShowTitle = true;
			this.panelTool.Size = new System.Drawing.Size(600, 225);
			this.panelTool.TabIndex = 0;
			this.panelTool.Title = "Content Delivery Networks Finder";
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSite,
            this.columnHeaderResources});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(1, 1);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(293, 167);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 1;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderSite
			// 
			this.columnHeaderSite.Text = "Site";
			this.columnHeaderSite.Width = 150;
			// 
			// columnHeaderResources
			// 
			this.columnHeaderResources.Text = "Resources";
			this.columnHeaderResources.Width = 100;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Globe");
			this.imageList.Images.SetKeyName(1, "GlobeSuccess");
			this.imageList.Images.SetKeyName(2, "GlobeWarning");
			this.imageList.Images.SetKeyName(3, "GlobeError");
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelServer,
            this.textBoxUrl,
            this.buttonSettings,
            this.separator1,
            this.buttonOpen,
            this.separator2,
            this.buttonStart,
            this.buttonStop,
            this.separator3});
			this.toolStrip.Location = new System.Drawing.Point(1, 22);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(598, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// labelServer
			// 
			this.labelServer.Name = "labelServer";
			this.labelServer.Size = new System.Drawing.Size(42, 22);
			this.labelServer.Text = "Server:";
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.Size = new System.Drawing.Size(200, 25);
			this.textBoxUrl.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// buttonSettings
			// 
			this.buttonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonSettings.Image = global::InetTools.Properties.Resources.Settings_16;
			this.buttonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(23, 22);
			this.buttonSettings.Text = "&Settings";
			this.buttonSettings.Click += new System.EventHandler(this.OnSettingsClick);
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonOpen
			// 
			this.buttonOpen.Image = global::InetTools.Properties.Resources.Open_16;
			this.buttonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(65, 22);
			this.buttonOpen.Text = "&Open...";
			this.buttonOpen.Click += new System.EventHandler(this.OnOpen);
			// 
			// separator2
			// 
			this.separator2.Name = "separator2";
			this.separator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonStart
			// 
			this.buttonStart.Enabled = false;
			this.buttonStart.Image = global::InetTools.Properties.Resources.PlayStart_16;
			this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(51, 22);
			this.buttonStart.Text = "&Start";
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::InetTools.Properties.Resources.PlayStop_16;
			this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(51, 22);
			this.buttonStop.Text = "St&op";
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
			// 
			// separator3
			// 
			this.separator3.Name = "separator3";
			this.separator3.Size = new System.Drawing.Size(6, 25);
			// 
			// controlLog
			// 
			this.controlLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLog.Location = new System.Drawing.Point(0, 0);
			this.controlLog.Name = "controlLog";
			this.controlLog.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.controlLog.ShowBorder = true;
			this.controlLog.ShowTitle = true;
			this.controlLog.Size = new System.Drawing.Size(600, 170);
			this.controlLog.TabIndex = 0;
			this.controlLog.Title = "Event Log";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "XML files (*.xml)|*.xml";
			this.saveFileDialog.Title = "Export Alexa Ranking";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Alexa ranking XML files (*.xml)|*.xml";
			this.openFileDialog.Title = "Open Sites List";
			// 
			// splitContainerDomains
			// 
			this.splitContainerDomains.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerDomains.Location = new System.Drawing.Point(4, 4);
			this.splitContainerDomains.Name = "splitContainerDomains";
			// 
			// splitContainerDomains.Panel1
			// 
			this.splitContainerDomains.Panel1.Controls.Add(this.listView);
			this.splitContainerDomains.Panel1.Padding = new System.Windows.Forms.Padding(1);
			// 
			// splitContainerDomains.Panel2
			// 
			this.splitContainerDomains.Panel2.Controls.Add(this.listViewResources);
			this.splitContainerDomains.Panel2.Controls.Add(this.panelDomain);
			this.splitContainerDomains.Panel2.Padding = new System.Windows.Forms.Padding(1);
			this.splitContainerDomains.Size = new System.Drawing.Size(590, 169);
			this.splitContainerDomains.SplitterDistance = 295;
			this.splitContainerDomains.SplitterWidth = 5;
			this.splitContainerDomains.TabIndex = 2;
			this.splitContainerDomains.UseTheme = false;
			// 
			// panelDomains
			// 
			this.panelDomains.Controls.Add(this.splitContainerDomains);
			this.panelDomains.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelDomains.Location = new System.Drawing.Point(1, 47);
			this.panelDomains.Name = "panelDomains";
			this.panelDomains.Padding = new System.Windows.Forms.Padding(4);
			this.panelDomains.Size = new System.Drawing.Size(598, 177);
			this.panelDomains.TabIndex = 3;
			// 
			// panelDomain
			// 
			this.panelDomain.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelDomain.Location = new System.Drawing.Point(1, 1);
			this.panelDomain.Name = "panelDomain";
			this.panelDomain.Size = new System.Drawing.Size(288, 100);
			this.panelDomain.TabIndex = 0;
			// 
			// listViewResources
			// 
			this.listViewResources.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewResources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderHostname,
            this.columnHeaderCount,
            this.columnHeaderSize,
            this.columnHeaderCdn,
            this.columnHeaderIsBase});
			this.listViewResources.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewResources.FullRowSelect = true;
			this.listViewResources.GridLines = true;
			this.listViewResources.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewResources.HideSelection = false;
			this.listViewResources.Location = new System.Drawing.Point(1, 101);
			this.listViewResources.MultiSelect = false;
			this.listViewResources.Name = "listViewResources";
			this.listViewResources.Size = new System.Drawing.Size(288, 67);
			this.listViewResources.TabIndex = 1;
			this.listViewResources.UseCompatibleStateImageBehavior = false;
			this.listViewResources.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderHostname
			// 
			this.columnHeaderHostname.Text = "Hostname";
			this.columnHeaderHostname.Width = 120;
			// 
			// columnHeaderCount
			// 
			this.columnHeaderCount.Text = "Count";
			// 
			// columnHeaderSize
			// 
			this.columnHeaderSize.Text = "Size";
			// 
			// columnHeaderCdn
			// 
			this.columnHeaderCdn.Text = "CDN";
			this.columnHeaderCdn.Width = 120;
			// 
			// columnHeaderIsBase
			// 
			this.columnHeaderIsBase.Text = "Is base";
			// 
			// ControlCdnFinder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlCdnFinder";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelTool.ResumeLayout(false);
			this.panelTool.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainerDomains.Panel1.ResumeLayout(false);
			this.splitContainerDomains.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDomains)).EndInit();
			this.splitContainerDomains.ResumeLayout(false);
			this.panelDomains.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private DotNetApi.Windows.Controls.ThemeControl panelTool;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripLabel labelServer;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderSite;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripTextBox textBoxUrl;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripSeparator separator3;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private InetAnalytics.Controls.Log.ControlLogList controlLog;
		private System.Windows.Forms.ToolStripButton buttonSettings;
		private System.Windows.Forms.ToolStripButton buttonOpen;
		private System.Windows.Forms.ColumnHeader columnHeaderResources;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerDomains;
		private System.Windows.Forms.Panel panelDomains;
		private System.Windows.Forms.Panel panelDomain;
		private System.Windows.Forms.ListView listViewResources;
		private System.Windows.Forms.ColumnHeader columnHeaderHostname;
		private System.Windows.Forms.ColumnHeader columnHeaderCount;
		private System.Windows.Forms.ColumnHeader columnHeaderSize;
		private System.Windows.Forms.ColumnHeader columnHeaderCdn;
		private System.Windows.Forms.ColumnHeader columnHeaderIsBase;
	}
}
