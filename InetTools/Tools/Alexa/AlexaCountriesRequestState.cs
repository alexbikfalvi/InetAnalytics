using System;
using DotNetApi.Web

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
		public AlexaCountriesRequestState(AsyncWebRequestCallback callback, AlexaCountries countries, object state)
			: base(callback, state)
		{
			// Set the countries list.
			this.countries = countries != null ? countries : new AlexaCountries();
		}

		// Public properties.

		/// <summary>
		/// Gets the list of Alexa countries.
		/// </summary>
		public AlexaCountries Countries { get { return this.countries; } }
	}
}
