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
using System.Windows.Forms;
using InetCrawler.Tools;
using InetTools.Controls;

namespace InetTools.Tools
{
	/// <summary>
	/// A tool that collects the top web sites from the Alexa ranking.
	/// </summary>
	[ToolInfo(
		"24654A51-339D-4C75-A60C-559388B5AFCB",
		1, 0, 0, 0,
		"Alexa Top Sites",
		"A tool that collects the top web sites from the Alexa ranking."
		)]
	public sealed class ToolAlexaTopSites : Tool
	{
		private readonly ControlAlexaTopSites control;

		/// <summary>
		/// Creates a new tool instance.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="toolset">The toolset information.</param>
		public ToolAlexaTopSites(IToolApi api, ToolsetInfoAttribute toolset)
			: base(api, toolset)
		{
			// Create the control.
			this.control = new ControlAlexaTopSites(api);
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
			// Call the base clas method.
			base.Dispose(disposing);
		}
	}
}
