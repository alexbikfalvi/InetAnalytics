namespace InetAnalytics.Forms.Net
{
	partial class FormIpSelectAddress
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
			this.buttonSelect = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.listViewAddress = new System.Windows.Forms.ListView();
			this.columnHeaderAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderFamily = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
			// buttonSelect
			// 
			this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSelect.Location = new System.Drawing.Point(216, 277);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(75, 23);
			this.buttonSelect.TabIndex = 3;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
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
			this.labelTitle.Size = new System.Drawing.Size(237, 20);
			this.labelTitle.TabIndex = 8;
			this.labelTitle.Text = "Select Internet Protocol address";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.Select_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 9;
			this.pictureBox.TabStop = false;
			// 
			// listViewAddress
			// 
			this.listViewAddress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress,
            this.columnHeaderFamily});
			this.listViewAddress.FullRowSelect = true;
			this.listViewAddress.GridLines = true;
			this.listViewAddress.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewAddress.HideSelection = false;
			this.listViewAddress.Location = new System.Drawing.Point(12, 74);
			this.listViewAddress.MultiSelect = false;
			this.listViewAddress.Name = "listViewAddress";
			this.listViewAddress.Size = new System.Drawing.Size(360, 197);
			this.listViewAddress.TabIndex = 10;
			this.listViewAddress.UseCompatibleStateImageBehavior = false;
			this.listViewAddress.View = System.Windows.Forms.View.Details;
			this.listViewAddress.ItemActivate += new System.EventHandler(this.OnSelect);
			this.listViewAddress.SelectedIndexChanged += new System.EventHandler(this.OnSelectionChanged);
			// 
			// columnHeaderAddress
			// 
			this.columnHeaderAddress.Text = "Address";
			this.columnHeaderAddress.Width = 200;
			// 
			// columnHeaderFamily
			// 
			this.columnHeaderFamily.Text = "Family";
			this.columnHeaderFamily.Width = 100;
			// 
			// FormIpSelectAddress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(384, 312);
			this.Controls.Add(this.listViewAddress);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.buttonSelect);
			this.Controls.Add(this.buttonCancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 350);
			this.Name = "FormIpSelectAddress";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Select Internet Protocol Address";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSelect;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.ListView listViewAddress;
		private System.Windows.Forms.ColumnHeader columnHeaderAddress;
		private System.Windows.Forms.ColumnHeader columnHeaderFamily;
	}
}