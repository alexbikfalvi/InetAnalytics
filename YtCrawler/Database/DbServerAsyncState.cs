/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
using System.Threading;

namespace YtCrawler.Database
{
	public delegate void DbServerCallback(DbServerAsyncState asyncState);

	/// <summary>
	/// A class representing the asynchronous state for a database operation.
	/// </summary>
	public sealed class DbServerAsyncState
	{
		private object state;

		/// <summary>
		/// Creates a new instance of the asynchronous state.
		/// </summary>
		/// <param name="state">The user state.</param>
		public DbServerAsyncState(object state)
		{
			this.state = state;
		}

		/// <summary>
		/// Gets or sets the asynchronous exception.
		/// </summary>
		public Exception Exception { get; set; }
	}
}
