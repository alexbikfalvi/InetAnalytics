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
using YtApi.Api.V2.Atom;

namespace YtApi.Api.V2.Data
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
		private PriceType type;

		/// <summary>
		/// Creates a price object based on an atom instance.
		/// </summary>
		/// <param name="atom"></param>
		public Price(AtomMediaPrice atom)
		{
			this.atom = atom;
			switch (atom.Type.ToLower())
			{
				case "package": this.type = PriceType.Package; break;
				case "purchase": this.type = PriceType.Purchase; break;
				case "rent": this.type = PriceType.Rent; break;
				case "subscription": this.type = PriceType.Subscription; break;
				default: throw new YouTubeException(string.Format("Cannot create a price object: unknown type \"{0}\".", atom.Type));
			}
		}

		public PriceType Type { get { return this.type; } }
		public string TypeAsString { get { return this.atom.Type; } }
		public decimal Value { get { return this.atom.Price; } }
		public string Currency { get { return this.atom.Currency; } }
		public TimeSpan Duration { get { return this.atom.YtDuration; } }
	}
}
