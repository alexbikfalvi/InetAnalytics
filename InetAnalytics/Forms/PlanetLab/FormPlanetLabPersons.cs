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
using PlanetLab;
using PlanetLab.Api;
using DotNetApi.Windows;

namespace InetAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog allowing the selection of the PlanetLab person account.
	/// </summary>
	public sealed partial class FormPlanetLabPersons : Form
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormPlanetLabPersons()
		{
			InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// Gets the selected PlanetLab person.
		/// </summary>
		public PlPerson Result { get; private set; }

		// Public methods.

		/// <summary>
		/// Opens the modal dialog to select a PlanetLab person.
		/// </summary>
		/// <param name="owner">The window owner.</param>
		/// <param name="username">The username of the selected account.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, string username, PlList<PlPerson> persons)
		{
			// Reset the result.
			this.Result = null;
			// Refresh the results list.
			this.control.Refresh(username, persons);
			// Show the dialog.
			return base.ShowDialog(owner);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user cancels the selection.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCancel(object sender, EventArgs e)
		{
			// Set the dialog result.
			this.DialogResult = DialogResult.Cancel;
			// Close the form.
			this.Close();
		}

		/// <summary>
		/// An event handler called when the user selects a PlanetLab person.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelected(object sender, PlObjectEventArgs<PlPerson> e)
		{
			// Set the result.
			this.Result = e.Object;
			// Set the dialog result.
			this.DialogResult = DialogResult.OK;
			// Close the form.
			this.Close();
		}
	}
}
