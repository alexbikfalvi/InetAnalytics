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
using PlanetLab.Api;
using PlanetLab.Database;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;

namespace InetAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog that allows exporting the PlanetLab nodes.
	/// </summary>
	public partial class FormExportNodes : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormExportNodes()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public methods.

		/// <summary>
		/// Shows the form as a dialog to export the list of PlanetLab nodes.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="nodes">The list PlanetLab nodes.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, PlDatabaseList<PlNode> nodes)
		{
			// Initialize the control.
			this.control.Initialize(nodes);
			// Call the base class methods.
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handle called when the control raised the closed event.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClosed(object sender, EventArgs e)
		{
			// Set the dialog result.
			this.DialogResult = this.control.Result;
			// Close the dialog.
			this.Close();
		}
	}
}
