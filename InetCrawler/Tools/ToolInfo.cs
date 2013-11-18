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

namespace InetCrawler.Tools
{
	/// <summary>
	/// A structure representing the tool information.
	/// </summary>
	public struct ToolInfo
	{
		/// <summary>
		/// Creates a new tool information structure.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="version">The tool version.</param>
		/// <p
		public ToolInfo(Guid id, Version version)
			: this()
		{
			this.Id = id;
			this.Version = version;
		}

		/// <summary>
		/// Gets the tool identifier.
		/// </summary>
		public Guid Id { get; private set; }
		/// <summary>
		/// Gets the tool version.
		/// </summary>
		public Version Version { get; private set; }

		/// <summary>
		/// Compares two tool information structures for equality.
		/// </summary>
		/// <param name="obj">The tool information structure to compare.</param>
		/// <returns><b>True</b> if the two structures are equal, <b>false</b> otherwise.</returns>
		public override bool Equals(object obj)
		{
			if (null == obj) return false;
			if (!(obj is ToolInfo)) return false;
			ToolInfo info = (ToolInfo)obj;
			return (this.Id == info.Id) && (this.Version == info.Version);
		}
	}
}
