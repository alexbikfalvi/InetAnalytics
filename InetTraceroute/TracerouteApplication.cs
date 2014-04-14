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
using InetCommon;
using InetCommon.Log;
using InetCommon.Status;

namespace InetTraceroute
{
	/// <summary>
	/// A class representing the Internet traceroute application.
	/// </summary>
	public sealed class TracerouteApplication : IApplication, IDisposable
	{
		private readonly TracerouteConfig config;
		private readonly Logger log;
		private readonly ApplicationStatus status;

		/// <summary>
		/// Creates a traceroute application instance.
		/// </summary>
		/// <param name="rootKey">The registry root key.</param>
		/// <param name="rootPath">The registry root path.</param>
		public TracerouteApplication(RegistryKey rootKey, string rootPath)
		{
			// Create the configuration.
			this.config = new TracerouteConfig(rootKey, rootPath);
			// Create the log.
			this.log = new Logger(this.config.LogFileName);
			// Create the status.
			this.status = new ApplicationStatus();
		}

		#region Public properties

		/// <summary>
		/// Gets the traceroute configuration.
		/// </summary>
		public TracerouteConfig Config { get { return this.config; } }
		/// <summary>
		/// Gets the traceroute configuration.
		/// </summary>
		IApplicationConfig IApplication.Config { get { return this.config; } }
		/// <summary>
		/// Gets the log.
		/// </summary>
		public Logger Log { get { return this.log; } }
		/// <summary>
		/// Gets the application status.
		/// </summary>
		public ApplicationStatus Status { get { return this.status; } }

		#endregion

		#region Public methods

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the member objects.
			this.status.Dispose();
			this.log.Dispose();
			this.config.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
