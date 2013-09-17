namespace YtAnalytics.Controls.PlanetLab
{
	partial class ControlPlanetLabInfo
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
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.linkLabelSites = new System.Windows.Forms.LinkLabel();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.labelConfiguration = new System.Windows.Forms.Label();
			this.labelSites = new System.Windows.Forms.Label();
			this.settings = new YtAnalytics.Controls.PlanetLab.ControlPlanetLabSettings();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::YtAnalytics.Resources.GlobeLab_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 20);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 0;
			this.pictureBoxIcon.TabStop = false;
			// 
			// linkLabelSites
			// 
			this.linkLabelSites.AutoSize = true;
			this.linkLabelSites.Location = new System.Drawing.Point(3, 49);
			this.linkLabelSites.Margin = new System.Windows.Forms.Padding(3);
			this.linkLabelSites.Name = "linkLabelSites";
			this.linkLabelSites.Size = new System.Drawing.Size(30, 13);
			this.linkLabelSites.TabIndex = 5;
			this.linkLabelSites.TabStop = true;
			this.linkLabelSites.Text = "Sites";
			this.linkLabelSites.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnNodesClick);
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.labelDescription, 2);
			this.labelDescription.Location = new System.Drawing.Point(3, 30);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(393, 13);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "You can use the PlanetLab project to perform distributed YouTube measurements.";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.labelTitle, 2);
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(90, 20);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "PlanetLab";
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.labelConfiguration, 0, 3);
			this.tableLayoutPanel.Controls.Add(this.labelTitle, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.linkLabelSites, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.labelDescription, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.labelSites, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.settings, 0, 4);
			this.tableLayoutPanel.Location = new System.Drawing.Point(74, 20);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 5;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(723, 577);
			this.tableLayoutPanel.TabIndex = 5;
			// 
			// labelConfiguration
			// 
			this.labelConfiguration.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.labelConfiguration, 2);
			this.labelConfiguration.Location = new System.Drawing.Point(3, 105);
			this.labelConfiguration.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
			this.labelConfiguration.Name = "labelConfiguration";
			this.labelConfiguration.Size = new System.Drawing.Size(231, 13);
			this.labelConfiguration.TabIndex = 7;
			this.labelConfiguration.Text = "The PlanetLab uses the following configuration.";
			// 
			// labelSites
			// 
			this.labelSites.AutoSize = true;
			this.labelSites.Location = new System.Drawing.Point(39, 49);
			this.labelSites.Margin = new System.Windows.Forms.Padding(3);
			this.labelSites.Name = "labelSites";
			this.labelSites.Size = new System.Drawing.Size(326, 13);
			this.labelSites.TabIndex = 6;
			this.labelSites.Text = "Visualize the PlanetLab sites available for distributed measurements.";
			// 
			// settings
			// 
			this.settings.AutoScroll = true;
			this.tableLayoutPanel.SetColumnSpan(this.settings, 2);
			this.settings.Crawler = null;
			this.settings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.settings.Location = new System.Drawing.Point(3, 124);
			this.settings.Name = "settings";
			this.settings.Size = new System.Drawing.Size(717, 450);
			this.settings.TabIndex = 8;
			// 
			// ControlPlanetLabInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.pictureBoxIcon);
			this.Name = "ControlPlanetLabInfo";
			this.Size = new System.Drawing.Size(800, 600);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.LinkLabel linkLabelSites;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelSites;
		private System.Windows.Forms.Label labelConfiguration;
		private ControlPlanetLabSettings settings;
	}
}
