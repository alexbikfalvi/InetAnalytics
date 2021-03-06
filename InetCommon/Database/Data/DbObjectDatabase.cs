﻿/* 
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
using InetCommon.Database;

namespace InetCommon.Database.Data
{
	/// <summary>
	/// A type representing a database in an SQL Server.
	/// </summary>
	[Serializable]
	public class DbObjectDatabase : DbObject
	{
		// Properties.

		[Browsable(true), DisplayName("Name"), ReadOnly(true), Db(DbType.String, false, "name"), Description("The database name.")]
		public string Name { get; set; }

		[Browsable(true), DisplayName("Database ID"), ReadOnly(true), Db(DbType.Int32, false, "database_id"), Description("The database ID.")]
		public int DatabaseId { get; set; }

		[Browsable(true), DisplayName("Create date"), ReadOnly(true), Db(DbType.DateTime, false, "create_date"), Description("The database creation date.")]
		public DateTime CreateDate { get; set; }

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
		public bool Equals(DbObjectDatabase obj)
		{
			return obj != null ? (this.Name == obj.Name) && (this.DatabaseId == obj.DatabaseId) && (this.CreateDate == obj.CreateDate) : false;
		}
	}
}
