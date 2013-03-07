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
	/// A class that represents a database record.
	/// </summary>
	public abstract class DbDatabase
	{
		public int id;
		public string name;
		public DateTime dateCreate;

		/// <summary>
		/// Creates a new database instance.
		/// </summary>
		/// <param name="id">The database ID.</param>
		/// <param name="name">The database name.</param>
		/// <param name="dateCreate">The database creation date.</param>
		public DbDatabase(int id, string name, DateTime dateCreate)
		{
			this.id = id;
			this.name = name;
			this.dateCreate = dateCreate;
		}
		/// <summary>
		/// Gets the database ID.
		/// </summary>
		public int Id { get { return this.id; } }
		/// <summary>
		/// Gets the database name.
		/// </summary>
		public string Name { get { return this.name; } }
		/// <summary>
		/// Gets the database creation date.
		/// </summary>
		public DateTime DateCreate { get { return this.dateCreate; } }
	}
}
