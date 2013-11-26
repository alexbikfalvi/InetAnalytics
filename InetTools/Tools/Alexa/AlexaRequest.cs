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
using DotNetApi;
using DotNetApi.Web;

namespace InetTools.Tools.Alexa
{
	/// <summary>
	/// A class representing a web request to the Alexa web request.
	/// </summary>
	public sealed class AlexaRequest : AsyncWebRequest
	{
		private delegate void AlexaRankingAction(AlexaRankingRequestState asyncState, out Uri uri, out AlexaCountry country);

		private static readonly Uri urlCountries = new Uri("http://www.alexa.com/topsites/countries");
		private static readonly string urlRankingGlobal = "http://www.alexa.com/topsites/global;{0}";
		private static readonly string urlRankingCountry = "http://www.alexa.com/topsites/countries;{0}/{1}";

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
		public IAsyncResult BeginGetCountries(AsyncCallback callback, AlexaCountries countries = null, object userState = null)
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
		/// <param name="result">The result of the asynchronous operation.</param>
		/// <returns>The list of Alexa countries.</returns>
		public AlexaCountries EndGetCountries(IAsyncResult result)
		{
			// Get the asynchronous state.
			AlexaCountriesRequestState asyncState = result as AlexaCountriesRequestState;
			
			// If the request state is null, throw an exception.
			if (null == asyncState) throw new InvalidOperationException("Cannot end the asynchronous operation because the asynchronous result does not match the request.");

			// If the operation has an exception, throw the exception.
			if (null != asyncState.Exception)
			{
				throw asyncState.Exception;
			}

			// Else, return the result.
			return asyncState.Countries;
		}

		/// <summary>
		/// Begins an asynchronous request for the global Alexa ranking.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="pages">The number of pages to return.</param>
		/// <param name="ranking">The ranking list.</param>
		/// <param name="userState">The user state.</param>
		public IAsyncResult BeginGetGlobalRanking(AsyncCallback callback, int pages, AlexaRanking ranking = null, object userState = null)
		{
			// Create the request state.
			AlexaRankingRequestState asyncState = new AlexaRankingRequestState(callback, pages, ranking, userState);

			// Call the internal request method.
			this.BeginGetRankingInternal(asyncState, this.GetUriGlobalRanking);

			// Return the request state.
			return asyncState;
		}

		/// <summary>
		/// Begins an asynchronous request for the country-specific Alexa ranking.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="country">The country.</param>
		/// <param name="pages">The number of pages to return.</param>
		/// <param name="ranking">The ranking list.</param>
		/// <param name="userState">The user state.</param>
		public IAsyncResult BeginGetCountryRanking(AsyncCallback callback, AlexaCountry country, int pages, AlexaRanking ranking = null, object userState = null)
		{
			// Create the request state.
			AlexaRankingRequestState asyncState = new AlexaRankingRequestState(callback, country, pages, ranking, userState);

			// Call the internal request method.
			this.BeginGetRankingInternal(asyncState, this.GetUriCountryRanking);

			// Return the request state.
			return asyncState;
		}

		/// <summary>
		/// Ends an asynchronous request for the country-specific Alexa ranking.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		/// <returns>The Alexa ranking list.</returns>
		public AlexaRanking EndGetRanking(IAsyncResult result)
		{
			// Get the asynchronous state.
			AlexaRankingRequestState asyncState = result as AlexaRankingRequestState;

			// If the request state is null, throw an exception.
			if (null == asyncState) throw new InvalidOperationException("Cannot end the asynchronous operation because the asynchronous result does not match the request.");

			// If the operation has an exception, throw the exception.
			if (null != asyncState.Exception)
			{
				throw asyncState.Exception;
			}

			// Else, return the result.
			return asyncState.Ranking;
		}

		/// <summary>
		/// Cancels the specified asynchronous request.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		public new void Cancel(IAsyncResult result)
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
						if (null != asyncState.Callback) asyncState.Callback(asyncState);
						// Dispose the state.
						asyncState.Dispose();
					}
				}, asyncState);
		}

		/// <summary>
		/// Begins an asynchronous request for the Alexa ranking.
		/// </summary>
		/// <param name="asyncState">The asynchronous state.</param>
		private void BeginGetRankingInternal(AlexaRankingRequestState asyncState, AlexaRankingAction actionUri)
		{
			// The URI.
			Uri uri;
			// The country.
			AlexaCountry country;
			// Call the ranking action.
			actionUri(asyncState, out uri, out country);
			// Begin an asynchronous request for the Alexa ranking.
			asyncState.Result = base.Begin(uri, (AsyncWebResult asyncResult) =>
			{
				try
				{
					// The request data.
					string data;
					// Complete the request.
					AsyncWebResult result = base.End(asyncResult, out data);
					// Parse the list of countries.
					asyncState.Ranking.Parse(data, country);

					// If there are more pages.
					if (asyncState.Page < asyncState.Pages)
					{
						// Begin a new request.
						this.BeginGetRankingInternal(asyncState, actionUri);
					}
					else
					{
						// Complete the request.
						asyncState.Complete();
						// Call the callback method.
						if (null != asyncState.Callback) asyncState.Callback(asyncState);
						// Dispose the state.
						asyncState.Dispose();
					}
				}
				catch (Exception exception)
				{
					// Set the exception.
					asyncState.Exception = exception;
					// Complete the request.
					asyncState.Complete();
					// Call the callback method.
					if (null != asyncState.Callback) asyncState.Callback(asyncState);
					// Dispose the state.
					asyncState.Dispose();
				}
			}, asyncState);
		}

		/// <summary>
		/// Computes the request URI for the Alexa global ranking.
		/// </summary>
		/// <param name="asyncState">The request state</param>
		/// <param name="uri">The request URI.</param>
		/// <param name="country">The request country.</param>
		private void GetUriGlobalRanking(AlexaRankingRequestState asyncState, out Uri uri, out AlexaCountry country)
		{
			// Set the URI.
			uri = new Uri(AlexaRequest.urlRankingGlobal.FormatWith(asyncState.Page++));
			// Set the country.
			country = AlexaCountry.Global;
		}

		/// <summary>
		/// Computes the request URI for the Alexa country ranking.
		/// </summary>
		/// <param name="asyncState">The request state</param>
		/// <param name="uri">The request URI.</param>
		/// <param name="country">The request country.</param>
		private void GetUriCountryRanking(AlexaRankingRequestState asyncState, out Uri uri, out AlexaCountry country)
		{
			// Set the URI.
			uri = new Uri(AlexaRequest.urlRankingCountry.FormatWith(asyncState.Page++, asyncState.Country.Code));
			// Set the country.
			country = asyncState.Country;
		}
	}
}
