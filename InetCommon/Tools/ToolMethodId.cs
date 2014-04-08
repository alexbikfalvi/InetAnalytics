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
	/// A structure representing a tool method identifier.
	/// </summary>
	public struct ToolMethodId
	{
		/// <summary>
		/// Creates a new tool method information structure.
		/// </summary>
		/// <param name="guidTool">The tool identifier.</param>
		/// <param name="version">The tool version.</param>
		/// <param name="guidMethod">The method identifier.</param>
		public ToolMethodId(Guid guidTool, Version version, Guid guidMethod)
			: this()
		{
			this.GuidTool = guidTool;
			this.GuidMethod = guidMethod;
			this.Version = version;
		}

		// Public properties.

		/// <summary>
		/// Gets the tool identifier.
		/// </summary>
		public Guid GuidTool { get; private set; }
		/// <summary>
		/// Gets the method identifier.
		/// </summary>
		public Guid GuidMethod { get; private set; }
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
			if (!(obj is ToolMethodId)) return false;
			ToolMethodId info = (ToolMethodId)obj;
			return (this.GuidTool == info.GuidTool) && (this.Version == info.Version) && (this.GuidMethod == info.GuidMethod);
		}

		/// <summary>
		/// Returns the hash code of the current object.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			return this.GuidTool.GetHashCode() ^ this.Version.GetHashCode() ^ this.GuidMethod.GetHashCode();
		}

		/// <summary>
		/// Converts the tool identifier to a string.
		/// </summary>
		/// <returns>The string.</returns>
		public override string ToString()
		{
			return "{0},{1},{2}".FormatWith(this.GuidTool.ToString(), this.Version.ToString(), this.GuidMethod.ToString());
		}

		/// <summary>
		/// Compares two tool information structures.
		/// </summary>
		/// <param name="left">The left header.</param>
		/// <param name="right">The right header.</param>
		/// <returns><b>True</b> if the two headers are equal, or <b>false</b> otherwise.</returns>
		public static bool operator ==(ToolMethodId left, ToolMethodId right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Compares two tool information structures.
		/// </summary>
		/// <param name="left">The left header.</param>
		/// <param name="right">The right header.</param>
		/// <returns><b>True</b> if the two headers are equal, or <b>false</b> otherwise.</returns>
		public static bool operator !=(ToolMethodId left, ToolMethodId right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		/// Parses the specified string into a tool identifier.
		/// </summary>
		/// <param name="value">The string value.</param>
		/// <returns>The tool identifier.</returns>
		public static ToolMethodId Parse(string value)
		{
			// Split the tool information between identifier and version.
			string[] str = value.Split(',');

			// If the information does not have exactly two parameters, throw an exception.
			if (3 != str.Length) throw new FormatException("The specified string does not correspond to a tool method identifier.");

			// Return the tool identifier.
			return new ToolMethodId(Guid.Parse(str[0]), Version.Parse(str[1]), Guid.Parse(str[2]));
		}

		/// <summary>
		/// Try and parse the specified string into a tool identifier.
		/// </summary>
		/// <param name="value">The string value.</param>
		/// <param name="id">The tool identifier.</param>
		/// <returns><b>True</b> if the parsing was successful, <b>false</b> otherwise.</returns>
		public static bool TryParse(string value, out ToolMethodId id)
		{
			// Split the tool information between identifier and version.
			string[] str = value.Split(',');

			id = default(ToolMethodId);

			// If the information does not have exactly two parameters, throw an exception.
			if (3 != str.Length) return false;

			Guid guidTool;
			Version version;
			Guid guidMethod;

			// Try parse the GUID.
			if (!Guid.TryParse(str[0], out guidTool)) return false;
			// Try parse the version.
			if (!Version.TryParse(str[1], out version)) return false;
			// Try parse the version.
			if (!Guid.TryParse(str[2], out guidMethod)) return false;

			// Create the new tool identifier.
			id = new ToolMethodId(guidTool, version, guidMethod);

			return true;
		}
	}
}
