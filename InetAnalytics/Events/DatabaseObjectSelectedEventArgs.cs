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
using InetCrawler.Database;
using InetCrawler.Database.Data;

namespace InetAnalytics.Events
{
	/// <summary>
	/// A delegate representing a database object selected event handler.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void DatabaseObjectSelectedEventHandler(object sender, DatabaseObjectSelectedEventArgs e);

	/// <summary>
	/// A class representing a database object selected event argument.
	/// </summary>
	public class DatabaseObjectSelectedEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new event instance.
		/// </summary>
		/// <param name="selectedResult">The selected result.</param>
		/// <param name="allResults">All results.</param>
		public DatabaseObjectSelectedEventArgs(DbObject selectedResult, DbDataObject allResults)
		{
			this.SelectedResult = selectedResult;
			this.AllResults = allResults;
		}

		/// <summary>
		/// Gets the selected result.
		/// </summary>
		public DbObject SelectedResult { get; private set; }
		/// <summary>
		/// Gets all result.
		/// </summary>
		public DbDataObject AllResults { get; private set; }
	}
}
