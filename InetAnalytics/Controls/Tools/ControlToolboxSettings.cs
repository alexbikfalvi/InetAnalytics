/* 
 * Copyright (C) 2013 Alex Bikfalvi
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at
 * your option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
 */

using System;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetAnalytics.Forms.Tools;
using InetCrawler;
using InetCrawler.Tools;

namespace InetAnalytics.Controls.Tools
{
	/// <summary>
	/// A class representing the toolbox settings.
	/// </summary>
	public partial class ControlToolboxSettings : ThemeControl
	{
		/// <summary>
		/// A structure representing the control information for a toolbox tool.
		/// </summary>
		private struct ToolboxInfo
		{
			/// <summary>
			/// Creates a new toolbox information instance.
			/// </summary>
			/// <param name="tool">The tool.</param>
			/// <param name="node">The tree node.</param>
			public ToolboxInfo(Tool tool, TreeNode node)
				: this()
			{
				this.Tool = tool;
				this.Node = node;
				this.Control = tool.Control;
			}

			/// <summary>
			/// Gets the tool.
			/// </summary>
			public Tool Tool { get; private set; }
			/// <summary>
			/// Gets the tree node for this tool.
			/// </summary>
			public TreeNode Node { get; private set; }
			/// <summary>
			/// Gets the control for this tool.
			/// </summary>
			public Control Control { get; private set; }
		}

		private Crawler crawler;
		private ImageList imageList;
		private TreeNode treeNode;
		private Control.ControlCollection controls;

		private readonly FormAddTool formAddTool = new FormAddTool();
		private readonly FormToolProperties formToolProperties = new FormToolProperties();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlToolboxSettings()
		{
			InitializeComponent();
		}

