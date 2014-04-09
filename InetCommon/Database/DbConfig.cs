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

namespace InetCommon.Database
{
	/// <summary>
	/// A class representing the database configuration.
	/// </summary>
	public sealed class DbConfig : IDisposable
	{
		private readonly DbConfigSql dbSql;

		/// <summary>
		/// Creates a new configuration instance.
		/// </summary>
		/// <param name="config">The configuration.</param>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="rootPath">The registry path.</param>
		public DbConfig(IDbApplication config, RegistryKey rootKey, string rootPath)
		{
			// Create the SQL database configuration.
			this.dbSql = new DbConfigSql(config, rootKey, rootPath + @"\Sql");
		}

		// Public properties.

		/// <summary>
		/// Gets the SQL database configuration.
		/// </summary>
		public DbConfigSql Sql { get { return this.dbSql; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the configurations.
			this.dbSql.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}
	}
}
