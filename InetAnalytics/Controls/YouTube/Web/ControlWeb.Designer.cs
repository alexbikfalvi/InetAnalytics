namespace InetAnalytics.Controls.YouTube.Web
{
	partial class ControlWeb
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlWeb));
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.linkLabelVideoStatistics = new System.Windows.Forms.LinkLabel();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.labelVideoStatistics = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::InetAnalytics.Resources.ServerGlobe_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 41);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 0;
			this.pictureBoxIcon.TabStop = false;
			// 
			// linkLabelVideoStatistics
			// 
			this.linkLabelVideoStatistics.AutoSize = true;
			this.linkLabelVideoStatistics.Location = new System.Drawing.Point(3, 75);
			this.linkLabelVideoStatistics.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelVideoStatistics.Name = "linkLabelVideoStatistics";
			this.linkLabelVideoStatistics.Size = new System.Drawing.Size(77, 13);
			this.linkLabelVideoStatistics.TabIndex = 5;
			this.linkLabelVideoStatistics.TabStop = true;
			this.linkLabelVideoStatistics.Text = "Video statistics";
			this.linkLabelVideoStatistics.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnVideoStatisticsClick);
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.labelDescription, 2);
			this.labelDescription.Location = new System.Drawing.Point(3, 30);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(308, 39);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "This analytics function collects data from the YouTube web site.\r\n\r\nCurrently, th" +
    "e following options are available:\r\n";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.labelTitle, 2);
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(122, 20);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "YouTube Web";
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.labelTitle, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.linkLabelVideoStatistics, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.labelDescription, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.labelVideoStatistics, 1, 2);
			this.tableLayoutPanel.Location = new System.Drawing.Point(75, 42);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 4;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(721, 554);
			this.tableLayoutPanel.TabIndex = 5;
			// 
			// labelVideoStatistics
			// 
			this.labelVideoStatistics.AutoSize = true;
			this.labelVideoStatistics.Location = new System.Drawing.Point(86, 75);
			this.labelVideoStatistics.Margin = new System.Windows.Forms.Padding(3);
			this.labelVideoStatistics.Name = "labelVideoStatistics";
			this.labelVideoStatistics.Size = new System.Drawing.Size(592, 26);
			this.labelVideoStatistics.TabIndex = 6;
			this.labelVideoStatistics.Text = resources.GetString("labelVideoStatistics.Text");
			// 
			// ControlWeb
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.pictureBoxIcon);
			this.Name = "ControlWeb";
			this.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.ShowBorder = true;
			this.ShowTitle = true;
			this.Size = new System.Drawing.Size(800, 600);
			this.Title = "YouTube Web Data";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.LinkLabel linkLabelVideoStatistics;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelVideoStatistics;
	}
}
