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

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A delegate representing a PlanetLab command event handler.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void PlCommandEventHandler(object sender, PlCommandEventArgs e);

	/// <summary>
	/// A class representing PlanetLab command event arguments.
	/// </summary>
	public class PlCommandEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new event arguments instance.
		/// </summary>
		/// <param name="command">The PlanetLab command.</param>
		public PlCommandEventArgs(PlCommand command)
		{
			this.Command = command;
		}

		// Public properties.

		/// <summary>
		/// The PlanetLab command.
		/// </summary>
		public PlCommand Command { get; private set; }
	}
}
