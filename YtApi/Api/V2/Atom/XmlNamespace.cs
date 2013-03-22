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
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace YtApi.Api.V2.Atom
{
	/// <summary>
	/// A class representing the current XML namespaces.
	/// </summary>
	[Serializable]
	public class XmlNamespace : ISerializable
	{
		private XmlNamespace top = null;
		private Dictionary<string, string> ns = new Dictionary<string, string>();

		/// <summary>
		/// Creates a new namespace set.
		/// </summary>
		/// <param name="root">The current root element.</param>
		/// <param name="top">The top namespace set.</param>
		public XmlNamespace(XElement root, XmlNamespace top = null)
		{
			// Save the top namespace.
			this.top = top;
			// Add the default namespace.
			//this.ns.Add("xmlns", XNamespace.Xmlns.NamespaceName);
			// Add all attributes that have the XMLNS namespace.
			foreach (XAttribute attr in root.Attributes())
			{
				if (attr.Name.LocalName == "xmlns")
					this.ns.Add("xmlns", attr.Value);
				if (attr.Name.NamespaceName == XNamespace.Xmlns.NamespaceName)
					this.ns.Add(attr.Name.LocalName, attr.Value);
			}
		}

		/// <summary>
		/// Creates a new XML namespace instance during the deserialization.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="ctx">The streaming context.</param>
		public XmlNamespace(SerializationInfo info, StreamingContext ctx)
		{
			this.top = info.GetValue("top", typeof(XmlNamespace)) as XmlNamespace;
			this.ns = info.GetValue("ns", typeof(Dictionary<string, string>)) as Dictionary<string, string>;
		}

		/// <summary>
		/// Returns the object data during serialization.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("top", this.top);
			info.AddValue("ns", this.ns);
		}

		/// <summary>
		/// Gets the namespace name for a given namespace local name.
		/// </summary>
		/// <param name="ns">The namespace local name.</param>
		/// <returns>The namespace name.</returns>
		public string this[string ns]
		{
			get
			{
				string name;
				// Try and get the namespace name from the local set.
				if (this.ns.TryGetValue(ns, out name)) return name;
				// Else, if the top set is not null, get the name from the top set.
				if (null != this.top) return this.top[ns];
				// Else, return an empty namespace.
				return string.Empty;
			}
		}

		/// <summary>
		/// Returns the top namespace object.
		/// </summary>
		public XmlNamespace Top { get { return this.top; } }

		/// <summary>
		/// Returns the collection of namespace entries.
		/// </summary>
		public ICollection<KeyValuePair<string, string>> Entries { get { return this.ns; } }
	}
}
