﻿namespace YtAnalytics.Forms
{
	partial class FormCompareFields
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
			this.buttonContinue = new System.Windows.Forms.Button();
			this.control = new YtAnalytics.Controls.Database.ControlCompareFields();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.No;
			this.buttonCancel.Location = new System.Drawing.Point(397, 273);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonContinue
			// 
			this.buttonContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonContinue.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.buttonContinue.Location = new System.Drawing.Point(316, 273);
			this.buttonContinue.Name = "buttonContinue";
			this.buttonContinue.Size = new System.Drawing.Size(75, 23);
			this.buttonContinue.TabIndex = 1;
			this.buttonContinue.Text = "Continue";
			this.buttonContinue.UseVisualStyleBackColor = true;
			// 
			// control
			// 
			this.control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.control.AutoScroll = true;
			this.control.Location = new System.Drawing.Point(0, 0);
			this.control.MinimumSize = new System.Drawing.Size(0, 230);
			this.control.Name = "control";
			this.control.Size = new System.Drawing.Size(484, 267);
			this.control.TabIndex = 3;
			// 
			// FormCompareFields
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(484, 308);
			this.Controls.Add(this.control);
			this.Controls.Add(this.buttonContinue);
			this.Controls.Add(this.buttonCancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormCompareFields";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Compare Table Fields";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonContinue;
		private Controls.Database.ControlCompareFields control;

	}
}