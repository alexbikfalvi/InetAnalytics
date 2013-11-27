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
			if (disposing && (components != null))
			{
				components.Dispose();
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
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDownTimeout
			// 
			this.numericUpDownTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownTimeout.Location = new System.Drawing.Point(172, 12);
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
			this.numericUpDownTimeout.Size = new System.Drawing.Size(150, 20);
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
			this.labelTimeout.Location = new System.Drawing.Point(12, 14);
			this.labelTimeout.Name = "labelTimeout";
			this.labelTimeout.Size = new System.Drawing.Size(109, 13);
			this.labelTimeout.TabIndex = 0;
			this.labelTimeout.Text = "Request &timeout (ms):";
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Enabled = false;
			this.buttonApply.Location = new System.Drawing.Point(247, 127);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 4;
			this.buttonApply.Text = "&Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(166, 127);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.Location = new System.Drawing.Point(85, 127);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 2;
			this.buttonOk.Text = "&OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.OnOkClick);
			// 
			// FormCdnFinderSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(334, 162);
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

	}
}