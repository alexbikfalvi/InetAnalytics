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

namespace InetCrawler.Database
{
	/// <summary>
	/// A class representing a table relationship template.
	/// </summary>
	public sealed class DbRelationshipTemplate
	{
		/// <summary>
		/// Creates a new table relationship template.
		/// </summary>
		/// <param name="leftTable">The left table template.</param>
		/// <param name="rightTable">The right table template.</param>
		/// <param name="leftField">The left field name.</param>
		/// <param name="rightField">The right field name.</param>
		/// <param name="readOnly">Indicates if the relationship is read-only.</param>
		public DbRelationshipTemplate(DbTableTemplate leftTable, DbTableTemplate rightTable, string leftField, string rightField, bool readOnly)
		{
			// Validate the arguments.
			if (null == leftTable) throw new ArgumentNullException("leftTable");
			if (null == rightTable) throw new ArgumentNullException("rightTable");
			if (null == leftField) throw new ArgumentNullException("leftField");
			if (null == rightField) throw new ArgumentNullException("rightField");

			// Set the properties.
			this.LeftTable = leftTable;
			this.RightTable = rightTable;
			this.LeftField = leftField;
			this.RightField = rightField;
		}

		// Public properties.

		/// <summary>
		/// Gets the left table template.
		/// </summary>
		public DbTableTemplate LeftTable { get; private set; }
		/// <summary>
		/// Gets the right table template.
		/// </summary>
		public DbTableTemplate RightTable { get; private set; }
		/// <summary>
		/// Gets the left field name.
		/// </summary>
		public string LeftField { get; private set; }
		/// <summary>
		/// Gets the right field name.
		/// </summary>
		public string RightField { get; private set; }
		/// <summary>
		/// Indicates whether the relationship is read-only.
		/// </summary>
		public bool ReadOnly { get; private set; }
	}
}
