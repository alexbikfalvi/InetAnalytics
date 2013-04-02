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
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YtAnalytics.Controls.YouTube
{
	/// <summary>
	/// A control that allows browsing through YouTube video standard feeds.
	/// </summary>
	public partial class ControlStandardFeeds : UserControl
	{
		/// <summary>
		/// An enumeration representing the selection level.
		/// </summary>
		private enum SelectionLevel
		{
			Feeds = 0,
			Feed = 1,
			Time = 2,
			Category = 3,
			Region = 4
		};

		private struct NavigationButton
		{
		}

		private struct ItemButton
		{
		}

		private int buttonItemHeight = 48;		// The height of the item button.
		private int buttonScrollHeight = 12;	// The height of the scroll button.
		private int legendHeight = 23;			// The height of the legend.

		private Color colorNavigationOuterBorder = ProfessionalColors.MenuBorder;
		private Color colorNavigationInnerBorder = Color.FromArgb(250, 252, 254);
		private Color colorNavigationFill = Color.FromArgb(248, 250, 253);
		private Color colorNavigationItemOuterBorder = Color.FromArgb(60, 127, 177);
		//private Color colorNavigationItemInnerBorder = C

		private Rectangle rectNavigationOuterBorder = new Rectangle();
		private Rectangle rectNavigationInnerBorder = new Rectangle();

		private SelectionLevel selectionLevel = SelectionLevel.Feeds;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlStandardFeeds()
		{
			InitializeComponent();

			// Set the padding.
			this.Padding = new Padding(3);

			// Set the heights.
			this.rectNavigationOuterBorder.Height = 20;
			this.rectNavigationInnerBorder.Height = this.rectNavigationOuterBorder.Height - 2;
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the height of the navigation bar.
		/// </summary>
		public int NavigationBarHeight
		{
			get { return this.rectNavigationOuterBorder.Height; }
			set
			{
				this.rectNavigationOuterBorder.Height = value;
				this.rectNavigationInnerBorder.Height = value - 2;
				this.Refresh();
			}
		}

		// Public methods.

		// Private methods.

		/// <summary>
		/// An event handler called when painting the control.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPaint(object sender, PaintEventArgs e)
		{
			// Create the pen.
			using(Pen pen = new Pen(this.colorNavigationOuterBorder))
			{
				e.Graphics.DrawRectangle(pen, this.rectNavigationOuterBorder);
				pen.Color = this.colorNavigationInnerBorder;
				e.Graphics.DrawRectangle(pen, this.rectNavigationInnerBorder);
			}

			/*
			Rectangle rectNavigationInner = new Rectangle(
				rectNavigationOuter.X + 2,
				rectNavigationOuter.Y + 2,
				rectNavigationOuter.Width - 3,
				rectNavigationOuter.Height - 3
				);
			LinearGradientBrush brushGradientBlue = new LinearGradientBrush(rectNavigationInner, Color.Black, Color.Black, LinearGradientMode.Vertical);
			ColorBlend colorBlendBlue = new ColorBlend(4);
			colorBlendBlue.Colors = new Color[] { 
				Color.FromArgb(232, 246, 253),
				Color.FromArgb(215, 239, 252),
				Color.FromArgb(186, 228, 252),
				Color.FromArgb(166, 217, 244)
			};
			colorBlendBlue.Positions = new float[] { 0.0f, 0.45f, 0.55f, 1.0f };
			brushGradientBlue.InterpolationColors = colorBlendBlue;
			// Draw the navigation bar.
			//e.Graphics.FillRectangle(brushGradientBlue, rectNavigationInner);
			 * */
		}

		/// <summary>
		/// An event handler called when resizing the control.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnResize(object sender, EventArgs e)
		{
			this.rectNavigationOuterBorder.X = this.ClientRectangle.X + this.Padding.Left;
			this.rectNavigationOuterBorder.Y = this.ClientRectangle.Y + this.Padding.Top;
			this.rectNavigationOuterBorder.Width = this.ClientRectangle.Width - this.Padding.Left - this.Padding.Right - 1;

			this.rectNavigationInnerBorder.X = this.rectNavigationOuterBorder.X + 1;
			this.rectNavigationInnerBorder.Y = this.rectNavigationOuterBorder.Y + 1;
			this.rectNavigationInnerBorder.Width = this.rectNavigationOuterBorder.Width - 2;
		}
	}
}
