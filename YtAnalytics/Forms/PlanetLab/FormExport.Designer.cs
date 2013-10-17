namespace YtAnalytics.Forms.PlanetLab
{
	partial class FormExport
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelText = new System.Windows.Forms.Label();
			this.checkBoxHeaders = new System.Windows.Forms.CheckBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.listHeaders = new System.Windows.Forms.ListView();
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.buttonSelectAll = new System.Windows.Forms.Button();
			this.buttonClearAll = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(297, 327);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Location = new System.Drawing.Point(12, 9);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(269, 13);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "&Select the data fields you want to export to the CSV file:";
			// 
			// checkBoxHeaders
			// 
			this.checkBoxHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxHeaders.AutoSize = true;
			this.checkBoxHeaders.Location = new System.Drawing.Point(12, 300);
			this.checkBoxHeaders.Name = "checkBoxHeaders";
			this.checkBoxHeaders.Size = new System.Drawing.Size(86, 17);
			this.checkBoxHeaders.TabIndex = 2;
			this.checkBoxHeaders.Text = "Use headers";
			this.checkBoxHeaders.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(216, 327);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save as...";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.OnSave);
			// 
			// listHeaders
			// 
			this.listHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listHeaders.CheckBoxes = true;
			this.listHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderType});
			this.listHeaders.GridLines = true;
			this.listHeaders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listHeaders.HideSelection = false;
			this.listHeaders.Location = new System.Drawing.Point(15, 54);
			this.listHeaders.MultiSelect = false;
			this.listHeaders.Name = "listHeaders";
			this.listHeaders.Size = new System.Drawing.Size(357, 240);
			this.listHeaders.TabIndex = 5;
			this.listHeaders.UseCompatibleStateImageBehavior = false;
			this.listHeaders.View = System.Windows.Forms.View.Details;
			this.listHeaders.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnHeaderChecked);
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 180;
			// 
			// columnHeaderType
			// 
			this.columnHeaderType.Text = "Type";
			this.columnHeaderType.Width = 120;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
			this.saveFileDialog.Title = "Select File Name";
			// 
			// buttonSelectAll
			// 
			this.buttonSelectAll.Enabled = false;
			this.buttonSelectAll.Location = new System.Drawing.Point(15, 25);
			this.buttonSelectAll.Name = "buttonSelectAll";
			this.buttonSelectAll.Size = new System.Drawing.Size(75, 23);
			this.buttonSelectAll.TabIndex = 6;
			this.buttonSelectAll.Text = "Select all";
			this.buttonSelectAll.UseVisualStyleBackColor = true;
			this.buttonSelectAll.Click += new System.EventHandler(this.OnSelectAll);
			// 
			// buttonClearAll
			// 
			this.buttonClearAll.Enabled = false;
			this.buttonClearAll.Location = new System.Drawing.Point(96, 25);
			this.buttonClearAll.Name = "buttonClearAll";
			this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
			this.buttonClearAll.TabIndex = 7;
			this.buttonClearAll.Text = "Clear all";
			this.buttonClearAll.UseVisualStyleBackColor = true;
			this.buttonClearAll.Click += new System.EventHandler(this.OnClearAll);
			// 
			// FormExport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(384, 362);
			this.Controls.Add(this.buttonClearAll);
			this.Controls.Add(this.buttonSelectAll);
			this.Controls.Add(this.listHeaders);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.checkBoxHeaders);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.buttonCancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormExport";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Export to CSV File";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.CheckBox checkBoxHeaders;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.ListView listHeaders;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderType;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Button buttonSelectAll;
		private System.Windows.Forms.Button buttonClearAll;
	}
}