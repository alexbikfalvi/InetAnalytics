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
using DotNetApi.Async;

namespace InetCrawler.Database
{
	/// <summary>
	/// A class representing the state for a database asynchronous operation.
	/// </summary>
	public class DbAsyncResult : AsyncResult
	{
		/// <summary>
		/// Creates a new instance of the asynchronous state.
		/// </summary>
		/// <param name="state">The user state.</param>
		public DbAsyncResult(object state)
			: base(state)
		{
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the asynchronous exception.
		/// </summary>
		public DbException Exception { get; set; }
	}
}
