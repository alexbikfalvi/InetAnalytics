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
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Web;
using DotNetApi.Windows.Controls;
using YtAnalytics.Forms.Net;
using YtCrawler;
using YtCrawler.Log;
using YtCrawler.Status;

namespace YtAnalytics.Controls.Testing
{
	/// <summary>
	/// A control class for testing web request.
	/// </summary>
	public partial class ControlTestingWebRequest : ThreadSafeControl
	{
		private static string logSource = "Testing Web Request";

		// Private variables.

		private Crawler crawler = null;
		private StatusHandler status = null;

		private Uri uri = null;
		private AsyncWebRequest request = new AsyncWebRequest();
		private IAsyncResult result = null;

		private FormHttpAddRequestHeader formAddHttpRequestHeader = new FormHttpAddRequestHeader();
		private FormHttpHeaderProperties formHttpHeader = new FormHttpHeaderProperties();

		private EncodingInfo[] encodings;
		private Dictionary<int, int> encodingPages = new Dictionary<int,int>();

		// Public declarations

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlTestingWebRequest()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Populate the encoding combo box.
			this.encodings = Encoding.GetEncodings();
			for (int index = 0; index < this.encodings.Length; index++)
			{
				this.comboBoxEncoding.Items.Add("({0}) {1}".FormatWith(this.encodings[index].CodePage, this.encodings[index].DisplayName));
				this.encodingPages.Add(this.encodings[index].CodePage, index);
			}
		}
		
		// Public methods.

		/// <summary>
		/// Initialized the control with the specified crawler.
		/// </summary>
		/// <param name="crawler">The crawler.</param>
		public void Initialize(Crawler crawler)
		{
			// Set the crawler.
			this.crawler = crawler;

			// Get the crawler status.
			this.status = this.crawler.Status.GetHandler(this);
			this.status.Send("Ready.", Resources.Information_16);

			// Enable the control.
			this.Enabled = true;

			// Load the settings.
			this.OnLoad();
		}

		// Private methods.

		/// <summary>
		/// Starts an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Change the controls state.
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;
			this.textBoxUrl.Enabled = false;

			// Clear the response headers.
			this.listViewResponseHeaders.Items.Clear();
			// Clear the response data.
			this.textBoxResponseData.Text = string.Empty;
			// Clear the status bar.
			this.status.Send("Executing the HTTP request...", Resources.Busy_16);

