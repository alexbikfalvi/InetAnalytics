namespace InetTools.Controls
{
	partial class ControlMercuryClient
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
					//// Dispose the cancellation token.
					//if (null != this.asyncCancel)
					//{
					//	// Cancel the asynchronous operation.
					//	asyncCancel.Cancel();
					//	// If there exists an asynchronous operation in progress.
					//	if (null != this.asyncResult)
					//	{
					//		// Wait for the operation to complete.
					//		this.asyncResult.AsyncWaitHandle.WaitOne();
					//	}
					//	// Dispose the cancellation token.
					//	asyncCancel.Dispose();
					//}
				}
				// Dispose the components.
				if (this.components != null)
				{
					components.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlMercuryClient));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelTool = new DotNetApi.Windows.Controls.ThemeControl();
			this.tabControl = new DotNetApi.Windows.Controls.ThemeTabControl();
			this.tabPageTraceroute = new System.Windows.Forms.TabPage();
			this.splitContainerTraceroute = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.codeTextBox = new DotNetApi.Windows.Controls.CodeTextBox();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.labelServer = new System.Windows.Forms.ToolStripLabel();
			this.textBoxUrl = new System.Windows.Forms.ToolStripTextBox();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonUpload = new System.Windows.Forms.ToolStripButton();
			this.buttonCancel = new System.Windows.Forms.ToolStripButton();
			this.controlLog = new InetAnalytics.Controls.Log.ControlLogList();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.controlTraceroute = new InetTools.Controls.ControlMercuryClientTraceroute();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelTool.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageTraceroute.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTraceroute)).BeginInit();
			this.splitContainerTraceroute.Panel1.SuspendLayout();
			this.splitContainerTraceroute.Panel2.SuspendLayout();
			this.splitContainerTraceroute.SuspendLayout();
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
			this.panelTool.Title = "Content Delivery Networks Finder";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageTraceroute);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(1, 48);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(798, 376);
			this.tabControl.TabIndex = 3;
			// 
			// tabPageTraceroute
			// 
			this.tabPageTraceroute.Controls.Add(this.splitContainerTraceroute);
			this.tabPageTraceroute.Location = new System.Drawing.Point(2, 23);
			this.tabPageTraceroute.Name = "tabPageTraceroute";
			this.tabPageTraceroute.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageTraceroute.Size = new System.Drawing.Size(794, 351);
			this.tabPageTraceroute.TabIndex = 0;
			this.tabPageTraceroute.Text = "Traceroute";
			this.tabPageTraceroute.UseVisualStyleBackColor = true;
			// 
			// splitContainerTraceroute
			// 
			this.splitContainerTraceroute.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerTraceroute.Location = new System.Drawing.Point(4, 4);
			this.splitContainerTraceroute.Name = "splitContainerTraceroute";
			// 
			// splitContainerTraceroute.Panel1
			// 
			this.splitContainerTraceroute.Panel1.Controls.Add(this.codeTextBox);
			this.splitContainerTraceroute.Panel1.Padding = new System.Windows.Forms.Padding(1);
			// 
			// splitContainerTraceroute.Panel2
			// 
			this.splitContainerTraceroute.Panel2.Controls.Add(this.controlTraceroute);
			this.splitContainerTraceroute.Panel2.Padding = new System.Windows.Forms.Padding(1);
			this.splitContainerTraceroute.Size = new System.Drawing.Size(786, 343);
			this.splitContainerTraceroute.SplitterDistance = 388;
			this.splitContainerTraceroute.SplitterWidth = 5;
			this.splitContainerTraceroute.TabIndex = 3;
			this.splitContainerTraceroute.UseTheme = false;
			// 
			// codeTextBox
			// 
			this.codeTextBox.BackColor = System.Drawing.Color.White;
			this.codeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.codeTextBox.ColorCollection = null;
			this.codeTextBox.DefaultBackgroundColor = System.Drawing.Color.White;
			this.codeTextBox.DefaultForegroundColor = System.Drawing.Color.Black;
			this.codeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.codeTextBox.Font = new System.Drawing.Font("Consolas", 10F);
			this.codeTextBox.ForeColor = System.Drawing.Color.Black;
			this.codeTextBox.Location = new System.Drawing.Point(1, 1);
			this.codeTextBox.Name = "codeTextBox";
			this.codeTextBox.Size = new System.Drawing.Size(386, 341);
			this.codeTextBox.TabIndex = 1;
			this.codeTextBox.Text = "";
			this.codeTextBox.TextChanged += new System.EventHandler(this.OnInputChanged);
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
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelServer,
            this.textBoxUrl,
            this.separator1,
            this.buttonUpload,
            this.buttonCancel});
			this.toolStrip.Location = new System.Drawing.Point(1, 23);
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
			// buttonUpload
			// 
			this.buttonUpload.Enabled = false;
			this.buttonUpload.Image = global::InetTools.Properties.Resources.GlobeUpload_16;
			this.buttonUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonUpload.Name = "buttonUpload";
			this.buttonUpload.Size = new System.Drawing.Size(118, 22);
			this.buttonUpload.Text = "&Parse and upload";
			this.buttonUpload.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Enabled = false;
			this.buttonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(47, 22);
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.OnStop);
			// 
			// controlLog
			// 
			this.controlLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLog.Location = new System.Drawing.Point(0, 0);
			this.controlLog.Name = "controlLog";
			this.controlLog.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.controlLog.ShowBorder = true;
			this.controlLog.ShowTitle = true;
			this.controlLog.Size = new System.Drawing.Size(800, 170);
			this.controlLog.TabIndex = 0;
			this.controlLog.Title = "Event Log";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "XML files (*.xml)|*.xml";
			this.saveFileDialog.Title = "Save Sites";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Alexa ranking files (*.alx)|*.alx";
			this.openFileDialog.Title = "Open Sites List";
			// 
			// controlTraceroute
			// 
			this.controlTraceroute.AutoScroll = true;
			this.controlTraceroute.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlTraceroute.Location = new System.Drawing.Point(1, 1);
			this.controlTraceroute.Name = "controlTraceroute";
			this.controlTraceroute.Size = new System.Drawing.Size(391, 341);
			this.controlTraceroute.TabIndex = 0;
			// 
			// ControlMercuryClient
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlMercuryClient";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelTool.ResumeLayout(false);
			this.panelTool.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageTraceroute.ResumeLayout(false);
			this.splitContainerTraceroute.Panel1.ResumeLayout(false);
			this.splitContainerTraceroute.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTraceroute)).EndInit();
			this.splitContainerTraceroute.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private DotNetApi.Windows.Controls.ThemeControl panelTool;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonUpload;
		private System.Windows.Forms.ToolStripButton buttonCancel;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private InetAnalytics.Controls.Log.ControlLogList controlLog;
		private DotNetApi.Windows.Controls.ThemeTabControl tabControl;
		private System.Windows.Forms.TabPage tabPageTraceroute;
		private System.Windows.Forms.ToolStripLabel labelServer;
		private System.Windows.Forms.ToolStripTextBox textBoxUrl;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerTraceroute;
		private DotNetApi.Windows.Controls.CodeTextBox codeTextBox;
		private ControlMercuryClientTraceroute controlTraceroute;
	}
}
