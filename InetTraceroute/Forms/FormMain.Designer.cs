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
			if (disposing && (components != null))
			{
				components.Dispose();
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
			this.statusLabelMiddle = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelRight = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelRun = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelConnection = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabelLeft = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl = new DotNetApi.Windows.Controls.ThemeTabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
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
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(584, 415);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new System.Drawing.Size(584, 462);
			this.toolStripContainer.TabIndex = 0;
			this.toolStripContainer.Text = "toolStripContainer1";
			// 
			// statusStrip
			// 
			this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelLeft,
            this.statusLabelMiddle,
            this.statusLabelRight,
            this.statusLabelRun,
            this.statusLabelConnection});
			this.statusStrip.Location = new System.Drawing.Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.ShowItemToolTips = true;
			this.statusStrip.Size = new System.Drawing.Size(584, 22);
			this.statusStrip.TabIndex = 1;
			// 
			// statusLabelMiddle
			// 
			this.statusLabelMiddle.Name = "statusLabelMiddle";
			this.statusLabelMiddle.Size = new System.Drawing.Size(314, 17);
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
			// statusLabelConnection
			// 
			this.statusLabelConnection.Name = "statusLabelConnection";
			this.statusLabelConnection.Size = new System.Drawing.Size(65, 17);
			this.statusLabelConnection.Text = "Connected";
			// 
			// statusLabelLeft
			// 
			this.statusLabelLeft.Image = global::InetTraceroute.Resources.Information_16;
			this.statusLabelLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.statusLabelLeft.Name = "statusLabelLeft";
			this.statusLabelLeft.Size = new System.Drawing.Size(55, 17);
			this.statusLabelLeft.Text = "Ready";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(584, 415);
			this.tabControl.TabIndex = 0;
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.OnTabChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(2, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(580, 390);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(2, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(196, 75);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 462);
			this.Controls.Add(this.toolStripContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormMain";
			this.Text = "Internet Traceroute";
			this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer toolStripContainer;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelLeft;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelMiddle;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelRight;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelRun;
		private System.Windows.Forms.ToolStripStatusLabel statusLabelConnection;
		private DotNetApi.Windows.Controls.ThemeTabControl tabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
	}
}

