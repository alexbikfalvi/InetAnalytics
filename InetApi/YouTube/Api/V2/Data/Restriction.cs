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
	[Serializable]
	public enum RestrictionType
	{
		Country = 1
	};

	[Serializable]
	public enum RestrictionRelationship
	{
		Allow = 1,
		Deny = 2
	}

	/// <summary>
	/// A class that represents the media restriction for a YouTube video.
	/// </summary>
	[Serializable]
	public sealed class Restriction
	{
		private AtomMediaRestriction atom;

		/// <summary>
		/// Creates a restriction object based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public Restriction(AtomMediaRestriction atom)
		{
			this.atom = atom;
			switch (this.atom.Type.ToLower())
			{
				case "country": this.Type = RestrictionType.Country; break;
				default: throw new YouTubeException("Cannot create the restriction object: unknown type \"{0}\".".FormatWith(this.atom.Type));
			}
			switch (this.atom.Relationship.ToLower())
			{
				case "allow": this.Relationship = RestrictionRelationship.Allow; break;
				case "deny": this.Relationship = RestrictionRelationship.Deny; break;
				default: throw new YouTubeException("Cannot create the restriction object: unknown relationship \"{0}\".".FormatWith(this.atom.Relationship));
			}
		}

		public RestrictionType Type { get; private set; }
		public string TypeAsString { get { return this.atom.Type; } }
		public RestrictionRelationship Relationship { get; private set; }
		public string RelationshipAsString { get { return this.atom.Relationship; } }
		public string Countries { get { return this.atom.Value; } }
	}
}
