namespace InetAnalytics.Forms.Database
{
	partial class FormDatabaseSelect
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
			this.control = new InetAnalytics.Controls.Database.ControlDatabaseSelect();
			this.SuspendLayout();
			// 
			// control
			// 
			this.control.Dock = System.Windows.Forms.DockStyle.Fill;
			this.control.Location = new System.Drawing.Point(0, 0);
			this.control.Name = "control";
			this.control.Size = new System.Drawing.Size(584, 362);
			this.control.TabIndex = 0;
			this.control.DatabaseOperationStarted += new System.EventHandler(this.OnDatabaseOperationStarted);
			this.control.DatabaseOperationFinished += new System.EventHandler(this.OnDatabaseOperationFinished);
			this.control.Selected += new InetAnalytics.Events.DatabaseObjectSelectedEventHandler(this.OnSelected);
			this.control.Closed += new System.EventHandler(this.OnClosed);
			// 
			// FormDatabaseSelect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 362);
			this.Controls.Add(this.control);
			this.MinimizeBox = false;
			this.Name = "FormDatabaseSelect";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Select From Database";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
			this.Load += new System.EventHandler(this.OnLoad);
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.Database.ControlDatabaseSelect control;


	}
}