		// Public methods.

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="crawler">The crawler.</param>
		/// <param name="treeNode">The root tree node.</param>
		/// <param name="controls">The controls collection.</param>
		public void Initialize(Crawler crawler, ImageList imageList, TreeNode treeNode, Control.ControlCollection controls)
		{
			// Set the parameters.
			this.crawler = crawler;
			this.imageList = imageList;
			this.treeNode = treeNode;
			this.controls = controls;

			// Enable the control.
			this.Enabled = true;

			// Set the image list.
			this.listView.SmallImageList = this.imageList;

			// Set the toolbox event handlers.
			this.crawler.Toolbox.ToolAdded += this.OnToolAdded;
			this.crawler.Toolbox.ToolRemoved += this.OnToolRemoved;

			// Load the current tools from the toolset.
			foreach (Tool tool in this.crawler.Toolbox)
			{
				this.OnAddTool(tool);
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called when adding a tool to the toolbox.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAdd(object sender, EventArgs e)
		{
			// Show the load file dialog.
			if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					// If the user selects a file, open the toolset.
					Toolset toolset = this.crawler.Toolbox.Open(this.openFileDialog.FileName);

					// Show the add tool dialog with the loaded toolset.
					if (this.formAddTool.ShowDialog(this, toolset) == DialogResult.OK)
					{
						// Get the list of added tools.
						ToolId[] tools = this.formAddTool.Result;
						// Add the tools to the toolbox.
						this.crawler.Toolbox.Add(this.openFileDialog.FileName, toolset, tools);
					}
				}
				catch
				{
					// If an error occurs, show an error message.
					MessageBox.Show(this, "Cannot load a toolset from the specified file.", "Cannot Load Toolset", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// An event handler called when removing a tool from the toolbox.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemove(object sender, EventArgs e)
		{
			// If there is no tool selected, do nothing.
			if (0 == this.listView.SelectedItems.Count) return;

			// Get the toolbox information.
			ToolboxInfo info = (ToolboxInfo)this.listView.SelectedItems[0].Tag;

			// Show a confirmation dialog.
			if (MessageBox.Show(
				this,
				@"You are removing the tool '{0}' from toolbox. Upon removal all tasks executed by this tool will be closed and unsaved data will be lost. Do you want to continue?".FormatWith(info.Tool.Info.Name),
				"Confirm Remove the Toolbox Tool",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2) == DialogResult.OK)
			{
				// Remove the tool from the toolbox.
				this.crawler.Toolbox.Remove(info.Tool);
			}
		}

		/// <summary>
		/// An event handler called when viewing the properties of a tool.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			// If there is no tool selected, do nothing.
			if (0 == this.listView.SelectedItems.Count) return;
			
			// Get the toolbox information.
			ToolboxInfo info = (ToolboxInfo)this.listView.SelectedItems[0].Tag;
			
			// Open the tool properties dialog for the selected dialog.
			this.formToolProperties.ShowDialog(this, info.Tool);
		}

		/// <summary>
		/// An event handler called when the selected tool has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectedChanged(object sender, EventArgs e)
		{
			if (this.listView.SelectedItems.Count > 0)
			{
				this.buttonRemove.Enabled = true;
				this.buttonProperties.Enabled = true;
			}
			else
			{
				this.buttonRemove.Enabled = false;
				this.buttonProperties.Enabled = false;
			}
		}

		/// <summary>
		/// An event handler called when a tool was added to the toolbox.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnToolAdded(object sender, ToolEventArgs e)
		{
			this.OnAddTool(e.Tool);
		}

		/// <summary>
		/// An event handler called when a tool was removed from the toolbox.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnToolRemoved(object sender, ToolEventArgs e)
		{
			this.OnRemoveTool(e.Tool);
		}

		/// <summary>
		/// Adds a new tool to the toolbox.
		/// </summary>
		/// <param name="tool">The tool.</param>
		private void OnAddTool(Tool tool)
		{
			// If the tool has a custom icon.
			if (tool.Icon != null)
			{
				// Add the custom icon to the image list.
				this.imageList.Images.Add(tool.Info.Id.ToString(), tool.Icon);
			}

			// Create a new tree node.
			TreeNode node = new TreeNode(tool.Info.Name);
			node.ImageKey = tool.Icon != null ? tool.Info.Id.ToString() : "ToolboxPickAxe";
			node.SelectedImageKey = tool.Icon != null ? tool.Info.Id.ToString() : "ToolboxPickAxe";
			// Add the node to the nodes list.
			this.treeNode.Nodes.Add(node);
			// Expand the tree nodes.
			this.treeNode.ExpandAll();

			// Create the toolbox information.
			ToolboxInfo info = new ToolboxInfo(tool, node);

			// Add the tool to the toolbox list.
			ListViewItem item = new ListViewItem(new string[] {
				tool.Info.Name,
				tool.Toolset.Name,
				tool.Toolset.Author,
				tool.Toolset.Product,
				tool.Toolset.Id.Version.ToString(),
				tool.Info.Id.Version.ToString()
			});
			item.ImageKey = tool.Icon != null ? tool.Info.Id.ToString() : "ToolboxPickAxe";
			item.Tag = info;
			// Add the item to the list.
			this.listView.Items.Add(item);

			// If the tool control is not null.
			if (null != info.Control)
			{
				// Set the control properties.
				info.Control.Dock = DockStyle.Fill;
				info.Control.Visible = false;

				// Add the control.
				this.controls.Add(info.Control);
				node.Tag = info.Control;
			}
		}

		/// <summary>
		/// Removes a new tool to the toolbox.
		/// </summary>
		/// <param name="tool">The tool.</param>
		private void OnRemoveTool(Tool tool)
		{
			// Find the list view item corresponding to the tool.
			ListViewItem item = this.listView.Items.FirstOrDefault((ListViewItem it) =>
				{
					// Return true if the tool matches.
					return object.ReferenceEquals(tool, ((ToolboxInfo)it.Tag).Tool);
				});

			// Get the toolbox information.
			ToolboxInfo info = (ToolboxInfo)item.Tag;

			// Remove the tree node.
			this.treeNode.Nodes.Remove(info.Node);

			// Remove the control.
			this.controls.Remove(info.Control);

			// Remove the list view item.
			this.listView.Items.Remove(item);

			// Call the selection changed event handler.
			this.OnSelectedChanged(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when the use clicks with the mouse on the tools list.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (this.listView.FocusedItem != null)
				{
					if (this.listView.FocusedItem.Bounds.Contains(e.Location))
					{
						this.contextMenu.Show(this.listView, e.Location);
					}
				}
			}
		}
	}
}
