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
using PlanetLab.Api;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A delegate for the PlanetLab manager node event handlers.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void PlManagerNodeEventHandler(object sender, PlManagerNodeEventArgs e);

	/// <summary>
	/// A class representing the PlanetLab manager node event arguments.
	/// </summary>
	public class PlManagerNodeEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new PlanetLab manager node event arguments instance.
		/// </summary>
		/// <param name="state">The manager state.</param>
		/// <param name="node">The PlanetLab node.</param>
		/// <param name="count">Indicates the number of commands to run on the specified node.</param>
		public PlManagerNodeEventArgs(PlManagerState state, PlNode node, int count = 0)
		{
			this.State = state;
			this.Node = node;
			this.Count = count;
		}

		// Public properties.

		/// <summary>
		/// The manager state.
		/// </summary>
		public PlManagerState State { get; private set; }
		/// <summary>
		/// The PlanetLab node.
		/// </summary>
		public PlNode Node { get; private set; }
		/// <summary>
		/// Indicates the number of commands to run on the specified node.
		/// </summary>
		public int Count { get; private set; }
	}
}
