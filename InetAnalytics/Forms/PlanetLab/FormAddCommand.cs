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
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;
using InetCrawler.PlanetLab;

namespace InetAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog that adds a PlanetLab command.
	/// </summary>
	public partial class FormAddCommand : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormAddCommand()
		{
			// Initialize the components.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// Gets the current command.
		/// </summary>
		public PlCommand Command
		{
			get { return this.control.Command; }
		}

		// Public methods.

		/// <summary>
		/// Shows the add PlanetLab command dialog.
		/// </summary>
		/// <returns>The dialog result.</returns>
		public new DialogResult ShowDialog()
		{
			// Create a new empty command.
			this.control.Command = new PlCommand();

			// Show the dialog.
			return base.ShowDialog();
		}

		/// <summary>
		/// Shows the add PlanetLab command dialog.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <returns>The dialog result.</returns>
		public new DialogResult ShowDialog(IWin32Window owner)
		{
			// Create a new empty command.
			this.control.Command = new PlCommand();

			// Show the dialog.
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handler called when the command input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			// Set the add button enabled state.
			this.buttonAdd.Enabled = this.control.IsValid;
		}

		/// <summary>
		/// An event handler called when the user clicks on the add button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAdd(object sender, EventArgs e)
		{
			// Save the command.
			this.control.Save();
		}
	}
}
