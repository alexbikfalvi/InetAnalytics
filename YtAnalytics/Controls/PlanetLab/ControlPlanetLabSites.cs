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
using DotNetApi.Web;
using DotNetApi.Web.XmlRpc;
using DotNetApi.Windows.Controls;
using PlanetLab.Requests;
using YtCrawler;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control class for PlanetLab nodes.
	/// </summary>
	public partial class ControlPlanetLabSites : NotificationControl
	{
		// Private variables.

		private Crawler crawler = null;
		private PlRequestGetSites request = new PlRequestGetSites();

		// Public declarations

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabSites()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		public void Initialize(Crawler crawler)
		{
			// Save the parameters.
			this.crawler = crawler;
		
			// Enable the control.
			this.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the user refreshes the list of PlanetLab nodes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// Set the button enabled state.
			this.buttonRefresh.Enabled = false;
			this.buttonCancel.Enabled = true;

			// Show the notification box.
			this.ShowMessage(Resources.GlobeClock_48, "Refreshing PlanetLab", "Refreshing the list of PlanetLab nodes...");

			// Begin an asynchrnoys PlanetLab request.
			try
			{
				// Begin the request.
				this.request.Begin(
					this.crawler.Config.PlanetLabUserName,
					this.crawler.Config.PlanetLabPassword,
					string.Empty,
					this.OnCallback);
			}
			catch (Exception exception)
			{
				// Show an error message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"PlanetLab Error",
					string.Format("An error occured while refreshing the PlanetLab nodes. {0}", exception.Message),
					false,
					(int)this.crawler.Config.ConsoleMessageCloseDelay.TotalMilliseconds,
					this.OnComplete);
			}
		}

		/// <summary>
		/// An event handler called when the user cancels the refresh of PlanetLab nodes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCancel(object sender, EventArgs e)
		{
			// Disable the cancel button.
			this.buttonCancel.Enabled = false;
		}

		/// <summary>
		/// An event handler called when the asynchronous request has completed.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		private void OnCallback(AsyncWebResult result)
		{
			try
			{
				// Complete the request.
				AsyncWebResult asyncResult;
				
				// Get the XML RPC response.
				XmlRpcResponse rpcResponse = this.request.End(result, out asyncResult);

				// If a fault occurred during the XML-RPC request.
				if (rpcResponse.Fault != null)
				{
					// Show an error message.
					this.ShowMessage(
						Resources.GlobeWarning_48,
						"PlanetLab Error",
						string.Format("Refreshing the PlanetLab nodes has completed failed (RPC code {0} {1})", rpcResponse.Fault.FaultCode, rpcResponse.Fault.FaultString),
						false,
						(int)this.crawler.Config.ConsoleMessageCloseDelay.TotalMilliseconds,
						this.OnComplete);
				}
				else
				{
					// Show a success message.
					this.ShowMessage(
						Resources.GlobeSuccess_48,
						"PlanetLab Success",
						"Refreshing the PlanetLab nodes has completed successfuly.",
						false,
						(int)this.crawler.Config.ConsoleMessageCloseDelay.TotalMilliseconds,
						this.OnComplete);
				}

			}
			catch (Exception exception)
			{
				// Show an error message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"PlanetLab Error",
					string.Format("An error occured while refreshing the PlanetLab nodes. {0}",
					exception.Message), false, (int)this.crawler.Config.ConsoleMessageCloseDelay.TotalMilliseconds,
					this.OnComplete);
			}
		}

		/// <summary>
		/// An event handler called when the request has completed.
		/// </summary>
		private void OnComplete()
		{
			// Set the button enabled state.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
		}
	}
}
