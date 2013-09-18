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
		public static string YouTubeUsername { get; internal set; }

		public static SecureString YouTubePassword { get; internal set; }

		public static string YouTubeCategoriesFileName { get; internal set; }

		public static SecureString YouTubeV2ApiKey { get; internal set; }

		public static string LogFileName { get; internal set; }

		public static string DatabaseLogFileName { get; internal set; }

		public static string CommentsVideosFileName { get; internal set; }

		public static string CommentsUsersFileName { get; internal set; }

		public static string CommentsPlaylistsFileName { get; internal set; }

		public static TimeSpan ConsoleMessageCloseDelay { get; internal set; }

		public static int ConsoleSideMenuVisibleItems { get; internal set; }

		public static int ConsoleSideMenuSelectedItem { get; internal set; }

		public static int[] ConsoleSideMenuSelectedNode { get; internal set; }

		public static string PlanetLabUsername { get; internal set; }

		public static SecureString PlanetLabPassword { get; internal set; }

		public static int PlanetLabPersonId { get; internal set; }

		public static string PlanetLabSitesFileName { get; internal set; }

		public static string PlanetLabPersonsFileName { get; internal set; }

		public static string PlanetLabSlicesFileName { get; internal set; }
	}
}
