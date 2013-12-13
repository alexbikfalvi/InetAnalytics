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

namespace InetCrawler.Status
{
	/// <summary>
	/// A delegate used when performing an action on the status handler.
	/// </summary>
	/// <param name="handle">The status handler.</param>
	internal delegate void CrawlerStatusHandlerAction(CrawlerStatusHandler handler);

	/// <summary>
	/// A class allowing a single control to send status messages.
	/// </summary>
	public sealed class CrawlerStatusHandler
	{
		private readonly object owner;
		private readonly CrawlerStatusHandlerAction actionSend;
		private readonly CrawlerStatusHandlerAction actionLock;

		private readonly object sync = new object();

		private CrawlerStatusMessage message;
		private volatile bool locked = false;

		/// <summary>
		/// Creates a new object instance for the specified ownwer.
		/// </summary>
		/// <param name="owner">The owner object.</param>
		/// <param name="actionSend">The action handler for sending a status message.</param>
		/// <param name="actionLock">The action handler for changing the status lock.</param>
		internal CrawlerStatusHandler(object owner, CrawlerStatusHandlerAction actionSend, CrawlerStatusHandlerAction actionLock)
		{
			// Set the owner.
			this.owner = owner;
			// Set the action handlers.
			this.actionSend = actionSend;
			this.actionLock = actionLock;
		}

		// Public properties.

		/// <summary>
		/// Gets the owner object of the current handle.
		/// </summary>
		public object Owner { get { return this.owner; } }
		/// <summary>
		/// Gets the current status message for this handler.
		/// </summary>
		public CrawlerStatusMessage Message { get { return this.message; } }
		/// <summary>
		/// Gets whether the status locks the application.
		/// </summary>
		public bool Locked { get { return this.locked; } }

		// Public methods.

		/// <summary>
		/// Sends a notification status message.
		/// </summary>
		/// <param name="type">The status type.</param>
		/// <param name="text">The left text.</param>
		public void Send(CrawlerStatus.StatusType type, string text)
		{
			lock (this.sync)
			{
				// Set the message.
				this.message = new CrawlerStatusMessage(type, text);
				// Call the delegate.
				this.actionSend(this);
			}
		}

		/// <summary>
		/// Sends a notification status message.
		/// </summary>
		/// <param name="type">The status type.</param>
		/// <param name="text">The left text.</param>
		/// <param name="image">The left image.</param>
		public void Send(CrawlerStatus.StatusType type, string text, Image image)
		{
			lock (this.sync)
			{
				// Set the message.
				this.message = new CrawlerStatusMessage(type, text, image);
				// Call the delegate.
				this.actionSend(this);
			}
		}

		/// <summary>
		/// Sends a notification status message.
		/// </summary>
		/// <param name="type">The status type.</param>
		/// <param name="leftText">The left text.</param>
		/// <param name="rightText">The right text.</param>
		/// <param name="leftImage">The left image.</param>
		/// <param name="rightImage">The right image.</param>
		public void Send(CrawlerStatus.StatusType type, string leftText, string rightText, Image leftImage = null, Image rightImage = null)
		{
			lock (this.sync)
			{
				// Set the message.
				this.message = new CrawlerStatusMessage(type, leftText, rightText, leftImage, rightImage);
				// Call the delegate.
				this.actionSend(this);
			}
		}

		/// <summary>
		/// Prevents the application from closing when running a background operation.
		/// </summary>
		public void Lock()
		{
			lock (this.sync)
			{
				// If the lock is not set.
				if (!this.locked)
				{
					// Set the lock.
					this.locked = true;
					// Call the delegate.
					this.actionLock(this);
				}
			}
		}

		/// <summary>
		/// Allows the application to close  when not running a background operation.
		/// </summary>
		public void Unlock()
		{
			lock (this.sync)
			{
				// If the lock is set.
				if (this.locked)
				{
					// Clear the lock.
					this.locked = false;
					// Call the delegate.
					this.actionLock(this);
				}
			}
		}
	}

}
