namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlCommand
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
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.textBox = new DotNetApi.Windows.Controls.CodeTextBox();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonSave = new System.Windows.Forms.ToolStripButton();
			this.buttonUndo = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonAddParameters = new System.Windows.Forms.ToolStripButton();
			this.buttonRemoveParameter = new System.Windows.Forms.ToolStripButton();
			this.dataParemeters = new System.Windows.Forms.DataGridView();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelSpring = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelInfo = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataParemeters)).BeginInit();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.textBox);
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(1);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.dataParemeters);
			this.splitContainer.Panel2.Controls.Add(this.statusStrip);
			this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(1);
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 200;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 0;
			this.splitContainer.UseTheme = false;
			// 
			// textBox
			// 
			this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox.Font = new System.Drawing.Font("Consolas", 10F);
			this.textBox.ForeColor = System.Drawing.Color.Blue;
			this.textBox.Location = new System.Drawing.Point(1, 26);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(598, 173);
			this.textBox.TabIndex = 3;
			this.textBox.Text = "";
			this.textBox.TextChanged += new System.EventHandler(this.OnCommandChanged);
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSave,
            this.buttonUndo,
            this.separator1,
            this.buttonAddParameters,
            this.buttonRemoveParameter});
			this.toolStrip.Location = new System.Drawing.Point(1, 1);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(598, 25);
			this.toolStrip.TabIndex = 2;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Image = global::InetAnalytics.Resources.Save_16;
			this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(51, 22);
			this.buttonSave.Text = "&Save";
			this.buttonSave.Click += new System.EventHandler(this.OnSave);
			// 
			// buttonUndo
			// 
			this.buttonUndo.Enabled = false;
			this.buttonUndo.Image = global::InetAnalytics.Resources.UndoLarge_16;
			this.buttonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.Size = new System.Drawing.Size(56, 22);
			this.buttonUndo.Text = "&Undo";
			this.buttonUndo.Click += new System.EventHandler(this.OnUndo);
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonAddParameters
			// 
			this.buttonAddParameters.Enabled = false;
			this.buttonAddParameters.Image = global::InetAnalytics.Resources.ParameterAdd_16;
			this.buttonAddParameters.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAddParameters.Name = "buttonAddParameters";
			this.buttonAddParameters.Size = new System.Drawing.Size(111, 22);
			this.buttonAddParameters.Text = "&Add parameters";
			this.buttonAddParameters.Click += new System.EventHandler(this.OnAddParameter);
			// 
			// buttonRemoveParameter
			// 
			this.buttonRemoveParameter.Enabled = false;
			this.buttonRemoveParameter.Image = global::InetAnalytics.Resources.ParameterRemove_16;
			this.buttonRemoveParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemoveParameter.Name = "buttonRemoveParameter";
			this.buttonRemoveParameter.Size = new System.Drawing.Size(132, 22);
			this.buttonRemoveParameter.Text = "&Remove parameters";
			this.buttonRemoveParameter.Click += new System.EventHandler(this.OnRemoveParameters);
			// 
			// dataParemeters
			// 
			this.dataParemeters.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataParemeters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataParemeters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataParemeters.Location = new System.Drawing.Point(1, 1);
			this.dataParemeters.Name = "dataParemeters";
			this.dataParemeters.Size = new System.Drawing.Size(598, 171);
			this.dataParemeters.TabIndex = 0;
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus,
            this.labelSpring,
            this.labelInfo});
			this.statusStrip.Location = new System.Drawing.Point(1, 172);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(598, 22);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// labelStatus
			// 
			this.labelStatus.Image = global::InetAnalytics.Resources.Information_16;
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(55, 17);
			this.labelStatus.Text = "Ready";
			// 
			// labelSpring
			// 
			this.labelSpring.Name = "labelSpring";
			this.labelSpring.Size = new System.Drawing.Size(497, 17);
			this.labelSpring.Spring = true;
			// 
			// labelInfo
			// 
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(0, 17);
			// 
			// ControlCommand
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlCommand";
			this.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataParemeters)).EndInit();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private System.Windows.Forms.DataGridView dataParemeters;
		private System.Windows.Forms.ToolStrip toolStrip;
		private DotNetApi.Windows.Controls.CodeTextBox textBox;
		private System.Windows.Forms.ToolStripButton buttonSave;
		private System.Windows.Forms.ToolStripButton buttonUndo;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripButton buttonAddParameters;
		private System.Windows.Forms.ToolStripButton buttonRemoveParameter;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel labelStatus;
		private System.Windows.Forms.ToolStripStatusLabel labelSpring;
		private System.Windows.Forms.ToolStripStatusLabel labelInfo;
	}
}
