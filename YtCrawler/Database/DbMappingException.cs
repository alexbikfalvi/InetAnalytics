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

namespace YtCrawler.Database
{
	/// <summary>
	/// A class representing a mapping exception.
	/// </summary>
	public class DbMappingException : DbException
	{
		private Type type;
		private string property;

		public DbMappingException(string message, Type type, string property)
			: base(message)
		{
			this.type = type;
			this.property = property;
		}

		/// <summary>
		/// Gets the type that generated the exception.
		/// </summary>
		public new Type Type { get { return this.type; } }

		/// <summary>
		/// Gets the property name for which the mapping could not be solved.
		/// </summary>
		public string Property { get { return this.property; } }
	}
}
