/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
using InetApi.YouTube.Api.V2.Atom;

namespace InetApi.YouTube.Api.V2.Data
{
	/// <summary>
	/// A class describing a YouTube video.
	/// </summary>
	[Serializable]
	public sealed class Video : Entry
	{
		private AtomEntryVideo atom;

		/// <summary>
		/// Creates a new video entry from an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		/// <returns>The video entry.</returns>
		public override Entry Create(InetApi.YouTube.Api.V2.Atom.Atom atom)
		{
			return new Video(atom as AtomEntryVideo);
		}

		/// <summary>
		/// Creates an undefined video object.
		/// </summary>
		public Video() { }

		/// <summary>
		/// Creates a video object based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public Video(AtomEntryVideo atom)
		{
			this.atom = atom;

			if (null == this.atom.MediaGroup) throw new YouTubeException("Cannot parse video atom object with ID {0}: the media group is missing.".FormatWith(this.AtomId));
			if (null == this.atom.MediaGroup.YtVideoId) throw new YouTubeException("Cannot parse video atom object with ID {0}: the media group video ID is missing.".FormatWith(this.AtomId));
			if (null == this.atom.MediaGroup.MediaCategory) throw new YouTubeException("Cannot parse video atom object with ID {0}: the media group category is missing.".FormatWith(this.AtomId));
			if (null == this.atom.Updated) throw new YouTubeException("Cannot parse video atom object with ID {0}: the updated date/time is missing.".FormatWith(this.AtomId));
			if (null == this.atom.Title) throw new YouTubeException("Cannot parse video atom object with ID {0}: the title is missing.".FormatWith(this.AtomId));

			this.Author = this.atom.Author != null ? new Author(this.atom.Author) : null;
			this.Category = new Category(this.atom.MediaGroup.MediaCategory);
            this.Prices = new PriceList(this.atom.MediaGroup.MediaPrices);
			this.ContentRating = this.atom.MediaGroup.MediaRating != null ? new ContentRating(this.atom.MediaGroup.MediaRating) : null;
			this.Restriction = this.atom.MediaGroup.MediaRestriction != null ? new Restriction(this.atom.MediaGroup.MediaRestriction) : null;
			this.Statistics = this.atom.YtStatistics != null ? new Statistics(this.atom.YtStatistics) : null;
			this.UserRatingStar = this.atom.GdRating != null ? new UserRatingStar(this.atom.GdRating) : null;
            this.UserRatingLike = this.atom.YtRating != null ? new UserRatingLike(this.atom.YtRating) : null;
            this.AccessControl = new AccessControlList(this.atom.YtAccessControlList);
			this.Availability = this.atom.YtAvailability != null ? new Availability(this.atom.YtAvailability) : null;
			this.GeoLocation = this.atom.GeoRssWhere != null ? new GeoLocation(this.atom.GeoRssWhere) : null;
			this.State = this.atom.AppControl != null ? new PublishingState(this.atom.AppControl) : null;
			this.Thumbnails = new ThumbnailList(this.atom.MediaGroup.MediaThumbnails);
		}

		/// <summary>
		/// Creates a corresponding atom feed from the specified data string.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <returns>The atom feed.</returns>
		public override AtomFeed CreateFeed(string data)
		{
			return AtomFeedVideo.Parse(data);
		}

		/// <summary>
		/// Returns the atom corresponding to this video.
		/// </summary>
		public AtomEntryVideo Atom { get { return this.atom; } }

		/// <summary>
		/// Returns the Atom ID of the video object (usually an URL of type "http://gdata.youtube.com/feeds/api/videos/<videoID>").
		/// Use the Id property to get the video ID as published in the media group. It cannot be null.
		/// </summary>
		public string AtomId { get { return this.atom.Id.Value; } }

		/// <summary>
		/// Returns the ID of the video object as published in the media group. It cannot be null.
		/// </summary>
		public string Id { get { return this.atom.MediaGroup.YtVideoId.Value; } }

		/// <summary>
		/// The date/time of video publication. It can be null.
		/// </summary>
		public DateTime? Published { get { return this.atom.Published != null ? this.atom.Published.Value as DateTime? : null; } }

		/// <summary>
		/// The date/time when the video entry was last updated. It cannot be null.
		/// </summary>
		public DateTime Updated { get { return this.atom.Updated.Value; } }

		/// <summary>
		/// The video title. It cannot be null.
		/// </summary>
		public string Title { get { return this.atom.Title.Value; } }

		/// <summary>
		/// The video description. It can be null.
		/// </summary>
		public string Description { get { return this.atom.MediaGroup.MediaDescription != null ? this.atom.MediaGroup.MediaDescription.Value : null; } }

		/// <summary>
		/// The video keywords. It can be null.
		/// </summary>
		public string Keywords { get { return this.atom.MediaGroup.MediaKeywords != null ? this.atom.MediaGroup.MediaKeywords.Value : null; } }

