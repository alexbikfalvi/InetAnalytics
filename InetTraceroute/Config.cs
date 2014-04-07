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
using InetCommon.Log;
using InetCommon.Status;

namespace InetTraceroute
{
	/// <summary>
	/// A class representing the application configuration.
	/// </summary>
	public sealed class Config : IDisposable
	{
		private RegistryKey rootKey;
		private string rootPath;
		private string root;

		private readonly ApplicationStatus status;
		private readonly Logger log;

		public Config(RegistryKey rootKey, string rootPath)
		{
			// Set the registry configuration.
			this.rootKey = rootKey;
			this.rootPath = rootPath;
			this.root = string.Format(@"{0}\{1}", this.rootKey.Name, this.rootPath);

			// Create the application status.
			this.status = new ApplicationStatus();
			// Create the application log.
			this.log = new Logger(this.LogFileName);
		}

		#region Public properties

		/// <summary>
		/// Gets the application folder.
		/// </summary>
		private static string ApplicationFolder { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\Internet Traceroute"; } }
		/// <summary>
		/// Gets the application status.
		/// </summary>
		public ApplicationStatus Status { get { return this.status; } }
		/// <summary>
		/// Gets the application log.
		/// </summary>
		public Logger Log { get { return this.log; } }
		/// <summary>
		/// Gets or sets the log file name.
		/// </summary>
		public string LogFileName
		{
			get
			{
				return DotNetApi.Windows.RegistryExtensions.GetString(this.root + @"\Log", "FileName", Config.ApplicationFolder + @"\Log\Log-{0}-{1}-{2}.xml");
			}
			set
			{
				DotNetApi.Windows.RegistryExtensions.SetString(this.root + @"\Log", "FileName", value);
			}
		}
		/// <summary>
		/// Gets or sets the console message close delay.
		/// </summary>
		public TimeSpan ConsoleMessageCloseDelay
		{
			get
			{
				return DotNetApi.Windows.RegistryExtensions.GetTimeSpan(this.root + @"\Console", "MessageCloseDelay", TimeSpan.FromMilliseconds(1000));
			}
			set
			{
				DotNetApi.Windows.RegistryExtensions.SetTimeSpan(this.root + @"\Console", "MessageCloseDelay", value);
			}
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the status.
			this.status.Dispose();
			// Dispose the log.
			this.log.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
