namespace InetAnalytics.Controls.Database
{
	partial class ControlFieldProperties
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlFieldProperties));
			this.labelTitle = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.checkBoxConfigured = new System.Windows.Forms.CheckBox();
			this.labelTypeDatabase = new System.Windows.Forms.Label();
			this.textBoxTypeDatabase = new System.Windows.Forms.TextBox();
			this.labelTypeLocal = new System.Windows.Forms.Label();
			this.textBoxTypeLocal = new System.Windows.Forms.TextBox();
			this.checkBoxNullable = new System.Windows.Forms.CheckBox();
			this.textBoxNameDisplay = new System.Windows.Forms.TextBox();
			this.textBoxNameDatabase = new System.Windows.Forms.TextBox();
			this.textBoxNameLocal = new System.Windows.Forms.TextBox();
			this.labelDisplayName = new System.Windows.Forms.Label();
			this.labelNameDatabase = new System.Windows.Forms.Label();
			this.labelNameLocal = new System.Windows.Forms.Label();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tabControl.SuspendLayout();
			this.tabPageGeneral.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Location = new System.Drawing.Point(59, 29);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(86, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No field selected";
			this.labelTitle.UseMnemonic = false;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageGeneral);
			this.tabControl.Location = new System.Drawing.Point(3, 58);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(394, 289);
			this.tabControl.TabIndex = 0;
			this.tabControl.Visible = false;
			// 
			// tabPageGeneral
			// 
			this.tabPageGeneral.Controls.Add(this.labelDescription);
			this.tabPageGeneral.Controls.Add(this.textBoxDescription);
			this.tabPageGeneral.Controls.Add(this.checkBoxConfigured);
			this.tabPageGeneral.Controls.Add(this.labelTypeDatabase);
			this.tabPageGeneral.Controls.Add(this.textBoxTypeDatabase);
			this.tabPageGeneral.Controls.Add(this.labelTypeLocal);
			this.tabPageGeneral.Controls.Add(this.textBoxTypeLocal);
			this.tabPageGeneral.Controls.Add(this.checkBoxNullable);
			this.tabPageGeneral.Controls.Add(this.textBoxNameDisplay);
			this.tabPageGeneral.Controls.Add(this.textBoxNameDatabase);
			this.tabPageGeneral.Controls.Add(this.textBoxNameLocal);
			this.tabPageGeneral.Controls.Add(this.labelDisplayName);
			this.tabPageGeneral.Controls.Add(this.labelNameDatabase);
			this.tabPageGeneral.Controls.Add(this.labelNameLocal);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(386, 263);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(10, 145);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(63, 13);
			this.labelDescription.TabIndex = 24;
			this.labelDescription.Text = "Des&cription:";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDescription.Location = new System.Drawing.Point(102, 142);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.Size = new System.Drawing.Size(256, 69);
			this.textBoxDescription.TabIndex = 23;
			// 
			// checkBoxConfigured
			// 
			this.checkBoxConfigured.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxConfigured.AutoSize = true;
			this.checkBoxConfigured.Enabled = false;
			this.checkBoxConfigured.Location = new System.Drawing.Point(102, 240);
			this.checkBoxConfigured.Name = "checkBoxConfigured";
			this.checkBoxConfigured.Size = new System.Drawing.Size(87, 17);
			this.checkBoxConfigured.TabIndex = 22;
			this.checkBoxConfigured.Text = "I&s configured";
			this.checkBoxConfigured.UseVisualStyleBackColor = true;
			// 
			// labelTypeDatabase
			// 
			this.labelTypeDatabase.AutoSize = true;
			this.labelTypeDatabase.Location = new System.Drawing.Point(10, 119);
			this.labelTypeDatabase.Name = "labelTypeDatabase";
			this.labelTypeDatabase.Size = new System.Drawing.Size(79, 13);
			this.labelTypeDatabase.TabIndex = 21;
			this.labelTypeDatabase.Text = "Database typ&e:";
			// 
			// textBoxTypeDatabase
			// 
			this.textBoxTypeDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTypeDatabase.Location = new System.Drawing.Point(102, 116);
			this.textBoxTypeDatabase.Name = "textBoxTypeDatabase";
			this.textBoxTypeDatabase.ReadOnly = true;
			this.textBoxTypeDatabase.Size = new System.Drawing.Size(256, 20);
			this.textBoxTypeDatabase.TabIndex = 20;
			// 
			// labelTypeLocal
			// 
			this.labelTypeLocal.AutoSize = true;
			this.labelTypeLocal.Location = new System.Drawing.Point(10, 93);
			this.labelTypeLocal.Name = "labelTypeLocal";
			this.labelTypeLocal.Size = new System.Drawing.Size(59, 13);
			this.labelTypeLocal.TabIndex = 19;
			this.labelTypeLocal.Text = "Local &type:";
			// 
			// textBoxTypeLocal
			// 
			this.textBoxTypeLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTypeLocal.Location = new System.Drawing.Point(102, 90);
			this.textBoxTypeLocal.Name = "textBoxTypeLocal";
			this.textBoxTypeLocal.ReadOnly = true;
			this.textBoxTypeLocal.Size = new System.Drawing.Size(256, 20);
			this.textBoxTypeLocal.TabIndex = 18;
			// 
			// checkBoxNullable
			// 
			this.checkBoxNullable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxNullable.AutoSize = true;
			this.checkBoxNullable.Enabled = false;
			this.checkBoxNullable.Location = new System.Drawing.Point(102, 217);
			this.checkBoxNullable.Name = "checkBoxNullable";
			this.checkBoxNullable.Size = new System.Drawing.Size(73, 17);
			this.checkBoxNullable.TabIndex = 17;
			this.checkBoxNullable.Text = "&Is nullable";
			this.checkBoxNullable.UseVisualStyleBackColor = true;
			// 
			// textBoxNameDisplay
			// 
			this.textBoxNameDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNameDisplay.Location = new System.Drawing.Point(102, 64);
			this.textBoxNameDisplay.Name = "textBoxNameDisplay";
			this.textBoxNameDisplay.ReadOnly = true;
			this.textBoxNameDisplay.Size = new System.Drawing.Size(256, 20);
			this.textBoxNameDisplay.TabIndex = 16;
			// 
			// textBoxNameDatabase
			// 
			this.textBoxNameDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNameDatabase.Location = new System.Drawing.Point(102, 38);
			this.textBoxNameDatabase.Name = "textBoxNameDatabase";
			this.textBoxNameDatabase.ReadOnly = true;
			this.textBoxNameDatabase.Size = new System.Drawing.Size(256, 20);
			this.textBoxNameDatabase.TabIndex = 14;
			// 
			// textBoxNameLocal
			// 
			this.textBoxNameLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNameLocal.Location = new System.Drawing.Point(102, 12);
			this.textBoxNameLocal.Name = "textBoxNameLocal";
			this.textBoxNameLocal.ReadOnly = true;
			this.textBoxNameLocal.Size = new System.Drawing.Size(256, 20);
			this.textBoxNameLocal.TabIndex = 12;
			// 
			// labelDisplayName
			// 
			this.labelDisplayName.AutoSize = true;
			this.labelDisplayName.Location = new System.Drawing.Point(10, 67);
			this.labelDisplayName.Name = "labelDisplayName";
			this.labelDisplayName.Size = new System.Drawing.Size(73, 13);
			this.labelDisplayName.TabIndex = 15;
			this.labelDisplayName.Text = "Display &name:";
			// 
			// labelNameDatabase
			// 
			this.labelNameDatabase.AutoSize = true;
			this.labelNameDatabase.Location = new System.Drawing.Point(10, 41);
			this.labelNameDatabase.Name = "labelNameDatabase";
			this.labelNameDatabase.Size = new System.Drawing.Size(85, 13);
			this.labelNameDatabase.TabIndex = 13;
			this.labelNameDatabase.Text = "&Database name:";
			// 
			// labelNameLocal
			// 
			this.labelNameLocal.AutoSize = true;
			this.labelNameLocal.Location = new System.Drawing.Point(10, 15);
			this.labelNameLocal.Name = "labelNameLocal";
			this.labelNameLocal.Size = new System.Drawing.Size(65, 13);
			this.labelNameLocal.TabIndex = 11;
			this.labelNameLocal.Text = "&Local name:";
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Field");
			this.imageList.Images.SetKeyName(1, "FieldWarning");
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetAnalytics.Resources.Field_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ControlFieldProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlFieldProperties";
			this.Size = new System.Drawing.Size(400, 350);
			this.tabControl.ResumeLayout(false);
			this.tabPageGeneral.ResumeLayout(false);
			this.tabPageGeneral.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageGeneral;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Label labelTypeLocal;
		private System.Windows.Forms.TextBox textBoxTypeLocal;
		private System.Windows.Forms.CheckBox checkBoxNullable;
		private System.Windows.Forms.TextBox textBoxNameDisplay;
		private System.Windows.Forms.TextBox textBoxNameDatabase;
		private System.Windows.Forms.TextBox textBoxNameLocal;
		private System.Windows.Forms.Label labelDisplayName;
		private System.Windows.Forms.Label labelNameDatabase;
		private System.Windows.Forms.Label labelNameLocal;
		private System.Windows.Forms.TextBox textBoxTypeDatabase;
		private System.Windows.Forms.Label labelTypeDatabase;
		private System.Windows.Forms.CheckBox checkBoxConfigured;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Label labelDescription;
	}
}
