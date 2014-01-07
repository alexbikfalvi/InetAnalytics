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
using System.Net;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A class that performs an Internet traceroute.
	/// </summary>
	public class Traceroute : IDisposable
	{
		public readonly TracerouteSettings settings;

		/// <summary>
		/// Creates a new traceroute instance.
		/// </summary>
		/// <param name="settings">The traceroute settings.</param>
		public Traceroute(TracerouteSettings settings)
		{
			// Set the traceroute settings.
			this.settings = settings;
		}

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Call the dispose method.
			this.Dispose(true);
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Creates a traceroute asynchronous state.
		/// </summary>
		/// <param name="localAddress"></param>
		/// <returns></returns>
		//public static TracerouteState Create(IPAddress localAddress)
		//{

		//}

		//public IAsyncResult BeginSendIcmp(str)


		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
		}
	}
}
