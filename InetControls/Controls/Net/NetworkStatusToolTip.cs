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
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Drawing;
using DotNetApi.Windows;
using DotNetApi.Windows.Themes;
using InetCommon.Net;

namespace InetCommon.Controls.Net
{
	/// <summary>
	/// A control representing the network status tooltip.
	/// </summary>
	public sealed class NetworkStatusToolTip : ToolTip
	{
		private const float spacingFactor = 0.5f;
		private static readonly Bitmap[] icons = {
													 Resources.ConnectionQuestion_32,
													 Resources.ConnectionSuccess_32,
													 Resources.ConnectionWarning_32,
													 Resources.ConnectionError_32
												 };
		private static readonly string[] message = {
													   "Connectivity unknown",
													   "Connected to Internet",
													   "Connected to local network",
													   "Not connected"
												   };

		// Network status.
		private readonly NetworkStatus networkStatus;

		// Theme.
		private readonly ThemeSettings themeSettings;

		// Current settings.
		Bitmap icon;

		string messageTitle;
		string messageIcmp;
		string messageHttp;
		string messageHttps;
		string messageUpdated;

		Rectangle boundsIcon;
		Rectangle boundsTitle;
		Rectangle boundsIcmp;
		Rectangle boundsHttp;
		Rectangle boundsHttps;
		Rectangle boundsUpdated;

		Size size;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="container">The container.</param>
		/// <param name="networkStatus">The network status.</param>
		public NetworkStatusToolTip(IContainer container, NetworkStatus networkStatus)
			: base(container)
		{
			// Get the theme settings.
			this.themeSettings = ToolStripManager.Renderer is ThemeRenderer ? (ToolStripManager.Renderer as ThemeRenderer).Settings : ThemeSettings.Default;

			// Set the network status.
			this.networkStatus = networkStatus;

			// Set the default properties.
			this.IsBalloon = false;
			this.OwnerDraw = true;
			this.UseAnimation = true;
			this.UseFading = true;

			// Set the event handlers.
			this.Popup += this.OnPopup;
			this.Draw += this.OnDraw;
		}

		// Public properties.

		/// <summary>
		/// Gets whether the tooltip is visible.
		/// </summary>
		public bool Visible { get; private set; }

		// Public methods.

