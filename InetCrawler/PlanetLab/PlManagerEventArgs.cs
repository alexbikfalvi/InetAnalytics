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

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A delegate for the PlanetLab manager status event handlers.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void PlManagerEventHandler(object sender, PlManagerEventArgs e);

	/// <summary>
	/// A class representing the PlanetLab manager status event arguments.
	/// </summary>
	public class PlManagerEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new PlanetLab manager status event arguments instance.
		/// </summary>
		/// <param name="state">The manager state.</param>
		public PlManagerEventArgs(PlManagerState state)
		{
			this.State = state;
			this.Message = null;
			this.Exception = null;
		}

		/// <summary>
		/// Creates a new PlanetLab manager status event arguments instance.
		/// </summary>
		/// <param name="state">The manager state.</param>
		/// <param name="message">The event message.</param>
		public PlManagerEventArgs(PlManagerState state, string message)
		{
			this.State = state;
			this.Message = message;
			this.Exception = null;
		}

		/// <summary>
		/// Creates a new PlanetLab manager status event arguments instance.
		/// </summary>
		/// <param name="state">The manager state.</param>
		/// <param name="exception">The event exception.</param>
		public PlManagerEventArgs(PlManagerState state, Exception exception)
		{
			this.State = state;
			this.Message = null;
			this.Exception = exception;
		}

		// Public properties.

		/// <summary>
		/// The manager state.
		/// </summary>
		public PlManagerState State { get; private set; }
		/// <summary>
		/// The event message.
		/// </summary>
		public string Message { get; private set; }
		/// <summary>
		/// The event exception.
		/// </summary>
		public Exception Exception { get; private set; }
	}
}
