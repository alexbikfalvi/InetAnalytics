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
using System.Security;
using Microsoft.Win32;
using DotNetApi;
using DotNetApi.Security;
using YtCrawler.Database;
using YtCrawler.PlanetLab;

namespace YtCrawler
{
	/// <summary>
	/// Global configuration for the YouTube crawler.
	/// </summary>
	public sealed class CrawlerConfig : IDisposable
	{
		internal static readonly byte[] cryptoKey = { 155, 181, 197, 167, 41, 252, 217, 150, 25, 158, 203, 88, 187, 162, 110, 28, 215, 36, 26, 6, 146, 170, 29, 221, 182, 144, 72, 69, 2, 91, 132, 31 };
		internal static readonly byte[] cryptoIV = { 61, 135, 168, 42, 118, 126, 73, 70, 125, 92, 153, 57, 60, 201, 77, 131 };

		private RegistryKey rootKey;
		private string rootPath;
		private string root;
		private DbConfig dbConfig;
		private PlConfig plConfig;

		/// <summary>
		/// Creates a new crawler configuration based on the specified root registry key.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="rootPath">The root registry path.</param>
		public CrawlerConfig(RegistryKey rootKey, string rootPath)
		{
			this.rootKey = rootKey;
			this.rootPath = rootPath;
			this.root = @"{0}\{1}".FormatWith(this.rootKey.Name, this.rootPath);

			// Create the database configuration.
			this.dbConfig = new DbConfig(this.rootKey, this.rootPath + @"\Database");

			// Create the PlanetLab configuration.
			this.plConfig = new PlConfig(this.rootKey, this.rootPath + @"\PlanetLab");

			// Initialize the static configuration.
			CrawlerStatic.YouTubeUsername = this.YouTubeUsername;
			CrawlerStatic.YouTubePassword = this.YouTubePassword;
			CrawlerStatic.YouTubeCategoriesFileName = this.YouTubeCategoriesFileName;
			CrawlerStatic.YouTubeV2ApiKey = this.YouTubeV2ApiKey;
			CrawlerStatic.LogFileName = this.LogFileName;
			CrawlerStatic.DatabaseLogFileName = this.DatabaseLogFileName;
			CrawlerStatic.CommentsVideosFileName = this.CommentsVideosFileName;
			CrawlerStatic.CommentsUsersFileName = this.CommentsUsersFileName;
			CrawlerStatic.CommentsPlaylistsFileName = this.CommentsVideosFileName;
			CrawlerStatic.ConsoleMessageCloseDelay = this.ConsoleMessageCloseDelay;
			CrawlerStatic.ConsoleSideMenuVisibleItems = this.ConsoleSideMenuVisibleItems;
			CrawlerStatic.ConsoleSideMenuSelectedItem = this.ConsoleSideMenuSelectedItem;
			CrawlerStatic.ConsoleSideMenuSelectedNode = this.ConsoleSideMenuSelectedNode;
			CrawlerStatic.PlanetLabUsername = this.PlanetLab.Username;
			CrawlerStatic.PlanetLabPassword = this.PlanetLab.Password;
			CrawlerStatic.PlanetLabSitesFileName = this.PlanetLab.SitesFileName;
		}

