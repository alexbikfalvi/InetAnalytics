using PlanetLab.Api;

namespace InetAnalytics.Forms.PlanetLab
{
	partial class FormPlanetLabPersons
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
			this.control = new InetAnalytics.Controls.PlanetLab.ControlPlanetLabPersons();
			this.SuspendLayout();
			// 
			// control
			// 
			this.control.AutoScroll = true;
			this.control.Dock = System.Windows.Forms.DockStyle.Fill;
			this.control.Location = new System.Drawing.Point(0, 0);
			this.control.MinimumSize = new System.Drawing.Size(0, 230);
			this.control.Name = "control";
			this.control.Size = new System.Drawing.Size(434, 242);
			this.control.TabIndex = 0;
			this.control.Selected += new global::PlanetLab.PlObjectEventHandler<global::PlanetLab.Api.PlPerson>(this.OnSelected);
			this.control.Canceled += new System.EventHandler(this.OnCancel);
			// 
			// FormPlanetLabPersons
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 242);
			this.Controls.Add(this.control);
			this.MinimizeBox = false;
			this.Name = "FormPlanetLabPersons";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Select PlanetLab Account";
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.PlanetLab.ControlPlanetLabPersons control;
	}
}