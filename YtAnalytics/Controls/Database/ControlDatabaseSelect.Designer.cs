namespace YtAnalytics.Controls.Database
{
	partial class ControlDatabaseSelect
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
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonSelect = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.dataGrid = new System.Windows.Forms.DataGridView();
			this.labelStatus = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(172, 20);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Select database object";
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(522, 374);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 6;
			this.buttonClose.Text = "&Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.OnClose);
			// 
			// buttonSelect
			// 
			this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelect.Location = new System.Drawing.Point(441, 374);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(75, 23);
			this.buttonSelect.TabIndex = 5;
			this.buttonSelect.Text = "&Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Click += new System.EventHandler(this.OnSelect);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCancel.Location = new System.Drawing.Point(84, 374);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "C&ancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRefresh.Image = global::YtAnalytics.Resources.Refresh_16;
			this.buttonRefresh.Location = new System.Drawing.Point(3, 374);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
			this.buttonRefresh.TabIndex = 2;
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefreshStarted);
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.DatabaseRead_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// dataGrid
			// 
			this.dataGrid.AllowUserToAddRows = false;
			this.dataGrid.AllowUserToDeleteRows = false;
			this.dataGrid.AllowUserToOrderColumns = true;
			this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid.Location = new System.Drawing.Point(3, 74);
			this.dataGrid.MultiSelect = false;
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGrid.Size = new System.Drawing.Size(594, 294);
			this.dataGrid.TabIndex = 1;
			this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellDoubleClick);
			this.dataGrid.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStatus.AutoEllipsis = true;
			this.labelStatus.Location = new System.Drawing.Point(165, 374);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(270, 23);
			this.labelStatus.TabIndex = 4;
			this.labelStatus.Text = "Ready.";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ControlDatabaseSelect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.dataGrid);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSelect);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlDatabaseSelect";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.pictureBox, 0);
			this.Controls.SetChildIndex(this.labelTitle, 0);
			this.Controls.SetChildIndex(this.buttonRefresh, 0);
			this.Controls.SetChildIndex(this.buttonClose, 0);
			this.Controls.SetChildIndex(this.buttonSelect, 0);
			this.Controls.SetChildIndex(this.buttonCancel, 0);
			this.Controls.SetChildIndex(this.dataGrid, 0);
			this.Controls.SetChildIndex(this.labelStatus, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSelect;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.DataGridView dataGrid;
		private System.Windows.Forms.Label labelStatus;
	}
}
