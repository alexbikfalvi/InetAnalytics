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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace YtCrawler
{
	/// <summary>
	/// Global configuration for the YouTube crawler.
	/// </summary>
	public class CrawlerConfig
	{
		private string root = null;

		/// <summary>
		/// Creates a new crawler configuration based on the specified root registry key.
		/// </summary>
		/// <param name="root">The root key. </param>
		public CrawlerConfig(string root)
		{
			this.root = root;
		}

		/// <summary>
		/// Gets or sets the YouTube API version 2 developer key.
		/// </summary>
		public string YouTubeV2ApiKey
		{
			get
			{
				try
				{
					string value;
					return null != (value = Registry.GetValue(this.root + "\\YouTube\\V2", "ApiKey", string.Empty) as string) ? value : string.Empty;
				}
				catch (Exception) { return string.Empty; }
			}
			set { Registry.SetValue(this.root + "\\YouTube\\V2", "ApiKey", value, RegistryValueKind.String); }
		}

		/// <summary>
		/// Gets or sets the YouTube account name.
		/// </summary>
		public string YouTubeUserName
		{
			get
			{
				try
				{
					string value;
					return null != (value = Registry.GetValue(this.root + "\\YouTube", "UserName", string.Empty) as string) ? value : string.Empty;
				}
				catch (Exception) { return string.Empty; }
			}
			set { Registry.SetValue(this.root + "\\YouTube", "UserName", value, RegistryValueKind.String); }
		}

		/// <summary>
		/// Gets or sets the YouTube account password.
		/// </summary>
		public string YouTubePassword
		{
			get
			{
				try
				{
					string value;
					return null != (value = CrawlerCrypto.Decrypt(Registry.GetValue(this.root + "\\YouTube", "Password", null) as byte[])) ? value : string.Empty;
				}
				catch (Exception) { return string.Empty; }
			}
			set { Registry.SetValue(this.root + "\\YouTube", "Password", CrawlerCrypto.Encrypt(value), RegistryValueKind.Binary); }
		}

		/// <summary>
		/// Gets or sets the log file name.
		/// </summary>
		public string LogFileName
		{
			get
			{
				try
				{
					string value;
					return null != (value = Registry.GetValue(this.root + "\\Log", "FileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Log\\YtLog-{0}-{1}-{2}.xml") as string)
						? value
						: Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Log\\YtLog-{0}-{1}-{2}.xml";
				}
				catch (Exception) { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Log\\YtLog-{0}-{1}-{2}.xml"; }
			}
			set { Registry.SetValue(this.root + "\\Log", "FileName", value, RegistryValueKind.String); }
		}

		/// <summary>
		/// Gets or sets the videos comments file name.
		/// </summary>
		public string CommentsVideosFileName
		{
			get
			{
				try
				{
					string value;
					return null != (value = Registry.GetValue(this.root + "\\Comments", "VideosFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Videos.xml") as string)
						? value
						: Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Videos.xml";
				}
				catch (Exception) { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Videos.xml"; }
			}
			set { Registry.SetValue(this.root + "\\Comments", "VideosFileName", value, RegistryValueKind.String); }
		}

		/// <summary>
		/// Gets or sets the users comments file name.
		/// </summary>
		public string CommentsUsersFileName
		{
			get
			{
				try
				{
					string value;
					return null != (value = Registry.GetValue(this.root + "\\Comments", "UsersFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Users.xml") as string)
						? value
						: Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Users.xml";
				}
				catch (Exception) { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Users.xml"; }
			}
			set { Registry.SetValue(this.root + "\\Comments", "UsersFileName", value, RegistryValueKind.String); }
		}

		/// <summary>
		/// Gets or sets the playlists comments file name.
		/// </summary>
		public string CommentsPlaylistsFileName
		{
			get
			{
				try
				{
					string value;
					return null != (value = Registry.GetValue(this.root + "\\Comments", "PlaylistsFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Playlists.xml") as string)
						? value
						: Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Playlists.xml";
				}
				catch (Exception) { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\Comments\\Playlists.xml"; }
			}
			set { Registry.SetValue(this.root + "\\Comments", "PlaylistsFileName", value, RegistryValueKind.String); }
		}

		/// <summary>
		/// Gets or sets the delay to display a user message, after the operation generating the message has completed.
		/// </summary>
		public TimeSpan MessageCloseDelay
		{
			get
			{
				try
				{
					object value = Registry.GetValue(this.root + "\\Console", "MessageCloseDelay", 1000);	
					return TimeSpan.FromMilliseconds((int)(null != value ? value : 1000));
				}
				catch (Exception) { return TimeSpan.FromMilliseconds(1000); }
			}
			set { Registry.SetValue(this.root + "\\Console", "MessageCloseDelay", value, RegistryValueKind.DWord); }
		}
	}
}
