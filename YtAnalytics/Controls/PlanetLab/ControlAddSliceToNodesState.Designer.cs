namespace YtAnalytics.Controls.PlanetLab
{
	partial class ControlAddSliceToNodesState
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlAddSliceToNodesState));
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxFilter = new System.Windows.Forms.TextBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelSearch = new System.Windows.Forms.Label();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.labelStatus = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSelect = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.listView = new System.Windows.Forms.ListView();
			this.columnNodeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeHostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeBootState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeDateCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeLastUpdated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnNodeType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.checkBoxFilter = new System.Windows.Forms.CheckBox();
			this.stateFilter = new DotNetApi.Windows.Controls.ToolStripDropDownCheckedList();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(215, 20);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Add PlanetLab slice to nodes";
			// 
			// textBoxFilter
			// 
			this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFilter.Location = new System.Drawing.Point(110, 73);
			this.textBoxFilter.Name = "textBoxFilter";
			this.textBoxFilter.Size = new System.Drawing.Size(606, 20);
			this.textBoxFilter.TabIndex = 2;
			this.textBoxFilter.TextChanged += new System.EventHandler(this.OnHostnameFilterChanged);
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.NodeAdd_48;
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
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "NodeUnknown");
			this.imageList.Images.SetKeyName(1, "NodeBoot");
			this.imageList.Images.SetKeyName(2, "NodeSafeBoot");
			this.imageList.Images.SetKeyName(3, "NodeDisabled");
			this.imageList.Images.SetKeyName(4, "NodeReinstall");
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStatus.AutoEllipsis = true;
			this.labelStatus.Location = new System.Drawing.Point(165, 574);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(470, 23);
			this.labelStatus.TabIndex = 7;
			this.labelStatus.Text = "Ready.";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCancel.Location = new System.Drawing.Point(84, 574);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "C&ancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// buttonSelect
			// 
			this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelect.Location = new System.Drawing.Point(641, 574);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(75, 23);
			this.buttonSelect.TabIndex = 8;
			this.buttonSelect.Text = "&Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Click += new System.EventHandler(this.OnSelect);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(722, 574);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 9;
			this.buttonClose.Text = "&Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.OnClose);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRefresh.Image = global::YtAnalytics.Resources.Refresh_16;
			this.buttonRefresh.Location = new System.Drawing.Point(3, 574);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
			this.buttonRefresh.TabIndex = 5;
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefreshStarted);
			// 
			// listView
			// 
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView.CheckBoxes = true;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNodeId,
            this.columnNodeHostname,
            this.columnNodeBootState,
            this.columnNodeModel,
            this.columnNodeVersion,
            this.columnNodeDateCreated,
            this.columnNodeLastUpdated,
            this.columnNodeType});
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(3, 99);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(794, 469);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 4;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemActivate += new System.EventHandler(this.OnProperties);
			this.listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnNodeChecked);
			// 
			// columnNodeId
			// 
			this.columnNodeId.Text = "ID";
			this.columnNodeId.Width = 80;
			// 
			// columnNodeHostname
			// 
			this.columnNodeHostname.Text = "Hostname";
			this.columnNodeHostname.Width = 120;
			// 
			// columnNodeBootState
			// 
			this.columnNodeBootState.Text = "Boot state";
			// 
			// columnNodeModel
			// 
			this.columnNodeModel.Text = "Model";
			this.columnNodeModel.Width = 120;
			// 
			// columnNodeVersion
			// 
			this.columnNodeVersion.Text = "Version";
			// 
			// columnNodeDateCreated
			// 
			this.columnNodeDateCreated.Text = "Date created";
			this.columnNodeDateCreated.Width = 120;
			// 
			// columnNodeLastUpdated
			// 
			this.columnNodeLastUpdated.Text = "Last updated";
			this.columnNodeLastUpdated.Width = 120;
			// 
			// columnNodeType
			// 
			this.columnNodeType.Text = "Type";
			this.columnNodeType.Width = 120;
			// 
			// checkBoxFilter
			// 
			this.checkBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxFilter.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBoxFilter.Image = global::YtAnalytics.Resources.Filter_16;
			this.checkBoxFilter.Location = new System.Drawing.Point(722, 71);
			this.checkBoxFilter.Name = "checkBoxFilter";
			this.checkBoxFilter.Size = new System.Drawing.Size(75, 23);
			this.checkBoxFilter.TabIndex = 3;
			this.checkBoxFilter.Text = "&Filter by";
			this.checkBoxFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.checkBoxFilter.UseVisualStyleBackColor = true;
			this.checkBoxFilter.CheckedChanged += new System.EventHandler(this.OnFilterState);
			// 
			// stateFilter
			// 
			this.stateFilter.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.stateFilter.ListMinimumSize = new System.Drawing.Size(200, 200);
			this.stateFilter.ListSize = new System.Drawing.Size(200, 200);
			this.stateFilter.Name = "checkedListFilter";
			this.stateFilter.Padding = new System.Windows.Forms.Padding(4, 2, 4, 0);
			this.stateFilter.Size = new System.Drawing.Size(208, 205);
			this.stateFilter.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnStateFilterCheck);
			this.stateFilter.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.OnStateFilterClosed);
			// 
			// ControlAddSliceToNodesState
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.checkBoxFilter);
			this.Controls.Add(this.listView);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSelect);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.labelSearch);
			this.Controls.Add(this.textBoxFilter);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.MinimumSize = new System.Drawing.Size(0, 230);
			this.Name = "ControlAddSliceToNodesState";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.pictureBox, 0);
			this.Controls.SetChildIndex(this.labelTitle, 0);
			this.Controls.SetChildIndex(this.textBoxFilter, 0);
			this.Controls.SetChildIndex(this.labelSearch, 0);
			this.Controls.SetChildIndex(this.buttonRefresh, 0);
			this.Controls.SetChildIndex(this.buttonClose, 0);
			this.Controls.SetChildIndex(this.buttonSelect, 0);
			this.Controls.SetChildIndex(this.buttonCancel, 0);
			this.Controls.SetChildIndex(this.labelStatus, 0);
			this.Controls.SetChildIndex(this.listView, 0);
			this.Controls.SetChildIndex(this.checkBoxFilter, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TextBox textBoxFilter;
		private System.Windows.Forms.Label labelSearch;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSelect;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader columnNodeId;
		private System.Windows.Forms.ColumnHeader columnNodeHostname;
		private System.Windows.Forms.ColumnHeader columnNodeBootState;
		private System.Windows.Forms.ColumnHeader columnNodeModel;
		private System.Windows.Forms.ColumnHeader columnNodeVersion;
		private System.Windows.Forms.ColumnHeader columnNodeDateCreated;
		private System.Windows.Forms.ColumnHeader columnNodeLastUpdated;
		private System.Windows.Forms.ColumnHeader columnNodeType;
		private System.Windows.Forms.CheckBox checkBoxFilter;
		private DotNetApi.Windows.Controls.ToolStripDropDownCheckedList stateFilter;
	}
}
