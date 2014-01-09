namespace InetTools.Controls.Net
{
	partial class ControlTraceroute
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
				// Dispose the components.
				if (this.components != null)
				{
					this.components.Dispose();
				}
				// Dispose the traceroute.
				this.traceroute.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlTraceroute));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelTool = new DotNetApi.Windows.Controls.ThemeControl();
			this.tabControl = new DotNetApi.Windows.Controls.ThemeTabControl();
			this.tabPageRoute = new System.Windows.Forms.TabPage();
			this.listViewRoute = new System.Windows.Forms.ListView();
			this.columnHeaderTtl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderRtt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSuccess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabPageSettings = new System.Windows.Forms.TabPage();
			this.labelDataLength = new System.Windows.Forms.Label();
			this.numericUpDownDataLength = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMaximumFailedHops = new System.Windows.Forms.NumericUpDown();
			this.labelMaximumFailedHops = new System.Windows.Forms.Label();
			this.checkBoxStopOnFail = new System.Windows.Forms.CheckBox();
			this.checkBoxStopHopOnSuccess = new System.Windows.Forms.CheckBox();
			this.labelMaximumAttempts = new System.Windows.Forms.Label();
			this.checkBoxAutomaticNameResolution = new System.Windows.Forms.CheckBox();
			this.numericUpDownMaximumHops = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMaximumAttempts = new System.Windows.Forms.NumericUpDown();
			this.labelMaximumHops = new System.Windows.Forms.Label();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.labelDestination = new System.Windows.Forms.ToolStripLabel();
			this.textBoxDestination = new System.Windows.Forms.ToolStripTextBox();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonSave = new System.Windows.Forms.ToolStripButton();
			this.buttonUndo = new System.Windows.Forms.ToolStripButton();
			this.log = new InetAnalytics.Controls.Log.ControlLogList();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelTool.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageRoute.SuspendLayout();
			this.tabPageSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDataLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumFailedHops)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumHops)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumAttempts)).BeginInit();
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
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
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
			this.panelTool.Size = new System.Drawing.Size(800, 425);
			this.panelTool.TabIndex = 0;
			this.panelTool.Title = "Traceroute";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageRoute);
			this.tabControl.Controls.Add(this.tabPageSettings);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(1, 48);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(798, 376);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageRoute
			// 
			this.tabPageRoute.Controls.Add(this.listViewRoute);
			this.tabPageRoute.Location = new System.Drawing.Point(2, 23);
			this.tabPageRoute.Name = "tabPageRoute";
			this.tabPageRoute.Size = new System.Drawing.Size(794, 351);
			this.tabPageRoute.TabIndex = 0;
			this.tabPageRoute.Text = "Route";
			this.tabPageRoute.UseVisualStyleBackColor = true;
			// 
			// listViewRoute
			// 
			this.listViewRoute.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewRoute.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTtl,
            this.columnHeaderIp,
            this.columnHeaderRtt,
            this.columnHeaderSuccess,
            this.columnHeaderError,
            this.columnHeaderTotal});
			this.listViewRoute.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewRoute.FullRowSelect = true;
			this.listViewRoute.GridLines = true;
			this.listViewRoute.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewRoute.HideSelection = false;
			this.listViewRoute.Location = new System.Drawing.Point(0, 0);
			this.listViewRoute.MultiSelect = false;
			this.listViewRoute.Name = "listViewRoute";
			this.listViewRoute.Size = new System.Drawing.Size(794, 351);
			this.listViewRoute.SmallImageList = this.imageList;
			this.listViewRoute.TabIndex = 0;
			this.listViewRoute.UseCompatibleStateImageBehavior = false;
			this.listViewRoute.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderTtl
			// 
			this.columnHeaderTtl.Text = "Time-to-live";
			this.columnHeaderTtl.Width = 80;
			// 
			// columnHeaderIp
			// 
			this.columnHeaderIp.Text = "IP address";
			this.columnHeaderIp.Width = 200;
			// 
			// columnHeaderRtt
			// 
			this.columnHeaderRtt.Text = "Round-trip time";
			this.columnHeaderRtt.Width = 200;
			// 
			// columnHeaderSuccess
			// 
			this.columnHeaderSuccess.Text = "Success";
			// 
			// columnHeaderError
			// 
			this.columnHeaderError.Text = "Error";
			// 
			// columnHeaderTotal
			// 
			this.columnHeaderTotal.Text = "Total";
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Success");
			this.imageList.Images.SetKeyName(1, "SuccessWarning");
			this.imageList.Images.SetKeyName(2, "Warning");
			this.imageList.Images.SetKeyName(3, "Error");
			this.imageList.Images.SetKeyName(4, "ErrorWarning");
			// 
			// tabPageSettings
			// 
			this.tabPageSettings.Controls.Add(this.labelDataLength);
			this.tabPageSettings.Controls.Add(this.numericUpDownDataLength);
			this.tabPageSettings.Controls.Add(this.numericUpDownMaximumFailedHops);
			this.tabPageSettings.Controls.Add(this.labelMaximumFailedHops);
			this.tabPageSettings.Controls.Add(this.checkBoxStopOnFail);
			this.tabPageSettings.Controls.Add(this.checkBoxStopHopOnSuccess);
			this.tabPageSettings.Controls.Add(this.labelMaximumAttempts);
			this.tabPageSettings.Controls.Add(this.checkBoxAutomaticNameResolution);
			this.tabPageSettings.Controls.Add(this.numericUpDownMaximumHops);
			this.tabPageSettings.Controls.Add(this.numericUpDownMaximumAttempts);
			this.tabPageSettings.Controls.Add(this.labelMaximumHops);
			this.tabPageSettings.Location = new System.Drawing.Point(2, 23);
			this.tabPageSettings.Name = "tabPageSettings";
			this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSettings.Size = new System.Drawing.Size(794, 351);
			this.tabPageSettings.TabIndex = 1;
			this.tabPageSettings.Text = "Settings";
			this.tabPageSettings.UseVisualStyleBackColor = true;
			// 
			// labelDataLength
			// 
			this.labelDataLength.AutoSize = true;
			this.labelDataLength.Location = new System.Drawing.Point(7, 159);
			this.labelDataLength.Name = "labelDataLength";
			this.labelDataLength.Size = new System.Drawing.Size(88, 13);
			this.labelDataLength.TabIndex = 10;
			this.labelDataLength.Text = "Data size (bytes):";
			// 
			// numericUpDownDataLength
			// 
			this.numericUpDownDataLength.Location = new System.Drawing.Point(187, 157);
			this.numericUpDownDataLength.Maximum = new decimal(new int[] {
            65500,
            0,
            0,
            0});
			this.numericUpDownDataLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownDataLength.Name = "numericUpDownDataLength";
			this.numericUpDownDataLength.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownDataLength.TabIndex = 9;
			this.numericUpDownDataLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownDataLength.ValueChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// numericUpDownMaximumFailedHops
			// 
			this.numericUpDownMaximumFailedHops.Location = new System.Drawing.Point(187, 131);
			this.numericUpDownMaximumFailedHops.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.numericUpDownMaximumFailedHops.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMaximumFailedHops.Name = "numericUpDownMaximumFailedHops";
			this.numericUpDownMaximumFailedHops.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownMaximumFailedHops.TabIndex = 8;
			this.numericUpDownMaximumFailedHops.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMaximumFailedHops.ValueChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// labelMaximumFailedHops
			// 
			this.labelMaximumFailedHops.AutoSize = true;
			this.labelMaximumFailedHops.Location = new System.Drawing.Point(7, 133);
			this.labelMaximumFailedHops.Name = "labelMaximumFailedHops";
			this.labelMaximumFailedHops.Size = new System.Drawing.Size(158, 13);
			this.labelMaximumFailedHops.TabIndex = 7;
			this.labelMaximumFailedHops.Text = "Maximum number of &failed hops:";
			// 
			// checkBoxStopOnFail
			// 
			this.checkBoxStopOnFail.AutoSize = true;
			this.checkBoxStopOnFail.Location = new System.Drawing.Point(10, 108);
			this.checkBoxStopOnFail.Name = "checkBoxStopOnFail";
			this.checkBoxStopOnFail.Size = new System.Drawing.Size(297, 17);
			this.checkBoxStopOnFail.TabIndex = 6;
			this.checkBoxStopOnFail.Text = "&Stop traceroute after a number of consecutive failed hops";
			this.checkBoxStopOnFail.UseVisualStyleBackColor = true;
			this.checkBoxStopOnFail.CheckedChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// checkBoxStopHopOnSuccess
			// 
			this.checkBoxStopHopOnSuccess.AutoSize = true;
			this.checkBoxStopHopOnSuccess.Location = new System.Drawing.Point(10, 85);
			this.checkBoxStopHopOnSuccess.Name = "checkBoxStopHopOnSuccess";
			this.checkBoxStopHopOnSuccess.Size = new System.Drawing.Size(220, 17);
			this.checkBoxStopHopOnSuccess.TabIndex = 5;
			this.checkBoxStopHopOnSuccess.Text = "Stop traceroute &hop attempts on success";
			this.checkBoxStopHopOnSuccess.UseVisualStyleBackColor = true;
			this.checkBoxStopHopOnSuccess.CheckedChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// labelMaximumAttempts
			// 
			this.labelMaximumAttempts.AutoSize = true;
			this.labelMaximumAttempts.Location = new System.Drawing.Point(7, 61);
			this.labelMaximumAttempts.Name = "labelMaximumAttempts";
			this.labelMaximumAttempts.Size = new System.Drawing.Size(136, 13);
			this.labelMaximumAttempts.TabIndex = 3;
			this.labelMaximumAttempts.Text = "Maximum &attempts per hop:";
			// 
			// checkBoxAutomaticNameResolution
			// 
			this.checkBoxAutomaticNameResolution.AutoSize = true;
			this.checkBoxAutomaticNameResolution.Location = new System.Drawing.Point(10, 10);
			this.checkBoxAutomaticNameResolution.Name = "checkBoxAutomaticNameResolution";
			this.checkBoxAutomaticNameResolution.Size = new System.Drawing.Size(183, 17);
			this.checkBoxAutomaticNameResolution.TabIndex = 0;
			this.checkBoxAutomaticNameResolution.Text = "&Resolve hostnames automatically";
			this.checkBoxAutomaticNameResolution.UseVisualStyleBackColor = true;
			this.checkBoxAutomaticNameResolution.CheckedChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// numericUpDownMaximumHops
			// 
			this.numericUpDownMaximumHops.Location = new System.Drawing.Point(187, 33);
			this.numericUpDownMaximumHops.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.numericUpDownMaximumHops.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMaximumHops.Name = "numericUpDownMaximumHops";
			this.numericUpDownMaximumHops.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownMaximumHops.TabIndex = 2;
			this.numericUpDownMaximumHops.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMaximumHops.ValueChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// numericUpDownMaximumAttempts
			// 
			this.numericUpDownMaximumAttempts.Location = new System.Drawing.Point(187, 59);
			this.numericUpDownMaximumAttempts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMaximumAttempts.Name = "numericUpDownMaximumAttempts";
			this.numericUpDownMaximumAttempts.Size = new System.Drawing.Size(120, 20);
			this.numericUpDownMaximumAttempts.TabIndex = 4;
			this.numericUpDownMaximumAttempts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMaximumAttempts.ValueChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// labelMaximumHops
			// 
			this.labelMaximumHops.AutoSize = true;
			this.labelMaximumHops.Location = new System.Drawing.Point(7, 35);
			this.labelMaximumHops.Name = "labelMaximumHops";
			this.labelMaximumHops.Size = new System.Drawing.Size(80, 13);
			this.labelMaximumHops.TabIndex = 1;
			this.labelMaximumHops.Text = "Ma&ximum hops:";
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelDestination,
            this.textBoxDestination,
            this.buttonStart,
            this.buttonStop,
            this.separator1,
            this.buttonSave,
            this.buttonUndo});
			this.toolStrip.Location = new System.Drawing.Point(1, 23);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// labelDestination
			// 
			this.labelDestination.Name = "labelDestination";
			this.labelDestination.Size = new System.Drawing.Size(70, 22);
			this.labelDestination.Text = "&Destination:";
			// 
			// textBoxDestination
			// 
			this.textBoxDestination.Name = "textBoxDestination";
			this.textBoxDestination.Size = new System.Drawing.Size(150, 25);
			this.textBoxDestination.TextChanged += new System.EventHandler(this.OnInputChanged);
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
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Image = global::InetAnalytics.Resources.Save_16;
			this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(51, 22);
			this.buttonSave.Text = "&Save";
			this.buttonSave.Click += new System.EventHandler(this.OnSave);
			// 
			// buttonUndo
			// 
			this.buttonUndo.Enabled = false;
			this.buttonUndo.Image = global::InetAnalytics.Resources.UndoLarge_16;
			this.buttonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.Size = new System.Drawing.Size(56, 22);
			this.buttonUndo.Text = "&Undo";
			this.buttonUndo.Click += new System.EventHandler(this.OnUndo);
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.log.ShowBorder = true;
			this.log.ShowTitle = true;
			this.log.Size = new System.Drawing.Size(800, 170);
			this.log.TabIndex = 0;
			this.log.Title = "Event Log";
			// 
			// ControlTraceroute
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlTraceroute";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelTool.ResumeLayout(false);
			this.panelTool.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageRoute.ResumeLayout(false);
			this.tabPageSettings.ResumeLayout(false);
			this.tabPageSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownDataLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumFailedHops)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumHops)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaximumAttempts)).EndInit();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private DotNetApi.Windows.Controls.ThemeControl panelTool;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ImageList imageList;
		private InetAnalytics.Controls.Log.ControlLogList log;
		private DotNetApi.Windows.Controls.ThemeTabControl tabControl;
		private System.Windows.Forms.TabPage tabPageRoute;
		private System.Windows.Forms.TabPage tabPageSettings;
		private System.Windows.Forms.ToolStripLabel labelDestination;
		private System.Windows.Forms.ToolStripTextBox textBoxDestination;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private System.Windows.Forms.ListView listViewRoute;
		private System.Windows.Forms.ColumnHeader columnHeaderTtl;
		private System.Windows.Forms.ColumnHeader columnHeaderIp;
		private System.Windows.Forms.ColumnHeader columnHeaderRtt;
		private System.Windows.Forms.ColumnHeader columnHeaderSuccess;
		private System.Windows.Forms.ColumnHeader columnHeaderError;
		private System.Windows.Forms.ColumnHeader columnHeaderTotal;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripButton buttonSave;
		private System.Windows.Forms.ToolStripButton buttonUndo;
		private System.Windows.Forms.Label labelMaximumHops;
		private System.Windows.Forms.NumericUpDown numericUpDownMaximumAttempts;
		private System.Windows.Forms.CheckBox checkBoxAutomaticNameResolution;
		private System.Windows.Forms.NumericUpDown numericUpDownMaximumHops;
		private System.Windows.Forms.Label labelMaximumAttempts;
		private System.Windows.Forms.CheckBox checkBoxStopHopOnSuccess;
		private System.Windows.Forms.CheckBox checkBoxStopOnFail;
		private System.Windows.Forms.NumericUpDown numericUpDownMaximumFailedHops;
		private System.Windows.Forms.Label labelMaximumFailedHops;
		private System.Windows.Forms.Label labelDataLength;
		private System.Windows.Forms.NumericUpDown numericUpDownDataLength;
	}
}
