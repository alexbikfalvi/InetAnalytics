namespace InetTools.Forms.Mercury
{
	partial class FormMercuryClientSettings
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
			this.labelSessionUrl = new System.Windows.Forms.Label();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.textBoxSessionUrl = new System.Windows.Forms.TextBox();
			this.labelTracerouteUrl = new System.Windows.Forms.Label();
			this.textBoxTracerouteUrl = new System.Windows.Forms.TextBox();
			this.labelLocalAddress = new System.Windows.Forms.Label();
			this.textBoxLocalAddress = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// labelSessionUrl
			// 
			this.labelSessionUrl.AutoSize = true;
			this.labelSessionUrl.Location = new System.Drawing.Point(9, 14);
			this.labelSessionUrl.Name = "labelSessionUrl";
			this.labelSessionUrl.Size = new System.Drawing.Size(107, 13);
			this.labelSessionUrl.TabIndex = 0;
			this.labelSessionUrl.Text = "Upload &session URL:";
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Enabled = false;
			this.buttonApply.Location = new System.Drawing.Point(347, 277);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 8;
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
			this.buttonCancel.TabIndex = 7;
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
			this.buttonOk.TabIndex = 6;
			this.buttonOk.Text = "&OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.OnOkClick);
			// 
			// textBoxSessionUrl
			// 
			this.textBoxSessionUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSessionUrl.Location = new System.Drawing.Point(12, 30);
			this.textBoxSessionUrl.Name = "textBoxSessionUrl";
			this.textBoxSessionUrl.Size = new System.Drawing.Size(410, 20);
			this.textBoxSessionUrl.TabIndex = 1;
			this.textBoxSessionUrl.TextChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// labelTracerouteUrl
			// 
			this.labelTracerouteUrl.AutoSize = true;
			this.labelTracerouteUrl.Location = new System.Drawing.Point(9, 53);
			this.labelTracerouteUrl.Name = "labelTracerouteUrl";
			this.labelTracerouteUrl.Size = new System.Drawing.Size(120, 13);
			this.labelTracerouteUrl.TabIndex = 2;
			this.labelTracerouteUrl.Text = "Upload &traceroute URL:";
			// 
			// textBoxTracerouteUrl
			// 
			this.textBoxTracerouteUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTracerouteUrl.Location = new System.Drawing.Point(12, 69);
			this.textBoxTracerouteUrl.Name = "textBoxTracerouteUrl";
			this.textBoxTracerouteUrl.Size = new System.Drawing.Size(410, 20);
			this.textBoxTracerouteUrl.TabIndex = 3;
			this.textBoxTracerouteUrl.TextChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// labelLocalAddress
			// 
			this.labelLocalAddress.AutoSize = true;
			this.labelLocalAddress.Location = new System.Drawing.Point(12, 92);
			this.labelLocalAddress.Name = "labelLocalAddress";
			this.labelLocalAddress.Size = new System.Drawing.Size(89, 13);
			this.labelLocalAddress.TabIndex = 4;
			this.labelLocalAddress.Text = "Local IP &address:";
			// 
			// textBoxLocalAddress
			// 
			this.textBoxLocalAddress.Location = new System.Drawing.Point(12, 108);
			this.textBoxLocalAddress.Name = "textBoxLocalAddress";
			this.textBoxLocalAddress.Size = new System.Drawing.Size(150, 20);
			this.textBoxLocalAddress.TabIndex = 5;
			this.textBoxLocalAddress.TextChanged += new System.EventHandler(this.OnSettingsChanged);
			this.textBoxLocalAddress.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateLocalAddress);
			// 
			// FormMercuryClientSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(434, 312);
			this.Controls.Add(this.textBoxLocalAddress);
			this.Controls.Add(this.labelLocalAddress);
			this.Controls.Add(this.textBoxTracerouteUrl);
			this.Controls.Add(this.labelTracerouteUrl);
			this.Controls.Add(this.textBoxSessionUrl);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.labelSessionUrl);
			this.MinimizeBox = false;
			this.Name = "FormMercuryClientSettings";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelSessionUrl;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.TextBox textBoxSessionUrl;
		private System.Windows.Forms.Label labelTracerouteUrl;
		private System.Windows.Forms.TextBox textBoxTracerouteUrl;
		private System.Windows.Forms.Label labelLocalAddress;
		private System.Windows.Forms.TextBox textBoxLocalAddress;

	}
}