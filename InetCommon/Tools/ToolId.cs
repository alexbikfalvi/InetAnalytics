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

namespace InetCommon.Tools
{
	/// <summary>
	/// A structure representing a tool identifier.
	/// </summary>
	public struct ToolId
	{
		/// <summary>
		/// Creates a new tool information structure.
		/// </summary>
		/// <param name="guid">The identifier.</param>
		/// <param name="version">The tool version.</param>
		public ToolId(Guid guid, Version version)
			: this()
		{
			this.Guid = guid;
			this.Version = version;
		}

		// Public properties.

		/// <summary>
		/// Gets the tool identifier.
		/// </summary>
		public Guid Guid { get; private set; }
		/// <summary>
		/// Gets the tool version.
		/// </summary>
		public Version Version { get; private set; }

		// Public methods.

		/// <summary>
		/// Compares two tool information structures for equality.
		/// </summary>
		/// <param name="obj">The tool information structure to compare.</param>
		/// <returns><b>True</b> if the two structures are equal, <b>false</b> otherwise.</returns>
		public override bool Equals(object obj)
		{
			if (null == obj) return false;
			if (!(obj is ToolId)) return false;
			ToolId info = (ToolId)obj;
			return (this.Guid == info.Guid) && (this.Version == info.Version);
		}

		/// <summary>
		/// Returns the hash code of the current object.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			return this.Guid.GetHashCode() ^ this.Version.GetHashCode();
		}

		/// <summary>
		/// Converts the tool identifier to a string.
		/// </summary>
		/// <returns>The string.</returns>
		public override string ToString()
		{
			return "{0},{1}".FormatWith(this.Guid.ToString(), this.Version.ToString());
		}

		/// <summary>
		/// Compares two tool information structures.
		/// </summary>
		/// <param name="left">The left header.</param>
		/// <param name="right">The right header.</param>
		/// <returns><b>True</b> if the two headers are equal, or <b>false</b> otherwise.</returns>
		public static bool operator ==(ToolId left, ToolId right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Compares two tool information structures.
		/// </summary>
		/// <param name="left">The left header.</param>
		/// <param name="right">The right header.</param>
		/// <returns><b>True</b> if the two headers are equal, or <b>false</b> otherwise.</returns>
		public static bool operator !=(ToolId left, ToolId right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		/// Parses the specified string into a tool identifier.
		/// </summary>
		/// <param name="value">The string value.</param>
		/// <returns>The tool identifier.</returns>
		public static ToolId Parse(string value)
		{
			// Split the tool information between identifier and version.
			string[] str = value.Split(',');

			// If the information does not have exactly two parameters, throw an exception.
			if (2 != str.Length) throw new FormatException("The specified string does not correspond to a tool identifier.");

			// Return the tool identifier.
			return new ToolId(Guid.Parse(str[0]), Version.Parse(str[1]));
		}

		/// <summary>
		/// Try and parse the specified string into a tool identifier.
		/// </summary>
		/// <param name="value">The string value.</param>
		/// <param name="id">The tool identifier.</param>
		/// <returns><b>True</b> if the parsing was successful, <b>false</b> otherwise.</returns>
		public static bool TryParse(string value, out ToolId id)
		{
			// Split the tool information between identifier and version.
			string[] str = value.Split(',');

			id = default(ToolId);

			// If the information does not have exactly two parameters, throw an exception.
			if (2 != str.Length) return false;

			Guid guid;
			Version version;

			// Try parse the GUID.
			if (!Guid.TryParse(str[0], out guid)) return false;
			// Try parse the version.
			if (!Version.TryParse(str[1], out version)) return false;

			// Create the new tool identifier.
			id = new ToolId(guid, version);

			return true;
		}
	}
}
