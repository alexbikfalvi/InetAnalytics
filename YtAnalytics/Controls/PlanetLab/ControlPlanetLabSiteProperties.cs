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
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using YtAnalytics.Forms;
using PlanetLab;
using PlanetLab.Api;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that displays the information of a PlanetLab site.
	/// </summary>
	public partial class ControlPlanetLabSiteProperties : ThreadSafeControl
	{
		private PlSite site = null;
		private GeoMarkerCircle marker = new GeoMarkerCircle(new PointF());

		private static string notAvailable = "(not available)";

		private static Color colorMarkerLine = Color.FromArgb(153, 51, 51);
		private static Color colorMarkerFill = Color.FromArgb(255, 51, 51);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabSiteProperties()
		{
			InitializeComponent();

			// Set the marker colors.
			this.marker.ColorLine = ControlPlanetLabSiteProperties.colorMarkerLine;
			this.marker.ColorFill = ControlPlanetLabSiteProperties.colorMarkerFill;
			// Add the marker to the world map.
			this.worldMap.Markers.Add(this.marker);
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the PlanetLab site.
		/// </summary>
		public PlSite PlanetLabSite
		{
			get { return this.site; }
			set
			{
				// Save the old site.
				PlSite oldSite = this.site;
				// Change the site.
				this.site = value;
				// Call the event handler.
				this.OnSiteSet(oldSite, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new site has been set.
		/// </summary>
		/// <param name="oldSite">The old PlanetLab site.</param>
		/// <param name="newSite">The new PlanetLab site.</param>
		protected virtual void OnSiteSet(PlSite oldSite, PlSite newSite)
		{
			// If the old an new sites are the same, do nothing.
			if (oldSite == newSite) return;
			// Change the display information for the new site.
			if (null == newSite)
			{
				this.labelTitle.Text = "No site selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelTitle.Text = newSite.Name;

				this.textBoxName.Text = newSite.Name;
				this.textBoxAbbreviatedName.Text = newSite.AbbreviatedName;
				this.textBoxUrl.Text = newSite.Url;
				this.textBoxLoginBase.Text = newSite.LoginBase;

				this.textBoxSiteId.Text = newSite.SiteId.HasValue ? newSite.SiteId.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxPeerId.Text = newSite.PeerId.HasValue ? newSite.PeerId.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxExtConsortiumId.Text = newSite.ExtConsortiumId.HasValue ? newSite.ExtConsortiumId.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxPeerSiteId.Text = newSite.PeerSiteId.HasValue ? newSite.PeerSiteId.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;

				this.textBoxDateCreated.Text = newSite.DateCreated.HasValue ? newSite.DateCreated.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxLastUpdated.Text = newSite.LastUpdated.HasValue ? newSite.LastUpdated.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;

				this.textBoxLatitude.Text = newSite.Latitude.HasValue ? PlUtil.LatitudeToString(newSite.Latitude.Value) : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxLongitude.Text = newSite.Longitude.HasValue ? PlUtil.LongitudeToString(newSite.Longitude.Value) : ControlPlanetLabSiteProperties.notAvailable;

				this.textBoxMaxSlices.Text = newSite.MaxSlices.HasValue ? newSite.MaxSlices.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxMaxSlivers.Text = newSite.MaxSlivers.HasValue ? newSite.MaxSlivers.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;

				this.checkBoxIsEnabled.CheckState = newSite.IsEnabled.HasValue ? newSite.IsEnabled.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate ;
				this.checkBoxIsPublic.CheckState = newSite.IsPublic.HasValue ? newSite.IsPublic.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;

				if (newSite.Latitude.HasValue && newSite.Longitude.HasValue)
				{
					this.marker.Coordinates = new PointF((float)newSite.Longitude.Value, (float)newSite.Latitude.Value);
					this.worldMap.ShowMarkers = true;
				}
				else this.worldMap.ShowMarkers = false;

				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxName.Select();
				this.textBoxName.SelectionStart = 0;
				this.textBoxName.SelectionLength = 0;
			}
		}
	}
}
