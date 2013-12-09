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
	/// A deleate for a tool method action.
	/// </summary>
	/// <param name="arguments">The method arguments.</param>
	public delegate void ToolMethodAction(object[] arguments);

	/// <summary>
	/// A class representing a tool method.
	/// </summary>
	public sealed class ToolMethod
	{
		private readonly Guid id;
		private readonly string name;
		private readonly ToolMethodAction action;

		/// <summary>
		/// Createa a new tool method instance.
		/// </summary>
		/// <param name="id">The tool method identifier.</param>
		/// <param name="name">The method name.</param>
		/// <param name="action">The action.</param>
		public ToolMethod(Guid id, string name, ToolMethodAction action)
		{
			// Validate the arguments.
			if (null == action) throw new ArgumentNullException("action");

			this.id = id;
			this.name = name;
			this.action = action;
		}

		// Public properties.

		/// <summary>
		/// Gets the tool method identifier.
		/// </summary>
		public Guid Id { get { return this.id; } }
		/// <summary>
		/// Gets the tool method name.
		/// </summary>
		public string Name { get { return this.name; } }

		// Public methods.


		/// <summary>
		/// Calls the tool method.
		/// </summary>
		/// <param name="arguments">The method arguments.</param>
		public void Call(params object[] arguments)
		{
			// Call the method handler.
			this.action(arguments);
		}
	}
}
