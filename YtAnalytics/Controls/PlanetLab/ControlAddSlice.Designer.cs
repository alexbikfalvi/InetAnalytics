namespace YtAnalytics.Controls.PlanetLab
{
	partial class ControlAddSlice
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
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelSearch = new System.Windows.Forms.Label();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderExpires = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderNodes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderMaximum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labelStatus = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSelect = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonRefresh = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(149, 20);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Add PlanetLab slice";
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Location = new System.Drawing.Point(110, 73);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(487, 20);
			this.textBoxName.TabIndex = 4;
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.ObjectSmallAdd_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// labelSearch
			// 
			this.labelSearch.AutoSize = true;
			this.labelSearch.Location = new System.Drawing.Point(17, 76);
			this.labelSearch.Name = "labelSearch";
			this.labelSearch.Size = new System.Drawing.Size(87, 13);
			this.labelSearch.TabIndex = 1;
			this.labelSearch.Text = "&Search by name:";
			// 
			// listView
			// 
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderName,
            this.columnHeaderCreated,
            this.columnHeaderExpires,
            this.columnHeaderNodes,
            this.columnHeaderMaximum});
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(3, 99);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(594, 269);
			this.listView.TabIndex = 11;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 120;
			// 
			// columnHeaderCreated
			// 
			this.columnHeaderCreated.Text = "Created";
			this.columnHeaderCreated.Width = 120;
			// 
			// columnHeaderExpires
			// 
			this.columnHeaderExpires.Text = "Expires";
			this.columnHeaderExpires.Width = 120;
			// 
			// columnHeaderNodes
			// 
			this.columnHeaderNodes.Text = "Nodes";
			this.columnHeaderNodes.Width = 80;
			// 
			// columnHeaderMaximum
			// 
			this.columnHeaderMaximum.Text = "Maximum";
			this.columnHeaderMaximum.Width = 80;
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStatus.AutoEllipsis = true;
			this.labelStatus.Location = new System.Drawing.Point(165, 374);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(270, 23);
			this.labelStatus.TabIndex = 16;
			this.labelStatus.Text = "Ready.";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCancel.Location = new System.Drawing.Point(84, 374);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 15;
			this.buttonCancel.Text = "C&ancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonSelect
			// 
			this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelect.Location = new System.Drawing.Point(441, 374);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(75, 23);
			this.buttonSelect.TabIndex = 14;
			this.buttonSelect.Text = "&Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(522, 374);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 13;
			this.buttonClose.Text = "&Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRefresh.Image = global::YtAnalytics.Resources.Refresh_16;
			this.buttonRefresh.Location = new System.Drawing.Point(3, 374);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
			this.buttonRefresh.TabIndex = 12;
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			// 
			// ControlAddSlice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSelect);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.listView);
			this.Controls.Add(this.labelSearch);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.MinimumSize = new System.Drawing.Size(0, 230);
			this.Name = "ControlAddSlice";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.pictureBox, 0);
			this.Controls.SetChildIndex(this.labelTitle, 0);
			this.Controls.SetChildIndex(this.textBoxName, 0);
			this.Controls.SetChildIndex(this.labelSearch, 0);
			this.Controls.SetChildIndex(this.listView, 0);
			this.Controls.SetChildIndex(this.buttonRefresh, 0);
			this.Controls.SetChildIndex(this.buttonClose, 0);
			this.Controls.SetChildIndex(this.buttonSelect, 0);
			this.Controls.SetChildIndex(this.buttonCancel, 0);
			this.Controls.SetChildIndex(this.labelStatus, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelSearch;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderCreated;
		private System.Windows.Forms.ColumnHeader columnHeaderExpires;
		private System.Windows.Forms.ColumnHeader columnHeaderNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderMaximum;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSelect;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonRefresh;
	}
}
