namespace InetTraceroute.Controls
{
	partial class ControlAddresses
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlAddresses));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.themeControl = new DotNetApi.Windows.Controls.ThemeControl();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderInterface = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
			this.controlLog = new InetControls.Controls.Log.ControlLogList();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.themeControl.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.themeControl);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.controlLog);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(600, 500);
			this.splitContainer.SplitterDistance = 329;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 1;
			this.splitContainer.UseTheme = false;
			// 
			// themeControl
			// 
			this.themeControl.Controls.Add(this.listView);
			this.themeControl.Controls.Add(this.toolStrip);
			this.themeControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.themeControl.Location = new System.Drawing.Point(0, 0);
			this.themeControl.Name = "themeControl";
			this.themeControl.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.themeControl.ShowBorder = true;
			this.themeControl.ShowTitle = true;
			this.themeControl.Size = new System.Drawing.Size(600, 329);
			this.themeControl.TabIndex = 0;
			this.themeControl.Title = "Local Addresses";
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.CheckBoxes = true;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress,
            this.columnHeaderProtocol,
            this.columnHeaderInterface});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(1, 48);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(598, 280);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 1;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnItemChecked);
			// 
			// columnHeaderAddress
			// 
			this.columnHeaderAddress.Text = "Address";
			this.columnHeaderAddress.Width = 200;
			// 
			// columnHeaderProtocol
			// 
			this.columnHeaderProtocol.Text = "Protocol";
			this.columnHeaderProtocol.Width = 100;
			// 
			// columnHeaderInterface
			// 
			this.columnHeaderInterface.Text = "Interface";
			this.columnHeaderInterface.Width = 200;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "NetworkInterface");
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefresh});
			this.toolStrip.Location = new System.Drawing.Point(1, 23);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(598, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Image = global::InetTraceroute.Resources.Refresh_16;
			this.buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(66, 22);
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefresh);
			// 
			// controlLog
			// 
			this.controlLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLog.Location = new System.Drawing.Point(0, 0);
			this.controlLog.Name = "controlLog";
			this.controlLog.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.controlLog.ShowBorder = true;
			this.controlLog.ShowTitle = true;
			this.controlLog.Size = new System.Drawing.Size(600, 166);
			this.controlLog.TabIndex = 0;
			this.controlLog.Title = "Event Log";
			// 
			// ControlAddresses
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlAddresses";
			this.Size = new System.Drawing.Size(600, 500);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.themeControl.ResumeLayout(false);
			this.themeControl.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private DotNetApi.Windows.Controls.ThemeControl themeControl;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderAddress;
		private System.Windows.Forms.ColumnHeader columnHeaderProtocol;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonRefresh;
		private InetControls.Controls.Log.ControlLogList controlLog;
		private System.Windows.Forms.ColumnHeader columnHeaderInterface;
		private System.Windows.Forms.ImageList imageList;
	}
}
