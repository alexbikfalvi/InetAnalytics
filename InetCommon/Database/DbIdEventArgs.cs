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

namespace InetCommon.Database
{
	/// <summary>
	/// A delegate representing a database identifier event handler.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void DbIdEventHandler(object sender, DbIdEventArgs e);

	/// <summary>
	/// A class representing a database identifier event arguments.
	/// </summary>
	public class DbIdEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new event arguments instance.
		/// </summary>
		/// <param name="id">The database identifier.</param>
		public DbIdEventArgs(Guid id)
		{
			this.Id = id;
		}

		// Public properties.

		/// <summary>
		/// Gets the database identifier.
		/// </summary>
		public Guid Id { get; private set; }
	}
}
