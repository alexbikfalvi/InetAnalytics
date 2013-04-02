namespace YtAnalytics.Controls.Log
{
	partial class ControlLogList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlLogList));
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripLog = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView
			// 
			this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderDescription});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(0, 25);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(600, 125);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 0;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemActivate += new System.EventHandler(this.OnItemActivate);
			// 
			// columnHeaderTime
			// 
			this.columnHeaderTime.Text = "Date/Time";
			this.columnHeaderTime.Width = 140;
			// 
			// columnHeaderDescription
			// 
			this.columnHeaderDescription.Text = "Description";
			this.columnHeaderDescription.Width = 400;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Information_16.png");
			this.imageList.Images.SetKeyName(1, "Success_16.png");
			this.imageList.Images.SetKeyName(2, "Error_16.png");
			this.imageList.Images.SetKeyName(3, "Canceled_16.png");
			this.imageList.Images.SetKeyName(4, "Warning_16.png");
			this.imageList.Images.SetKeyName(5, "Stop_16.png");
			this.imageList.Images.SetKeyName(6, "SuccessWarning_16.png");
			this.imageList.Images.SetKeyName(7, "ErrorWarning_16.png");
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLog,
            this.toolStripSeparator1,
            this.toolStripLabel,
            this.toolStripComboBox,
            this.toolStripSeparator2,
            this.toolStripButtonClear});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(600, 25);
			this.toolStrip.TabIndex = 1;
			this.toolStrip.Text = "toolStrip";
			// 
			// toolStripLog
			// 
			this.toolStripLog.Image = global::YtAnalytics.Resources.Log_16;
			this.toolStripLog.Name = "toolStripLog";
			this.toolStripLog.Size = new System.Drawing.Size(16, 22);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel
			// 
			this.toolStripLabel.Name = "toolStripLabel";
			this.toolStripLabel.Size = new System.Drawing.Size(96, 22);
			this.toolStripLabel.Text = "Maximum items:";
			// 
			// toolStripComboBox
			// 
			this.toolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toolStripComboBox.Items.AddRange(new object[] {
            "10",
            "100",
            "1000",
            "Unlimited"});
			this.toolStripComboBox.Name = "toolStripComboBox";
			this.toolStripComboBox.Size = new System.Drawing.Size(80, 25);
			this.toolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.OnMaximumItemsChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonClear
			// 
			this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButtonClear.Enabled = false;
			this.toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClear.Image")));
			this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonClear.Name = "toolStripButtonClear";
			this.toolStripButtonClear.Size = new System.Drawing.Size(38, 22);
			this.toolStripButtonClear.Text = "Clear";
			this.toolStripButtonClear.Click += new System.EventHandler(this.OnClear);
			// 
			// ControlLogList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listView);
			this.Controls.Add(this.toolStrip);
			this.Name = "ControlLogList";
			this.Size = new System.Drawing.Size(600, 150);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderTime;
		private System.Windows.Forms.ColumnHeader columnHeaderDescription;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton toolStripButtonClear;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLog;
	}
}
