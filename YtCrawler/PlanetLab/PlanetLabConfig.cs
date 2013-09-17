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
using Microsoft.Win32;
using DotNetApi;
using DotNetApi.Security;

namespace YtCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the PlanetLab configuration.
	/// </summary>
	public class PlanetLabConfig : IDisposable
	{
		private RegistryKey key;
		private string root;

		/// <summary>
		/// Creates a PlanetLab configuration instance at the specified registry key.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="path">The registry key.</param>
		public PlanetLabConfig(RegistryKey rootKey, string path)
		{
			// Open the database configuration key.
			if (null == (this.key = rootKey.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);
			}
			// Set the root path.
			this.root = "{0}\\{1}".FormatWith(rootKey.Name, path);
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the PlanetLab account name.
		/// </summary>
		public string Username
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "UserName", string.Empty);
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "UserName", value);
				CrawlerStatic.PlanetLabUsername = value;
			}
		}

		/// <summary>
		/// Gets or sets the PlanetLab account password.
		/// </summary>
		public SecureString Password
		{
			get
			{
				return DotNetApi.Windows.Registry.GetSecureString(this.root, "Password", SecureStringExtensions.Empty, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			}
			set
			{
				DotNetApi.Windows.Registry.SetSecureString(this.root, "Password", value, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
				CrawlerStatic.PlanetLabPassword = value;
			}
		}

		/// <summary>
		/// Gets or sets the PlanetLab sites file name.
		/// </summary>
		public string SitesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "SitesFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Alex Bikfalvi\\YouTube Analytics\\PlanetLab\\Sites.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "SitesFileName", value);
				CrawlerStatic.PlanetLabSitesFileName = value;
			}
		}

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Close the registry key.
			this.key.Close();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}
	}
}
