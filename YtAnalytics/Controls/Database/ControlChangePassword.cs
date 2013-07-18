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
using DotNetApi.Windows.Controls;
using YtCrawler.Database;

namespace YtAnalytics.Controls.Database
{
	/// <summary>
	/// A control that receives user input to change the password.
	/// </summary>
	public partial class ControlChangePassword : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlChangePassword()
		{
			InitializeComponent();
		}

		/// <summary>
		/// An event raised when the input has changed.
		/// </summary>
		public event EventHandler InputChanged;

		/// <summary>
		/// Gets the old password.
		/// </summary>
		public SecureString Old { get { return this.textBoxOld.SecureText; } }

		/// <summary>
		/// Gets the new password.
		/// </summary>
		public SecureString New { get { return this.textBoxNew.SecureText; } }

		/// <summary>
		/// Gets the confirmed new password.
		/// </summary>
		public SecureString Confirm { get { return this.textBoxConfirm.SecureText; } }

		/// <summary>
		/// Clears the current settings.
		/// </summary>
		public void Clear()
		{
			this.textBoxOld.Clear();
			this.textBoxNew.Clear();
			this.textBoxConfirm.Clear();
		}

		/// <summary>
		/// Selects the current control.
		/// </summary>
		public new void Select()
		{
			base.Select();
			this.textBoxOld.Select();
			this.textBoxOld.SelectionStart = 0;
			this.textBoxOld.SelectionLength = 0;
		}

		/// <summary>
		/// An event handler called when the input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			if (this.InputChanged != null) this.InputChanged(sender, e);
		}
	}
}
