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
using DotNetApi.Security;
using InetApi.YouTube.Api.V2;
using InetApi.YouTube.Api.V2.Data;

namespace InetCrawler.YouTube
{
	/// <summary>
	/// A class representing the YouTube configuration.
	/// </summary>
	public sealed class YtConfig : IDisposable
	{
		private readonly YouTubeSettings settings;
		private readonly YouTubeCategories categories;


		/// <summary>
		/// Creates a new YouTube configuration instance.
		/// </summary>
		public YtConfig(CrawlerConfig config)
		{
			// Create the YouTube settings.
			this.settings = new YouTubeSettings(config.YouTubeV2ApiKey);
			// Create the YouTube categories.
			this.categories = new YouTubeCategories(config.YouTubeCategoriesFileName);
		}

		// Public properties.

		/// <summary>
		/// Returns the YouTube settings.
		/// </summary>
		public YouTubeSettings Settings { get { return this.settings; } }
		/// <summary>
		/// Returns the YouTube categories.
		/// </summary>
		public YouTubeCategories Categories { get { return this.categories; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the categories.
			this.categories.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}
	}
}
