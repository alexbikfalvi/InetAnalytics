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
using InetCrawler.Tools;

namespace InetAnalytics.Controls.Tools
{
	/// <summary>
	/// A control that adds tools from a toolbox library.
	/// </summary>
	public partial class ControlAddTool : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddTool()
		{
			InitializeComponent();
		}

		// Public events.

		/// <summary>
		/// An event raised when the user selects one or more tools.
		/// </summary>
		public event EventHandler Selected;
		/// <summary>
		/// An event raised when the user cancels the tools selection.
		/// </summary>
		public event EventHandler Canceled;

		// Public methods.

		/// <summary>
		/// Refreshes the control with the information from the specified toolset.
		/// </summary>
		/// <param name="toolset">The toolset.</param>
		public void Refresh(Toolset toolset)
		{
			// Reset the buttons.
			this.buttonAdd.Enabled = false;
			this.buttonProperties.Enabled = false;

			// Clear the list.
			this.listView.Items.Clear();
			
			// Load the toolset information.
			ToolsetInfoAttribute toolsetInfo = toolset.GetToolsetInfo();

			// If the toolset information is missing.
			if (null == toolsetInfo)
			{
				// Show an error message.
				MessageBox.Show(this, "The selected toolset is invalid.", "Invalid Toolset", MessageBoxButtons.OK, MessageBoxIcon.Error);
				// Cancel the selection.
				if (null != this.Canceled) this.Canceled(this, EventArgs.Empty);
				// Return.
				return;
			}

			// Set the toolset information.
			this.textBoxName.Text = toolsetInfo.Name;
			this.textBoxVersion.Text = toolsetInfo.Version.ToString();
			this.textBoxProduct.Text = toolsetInfo.Product;
			this.textBoxVendor.Text = toolsetInfo.Vendor;

			// List all tools.
			foreach (Type type in toolset.Tools)
			{
				// Get the tool attributes.
				object[] attributes = type.GetCustomAttributes(typeof(ToolInfoAttribute), false);
				// Check the tool type has a tool attribute.
				if (attributes.Length > 0)
				{
					// Get the tool information.
					ToolInfoAttribute toolInfo = attributes[0] as ToolInfoAttribute;
					// Create a new item.
					ListViewItem item = new ListViewItem(new string[] { toolInfo.Name, toolInfo.Info.Version.ToString(), toolInfo.Description });
					// Set the item as not checked.
					item.Checked = false;
					// Add the item.
					this.listView.Items.Add(item);
				}
			}
		}
	}
}
