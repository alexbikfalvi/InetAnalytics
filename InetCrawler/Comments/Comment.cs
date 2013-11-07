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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InetCrawler.Comments
{
	/// <summary>
	/// Represents a user comment.
	/// </summary>
	public sealed class Comment
	{
		public enum CommentType
		{
			Video = 0,
			User = 1,
			Playlist = 2
		}

		private CommentType type;
		private Guid guid;
		private DateTime time;
		private string user;
		private string item;
		private string text;

		private XElement xml = null;

		/// <summary>
		/// Private contructor.
		/// </summary>
		private Comment() { }

		/// <summary>
		/// Creates a comment instance.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="time">The time.</param>
		/// <param name="user">The user.</param>
		/// <param name="item">The item.</param>
		/// <param name="text">The text.</param>
		public Comment(CommentType type, DateTime time, string user, string item, string text)
		{
			this.type = type;
			this.guid = Guid.NewGuid();
			this.time = time;
			this.user = user;
			this.item = item;
			this.text = text;

			this.xml = new XElement("comment",
				new XAttribute("type", ((int)this.type).ToString(CultureInfo.InvariantCulture)),
				new XAttribute("guid", this.guid),
				new XAttribute("time", this.time.ToString(CultureInfo.InvariantCulture)),
				new XAttribute("item", this.item),
				new XAttribute("user", this.user),
				text);
		}

		/// <summary>
		/// Creates a new comment instance from an XML element.
		/// </summary>
		/// <param name="xml">The XML element.</param>
		public Comment(XElement xml)
		{
			this.type = (CommentType)int.Parse(xml.Attribute("type").Value, CultureInfo.InvariantCulture);
			this.guid = Guid.Parse(xml.Attribute("guid").Value);
			this.time = DateTime.Parse(xml.Attribute("time").Value, CultureInfo.InvariantCulture);
			this.user = xml.Attribute("user").Value;
			this.item = xml.Attribute("item").Value;
			this.text = xml.Value;
			this.xml = xml;
		}

		/// <summary>
		/// Returns the comment type.
		/// </summary>
		public CommentType Type { get { return this.type; } }

		/// <summary>
		/// Returns the GUID.
		/// </summary>
		public Guid Guid { get { return this.guid; } }

		/// <summary>
		/// Returns the comment time.
		/// </summary>
		public DateTime Time { get { return this.time; } }

		/// <summary>
		/// Returns the comment user.
		/// </summary>
		public string User { get { return this.user; } }

		/// <summary>
		/// Returns the comment item.
		/// </summary>
		public string Item { get { return this.item; } }

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
