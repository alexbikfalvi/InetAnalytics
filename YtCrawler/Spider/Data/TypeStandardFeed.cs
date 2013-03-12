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
using YtCrawler.Database;

namespace YtCrawler.Spider.Data
{
	/// <summary>
	/// A table representing the crawling state of a standard feed in YouTube API version 2.
	/// </summary>
	public class TypeStandardFeed : DbType
	{
		/// <summary>
		/// Creates a new object instance using data from the specified table row, and using the given mapping.
		/// </summary>
		/// <param name="table">The data table.</param>
		/// <param name="row">The row index.</param>
		/// <param name="mapping">The type mapping.</param>
		public TypeStandardFeed(DbData table, int row, DbMapping mapping)
			: base(table, row, mapping)
		{
			
		}

		[Browsable(true), DisplayName("Feed")]
		public string Feed { get; set; }
		[Browsable(true), DisplayName("Category")]
		public string Category { get; set; }
		[Browsable(true), DisplayName("Time")]
		public string Time { get; set; }
		[Browsable(true), DisplayName("Region")]
		public string Region { get; set; }
		[Browsable(true), DisplayName("Url")]
		public string Url { get; set; }
		[Browsable(true), DisplayName("Browsable")]
		public bool Browsable { get; set; }



		/*
		/// <summary>
		/// Generates an SQL INSERT query for the current object.
		/// </summary>
		/// <returns>The SQL query.</returns>
		public string QueryInsert()
		{
		}

		/// <summary>
		/// Generates an SQL UPDATE query for the current object.
		/// </summary>
		/// <returns>The SQL query.</returns>
		public string QueryUpdate()
		{
		}

		/// <summary>
		/// Generates an SQL DELETE query for the current object.
		/// </summary>
		/// <returns>The SQL query.</returns>
		public string QueryDelete()
		{
		}
		 * */
	}
}
