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
using DotNetApi;
using InetApi.YouTube.Api.V2.Atom;

namespace InetApi.YouTube.Api.V2.Data
{
    /// <summary>
    /// A YouTube media price type.
    /// </summary>
	[Serializable]
	public enum PriceType
	{
		Rent = 1,
		Purchase = 2,
		Package = 3,
		Subscription = 4
	}

    /// <summary>
    /// A YouTube media price. 
    /// </summary>
	[Serializable]
	public sealed class Price
	{
		private AtomMediaPrice atom;

		/// <summary>
		/// Creates a price object based on an atom instance.
		/// </summary>
		/// <param name="atom"></param>
		public Price(AtomMediaPrice atom)
		{
			this.atom = atom;
			switch (atom.Type.ToLower())
			{
				case "package": this.Type = PriceType.Package; break;
				case "purchase": this.Type = PriceType.Purchase; break;
				case "rent": this.Type = PriceType.Rent; break;
				case "subscription": this.Type = PriceType.Subscription; break;
				default: throw new YouTubeException("Cannot create a price object: unknown type \"{0}\".".FormatWith(atom.Type));
			}
		}

		public PriceType Type { get; private set; }
		public string TypeAsString { get { return this.atom.Type; } }
		public decimal Value { get { return this.atom.Price; } }
		public string Currency { get { return this.atom.Currency; } }
		public TimeSpan Duration { get { return this.atom.YtDuration; } }
	}
}
