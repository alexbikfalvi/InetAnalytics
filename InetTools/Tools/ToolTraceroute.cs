/* 
 * Copyright (C) 2013-2014 Alex Bikfalvi
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
using System.Windows.Forms;
using InetCrawler.Tools;
using InetTools.Controls.Net;
using InetTools.Tools.Net;

namespace InetTools.Tools
{
	/// <summary>
	/// Creates a new web client tool.
	/// </summary>
	[ToolInfo(
		"BA934943-DF09-476F-AF41-A1DF17A7EEC5",
		1, 0, 0, 0,
		"Internet Traceroute",
		"An Internet traceroute tool."
		)]
	public sealed class ToolTraceroute : Tool
	{
		private readonly ControlTraceroute control;
		private readonly TracerouteConfig config;

		/// <summary>
		/// Creates a new tool instance.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="toolset">The toolset information.</param>
		public ToolTraceroute(IToolApi api, ToolsetInfoAttribute toolset)
			: base(api, toolset)
		{
			// Create the configuration.
			this.config = new TracerouteConfig(api);

			// Initialize the control.
			this.control = new ControlTraceroute(this.config);
		}

		// Public properties.

		/// <summary>
		/// Gets the user interface control for this tool.
		/// </summary>
		public override Control Control { get { return this.control; } }

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose the control.
				this.control.Dispose();
			}

			// Call the base class method.
			base.Dispose(disposing);
		}
	}
}
