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
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InetCrawler.Status
{
	/// <summary>
	/// A class allowing controls to send status messages.
	/// </summary>
	public sealed class Status : IDisposable
	{
		private readonly Dictionary<object, StatusHandler> handlers = new Dictionary<object, StatusHandler>();
		private CrawlerStatusHandlerAction status;
		private StatusHandler handler = null;
		private bool disposed = false;

		/// <summary>
		/// Creates a new crawler notification instance.
		/// </summary>
		public Status()
		{
			this.status = new CrawlerStatusHandlerAction(this.OnSend);
		}

		// Public events.

		public event StatusMessageEventHandler Message;

		// Public methods.

		/// <summary>
		/// A methods called when the object is being disposed.
		/// </summary>
		public void Dispose()
		{
			this.disposed = true;
		}

		/// <summary>
		/// Returns a new notification handler attached to the specified object.
		/// </summary>
		/// <param name="owner">The object.</param>
		/// <returns>The notification handler.</returns>
		public StatusHandler GetHandler(object owner)
		{
			StatusHandler handler;
			// Try get the handler from the current collection.
			if (!this.handlers.TryGetValue(owner, out handler))
			{
				// If the handler is not found, create a new handler for the given owner.
				handler = new StatusHandler(owner, this.status);
				// Add the handler to the collection.
				this.handlers.Add(owner, handler);
			}
			// Return the handler.
			return handler;
		}

		/// <summary>
		/// Activates the notification handler attached to the specified object.
		/// </summary>
		/// <param name="owner">The owner object.</param>
		public void Activate(object owner)
		{
			StatusHandler handler;
			// Try and get the handler for the specified owner.
			if (this.handlers.TryGetValue(owner, out handler))
			{
				this.handler = handler;
			}
			else
			{
				this.handler = null;
			}
			// Send a notification.
			this.OnSend();
		}

		/// <summary>
		/// Deactivates the notification handler attached to the specified object.
		/// </summary>
		/// <param name="owner">The owner object.</param>
		public void Deactivate(object owner)
		{
			// If there exists a current handler.
			if (null != this.handler)
			{
				// If handler owner is the specified owner.
				if (this.handler.Owner.Equals(owner))
				{
					// Set the handler to null.
					this.handler = null;
					// Send a notification.
					this.OnSend();
				}
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called when receiving a status message from a handler.
		/// </summary>
		/// <param name="handler">The handler that sent the notification.</param>
		private void OnSend(StatusHandler handler)
		{
			// If the object is disposed, do nothing.
			if (this.disposed) return;
			// If this is the currenty selected handler, send the notification.
			if (this.handler == handler)
			{
				this.OnSend();
			}
		}

		/// <summary>
		/// An event handler called when raising a notification event.
		/// </summary>
		private void OnSend()
		{
			// If there exists an event handler.
			if (null != this.Message)
			{
				// If the handler is not null.
				if (null != this.handler) this.Message(this, new StatusMessageEventArgs(this.handler.Message));
				else this.Message(this, new StatusMessageEventArgs(null));
			}
		}
	}
}
