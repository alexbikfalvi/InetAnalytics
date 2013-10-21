namespace YtAnalytics.Forms.PlanetLab
{
	partial class FormExportMap
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
			this.buttonSave = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(297, 277);
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
			this.labelText.Size = new System.Drawing.Size(212, 13);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "&Select the properties of the exported image:";
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSave.Location = new System.Drawing.Point(216, 277);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save as...";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.OnSave);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "BMP image (*.bmp)|*.bmp|PNG image (*.png)|*.png|JPEG image (*.jpg)|*.jpg|TIFF ima" +
    "ge (*.tiff)|*.tiff|Enhanced meta-file image (*.emf)|*.emf|Windows meta-file imag" +
    "e (*.wmf)|*.wmf";
			this.saveFileDialog.Title = "Select File Name";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(90, 20);
			this.labelTitle.TabIndex = 8;
			this.labelTitle.Text = "Export map";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.MapExport_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 9;
			this.pictureBox.TabStop = false;
			// 
			// propertyGrid
			// 
			this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid.Location = new System.Drawing.Point(20, 87);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(352, 184);
			this.propertyGrid.TabIndex = 10;
			// 
			// FormExportMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(384, 312);
			this.Controls.Add(this.propertyGrid);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.buttonCancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormExportMap";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Export Map";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.PropertyGrid propertyGrid;
	}
}