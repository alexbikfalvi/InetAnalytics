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
			this.panelDomains = new System.Windows.Forms.Panel();
			this.splitContainerDomains = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderResources = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.listViewResources = new System.Windows.Forms.ListView();
			this.columnHeaderHostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCdn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderIsBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panelDomain = new System.Windows.Forms.Panel();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.labelServer = new System.Windows.Forms.ToolStripLabel();
			this.textBoxUrl = new System.Windows.Forms.ToolStripTextBox();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.separator3 = new System.Windows.Forms.ToolStripSeparator();
			this.controlLog = new InetAnalytics.Controls.Log.ControlLogList();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.buttonSettings = new System.Windows.Forms.ToolStripButton();
			this.buttonOpen = new System.Windows.Forms.ToolStripButton();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.textBoxSite = new System.Windows.Forms.TextBox();
			this.labelSite = new System.Windows.Forms.Label();
			this.textBoxAssetCdn = new System.Windows.Forms.TextBox();
			this.labelAssetCdn = new System.Windows.Forms.Label();
			this.textBoxBaseCdn = new System.Windows.Forms.TextBox();
			this.labelBaseCdn = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelTool.SuspendLayout();
			this.panelDomains.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDomains)).BeginInit();
			this.splitContainerDomains.Panel1.SuspendLayout();
			this.splitContainerDomains.Panel2.SuspendLayout();
			this.splitContainerDomains.SuspendLayout();
			this.panelDomain.SuspendLayout();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
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
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
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
			this.panelTool.Size = new System.Drawing.Size(800, 425);
			this.panelTool.TabIndex = 0;
			this.panelTool.Title = "Content Delivery Networks Finder";
			// 
			// panelDomains
			// 
			this.panelDomains.Controls.Add(this.splitContainerDomains);
			this.panelDomains.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelDomains.Location = new System.Drawing.Point(1, 47);
			this.panelDomains.Name = "panelDomains";
			this.panelDomains.Padding = new System.Windows.Forms.Padding(4);
			this.panelDomains.Size = new System.Drawing.Size(798, 377);
			this.panelDomains.TabIndex = 3;
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
			this.splitContainerDomains.Size = new System.Drawing.Size(790, 369);
			this.splitContainerDomains.SplitterDistance = 390;
			this.splitContainerDomains.SplitterWidth = 5;
			this.splitContainerDomains.TabIndex = 2;
			this.splitContainerDomains.UseTheme = false;
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
			this.listView.Size = new System.Drawing.Size(388, 367);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 0;
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
			this.imageList.Images.SetKeyName(0, "GlobeQuestion");
			this.imageList.Images.SetKeyName(1, "GlobeSuccess");
			this.imageList.Images.SetKeyName(2, "GlobeWarning");
			this.imageList.Images.SetKeyName(3, "GlobeError");
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
			this.listViewResources.Location = new System.Drawing.Point(1, 146);
			this.listViewResources.MultiSelect = false;
			this.listViewResources.Name = "listViewResources";
			this.listViewResources.Size = new System.Drawing.Size(393, 222);
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
			// panelDomain
			// 
			this.panelDomain.AutoScroll = true;
			this.panelDomain.Controls.Add(this.labelBaseCdn);
			this.panelDomain.Controls.Add(this.textBoxBaseCdn);
			this.panelDomain.Controls.Add(this.labelAssetCdn);
			this.panelDomain.Controls.Add(this.textBoxAssetCdn);
			this.panelDomain.Controls.Add(this.labelSite);
			this.panelDomain.Controls.Add(this.textBoxSite);
			this.panelDomain.Controls.Add(this.labelTitle);
			this.panelDomain.Controls.Add(this.pictureBox);
			this.panelDomain.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelDomain.Location = new System.Drawing.Point(1, 1);
			this.panelDomain.Name = "panelDomain";
			this.panelDomain.Size = new System.Drawing.Size(393, 145);
			this.panelDomain.TabIndex = 0;
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
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
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
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(6, 25);
			// 
			// separator2
			// 
			this.separator2.Name = "separator2";
			this.separator2.Size = new System.Drawing.Size(6, 25);
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
			this.controlLog.Size = new System.Drawing.Size(800, 170);
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
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(64, 28);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(83, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No site selected";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetTools.Properties.Resources.GlobeQuestion_48;
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
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
			// buttonOpen
			// 
			this.buttonOpen.Image = global::InetTools.Properties.Resources.Open_16;
			this.buttonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(65, 22);
			this.buttonOpen.Text = "&Open...";
			this.buttonOpen.Click += new System.EventHandler(this.OnOpen);
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
			// textBoxSite
			// 
			this.textBoxSite.Location = new System.Drawing.Point(112, 64);
			this.textBoxSite.Name = "textBoxSite";
			this.textBoxSite.ReadOnly = true;
			this.textBoxSite.Size = new System.Drawing.Size(240, 20);
			this.textBoxSite.TabIndex = 2;
			// 
			// labelSite
			// 
			this.labelSite.AutoSize = true;
			this.labelSite.Location = new System.Drawing.Point(7, 67);
			this.labelSite.Name = "labelSite";
			this.labelSite.Size = new System.Drawing.Size(28, 13);
			this.labelSite.TabIndex = 1;
			this.labelSite.Text = "&Site:";
			// 
			// textBoxAssetCdn
			// 
			this.textBoxAssetCdn.Location = new System.Drawing.Point(112, 90);
			this.textBoxAssetCdn.Name = "textBoxAssetCdn";
			this.textBoxAssetCdn.ReadOnly = true;
			this.textBoxAssetCdn.Size = new System.Drawing.Size(240, 20);
			this.textBoxAssetCdn.TabIndex = 4;
			// 
			// labelAssetCdn
			// 
			this.labelAssetCdn.AutoSize = true;
			this.labelAssetCdn.Location = new System.Drawing.Point(7, 93);
			this.labelAssetCdn.Name = "labelAssetCdn";
			this.labelAssetCdn.Size = new System.Drawing.Size(62, 13);
			this.labelAssetCdn.TabIndex = 3;
			this.labelAssetCdn.Text = "&Asset CDN:";
			// 
			// textBoxBaseCdn
			// 
			this.textBoxBaseCdn.Location = new System.Drawing.Point(112, 116);
			this.textBoxBaseCdn.Name = "textBoxBaseCdn";
			this.textBoxBaseCdn.ReadOnly = true;
			this.textBoxBaseCdn.Size = new System.Drawing.Size(240, 20);
			this.textBoxBaseCdn.TabIndex = 6;
			// 
			// labelBaseCdn
			// 
			this.labelBaseCdn.AutoSize = true;
			this.labelBaseCdn.Location = new System.Drawing.Point(7, 119);
			this.labelBaseCdn.Name = "labelBaseCdn";
			this.labelBaseCdn.Size = new System.Drawing.Size(60, 13);
			this.labelBaseCdn.TabIndex = 5;
			this.labelBaseCdn.Text = "&Base CDN:";
			// 
			// ControlCdnFinder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlCdnFinder";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelTool.ResumeLayout(false);
			this.panelTool.PerformLayout();
			this.panelDomains.ResumeLayout(false);
			this.splitContainerDomains.Panel1.ResumeLayout(false);
			this.splitContainerDomains.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerDomains)).EndInit();
			this.splitContainerDomains.ResumeLayout(false);
			this.panelDomain.ResumeLayout(false);
			this.panelDomain.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
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
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxSite;
		private System.Windows.Forms.Label labelSite;
		private System.Windows.Forms.Label labelAssetCdn;
		private System.Windows.Forms.TextBox textBoxAssetCdn;
		private System.Windows.Forms.Label labelBaseCdn;
		private System.Windows.Forms.TextBox textBoxBaseCdn;
	}
}
