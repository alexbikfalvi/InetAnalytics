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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DotNetApi;

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class representing the Internet Analytics toolbox.
	/// </summary>
	public sealed class Toolbox : IDisposable, IEnumerable<Tool>
	{
		private readonly Dictionary<ToolInfo, Tool> tools = new Dictionary<ToolInfo, Tool>();
		private readonly object sync = new object();

		/// <summary>
		/// Creates a new toolbox instance.
		/// </summary>
		public Toolbox()
		{

		}

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Gets the generic enumerator for the toolbox collection.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<Tool> GetEnumerator()
		{
			return this.tools.Values.GetEnumerator();
		}

		/// <summary>
		/// Gets the non-generic enumerator for the toolbox collection.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Loads a toolbox from the specified file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		/// <returns>The toolbox.</returns>
		public static Toolset Load(string fileName)
		{
			// Load the file as an assembly.
			Assembly assembly = Assembly.LoadFrom(fileName);

			// Search the assembly for a toolset type.
			foreach (Type type in assembly.GetExportedTypes())
			{
				// Check the type extends the toolset interface.
				if (type.IsSubclassOf(typeof(Toolset)))
				{
					// Check the toolbox class has a toolbox attribute.
					object[] attributes = type.GetCustomAttributes(typeof(ToolsetInfoAttribute), false);

					// If the attributes list is not empty.
					if (attributes.Length != 0)
					{
						// Create a new instance.
						return Activator.CreateInstance(type) as Toolset;
					}
				}
			}
			// Else, throw an exception.
			throw new NotSupportedException("Cannot find an Internet Analytics toolbox in the specified library.");
		}
	}
}
