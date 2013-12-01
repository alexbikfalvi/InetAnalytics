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
using InetCrawler.Log;
using InetCrawler.Status;

namespace InetCrawler
{
	/// <summary>
	/// A class representing an internal API for crawler components.
	/// </summary>
	public sealed class CrawlerApi
	{
		private readonly CrawlerConfig config;
		private readonly DbConfig database;
		private readonly Logger log;
		private readonly CrawlerStatus status;

		/// <summary>
		/// Creates a new crawler API instance.
		/// </summary>
		/// <param name="config">The crawler configuration.</param>
		/// <param name="database">The database configuration.</param>
		/// <param name="log">The crawler log.</param>
		/// <param name="status">The crawler status.</param>
		public CrawlerApi(CrawlerConfig config, DbConfig database, Logger log, CrawlerStatus status)
		{
			this.config = config;
			this.database = database;
			this.log = log;
			this.status = status;
		}

		// Public properties.

		/// <summary>
		/// Gets the crawler configuration.
		/// </summary>
		public CrawlerConfig Config { get { return this.config; } }
		/// <summary>
		/// Gets the database configuration.
		/// </summary>
		public DbConfig Database { get { return this.database; } }
		/// <summary>
		/// Gets the crawler log.
		/// </summary>
		public Logger Log { get { return this.log; } }
		/// <summary>
		/// Gets the crawler status.
		/// </summary>
		public CrawlerStatus Status { get { return this.status; } }
	}
}
