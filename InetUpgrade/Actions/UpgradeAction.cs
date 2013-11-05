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

namespace InetUpgrade.Actions
{
	/// <summary>
	/// An abstract class representing the upgrade action.
	/// </summary>
	public abstract class UpgradeAction
	{
		// Public events.

		/// <summary>
		/// An event raised when the action progersses.
		/// </summary>
		public event UpgradeActionEventHandler Progress;

		// Public methods.

		/// <summary>
		/// Executes the action.
		/// </summary>
		public abstract void Execute();

		// Protected methods.

		/// <summary>
		/// An event handler called when the action progresses.
		/// </summary>
		/// <param name="message">The message.</param>
		protected virtual void OnProgress(string message)
		{
			// Raise the event.
			if (null != this.Progress) this.Progress(this, new UpgradeActionEventArgs(message));
		}
	}
}
