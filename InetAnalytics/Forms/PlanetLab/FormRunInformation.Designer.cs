namespace InetAnalytics.Forms.PlanetLab
{
	partial class FormRunInformation
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelText = new System.Windows.Forms.Label();
			this.buttonContinue = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.textBoxAuthor = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.labelId = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(347, 277);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Location = new System.Drawing.Point(17, 71);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(260, 13);
			this.labelText.TabIndex = 4;
			this.labelText.Text = "Enter your name and a description of your experiment.";
			// 
			// buttonContinue
			// 
			this.buttonContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonContinue.Enabled = false;
			this.buttonContinue.Location = new System.Drawing.Point(266, 277);
			this.buttonContinue.Name = "buttonContinue";
			this.buttonContinue.Size = new System.Drawing.Size(75, 23);
			this.buttonContinue.TabIndex = 1;
			this.buttonContinue.Text = "Continue";
			this.buttonContinue.UseVisualStyleBackColor = true;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
			this.saveFileDialog.Title = "Select File Name";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(197, 20);
			this.labelTitle.TabIndex = 3;
			this.labelTitle.Text = "Run PlanetLab commands";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.GlobePlayStart_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 9;
			this.pictureBox.TabStop = false;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(17, 136);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(41, 13);
			this.labelName.TabIndex = 7;
			this.labelName.Text = "&Author:";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDescription.Location = new System.Drawing.Point(20, 191);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(402, 80);
			this.textBoxDescription.TabIndex = 0;
			this.textBoxDescription.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// textBoxAuthor
			// 
			this.textBoxAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxAuthor.Location = new System.Drawing.Point(20, 152);
			this.textBoxAuthor.Name = "textBoxAuthor";
			this.textBoxAuthor.Size = new System.Drawing.Size(402, 20);
			this.textBoxAuthor.TabIndex = 8;
			this.textBoxAuthor.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(17, 175);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(63, 13);
			this.labelDescription.TabIndex = 9;
			this.labelDescription.Text = "&Description:";
			// 
			// textBoxId
			// 
			this.textBoxId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxId.Location = new System.Drawing.Point(20, 113);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.Size = new System.Drawing.Size(402, 20);
			this.textBoxId.TabIndex = 6;
			this.textBoxId.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// labelId
			// 
			this.labelId.AutoSize = true;
			this.labelId.Location = new System.Drawing.Point(17, 97);
			this.labelId.Name = "labelId";
			this.labelId.Size = new System.Drawing.Size(89, 13);
			this.labelId.TabIndex = 5;
			this.labelId.Text = "&Session identifier:";
			// 
			// FormRunInformation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(434, 312);
			this.Controls.Add(this.labelId);
			this.Controls.Add(this.textBoxId);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.textBoxAuthor);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.buttonContinue);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.buttonCancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(450, 350);
			this.Name = "FormRunInformation";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Run PlanetLab Commands";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.Button buttonContinue;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.TextBox textBoxAuthor;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.Label labelId;
	}
}