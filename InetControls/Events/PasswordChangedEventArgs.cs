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
using System.Security;

namespace InetControls.Events
{
	/// <summary>
	/// A delegate representing a password changed event handler.
	/// </summary>
	/// <param name="sender">The sender object.</param>
	/// <param name="e">The event arguments.</param>
	public delegate void PasswordChangedEventHandler(object sender, PasswordChangedEventArgs e);

	/// <summary>
	/// A class representing a password changed event argument.
	/// </summary>
	public class PasswordChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Creates a new event instance.
		/// </summary>
		/// <param name="oldPassword">The old password.</param>
		/// <param name="newPassword">The new password.</param>
		/// <param name="state">The user state.</param>
		public PasswordChangedEventArgs(SecureString oldPassword, SecureString newPassword, object state)
		{
			this.OldPassword = oldPassword;
			this.NewPassword = newPassword;
			this.State = state;
		}
		
		/// <summary>
		/// Gets the old password.
		/// </summary>
		public SecureString OldPassword { get; private set; }
		/// <summary>
		/// Gets the new password.
		/// </summary>
		public SecureString NewPassword { get; private set; }
		/// <summary>
		/// Gets the user state.
		/// </summary>
		public object State { get; private set; }
	}
}
