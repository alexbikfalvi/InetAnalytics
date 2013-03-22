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
	/// A type representing a database in an SQL Server.
	/// </summary>
	[Serializable]
	public sealed class DbObjectSqlDatabase : DbObjectDatabase
	{
		// Properties.

		[Browsable(true), DisplayName("Source database ID"), ReadOnly(true), Db(DbType.Int32, true, "source_database_id"), Description("The source database ID.")]
		public int? SourceDatabaseId { get; set; }

		[Browsable(true), DisplayName("Owner SID"), ReadOnly(true), Db(DbType.Binary, true, "owner_sid"), Description("The owner ID.")]
		public byte[] OwnerSid { get; set; }

		[Browsable(true), DisplayName("Is read-only"), ReadOnly(true), Db(DbType.Boolean, true, "is_read_only"), Description("Indicates whether the database is read-only.")]
		public bool? IsReadOnly { get; set; }
	}
}
