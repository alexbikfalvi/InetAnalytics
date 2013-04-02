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
	/// A type representing the crawling state of a standard feed in YouTube API version 2.
	/// </summary>
	[Serializable]
	public sealed class DbObjectStandardFeed : DbObject
	{
		// Properties.

		[Browsable(true), DisplayName("ID"), ReadOnly(true), Db(DbType.String, false), Description("The feed primary key.")]
		public string Id { get; set; }

		[Browsable(true), DisplayName("Feed"), ReadOnly(true), Db(DbType.Int32, false), Description("The standard feed numeric ID.")]
		public int FeedId { get; set; }

		[Browsable(true), DisplayName("Time"), ReadOnly(true), Db(DbType.Int32, true), Description("The time numeric ID.")]
		public int TimeId { get; set; }

		[Browsable(true), DisplayName("Category"), ReadOnly(true), Db(DbType.String, true), Description("The video category.")]
		public string Category { get; set; }

		[Browsable(true), DisplayName("Region"), ReadOnly(true), Db(DbType.StringFixedLength, true), Description("The region.")]
		public string Region { get; set; }

		[Browsable(true), DisplayName("Url"), ReadOnly(true), Db(DbType.String, true), Description("The feed URL.")]
		public string Url { get; set; }

		[Browsable(true), DisplayName("Browsable"), ReadOnly(true), Db(DbType.Boolean, false), Description("Indicates whether the feed is browsable.")]
		public bool Browsable { get; set; }

		[Browsable(true), DisplayName("HTTP code"), ReadOnly(true), Db(DbType.Int32, true), Description("Indicates the HTTP response code received from the last access of this feed.")]
		public int? HttpCode { get; set; }

		// Methods.

		/// <summary>
		/// The name of the current object.
		/// </summary>
		/// <returns>The name.</returns>
		public override string GetName()
		{
			return this.Id;
		}

		/// <summary>
		/// Compares two database objects.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns><b>True</b> if the two objects are equal, <b>false</b> otherwise.</returns>
		public bool Equals(DbObjectStandardFeed obj)
		{
			return (this.Id == obj.Id);
		}
	}
}