		/// <summary>
		/// Shows the tooltip.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="location">The location relative to the control.</param>
		/// <param name="alignment">The alignment relative to the location.</param>
		public void Show(IWin32Window control, Point location, ContentAlignment alignment)
		{
			// Create the title font.
			using (Font font = new Font(Window.DefaultFont, FontStyle.Bold))
			{
				// Compute the tooltip strings.
				this.messageTitle = NetworkStatusToolTip.message[(int)this.networkStatus.IsInternetAvailable];
				this.messageIcmp = "ICMP connectivity: {0}".FormatWith(this.networkStatus.IsInternetIcmpAvailable ? "Yes" : "No");
				this.messageHttp = "HTTP connectivity: {0}".FormatWith(this.networkStatus.IsInternetHttpAvailable ? "Yes" : "No");
				this.messageHttps = "HTTPS connectivity: {0}".FormatWith(this.networkStatus.IsInternetHttpsAvailable ? "Yes" : "No");
				this.messageUpdated = "Connectivity last checked at {0}".FormatWith(this.networkStatus.InternetAvailableLastUpdated.ToLongTimeString());

				// Compute the strings size.
				Size sizeTitle = TextRenderer.MeasureText(messageTitle, font);
				Size sizeIcmp = TextRenderer.MeasureText(messageIcmp, Window.DefaultFont);
				Size sizeHttp = TextRenderer.MeasureText(messageHttp, Window.DefaultFont);
				Size sizeHttps = TextRenderer.MeasureText(messageHttps, Window.DefaultFont);
				Size sizeUpdated = TextRenderer.MeasureText(messageUpdated, Window.DefaultFont);

				// Compute the spacing size.

				int spacing = (int)(Window.DefaultFont.SizeInPoints * spacingFactor);

				// Get the icon.
				this.icon = NetworkStatusToolTip.icons[(int)this.networkStatus.IsInternetAvailable];

				// Compute the bounds.
				this.boundsIcon = new Rectangle(new Point(spacing << 1, spacing << 1), this.icon.Size);
				this.boundsTitle = new Rectangle(this.boundsIcon.Right + (spacing << 1), this.boundsIcon.Top, sizeTitle.Width, sizeTitle.Height);
				this.boundsIcmp = new Rectangle(this.boundsTitle.Left, this.boundsTitle.Bottom + (spacing << 1), sizeIcmp.Width, sizeIcmp.Height);
				this.boundsHttp = new Rectangle(this.boundsTitle.Left, this.boundsIcmp.Bottom + spacing, sizeHttp.Width, sizeHttp.Height);
				this.boundsHttps = new Rectangle(this.boundsTitle.Left, this.boundsHttp.Bottom + spacing, sizeHttps.Width, sizeHttps.Height);
				this.boundsUpdated = new Rectangle(this.boundsTitle.Left, this.boundsHttps.Bottom + (spacing << 1), sizeUpdated.Width, sizeUpdated.Height);

				// Compute the maximum bounds.
				Rectangle boundsMax = Geometry.Max(this.boundsIcon, this.boundsTitle, this.boundsIcmp, this.boundsHttp, this.boundsHttps, this.boundsUpdated);

				// Compute the size.
				this.size = new Size(boundsMax.Width + (spacing << 2), boundsMax.Height + (spacing << 2));

				// Update the location according to the alignment.
				switch (alignment)
				{
					case ContentAlignment.TopCenter: location = location.Add(-(this.size.Width >> 1), 0); break;
					case ContentAlignment.TopRight: location = location.Add(-this.size.Width, 0); break;
					case ContentAlignment.MiddleLeft: location = location.Add(0, -(this.size.Height >> 1)); break;
					case ContentAlignment.MiddleCenter: location = location.Add(-(this.size.Width >> 1), -(this.size.Height >> 1)); break;
					case ContentAlignment.MiddleRight: location = location.Add(-this.size.Width, -this.size.Height); break;
					case ContentAlignment.BottomLeft: location = location.Add(0, -this.size.Height); break;
					case ContentAlignment.BottomCenter: location = location.Add(-(this.size.Width >> 1), -this.size.Height); break;
					case ContentAlignment.BottomRight: location = location.Add(-this.size.Width, -this.size.Height); break;
				}
			}

			// Show the tooltip.
			base.Show(" ", control, location);
		}

		/// <summary>
		/// Hides the tooltip.
		/// </summary>
		/// <param name="control">The control.</param>
		public new void Hide(IWin32Window control)
		{
			// Hide the tooltip.
			base.Hide(control);
			// Set the visibility to false.
			this.Visible = false;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the tooltip pops up.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPopup(object sender, PopupEventArgs e)
		{
			// Set the visibility to true.
			this.Visible = true;
			// Set the tooltip size.
			e.ToolTipSize = this.size;
		}

		/// <summary>
		/// An event handler called when drawing the tooltip.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDraw(object sender, DrawToolTipEventArgs e)
		{
			// Fill the tooltip background.
			using (SolidBrush brush = new SolidBrush(this.themeSettings.ColorTable.StatusStripNormalBackground))
			{
				e.Graphics.FillRectangle(brush, e.Bounds);
			}
			// Draw the tooltip border.
			e.DrawBorder();
			// Draw the icon.
			e.Graphics.DrawImage(this.icon, this.boundsIcon);
			// Draw the text.
			using (Font font = new Font(Window.DefaultFont, FontStyle.Bold))
			{
				TextRenderer.DrawText(
					e.Graphics,
					this.messageTitle,
					font,
					this.boundsTitle,
					this.themeSettings.ColorTable.StatusStripNormalText,
					TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
			}
			TextRenderer.DrawText(
				e.Graphics,
				this.messageIcmp,
				Window.DefaultFont,
				this.boundsIcmp,
				this.themeSettings.ColorTable.StatusStripNormalText,
				TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
			TextRenderer.DrawText(
				e.Graphics,
				this.messageHttp,
				Window.DefaultFont,
				this.boundsHttp,
				this.themeSettings.ColorTable.StatusStripNormalText,
				TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
			TextRenderer.DrawText(
				e.Graphics,
				this.messageHttps,
				Window.DefaultFont,
				this.boundsHttps,
				this.themeSettings.ColorTable.StatusStripNormalText,
				TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
			TextRenderer.DrawText(
				e.Graphics,
				this.messageUpdated,
				Window.DefaultFont,
				this.boundsUpdated,
				this.themeSettings.ColorTable.StatusStripNormalText,
				TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
		}
	}
}
