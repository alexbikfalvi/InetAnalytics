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

namespace YtCrawler.Status
{
	/// <summary>
	/// A structure representing a status message.
	/// </summary>
	public struct StatusMessage
	{
		/// <summary>
		/// Creates a new message structure.
		/// </summary>
		/// <param name="text">The left text.</param>
		public StatusMessage(string text)
			: this()
		{
			this.LeftText = text;
		}

		/// <summary>
		/// Creates a new message structure.
		/// </summary>
		/// <param name="text">The left text.</param>
		/// <param name="image">The left image.</param>
		public StatusMessage(string text, Image image)
			: this()
		{
			this.LeftText = text;
			this.LeftImage = image;
		}

		/// <summary>
		/// Creates a new messge structure.
		/// </summary>
		/// <param name="leftText">The left text.</param>
		/// <param name="rightText">The right text.</param>
		/// <param name="leftImage">The left image.</param>
		/// <param name="rightImage">The right image.</param>
		public StatusMessage(string leftText, string rightText, Image leftImage, Image rightImage)
			: this()
		{
			this.LeftText = leftText;
			this.RightText = rightText;
			this.LeftImage = leftImage;
			this.RightImage = rightImage;
		}

		// Public properties.

		/// <summary>
		/// Gets the left image.
		/// </summary>
		public Image LeftImage { get; private set; }
		/// <summary>
		/// Gets the right image.
		/// </summary>
		public Image RightImage { get; private set; }
		/// <summary>
		/// Gets the left text.
		/// </summary>
		public string LeftText { get; private set; }
		/// <summary>
		/// Gets the right text.
		/// </summary>
		public string RightText { get; private set; }
	}
}
