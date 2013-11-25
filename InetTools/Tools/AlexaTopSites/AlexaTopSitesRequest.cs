/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using DotNetApi.Web;

namespace InetTools.Tools.AlexaTopSites
{
	/// <summary>
	/// A class representing a web request to the Alexa web request.
	/// </summary>
	public sealed class AlexaTopSitesRequest
	{
		private readonly AsyncWebRequest request = new AsyncWebRequest();
		private readonly object sync = new object();
		private IAsyncResult result = null;

		/// <summary>
		/// Creates a new Alexa web request instance.
		/// </summary>
		public AlexaTopSitesRequest()
		{
		}

		// Public methods.

		/// <summary>
		/// Cancels the current request.
		/// </summary>
		public void Cancel()
		{
			lock (this.sync)
			{
				if (null != this.result) this.request.Cancel(this.result);
			}
		}

		public void BeginGetCountries()
		{

		}

		public AlexaTopSitesCountries EndGetCountries(IAsyncResult result)
		{

		}

		public void BeginGetRanking()
		{

		}

		public AlexaTopSitesRanking EndGetRanking(IAsyncResult result)
		{

		}
	}
}
