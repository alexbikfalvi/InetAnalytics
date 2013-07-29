/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
	/// A class describing a YouTube user profile.
	/// </summary>
	[Serializable]
	public sealed class Profile : Entry
	{
		private AtomEntryProfile atom;

		private Author author;
		private Username username;
		private Statistics statistics;
		private Thumbnail thumbnail;

		public override Entry Create(YtApi.Api.V2.Atom.Atom atom)
		{
			return new Profile(atom as AtomEntryProfile);
		}

		/// <summary>
		/// Creates an undefined profile object.
		/// </summary>
		public Profile() { }

		/// <summary>
		/// Creates a profile object based on an atom instance.
		/// </summary>
		/// <param name="atom">The atom instance.</param>
		public Profile(AtomEntryProfile atom)
		{
			this.atom = atom;

			this.author = this.atom.Author != null ? new Author(this.atom.Author) : null;
			this.username = this.atom.YtUserName != null ? new Username(this.atom.YtUserName) : null;
			this.statistics = this.atom.YtStatistics != null ? new Statistics(this.atom.YtStatistics) : null;
			this.thumbnail = this.atom.MediaThumbnail != null ? new Thumbnail(this.atom.MediaThumbnail) : null;
		}

		/// <summary>
		/// Creates a corresponding atom feed from the specified data string.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <returns>The atom feed.</returns>
		public override AtomFeed CreateFeed(string data)
		{
			return AtomFeedProfile.Parse(data);
		}

		/// <summary>
		/// Returns the atom corresponding to this profile.
		/// </summary>
		public AtomEntryProfile Atom { get { return this.atom; } }

		/// <summary>
		/// Returns the Atom ID of the profile object.
		/// </summary>
		public string AtomId { get { return this.atom.Id.Value; } }

		/// <summary>
		/// The profile user ID.
		/// </summary>
		public string Id { get { return this.atom.YtUserId != null ? this.atom.YtUserId.Value : null; } }

		/// <summary>
		/// The date/time of profile publication. It can be null.
		/// </summary>
		public DateTime? Published { get { return this.atom.Published != null ? this.atom.Published.Value as DateTime? : null; } }

		/// <summary>
		/// The date/time when the profile entry was last updated. It cannot be null.
		/// </summary>
		public DateTime Updated { get { return this.atom.Updated.Value; } }

		/// <summary>
		/// The profile title. It cannot be null.
		/// </summary>
		public string Title { get { return this.atom.Title.Value; } }

		/// <summary>
		/// The profile author. It can be null.
		/// </summary>
		public Author Author { get { return this.author; } }

		/// <summary>
		/// The user's about description. It can be null.
		/// </summary>
		public string AboutMe { get { return this.atom.YtAboutMe != null ? this.atom.YtAboutMe.Value : null; } }

		/// <summary>
		/// The user's age. It can be null.
		/// </summary>
		public int? Age { get { return this.atom.YtAge != null ? this.atom.YtAge.Value as int? : null; } }

		/// <summary>
		/// The user's favorite books. It can be null.
		/// </summary>
		public string Books { get { return this.atom.YtBooks != null ? this.atom.YtBooks.Value : null; } }

		/// <summary>
		/// The user's company. It can be null.
		/// </summary>
		public string Company { get { return this.atom.YtCompany != null ? this.atom.YtCompany.Value : null; } }

		/// <summary>
		/// The user's first name. It can be null.
		/// </summary>
		public string FirstName { get { return this.atom.YtFirstName != null ? this.atom.YtFirstName.Value : null; } }

		/// <summary>
		/// The user's gender. It can be null.
		/// </summary>
		public Gender? Gender { get { return this.atom.YtGender != null ? this.atom.YtGender.Value as Gender? : null; } }

		/// <summary>
		/// The user's hobbies. It can be null.
		/// </summary>
		public string Hobbies { get { return this.atom.YtHobbies != null ? this.atom.YtHobbies.Value : null; } }

		/// <summary>
		/// The user's hometown. It can be null.
		/// </summary>
		public string Hometown { get { return this.atom.YtHometown != null ? this.atom.YtHometown.Value : null; } }

		/// <summary>
		/// The user's last name. It can be null.
		/// </summary>
		public string LastName { get { return this.atom.YtLastName != null ? this.atom.YtLastName.Value : null; } }

		/// <summary>
		/// The user's location. It can be null.
		/// </summary>
		public string Location { get { return this.atom.YtLocation != null ? this.atom.YtLocation.Value : null; } }

		/// <summary>
		/// The user's maximum upload duration in seconds. It can be null.
		/// </summary>
		public int? MaxUploadDuration { get { return this.atom.YtMaxUploadDuration != null ? this.atom.YtMaxUploadDuration.Seconds as int? : null; } }

		/// <summary>
		/// The user's favorite videos. It can be null.
		/// </summary>
		public string Movies { get { return this.atom.YtMovies != null ? this.atom.YtMovies.Value : null; } }

		/// <summary>
		/// The user's favorite music. It can be null.
		/// </summary>
		public string Music { get { return this.atom.YtMusic != null ? this.atom.YtMusic.Value : null; } }

		/// <summary>
		/// The user's occupation. It can be null.
		/// </summary>
		public string Occupation { get { return this.atom.YtOccupation != null ? this.atom.YtOccupation.Value : null; } }

		/// <summary>
		/// The user's school. It can be null.
		/// </summary>
		public string School { get { return this.atom.YtSchool != null ? this.atom.YtSchool.Value : null; } }

		/// <summary>
		/// The user profile statistics. It can be null.
		/// </summary>
		public Statistics Statistics { get { return this.statistics; } }

		/// <summary>
		/// The profile summary. It can be null.
		/// </summary>
		public string Summary { get { return this.atom.Summary != null ? this.atom.Summary.Value : null; } }

		/// <summary>
		/// The profile thumbnail. It can be null.
		/// </summary>
		public Thumbnail Thumbnail { get { return this.thumbnail; } }

		/// <summary>
		/// The profile username. It can be null.
		/// </summary>
		public Username Username { get { return this.username; } }
	}
}
