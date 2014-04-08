﻿/* 
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
	/// A delegate representing a database table event handler.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void DbTableEventHandler(object sender, DbTableEventArgs e);

	/// <summary>
	/// A class representing a database table event arguments.
	/// </summary>
	public class DbTableEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new event arguments instance.
		/// </summary>
		/// <param name="table">The database table.</param>
		public DbTableEventArgs(ITable table)
		{
			this.Table = table;
		}

		// Public properties.

		/// <summary>
		/// Gets the database table.
		/// </summary>
		public ITable Table { get; private set; }
	}
}
