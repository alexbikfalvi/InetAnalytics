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
using DotNetApi.Windows.Controls;
using InetCrawler.PlanetLab;

namespace InetAnalytics.Controls.Database
{
	/// <summary>
	/// A control that receives input to add a PlanetLab command.
	/// </summary>
	public partial class ControlAddCommand : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddCommand()
		{
			// Initialize the components.
			this.InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the current command.
		/// </summary>
		public PlCommand Command
		{
			get { return this.controlCommand.Command; }
			set { this.controlCommand.Command = value; }
		}
	}
}
