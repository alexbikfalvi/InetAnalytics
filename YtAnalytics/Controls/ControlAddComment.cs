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

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A control that receives user input data to add a video comment.
	/// </summary>
	public partial class ControlAddComment : UserControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddComment()
		{
			InitializeComponent();
		}

		/// <summary>
		/// An event raised when the input has changed.
		/// </summary>
		public event EventHandler InputChanged;

		/// <summary>
		/// Gets or sets the object ID.
		/// </summary>
		public string Object
		{
			get { return this.textBoxObject.Text; }
			set { this.textBoxObject.Text = value; }
		}

		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		public string User
		{
			get { return this.textBoxUser.Text; }
			set { this.textBoxUser.Text = value; }
		}

		/// <summary>
		/// Gets or sets the comment text.
		/// </summary>
		public new string Text
		{
			get { return this.textBoxText.Text; }
			set { this.textBoxText.Text = value; }
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
