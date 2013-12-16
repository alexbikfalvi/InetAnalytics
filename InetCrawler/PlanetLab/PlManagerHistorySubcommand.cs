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
using System.Xml.Linq;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the history of a PlanetLab subcommand.
	/// </summary>
	public sealed class PlManagerHistorySubcommand
	{
		//public static readonly string xmlName = "Subcommand";
		//public static readonly string xmlCommand = "Command";
		//public static readonly string xmlException = "Exception";
		//public static readonly string xmlTimeout = "Timeout";
		//public static readonly string xmlExitStatus = "ExitStatus";
		//public static readonly string xmlResult = "Result";
		//public static readonly string xmlError = "Error";
		//public static readonly string xmlDuration = "Duration";
		//public static readonly string xmlRetries = "Retries";

		/// <summary>
		/// Creates a new subcommand history from the specicified subcommand state.
		/// </summary>
		/// <param name="state">The subcommand state.</param>
		public PlManagerHistorySubcommand(PlManagerSubcommandState state)
		{
			this.Command = state.Command;
			this.Exception = state.Exception != null ? state.Exception.Message : null;
			this.Timeout = state.Timeout;
			this.ExitStatus = state.ExitStatus;
			this.Result = state.Result;
			this.Error = state.Error;
			this.Duration = state.Duration;
			this.Retries = state.Retries;
		}

		/// <summary>
		/// Creates a new subcommand history from the specified XML element.
		/// </summary>
		/// <param name="xml">The XML element.</param>
		public PlManagerHistorySubcommand(XElement xml)
		{

		}

		// Public properties.

		/// <summary>
		/// Gets the command text.
		/// </summary>
		public string Command { get; private set; }
		/// <summary>
		/// Gets the command exception.
		/// </summary>
		public string Exception { get; private set; }
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

		// Public methods.

		///// <summary>
		///// Converts the current object to the corresponding XML element.
		///// </summary>
		///// <returns>The XML element.</returns>
		//public XElement ToXml()
		//{
		//	// Create the XML element.
		//	return new XElement(PlManagerHistorySubcommand.xmlName,
		//		new XElement(PlManagerHistorySubcommand.xmlCommand, this.Command),
		//		new XElement(PlManagerHistorySubcommand.xmlException, this.Exception),
		//		new XAttribute(PlManagerHistorySubcommand.xmlTimeout, this.Timeout),
		//		new XAttribute(PlManagerHistorySubcommand.xmlExitStatus, this.ExitStatus),
		//		new XElement(PlManagerHistorySubcommand.xmlResult, this.Result),
		//		new XElement(PlManagerHistorySubcommand.xmlError, this.Error),
		//		new XAttribute(PlManagerHistorySubcommand.xmlDuration, this.Duration),
		//		new XAttribute(PlManagerHistorySubcommand.xmlRetries, this.Retries)
		//		);
		//}
	}
}
