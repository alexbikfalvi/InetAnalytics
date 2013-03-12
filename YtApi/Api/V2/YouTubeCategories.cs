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
using DotNetApi.Web;

namespace YtApi.Api.V2
{
	/// <summary>
	/// A set of YouTube categories.
	/// </summary>
	public sealed class YouTubeCategories
	{
		private List<YouTubeCategory> categories = new List<YouTubeCategory>();
		private YouTubeRequest request = new YouTubeRequest(null);

		private object state = null;
		private AsyncWebRequestCallback callback = null;

		private XDocument xml = null;

		private string xmlnsApp = null;
		private string xmlnsAtom = null;
		private string xmlnsYt = null;

		private string[] categoryLabels = new string[0];

		/// <summary>
		/// Creates an empty list of YouTube categories.
		/// </summary>
		public YouTubeCategories() { }

		/// <summary>
		/// Begins an asynchronous refresh operation.
		/// </summary>
		/// <param name="callback">The callback function.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public IAsyncResult BeginRefresh(AsyncWebRequestCallback callback, object state)
		{
			if(null == this.callback)
			{
				// Save the callback function and the user state.
				this.callback = callback;
				this.state = state;
				// Begin the request.
				return this.request.Begin(YouTubeUri.UriCategories, this.Callback);
			}
			else
			{
				throw new YouTubeException("Cannot begin a new refresh request, until a previous one completes.");
			}
		}

		/// <summary>
		/// Callback function to an asynchronous refresh request.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		private void Callback(IAsyncResult result)
		{
			object state;

			// Get the asynchronous result.
			AsyncWebResult asyncResult = result as AsyncWebResult;

			// If no exception was thrown, complete the request
			if (null == asyncResult.Exception)
			{
				try
				{
					// Parse the string data.
					this.Parse(this.request.End(result, out state));
				}
				catch (Exception exception)
				{
					asyncResult.Exception = exception;
				}
			}

			// Call the callback function
			if (this.callback != null)
			{
				this.callback(asyncResult);
			}

			// Reset the callback and state
			this.callback = null;
			this.state = null;
		}

		/// <summary>
		/// Completes an asynchronous refresh operation.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <returns>The user state.</returns>
		public object EndRefresh(IAsyncResult result)
		{
			// Get the asynchronous result.
			AsyncWebResult asyncResult = result as AsyncWebResult;

			// If an exception was thrown during the asynchronous operation.
			if (null != asyncResult.Exception)
			{
				// Rethrow the exception.
				throw asyncResult.Exception;
			}

			// Return the user state
			return asyncResult.AsyncState;
		}

		/// <summary>
		/// Create a list of categories based on XML data.
		/// </summary>
		/// <param name="data">The XML data.</param>
		public void Parse(string data)
		{
			// Parse the XML data, and create the XML document.
			this.xml = XDocument.Parse(data);

			// Get the XML namespaces
			this.xmlnsApp = this.xml.Root.Attribute(XName.Get("app", XNamespace.Xmlns.NamespaceName)).Value;
			this.xmlnsAtom = this.xml.Root.Attribute(XName.Get("atom", XNamespace.Xmlns.NamespaceName)).Value;
			this.xmlnsYt = this.xml.Root.Attribute(XName.Get("yt", XNamespace.Xmlns.NamespaceName)).Value;

			// Check the root element name
			if ((this.xml.Root.Name.LocalName != "categories") || (this.xml.Root.Name.NamespaceName != this.xmlnsApp))
				throw new YouTubeException("Invalid categories XML file");

			// Parse the categories
			this.categories.Clear();
			foreach (XElement element in this.xml.Root.Elements(XName.Get("category", this.xmlnsAtom)))
			{
				this.ParseCategory(element);
			}

			// Create the list of category labels.
			this.categoryLabels = new string[this.categories.Count];
			for (int index = 0; index < this.categories.Count; index++)
				this.categoryLabels[index] = this.categories[index].Label;
		}

		private void ParseCategory(XElement element)
		{
			XElement el;

			this.categories.Add(new YouTubeCategory(
				element.Attribute(XName.Get("term")).Value,
				element.Attribute(XName.Get("label")).Value,
				element.Element(XName.Get("assignable", this.xmlnsYt)) != null,
				element.Element(XName.Get("deprecated", this.xmlnsYt)) != null,
				(el = element.Element(XName.Get("browsable", this.xmlnsYt))) != null
				? el.Attribute(XName.Get("regions")).Value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				: null
				));
		}

		/// <summary>
		/// Returns the number of categories.
		/// </summary>
		public int Count { get { return this.categories.Count; } }

		/// <summary>
		/// Returns the category at a specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>The YouTube category.</returns>
		public YouTubeCategory this[int index] { get { return this.categories[index]; } }

		/// <summary>
		/// Returns the category at a specified label.
		/// </summary>
		/// <param name="label">The label.</param>
		/// <returns>The YouTube category.</returns>
		public YouTubeCategory this[string label] { get { return this.categories[Array.IndexOf(this.categoryLabels, label)]; } }

		/// <summary>
		/// Returns the list of category labels.
		/// </summary>
		public string[] CategoryLabels { get { return this.categoryLabels; } }
	}
}
