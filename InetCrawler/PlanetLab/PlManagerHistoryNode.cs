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
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the history for a PlanetLab node.
	/// </summary>
	public sealed class PlManagerHistoryNode
	{
		private readonly List<PlManagerHistorySubcommand> subcommands = new List<PlManagerHistorySubcommand>();

		/// <summary>
		/// Creates a new node history from the specified node state.
		/// </summary>
		/// <param name="state">The node state.</param>
		public PlManagerHistoryNode(PlManagerNodeState state)
		{
			// Validate the argument.
			if (null == state) throw new ArgumentNullException("state");

			// Create the node history commands.
			this.subcommands.AddRange(from subcommand in state.Subcommands select new PlManagerHistorySubcommand(subcommand));
		}

		// Public properties.

		/// <summary>
		/// Gets the node identifier.
		/// </summary>
		public int Id { get; private set; }
		/// <summary>
		/// Gets the node hostname.
		/// </summary>
		public string Hostname { get; private set; }
		/// <summary>
		/// Gets the node success count.
		/// </summary>
		public int Success { get; private set; }
		/// <summary>
		/// Gets the node warning count.
		/// </summary>
		public int Warning { get; private set; }
		/// <summary>
		/// Gets the node failure count.
		/// </summary>
		public int Fail { get; private set; }
		/// <summary>
		/// Gets the list of subcommands.
		/// </summary>
		public IList<PlManagerHistorySubcommand> Subcommands { get; private set; }
	}
}
