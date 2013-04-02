namespace YtAnalytics.Controls.Database
{
	partial class ControlCompareFields
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
			this.labelTitle = new System.Windows.Forms.Label();
			this.dataGrid = new System.Windows.Forms.DataGridView();
			this.ColumnLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnRemote = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(154, 20);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Compare table fields";
			// 
			// dataGrid
			// 
			this.dataGrid.AllowUserToAddRows = false;
			this.dataGrid.AllowUserToDeleteRows = false;
			this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLocal,
            this.ColumnRemote});
			this.dataGrid.EnableHeadersVisualStyles = false;
			this.dataGrid.Location = new System.Drawing.Point(20, 74);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGrid.ShowCellErrors = false;
			this.dataGrid.ShowCellToolTips = false;
			this.dataGrid.ShowEditingIcon = false;
			this.dataGrid.ShowRowErrors = false;
			this.dataGrid.Size = new System.Drawing.Size(360, 255);
			this.dataGrid.TabIndex = 10;
			this.dataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnFormatting);
			// 
			// ColumnLocal
			// 
			this.ColumnLocal.HeaderText = "Local data";
			this.ColumnLocal.Name = "ColumnLocal";
			this.ColumnLocal.ReadOnly = true;
			// 
			// ColumnRemote
			// 
			this.ColumnRemote.HeaderText = "Remote data";
			this.ColumnRemote.Name = "ColumnRemote";
			this.ColumnRemote.ReadOnly = true;
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.FieldCompare_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ControlCompareFields
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.dataGrid);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.MinimumSize = new System.Drawing.Size(0, 230);
			this.Name = "ControlCompareFields";
			this.Size = new System.Drawing.Size(400, 349);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.DataGridView dataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLocal;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemote;
	}
}
