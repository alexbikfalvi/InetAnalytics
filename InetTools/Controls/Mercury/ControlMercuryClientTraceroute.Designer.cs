namespace InetTools.Controls.Mercury
{
	partial class ControlMercuryClientTraceroute
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlMercuryClientTraceroute));
			this.panelDomain = new System.Windows.Forms.Panel();
			this.labelDestination = new System.Windows.Forms.Label();
			this.textBoxDestination = new System.Windows.Forms.TextBox();
			this.labelPacketSize = new System.Windows.Forms.Label();
			this.textBoxPacketSize = new System.Windows.Forms.TextBox();
			this.labelMaxHops = new System.Windows.Forms.Label();
			this.textBoxMaxHops = new System.Windows.Forms.TextBox();
			this.labelSource = new System.Windows.Forms.Label();
			this.textBoxSource = new System.Windows.Forms.TextBox();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.listViewHops = new System.Windows.Forms.ListView();
			this.columnHeaderHop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderHostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderAs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderRtt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.panelDomain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// panelDomain
			// 
			this.panelDomain.AutoScroll = true;
			this.panelDomain.Controls.Add(this.labelDestination);
			this.panelDomain.Controls.Add(this.textBoxDestination);
			this.panelDomain.Controls.Add(this.labelPacketSize);
			this.panelDomain.Controls.Add(this.textBoxPacketSize);
			this.panelDomain.Controls.Add(this.labelMaxHops);
			this.panelDomain.Controls.Add(this.textBoxMaxHops);
			this.panelDomain.Controls.Add(this.labelSource);
			this.panelDomain.Controls.Add(this.textBoxSource);
			this.panelDomain.Controls.Add(this.labelTitle);
			this.panelDomain.Controls.Add(this.pictureBox);
			this.panelDomain.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelDomain.Location = new System.Drawing.Point(0, 0);
			this.panelDomain.Name = "panelDomain";
			this.panelDomain.Size = new System.Drawing.Size(400, 170);
			this.panelDomain.TabIndex = 0;
			// 
			// labelDestination
			// 
			this.labelDestination.AutoSize = true;
			this.labelDestination.Location = new System.Drawing.Point(7, 93);
			this.labelDestination.Name = "labelDestination";
			this.labelDestination.Size = new System.Drawing.Size(63, 13);
			this.labelDestination.TabIndex = 3;
			this.labelDestination.Text = "&Destination:";
			// 
			// textBoxDestination
			// 
			this.textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDestination.Location = new System.Drawing.Point(112, 90);
			this.textBoxDestination.Name = "textBoxDestination";
			this.textBoxDestination.ReadOnly = true;
			this.textBoxDestination.Size = new System.Drawing.Size(280, 20);
			this.textBoxDestination.TabIndex = 4;
			// 
			// labelPacketSize
			// 
			this.labelPacketSize.AutoSize = true;
			this.labelPacketSize.Location = new System.Drawing.Point(7, 145);
			this.labelPacketSize.Name = "labelPacketSize";
			this.labelPacketSize.Size = new System.Drawing.Size(65, 13);
			this.labelPacketSize.TabIndex = 7;
			this.labelPacketSize.Text = "&Packet size:";
			// 
			// textBoxPacketSize
			// 
			this.textBoxPacketSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPacketSize.Location = new System.Drawing.Point(112, 142);
			this.textBoxPacketSize.Name = "textBoxPacketSize";
			this.textBoxPacketSize.ReadOnly = true;
			this.textBoxPacketSize.Size = new System.Drawing.Size(280, 20);
			this.textBoxPacketSize.TabIndex = 8;
			// 
			// labelMaxHops
			// 
			this.labelMaxHops.AutoSize = true;
			this.labelMaxHops.Location = new System.Drawing.Point(7, 119);
			this.labelMaxHops.Name = "labelMaxHops";
			this.labelMaxHops.Size = new System.Drawing.Size(80, 13);
			this.labelMaxHops.TabIndex = 5;
			this.labelMaxHops.Text = "Maximum &hops:";
			// 
			// textBoxMaxHops
			// 
			this.textBoxMaxHops.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMaxHops.Location = new System.Drawing.Point(112, 116);
			this.textBoxMaxHops.Name = "textBoxMaxHops";
			this.textBoxMaxHops.ReadOnly = true;
			this.textBoxMaxHops.Size = new System.Drawing.Size(280, 20);
			this.textBoxMaxHops.TabIndex = 6;
			// 
			// labelSource
			// 
			this.labelSource.AutoSize = true;
			this.labelSource.Location = new System.Drawing.Point(7, 67);
			this.labelSource.Name = "labelSource";
			this.labelSource.Size = new System.Drawing.Size(44, 13);
			this.labelSource.TabIndex = 1;
			this.labelSource.Text = "&Source:";
			// 
			// textBoxSource
			// 
			this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSource.Location = new System.Drawing.Point(112, 64);
			this.textBoxSource.Name = "textBoxSource";
			this.textBoxSource.ReadOnly = true;
			this.textBoxSource.Size = new System.Drawing.Size(280, 20);
			this.textBoxSource.TabIndex = 2;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(64, 28);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(115, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No traceroute selected";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.PushPin_48;
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// listViewHops
			// 
			this.listViewHops.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewHops.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderHop,
            this.columnHeaderIp,
            this.columnHeaderHostname,
            this.columnHeaderAs,
            this.columnHeaderRtt});
			this.listViewHops.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewHops.FullRowSelect = true;
			this.listViewHops.GridLines = true;
			this.listViewHops.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewHops.HideSelection = false;
			this.listViewHops.Location = new System.Drawing.Point(0, 170);
			this.listViewHops.MultiSelect = false;
			this.listViewHops.Name = "listViewHops";
			this.listViewHops.Size = new System.Drawing.Size(400, 230);
			this.listViewHops.SmallImageList = this.imageList;
			this.listViewHops.TabIndex = 1;
			this.listViewHops.UseCompatibleStateImageBehavior = false;
			this.listViewHops.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderHop
			// 
			this.columnHeaderHop.Text = "Hop";
			// 
			// columnHeaderIp
			// 
			this.columnHeaderIp.Text = "IP";
			this.columnHeaderIp.Width = 120;
			// 
			// columnHeaderHostname
			// 
			this.columnHeaderHostname.Text = "Hostname";
			this.columnHeaderHostname.Width = 120;
			// 
			// columnHeaderAs
			// 
			this.columnHeaderAs.Text = "AS numbers";
			this.columnHeaderAs.Width = 120;
			// 
			// columnHeaderRtt
			// 
			this.columnHeaderRtt.Text = "Round-trip times";
			this.columnHeaderRtt.Width = 120;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "PushPinSuccess");
			this.imageList.Images.SetKeyName(1, "PushPinError");
			// 
			// ControlMercuryClientTraceroute
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.listViewHops);
			this.Controls.Add(this.panelDomain);
			this.Name = "ControlMercuryClientTraceroute";
			this.Size = new System.Drawing.Size(400, 400);
			this.panelDomain.ResumeLayout(false);
			this.panelDomain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelDomain;
		private System.Windows.Forms.Label labelPacketSize;
		private System.Windows.Forms.TextBox textBoxPacketSize;
		private System.Windows.Forms.Label labelMaxHops;
		private System.Windows.Forms.TextBox textBoxMaxHops;
		private System.Windows.Forms.Label labelSource;
		private System.Windows.Forms.TextBox textBoxSource;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.ListView listViewHops;
		private System.Windows.Forms.ColumnHeader columnHeaderHop;
		private System.Windows.Forms.ColumnHeader columnHeaderIp;
		private System.Windows.Forms.ColumnHeader columnHeaderHostname;
		private System.Windows.Forms.ColumnHeader columnHeaderAs;
		private System.Windows.Forms.ColumnHeader columnHeaderRtt;
		private System.Windows.Forms.Label labelDestination;
		private System.Windows.Forms.TextBox textBoxDestination;
		private System.Windows.Forms.ImageList imageList;

	}
}
