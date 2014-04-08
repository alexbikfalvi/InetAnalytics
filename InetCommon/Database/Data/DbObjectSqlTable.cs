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
using InetCommon.Database;

namespace InetCommon.Database.Data
{
	/// <summary>
	/// A type representing a table in an SQL Server.
	/// </summary>
	[Serializable]
	public sealed class DbObjectSqlTable : DbObjectTable
	{
		// Properties.

		[Browsable(true), DisplayName("Object ID"), ReadOnly(true), Db(DbType.Int32, false, "object_id"), Description("The table object ID.")]
		public int ObjectId { get; set; }

		[Browsable(true), DisplayName("Principal ID"), ReadOnly(true), Db(DbType.Int32, true, "object_id"), Description("The table principal ID.")]
		public int? PrincipalId { get; set; }

		[Browsable(true), DisplayName("Schema ID"), ReadOnly(true), Db(DbType.Int32, false, "schema_id"), Description("The table schema ID.")]
		public int SchemaId { get; set; }

		[Browsable(true), DisplayName("Parent object ID"), ReadOnly(true), Db(DbType.Int32, false, "parent_object_id"), Description("The table parent object ID.")]
		public int ParentObjectId { get; set; }

		[Browsable(true), DisplayName("Type"), ReadOnly(true), Db(DbType.StringFixedLength, false, "type"), Description("The table type.")]
		public string Type { get; set; }

		[Browsable(true), DisplayName("Type description"), ReadOnly(true), Db(DbType.String, true, "type_desc"), Description("The table type description.")]
		public string TypeDescription { get; set; }

		[Browsable(true), DisplayName("Create date"), ReadOnly(true), Db(DbType.DateTime, false, "create_date"), Description("The table creation date.")]
		public DateTime CreateDate { get; set; }

		[Browsable(true), DisplayName("Modify date"), ReadOnly(true), Db(DbType.DateTime, false, "modify_date"), Description("The table last modification date.")]
		public DateTime ModifyDate { get; set; }

		[Browsable(true), DisplayName("Is Microsoft shipped"), ReadOnly(true), Db(DbType.Boolean, false, "is_ms_shipped"), Description("Indicates if the table is created by default in the SQL server.")]
		public bool IsMsShipped { get; set; }

		[Browsable(true), DisplayName("Is published"), ReadOnly(true), Db(DbType.Boolean, false, "is_published"), Description("Indicates if the table is published.")]
		public bool IsPublished { get; set; }

		[Browsable(true), DisplayName("Is schema published"), ReadOnly(true), Db(DbType.Boolean, false, "is_schema_published"), Description("Indicates if the table schema is published.")]
		public bool IsSchemaPublished { get; set; }
	}
}
