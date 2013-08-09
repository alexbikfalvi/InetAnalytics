namespace YtAnalytics.Controls.YouTube
{
	partial class ControlCategoryProperties
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
			this.labelTitle = new System.Windows.Forms.Label();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageGeneral = new System.Windows.Forms.TabPage();
			this.listViewBrowsable = new System.Windows.Forms.ListView();
			this.checkBoxDeprecated = new System.Windows.Forms.CheckBox();
			this.textBoxLabel = new System.Windows.Forms.TextBox();
			this.textBoxTerm = new System.Windows.Forms.TextBox();
			this.labelBrowsable = new System.Windows.Forms.Label();
			this.checkBoxAssignable = new System.Windows.Forms.CheckBox();
			this.labelLabel = new System.Windows.Forms.Label();
			this.labelTerm = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
			this.labelTitle.Size = new System.Drawing.Size(108, 13);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "No category selected";
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
			this.tabPageGeneral.Controls.Add(this.listViewBrowsable);
			this.tabPageGeneral.Controls.Add(this.checkBoxDeprecated);
			this.tabPageGeneral.Controls.Add(this.textBoxLabel);
			this.tabPageGeneral.Controls.Add(this.textBoxTerm);
			this.tabPageGeneral.Controls.Add(this.labelBrowsable);
			this.tabPageGeneral.Controls.Add(this.checkBoxAssignable);
			this.tabPageGeneral.Controls.Add(this.labelLabel);
			this.tabPageGeneral.Controls.Add(this.labelTerm);
			this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabPageGeneral.Name = "tabPageGeneral";
			this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGeneral.Size = new System.Drawing.Size(386, 263);
			this.tabPageGeneral.TabIndex = 0;
			this.tabPageGeneral.Text = "General";
			this.tabPageGeneral.UseVisualStyleBackColor = true;
			// 
			// listViewBrowsable
			// 
			this.listViewBrowsable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewBrowsable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
			this.listViewBrowsable.Location = new System.Drawing.Point(102, 87);
			this.listViewBrowsable.Name = "listViewBrowsable";
			this.listViewBrowsable.Size = new System.Drawing.Size(256, 170);
			this.listViewBrowsable.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listViewBrowsable.TabIndex = 7;
			this.listViewBrowsable.UseCompatibleStateImageBehavior = false;
			this.listViewBrowsable.View = System.Windows.Forms.View.List;
			// 
			// checkBoxDeprecated
			// 
			this.checkBoxDeprecated.AutoSize = true;
			this.checkBoxDeprecated.Enabled = false;
			this.checkBoxDeprecated.Location = new System.Drawing.Point(185, 64);
			this.checkBoxDeprecated.Name = "checkBoxDeprecated";
			this.checkBoxDeprecated.Size = new System.Drawing.Size(82, 17);
			this.checkBoxDeprecated.TabIndex = 5;
			this.checkBoxDeprecated.Text = "&Deprecated";
			this.checkBoxDeprecated.UseVisualStyleBackColor = true;
			// 
			// textBoxLabel
			// 
			this.textBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLabel.Location = new System.Drawing.Point(102, 38);
			this.textBoxLabel.Name = "textBoxLabel";
			this.textBoxLabel.ReadOnly = true;
			this.textBoxLabel.Size = new System.Drawing.Size(256, 20);
			this.textBoxLabel.TabIndex = 3;
			// 
			// textBoxTerm
			// 
			this.textBoxTerm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTerm.Location = new System.Drawing.Point(102, 12);
			this.textBoxTerm.Name = "textBoxTerm";
			this.textBoxTerm.ReadOnly = true;
			this.textBoxTerm.Size = new System.Drawing.Size(256, 20);
			this.textBoxTerm.TabIndex = 1;
			// 
			// labelBrowsable
			// 
			this.labelBrowsable.AutoSize = true;
			this.labelBrowsable.Location = new System.Drawing.Point(10, 90);
			this.labelBrowsable.Name = "labelBrowsable";
			this.labelBrowsable.Size = new System.Drawing.Size(59, 13);
			this.labelBrowsable.TabIndex = 6;
			this.labelBrowsable.Text = "&Browsable:";
			// 
			// checkBoxAssignable
			// 
			this.checkBoxAssignable.AutoSize = true;
			this.checkBoxAssignable.Enabled = false;
			this.checkBoxAssignable.Location = new System.Drawing.Point(102, 64);
			this.checkBoxAssignable.Name = "checkBoxAssignable";
			this.checkBoxAssignable.Size = new System.Drawing.Size(77, 17);
			this.checkBoxAssignable.TabIndex = 4;
			this.checkBoxAssignable.Text = "&Assignable";
			this.checkBoxAssignable.UseVisualStyleBackColor = true;
			// 
			// labelLabel
			// 
			this.labelLabel.AutoSize = true;
			this.labelLabel.Location = new System.Drawing.Point(10, 41);
			this.labelLabel.Name = "labelLabel";
			this.labelLabel.Size = new System.Drawing.Size(36, 13);
			this.labelLabel.TabIndex = 2;
			this.labelLabel.Text = "&Label:";
			// 
			// labelTerm
			// 
			this.labelTerm.AutoSize = true;
			this.labelTerm.Location = new System.Drawing.Point(10, 15);
			this.labelTerm.Name = "labelTerm";
			this.labelTerm.Size = new System.Drawing.Size(34, 13);
			this.labelTerm.TabIndex = 0;
			this.labelTerm.Text = "&Term:";
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::YtAnalytics.Resources.Category_32;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(32, 32);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// columnHeader
			// 
			this.columnHeader.Text = "Country";
			this.columnHeader.Width = 30;
			// 
			// ControlCategoryProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlCategoryProperties";
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
		private System.Windows.Forms.Label labelLabel;
		private System.Windows.Forms.TextBox textBoxLabel;
		private System.Windows.Forms.CheckBox checkBoxAssignable;
		private System.Windows.Forms.Label labelBrowsable;
		private System.Windows.Forms.TextBox textBoxTerm;
		private System.Windows.Forms.Label labelTerm;
		private System.Windows.Forms.CheckBox checkBoxDeprecated;
		private System.Windows.Forms.ListView listViewBrowsable;
		private System.Windows.Forms.ColumnHeader columnHeader;
	}
}
