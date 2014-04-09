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
using System.Collections.Generic;
using System.Windows.Forms;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;
using InetCommon.Tools;

namespace InetControls.Forms.Tools
{
	/// <summary>
	/// A form dialog to add a tool metohod.
	/// </summary>
	public partial class FormAddMethod : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormAddMethod()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// Gets the selected tool method.
		/// </summary>
		public ToolMethod Method
		{
			get { return this.control.Method; }
		}
		/// <summary>
		/// Gets the selected tool trigger.
		/// </summary>
		public ToolMethodTrigger Trigger
		{
			get { return this.control.Trigger; }
		}

		// Public methods.

		/// <summary>
		/// Shows a dialog to add a tool method from the specified toolbox.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="toolbox">The toolbox.</param>
		/// <param name="triggers">The list of triggers.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, Toolbox toolbox, IEnumerable<ToolMethodTrigger> triggers)
		{
			// Initialize the control.
			this.control.Initialize(toolbox, triggers);
			// Show the dialog.
			return base.ShowDialog(owner);
		}

		// Private method.

		/// <summary>
		/// Shows the form.
		/// </summary>
		private new void Show()
		{
			base.Show();
		}

		/// <summary>
		/// Shows the form.
		/// </summary>
		/// <param name="owner">The owner.</param>
		private new void Show(IWin32Window owner)
		{
			base.Show(owner);
		}

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <returns>The dialog result.</returns>
		private new DialogResult ShowDialog()
		{
			return base.ShowDialog();
		}

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <returns>The dialog result.</returns>
		private new DialogResult ShowDialog(IWin32Window owner)
		{
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handler called when the user input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			// Enable the add button.
			this.buttonAdd.Enabled = this.control.Method != null;
		}
	}
}
