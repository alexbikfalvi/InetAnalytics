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
		
		[Browsable(true), DisplayName("Is ANSI padded"), ReadOnly(true), Db(DbType.Boolean, false, "is_ansi_padded"), Description("Indicates if the column is ANSI padded.")]
		public bool IsAnsiPadded { get; set; }
	}
}
