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
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace YtApi.Ajax
{
	/// <summary>
	/// A class that represents an AJAX exception.
	/// </summary>
	[Serializable]
	public class AjaxParsingException : AjaxException, ISerializable
	{
		private string html;

		/// <summary>
		/// Creates a new exception instance using the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="html">The HTML code that generated the exception.</param>
		public AjaxParsingException(string message, string html)
			: base(message)
		{
			this.html = html;
		}

		/// <summary>
		/// Creates a new exception instance using the specified message and inner exception.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		/// <param name="html">The HTML code that generated the exception.</param>
		public AjaxParsingException(string message, Exception innerException, string html)
			: base(message, innerException)
		{
			this.html = html;
		}

		/// <summary>
		/// Creates a new AJAX exception instance during the deserialization.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="ctx">The streaming context.</param>
		protected AjaxParsingException(SerializationInfo info, StreamingContext ctx)
			: base(info, ctx)
		{
			this.html = info.GetString("html");
		}

		/// <summary>
		/// Returns the object data during serialization.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("html", this.html);
			base.GetObjectData(info, context);
		}

		/// <summary>
		/// Returns the HTML code that generated the exception.
		/// </summary>
		public string Html { get { return this.html; } }
	}
}
