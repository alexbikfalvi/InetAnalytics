namespace InetTools.Controls
{
	partial class ControlCdnFinderSite
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCdnFinderSite));
			this.panelDomain = new System.Windows.Forms.Panel();
			this.labelUrl = new System.Windows.Forms.Label();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.labelBaseCdn = new System.Windows.Forms.Label();
			this.textBoxBaseCdn = new System.Windows.Forms.TextBox();
			this.labelAssetCdn = new System.Windows.Forms.Label();
			this.textBoxAssetCdn = new System.Windows.Forms.TextBox();
			this.labelSite = new System.Windows.Forms.Label();
			this.textBoxSite = new System.Windows.Forms.TextBox();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.listViewResources = new System.Windows.Forms.ListView();
			this.columnHeaderHostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCdn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderIsBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.panelDomain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// panelDomain
			// 
			this.panelDomain.AutoScroll = true;
			this.panelDomain.Controls.Add(this.labelUrl);
			this.panelDomain.Controls.Add(this.textBoxUrl);
			this.panelDomain.Controls.Add(this.labelBaseCdn);
			this.panelDomain.Controls.Add(this.textBoxBaseCdn);
			this.panelDomain.Controls.Add(this.labelAssetCdn);
			this.panelDomain.Controls.Add(this.textBoxAssetCdn);
			this.panelDomain.Controls.Add(this.labelSite);
			this.panelDomain.Controls.Add(this.textBoxSite);
			this.panelDomain.Controls.Add(this.labelTitle);
			this.panelDomain.Controls.Add(this.pictureBox);
			this.panelDomain.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelDomain.Location = new System.Drawing.Point(0, 0);
			this.panelDomain.Name = "panelDomain";
			this.panelDomain.Size = new System.Drawing.Size(400, 170);
			this.panelDomain.TabIndex = 0;
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(7, 93);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(32, 13);
			this.labelUrl.TabIndex = 3;
			this.labelUrl.Text = "&URL:";
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Location = new System.Drawing.Point(112, 90);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.ReadOnly = true;
			this.textBoxUrl.Size = new System.Drawing.Size(240, 20);
			this.textBoxUrl.TabIndex = 4;
			// 
			// labelBaseCdn
			// 
			this.labelBaseCdn.AutoSize = true;
			this.labelBaseCdn.Location = new System.Drawing.Point(7, 145);
			this.labelBaseCdn.Name = "labelBaseCdn";
			this.labelBaseCdn.Size = new System.Drawing.Size(60, 13);
			this.labelBaseCdn.TabIndex = 7;
			this.labelBaseCdn.Text = "&Base CDN:";
			// 
			// textBoxBaseCdn
			// 
			this.textBoxBaseCdn.Location = new System.Drawing.Point(112, 142);
			this.textBoxBaseCdn.Name = "textBoxBaseCdn";
			this.textBoxBaseCdn.ReadOnly = true;
			this.textBoxBaseCdn.Size = new System.Drawing.Size(240, 20);
			this.textBoxBaseCdn.TabIndex = 8;
			// 
			// labelAssetCdn
			// 
			this.labelAssetCdn.AutoSize = true;
			this.labelAssetCdn.Location = new System.Drawing.Point(7, 119);
			this.labelAssetCdn.Name = "labelAssetCdn";
			this.labelAssetCdn.Size = new System.Drawing.Size(62, 13);
			this.labelAssetCdn.TabIndex = 5;
			this.labelAssetCdn.Text = "&Asset CDN:";
			// 
			// textBoxAssetCdn
			// 
			this.textBoxAssetCdn.Location = new System.Drawing.Point(112, 116);
			this.textBoxAssetCdn.Name = "textBoxAssetCdn";
			this.textBoxAssetCdn.ReadOnly = true;
			this.textBoxAssetCdn.Size = new System.Drawing.Size(240, 20);
			this.textBoxAssetCdn.TabIndex = 6;
			// 
			// labelSite
			// 
			this.labelSite.AutoSize = true;
			this.labelSite.Location = new System.Drawing.Point(7, 67);
			this.labelSite.Name = "labelSite";
			this.labelSite.Size = new System.Drawing.Size(28, 13);
			this.labelSite.TabIndex = 1;
			this.labelSite.Text = "&Site:";
			// 
			// textBoxSite
			// 
			this.textBoxSite.Location = new System.Drawing.Point(112, 64);
			this.textBoxSite.Name = "textBoxSite";
			this.textBoxSite.ReadOnly = true;
			this.textBoxSite.Size = new System.Drawing.Size(240, 20);
			this.textBoxSite.TabIndex = 2;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(64, 28);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(83, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No site selected";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetTools.Properties.Resources.GlobeQuestion_48;
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// listViewResources
			// 
			this.listViewResources.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewResources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderHostname,
            this.columnHeaderCount,
            this.columnHeaderSize,
            this.columnHeaderCdn,
            this.columnHeaderIsBase});
			this.listViewResources.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewResources.FullRowSelect = true;
			this.listViewResources.GridLines = true;
			this.listViewResources.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewResources.HideSelection = false;
			this.listViewResources.Location = new System.Drawing.Point(0, 170);
			this.listViewResources.MultiSelect = false;
			this.listViewResources.Name = "listViewResources";
			this.listViewResources.Size = new System.Drawing.Size(400, 230);
			this.listViewResources.SmallImageList = this.imageList;
			this.listViewResources.TabIndex = 1;
			this.listViewResources.UseCompatibleStateImageBehavior = false;
			this.listViewResources.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderHostname
			// 
			this.columnHeaderHostname.Text = "Hostname";
			this.columnHeaderHostname.Width = 120;
			// 
			// columnHeaderCount
			// 
			this.columnHeaderCount.Text = "Count";
			// 
			// columnHeaderSize
			// 
			this.columnHeaderSize.Text = "Size";
			// 
			// columnHeaderCdn
			// 
			this.columnHeaderCdn.Text = "CDN";
			this.columnHeaderCdn.Width = 120;
			// 
			// columnHeaderIsBase
			// 
			this.columnHeaderIsBase.Text = "Is base";
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Link");
			// 
			// ControlCdnFinderSite
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.listViewResources);
			this.Controls.Add(this.panelDomain);
			this.Name = "ControlCdnFinderSite";
			this.Size = new System.Drawing.Size(400, 400);
			this.panelDomain.ResumeLayout(false);
			this.panelDomain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelDomain;
		private System.Windows.Forms.Label labelBaseCdn;
		private System.Windows.Forms.TextBox textBoxBaseCdn;
		private System.Windows.Forms.Label labelAssetCdn;
		private System.Windows.Forms.TextBox textBoxAssetCdn;
		private System.Windows.Forms.Label labelSite;
		private System.Windows.Forms.TextBox textBoxSite;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.ListView listViewResources;
		private System.Windows.Forms.ColumnHeader columnHeaderHostname;
		private System.Windows.Forms.ColumnHeader columnHeaderCount;
		private System.Windows.Forms.ColumnHeader columnHeaderSize;
		private System.Windows.Forms.ColumnHeader columnHeaderCdn;
		private System.Windows.Forms.ColumnHeader columnHeaderIsBase;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.TextBox textBoxUrl;
		private System.Windows.Forms.ImageList imageList;

	}
}
