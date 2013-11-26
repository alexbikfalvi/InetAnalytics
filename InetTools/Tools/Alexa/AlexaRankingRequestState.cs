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

namespace InetTools.Tools.Alexa
{
	/// <summary>
	/// A class representing an Alexa ranking request state.
	/// </summary>
	public sealed class AlexaRankingRequestState : AlexaRequestState
	{
		private readonly AlexaRanking ranking;

		/// <summary>
		/// Creates a new Alexa request state instance.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="pages">The number of pages to return.</param>
		/// <param name="ranking">The Alexa ranking list.</param>
		/// <param name="state">The user state.</param>
		public AlexaRankingRequestState(AsyncCallback callback, int pages, AlexaRanking ranking, object state)
			: base(callback, state)
		{
			// Set the number of pages.
			this.Pages = pages;
			// Set the ranking list.
			this.ranking = ranking != null ? ranking : new AlexaRanking();
			// Clear the ranking list.
			this.ranking.Clear();
		}

		/// <summary>
		/// Creates a new Alexa request state instance.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="country">The country.</param>
		/// <param name="pages">The number of pages to return.</param>
		/// <param name="ranking">The Alexa ranking list.</param>
		/// <param name="state">The user state.</param>
		public AlexaRankingRequestState(AsyncCallback callback, AlexaCountry country, int pages, AlexaRanking ranking, object state)
			: base(callback, state)
		{
			// Set the country.
			this.Country = country;
			// Set the number of pages.
			this.Pages = pages;
			// Set the ranking list.
			this.ranking = ranking != null ? ranking : new AlexaRanking();
			// Clear the ranking list.
			this.ranking.Clear();
		}

		// Public properties.

		/// <summary>
		/// Gets the list of Alexa ranking.
		/// </summary>
		public AlexaRanking Ranking { get { return this.ranking; } }
		/// <summary>
		/// Gets the country.
		/// </summary>
		public AlexaCountry Country { get; private set; }
		/// <summary>
		/// Gets the number of pages to return.
		/// </summary>
		public int Pages { get; private set; }
		/// <summary>
		/// Gets or sets the current request page.
		/// </summary>
		public int Page { get; set; }
	}
}
