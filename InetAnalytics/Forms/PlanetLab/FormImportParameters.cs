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
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;

namespace InetAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog that allows importing parameters for a PlanetLab command.
	/// </summary>
	public partial class FormImportParameters : ThreadSafeForm
	{
		private readonly List<int> selection = new List<int>();

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormImportParameters()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// Gets the parameter selection;
		/// </summary>
		public IEnumerable<int> Selection
		{
			get { return this.selection; }
		}

		// Public methods.

		/// <summary>
		/// Shows the form as a dialog to import parameters for a PlanetLab command.
		/// </summary>
		/// <param name="count">The data count.</param>
		/// <param name="parameters">The parameters count.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, int count, int parameters)
		{
			// Clear the selection.
			this.selection.Clear();

			// Clear the dialog.
			this.buttonImport.Enabled = false;

			// Set the message.
			this.labelText.Text = "The selected file contains {0} lines of data. &Select the command parameters you want to set with this data.{1}{2}The command will add the necessary number of parameter sets.".FormatWith(
				count, Environment.NewLine, Environment.NewLine
				);

			// Initialize the list of parameters.
			this.listParameters.Items.Clear();
			for (int index = 0; index < parameters; index++)
			{
				ListViewItem item = new ListViewItem("Parameter {{{0}}}".FormatWith(index));
				item.Checked = false;
				item.Tag = index;
				this.listParameters.Items.Add(item);
			}

			// Set the select all and clear all enabled state.
			this.buttonSelectAll.Enabled = (this.listParameters.Items.Count > 0) && (this.listParameters.CheckedItems.Count < this.listParameters.Items.Count);
			this.buttonClearAll.Enabled = this.listParameters.CheckedItems.Count > 0;

			return base.ShowDialog(owner);
		}

		// Private methods.

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
		/// An event handler called when the headers check state has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnHeaderChecked(object sender, ItemCheckedEventArgs e)
		{
			this.buttonImport.Enabled = this.listParameters.CheckedItems.Count > 0;
			this.buttonSelectAll.Enabled = (this.listParameters.Items.Count > 0) && (this.listParameters.CheckedItems.Count < this.listParameters.Items.Count);
			this.buttonClearAll.Enabled = this.listParameters.CheckedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user clicks on the save button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnImport(object sender, EventArgs e)
		{
			// Set the selected parameters.
			foreach (ListViewItem item in this.listParameters.CheckedItems)
			{
				this.selection.Add((int)item.Tag);
			}
		}

		/// <summary>
		/// An event handler called when the user selects all headers.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectAll(object sender, EventArgs e)
		{
			foreach (ListViewItem item in this.listParameters.Items)
			{
				item.Checked = true;
			}
		}

		/// <summary>
		/// An event handler called when the user clears all headers.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClearAll(object sender, EventArgs e)
		{
			foreach (ListViewItem item in this.listParameters.Items)
			{
				item.Checked = false;
			}
		}
	}
}
