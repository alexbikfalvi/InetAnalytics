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
using Microsoft.Win32;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class that stores the configuration of the database servers.
	/// </summary>
	public sealed class DbConfig : IDisposable
	{
		private RegistryKey key;

		/// <summary>
		/// Creates a database configuration instance at the specified registry key.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="path">The registry key.</param>
		public DbConfig(RegistryKey rootKey, string path)
		{
			// Open the database configuration key.
			if (null == (this.key = rootKey.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);
			}
		}

		// Public properties.

		/// <summary>
		/// Returns an array with the current server IDs (not server names).
		/// </summary>
		public string[] Servers { get { return this.key.GetSubKeyNames(); } }

		/// <summary>
		/// Returns the database registry key.
		/// </summary>
		public RegistryKey Key { get { return this.key; } }

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

		/// <summary>
		/// Removes the configuration for server with the specified identifier.
		/// </summary>
		/// <param name="id">The server ID.</param>
		public void Remove(string id)
		{
			this.key.DeleteSubKey(id);
		}
	}
}
