﻿namespace InetAnalytics.Forms.YouTube
{
	partial class FormDiscoveryProperties
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
			this.buttonClose = new System.Windows.Forms.Button();
			this.controlHistoryDiscoveryEvent = new InetAnalytics.Controls.YouTube.ControlDiscoveryProperties();
			this.SuspendLayout();
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.Location = new System.Drawing.Point(297, 377);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 1;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			// 
			// controlHistoryDiscoveryEvent
			// 
			this.controlHistoryDiscoveryEvent.Event = null;
			this.controlHistoryDiscoveryEvent.Location = new System.Drawing.Point(6, 0);
			this.controlHistoryDiscoveryEvent.Name = "controlHistoryDiscoveryEvent";
			this.controlHistoryDiscoveryEvent.Size = new System.Drawing.Size(372, 371);
			this.controlHistoryDiscoveryEvent.TabIndex = 2;
			// 
			// FormDiscoveryProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(384, 412);
			this.Controls.Add(this.controlHistoryDiscoveryEvent);
			this.Controls.Add(this.buttonClose);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormDiscoveryProperties";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Discovery Event Properties";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonClose;
		private Controls.YouTube.ControlDiscoveryProperties controlHistoryDiscoveryEvent;

	}
}