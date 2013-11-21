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
using DotNetApi.Windows.Controls;
using InetCrawler;

namespace InetAnalytics.Controls.Tools
{
	/// <summary>
	/// A control that displays the toolbox introduction and configuration.
	/// </summary>
	public partial class ControlToolboxInfo : ThemeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlToolboxInfo()
		{
			// Initialize component.
			InitializeComponent();
			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		// Public methods.

		/// <summary>
		/// Initializes the control with the specified crawler object.
		/// </summary>
		/// <param name="crawler">The crawler.</param>
		/// <param name="treeNode">The root tree node.</param>
		/// <param name="controls">The controls collection.</param>
		public void Initialize(Crawler crawler, TreeNode treeNode, Control.ControlCollection controls)
		{
			// Initialize the settings.
			this.settings.Initialize(crawler, treeNode, controls);
		}
	}
}