			// Log
			this.log.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlTestingWebRequest.logSource,
				"Started an HTTP request for the URL \'{0}\'.",
				new object[] { this.textBoxUrl.Text }));

			// Clear the results text box.
			this.textBoxResponseData.Clear();

			try
			{
				// Create the URI.
				this.uri = new Uri(this.textBoxUrl.Text);
				// Create the request.
				AsyncWebResult result = AsyncWebRequest.Create(this.uri, this.Callback, null);
				
				// Set the method.
				result.Request.Method = this.comboBoxMethod.SelectedItem as string;
				// Set the request fixed headers.
				if (this.checkBoxAccept.Checked)
					result.Request.Accept = this.textBoxAccept.Text;
				if (this.checkBoxContentType.Checked)
					result.Request.ContentType = this.textBoxContentType.Text;
				if (this.checkBoxDate.Checked)
					result.Request.Date = this.dateTimePicker.Value;
				if (this.checkBoxExpect.Checked)
					result.Request.Expect = this.textBoxExpect.Text;
				if (this.checkBoxReferer.Checked)
					result.Request.Referer = this.textBoxReferer.Text;
				if (this.checkBoxUserAgent.Checked)
					result.Request.UserAgent = this.textBoxUserAgent.Text;
				
				// Set the request custom headers.
				foreach (ListViewItem item in this.listViewRequestHeaders.Items)
				{
					result.Request.Headers.Add(item.SubItems[0].Text, item.SubItems[1].Text);
				}

				// If the method is POST and the data is not empty.
				if ((result.Request.Method == "POST") && (this.textBoxRequestData.Text != string.Empty))
				{
					// Get the current encoding.
					Encoding encoding = Encoding.GetEncoding(this.encodings[this.comboBoxEncoding.SelectedIndex].CodePage);

					// Add the data to the send buffer.
					result.SendData.Append(this.textBoxRequestData.Text, encoding);
				}

				// Begin the request.
				this.result = this.request.Begin(result);  
			}
			catch (Exception exception)
			{
				// Update the status label.
				this.status.Send("The HTTP request for web URL failed. {0}".FormatWith(exception.Message), Resources.Error_16);
				// Log the result.
				this.log.Add(this.crawler.Log.Add(
					LogEventLevel.Important,
					LogEventType.Error,
					ControlTestingWebRequest.logSource,
					"The HTTP request for web URL \'{0}\' failed. {1}",
					new object[] { this.textBoxUrl.Text, exception.Message },
					exception));
			}
		}

		/// <summary>
		/// Cancels an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			// Cancel the request.
			this.request.Cancel(this.result);
			// Disable the stop button.
			this.buttonStop.Enabled = false;
		}

		/// <summary>
		/// Completes an asynchronous request for the selected video feed.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		private void Callback(IAsyncResult result)
		{
			if (this.InvokeRequired)
				this.Invoke(new AsyncCallback(this.Callback), new object[] { result });
			else
			{
				try
				{
					// Complete the request, and get the asynchronous web result.
					AsyncWebResult asyncResult = this.request.End(result);

					// Get the encoding for the received response.
					Encoding encoding = Encoding.GetEncoding(asyncResult.Response.CharacterSet);

					// Display the response data.
					this.textBoxResponseData.Text = (null != asyncResult.ReceiveData.Data) ? encoding.GetString(asyncResult.ReceiveData.Data) : string.Empty;

					// Display the response headers.
					foreach (string header in asyncResult.Response.Headers)
					{
						ListViewItem item = new ListViewItem(new string[] { header, asyncResult.Response.Headers[header] });
						item.ImageIndex = 0;
						this.listViewResponseHeaders.Items.Add(item);
					}

					// Update the status label.
					this.status.Send(
						"The HTTP request for the web URL completed successfully.",
						"{0} bytes of data received".FormatWith(asyncResult.ReceiveData.Data != null ? asyncResult.ReceiveData.Data.LongLength : 0),
						Resources.Success_16); 
					// Log the result.
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Verbose,
						LogEventType.Success,
						ControlTestingWebRequest.logSource,
						"The HTTP request for the web URL \'{0}\' completed successfully.",
						new object[] { this.textBoxUrl.Text }));
				}
				catch (WebException exception)
				{
					if (exception.Status == WebExceptionStatus.RequestCanceled)
					{
						// Update the status label.
						this.status.Send("The HTTP request for the web URL has been canceled.", Resources.Canceled_16);
						// Log the result.
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Verbose,
							LogEventType.Canceled,
							ControlTestingWebRequest.logSource,
							"The HTTP request for the web URL \'{0}\' has been canceled.",
							new object[] { this.textBoxUrl.Text }));
					}
					else
					{
						// Update the status label.
						this.status.Send("The HTTP request for the web URL failed. {0}".FormatWith(exception.Message), Resources.Error_16);
						// Log the result.
						this.log.Add(this.crawler.Log.Add(
							LogEventLevel.Important,
							LogEventType.Error,
							ControlTestingWebRequest.logSource,
							"The HTTP request for the web URL \'{0}\' failed. {1}",
							new object[] { this.textBoxUrl.Text, exception.Message },
							exception));
					}
				}
				catch (Exception exception)
				{
					// Update the status label.
					this.status.Send("The HTTP request for the web URL \'{0}\' failed. {1}".FormatWith(this.textBoxUrl.Text, exception.Message), Resources.Error_16);
					// Log the result.
					this.log.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlTestingWebRequest.logSource,
						"The HTTP request for the web URL \'{0}\' failed. {1}",
						new object[] { this.textBoxUrl.Text, exception.Message },
						exception));
				}
				finally
				{
					this.buttonStart.Enabled = true;
					this.buttonStop.Enabled = false;
					this.textBoxUrl.Enabled = true;
				}
			}
		}

		/// <summary>
		/// An event handler called when the request input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			// Enable the start button.
			this.buttonStart.Enabled = this.textBoxUrl.Text != string.Empty;
			// Enable the save and undo buttons.
			this.buttonSave.Enabled = true;
			this.buttonUndo.Enabled = true;
		}

		/// <summary>
		/// An event handler called when adding a new HTTP request header.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddHeader(object sender, EventArgs e)
		{
			// Show the add HTTP request header dialog.
			if (this.formAddHttpRequestHeader.ShowDialog(this) == DialogResult.OK)
			{
				// If the users adds a new header, check the header does not exist.
				if (!this.crawler.Testing.WebRequest.HasHeader(this.formAddHttpRequestHeader.Header))
				{
					// Try add the header to the testing configuration.
					if (this.crawler.Testing.WebRequest.AddHeader(
						this.formAddHttpRequestHeader.Header,
						this.formAddHttpRequestHeader.Value))
					{
						// Add a new list view item with the specified header.
						ListViewItem item = new ListViewItem(new string[] {
							this.formAddHttpRequestHeader.Header,
							this.formAddHttpRequestHeader.Value },
							0);
						item.Tag = this.formAddHttpRequestHeader.Header;
						this.listViewRequestHeaders.Items.Add(item);
						// Enable the save and undo buttons.
						this.buttonSave.Enabled = true;
						this.buttonUndo.Enabled = true;
					}
					else
					{
						// Show a warning message.
						MessageBox.Show(
							this,
							"The header \'{0}\' is restricted for the HTTP request.".FormatWith(this.formAddHttpRequestHeader.Header),
							"HTTP Header Restricted",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);
					}
				}
				else
				{
					// Show a warning message.
					MessageBox.Show(
						this,
						"The header \'{0}\' already exists in the headers list.".FormatWith(this.formAddHttpRequestHeader.Header),
						"HTTP Header Already Exists",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
		}

		/// <summary>
		/// An event handler called when removing an HTTP request header.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemoveHeader(object sender, EventArgs e)
		{
			// If there are no headers selected, do nothing.
			if (this.listViewRequestHeaders.SelectedItems.Count == 0) return;
			// Get the selected header.
			string header = this.listViewRequestHeaders.SelectedItems[0].Text;
			// Else, remove the header.
			this.crawler.Testing.WebRequest.RemoveHeader(header);
			// Remove the selected list view item.
			this.listViewRequestHeaders.Items.Remove(this.listViewRequestHeaders.SelectedItems[0]);
			// Enable the save and undo buttons.
			this.buttonSave.Enabled = true;
			this.buttonUndo.Enabled = true;
		}

		/// <summary>
		/// An event handler called when changing an HTTP request header.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChangeHeader(object sender, EventArgs e)
		{
			// If there are no headers selected, do nothing.
			if (this.listViewRequestHeaders.SelectedItems.Count == 0) return;
			// Get the header and value.
			string header = this.listViewRequestHeaders.SelectedItems[0].SubItems[0].Text;
			string value = this.listViewRequestHeaders.SelectedItems[0].SubItems[1].Text;
			// Show the change HTTP header dialog.
			if (this.formAddHttpRequestHeader.ShowDialog(this, header, value) == DialogResult.OK)
			{
				// If the users changes an existing header, check the header exists.
				if (this.crawler.Testing.WebRequest.HasHeader(this.formAddHttpRequestHeader.Header))
				{
					// Try change the header to the testing configuration.
					if (this.crawler.Testing.WebRequest.ChangeHeader(
						this.formAddHttpRequestHeader.Header,
						this.formAddHttpRequestHeader.Value))
					{
						// Update the selected list view item.
						this.listViewRequestHeaders.SelectedItems[0].SubItems[1].Text = this.formAddHttpRequestHeader.Value;
						// Enable the save and undo buttons.
						this.buttonSave.Enabled = true;
						this.buttonUndo.Enabled = true;
					}
					else
					{
						// Show a warning message.
						MessageBox.Show(
							this,
							"The header \'{0}\' is restricted for the HTTP request.".FormatWith(this.formAddHttpRequestHeader.Header),
							"HTTP Header Restricted",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning);
					}
				}
				else
				{
					// Show a warning message.
					MessageBox.Show(
						this,
						"The header \'{0}\' does not exist in the headers list.".FormatWith(this.formAddHttpRequestHeader.Header),
						"HTTP Header Does not Exists",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
			}
		}

		/// <summary>
		/// An event handler called when the user views an HTTP request header.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnViewHeader(object sender, EventArgs e)
		{
			// If no headers are selected, do nothing.
			if (this.listViewResponseHeaders.SelectedItems.Count == 0) return;
			// Get the header information.
			string header = this.listViewResponseHeaders.SelectedItems[0].SubItems[0].Text;
			string value = this.listViewResponseHeaders.SelectedItems[0].SubItems[1].Text;
			// Open an HTTP header properties dialog for the selected header.
			this.formHttpHeader.ShowDialog(this, header, value);
		}

		/// <summary>
		/// An event handler called when the selection of the request headers has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRequestHeadersSelectionChanged(object sender, EventArgs e)
		{
			this.buttonChangeHeader.Enabled = this.listViewRequestHeaders.SelectedItems.Count != 0;
			this.buttonRemoveHeader.Enabled = this.listViewRequestHeaders.SelectedItems.Count != 0;
		}

		/// <summary>
		/// An event handler called when the selection of the response headers has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnResponseHeadersSelectionChanged(object sender, EventArgs e)
		{
			this.buttonViewHeader.Enabled = this.listViewResponseHeaders.SelectedItems.Count != 0;
		}

		/// <summary>
		/// An event handler called when the user clicks on the save button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			// Save the input settings to the registry.
			this.crawler.Testing.WebRequest.Url = this.textBoxUrl.Text;
			this.crawler.Testing.WebRequest.Method = this.comboBoxMethod.SelectedItem as string;
			this.crawler.Testing.WebRequest.Data = this.textBoxRequestData.Text;
			this.crawler.Testing.WebRequest.DataEncoding = this.encodings[this.comboBoxEncoding.SelectedIndex].CodePage;
			
			this.crawler.Testing.WebRequest.AcceptHeaderChecked = this.checkBoxAccept.Checked;
			this.crawler.Testing.WebRequest.ContentTypeHeaderChecked = this.checkBoxContentType.Checked;
			this.crawler.Testing.WebRequest.DateHeaderChecked = this.checkBoxDate.Checked;
			this.crawler.Testing.WebRequest.ExpectHeaderChecked = this.checkBoxExpect.Checked;
			this.crawler.Testing.WebRequest.RefererHeaderChecked = this.checkBoxReferer.Checked;
			this.crawler.Testing.WebRequest.UserAgentHeaderChecked = this.checkBoxUserAgent.Checked;
			
			this.crawler.Testing.WebRequest.AcceptHeaderValue = this.textBoxAccept.Text;
			this.crawler.Testing.WebRequest.ContentTypeHeaderValue = this.textBoxContentType.Text;
			this.crawler.Testing.WebRequest.DateHeaderValue = this.dateTimePicker.Value;
			this.crawler.Testing.WebRequest.ExpectHeaderValue = this.textBoxExpect.Text;
			this.crawler.Testing.WebRequest.RefererHeaderValue = this.textBoxReferer.Text;
			this.crawler.Testing.WebRequest.UserAgentHeaderValue = this.textBoxUserAgent.Text;
			
			this.crawler.Testing.WebRequest.SaveHeaders();
			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// An event handler called when the user clicks on the undo button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUndo(object sender, EventArgs e)
		{
			// Reload the input settings from the registry.
			this.OnLoad();
		}

		/// <summary>
		/// Loads the current request settings from the registry.
		/// </summary>
		private void OnLoad()
		{
			// Select the default settings.
			this.textBoxUrl.Text = this.crawler.Testing.WebRequest.Url;
			this.comboBoxMethod.SelectedItem = this.crawler.Testing.WebRequest.Method;
			this.textBoxRequestData.Text = this.crawler.Testing.WebRequest.Data;
			this.comboBoxEncoding.SelectedIndex = this.encodingPages[this.crawler.Testing.WebRequest.DataEncoding];

			this.checkBoxAccept.Checked = this.crawler.Testing.WebRequest.AcceptHeaderChecked;
			this.checkBoxContentType.Checked = this.crawler.Testing.WebRequest.ContentTypeHeaderChecked;
			this.checkBoxDate.Checked = this.crawler.Testing.WebRequest.DateHeaderChecked;
			this.checkBoxExpect.Checked = this.crawler.Testing.WebRequest.ExpectHeaderChecked;
			this.checkBoxReferer.Checked = this.crawler.Testing.WebRequest.RefererHeaderChecked;
			this.checkBoxUserAgent.Checked = this.crawler.Testing.WebRequest.UserAgentHeaderChecked;

			this.textBoxAccept.Text = this.crawler.Testing.WebRequest.AcceptHeaderValue;
			this.textBoxContentType.Text = this.crawler.Testing.WebRequest.ContentTypeHeaderValue;
			try { this.dateTimePicker.Value = this.crawler.Testing.WebRequest.DateHeaderValue; }
			catch { this.dateTimePicker.Value = DateTime.Now; }
			this.textBoxExpect.Text = this.crawler.Testing.WebRequest.ExpectHeaderValue;
			this.textBoxReferer.Text = this.crawler.Testing.WebRequest.RefererHeaderValue;
			this.textBoxUserAgent.Text = this.crawler.Testing.WebRequest.UserAgentHeaderValue;

			this.crawler.Testing.WebRequest.LoadHeaders();

			this.OnHeaderCheckedChanged(null, null);
			
			this.listViewRequestHeaders.Items.Clear();
			foreach (KeyValuePair<string, string> header in this.crawler.Testing.WebRequest.Headers)
			{
				// Add a new list view item with the specified header.
				ListViewItem item = new ListViewItem(new string[] {
						header.Key,
						header.Value },
					0);
				item.Tag = header.Key;
				this.listViewRequestHeaders.Items.Add(item);
			}

			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// An event handler called when the checked property of a header has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnHeaderCheckedChanged(object sender, EventArgs e)
		{
			// Change the enabled state of the header text boxes.
			this.textBoxAccept.Enabled = this.checkBoxAccept.Checked;
			this.textBoxContentType.Enabled = this.checkBoxContentType.Checked;
			this.dateTimePicker.Enabled = this.checkBoxDate.Checked;
			this.textBoxExpect.Enabled = this.checkBoxExpect.Checked;
			this.textBoxReferer.Enabled = this.checkBoxReferer.Checked;
			this.textBoxUserAgent.Enabled = this.checkBoxUserAgent.Checked;

			// Call the input changed event handler.
			this.OnInputChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the export button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnExport(object sender, EventArgs e)
		{
			// Show the save file dialog.
			if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				// If the user chooses to export the current settings, save the settings.
				this.OnSave(sender, e);

				try
				{
					// Try save the configuration to the specified file.
					this.crawler.Testing.WebRequest.SaveToFile(this.saveFileDialog.FileName);
					// Show a success dialog.
					MessageBox.Show(this, "The export was successful.", "Export Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception exception)
				{
					// Show an error dialog.
					MessageBox.Show(this, "The export failed. {0}".FormatWith(exception.Message), "Export Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the import button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnImport(object sender, EventArgs e)
		{
			// Show the open file dialog.
			if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					// Try and load the configuration from the specified file.
					this.crawler.Testing.WebRequest.LoadFromFile(this.openFileDialog.FileName);
					// Show a success dialog.
					MessageBox.Show(this, "The export was successful.", "Export Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception exception)
				{
					// Show an error dialog.
					MessageBox.Show(this, "The import failed. {0}".FormatWith(exception.Message), "Import Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				//  Load the new configuration.
				this.OnLoad();
			}
		}
	}
}
