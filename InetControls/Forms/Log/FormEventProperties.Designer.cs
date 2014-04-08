namespace InetCommon.Forms.Log
{
	partial class FormEventProperties
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
			this.logEvent = new InetCommon.Controls.Log.ControlLogEventProperties();
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
			// logEvent
			// 
			this.logEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.logEvent.Event = null;
			this.logEvent.Location = new System.Drawing.Point(6, 0);
			this.logEvent.Name = "logEvent";
			this.logEvent.Size = new System.Drawing.Size(372, 368);
			this.logEvent.TabIndex = 0;
			// 
			// FormEventProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(384, 412);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.logEvent);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEventProperties";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Event Properties";
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.Log.ControlLogEventProperties logEvent;
		private System.Windows.Forms.Button buttonClose;

	}
}