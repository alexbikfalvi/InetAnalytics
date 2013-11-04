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

namespace InetCrawler.Log
{
	/// <summary>
	/// A delegate representing a log event handler.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void LogEventHandler(object sender, LogEventArgs e);

	/// <summary>
	/// A class representing a log event arguments.
	/// </summary>
	public class LogEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new event arguments instance.
		/// </summary>
		/// <param name="server">The log event.</param>
		public LogEventArgs(LogEvent evt)
		{
			this.Event = evt;
		}

		// Public properties.

		/// <summary>
		/// Gets the database identifier.
		/// </summary>
		public LogEvent Event { get; private set; }
	}
}
