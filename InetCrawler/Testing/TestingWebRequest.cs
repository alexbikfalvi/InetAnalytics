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
using System.Net;
using System.Text;
using System.Xml.Linq;
using DotNetApi;
using DotNetApi.IO;
using DotNetApi.Windows;

namespace InetCrawler.Testing
{
	/// <summary>
	/// A class that stores the testing web request parameters.
	/// </summary>
	public sealed class TestingWebRequest
	{
		private string key;
		private readonly Dictionary<string, string> headers = new Dictionary<string, string>();
		private static readonly char[] headerSeparator = { ':' };

		/// <summary>
		/// Creates a new testing web request instance.
		/// </summary>
		/// <param name="key">The registry key.</param>
		public TestingWebRequest(string key)
		{
			// Set the registry key.
			this.key = key;
		}

		// Public properties.

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
			get { return Registry.GetString(this.key, "Url", string.Empty); }
			set { Registry.SetString(this.key, "Url", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the web request method.
		/// </summary>
		public string Method
		{
			get { return Registry.GetString(this.key, "Method", "GET"); }
			set { Registry.SetString(this.key, "Method", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the web request data.
		/// </summary>
		public string Data
		{
			get { return Registry.GetString(this.key, "Data", string.Empty); }
			set { Registry.SetString(this.key, "Data", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the codepage used for the data encoding.
		/// </summary>
		public int DataEncoding
		{
			get { return Registry.GetInteger(this.key, "DataEncoding", 65001); }
			set { Registry.SetInteger(this.key, "DataEncoding", value); }
		}

		/// <summary>
		/// Gets or sets whether the Accept header is checked.
		/// </summary>
		public bool AcceptHeaderChecked
		{
			get { return Registry.GetBoolean(this.key, "AcceptHeaderChecked", false); }
			set { Registry.SetBoolean(this.key, "AcceptHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets whether the Content-Type header is checked.
		/// </summary>
		public bool ContentTypeHeaderChecked
		{
			get { return Registry.GetBoolean(this.key, "ContentTypeHeaderChecked", false); }
			set { Registry.SetBoolean(this.key, "ContentTypeHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets whether the Date header is checked.
		/// </summary>
		public bool DateHeaderChecked
		{
			get { return Registry.GetBoolean(this.key, "DateHeaderChecked", false); }
			set { Registry.SetBoolean(this.key, "DateHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets whether the Expect header is checked.
		/// </summary>
		public bool ExpectHeaderChecked
		{
			get { return Registry.GetBoolean(this.key, "ExpectHeaderChecked", false); }
			set { Registry.SetBoolean(this.key, "ExpectHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets whether the Referer header is checked.
		/// </summary>
		public bool RefererHeaderChecked
		{
			get { return Registry.GetBoolean(this.key, "RefererHeaderChecked", false); }
			set { Registry.SetBoolean(this.key, "RefererHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets whether the User-Agent header is checked.
		/// </summary>
		public bool UserAgentHeaderChecked
		{
			get { return Registry.GetBoolean(this.key, "UserAgentHeaderChecked", false); }
			set { Registry.SetBoolean(this.key, "UserAgentHeaderChecked", value); }
		}

		/// <summary>
		/// Gets or sets the Accept header value.
		/// </summary>
		public string AcceptHeaderValue
		{
			get { return Registry.GetString(this.key, "AcceptHeaderValue", string.Empty); }
			set { Registry.SetString(this.key, "AcceptHeaderValue", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the Content-Type header value.
		/// </summary>
		public string ContentTypeHeaderValue
		{
			get { return Registry.GetString(this.key, "ContentTypeHeaderValue", string.Empty); }
			set { Registry.SetString(this.key, "ContentTypeHeaderValue", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the Date header value.
		/// </summary>
		public DateTime DateHeaderValue
		{
			get { return Registry.GetDateTime(this.key, "DateHeaderValue", DateTime.Now); }
			set { Registry.SetDateTime(this.key, "DateHeaderValue", value); }
		}

		/// <summary>
		/// Gets or sets the Expect header value.
		/// </summary>
		public string ExpectHeaderValue
		{
			get { return Registry.GetString(this.key, "ExpectHeaderValue", string.Empty); }
			set { Registry.SetString(this.key, "ExpectHeaderValue", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the Referer header value.
		/// </summary>
		public string RefererHeaderValue
		{
			get { return Registry.GetString(this.key, "RefererHeaderValue", string.Empty); }
			set { Registry.SetString(this.key, "RefererHeaderValue", value != null ? value : string.Empty); }
		}

		/// <summary>
		/// Gets or sets the User-Agent header value.
		/// </summary>
		public string UserAgentHeaderValue
		{
			get { return Registry.GetString(this.key, "UserAgentHeaderValue", string.Empty); }
			set { Registry.SetString(this.key, "UserAgentHeaderValue", value != null ? value : string.Empty); }
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
				string[] list = Registry.GetMultiString(this.key, "Headers", null);
				// If the list of headers is not null.
				if (null != list)
				{
					// Add the headers to the headers list.
					foreach (string header in list)
					{
						// Split the header string into tokens using the column separator.
						string[] tokens = header.Split(TestingWebRequest.headerSeparator, 2);
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
			Registry.SetMultiString(this.key, "Headers", list);
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
			// Create the XML headers element.
			XElement headers = new XElement("custom-headers");
			foreach (KeyValuePair<string, string> header in this.Headers)
			{
				headers.Add(new XElement("header", new XAttribute("name", header.Key), this.EncodeToBase64(header.Value)));
			}

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
						headers)));

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
			if (root.Name != "testing-web-request") throw new CrawlerException("Invalid settings file");
			
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
