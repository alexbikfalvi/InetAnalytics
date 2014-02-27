namespace InetTools.Controls.Mercury
{
	partial class ControlMercury
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
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.linkLabelUploadRouting = new System.Windows.Forms.LinkLabel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.linkLabelAnalyze = new System.Windows.Forms.LinkLabel();
			this.linkLabelUploadTraceroute = new System.Windows.Forms.LinkLabel();
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.linkLabelUploadRouting, 0, 4);
			this.tableLayoutPanel.Controls.Add(this.labelTitle, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.labelDescription, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.linkLabelAnalyze, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.linkLabelUploadTraceroute, 0, 3);
			this.tableLayoutPanel.Location = new System.Drawing.Point(75, 42);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 6;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(721, 554);
			this.tableLayoutPanel.TabIndex = 5;
			// 
			// linkLabelUploadRouting
			// 
			this.linkLabelUploadRouting.AutoSize = true;
			this.linkLabelUploadRouting.Location = new System.Drawing.Point(3, 113);
			this.linkLabelUploadRouting.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelUploadRouting.Name = "linkLabelUploadRouting";
			this.linkLabelUploadRouting.Size = new System.Drawing.Size(100, 13);
			this.linkLabelUploadRouting.TabIndex = 7;
			this.linkLabelUploadRouting.TabStop = true;
			this.linkLabelUploadRouting.Text = "Upload routing data";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(72, 20);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Mercury";
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(3, 30);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(374, 39);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "This tool allows you to manage and analyze the data from the Mercury project.\r\n\r\n" +
    "You can access the data using the following tools:\r\n";
			// 
			// linkLabelAnalyze
			// 
			this.linkLabelAnalyze.AutoSize = true;
			this.linkLabelAnalyze.Location = new System.Drawing.Point(3, 75);
			this.linkLabelAnalyze.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelAnalyze.Name = "linkLabelAnalyze";
			this.linkLabelAnalyze.Size = new System.Drawing.Size(68, 13);
			this.linkLabelAnalyze.TabIndex = 5;
			this.linkLabelAnalyze.TabStop = true;
			this.linkLabelAnalyze.Text = "Analyze data";
			this.linkLabelAnalyze.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnAnalyzeClick);
			// 
			// linkLabelUploadTraceroute
			// 
			this.linkLabelUploadTraceroute.AutoSize = true;
			this.linkLabelUploadTraceroute.Location = new System.Drawing.Point(3, 94);
			this.linkLabelUploadTraceroute.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelUploadTraceroute.Name = "linkLabelUploadTraceroute";
			this.linkLabelUploadTraceroute.Size = new System.Drawing.Size(116, 13);
			this.linkLabelUploadTraceroute.TabIndex = 6;
			this.linkLabelUploadTraceroute.TabStop = true;
			this.linkLabelUploadTraceroute.Text = "Upload traceroute data";
			this.linkLabelUploadTraceroute.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnUploadTracerouteClick);
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::InetAnalytics.Resources.ToolboxGraph_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 41);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 0;
			this.pictureBoxIcon.TabStop = false;
			// 
			// ControlMercury
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.pictureBoxIcon);
			this.Name = "ControlMercury";
			this.ShowBorder = true;
			this.ShowTitle = true;
			this.Size = new System.Drawing.Size(800, 600);
			this.Title = "Mercury";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.LinkLabel linkLabelAnalyze;
		private System.Windows.Forms.LinkLabel linkLabelUploadTraceroute;
		private System.Windows.Forms.LinkLabel linkLabelUploadRouting;
	}
}
