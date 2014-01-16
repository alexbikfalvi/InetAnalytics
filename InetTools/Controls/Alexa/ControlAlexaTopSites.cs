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
using System.Net;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetAnalytics;
using InetCommon.Status;
using InetCrawler.Log;
using InetCrawler.Tools;
using InetTools.Tools.Alexa;

namespace InetTools.Controls.Alexa
{
	/// <summary>
	/// A class representing the control for Alexa Top Sites.
	/// </summary>
	public partial class ControlAlexaTopSites : NotificationControl
	{
		private readonly IToolApi api;
		private readonly ApplicationStatusHandler status = null;
		
		private readonly object sync = new object();

		private readonly AlexaRequest request = new AlexaRequest();
		private IAsyncResult result = null;

		private AlexaCountries countries = new AlexaCountries();
		private AlexaRanking ranking = new AlexaRanking();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		public ControlAlexaTopSites(IToolApi api)
		{
			// Initialize the component.
			this.InitializeComponent();
			
			// Set the API.
			this.api = api;

			// Set the status.
			this.status = this.api.Status.GetHandler(this);
			this.status.Send(ApplicationStatus.StatusType.Normal, "Ready.", Resources.Information_16);

			// Initialize the number of pages.
			this.comboBoxPages.SelectedIndex = 0;

			// Initialize the list of countries.
			this.OnUpdateCountries();
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a request has started.
		/// </summary>
		private void OnRequestStarted()
		{
			// Set the controls enabled state.
			this.buttonStart.Enabled = false;
			this.buttonRefreshCountries.Enabled = false;
			this.buttonStop.Enabled = true;
			this.comboBoxCountries.Enabled = false;
			this.comboBoxPages.Enabled = false;
		}

		/// <summary>
		/// An event handler called when a request has finished.
		/// </summary>
		private void OnRequestFinished()
		{
			// Set the controls enabled state.
			this.buttonStart.Enabled = true;
			this.buttonRefreshCountries.Enabled = true;
			this.buttonStop.Enabled = false;
			this.comboBoxCountries.Enabled = true;
			this.comboBoxPages.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the user clicks on the start button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Compute the number of pages to download.
			int pages;
			if(!int.TryParse(this.comboBoxPages.Text, out pages))
			{
				MessageBox.Show(this, "The number of pages is not an integer.", "Number of Pages Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if ((pages <= 0) || (pages > 20))
			{
				MessageBox.Show(this, "You can request between 1 and 20 pages.", "Number of Pages", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Call the request started event handler.
			this.OnRequestStarted();

			try
			{
				// Clear the ranking lists.
				this.listView.Items.Clear();
				// Disable the save button.
				this.buttonSave.Enabled = false;

				// If the selected index is zero.
				if (this.comboBoxCountries.SelectedIndex == 0)
				{
					lock (this.sync)
					{
						// Get the global Alexa ranking.
						this.result = this.request.BeginGetGlobalRanking(this.OnCallbackRanking, pages, this.ranking);
					}
				}
				else
				{
					// Get the selected country.
					AlexaCountry country = this.countries[this.comboBoxCountries.SelectedIndex - 1];
					lock (this.sync)
					{
						// Get the country specific Alexa ranking.
						this.result = this.request.BeginGetCountryRanking(this.OnCallbackRanking, country, pages, this.ranking);
					}
				}

				// Set the status.
				this.status.Send(ApplicationStatus.StatusType.Busy, "Updating the Alexa ranking...", Resources.Busy_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeClock_48,
					"Alexa Request",
					"Updating the Alexa ranking...");
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Verbose,
					LogEventType.Information,
					"Started a request for updating the Alexa ranking."
					));
			}
			catch (Exception exception)
			{
				// Call the request finished event handler.
				this.OnRequestFinished();
				// Update the status label.
				this.status.Send(ApplicationStatus.StatusType.Normal, "Updating the Alexa ranking failed. {0}".FormatWith(exception.Message), Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"Alexa Request",
					"Updating the Alexa ranking failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
					false,
					(int)this.api.Config.MessageCloseDelay.TotalMilliseconds);
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					"Updating the Alexa ranking failed. {0}",
					new object[] { exception.Message },
					exception
					));
			}
		}

		/// <summary>
		/// A method called when receiving the web response.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		private void OnCallbackRanking(IAsyncResult result)
		{
			// Set the result to null.
			lock (this.sync)
			{
				this.result = null;
			}

			try
			{
				// Complete the request.
				this.request.EndGetRanking(result);
				// Update the status label.
				this.status.Send(
					ApplicationStatus.StatusType.Normal,
					"Updating the Alexa ranking completed successfully.",
					"{0} web sites received.".FormatWith(this.ranking.Count),
					Resources.Success_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeSuccess_48,
					"Alexa Request",
					"Updating the Alexa ranking completed successfully.",
					false,
					(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the request finished event handler.
						this.OnRequestFinished();
						// Update the ranking list.
						this.OnUpdateRanking();
					});
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Verbose,
					LogEventType.Success,
					"Updating the Alexa ranking completed successfully."
					));
			}
			catch (WebException exception)
			{
				if (exception.Status == WebExceptionStatus.RequestCanceled)
				{
					// Update the status label.
					this.status.Send(ApplicationStatus.StatusType.Normal, "Updating the Alexa ranking was canceled.".FormatWith(exception.Message), Resources.Canceled_16);
					// Show a message.
					this.ShowMessage(
						Resources.GlobeCanceled_48,
						"Alexa Request",
						"Updating the Alexa ranking was canceled.",
						false,
						(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
						{
							// Call the request finished event handler.
							this.OnRequestFinished();
						});
					// Log the events.
					this.controlLog.Add(this.api.Log(
						LogEventLevel.Normal,
						LogEventType.Canceled,
						"Updating the Alexa ranking was canceled."
						));
				}
				else
				{
					// Update the status label.
					this.status.Send(ApplicationStatus.StatusType.Normal, "Updating the Alexa ranking failed. {0}".FormatWith(exception.Message), Resources.Error_16);
					// Show a message.
					this.ShowMessage(
						Resources.GlobeError_48,
						"Alexa Request",
						"Updating the Alexa ranking failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
						false,
						(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
						{
							// Call the request finished event handler.
							this.OnRequestFinished();
						});
					// Log the events.
					this.controlLog.Add(this.api.Log(
						LogEventLevel.Important,
						LogEventType.Error,
						"Updating the Alexa ranking failed. {0}",
						new object[] { exception.Message },
						exception
						));
				}
			}
			catch (Exception exception)
			{
				// Update the status label.
				this.status.Send(ApplicationStatus.StatusType.Normal, "Updating the Alexa ranking failed. {0}".FormatWith(exception.Message), Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"Alexa Request",
					"Updating the Alexa ranking failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
					false,
					(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the request finished event handler.
						this.OnRequestFinished();
					});
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					"Updating the Alexa ranking failed. {0}",
					new object[] { exception.Message },
					exception
					));
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the stop button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			// Set the controls enabled state.
			this.buttonStop.Enabled = false;

			lock (this.sync)
			{
				// If the request result is not null.
				if (null != this.result)
				{
					// Cancel the asynchronous operation.
					this.request.Cancel(this.result);
					// Set the result to null.
					this.result = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when refreshing the list of Alexa countries.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefreshCountries(object sender, EventArgs e)
		{
			// Call the request started event handler.
			this.OnRequestStarted();

			try
			{
				// Clear the countries list.
				this.comboBoxCountries.Items.Clear();

				// Set the status.
				this.status.Send(ApplicationStatus.StatusType.Busy, "Updating the list of Alexa ranking countries...", Resources.Busy_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeClock_48,
					"Alexa Request",
					"Updating the list of Alexa ranking countries...");
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Verbose,
					LogEventType.Information,
					"Started a request for updating the list of Alexa ranking countries."
					));

				lock (this.sync)
				{
					// Begin a new web request.
					this.result = this.request.BeginGetCountries(this.OnCallbackCountries, this.countries);
				}
			}
			catch (Exception exception)
			{
				// Call the request finished event handler.
				this.OnRequestFinished();
				// Update the status label.
				this.status.Send(ApplicationStatus.StatusType.Normal, "Updating the list of Alexa ranking countries failed. {0}".FormatWith(exception.Message), Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"Alexa Request",
					"Updating the list of Alexa ranking countries failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
					false,
					(int)this.api.Config.MessageCloseDelay.TotalMilliseconds);
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					"Updating the list of Alexa ranking countries failed. {0}",
					new object[] { exception.Message },
					exception
					));
			}
		}

