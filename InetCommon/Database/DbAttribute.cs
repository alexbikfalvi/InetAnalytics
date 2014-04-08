/* 
 * Copyright (C) 2012-2014 Alex Bikfalvi
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
using System.Data;

namespace InetCommon.Database
{
	/// <summary>
	/// A class representing a database name attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class DbAttribute : Attribute
	{
		private DbType type;
		private string name;
		private bool nullable;

		/// <summary>
		/// Creates a new attribute instance.
		/// </summary>
		/// <param name="type">The database type.</param>
		/// <param name="nullable">Indicates if the field is nullable.</param>
		/// <param name="name">The name of the field in the database.</param>
		public DbAttribute(DbType type, bool nullable, string name = null)
		{
			this.name = name;
			this.type = type;
			this.nullable = nullable;
		}

		/// <summary>
		/// Gets the field name.
		/// </summary>
		public string Name { get { return this.name; } }
		/// <summary>
		/// Gets the database type.
		/// </summary>
		public DbType Type { get { return this.type; } }
		/// <summary>
		/// Indicates whether the field is nullable.
		/// </summary>
		public bool IsNullable { get { return this.nullable; } }
	}
}
