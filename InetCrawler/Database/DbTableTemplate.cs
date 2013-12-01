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
using InetCrawler.Database.Data;

namespace InetCrawler.Database
{
	/// <summary>
	/// Creates a new table template of the specified type.
	/// </summary>
	/// <typeparam name="T">The table type.</typeparam>
	public sealed class DbTableTemplate<T> : DbTableTemplate where T : DbObject, new()
	{
		/// <summary>
		/// Creates a new database table template.
		/// </summary>
		/// <param name="id">The table identifier.</param>
		/// <param name="localName">The table local name.</param>
		public DbTableTemplate(Guid id, string localName)
			: base(typeof(T), id, localName)
		{
		}
	}

	/// <summary>
	/// A class representing a template for a database table.
	/// </summary>
	public class DbTableTemplate
	{
		/// <summary>
		/// Creates a new database table template.
		/// </summary>
		/// <param name="type">The table type.</param>
		/// <param name="id">The table identifier.</param>
		/// <param name="localName">The table local name.</param>
		public DbTableTemplate(Type type, Guid id, string localName)
		{
			this.Type = type;
			this.Id = id;
			this.LocalName = localName;
		}

		// Public properties.

		/// <summary>
		/// The table type.
		/// </summary>
		public Type Type { get; private set; }
		/// <summary>
		/// The table identifier.
		/// </summary>
		public Guid Id { get; private set; }
		/// <summary>
		/// The table local name.
		/// </summary>
		public string LocalName { get; private set; }
	}
}
