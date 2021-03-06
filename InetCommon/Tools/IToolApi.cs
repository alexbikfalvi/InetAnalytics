﻿/* 
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
using Microsoft.Win32;
using InetCommon.Database;
using InetCommon.Log;
using InetCommon.Status;

namespace InetCommon.Tools
{
	/// <summary>
	/// An interface allowing the communication of a tool with the host application.
	/// </summary>
	public interface IToolApi
	{
		// Registry.

		/// <summary>
		/// Gets the registry key for this tool.
		/// </summary>
		RegistryKey Key { get; }

		// Configuration.

		/// <summary>
		/// Gets the tool configuration.
		/// </summary>
		IToolConfig Config { get; }

		// Log.

		/// Logs an event for the specified tool.
		/// </summary>
		/// <param name="level">The log event level.</param>
		/// <param name="type">The log event type.</param>
		/// <param name="message">The event message.</param>
		/// <param name="parameters">The event parameters.</param>
		/// <param name="exception">The event exception.</param>
		LogEvent Log(LogEventLevel level, LogEventType type, string message, object[] parameters = null, Exception exception = null);

		// Database.

		/// <summary>
		/// Adds the table template to the database.
		/// </summary>
		/// <param name="table">The database table template.</param>
		void DatabaseAddTable(DbTableTemplate table);

		/// <summary>
		/// Removes the table template to the database.
		/// </summary>
		/// <param name="table">The database table template.</param>
		void DatabaseRemoveTable(DbTableTemplate table);

		/// <summary>
		/// Adds the table relationship to the database.
		/// </summary>
		/// <param name="leftTable">The left table template.</param>
		/// <param name="rightTable">The right table template.</param>
		/// <param name="leftField">The left field.</param>
		/// <param name="rightField">The right field.</param>
		/// <param name="readOnly">Indicates if the relationship is read-only.</param>
		void DatabaseAddRelationship(DbTableTemplate leftTable, DbTableTemplate rightTable, string leftField, string rightField, bool readOnly);

		// Status.

		/// <summary>
		/// Gets the crawler status.
		/// </summary>
		ApplicationStatus Status { get; }
	}
}
