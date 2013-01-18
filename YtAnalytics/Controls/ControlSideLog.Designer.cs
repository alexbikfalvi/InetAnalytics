namespace YtAnalytics.Controls
{
	partial class ControlSideLog
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
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.calendar = new System.Windows.Forms.MonthCalendar();
			this.panel = new System.Windows.Forms.Panel();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.labelEnd = new System.Windows.Forms.Label();
			this.labelStart = new System.Windows.Forms.Label();
			this.labelStartText = new System.Windows.Forms.Label();
			this.labelEndText = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel.SuspendLayout();
			this.panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.AutoSize = true;
			this.tableLayoutPanel.ColumnCount = 3;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.Controls.Add(this.calendar, 1, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 1;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(283, 180);
			this.tableLayoutPanel.TabIndex = 1;
			// 
			// calendar
			// 
			this.calendar.Location = new System.Drawing.Point(28, 9);
			this.calendar.MaxSelectionCount = 360;
			this.calendar.Name = "calendar";
			this.calendar.TabIndex = 0;
			this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.OnDateChanged);
			// 
			// panel
			// 
			this.panel.Controls.Add(this.buttonRefresh);
			this.panel.Controls.Add(this.labelEnd);
			this.panel.Controls.Add(this.labelStart);
			this.panel.Controls.Add(this.labelStartText);
			this.panel.Controls.Add(this.labelEndText);
			this.panel.Controls.Add(this.pictureBox);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 180);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(283, 184);
			this.panel.TabIndex = 2;
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRefresh.Location = new System.Drawing.Point(10, 57);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
			this.buttonRefresh.TabIndex = 5;
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefresh);
			// 
			// labelEnd
			// 
			this.labelEnd.AutoSize = true;
			this.labelEnd.Location = new System.Drawing.Point(127, 33);
			this.labelEnd.Name = "labelEnd";
			this.labelEnd.Size = new System.Drawing.Size(0, 13);
			this.labelEnd.TabIndex = 4;
			// 
			// labelStart
			// 
			this.labelStart.AutoSize = true;
			this.labelStart.Location = new System.Drawing.Point(127, 12);
			this.labelStart.Name = "labelStart";
			this.labelStart.Size = new System.Drawing.Size(0, 13);
			this.labelStart.TabIndex = 3;
			// 
			// labelStartText
			// 
			this.labelStartText.AutoSize = true;
			this.labelStartText.Location = new System.Drawing.Point(65, 12);
			this.labelStartText.Name = "labelStartText";
			this.labelStartText.Size = new System.Drawing.Size(56, 13);
			this.labelStartText.TabIndex = 2;
			this.labelStartText.Text = "Start date:";
			// 
			// labelEndText
			// 
			this.labelEndText.AutoSize = true;
			this.labelEndText.Location = new System.Drawing.Point(65, 33);
			this.labelEndText.Name = "labelEndText";
			this.labelEndText.Size = new System.Drawing.Size(53, 13);
			this.labelEndText.TabIndex = 1;
			this.labelEndText.Text = "End date:";
			// 
			// pictureBox
			// 
			this.pictureBox.ErrorImage = global::YtAnalytics.Resources.Log_48;
			this.pictureBox.Image = global::YtAnalytics.Resources.Log_48;
			this.pictureBox.InitialImage = global::YtAnalytics.Resources.Log_48;
			this.pictureBox.Location = new System.Drawing.Point(10, 3);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(48, 48);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// ControlSideLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "ControlSideLog";
			this.Size = new System.Drawing.Size(283, 364);
			this.tableLayoutPanel.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.MonthCalendar calendar;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label labelStartText;
		private System.Windows.Forms.Label labelEndText;
		private System.Windows.Forms.Label labelEnd;
		private System.Windows.Forms.Label labelStart;
		private System.Windows.Forms.Button buttonRefresh;
	}
}
