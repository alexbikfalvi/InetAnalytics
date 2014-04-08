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
	/// A structure representing the trigger that calls a tool method.
	/// </summary>
	public struct ToolMethodTrigger
	{
		/// <summary>
		/// Creates a new tool method trigger instance.
		/// </summary>
		/// <param name="id">The trigger identifier.</param>
		/// <param name="description">The trigger description.</param>
		public ToolMethodTrigger(Guid id, string description)
			: this()
		{
			this.Id = id;
			this.Description = description;
		}

		// Public properties.

		/// <summary>
		/// The trigger identifier.
		/// </summary>
		public Guid Id { get; private set; }
		/// <summary>
		/// The trigger description.
		/// </summary>
		public string Description { get; private set; }

		// Public methods.

		/// <summary>
		/// Compares the two trigger objects for equality.
		/// </summary>
		/// <param name="left">The left object.</param>
		/// <param name="right">The right object.</param>
		/// <returns><b>True</b> if the two objects are equal, <b>false</b> otherwise.</returns>
		public static bool operator ==(ToolMethodTrigger left, ToolMethodTrigger right)
		{
			return left.Id == right.Id;
		}

		/// <summary>
		/// Compares the two trigger objects for inequality.
		/// </summary>
		/// <param name="left">The left object.</param>
		/// <param name="right">The right object.</param>
		/// <returns><b>True</b> if the two objects are different, <b>false</b> otherwise.</returns>
		public static bool operator !=(ToolMethodTrigger left, ToolMethodTrigger right)
		{
			return left.Id != right.Id;
		}

		/// <summary>
		/// Compares two tool method triggers objects.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns><b>True</b> if the objects are equal, <b>false</b> otherwise.</returns>
		public override bool Equals(object obj)
		{
			if (null == obj) return false;
			if (!(obj is ToolMethodTrigger)) return false;
			ToolMethodTrigger trigger = (ToolMethodTrigger)obj;
			return this.Id == trigger.Id;
		}

		/// <summary>
		/// Returns the hash code of the current object.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}

		/// <summary>
		/// Gets a string representation of the current object.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.Description;
		}
	}
}
