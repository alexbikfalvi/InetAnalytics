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
using YtAnalytics.Events;
using PlanetLab.Api;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that receives user input data to add a new PlanetLab slice.
	/// </summary>
	public partial class ControlAddSlice : ControlRequest
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddSlice()
		{
			// Initialize the component.
			this.InitializeComponent();
		}

		// Public events.

		/// <summary>
		/// An event raised when a PlanetLab operation has started.
		/// </summary>
		public event EventHandler RequestStarted;
		/// <summary>
		/// An event raised when a PlanetLab operation has finished.
		/// </summary>
		public event EventHandler RequestFinished;
		/// <summary>
		/// An event raised when a PlanetLab site was selected.
		/// </summary>
		public event PlanetLabObjectEventHandler<PlSite> Selected;
		/// <summary>
		/// An event raised when user closes the selection.
		/// </summary>
		public event EventHandler Closed;

		// Public methods.



		// Private methods.
	}
}
