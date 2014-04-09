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
using System.Xml.Linq;
using DotNetApi.Xml;
using InetCommon.Web;

namespace InetApi.YouTube.Api.V2.Atom
{
	/// <summary>
	/// A class representing a media:group atom.
	/// </summary>
	[Serializable]
	public sealed class AtomMediaGroup : Atom
	{
		internal const string xmlPrefix = "media";
		internal const string xmlName = "group";

		/// <summary>
		/// Private constructor.
		/// </summary>
		/// <param name="element">The XML element.</param>
		private AtomMediaGroup(XElement element)
			: base(xmlPrefix, xmlName, element)
		{
			// Set the elements.
			this.MediaTitle = AtomMediaTitle.ParseChild(element, false);
			this.MediaDescription = AtomMediaDescription.ParseChild(element, false);
			this.MediaKeywords = AtomMediaKeywords.ParseChild(element, false);
			this.MediaCategory = AtomMediaCategory.ParseChild(element, false);
			this.MediaContents = AtomMediaContentList.ParseChildren(element);
			this.MediaCredits = AtomMediaCreditList.ParseChildren(element);
			this.MediaPlayer = AtomMediaPlayer.ParseChild(element, false);
			this.MediaPrices = AtomMediaPriceList.ParseChildren(element);
			this.MediaRating = AtomMediaRating.ParseChild(element, false);
			this.MediaRestriction = AtomMediaRestriction.ParseChild(element, false);
			this.MediaThumbnails = AtomMediaThumbnailList.ParseChildren(element);
			this.YtAspectRatio = AtomYtAspectRatio.ParseChild(element, false);
			this.YtAudioTracks = AtomYtAudioTracks.ParseChild(element, false);
			this.YtCaptionTracks = AtomYtCaptionTracks.ParseChild(element, false);
			this.YtDuration = AtomYtDuration.ParseChild(element, false);
			this.YtPrivate = element.Element("yt", "private") != null ? true : false;
			this.YtUploaded = AtomYtUploaded.ParseChild(element, false);
			this.YtUploaderId = AtomYtUploaderId.ParseChild(element, false);
			this.YtVideoId = AtomYtVideoId.ParseChild(element, false);
		}

		// Public methods.

		/// <summary>
		/// Parses the XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomMediaGroup Parse(XElement element, bool mandatory)
		{
			// If the element is null.
			if (null == element)
			{
				// If the element is mandatory, throw an exception.
				if (mandatory) throw new ArgumentNullException("element");
				else return null;
			}

			// Return a new atom instance.
			return new AtomMediaGroup(element);
		}

		/// <summary>
		/// Parses the first child XML element into a new atom instance.
		/// </summary>
		/// <param name="element">The parent XML element.</param>
		/// <param name="mandatory">Specified whether this element is mandatory.</param>
		/// <returns>The atom instance.</returns>
		public static AtomMediaGroup ParseChild(XElement element, bool mandatory)
		{
			// If the element is null, throw an exception.
			if (null == element) throw new ArgumentNullException("element");

			try
			{
				// Parse the children for the first element.
				return AtomMediaGroup.Parse(element.Element(AtomMediaGroup.xmlPrefix, AtomMediaGroup.xmlName), mandatory);
			}
			catch (Exception exception)
			{
				// Throw a new atom exception.
				throw exception is AtomException ? exception : new AtomException("An error occurred while parsing the children of an XML element.", element, exception);
			}
		}

		// Properties.

		// Elements.
		public AtomMediaTitle MediaTitle { get; private set; }
		public AtomMediaDescription MediaDescription { get; private set; }
		public AtomMediaKeywords MediaKeywords { get; private set; }
		public AtomMediaCategory MediaCategory { get; private set; }
		public AtomMediaContentList MediaContents { get; private set; }
		public AtomMediaCreditList MediaCredits { get; private set; }
		public AtomMediaPlayer MediaPlayer { get; private set; }
		public AtomMediaPriceList MediaPrices { get; private set; }
		public AtomMediaRating MediaRating { get; private set; }
		public AtomMediaRestriction MediaRestriction { get; private set; }
		public AtomMediaThumbnailList MediaThumbnails { get; private set; }
		public AtomYtAspectRatio YtAspectRatio { get; private set; }
		public AtomYtAudioTracks YtAudioTracks { get; private set; }
		public AtomYtCaptionTracks YtCaptionTracks { get; private set; }
		public AtomYtDuration YtDuration { get; private set; }
		public bool YtPrivate { get; private set; }
		public AtomYtUploaded YtUploaded { get; private set; }
		public AtomYtUploaderId YtUploaderId { get; private set; }
		public AtomYtVideoId YtVideoId { get; private set; }
	}
}
