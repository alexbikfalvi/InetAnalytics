namespace YtAnalytics.Controls.Testing
{
	partial class ControlAddHttpRequestHeader
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
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelCaption = new System.Windows.Forms.Label();
			this.textBoxValue = new System.Windows.Forms.TextBox();
			this.labelValue = new System.Windows.Forms.Label();
			this.labelItem = new System.Windows.Forms.Label();
			this.comboBoxHeader = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.HeaderAdd_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// labelCaption
			// 
			this.labelCaption.AutoSize = true;
			this.labelCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCaption.Location = new System.Drawing.Point(75, 34);
			this.labelCaption.Name = "labelCaption";
			this.labelCaption.Size = new System.Drawing.Size(194, 20);
			this.labelCaption.TabIndex = 0;
			this.labelCaption.Text = "Add HTTP request header";
			// 
			// textBoxValue
			// 
			this.textBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxValue.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxValue.Location = new System.Drawing.Point(99, 101);
			this.textBoxValue.Multiline = true;
			this.textBoxValue.Name = "textBoxValue";
			this.textBoxValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxValue.Size = new System.Drawing.Size(270, 186);
			this.textBoxValue.TabIndex = 6;
			this.textBoxValue.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// labelValue
			// 
			this.labelValue.AutoSize = true;
			this.labelValue.Location = new System.Drawing.Point(17, 104);
			this.labelValue.Name = "labelValue";
			this.labelValue.Size = new System.Drawing.Size(37, 13);
			this.labelValue.TabIndex = 5;
			this.labelValue.Text = "&Value:";
			// 
			// labelItem
			// 
			this.labelItem.AutoSize = true;
			this.labelItem.Location = new System.Drawing.Point(17, 77);
			this.labelItem.Name = "labelItem";
			this.labelItem.Size = new System.Drawing.Size(45, 13);
			this.labelItem.TabIndex = 1;
			this.labelItem.Text = "&Header:";
			// 
			// comboBoxHeader
			// 
			this.comboBoxHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxHeader.FormattingEnabled = true;
			this.comboBoxHeader.Location = new System.Drawing.Point(99, 74);
			this.comboBoxHeader.Name = "comboBoxHeader";
			this.comboBoxHeader.Size = new System.Drawing.Size(270, 21);
			this.comboBoxHeader.TabIndex = 7;
			this.comboBoxHeader.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// ControlAddHttpRequestHeader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.comboBoxHeader);
			this.Controls.Add(this.textBoxValue);
			this.Controls.Add(this.labelValue);
			this.Controls.Add(this.labelItem);
			this.Controls.Add(this.labelCaption);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlAddHttpRequestHeader";
			this.Size = new System.Drawing.Size(400, 290);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelCaption;
		private System.Windows.Forms.TextBox textBoxValue;
		private System.Windows.Forms.Label labelValue;
		private System.Windows.Forms.Label labelItem;
		private System.Windows.Forms.ComboBox comboBoxHeader;
	}
}
