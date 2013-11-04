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
using System.Runtime.Serialization;
using DotNetApi;

namespace InetCrawler.Database
{
	/// <summary>
	/// A class representing a mapping exception.
	/// </summary>
	[Serializable]
	public class DbFieldException : DbException
	{
		private string property;

		/// <summary>
		/// Create a new exception instance, with the specified message and property name.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <param name="property">The property name.</param>
		public DbFieldException(string message, string property)
			: base(message)
		{
			this.property = property;
		}

		/// <summary>
		/// Creates a new database exception instance during the deserialization.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The streaming context.</param>
		protected DbFieldException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			this.property = info.GetString("property");
		}

		/// <summary>
		/// Gets the property name for which the mapping could not be solved.
		/// </summary>
		public string Property { get { return this.property; } }

		// Public methods.

		/// <summary>
		/// Populates a serialization info with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The serialization info.</param>
		/// <param name="context">The serialization.</param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// Validate the arguments.
			if (null == info) throw new ArgumentNullException("info");
			// Call the base class method.
			base.GetObjectData(info, context);
			// Set the property.
			info.AddValue("property", this.property);
		}
	}
}
