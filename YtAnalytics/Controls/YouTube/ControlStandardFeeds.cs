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
		/// An enumeration representing the navigation level.
		/// </summary>
		private enum NavigationLevel
		{
			Feeds = 1,
			Feed = 2,
			Time = 3,
			Category = 4,
			Region = 5
		};

		/// <summary>
		/// A class representing a navigation button.
		/// </summary>
		private class NavigationButton
		{
			public enum NavigationButtonState
			{
				Normal = 0,
				Highlighted = 1,
				Pressed = 2
			}

			/// <summary>
			/// Creates a new navigation button instance.
			/// </summary>
			/// <param name="level">The selection level for this button.</param>
			/// <param name="text">The button text.</param>
			/// <param name="state">Teh button state.</param>
			public NavigationButton(NavigationLevel level, string text = null, NavigationButtonState state = NavigationButtonState.Normal)
			{
				this.Level = level;
				this.Text = text;
				this.State = state;
			}

			/// <summary>
			/// Gets or sets the navigation button state.
			/// </summary>
			public NavigationButtonState State { get; set; }
			/// <summary>
			/// Gets or sets the navigation level.
			/// </summary>
			public NavigationLevel Level { get; set; }
			/// <summary>
			/// Gets or sets the navigation button text.
			/// </summary>
			public string Text { get; set; }
			/// <summary>
			/// Gets or sets the text size.
			/// </summary>
			public Size TextSize { get; set; }
			/// <summary>
			/// Gets or sets the navigation button bounds.
			/// </summary>
			public Rectangle Bounds { get; set; }
			/// <summary>
			/// Gets or sets the text bounds.
			/// </summary>
			public Rectangle TextBounds { get; set; }
			/// <summary>
			/// Gets or sets the item fill path.
			/// </summary>
			public GraphicsPath FillPath { get; set; }
			/// <summary>
			/// Gets or sets the item fill rectangle.
			/// </summary>
			public Rectangle FillRectangle { get; set; }
		}

		private class ItemButton
		{
		}

		private int buttonItemWidth = 100;		// The width of the item button.
		private int buttonItemHeight = 48;		// The height of the item button.
		private int buttonScrollHeight = 12;	// The height of the scroll button.
		private int buttonGridRows;
		private int buttonGridColumns;
		private Padding buttonNavigationPadding = new Padding(3, 0, 0, 0);
		private int buttonNavigationChevron = 5;
		//private int legendHeight = 23;			// The height of the legend.

		private Rectangle rectNavigationBorder = new Rectangle();

		private NavigationLevel navigationLevel = NavigationLevel.Region;
		private NavigationButton[] navigationButtons = new NavigationButton[5] {
			new NavigationButton(NavigationLevel.Feeds, "Standard feeds"),
			new NavigationButton(NavigationLevel.Feed, "Feed"),
			new NavigationButton(NavigationLevel.Time, "All time"),
			new NavigationButton(NavigationLevel.Category, "Movies"),
			new NavigationButton(NavigationLevel.Region, "Brazil")
		};

		private ColorBlend colorBlend = new ColorBlend(3);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlStandardFeeds()
		{
			InitializeComponent();

			// Set the padding.
			this.Padding = new Padding(3);

			// Set the dimensions.
			this.rectNavigationBorder.Height = 20;

			// Set the colorblend positions.
			this.colorBlend.Positions[0] = 0.0f;
			this.colorBlend.Positions[1] = 0.5f;
			this.colorBlend.Positions[2] = 1.0f;
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the height of the navigation bar.
		/// </summary>
		public int NavigationBarHeight
		{
			get { return this.rectNavigationBorder.Height; }
			set
			{
				this.rectNavigationBorder.Height = value;
				this.Refresh();
			}
		}
		/// <summary>
		/// Gets or sets the navigation button padding.
		/// </summary>
		public Padding ButtonNavigationPadding
		{
			get { return this.buttonNavigationPadding; }
			set { this.buttonNavigationPadding = value; }
		}
		/// <summary>
		/// Gets or sets the navigation button chevron size.
		/// </summary>
		public int ButtonNavigationChevron
		{
			get { return this.buttonNavigationChevron; }
			set { this.buttonNavigationChevron = value; }
		}

		// Public methods.

		// Private properties.

		public int ButtonNavigationWidthDelta
		{
			get { return this.ButtonNavigationPadding.Left + this.ButtonNavigationPadding.Right + this.ButtonNavigationChevron; }
		}

		// Private methods.


		/// <summary>
		/// An event handler called when painting the control.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPaint(object sender, PaintEventArgs e)
		{
			// Set the smoothing mode.
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			// Create the pen.
			using(Pen pen = new Pen(ProfessionalColors.MenuBorder))
			{
				// Draw the navigation bar.
				e.Graphics.DrawRectangle(pen, this.rectNavigationBorder);

				// Paint the navigation bar buttons.
				int navigationLeft = this.rectNavigationBorder.Left;
				for (int index = 0; index < (int)this.navigationLevel; index++)
				{
					this.OnPaintNavigationButton(
						e.Graphics,
						pen,
						this.navigationButtons[index],
						navigationLeft);
				}
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

		private void OnPaintNavigationButton(Graphics g, Pen pen, NavigationButton button, int left)
		{
			// Compute the background colors for this item.
			Color colorBegin = Color.Black;
			Color colorEnd = Color.Black;
			switch (button.State)
			{
				case NavigationButton.NavigationButtonState.Normal:
					colorBegin = ProfessionalColors.MenuStripGradientBegin;
					colorEnd = ProfessionalColors.MenuStripGradientEnd;
					break;
				case NavigationButton.NavigationButtonState.Highlighted:
					colorBegin = ProfessionalColors.ButtonSelectedGradientBegin;
					colorEnd = ProfessionalColors.ButtonSelectedGradientEnd;
					break;
				case NavigationButton.NavigationButtonState.Pressed:
					colorBegin = ProfessionalColors.ButtonPressedGradientBegin;
					colorEnd = ProfessionalColors.ButtonPressedGradientEnd;
					break;
			}

			// Fill the button.
			using (Brush brush = new LinearGradientBrush(button.FillRectangle, colorEnd, colorBegin, LinearGradientMode.Vertical))
			{
				g.FillPath(brush, button.FillPath);
			}
			
			// Draw the button outer border.
			pen.Color = ProfessionalColors.MenuBorder;
			g.DrawPath(pen, button.FillPath);			

			// Draw the text.
			TextRenderer.DrawText(
				g,
				button.Text,
				this.Font,
				button.TextBounds,
				SystemColors.MenuText,
				TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
		}

		/// <summary>
		/// An event handler called when resizing the control.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnResize(object sender, EventArgs e)
		{
			// Resize the navigation bar.
			this.OnResizeNavigation();
			this.Refresh();
		}

		/// <summary>
		/// An event handler called when resizing all navigation buttons.
		/// </summary>
		private void OnResizeNavigation()
		{
			// Resize the navigation bar outer border.
			this.rectNavigationBorder.X = this.ClientRectangle.X + this.Padding.Left;
			this.rectNavigationBorder.Y = this.ClientRectangle.Y + this.Padding.Top;
			this.rectNavigationBorder.Width = this.ClientRectangle.Width - this.Padding.Left - this.Padding.Right - 1;

			// Compute the preferred width for the navigation bar.
			int preferredWidth = this.buttonNavigationChevron;
			for (int index = 0; index < (int)this.navigationLevel; index++)
			{
				// Add the preferred width for each navigation button.
				preferredWidth += TextRenderer.MeasureText(this.navigationButtons[index].Text, this.Font).Width;
			}
			// Compute the resize factor.
			double resize = (double)(this.rectNavigationBorder.Width - ((int)this.navigationLevel)*(this.buttonNavigationPadding.Left + this.buttonNavigationPadding.Right + this.buttonNavigationChevron)) / preferredWidth;
			resize = (resize < 0.0) ? 0.0 : resize;
			resize = (resize > 1.0) ? 1.0 : resize;
			// Resize all navigation buttons.
			for (int index = 0; index < this.navigationButtons.Length; index++)
			{
				this.OnResizeNavigation(index, resize);
			}
		}

		/// <summary>
		/// An event handler called when resizing the navigation button at the specified index.
		/// </summary>
		/// <param name="index">The navigation button index.</param>
		/// <param name="resize">The resize factor for this button.</param>
		private void OnResizeNavigation(int index, double resize)
		{
			// Get the button.
			NavigationButton button = this.navigationButtons[index];

			// Compute the text size.
			Size textSize = TextRenderer.MeasureText(button.Text, this.Font);
			// Resize the button.
			textSize.Width = (int)(textSize.Width * resize);
			// Set the text size.
			button.TextSize = textSize;

			// Compute the button bounds.
			button.Bounds = new Rectangle(
				(index > 0) ? this.navigationButtons[index-1].Bounds.Right : this.rectNavigationBorder.Left,
				this.rectNavigationBorder.Y,
				button.TextSize.Width + this.buttonNavigationPadding.Left + this.buttonNavigationPadding.Right + this.buttonNavigationChevron,// + ((index > 0) ? this.buttonNavigationChevron : 0),
				this.rectNavigationBorder.Height);
			// Compute the text bounds.
			button.TextBounds = new Rectangle(
				button.Bounds.X + this.buttonNavigationPadding.Left,
				button.Bounds.Y,
				button.TextSize.Width,
				button.Bounds.Height);

			// Compute the fill rectangle.
			button.FillRectangle = new Rectangle(
				button.Bounds.Left,
				button.Bounds.Top,
				button.Bounds.Right,
				button.Bounds.Bottom);

			// If this is the first button.
			if (index == 0)
			{
				// Compute the button fill path.
				button.FillPath = new GraphicsPath(new Point[] {
					new Point(button.Bounds.Left, button.Bounds.Bottom),
					new Point(button.Bounds.Left, button.Bounds.Top),
					new Point(button.Bounds.Right - this.buttonNavigationChevron, button.Bounds.Top),
					new Point(button.Bounds.Right, (button.Bounds.Top + button.Bounds.Bottom) / 2),
					new Point(button.Bounds.Right - this.buttonNavigationChevron, button.Bounds.Bottom),
					new Point(button.Bounds.Left, button.Bounds.Bottom)
				}, new byte[] {
					(byte)PathPointType.Line,
					(byte)PathPointType.Line,
					(byte)PathPointType.Line,
					(byte)PathPointType.Line,
					(byte)PathPointType.Line,
					(byte)PathPointType.Line
				});
			}
			else
			{
				// Compute the button fill path.
				button.FillPath = new GraphicsPath(new Point[] {
					new Point(button.Bounds.Left - this.buttonNavigationChevron, button.Bounds.Bottom),
					new Point(button.Bounds.Left, (button.Bounds.Top + button.Bounds.Bottom) / 2),
					new Point(button.Bounds.Left - this.buttonNavigationChevron, button.Bounds.Top),
					new Point(button.Bounds.Right - this.buttonNavigationChevron, button.Bounds.Top),
					new Point(button.Bounds.Right, (button.Bounds.Top + button.Bounds.Bottom) / 2),
					new Point(button.Bounds.Right - this.buttonNavigationChevron, button.Bounds.Bottom),
					new Point(button.Bounds.Left - this.buttonNavigationChevron, button.Bounds.Bottom)
				}, new byte[] {
					(byte)PathPointType.Line,
					(byte)PathPointType.Line,
					(byte)PathPointType.Line,
					(byte)PathPointType.Line,
					(byte)PathPointType.Line,
					(byte)PathPointType.Line,
					(byte)PathPointType.Line
				});
			}
		}

		/// <summary>
		/// An event handler called when the mouse moves over the control.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			// Mouse move over the navigation bar.
			foreach (NavigationButton button in this.navigationButtons)
			{
				
			}
		}

		/// <summary>
		/// An event handler called when the mouse leaves the control.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseLeave(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when a mouse button is pressed over the control.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseDown(object sender, MouseEventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when a mouse button is released over the control.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseUp(object sender, MouseEventArgs e)
		{

		}
	}
}
