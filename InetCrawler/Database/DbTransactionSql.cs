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
using System.Data;
using System.Data.SqlClient;

namespace InetCrawler.Database
{
	/// <summary>
	/// A class representing a database transaction for a SQL Server.
	/// </summary>
	public sealed class DbTransactionSql : DbTransaction
	{
		private SqlTransaction transaction;

		/// <summary>
		/// Creates a new database transaction instance.
		/// </summary>
		/// <param name="connection">The database connection.</param>
		/// <param name="isolation">The isolation level for this transaction.</param>
		public DbTransactionSql(SqlConnection connection, IsolationLevel isolation)
		{
			// Begin a new transaction on the database connection.
			this.transaction = connection.BeginTransaction(isolation);
		}

		// Public properties.

		public SqlTransaction Transaction { get { return this.transaction; } }

		// Public methods.

		/// <summary>
		/// Commits the database transaction.
		/// </summary>
		public override void Commit()
		{
			// Commit the transaction.
			this.transaction.Commit();
		}

		/// <summary>
		/// Rolls back the database transaction.
		/// </summary>
		public override void Rollback()
		{
			// Roll back the transaction.
			this.transaction.Rollback();
		}

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose the current transaction.
				this.transaction.Dispose();
			}
			// Call the base class method.
			base.Dispose(disposing);
		}
	}
}
