namespace InetAnalytics.Controls.Database
{
	partial class ControlServerQuery
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
			// Clear the items such that database events do not call handles on disposed components.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlServerQuery));
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonConnect = new System.Windows.Forms.ToolStripButton();
			this.buttonDisconnect = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.codeBox = new DotNetApi.Windows.Controls.CodeTextBox();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.dataGrid = new System.Windows.Forms.DataGridView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.panelQuery = new DotNetApi.Windows.Controls.ThemeControl();
			this.panelResult = new DotNetApi.Windows.Controls.ThemeControl();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.statusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.panelQuery.SuspendLayout();
			this.panelResult.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonConnect,
            this.buttonDisconnect,
            this.toolStripSeparator1,
            this.buttonStart,
            this.buttonStop});
			this.toolStrip.Location = new System.Drawing.Point(1, 22);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// buttonConnect
			// 
			this.buttonConnect.Enabled = false;
			this.buttonConnect.Image = global::InetAnalytics.Resources.Connect_16;
			this.buttonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(72, 22);
			this.buttonConnect.Text = "&Connect";
			this.buttonConnect.Click += new System.EventHandler(this.OnConnect);
			// 
			// buttonDisconnect
			// 
			this.buttonDisconnect.Enabled = false;
			this.buttonDisconnect.Image = global::InetAnalytics.Resources.Disconnect_16;
			this.buttonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonDisconnect.Name = "buttonDisconnect";
			this.buttonDisconnect.Size = new System.Drawing.Size(86, 22);
			this.buttonDisconnect.Text = "&Disconnect";
			this.buttonDisconnect.Click += new System.EventHandler(this.OnDisconnect);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonStart
			// 
			this.buttonStart.Enabled = false;
			this.buttonStart.Image = global::InetAnalytics.Resources.QueryStart_16;
			this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(84, 22);
			this.buttonStart.Text = "St&art query";
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::InetAnalytics.Resources.QueryStop_24;
			this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(84, 22);
			this.buttonStop.Text = "St&op query";
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.panelQuery);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.panelResult);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 300;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 1;
			// 
			// codeBox
			// 
			this.codeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.codeBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.codeBox.Font = new System.Drawing.Font("Consolas", 10F);
			this.codeBox.ForeColor = System.Drawing.Color.Blue;
			this.codeBox.Location = new System.Drawing.Point(1, 47);
			this.codeBox.Name = "codeBox";
			this.codeBox.Size = new System.Drawing.Size(798, 230);
			this.codeBox.TabIndex = 2;
			this.codeBox.Text = "";
			this.codeBox.TextChanged += new System.EventHandler(this.OnQueryChanged);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
			this.statusStrip.Location = new System.Drawing.Point(1, 277);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(798, 22);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 1;
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(39, 17);
			this.statusLabel.Text = "Ready";
			// 
			// dataGrid
			// 
			this.dataGrid.AllowUserToAddRows = false;
			this.dataGrid.AllowUserToDeleteRows = false;
			this.dataGrid.AllowUserToOrderColumns = true;
			this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid.Location = new System.Drawing.Point(1, 22);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGrid.Size = new System.Drawing.Size(798, 272);
			this.dataGrid.TabIndex = 0;
			this.dataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnCellFormatting);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Database");
			this.imageList.Images.SetKeyName(1, "DatabaseStar");
			// 
			// panelQuery
			// 
			this.panelQuery.Controls.Add(this.codeBox);
			this.panelQuery.Controls.Add(this.statusStrip);
			this.panelQuery.Controls.Add(this.toolStrip);
			this.panelQuery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelQuery.Location = new System.Drawing.Point(0, 0);
			this.panelQuery.Name = "panelQuery";
			this.panelQuery.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelQuery.ShowBorder = true;
			this.panelQuery.ShowTitle = true;
			this.panelQuery.Size = new System.Drawing.Size(800, 300);
			this.panelQuery.TabIndex = 3;
			this.panelQuery.Title = "Database Query";
			// 
			// panelResult
			// 
			this.panelResult.Controls.Add(this.dataGrid);
			this.panelResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelResult.Location = new System.Drawing.Point(0, 0);
			this.panelResult.Name = "panelResult";
			this.panelResult.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelResult.ShowBorder = true;
			this.panelResult.ShowTitle = true;
			this.panelResult.Size = new System.Drawing.Size(800, 295);
			this.panelResult.TabIndex = 1;
			this.panelResult.Title = "Query Result";
			// 
			// ControlServerQuery
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlServerQuery";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.panelQuery.ResumeLayout(false);
			this.panelQuery.PerformLayout();
			this.panelResult.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton buttonConnect;
		private System.Windows.Forms.ToolStripButton buttonDisconnect;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.DataGridView dataGrid;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private DotNetApi.Windows.Controls.CodeTextBox codeBox;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private DotNetApi.Windows.Controls.ThemeControl panelQuery;
		private DotNetApi.Windows.Controls.ThemeControl panelResult;
	}
}
