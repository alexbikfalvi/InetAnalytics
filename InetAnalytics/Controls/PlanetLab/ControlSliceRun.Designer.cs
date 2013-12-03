namespace InetAnalytics.Controls.PlanetLab
{
	partial class ControlSliceRun
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
			// If disposing the managed resources.
			if (disposing)
			{
				// Dispose the nodes.
				this.OnDisposeNodes();
				// Remove the slice event handler.
				this.slice.Changed -= this.OnSliceChanged;
				// If the components are not null.
				if (components != null)
				{
					// Dispose the components.
					components.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlSliceRun));
			this.splitContainer = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.panelRun = new DotNetApi.Windows.Controls.ThemeControl();
			this.tabControl = new DotNetApi.Windows.Controls.ThemeTabControl();
			this.tabPageNodes = new System.Windows.Forms.TabPage();
			this.splitContainerNodes = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.listViewNodes = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderHostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.labelNodesParallel = new System.Windows.Forms.Label();
			this.checkBoxNodesSite = new System.Windows.Forms.CheckBox();
			this.checkBoxNodesBoot = new System.Windows.Forms.CheckBox();
			this.checkBoxNodesUpdate = new System.Windows.Forms.CheckBox();
			this.tabPageCommands = new System.Windows.Forms.TabPage();
			this.splitContainerCommands = new DotNetApi.Windows.Controls.ToolSplitContainer();
			this.commandList = new InetAnalytics.Controls.PlanetLab.Commands.CommandListBox();
			this.tabPageLog = new System.Windows.Forms.TabPage();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.buttonRefresh = new System.Windows.Forms.ToolStripButton();
			this.buttonCancel = new System.Windows.Forms.ToolStripButton();
			this.separator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonStart = new System.Windows.Forms.ToolStripButton();
			this.buttonPause = new System.Windows.Forms.ToolStripButton();
			this.buttonStop = new System.Windows.Forms.ToolStripButton();
			this.separator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttonAddCommand = new System.Windows.Forms.ToolStripButton();
			this.buttonRemoveCommand = new System.Windows.Forms.ToolStripButton();
			this.controlLog = new InetAnalytics.Controls.Log.ControlLogList();
			this.legendItemSuccess = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemFail = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemWarning = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.legendItemPending = new DotNetApi.Windows.Controls.ProgressLegendItem();
			this.controlCommand = new InetAnalytics.Controls.PlanetLab.ControlCommand();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelRun.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageNodes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerNodes)).BeginInit();
			this.splitContainerNodes.Panel1.SuspendLayout();
			this.splitContainerNodes.Panel2.SuspendLayout();
			this.splitContainerNodes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.tabPageCommands.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerCommands)).BeginInit();
			this.splitContainerCommands.Panel1.SuspendLayout();
			this.splitContainerCommands.Panel2.SuspendLayout();
			this.splitContainerCommands.SuspendLayout();
			this.toolStrip.SuspendLayout();
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
			this.splitContainer.Panel1.Controls.Add(this.panelRun);
			this.splitContainer.Panel1Border = false;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.controlLog);
			this.splitContainer.Panel2Border = false;
			this.splitContainer.Size = new System.Drawing.Size(800, 600);
			this.splitContainer.SplitterDistance = 425;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 2;
			// 
			// panelRun
			// 
			this.panelRun.Controls.Add(this.tabControl);
			this.panelRun.Controls.Add(this.toolStrip);
			this.panelRun.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRun.Location = new System.Drawing.Point(0, 0);
			this.panelRun.Name = "panelRun";
			this.panelRun.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.panelRun.ShowBorder = true;
			this.panelRun.ShowTitle = true;
			this.panelRun.Size = new System.Drawing.Size(800, 425);
			this.panelRun.TabIndex = 1;
			this.panelRun.Title = "Run on PlanetLab Slice";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageNodes);
			this.tabControl.Controls.Add(this.tabPageCommands);
			this.tabControl.Controls.Add(this.tabPageLog);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(1, 48);
			this.tabControl.Name = "tabControl";
			this.tabControl.Padding = new System.Drawing.Point(0, 0);
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(798, 376);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageNodes
			// 
			this.tabPageNodes.Controls.Add(this.splitContainerNodes);
			this.tabPageNodes.Location = new System.Drawing.Point(2, 23);
			this.tabPageNodes.Name = "tabPageNodes";
			this.tabPageNodes.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageNodes.Size = new System.Drawing.Size(794, 351);
			this.tabPageNodes.TabIndex = 0;
			this.tabPageNodes.Text = "Nodes";
			this.tabPageNodes.UseVisualStyleBackColor = true;
			// 
			// splitContainerNodes
			// 
			this.splitContainerNodes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerNodes.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainerNodes.Location = new System.Drawing.Point(4, 4);
			this.splitContainerNodes.Name = "splitContainerNodes";
			// 
			// splitContainerNodes.Panel1
			// 
			this.splitContainerNodes.Panel1.Controls.Add(this.listViewNodes);
			this.splitContainerNodes.Panel1.Padding = new System.Windows.Forms.Padding(1);
			// 
			// splitContainerNodes.Panel2
			// 
			this.splitContainerNodes.Panel2.AutoScroll = true;
			this.splitContainerNodes.Panel2.Controls.Add(this.numericUpDown1);
			this.splitContainerNodes.Panel2.Controls.Add(this.labelNodesParallel);
			this.splitContainerNodes.Panel2.Controls.Add(this.checkBoxNodesSite);
			this.splitContainerNodes.Panel2.Controls.Add(this.checkBoxNodesBoot);
			this.splitContainerNodes.Panel2.Controls.Add(this.checkBoxNodesUpdate);
			this.splitContainerNodes.Panel2.Padding = new System.Windows.Forms.Padding(1);
			this.splitContainerNodes.Size = new System.Drawing.Size(786, 343);
			this.splitContainerNodes.SplitterDistance = 400;
			this.splitContainerNodes.SplitterWidth = 5;
			this.splitContainerNodes.TabIndex = 0;
			this.splitContainerNodes.UseTheme = false;
			// 
			// listViewNodes
			// 
			this.listViewNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderHostname,
            this.columnHeaderState});
			this.listViewNodes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewNodes.FullRowSelect = true;
			this.listViewNodes.GridLines = true;
			this.listViewNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewNodes.HideSelection = false;
			this.listViewNodes.Location = new System.Drawing.Point(1, 1);
			this.listViewNodes.MultiSelect = false;
			this.listViewNodes.Name = "listViewNodes";
			this.listViewNodes.Size = new System.Drawing.Size(398, 341);
			this.listViewNodes.SmallImageList = this.imageList;
			this.listViewNodes.TabIndex = 1;
			this.listViewNodes.UseCompatibleStateImageBehavior = false;
			this.listViewNodes.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
			// 
			// columnHeaderHostname
			// 
			this.columnHeaderHostname.Text = "Hostname";
			this.columnHeaderHostname.Width = 120;
			// 
			// columnHeaderState
			// 
			this.columnHeaderState.Text = "State";
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "NodeUnknown");
			this.imageList.Images.SetKeyName(1, "NodeBoot");
			this.imageList.Images.SetKeyName(2, "NodeSafeBoot");
			this.imageList.Images.SetKeyName(3, "NodeReinstall");
			this.imageList.Images.SetKeyName(4, "NodeDisabled");
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(10, 92);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(150, 20);
			this.numericUpDown1.TabIndex = 4;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// labelNodesParallel
			// 
			this.labelNodesParallel.AutoSize = true;
			this.labelNodesParallel.Location = new System.Drawing.Point(7, 76);
			this.labelNodesParallel.Name = "labelNodesParallel";
			this.labelNodesParallel.Size = new System.Drawing.Size(308, 13);
			this.labelNodesParallel.TabIndex = 3;
			this.labelNodesParallel.Text = "Run the commands in &parallel on the following number of nodes:";
			// 
			// checkBoxNodesSite
			// 
			this.checkBoxNodesSite.AutoSize = true;
			this.checkBoxNodesSite.Location = new System.Drawing.Point(10, 56);
			this.checkBoxNodesSite.Name = "checkBoxNodesSite";
			this.checkBoxNodesSite.Size = new System.Drawing.Size(199, 17);
			this.checkBoxNodesSite.TabIndex = 2;
			this.checkBoxNodesSite.Text = "Use a &single PlanetLab node per site";
			this.checkBoxNodesSite.UseVisualStyleBackColor = true;
			// 
			// checkBoxNodesBoot
			// 
			this.checkBoxNodesBoot.AutoSize = true;
			this.checkBoxNodesBoot.Location = new System.Drawing.Point(10, 33);
			this.checkBoxNodesBoot.Name = "checkBoxNodesBoot";
			this.checkBoxNodesBoot.Size = new System.Drawing.Size(268, 17);
			this.checkBoxNodesBoot.TabIndex = 1;
			this.checkBoxNodesBoot.Text = "Only use the PlanetLab nodes that are in &boot state";
			this.checkBoxNodesBoot.UseVisualStyleBackColor = true;
			// 
			// checkBoxNodesUpdate
			// 
			this.checkBoxNodesUpdate.AutoSize = true;
			this.checkBoxNodesUpdate.Location = new System.Drawing.Point(10, 10);
			this.checkBoxNodesUpdate.Name = "checkBoxNodesUpdate";
			this.checkBoxNodesUpdate.Size = new System.Drawing.Size(267, 17);
			this.checkBoxNodesUpdate.TabIndex = 0;
			this.checkBoxNodesUpdate.Text = "&Update the PlanetLab nodes information before run";
			this.checkBoxNodesUpdate.UseVisualStyleBackColor = true;
			// 
			// tabPageCommands
			// 
			this.tabPageCommands.Controls.Add(this.splitContainerCommands);
			this.tabPageCommands.Location = new System.Drawing.Point(2, 23);
			this.tabPageCommands.Name = "tabPageCommands";
			this.tabPageCommands.Padding = new System.Windows.Forms.Padding(5);
			this.tabPageCommands.Size = new System.Drawing.Size(794, 351);
			this.tabPageCommands.TabIndex = 1;
			this.tabPageCommands.Text = "Commands";
			this.tabPageCommands.UseVisualStyleBackColor = true;
			// 
			// splitContainerCommands
			// 
			this.splitContainerCommands.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerCommands.Location = new System.Drawing.Point(5, 5);
			this.splitContainerCommands.Name = "splitContainerCommands";
			// 
			// splitContainerCommands.Panel1
			// 
			this.splitContainerCommands.Panel1.Controls.Add(this.commandList);
			this.splitContainerCommands.Panel1.Padding = new System.Windows.Forms.Padding(1);
			// 
			// splitContainerCommands.Panel2
			// 
			this.splitContainerCommands.Panel2.Controls.Add(this.controlCommand);
			this.splitContainerCommands.Panel2Border = false;
			this.splitContainerCommands.Size = new System.Drawing.Size(784, 341);
			this.splitContainerCommands.SplitterDistance = 392;
			this.splitContainerCommands.SplitterWidth = 5;
			this.splitContainerCommands.TabIndex = 0;
			this.splitContainerCommands.UseTheme = false;
			// 
			// commandList
			// 
			this.commandList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.commandList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.commandList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.commandList.FormattingEnabled = true;
			this.commandList.IntegralHeight = false;
			this.commandList.ItemHeight = 48;
			this.commandList.Location = new System.Drawing.Point(1, 1);
			this.commandList.Name = "commandList";
			this.commandList.Size = new System.Drawing.Size(390, 339);
			this.commandList.TabIndex = 0;
			this.commandList.SelectedIndexChanged += new System.EventHandler(this.OnCommandSelectionChanged);
			// 
			// tabPageLog
			// 
			this.tabPageLog.Location = new System.Drawing.Point(2, 23);
			this.tabPageLog.Name = "tabPageLog";
			this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLog.Size = new System.Drawing.Size(794, 351);
			this.tabPageLog.TabIndex = 3;
			this.tabPageLog.Text = "Log";
			this.tabPageLog.UseVisualStyleBackColor = true;
			// 
			// toolStrip
			// 
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonRefresh,
            this.buttonCancel,
            this.separator1,
            this.buttonStart,
            this.buttonPause,
            this.buttonStop,
            this.separator2,
            this.buttonAddCommand,
            this.buttonRemoveCommand});
			this.toolStrip.Location = new System.Drawing.Point(1, 23);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(798, 25);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip1";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Image = global::InetAnalytics.Resources.Refresh_16;
			this.buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(66, 22);
			this.buttonRefresh.Text = "&Refresh";
			this.buttonRefresh.Click += new System.EventHandler(this.OnRefreshSlice);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(47, 22);
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// separator1
			// 
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonStart
			// 
			this.buttonStart.Enabled = false;
			this.buttonStart.Image = global::InetAnalytics.Resources.PlayStart_16;
			this.buttonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(51, 22);
			this.buttonStart.Text = "St&art";
			this.buttonStart.Click += new System.EventHandler(this.OnStart);
			// 
			// buttonPause
			// 
			this.buttonPause.Enabled = false;
			this.buttonPause.Image = global::InetAnalytics.Resources.PlayPause_16;
			this.buttonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonPause.Name = "buttonPause";
			this.buttonPause.Size = new System.Drawing.Size(58, 22);
			this.buttonPause.Text = "&Pause";
			this.buttonPause.Click += new System.EventHandler(this.OnPause);
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Image = global::InetAnalytics.Resources.PlayStop_16;
			this.buttonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(51, 22);
			this.buttonStop.Text = "St&op";
			this.buttonStop.Click += new System.EventHandler(this.OnStop);
			// 
			// separator2
			// 
			this.separator2.Name = "separator2";
			this.separator2.Size = new System.Drawing.Size(6, 25);
			// 
			// buttonAddCommand
			// 
			this.buttonAddCommand.Image = global::InetAnalytics.Resources.ScriptLargeAdd_16;
			this.buttonAddCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonAddCommand.Name = "buttonAddCommand";
			this.buttonAddCommand.Size = new System.Drawing.Size(107, 22);
			this.buttonAddCommand.Text = "&Add command";
			this.buttonAddCommand.Click += new System.EventHandler(this.OnAddCommand);
			// 
			// buttonRemoveCommand
			// 
			this.buttonRemoveCommand.Enabled = false;
			this.buttonRemoveCommand.Image = global::InetAnalytics.Resources.ScriptLargeRemove_16;
			this.buttonRemoveCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttonRemoveCommand.Name = "buttonRemoveCommand";
			this.buttonRemoveCommand.Size = new System.Drawing.Size(128, 22);
			this.buttonRemoveCommand.Text = "&Remove command";
			this.buttonRemoveCommand.Click += new System.EventHandler(this.OnRemoveCommand);
			// 
			// controlLog
			// 
			this.controlLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlLog.Location = new System.Drawing.Point(0, 0);
			this.controlLog.Name = "controlLog";
			this.controlLog.Padding = new System.Windows.Forms.Padding(1, 23, 1, 1);
			this.controlLog.ShowBorder = true;
			this.controlLog.ShowTitle = true;
			this.controlLog.Size = new System.Drawing.Size(800, 170);
			this.controlLog.TabIndex = 0;
			this.controlLog.Title = "Log";
			// 
			// legendItemSuccess
			// 
			this.legendItemSuccess.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.legendItemSuccess.Text = "Success";
			// 
			// legendItemFail
			// 
			this.legendItemFail.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.legendItemFail.Text = "Fail";
			// 
			// legendItemWarning
			// 
			this.legendItemWarning.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.legendItemWarning.Text = "Warning";
			// 
			// legendItemPending
			// 
			this.legendItemPending.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.legendItemPending.Text = "Pending";
			// 
			// controlCommand
			// 
			this.controlCommand.Command = null;
			this.controlCommand.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlCommand.HideSave = false;
			this.controlCommand.Location = new System.Drawing.Point(0, 0);
			this.controlCommand.Name = "controlCommand";
			this.controlCommand.Size = new System.Drawing.Size(387, 341);
			this.controlCommand.TabIndex = 0;
			// 
			// ControlSliceRun
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Enabled = false;
			this.Name = "ControlSliceRun";
			this.Size = new System.Drawing.Size(800, 600);
			this.Controls.SetChildIndex(this.splitContainer, 0);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.panelRun.ResumeLayout(false);
			this.panelRun.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageNodes.ResumeLayout(false);
			this.splitContainerNodes.Panel1.ResumeLayout(false);
			this.splitContainerNodes.Panel2.ResumeLayout(false);
			this.splitContainerNodes.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerNodes)).EndInit();
			this.splitContainerNodes.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.tabPageCommands.ResumeLayout(false);
			this.splitContainerCommands.Panel1.ResumeLayout(false);
			this.splitContainerCommands.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerCommands)).EndInit();
			this.splitContainerCommands.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainer;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemPending;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemSuccess;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemFail;
		private DotNetApi.Windows.Controls.ProgressLegendItem legendItemWarning;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ImageList imageList;
		private Log.ControlLogList controlLog;
		private DotNetApi.Windows.Controls.ThemeControl panelRun;
		private System.Windows.Forms.ToolStripButton buttonRefresh;
		private System.Windows.Forms.ToolStripButton buttonCancel;
		private DotNetApi.Windows.Controls.ThemeTabControl tabControl;
		private System.Windows.Forms.TabPage tabPageNodes;
		private System.Windows.Forms.TabPage tabPageCommands;
		private System.Windows.Forms.TabPage tabPageLog;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerNodes;
		private System.Windows.Forms.CheckBox checkBoxNodesBoot;
		private System.Windows.Forms.CheckBox checkBoxNodesUpdate;
		private System.Windows.Forms.CheckBox checkBoxNodesSite;
		private System.Windows.Forms.ListView listViewNodes;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderHostname;
		private System.Windows.Forms.ColumnHeader columnHeaderState;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label labelNodesParallel;
		private DotNetApi.Windows.Controls.ToolSplitContainer splitContainerCommands;
		private System.Windows.Forms.ToolStripSeparator separator1;
		private System.Windows.Forms.ToolStripButton buttonStart;
		private System.Windows.Forms.ToolStripButton buttonStop;
		private System.Windows.Forms.ToolStripButton buttonPause;
		private System.Windows.Forms.ToolStripSeparator separator2;
		private System.Windows.Forms.ToolStripButton buttonAddCommand;
		private System.Windows.Forms.ToolStripButton buttonRemoveCommand;
		private Commands.CommandListBox commandList;
		private ControlCommand controlCommand;
	}
}
