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
using System.ComponentModel;
using System.Reflection;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing the type of an object that can be stored in a database table.
	/// </summary>
	public abstract class DbType
	{
		private DbMapping mapping;

		/// <summary>
		/// Creates a new database type instance using the specified type mapping.
		/// </summary>
		/// <param name="table">The data table.</param>
		/// <param name="row">The row index.</param>
		/// <param name="mapping">The type mapping.</param>
		public DbType(DbData table, int row, DbMapping mapping)
		{
			this.mapping = mapping;

			// For each property of the current object.
			foreach(PropertyInfo property in this.GetType().GetProperties())
			{
				// Get the property browsable attributes.
				object[] browsableAttributes = property.GetCustomAttributes(typeof(BrowsableAttribute), true);
				// If the property does not have any browsable attribute, continue.
				if (browsableAttributes.Length == 0) continue;
				// Else, get the value of the browsable attribute.
			}
		}

		/// <summary>
		/// Gets the mapping used by the current type.
		/// </summary>
		//public DbMapping Mapping { get { return this.mapping; } }

		//public object GetProperty(PropertyInfo
	}
}
