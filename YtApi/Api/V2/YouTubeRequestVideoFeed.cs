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
using YtApi.Api.V2.Atom;
using YtApi.Api.V2.Data;

namespace YtApi.Api.V2
{
	/// <summary>
	/// Class representing a request for a YouTube standard feed.
	/// </summary>
	public class YouTubeRequestVideoFeed : YouTubeRequest
	{
		/// <summary>
		/// Conversion class for an asynchronous operation returning a video feed.
		/// </summary>
		public class VideoFeedRequestFunction : IAsyncFunction<Feed<Video>>
		{
			/// <summary>
			/// Returns a videos feed for the received asynchronous data.
			/// </summary>
			/// <param name="data">The data string.</param>
			/// <returns>A video feed.</returns>
			public Feed<Video> GetResult(string data)
			{
				// Parse the string data.
				return new Feed<Video>(AtomFeedVideo.Parse(data));
			}
		}

		private VideoFeedRequestFunction funcConvert = new VideoFeedRequestFunction();

		/// <summary>
		/// A request to the YouTube API for a video feed.
		/// </summary>
		/// <param name="settings">The request settings.</param>
		public YouTubeRequestVideoFeed(YouTubeSettings settings)
			: base(settings)
		{
		}

		/// <summary>
		/// Ends an asynchronous request for a video.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The video object.</returns>
		public new Feed<Video> End(IAsyncResult result, out object state)
		{
			return this.funcConvert.GetResult(base.End(result, out state));
		}

		/// <summary>
		/// Ends an asynchronous request for a video.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <returns>The video object.</returns>
		public Feed<Video> End(IAsyncResult result)
		{
			object state;
			return this.funcConvert.GetResult(base.End(result, out state));
		}
	}
}
