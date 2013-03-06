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

namespace YtApi.Api.V2.Data
{
	[Serializable]
	public sealed class Statistics
	{
		private AtomYtStatistics atom;

		/// <summary>
		/// Creates a statistics object, based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public Statistics(AtomYtStatistics atom)
		{
			this.atom = atom;
		}

		/// <summary>
		/// For a video, it represents the number of times a video has been watched.
		/// For a user, it represents the number of times the user profile has been viewed.
		/// </summary>
		public int ViewCount { get { return this.atom.ViewCount; } }

		/// <summary>
		/// For a video, null.
		/// For a user, the number of videos watched.
		/// </summary>
		public int? VideoWatchCount { get { return this.atom.VideoWatchCount; } }

		/// <summary>
		/// For a video, null.
		/// For a user, the number of subscribers.
		/// </summary>
		public int? SubscriberCount { get { return this.atom.SubscriberCount; } }

		/// <summary>
		/// For a video, null.
		/// For a user, the date/time of the last access to YouTube.
		/// </summary>
		public DateTime? LastWebAccess { get { return this.atom.LastWebAccess; } }

		/// <summary>
		/// For a video, the number of times the video has been added as favorite.
		/// For a user, null.
		/// </summary>
		public int? FavoriteCount { get { return this.atom.FavoriteCount; } }

		/// <summary>
		/// For a video, null.
		/// For a user, the total number of views for all videos.
		/// </summary>
		public Int64? TotalUploadViews { get { return this.atom.TotalUploadViews; } }
	}
}
