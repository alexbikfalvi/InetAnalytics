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

namespace YtCrawler.Spider
{
	/// <summary>
	/// A delegate representing a spider info event handler.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event information.</param>
	public delegate void SpiderInfoEventHandler<T>(object sender, SpiderInfoEventArgs<T> e);

	/// <summary>
	/// A class representing a spider info event information.
	/// </summary>
	public class SpiderInfoEventArgs<T> : SpiderEventArgs
	{
		/// <summary>
		/// Creates a new event information instance.
		/// </summary>
		/// <param name="spider">The spider.</param>
		/// <param name="info">The custom event information.</param>
		public SpiderInfoEventArgs(Spider spider, T info)
			: base(spider)
		{
			this.Info = info;
		}

		// Public properties.

		/// <summary>
		/// Gets the information.
		/// </summary>
		public T Info { get; private set; }
	}
}
