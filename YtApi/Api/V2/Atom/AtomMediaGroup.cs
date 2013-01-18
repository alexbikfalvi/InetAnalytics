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
using System.Xml.Linq;

namespace YtApi.Api.V2.Atom
{
	[Serializable]
	public sealed class AtomMediaGroup : Atom
	{
		private AtomMediaGroup() { }

		public static AtomMediaGroup Parse(XElement element, XmlNamespace top)
		{
			AtomMediaGroup atom = new AtomMediaGroup();
			XmlNamespace ns = new XmlNamespace(element, top);
			XElement el;

			atom.MediaContent = new List<AtomMediaContent>();
			atom.MediaCredit = new List<AtomMediaCredit>();
			atom.MediaPrice = new List<AtomMediaPrice>();
			atom.MediaThumbnail = new List<AtomMediaThumbnail>();

			atom.MediaTitle = (el = element.Element(XName.Get("title", ns["media"]))) != null ? AtomMediaTitle.Parse(el) : null;
			atom.MediaDescription = (el = element.Element(XName.Get("description", ns["media"]))) != null ? AtomMediaDescription.Parse(el) : null;
			atom.MediaKeywords = (el = element.Element(XName.Get("keywords", ns["media"]))) != null ? AtomMediaKeywords.Parse(el) : null;
			atom.MediaCategory = AtomMediaCategory.Parse(element.Element(XName.Get("category", ns["media"])));
			foreach (XElement child in element.Elements(XName.Get("content", ns["media"])))
				atom.MediaContent.Add(AtomMediaContent.Parse(child, ns));
			foreach (XElement child in element.Elements(XName.Get("credit", ns["media"])))
				atom.MediaCredit.Add(AtomMediaCredit.Parse(child, ns));
			atom.MediaPlayer = (el = element.Element(XName.Get("player", ns["media"]))) != null ? AtomMediaPlayer.Parse(el) : null;
			foreach (XElement child in element.Elements(XName.Get("price", ns["media"])))
				atom.MediaPrice.Add(AtomMediaPrice.Parse(child, ns));
			atom.MediaRating = (el = element.Element(XName.Get("rating", ns["media"]))) != null ? AtomMediaRating.Parse(el) : null;
			atom.MediaRestriction = (el = element.Element(XName.Get("restriction", ns["media"]))) != null ? AtomMediaRestriction.Parse(el) : null;
			foreach (XElement child in element.Elements(XName.Get("thumbnail", ns["media"])))
				atom.MediaThumbnail.Add(AtomMediaThumbnail.Parse(child, ns));
			atom.YtAspectRatio = (el = element.Element(XName.Get("aspectratio", ns["yt"]))) != null ? AtomYtAspectRatio.Parse(el) : null;
			atom.YtAudioTracks = (el = element.Element(XName.Get("audioTracks", ns["yt"]))) != null ? AtomYtAudioTracks.Parse(el) : null;
			atom.YtCaptionTracks = (el = element.Element(XName.Get("captionTracks", ns["yt"]))) != null ? AtomYtCaptionTracks.Parse(el) : null;
			atom.YtDuration = (el = element.Element(XName.Get("duration", ns["yt"]))) != null ? AtomYtDuration.Parse(el) : null;
			atom.YtPrivate = (el = element.Element(XName.Get("private", ns["yt"]))) != null ? true : false;
			atom.YtUploaded = (el = element.Element(XName.Get("uploaded", ns["yt"]))) != null ? AtomYtUploaded.Parse(el) : null;
			atom.YtUploaderId = (el = element.Element(XName.Get("uploaderId", ns["yt"]))) != null ? AtomYtUploaderId.Parse(el) : null;
			atom.YtVideoId = (el = element.Element(XName.Get("videoid", ns["yt"]))) != null ? AtomYtVideoId.Parse(el) : null;

			return atom;
		}

		// Elements
		public AtomMediaTitle MediaTitle { get; set; }
		public AtomMediaDescription MediaDescription { get; set; }
		public AtomMediaKeywords MediaKeywords { get; set; }
		public AtomMediaCategory MediaCategory { get; set; }
		public List<AtomMediaContent> MediaContent { get; set; }
		public List<AtomMediaCredit> MediaCredit { get; set; }
		public AtomMediaPlayer MediaPlayer { get; set; }
		public List<AtomMediaPrice> MediaPrice { get; set; }
		public AtomMediaRating MediaRating { get; set; }
		public AtomMediaRestriction MediaRestriction { get; set; }
		public List<AtomMediaThumbnail> MediaThumbnail { get; set; }
		public AtomYtAspectRatio YtAspectRatio { get; set; }
		public AtomYtAudioTracks YtAudioTracks { get; set; }
		public AtomYtCaptionTracks YtCaptionTracks { get; set; }
		public AtomYtDuration YtDuration { get; set; }
		public bool YtPrivate { get; set; }
		public AtomYtUploaded YtUploaded { get; set; }
		public AtomYtUploaderId YtUploaderId { get; set; }
		public AtomYtVideoId YtVideoId { get; set; }
	}
}
