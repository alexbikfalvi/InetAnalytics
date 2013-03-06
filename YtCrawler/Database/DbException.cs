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
using System.Data.SqlClient;

namespace YtCrawler.Database
{
	/// <summary>
	/// A class that represents a database exception.
	/// </summary>
	public class DbException : Exception
	{
		/// <summary>
		/// Indicates the exception type.
		/// </summary>
		public enum Type
		{
			Unknown,
			LoginInvalidConnect,
			LoginFailed,
			LoginPasswordExpired,
			LoginPasswordMustChange
		};

		private static Dictionary<int, Type> sqlCodes = new Dictionary<int,Type>
		{
			{ 18452, Type.LoginInvalidConnect },
			{ 18456, Type.LoginFailed },
			{ 18487, Type.LoginPasswordExpired },
			{ 18488, Type.LoginPasswordMustChange }
		};

		private bool isDb = false;
		private string dbMessage = string.Empty;
		private Type dbType = Type.Unknown;

		/// <summary>
		/// Creates a new exception instance.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <param name="innerException">The inner exception.</param>
		public DbException(string message, Exception innerException)
			: base(message, innerException)
		{
			// If the message type 
			if (typeof(SqlException) == innerException.GetType())
			{
				SqlException exception = innerException as SqlException;
				this.isDb = true;
				this.dbMessage = exception.Message;
				if (DbException.sqlCodes.ContainsKey(exception.Number))
				{
					this.dbType = DbException.sqlCodes[exception.Number];
				}
			}
		}

		/// <summary>
		/// Indicates if this is a database exception.
		/// </summary>
		public bool IsDb { get { return this.isDb; } }

		/// <summary>
		/// Gets the message for a database exception.
		/// </summary>
		public string DbMessage { get { return this.dbMessage; } }

		/// <summary>
		/// Gets the type for a database exception.
		/// </summary>
		public Type DbType { get { return this.dbType; } }
	}
}
