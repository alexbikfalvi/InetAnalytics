/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
using DotNetApi.Windows.Controls;
using InetAnalytics.Forms.Tools;
using InetCrawler.Tools;

namespace InetAnalytics.Controls.Tools
{
	/// <summary>
	/// A control that adds tools from a toolbox library.
	/// </summary>
	public partial class ControlAddTool : ThreadSafeControl
	{
		private readonly FormToolInfoProperties formToolProperties = new FormToolInfoProperties();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddTool()
		{
			InitializeComponent();
		}

		// Public events.

		/// <summary>
		/// An event raised when the user adds one or more tools.
		/// </summary>
		public event EventHandler Added;
		/// <summary>
		/// An event raised when the user cancels the tools selection.
		/// </summary>
		public event EventHandler Canceled;

		// Public result.

		/// <summary>
		/// The list of selected tools.
		/// </summary>
		public ToolId[] Result { get; private set; }

		// Public methods.

		/// <summary>
		/// Refreshes the control with the information from the specified toolset.
		/// </summary>
		/// <param name="toolset">The toolset.</param>
		public bool Refresh(Toolset toolset)
		{
			// Reset the buttons.
			this.buttonAdd.Enabled = false;
			this.buttonSelectAll.Enabled = toolset.Tools.Count > 0;
			this.buttonClearAll.Enabled = false;

			// Clear the list.
			this.listView.Items.Clear();

			// Clear the result.
			this.Result = null;
			
			// Set the toolset information.
			this.textBoxName.Text = toolset.Info.Name;
			this.textBoxVersion.Text = toolset.Info.Id.Version.ToString();
			this.textBoxProduct.Text = toolset.Info.Product;
			this.textBoxVendor.Text = toolset.Info.Author;

			// List all tools.
			foreach (Type type in toolset.Tools)
			{
				// Get the tool information.
				ToolInfoAttribute info = Tool.GetToolInfo(type);

				// If the info is not null.
				if (null != info)
				{
					// Create a new item.
					ListViewItem item = new ListViewItem(new string[] { info.Name, info.Id.Version.ToString(), info.Description });
					// Set the item tag.
					item.Tag = info;
					// Set the item as not checked.
					item.Checked = false;
					// Add the item.
					this.listView.Items.Add(item);
				}
			}

			// Return true.
			return true;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when an item was checked.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnItemChecked(object sender, ItemCheckedEventArgs e)
		{
			// Update the button enabled state.
			this.buttonAdd.Enabled = this.listView.CheckedItems.Count > 0;
			this.buttonSelectAll.Enabled = this.listView.CheckedItems.Count < this.listView.Items.Count;
			this.buttonClearAll.Enabled = this.listView.CheckedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user adds a new tool.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAdded(object sender, EventArgs e)
		{
			// Set the result.
			this.Result = new ToolId[this.listView.CheckedItems.Count];
			// Set the tools.
			for (int index = 0; index < this.listView.CheckedItems.Count; index++)
			{
				this.Result[index] = (this.listView.CheckedItems[index].Tag as ToolInfoAttribute).Id;
			}
			// Raise the added event.
			if (null != this.Added) this.Added(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when the user cancels the addition of a new tool.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCanceled(object sender, EventArgs e)
		{
			// Raise the canceled event.
			if (null != this.Canceled) this.Canceled(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when the selected tool has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectedChanged(object sender, EventArgs e)
		{
			// Update the button enabled state.
			this.buttonProperties.Enabled = this.listView.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user selects a tool properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The sender arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			// If there are no selected tools, do nothing.
			if (0 == this.listView.SelectedItems.Count) return;
			// Show the properties dialog.
			this.formToolProperties.ShowDialog(this, this.listView.SelectedItems[0].Tag as Type);
		}

		/// <summary>
		/// An event handler called when selecting all tools.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectAll(object sender, EventArgs e)
		{
			foreach (ListViewItem item in this.listView.Items)
			{
				item.Checked = true;
			}
		}

		/// <summary>
		/// An event handler called when clearing all tools.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClearAll(object sender, EventArgs e)
		{
			foreach (ListViewItem item in this.listView.Items)
			{
				item.Checked = false;
			}
		}
	}
}
