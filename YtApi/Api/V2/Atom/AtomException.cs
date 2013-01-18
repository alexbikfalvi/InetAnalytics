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
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YtApi.Api.V2.Atom
{
	/// <summary>
	/// A class representing an atom exception.
	/// </summary>
	[Serializable]
	public class AtomException : Exception, ISerializable
	{
		private string xml;
 		private XmlNamespace ns;

		/// <summary>
		/// Creates a new atom exception instance.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <param name="xml">The XML element that cannot be parsed.</param>
		/// <param name="ns">The XML namespace.</param>
		/// <param name="innerException">The inner exception.</param>
		public AtomException(string message, XElement xml, XmlNamespace ns, Exception innerException)
			: base(message, innerException)
		{
			this.xml = xml.ToString(SaveOptions.None);
			this.ns = ns;
		}

		/// <summary>
		/// Creates a new atom exception instance during the deserialization.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="ctx">The streaming context.</param>
		protected AtomException(SerializationInfo info, StreamingContext ctx)
			: base(info, ctx)
		{
			this.xml = info.GetValue("xml", typeof(string)) as string;
			this.ns = info.GetValue("ns", typeof(XmlNamespace)) as XmlNamespace;
		}

		/// <summary>
		/// Returns the object data during serialization.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("xml", this.xml);
			info.AddValue("ns", this.ns);
			base.GetObjectData(info, context);
		}

		/// <summary>
		/// Gets the XML string that generated the exception.
		/// </summary>
		public string Xml { get { return this.xml; } }

		/// <summary>
		/// Gets the XML namespace.
		/// </summary>
		public XmlNamespace Namespace { get { return this.ns; } }
	}
}
