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
using System.Collections.Generic;
using System.Xml.Linq;
using DotNetApi;

namespace InetCommon.Database
{
	/// <summary>
	/// An interface for a database relationship.
	/// </summary>
	public interface IRelationship
	{
		/// <summary>
		/// Gets the left table of the database relationship.
		/// </summary>
		ITable LeftTable { get; }
		/// <summary>
		/// Gets the right table of the database relationship.
		/// </summary>
		ITable RightTable { get; }
		/// <summary>
		/// Gets the left field of the database relationship.
		/// </summary>
		string LeftField { get; }
		/// <summary>
		/// Gets the right field of the database relationship.
		/// </summary>
		string RightField { get; }
		/// <summary>
		/// Gets whether the relationship is read-only.
		/// </summary>
		bool ReadOnly { get; }
	};

	/// <summary>
	/// A class that represents a database relationship between two tables.
	/// </summary>
	public class DbRelationship : IRelationship
	{
		private static readonly string xmlRelationship = "DbRelationship";
		private static readonly string xmlLeftTable = "leftTable";
		private static readonly string xmlRightTable = "rightTable";
		private static readonly string xmlLeftField = "leftField";
		private static readonly string xmlRightField = "rightField";

		private ITable leftTable;
		private string leftField;

		private ITable rightTable;
		private string rightField;

		private bool readOnly = true;

		private XElement xml = null;

		/// <summary>
		/// Creates a new database relationship.
		/// </summary>
		/// <param name="leftTable">The left table.</param>
		/// <param name="rightTable">The right table.</param>
		/// <param name="leftField">The left field name.</param>
		/// <param name="rightField">The right field name.</param>
		/// <param name="readOnly">Indicates if the relationship is read-only.</param>
		public DbRelationship(ITable leftTable, ITable rightTable, string leftField, string rightField, bool readOnly)
		{
			// Check the tables exist.
			if (null == leftTable) throw new DbException("Cannot create a database relationship: the left table does not exist.");
			if (null == rightTable) throw new DbException("Cannot create a database relationship: the right table does not exist.");
			// Check the table fields exist.
			if (null == leftTable[leftField]) throw new DbException("Cannot create a database relationship: the left field \'{0}\' does not exist in table \'{1}\'.".FormatWith(leftField, leftTable.LocalName));
			if (null == rightTable[rightField]) throw new DbException("Cannot create a datbase relationship: the right field \'{0}\' does not exist in table \'{1}\'.".FormatWith(rightField, rightTable.LocalName));
			// Set the relationship members.
			this.leftTable = leftTable;
			this.rightTable = rightTable;
			this.leftField = leftField;
			this.rightField = rightField;
			this.readOnly = readOnly;
			// Set the relationship on the left table.
			this.leftTable.AddRelationship(this);
		}

		// Public properties.

		/// <summary>
		/// Gets the left table of the database relationship.
		/// </summary>
		public ITable LeftTable { get { return this.leftTable; } }
		/// <summary>
		/// Gets the right table of the database relationship.
		/// </summary>
		public ITable RightTable { get { return this.rightTable; } }
		/// <summary>
		/// Gets the left field of the database relationship.
		/// </summary>
		public string LeftField { get { return this.leftField; } }
		/// <summary>
		/// Gets the right field of the database relationship.
		/// </summary>
		public string RightField { get { return this.rightField; } }
		/// <summary>
		/// Gets whether the relationship is read-only.
		/// </summary>
		public bool ReadOnly { get { return this.readOnly; } }
		/// <summary>
		/// Gets the XML element for this database relationship.
		/// </summary>
		public XElement Xml
		{
			get
			{
				// If there exists a current XML element, return that element, otherwise create a new one.
				return this.xml != null? this.xml : (this.xml = new XElement(DbRelationship.xmlRelationship,
					new XAttribute(DbRelationship.xmlLeftTable, this.leftTable.Id.ToString()),
					new XAttribute(DbRelationship.xmlRightTable, this.rightTable.Id.ToString()),
					new XAttribute(DbRelationship.xmlLeftField, this.leftField),
					new XAttribute(DbRelationship.xmlRightField, this.rightField)));
			}
		}

		// Public methods.

		/// <summary>
		/// Creates a new database relationshiop from the specified XML element and list of tables.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="tables">The set of database tables.</param>
		public static DbRelationship Create(XElement element, DbTables tables)
		{
			// Verify the name of the XML element.
			if (element.Name != DbRelationship.xmlRelationship) throw new DbException("Cannot create a database relationship because the name of XML element is \'{0}\'".FormatWith(element.Name));
			// Get the names of the tables and fields.
			Guid tableLeft = new Guid(element.Attribute(DbRelationship.xmlLeftTable).Value);
			Guid tableRight = new Guid(element.Attribute(DbRelationship.xmlRightTable).Value);
			string fieldLeft = element.Attribute(DbRelationship.xmlLeftField).Value;
			string fieldRight = element.Attribute(DbRelationship.xmlRightField).Value;
			// Check the tables exist.
			if (null == tables[tableLeft]) throw new DbException("Cannot create a database relationship: the left table \'{0}\' does not exist.".FormatWith(tableLeft));
			if (null == tables[tableRight]) throw new DbException("Cannot create a database relationship: the right table \'{0}\' does not exist.".FormatWith(tableRight));
			// Create a new database relationship object, which is not read-only.
			DbRelationship relationship = new DbRelationship(tables[tableLeft], tables[tableRight], fieldLeft, fieldRight, false);
			// Set the XML element.
			relationship.xml = element;
			// Return the relationship.
			return relationship;
		}

		/// <summary>
		/// Compares two relationship objects.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns><b>True</b> if the two objects are equal, <b>false</b> otherwise.</returns>
		public override bool Equals(object obj)
		{
			if (null == obj) return false;
			else if (!(obj is DbRelationship)) return false;
			else
			{
				// Get the relationship object.
				DbRelationship relationship = obj as DbRelationship;
				// Check the tables and the fields are equal.
				return object.ReferenceEquals(this.leftTable, relationship.leftTable) &&
					object.ReferenceEquals(this.rightTable, relationship.rightTable) &&
					(this.leftField == relationship.leftField) &&
					(this.rightField == relationship.rightField);
			}
		}

		/// <summary>
		/// Gets the hash code for the relationship object.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			return this.leftTable.GetHashCode() ^ this.rightTable.GetHashCode() ^ this.leftField.GetHashCode() ^ this.rightField.GetHashCode();
		}
	}
}
