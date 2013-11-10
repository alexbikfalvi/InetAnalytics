namespace InetAnalytics.Controls.Testing
{
	partial class ControlTestingSshRequest
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
			if (disposing)
			{
				// Dispose the components.
				if (null != this.components)
				{
					this.components.Dispose();
				}
			}
			// Call the base class method.
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Security.SecureString secureString1 = new System.Security.SecureString();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlTestingSshRequest));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelTesting = new DotNetApi.Windows.Controls.ThemeControl();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageAuthentication = new System.Windows.Forms.TabPage();
			this.buttonLoadKey = new System.Windows.Forms.Button();
			this.secureTextBoxPassword = new DotNetApi.Windows.Controls.SecureTextBox();
			this.textBoxKey = new System.Windows.Forms.TextBox();
			this.labelKey = new System.Windows.Forms.Label();
			this.radioKeyAuthentication = new System.Windows.Forms.RadioButton();
			this.labelPassword = new System.Windows.Forms.Label();
			this.textBoxUsername = new System.Windows.Forms.TextBox();
			this.labelUsername = new System.Windows.Forms.Label();
			this.radioPasswordAuthentication = new System.Windows.Forms.RadioButton();
			this.tabPageConsole = new System.Windows.Forms.TabPage();
			this.console = new InetAnalytics.Controls.ControlConsole();
			this.buttonExport = new System.Windows.Forms.Button();
			this.buttonImport = new System.Windows.Forms.Button();
			this.buttonUndo = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxServer = new System.Windows.Forms.TextBox();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.buttonDisconnect = new System.Windows.Forms.Button();
			this.labelServer = new System.Windows.Forms.Label();
			this.log = new InetAnalytics.Controls.Log.ControlLogList();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelTesting.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageAuthentication.SuspendLayout();
			this.tabPageConsole.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.panelTesting);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 2;
			// 
			// panelTesting
			// 
			this.panelTesting.Controls.Add(this.tabControl);
			this.panelTesting.Controls.Add(this.buttonExport);
			this.panelTesting.Controls.Add(this.buttonImport);
			this.panelTesting.Controls.Add(this.buttonUndo);
			this.panelTesting.Controls.Add(this.buttonSave);
			this.panelTesting.Controls.Add(this.textBoxServer);
			this.panelTesting.Controls.Add(this.buttonConnect);
			this.panelTesting.Controls.Add(this.buttonDisconnect);
			this.panelTesting.Controls.Add(this.labelServer);
			this.panelTesting.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTesting.Location = new System.Drawing.Point(0, 0);
			this.panelTesting.Name = "panelTesting";
			this.panelTesting.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.panelTesting.ShowBorder = true;
			this.panelTesting.ShowTitle = true;
			this.panelTesting.Size = new System.Drawing.Size(600, 225);
			this.panelTesting.TabIndex = 0;
			this.panelTesting.Title = "Secure Shell Testing";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageAuthentication);
			this.tabControl.Controls.Add(this.tabPageConsole);
			this.tabControl.Location = new System.Drawing.Point(7, 52);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(508, 169);
			this.tabControl.TabIndex = 4;
			// 
			// tabPageAuthentication
			// 
			this.tabPageAuthentication.AutoScroll = true;
			this.tabPageAuthentication.Controls.Add(this.buttonLoadKey);
			this.tabPageAuthentication.Controls.Add(this.secureTextBoxPassword);
			this.tabPageAuthentication.Controls.Add(this.textBoxKey);
			this.tabPageAuthentication.Controls.Add(this.labelKey);
			this.tabPageAuthentication.Controls.Add(this.radioKeyAuthentication);
			this.tabPageAuthentication.Controls.Add(this.labelPassword);
			this.tabPageAuthentication.Controls.Add(this.textBoxUsername);
			this.tabPageAuthentication.Controls.Add(this.labelUsername);
			this.tabPageAuthentication.Controls.Add(this.radioPasswordAuthentication);
			this.tabPageAuthentication.Location = new System.Drawing.Point(4, 22);
			this.tabPageAuthentication.Name = "tabPageAuthentication";
			this.tabPageAuthentication.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAuthentication.Size = new System.Drawing.Size(500, 143);
			this.tabPageAuthentication.TabIndex = 0;
			this.tabPageAuthentication.Text = "Authentication";
			this.tabPageAuthentication.UseVisualStyleBackColor = true;
			// 
			// buttonLoadKey
			// 
			this.buttonLoadKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoadKey.Enabled = false;
			this.buttonLoadKey.Location = new System.Drawing.Point(419, 108);
			this.buttonLoadKey.Name = "buttonLoadKey";
			this.buttonLoadKey.Size = new System.Drawing.Size(75, 23);
			this.buttonLoadKey.TabIndex = 8;
			this.buttonLoadKey.Text = "&Load";
			this.buttonLoadKey.UseVisualStyleBackColor = true;
			this.buttonLoadKey.Click += new System.EventHandler(this.OnLoadKey);
			// 
			// secureTextBoxPassword
			// 
			this.secureTextBoxPassword.Location = new System.Drawing.Point(110, 59);
			this.secureTextBoxPassword.Name = "secureTextBoxPassword";
			this.secureTextBoxPassword.SecureText = secureString1;
			this.secureTextBoxPassword.Size = new System.Drawing.Size(214, 20);
			this.secureTextBoxPassword.TabIndex = 4;
			this.secureTextBoxPassword.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// textBoxKey
			// 
			this.textBoxKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxKey.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxKey.Location = new System.Drawing.Point(110, 108);
			this.textBoxKey.Multiline = true;
			this.textBoxKey.Name = "textBoxKey";
			this.textBoxKey.ReadOnly = true;
			this.textBoxKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxKey.Size = new System.Drawing.Size(303, 29);
			this.textBoxKey.TabIndex = 7;
			this.textBoxKey.WordWrap = false;
			this.textBoxKey.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// labelKey
			// 
			this.labelKey.AutoSize = true;
			this.labelKey.Location = new System.Drawing.Point(6, 111);
			this.labelKey.Name = "labelKey";
			this.labelKey.Size = new System.Drawing.Size(28, 13);
			this.labelKey.TabIndex = 6;
			this.labelKey.Text = "K&ey:";
			// 
			// radioKeyAuthentication
			// 
			this.radioKeyAuthentication.AutoSize = true;
			this.radioKeyAuthentication.Location = new System.Drawing.Point(6, 85);
			this.radioKeyAuthentication.Name = "radioKeyAuthentication";
			this.radioKeyAuthentication.Size = new System.Drawing.Size(113, 17);
			this.radioKeyAuthentication.TabIndex = 5;
			this.radioKeyAuthentication.Text = "&Key authentication";
			this.radioKeyAuthentication.UseVisualStyleBackColor = true;
			// 
			// labelPassword
			// 
			this.labelPassword.AutoSize = true;
			this.labelPassword.Location = new System.Drawing.Point(6, 62);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(56, 13);
			this.labelPassword.TabIndex = 3;
			this.labelPassword.Text = "P&assword:";
			// 
			// textBoxUsername
			// 
			this.textBoxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUsername.Location = new System.Drawing.Point(110, 10);
			this.textBoxUsername.Name = "textBoxUsername";
			this.textBoxUsername.Size = new System.Drawing.Size(214, 20);
			this.textBoxUsername.TabIndex = 1;
			this.textBoxUsername.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// labelUsername
			// 
			this.labelUsername.AutoSize = true;
			this.labelUsername.Location = new System.Drawing.Point(6, 13);
			this.labelUsername.Name = "labelUsername";
			this.labelUsername.Size = new System.Drawing.Size(61, 13);
			this.labelUsername.TabIndex = 0;
			this.labelUsername.Text = "&User name:";
			// 
			// radioPasswordAuthentication
			// 
			this.radioPasswordAuthentication.AutoSize = true;
			this.radioPasswordAuthentication.Checked = true;
			this.radioPasswordAuthentication.Location = new System.Drawing.Point(6, 36);
			this.radioPasswordAuthentication.Name = "radioPasswordAuthentication";
			this.radioPasswordAuthentication.Size = new System.Drawing.Size(141, 17);
			this.radioPasswordAuthentication.TabIndex = 2;
			this.radioPasswordAuthentication.TabStop = true;
			this.radioPasswordAuthentication.Text = "&Password authentication";
			this.radioPasswordAuthentication.UseVisualStyleBackColor = true;
			this.radioPasswordAuthentication.CheckedChanged += new System.EventHandler(this.OnAuthenticationChanged);
			// 
			// tabPageConsole
			// 
			this.tabPageConsole.Controls.Add(this.console);
			this.tabPageConsole.Location = new System.Drawing.Point(4, 22);
			this.tabPageConsole.Name = "tabPageConsole";
			this.tabPageConsole.Size = new System.Drawing.Size(500, 143);
			this.tabPageConsole.TabIndex = 1;
			this.tabPageConsole.Text = "Console";
			this.tabPageConsole.UseVisualStyleBackColor = true;
			// 
			// console
			// 
			this.console.ButtonImage = ((System.Drawing.Image)(resources.GetObject("console.ButtonImage")));
			this.console.Dock = System.Windows.Forms.DockStyle.Fill;
			this.console.Location = new System.Drawing.Point(0, 0);
			this.console.Name = "console";
			this.console.Size = new System.Drawing.Size(500, 143);
			this.console.TabIndex = 0;
			this.console.Execute += new System.EventHandler(this.OnExecuteCommand);
			this.console.Cancel += new System.EventHandler(this.OnCancelCommand);
			// 
			// buttonExport
			// 
			this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExport.Location = new System.Drawing.Point(521, 170);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(75, 23);
			this.buttonExport.TabIndex = 7;
			this.buttonExport.Text = "&Export";
			this.buttonExport.UseVisualStyleBackColor = true;
			// 
			// buttonImport
			// 
			this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonImport.Location = new System.Drawing.Point(521, 198);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(75, 23);
			this.buttonImport.TabIndex = 8;
			this.buttonImport.Text = "&Import";
			this.buttonImport.UseVisualStyleBackColor = true;
			// 
			// buttonUndo
			// 
			this.buttonUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUndo.Enabled = false;
			this.buttonUndo.Location = new System.Drawing.Point(521, 82);
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.Size = new System.Drawing.Size(75, 23);
			this.buttonUndo.TabIndex = 6;
			this.buttonUndo.Text = "&Undo";
			this.buttonUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonUndo.UseVisualStyleBackColor = true;
			this.buttonUndo.Click += new System.EventHandler(this.OnUndo);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(521, 53);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "&Save";
			this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.OnSave);
			// 
			// textBoxServer
			// 
			this.textBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxServer.Location = new System.Drawing.Point(80, 26);
			this.textBoxServer.Name = "textBoxServer";
			this.textBoxServer.Size = new System.Drawing.Size(354, 20);
			this.textBoxServer.TabIndex = 1;
			this.textBoxServer.TextChanged += new System.EventHandler(this.OnChanged);
			// 
			// buttonConnect
			// 
			this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonConnect.Enabled = false;
			this.buttonConnect.Image = global::InetAnalytics.Resources.Connect_16;
			this.buttonConnect.Location = new System.Drawing.Point(440, 24);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(75, 23);
			this.buttonConnect.TabIndex = 2;
			this.buttonConnect.Text = "&Connect";
			this.buttonConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonConnect.UseVisualStyleBackColor = true;
			this.buttonConnect.Click += new System.EventHandler(this.OnConnect);
			// 
			// buttonDisconnect
			// 
			this.buttonDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDisconnect.Enabled = false;
			this.buttonDisconnect.Location = new System.Drawing.Point(521, 24);
			this.buttonDisconnect.Name = "buttonDisconnect";
			this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
			this.buttonDisconnect.TabIndex = 3;
			this.buttonDisconnect.Text = "&Disconnect";
			this.buttonDisconnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonDisconnect.UseVisualStyleBackColor = true;
			this.buttonDisconnect.Click += new System.EventHandler(this.OnDisconnect);
			// 
			// labelServer
			// 
			this.labelServer.AutoSize = true;
			this.labelServer.Location = new System.Drawing.Point(4, 29);
			this.labelServer.Name = "labelServer";
			this.labelServer.Size = new System.Drawing.Size(41, 13);
			this.labelServer.TabIndex = 0;
			this.labelServer.Text = "&Server:";
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
			this.log.ShowBorder = true;
			this.log.ShowTitle = true;
			this.log.Size = new System.Drawing.Size(600, 170);
			this.log.TabIndex = 0;
			this.log.Title = "Log";
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Header_16.png");
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Title = "Export Settings";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "XML files (*.xml)|*.xml";
			this.openFileDialog.Title = "Import Settings";
			// 
			// ControlTestingSshRequest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlTestingSshRequest";
			this.Size = new System.Drawing.Size(600, 400);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelTesting.ResumeLayout(false);
			this.panelTesting.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageAuthentication.ResumeLayout(false);
			this.tabPageAuthentication.PerformLayout();
			this.tabPageConsole.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private Log.ControlLogList log;
		private DotNetApi.Windows.Controls.ThemeControl panelTesting;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button buttonExport;
		private System.Windows.Forms.Button buttonImport;
		private System.Windows.Forms.Button buttonUndo;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.TextBox textBoxServer;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.Button buttonDisconnect;
		private System.Windows.Forms.Label labelServer;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageAuthentication;
		private System.Windows.Forms.RadioButton radioPasswordAuthentication;
		private System.Windows.Forms.Label labelUsername;
		private System.Windows.Forms.TextBox textBoxUsername;
		private System.Windows.Forms.Label labelPassword;
		private System.Windows.Forms.RadioButton radioKeyAuthentication;
		private System.Windows.Forms.TextBox textBoxKey;
		private System.Windows.Forms.Label labelKey;
		private DotNetApi.Windows.Controls.SecureTextBox secureTextBoxPassword;
		private System.Windows.Forms.Button buttonLoadKey;
		private System.Windows.Forms.TabPage tabPageConsole;
		private ControlConsole console;

	}
}
