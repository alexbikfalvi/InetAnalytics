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
using InetCrawler.Log;

namespace InetCrawler.Tools
{
	/// <summary>
	/// An interface allowing the communication of a tool with the host application.
	/// </summary>
	public interface IToolApi
	{
		// Configuration.

		/// <summary>
		/// Gets the tool configuration.
		/// </summary>
		IToolConfig Config { get; }

		// Log.

		/// Logs an event for the specified tool.
		/// </summary>
		/// <param name="level">The log event level.</param>
		/// <param name="type">The log event type.</param>
		/// <param name="message">The event message.</param>
		/// <param name="parameters">The event parameters.</param>
		/// <param name="exception">The event exception.</param>
		LogEvent Log(LogEventLevel level, LogEventType type, string message, object[] parameters = null, Exception exception = null);
	}
}
