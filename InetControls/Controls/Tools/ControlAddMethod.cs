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
using InetCrawler.Tools;

namespace InetAnalytics.Controls.Tools
{
	/// <summary>
	/// A control that adds a tool method.
	/// </summary>
	public partial class ControlAddMethod : UserControl
	{
		private Toolbox toolbox;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddMethod()
		{
			// Initialize the component.
			this.InitializeComponent();
		}

		// Public events.

		/// <summary>
		/// An event raised when the input has changed.
		/// </summary>
		public event EventHandler InputChanged;

		// Public properties.

		/// <summary>
		/// Gets the selected tool method.
		/// </summary>
		public ToolMethod Method { get; private set; }

		// Public methods.

		/// <summary>
		/// Initializes the control with the specified toolbox.
		/// </summary>
		/// <param name="toolbox">The toolbox.</param>
		public void Initialize(Toolbox toolbox)
		{
			// Set the toolbox.
			this.toolbox = toolbox;

			// Update the list of tools.
			this.comboBoxTool.Items.Clear();
			foreach (Tool tool in this.toolbox)
			{
				this.comboBoxTool.Items.Add(tool);
			}

			// Clear the list of methods.
			this.listViewMethods.Items.Clear();

			// Call the method selection changed.
			this.OnMethodSelectionChanged(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when the tool selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnToolSelectionChanged(object sender, EventArgs e)
		{
			// If there is no selected tool, do nothing.
			if (this.comboBoxTool.SelectedIndex < 0) return;

			// Get the selected tool.
			Tool tool = this.comboBoxTool.SelectedItem as Tool;

			// Update the list of methods.
			this.listViewMethods.Items.Clear();
			foreach (ToolMethod method in tool.Methods)
			{
				ListViewItem item = new ListViewItem(new string[] { method.Name, method.Id.ToString() });
				item.ImageKey = "Cube";
				item.Tag = method;
				this.listViewMethods.Items.Add(item);
			}

			// Call the method selection changed.
			this.OnMethodSelectionChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when the method selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMethodSelectionChanged(object sender, EventArgs e)
		{
			// If there is a selected method.
			if (this.listViewMethods.SelectedItems.Count > 0)
			{
				// Set the selected method.
				this.Method =  this.listViewMethods.SelectedItems[0].Tag as ToolMethod;

				// Set the method description.
				this.textBoxDescription.Text = this.Method.Description;
			}
			else
			{
				// Set the selected method.
				this.Method = null;

				// Set the method description.
				this.textBoxDescription.Text = string.Empty;
			}

			// Raise the input changed event.
			if (null != this.InputChanged) this.InputChanged(this, EventArgs.Empty);
		}
	}
}
