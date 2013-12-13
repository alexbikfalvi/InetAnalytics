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
	public sealed class CrawlerStatus : IDisposable
	{
		/// <summary>
		/// An enumeration representing the status type.
		/// </summary>
		public enum StatusType
		{
			Ready = 0,
			Normal = 1,
			Busy = 2,
			Unknown = 3
		}

		private readonly object sync = new object();

		private readonly Dictionary<object, CrawlerStatusHandler> handlers = new Dictionary<object, CrawlerStatusHandler>();
		private readonly HashSet<object> locks = new HashSet<object>();

		private CrawlerStatusHandler handler = null;
		private bool disposed = false;

		/// <summary>
		/// Creates a new crawler notification instance.
		/// </summary>
		public CrawlerStatus()
		{
		}

		// Public properties.

		/// <summary>
		/// Gets whether there exist a status lock.
		/// </summary>
		public bool IsLocked { get { lock (this.sync) { return this.locks.Count > 0; } } }

		// Public events.

		/// <summary>
		/// An event raised when a handler sends a status message.
		/// </summary>
		public event StatusMessageEventHandler MessageChanged;
		/// <summary>
		/// An event raised when the lock status has changed.
		/// </summary>
		public event EventHandler LockChanged;

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
		public CrawlerStatusHandler GetHandler(object owner)
		{
			CrawlerStatusHandler handler;
			// Try get the handler from the current collection.
			if (!this.handlers.TryGetValue(owner, out handler))
			{
				// If the handler is not found, create a new handler for the given owner.
				handler = new CrawlerStatusHandler(owner, this.OnMessageChanged, this.OnLockChanged);
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
			lock (this.sync)
			{
				CrawlerStatusHandler handler;
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
				this.OnMessageChanged();
			}
		}

		/// <summary>
		/// Deactivates the notification handler attached to the specified object.
		/// </summary>
		/// <param name="owner">The owner object.</param>
		public void Deactivate(object owner)
		{
			lock (this.sync)
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
						this.OnMessageChanged();
					}
				}
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called when receiving a status message from a handler.
		/// </summary>
		/// <param name="handler">The handler that changed the message.</param>
		private void OnMessageChanged(CrawlerStatusHandler handler)
		{
			// If the object is disposed, do nothing.
			if (this.disposed) return;

			lock (this.sync)
			{
				// If this is the currenty selected handler, raise an event.
				if (this.handler == handler)
				{
					this.OnMessageChanged();
				}
			}
		}

		/// <summary>
		/// An event handler called when raising a message changed event.
		/// </summary>
		private void OnMessageChanged()
		{
			// If there exists an event handler.
			if (null != this.MessageChanged)
			{
				// If the handler is not null.
				if (null != this.handler) this.MessageChanged(this, new CrawlerStatusMessageEventArgs(this.handler.Message));
				else this.MessageChanged(this, new CrawlerStatusMessageEventArgs(null));
			}
		}

		/// <summary>
		/// An event handler called when a status handler changes the lock state.
		/// </summary>
		/// <param name="handler">The handler that changed the lock.</param>
		private void OnLockChanged(CrawlerStatusHandler handler)
		{
			lock (this.sync)
			{
				// If the handler lock is set.
				if (handler.Locked)
				{
					// Add the handler owner to the list of locks.
					if (this.locks.Add(handler.Owner))
					{
						this.OnLockChanged();
					}
				}
				else
				{
					// Remove the handler owner from the list of locks.
					if (this.locks.Remove(handler.Owner))
					{
						this.OnLockChanged();
					}
				}
			}
		}

		/// <summary>
		/// An event handler called when raising a lock changed event.
		/// </summary>
		private void OnLockChanged()
		{
			// Raise the event.
			if (null != this.LockChanged) this.LockChanged(this, EventArgs.Empty);
		}
	}
}
