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
using Microsoft.Win32;
using InetCommon;
using InetCommon.Database;
using InetCommon.Net;
using InetCommon.Log;
using InetCommon.Status;
using InetCommon.Tools;
using InetCrawler.Comments;
using InetCrawler.Events;
using InetCrawler.PlanetLab;
using InetCrawler.Spider;
using InetCrawler.YouTube;

namespace InetCrawler
{
	/// <summary>
	/// A class representing the YouTube crawler.
	/// </summary>
	public sealed class Crawler : IDbApplication, IDisposable
	{
		private readonly CrawlerConfig config;
		private readonly CrawlerEvents events;
		private readonly CrawlerApi api;
		private readonly Toolbox toolbox;
		private readonly Logger log;
		private readonly DbConfig dbConfig;
		private readonly PlConfig plConfig;
		private readonly YtConfig ytConfig;
		private readonly Spiders spiders;
		private readonly ApplicationStatus status;
		private readonly CrawlerComments comments;
		
		/// <summary>
		/// Creates a new crawer global object, based on a configuration from the specified root registry key.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="rootPath">The root registry path.</param>
		public Crawler(RegistryKey rootKey, string rootPath)
		{
			// Create the configuration.
			this.config = new CrawlerConfig(rootKey, rootPath);

			// Create the crawler events.
			this.events = new CrawlerEvents();

			// Create the logger.
			this.log = new Logger(this.config.LogFileName);

			// Create the database servers.
			this.dbConfig = new DbConfig(this, rootKey, rootPath + @"\Database");

			// Create the PlanetLab configuration.
			this.plConfig = new PlConfig(rootKey, rootPath + @"\PlanetLab");

			// Create the YouTube configuration.
			this.ytConfig = new YtConfig(this.config);

			// Create the status.
			this.status = new ApplicationStatus();

			// Create the comments.
			this.comments = new CrawlerComments(this.config);

			// Create the crawler spiders.
			this.spiders = new Spiders(this);

			// Create the crawler API.
			this.api = new CrawlerApi(this.config, this.dbConfig, this.log, this.status);

			// Create the toolbox.
			this.toolbox = new Toolbox(this, rootKey, rootPath + @"\Toolbox");
		}

		#region Public properties

		/// <summary>
		/// Gets the crawler configuration.
		/// </summary>
		IApplicationConfig IApplication.Config { get { return this.config; } }
		/// <summary>
		/// Gets the crawler configuration.
		/// </summary>
		IDbApplicationConfig IDbApplication.Config { get { return this.config; } }
		/// <summary>
		/// Gets the crawler configuration.
		/// </summary>
		public CrawlerConfig Config { get { return this.config; } }
		/// <summary>
		/// Gets the crawler events.
		/// </summary>
		public CrawlerEvents Events { get { return this.events; } }
		/// <summary>
		/// Gets the database configuration.
		/// </summary>
		public DbConfig Database { get { return this.dbConfig; } }
		/// <summary>
		/// Gets the PlanetLab configuration.
		/// </summary>
		public PlConfig PlanetLab { get { return this.plConfig; } }
		/// <summary>
		/// Gets the YouTube configuration.
		/// </summary>
		public YtConfig YouTube { get { return this.ytConfig; } }
		/// <summary>
		/// Returns the crawler spiders.
		/// </summary>
		public Spiders Spiders { get { return this.spiders; } }
		/// <summary>
		/// Returns the crawler log.
		/// </summary>
		public Logger Log { get { return this.log; } }
		/// <summary>
		/// Returns the toolbox.
		/// </summary>
		public Toolbox Toolbox { get { return this.toolbox; } }
		/// <summary>
		/// Returns the crawler status.
		/// </summary>
		public ApplicationStatus Status { get { return this.status; } }
		/// <summary>
		/// Returns the crawler comments.
		/// </summary>
		public CrawlerComments Comments { get { return this.comments; } }

		#endregion

		#region Public methods

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Close the toolbox.
			this.toolbox.Dispose();
			// Close the database configuration.
			this.dbConfig.Dispose();
			// Close the PlanetLab configuration.
			this.plConfig.Dispose();
			// Close the YouTube configuration.
			this.ytConfig.Dispose();
			// Close the status.
			this.status.Dispose();
			// Close the comments.
			this.comments.Dispose();
			// Close the spiders.
			this.spiders.Dispose();
			// Close the log.
			this.log.Dispose();
			// Close the configuration.
			this.config.Dispose();
		}

		#endregion
	}
}