		/// <summary>
		/// The video author. It can be null.
		/// </summary>
		public Author Author { get; private set; }

		/// <summary>
		/// The video category. It cannot be null.
		/// </summary>
		public Category Category { get; private set; }

		/// <summary>
		/// The video prices, if any. It cannot be null, however it may have zero elements.
		/// </summary>
		public PriceList Prices { get; private set; }

		/// <summary>
		/// The content rating, if any. It can be null.
		/// </summary>
		public ContentRating ContentRating { get; private set; }

		/// <summary>
		/// The media restriction, if any. It can be null.
		/// </summary>
		public Restriction Restriction { get; private set; }

		/// <summary>
		/// Indicates the video has a widescreen format.
		/// </summary>
		public bool IsWidescreen { get { return this.atom.MediaGroup.YtAspectRatio != null; } }

		/// <summary>
		/// Indicates multiple audio tracks for this video. It can be null.
		/// </summary>
		public string AudioTracks { get { return this.atom.MediaGroup.YtAudioTracks != null ? this.atom.MediaGroup.YtAudioTracks.Value : null; } }

		/// <summary>
		/// Indicates multple caption tracks for this video. It can be null.
		/// </summary>
		public string CaptionTracks { get { return this.atom.MediaGroup.YtCaptionTracks != null ? this.atom.MediaGroup.YtCaptionTracks.Value : null; } }

		/// <summary>
		/// The duration of the video. It can be null.
		/// </summary>
		public TimeSpan? Duration { get { return this.atom.MediaGroup.YtDuration != null ? TimeSpan.FromSeconds(this.atom.MediaGroup.YtDuration.Value) as TimeSpan? : null; } }

		/// <summary>
		/// Indicates whether the video is private.
		/// </summary>
		public bool IsPrivate { get { return this.atom.MediaGroup.YtPrivate; } }

		/// <summary>
		/// The date/time when the video was uploaded. It can be null.
		/// </summary>
		public DateTime? Uploaded { get { return this.atom.MediaGroup.YtUploaded != null ? this.atom.MediaGroup.YtUploaded.Value as DateTime? : null; } }

		/// <summary>
		/// The ID of the video uploader. It can be null.
		/// </summary>
		public string Uploader { get { return this.atom.MediaGroup.YtUploaderId != null ? this.atom.MediaGroup.YtUploaderId.Value : null; } }

		/// <summary>
		/// The statistics for this video. It can be null.
		/// </summary>
		public Statistics Statistics { get; private set; }

		/// <summary>
		/// The comments count. It can be null.
		/// </summary>
		public int? Comments { get { return this.atom.GdComments != null ? this.atom.GdComments.FeedLink.CountHint as int? : null; } }

		/// <summary>
		/// The user rating based on star ratings (for old views). It can be null.
		/// </summary>
		public UserRatingStar UserRatingStar { get; private set; }

		/// <summary>
		/// The user rating based on likes ratings (for new views). It can be null.
		/// </summary>
		public UserRatingLike UserRatingLike { get; private set; }

		/// <summary>
		/// The location at which the video was taken. It can be null.
		/// </summary>
		public string Location { get { return this.atom.YtLocation != null ? this.atom.YtLocation.Value : null; } }

		/// <summary>
		/// The date/time at which the video was recorded. It can be null.
		/// </summary>
		public DateTime? Recorded { get { return this.atom.YtRecorded != null ? this.atom.YtRecorded.Value as DateTime? : null; } }

        /// <summary>
        /// The access control list for the video. It cannot be null.
        /// </summary>
		public AccessControlList AccessControl { get; private set; }

		/// <summary>
		/// The availability period for a video, if specified. It can be null.
		/// </summary>
		public Availability Availability { get; private set; }

		/// <summary>
		/// The video episode number, if the video is part of a TV show. It can be null.
		/// </summary>
		public string Episode { get { return this.atom.YtEpisode != null ? this.atom.YtEpisode.Number : null;  } }

		/// <summary>
		/// The video favorite ID, if any. It can be null.
		/// </summary>
		public string FavoriteId { get { return this.atom.YtFavoriteId != null ? this.atom.YtFavoriteId.Value : null; } }

		/// <summary>
		/// The date/time when the video was first released. It can be null.
		/// </summary>
		public DateTime? FirstReleased { get { return this.atom.YtFirstReleased != null ? this.atom.YtFirstReleased.Value as DateTime? : null; } }

		/// <summary>
		/// The geographical location associated with the video. It can be null.
		/// </summary>
		public GeoLocation GeoLocation { get; private set; }

		/// <summary>
		/// The publishing state of the video. It can be null.
		/// </summary>
		public PublishingState State { get; private set; }

		/// <summary>
		/// The list of thumbnails for this video. It cannot be null.
		/// </summary>
		public ThumbnailList Thumbnails { get; private set; }
	}
}
