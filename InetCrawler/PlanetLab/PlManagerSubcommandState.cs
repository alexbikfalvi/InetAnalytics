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
using Renci.SshNet;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the state for a PlanetLab command.
	/// </summary>
	public sealed class PlManagerSubcommandState
	{
		/// <summary>
		/// Creates a new command state instance.
		/// </summary>
		/// <param name="node">The PlanetLab node state.</param>
		/// <param name="command">The secure shell command.</param>
		/// <param name="duration">The subcommand duration.</param>
		/// <param name="retries">The number of retries for this command.</param>
		public PlManagerSubcommandState(PlManagerNodeState node, SshCommand command, TimeSpan duration, int retries)
		{
			this.Node = node;
			this.Command = command.CommandText;
			this.Timeout = command.CommandTimeout;
			this.ExitStatus = command.ExitStatus;
			this.Result = command.Result;
			this.Error = command.Error;
			this.Duration = duration;
			this.Retries = retries;
		}

		/// <summary>
		/// Creates a new command state instance.
		/// </summary>
		/// <param name="node">The PlanetLab node state.</param>
		/// <param name="command">The secure shell command.</param>
		/// <param name="exception">The subcommand exception.</param>
		public PlManagerSubcommandState(PlManagerNodeState node, SshCommand command, Exception exception)
		{
			this.Node = node;
			this.Command = command.CommandText;
			this.Timeout = command.CommandTimeout;
			this.ExitStatus = command.ExitStatus;
			this.Result = command.Result;
			this.Error = command.Error;
			this.Exception = exception;
		}

		// Public properties.

		/// <summary>
		/// Gets the PlanetLab node.
		/// </summary>
		public PlManagerNodeState Node { get; private set; }
		/// <summary>
		/// Gets the command text.
		/// </summary>
		public string Command { get; private set; }
		/// <summary>
		/// Gets the command exception.
		/// </summary>
		public Exception Exception { get; private set; }
		/// <summary>
		/// Gets the command timeout.
		/// </summary>
		public TimeSpan Timeout { get; private set; }
		/// <summary>
		/// Gets the command exit status.
		/// </summary>
		public int ExitStatus { get; private set; }
		/// <summary>
		/// Gets the command result.
		/// </summary>
		public string Result { get; private set; }
		/// <summary>
		/// Gets the command error.
		/// </summary>
		public string Error { get; private set; }
		/// <summary>
		/// Gets the subcommand duration.
		/// </summary>
		public TimeSpan Duration { get; private set; }
		/// <summary>
		/// Gets the number of retries for this command.
		/// </summary>
		public int Retries { get; private set; }
	}
}
