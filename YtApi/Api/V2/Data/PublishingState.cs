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
	public enum PublishingStateName
	{
		Processing = 1,
		Restricted = 2,
		Deleted = 3,
		Rejected = 4,
		Failed = 5
	}

	public enum PublishingStateReason
	{
		Unspecified = 0,

		RestrictedRequesterRegion = 0x00020001,
		RestrictedLimitedSyndication = 0x00020002,
		RestrictedPrivate = 0x00020003,

		RejectedCopyright = 0x00040001,
		RejectedInappropriate = 0x00040002,
		RejectedDuplicate = 0x00040003,
		RejectedTermsOfUse = 0x00040004,
		RejectedSuspended = 0x00040005,
		RejectedTooLong = 0x00040006,
		RejectedBlocked = 0x00040007,

		FailedCantProcess = 0x00050001,
		FailedInvalidFormat = 0x00050002,
		FailedUnsupportedCodec = 0x00050003,
		FailedEmpty = 0x00050004,
		FailedTooSmall = 0x00050005
	}

	/// <summary>
	/// Indicates the publishing state of a video.
	/// </summary>
	public class PublishingState
	{
		bool draft;

		PublishingStateName? name;
		PublishingStateReason? reason;

		/// <summary>
		/// Creates a new publishing state object based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public PublishingState(AtomAppControl atom)
		{
			this.draft = atom.AppDraft != null;

			if (null != atom.YtState)
			{
				switch (atom.YtState.Name.ToLower())
				{
					case "processing": this.name = PublishingStateName.Processing; this.reason = PublishingStateReason.Unspecified; break;
					case "restricted":
						this.name = PublishingStateName.Restricted;
						switch (atom.YtState.ReasonCode.ToLower())
						{
							case "requesterregion": this.reason = PublishingStateReason.RestrictedRequesterRegion; break;
							case "limitedsyndication": this.reason = PublishingStateReason.RestrictedLimitedSyndication; break;
							case "private": this.reason = PublishingStateReason.RestrictedPrivate; break;
							default: throw new YouTubeException(string.Format("Cannot create the publishing state: invalid reason code \"{0}\"for state name \"{1}\".", atom.YtState.ReasonCode, atom.YtState.Name));
						}
						break;
					case "deleted": this.name = PublishingStateName.Deleted; this.reason = PublishingStateReason.Unspecified; break;
					case "rejected":
						this.name = PublishingStateName.Rejected;
						switch (atom.YtState.ReasonCode.ToLower())
						{
							case "copyright": this.reason = PublishingStateReason.RejectedCopyright; break;
							case "inappropriate": this.reason = PublishingStateReason.RejectedInappropriate; break;
							case "duplicate": this.reason = PublishingStateReason.RejectedDuplicate; break;
							case "termsofuse": this.reason = PublishingStateReason.RejectedTermsOfUse; break;
							case "suspended": this.reason = PublishingStateReason.RejectedSuspended; break;
							case "toolong": this.reason = PublishingStateReason.RejectedTooLong; break;
							case "blocked": this.reason = PublishingStateReason.RejectedBlocked; break;
							default: throw new YouTubeException(string.Format("Cannot create the publishing state: invalid reason code \"{0}\"for state name \"{1}\".", atom.YtState.ReasonCode, atom.YtState.Name));
						}
						break;
					case "failed":
						this.name = PublishingStateName.Failed;
						switch (atom.YtState.ReasonCode.ToLower())
						{
							case "cantprocess": this.reason = PublishingStateReason.FailedCantProcess; break;
							case "invalidformat": this.reason = PublishingStateReason.FailedInvalidFormat; break;
							case "unsupportedcodec": this.reason = PublishingStateReason.FailedUnsupportedCodec; break;
							case "empty": this.reason = PublishingStateReason.FailedEmpty; break;
							case "toosmall": this.reason = PublishingStateReason.FailedTooSmall; break;
							default: throw new YouTubeException(string.Format("Cannot create the publishing state: invalid reason code \"{0}\"for state name \"{1}\".", atom.YtState.ReasonCode, atom.YtState.Name));
						}
						break;
					default: throw new YouTubeException(string.Format("Cannot create the publishing state: unknwon state name \"{0}\".", atom.YtState.Name));
				}
			}
			else
			{
				this.name = null;
				this.reason = null;
			}
		}

		/// <summary>
		/// Indicates whether the video is a draft.
		/// </summary>
		public bool IsDraft { get { return this.draft; } }

		/// <summary>
		/// The state name.
		/// </summary>
		public PublishingStateName? Name { get { return this.name; } }

		/// <summary>
		/// The state reason.
		/// </summary>
		public PublishingStateReason? Reason { get { return this.reason; } }
	}
}
