namespace InetTraceroute.Forms
{
	partial class FormMain
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
			if (disposing)
			{
				// Dispose the configuration.

				// Dispose the components.
				if (components != null)
				{
					this.components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.statusLabelLeft = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.statusLabelMiddle = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelRight = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelRun = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl = new DotNetApi.Windows.Controls.ThemeTabControl();
			this.tabPageAddresses = new System.Windows.Forms.TabPage();
			this.controlInterfaces = new InetTraceroute.Controls.ControlAddresses();
			this.tabPageDns = new System.Windows.Forms.TabPage();
			this.tabPageTraceroute = new System.Windows.Forms.TabPage();
			this.tabPageLog = new System.Windows.Forms.TabPage();
			this.controlLog1 = new InetTraceroute.Controls.Log.ControlLog();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageAddresses.SuspendLayout();
			this.tabPageLog.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer
			// 
			// 
			// toolStripContainer.BottomToolStripPanel
			// 
			this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.statusStrip);
			// 
			// toolStripContainer.ContentPanel
			// 
			this.toolStripContainer.ContentPanel.Controls.Add(this.tabControl);
			this.toolStripContainer.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(784, 516);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new System.Drawing.Size(784, 562);
			this.toolStripContainer.TabIndex = 0;
			this.toolStripContainer.Text = "toolStripContainer1";
			// 
			// toolStripContainer.TopToolStripPanel
			// 
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
			// 
			// statusStrip
			// 
			this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelLeft,
            this.statusProgress,
            this.statusLabelMiddle,
            this.statusLabelRight,
            this.statusLabelRun});
			this.statusStrip.Location = new System.Drawing.Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.ShowItemToolTips = true;
			this.statusStrip.Size = new System.Drawing.Size(784, 22);
			this.statusStrip.TabIndex = 1;
			// 
			// statusLabelLeft
			// 
			this.statusLabelLeft.Image = global::InetTraceroute.Resources.Information_16;
			this.statusLabelLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.statusLabelLeft.Name = "statusLabelLeft";
			this.statusLabelLeft.Size = new System.Drawing.Size(55, 17);
			this.statusLabelLeft.Text = "Ready";
			// 
			// statusProgress
			// 
			this.statusProgress.Name = "statusProgress";
			this.statusProgress.Size = new System.Drawing.Size(100, 16);
			this.statusProgress.Visible = false;
			// 
			// statusLabelMiddle
			// 
			this.statusLabelMiddle.Name = "statusLabelMiddle";
			this.statusLabelMiddle.Size = new System.Drawing.Size(579, 17);
			this.statusLabelMiddle.Spring = true;
			// 
			// statusLabelRight
			// 
			this.statusLabelRight.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.statusLabelRight.Name = "statusLabelRight";
			this.statusLabelRight.Size = new System.Drawing.Size(0, 17);
			// 
			// statusLabelRun
			// 
			this.statusLabelRun.Image = global::InetTraceroute.Resources.RunConcurrentStop_16;
			this.statusLabelRun.Name = "statusLabelRun";
			this.statusLabelRun.Size = new System.Drawing.Size(135, 17);
			this.statusLabelRun.Text = "No background tasks";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageAddresses);
			this.tabControl.Controls.Add(this.tabPageDns);
			this.tabControl.Controls.Add(this.tabPageTraceroute);
			this.tabControl.Controls.Add(this.tabPageLog);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(784, 516);
			this.tabControl.TabIndex = 1;
			// 
			// tabPageAddresses
			// 
			this.tabPageAddresses.Controls.Add(this.controlInterfaces);
			this.tabPageAddresses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabPageAddresses.Location = new System.Drawing.Point(2, 23);
			this.tabPageAddresses.Name = "tabPageAddresses";
			this.tabPageAddresses.Padding = new System.Windows.Forms.Padding(5);
			this.tabPageAddresses.Size = new System.Drawing.Size(780, 491);
			this.tabPageAddresses.TabIndex = 0;
			this.tabPageAddresses.Text = "Addresses";
			this.tabPageAddresses.UseVisualStyleBackColor = true;
			// 
			// controlInterfaces
			// 
			this.controlInterfaces.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlInterfaces.Location = new System.Drawing.Point(5, 5);
			this.controlInterfaces.Name = "controlInterfaces";
			this.controlInterfaces.Size = new System.Drawing.Size(770, 481);
			this.controlInterfaces.TabIndex = 0;
			// 
			// tabPageDns
			// 
			this.tabPageDns.Location = new System.Drawing.Point(2, 23);
			this.tabPageDns.Name = "tabPageDns";
			this.tabPageDns.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDns.Size = new System.Drawing.Size(780, 491);
			this.tabPageDns.TabIndex = 2;
			this.tabPageDns.Text = "Name Resolution";
			this.tabPageDns.UseVisualStyleBackColor = true;
			// 
			// tabPageTraceroute
			// 
			this.tabPageTraceroute.Location = new System.Drawing.Point(2, 23);
			this.tabPageTraceroute.Name = "tabPageTraceroute";
			this.tabPageTraceroute.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTraceroute.Size = new System.Drawing.Size(780, 491);
			this.tabPageTraceroute.TabIndex = 1;
			this.tabPageTraceroute.Text = "Traceroute";
			this.tabPageTraceroute.UseVisualStyleBackColor = true;
			// 
			// tabPageLog
			// 
			this.tabPageLog.Controls.Add(this.controlLog1);
			this.tabPageLog.Location = new System.Drawing.Point(2, 23);
			this.tabPageLog.Name = "tabPageLog";
			this.tabPageLog.Padding = new System.Windows.Forms.Padding(5);
			this.tabPageLog.Size = new System.Drawing.Size(780, 491);
			this.tabPageLog.TabIndex = 3;
			this.tabPageLog.Text = "Log";
			this.tabPageLog.UseVisualStyleBackColor = true;
			// 
			// controlLog1
			// 
			this.controlLog1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLog1.Enabled = false;
			this.controlLog1.Location = new System.Drawing.Point(5, 5);
			this.controlLog1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.controlLog1.Name = "controlLog1";
			this.controlLog1.Size = new System.Drawing.Size(770, 481);
			this.controlLog1.TabIndex = 0;
			// 
			// menuStrip
			// 
			this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemHelp});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(784, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// menuItemFile
			// 
			this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExit});
			this.menuItemFile.Name = "menuItemFile";
			this.menuItemFile.Size = new System.Drawing.Size(37, 20);
			this.menuItemFile.Text = "&File";
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.menuItemExit.Size = new System.Drawing.Size(134, 22);
			this.menuItemExit.Text = "&Exit";
			this.menuItemExit.Click += new System.EventHandler(this.OnExit);
			// 
			// menuItemHelp
			// 
			this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
			this.menuItemHelp.Name = "menuItemHelp";
			this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
			this.menuItemHelp.Text = "&Help";
			// 
			// menuItemAbout
			// 
			this.menuItemAbout.Name = "menuItemAbout";
			this.menuItemAbout.Size = new System.Drawing.Size(116, 22);
			this.menuItemAbout.Text = "&About...";
			this.menuItemAbout.Click += new System.EventHandler(this.OnAbout);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.toolStripContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "FormMain";
			this.Text = "Internet Traceroute";
			this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.PerformLayout();
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageAddresses.ResumeLayout(false);
			this.tabPageLog.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelLeft;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelMiddle;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelRight;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelRun;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem menuItemFile;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
		private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
		private System.Windows.Forms.ToolStripProgressBar statusProgress;
		private DotNetApi.Windows.Controls.ThemeTabControl tabControl;
		private System.Windows.Forms.TabPage tabPageAddresses;
		private System.Windows.Forms.TabPage tabPageTraceroute;
		private System.Windows.Forms.TabPage tabPageDns;
		private Controls.ControlAddresses controlInterfaces;
		private System.Windows.Forms.TabPage tabPageLog;
		private Controls.Log.ControlLog controlLog1;
	}
}

