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
using DotNetApi;
using InetCrawler.Log;

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class allowing the communication of a tool with the host application.
	/// </summary>
	public sealed class ToolApi : IToolApi
	{
		private readonly Logger log;

		/// <summary>
		/// Creates a new tool API instance.
		/// </summary>
		/// <param name="log">The log.</param>
		public ToolApi(Logger log)
		{
			// Check the arguments.
			if (null == log) throw new ArgumentNullException("log");

			// Set the parameters.
			this.log = log;
		}

		/// <summary>
		/// Logs an event for the specified toolset.
		/// </summary>
		/// <param name="toolset">The toolset.</param>
		/// <param name="level">The log event level.</param>
		/// <param name="type">The log event type.</param>
		/// <param name="message">The event message.</param>
		/// <param name="parameters">The event parameters.</param>
		/// <param name="exception">The event exception.</param>
		public LogEvent Log(Toolset toolset, LogEventLevel level, LogEventType type, string message, object[] parameters = null, Exception exception = null)
		{
			return this.log.Add(
				level,
				type,
				@"Toolbox\{0}".FormatWith(toolset.Info.Name),
				message,
				parameters,
				exception
				);
		}


		/// Logs an event for the specified tool.
		/// </summary>
		/// <param name="tool">The tool.</param>
		/// <param name="level">The log event level.</param>
		/// <param name="type">The log event type.</param>
		/// <param name="message">The event message.</param>
		/// <param name="parameters">The event parameters.</param>
		/// <param name="exception">The event exception.</param>
		public LogEvent Log(Tool tool, LogEventLevel level, LogEventType type, string message, object[] parameters = null, Exception exception = null)
		{
			return this.log.Add(
				level,
				type,
				@"Toolbox\{0}\{1}".FormatWith(tool.Toolset.Name, tool.Info.Name),
				message,
				parameters,
				exception
				);
		}

		/// <summary>
		/// The delay to close a notification message.
		/// </summary>
		/// <returns>The delay.</returns>
		public TimeSpan MessageCloseDelay()
		{
			return CrawlerConfig.Static.ConsoleMessageCloseDelay;
		}
	}
}
