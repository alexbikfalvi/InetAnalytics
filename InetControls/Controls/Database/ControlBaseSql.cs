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
using System.Drawing;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using InetCrawler;
using InetCrawler.Database;
using InetCrawler.Database.Data;
using InetCrawler.Log;
using DotNetApi;
using DotNetApi.Windows.Controls;

namespace InetAnalytics.Controls.Database
{
	/// <summary>
	/// A generic control that allows a background SQL database operation.
	/// </summary>
	public class ControlBaseSql : ControlBase
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlBaseSql()
		{
		}

		// Protected methods.

		/// <summary>
		/// A method called when the execution of the database query starts.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="command">The database command.</param>
		protected virtual void OnQueryStarted(DbServerSql server, DbQuerySql query, DbCommand command) { }
		/// <summary>
		/// A method called when the execution of the database query succeeded and the data is raw.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="result">The result data.</param>
		/// <param name="recordsAffected">The number of records affected.</param>
		protected virtual void OnQuerySucceeded(DbServerSql server, DbQuerySql query, DbDataRaw result, int recordsAffected) { }
		/// <summary>
		/// A method called when the execution of the database query succeeded and the data is object.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="result">The result data.</param>
		/// <param name="recordsAffected">The number of records affected.</param>
		protected virtual void OnQuerySucceeded(DbServerSql server, DbQuerySql query, DbDataObject result, int recordsAffected) { }
		/// <summary>
		/// A method called when the executiopn of the database query has failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="exception">The exception.</param>
		protected virtual void OnQueryFailed(DbServerSql server, DbQuerySql query, Exception exception) { }
		/// <summary>
		/// A method called when the user cancels a current database query.
		/// </summary>
		/// <param name="query">The database query.</param>
		protected virtual void OnQueryCanceling(DbQuerySql query) { }

