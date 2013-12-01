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
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;
using InetAnalytics.Controls.PlanetLab;
using InetCrawler;

namespace InetAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog that displays the information of a PlanetLab object.
	/// </summary>
	public partial class FormObjectProperties<T> : ThreadSafeForm where T : ControlObjectProperties, new()
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormObjectProperties()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set an object changed event handler.
			this.controlPlanetLab.ObjectChanged += this.OnObjectChanged;

			// Set the font.
			Window.SetFont(this);
		}

		// Public events.

		/// <summary>
		/// An event raised when the current object has changed.
		/// </summary>
		public event EventHandler ObjectChanged;

		// Public properties.

		/// <summary>
		/// Gets the current PlanetLab object.
		/// </summary>
		public PlObject Object { get { return this.controlPlanetLab.Object; } }

		// Public methods.

		/// <summary>
		/// Shows the form as a dialog with the specified PlanetLab object.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="title">The window title.</param>
		/// <param name="id">The PlanetLab object ID.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, string title, int id)
		{
			// Set the PlanetLab object to null.
			this.controlPlanetLab.Object = null;
			// Updated the PlanetLab object.
			this.controlPlanetLab.Update(id);
			// Set the title.
			this.Text = "{0} {1} Properties".FormatWith(title, id);
			// Open the dialog.
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// Shows the form as a dialog and the specified PlanetLab object.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="title">The window title.</param>
		/// <param name="obj">The PlanetLab object.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, string title, PlObject obj)
		{
			// If the site is null, do nothing.
			if (null == obj) return DialogResult.Abort;

			// Set the PlanetLab site.
			this.controlPlanetLab.Object = obj;
			// Set the title.
			this.Text = "{0} {1} Properties".FormatWith(title, obj.Id.HasValue ? obj.Id.Value.ToString() : "(unknown)");
			// Open the dialog.
			return base.ShowDialog(owner);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the PlanetLab object has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnObjectChanged(object sender, EventArgs e)
		{
			// Raise the event.
			if (null != this.ObjectChanged) this.ObjectChanged(sender, e);
		}
	}
}
