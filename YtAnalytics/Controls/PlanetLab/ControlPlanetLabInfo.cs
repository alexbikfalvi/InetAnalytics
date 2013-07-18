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
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using YtCrawler;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that displays the PlanetLab introduction and configuration.
	/// </summary>
	public partial class ControlPlanetLabInfo : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabInfo()
		{
			// Initialize component.
			InitializeComponent();
			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// An event raised when the user selects the sites link.
		/// </summary>
		public event EventHandler ClickSites;

		// Public methods.

		/// <summary>
		/// Initializes the control with the specified crawler object.
		/// </summary>
		/// <param name="crawler">The crawler.</param>
		public void Initialize(Crawler crawler)
		{
			// Set the settings crawler.
			this.settings.Crawler = crawler;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user selects the nodes link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodesClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickSites) this.ClickSites(this, e);
		}
	}
}