		/// <summary>
		/// Executes a database query.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		protected override void DatabaseQuery(DbServer server, DbQuery query)
		{
			// If the server is not an SQL server, do nothing.
			if (!(server is DbServerSql)) return;
			// If the query is not an SQL query, do nothing.
			if (!(query is DbQuerySql)) return;

			// Get the SQL server.
			DbServerSql serverSql = server as DbServerSql;
			// Get the SQL query.
			DbQuerySql querySql = query as DbQuerySql;

			// If the database server is not connected.
			if (serverSql.State != DbServerSql.ServerState.Connected)
			{
				// Connect to the database and pass the query as the user state.
				this.DatabaseConnect(serverSql, querySql);
				// Return.
				return;
			}

			// Else, create a database command that selects all items for the specified table.

			// Show a connecting message.
			this.ShowMessage(Resources.DatabaseBusy_48, "Database", querySql.MessageStart);
			// Create a new database command.
			DbCommand command = serverSql.CreateCommand(querySql);
			// Call the query start method.
			this.OnQueryStarted(serverSql, querySql, command);
			try
			{
				// Execute the command asynchronously.
				command.ExecuteReader((DbAsyncResult commandResult, DbReader reader) =>
				{
					try
					{
						// If the result has an exception, throw the exception.
						if (commandResult.Exception != null) throw commandResult.Exception;
						// Read the data asynchronously for the specified query.
						reader.Read(querySql, null, (DbAsyncResult readerResult, DbData result) =>
						{
							try
							{
								// Throw a reader exception, if any.
								if (readerResult.Exception != null)
								{
									reader.Close();
									throw readerResult.Exception;
								}
								// Get the number of records read.
								int recordsAffected = reader.RecordsAffected;
								// Close the reader.
								reader.Close();
								// Dispose and reset the command.
								command.Dispose();
								// Show a success message.
								this.ShowMessage(Resources.DatabaseSuccess_48, "Database", querySql.MessageFinishSuccess, false);
								// Wait.
								Thread.Sleep(CrawlerConfig.Static.ConsoleMessageCloseDelay);
								// Hide the message.
								this.HideMessage();
								// Call the completion method, depending on the type of data.
								if (querySql.Table != null)
									this.DatabaseQuerySuccess(serverSql, querySql, result as DbDataObject, recordsAffected);
								else
									this.DatabaseQuerySuccess(serverSql, querySql, result as DbDataRaw, recordsAffected);
							}
							catch (Exception exception)
							{
								// Dispose the command.
								command.Dispose();
								// Show an error message.
								this.ShowMessage(Resources.DatabaseError_48, "Database", querySql.MessageFinishFail, false);
								// Log the event.
								serverSql.LogEvent(
									LogEventLevel.Important,
									LogEventType.Error,
									"Executing query on the database server \'{0}\' failed. {1}",
									new object[] { serverSql.Name, exception.Message },
									exception);
								// Wait.
								Thread.Sleep(CrawlerConfig.Static.ConsoleMessageCloseDelay);
								// Hide the message.
								this.HideMessage();
								// Call the completion method.
								this.DatabaseQueryFail(serverSql, querySql, exception);
							}
						}, null);
					}
					catch (DbException exception)
					{
						// Dispose the command.
						command.Dispose();
						// Show an error message.
						this.ShowMessage(Resources.DatabaseError_48, "Database", "{0} {1}".FormatWith(querySql.MessageFinishFail, exception.InnerException.Message), false);
						// Log the event.
						serverSql.LogEvent(
							LogEventLevel.Important,
							LogEventType.Error,
							"Executing query on the database server \'{0}\' failed. {1}",
							new object[] { serverSql.Name, exception.Message },
							exception);
						// Wait.
						Thread.Sleep(CrawlerConfig.Static.ConsoleMessageCloseDelay);
						// Hide the message.
						this.HideMessage();
						// Call the completion method.
						this.DatabaseQueryFail(serverSql, querySql, exception);
					}
					catch (Exception exception)
					{
						// Dispose the command.
						command.Dispose();
						// Show an error message.
						this.ShowMessage(Resources.DatabaseError_48, "Database", querySql.MessageFinishFail, false);
						// Log the event.
						serverSql.LogEvent(
							LogEventLevel.Important,
							LogEventType.Error,
							"Executing query on the database server \'{0}\' failed. {1}",
							new object[] { serverSql.Name, exception.Message },
							exception);
						// Wait.
						Thread.Sleep(CrawlerConfig.Static.ConsoleMessageCloseDelay);
						// Hide the message.
						this.HideMessage();
						// Call the completion method.
						this.DatabaseQueryFail(serverSql, querySql, exception);
					}
				});
			}
			catch (Exception exception)
			{
				// Dispose the command.
				command.Dispose();
				// Show an error message.
				this.ShowMessage(Resources.DatabaseError_48, "Database", querySql.MessageFinishFail, false);
				// Log the event.
				serverSql.LogEvent(
					LogEventLevel.Important,
					LogEventType.Error,
					"Executing query on the database server \'{0}\' failed. {1}",
					new object[] { serverSql.Name, exception.Message },
					exception);
				// Wait.
				Thread.Sleep(CrawlerConfig.Static.ConsoleMessageCloseDelay);
				// Hide the message.
				this.HideMessage();
				// Call the completion method.
				this.DatabaseQueryFail(serverSql, querySql, exception);
			}
		}

		/// <summary>
		/// Cancels the specified command.
		/// </summary>
		/// <param name="command">The database command to cancel.</param>
		protected void DatabaseQueryCancel(DbCommand command)
		{
			// Cancel the command.
			command.Cancel();
			// Call the event handler.
			this.OnQueryCanceling(command.Query);
		}

		/// <summary>
		/// An event handler called when the database query completed successfully and the resulting data is raw
		/// data.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="result">The database result.</param>
		/// <param name="recordsAffected">The number of records read.</param>
		private void DatabaseQuerySuccess(DbServerSql server, DbQuerySql query, DbDataRaw result, int recordsAffected)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
			{
				this.OnQuerySucceeded(server, query, result, recordsAffected);
			});
		}

		/// <summary>
		/// An event handler called when the database query completed successfully and the resulting data is object
		/// data.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="result">The database result.</param>
		/// <param name="recordsAffected">The number of records affected.</param>
		private void DatabaseQuerySuccess(DbServerSql server, DbQuerySql query, DbDataObject result, int recordsAffected)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
			{
				this.OnQuerySucceeded(server, query, result, recordsAffected);
			});
		}

		/// <summary>
		/// An event handler called when the refresh operation failed.
		/// </summary>
		/// <param name="server">The database server.</param>
		/// <param name="query">The database query.</param>
		/// <param name="exception">The exception.</param>
		private void DatabaseQueryFail(DbServerSql server, DbQuerySql query, Exception exception)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
			{
				this.OnQueryFailed(server, query, exception);
			});
		}
	}
}
