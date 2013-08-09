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
using YtCrawler.Spider;
using YtCrawler.Status;
using YtCrawler.Testing;
using Microsoft.Win32;

namespace YtCrawler
{
	/// <summary>
	/// A class representing the YouTube crawler.
	/// </summary>
	public sealed class Crawler : IDisposable
	{
		private CrawlerConfig config;
		private YouTubeSettings settings;
		private YouTubeCategories categories;
		private Logger log;
		private Status.Status status;
		private Comments.Comments comments;
		private DbServers servers;
		private Spiders spiders;
		private PlanetLab.PlanetLab planetLab;
		private Testing.Testing testing;

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
			this.settings = new YouTubeSettings(this.config.YouTubeV2ApiKey);

			// Create the YouTube categories
			this.categories = new YouTubeCategories(this.config.YouTubeCategoriesFileName);

			// Create the logger.
			this.log = new Logger(this.Config.LogFileName);

			// Create the status.
			this.status = new Status.Status();

			// Create the comments.
			this.comments = new Comments.Comments(this.config);

			// Create the database servers.
			this.servers = new DbServers(this.config);

			// Create the crawler spiders.
			this.spiders = new Spiders(this);

			// Create the PlanetLab configuration.
			this.planetLab = new PlanetLab.PlanetLab(this.config);

			// Create the crawler testing.
			this.testing = new Testing.Testing(rootKey, rootPath);
		}

		/// <summary>
		/// A method called when the object is disposed.
		/// </summary>
		public void Dispose()
		{
			// Close the database servers.
			this.servers.Dispose();
			// Close the log.
			this.log.Dispose();
			// Close the comments.
			this.comments.Dispose();
			// Close the YouTube categories.
			this.categories.Dispose();
			// Close the PlanetLab.
			this.planetLab.Dispose();
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
		public Logger Log { get { return this.log; } }

		/// <summary>
		/// Returns the crawler status.
		/// </summary>
		public Status.Status Status { get { return this.status; } }

		/// <summary>
		/// Returns the crawler comments.
		/// </summary>
		public Comments.Comments Comments { get { return this.comments; } }

		/// <summary>
		/// Returns the database servers.
		/// </summary>
		public DbServers Servers { get { return this.servers; } }

		/// <summary>
		/// Returns the crawler spiders.
		/// </summary>
		public Spiders Spiders { get { return this.spiders; } }

		/// <summary>
		/// Returns the PlanetLab configuration.
		/// </summary>
		public PlanetLab.PlanetLab PlanetLab { get { return this.planetLab; } }

		/// <summary>
		/// Returns the crawler testing configuration.
		/// </summary>
		public Testing.Testing Testing { get { return this.testing; } }
	}
}
