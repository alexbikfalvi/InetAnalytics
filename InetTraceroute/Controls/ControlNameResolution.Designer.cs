namespace InetTraceroute.Controls
{
	partial class ControlNameResolution
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlNameResolution));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.themeControl = new DotNetApi.Windows.Controls.ThemeControl();
			this.textBoxResult = new DotNetApi.Windows.Controls.ConsoleTextBox();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.labelName = new System.Windows.Forms.ToolStripLabel();
			this.textBoxName = new System.Windows.Forms.ToolStripTextBox();
			this.buttonRecords = new System.Windows.Forms.ToolStripDropDownButton();
			this.listRecords = new DotNetApi.Windows.Controls.ToolStripDropDownCheckedList();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.controlLog = new InetControls.Controls.Log.ControlLogList();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
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
			this.themeControl.Controls.Add(this.textBoxResult);
			this.themeControl.Controls.Add(this.toolStrip);
			this.themeControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.themeControl.Location = new System.Drawing.Point(0, 0);
			this.themeControl.Name = "themeControl";
			this.themeControl.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.themeControl.ShowBorder = true;
			this.themeControl.ShowTitle = true;
			this.themeControl.Size = new System.Drawing.Size(600, 329);
			this.themeControl.TabIndex = 0;
			this.themeControl.Title = "Name Resolution";
			// 
			// textBoxResult
			// 
			this.textBoxResult.BackColor = System.Drawing.Color.Black;
			this.textBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxResult.DefaultBackgroundColor = System.Drawing.Color.Black;
			this.textBoxResult.DefaultForegroundColor = System.Drawing.Color.LightGray;
			this.textBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxResult.Font = new System.Drawing.Font("Consolas", 10F);
			this.textBoxResult.ForeColor = System.Drawing.Color.LightGray;
			this.textBoxResult.Location = new System.Drawing.Point(1, 48);
			this.textBoxResult.Name = "textBoxResult";
			this.textBoxResult.ReadOnly = true;
			this.textBoxResult.Size = new System.Drawing.Size(598, 280);
			this.textBoxResult.TabIndex = 1;
			this.textBoxResult.Text = "";
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelName,
            this.textBoxName,
            this.buttonRecords,
            this.buttonStart,
            this.buttonStop});
			this.toolStrip.Location = new System.Drawing.Point(1, 23);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(598, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// labelName
			// 
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(42, 22);
			this.labelName.Text = "Name:";
			// 
			// textBoxName
			// 
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(200, 25);
			this.textBoxName.TextChanged += new System.EventHandler(this.OnNameChanged);
			// 
			// buttonRecords
			// 
			this.buttonRecords.DropDown = this.listRecords;
			this.buttonRecords.Image = global::InetTraceroute.Resources.RecordLarge_16;
			this.buttonRecords.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRecords.Name = "buttonRecords";
			this.buttonRecords.Size = new System.Drawing.Size(104, 22);
			this.buttonRecords.Text = "Record types";
			// 
			// listRecords
			// 
			this.listRecords.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.listRecords.ListMinimumSize = new System.Drawing.Size(200, 200);
			this.listRecords.ListSize = new System.Drawing.Size(200, 200);
			this.listRecords.Name = "listRecords";
			this.listRecords.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
			this.listRecords.Size = new System.Drawing.Size(208, 227);
			// 
			// buttonStart
			// 
			this.buttonStart.Enabled = false;
			this.buttonStart.Image = global::InetTraceroute.Resources.PlayStart_16;
			this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(51, 22);
			this.buttonStart.Text = "Start";
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::InetTraceroute.Resources.PlayStop_16;
			this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(51, 22);
			this.buttonStop.Text = "Stop";
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
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
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "NetworkInterface");
			// 
			// ControlNameResolution
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlNameResolution";
			this.Size = new System.Drawing.Size(600, 500);
			this.Controls.SetChildIndex(this.splitContainer, 0);
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
		private System.Windows.Forms.ToolStrip toolStrip;
		private InetControls.Controls.Log.ControlLogList controlLog;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private System.Windows.Forms.ToolStripLabel labelName;
		private System.Windows.Forms.ToolStripTextBox textBoxName;
		private DotNetApi.Windows.Controls.ConsoleTextBox textBoxResult;
		private DotNetApi.Windows.Controls.ToolStripDropDownCheckedList listRecords;
		private System.Windows.Forms.ToolStripDropDownButton buttonRecords;
	}
}
