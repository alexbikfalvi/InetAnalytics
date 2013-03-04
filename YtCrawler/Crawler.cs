/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using YtApi.Api.V2;
using YtCrawler.Database;
using YtCrawler.Log;
using Microsoft.Win32;

namespace YtCrawler
{
	public class Crawler : IDisposable
	{
		private CrawlerConfig config;
		private YouTubeSettings settings;
		private YouTubeCategories categories;
		private Logger logger;
		private Comments.Comments comments;
		private DbServers servers;

		/// <summary>
		/// Creates a new crawer global object, based on a configuration from the specified root registry key.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="rootPath">The root registry path.</param>
		public Crawler(RegistryKey rootKey, string rootPath)
		{
			// Read the crawler configuration
			this.config = new CrawlerConfig(rootKey, rootPath);

			// Create the YouTube settings
			this.settings = new YouTubeSettings(this.Config.YouTubeV2ApiKey);

			// Create the YouTube categories
			this.categories = new YouTubeCategories();

			// Create the logger.
			this.logger = new Logger(this.Config.LogFileName);

			// Create the comments.
			this.comments = new Comments.Comments(this.Config);

			// Create the database servers.
			this.servers = new DbServers(this.config);
		}

		/// <summary>
		/// A method called when the object is disposed.
		/// </summary>
		public void Dispose()
		{
			// Close the database servers.
			this.servers.Dispose();
			// Close the log.
			this.Log.Dispose();
			// Save the comments.
			this.Comments.Dispose();
		}

		/// <summary>
		/// Returns the crawler configuration.
		/// </summary>
		public CrawlerConfig Config { get { return this.config; } }

		/// <summary>
		/// Returns the YouTube settings.
		/// </summary>
		public YouTubeSettings Settings { get { return this.settings; } }

		/// <summary>
		/// Returns the YouTube categories.
		/// </summary>
		public YouTubeCategories Categories { get { return this.categories; } }

		/// <summary>
		/// Returns the crawler log.
		/// </summary>
		public Logger Log { get { return this.logger; } }

		/// <summary>
		/// Returns the crawler comments.
		/// </summary>
		public Comments.Comments Comments { get { return this.comments; } }
	}
}
