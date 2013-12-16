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
	/// A delegate for the PlanetLab manager subcommand event handlers.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void PlManagerSubcommandEventHandler(object sender, PlManagerSubcommandEventArgs e);

	/// <summary>
	/// A class representing the PlanetLab manager subcommand event arguments.
	/// </summary>
	public class PlManagerSubcommandEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new PlanetLab manager node event arguments instance.
		/// </summary>
		/// <param name="state">The manager state.</param>
		/// <param name="node">The PlanetLab node.</param>
		/// <param name="command">The PlanetLab command.</param>
		/// <param name="set">The PlanetLab command parameter set.</param>
		/// <param name="subcommand">The PlanetLab subcommand state.</param>
		public PlManagerSubcommandEventArgs(PlManagerState state, PlNode node, PlCommand command, int set, PlManagerSubcommandState subcommand)
		{
			this.State = state;
			this.Node = node;
			this.Command = command;
			this.Set = set;
			this.Subcommand = subcommand;
		}

		/// <summary>
		/// Creates a new PlanetLab manager node event arguments instance.
		/// </summary>
		/// <param name="state">The manager state.</param>
		/// <param name="node">The PlanetLab node.</param>
		/// <param name="command">The PlanetLab command.</param>
		/// <param name="set">The PlanetLab command parameter set.</param>
		/// <param name="exception">The command exception.</param>
		public PlManagerSubcommandEventArgs(PlManagerState state, PlNode node, PlCommand command, int set, Exception exception)
		{
			this.State = state;
			this.Node = node;
			this.Command = command;
			this.Set = set;
			this.Exception = exception;
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
		/// The PlanetLab command.
		/// </summary>
		public PlCommand Command { get; private set; }
		/// <summary>
		/// The PlanetLab command parameter set.
		/// </summary>
		public int Set { get; private set; }
		/// <summary>
		/// The PlanetLab subcommand state.
		/// </summary>
		public PlManagerSubcommandState Subcommand { get; private set; }
		/// <summary>
		/// The exception that occurred during the execution of the PlanetLab command.
		/// </summary>
		public Exception Exception { get; private set; }
	}
}
