namespace InetAnalytics.Forms
{
	partial class FormCrash
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrash));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelType = new System.Windows.Forms.Label();
			this.labelTarget = new System.Windows.Forms.Label();
			this.labelMessage = new System.Windows.Forms.Label();
			this.textBoxTarget = new System.Windows.Forms.TextBox();
			this.labelSource = new System.Windows.Forms.Label();
			this.textBoxType = new System.Windows.Forms.TextBox();
			this.textBoxSource = new System.Windows.Forms.TextBox();
			this.textBoxMessage = new System.Windows.Forms.TextBox();
			this.textBoxStack = new System.Windows.Forms.TextBox();
			this.labelStack = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::InetAnalytics.Resources.Error_48;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(48, 48);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoEllipsis = true;
			this.labelTitle.Location = new System.Drawing.Point(67, 12);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(355, 64);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "YouTube Analytics has crashed due to an unhandled exception.\r\n\r\nUnfortunately, yo" +
    "ur work may be lost, but you can report back to the developer with the informati" +
    "on below to fix the problem.";
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(12, 82);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(34, 13);
			this.labelType.TabIndex = 13;
			this.labelType.Text = "&Type:";
			// 
			// labelTarget
			// 
			this.labelTarget.AutoSize = true;
			this.labelTarget.Location = new System.Drawing.Point(12, 160);
			this.labelTarget.Name = "labelTarget";
			this.labelTarget.Size = new System.Drawing.Size(41, 13);
			this.labelTarget.TabIndex = 24;
			this.labelTarget.Text = "T&arget:";
			// 
			// labelMessage
			// 
			this.labelMessage.AutoSize = true;
			this.labelMessage.Location = new System.Drawing.Point(12, 108);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(53, 13);
			this.labelMessage.TabIndex = 15;
			this.labelMessage.Text = "&Message:";
			// 
			// textBoxTarget
			// 
			this.textBoxTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTarget.Location = new System.Drawing.Point(86, 157);
			this.textBoxTarget.Name = "textBoxTarget";
			this.textBoxTarget.ReadOnly = true;
			this.textBoxTarget.Size = new System.Drawing.Size(336, 20);
			this.textBoxTarget.TabIndex = 23;
			// 
			// labelSource
			// 
			this.labelSource.AutoSize = true;
			this.labelSource.Location = new System.Drawing.Point(12, 134);
			this.labelSource.Name = "labelSource";
			this.labelSource.Size = new System.Drawing.Size(44, 13);
			this.labelSource.TabIndex = 22;
			this.labelSource.Text = "&Source:";
			// 
			// textBoxType
			// 
			this.textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxType.Location = new System.Drawing.Point(86, 79);
			this.textBoxType.Name = "textBoxType";
			this.textBoxType.ReadOnly = true;
			this.textBoxType.Size = new System.Drawing.Size(336, 20);
			this.textBoxType.TabIndex = 14;
			// 
			// textBoxSource
			// 
			this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSource.Location = new System.Drawing.Point(86, 131);
			this.textBoxSource.Name = "textBoxSource";
			this.textBoxSource.ReadOnly = true;
			this.textBoxSource.Size = new System.Drawing.Size(336, 20);
			this.textBoxSource.TabIndex = 21;
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMessage.Location = new System.Drawing.Point(86, 105);
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.ReadOnly = true;
			this.textBoxMessage.Size = new System.Drawing.Size(336, 20);
			this.textBoxMessage.TabIndex = 16;
			// 
			// textBoxStack
			// 
			this.textBoxStack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxStack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxStack.Location = new System.Drawing.Point(86, 183);
			this.textBoxStack.Multiline = true;
			this.textBoxStack.Name = "textBoxStack";
			this.textBoxStack.ReadOnly = true;
			this.textBoxStack.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxStack.Size = new System.Drawing.Size(336, 255);
			this.textBoxStack.TabIndex = 20;
			this.textBoxStack.WordWrap = false;
			// 
			// labelStack
			// 
			this.labelStack.AutoSize = true;
			this.labelStack.Location = new System.Drawing.Point(12, 185);
			this.labelStack.Name = "labelStack";
			this.labelStack.Size = new System.Drawing.Size(38, 13);
			this.labelStack.TabIndex = 19;
			this.labelStack.Text = "Stack:";
			// 
			// FormCrash
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 450);
			this.Controls.Add(this.labelType);
			this.Controls.Add(this.labelTarget);
			this.Controls.Add(this.labelMessage);
			this.Controls.Add(this.textBoxTarget);
			this.Controls.Add(this.labelSource);
			this.Controls.Add(this.textBoxType);
			this.Controls.Add(this.textBoxSource);
			this.Controls.Add(this.textBoxMessage);
			this.Controls.Add(this.textBoxStack);
			this.Controls.Add(this.labelStack);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormCrash";
			this.Text = "YouTube Analytics Crashed";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.Label labelTarget;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.TextBox textBoxTarget;
		private System.Windows.Forms.Label labelSource;
		private System.Windows.Forms.TextBox textBoxType;
		private System.Windows.Forms.TextBox textBoxSource;
		private System.Windows.Forms.TextBox textBoxMessage;
		private System.Windows.Forms.TextBox textBoxStack;
		private System.Windows.Forms.Label labelStack;
	}
}