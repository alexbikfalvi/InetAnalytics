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
using System.Linq;
using System.Windows.Forms;
using DotNetApi;
using InetCommon.Tools;
using InetCommon.Forms.Tools;

namespace InetCommon.Controls.Tools
{
	/// <summary>
	/// A control that adds a tool method.
	/// </summary>
	public partial class ControlMethods : UserControl
	{
		private Toolbox toolbox;
		private IEnumerable<ToolMethodTrigger> triggers;

		private readonly HashSet<ToolMethodInfo> methods = new HashSet<ToolMethodInfo>();

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
		public IEnumerable<ToolMethodInfo> Methods { get { return this.methods; } }

		// Public methods.

		/// <summary>
		/// Initializes the current control with the specified toolbox.
		/// </summary>
		/// <param name="toolbox">The toolbox.</param>
		/// <param name="methods">The list of methods.</param>
		/// <param name="triggers">The list of triggers.</param>
		public void Initialize(Toolbox toolbox, string[] methods, IEnumerable<ToolMethodTrigger> triggers)
		{
			// Set the toolbox.
			this.toolbox = toolbox;

			// Set the triggers.
			this.triggers = triggers;
			
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
				// The trigger and method identifiers.
				Guid triggerId;
				ToolMethodId methodId;

				// Try parse the trigger and method identifier.
				if (!ToolMethodInfo.TryParse(id, out triggerId, out methodId)) continue;

				// Get the trigger.
				ToolMethodTrigger trigger = this.triggers.FirstOrDefault(trg => trg.Id == triggerId);

				// If the trigger is default, continue.
				if (default(ToolMethodTrigger) == trigger) continue;

				// Get the tool corresponding to the method.
				Tool tool = this.toolbox.GetTool(methodId.GuidTool, methodId.Version);

				// If the tool is null, continue.
				if (null == tool) continue;

				// Get the method.
				ToolMethod method = tool.GetMethod(methodId.GuidMethod);

				// If the method is null, continue.
				if (null == method) continue;

				// Add the method.
				this.OnAddMethod(trigger, method);
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
				// Get the method information.
				ToolMethodInfo info = this.listViewMethods.Items[index].Tag as ToolMethodInfo;
				// Set the method identifier.
				methods[index] = info.ToString();
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
			if (this.formAddMethod.ShowDialog(this, this.toolbox, this.triggers) == DialogResult.OK)
			{
				// Add the method.
				this.OnAddMethod(this.formAddMethod.Trigger, this.formAddMethod.Method);
			}
		}

		/// <summary>
		/// Adds a new method to the list of methods.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		/// <param name="method">The method.</param>
		private void OnAddMethod(ToolMethodTrigger trigger, ToolMethod method)
		{
			// Compute the method information.
			ToolMethodInfo info = new ToolMethodInfo(trigger, method);

			// Check whether the item already exists.
			if (this.methods.Contains(info)) return;

			// Add the item to the dictionary.
			this.methods.Add(info);

			// Add the method item.
			ListViewItem item = new ListViewItem(new string[] {
				trigger.Description,
				method.Name,
				method.Tool.Info.Name,
				method.Tool.Info.Id.Version.ToString()
			});
			item.ImageKey = "Cube";
			item.Tag = info;
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
			
			// Get the selected method information.
			ToolMethodInfo info = this.listViewMethods.SelectedItems[0].Tag as ToolMethodInfo;

			// Remove the specified method.
			this.methods.Remove(info);

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
				// Get the selected method information.
				ToolMethodInfo info = this.listViewMethods.SelectedItems[0].Tag as ToolMethodInfo;
				// Set the method description.
				this.textBoxDescription.Text = info.Method.Description;
				// Set the remove button enabled state.
				this.buttonRemove.Enabled = true;
			}
			else
			{
				// Set the method description.
				this.textBoxDescription.Clear();
				// Set the remove button enabled state.
				this.buttonRemove.Enabled = false;
			}
		}
	}
}
