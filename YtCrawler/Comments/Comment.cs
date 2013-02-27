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
	/// Represents a user comment.
	/// </summary>
	public abstract class Comment
	{
		public enum CommentType
		{
			Object = 0,
			Video = 1,
			User = 2
		};

		private Guid guid;
		private DateTime time;
		private string user;
		private string text;
		private CommentType type;

		private XElement xml = null;

		/// <summary>
		/// Creates an empty comment with the current time.
		/// </summary>
		public Comment()
		{
			this.guid = Guid.Empty;
			this.time = DateTime.Now;
			this.user = string.Empty;
			this.text = string.Empty;
			this.type = CommentType.Object;
		}

		/// <summary>
		/// Creates a comment instance.
		/// </summary>
		/// <param name="time">The time.</param>
		/// <param name="user">The user.</param>
		/// <param name="text">The text.</param>
		/// <param name="obj"></param>
		public Comment(DateTime time, string user, string text, string obj)
		{
			this.guid = Guid.NewGuid();
			this.time = time;
			this.user = user;
			this.text = text;

			this.xml = new XElement("comment",
				new XAttribute("guid", this.guid),
				new XAttribute("time", this.time),
				new XAttribute("user", this.user),
				text);
		}

		/// <summary>
		/// Parses the comment from an XML element.
		/// </summary>
		/// <param name="xml">The XML element.</param>
		public virtual void Parse(XElement xml)
		{
			this.guid = Guid.Parse(xml.Attribute("guid").Value);
			this.time = DateTime.Parse(xml.Attribute("time").Value);
			this.user = xml.Attribute("user").Value;
			this.text = xml.Value;
			this.xml = xml;
		}

		/// <summary>
		/// Returns the GUID.
		/// </summary>
		public Guid Guid { get { return this.guid; } }

		public string Object { 

		/// <summary>
		/// Returns the comment time.
		/// </summary>
		public DateTime Time { get { return this.time; } }

		/// <summary>
		/// Returns the comment user.
		/// </summary>
		public string User { get { return this.user; } }

		/// <summary>
		/// Returns the comment text.
		/// </summary>
		public string Text { get { return this.text; } }

		/// <summary>
		/// Returns the XML element corresponding to this comment.
		/// </summary>
		public XElement Xml { get { return this.xml; } }
	}
}
