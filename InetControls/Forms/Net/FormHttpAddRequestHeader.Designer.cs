﻿namespace InetControls.Forms.Net
{
	partial class FormHttpAddRequestHeader
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
			this.buttonAdd = new System.Windows.Forms.Button();
			this.control = new InetControls.Controls.Net.ControlHttpAddRequestHeader();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(297, 227);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonAdd.Enabled = false;
			this.buttonAdd.Location = new System.Drawing.Point(216, 227);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 1;
			this.buttonAdd.Text = "&Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			// 
			// control
			// 
			this.control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.control.Caption = "Add HTTP request header";
			this.control.Header = "";
			this.control.HeaderEnabled = true;
			this.control.Location = new System.Drawing.Point(0, 0);
			this.control.Name = "control";
			this.control.Size = new System.Drawing.Size(385, 221);
			this.control.TabIndex = 0;
			this.control.Value = "";
			this.control.InputChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// FormHttpAddRequestHeader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(384, 262);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.control);
			this.Controls.Add(this.buttonCancel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormHttpAddRequestHeader";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Add HTTP Request Header";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private InetControls.Controls.Net.ControlHttpAddRequestHeader control;
		private System.Windows.Forms.Button buttonAdd;

	}
}