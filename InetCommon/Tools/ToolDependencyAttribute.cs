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

namespace InetCommon.Tools
{
	/// <summary>
	/// A class representing a tool dependency attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public sealed class ToolDependencyAttribute : Attribute
	{
		/// <summary>
		/// Creates a new tool information structure.
		/// </summary>
		/// <param name="id">The tool identifier.</param>
		/// <param name="major">The toolbox major version.</param>
		/// <param name="minor">The toolbox minor version.</param>
		/// <param name="build">The toolbox build version.</param>
		/// <param name="revision">The toolbox revision version.</param>
		public ToolDependencyAttribute(string id, int major, int minor, int build, int revision)
		{
			this.Info = new ToolId(new Guid(id), new Version(major, minor, build, revision));
		}

		/// <summary>
		/// Gets the dependency tool information.
		/// </summary>
		public ToolId Info { get; private set; }
	}
}
