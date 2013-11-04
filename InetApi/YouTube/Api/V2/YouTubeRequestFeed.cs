/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InetApi.YouTube.Api.V2.Atom;
using InetApi.YouTube.Api.V2.Data;
using DotNetApi.Web;

namespace InetApi.YouTube.Api.V2
{
	/// <summary>
	/// Class representing a request for a YouTube feed.
	/// </summary>
	public class YouTubeRequestFeed<T> : YouTubeRequest where T : Entry, new() 
	{
		/// <summary>
		/// Conversion class for an asynchronous operation returning a comments feed.
		/// </summary>
		public class CommentFeedRequestFunction : IAsyncFunction<Feed<T>>
		{
			/// <summary>
			/// Returns a comments feed for the received asynchronous data.
			/// </summary>
			/// <param name="data">The data string.</param>
			/// <returns>A comment feed.</returns>
			public Feed<T> GetResult(string data)
			{
				using (T obj = new T())
				{
					// Use the object to parse the string data to the corresponding feed.
					return new Feed<T>(obj.CreateFeed(data));
				}
			}
		}

		private CommentFeedRequestFunction funcConvert = new CommentFeedRequestFunction();

		/// <summary>
		/// A request to the YouTube API for a comment feed.
		/// </summary>
		/// <param name="settings">The request settings.</param>
		public YouTubeRequestFeed(YouTubeSettings settings)
			: base(settings)
		{
		}

		/// <summary>
		/// Ends an asynchronous request for a comment feed.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The comments feed object.</returns>
		public new Feed<T> End(IAsyncResult result, out object state)
		{
			return this.funcConvert.GetResult(base.End(result, out state));
		}

		/// <summary>
		/// Ends an asynchronous request for a comment feed.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <returns>The comment feed object.</returns>
		public new Feed<T> End(IAsyncResult result)
		{
			object state;
			return this.funcConvert.GetResult(base.End(result, out state));
		}
	}
}
