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
		private AccessControlAction action;
		private AccessControlPermission permission;

        /// <summary>
        /// Creates an access control object based on an atom instance.
        /// </summary>
        /// <param name="atom">The atom instance.</param>
		public AccessControlEntry(AtomYtAccessControl atom)
		{
			switch (atom.Action.ToLower())
			{
				case "rate": this.action = AccessControlAction.Rate; break;
				case "comment": this.action = AccessControlAction.Comment; break;
				case "commentvote": this.action = AccessControlAction.CommentVote; break;
                case "videorespond": this.action = AccessControlAction.VideoRespond; break;
                case "embed": this.action = AccessControlAction.Embed; break;
                case "syndicate": this.action = AccessControlAction.Syndicate; break;
                case "list": this.action = AccessControlAction.List; break;
				case "autoplay": this.action = AccessControlAction.AutoPlay; break;
                default: throw new YouTubeException(string.Format("Cannot create access control entry: unknown action \"{0}\".", atom.Action));
			}
            switch (atom.Permission.ToLower())
            {
                case "allowed": this.permission = AccessControlPermission.Allowed; break;
                case "denied": this.permission = AccessControlPermission.Denied; break;
                case "moderated": this.permission = AccessControlPermission.Moderated; break;
                default: throw new YouTubeException(string.Format("Cannot create access control entry: unknown permission \"{0}\".", atom.Permission));
            }
		}

        public AccessControlAction Action { get { return this.action; } }
        public AccessControlPermission Permission { get { return this.permission; } } 
	}
}
