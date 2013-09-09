namespace YtAnalytics.Controls.Testing
{
	partial class ControlTestingWebRequest
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlTestingWebRequest));
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.panel = new System.Windows.Forms.Panel();
			this.buttonExport = new System.Windows.Forms.Button();
			this.buttonImport = new System.Windows.Forms.Button();
			this.buttonUndo = new System.Windows.Forms.Button();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.checkBoxUserAgent = new System.Windows.Forms.CheckBox();
			this.textBoxUserAgent = new System.Windows.Forms.TextBox();
			this.checkBoxReferer = new System.Windows.Forms.CheckBox();
			this.textBoxReferer = new System.Windows.Forms.TextBox();
			this.checkBoxDate = new System.Windows.Forms.CheckBox();
			this.checkBoxExpect = new System.Windows.Forms.CheckBox();
			this.textBoxExpect = new System.Windows.Forms.TextBox();
			this.textBoxContentType = new System.Windows.Forms.TextBox();
			this.checkBoxContentType = new System.Windows.Forms.CheckBox();
			this.textBoxAccept = new System.Windows.Forms.TextBox();
			this.checkBoxAccept = new System.Windows.Forms.CheckBox();
			this.labelMethod = new System.Windows.Forms.Label();
			this.comboBoxMethod = new System.Windows.Forms.ComboBox();
			this.tabPageRequestHeaders = new System.Windows.Forms.TabPage();
			this.listViewRequestHeaders = new System.Windows.Forms.ListView();
			this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.buttonChangeHeader = new System.Windows.Forms.Button();
			this.buttonAddHeader = new System.Windows.Forms.Button();
			this.buttonRemoveHeader = new System.Windows.Forms.Button();
			this.tabPageRequestData = new System.Windows.Forms.TabPage();
			this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
			this.labelEncoding = new System.Windows.Forms.Label();
			this.textBoxRequestData = new System.Windows.Forms.TextBox();
			this.tabPageResponseHeaders = new System.Windows.Forms.TabPage();
			this.buttonViewHeader = new System.Windows.Forms.Button();
			this.listViewResponseHeaders = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageResponseData = new System.Windows.Forms.TabPage();
			this.textBoxResponseData = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.labelUrl = new System.Windows.Forms.Label();
			this.log = new YtAnalytics.Controls.Log.ControlLogList();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panel.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageRequestHeaders.SuspendLayout();
			this.tabPageRequestData.SuspendLayout();
			this.tabPageResponseHeaders.SuspendLayout();
			this.tabPageResponseData.SuspendLayout();
			this.SuspendLayout();
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
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.log);
			this.splitContainer.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.SplitterDistance = 225;
			this.splitContainer.TabIndex = 2;
			// 
			// panel
			// 
			this.panel.Controls.Add(this.buttonExport);
			this.panel.Controls.Add(this.buttonImport);
			this.panel.Controls.Add(this.buttonUndo);
			this.panel.Controls.Add(this.tabControl);
			this.panel.Controls.Add(this.buttonSave);
			this.panel.Controls.Add(this.textBoxUrl);
			this.panel.Controls.Add(this.buttonStart);
			this.panel.Controls.Add(this.buttonStop);
			this.panel.Controls.Add(this.labelUrl);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(598, 223);
			this.panel.TabIndex = 0;
			// 
			// buttonExport
			// 
			this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExport.Location = new System.Drawing.Point(520, 169);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.Size = new System.Drawing.Size(75, 23);
			this.buttonExport.TabIndex = 7;
			this.buttonExport.Text = "&Export";
			this.buttonExport.UseVisualStyleBackColor = true;
			this.buttonExport.Click += new System.EventHandler(this.OnExport);
			// 
			// buttonImport
			// 
			this.buttonImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonImport.Location = new System.Drawing.Point(520, 197);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new System.Drawing.Size(75, 23);
			this.buttonImport.TabIndex = 8;
			this.buttonImport.Text = "&Import";
			this.buttonImport.UseVisualStyleBackColor = true;
			this.buttonImport.Click += new System.EventHandler(this.OnImport);
			// 
			// buttonUndo
			// 
			this.buttonUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUndo.Enabled = false;
			this.buttonUndo.Location = new System.Drawing.Point(520, 60);
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.Size = new System.Drawing.Size(75, 23);
			this.buttonUndo.TabIndex = 6;
			this.buttonUndo.Text = "&Undo";
			this.buttonUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonUndo.UseVisualStyleBackColor = true;
			this.buttonUndo.Click += new System.EventHandler(this.OnUndo);
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageRequestHeaders);
			this.tabControl.Controls.Add(this.tabPageRequestData);
			this.tabControl.Controls.Add(this.tabPageResponseHeaders);
			this.tabControl.Controls.Add(this.tabPageResponseData);
			this.tabControl.Location = new System.Drawing.Point(6, 30);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(508, 190);
			this.tabControl.TabIndex = 4;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.AutoScroll = true;
			this.tabPageGeneral.Controls.Add(this.dateTimePicker);
			this.tabPageGeneral.Controls.Add(this.checkBoxUserAgent);
			this.tabPageGeneral.Controls.Add(this.textBoxUserAgent);
			this.tabPageGeneral.Controls.Add(this.checkBoxReferer);
			this.tabPageGeneral.Controls.Add(this.textBoxReferer);
			this.tabPageGeneral.Controls.Add(this.checkBoxDate);
			this.tabPageGeneral.Controls.Add(this.checkBoxExpect);
			this.tabPageGeneral.Controls.Add(this.textBoxExpect);
			this.tabPageGeneral.Controls.Add(this.textBoxContentType);
			this.tabPageGeneral.Controls.Add(this.checkBoxContentType);
			this.tabPageGeneral.Controls.Add(this.textBoxAccept);
			this.tabPageGeneral.Controls.Add(this.checkBoxAccept);
			this.tabPageGeneral.Controls.Add(this.labelMethod);
			this.tabPageGeneral.Controls.Add(this.comboBoxMethod);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(500, 164);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// dateTimePicker
			// 
			this.dateTimePicker.Location = new System.Drawing.Point(110, 89);
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker.TabIndex = 7;
			this.dateTimePicker.ValueChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// checkBoxUserAgent
			// 
			this.checkBoxUserAgent.AutoSize = true;
			this.checkBoxUserAgent.Location = new System.Drawing.Point(6, 169);
			this.checkBoxUserAgent.Name = "checkBoxUserAgent";
			this.checkBoxUserAgent.Size = new System.Drawing.Size(81, 17);
			this.checkBoxUserAgent.TabIndex = 12;
			this.checkBoxUserAgent.Text = "User agent:";
			this.checkBoxUserAgent.UseVisualStyleBackColor = true;
			this.checkBoxUserAgent.CheckedChanged += new System.EventHandler(this.OnHeaderCheckedChanged);
			// 
			// textBoxUserAgent
			// 
			this.textBoxUserAgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUserAgent.Location = new System.Drawing.Point(110, 167);
			this.textBoxUserAgent.Name = "textBoxUserAgent";
			this.textBoxUserAgent.Size = new System.Drawing.Size(214, 20);
			this.textBoxUserAgent.TabIndex = 13;
			this.textBoxUserAgent.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// checkBoxReferer
			// 
			this.checkBoxReferer.AutoSize = true;
			this.checkBoxReferer.Location = new System.Drawing.Point(6, 143);
			this.checkBoxReferer.Name = "checkBoxReferer";
			this.checkBoxReferer.Size = new System.Drawing.Size(64, 17);
			this.checkBoxReferer.TabIndex = 10;
			this.checkBoxReferer.Text = "Referer:";
			this.checkBoxReferer.UseVisualStyleBackColor = true;
			this.checkBoxReferer.CheckedChanged += new System.EventHandler(this.OnHeaderCheckedChanged);
			// 
			// textBoxReferer
			// 
			this.textBoxReferer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxReferer.Location = new System.Drawing.Point(110, 141);
			this.textBoxReferer.Name = "textBoxReferer";
			this.textBoxReferer.Size = new System.Drawing.Size(214, 20);
			this.textBoxReferer.TabIndex = 11;
			this.textBoxReferer.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// checkBoxDate
			// 
			this.checkBoxDate.AutoSize = true;
			this.checkBoxDate.Location = new System.Drawing.Point(6, 91);
			this.checkBoxDate.Name = "checkBoxDate";
			this.checkBoxDate.Size = new System.Drawing.Size(52, 17);
			this.checkBoxDate.TabIndex = 6;
			this.checkBoxDate.Text = "Date:";
			this.checkBoxDate.UseVisualStyleBackColor = true;
			this.checkBoxDate.CheckedChanged += new System.EventHandler(this.OnHeaderCheckedChanged);
			// 
			// checkBoxExpect
			// 
			this.checkBoxExpect.AutoSize = true;
			this.checkBoxExpect.Location = new System.Drawing.Point(6, 117);
			this.checkBoxExpect.Name = "checkBoxExpect";
			this.checkBoxExpect.Size = new System.Drawing.Size(62, 17);
			this.checkBoxExpect.TabIndex = 8;
			this.checkBoxExpect.Text = "Expect:";
			this.checkBoxExpect.UseVisualStyleBackColor = true;
			this.checkBoxExpect.CheckedChanged += new System.EventHandler(this.OnHeaderCheckedChanged);
			// 
			// textBoxExpect
			// 
			this.textBoxExpect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxExpect.Location = new System.Drawing.Point(110, 115);
			this.textBoxExpect.Name = "textBoxExpect";
			this.textBoxExpect.Size = new System.Drawing.Size(214, 20);
			this.textBoxExpect.TabIndex = 9;
			this.textBoxExpect.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// textBoxContentType
			// 
			this.textBoxContentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxContentType.Location = new System.Drawing.Point(110, 63);
			this.textBoxContentType.Name = "textBoxContentType";
			this.textBoxContentType.Size = new System.Drawing.Size(214, 20);
			this.textBoxContentType.TabIndex = 5;
			this.textBoxContentType.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// checkBoxContentType
			// 
			this.checkBoxContentType.AutoSize = true;
			this.checkBoxContentType.Location = new System.Drawing.Point(6, 65);
			this.checkBoxContentType.Name = "checkBoxContentType";
			this.checkBoxContentType.Size = new System.Drawing.Size(89, 17);
			this.checkBoxContentType.TabIndex = 4;
			this.checkBoxContentType.Text = "Content type:";
			this.checkBoxContentType.UseVisualStyleBackColor = true;
			this.checkBoxContentType.CheckedChanged += new System.EventHandler(this.OnHeaderCheckedChanged);
			// 
			// textBoxAccept
			// 
			this.textBoxAccept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxAccept.Location = new System.Drawing.Point(110, 37);
			this.textBoxAccept.Name = "textBoxAccept";
			this.textBoxAccept.Size = new System.Drawing.Size(214, 20);
			this.textBoxAccept.TabIndex = 3;
			this.textBoxAccept.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// checkBoxAccept
			// 
			this.checkBoxAccept.AutoSize = true;
			this.checkBoxAccept.Location = new System.Drawing.Point(6, 39);
			this.checkBoxAccept.Name = "checkBoxAccept";
			this.checkBoxAccept.Size = new System.Drawing.Size(63, 17);
			this.checkBoxAccept.TabIndex = 2;
			this.checkBoxAccept.Text = "Accept:";
			this.checkBoxAccept.UseVisualStyleBackColor = true;
			this.checkBoxAccept.CheckedChanged += new System.EventHandler(this.OnHeaderCheckedChanged);
			// 
			// labelMethod
			// 
			this.labelMethod.AutoSize = true;
			this.labelMethod.Location = new System.Drawing.Point(6, 13);
			this.labelMethod.Name = "labelMethod";
			this.labelMethod.Size = new System.Drawing.Size(46, 13);
			this.labelMethod.TabIndex = 0;
			this.labelMethod.Text = "&Method:";
			// 
			// comboBoxMethod
			// 
			this.comboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMethod.FormattingEnabled = true;
			this.comboBoxMethod.Items.AddRange(new object[] {
            "GET",
            "POST"});
			this.comboBoxMethod.Location = new System.Drawing.Point(110, 10);
			this.comboBoxMethod.Name = "comboBoxMethod";
			this.comboBoxMethod.Size = new System.Drawing.Size(150, 21);
			this.comboBoxMethod.TabIndex = 1;
			this.comboBoxMethod.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// tabPageRequestHeaders
			// 
			this.tabPageRequestHeaders.AutoScroll = true;
			this.tabPageRequestHeaders.Controls.Add(this.listViewRequestHeaders);
			this.tabPageRequestHeaders.Controls.Add(this.buttonChangeHeader);
			this.tabPageRequestHeaders.Controls.Add(this.buttonAddHeader);
			this.tabPageRequestHeaders.Controls.Add(this.buttonRemoveHeader);
			this.tabPageRequestHeaders.Location = new System.Drawing.Point(4, 22);
			this.tabPageRequestHeaders.Name = "tabPageRequestHeaders";
			this.tabPageRequestHeaders.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRequestHeaders.Size = new System.Drawing.Size(500, 164);
			this.tabPageRequestHeaders.TabIndex = 1;
			this.tabPageRequestHeaders.Text = "Request headers";
			this.tabPageRequestHeaders.UseVisualStyleBackColor = true;
			// 
			// listViewRequestHeaders
			// 
			this.listViewRequestHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewRequestHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader,
            this.columnValue});
			this.listViewRequestHeaders.FullRowSelect = true;
			this.listViewRequestHeaders.GridLines = true;
			this.listViewRequestHeaders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewRequestHeaders.HideSelection = false;
			this.listViewRequestHeaders.Location = new System.Drawing.Point(6, 6);
			this.listViewRequestHeaders.MultiSelect = false;
			this.listViewRequestHeaders.Name = "listViewRequestHeaders";
			this.listViewRequestHeaders.Size = new System.Drawing.Size(407, 152);
			this.listViewRequestHeaders.SmallImageList = this.imageList;
			this.listViewRequestHeaders.TabIndex = 0;
			this.listViewRequestHeaders.UseCompatibleStateImageBehavior = false;
			this.listViewRequestHeaders.View = System.Windows.Forms.View.Details;
			this.listViewRequestHeaders.ItemActivate += new System.EventHandler(this.OnChangeHeader);
			this.listViewRequestHeaders.SelectedIndexChanged += new System.EventHandler(this.OnRequestHeadersSelectionChanged);
			// 
			// columnHeader
			// 
			this.columnHeader.Text = "Header";
			this.columnHeader.Width = 120;
			// 
			// columnValue
			// 
			this.columnValue.Text = "Value";
			this.columnValue.Width = 170;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Header_16.png");
			// 
			// buttonChangeHeader
			// 
			this.buttonChangeHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonChangeHeader.Enabled = false;
			this.buttonChangeHeader.Location = new System.Drawing.Point(419, 64);
			this.buttonChangeHeader.Name = "buttonChangeHeader";
			this.buttonChangeHeader.Size = new System.Drawing.Size(75, 23);
			this.buttonChangeHeader.TabIndex = 3;
			this.buttonChangeHeader.Text = "&Change";
			this.buttonChangeHeader.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonChangeHeader.UseVisualStyleBackColor = true;
			this.buttonChangeHeader.Click += new System.EventHandler(this.OnChangeHeader);
			// 
			// buttonAddHeader
			// 
			this.buttonAddHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddHeader.Image = global::YtAnalytics.Resources.HeaderAdd_16;
			this.buttonAddHeader.Location = new System.Drawing.Point(419, 6);
			this.buttonAddHeader.Name = "buttonAddHeader";
			this.buttonAddHeader.Size = new System.Drawing.Size(75, 23);
			this.buttonAddHeader.TabIndex = 1;
			this.buttonAddHeader.Text = "A&dd";
			this.buttonAddHeader.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonAddHeader.UseVisualStyleBackColor = true;
			this.buttonAddHeader.Click += new System.EventHandler(this.OnAddHeader);
			// 
			// buttonRemoveHeader
			// 
			this.buttonRemoveHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemoveHeader.Enabled = false;
			this.buttonRemoveHeader.Image = global::YtAnalytics.Resources.HeaderRemove_16;
			this.buttonRemoveHeader.Location = new System.Drawing.Point(419, 35);
			this.buttonRemoveHeader.Name = "buttonRemoveHeader";
			this.buttonRemoveHeader.Size = new System.Drawing.Size(75, 23);
			this.buttonRemoveHeader.TabIndex = 2;
			this.buttonRemoveHeader.Text = "&Remove";
			this.buttonRemoveHeader.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonRemoveHeader.UseVisualStyleBackColor = true;
			this.buttonRemoveHeader.Click += new System.EventHandler(this.OnRemoveHeader);
			// 
			// tabPageRequestData
			// 
			this.tabPageRequestData.Controls.Add(this.comboBoxEncoding);
			this.tabPageRequestData.Controls.Add(this.labelEncoding);
			this.tabPageRequestData.Controls.Add(this.textBoxRequestData);
			this.tabPageRequestData.Location = new System.Drawing.Point(4, 22);
			this.tabPageRequestData.Name = "tabPageRequestData";
			this.tabPageRequestData.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRequestData.Size = new System.Drawing.Size(500, 164);
			this.tabPageRequestData.TabIndex = 2;
			this.tabPageRequestData.Text = "Request data";
			this.tabPageRequestData.UseVisualStyleBackColor = true;
			// 
			// comboBoxEncoding
			// 
			this.comboBoxEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEncoding.FormattingEnabled = true;
			this.comboBoxEncoding.Location = new System.Drawing.Point(64, 6);
			this.comboBoxEncoding.Name = "comboBoxEncoding";
			this.comboBoxEncoding.Size = new System.Drawing.Size(430, 21);
			this.comboBoxEncoding.TabIndex = 1;
			this.comboBoxEncoding.SelectedIndexChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// labelEncoding
			// 
			this.labelEncoding.AutoSize = true;
			this.labelEncoding.Location = new System.Drawing.Point(3, 9);
			this.labelEncoding.Name = "labelEncoding";
			this.labelEncoding.Size = new System.Drawing.Size(55, 13);
			this.labelEncoding.TabIndex = 0;
			this.labelEncoding.Text = "Encoding:";
			// 
			// textBoxRequestData
			// 
			this.textBoxRequestData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxRequestData.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxRequestData.Location = new System.Drawing.Point(6, 33);
			this.textBoxRequestData.Multiline = true;
			this.textBoxRequestData.Name = "textBoxRequestData";
			this.textBoxRequestData.Size = new System.Drawing.Size(488, 125);
			this.textBoxRequestData.TabIndex = 2;
			this.textBoxRequestData.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// tabPageResponseHeaders
			// 
			this.tabPageResponseHeaders.Controls.Add(this.buttonViewHeader);
			this.tabPageResponseHeaders.Controls.Add(this.listViewResponseHeaders);
			this.tabPageResponseHeaders.Location = new System.Drawing.Point(4, 22);
			this.tabPageResponseHeaders.Name = "tabPageResponseHeaders";
			this.tabPageResponseHeaders.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageResponseHeaders.Size = new System.Drawing.Size(500, 164);
			this.tabPageResponseHeaders.TabIndex = 4;
			this.tabPageResponseHeaders.Text = "Response headers";
			this.tabPageResponseHeaders.UseVisualStyleBackColor = true;
			// 
			// buttonViewHeader
			// 
			this.buttonViewHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonViewHeader.Enabled = false;
			this.buttonViewHeader.Location = new System.Drawing.Point(419, 6);
			this.buttonViewHeader.Name = "buttonViewHeader";
			this.buttonViewHeader.Size = new System.Drawing.Size(75, 23);
			this.buttonViewHeader.TabIndex = 1;
			this.buttonViewHeader.Text = "&View";
			this.buttonViewHeader.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonViewHeader.UseVisualStyleBackColor = true;
			this.buttonViewHeader.Click += new System.EventHandler(this.OnViewHeader);
			// 
			// listViewResponseHeaders
			// 
			this.listViewResponseHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewResponseHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listViewResponseHeaders.FullRowSelect = true;
			this.listViewResponseHeaders.GridLines = true;
			this.listViewResponseHeaders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewResponseHeaders.HideSelection = false;
			this.listViewResponseHeaders.Location = new System.Drawing.Point(6, 6);
			this.listViewResponseHeaders.MultiSelect = false;
			this.listViewResponseHeaders.Name = "listViewResponseHeaders";
			this.listViewResponseHeaders.Size = new System.Drawing.Size(407, 152);
			this.listViewResponseHeaders.SmallImageList = this.imageList;
			this.listViewResponseHeaders.TabIndex = 0;
			this.listViewResponseHeaders.UseCompatibleStateImageBehavior = false;
			this.listViewResponseHeaders.View = System.Windows.Forms.View.Details;
			this.listViewResponseHeaders.ItemActivate += new System.EventHandler(this.OnViewHeader);
			this.listViewResponseHeaders.SelectedIndexChanged += new System.EventHandler(this.OnResponseHeadersSelectionChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Header";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value";
			this.columnHeader2.Width = 170;
			// 
			// tabPageResponseData
			// 
			this.tabPageResponseData.Controls.Add(this.textBoxResponseData);
			this.tabPageResponseData.Location = new System.Drawing.Point(4, 22);
			this.tabPageResponseData.Name = "tabPageResponseData";
			this.tabPageResponseData.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageResponseData.Size = new System.Drawing.Size(500, 164);
			this.tabPageResponseData.TabIndex = 3;
			this.tabPageResponseData.Text = "Response data";
			this.tabPageResponseData.UseVisualStyleBackColor = true;
			// 
			// textBoxResponseData
			// 
			this.textBoxResponseData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxResponseData.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxResponseData.Location = new System.Drawing.Point(6, 6);
			this.textBoxResponseData.Multiline = true;
			this.textBoxResponseData.Name = "textBoxResponseData";
			this.textBoxResponseData.ReadOnly = true;
			this.textBoxResponseData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxResponseData.Size = new System.Drawing.Size(488, 152);
			this.textBoxResponseData.TabIndex = 0;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(520, 31);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "&Save";
			this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.OnSave);
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUrl.Location = new System.Drawing.Point(79, 4);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.Size = new System.Drawing.Size(354, 20);
			this.textBoxUrl.TabIndex = 1;
			this.textBoxUrl.TextChanged += new System.EventHandler(this.OnInputChanged);
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStart.Enabled = false;
			this.buttonStart.Image = global::YtAnalytics.Resources.PlayStart_16;
			this.buttonStart.Location = new System.Drawing.Point(439, 2);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 2;
			this.buttonStart.Text = "St&art";
			this.buttonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonStop
			// 
			this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::YtAnalytics.Resources.PlayStop_16;
			this.buttonStop.Location = new System.Drawing.Point(520, 2);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 3;
			this.buttonStop.Text = "St&op";
			this.buttonStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(3, 7);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(32, 13);
			this.labelUrl.TabIndex = 0;
			this.labelUrl.Text = "&URL:";
			// 
			// log
			// 
			this.log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.log.Location = new System.Drawing.Point(0, 0);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(598, 169);
			this.log.TabIndex = 0;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "XML files (*.xml)|*.xml";
			this.saveFileDialog.Title = "Export Settings";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "XML files (*.xml)|*.xml";
			this.openFileDialog.Title = "Import Settings";
			// 
			// ControlTestingWebRequest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlTestingWebRequest";
			this.Size = new System.Drawing.Size(600, 400);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageRequestHeaders.ResumeLayout(false);
			this.tabPageRequestData.ResumeLayout(false);
			this.tabPageRequestData.PerformLayout();
			this.tabPageResponseHeaders.ResumeLayout(false);
			this.tabPageResponseData.ResumeLayout(false);
			this.tabPageResponseData.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private Log.ControlLogList log;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.TextBox textBoxUrl;
		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.ComboBox comboBoxMethod;
		private System.Windows.Forms.Label labelMethod;
		private System.Windows.Forms.TextBox textBoxRequestData;
		private System.Windows.Forms.ListView listViewRequestHeaders;
		private System.Windows.Forms.ColumnHeader columnHeader;
		private System.Windows.Forms.ColumnHeader columnValue;
		private System.Windows.Forms.Button buttonRemoveHeader;
		private System.Windows.Forms.Button buttonAddHeader;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonChangeHeader;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.TabPage tabPageRequestHeaders;
		private System.Windows.Forms.TabPage tabPageRequestData;
		private System.Windows.Forms.TabPage tabPageResponseData;
		private System.Windows.Forms.TextBox textBoxResponseData;
		private System.Windows.Forms.Button buttonUndo;
		private System.Windows.Forms.TextBox textBoxAccept;
		private System.Windows.Forms.CheckBox checkBoxAccept;
		private System.Windows.Forms.TextBox textBoxContentType;
		private System.Windows.Forms.CheckBox checkBoxContentType;
		private System.Windows.Forms.CheckBox checkBoxExpect;
		private System.Windows.Forms.TextBox textBoxExpect;
		private System.Windows.Forms.CheckBox checkBoxDate;
		private System.Windows.Forms.TextBox textBoxReferer;
		private System.Windows.Forms.CheckBox checkBoxReferer;
		private System.Windows.Forms.CheckBox checkBoxUserAgent;
		private System.Windows.Forms.TextBox textBoxUserAgent;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.ComboBox comboBoxEncoding;
		private System.Windows.Forms.Label labelEncoding;
		private System.Windows.Forms.Button buttonExport;
		private System.Windows.Forms.Button buttonImport;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.TabPage tabPageResponseHeaders;
		private System.Windows.Forms.ListView listViewResponseHeaders;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button buttonViewHeader;

	}
}
