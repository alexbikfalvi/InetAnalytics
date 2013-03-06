namespace YtAnalytics.Controls
{
	partial class ControlServer
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
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonConnect = new System.Windows.Forms.ToolStripButton();
			this.buttonDisconnect = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonPrimary = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonChangePassword = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonProperties = new System.Windows.Forms.ToolStripButton();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.panel = new System.Windows.Forms.Panel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelName = new System.Windows.Forms.Label();
			this.labelPrimary = new System.Windows.Forms.Label();
			this.log = new YtAnalytics.Controls.ControlLogList();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonConnect,
            this.buttonDisconnect,
            this.toolStripSeparator1,
            this.buttonPrimary,
            this.toolStripSeparator2,
            this.buttonChangePassword,
            this.toolStripSeparator3,
            this.buttonProperties});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// buttonConnect
			// 
			this.buttonConnect.Enabled = false;
			this.buttonConnect.Image = global::YtAnalytics.Resources.Connect_16;
			this.buttonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(72, 22);
			this.buttonConnect.Text = "&Connect";
			this.buttonConnect.Click += new System.EventHandler(this.OnConnect);
			// 
			// buttonDisconnect
			// 
			this.buttonDisconnect.Enabled = false;
			this.buttonDisconnect.Image = global::YtAnalytics.Resources.Disconnect_16;
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
			// buttonPrimary
			// 
			this.buttonPrimary.Enabled = false;
			this.buttonPrimary.Image = global::YtAnalytics.Resources.ServerStar_16;
			this.buttonPrimary.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonPrimary.Name = "buttonPrimary";
			this.buttonPrimary.Size = new System.Drawing.Size(100, 22);
			this.buttonPrimary.Text = "Make &primary";
			this.buttonPrimary.Click += new System.EventHandler(this.OnMakePrimary);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonChangePassword
			// 
			this.buttonChangePassword.Image = global::YtAnalytics.Resources.PasswordChange_16;
			this.buttonChangePassword.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonChangePassword.Name = "buttonChangePassword";
			this.buttonChangePassword.Size = new System.Drawing.Size(121, 22);
			this.buttonChangePassword.Text = "Cha&nge password";
			this.buttonChangePassword.Click += new System.EventHandler(this.OnChangePassword);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonProperties
			// 
			this.buttonProperties.Image = global::YtAnalytics.Resources.Properties_16;
			this.buttonProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonProperties.Name = "buttonProperties";
			this.buttonProperties.Size = new System.Drawing.Size(80, 22);
			this.buttonProperties.Text = "P&roperties";
			this.buttonProperties.Click += new System.EventHandler(this.OnProperties);
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
			this.splitContainer.Panel1.Controls.Add(this.panel);
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.TabIndex = 1;
			// 
			// panel
			// 
			this.panel.AutoScroll = true;
			this.panel.Controls.Add(this.labelPrimary);
			this.panel.Controls.Add(this.labelName);
			this.panel.Controls.Add(this.pictureBox);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 25);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(798, 398);
			this.panel.TabIndex = 1;
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.ServerDown_48;
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelName.Location = new System.Drawing.Point(64, 16);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(99, 20);
			this.labelName.TabIndex = 1;
			this.labelName.Text = "Server name";
			// 
			// labelPrimary
			// 
			this.labelPrimary.AutoSize = true;
			this.labelPrimary.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.labelPrimary.Location = new System.Drawing.Point(65, 37);
			this.labelPrimary.Name = "labelPrimary";
			this.labelPrimary.Size = new System.Drawing.Size(73, 13);
			this.labelPrimary.TabIndex = 2;
			this.labelPrimary.Text = "Primary server";
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(798, 169);
			this.log.TabIndex = 0;
			// 
			// ControlServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlServer";
			this.Size = new System.Drawing.Size(800, 600);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.SplitContainer splitContainer;
		private ControlLogList log;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton buttonPrimary;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton buttonConnect;
		private System.Windows.Forms.ToolStripButton buttonDisconnect;
		private System.Windows.Forms.ToolStripButton buttonChangePassword;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton buttonProperties;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelPrimary;
		private System.Windows.Forms.Label labelName;
	}
}
