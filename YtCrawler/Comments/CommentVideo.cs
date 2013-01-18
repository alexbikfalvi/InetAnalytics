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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YtCrawler.Comments
{
	/// <summary>
	/// A class that represents a video comment.
	/// </summary>
	public class CommentVideo : Comment
	{
		private string video;

		/// <summary>
		/// Creates an empty video comment with the current time.
		/// </summary>
		public CommentVideo()
			: base()
		{
			this.video = string.Empty;
		}

		/// <summary>
		/// Creates a new video comment instance.
		/// </summary>
		/// <param name="time">The time.</param>
		/// <param name="user">The user.</param>
		/// <param name="text">The text.</param>
		/// <param name="video">The video.</param>
		public CommentVideo(DateTime time, string user, string text, string video)
			: base(time, user, text)
		{
			this.video = video;

			this.Xml.Add(new XAttribute("video", video));
		}

		/// <summary>
		/// Parses the video comment from an XML element.
		/// </summary>
		/// <param name="xml">The XML element.</param>
		public override void Parse(XElement xml)
		{
			// Parse the base class fields.
			base.Parse(xml);

			this.video = xml.Attribute("video").Value;
		}

		/// <summary>
		/// Returns the comment video.
		/// </summary>
		public string Video { get { return this.video; } }
	}
}
