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
	/// A class representing an Alexa countries request state.
	/// </summary>
	public sealed class AlexaCountriesRequestState : AlexaRequestState
	{
		private readonly AlexaCountries countries;

		/// <summary>
		/// Creates a new Alexa request state instance.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="countries">The list of Alexa counties.</param>
		/// <param name="state">The user state.</param>
		public AlexaCountriesRequestState(AsyncCallback callback, AlexaCountries countries, object state)
			: base(callback, state)
		{
			// Set the countries list.
			this.countries = countries != null ? countries : new AlexaCountries();
			// Clear the list of countries.
			this.countries.Clear();
		}

		// Public properties.

		/// <summary>
		/// Gets the list of Alexa countries.
		/// </summary>
		public AlexaCountries Countries { get { return this.countries; } }
	}
}
