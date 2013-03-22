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
using System.Data;
using YtCrawler.Database;

namespace YtCrawler.Database.Data
{
	/// <summary>
	/// A type representing a table column.
	/// </summary>
	[Serializable]
	public class DbObjectColumn : DbObject
	{
		// Properties.

		[Browsable(true), DisplayName("Object ID"), ReadOnly(true), Db(DbType.Int32, false, "object_id"), Description("The object ID of the corresponding table.")]
		public int ObjectId { get; set; }

		[Browsable(true), DisplayName("Name"), ReadOnly(true), Db(DbType.String, true, "name"), Description("The table name.")]
		public string Name { get; set; }

		[Browsable(true), DisplayName("Column ID"), ReadOnly(true), Db(DbType.Int32, false, "column_id"), Description("The column ID.")]
		public int ColumnId { get; set; }

		// Methods.

		/// <summary>
		/// The name of the current object.
		/// </summary>
		/// <returns>The name.</returns>
		public override string GetName()
		{
			return this.Name;
		}

		/// <summary>
		/// Compares two database objects.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns><b>True</b> if the two objects are equal, <b>false</b> otherwise.</returns>
		public bool Equals(DbObjectColumn obj)
		{
			return (this.Name == obj.Name) && (this.ColumnId == obj.ColumnId);
		}
	}
}
