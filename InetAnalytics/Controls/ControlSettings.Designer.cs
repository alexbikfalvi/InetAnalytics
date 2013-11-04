namespace InetAnalytics.Controls
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
			System.Security.SecureString secureString1 = new System.Security.SecureString();
			System.Security.SecureString secureString2 = new System.Security.SecureString();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonSave = new System.Windows.Forms.ToolStripButton();
			this.buttonUndo = new System.Windows.Forms.ToolStripButton();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.numericMessageCloseDelay = new System.Windows.Forms.NumericUpDown();
			this.labelMessageCloseDelay = new System.Windows.Forms.Label();
			this.tabPageYouTube = new System.Windows.Forms.TabPage();
			this.groupBoxYt2 = new System.Windows.Forms.GroupBox();
			this.labelYt2Key = new System.Windows.Forms.Label();
			this.textBoxYt2Key = new DotNetApi.Windows.Controls.SecureTextBox();
			this.textBoxYtPassword = new DotNetApi.Windows.Controls.SecureTextBox();
			this.labelYtPassword = new System.Windows.Forms.Label();
			this.textBoxYtUserName = new System.Windows.Forms.TextBox();
			this.labelYtUserName = new System.Windows.Forms.Label();
			this.tabPageLog = new System.Windows.Forms.TabPage();
			this.textBoxLogFile = new System.Windows.Forms.TextBox();
			this.labelLogFile = new System.Windows.Forms.Label();
			this.tabPageComments = new System.Windows.Forms.TabPage();
			this.labelPlaylistCommentsFile = new System.Windows.Forms.Label();
			this.textBoxPlaylistCommentsFile = new System.Windows.Forms.TextBox();
			this.textBoxUserCommentsFile = new System.Windows.Forms.TextBox();
			this.labelUserCommentsFile = new System.Windows.Forms.Label();
			this.textBoxVideoCommentsFile = new System.Windows.Forms.TextBox();
			this.labelVideoCommentsFile = new System.Windows.Forms.Label();
			this.labelYtCategories = new System.Windows.Forms.Label();
			this.textBoxYtCategories = new System.Windows.Forms.TextBox();
			this.toolStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericMessageCloseDelay)).BeginInit();
			this.tabPageYouTube.SuspendLayout();
			this.groupBoxYt2.SuspendLayout();
			this.tabPageLog.SuspendLayout();
			this.tabPageComments.SuspendLayout();
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
			this.buttonSave.Image = global::InetAnalytics.Resources.SaveAll_16;
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
			// labelMessageCloseDelay
			// 
			this.labelMessageCloseDelay.AutoSize = true;
			this.labelMessageCloseDelay.Location = new System.Drawing.Point(16, 16);
			this.labelMessageCloseDelay.Name = "labelMessageCloseDelay";
			this.labelMessageCloseDelay.Size = new System.Drawing.Size(109, 13);
			this.labelMessageCloseDelay.TabIndex = 0;
			this.labelMessageCloseDelay.Text = "Message close delay:";
			// 
			// tabPageYouTube
			// 
			this.tabPageYouTube.Controls.Add(this.textBoxYtCategories);
			this.tabPageYouTube.Controls.Add(this.labelYtCategories);
			this.tabPageYouTube.Controls.Add(this.groupBoxYt2);
			this.tabPageYouTube.Controls.Add(this.textBoxYtPassword);
			this.tabPageYouTube.Controls.Add(this.labelYtPassword);
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
			// groupBoxYt2
			// 
			this.groupBoxYt2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxYt2.Controls.Add(this.labelYt2Key);
			this.groupBoxYt2.Controls.Add(this.textBoxYt2Key);
			this.groupBoxYt2.Location = new System.Drawing.Point(6, 65);
			this.groupBoxYt2.Name = "groupBoxYt2";
			this.groupBoxYt2.Size = new System.Drawing.Size(574, 53);
			this.groupBoxYt2.TabIndex = 7;
			this.groupBoxYt2.TabStop = false;
			this.groupBoxYt2.Text = "API version 2";
			// 
			// labelYt2Key
			// 
			this.labelYt2Key.AutoSize = true;
			this.labelYt2Key.Location = new System.Drawing.Point(10, 22);
			this.labelYt2Key.Name = "labelYt2Key";
			this.labelYt2Key.Size = new System.Drawing.Size(28, 13);
			this.labelYt2Key.TabIndex = 8;
			this.labelYt2Key.Text = "&Key:";
			// 
			// textBoxYt2Key
			// 
			this.textBoxYt2Key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxYt2Key.Location = new System.Drawing.Point(144, 19);
			this.textBoxYt2Key.Name = "textBoxYt2Key";
			this.textBoxYt2Key.SecureText = secureString1;
			this.textBoxYt2Key.Size = new System.Drawing.Size(424, 20);
			this.textBoxYt2Key.TabIndex = 7;
			this.textBoxYt2Key.UseSystemPasswordChar = true;
			this.textBoxYt2Key.TextChanged += new System.EventHandler(this.OnSettingsChanged);
			// 
			// textBoxYtPassword
			// 
			this.textBoxYtPassword.Location = new System.Drawing.Point(150, 39);
			this.textBoxYtPassword.Name = "textBoxYtPassword";
			this.textBoxYtPassword.SecureText = secureString2;
			this.textBoxYtPassword.Size = new System.Drawing.Size(150, 20);
			this.textBoxYtPassword.TabIndex = 6;
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
			// textBoxYtUserName
			// 
			this.textBoxYtUserName.Location = new System.Drawing.Point(150, 13);
			this.textBoxYtUserName.Name = "textBoxYtUserName";
			this.textBoxYtUserName.Size = new System.Drawing.Size(150, 20);
			this.textBoxYtUserName.TabIndex = 3;
			this.textBoxYtUserName.TextChanged += new System.EventHandler(this.OnSettingsChanged);
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
			// labelLogFile
			// 
			this.labelLogFile.AutoSize = true;
			this.labelLogFile.Location = new System.Drawing.Point(16, 16);
			this.labelLogFile.Name = "labelLogFile";
			this.labelLogFile.Size = new System.Drawing.Size(44, 13);
			this.labelLogFile.TabIndex = 3;
			this.labelLogFile.Text = "&Log file:";
			// 
			// tabPageComments
			// 
			this.tabPageComments.Controls.Add(this.labelPlaylistCommentsFile);
			this.tabPageComments.Controls.Add(this.textBoxPlaylistCommentsFile);
			this.tabPageComments.Controls.Add(this.textBoxUserCommentsFile);
			this.tabPageComments.Controls.Add(this.labelUserCommentsFile);
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
			// labelPlaylistCommentsFile
			// 
			this.labelPlaylistCommentsFile.AutoSize = true;
			this.labelPlaylistCommentsFile.Location = new System.Drawing.Point(16, 68);
			this.labelPlaylistCommentsFile.Name = "labelPlaylistCommentsFile";
			this.labelPlaylistCommentsFile.Size = new System.Drawing.Size(109, 13);
			this.labelPlaylistCommentsFile.TabIndex = 9;
			this.labelPlaylistCommentsFile.Text = "&Playlist comments file:";
			// 
			// textBoxPlaylistCommentsFile
			// 
			this.textBoxPlaylistCommentsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPlaylistCommentsFile.Location = new System.Drawing.Point(150, 65);
			this.textBoxPlaylistCommentsFile.Name = "textBoxPlaylistCommentsFile";
			this.textBoxPlaylistCommentsFile.ReadOnly = true;
			this.textBoxPlaylistCommentsFile.Size = new System.Drawing.Size(430, 20);
			this.textBoxPlaylistCommentsFile.TabIndex = 8;
			// 
			// textBoxUserCommentsFile
			// 
			this.textBoxUserCommentsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUserCommentsFile.Location = new System.Drawing.Point(150, 39);
			this.textBoxUserCommentsFile.Name = "textBoxUserCommentsFile";
			this.textBoxUserCommentsFile.ReadOnly = true;
			this.textBoxUserCommentsFile.Size = new System.Drawing.Size(430, 20);
			this.textBoxUserCommentsFile.TabIndex = 7;
			// 
			// labelUserCommentsFile
			// 
			this.labelUserCommentsFile.AutoSize = true;
			this.labelUserCommentsFile.Location = new System.Drawing.Point(16, 42);
			this.labelUserCommentsFile.Name = "labelUserCommentsFile";
			this.labelUserCommentsFile.Size = new System.Drawing.Size(99, 13);
			this.labelUserCommentsFile.TabIndex = 6;
			this.labelUserCommentsFile.Text = "&User comments file:";
			// 
			// textBoxVideoCommentsFile
			// 
			this.textBoxVideoCommentsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxVideoCommentsFile.Location = new System.Drawing.Point(150, 13);
			this.textBoxVideoCommentsFile.Name = "textBoxVideoCommentsFile";
			this.textBoxVideoCommentsFile.ReadOnly = true;
			this.textBoxVideoCommentsFile.Size = new System.Drawing.Size(430, 20);
			this.textBoxVideoCommentsFile.TabIndex = 5;
			this.textBoxVideoCommentsFile.TextChanged += new System.EventHandler(this.OnSettingsChanged);
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
			// labelYtCategories
			// 
			this.labelYtCategories.AutoSize = true;
			this.labelYtCategories.Location = new System.Drawing.Point(16, 127);
			this.labelYtCategories.Name = "labelYtCategories";
			this.labelYtCategories.Size = new System.Drawing.Size(76, 13);
			this.labelYtCategories.TabIndex = 8;
			this.labelYtCategories.Text = "&Categories file:";
			// 
			// textBoxYtCategories
			// 
			this.textBoxYtCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxYtCategories.Location = new System.Drawing.Point(150, 124);
			this.textBoxYtCategories.Name = "textBoxYtCategories";
			this.textBoxYtCategories.ReadOnly = true;
			this.textBoxYtCategories.Size = new System.Drawing.Size(424, 20);
			this.textBoxYtCategories.TabIndex = 9;
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
			((System.ComponentModel.ISupportInitialize)(this.numericMessageCloseDelay)).EndInit();
			this.tabPageYouTube.ResumeLayout(false);
			this.tabPageYouTube.PerformLayout();
			this.groupBoxYt2.ResumeLayout(false);
			this.groupBoxYt2.PerformLayout();
			this.tabPageLog.ResumeLayout(false);
			this.tabPageLog.PerformLayout();
			this.tabPageComments.ResumeLayout(false);
			this.tabPageComments.PerformLayout();
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
		private System.Windows.Forms.Label labelYtPassword;
		private System.Windows.Forms.Label labelLogFile;
		private System.Windows.Forms.TextBox textBoxLogFile;
		private System.Windows.Forms.Label labelVideoCommentsFile;
		private System.Windows.Forms.TextBox textBoxVideoCommentsFile;
		private System.Windows.Forms.Label labelPlaylistCommentsFile;
		private System.Windows.Forms.TextBox textBoxPlaylistCommentsFile;
		private System.Windows.Forms.TextBox textBoxUserCommentsFile;
		private System.Windows.Forms.Label labelUserCommentsFile;
		private DotNetApi.Windows.Controls.SecureTextBox textBoxYtPassword;
		private System.Windows.Forms.GroupBox groupBoxYt2;
		private DotNetApi.Windows.Controls.SecureTextBox textBoxYt2Key;
		private System.Windows.Forms.Label labelYt2Key;
		private System.Windows.Forms.TextBox textBoxYtCategories;
		private System.Windows.Forms.Label labelYtCategories;
	}
}
