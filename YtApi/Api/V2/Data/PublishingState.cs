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
	public enum PublishingStateName
	{
		Processing = 1,
		Restricted = 2,
		Deleted = 3,
		Rejected = 4,
		Failed = 5
	}

	[Serializable]
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
	[Serializable]
	public sealed class PublishingState
	{
		/// <summary>
		/// Creates a new publishing state object based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public PublishingState(AtomAppControl atom)
		{
			this.IsDraft = atom.AppDraft != null;

			if (null != atom.YtState)
			{
				switch (atom.YtState.Name.ToLower())
				{
					case "processing": this.Name = PublishingStateName.Processing; this.Reason = PublishingStateReason.Unspecified; break;
					case "restricted":
						this.Name = PublishingStateName.Restricted;
						switch (atom.YtState.ReasonCode.ToLower())
						{
							case "requesterregion": this.Reason = PublishingStateReason.RestrictedRequesterRegion; break;
							case "limitedsyndication": this.Reason = PublishingStateReason.RestrictedLimitedSyndication; break;
							case "private": this.Reason = PublishingStateReason.RestrictedPrivate; break;
							default: throw new YouTubeException("Cannot create the publishing state: invalid reason code \"{0}\"for state name \"{1}\".".FormatWith(atom.YtState.ReasonCode, atom.YtState.Name));
						}
						break;
					case "deleted": this.Name = PublishingStateName.Deleted; this.Reason = PublishingStateReason.Unspecified; break;
					case "rejected":
						this.Name = PublishingStateName.Rejected;
						switch (atom.YtState.ReasonCode.ToLower())
						{
							case "copyright": this.Reason = PublishingStateReason.RejectedCopyright; break;
							case "inappropriate": this.Reason = PublishingStateReason.RejectedInappropriate; break;
							case "duplicate": this.Reason = PublishingStateReason.RejectedDuplicate; break;
							case "termsofuse": this.Reason = PublishingStateReason.RejectedTermsOfUse; break;
							case "suspended": this.Reason = PublishingStateReason.RejectedSuspended; break;
							case "toolong": this.Reason = PublishingStateReason.RejectedTooLong; break;
							case "blocked": this.Reason = PublishingStateReason.RejectedBlocked; break;
							default: throw new YouTubeException("Cannot create the publishing state: invalid reason code \"{0}\"for state name \"{1}\".".FormatWith(atom.YtState.ReasonCode, atom.YtState.Name));
						}
						break;
					case "failed":
						this.Name = PublishingStateName.Failed;
						switch (atom.YtState.ReasonCode.ToLower())
						{
							case "cantprocess": this.Reason = PublishingStateReason.FailedCantProcess; break;
							case "invalidformat": this.Reason = PublishingStateReason.FailedInvalidFormat; break;
							case "unsupportedcodec": this.Reason = PublishingStateReason.FailedUnsupportedCodec; break;
							case "empty": this.Reason = PublishingStateReason.FailedEmpty; break;
							case "toosmall": this.Reason = PublishingStateReason.FailedTooSmall; break;
							default: throw new YouTubeException("Cannot create the publishing state: invalid reason code \"{0}\"for state name \"{1}\".".FormatWith(atom.YtState.ReasonCode, atom.YtState.Name));
						}
						break;
					default: throw new YouTubeException("Cannot create the publishing state: unknwon state name \"{0}\".".FormatWith(atom.YtState.Name));
				}
			}
			else
			{
				this.Name = null;
				this.Reason = null;
			}
		}

		/// <summary>
		/// Indicates whether the video is a draft.
		/// </summary>
		public bool IsDraft { get; private set; }

		/// <summary>
		/// The state name.
		/// </summary>
		public PublishingStateName? Name { get; private set; }

		/// <summary>
		/// The state reason.
		/// </summary>
		public PublishingStateReason? Reason { get; private set; }
	}
}
