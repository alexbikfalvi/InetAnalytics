namespace InetAnalytics.Controls.Tools
{
	partial class ControlToolboxInfo
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
			this.labelTitle = new System.Windows.Forms.Label();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelConfiguration = new System.Windows.Forms.Label();
			this.settings = new InetAnalytics.Controls.Tools.ControlToolboxSettings();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::InetAnalytics.Resources.ServerToolbox_48;
			this.pictureBoxIcon.Location = new System.Drawing.Point(20, 41);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.TabIndex = 0;
			this.pictureBoxIcon.TabStop = false;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.labelTitle, 2);
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(3, 0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(71, 20);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Toolbox";
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
			this.tableLayoutPanel.Controls.Add(this.labelDescription, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.labelConfiguration, 0, 2);
			this.tableLayoutPanel.Controls.Add(this.settings, 0, 3);
			this.tableLayoutPanel.Location = new System.Drawing.Point(75, 42);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 4;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(721, 554);
			this.tableLayoutPanel.TabIndex = 5;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.labelDescription, 2);
			this.labelDescription.Location = new System.Drawing.Point(3, 30);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(390, 13);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "You can use the toolbox to manage the analytics tools for Internet measurements.";
			// 
			// labelConfiguration
			// 
			this.labelConfiguration.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.labelConfiguration, 2);
			this.labelConfiguration.Location = new System.Drawing.Point(3, 86);
			this.labelConfiguration.Margin = new System.Windows.Forms.Padding(3, 40, 3, 3);
			this.labelConfiguration.Name = "labelConfiguration";
			this.labelConfiguration.Size = new System.Drawing.Size(462, 13);
			this.labelConfiguration.TabIndex = 11;
			this.labelConfiguration.Text = "The following list shows the current analytics tool. You can load new tools from " +
    "an existing library.";
			// 
			// settings
			// 
			this.tableLayoutPanel.SetColumnSpan(this.settings, 2);
			this.settings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.settings.Enabled = false;
			this.settings.Location = new System.Drawing.Point(3, 105);
			this.settings.Name = "settings";
			this.settings.Padding = new System.Windows.Forms.Padding(1);
			this.settings.ShowBorder = true;
			this.settings.Size = new System.Drawing.Size(715, 446);
			this.settings.TabIndex = 12;
			this.settings.Title = "";
			// 
			// ControlToolboxInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.pictureBoxIcon);
			this.Name = "ControlToolboxInfo";
			this.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.ShowBorder = true;
			this.ShowTitle = true;
			this.Size = new System.Drawing.Size(800, 600);
			this.Title = "Toolbox";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Label labelConfiguration;
		private System.Windows.Forms.Label labelDescription;
		private ControlToolboxSettings settings;
	}
}
