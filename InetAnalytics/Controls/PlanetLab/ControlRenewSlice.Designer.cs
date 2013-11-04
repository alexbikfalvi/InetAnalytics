namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlRenewSlice
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlRenewSlice));
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.labelStatus = new System.Windows.Forms.Label();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonRenew = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxExpires = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelExpires = new System.Windows.Forms.Label();
			this.comboBoxRenew = new System.Windows.Forms.ComboBox();
			this.labelRenew = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(170, 20);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Renew PlanetLab slice";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.ClockNew_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "GlobeObject");
			// 
			// labelStatus
			// 
			this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelStatus.AutoEllipsis = true;
			this.labelStatus.Location = new System.Drawing.Point(165, 274);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(170, 23);
			this.labelStatus.TabIndex = 9;
			this.labelStatus.Text = "Ready.";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCancel.Location = new System.Drawing.Point(84, 274);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "C&ancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// buttonRenew
			// 
			this.buttonRenew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRenew.Location = new System.Drawing.Point(341, 274);
			this.buttonRenew.Name = "buttonRenew";
			this.buttonRenew.Size = new System.Drawing.Size(75, 23);
			this.buttonRenew.TabIndex = 10;
			this.buttonRenew.Text = "Rene&w";
			this.buttonRenew.UseVisualStyleBackColor = true;
			this.buttonRenew.Click += new System.EventHandler(this.OnRenew);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(422, 274);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 11;
			this.buttonClose.Text = "&Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.OnClose);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRefresh.Image = global::InetAnalytics.Resources.Refresh_16;
			this.buttonRefresh.Location = new System.Drawing.Point(3, 274);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
			this.buttonRefresh.TabIndex = 7;
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefreshSlice);
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(17, 77);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(62, 13);
			this.labelName.TabIndex = 1;
			this.labelName.Text = "Slice &name:";
			// 
			// textBoxExpires
			// 
			this.textBoxExpires.Location = new System.Drawing.Point(112, 100);
			this.textBoxExpires.Name = "textBoxExpires";
			this.textBoxExpires.ReadOnly = true;
			this.textBoxExpires.Size = new System.Drawing.Size(250, 20);
			this.textBoxExpires.TabIndex = 4;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(112, 74);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.ReadOnly = true;
			this.textBoxName.Size = new System.Drawing.Size(250, 20);
			this.textBoxName.TabIndex = 2;
			// 
			// labelExpires
			// 
			this.labelExpires.AutoSize = true;
			this.labelExpires.Location = new System.Drawing.Point(17, 103);
			this.labelExpires.Name = "labelExpires";
			this.labelExpires.Size = new System.Drawing.Size(80, 13);
			this.labelExpires.TabIndex = 3;
			this.labelExpires.Text = "E&xpiration date:";
			// 
			// comboBoxRenew
			// 
			this.comboBoxRenew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxRenew.FormattingEnabled = true;
			this.comboBoxRenew.Location = new System.Drawing.Point(112, 126);
			this.comboBoxRenew.Name = "comboBoxRenew";
			this.comboBoxRenew.Size = new System.Drawing.Size(250, 21);
			this.comboBoxRenew.TabIndex = 6;
			this.comboBoxRenew.SelectedIndexChanged += new System.EventHandler(this.OnRenewChanged);
			// 
			// labelRenew
			// 
			this.labelRenew.AutoSize = true;
			this.labelRenew.Location = new System.Drawing.Point(17, 129);
			this.labelRenew.Name = "labelRenew";
			this.labelRenew.Size = new System.Drawing.Size(89, 13);
			this.labelRenew.TabIndex = 5;
			this.labelRenew.Text = "Renewal inter&val:";
			// 
			// ControlRenewSlice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.labelRenew);
			this.Controls.Add(this.comboBoxRenew);
			this.Controls.Add(this.labelExpires);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.textBoxExpires);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonRenew);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.MinimumSize = new System.Drawing.Size(0, 230);
			this.Name = "ControlRenewSlice";
			this.Size = new System.Drawing.Size(500, 300);
			this.Controls.SetChildIndex(this.pictureBox, 0);
			this.Controls.SetChildIndex(this.labelTitle, 0);
			this.Controls.SetChildIndex(this.buttonRefresh, 0);
			this.Controls.SetChildIndex(this.buttonClose, 0);
			this.Controls.SetChildIndex(this.buttonRenew, 0);
			this.Controls.SetChildIndex(this.buttonCancel, 0);
			this.Controls.SetChildIndex(this.labelStatus, 0);
			this.Controls.SetChildIndex(this.labelName, 0);
			this.Controls.SetChildIndex(this.textBoxExpires, 0);
			this.Controls.SetChildIndex(this.textBoxName, 0);
			this.Controls.SetChildIndex(this.labelExpires, 0);
			this.Controls.SetChildIndex(this.comboBoxRenew, 0);
			this.Controls.SetChildIndex(this.labelRenew, 0);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonRenew;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxExpires;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelExpires;
		private System.Windows.Forms.ComboBox comboBoxRenew;
		private System.Windows.Forms.Label labelRenew;
	}
}
