﻿namespace InetAnalytics.Forms.Database
{
	partial class FormDatabaseProperties
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
			this.control = new InetAnalytics.Controls.Database.ControlDatabaseProperties();
			this.buttonClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// control
			// 
			this.control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.control.Database = null;
			this.control.IsSelected = false;
			this.control.Location = new System.Drawing.Point(6, 0);
			this.control.Name = "control";
			this.control.Size = new System.Drawing.Size(372, 371);
			this.control.TabIndex = 2;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.Location = new System.Drawing.Point(297, 377);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 3;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			// 
			// FormDatabaseProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(384, 412);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.control);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormDatabaseProperties";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Database Properties";
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.Database.ControlDatabaseProperties control;
		private System.Windows.Forms.Button buttonClose;

	}
}