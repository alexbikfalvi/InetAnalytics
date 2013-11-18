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
using InetCrawler.Tools;

namespace InetAnalytics.Forms.Tools
{
	/// <summary>
	/// A form dialog allowing the selection of a PlanetLab slice.
	/// </summary>
	public sealed partial class FormAddTool : Form
	{
		private bool canClose = true;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormAddTool()
		{
			InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// The selected PlanetLab slice.
		/// </summary>
		//public PlSlice Result { get; private set; }

		// Public methods.

		/// <summary>
		/// Opens the modal dialog to select a PlanetLab object.
		/// </summary>
		/// <param name="owner">The window owner.</param>
		/// <param name="toolbox">The toolbox.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, Toolset toolbox)
		{
			// Reset the result.
			//this.Result = null;
			// Refresh the results list.
			this.control.Refresh(toolbox);
			// Show the dialog.
			return base.ShowDialog(owner);
		}

		// Private methods.

	}
}
