namespace InetTools.Forms
{
	partial class FormCdnFinderSettings
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
			if (disposing)
			{
				// Dispose the components.
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.numericUpDownTimeout = new System.Windows.Forms.NumericUpDown();
			this.labelTimeout = new System.Windows.Forms.Label();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.textBoxPrefix = new System.Windows.Forms.TextBox();
			this.labelPrefix = new System.Windows.Forms.Label();
			this.checkBoxAutoRedirect = new System.Windows.Forms.CheckBox();
			this.labelProtocol = new System.Windows.Forms.Label();
			this.comboBoxProtocol = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDownTimeout
			// 
			this.numericUpDownTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownTimeout.Location = new System.Drawing.Point(12, 30);
			this.numericUpDownTimeout.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
			this.numericUpDownTimeout.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownTimeout.Name = "numericUpDownTimeout";
			this.numericUpDownTimeout.Size = new System.Drawing.Size(410, 20);
			this.numericUpDownTimeout.TabIndex = 1;
			this.numericUpDownTimeout.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericUpDownTimeout.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// labelTimeout
			// 
			this.labelTimeout.AutoSize = true;
			this.labelTimeout.Location = new System.Drawing.Point(9, 14);
			this.labelTimeout.Name = "labelTimeout";
			this.labelTimeout.Size = new System.Drawing.Size(109, 13);
			this.labelTimeout.TabIndex = 0;
			this.labelTimeout.Text = "Request &timeout (ms):";
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Enabled = false;
			this.buttonApply.Location = new System.Drawing.Point(347, 277);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 9;
			this.buttonApply.Text = "&Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.OnApplyClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(266, 277);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(185, 277);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 7;
			this.buttonOk.Text = "&OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.OnOkClick);
			// 
			// textBoxPrefix
			// 
			this.textBoxPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPrefix.Location = new System.Drawing.Point(12, 109);
			this.textBoxPrefix.Name = "textBoxPrefix";
			this.textBoxPrefix.Size = new System.Drawing.Size(410, 20);
			this.textBoxPrefix.TabIndex = 5;
			this.textBoxPrefix.TextChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// labelPrefix
			// 
			this.labelPrefix.AutoSize = true;
			this.labelPrefix.Location = new System.Drawing.Point(9, 93);
			this.labelPrefix.Name = "labelPrefix";
			this.labelPrefix.Size = new System.Drawing.Size(355, 13);
			this.labelPrefix.TabIndex = 4;
			this.labelPrefix.Text = "&Subdomains for non-existing domains (separate multiple subdomains by \';\'):";
			// 
			// checkBoxAutoRedirect
			// 
			this.checkBoxAutoRedirect.AutoSize = true;
			this.checkBoxAutoRedirect.Location = new System.Drawing.Point(12, 135);
			this.checkBoxAutoRedirect.Name = "checkBoxAutoRedirect";
			this.checkBoxAutoRedirect.Size = new System.Drawing.Size(227, 17);
			this.checkBoxAutoRedirect.TabIndex = 6;
			this.checkBoxAutoRedirect.Text = "Use &automatic redirection for web requests";
			this.checkBoxAutoRedirect.UseVisualStyleBackColor = true;
			this.checkBoxAutoRedirect.CheckedChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// labelProtocol
			// 
			this.labelProtocol.AutoSize = true;
			this.labelProtocol.Location = new System.Drawing.Point(9, 53);
			this.labelProtocol.Name = "labelProtocol";
			this.labelProtocol.Size = new System.Drawing.Size(49, 13);
			this.labelProtocol.TabIndex = 2;
			this.labelProtocol.Text = "Pr&otocol:";
			// 
			// comboBoxProtocol
			// 
			this.comboBoxProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxProtocol.FormattingEnabled = true;
			this.comboBoxProtocol.Items.AddRange(new object[] {
            "http",
            "https"});
			this.comboBoxProtocol.Location = new System.Drawing.Point(12, 69);
			this.comboBoxProtocol.Name = "comboBoxProtocol";
			this.comboBoxProtocol.Size = new System.Drawing.Size(410, 21);
			this.comboBoxProtocol.TabIndex = 3;
			// 
			// FormCdnFinderSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(434, 312);
			this.Controls.Add(this.comboBoxProtocol);
			this.Controls.Add(this.labelProtocol);
			this.Controls.Add(this.checkBoxAutoRedirect);
			this.Controls.Add(this.labelPrefix);
			this.Controls.Add(this.textBoxPrefix);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.labelTimeout);
			this.Controls.Add(this.numericUpDownTimeout);
			this.MinimizeBox = false;
			this.Name = "FormCdnFinderSettings";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Settings";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numericUpDownTimeout;
		private System.Windows.Forms.Label labelTimeout;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.TextBox textBoxPrefix;
		private System.Windows.Forms.Label labelPrefix;
		private System.Windows.Forms.CheckBox checkBoxAutoRedirect;
		private System.Windows.Forms.Label labelProtocol;
		private System.Windows.Forms.ComboBox comboBoxProtocol;

	}
}