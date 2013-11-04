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

namespace InetCrawler.Database
{
	/// <summary>
	/// An interface for a database relationship.
	/// </summary>
	public interface IRelationship
	{
		/// <summary>
		/// Gets the left table of the database relationship.
		/// </summary>
		ITable TableLeft { get; }
		/// <summary>
		/// Gets the right table of the database relationship.
		/// </summary>
		ITable TableRight { get; }
		/// <summary>
		/// Gets the left field of the database relationship.
		/// </summary>
		string FieldLeft { get; }
		/// <summary>
		/// Gets the right field of the database relationship.
		/// </summary>
		string FieldRight { get; }
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
		private static readonly string xmlLeftTable = "tableLeft";
		private static readonly string xmlRightTable = "tableRight";
		private static readonly string xmlLeftField = "fieldLeft";
		private static readonly string xmlRightField = "fieldRight";

		private ITable tableLeft;
		private string fieldLeft;

		private ITable tableRight;
		private string fieldRight;

		private bool readOnly = true;

		private XElement xml = null;

		/// <summary>
		/// Creates a new database relationship.
		/// </summary>
		/// <param name="tableLeft">The left table.</param>
		/// <param name="tableRight">The right table.</param>
		/// <param name="fieldLeft">The left field name.</param>
		/// <param name="fieldRight">The right field name.</param>
		/// <param name="readOnly">Indicates if the relationship is read-only.</param>
		public DbRelationship(ITable tableLeft, ITable tableRight, string fieldLeft, string fieldRight, bool readOnly)
		{
			// Check the tables exist.
			if (null == tableLeft) throw new DbException("Cannot create a database relationship: the left table does not exist.");
			if (null == tableRight) throw new DbException("Cannot create a database relationship: the right table does not exist.");
			// Check the table fields exist.
			if (null == tableLeft[fieldLeft]) throw new DbException("Cannot create a database relationship: the left field \'{0}\' does not exist in table \'{1}\'.".FormatWith(fieldLeft, tableLeft.LocalName));
			if (null == tableRight[fieldRight]) throw new DbException("Cannot create a datbase relationship: the right field \'{0}\' does not exist in table \'{1}\'.".FormatWith(fieldRight, tableRight.LocalName));
			// Set the relationship members.
			this.tableLeft = tableLeft;
			this.tableRight = tableRight;
			this.fieldLeft = fieldLeft;
			this.fieldRight = fieldRight;
			this.readOnly = readOnly;
			// Set the relationship on the left table.
			this.tableLeft.AddRelationship(this);
		}

		// Public properties.

		/// <summary>
		/// Gets the left table of the database relationship.
		/// </summary>
		public ITable TableLeft { get { return this.tableLeft; } }
		/// <summary>
		/// Gets the right table of the database relationship.
		/// </summary>
		public ITable TableRight { get { return this.tableRight; } }
		/// <summary>
		/// Gets the left field of the database relationship.
		/// </summary>
		public string FieldLeft { get { return this.fieldLeft; } }
		/// <summary>
		/// Gets the right field of the database relationship.
		/// </summary>
		public string FieldRight { get { return this.fieldRight; } }
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
					new XAttribute(DbRelationship.xmlLeftTable, this.tableLeft.LocalName),
					new XAttribute(DbRelationship.xmlRightTable, this.tableRight.LocalName),
					new XAttribute(DbRelationship.xmlLeftField, this.fieldLeft),
					new XAttribute(DbRelationship.xmlRightField, this.fieldRight)));
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
			string tableLeft = element.Attribute(DbRelationship.xmlLeftTable).Value;
			string tableRight = element.Attribute(DbRelationship.xmlRightTable).Value;
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
	}
}
