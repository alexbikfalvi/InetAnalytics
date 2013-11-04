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

namespace InetApi.YouTube.Ajax
{
	public class AjaxRequest : AsyncWebRequest
	{
		/// <summary>
		/// Conversion class for an asynchronous operation returning an XML document.
		/// </summary>
		public class AjaxRequestFunction : IAsyncFunction<XDocument>
		{
			/// <summary>
			/// Returns an XML document for the received asynchronous data.
			/// </summary>
			/// <param name="data">The data string.</param>
			/// <returns>The generated XML document.</returns>
			public XDocument GetResult(string data)
			{
				return XDocument.Parse(data);
			}
		}

		private AjaxRequestFunction func = new AjaxRequestFunction();

		/// <summary>
		/// Completes the asynchronous operation and returns the received data as an XML document.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <returns>An XML document representing the data received during the asynchronous operation.</returns>
		public new XDocument End(IAsyncResult result)
		{
			// Get the asynchronous result.
			AsyncWebResult asyncResult = (AsyncWebResult)result;

			// Get the asynchronous state.
			AsyncWebResult asyncState = (AsyncWebResult)asyncResult.AsyncState;

			// Determine the encoding of the received response.
			return this.End<XDocument>(result, this.func);
		}
	}
}
