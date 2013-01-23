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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YtAnalytics.Forms
{
	/// <summary>
	/// A form that displays an image.
	/// </summary>
	public partial class FormImage : Form
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormImage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Shows the dialog with the specified image.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="title">The title.</param>
		/// <param name="image">The image.</param>
		public void Show(IWin32Window owner, string title, Image image)
		{
			this.ClientSize = image.Size;
			this.Text = title;
			this.pictureBox.Image = image;
			base.ShowDialog();
		}
	}
}
