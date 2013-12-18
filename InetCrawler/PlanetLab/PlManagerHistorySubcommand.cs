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
using System.Xml.Serialization;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the history of a PlanetLab subcommand.
	/// </summary>
	public sealed class PlManagerHistorySubcommand
	{
		/// <summary>
		/// Creates an empty subcommand history.
		/// </summary>
		public PlManagerHistorySubcommand()
		{
		}

		/// <summary>
		/// Creates a new subcommand history from the specified subcommand state.
		/// </summary>
		/// <param name="state">The subcommand state.</param>
		public PlManagerHistorySubcommand(PlManagerSubcommandState state)
		{
			// Validate the argument.
			if (null == state) throw new ArgumentNullException("state");

			// Set the properties.
			this.Command = state.Command;
			this.Exception = state.Exception != null ? state.Exception.Message : null;
			this.Timeout = state.Timeout;
			this.ExitStatus = state.ExitStatus;
			this.Result = state.Result;
			this.Error = state.Error;
			this.Duration = state.Duration;
			this.Retries = state.Retries;
		}

		// Public properties.

		/// <summary>
		/// Gets the command text.
		/// </summary>
		[XmlElement("Command", IsNullable = true)]
		public string Command { get; private set; }
		/// <summary>
		/// Gets the command exception.
		/// </summary>
		[XmlElement("Exception", IsNullable = true)]
		public string Exception { get; private set; }
		/// <summary>
		/// Gets the command timeout.
		/// </summary>
		[XmlAttribute("Timeout")]
		public TimeSpan Timeout { get; private set; }
		/// <summary>
		/// Gets the command exit status.
		/// </summary>
		[XmlAttribute("ExitStatus")]
		public int ExitStatus { get; private set; }
		/// <summary>
		/// Gets the command result.
		/// </summary>
		[XmlElement("Result", IsNullable = true)]
		public string Result { get; private set; }
		/// <summary>
		/// Gets the command error.
		/// </summary>
		[XmlElement("Error", IsNullable = true)]
		public string Error { get; private set; }
		/// <summary>
		/// Gets the subcommand duration.
		/// </summary>
		[XmlAttribute("Duration")]
		public TimeSpan Duration { get; private set; }
		/// <summary>
		/// Gets the number of retries for this command.
		/// </summary>
		[XmlAttribute("Retries")]
		public int Retries { get; private set; }
	}
}
