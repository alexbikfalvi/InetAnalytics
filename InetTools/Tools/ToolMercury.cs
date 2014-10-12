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
using System.Drawing;
using System.Windows.Forms;
using InetCommon.Tools;
using InetTools.Controls.Mercury;
using InetTools.Tools.Mercury;

namespace InetTools.Tools
{
	/// <summary>
	/// A tool for the Mercury project.
	/// </summary>
	[ToolInfo(
		"EF0D8AA8-3DB8-4467-B6A6-7EABC12A9A53",
		1, 0, 0, 0,
		"Mercury",
		"A tool for the Mercury project."
		)]
	public sealed class ToolMercury : Tool
	{
		private readonly MercuryConfig config;
		private readonly ControlMercury control;
		private readonly MercuryRequest request = new MercuryRequest();

		/// <summary>
		/// Creates a new tool instance.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="toolset">The toolset information.</param>
		public ToolMercury(IToolApi api, ToolsetInfoAttribute toolset)
			: base(api, toolset)
		{
			// Create the configuration.
			this.config = new MercuryConfig(api);

			// Create the control.
			this.control = new ControlMercury(this.config);
		}

		#region Public properties.

		/// <summary>
		/// Gets the user interface control for this tool.
		/// </summary>
		public override Control Control { get { return this.control; } }
		/// <summary>
		/// Gets the user interface icon for this tool.
		/// </summary>
		public override Image Icon { get { return InetAnalytics.Resources.ToolboxGraph_16; } }

		#endregion

		#region Protected methods.

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

		#endregion
	}
}
