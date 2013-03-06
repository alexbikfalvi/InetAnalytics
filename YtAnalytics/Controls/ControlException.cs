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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtAnalytics.Forms;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A control that displays an exception.
	/// </summary>
	public partial class ControlException : UserControl
	{
		private Exception exception = null;

		private FormException formException = null;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlException()
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
				this.exception = value;
				if (null == value)
				{
					this.labelException.Text = "No exception";
					this.textBoxType.Text = string.Empty;
					this.textBoxMessage.Text = string.Empty;
					this.textBoxSource.Text = string.Empty;
					this.textBoxTarget.Text = string.Empty;
					this.textBoxStack.Text = string.Empty;
					this.linkLabelInner.Text = "None";
					this.linkLabelInner.Enabled = false;
				}
				else
				{
					this.labelException.Text = value.GetType().ToString();
					this.textBoxType.Text = value.GetType().ToString();
					this.textBoxMessage.Text = value.Message;
					this.textBoxSource.Text = value.Source;
					this.textBoxTarget.Text = value.TargetSite != null ? value.TargetSite.ToString() : string.Empty;
					this.textBoxStack.Text = value.StackTrace;
					if (value.InnerException != null)
					{
						this.linkLabelInner.Text = value.InnerException.GetType().ToString();
						this.linkLabelInner.Enabled = true;
					}
					else
					{
						this.linkLabelInner.Text = "None";
						this.linkLabelInner.Enabled = false;
					}
				}
				this.linkLabelInner.Width = this.linkLabelInner.PreferredWidth + 20;
				this.linkLabelInner.Height = this.linkLabelInner.PreferredHeight > 16 ? this.linkLabelInner.PreferredHeight : 16;

				this.tabControl.SelectedTab = this.tabPageGeneral;
				this.textBoxType.Select();
				this.textBoxType.SelectionStart = 0;
				this.textBoxType.SelectionLength = 0;
			}
		}

		/// <summary>
		/// An event handler called when the inner exception link label is clicked;
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInnerExceptionClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null == this.exception.InnerException) return;
			if (null == this.formException)
				this.formException = new FormException();
			this.formException.ShowDialog(this, this.exception.InnerException);
		}
	}
}
