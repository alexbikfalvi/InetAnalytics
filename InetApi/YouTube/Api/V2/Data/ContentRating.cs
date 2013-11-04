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
using InetApi.YouTube.Api.V2.Atom;

namespace InetApi.YouTube.Api.V2.Data
{
	/*
	 * urn:mpaa – The scheme specifies a Motion Picture Association of America (MPAA) rating. Valid MPAA ratings are g, pg, pg-13, r, and nc-17.
	 * urn:v-chip – The scheme specifies a V-Chip rating. Valid V-Chip ratings are tv-y, tv-y7, tv-y7-fv, tv-g, tv-pg, tv-14, and tv-ma.
	 * urn:acb – The scheme specifies an Australian Classification Board (ACB) rating. Valid ACB ratings are E, G, PG, M, MA15+, and R18+.
	 * urn:bbfc – The scheme specifies a British Board of Film Classification (BBFC) rating. Valid BBFC ratings are U, PG, 12, 12, 15, 18,and R18.
	 * urn:cbfc – The scheme specifies a Central Board of Film Certification (CBFC - India) rating. Valid CBFC ratings are U, U/A, A, and S.
	 * urn:chvrs – The scheme specifies a Canadian Home Video Rating System (CHVRS) rating. Valid CHVRS ratings are G, PG, 14A, 18A, R, and E.
	 * urn:eirin – The scheme specifies a 映倫管理委員会 (EIRIN - Japan) rating. Valid EIRIN ratings are G, PG-12, R15+, and R18+.
	 * urn:fmoc – The scheme specifies a Centre national du cinéma et de l'image animé (FMOC - France) rating. Valid FMOC ratings are E, U, 10, 12, 16, and 18.
	 * urn:fsk – The scheme specifies a Freiwillige Selbstkontrolle der Filmwirtschaft (FSK - Germany) rating. Valid FSK ratings are FSK 0, FSK 6, FSK 12, FSK 16, FSK 18.
	 * urn:icaa – The scheme specifies an Instituto de la Cinematografía y de las Artes Audiovisuales (ICAA - Spain) rating. Valid ICAA ratings are E, G, PG, M, MA15+, and R18+.
	 * urn:kmrb – The scheme specifies a Korea Media Rating Board (영상물등급위원회) (KMRB) rating. Valid KMRB ratings are All, 12+, 15+, Teenager restricted, and Restricted.
	 * urn:oflc – The scheme specifies an Office of Film and Literature Classification (OFLC - New Zealand) rating. Valid OFLC ratings are G, PG, R13, R15, R16, M, and R18.
	 * http://gdata.youtube.com/schemas/2007#mediarating – The scheme identifies content that is restricted in some countries.
	 */

	/// <summary>
	/// A class that represents the content rating.
	/// </summary>
	[Serializable]
	public sealed class ContentRating
	{
		private AtomMediaRating atom;

		/// <summary>
		/// Creates a content rating object, based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public ContentRating(AtomMediaRating atom)
		{
			this.atom = atom;
		}

		public string Scheme { get { return this.atom.Scheme; } }
		public string Country { get { return this.atom.Country; } }
		public string Value { get { return this.atom.Value; } }
	}
}
