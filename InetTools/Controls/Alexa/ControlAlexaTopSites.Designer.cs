namespace InetTools.Controls.Alexa
{
	partial class ControlAlexaTopSites
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
			// If disposing the managed resources.
			if (disposing)
			{
				lock (this.sync)
				{
					// If there exists a pending asynchronous operation.
					if (null != this.result)
					{
						// Cancel the asynchronous operation.
						this.request.Cancel(this.result);
						// Wait for the request to complete.
						this.result.AsyncWaitHandle.WaitOne();
					}
				}
				// Dispose the components.
				if (this.components != null)
				{
					this.components.Dispose();
				}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlAlexaTopSites));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelTool = new DotNetApi.Windows.Controls.ThemeControl();
			this.tabControl = new DotNetApi.Windows.Controls.ThemeTabControl();
			this.tabPageAlexa = new System.Windows.Forms.TabPage();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderRank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.labelCountry = new System.Windows.Forms.ToolStripLabel();
			this.comboBoxCountries = new System.Windows.Forms.ToolStripComboBox();
			this.buttonRefreshCountries = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.labelPages = new System.Windows.Forms.ToolStripLabel();
			this.comboBoxPages = new System.Windows.Forms.ToolStripComboBox();
			this.separator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonSave = new System.Windows.Forms.ToolStripButton();
			this.controlLog = new InetAnalytics.Controls.Log.ControlLogList();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelTool.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageAlexa.SuspendLayout();
			this.toolStrip.SuspendLayout();
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
			this.panelTool.Controls.Add(this.tabControl);
			this.panelTool.Controls.Add(this.toolStrip);
			this.panelTool.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTool.Location = new System.Drawing.Point(0, 0);
			this.panelTool.Name = "panelTool";
			this.panelTool.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.panelTool.ShowBorder = true;
			this.panelTool.ShowTitle = true;
			this.panelTool.Size = new System.Drawing.Size(600, 225);
			this.panelTool.TabIndex = 0;
			this.panelTool.Title = "Alexa Top Sites";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageAlexa);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(1, 48);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(598, 176);
			this.tabControl.TabIndex = 2;
			// 
			// tabPageAlexa
			// 
			this.tabPageAlexa.Controls.Add(this.listView);
			this.tabPageAlexa.Location = new System.Drawing.Point(2, 23);
			this.tabPageAlexa.Name = "tabPageAlexa";
			this.tabPageAlexa.Size = new System.Drawing.Size(594, 151);
			this.tabPageAlexa.TabIndex = 0;
			this.tabPageAlexa.Text = "Alexa";
			this.tabPageAlexa.UseVisualStyleBackColor = true;
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRank,
            this.columnHeaderSite});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(0, 0);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(594, 151);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 1;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderRank
			// 
			this.columnHeaderRank.Text = "Rank";
			// 
			// columnHeaderSite
			// 
			this.columnHeaderSite.Text = "Site";
			this.columnHeaderSite.Width = 150;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Globe");
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelCountry,
            this.comboBoxCountries,
            this.buttonRefreshCountries,
            this.separator1,
            this.buttonStart,
            this.buttonStop,
            this.separator2,
            this.labelPages,
            this.comboBoxPages,
            this.separator3,
            this.buttonSave});
			this.toolStrip.Location = new System.Drawing.Point(1, 23);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(598, 25);
			this.toolStrip.TabIndex = 1;
			this.toolStrip.Text = "toolStrip1";
			// 
			// labelCountry
			// 
			this.labelCountry.Name = "labelCountry";
			this.labelCountry.Size = new System.Drawing.Size(53, 22);
			this.labelCountry.Text = "Country:";
			// 
			// comboBoxCountries
			// 
			this.comboBoxCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCountries.Name = "comboBoxCountries";
			this.comboBoxCountries.Size = new System.Drawing.Size(121, 25);
			// 
			// buttonRefreshCountries
			// 
			this.buttonRefreshCountries.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.buttonRefreshCountries.Image = global::InetAnalytics.Resources.Refresh_16;
			this.buttonRefreshCountries.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRefreshCountries.Name = "buttonRefreshCountries";
			this.buttonRefreshCountries.Size = new System.Drawing.Size(23, 22);
			this.buttonRefreshCountries.Text = "Refresh countries";
			this.buttonRefreshCountries.Click += new System.EventHandler(this.OnRefreshCountries);
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonStart
			// 
			this.buttonStart.Image = global::InetAnalytics.Resources.PlayStart_16;
			this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(51, 22);
			this.buttonStart.Text = "&Start";
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
			// separator2
			// 
			this.separator2.Name = "separator2";
			this.separator2.Size = new System.Drawing.Size(6, 25);
			// 
			// labelPages
			// 
			this.labelPages.Name = "labelPages";
			this.labelPages.Size = new System.Drawing.Size(41, 22);
			this.labelPages.Text = "Pages:";
			// 
			// comboBoxPages
			// 
			this.comboBoxPages.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "15",
            "20"});
			this.comboBoxPages.Name = "comboBoxPages";
			this.comboBoxPages.Size = new System.Drawing.Size(75, 25);
			// 
			// separator3
			// 
			this.separator3.Name = "separator3";
			this.separator3.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Image = global::InetAnalytics.Resources.Save_16;
			this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(74, 22);
			this.buttonSave.Text = "&Save as...";
			this.buttonSave.Click += new System.EventHandler(this.OnSave);
			// 
			// controlLog
			// 
			this.controlLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLog.Location = new System.Drawing.Point(0, 0);
			this.controlLog.Name = "controlLog";
			this.controlLog.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.controlLog.ShowBorder = true;
			this.controlLog.ShowTitle = true;
			this.controlLog.Size = new System.Drawing.Size(600, 170);
			this.controlLog.TabIndex = 0;
			this.controlLog.Title = "Event Log";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Alexa ranking files (*.alx)|*.alx|Text files (*.txt)|*.txt";
			this.saveFileDialog.Title = "Save Alexa Ranking";
			// 
			// ControlAlexaTopSites
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlAlexaTopSites";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelTool.ResumeLayout(false);
			this.panelTool.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageAlexa.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private DotNetApi.Windows.Controls.ThemeControl panelTool;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderRank;
		private System.Windows.Forms.ColumnHeader columnHeaderSite;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private InetAnalytics.Controls.Log.ControlLogList controlLog;
		private DotNetApi.Windows.Controls.ThemeTabControl tabControl;
		private System.Windows.Forms.TabPage tabPageAlexa;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripLabel labelCountry;
		private System.Windows.Forms.ToolStripComboBox comboBoxCountries;
		private System.Windows.Forms.ToolStripButton buttonRefreshCountries;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripLabel labelPages;
		private System.Windows.Forms.ToolStripComboBox comboBoxPages;
		private System.Windows.Forms.ToolStripSeparator separator3;
		private System.Windows.Forms.ToolStripButton buttonSave;
	}
}
