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
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(297, 427);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Location = new System.Drawing.Point(17, 71);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(269, 13);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "&Select the data fields you want to export to the CSV file:";
			// 
			// checkBoxHeaders
			// 
			this.checkBoxHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxHeaders.AutoSize = true;
			this.checkBoxHeaders.Location = new System.Drawing.Point(12, 400);
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
			this.buttonSave.Location = new System.Drawing.Point(216, 427);
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
			this.listHeaders.Location = new System.Drawing.Point(15, 116);
			this.listHeaders.MultiSelect = false;
			this.listHeaders.Name = "listHeaders";
			this.listHeaders.Size = new System.Drawing.Size(357, 278);
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
			this.buttonSelectAll.Location = new System.Drawing.Point(15, 87);
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
			this.buttonClearAll.Location = new System.Drawing.Point(96, 87);
			this.buttonClearAll.Name = "buttonClearAll";
			this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
			this.buttonClearAll.TabIndex = 7;
			this.buttonClearAll.Text = "Clear all";
			this.buttonClearAll.UseVisualStyleBackColor = true;
			this.buttonClearAll.Click += new System.EventHandler(this.OnClearAll);
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(167, 20);
			this.labelTitle.TabIndex = 8;
			this.labelTitle.Text = "Export PlanetLab data";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.Export_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 9;
			this.pictureBox.TabStop = false;
			// 
			// FormExport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(384, 462);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
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
			this.Text = "Export PlanetLab Data";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
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
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
	}
}