namespace YtAnalytics.Controls.PlanetLab
{
	partial class ControlSession
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
				// Remove the slice configuration event handlers.
				this.config.Changed -= this.OnConfigurationChanged;
				this.config.Disposed -= this.OnConfigurationChanged;

				// Remove the node event handlers.
				this.node.Changed -= this.OnConfigurationChanged;

				// Dispose the components.
				if (null != this.components)
				{
					this.components.Dispose();
				}
			}
			// Call the base class method.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSession));
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.panel = new System.Windows.Forms.Panel();
			this.console = new YtAnalytics.Controls.ControlConsole();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.labelHostname = new System.Windows.Forms.ToolStripLabel();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonConnect = new System.Windows.Forms.ToolStripButton();
			this.buttonDisconnect = new System.Windows.Forms.ToolStripButton();
			this.log = new YtAnalytics.Controls.Log.ControlLogList();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
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
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
			this.splitContainer.TabIndex = 2;
			// 
			// panel
			// 
			this.panel.Controls.Add(this.console);
			this.panel.Controls.Add(this.toolStrip1);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(598, 223);
			this.panel.TabIndex = 0;
			// 
			// console
			// 
			this.console.ButtonImage = ((System.Drawing.Image)(resources.GetObject("console.ButtonImage")));
			this.console.Dock = System.Windows.Forms.DockStyle.Fill;
			this.console.Location = new System.Drawing.Point(0, 25);
			this.console.Name = "console";
			this.console.Size = new System.Drawing.Size(598, 198);
			this.console.TabIndex = 1;
			this.console.Execute += new System.EventHandler(this.OnExecuteCommand);
			this.console.Cancel += new System.EventHandler(this.OnCancelCommand);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelHostname,
            this.separator1,
            this.buttonConnect,
            this.buttonDisconnect});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(598, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// labelHostname
			// 
			this.labelHostname.Name = "labelHostname";
			this.labelHostname.Size = new System.Drawing.Size(62, 22);
			this.labelHostname.Text = "Hostname";
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonConnect
			// 
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
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(598, 169);
			this.log.TabIndex = 0;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Header_16.png");
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Title = "Export Settings";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "XML files (*.xml)|*.xml";
			this.openFileDialog.Title = "Import Settings";
			// 
			// ControlSession
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlSession";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private Log.ControlLogList log;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private ControlConsole console;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton buttonConnect;
		private System.Windows.Forms.ToolStripButton buttonDisconnect;
		private System.Windows.Forms.ToolStripLabel labelHostname;
		private System.Windows.Forms.ToolStripSeparator separator1;

	}
}
