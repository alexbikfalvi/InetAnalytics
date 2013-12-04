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
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonImportParameters = new System.Windows.Forms.ToolStripButton();
			this.buttonClearParameters = new System.Windows.Forms.ToolStripButton();
			this.dataParameters = new System.Windows.Forms.DataGridView();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataParameters)).BeginInit();
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
			this.splitContainer.Panel2.Controls.Add(this.dataParameters);
			this.splitContainer.Panel2.Controls.Add(this.statusStrip);
			this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(1);
			this.splitContainer.Size = new System.Drawing.Size(700, 500);
			this.splitContainer.SplitterDistance = 250;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 0;
			this.splitContainer.UseTheme = false;
			// 
			// textBox
			// 
			this.textBox.BackColor = System.Drawing.Color.White;
			this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox.ColorCollection = null;
			this.textBox.DefaultBackgroundColor = System.Drawing.Color.White;
			this.textBox.DefaultForegroundColor = System.Drawing.Color.Black;
			this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox.Font = new System.Drawing.Font("Consolas", 10F);
			this.textBox.ForeColor = System.Drawing.Color.Blue;
			this.textBox.Location = new System.Drawing.Point(1, 26);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(698, 223);
			this.textBox.TabIndex = 0;
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
            this.buttonRemoveParameter,
            this.separator2,
            this.buttonImportParameters,
            this.buttonClearParameters});
			this.toolStrip.Location = new System.Drawing.Point(1, 1);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(698, 25);
			this.toolStrip.TabIndex = 1;
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
			this.buttonAddParameters.Size = new System.Drawing.Size(124, 22);
			this.buttonAddParameters.Text = "&Add parameter set";
			this.buttonAddParameters.Click += new System.EventHandler(this.OnAddParameter);
			// 
			// buttonRemoveParameter
			// 
			this.buttonRemoveParameter.Enabled = false;
			this.buttonRemoveParameter.Image = global::InetAnalytics.Resources.ParameterRemove_16;
			this.buttonRemoveParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemoveParameter.Name = "buttonRemoveParameter";
			this.buttonRemoveParameter.Size = new System.Drawing.Size(145, 22);
			this.buttonRemoveParameter.Text = "&Remove parameter set";
			this.buttonRemoveParameter.Click += new System.EventHandler(this.OnRemoveParameters);
			// 
			// separator2
			// 
			this.separator2.Name = "separator2";
			this.separator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonImportParameters
			// 
			this.buttonImportParameters.Enabled = false;
			this.buttonImportParameters.Image = global::InetAnalytics.Resources.TableImport_16;
			this.buttonImportParameters.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonImportParameters.Name = "buttonImportParameters";
			this.buttonImportParameters.Size = new System.Drawing.Size(125, 22);
			this.buttonImportParameters.Text = "&Import parameters";
			this.buttonImportParameters.Click += new System.EventHandler(this.OnImportParameters);
			// 
			// buttonClearParameters
			// 
			this.buttonClearParameters.Enabled = false;
			this.buttonClearParameters.Image = global::InetAnalytics.Resources.TableRemove_16;
			this.buttonClearParameters.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonClearParameters.Name = "buttonClearParameters";
			this.buttonClearParameters.Size = new System.Drawing.Size(116, 22);
			this.buttonClearParameters.Text = "&Clear parameters";
			this.buttonClearParameters.Click += new System.EventHandler(this.OnClearParameters);
			// 
			// dataParameters
			// 
			this.dataParameters.AllowUserToAddRows = false;
			this.dataParameters.AllowUserToDeleteRows = false;
			this.dataParameters.AllowUserToResizeRows = false;
			this.dataParameters.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataParameters.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dataParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataParameters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataParameters.Location = new System.Drawing.Point(1, 1);
			this.dataParameters.MultiSelect = false;
			this.dataParameters.Name = "dataParameters";
			this.dataParameters.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dataParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataParameters.Size = new System.Drawing.Size(698, 221);
			this.dataParameters.TabIndex = 0;
			this.dataParameters.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.OnParameterChanged);
			this.dataParameters.SelectionChanged += new System.EventHandler(this.OnParameterChanged);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus,
            this.labelInfo});
			this.statusStrip.Location = new System.Drawing.Point(1, 222);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(698, 22);
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
			// labelInfo
			// 
			this.labelInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(597, 17);
			this.labelInfo.Spring = true;
			this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Text files (*.txt)|*.txt";
			this.openFileDialog.Title = "Import Command Parameters";
			// 
			// ControlCommand
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlCommand";
			this.Size = new System.Drawing.Size(700, 500);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataParameters)).EndInit();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private System.Windows.Forms.DataGridView dataParameters;
		private System.Windows.Forms.ToolStrip toolStrip;
		private DotNetApi.Windows.Controls.CodeTextBox textBox;
		private System.Windows.Forms.ToolStripButton buttonSave;
		private System.Windows.Forms.ToolStripButton buttonUndo;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripButton buttonAddParameters;
		private System.Windows.Forms.ToolStripButton buttonRemoveParameter;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel labelStatus;
		private System.Windows.Forms.ToolStripStatusLabel labelInfo;
		private System.Windows.Forms.ToolStripButton buttonImportParameters;
		private System.Windows.Forms.ToolStripButton buttonClearParameters;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}
