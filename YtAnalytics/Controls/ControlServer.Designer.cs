namespace YtAnalytics.Controls
{
	partial class ControlServer
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
			// Clear the items such that database events do not call handles on disposed components.
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
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.panel = new System.Windows.Forms.Panel();
			this.labelPrimary = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageDatabase = new System.Windows.Forms.TabPage();
			this.tabPageTable = new System.Windows.Forms.TabPage();
			this.pictureBoxDatabase = new System.Windows.Forms.PictureBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.buttonConnect = new System.Windows.Forms.ToolStripButton();
			this.buttonDisconnect = new System.Windows.Forms.ToolStripButton();
			this.buttonPrimary = new System.Windows.Forms.ToolStripButton();
			this.buttonChangePassword = new System.Windows.Forms.ToolStripButton();
			this.buttonProperties = new System.Windows.Forms.ToolStripButton();
			this.labelDatabaseTitle = new System.Windows.Forms.Label();
			this.labelDatabaseCurrent = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonDatabaseProperties = new System.Windows.Forms.Button();
			this.gridDatabase = new System.Windows.Forms.DataGridView();
			this.labelDatabaseSelect = new System.Windows.Forms.Label();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.log = new YtAnalytics.Controls.ControlLogList();
			this.ColumnSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageDatabase.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatabase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridDatabase)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonConnect,
            this.buttonDisconnect,
            this.toolStripSeparator1,
            this.buttonPrimary,
            this.toolStripSeparator2,
            this.buttonChangePassword,
            this.toolStripSeparator3,
            this.buttonProperties});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// splitContainer
			// 
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.panel);
			this.splitContainer.Panel1.Controls.Add(this.toolStrip);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.TabIndex = 1;
			// 
			// panel
			// 
			this.panel.AutoScroll = true;
			this.panel.Controls.Add(this.tabControl);
			this.panel.Controls.Add(this.labelPrimary);
			this.panel.Controls.Add(this.labelName);
			this.panel.Controls.Add(this.pictureBox);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 25);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(798, 398);
			this.panel.TabIndex = 0;
			// 
			// labelPrimary
			// 
			this.labelPrimary.AutoSize = true;
			this.labelPrimary.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.labelPrimary.Location = new System.Drawing.Point(65, 37);
			this.labelPrimary.Name = "labelPrimary";
			this.labelPrimary.Size = new System.Drawing.Size(73, 13);
			this.labelPrimary.TabIndex = 1;
			this.labelPrimary.Text = "Primary server";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelName.Location = new System.Drawing.Point(64, 16);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(99, 20);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Server name";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageDatabase);
			this.tabControl.Controls.Add(this.tabPageTable);
			this.tabControl.Location = new System.Drawing.Point(10, 64);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(780, 325);
			this.tabControl.TabIndex = 2;
			// 
			// tabPageDatabase
			// 
			this.tabPageDatabase.Controls.Add(this.buttonRefresh);
			this.tabPageDatabase.Controls.Add(this.labelDatabaseSelect);
			this.tabPageDatabase.Controls.Add(this.gridDatabase);
			this.tabPageDatabase.Controls.Add(this.buttonDatabaseProperties);
			this.tabPageDatabase.Controls.Add(this.textBox1);
			this.tabPageDatabase.Controls.Add(this.labelDatabaseCurrent);
			this.tabPageDatabase.Controls.Add(this.labelDatabaseTitle);
			this.tabPageDatabase.Controls.Add(this.pictureBoxDatabase);
			this.tabPageDatabase.Location = new System.Drawing.Point(4, 22);
			this.tabPageDatabase.Name = "tabPageDatabase";
			this.tabPageDatabase.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDatabase.Size = new System.Drawing.Size(772, 299);
			this.tabPageDatabase.TabIndex = 0;
			this.tabPageDatabase.Text = "Database";
			this.tabPageDatabase.UseVisualStyleBackColor = true;
			// 
			// tabPageTable
			// 
			this.tabPageTable.Location = new System.Drawing.Point(4, 22);
			this.tabPageTable.Name = "tabPageTable";
			this.tabPageTable.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTable.Size = new System.Drawing.Size(772, 299);
			this.tabPageTable.TabIndex = 1;
			this.tabPageTable.Text = "Table";
			this.tabPageTable.UseVisualStyleBackColor = true;
			// 
			// pictureBoxDatabase
			// 
			this.pictureBoxDatabase.Image = global::YtAnalytics.Resources.Database_32;
			this.pictureBoxDatabase.Location = new System.Drawing.Point(20, 20);
			this.pictureBoxDatabase.Name = "pictureBoxDatabase";
			this.pictureBoxDatabase.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxDatabase.TabIndex = 1;
			this.pictureBoxDatabase.TabStop = false;
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.ServerDown_48;
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// buttonConnect
			// 
			this.buttonConnect.Enabled = false;
			this.buttonConnect.Image = global::YtAnalytics.Resources.Connect_16;
			this.buttonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(72, 22);
			this.buttonConnect.Text = "&Connect";
			this.buttonConnect.Click += new System.EventHandler(this.OnConnect);
			// 
			// buttonDisconnect
			// 
			this.buttonDisconnect.Enabled = false;
			this.buttonDisconnect.Image = global::YtAnalytics.Resources.Disconnect_16;
			this.buttonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonDisconnect.Name = "buttonDisconnect";
			this.buttonDisconnect.Size = new System.Drawing.Size(86, 22);
			this.buttonDisconnect.Text = "&Disconnect";
			this.buttonDisconnect.Click += new System.EventHandler(this.OnDisconnect);
			// 
			// buttonPrimary
			// 
			this.buttonPrimary.Enabled = false;
			this.buttonPrimary.Image = global::YtAnalytics.Resources.ServerStar_16;
			this.buttonPrimary.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonPrimary.Name = "buttonPrimary";
			this.buttonPrimary.Size = new System.Drawing.Size(100, 22);
			this.buttonPrimary.Text = "Make &primary";
			this.buttonPrimary.Click += new System.EventHandler(this.OnMakePrimary);
			// 
			// buttonChangePassword
			// 
			this.buttonChangePassword.Image = global::YtAnalytics.Resources.PasswordChange_16;
			this.buttonChangePassword.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonChangePassword.Name = "buttonChangePassword";
			this.buttonChangePassword.Size = new System.Drawing.Size(121, 22);
			this.buttonChangePassword.Text = "Cha&nge password";
			this.buttonChangePassword.Click += new System.EventHandler(this.OnChangePassword);
			// 
			// buttonProperties
			// 
			this.buttonProperties.Image = global::YtAnalytics.Resources.Properties_16;
			this.buttonProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonProperties.Name = "buttonProperties";
			this.buttonProperties.Size = new System.Drawing.Size(80, 22);
			this.buttonProperties.Text = "P&roperties";
			this.buttonProperties.Click += new System.EventHandler(this.OnProperties);
			// 
			// labelDatabaseTitle
			// 
			this.labelDatabaseTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelDatabaseTitle.Location = new System.Drawing.Point(59, 20);
			this.labelDatabaseTitle.Name = "labelDatabaseTitle";
			this.labelDatabaseTitle.Size = new System.Drawing.Size(707, 32);
			this.labelDatabaseTitle.TabIndex = 0;
			this.labelDatabaseTitle.Text = "Use this tab to select the SQL database you want to use for storing the YouTube d" +
    "ata.";
			this.labelDatabaseTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDatabaseCurrent
			// 
			this.labelDatabaseCurrent.AutoSize = true;
			this.labelDatabaseCurrent.Location = new System.Drawing.Point(17, 58);
			this.labelDatabaseCurrent.Name = "labelDatabaseCurrent";
			this.labelDatabaseCurrent.Size = new System.Drawing.Size(122, 13);
			this.labelDatabaseCurrent.TabIndex = 1;
			this.labelDatabaseCurrent.Text = "The &current database is:";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(145, 55);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(500, 20);
			this.textBox1.TabIndex = 2;
			// 
			// buttonDatabaseProperties
			// 
			this.buttonDatabaseProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDatabaseProperties.Image = global::YtAnalytics.Resources.Properties_16;
			this.buttonDatabaseProperties.Location = new System.Drawing.Point(651, 53);
			this.buttonDatabaseProperties.Name = "buttonDatabaseProperties";
			this.buttonDatabaseProperties.Size = new System.Drawing.Size(95, 23);
			this.buttonDatabaseProperties.TabIndex = 3;
			this.buttonDatabaseProperties.Text = "&Properties";
			this.buttonDatabaseProperties.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonDatabaseProperties.UseVisualStyleBackColor = true;
			// 
			// gridDatabase
			// 
			this.gridDatabase.AllowUserToAddRows = false;
			this.gridDatabase.AllowUserToDeleteRows = false;
			this.gridDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDatabase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridDatabase.BackgroundColor = System.Drawing.SystemColors.Window;
			this.gridDatabase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.gridDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridDatabase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSelected,
            this.ColumnName,
            this.ColumnId,
            this.ColumnDate});
			this.gridDatabase.Location = new System.Drawing.Point(145, 82);
			this.gridDatabase.Name = "gridDatabase";
			this.gridDatabase.ReadOnly = true;
			this.gridDatabase.Size = new System.Drawing.Size(500, 211);
			this.gridDatabase.TabIndex = 5;
			// 
			// labelDatabaseSelect
			// 
			this.labelDatabaseSelect.AutoSize = true;
			this.labelDatabaseSelect.Location = new System.Drawing.Point(17, 87);
			this.labelDatabaseSelect.Name = "labelDatabaseSelect";
			this.labelDatabaseSelect.Size = new System.Drawing.Size(96, 13);
			this.labelDatabaseSelect.TabIndex = 4;
			this.labelDatabaseSelect.Text = "&Select a database:";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefresh.Image = global::YtAnalytics.Resources.Refresh_16;
			this.buttonRefresh.Location = new System.Drawing.Point(651, 82);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(95, 23);
			this.buttonRefresh.TabIndex = 6;
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(798, 169);
			this.log.TabIndex = 0;
			// 
			// ColumnSelected
			// 
			this.ColumnSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.ColumnSelected.HeaderText = "Selected";
			this.ColumnSelected.Name = "ColumnSelected";
			this.ColumnSelected.ReadOnly = true;
			this.ColumnSelected.Width = 60;
			// 
			// ColumnName
			// 
			this.ColumnName.HeaderText = "Name";
			this.ColumnName.Name = "ColumnName";
			this.ColumnName.ReadOnly = true;
			// 
			// ColumnId
			// 
			this.ColumnId.HeaderText = "ID";
			this.ColumnId.Name = "ColumnId";
			this.ColumnId.ReadOnly = true;
			// 
			// ColumnDate
			// 
			this.ColumnDate.HeaderText = "Creation date";
			this.ColumnDate.Name = "ColumnDate";
			this.ColumnDate.ReadOnly = true;
			// 
			// ControlServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "ControlServer";
			this.Size = new System.Drawing.Size(800, 600);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageDatabase.ResumeLayout(false);
			this.tabPageDatabase.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDatabase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridDatabase)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.SplitContainer splitContainer;
		private ControlLogList log;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton buttonPrimary;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton buttonConnect;
		private System.Windows.Forms.ToolStripButton buttonDisconnect;
		private System.Windows.Forms.ToolStripButton buttonChangePassword;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton buttonProperties;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelPrimary;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageDatabase;
		private System.Windows.Forms.TabPage tabPageTable;
		private System.Windows.Forms.PictureBox pictureBoxDatabase;
		private System.Windows.Forms.Label labelDatabaseTitle;
		private System.Windows.Forms.Label labelDatabaseCurrent;
		private System.Windows.Forms.Button buttonDatabaseProperties;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGridView gridDatabase;
		private System.Windows.Forms.Label labelDatabaseSelect;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSelected;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
	}
}
