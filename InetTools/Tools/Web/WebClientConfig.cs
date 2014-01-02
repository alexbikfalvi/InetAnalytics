/* 
 * Copyright (C) 2013-2014 Alex Bikfalvi
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
using System.Net;
using System.Security;
using System.Text;
using System.Xml.Linq;
using DotNetApi;
using DotNetApi.IO;
using DotNetApi.Security;
using DotNetApi.Windows;
using InetCrawler.Tools;

namespace InetTools.Tools.Web
{
	/// <summary>
	/// A class representing the configuration for the web client tool.
	/// </summary>
	public sealed class WebClientConfig
	{
		private readonly IToolApi api;

		private readonly Dictionary<string, string> headers = new Dictionary<string, string>();
		private static readonly char[] headerSeparator = { ':' };

		private static readonly byte[] cryptoKey = { 0xE8, 0xE2, 0x3A, 0x45, 0x7D, 0x70, 0xB3, 0x82, 0x8C, 0x71, 0x57, 0xFE, 0x88, 0x84, 0xE9, 0x8D, 0xE0, 0xF3, 0x7F, 0x2A, 0x78, 0x8D, 0xE2, 0x4E, 0x82, 0xC0, 0x4D, 0x89, 0xC6, 0x76, 0x33, 0xDF };
		private static readonly byte[] cryptoIV = { 0xC7, 0x2B, 0xBA, 0x24, 0x1A, 0x83, 0xC8, 0xF6, 0x3B, 0x1B, 0x71, 0x37, 0x4C, 0x8A, 0x8F, 0x2B };

		/// <summary>
		/// Creates a new web client configuration instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		public WebClientConfig(IToolApi api)
		{
			this.api = api;
		}

		// Public properties.

		/// <summary>
		/// Gets the tool API.
		/// </summary>
		public IToolApi Api { get { return this.api; } }

		/// <summary>
		/// Gets or sets the value of the specified HTTP request header.
		/// </summary>
		/// <param name="header">The HTTP request header.</param>
		/// <returns>The header value.</returns>
		public string this[string header]
		{
			get { return this.headers[header]; }
			set { this.headers[header] = value; }
		}

		/// <summary>
		/// Gets or sets the web request URL.
		/// </summary>
		public string Url
		{
			get { return this.api.Key.GetString("Url", string.Empty); }
			set { this.api.Key.SetString("Url", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the web request method.
		/// </summary>
		public string Method
		{
			get { return this.api.Key.GetString("Method", "GET"); }
			set { this.api.Key.SetString("Method", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the web request data.
		/// </summary>
		public string Data
		{
			get { return this.api.Key.GetString("Data", string.Empty); }
			set { this.api.Key.SetString("Data", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the codepage used for the data encoding.
		/// </summary>
		public int DataEncoding
		{
			get { return this.api.Key.GetInteger("DataEncoding", 65001); }
			set { this.api.Key.SetInteger("DataEncoding", value); }
		}

		/// <summary>
		/// Gets or sets whether the Accept header is checked.
		/// </summary>
		public bool AcceptHeaderChecked
		{
			get { return this.api.Key.GetBoolean("AcceptHeaderChecked", false); }
			set { this.api.Key.SetBoolean("AcceptHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets whether the Content-Type header is checked.
		/// </summary>
		public bool ContentTypeHeaderChecked
		{
			get { return this.api.Key.GetBoolean("ContentTypeHeaderChecked", false); }
			set { this.api.Key.SetBoolean("ContentTypeHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets whether the Date header is checked.
		/// </summary>
		public bool DateHeaderChecked
		{
			get { return this.api.Key.GetBoolean("DateHeaderChecked", false); }
			set { this.api.Key.SetBoolean("DateHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets whether the Expect header is checked.
		/// </summary>
		public bool ExpectHeaderChecked
		{
			get { return this.api.Key.GetBoolean("ExpectHeaderChecked", false); }
			set { this.api.Key.SetBoolean("ExpectHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets whether the Referer header is checked.
		/// </summary>
		public bool RefererHeaderChecked
		{
			get { return this.api.Key.GetBoolean("RefererHeaderChecked", false); }
			set { this.api.Key.SetBoolean("RefererHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets whether the User-Agent header is checked.
		/// </summary>
		public bool UserAgentHeaderChecked
		{
			get { return this.api.Key.GetBoolean("UserAgentHeaderChecked", false); }
			set { this.api.Key.SetBoolean("UserAgentHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets the Accept header value.
		/// </summary>
		public string AcceptHeaderValue
		{
			get { return this.api.Key.GetString("AcceptHeaderValue", string.Empty); }
			set { this.api.Key.SetString("AcceptHeaderValue", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the Content-Type header value.
		/// </summary>
		public string ContentTypeHeaderValue
		{
			get { return this.api.Key.GetString("ContentTypeHeaderValue", string.Empty); }
			set { this.api.Key.SetString("ContentTypeHeaderValue", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the Date header value.
		/// </summary>
		public DateTime DateHeaderValue
		{
			get { return this.api.Key.GetDateTime("DateHeaderValue", DateTime.Now); }
			set { this.api.Key.SetDateTime("DateHeaderValue", value); }
		}

		/// <summary>
		/// Gets or sets the Expect header value.
		/// </summary>
		public string ExpectHeaderValue
		{
			get { return this.api.Key.GetString("ExpectHeaderValue", string.Empty); }
			set { this.api.Key.SetString("ExpectHeaderValue", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the Referer header value.
		/// </summary>
		public string RefererHeaderValue
		{
			get { return this.api.Key.GetString("RefererHeaderValue", string.Empty); }
			set { this.api.Key.SetString("RefererHeaderValue", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the User-Agent header value.
		/// </summary>
		public string UserAgentHeaderValue
		{
			get { return this.api.Key.GetString("UserAgentHeaderValue", string.Empty); }
			set { this.api.Key.SetString("UserAgentHeaderValue", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets the collection of HTTP request headers.
		/// </summary>
		public ICollection<KeyValuePair<string, string>> Headers
		{
			get { return this.headers; }
		}

		// Public methods.

		/// <summary>
		/// Loads the request headers from the registry.
		/// </summary>
		public void LoadHeaders()
		{
			// Clear the headers.
			this.headers.Clear();
			try
			{
				// Read the headers string from the registry.
				string[] list = this.api.Key.GetMultiString("Headers", null);
				// If the list of headers is not null.
				if (null != list)
				{
					// Add the headers to the headers list.
					foreach (string header in list)
					{
						// Split the header string into tokens using the column separator.
						string[] tokens = header.Split(WebClientConfig.headerSeparator, 2);
						// If the number of tokens is not two, continue to the next header.
						if (tokens.Length != 2) continue;
						// Check whether the header is restricted.
						if (!WebHeaderCollection.IsRestricted(tokens[0]))
						{
							// Add the header to the headers list.
							this.headers.Add(tokens[0], tokens[1]);
						}
					}
				}
			}
			catch (Exception) { }
		}

		/// <summary>
		/// Saves the request headers to the registry.
		/// </summary>
		public void SaveHeaders()
		{
			// Create a string array to save the headers.
			string[] list = new string[this.headers.Count];
			// Add all headers, by index to the string builder with the equivalent value.
			int index = 0;
			foreach (KeyValuePair<string, string> header in this.headers)
			{
				list[index++] = "{0}:{1}".FormatWith(header.Key, header.Value);
			}
			// Write the headers string builder to the registry.
			this.api.Key.SetMultiString("Headers", list);
		}

		/// <summary>
		/// Checks whether the specified HTTP request header exists in the current collection.
		/// </summary>
		/// <param name="header">The header.</param>
		/// <returns><b>True</b> if the specified header exists, <b>false</b> otherwise.</returns>
		public bool HasHeader(string header)
		{
			return this.headers.ContainsKey(header);
		}

		/// <summary>
		/// Adds the specified HTTP request header and value to the headers collection.
		/// </summary>
		/// <param name="header">The HTTP request header.</param>
		/// <param name="value">The header value.</param>
		/// <returns><b>True</b> if the header was added successfully, <b>false</b> otherwise.</returns>
		public bool AddHeader(string header, string value)
		{
			// Check whether the header is restricted.
			if (!WebHeaderCollection.IsRestricted(header))
			{
				this.headers.Add(header, value);
				return true;
			}
			else return false;
		}

		/// <summary>
		/// Removes the specified HTTP request header from the headers collection.
		/// </summary>
		/// <param name="header">The HTTP request header.</param>
		public void RemoveHeader(string header)
		{
			this.headers.Remove(header);
		}

		/// <summary>
		/// Changes the specified HTTP header value to the specified value. If the header does not exist,
		/// the method does nothing.
		/// </summary>
		/// <param name="header">The HTTP request header.</param>
		/// <param name="value">The new header value.</param>
		/// <returns><b>True</b> if the header was changed successfully, <b>false</b> otherwise.</returns>
		public bool ChangeHeader(string header, string value)
		{
			// If the header does not exist, do nothing.
			if (!this.headers.ContainsKey(header)) return false;
			// Check whether the header is restricted.
			if (!WebHeaderCollection.IsRestricted(header))
			{
				this.headers[header] = value;
				return true;
			}
			else return false;
		}

		/// <summary>
		/// Saves the current configuration to the specified XML file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public void SaveToFile(string fileName)
		{
			// Create the XML document.
			XDocument document = new XDocument(
				new XElement("testing-web-request",
					new XElement("url", this.Url),
					new XElement("method", this.Method),
					new XElement("data", this.EncodeToBase64(this.Data)),
					new XElement("data-encoding", this.DataEncoding.ToString(CultureInfo.InvariantCulture)),
					new XElement("headers",
						new XElement("system-headers",
							new XElement("accept",
								new XAttribute("checked", this.AcceptHeaderChecked),
								this.EncodeToBase64(this.AcceptHeaderValue)),
							new XElement("content-type",
								new XAttribute("checked", this.ContentTypeHeaderChecked),
								this.EncodeToBase64(this.ContentTypeHeaderValue)),
							new XElement("date",
								new XAttribute("checked", this.DateHeaderChecked),
								this.DateHeaderValue.ToString(CultureInfo.InvariantCulture)),
							new XElement("expect",
								new XAttribute("checked", this.ExpectHeaderChecked),
								this.EncodeToBase64(this.ExpectHeaderValue)),
							new XElement("referer",
								new XAttribute("checked", this.RefererHeaderChecked),
								this.EncodeToBase64(this.RefererHeaderValue)),
							new XElement("user-agent",
								new XAttribute("checked", this.UserAgentHeaderChecked),
								this.EncodeToBase64(this.UserAgentHeaderValue))),
							new XElement("custom-headers",
								from header in this.Headers select new XElement("header",
									new XAttribute("name", header.Key), this.EncodeToBase64(header.Value))
								))));

			// Check the file directory exists.
			if (Directory.EnsureFileDirectoryExists(fileName))
			{
				// Save the XML document to a file.
				document.Save(fileName);
			}
		}

		/// <summary>
		/// Loads the current configuration from the specified XML file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public void LoadFromFile(string fileName)
		{
			// Read the XML document from the specified file.
			XDocument document = XDocument.Load(fileName);
			// Get the root element of the XML document.
			XElement root = document.Root;
			// Check the root of the XML file.
			if (root.Name != "testing-web-request") throw new ToolException("Invalid settings file.");

			// Load the configuration.
			this.Url = root.Element("url").Value;
			this.Method = root.Element("method").Value;
			this.Data = this.DecodeFromBase64(root.Element("data").Value);
			this.DataEncoding = int.Parse(root.Element("data-encoding").Value, CultureInfo.InvariantCulture);

			// Get the system headers element.
			XElement systemHeaders = root.Element("headers").Element("system-headers");

			this.AcceptHeaderChecked = bool.Parse(systemHeaders.Element("accept").Attribute("checked").Value);
			this.ContentTypeHeaderChecked = bool.Parse(systemHeaders.Element("content-type").Attribute("checked").Value);
			this.DateHeaderChecked = bool.Parse(systemHeaders.Element("date").Attribute("checked").Value);
			this.ExpectHeaderChecked = bool.Parse(systemHeaders.Element("expect").Attribute("checked").Value);
			this.RefererHeaderChecked = bool.Parse(systemHeaders.Element("referer").Attribute("checked").Value);
			this.UserAgentHeaderChecked = bool.Parse(systemHeaders.Element("user-agent").Attribute("checked").Value);

			this.AcceptHeaderValue = this.DecodeFromBase64(systemHeaders.Element("accept").Value);
			this.ContentTypeHeaderValue = this.DecodeFromBase64(systemHeaders.Element("content-type").Value);
			this.DateHeaderValue = DateTime.Parse(systemHeaders.Element("date").Value, CultureInfo.InvariantCulture);
			this.ExpectHeaderValue = this.DecodeFromBase64(systemHeaders.Element("expect").Value);
			this.RefererHeaderValue = this.DecodeFromBase64(systemHeaders.Element("referer").Value);
			this.UserAgentHeaderValue = this.DecodeFromBase64(systemHeaders.Element("user-agent").Value);

			// Get the custom headers element.
			XElement customHeaders = root.Element("headers").Element("custom-headers");

			// Clear the headers.
			this.headers.Clear();
			foreach (XElement element in customHeaders.Elements("header"))
			{
				// Get the element name  attribute.
				string name = element.Attribute("name").Value;
				// Get the element header attribute.
				string value = this.DecodeFromBase64(element.Value);
				// Add the header to the headers collection.
				this.headers.Add(name, value);
			}
		}

		// Private methods.

		/// <summary>
		/// Encodes the specified string as a Base64 string.
		/// </summary>
		/// <param name="data">The string to encode.</param>
		/// <returns>The Base64 encoded string.</returns>
		private string EncodeToBase64(string data)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
		}

		/// <summary>
		/// Decodes the specified Base64 string.
		/// </summary>
		/// <param name="data">The Base64 string to decode.</param>
		/// <returns>The decoded string.</returns>
		private string DecodeFromBase64(string data)
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String(data));
		}
	}
}
