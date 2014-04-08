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
using InetCommon.Forms;

namespace InetCommon.Controls
{
	/// <summary>
	/// A control that displays an exception.
	/// </summary>
	public partial class ControlExceptionProperties : ThreadSafeControl
	{
		private Exception exception = null;

		private FormExceptionProperties formException = null;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlExceptionProperties()
		{
			InitializeComponent();
			this.linkLabelInner.Width = this.linkLabelInner.PreferredWidth + 20;
			this.linkLabelInner.Height = this.linkLabelInner.PreferredHeight > 16 ? this.linkLabelInner.PreferredHeight : 16;
		}

		/// <summary>
		/// Gets or sets the current exception.
		/// </summary>
		public Exception Exception
		{
			get { return this.exception; }
			set
			{
				// Save the old value.
				Exception old = this.exception;
				// Set the new exception.
				this.exception = value;
				// Call the event handler.
				this.OnExceptionSet(old, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new exception has been set.
		/// </summary>
		/// <param name="oldException">The old exception.</param>
		/// <param name="newException">The new exception.</param>
		protected virtual void OnExceptionSet(Exception oldException, Exception newException)
		{
			// If the exception has not changed, do nothing.
			if (oldException == newException) return;

			if (null == newException)
			{
				this.labelException.Text = "No exception selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelException.Text = newException.GetType().ToString();
				this.textBoxType.Text = newException.GetType().ToString();
				this.textBoxMessage.Text = newException.Message;
				this.textBoxSource.Text = newException.Source;
				this.textBoxTarget.Text = newException.TargetSite != null ? newException.TargetSite.ToString() : string.Empty;
				this.textBoxStack.Text = newException.StackTrace;
				if (newException.InnerException != null)
				{
					this.linkLabelInner.Text = newException.InnerException.GetType().ToString();
					this.linkLabelInner.Enabled = true;
				}
				else
				{
					this.linkLabelInner.Text = "None";
					this.linkLabelInner.Enabled = false;
				}
				this.tabControl.Visible = true;
			}
			this.linkLabelInner.Width = this.linkLabelInner.PreferredWidth + 20;
			this.linkLabelInner.Height = this.linkLabelInner.PreferredHeight > 16 ? this.linkLabelInner.PreferredHeight : 16;

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxType.Select();
				this.textBoxType.SelectionStart = 0;
				this.textBoxType.SelectionLength = 0;
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the inner exception link label is clicked;
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInnerExceptionClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null == this.exception.InnerException) return;
			if (null == this.formException)
				this.formException = new FormExceptionProperties();
			this.formException.ShowDialog(this, this.exception.InnerException);
		}
	}
}
