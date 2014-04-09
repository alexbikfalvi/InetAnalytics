namespace InetControls.Controls.Tools
{
	partial class ControlAddMethod
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlAddMethod));
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelTool = new System.Windows.Forms.Label();
			this.comboBoxTool = new System.Windows.Forms.ComboBox();
			this.listViewMethods = new System.Windows.Forms.ListView();
			this.columnHeaderMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.groupBoxDescription = new System.Windows.Forms.GroupBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.comboBoxTrigger = new System.Windows.Forms.ComboBox();
			this.labelTrigger = new System.Windows.Forms.Label();
			this.groupBoxDescription.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(75, 34);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(126, 20);
			this.labelTitle.TabIndex = 1;
			this.labelTitle.Text = "Add tool method";
			// 
			// labelTool
			// 
			this.labelTool.AutoSize = true;
			this.labelTool.Location = new System.Drawing.Point(17, 103);
			this.labelTool.Name = "labelTool";
			this.labelTool.Size = new System.Drawing.Size(60, 13);
			this.labelTool.TabIndex = 3;
			this.labelTool.Text = "Select &tool:";
			// 
			// comboBoxTool
			// 
			this.comboBoxTool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTool.FormattingEnabled = true;
			this.comboBoxTool.Location = new System.Drawing.Point(99, 100);
			this.comboBoxTool.Name = "comboBoxTool";
			this.comboBoxTool.Size = new System.Drawing.Size(348, 21);
			this.comboBoxTool.TabIndex = 4;
			this.comboBoxTool.SelectedIndexChanged += new System.EventHandler(this.OnToolSelectionChanged);
			// 
			// listViewMethods
			// 
			this.listViewMethods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewMethods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMethod,
            this.columnHeaderId});
			this.listViewMethods.FullRowSelect = true;
			this.listViewMethods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewMethods.HideSelection = false;
			this.listViewMethods.Location = new System.Drawing.Point(3, 127);
			this.listViewMethods.MultiSelect = false;
			this.listViewMethods.Name = "listViewMethods";
			this.listViewMethods.Size = new System.Drawing.Size(444, 114);
			this.listViewMethods.SmallImageList = this.imageList;
			this.listViewMethods.TabIndex = 5;
			this.listViewMethods.UseCompatibleStateImageBehavior = false;
			this.listViewMethods.View = System.Windows.Forms.View.Details;
			this.listViewMethods.SelectedIndexChanged += new System.EventHandler(this.OnMethodSelectionChanged);
			// 
			// columnHeaderMethod
			// 
			this.columnHeaderMethod.Text = "Method";
			this.columnHeaderMethod.Width = 200;
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
			this.columnHeaderId.Width = 120;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Cube");
			// 
			// groupBoxDescription
			// 
			this.groupBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxDescription.Controls.Add(this.textBoxDescription);
			this.groupBoxDescription.Location = new System.Drawing.Point(3, 247);
			this.groupBoxDescription.Name = "groupBoxDescription";
			this.groupBoxDescription.Size = new System.Drawing.Size(444, 100);
			this.groupBoxDescription.TabIndex = 6;
			this.groupBoxDescription.TabStop = false;
			this.groupBoxDescription.Text = "Description";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxDescription.Location = new System.Drawing.Point(6, 19);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescription.Size = new System.Drawing.Size(432, 75);
			this.textBoxDescription.TabIndex = 0;
			// 
			// pictureBox
			// 
			this.pictureBox.Image = global::InetControls.Resources.CubeAdd_48;
			this.pictureBox.Location = new System.Drawing.Point(20, 20);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			// 
			// comboBoxTrigger
			// 
			this.comboBoxTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTrigger.FormattingEnabled = true;
			this.comboBoxTrigger.Location = new System.Drawing.Point(99, 73);
			this.comboBoxTrigger.Name = "comboBoxTrigger";
			this.comboBoxTrigger.Size = new System.Drawing.Size(348, 21);
			this.comboBoxTrigger.TabIndex = 7;
			this.comboBoxTrigger.SelectedIndexChanged += new System.EventHandler(this.OnTriggerSelectionChanged);
			// 
			// labelTrigger
			// 
			this.labelTrigger.AutoSize = true;
			this.labelTrigger.Location = new System.Drawing.Point(17, 76);
			this.labelTrigger.Name = "labelTrigger";
			this.labelTrigger.Size = new System.Drawing.Size(39, 13);
			this.labelTrigger.TabIndex = 8;
			this.labelTrigger.Text = "&When:";
			// 
			// ControlAddMethod
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelTrigger);
			this.Controls.Add(this.comboBoxTrigger);
			this.Controls.Add(this.groupBoxDescription);
			this.Controls.Add(this.listViewMethods);
			this.Controls.Add(this.labelTool);
			this.Controls.Add(this.comboBoxTool);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.pictureBox);
			this.Name = "ControlAddMethod";
			this.Size = new System.Drawing.Size(450, 350);
			this.groupBoxDescription.ResumeLayout(false);
			this.groupBoxDescription.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelTool;
		private System.Windows.Forms.ComboBox comboBoxTool;
		private System.Windows.Forms.ListView listViewMethods;
		private System.Windows.Forms.ColumnHeader columnHeaderMethod;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.GroupBox groupBoxDescription;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ComboBox comboBoxTrigger;
		private System.Windows.Forms.Label labelTrigger;
	}
}
