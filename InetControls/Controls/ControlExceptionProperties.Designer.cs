namespace InetControls.Controls
{
	partial class ControlExceptionProperties
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
			this.labelException = new System.Windows.Forms.Label();
			this.textBoxStack = new System.Windows.Forms.TextBox();
			this.textBoxMessage = new System.Windows.Forms.TextBox();
			this.textBoxType = new System.Windows.Forms.TextBox();
			this.labelMessage = new System.Windows.Forms.Label();
			this.labelType = new System.Windows.Forms.Label();
			this.labelStack = new System.Windows.Forms.Label();
			this.textBoxSource = new System.Windows.Forms.TextBox();
			this.labelSource = new System.Windows.Forms.Label();
			this.textBoxTarget = new System.Windows.Forms.TextBox();
			this.labelTarget = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.labelInner = new System.Windows.Forms.Label();
			this.linkLabelInner = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelException
			// 
			this.labelException.AutoSize = true;
			this.labelException.Location = new System.Drawing.Point(59, 29);
			this.labelException.Name = "labelException";
			this.labelException.Size = new System.Drawing.Size(113, 13);
			this.labelException.TabIndex = 0;
			this.labelException.Text = "No exception selected";
			this.labelException.UseMnemonic = false;
			// 
			// textBoxStack
			// 
			this.textBoxStack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxStack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxStack.Location = new System.Drawing.Point(82, 136);
			this.textBoxStack.Multiline = true;
			this.textBoxStack.Name = "textBoxStack";
			this.textBoxStack.ReadOnly = true;
			this.textBoxStack.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxStack.Size = new System.Drawing.Size(245, 171);
			this.textBoxStack.TabIndex = 11;
			this.textBoxStack.WordWrap = false;
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMessage.Location = new System.Drawing.Point(82, 32);
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.ReadOnly = true;
			this.textBoxMessage.Size = new System.Drawing.Size(245, 20);
			this.textBoxMessage.TabIndex = 3;
			// 
			// textBoxType
			// 
			this.textBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxType.Location = new System.Drawing.Point(82, 6);
			this.textBoxType.Name = "textBoxType";
			this.textBoxType.ReadOnly = true;
			this.textBoxType.Size = new System.Drawing.Size(245, 20);
			this.textBoxType.TabIndex = 1;
			// 
			// labelMessage
			// 
			this.labelMessage.AutoSize = true;
			this.labelMessage.Location = new System.Drawing.Point(6, 35);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(53, 13);
			this.labelMessage.TabIndex = 2;
			this.labelMessage.Text = "&Message:";
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(6, 9);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(34, 13);
			this.labelType.TabIndex = 0;
			this.labelType.Text = "&Type:";
			// 
			// labelStack
			// 
			this.labelStack.AutoSize = true;
			this.labelStack.Location = new System.Drawing.Point(6, 138);
			this.labelStack.Name = "labelStack";
			this.labelStack.Size = new System.Drawing.Size(38, 13);
			this.labelStack.TabIndex = 10;
			this.labelStack.Text = "Stack:";
			// 
			// textBoxSource
			// 
			this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSource.Location = new System.Drawing.Point(82, 58);
			this.textBoxSource.Name = "textBoxSource";
			this.textBoxSource.ReadOnly = true;
			this.textBoxSource.Size = new System.Drawing.Size(245, 20);
			this.textBoxSource.TabIndex = 5;
			// 
			// labelSource
			// 
			this.labelSource.AutoSize = true;
			this.labelSource.Location = new System.Drawing.Point(7, 61);
			this.labelSource.Name = "labelSource";
			this.labelSource.Size = new System.Drawing.Size(44, 13);
			this.labelSource.TabIndex = 4;
			this.labelSource.Text = "&Source:";
			// 
			// textBoxTarget
			// 
			this.textBoxTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTarget.Location = new System.Drawing.Point(82, 84);
			this.textBoxTarget.Name = "textBoxTarget";
			this.textBoxTarget.ReadOnly = true;
			this.textBoxTarget.Size = new System.Drawing.Size(245, 20);
			this.textBoxTarget.TabIndex = 7;
			// 
			// labelTarget
			// 
			this.labelTarget.AutoSize = true;
			this.labelTarget.Location = new System.Drawing.Point(6, 87);
			this.labelTarget.Name = "labelTarget";
			this.labelTarget.Size = new System.Drawing.Size(41, 13);
			this.labelTarget.TabIndex = 6;
			this.labelTarget.Text = "T&arget:";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetControls.Resources.Exception_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Location = new System.Drawing.Point(6, 58);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(341, 339);
			this.tabControl.TabIndex = 0;
			this.tabControl.Visible = false;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.labelType);
			this.tabPageGeneral.Controls.Add(this.labelTarget);
			this.tabPageGeneral.Controls.Add(this.labelMessage);
			this.tabPageGeneral.Controls.Add(this.textBoxTarget);
			this.tabPageGeneral.Controls.Add(this.labelInner);
			this.tabPageGeneral.Controls.Add(this.labelSource);
			this.tabPageGeneral.Controls.Add(this.textBoxType);
			this.tabPageGeneral.Controls.Add(this.textBoxSource);
			this.tabPageGeneral.Controls.Add(this.textBoxMessage);
			this.tabPageGeneral.Controls.Add(this.linkLabelInner);
			this.tabPageGeneral.Controls.Add(this.textBoxStack);
			this.tabPageGeneral.Controls.Add(this.labelStack);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(333, 313);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// labelInner
			// 
			this.labelInner.AutoSize = true;
			this.labelInner.Location = new System.Drawing.Point(6, 114);
			this.labelInner.Name = "labelInner";
			this.labelInner.Size = new System.Drawing.Size(34, 13);
			this.labelInner.TabIndex = 8;
			this.labelInner.Text = "I&nner:";
			// 
			// linkLabelInner
			// 
			this.linkLabelInner.Enabled = false;
			this.linkLabelInner.Image = global::InetControls.Resources.Exception_16;
			this.linkLabelInner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabelInner.Location = new System.Drawing.Point(79, 111);
			this.linkLabelInner.Name = "linkLabelInner";
			this.linkLabelInner.Size = new System.Drawing.Size(35, 16);
			this.linkLabelInner.TabIndex = 9;
			this.linkLabelInner.TabStop = true;
			this.linkLabelInner.Text = "None";
			this.linkLabelInner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.linkLabelInner.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnInnerExceptionClick);
			// 
			// ControlExceptionProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelException);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlExceptionProperties";
			this.Size = new System.Drawing.Size(350, 400);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelException;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.TextBox textBoxStack;
		private System.Windows.Forms.TextBox textBoxMessage;
		private System.Windows.Forms.TextBox textBoxType;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.Label labelStack;
		private System.Windows.Forms.TextBox textBoxSource;
		private System.Windows.Forms.Label labelSource;
		private System.Windows.Forms.TextBox textBoxTarget;
		private System.Windows.Forms.Label labelTarget;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.Label labelInner;
		private System.Windows.Forms.LinkLabel linkLabelInner;
	}
}
