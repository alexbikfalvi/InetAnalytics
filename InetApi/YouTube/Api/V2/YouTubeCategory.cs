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

namespace InetApi.YouTube.Api.V2
{
	/// <summary>
	/// A class representing a YouTube category.
	/// </summary>
	public sealed class YouTubeCategory
	{
		private string term;
		private string label;

		private bool assignable;
		private bool deprecated;

		private string[] browsable;

		/// <summary>
		/// Creates a YouTube category instance.
		/// </summary>
		/// <param name="term">Term.</param>
		/// <param name="label">Label.</param>
		/// <param name="assignable">Is assignable.</param>
		/// <param name="deprecated">Is deprecated.</param>
		/// <param name="browsable">Browsable regions.</param>
		public YouTubeCategory(
			string term,
			string label,
			bool assignable,
			bool deprecated,
			string[] browsable
			)
		{
			this.term = term;
			this.label = label;
			this.assignable = assignable;
			this.deprecated = deprecated;
			this.browsable = browsable;
		}

		// Public properties.

		/// <summary>
		/// The category term.
		/// </summary>
		public string Term { get { return this.term; } }
		/// <summary>
		/// The category label.
		/// </summary>
		public string Label { get { return this.label; } }
		/// <summary>
		/// Indicates if the category is assignable.
		/// </summary>
		public bool IsAssignable { get { return this.assignable; } }
		/// <summary>
		/// Indicates if the category is deprecated.
		/// </summary>
		public bool IsDeprecated { get { return this.deprecated; } }
		/// <summary>
		/// The set of browsable regions. It can be null if the category is not browsable.
		/// </summary>
		public string[] Browsable { get { return this.browsable; } }

		// Public methods.

		/// <summary>
		/// Parses the argument XML element into a YouTube category.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="xmlnsYt">The XML YouTube namespace.</param>
		/// <returns>A YouTube category.</returns>
		public static YouTubeCategory Parse(XElement element, string xmlnsYt)
		{
			XElement el;
			return new YouTubeCategory(
				element.Attribute(XName.Get("term")).Value,
				element.Attribute(XName.Get("label")).Value,
				element.Element(XName.Get("assignable", xmlnsYt)) != null,
				element.Element(XName.Get("deprecated", xmlnsYt)) != null,
				(el = element.Element(XName.Get("browsable", xmlnsYt))) != null
				? el.Attribute(XName.Get("regions")).Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				: null
				);
		}
	}
}
