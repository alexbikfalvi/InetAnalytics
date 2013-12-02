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
using System.Drawing;
using System.Windows.Forms;
using InetCrawler.PlanetLab;

namespace InetAnalytics.Controls.PlanetLab.Commands
{
	/// <summary>
	/// An image list box control.
	/// </summary>
	public sealed class CommandListBox : ListBox
	{
		private static readonly Image[] icons = {
													Resources.ScriptSuccess_32,
													Resources.ScriptWarning_32,
													Resources.ScriptError_32
												};

		/// <summary>
		/// Creates a new image list box instance.
		/// </summary>
		public CommandListBox()
		{
			// Set the object properties.
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.ItemHeight = 48;
			this.IntegralHeight = false;
		}

		// Public events.

		/// <summary>
		/// An event raised when the user activates an item.
		/// </summary>
		//public event ImageListBoxItemActivateEventHandler ItemActivate;

		// Public methods.

		/// <summary>
		/// Adds a new item to the image list box.
		/// </summary>
		/// <param name="text">The item text.</param>
		/// <param name="image">The item image.</param>
		public void AddItem(PlCommand command)
		{
			// Create a new command list box item.
			CommandListBoxItem item = new CommandListBoxItem(command);

			// Add the item to the list box.
			this.Items.Add(item);
		}

		// Protected methods.

		/// <summary>
		/// Draws the image list box item.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			// Call the base class method.
			base.OnDrawItem(e);

			// If the index is outside the item count, do nothing.
			if ((e.Index < 0) || (e.Index >= this.Items.Count)) return;

			// Get the image list box item.
			CommandListBoxItem item = this.Items[e.Index] as CommandListBoxItem;

			Rectangle rectText = new Rectangle(
				e.Bounds.Left + 48,
				e.Bounds.Top,
				e.Bounds.Width - 56,
				e.Bounds.Height);

			Rectangle rectImage = new Rectangle(
				e.Bounds.Left + 8,
				e.Bounds.Top + 8,
				32,
				32);

			//// Draw the image.
			//if (null != item.Image)
			//{
			//	e.Graphics.DrawImage(item.Image, rectImage);
			//}

			//using (Brush brush = new SolidBrush(e.BackColor))
			//{
			//	// Draw a background rectangle.
			//	e.Graphics.FillRectangle(brush, e.Bounds);
			//}

			//// Draw the text
			//if (null != item.Text)
			//{
			//	TextRenderer.DrawText(
			//		e.Graphics,
			//		item.Text,
			//		this.Font,
			//		rectText,
			//		e.ForeColor,
			//		TextFormatFlags.EndEllipsis | TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
			//}
		}

		///// <summary>
		///// An event handler called when the user double click on an item.
		///// </summary>
		///// <param name="e">The event arguments.</param>
		//protected override void OnDoubleClick(EventArgs e)
		//{
		//	// Call the base class method.
		//	base.OnDoubleClick(e);
		//	// Activate the selected item.
		//	if ((this.SelectedItem != null) && (this.ItemActivate != null))
		//	{
		//		this.ItemActivate(this, new ImageListBoxItemActivateEventArgs(this.SelectedItem as ImageListBoxItem));
		//	}
		//}
	}
}
