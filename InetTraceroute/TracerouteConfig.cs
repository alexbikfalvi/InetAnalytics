/* 
 * Copyright (C) 2014 Alex Bikfalvi
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
using DotNetApi;
using InetCommon;

namespace InetTraceroute
{
	/// <summary>
	/// A class representing the application configuration.
	/// </summary>
	public sealed class TracerouteConfig : IApplicationConfig, IDisposable
	{
		private static string applicationFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\Internet Traceroute";

		private RegistryKey rootKey;
		private string rootPath;
		private string root;

		/// <summary>
		/// Creates a new traceroute configuration based on the specified root registry key.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="rootPath">The root registry path.</param>
		public TracerouteConfig(RegistryKey rootKey, string rootPath)
		{
			this.rootKey = rootKey;
			this.rootPath = rootPath;
			this.root = @"{0}\{1}".FormatWith(this.rootKey.Name, this.rootPath);

			// Set the static properties.
			ApplicationConfig.MessageCloseDelay = this.MessageCloseDelay;
		}

		#region Public properties

		/// <summary>
		/// Gets or sets the delay to display a user message, after the operation generating the message has completed.
		/// </summary>
		public TimeSpan MessageCloseDelay
		{
			get
			{
				return DotNetApi.Windows.RegistryExtensions.GetTimeSpan(this.root + @"\Console", "MessageCloseDelay", TimeSpan.FromMilliseconds(1000));
			}
			set
			{
				DotNetApi.Windows.RegistryExtensions.SetTimeSpan(this.root + @"\Console", "MessageCloseDelay", value);
				ApplicationConfig.MessageCloseDelay = value;
			}
		}
		/// <summary>
		/// Gets or sets the DNS query timeout.
		/// </summary>
		public TimeSpan DnsQueryTimeout
		{
			get
			{
				return DotNetApi.Windows.RegistryExtensions.GetTimeSpan(this.root + @"\Network", "DnsQueryTimeout", TimeSpan.FromMilliseconds(1000));
			}
			set
			{
				DotNetApi.Windows.RegistryExtensions.SetTimeSpan(this.root + @"\Network", "DnsQueryTimeout", value);
			}
		}
		/// <summary>
		/// Gets or sets the log file name.
		/// </summary>
		public string LogFileName
		{
			get
			{
				return DotNetApi.Windows.RegistryExtensions.GetString(this.root + @"\Log", "FileName", TracerouteConfig.applicationFolder + @"\Log\Log-{0}-{1}-{2}.xml");
			}
			set
			{
				DotNetApi.Windows.RegistryExtensions.SetString(this.root + @"\Log", "FileName", value);
			}
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
