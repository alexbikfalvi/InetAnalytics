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
	internal delegate void CrawlerStatusHandlerAction(StatusHandler handler);

	/// <summary>
	/// A class allowing a single control to send status messages.
	/// </summary>
	public sealed class StatusHandler
	{
		private object owner;
		private StatusMessage message;
		private CrawlerStatusHandlerAction status;

		/// <summary>
		/// Creates a new object instance for the specified ownwer.
		/// </summary>
		/// <param name="owner">The owner object.</param>
		/// <param name="status">The status event handler.</param>
		internal StatusHandler(object owner, CrawlerStatusHandlerAction status)
		{
			this.owner = owner;
			this.status = status;
		}

		/// <summary>
		/// Gets the owner object of the current handle.
		/// </summary>
		public object Owner { get { return this.owner; } }
		/// <summary>
		/// Gets the current status message for this handler.
		/// </summary>
		public StatusMessage Message { get { return this.message; } }

		// Public methods.

		/// <summary>
		/// Sends a notification status message.
		/// </summary>
		/// <param name="text">The left text.</param>
		public void Send(string text)
		{
			// Set the message.
			this.message = new StatusMessage(text);
			// Call the delegate.
			this.status(this);
		}

		/// <summary>
		/// Sends a notification status message.
		/// </summary>
		/// <param name="text">The left text.</param>
		/// <param name="image">The left image.</param>
		public void Send(string text, Image image)
		{
			// Set the message.
			this.message = new StatusMessage(text, image);
			// Call the delegate.
			this.status(this);
		}

		/// <summary>
		/// Sends a notification status message.
		/// </summary>
		/// <param name="leftText">The left text.</param>
		/// <param name="rightText">The right text.</param>
		/// <param name="leftImage">The left image.</param>
		/// <param name="rightImage">The right image.</param>
		public void Send(string leftText, string rightText, Image leftImage = null, Image rightImage = null)
		{
			// Set the message.
			this.message = new StatusMessage(leftText, rightText, leftImage, rightImage);
			// Call the delegate.
			this.status(this);
		}
	}

}