		/// <summary>
		/// A method called when receiving the web response.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		private void OnCallbackCountries(IAsyncResult result)
		{
			// Set the result to null.
			lock (this.sync)
			{
				this.result = null;
			}

			try
			{
				// Complete the web request.
				this.request.EndGetCountries(result);

				// Update the status label.
				this.status.Send(
					ApplicationStatus.StatusType.Normal,
					"Updating the list of Alexa ranking countries completed successfully.",
					"{0} countries received.".FormatWith(this.countries.Count),
					Resources.Success_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeSuccess_48,
					"Alexa Request",
					"Updating the list of Alexa ranking countries completed successfully.",
					false,
					(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the request finished event handler.
						this.OnRequestFinished();
						// Update the list of countries.
						this.OnUpdateCountries();
					});
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Verbose,
					LogEventType.Success,
					"Updating the list of Alexa ranking countries completed successfully."
					));
			}
			catch (WebException exception)
			{
				if (exception.Status == WebExceptionStatus.RequestCanceled)
				{
					// Update the status label.
					this.status.Send(ApplicationStatus.StatusType.Normal, "Updating the list of Alexa ranking countries was canceled.".FormatWith(exception.Message), Resources.Canceled_16);
					// Show a message.
					this.ShowMessage(
						Resources.GlobeCanceled_48,
						"Alexa Request",
						"Updating the list of Alexa ranking countries was canceled.",
						false,
						(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
						{
							// Call the request finished event handler.
							this.OnRequestFinished();
						});
					// Log the events.
					this.controlLog.Add(this.api.Log(
						LogEventLevel.Normal,
						LogEventType.Canceled,
						"Updating the list of Alexa ranking was canceled."
						));
				}
				else
				{
					// Update the status label.
					this.status.Send(ApplicationStatus.StatusType.Normal, "Updating the list of Alexa ranking countries failed. {0}".FormatWith(exception.Message), Resources.Error_16);
					// Show a message.
					this.ShowMessage(
						Resources.GlobeError_48,
						"Alexa Request",
						"Updating the Alexa ranking failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
						false,
						(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
						{
							// Call the request finished event handler.
							this.OnRequestFinished();
						});
					// Log the events.
					this.controlLog.Add(this.api.Log(
						LogEventLevel.Important,
						LogEventType.Error,
						"Updating the list of Alexa ranking countries failed. {0}",
						new object[] { exception.Message },
						exception
						));
				}
			}
			catch (Exception exception)
			{
				// Show a message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"Alexa Request",
					"Updating the list of Alexa ranking countries failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
					false,
					(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the request finished event handler.
						this.OnRequestFinished();
					});
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					"Updating the list of Alexa ranking countries failed. {0}",
					new object[] { exception.Message },
					exception
					));
			}
		}

		/// <summary>
		/// Updates the current list of countries.
		/// </summary>
		private void OnUpdateCountries()
		{
			// Add the global ranking.
			this.comboBoxCountries.Items.Add("(Global)");
			// Update the list of countries.
			foreach (AlexaCountry country in this.countries)
			{
				this.comboBoxCountries.Items.Add(country.Name);
			}
			// Select the first index.
			this.comboBoxCountries.SelectedIndex = 0;
		}

		/// <summary>
		/// Updates the Alexa ranking.
		/// </summary>
		private void OnUpdateRanking()
		{
			// Update the list of sites.
			foreach (AlexaRank rank in this.ranking)
			{
				// Create a new item.
				ListViewItem item = new ListViewItem(new string[] { rank.Position.ToString(), rank.Site });
				item.Tag = rank;
				item.ImageIndex = 0;
				// Add the item to the list.
				this.listView.Items.Add(item);
			}
			// Enable the save button.
			this.buttonSave.Enabled = this.ranking.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user exports the data to a file.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			// Show the save file dialog.
			if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				// Save according to the file filter.
				switch (this.saveFileDialog.FilterIndex)
				{
					case 1:
						this.ranking.SaveXml(this.saveFileDialog.FileName);
						break;
					case 2:
						this.ranking.SaveText(this.saveFileDialog.FileName);
						break;
				}
			}
		}
	}
}
