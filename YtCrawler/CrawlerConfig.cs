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
using DotNetApi.Security;
using YtCrawler.Database;

namespace YtCrawler
{
	/// <summary>
	/// Global configuration for the YouTube crawler.
	/// </summary>
	public class CrawlerConfig
	{
		internal static readonly byte[] cryptoKey = { 155, 181, 197, 167, 41, 252, 217, 150, 25, 158, 203, 88, 187, 162, 110, 28, 215, 36, 26, 6, 146, 170, 29, 221, 182, 144, 72, 69, 2, 91, 132, 31 };
		internal static readonly byte[] cryptoIV = { 61, 135, 168, 42, 118, 126, 73, 70, 125, 92, 153, 57, 60, 201, 77, 131 };

		private RegistryKey rootKey;
		private string rootPath;
		private string root;
		private DbConfig dbConfig;

		/// <summary>
		/// Creates a new crawler configuration based on the specified root registry key.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="rootPath">The root registry path.</param>
		public CrawlerConfig(RegistryKey rootKey, string rootPath)
		{
			this.rootKey = rootKey;
			this.rootPath = rootPath;
			this.root = string.Format("{0}\\{1}", this.rootKey.Name, this.rootPath);

			RegistryKey dbKey;
			if(null == (dbKey = this.rootKey.OpenSubKey(this.rootPath + "\\Database", RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				dbKey = this.rootKey.CreateSubKey(this.rootPath + "\\Database", RegistryKeyPermissionCheck.ReadWriteSubTree);
			}

			this.dbConfig = new DbConfig(dbKey);

			// Initialize the static configuration.
			CrawlerStatic.youTubeUserName = this.YouTubeUserName;
			CrawlerStatic.youTubePassword = this.YouTubePassword;
			CrawlerStatic.youTubeCategoriesFileName = this.YouTubeCategoriesFileName;
			CrawlerStatic.youTubeV2ApiKey = this.YouTubeV2ApiKey;
			CrawlerStatic.logFileName = this.LogFileName;
			CrawlerStatic.databaseLogFileName = this.DatabaseLogFileName;
			CrawlerStatic.commentsVideosFileName = this.CommentsVideosFileName;
			CrawlerStatic.commentsUsersFileName = this.CommentsUsersFileName;
			CrawlerStatic.commentsPlaylistsFileName = this.CommentsVideosFileName;
			CrawlerStatic.consoleMessageCloseDelay = this.ConsoleMessageCloseDelay;
			CrawlerStatic.consoleSideMenuVisibleItems = this.ConsoleSideMenuVisibleItems;
			CrawlerStatic.consoleSideMenuSelectedItem = this.ConsoleSideMenuSelectedItem;
			CrawlerStatic.planetLabUserName = this.PlanetLabUserName;
			CrawlerStatic.planetLabPassword = this.PlanetLabPassword;
			CrawlerStatic.planetLabSitesFileName = this.PlanetLabSitesFileName;
		}

		/// <summary>
		/// Gets or sets the YouTube account name.
		/// </summary>
		public string YouTubeUserName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + "\\YouTube", "UserName", string.Empty);
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + "\\YouTube", "UserName", value);
				CrawlerStatic.youTubeUserName = value;
			}
		}

		/// <summary>
		/// Gets or sets the YouTube account password.
		/// </summary>
		public SecureString YouTubePassword
		{
			get
			{
				return DotNetApi.Windows.Registry.GetSecureString(this.root + "\\YouTube", "Password", SecureStringExtensions.Empty, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			}
			set
			{
				DotNetApi.Windows.Registry.SetSecureString(this.root + "\\YouTube", "Password", value, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
				CrawlerStatic.youTubePassword = value;
			}
		}

		/// <summary>
		/// Gets or sets the YouTube categories file name.
		/// </summary>
		public string YouTubeCategoriesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + "\\YouTube\\V2", "CategoriesFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\YouTube\\CategoriesV2.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + "\\YouTube\\V2", "CategoriesFileName", value);
				CrawlerStatic.youTubeCategoriesFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the YouTube API version 2 developer key.
		/// </summary>
		public SecureString YouTubeV2ApiKey
		{
			get
			{
				return DotNetApi.Windows.Registry.GetSecureString(this.root + "\\YouTube\\V2", "ApiKey", SecureStringExtensions.Empty, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			}
			set
			{
				DotNetApi.Windows.Registry.SetSecureString(this.root + "\\YouTube\\V2", "ApiKey", value, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
				CrawlerStatic.youTubeV2ApiKey = value;
			}
		}

		/// <summary>
		/// Gets or sets the log file name.
		/// </summary>
		public string LogFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + "\\Log", "FileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Log\\YtLog-{0}-{1}-{2}.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + "\\Log", "FileName", value);
				CrawlerStatic.logFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the database server log file name.
		/// </summary>
		public string DatabaseLogFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + "\\Log", "DatabaseFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Log\\YtLog-Db-{0}-{1}-{2}-{3}.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + "\\Log", "DatabaseFileName", value);
				CrawlerStatic.databaseLogFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the videos comments file name.
		/// </summary>
		public string CommentsVideosFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + "\\Comments", "VideosFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Videos.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + "\\Comments", "VideosFileName", value);
				CrawlerStatic.commentsVideosFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the users comments file name.
		/// </summary>
		public string CommentsUsersFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + "\\Comments", "UsersFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Users.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + "\\Comments", "UsersFileName", value);
				CrawlerStatic.commentsUsersFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the playlists comments file name.
		/// </summary>
		public string CommentsPlaylistsFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + "\\Comments", "PlaylistsFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Playlists.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + "\\Comments", "PlaylistsFileName", value);
				CrawlerStatic.commentsPlaylistsFileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the delay to display a user message, after the operation generating the message has completed.
		/// </summary>
		public TimeSpan ConsoleMessageCloseDelay
		{
			get
			{
				return DotNetApi.Windows.Registry.GetTimeSpan(this.root + "\\Console", "MessageCloseDelay", TimeSpan.FromMilliseconds(1000));
			}
			set
			{
				DotNetApi.Windows.Registry.SetTimeSpan(this.root + "\\Console", "MessageCloseDelay", value);
				CrawlerStatic.consoleMessageCloseDelay = value;
			}
		}

		/// <summary>
		/// Gets or sets the number of side menu visible items.
		/// </summary>
		public int ConsoleSideMenuVisibleItems
		{
			get
			{
				return DotNetApi.Windows.Registry.GetInteger(this.root + "\\Console", "SideMenuVisibleItems", 4);
			}
			set
			{
				DotNetApi.Windows.Registry.SetInteger(this.root + "\\Console", "SideMenuVisibleItems", value);
				CrawlerStatic.consoleSideMenuVisibleItems = value;
			}
		}

		/// <summary>
		/// Gets or sets the number of side menu selected item.
		/// </summary>
		public int ConsoleSideMenuSelectedItem
		{
			get
			{
				return DotNetApi.Windows.Registry.GetInteger(this.root + "\\Console", "SideMenuSelectedItem", 0);
			}
			set
			{
				DotNetApi.Windows.Registry.SetInteger(this.root + "\\Console", "SideMenuSelectedItem", value);
				CrawlerStatic.consoleSideMenuSelectedItem = value;
			}
		}
		/// <summary>
		/// Gets or sets the PlanetLab account name.
		/// </summary>
		public string PlanetLabUserName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + "\\PlanetLab", "UserName", string.Empty);
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + "\\PlanetLab", "UserName", value);
				CrawlerStatic.planetLabUserName = value;
			}
		}

		/// <summary>
		/// Gets or sets the PlanetLab account password.
		/// </summary>
		public SecureString PlanetLabPassword
		{
			get
			{
				return DotNetApi.Windows.Registry.GetSecureString(this.root + "\\PlanetLab", "Password", SecureStringExtensions.Empty, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			}
			set
			{
				DotNetApi.Windows.Registry.SetSecureString(this.root + "\\PlanetLab", "Password", value, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
				CrawlerStatic.planetLabPassword = value;
			}
		}

		/// <summary>
		/// Gets or sets the PlanetLab sites file name.
		/// </summary>
		public string PlanetLabSitesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root + "\\PlanetLab", "SitesFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\PlanetLab\\Sites.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root + "\\PlanetLab", "SitesFileName", value);
				CrawlerStatic.planetLabSitesFileName = value;
			}
		}

		/// <summary>
		/// Gets the database configuration.
		/// </summary>
		public DbConfig DatabaseConfig { get { return this.dbConfig; } }

		/// <summary>
		/// Gets the spiders configuration path.
		/// </summary>
		public string SpidersConfigPath { get { return this.root + "\\Spiders"; } }
	}
}
