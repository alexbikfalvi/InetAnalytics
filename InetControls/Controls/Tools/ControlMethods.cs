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
using System.Collections.Generic;
using System.Windows.Forms;
using InetCrawler.Tools;
using InetAnalytics.Forms.Tools;

namespace InetAnalytics.Controls.Tools
{
	/// <summary>
	/// A control that adds a tool method.
	/// </summary>
	public partial class ControlMethods : UserControl
	{
		private Toolbox toolbox;
		private readonly Dictionary<ToolMethodId, ToolMethod> methods = new Dictionary<ToolMethodId, ToolMethod>();

		private readonly FormAddMethod formAddMethod = new FormAddMethod();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlMethods()
		{
			// Initialize the component.
			this.InitializeComponent();
		}

		// Public events.

		/// <summary>
		/// An event raised when the list of methods has changed.
		/// </summary>
		public event EventHandler Changed;

		// Public properties.

		/// <summary>
		/// Gets the enumeration of selected methods.
		/// </summary>
		public IEnumerable<ToolMethod> Methods { get { return this.methods.Values; } }

		// Public methods.

		/// <summary>
		/// Initializes the current control with the specified toolbox.
		/// </summary>
		/// <param name="toolbox">The toolbox.</param>
		/// <param name="methods">The list of methods.</param>
		public void Initialize(Toolbox toolbox, string[] methods)
		{
			// Set the toolbox.
			this.toolbox = toolbox;
			
			// Load the list of methods.
			this.Load(methods);
			
			// Enable the control.
			this.Enabled = true;
		}

		/// <summary>
		/// Loads the specified list of methods from the toolbox.
		/// </summary>
		/// <param name="methods">The methods.</param>
		public new void Load(string[] methods)
		{
			// If the list of methods is null, do nothing.
			if (null == methods) return;

			// Else, for each method identifier.
			foreach (string id in methods)
			{
				// The method identifier structure.
				ToolMethodId methodId;
				// Try parse the method identifier.
				if (!ToolMethodId.TryParse(id, out methodId)) continue;

				// Get the tool corresponding to the method.
				Tool tool = this.toolbox.GetTool(methodId.GuidTool, methodId.Version);

				// If the tool is null, continue.
				if (null == tool) continue;

				// Get the method.
				ToolMethod method = tool.GetMethod(methodId.GuidMethod);

				// If the method is null, continue.
				if (null == method) continue;

				// Add the method.
				this.OnAddMethod(method);
			}
		}

		/// <summary>
		/// Saves the current list of methods to a string array.
		/// </summary>
		/// <returns>The string array with the method identifiers.</returns>
		public string[] Save()
		{
			// Create a new string array.
			string[] methods = new string[this.listViewMethods.Items.Count];

			// For all methods.
			for (int index = 0; index < this.listViewMethods.Items.Count; index++)
			{
				// Get the method.
				ToolMethod method = this.listViewMethods.Items[index].Tag as ToolMethod;
				// Set the method identifier.
				methods[index] = method.Id.ToString();
			}

			// Return the string array.
			return methods;
		}

		// Private methods.

		/// <summary>
		/// Shows a dialog to add a new method to the list of methods.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAdd(object sender, EventArgs e)
		{
			// Show the add method dialog.
			if (this.formAddMethod.ShowDialog(this, this.toolbox) == DialogResult.OK)
			{
				// Add the method.
				this.OnAddMethod(this.formAddMethod.Method);
			}
		}

		/// <summary>
		/// Adds a new method to the list of methods.
		/// </summary>
		/// <param name="method">The method.</param>
		private void OnAddMethod(ToolMethod method)
		{
			// Check whether the item already exists.
			if (this.methods.ContainsKey(method.Id)) return;

			// Add the item to the dictionary.
			this.methods.Add(method.Id, method);

			// Add the method item.
			ListViewItem item = new ListViewItem(new string[] {
					method.Name,
					method.Tool.Info.Name,
					method.Tool.Info.Id.Version.ToString()
				});
			item.ImageKey = "Cube";
			item.Tag = method;
			this.listViewMethods.Items.Add(item);

			// Raise the event.
			if (null != this.Changed) this.Changed(this, EventArgs.Empty);
		}

		/// <summary>
		/// Removes a method from the list of methods.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemove(object sender, EventArgs e)
		{
			// If there is no selected method, do nothing.
			if (this.listViewMethods.SelectedItems.Count == 0) return;
			
			// Get the selected method.
			ToolMethod method = this.listViewMethods.SelectedItems[0].Tag as ToolMethod;

			// Remove the specified method.
			this.methods.Remove(method.Id);

			// Remove the item.
			this.listViewMethods.Items.Remove(this.listViewMethods.SelectedItems[0]);

			// Call the selection changed event handler.
			this.OnSelectionChanged(sender, e);

			// Raise the event.
			if (null != this.Changed) this.Changed(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when the method selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			// If there exists a selected method.
			if (this.listViewMethods.SelectedItems.Count > 0)
			{
				// Get the selected method.
				ToolMethod method = this.listViewMethods.SelectedItems[0].Tag as ToolMethod;
				// Set the method description.
				this.textBoxDescription.Text = method.Description;
				// Set the remove button enabled state.
				this.buttonRemove.Enabled = true;
			}
			else
			{
				// Set the method description.
				this.textBoxDescription.Text = string.Empty;
				// Set the remove button enabled state.
				this.buttonRemove.Enabled = false;
			}
		}
	}
}
