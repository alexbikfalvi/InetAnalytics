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
using PlanetLab.Api;
using DotNetApi.Windows;

using YtCrawler;

namespace YtAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog that displays the information of a PlanetLab site.
	/// </summary>
	public partial class FormNodeProperties : Form
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormNodeProperties()
		{
			InitializeComponent();

			// Set the font.
			Formatting.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog with the specified PlanetLab node.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="id">The PlanetLab node ID.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, int id)
		{
			// Set the PlanetLab node to null.
			this.controlNode.PlanetLabNode = null;
			// Updated the PlanetLab node.
			this.controlNode.UpdateNode(id);
			// Set the title.
			this.Text = string.Format("Node {0} Properties", id);
			// Open the dialog.
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// Shows the form as a dialog and the specified PlanetLab node.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="node">The PlanetLab node.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, PlNode node)
		{
			// If the site is null, do nothing.
			if (null == node) return DialogResult.Abort;

			// Set the PlanetLab site.
			this.controlNode.PlanetLabNode = node;
			// Set the title.
			this.Text = string.Format("Node {0} Properties", node.NodeId);
			// Open the dialog.
			return base.ShowDialog(owner);
		}
	}
}
