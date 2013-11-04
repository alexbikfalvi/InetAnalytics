﻿/* 
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
using InetAnalytics.Events;
using PlanetLab.Api;
using DotNetApi.Windows;

namespace InetAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog allowing the removal of a slice from a PlanetLab node.
	/// </summary>
	public sealed partial class FormRemoveSliceFromNodes : Form
	{
		private bool canClose = true;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormRemoveSliceFromNodes()
		{
			InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// The selected PlanetLab slice.
		/// </summary>
		public int[] Result { get; private set; }

		// Public methods.

		/// <summary>
		/// Opens the modal dialog to remove a slice from one or more PlanetLab nodes.
		/// </summary>
		/// <param name="slice">The PlanetLab slice.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(PlSlice slice)
		{
			// Reset the result.
			this.Result = null;
			// Refresh the results list.
			this.control.Refresh(slice);
			// Show the dialog.
			return base.ShowDialog();
		}

		/// <summary>
		/// Opens the modal dialog to select a PlanetLab object.
		/// </summary>
		/// <param name="owner">The window owner.</param>
		/// <param name="slice">The PlanetLab slice.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, PlSlice slice)
		{
			// Reset the result.
			this.Result = null;
			// Refresh the results list.
			this.control.Refresh(slice);
			// Show the dialog.
			return base.ShowDialog(owner);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when starting to refresh the list of PlanetLab objects.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRequestStarted(object sender, EventArgs e)
		{
			this.canClose = false;
		}

		/// <summary>
		/// An event handler called when finishing to refresh the list of PlanetLab objects.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRequestFinished(object sender, EventArgs e)
		{
			this.canClose = true;
		}

		/// <summary>
		/// An event handler called when the user selects a .
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelected(object sender, ArrayEventArgs<int> e)
		{
			// Set the result.
			this.Result = e.Value;
			// Set the dialog result.
			this.DialogResult = DialogResult.OK;
			// Close the form.
			this.Close();
		}

		/// <summary>
		/// An event handler called when the user closes the dialog.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClosed(object sender, EventArgs e)
		{
			// Set the dialog result.
			this.DialogResult = DialogResult.Cancel;
			// Close the form.
			this.Close();
		}

		/// <summary>
		/// An event handler called when the user is closing the dialog.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			// If the form cannot be closed.
			if (!this.canClose)
			{
				// Cancel the closing.
				e.Cancel = true;
			}
		}
	}
}