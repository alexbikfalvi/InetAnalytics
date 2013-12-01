/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using DotNetApi;
using InetCrawler.Database;
using InetCrawler.Database.Data;

namespace InetTools.Tools.Alexa
{
	/// <summary>
	/// A class representing the Alexa history database object.
	/// </summary>
	[Serializable]
	public sealed class AlexaHistoryDbObject : DbObject
	{
		// Public properties.

		[Browsable(true), DisplayName("Timestamp"), ReadOnly(true), Db(DbType.DateTime, false), Description("The date-time of the Alexa ranking.")]
		public string Timestamp { get; set; }

		[Browsable(true), DisplayName("Global"), ReadOnly(true), Db(DbType.Boolean, false), Description("Indicates whether this is the global ranking.")]
		public bool Global { get; set; }

		[Browsable(true), DisplayName("Country"), ReadOnly(true), Db(DbType.String, true), Description("The ranking country if the ranking is not global.")]
		public string Country { get; set; }

		// Methods.

		/// <summary>
		/// The name of the current object.
		/// </summary>
		/// <returns>The name.</returns>
		public override string GetName()
		{
			return "{0} at {1}".FormatWith(this.Country, this.Timestamp);
		}

		/// <summary>
		/// Compares two database objects.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns><b>True</b> if the two objects are equal, <b>false</b> otherwise.</returns>
		public bool Equals(AlexaHistoryDbObject obj)
		{
			return this.Timestamp == obj.Timestamp;
		}
	}
}
