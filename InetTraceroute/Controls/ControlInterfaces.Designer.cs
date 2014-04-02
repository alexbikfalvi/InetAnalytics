namespace InetTraceroute.Controls
{
	partial class ControlInterfaces
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
			this.splitContainerNetwork = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.themeControlNetwork = new DotNetApi.Windows.Controls.ThemeControl();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeaderAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStripNetwork = new System.Windows.Forms.ToolStrip();
			this.buttonRefreshInterfaces = new System.Windows.Forms.ToolStripButton();
			this.controlLogNetwork = new InetAnalytics.Controls.Log.ControlLogList();
			this.columnHeaderInterface = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.splitContainerNetwork)).BeginInit();
			this.splitContainerNetwork.Panel1.SuspendLayout();
			this.splitContainerNetwork.Panel2.SuspendLayout();
			this.splitContainerNetwork.SuspendLayout();
			this.themeControlNetwork.SuspendLayout();
			this.toolStripNetwork.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainerNetwork
			// 
			this.splitContainerNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerNetwork.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerNetwork.Location = new System.Drawing.Point(0, 0);
			this.splitContainerNetwork.Name = "splitContainerNetwork";
			this.splitContainerNetwork.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerNetwork.Panel1
			// 
			this.splitContainerNetwork.Panel1.Controls.Add(this.themeControlNetwork);
			this.splitContainerNetwork.Panel1Border = false;
			// 
			// splitContainerNetwork.Panel2
			// 
			this.splitContainerNetwork.Panel2.Controls.Add(this.controlLogNetwork);
			this.splitContainerNetwork.Panel2Border = false;
			this.splitContainerNetwork.Size = new System.Drawing.Size(600, 500);
			this.splitContainerNetwork.SplitterDistance = 329;
			this.splitContainerNetwork.SplitterWidth = 5;
			this.splitContainerNetwork.TabIndex = 1;
			this.splitContainerNetwork.UseTheme = false;
			// 
			// themeControlNetwork
			// 
			this.themeControlNetwork.Controls.Add(this.listView1);
			this.themeControlNetwork.Controls.Add(this.toolStripNetwork);
			this.themeControlNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
			this.themeControlNetwork.Location = new System.Drawing.Point(0, 0);
			this.themeControlNetwork.Name = "themeControlNetwork";
			this.themeControlNetwork.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.themeControlNetwork.ShowBorder = true;
			this.themeControlNetwork.ShowTitle = true;
			this.themeControlNetwork.Size = new System.Drawing.Size(600, 329);
			this.themeControlNetwork.TabIndex = 0;
			this.themeControlNetwork.Title = "Local Interfaces";
			// 
			// listView1
			// 
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress,
            this.columnHeaderProtocol,
            this.columnHeaderInterface});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(1, 48);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(598, 280);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderAddress
			// 
			this.columnHeaderAddress.Text = "Address";
			this.columnHeaderAddress.Width = 160;
			// 
			// columnHeaderProtocol
			// 
			this.columnHeaderProtocol.Text = "Protocol";
			// 
			// toolStripNetwork
			// 
			this.toolStripNetwork.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefreshInterfaces});
			this.toolStripNetwork.Location = new System.Drawing.Point(1, 23);
			this.toolStripNetwork.Name = "toolStripNetwork";
			this.toolStripNetwork.Size = new System.Drawing.Size(598, 25);
			this.toolStripNetwork.TabIndex = 0;
			this.toolStripNetwork.Text = "toolStrip1";
			// 
			// buttonRefreshInterfaces
			// 
			this.buttonRefreshInterfaces.Image = global::InetTraceroute.Resources.Refresh_16;
			this.buttonRefreshInterfaces.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRefreshInterfaces.Name = "buttonRefreshInterfaces";
			this.buttonRefreshInterfaces.Size = new System.Drawing.Size(66, 22);
			this.buttonRefreshInterfaces.Text = "&Refresh";
			// 
			// controlLogNetwork
			// 
			this.controlLogNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLogNetwork.Location = new System.Drawing.Point(0, 0);
			this.controlLogNetwork.Name = "controlLogNetwork";
			this.controlLogNetwork.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.controlLogNetwork.ShowBorder = true;
			this.controlLogNetwork.ShowTitle = true;
			this.controlLogNetwork.Size = new System.Drawing.Size(600, 166);
			this.controlLogNetwork.TabIndex = 0;
			this.controlLogNetwork.Title = "Event Log";
			// 
			// columnHeaderInterface
			// 
			this.columnHeaderInterface.Text = "Interface";
			this.columnHeaderInterface.Width = 160;
			// 
			// ControlInterfaces
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainerNetwork);
			this.Name = "ControlInterfaces";
			this.Size = new System.Drawing.Size(600, 500);
			this.splitContainerNetwork.Panel1.ResumeLayout(false);
			this.splitContainerNetwork.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerNetwork)).EndInit();
			this.splitContainerNetwork.ResumeLayout(false);
			this.themeControlNetwork.ResumeLayout(false);
			this.themeControlNetwork.PerformLayout();
			this.toolStripNetwork.ResumeLayout(false);
			this.toolStripNetwork.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerNetwork;
		private DotNetApi.Windows.Controls.ThemeControl themeControlNetwork;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeaderAddress;
		private System.Windows.Forms.ColumnHeader columnHeaderProtocol;
		private System.Windows.Forms.ToolStrip toolStripNetwork;
		private System.Windows.Forms.ToolStripButton buttonRefreshInterfaces;
		private InetAnalytics.Controls.Log.ControlLogList controlLogNetwork;
		private System.Windows.Forms.ColumnHeader columnHeaderInterface;
	}
}
