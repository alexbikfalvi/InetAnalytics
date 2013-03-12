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

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing the column properties of a database table.
	/// </summary>
	public class DbColumn
	{
		private string name;
		private Type type;
		private int index;

		/// <summary>
		/// Creates a new table column instance.
		/// </summary>
		/// <param name="name">The column name.</param>
		/// <param name="type">The column type.</param>
		public DbColumn(string name, Type type, int index)
		{
			this.name = name;
			this.type = type;
			this.index = index;
		}
	}
}
