namespace YtAnalytics.Controls.YouTube
{
	partial class ControlVideoProperties
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
				if (components != null)
				{
					components.Dispose();
				}
				// Wait on the mutex.
				this.mutex.WaitOne();
				// Close the mutex.
				this.mutex.Dispose();
				// Dispose the image form.
				this.formImage.Dispose();
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
			this.labelId = new System.Windows.Forms.Label();
			this.labelPublished = new System.Windows.Forms.Label();
			this.labelDuration = new System.Windows.Forms.Label();
			this.labelUploaded = new System.Windows.Forms.Label();
			this.labelUpdated = new System.Windows.Forms.Label();
			this.labelKeywords = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelCategory = new System.Windows.Forms.Label();
			this.labelUploader = new System.Windows.Forms.Label();
			this.labelLocation = new System.Windows.Forms.Label();
			this.textBoxId = new System.Windows.Forms.TextBox();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.textBoxPublished = new System.Windows.Forms.TextBox();
			this.textBoxUpdated = new System.Windows.Forms.TextBox();
			this.textBoxKeywords = new System.Windows.Forms.TextBox();
			this.textBoxCategory = new System.Windows.Forms.TextBox();
			this.textBoxDuration = new System.Windows.Forms.TextBox();
			this.textBoxUploaded = new System.Windows.Forms.TextBox();
			this.textBoxUploader = new System.Windows.Forms.TextBox();
			this.textBoxLocation = new System.Windows.Forms.TextBox();
			this.labelRecorded = new System.Windows.Forms.Label();
			this.labelFavorites = new System.Windows.Forms.Label();
			this.labelViews = new System.Windows.Forms.Label();
			this.labelComments = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.textBoxComments = new System.Windows.Forms.TextBox();
			this.textBoxViews = new System.Windows.Forms.TextBox();
			this.textBoxFavorites = new System.Windows.Forms.TextBox();
			this.textBoxRecorded = new System.Windows.Forms.TextBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.checkBoxWidescreen = new System.Windows.Forms.CheckBox();
			this.checkBoxPrivate = new System.Windows.Forms.CheckBox();
			this.tabPageAuthor = new System.Windows.Forms.TabPage();
			this.buttonViewProfile = new System.Windows.Forms.Button();
			this.textBoxAuthorName = new System.Windows.Forms.TextBox();
			this.labelAuthorName = new System.Windows.Forms.Label();
			this.labelAuthorId = new System.Windows.Forms.Label();
			this.textBoxAuthorId = new System.Windows.Forms.TextBox();
			this.tabPageUpload = new System.Windows.Forms.TabPage();
			this.checkBoxDraft = new System.Windows.Forms.CheckBox();
			this.labelReason = new System.Windows.Forms.Label();
			this.textBoxReason = new System.Windows.Forms.TextBox();
			this.labelState = new System.Windows.Forms.Label();
			this.textBoxState = new System.Windows.Forms.TextBox();
			this.tabPageStatistics = new System.Windows.Forms.TabPage();
			this.groupBoxOld = new System.Windows.Forms.GroupBox();
			this.textBoxRatingMin = new System.Windows.Forms.TextBox();
			this.textBoxRatingMax = new System.Windows.Forms.TextBox();
			this.labelRatingRaters = new System.Windows.Forms.Label();
			this.labelRatingAverage = new System.Windows.Forms.Label();
			this.labelRatingMax = new System.Windows.Forms.Label();
			this.textBoxRatingRaters = new System.Windows.Forms.TextBox();
			this.textBoxRatingAverage = new System.Windows.Forms.TextBox();
			this.labelRatingMin = new System.Windows.Forms.Label();
			this.groupBoxNew = new System.Windows.Forms.GroupBox();
			this.labelRatingDislikes = new System.Windows.Forms.Label();
			this.labelRatingLikes = new System.Windows.Forms.Label();
			this.pictureBoxDislike = new System.Windows.Forms.PictureBox();
			this.pictureBoxLike = new System.Windows.Forms.PictureBox();
			this.tabPagePermissions = new System.Windows.Forms.TabPage();
			this.listViewPermissions = new System.Windows.Forms.ListView();
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageThumbnails = new System.Windows.Forms.TabPage();
			this.imageListBoxThumbnails = new DotNetApi.Windows.Controls.ImageListBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.labelVideo = new System.Windows.Forms.Label();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			this.tabPageAuthor.SuspendLayout();
			this.tabPageUpload.SuspendLayout();
			this.tabPageStatistics.SuspendLayout();
			this.groupBoxOld.SuspendLayout();
			this.groupBoxNew.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDislike)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike)).BeginInit();
			this.tabPagePermissions.SuspendLayout();
			this.tabPageThumbnails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelId
			// 
			this.labelId.AutoSize = true;
			this.labelId.Location = new System.Drawing.Point(6, 13);
			this.labelId.Name = "labelId";
			this.labelId.Size = new System.Drawing.Size(21, 13);
			this.labelId.TabIndex = 0;
			this.labelId.Text = "ID:";
			// 
			// labelPublished
			// 
			this.labelPublished.AutoSize = true;
			this.labelPublished.Location = new System.Drawing.Point(6, 64);
			this.labelPublished.Name = "labelPublished";
			this.labelPublished.Size = new System.Drawing.Size(56, 13);
			this.labelPublished.TabIndex = 4;
			this.labelPublished.Text = "Published:";
			// 
			// labelDuration
			// 
			this.labelDuration.AutoSize = true;
			this.labelDuration.Location = new System.Drawing.Point(246, 64);
			this.labelDuration.Name = "labelDuration";
			this.labelDuration.Size = new System.Drawing.Size(50, 13);
			this.labelDuration.TabIndex = 14;
			this.labelDuration.Text = "Duration:";
			// 
			// labelUploaded
			// 
			this.labelUploaded.AutoSize = true;
			this.labelUploaded.Location = new System.Drawing.Point(3, 13);
			this.labelUploaded.Name = "labelUploaded";
			this.labelUploaded.Size = new System.Drawing.Size(56, 13);
			this.labelUploaded.TabIndex = 0;
			this.labelUploaded.Text = "Uploaded:";
			// 
			// labelUpdated
			// 
			this.labelUpdated.AutoSize = true;
			this.labelUpdated.Location = new System.Drawing.Point(6, 90);
			this.labelUpdated.Name = "labelUpdated";
			this.labelUpdated.Size = new System.Drawing.Size(51, 13);
			this.labelUpdated.TabIndex = 6;
			this.labelUpdated.Text = "Updated:";
			// 
			// labelKeywords
			// 
			this.labelKeywords.AutoSize = true;
			this.labelKeywords.Location = new System.Drawing.Point(246, 11);
			this.labelKeywords.Name = "labelKeywords";
			this.labelKeywords.Size = new System.Drawing.Size(56, 13);
			this.labelKeywords.TabIndex = 10;
			this.labelKeywords.Text = "Keywords:";
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(6, 39);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(30, 13);
			this.labelTitle.TabIndex = 2;
			this.labelTitle.Text = "Title:";
			// 
			// labelCategory
			// 
			this.labelCategory.AutoSize = true;
			this.labelCategory.Location = new System.Drawing.Point(246, 38);
			this.labelCategory.Name = "labelCategory";
			this.labelCategory.Size = new System.Drawing.Size(52, 13);
			this.labelCategory.TabIndex = 12;
			this.labelCategory.Text = "Category:";
			// 
			// labelUploader
			// 
			this.labelUploader.AutoSize = true;
			this.labelUploader.Location = new System.Drawing.Point(3, 39);
			this.labelUploader.Name = "labelUploader";
			this.labelUploader.Size = new System.Drawing.Size(53, 13);
			this.labelUploader.TabIndex = 2;
			this.labelUploader.Text = "Uploader:";
			// 
			// labelLocation
			// 
			this.labelLocation.AutoSize = true;
			this.labelLocation.Location = new System.Drawing.Point(246, 13);
			this.labelLocation.Name = "labelLocation";
			this.labelLocation.Size = new System.Drawing.Size(51, 13);
			this.labelLocation.TabIndex = 6;
			this.labelLocation.Text = "Location:";
			// 
			// textBoxId
			// 
			this.textBoxId.Location = new System.Drawing.Point(75, 10);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.ReadOnly = true;
			this.textBoxId.Size = new System.Drawing.Size(160, 20);
			this.textBoxId.TabIndex = 1;
			this.textBoxId.Text = "(not available)";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Location = new System.Drawing.Point(75, 36);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.ReadOnly = true;
			this.textBoxTitle.Size = new System.Drawing.Size(160, 20);
			this.textBoxTitle.TabIndex = 3;
			this.textBoxTitle.Text = "(not available)";
			// 
			// textBoxPublished
			// 
			this.textBoxPublished.Location = new System.Drawing.Point(75, 61);
			this.textBoxPublished.Name = "textBoxPublished";
			this.textBoxPublished.ReadOnly = true;
			this.textBoxPublished.Size = new System.Drawing.Size(160, 20);
			this.textBoxPublished.TabIndex = 5;
			this.textBoxPublished.Text = "(not available)";
			// 
			// textBoxUpdated
			// 
			this.textBoxUpdated.Location = new System.Drawing.Point(75, 87);
			this.textBoxUpdated.Name = "textBoxUpdated";
			this.textBoxUpdated.ReadOnly = true;
			this.textBoxUpdated.Size = new System.Drawing.Size(160, 20);
			this.textBoxUpdated.TabIndex = 7;
			this.textBoxUpdated.Text = "(not available)";
			// 
			// textBoxKeywords
			// 
			this.textBoxKeywords.Location = new System.Drawing.Point(318, 10);
			this.textBoxKeywords.Name = "textBoxKeywords";
			this.textBoxKeywords.ReadOnly = true;
			this.textBoxKeywords.Size = new System.Drawing.Size(160, 20);
			this.textBoxKeywords.TabIndex = 11;
			this.textBoxKeywords.Text = "(not available)";
			// 
			// textBoxCategory
			// 
			this.textBoxCategory.Location = new System.Drawing.Point(318, 36);
			this.textBoxCategory.Name = "textBoxCategory";
			this.textBoxCategory.ReadOnly = true;
			this.textBoxCategory.Size = new System.Drawing.Size(160, 20);
			this.textBoxCategory.TabIndex = 13;
			this.textBoxCategory.Text = "(not available)";
			// 
			// textBoxDuration
			// 
			this.textBoxDuration.Location = new System.Drawing.Point(318, 61);
			this.textBoxDuration.Name = "textBoxDuration";
			this.textBoxDuration.ReadOnly = true;
			this.textBoxDuration.Size = new System.Drawing.Size(160, 20);
			this.textBoxDuration.TabIndex = 15;
			this.textBoxDuration.Text = "(not available)";
			// 
			// textBoxUploaded
			// 
			this.textBoxUploaded.Location = new System.Drawing.Point(75, 10);
			this.textBoxUploaded.Name = "textBoxUploaded";
			this.textBoxUploaded.ReadOnly = true;
			this.textBoxUploaded.Size = new System.Drawing.Size(160, 20);
			this.textBoxUploaded.TabIndex = 1;
			this.textBoxUploaded.Text = "(not available)";
			// 
			// textBoxUploader
			// 
			this.textBoxUploader.Location = new System.Drawing.Point(75, 36);
			this.textBoxUploader.Name = "textBoxUploader";
			this.textBoxUploader.ReadOnly = true;
			this.textBoxUploader.Size = new System.Drawing.Size(160, 20);
			this.textBoxUploader.TabIndex = 3;
			this.textBoxUploader.Text = "(not available)";
			// 
			// textBoxLocation
			// 
			this.textBoxLocation.Location = new System.Drawing.Point(318, 10);
			this.textBoxLocation.Name = "textBoxLocation";
			this.textBoxLocation.ReadOnly = true;
			this.textBoxLocation.Size = new System.Drawing.Size(160, 20);
			this.textBoxLocation.TabIndex = 7;
			this.textBoxLocation.Text = "(not available)";
			// 
			// labelRecorded
			// 
			this.labelRecorded.AutoSize = true;
			this.labelRecorded.Location = new System.Drawing.Point(246, 39);
			this.labelRecorded.Name = "labelRecorded";
			this.labelRecorded.Size = new System.Drawing.Size(57, 13);
			this.labelRecorded.TabIndex = 8;
			this.labelRecorded.Text = "Recorded:";
			// 
			// labelFavorites
			// 
			this.labelFavorites.AutoSize = true;
			this.labelFavorites.Location = new System.Drawing.Point(6, 39);
			this.labelFavorites.Name = "labelFavorites";
			this.labelFavorites.Size = new System.Drawing.Size(53, 13);
			this.labelFavorites.TabIndex = 2;
			this.labelFavorites.Text = "Favorites:";
			// 
			// labelViews
			// 
			this.labelViews.AutoSize = true;
			this.labelViews.Location = new System.Drawing.Point(6, 13);
			this.labelViews.Name = "labelViews";
			this.labelViews.Size = new System.Drawing.Size(38, 13);
			this.labelViews.TabIndex = 0;
			this.labelViews.Text = "Views:";
			// 
			// labelComments
			// 
			this.labelComments.AutoSize = true;
			this.labelComments.Location = new System.Drawing.Point(246, 13);
			this.labelComments.Name = "labelComments";
			this.labelComments.Size = new System.Drawing.Size(59, 13);
			this.labelComments.TabIndex = 4;
			this.labelComments.Text = "Comments:";
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(6, 116);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(63, 13);
			this.labelDescription.TabIndex = 8;
			this.labelDescription.Text = "Description:";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxDescription.Location = new System.Drawing.Point(76, 113);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescription.Size = new System.Drawing.Size(403, 142);
			this.textBoxDescription.TabIndex = 9;
			this.textBoxDescription.Text = "(not available)";
			// 
			// textBoxComments
			// 
			this.textBoxComments.Location = new System.Drawing.Point(318, 10);
			this.textBoxComments.Name = "textBoxComments";
			this.textBoxComments.ReadOnly = true;
			this.textBoxComments.Size = new System.Drawing.Size(160, 20);
			this.textBoxComments.TabIndex = 5;
			this.textBoxComments.Text = "(not available)";
			// 
			// textBoxViews
			// 
			this.textBoxViews.Location = new System.Drawing.Point(75, 10);
			this.textBoxViews.Name = "textBoxViews";
			this.textBoxViews.ReadOnly = true;
			this.textBoxViews.Size = new System.Drawing.Size(160, 20);
			this.textBoxViews.TabIndex = 1;
			this.textBoxViews.Text = "(not available)";
			// 
			// textBoxFavorites
			// 
			this.textBoxFavorites.Location = new System.Drawing.Point(75, 36);
			this.textBoxFavorites.Name = "textBoxFavorites";
			this.textBoxFavorites.ReadOnly = true;
			this.textBoxFavorites.Size = new System.Drawing.Size(160, 20);
			this.textBoxFavorites.TabIndex = 3;
			this.textBoxFavorites.Text = "(not available)";
			// 
			// textBoxRecorded
			// 
			this.textBoxRecorded.Location = new System.Drawing.Point(318, 36);
			this.textBoxRecorded.Name = "textBoxRecorded";
			this.textBoxRecorded.ReadOnly = true;
			this.textBoxRecorded.Size = new System.Drawing.Size(160, 20);
			this.textBoxRecorded.TabIndex = 9;
			this.textBoxRecorded.Text = "(not available)";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Controls.Add(this.tabPageAuthor);
			this.tabControl.Controls.Add(this.tabPageUpload);
			this.tabControl.Controls.Add(this.tabPageStatistics);
			this.tabControl.Controls.Add(this.tabPagePermissions);
			this.tabControl.Controls.Add(this.tabPageThumbnails);
			this.tabControl.Location = new System.Drawing.Point(3, 64);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(596, 310);
			this.tabControl.TabIndex = 0;
			this.tabControl.Visible = false;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.AutoScroll = true;
			this.tabPageGeneral.Controls.Add(this.checkBoxWidescreen);
			this.tabPageGeneral.Controls.Add(this.checkBoxPrivate);
			this.tabPageGeneral.Controls.Add(this.labelUpdated);
			this.tabPageGeneral.Controls.Add(this.textBoxId);
			this.tabPageGeneral.Controls.Add(this.labelId);
			this.tabPageGeneral.Controls.Add(this.textBoxDuration);
			this.tabPageGeneral.Controls.Add(this.labelPublished);
			this.tabPageGeneral.Controls.Add(this.textBoxCategory);
			this.tabPageGeneral.Controls.Add(this.labelDuration);
			this.tabPageGeneral.Controls.Add(this.textBoxKeywords);
			this.tabPageGeneral.Controls.Add(this.labelKeywords);
			this.tabPageGeneral.Controls.Add(this.labelTitle);
			this.tabPageGeneral.Controls.Add(this.textBoxUpdated);
			this.tabPageGeneral.Controls.Add(this.labelCategory);
			this.tabPageGeneral.Controls.Add(this.textBoxPublished);
			this.tabPageGeneral.Controls.Add(this.textBoxDescription);
			this.tabPageGeneral.Controls.Add(this.textBoxTitle);
			this.tabPageGeneral.Controls.Add(this.labelDescription);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(588, 284);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "Basic";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// checkBoxWidescreen
			// 
			this.checkBoxWidescreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxWidescreen.AutoSize = true;
			this.checkBoxWidescreen.Enabled = false;
			this.checkBoxWidescreen.Location = new System.Drawing.Point(318, 261);
			this.checkBoxWidescreen.Name = "checkBoxWidescreen";
			this.checkBoxWidescreen.Size = new System.Drawing.Size(83, 17);
			this.checkBoxWidescreen.TabIndex = 17;
			this.checkBoxWidescreen.Text = "Widescreen";
			this.checkBoxWidescreen.UseVisualStyleBackColor = true;
			// 
			// checkBoxPrivate
			// 
			this.checkBoxPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxPrivate.AutoSize = true;
			this.checkBoxPrivate.Enabled = false;
			this.checkBoxPrivate.Location = new System.Drawing.Point(75, 261);
			this.checkBoxPrivate.Name = "checkBoxPrivate";
			this.checkBoxPrivate.Size = new System.Drawing.Size(59, 17);
			this.checkBoxPrivate.TabIndex = 16;
			this.checkBoxPrivate.Text = "Private";
			this.checkBoxPrivate.UseVisualStyleBackColor = true;
			// 
			// tabPageAuthor
			// 
			this.tabPageAuthor.AutoScroll = true;
			this.tabPageAuthor.Controls.Add(this.buttonViewProfile);
			this.tabPageAuthor.Controls.Add(this.textBoxAuthorName);
			this.tabPageAuthor.Controls.Add(this.labelAuthorName);
			this.tabPageAuthor.Controls.Add(this.labelAuthorId);
			this.tabPageAuthor.Controls.Add(this.textBoxAuthorId);
			this.tabPageAuthor.Location = new System.Drawing.Point(4, 22);
			this.tabPageAuthor.Name = "tabPageAuthor";
			this.tabPageAuthor.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAuthor.Size = new System.Drawing.Size(588, 284);
			this.tabPageAuthor.TabIndex = 4;
			this.tabPageAuthor.Text = "Author";
			this.tabPageAuthor.UseVisualStyleBackColor = true;
			// 
			// buttonViewProfile
			// 
			this.buttonViewProfile.Enabled = false;
			this.buttonViewProfile.Image = global::YtAnalytics.Resources.User_16;
			this.buttonViewProfile.Location = new System.Drawing.Point(75, 63);
			this.buttonViewProfile.Name = "buttonViewProfile";
			this.buttonViewProfile.Size = new System.Drawing.Size(95, 23);
			this.buttonViewProfile.TabIndex = 4;
			this.buttonViewProfile.Text = "&View profile";
			this.buttonViewProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonViewProfile.UseVisualStyleBackColor = true;
			this.buttonViewProfile.Click += new System.EventHandler(this.OnViewProfile);
			// 
			// textBoxAuthorName
			// 
			this.textBoxAuthorName.Location = new System.Drawing.Point(75, 10);
			this.textBoxAuthorName.Name = "textBoxAuthorName";
			this.textBoxAuthorName.ReadOnly = true;
			this.textBoxAuthorName.Size = new System.Drawing.Size(160, 20);
			this.textBoxAuthorName.TabIndex = 1;
			this.textBoxAuthorName.Text = "(not available)";
			// 
			// labelAuthorName
			// 
			this.labelAuthorName.AutoSize = true;
			this.labelAuthorName.Location = new System.Drawing.Point(6, 13);
			this.labelAuthorName.Name = "labelAuthorName";
			this.labelAuthorName.Size = new System.Drawing.Size(38, 13);
			this.labelAuthorName.TabIndex = 0;
			this.labelAuthorName.Text = "Name:";
			// 
			// labelAuthorId
			// 
			this.labelAuthorId.AutoSize = true;
			this.labelAuthorId.Location = new System.Drawing.Point(6, 39);
			this.labelAuthorId.Name = "labelAuthorId";
			this.labelAuthorId.Size = new System.Drawing.Size(21, 13);
			this.labelAuthorId.TabIndex = 2;
			this.labelAuthorId.Text = "ID:";
			// 
			// textBoxAuthorId
			// 
			this.textBoxAuthorId.Location = new System.Drawing.Point(75, 36);
			this.textBoxAuthorId.Name = "textBoxAuthorId";
			this.textBoxAuthorId.ReadOnly = true;
			this.textBoxAuthorId.Size = new System.Drawing.Size(160, 20);
			this.textBoxAuthorId.TabIndex = 3;
			this.textBoxAuthorId.Text = "(not available)";
			// 
			// tabPageUpload
			// 
			this.tabPageUpload.AutoScroll = true;
			this.tabPageUpload.Controls.Add(this.checkBoxDraft);
			this.tabPageUpload.Controls.Add(this.labelReason);
			this.tabPageUpload.Controls.Add(this.textBoxReason);
			this.tabPageUpload.Controls.Add(this.labelState);
			this.tabPageUpload.Controls.Add(this.textBoxState);
			this.tabPageUpload.Controls.Add(this.labelUploaded);
			this.tabPageUpload.Controls.Add(this.textBoxUploaded);
			this.tabPageUpload.Controls.Add(this.labelUploader);
			this.tabPageUpload.Controls.Add(this.labelRecorded);
			this.tabPageUpload.Controls.Add(this.textBoxRecorded);
			this.tabPageUpload.Controls.Add(this.labelLocation);
			this.tabPageUpload.Controls.Add(this.textBoxLocation);
			this.tabPageUpload.Controls.Add(this.textBoxUploader);
			this.tabPageUpload.Location = new System.Drawing.Point(4, 22);
			this.tabPageUpload.Name = "tabPageUpload";
			this.tabPageUpload.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageUpload.Size = new System.Drawing.Size(588, 284);
			this.tabPageUpload.TabIndex = 1;
			this.tabPageUpload.Text = "Upload";
			this.tabPageUpload.UseVisualStyleBackColor = true;
			// 
			// checkBoxDraft
			// 
			this.checkBoxDraft.AutoSize = true;
			this.checkBoxDraft.Enabled = false;
			this.checkBoxDraft.Location = new System.Drawing.Point(75, 107);
			this.checkBoxDraft.Name = "checkBoxDraft";
			this.checkBoxDraft.Size = new System.Drawing.Size(49, 17);
			this.checkBoxDraft.TabIndex = 17;
			this.checkBoxDraft.Text = "Draft";
			this.checkBoxDraft.UseVisualStyleBackColor = true;
			// 
			// labelReason
			// 
			this.labelReason.AutoSize = true;
			this.labelReason.Location = new System.Drawing.Point(246, 84);
			this.labelReason.Name = "labelReason";
			this.labelReason.Size = new System.Drawing.Size(47, 13);
			this.labelReason.TabIndex = 10;
			this.labelReason.Text = "Reason:";
			// 
			// textBoxReason
			// 
			this.textBoxReason.Location = new System.Drawing.Point(318, 81);
			this.textBoxReason.Name = "textBoxReason";
			this.textBoxReason.ReadOnly = true;
			this.textBoxReason.Size = new System.Drawing.Size(160, 20);
			this.textBoxReason.TabIndex = 11;
			this.textBoxReason.Text = "(not available)";
			// 
			// labelState
			// 
			this.labelState.AutoSize = true;
			this.labelState.Location = new System.Drawing.Point(3, 84);
			this.labelState.Name = "labelState";
			this.labelState.Size = new System.Drawing.Size(35, 13);
			this.labelState.TabIndex = 4;
			this.labelState.Text = "State:";
			// 
			// textBoxState
			// 
			this.textBoxState.Location = new System.Drawing.Point(75, 81);
			this.textBoxState.Name = "textBoxState";
			this.textBoxState.ReadOnly = true;
			this.textBoxState.Size = new System.Drawing.Size(160, 20);
			this.textBoxState.TabIndex = 5;
			this.textBoxState.Text = "(not available)";
			// 
			// tabPageStatistics
			// 
			this.tabPageStatistics.AutoScroll = true;
			this.tabPageStatistics.Controls.Add(this.groupBoxOld);
			this.tabPageStatistics.Controls.Add(this.groupBoxNew);
			this.tabPageStatistics.Controls.Add(this.labelViews);
			this.tabPageStatistics.Controls.Add(this.labelFavorites);
			this.tabPageStatistics.Controls.Add(this.textBoxFavorites);
			this.tabPageStatistics.Controls.Add(this.textBoxComments);
			this.tabPageStatistics.Controls.Add(this.textBoxViews);
			this.tabPageStatistics.Controls.Add(this.labelComments);
			this.tabPageStatistics.Location = new System.Drawing.Point(4, 22);
			this.tabPageStatistics.Name = "tabPageStatistics";
			this.tabPageStatistics.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStatistics.Size = new System.Drawing.Size(588, 284);
			this.tabPageStatistics.TabIndex = 2;
			this.tabPageStatistics.Text = "Statistics";
			this.tabPageStatistics.UseVisualStyleBackColor = true;
			// 
			// groupBoxOld
			// 
			this.groupBoxOld.Controls.Add(this.textBoxRatingMin);
			this.groupBoxOld.Controls.Add(this.textBoxRatingMax);
			this.groupBoxOld.Controls.Add(this.labelRatingRaters);
			this.groupBoxOld.Controls.Add(this.labelRatingAverage);
			this.groupBoxOld.Controls.Add(this.labelRatingMax);
			this.groupBoxOld.Controls.Add(this.textBoxRatingRaters);
			this.groupBoxOld.Controls.Add(this.textBoxRatingAverage);
			this.groupBoxOld.Controls.Add(this.labelRatingMin);
			this.groupBoxOld.Location = new System.Drawing.Point(247, 62);
			this.groupBoxOld.Name = "groupBoxOld";
			this.groupBoxOld.Size = new System.Drawing.Size(232, 125);
			this.groupBoxOld.TabIndex = 7;
			this.groupBoxOld.TabStop = false;
			this.groupBoxOld.Text = "Old ratings";
			// 
			// textBoxRatingMin
			// 
			this.textBoxRatingMin.Location = new System.Drawing.Point(66, 16);
			this.textBoxRatingMin.Name = "textBoxRatingMin";
			this.textBoxRatingMin.ReadOnly = true;
			this.textBoxRatingMin.Size = new System.Drawing.Size(160, 20);
			this.textBoxRatingMin.TabIndex = 1;
			this.textBoxRatingMin.Text = "(not available)";
			// 
			// textBoxRatingMax
			// 
			this.textBoxRatingMax.Location = new System.Drawing.Point(66, 42);
			this.textBoxRatingMax.Name = "textBoxRatingMax";
			this.textBoxRatingMax.ReadOnly = true;
			this.textBoxRatingMax.Size = new System.Drawing.Size(160, 20);
			this.textBoxRatingMax.TabIndex = 3;
			this.textBoxRatingMax.Text = "(not available)";
			// 
			// labelRatingRaters
			// 
			this.labelRatingRaters.AutoSize = true;
			this.labelRatingRaters.Location = new System.Drawing.Point(6, 97);
			this.labelRatingRaters.Name = "labelRatingRaters";
			this.labelRatingRaters.Size = new System.Drawing.Size(41, 13);
			this.labelRatingRaters.TabIndex = 6;
			this.labelRatingRaters.Text = "Raters:";
			// 
			// labelRatingAverage
			// 
			this.labelRatingAverage.AutoSize = true;
			this.labelRatingAverage.Location = new System.Drawing.Point(6, 71);
			this.labelRatingAverage.Name = "labelRatingAverage";
			this.labelRatingAverage.Size = new System.Drawing.Size(50, 13);
			this.labelRatingAverage.TabIndex = 4;
			this.labelRatingAverage.Text = "Average:";
			// 
			// labelRatingMax
			// 
			this.labelRatingMax.AutoSize = true;
			this.labelRatingMax.Location = new System.Drawing.Point(6, 45);
			this.labelRatingMax.Name = "labelRatingMax";
			this.labelRatingMax.Size = new System.Drawing.Size(54, 13);
			this.labelRatingMax.TabIndex = 2;
			this.labelRatingMax.Text = "Maximum:";
			// 
			// textBoxRatingRaters
			// 
			this.textBoxRatingRaters.Location = new System.Drawing.Point(66, 94);
			this.textBoxRatingRaters.Name = "textBoxRatingRaters";
			this.textBoxRatingRaters.ReadOnly = true;
			this.textBoxRatingRaters.Size = new System.Drawing.Size(160, 20);
			this.textBoxRatingRaters.TabIndex = 7;
			this.textBoxRatingRaters.Text = "(not available)";
			// 
			// textBoxRatingAverage
			// 
			this.textBoxRatingAverage.Location = new System.Drawing.Point(66, 68);
			this.textBoxRatingAverage.Name = "textBoxRatingAverage";
			this.textBoxRatingAverage.ReadOnly = true;
			this.textBoxRatingAverage.Size = new System.Drawing.Size(160, 20);
			this.textBoxRatingAverage.TabIndex = 5;
			this.textBoxRatingAverage.Text = "(not available)";
			// 
			// labelRatingMin
			// 
			this.labelRatingMin.AutoSize = true;
			this.labelRatingMin.Location = new System.Drawing.Point(6, 19);
			this.labelRatingMin.Name = "labelRatingMin";
			this.labelRatingMin.Size = new System.Drawing.Size(51, 13);
			this.labelRatingMin.TabIndex = 0;
			this.labelRatingMin.Text = "Minimum:";
			// 
			// groupBoxNew
			// 
			this.groupBoxNew.Controls.Add(this.labelRatingDislikes);
			this.groupBoxNew.Controls.Add(this.labelRatingLikes);
			this.groupBoxNew.Controls.Add(this.pictureBoxDislike);
			this.groupBoxNew.Controls.Add(this.pictureBoxLike);
			this.groupBoxNew.Location = new System.Drawing.Point(3, 62);
			this.groupBoxNew.Name = "groupBoxNew";
			this.groupBoxNew.Size = new System.Drawing.Size(232, 125);
			this.groupBoxNew.TabIndex = 6;
			this.groupBoxNew.TabStop = false;
			this.groupBoxNew.Text = "New ratings";
			// 
			// labelRatingDislikes
			// 
			this.labelRatingDislikes.AutoSize = true;
			this.labelRatingDislikes.Location = new System.Drawing.Point(72, 52);
			this.labelRatingDislikes.Name = "labelRatingDislikes";
			this.labelRatingDislikes.Size = new System.Drawing.Size(73, 13);
			this.labelRatingDislikes.TabIndex = 1;
			this.labelRatingDislikes.Text = "(not available)";
			// 
			// labelRatingLikes
			// 
			this.labelRatingLikes.AutoSize = true;
			this.labelRatingLikes.Location = new System.Drawing.Point(72, 23);
			this.labelRatingLikes.Name = "labelRatingLikes";
			this.labelRatingLikes.Size = new System.Drawing.Size(73, 13);
			this.labelRatingLikes.TabIndex = 0;
			this.labelRatingLikes.Text = "(not available)";
			// 
			// pictureBoxDislike
			// 
			this.pictureBoxDislike.Image = global::YtAnalytics.Resources.Dislike_24;
			this.pictureBoxDislike.Location = new System.Drawing.Point(18, 48);
			this.pictureBoxDislike.Name = "pictureBoxDislike";
			this.pictureBoxDislike.Size = new System.Drawing.Size(24, 24);
			this.pictureBoxDislike.TabIndex = 1;
			this.pictureBoxDislike.TabStop = false;
			// 
			// pictureBoxLike
			// 
			this.pictureBoxLike.Image = global::YtAnalytics.Resources.Like_24;
			this.pictureBoxLike.Location = new System.Drawing.Point(18, 19);
			this.pictureBoxLike.Name = "pictureBoxLike";
			this.pictureBoxLike.Size = new System.Drawing.Size(24, 24);
			this.pictureBoxLike.TabIndex = 0;
			this.pictureBoxLike.TabStop = false;
			// 
			// tabPagePermissions
			// 
			this.tabPagePermissions.AutoScroll = true;
			this.tabPagePermissions.Controls.Add(this.listViewPermissions);
			this.tabPagePermissions.Location = new System.Drawing.Point(4, 22);
			this.tabPagePermissions.Name = "tabPagePermissions";
			this.tabPagePermissions.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePermissions.Size = new System.Drawing.Size(588, 284);
			this.tabPagePermissions.TabIndex = 3;
			this.tabPagePermissions.Text = "Permissions";
			this.tabPagePermissions.UseVisualStyleBackColor = true;
			// 
			// listViewPermissions
			// 
			this.listViewPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewPermissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listViewPermissions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderValue});
			this.listViewPermissions.FullRowSelect = true;
			this.listViewPermissions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewPermissions.HideSelection = false;
			this.listViewPermissions.Location = new System.Drawing.Point(6, 6);
			this.listViewPermissions.Name = "listViewPermissions";
			this.listViewPermissions.Size = new System.Drawing.Size(574, 274);
			this.listViewPermissions.TabIndex = 0;
			this.listViewPermissions.UseCompatibleStateImageBehavior = false;
			this.listViewPermissions.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Permission";
			this.columnHeaderName.Width = 120;
			// 
			// columnHeaderValue
			// 
			this.columnHeaderValue.Text = "Value";
			this.columnHeaderValue.Width = 120;
			// 
			// tabPageThumbnails
			// 
			this.tabPageThumbnails.AutoScroll = true;
			this.tabPageThumbnails.Controls.Add(this.imageListBoxThumbnails);
			this.tabPageThumbnails.Location = new System.Drawing.Point(4, 22);
			this.tabPageThumbnails.Name = "tabPageThumbnails";
			this.tabPageThumbnails.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageThumbnails.Size = new System.Drawing.Size(588, 284);
			this.tabPageThumbnails.TabIndex = 5;
			this.tabPageThumbnails.Text = "Thumbnails";
			this.tabPageThumbnails.UseVisualStyleBackColor = true;
			// 
			// imageListBoxThumbnails
			// 
			this.imageListBoxThumbnails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageListBoxThumbnails.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.imageListBoxThumbnails.FormattingEnabled = true;
			this.imageListBoxThumbnails.ImageWidth = 64;
			this.imageListBoxThumbnails.IntegralHeight = false;
			this.imageListBoxThumbnails.ItemHeight = 48;
			this.imageListBoxThumbnails.Location = new System.Drawing.Point(3, 3);
			this.imageListBoxThumbnails.Name = "imageListBoxThumbnails";
			this.imageListBoxThumbnails.Size = new System.Drawing.Size(582, 278);
			this.imageListBoxThumbnails.TabIndex = 0;
			this.imageListBoxThumbnails.ItemActivate += new DotNetApi.Windows.Controls.ImageListBoxItemActivateEventHandler(this.OnThumbnailActivate);
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.FileVideo_48;
			this.pictureBox.Location = new System.Drawing.Point(10, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(64, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// labelVideo
			// 
			this.labelVideo.AutoSize = true;
			this.labelVideo.Location = new System.Drawing.Point(80, 27);
			this.labelVideo.Name = "labelVideo";
			this.labelVideo.Size = new System.Drawing.Size(93, 13);
			this.labelVideo.TabIndex = 1;
			this.labelVideo.Text = "No video selected";
			this.labelVideo.UseMnemonic = false;
			// 
			// ControlVideoProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelVideo);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlVideoProperties";
			this.Size = new System.Drawing.Size(600, 376);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			this.tabPageAuthor.ResumeLayout(false);
			this.tabPageAuthor.PerformLayout();
			this.tabPageUpload.ResumeLayout(false);
			this.tabPageUpload.PerformLayout();
			this.tabPageStatistics.ResumeLayout(false);
			this.tabPageStatistics.PerformLayout();
			this.groupBoxOld.ResumeLayout(false);
			this.groupBoxOld.PerformLayout();
			this.groupBoxNew.ResumeLayout(false);
			this.groupBoxNew.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDislike)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLike)).EndInit();
			this.tabPagePermissions.ResumeLayout(false);
			this.tabPageThumbnails.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelId;
		private System.Windows.Forms.Label labelPublished;
		private System.Windows.Forms.Label labelDuration;
		private System.Windows.Forms.Label labelUploaded;
		private System.Windows.Forms.Label labelUpdated;
		private System.Windows.Forms.Label labelKeywords;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelCategory;
		private System.Windows.Forms.Label labelUploader;
		private System.Windows.Forms.Label labelLocation;
		private System.Windows.Forms.TextBox textBoxId;
		private System.Windows.Forms.TextBox textBoxTitle;
		private System.Windows.Forms.TextBox textBoxPublished;
		private System.Windows.Forms.TextBox textBoxUpdated;
		private System.Windows.Forms.TextBox textBoxKeywords;
		private System.Windows.Forms.TextBox textBoxCategory;
		private System.Windows.Forms.TextBox textBoxDuration;
		private System.Windows.Forms.TextBox textBoxUploaded;
		private System.Windows.Forms.TextBox textBoxUploader;
		private System.Windows.Forms.TextBox textBoxLocation;
		private System.Windows.Forms.Label labelRecorded;
		private System.Windows.Forms.Label labelFavorites;
		private System.Windows.Forms.Label labelViews;
		private System.Windows.Forms.Label labelComments;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.TextBox textBoxComments;
		private System.Windows.Forms.TextBox textBoxViews;
		private System.Windows.Forms.TextBox textBoxFavorites;
		private System.Windows.Forms.TextBox textBoxRecorded;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.TabPage tabPageUpload;
		private System.Windows.Forms.Label labelState;
		private System.Windows.Forms.TextBox textBoxState;
		private System.Windows.Forms.TabPage tabPageStatistics;
		private System.Windows.Forms.GroupBox groupBoxOld;
		private System.Windows.Forms.GroupBox groupBoxNew;
		private System.Windows.Forms.PictureBox pictureBoxLike;
		private System.Windows.Forms.PictureBox pictureBoxDislike;
		private System.Windows.Forms.TextBox textBoxRatingMin;
		private System.Windows.Forms.TextBox textBoxRatingMax;
		private System.Windows.Forms.Label labelRatingRaters;
		private System.Windows.Forms.Label labelRatingAverage;
		private System.Windows.Forms.Label labelRatingMax;
		private System.Windows.Forms.TextBox textBoxRatingRaters;
		private System.Windows.Forms.TextBox textBoxRatingAverage;
		private System.Windows.Forms.Label labelRatingMin;
		private System.Windows.Forms.Label labelRatingDislikes;
		private System.Windows.Forms.Label labelRatingLikes;
		private System.Windows.Forms.CheckBox checkBoxPrivate;
		private System.Windows.Forms.TabPage tabPagePermissions;
		private System.Windows.Forms.ListView listViewPermissions;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.CheckBox checkBoxWidescreen;
		private System.Windows.Forms.ColumnHeader columnHeaderValue;
		private System.Windows.Forms.Label labelReason;
		private System.Windows.Forms.TextBox textBoxReason;
		private System.Windows.Forms.CheckBox checkBoxDraft;
		private System.Windows.Forms.Label labelVideo;
		private System.Windows.Forms.TabPage tabPageAuthor;
		private System.Windows.Forms.TextBox textBoxAuthorName;
		private System.Windows.Forms.Label labelAuthorName;
		private System.Windows.Forms.Label labelAuthorId;
		private System.Windows.Forms.TextBox textBoxAuthorId;
		private System.Windows.Forms.Button buttonViewProfile;
		private System.Windows.Forms.TabPage tabPageThumbnails;
		private DotNetApi.Windows.Controls.ImageListBox imageListBoxThumbnails;
	}
}
