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
using Microsoft.Win32;
using DotNetApi;
using InetCrawler.Log;
using InetCrawler.Status;

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class allowing the communication of a tool with the host application.
	/// </summary>
	public sealed class ToolApi : IToolApi, IToolConfig
	{
		private readonly CrawlerApi api;
		private readonly ToolsetInfoAttribute toolset;
		private readonly ToolInfoAttribute tool;
		private readonly RegistryKey key;

		/// <summary>
		/// Creates a new tool API instance.
		/// </summary>
		/// <param name="api">The crawler API.</param>
		/// <param name="toolset">The toolset information.</param>
		/// <param name="tool">The tool information.</param>
		/// <param name="key">The registry key for this tool.</param>
		public ToolApi(CrawlerApi api, ToolsetInfoAttribute toolset, ToolInfoAttribute tool, RegistryKey key)
		{
			// Check the arguments.
			if (null == api) throw new ArgumentNullException("api");
			if (null == toolset) throw new ArgumentNullException("toolset");
			if (null == tool) throw new ArgumentNullException("tool");
			if (null == key) throw new ArgumentNullException("key");

			// Set the parameters.
			this.api = api;
			this.toolset = toolset;
			this.tool = tool;
			this.key = key;
		}

		// Configuration.

		/// <summary>
		/// Gets the Registry key.
		/// </summary>
		public RegistryKey Key { get { return this.key; } }
		/// <summary>
		/// Gets the tool configuration.
		/// </summary>
		public IToolConfig Config { get { return this; } }
		/// <summary>
		/// Gets the crawler status.
		/// </summary>
		public CrawlerStatus Status { get { return this.api.Status; } }
		/// <summary>
		/// Gets the notification message close delay.
		/// </summary>
		public TimeSpan MessageCloseDelay { get { return this.api.Config.ConsoleMessageCloseDelay; } }

		// Log.

		/// <summary>
		/// Logs an event for the specified toolset.
		/// </summary>
		/// <param name="level">The log event level.</param>
		/// <param name="type">The log event type.</param>
		/// <param name="message">The event message.</param>
		/// <param name="parameters">The event parameters.</param>
		/// <param name="exception">The event exception.</param>
		public LogEvent Log(LogEventLevel level, LogEventType type, string message, object[] parameters = null, Exception exception = null)
		{
			return this.api.Log.Add(
				level,
				type,
				@"Toolbox\{0}\{1}".FormatWith(this.toolset.Name, this.tool.Name),
				message,
				parameters,
				exception
				);
		}
	}
}
