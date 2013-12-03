namespace InetAnalytics.Forms.PlanetLab
{
	partial class FormImportParameters
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
			this.buttonImport = new System.Windows.Forms.Button();
			this.listParameters = new System.Windows.Forms.ListView();
			this.columnHeaderParameter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.buttonClearAll = new System.Windows.Forms.Button();
			this.buttonSelectAll = new System.Windows.Forms.Button();
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
			this.labelText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelText.Location = new System.Drawing.Point(17, 71);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(355, 80);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "The selected file contains 0 lines of data. &Select the command parameters you wa" +
    "nt to set with this data.\r\n\r\nThe command will add the necessary number of parame" +
    "ter sets.";
			// 
			// buttonImport
			// 
			this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonImport.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonImport.Enabled = false;
			this.buttonImport.Location = new System.Drawing.Point(216, 427);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(75, 23);
			this.buttonImport.TabIndex = 3;
			this.buttonImport.Text = "Import";
			this.buttonImport.UseVisualStyleBackColor = true;
			this.buttonImport.Click += new System.EventHandler(this.OnImport);
			// 
			// listParameters
			// 
			this.listParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listParameters.CheckBoxes = true;
			this.listParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderParameter});
			this.listParameters.GridLines = true;
			this.listParameters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listParameters.HideSelection = false;
			this.listParameters.Location = new System.Drawing.Point(15, 183);
			this.listParameters.MultiSelect = false;
			this.listParameters.Name = "listParameters";
			this.listParameters.Size = new System.Drawing.Size(357, 211);
			this.listParameters.TabIndex = 5;
			this.listParameters.UseCompatibleStateImageBehavior = false;
			this.listParameters.View = System.Windows.Forms.View.Details;
			this.listParameters.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnHeaderChecked);
			// 
			// columnHeaderParameter
			// 
			this.columnHeaderParameter.Text = "Parameter";
			this.columnHeaderParameter.Width = 180;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
			this.saveFileDialog.Title = "Select File Name";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(214, 20);
			this.labelTitle.TabIndex = 8;
			this.labelTitle.Text = "Import command parameters";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.TableImport_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 9;
			this.pictureBox.TabStop = false;
			// 
			// buttonClearAll
			// 
			this.buttonClearAll.Enabled = false;
			this.buttonClearAll.Location = new System.Drawing.Point(101, 154);
			this.buttonClearAll.Name = "buttonClearAll";
			this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
			this.buttonClearAll.TabIndex = 7;
			this.buttonClearAll.Text = "Clear all";
			this.buttonClearAll.UseVisualStyleBackColor = true;
			this.buttonClearAll.Click += new System.EventHandler(this.OnClearAll);
			// 
			// buttonSelectAll
			// 
			this.buttonSelectAll.Enabled = false;
			this.buttonSelectAll.Location = new System.Drawing.Point(20, 154);
			this.buttonSelectAll.Name = "buttonSelectAll";
			this.buttonSelectAll.Size = new System.Drawing.Size(75, 23);
			this.buttonSelectAll.TabIndex = 6;
			this.buttonSelectAll.Text = "Select all";
			this.buttonSelectAll.UseVisualStyleBackColor = true;
			this.buttonSelectAll.Click += new System.EventHandler(this.OnSelectAll);
			// 
			// FormImportParameters
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(384, 462);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.buttonClearAll);
			this.Controls.Add(this.buttonSelectAll);
			this.Controls.Add(this.listParameters);
			this.Controls.Add(this.buttonImport);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.buttonCancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormImportParameters";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Import Command Parameters";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.Button buttonImport;
		private System.Windows.Forms.ListView listParameters;
		private System.Windows.Forms.ColumnHeader columnHeaderParameter;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button buttonClearAll;
		private System.Windows.Forms.Button buttonSelectAll;
	}
}