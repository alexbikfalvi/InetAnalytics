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
	/// A type representing a table column in an SQL Server.
	/// </summary>
	[Serializable]
	public sealed class DbObjectSqlColumn : DbObjectColumn
	{
		// Properties.
		
		[Browsable(true), DisplayName("System type ID"), ReadOnly(true), Db(DbType.Int32, false, "system_type_id"), Description("The system type ID of the column type.")]
		public int SystemTypeId { get; set; }

		[Browsable(true), DisplayName("User type ID"), ReadOnly(true), Db(DbType.Int32, false, "user_type_id"), Description("The user type ID of the column type.")]
		public int UserTypeId { get; set; }

		[Browsable(true), DisplayName("Maximum length"), ReadOnly(true), Db(DbType.Int32, false, "max_length"), Description("The maximum length for this column.")]
		public int MaximumLength { get; set; }

		[Browsable(true), DisplayName("Precision"), ReadOnly(true), Db(DbType.Int32, false, "precision"), Description("The precision for this column.")]
		public int Precision { get; set; }

		[Browsable(true), DisplayName("Scale"), ReadOnly(true), Db(DbType.Int32, false, "scale"), Description("The scale for this column.")]
		public int Scale { get; set; }

		[Browsable(true), DisplayName("Is nullable"), ReadOnly(true), Db(DbType.Boolean, true, "is_nullable"), Description("Indicates if the column is nullable.")]
		public bool? IsNullable { get; set; }

		[Browsable(true), DisplayName("Is ANSI padded"), ReadOnly(true), Db(DbType.Boolean, false, "is_ansi_padded"), Description("Indicates if the column is ANSI padded.")]
		public bool IsAnsiPadded { get; set; }

		// Methods.

		/// <summary>
		/// Compares two database objects.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns><b>True</b> if the two objects are equal, <b>false</b> otherwise.</returns>
		public bool Equals(DbObjectSqlColumn obj)
		{
			return (this.Name == obj.Name) && (this.ColumnId == obj.ColumnId) && (this.SystemTypeId == obj.SystemTypeId) && (this.UserTypeId == obj.UserTypeId);
		}
	}
}
