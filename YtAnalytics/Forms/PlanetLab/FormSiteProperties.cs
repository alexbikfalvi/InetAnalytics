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
using System.Security;
using System.Windows.Forms;
using PlanetLab.Api;
using DotNetApi.Windows;

using YtCrawler;

namespace YtAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog that displays the information of a PlanetLab site.
	/// </summary>
	public partial class FormSiteProperties : Form
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormSiteProperties()
		{
			InitializeComponent();

			// Set the font.
			Formatting.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog with the specified PlanetLab site.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="id">The PlanetLab site ID.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, int id)
		{
			// Set the PlanetLab site to null.
			this.controlSite.PlanetLabSite = null;
			// Set the PlanetLab site.
			this.controlSite.UpdateSite(id);
			// Set the title.
			this.Text = string.Format("Site {0} Properties", id);
			// Open the dialog.
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// Shows the form as a dialog with the specified PlanetLab site.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="site">The PlanetLab site.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, PlSite site)
		{
			// If the site is null, do nothing.
			if (null == site) return DialogResult.Abort;

			// Set the PlanetLab site.
			this.controlSite.PlanetLabSite = site;
			// Set the title.
			this.Text = string.Format("Site {0} Properties", site.SiteId);
			// Open the dialog.
			return base.ShowDialog(owner);
		}
	}
}