		/// <summary>
		/// Gets or sets the YouTube account name.
		/// </summary>
		public string YouTubeUsername
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + @"\YouTube", "UserName", string.Empty);
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + @"\YouTube", "UserName", value);
				CrawlerStatic.YouTubeUsername = value;
			}
		}

		/// <summary>
		/// Gets or sets the YouTube account password.
		/// </summary>
		public SecureString YouTubePassword
		{
			get
			{
				return DotNetApi.Windows.Registry.GetSecureString(this.root + @"\YouTube", "Password", SecureStringExtensions.Empty, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			}
			set
			{
				DotNetApi.Windows.Registry.SetSecureString(this.root + @"\YouTube", "Password", value, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
				CrawlerStatic.YouTubePassword = value;
			}
		}

		/// <summary>
		/// Gets or sets the YouTube categories file name.
		/// </summary>
		public string YouTubeCategoriesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + @"\YouTube\V2", "CategoriesFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\YouTube\CategoriesV2.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + @"\YouTube\V2", "CategoriesFileName", value);
				CrawlerStatic.YouTubeCategoriesFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the YouTube API version 2 developer key.
		/// </summary>
		public SecureString YouTubeV2ApiKey
		{
			get
			{
				return DotNetApi.Windows.Registry.GetSecureString(this.root + @"\YouTube\V2", "ApiKey", SecureStringExtensions.Empty, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			}
			set
			{
				DotNetApi.Windows.Registry.SetSecureString(this.root + @"\YouTube\V2", "ApiKey", value, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
				CrawlerStatic.YouTubeV2ApiKey = value;
			}
		}

		/// <summary>
		/// Gets or sets the log file name.
		/// </summary>
		public string LogFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + @"\Log", "FileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\Log\YtLog-{0}-{1}-{2}.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + @"\Log", "FileName", value);
				CrawlerStatic.LogFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the database server log file name.
		/// </summary>
		public string DatabaseLogFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + @"\Log", "DatabaseFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\Log\YtLog-Db-{0}-{1}-{2}-{3}.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + @"\Log", "DatabaseFileName", value);
				CrawlerStatic.DatabaseLogFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the videos comments file name.
		/// </summary>
		public string CommentsVideosFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + @"\Comments", "VideosFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\Comments\Videos.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + @"\Comments", "VideosFileName", value);
				CrawlerStatic.CommentsVideosFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the users comments file name.
		/// </summary>
		public string CommentsUsersFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + @"\Comments", "UsersFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\Comments\Users.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + @"\Comments", "UsersFileName", value);
				CrawlerStatic.CommentsUsersFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the playlists comments file name.
		/// </summary>
		public string CommentsPlaylistsFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + @"\Comments", "PlaylistsFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\Comments\Playlists.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + @"\Comments", "PlaylistsFileName", value);
				CrawlerStatic.CommentsPlaylistsFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the delay to display a user message, after the operation generating the message has completed.
		/// </summary>
		public TimeSpan ConsoleMessageCloseDelay
		{
			get
			{
				return DotNetApi.Windows.Registry.GetTimeSpan(this.root + @"\Console", "MessageCloseDelay", TimeSpan.FromMilliseconds(1000));
			}
			set
			{
				DotNetApi.Windows.Registry.SetTimeSpan(this.root + @"\Console", "MessageCloseDelay", value);
				CrawlerStatic.ConsoleMessageCloseDelay = value;
			}
		}

		/// <summary>
		/// Gets or sets the number of side menu visible items.
		/// </summary>
		public int ConsoleSideMenuVisibleItems
		{
			get
			{
				return DotNetApi.Windows.Registry.GetInteger(this.root + @"\Console", "SideMenuVisibleItems", 4);
			}
			set
			{
				DotNetApi.Windows.Registry.SetInteger(this.root + @"\Console", "SideMenuVisibleItems", value);
				CrawlerStatic.ConsoleSideMenuVisibleItems = value;
			}
		}

		/// <summary>
		/// Gets or sets the number of side menu selected item.
		/// </summary>
		public int ConsoleSideMenuSelectedItem
		{
			get
			{
				return DotNetApi.Windows.Registry.GetInteger(this.root + @"\Console", "SideMenuSelectedItem", 0);
			}
			set
			{
				DotNetApi.Windows.Registry.SetInteger(this.root + @"\Console", "SideMenuSelectedItem", value);
				CrawlerStatic.ConsoleSideMenuSelectedItem = value;
			}
		}

		/// <summary>
		/// Gets or sets the indices of side menu selected node.
		/// </summary>
		public int[] ConsoleSideMenuSelectedNode
		{
			get
			{
				return DotNetApi.Windows.Registry.GetInt32Array(this.root + @"\Console", "SideMenuSelectedNode", null);
			}
			set
			{
				if (null == value) return;
				DotNetApi.Windows.Registry.SetInt32Array(this.root + @"\Console", "SideMenuSelectedNode", value);
				CrawlerStatic.ConsoleSideMenuSelectedNode = value;
			}
		}

		/// <summary>
		/// Gets the database configuration.
		/// </summary>
		public DbConfig Database { get { return this.dbConfig; } }
		
		/// <summary>
		/// Gets the PlanetLab configuration.
		/// </summary>
		public PlConfig PlanetLab { get { return this.plConfig; } }

		/// <summary>
		/// Gets the spiders configuration path.
		/// </summary>
		public string SpidersConfigPath { get { return this.root + @"\Spiders"; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the database configuration.
			this.dbConfig.Dispose();
			// Dispose the PlanetLab configuration.
			this.plConfig.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}
	}
}
