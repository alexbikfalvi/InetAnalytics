﻿namespace YtAnalytics.Controls
{
	partial class ControlSettings
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
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonSave = new System.Windows.Forms.ToolStripButton();
			this.buttonUndo = new System.Windows.Forms.ToolStripButton();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.tabPageYouTube = new System.Windows.Forms.TabPage();
			this.tabPageLog = new System.Windows.Forms.TabPage();
			this.tabPageComments = new System.Windows.Forms.TabPage();
			this.labelMessageCloseDelay = new System.Windows.Forms.Label();
			this.numericMessageCloseDelay = new System.Windows.Forms.NumericUpDown();
			this.labelYtUserName = new System.Windows.Forms.Label();
			this.textBoxYtUserName = new System.Windows.Forms.TextBox();
			this.textBoxYtPassword = new System.Windows.Forms.TextBox();
			this.labelYtPassword = new System.Windows.Forms.Label();
			this.labelLogFile = new System.Windows.Forms.Label();
			this.textBoxLogFile = new System.Windows.Forms.TextBox();
			this.labelVideoCommentsFile = new System.Windows.Forms.Label();
			this.textBoxVideoCommentsFile = new System.Windows.Forms.TextBox();
			this.toolStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageYouTube.SuspendLayout();
			this.tabPageLog.SuspendLayout();
			this.tabPageComments.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericMessageCloseDelay)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSave,
            this.buttonUndo});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(600, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Image = global::YtAnalytics.Resources.SaveAll_16;
			this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(66, 22);
			this.buttonSave.Text = "&Save all";
			this.buttonSave.Click += new System.EventHandler(this.OnSave);
			// 
			// buttonUndo
			// 
			this.buttonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.buttonUndo.Enabled = false;
			this.buttonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.Size = new System.Drawing.Size(40, 22);
			this.buttonUndo.Text = "Undo";
			this.buttonUndo.Click += new System.EventHandler(this.OnUndo);
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageYouTube);
			this.tabControl.Controls.Add(this.tabPageLog);
			this.tabControl.Controls.Add(this.tabPageComments);
			this.tabControl.Location = new System.Drawing.Point(3, 28);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(594, 369);
			this.tabControl.TabIndex = 1;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.numericMessageCloseDelay);
			this.tabPageGeneral.Controls.Add(this.labelMessageCloseDelay);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(586, 343);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// tabPageYouTube
			// 
			this.tabPageYouTube.Controls.Add(this.labelYtPassword);
			this.tabPageYouTube.Controls.Add(this.textBoxYtPassword);
			this.tabPageYouTube.Controls.Add(this.textBoxYtUserName);
			this.tabPageYouTube.Controls.Add(this.labelYtUserName);
			this.tabPageYouTube.Location = new System.Drawing.Point(4, 22);
			this.tabPageYouTube.Name = "tabPageYouTube";
			this.tabPageYouTube.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageYouTube.Size = new System.Drawing.Size(586, 343);
			this.tabPageYouTube.TabIndex = 1;
			this.tabPageYouTube.Text = "YouTube";
			this.tabPageYouTube.UseVisualStyleBackColor = true;
			// 
			// tabPageLog
			// 
			this.tabPageLog.Controls.Add(this.textBoxLogFile);
			this.tabPageLog.Controls.Add(this.labelLogFile);
			this.tabPageLog.Location = new System.Drawing.Point(4, 22);
			this.tabPageLog.Name = "tabPageLog";
			this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLog.Size = new System.Drawing.Size(586, 343);
			this.tabPageLog.TabIndex = 2;
			this.tabPageLog.Text = "Log";
			this.tabPageLog.UseVisualStyleBackColor = true;
			// 
			// tabPageComments
			// 
			this.tabPageComments.Controls.Add(this.textBoxVideoCommentsFile);
			this.tabPageComments.Controls.Add(this.labelVideoCommentsFile);
			this.tabPageComments.Location = new System.Drawing.Point(4, 22);
			this.tabPageComments.Name = "tabPageComments";
			this.tabPageComments.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageComments.Size = new System.Drawing.Size(586, 343);
			this.tabPageComments.TabIndex = 3;
			this.tabPageComments.Text = "Comments";
			this.tabPageComments.UseVisualStyleBackColor = true;
			// 
			// labelMessageCloseDelay
			// 
			this.labelMessageCloseDelay.AutoSize = true;
			this.labelMessageCloseDelay.Location = new System.Drawing.Point(16, 16);
			this.labelMessageCloseDelay.Name = "labelMessageCloseDelay";
			this.labelMessageCloseDelay.Size = new System.Drawing.Size(109, 13);
			this.labelMessageCloseDelay.TabIndex = 0;
			this.labelMessageCloseDelay.Text = "Message close delay:";
			// 
			// numericMessageCloseDelay
			// 
			this.numericMessageCloseDelay.Location = new System.Drawing.Point(150, 14);
			this.numericMessageCloseDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numericMessageCloseDelay.Name = "numericMessageCloseDelay";
			this.numericMessageCloseDelay.Size = new System.Drawing.Size(150, 20);
			this.numericMessageCloseDelay.TabIndex = 1;
			this.numericMessageCloseDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericMessageCloseDelay.ValueChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// labelYtUserName
			// 
			this.labelYtUserName.AutoSize = true;
			this.labelYtUserName.Location = new System.Drawing.Point(16, 16);
			this.labelYtUserName.Name = "labelYtUserName";
			this.labelYtUserName.Size = new System.Drawing.Size(61, 13);
			this.labelYtUserName.TabIndex = 2;
			this.labelYtUserName.Text = "User &name:";
			// 
			// textBoxYtUserName
			// 
			this.textBoxYtUserName.Location = new System.Drawing.Point(150, 13);
			this.textBoxYtUserName.Name = "textBoxYtUserName";
			this.textBoxYtUserName.Size = new System.Drawing.Size(150, 20);
			this.textBoxYtUserName.TabIndex = 3;
			this.textBoxYtUserName.TextChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// textBoxYtPassword
			// 
			this.textBoxYtPassword.Location = new System.Drawing.Point(150, 39);
			this.textBoxYtPassword.Name = "textBoxYtPassword";
			this.textBoxYtPassword.Size = new System.Drawing.Size(150, 20);
			this.textBoxYtPassword.TabIndex = 4;
			this.textBoxYtPassword.UseSystemPasswordChar = true;
			this.textBoxYtPassword.TextChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// labelYtPassword
			// 
			this.labelYtPassword.AutoSize = true;
			this.labelYtPassword.Location = new System.Drawing.Point(16, 42);
			this.labelYtPassword.Name = "labelYtPassword";
			this.labelYtPassword.Size = new System.Drawing.Size(56, 13);
			this.labelYtPassword.TabIndex = 5;
			this.labelYtPassword.Text = "&Password:";
			// 
			// labelLogFile
			// 
			this.labelLogFile.AutoSize = true;
			this.labelLogFile.Location = new System.Drawing.Point(16, 16);
			this.labelLogFile.Name = "labelLogFile";
			this.labelLogFile.Size = new System.Drawing.Size(44, 13);
			this.labelLogFile.TabIndex = 3;
			this.labelLogFile.Text = "&Log file:";
			// 
			// textBoxLogFile
			// 
			this.textBoxLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLogFile.Location = new System.Drawing.Point(150, 13);
			this.textBoxLogFile.Name = "textBoxLogFile";
			this.textBoxLogFile.ReadOnly = true;
			this.textBoxLogFile.Size = new System.Drawing.Size(400, 20);
			this.textBoxLogFile.TabIndex = 4;
			this.textBoxLogFile.TextChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// labelVideoCommentsFile
			// 
			this.labelVideoCommentsFile.AutoSize = true;
			this.labelVideoCommentsFile.Location = new System.Drawing.Point(16, 16);
			this.labelVideoCommentsFile.Name = "labelVideoCommentsFile";
			this.labelVideoCommentsFile.Size = new System.Drawing.Size(104, 13);
			this.labelVideoCommentsFile.TabIndex = 4;
			this.labelVideoCommentsFile.Text = "&Video comments file:";
			// 
			// textBoxVideoCommentsFile
			// 
			this.textBoxVideoCommentsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxVideoCommentsFile.Location = new System.Drawing.Point(150, 13);
			this.textBoxVideoCommentsFile.Name = "textBoxVideoCommentsFile";
			this.textBoxVideoCommentsFile.ReadOnly = true;
			this.textBoxVideoCommentsFile.Size = new System.Drawing.Size(400, 20);
			this.textBoxVideoCommentsFile.TabIndex = 5;
			this.textBoxVideoCommentsFile.TextChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// ControlSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.toolStrip);
			this.Enabled = false;
			this.Name = "ControlSettings";
			this.Size = new System.Drawing.Size(600, 400);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageYouTube.ResumeLayout(false);
			this.tabPageYouTube.PerformLayout();
			this.tabPageLog.ResumeLayout(false);
			this.tabPageLog.PerformLayout();
			this.tabPageComments.ResumeLayout(false);
			this.tabPageComments.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericMessageCloseDelay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton buttonSave;
		private System.Windows.Forms.ToolStripButton buttonUndo;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.TabPage tabPageYouTube;
		private System.Windows.Forms.TabPage tabPageLog;
		private System.Windows.Forms.TabPage tabPageComments;
		private System.Windows.Forms.Label labelMessageCloseDelay;
		private System.Windows.Forms.NumericUpDown numericMessageCloseDelay;
		private System.Windows.Forms.Label labelYtUserName;
		private System.Windows.Forms.TextBox textBoxYtUserName;
		private System.Windows.Forms.TextBox textBoxYtPassword;
		private System.Windows.Forms.Label labelYtPassword;
		private System.Windows.Forms.Label labelLogFile;
		private System.Windows.Forms.TextBox textBoxLogFile;
		private System.Windows.Forms.Label labelVideoCommentsFile;
		private System.Windows.Forms.TextBox textBoxVideoCommentsFile;
	}
}
