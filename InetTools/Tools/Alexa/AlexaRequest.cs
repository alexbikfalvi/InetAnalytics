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

namespace InetTools.Tools.Alexa
{
	/// <summary>
	/// A class representing a web request to the Alexa web request.
	/// </summary>
	public sealed class AlexaRequest : AsyncWebRequest
	{
		private static readonly Uri urlCountries = new Uri("http://www.alexa.com/topsites/countries");

		/// <summary>
		/// Creates a new Alexa web request instance.
		/// </summary>
		public AlexaRequest()
		{
		}

		// Public methods.

		/// <summary>
		/// Begins an asynchronous request for Alexa countries.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="countries">The list of countries.</param>
		/// <param name="userState">The user state.</param>
		public IAsyncResult BeginGetCountries(AsyncWebRequestCallback callback, AlexaCountries countries = null, object userState = null)
		{
			// Create the request state.
			AlexaCountriesRequestState asyncState = new AlexaCountriesRequestState(callback, countries, userState);
			
			// Call the internal request method.
			this.BeginGetCountriesInternal(asyncState);

			// Return the request state.
			return asyncState;
		}

		/// <summary>
		/// Ends an asynchronous request for Alexa countries.
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		public AlexaCountries EndGetCountries(IAsyncResult result)
		{

		}

		public void BeginGetRanking()
		{

		}

		public AlexaTopSitesRanking EndGetRanking(IAsyncResult result)
		{

		}

		/// <summary>
		/// Cancels the specified asynchronous request.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		public void Cancel(IAsyncResult result)
		{
			// Get the Alexa request state.
			AlexaRequestState asyncState = result as AlexaRequestState;
			// If the asyncronous result is not an Alexa request state, do nothing.
			if (null == asyncState) return;
			// Else, call the base class cancel method with the internal state.
			base.Cancel(asyncState.Result);
		}

		// Private methods.

		/// <summary>
		/// Begins an asynchronous request for the Alexa countries.
		/// </summary>
		/// <param name="asyncState">The asynchronous state.</param>
		private void BeginGetCountriesInternal(AlexaCountriesRequestState asyncState)
		{
			// Begin an asynchronous request for the Alexa countries.
			asyncState.Result = base.Begin(AlexaRequest.urlCountries, (AsyncWebResult asyncResult) =>
				{
					try
					{
						// The request data.
						string data;
						// Complete the request.
						AsyncWebResult result = base.End(asyncResult, out data);
						// Parse the list of countries.
						asyncState.Countries.Parse(data);
					}
					catch (Exception exception)
					{
						// Set the exception.
						asyncState.Exception = exception;
					}
					finally
					{
						// Complete the request.
						asyncState.Complete();
						// Call the callback method.
						if (null != asyncState.Callback) asyncState.Callback()
					}
				}, asyncState);
		}
	}
}
