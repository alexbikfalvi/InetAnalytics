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
using DotNetApi;
using YtApi.Api.V2.Atom;

namespace YtApi.Api.V2.Data
{
	[Serializable]
	public enum AccessControlAction
	{
		Rate = 1,
		Comment = 2,
		CommentVote = 3,
		VideoRespond = 4,
		Embed = 5,
		Syndicate = 6,
		List = 7,
		AutoPlay = 8
	}

	[Serializable]
	public enum AccessControlPermission
	{
		Allowed = 1,
		Denied = 2,
		Moderated = 3
	}

	/// <summary>
	/// A class that represents an access control entry.
	/// </summary>
	[Serializable]
	public sealed class AccessControlEntry
	{
        /// <summary>
        /// Creates an access control object based on an atom instance.
        /// </summary>
        /// <param name="atom">The atom instance.</param>
		public AccessControlEntry(AtomYtAccessControl atom)
		{
			switch (atom.Action.ToLower())
			{
				case "rate": this.Action = AccessControlAction.Rate; break;
				case "comment": this.Action = AccessControlAction.Comment; break;
				case "commentvote": this.Action = AccessControlAction.CommentVote; break;
                case "videorespond": this.Action = AccessControlAction.VideoRespond; break;
                case "embed": this.Action = AccessControlAction.Embed; break;
                case "syndicate": this.Action = AccessControlAction.Syndicate; break;
                case "list": this.Action = AccessControlAction.List; break;
				case "autoplay": this.Action = AccessControlAction.AutoPlay; break;
                default: throw new YouTubeException("Cannot create access control entry: unknown action \"{0}\".".FormatWith(atom.Action));
			}
            switch (atom.Permission.ToLower())
            {
                case "allowed": this.Permission = AccessControlPermission.Allowed; break;
                case "denied": this.Permission = AccessControlPermission.Denied; break;
                case "moderated": this.Permission = AccessControlPermission.Moderated; break;
                default: throw new YouTubeException("Cannot create access control entry: unknown permission \"{0}\".".FormatWith(atom.Permission));
            }
		}

		/// <summary>
		/// Gets the access control action.
		/// </summary>
		public AccessControlAction Action { get; private set; }
		/// <summary>
		/// Gets the access control permission.
		/// </summary>
		public AccessControlPermission Permission { get; private set; } 
	}
}
