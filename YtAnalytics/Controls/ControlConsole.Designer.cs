namespace YtAnalytics.Controls
{
	partial class ControlConsole
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
			this.layout = new System.Windows.Forms.TableLayoutPanel();
			this.textBox = new System.Windows.Forms.TextBox();
			this.textArea = new System.Windows.Forms.RichTextBox();
			this.label = new System.Windows.Forms.Label();
			this.button = new System.Windows.Forms.Button();
			this.layout.SuspendLayout();
			this.SuspendLayout();
			// 
			// layout
			// 
			this.layout.ColumnCount = 3;
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.layout.Controls.Add(this.textBox, 1, 1);
			this.layout.Controls.Add(this.textArea, 0, 0);
			this.layout.Controls.Add(this.label, 0, 1);
			this.layout.Controls.Add(this.button, 2, 1);
			this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout.Location = new System.Drawing.Point(0, 0);
			this.layout.Name = "layout";
			this.layout.RowCount = 2;
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.layout.Size = new System.Drawing.Size(600, 400);
			this.layout.TabIndex = 3;
			// 
			// textBox
			// 
			this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox.Enabled = false;
			this.textBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox.Location = new System.Drawing.Point(17, 382);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(561, 15);
			this.textBox.TabIndex = 0;
			this.textBox.TextChanged += new System.EventHandler(this.OnCommandChanged);
			this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
			// 
			// textArea
			// 
			this.textArea.BackColor = System.Drawing.Color.Black;
			this.textArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.layout.SetColumnSpan(this.textArea, 3);
			this.textArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textArea.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textArea.ForeColor = System.Drawing.Color.White;
			this.textArea.Location = new System.Drawing.Point(0, 0);
			this.textArea.Margin = new System.Windows.Forms.Padding(0);
			this.textArea.Name = "textArea";
			this.textArea.ReadOnly = true;
			this.textArea.Size = new System.Drawing.Size(600, 379);
			this.textArea.TabIndex = 1;
			this.textArea.Text = "";
			this.textArea.WordWrap = false;
			// 
			// label
			// 
			this.label.AutoSize = true;
			this.label.Dock = System.Windows.Forms.DockStyle.Left;
			this.label.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label.Location = new System.Drawing.Point(0, 379);
			this.label.Margin = new System.Windows.Forms.Padding(0);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(14, 21);
			this.label.TabIndex = 2;
			this.label.Text = ">";
			this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button
			// 
			this.button.Enabled = false;
			this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button.Image = global::YtAnalytics.Resources.PlayStart_16;
			this.button.Location = new System.Drawing.Point(581, 380);
			this.button.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(19, 19);
			this.button.TabIndex = 3;
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler(this.OnClick);
			// 
			// ControlConsole
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.layout);
			this.Name = "ControlConsole";
			this.Size = new System.Drawing.Size(600, 400);
			this.layout.ResumeLayout(false);
			this.layout.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel layout;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.RichTextBox textArea;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Button button;
	}
}
