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

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class representing the method information.
	/// </summary>
	public sealed class ToolMethodInfo
	{
		/// <summary>
		/// Creates a new tool method information instance.
		/// </summary>
		/// <param name="trigger">The trigger.</param>
		/// <param name="method">The method.</param>
		public ToolMethodInfo(ToolMethodTrigger trigger, ToolMethod method)
		{
			// Validate the arguments.
			if (null == method) throw new ArgumentNullException("method");

			// Set the properties.
			this.Trigger = trigger;
			this.Method = method;
		}

		// Public properties.

		/// <summary>
		/// Gets the trigger.
		/// </summary>
		public ToolMethodTrigger Trigger { get; private set; }
		/// <summary>
		/// Gets the method.
		/// </summary>
		public ToolMethod Method { get; private set; }

		// Public methods.

		/// <summary>
		/// Compares two method information objects.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (null == obj) return false;
			if (!(obj is ToolMethodInfo)) return false;
			ToolMethodInfo info = obj as ToolMethodInfo;
			return (this.Trigger.Id == info.Trigger.Id) && (this.Method.Id == this.Method.Id);
		}

		/// <summary>
		/// Returns the hash code of the current object.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			return this.Trigger.Id.GetHashCode() ^ this.Method.Id.GetHashCode();
		}

		/// <summary>
		/// Converts the method information object to a string.
		/// </summary>
		/// <returns>The string.</returns>
		public override string ToString()
		{
			return "{0}|{1}".FormatWith(this.Trigger.Id.ToString(), this.Method.Id.ToString());
		}

		/// <summary>
		/// Compares two tool information structures.
		/// </summary>
		/// <param name="left">The left header.</param>
		/// <param name="right">The right header.</param>
		/// <returns><b>True</b> if the two headers are equal, or <b>false</b> otherwise.</returns>
		public static bool operator ==(ToolMethodInfo left, ToolMethodInfo right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Compares two tool information structures.
		/// </summary>
		/// <param name="left">The left header.</param>
		/// <param name="right">The right header.</param>
		/// <returns><b>True</b> if the two headers are equal, or <b>false</b> otherwise.</returns>
		public static bool operator !=(ToolMethodInfo left, ToolMethodInfo right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		/// Tries to parse the specified string into a tool method trigger and a method identifier.
		/// </summary>
		/// <param name="value">The string value.</param>
		/// <param name="triggerId">The trigger identifier.</param>
		/// <param name="methodId">The method identifier.</param>
		/// <returns><b>True</b> if the parsing was successful, <b>false</b> otherwise.</returns>
		public static bool TryParse(string value, out Guid triggerId, out ToolMethodId methodId)
		{
			// Split the string value using the pipe.
			string[] tokens = value.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

			// If the number of tokens is 2.
			if (tokens.Length == 2)
			{
				// Parse the trigger and method identifiers.
				bool resultTrigger = Guid.TryParse(tokens[0], out triggerId);
				bool resultMethod = ToolMethodId.TryParse(tokens[1], out methodId);
				// Return the result.
				return resultTrigger && resultMethod;
			}

			// Set the default values.
			triggerId = default(Guid);
			methodId = default(ToolMethodId);

			// Return false.
			return false;
		}
	}
}
