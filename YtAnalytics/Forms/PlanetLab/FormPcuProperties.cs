﻿/* 
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
using PlanetLab.Api;
using DotNetApi.Windows;

using YtCrawler;

namespace YtAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog that displays the information of a PlanetLab PCU.
	/// </summary>
	public partial class FormPcuProperties : Form
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormPcuProperties()
		{
			InitializeComponent();

			// Set the font.
			Formatting.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog with the specified PlanetLab PCU.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="id">The PlanetLab PCU ID.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, int id)
		{
			// Set the PlanetLab PCU to null.
			this.controlPcu.PlanetLabPcu = null;
			// Updated the PlanetLab PCU.
			this.controlPcu.UpdatePcu(id);
			// Set the title.
			this.Text = string.Format("PCU {0} Properties", id);
			// Open the dialog.
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// Shows the form as a dialog and the specified PlanetLab PCU.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="pcu">The PlanetLab node.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, PlPcu pcu)
		{
			// If the site is null, do nothing.
			if (null == pcu) return DialogResult.Abort;

			// Set the PlanetLab site.
			this.controlPcu.PlanetLabPcu = pcu;
			// Set the title.
			this.Text = string.Format("PCU {0} Properties", pcu.PcuId);
			// Open the dialog.
			return base.ShowDialog(owner);
		}
	}
}
