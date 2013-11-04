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

namespace YtCrawler.Tasks
{
	/// <summary>
	/// A delegate representing a crawler trigger event handler.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void CrawlerTriggerEventHandler(object sender, CrawlerTriggerEventArgs e);

	/// <summary>
	/// A class representing the crawler trigger event arguments.
	/// </summary>
	public class CrawlerTriggerEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new event arguments instance.
		/// </summary>
		/// <param name="trigger">The crawler trigger.</param>
		public CrawlerTriggerEventArgs(CrawlerTrigger trigger)
		{
			this.Trigger = trigger;
		}

		// Public properties.

		/// <summary>
		/// Gets the trigger.
		/// </summary>
		public CrawlerTrigger Trigger { get; private set; }
	}
}
