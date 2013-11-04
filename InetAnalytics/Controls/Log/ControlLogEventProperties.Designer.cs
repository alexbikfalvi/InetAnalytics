namespace InetAnalytics.Controls.Log
{
	partial class ControlLogEventProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlLogEventProperties));
			this.labelType = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.labelParent = new System.Windows.Forms.Label();
			this.textBoxMessage = new System.Windows.Forms.TextBox();
			this.textBoxSource = new System.Windows.Forms.TextBox();
			this.textBoxTimestamp = new System.Windows.Forms.TextBox();
			this.textBoxLevel = new System.Windows.Forms.TextBox();
			this.labelMessage = new System.Windows.Forms.Label();
			this.labelSource = new System.Windows.Forms.Label();
			this.labelTimestamp = new System.Windows.Forms.Label();
			this.labelLevel = new System.Windows.Forms.Label();
			this.tabPageParameters = new System.Windows.Forms.TabPage();
			this.listViewParameters = new System.Windows.Forms.ListView();
			this.columnHeaderIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageException = new System.Windows.Forms.TabPage();
			this.buttonException = new System.Windows.Forms.Button();
			this.textBoxExceptionStack = new System.Windows.Forms.TextBox();
			this.textBoxExceptionMessage = new System.Windows.Forms.TextBox();
			this.textBoxExceptionType = new System.Windows.Forms.TextBox();
			this.labelExceptionStack = new System.Windows.Forms.Label();
			this.labelExceptionMessage = new System.Windows.Forms.Label();
			this.labelExceptionType = new System.Windows.Forms.Label();
			this.tabPageError = new System.Windows.Forms.TabPage();
			this.labelError = new System.Windows.Forms.Label();
			this.pictureBoxError = new System.Windows.Forms.PictureBox();
			this.tabPageSubevents = new System.Windows.Forms.TabPage();
			this.listViewSubevents = new System.Windows.Forms.ListView();
			this.columnHeaderTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labelSubevents = new System.Windows.Forms.Label();
			this.tabPageXml = new System.Windows.Forms.TabPage();
			this.pictureBoxXml = new System.Windows.Forms.PictureBox();
			this.listViewXml = new System.Windows.Forms.ListView();
			this.columnHeaderXmlName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderXmlNamespace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labelXml = new System.Windows.Forms.Label();
			this.tabPageCode = new System.Windows.Forms.TabPage();
			this.textBoxCode = new System.Windows.Forms.TextBox();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyValueToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageParameters.SuspendLayout();
			this.tabPageException.SuspendLayout();
			this.tabPageError.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).BeginInit();
			this.tabPageSubevents.SuspendLayout();
			this.tabPageXml.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxXml)).BeginInit();
			this.tabPageCode.SuspendLayout();
			this.contextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(59, 29);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(94, 13);
			this.labelType.TabIndex = 1;
			this.labelType.Text = "No event selected";
			this.labelType.UseMnemonic = false;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageParameters);
			this.tabControl.Controls.Add(this.tabPageException);
			this.tabControl.Controls.Add(this.tabPageError);
			this.tabControl.Controls.Add(this.tabPageSubevents);
			this.tabControl.Controls.Add(this.tabPageXml);
			this.tabControl.Controls.Add(this.tabPageCode);
			this.tabControl.Location = new System.Drawing.Point(3, 58);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(394, 289);
			this.tabControl.TabIndex = 2;
			this.tabControl.Visible = false;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.linkLabel);
			this.tabPageGeneral.Controls.Add(this.labelParent);
			this.tabPageGeneral.Controls.Add(this.textBoxMessage);
			this.tabPageGeneral.Controls.Add(this.textBoxSource);
			this.tabPageGeneral.Controls.Add(this.textBoxTimestamp);
			this.tabPageGeneral.Controls.Add(this.textBoxLevel);
			this.tabPageGeneral.Controls.Add(this.labelMessage);
			this.tabPageGeneral.Controls.Add(this.labelSource);
			this.tabPageGeneral.Controls.Add(this.labelTimestamp);
			this.tabPageGeneral.Controls.Add(this.labelLevel);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(386, 263);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// linkLabel
			// 
			this.linkLabel.Enabled = false;
			this.linkLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel.ImageIndex = 0;
			this.linkLabel.ImageList = this.imageList;
			this.linkLabel.Location = new System.Drawing.Point(85, 91);
			this.linkLabel.Name = "linkLabel";
			this.linkLabel.Size = new System.Drawing.Size(35, 16);
			this.linkLabel.TabIndex = 7;
			this.linkLabel.TabStop = true;
			this.linkLabel.Text = "None";
			this.linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnParentClick);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "EventBrown_16.png");
			this.imageList.Images.SetKeyName(1, "Information_16.png");
			this.imageList.Images.SetKeyName(2, "Success_16.png");
			this.imageList.Images.SetKeyName(3, "Error_16.png");
			this.imageList.Images.SetKeyName(4, "Canceled_16.png");
			this.imageList.Images.SetKeyName(5, "Warning_16.png");
			this.imageList.Images.SetKeyName(6, "Stop_16.png");
			this.imageList.Images.SetKeyName(7, "SuccessWarning_16.png");
			this.imageList.Images.SetKeyName(8, "ErrorWarning_16.png");
			this.imageList.Images.SetKeyName(9, "XmlNamespace_16.png");
			// 
			// labelParent
			// 
			this.labelParent.AutoSize = true;
			this.labelParent.Location = new System.Drawing.Point(11, 93);
			this.labelParent.Name = "labelParent";
			this.labelParent.Size = new System.Drawing.Size(41, 13);
			this.labelParent.TabIndex = 6;
			this.labelParent.Text = "Parent:";
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxMessage.Location = new System.Drawing.Point(88, 116);
			this.textBoxMessage.Multiline = true;
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.ReadOnly = true;
			this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxMessage.Size = new System.Drawing.Size(270, 141);
			this.textBoxMessage.TabIndex = 9;
			// 
			// textBoxSource
			// 
			this.textBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSource.Location = new System.Drawing.Point(88, 64);
			this.textBoxSource.Name = "textBoxSource";
			this.textBoxSource.ReadOnly = true;
			this.textBoxSource.Size = new System.Drawing.Size(270, 20);
			this.textBoxSource.TabIndex = 5;
			// 
			// textBoxTimestamp
			// 
			this.textBoxTimestamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTimestamp.Location = new System.Drawing.Point(88, 38);
			this.textBoxTimestamp.Name = "textBoxTimestamp";
			this.textBoxTimestamp.ReadOnly = true;
			this.textBoxTimestamp.Size = new System.Drawing.Size(270, 20);
			this.textBoxTimestamp.TabIndex = 3;
			// 
			// textBoxLevel
			// 
			this.textBoxLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLevel.Location = new System.Drawing.Point(88, 12);
			this.textBoxLevel.Name = "textBoxLevel";
			this.textBoxLevel.ReadOnly = true;
			this.textBoxLevel.Size = new System.Drawing.Size(270, 20);
			this.textBoxLevel.TabIndex = 1;
			// 
			// labelMessage
			// 
			this.labelMessage.AutoSize = true;
			this.labelMessage.Location = new System.Drawing.Point(11, 119);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(53, 13);
			this.labelMessage.TabIndex = 8;
			this.labelMessage.Text = "Message:";
			// 
			// labelSource
			// 
			this.labelSource.AutoSize = true;
			this.labelSource.Location = new System.Drawing.Point(10, 67);
			this.labelSource.Name = "labelSource";
			this.labelSource.Size = new System.Drawing.Size(44, 13);
			this.labelSource.TabIndex = 4;
			this.labelSource.Text = "Source:";
			// 
			// labelTimestamp
			// 
			this.labelTimestamp.AutoSize = true;
			this.labelTimestamp.Location = new System.Drawing.Point(11, 41);
			this.labelTimestamp.Name = "labelTimestamp";
			this.labelTimestamp.Size = new System.Drawing.Size(61, 13);
			this.labelTimestamp.TabIndex = 2;
			this.labelTimestamp.Text = "Timestamp:";
			// 
			// labelLevel
			// 
			this.labelLevel.AutoSize = true;
			this.labelLevel.Location = new System.Drawing.Point(10, 15);
			this.labelLevel.Name = "labelLevel";
			this.labelLevel.Size = new System.Drawing.Size(36, 13);
			this.labelLevel.TabIndex = 0;
			this.labelLevel.Text = "Level:";
			// 
			// tabPageParameters
			// 
			this.tabPageParameters.Controls.Add(this.listViewParameters);
			this.tabPageParameters.Location = new System.Drawing.Point(4, 22);
			this.tabPageParameters.Name = "tabPageParameters";
			this.tabPageParameters.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageParameters.Size = new System.Drawing.Size(386, 263);
			this.tabPageParameters.TabIndex = 1;
			this.tabPageParameters.Text = "Parameters";
			this.tabPageParameters.UseVisualStyleBackColor = true;
			// 
			// listViewParameters
			// 
			this.listViewParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIndex,
            this.columnHeaderValue});
			this.listViewParameters.FullRowSelect = true;
			this.listViewParameters.GridLines = true;
			this.listViewParameters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewParameters.HideSelection = false;
			this.listViewParameters.Location = new System.Drawing.Point(6, 6);
			this.listViewParameters.MultiSelect = false;
			this.listViewParameters.Name = "listViewParameters";
			this.listViewParameters.Size = new System.Drawing.Size(374, 251);
			this.listViewParameters.TabIndex = 0;
			this.listViewParameters.UseCompatibleStateImageBehavior = false;
			this.listViewParameters.View = System.Windows.Forms.View.Details;
			this.listViewParameters.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnParametersMouseClick);
			// 
			// columnHeaderIndex
			// 
			this.columnHeaderIndex.Text = "Index";
			// 
			// columnHeaderValue
			// 
			this.columnHeaderValue.Text = "Value";
			this.columnHeaderValue.Width = 120;
			// 
			// tabPageException
			// 
			this.tabPageException.Controls.Add(this.buttonException);
			this.tabPageException.Controls.Add(this.textBoxExceptionStack);
			this.tabPageException.Controls.Add(this.textBoxExceptionMessage);
			this.tabPageException.Controls.Add(this.textBoxExceptionType);
			this.tabPageException.Controls.Add(this.labelExceptionStack);
			this.tabPageException.Controls.Add(this.labelExceptionMessage);
			this.tabPageException.Controls.Add(this.labelExceptionType);
			this.tabPageException.Location = new System.Drawing.Point(4, 22);
			this.tabPageException.Name = "tabPageException";
			this.tabPageException.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageException.Size = new System.Drawing.Size(386, 263);
			this.tabPageException.TabIndex = 2;
			this.tabPageException.Text = "Exception";
			this.tabPageException.UseVisualStyleBackColor = true;
			// 
			// buttonException
			// 
			this.buttonException.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonException.Image = global::InetAnalytics.Resources.Exception_16;
			this.buttonException.Location = new System.Drawing.Point(283, 234);
			this.buttonException.Name = "buttonException";
			this.buttonException.Size = new System.Drawing.Size(75, 23);
			this.buttonException.TabIndex = 11;
			this.buttonException.Text = "Details...";
			this.buttonException.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonException.UseVisualStyleBackColor = true;
			this.buttonException.Click += new System.EventHandler(this.OnExceptionClick);
			// 
			// textBoxExceptionStack
			// 
			this.textBoxExceptionStack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxExceptionStack.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxExceptionStack.Location = new System.Drawing.Point(88, 64);
			this.textBoxExceptionStack.Multiline = true;
			this.textBoxExceptionStack.Name = "textBoxExceptionStack";
			this.textBoxExceptionStack.ReadOnly = true;
			this.textBoxExceptionStack.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxExceptionStack.Size = new System.Drawing.Size(270, 164);
			this.textBoxExceptionStack.TabIndex = 5;
			this.textBoxExceptionStack.WordWrap = false;
			// 
			// textBoxExceptionMessage
			// 
			this.textBoxExceptionMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxExceptionMessage.Location = new System.Drawing.Point(88, 38);
			this.textBoxExceptionMessage.Name = "textBoxExceptionMessage";
			this.textBoxExceptionMessage.ReadOnly = true;
			this.textBoxExceptionMessage.Size = new System.Drawing.Size(270, 20);
			this.textBoxExceptionMessage.TabIndex = 3;
			// 
			// textBoxExceptionType
			// 
			this.textBoxExceptionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxExceptionType.Location = new System.Drawing.Point(88, 12);
			this.textBoxExceptionType.Name = "textBoxExceptionType";
			this.textBoxExceptionType.ReadOnly = true;
			this.textBoxExceptionType.Size = new System.Drawing.Size(270, 20);
			this.textBoxExceptionType.TabIndex = 1;
			// 
			// labelExceptionStack
			// 
			this.labelExceptionStack.AutoSize = true;
			this.labelExceptionStack.Location = new System.Drawing.Point(10, 67);
			this.labelExceptionStack.Name = "labelExceptionStack";
			this.labelExceptionStack.Size = new System.Drawing.Size(38, 13);
			this.labelExceptionStack.TabIndex = 4;
			this.labelExceptionStack.Text = "Stack:";
			// 
			// labelExceptionMessage
			// 
			this.labelExceptionMessage.AutoSize = true;
			this.labelExceptionMessage.Location = new System.Drawing.Point(10, 41);
			this.labelExceptionMessage.Name = "labelExceptionMessage";
			this.labelExceptionMessage.Size = new System.Drawing.Size(53, 13);
			this.labelExceptionMessage.TabIndex = 2;
			this.labelExceptionMessage.Text = "Message:";
			// 
			// labelExceptionType
			// 
			this.labelExceptionType.AutoSize = true;
			this.labelExceptionType.Location = new System.Drawing.Point(10, 15);
			this.labelExceptionType.Name = "labelExceptionType";
			this.labelExceptionType.Size = new System.Drawing.Size(34, 13);
			this.labelExceptionType.TabIndex = 0;
			this.labelExceptionType.Text = "Type:";
			// 
			// tabPageError
			// 
			this.tabPageError.Controls.Add(this.labelError);
			this.tabPageError.Controls.Add(this.pictureBoxError);
			this.tabPageError.Location = new System.Drawing.Point(4, 22);
			this.tabPageError.Name = "tabPageError";
			this.tabPageError.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageError.Size = new System.Drawing.Size(386, 263);
			this.tabPageError.TabIndex = 5;
			this.tabPageError.Text = "Error";
			this.tabPageError.UseVisualStyleBackColor = true;
			// 
			// labelError
			// 
			this.labelError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelError.AutoEllipsis = true;
			this.labelError.Location = new System.Drawing.Point(44, 6);
			this.labelError.Name = "labelError";
			this.labelError.Size = new System.Drawing.Size(336, 254);
			this.labelError.TabIndex = 5;
			// 
			// pictureBoxError
			// 
			this.pictureBoxError.Image = global::InetAnalytics.Resources.Error_32;
			this.pictureBoxError.Location = new System.Drawing.Point(6, 6);
			this.pictureBoxError.Name = "pictureBoxError";
			this.pictureBoxError.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxError.TabIndex = 4;
			this.pictureBoxError.TabStop = false;
			// 
			// tabPageSubevents
			// 
			this.tabPageSubevents.Controls.Add(this.listViewSubevents);
			this.tabPageSubevents.Controls.Add(this.labelSubevents);
			this.tabPageSubevents.Location = new System.Drawing.Point(4, 22);
			this.tabPageSubevents.Name = "tabPageSubevents";
			this.tabPageSubevents.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSubevents.Size = new System.Drawing.Size(386, 263);
			this.tabPageSubevents.TabIndex = 3;
			this.tabPageSubevents.Text = "Subevents";
			this.tabPageSubevents.UseVisualStyleBackColor = true;
			// 
			// listViewSubevents
			// 
			this.listViewSubevents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewSubevents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTimestamp,
            this.columnHeaderDescription});
			this.listViewSubevents.FullRowSelect = true;
			this.listViewSubevents.GridLines = true;
			this.listViewSubevents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewSubevents.HideSelection = false;
			this.listViewSubevents.Location = new System.Drawing.Point(6, 31);
			this.listViewSubevents.MultiSelect = false;
			this.listViewSubevents.Name = "listViewSubevents";
			this.listViewSubevents.Size = new System.Drawing.Size(374, 226);
			this.listViewSubevents.SmallImageList = this.imageList;
			this.listViewSubevents.TabIndex = 1;
			this.listViewSubevents.UseCompatibleStateImageBehavior = false;
			this.listViewSubevents.View = System.Windows.Forms.View.Details;
			this.listViewSubevents.ItemActivate += new System.EventHandler(this.OnSubeventActivate);
			// 
			// columnHeaderTimestamp
			// 
			this.columnHeaderTimestamp.Text = "Date/Time";
			this.columnHeaderTimestamp.Width = 120;
			// 
			// columnHeaderDescription
			// 
			this.columnHeaderDescription.Text = "Description";
			this.columnHeaderDescription.Width = 240;
			// 
			// labelSubevents
			// 
			this.labelSubevents.AutoSize = true;
			this.labelSubevents.Location = new System.Drawing.Point(10, 15);
			this.labelSubevents.Name = "labelSubevents";
			this.labelSubevents.Size = new System.Drawing.Size(301, 13);
			this.labelSubevents.TabIndex = 0;
			this.labelSubevents.Text = "The following events were generated during the current event.";
			// 
			// tabPageXml
			// 
			this.tabPageXml.Controls.Add(this.pictureBoxXml);
			this.tabPageXml.Controls.Add(this.listViewXml);
			this.tabPageXml.Controls.Add(this.labelXml);
			this.tabPageXml.Location = new System.Drawing.Point(4, 22);
			this.tabPageXml.Name = "tabPageXml";
			this.tabPageXml.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageXml.Size = new System.Drawing.Size(386, 263);
			this.tabPageXml.TabIndex = 4;
			this.tabPageXml.Text = "XML";
			this.tabPageXml.UseVisualStyleBackColor = true;
			// 
			// pictureBoxXml
			// 
			this.pictureBoxXml.Image = global::InetAnalytics.Resources.XmlNamespace_32;
			this.pictureBoxXml.Location = new System.Drawing.Point(6, 6);
			this.pictureBoxXml.Name = "pictureBoxXml";
			this.pictureBoxXml.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxXml.TabIndex = 3;
			this.pictureBoxXml.TabStop = false;
			// 
			// listViewXml
			// 
			this.listViewXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewXml.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderXmlName,
            this.columnHeaderXmlNamespace});
			this.listViewXml.FullRowSelect = true;
			this.listViewXml.GridLines = true;
			this.listViewXml.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewXml.HideSelection = false;
			this.listViewXml.Location = new System.Drawing.Point(44, 22);
			this.listViewXml.MultiSelect = false;
			this.listViewXml.Name = "listViewXml";
			this.listViewXml.Size = new System.Drawing.Size(336, 235);
			this.listViewXml.SmallImageList = this.imageList;
			this.listViewXml.TabIndex = 3;
			this.listViewXml.UseCompatibleStateImageBehavior = false;
			this.listViewXml.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderXmlName
			// 
			this.columnHeaderXmlName.Text = "Name";
			// 
			// columnHeaderXmlNamespace
			// 
			this.columnHeaderXmlNamespace.Text = "Namespace";
			this.columnHeaderXmlNamespace.Width = 240;
			// 
			// labelXml
			// 
			this.labelXml.AutoSize = true;
			this.labelXml.Location = new System.Drawing.Point(44, 6);
			this.labelXml.Name = "labelXml";
			this.labelXml.Size = new System.Drawing.Size(212, 13);
			this.labelXml.TabIndex = 2;
			this.labelXml.Text = "The XML namespaces used during parsing.";
			// 
			// tabPageCode
			// 
			this.tabPageCode.Controls.Add(this.textBoxCode);
			this.tabPageCode.Location = new System.Drawing.Point(4, 22);
			this.tabPageCode.Name = "tabPageCode";
			this.tabPageCode.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCode.Size = new System.Drawing.Size(386, 263);
			this.tabPageCode.TabIndex = 6;
			this.tabPageCode.Text = "Code";
			this.tabPageCode.UseVisualStyleBackColor = true;
			// 
			// textBoxCode
			// 
			this.textBoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxCode.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxCode.Location = new System.Drawing.Point(3, 3);
			this.textBoxCode.Multiline = true;
			this.textBoxCode.Name = "textBoxCode";
			this.textBoxCode.ReadOnly = true;
			this.textBoxCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxCode.Size = new System.Drawing.Size(380, 257);
			this.textBoxCode.TabIndex = 0;
			this.textBoxCode.WordWrap = false;
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyValueToClipboardToolStripMenuItem});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(170, 26);
			// 
			// copyValueToClipboardToolStripMenuItem
			// 
			this.copyValueToClipboardToolStripMenuItem.Image = global::InetAnalytics.Resources.Copy_16;
			this.copyValueToClipboardToolStripMenuItem.Name = "copyValueToClipboardToolStripMenuItem";
			this.copyValueToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.copyValueToClipboardToolStripMenuItem.Text = "Copy to clipboard";
			this.copyValueToClipboardToolStripMenuItem.Click += new System.EventHandler(this.OnCopyClick);
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.EventMagenta_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ControlLogEvent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelType);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlLogEvent";
			this.Size = new System.Drawing.Size(400, 350);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageParameters.ResumeLayout(false);
			this.tabPageException.ResumeLayout(false);
			this.tabPageException.PerformLayout();
			this.tabPageError.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxError)).EndInit();
			this.tabPageSubevents.ResumeLayout(false);
			this.tabPageSubevents.PerformLayout();
			this.tabPageXml.ResumeLayout(false);
			this.tabPageXml.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxXml)).EndInit();
			this.tabPageCode.ResumeLayout(false);
			this.tabPageCode.PerformLayout();
			this.contextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.TabPage tabPageParameters;
		private System.Windows.Forms.TabPage tabPageException;
		private System.Windows.Forms.Label labelLevel;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.Label labelSource;
		private System.Windows.Forms.Label labelTimestamp;
		private System.Windows.Forms.TextBox textBoxLevel;
		private System.Windows.Forms.TextBox textBoxTimestamp;
		private System.Windows.Forms.TextBox textBoxMessage;
		private System.Windows.Forms.TextBox textBoxSource;
		private System.Windows.Forms.TextBox textBoxExceptionStack;
		private System.Windows.Forms.TextBox textBoxExceptionMessage;
		private System.Windows.Forms.TextBox textBoxExceptionType;
		private System.Windows.Forms.Label labelExceptionStack;
		private System.Windows.Forms.Label labelExceptionMessage;
		private System.Windows.Forms.Label labelExceptionType;
		private System.Windows.Forms.ListView listViewParameters;
		private System.Windows.Forms.ColumnHeader columnHeaderIndex;
		private System.Windows.Forms.ColumnHeader columnHeaderValue;
		private System.Windows.Forms.Label labelParent;
		private System.Windows.Forms.LinkLabel linkLabel;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.TabPage tabPageSubevents;
		private System.Windows.Forms.Label labelSubevents;
		private System.Windows.Forms.ListView listViewSubevents;
		private System.Windows.Forms.ColumnHeader columnHeaderTimestamp;
		private System.Windows.Forms.ColumnHeader columnHeaderDescription;
		private System.Windows.Forms.TabPage tabPageXml;
		private System.Windows.Forms.ListView listViewXml;
		private System.Windows.Forms.ColumnHeader columnHeaderXmlName;
		private System.Windows.Forms.ColumnHeader columnHeaderXmlNamespace;
		private System.Windows.Forms.Label labelXml;
		private System.Windows.Forms.PictureBox pictureBoxXml;
		private System.Windows.Forms.TabPage tabPageError;
		private System.Windows.Forms.PictureBox pictureBoxError;
		private System.Windows.Forms.Label labelError;
		private System.Windows.Forms.TabPage tabPageCode;
		private System.Windows.Forms.TextBox textBoxCode;
		private System.Windows.Forms.Button buttonException;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem copyValueToClipboardToolStripMenuItem;
	}
}
