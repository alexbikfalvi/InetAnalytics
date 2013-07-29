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
using System.Security;

namespace YtCrawler
{
	/// <summary>
	/// A class representing the static crawler configuration.
	/// </summary>
	public static class CrawlerStatic
	{
		internal static string youTubeUserName;
		internal static SecureString youTubePassword;
		internal static string youTubeCategoriesFileName ;
		internal static SecureString youTubeV2ApiKey;
		internal static string logFileName;
		internal static string databaseLogFileName;
		internal static string commentsVideosFileName;
		internal static string commentsUsersFileName;
		internal static string commentsPlaylistsFileName;
		internal static TimeSpan consoleMessageCloseDelay;
		internal static int consoleSideMenuVisibleItems;
		internal static int consoleSideMenuSelectedItem;
		internal static string planetLabUserName;
		internal static SecureString planetLabPassword;
		internal static string planetLabSitesFileName;

		public static string YouTubeUserName { get { return CrawlerStatic.youTubeUserName; } }

		public static SecureString YouTubePassword { get { return CrawlerStatic.youTubePassword; } }

		public static string YouTubeCategoriesFileName { get { return CrawlerStatic.youTubeCategoriesFileName; } }

		public static SecureString YouTubeV2ApiKey { get { return CrawlerStatic.youTubeV2ApiKey; } }

		public static string LogFileName { get { return CrawlerStatic.logFileName; } }

		public static string DatabaseLogFileName { get { return CrawlerStatic.databaseLogFileName; } }

		public static string CommentsVideosFileName { get { return CrawlerStatic.commentsVideosFileName; } }

		public static string CommentsUsersFileName { get { return CrawlerStatic.commentsUsersFileName; } }

		public static string CommentsPlaylistsFileName { get { return CrawlerStatic.commentsPlaylistsFileName; } }

		public static TimeSpan ConsoleMessageCloseDelay { get { return CrawlerStatic.consoleMessageCloseDelay; } }

		public static int ConsoleSideMenuVisibleItems { get { return CrawlerStatic.consoleSideMenuVisibleItems; } }

		public static int ConsoleSideMenuSelectedItem { get { return CrawlerStatic.consoleSideMenuSelectedItem; } }

		public static string PlanetLabUserName { get { return CrawlerStatic.planetLabUserName; } }

		public static SecureString PlanetLabPassword { get { return CrawlerStatic.planetLabPassword; } }

		public static string PlanetLabSitesFileName { get { return CrawlerStatic.planetLabSitesFileName; } }
	}
}
