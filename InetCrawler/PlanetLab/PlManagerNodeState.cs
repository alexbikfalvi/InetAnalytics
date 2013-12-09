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
using System.Threading;
using PlanetLab.Api;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the state of command execution on a PlanetLab node.
	/// </summary>
	public sealed class PlManagerNodeState
	{
		private readonly PlNode node;
		private readonly List<PlManagerSubcommandState> subcommands = new List<PlManagerSubcommandState>();
		private readonly object sync = new object();

		/// <summary>
		/// Creates a new node state instance.
		/// </summary>
		/// <param name="node">The PlanetLab node.</param>
		internal PlManagerNodeState(PlNode node)
		{
			this.node = node;

			this.CommandIndex = 0;
			this.ParameterIndex = 0;
			this.SuccessCount = 0;
			this.WarningCount = 0;
			this.FailureCount = 0;
		}

		// Public properties.

		/// <summary>
		/// Gets the synchronization object.
		/// </summary>
		public object Sync
		{
			get { return this.sync; }
		}
		/// <summary>
		/// Gets the collection of subcommands that were executed on this node.
		/// </summary>
		public IEnumerable<PlManagerSubcommandState> Subcommands
		{
			get { return this.subcommands; }
		}
		/// <summary>
		/// Gets the PlanetLab node.
		/// </summary>
		public PlNode Node
		{
			get { return this.node; }
		}

		// Internal properties.

		/// <summary>
		/// Gets the current command index.
		/// </summary>
		internal int CommandIndex { get; set; }
		/// <summary>
		/// Gets the current parameter set index.
		/// </summary>
		internal int ParameterIndex { get; set; }
		/// <summary>
		/// Gets the success count.
		/// </summary>
		internal int SuccessCount { get; set; }
		/// <summary>
		/// Gets the warning count.
		/// </summary>
		internal int WarningCount { get; set; }
		/// <summary>
		/// Gets the failure count.
		/// </summary>
		internal int FailureCount { get; set; }

		// Internal methods.

		/// <summary>
		/// Adds a subcommand to the collection of subcommands.
		/// </summary>
		/// <param name="subcommand">The subcommand.</param>
		public void AddSubcommand(PlManagerSubcommandState subcommand)
		{
			lock (this.sync)
			{
				this.subcommands.Add(subcommand);
			}
		}
	}
}
