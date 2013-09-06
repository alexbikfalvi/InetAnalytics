/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using System.IO;
using System.Threading;
using System.Xml.Linq;
using DotNetApi;

namespace YtCrawler.Log
{
	/// <summary>
	/// A class representing an event log.
	/// </summary>
	public sealed class Logger : IDisposable
	{
		private string filePattern;

		private Dictionary<DateTime, XDocument> logs = new Dictionary<DateTime,XDocument>(); // The set of log files.

		private Mutex mutex = new Mutex(); // Synchronization mutex.

		/// <summary>
		///  Creates a new logger instance.
		/// </summary>
		/// <param name="fileName">The log file name.</param>
		public Logger(string fileName)
		{
			// Save the file name.
			this.filePattern = fileName;
		}
		
		// Public events.

		public event LogEventHandler EventLogged;

		// Public methods.

		/// <summary>
		/// Closes the logger and saves all open logs to file.
		/// </summary>
		public void Dispose()
		{
			// Wait for exclusive access to the log.
			this.mutex.WaitOne();

			try
			{
				string fileName;
				// Save the log to the file.
				foreach (XDocument xml in logs.Values)
				{
					try
					{
						// Get the XML date.
						DateTime date = DateTime.Parse(xml.Root.Attribute(XName.Get("date")).Value);
						// Set the file name.
						fileName = this.filePattern.FormatWith(date.Year, date.Month, date.Day);
						// Save the XML file.
						xml.Save(fileName);
					}
					catch (Exception) { }
				}
			}
			finally
			{
				// Release the exclusive access to the log.
				this.mutex.ReleaseMutex();
			}

			// Dispose the mutex.
			this.mutex.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Adds a new event to the event log for the current date/time.
		/// </summary>
		/// <param name="level">The log event level.</param>
		/// <param name="type">The log event type.</param>
		/// <param name="source">The event source.</param>
		/// <param name="message">The event message.</param>
		/// <param name="parameters">The event parameters.</param>
		/// <param name="exception">The event exception.</param>
		/// <param name="subevents">The list of subevents.</param>
		/// <returns>The log event.</returns>
		public LogEvent Add(
			LogEventLevel level,
			LogEventType type,
			string source,
			string message,
			object[] parameters = null,
			Exception exception = null,
			List<LogEvent> subevents = null
			)
		{
			LogEvent evt;

			// Wait for exclusive access to the log.
			this.mutex.WaitOne();

			try
			{
				// Create the event.
				evt = new LogEvent(level, type, DateTime.Now, source, message, parameters, exception, subevents);

				// Compute the file name.
				string fileName = string.Format(this.filePattern, evt.Timestamp.ToUniversalTime().Year, evt.Timestamp.ToUniversalTime().Month, evt.Timestamp.ToUniversalTime().Day);

				try
				{
					XDocument xml;
					// Check whether there exists a file for the event date.
					if (!this.logs.TryGetValue(evt.Timestamp.Date, out xml))
					{
						// If the file exists.
						if (File.Exists(fileName))
						{
							// Read the XML from the file.
							try { xml = XDocument.Load(fileName); }
							catch (Exception) { xml = new XDocument(new XElement("log", new XAttribute("date", evt.Timestamp.ToUniversalTime().Date))); }
						}
						else
						{
							// Create a new empty XML.
							xml = new XDocument(new XElement("log", new XAttribute("date", evt.Timestamp.ToUniversalTime().Date)));
						}
						// Add the XML to the logs list.
						this.logs.Add(evt.Timestamp.Date, xml);
					}
					// Add the event to the XML file.
					xml.Root.Add(evt.Xml);
				}
				catch (Exception ex)
				{
					evt.Logger = string.Format("Could not save the event {0} to the log \"{1}\" ({2}).", evt.Timestamp, fileName, ex.Message);
				}
			}
			finally
			{
				// Release the exclusive access to the log.
				this.mutex.ReleaseMutex();
			}

			// Raise the event for this log event.
			if (this.EventLogged != null) this.EventLogged(this, new LogEventArgs(evt));

			return evt;
		}

		/// <summary>
		/// Reads a day of log events into memory.
		/// </summary>
		/// <param name="date"></param>
		public void Read(DateTime date)
		{
			// Wait for exclusive access to the log.
			this.mutex.WaitOne();

			try
			{
				XDocument xml;
				// If the specified date already exists in memory, do nothing.
				if (this.logs.TryGetValue(date.Date, out xml)) return;
				// Else, compute the file name.
				string fileName = string.Format(this.filePattern, date.Year, date.Month, date.Day);
				// If the file exists.
				if (File.Exists(fileName))
				{
					// Try and read the XML from the file.
					try { xml = XDocument.Load(fileName); }
					catch (Exception) { }
					// Add the XML to the logs list.
					this.logs.Add(date.Date, xml);
				}
			}
			finally
			{
				// Release the exclusive access to the log.
				this.mutex.ReleaseMutex();
			}
		}

		/// <summary>
		/// Reads a range of log events into memory.
		/// </summary>
		/// <param name="start">The start date.</param>
		/// <param name="end">The end date.</param>
		public void Read(DateTime start, DateTime end)
		{
			// Read the log for for all dates in the specified range.
			for (DateTime date = start; date <= end; date += TimeSpan.FromDays(1.0))
			{
				this.Read(date);
			}
		}

		/// <summary>
		/// Gets the list of log events for a particular date
		/// </summary>
		/// <param name="date">The date.</param>
		/// <returns>A collection of log events.</returns>
		public ICollection<LogEvent> Get(DateTime date)
		{
			// Create a new list.
			List<LogEvent> list = new List<LogEvent>();
			// Get the log events for the specified date.
			this.Get(date, list);
			// Return the list.
			return list;
		}

		/// <summary>
		/// Gets the list of log events for a particular date range.
		/// </summary>
		/// <param name="start">The start date.</param>
		/// <param name="end">The end date.</param>
		/// <returns>A collection of log events.</returns>
		public List<LogEvent> Get(DateTime start, DateTime end)
		{
			// Create a new list.
			List<LogEvent> list = new List<LogEvent>();
			// Get the log events for the specified range.
			for (DateTime date = start; date <= end; date += TimeSpan.FromDays(1.0))
				this.Get(date, list);
			// Return the list.
			return list;
		}

		// Private methods.

		/// <summary>
		/// Appends the log events for the specified date to a given list.
		/// </summary>
		/// <param name="date">The date.</param>
		/// <param name="events">The list.</param>
		private void Get(DateTime date, List<LogEvent> list)
		{
			// Wait for exclusive access to the log.
			this.mutex.WaitOne();

			try
			{
				XDocument xml;
				// If the specified day exists in the log.
				if (this.logs.TryGetValue(date.Date, out xml))
				{
					// Add the events to the list.
					foreach (XElement element in xml.Root.Elements("event"))
						list.Add(new LogEvent(element));
				}
			}
			finally
			{
				// Release the exclusive access to the log.
				this.mutex.ReleaseMutex();
			}
		}
	}
}
