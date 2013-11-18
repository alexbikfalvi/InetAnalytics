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
using InetAnalytics.Events;
using InetCrawler;
using PlanetLab;
using PlanetLab.Api;
using DotNetApi.Windows;

namespace InetAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog allowing the renewal of a PlanetLab slice.
	/// </summary>
	public sealed partial class FormRenewSlice : Form
	{
		private bool canClose = true;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormRenewSlice()
		{
			InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// The selected PlanetLab slice.
		/// </summary>
		public PlSlice Result { get; private set; }

		// Public methods.

		/// <summary>
		/// Opens the modal dialog to select a PlanetLab object.
		/// </summary>
		/// <param name="crawler">The crawler configuration.</param>
		/// <param name="slice">The PlanetLab slice.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(Crawler crawler, PlSlice slice)
		{
			// Reset the result.
			this.Result = null;
			// Refresh the results list.
			this.control.Refresh(crawler, slice);
			// Show the dialog.
			return base.ShowDialog();
		}

		/// <summary>
		/// Opens the modal dialog to select a PlanetLab object.
		/// </summary>
		/// <param name="owner">The window owner.</param>
		/// <param name="crawler">The crawler configuration.</param>
		/// <param name="slice">The PlanetLab slice.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, Crawler crawler, PlSlice slice)
		{
			// Reset the result.
			this.Result = null;
			// Refresh the results list.
			this.control.Refresh(crawler, slice);
			// Show the dialog.
			return base.ShowDialog(owner);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when starting a PlanetLab request.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRequestStarted(object sender, EventArgs e)
		{
			this.canClose = false;
		}

		/// <summary>
		/// An event handler called when finishing to a PlanetLab request.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRequestFinished(object sender, EventArgs e)
		{
			this.canClose = true;
		}

		/// <summary>
		/// An event handler called when the user renewes a PlanetLab slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRenewed(object sender, PlObjectEventArgs<PlSlice> e)
		{
			// Set the result.
			this.Result = e.Object;
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
