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
using System.Security;
using DotNetApi.Web;
using DotNetApi.Web.XmlRpc;
using DotNetApi.Windows.Controls;
using PlanetLab.Requests;
using YtCrawler;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// The base control that displays PlanetLab information.
	/// </summary>
	public class ControlPlanetLab : NotificationControl
	{
		private delegate void RequestEndedEventHandler(XmlRpcResponse response);
		private delegate void RequestCompletedEventHandler();

		private PlRequest request = null;
		private IAsyncResult result = null;

		private PlRequest pendingRequest = null;
		private string pendingUsername = null;
		private SecureString pendingPassword = null;
		private int? pendingId = null;

		private RequestEndedEventHandler delegateRequestEnded;
		private RequestCompletedEventHandler delegateRequestCompleted;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLab()
		{
			// Create the delegates.
			this.delegateRequestEnded = new RequestEndedEventHandler(this.OnEndRequestUi);
			this.delegateRequestCompleted = new RequestCompletedEventHandler(this.OnCompleteRequestUi);
		}

		/// <summary>
		/// Cancels the current PlanetLab request, if any.
		/// </summary>
		public void CancelRequest()
		{
			// If there is no current request, do nothing.
			if (null == this.request) return;

			// Cancel the request.
			this.request.Cancel(this.result);
		}

		// Protected methods.

		/// <summary>
		/// Begins an asynchrnous PlanetLab request using the pending values.
		/// </summary>
		protected void BeginRequest()
		{
			// Check that all pending values are not null.
			if (null == this.pendingRequest) return;
			if (null == this.pendingUsername) return;
			if (null == this.pendingPassword) return;
			if (null == this.pendingId) return;

			// Begin a normal requets using the pending values.
			this.BeginRequest(
				this.pendingRequest,
				this.pendingUsername,
				this.pendingPassword,
				this.pendingId.Value);
		}

		/// <summary>
		/// Begins a new asynchronous PlanetLab request.
		/// </summary>
		/// <param name="request">The PlanetLab request.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <param name="id">The identifier of the object being requested.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		protected void BeginRequest(PlRequest request, string username, SecureString password, int id)
		{
			// Set the pending values to null.
			this.pendingRequest = null;
			this.pendingUsername = null;
			this.pendingPassword = null;
			this.pendingId = null;

			// If a request is already in progress.
			if (null != this.request)
			{
				// Set the pending values.
				this.pendingRequest = request;
				this.pendingUsername = username;
				this.pendingPassword = password;
				this.pendingId = id;
				// Cancel the current request
				this.request.Cancel(this.result);
				// Return.
				return;
			}

			// Save the new request.
			this.request = request;
			try
			{
				// Show the notification box.
				this.ShowMessage(
					Resources.GlobeClock_48,
					"PlanetLab Update",
					"Refreshing the PlanetLab information...");

				// Begin the request.
				this.result = request.Begin(
					username,
					password,
					id,
					this.OnCallback
					);
			}
			catch (Exception exception)
			{
				// Set the current request and result to null.
				this.request = null;
				this.result = null;

				// Show the notification box.
				this.ShowMessage(
					Resources.GlobeError_48,
					"PlanetLab Update",
					string.Format("Refreshing the PlanetLab information failed. {0}", exception.Message));

				// Rethrow the exception.
				throw exception;
			}
		}

		/// <summary>
		/// An event handler called when the control completes an asynchronous request for a PlanetLab resource.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		protected virtual void OnEndRequest(XmlRpcResponse response)
		{
			// Do nothing.
		}

		/// <summary>
		/// An event handler called when the current request is completed, and the notification box is hidden.
		/// </summary>
		protected virtual void OnCompleteRequest()
		{
			// Do nothing.
		}

		// Private methods.

		/// <summary>
		/// A callback method called when the control completes an asynchrnous request for a PlanetLab resource.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		private void OnCallback(AsyncWebResult result)
		{
			// If the current request is null, do nothing.
			if (null == this.request) return;

			try
			{
				// The asynchronous web result.
				AsyncWebResult asyncResult = null;
				// Complete the asyncrhonous request.
				XmlRpcResponse response = this.request.End(result, out asyncResult);

				// If no fault occurred during the XML-RPC request.
				if (response.Fault == null)
				{
					// Display a success notification message.
					this.ShowMessage(
						Resources.GlobeSuccess_48,
						"PlanetLab Update",
						"Refreshing the PlanetLab information completed successfully.",
						false,
						(int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
						this.OnCompleteRequest);
				}
				else
				{
					// Display an error notification message.
					this.ShowMessage(
						Resources.GlobeWarning_48,
						"PlanetLab Error",
						string.Format("Refreshing the PlanetLab nodes has failed (RPC code {0} {1})", response.Fault.FaultCode, response.Fault.FaultString),
						false,
						(int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
						this.OnCompleteRequest);
				}

				// Call the event handler.
				this.OnEndRequestUi(response);
				// Set the current request to null.
				this.request = null;
				this.result = null;
			}
			catch (WebException exception)
			{
				// Set the current request to null.
				this.request = null;
				this.result = null;
				// If the exception status is canceled.
				if (exception.Status == WebExceptionStatus.RequestCanceled)
				{
					// Hide the notification message.
					this.HideMessage();
					// Begin a pending request, if any.
					this.BeginRequest();
				}
				else
				{
					// Display an error notification message.
					this.ShowMessage(
						Resources.GlobeError_48,
						"PlanetLab Update",
						string.Format("Refreshing the PlanetLab information failed. {0}", exception.Message),
						false,
						(int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
						this.OnCompleteRequest);
				}
			}
			catch (Exception exception)
			{
				// Set the current request to null.
				this.request = null;
				this.result = null;
				// Display an error notification message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"PlanetLab Update",
					string.Format("Refreshing the PlanetLab information failed. {0}", exception.Message),
					false,
					(int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
					this.OnCompleteRequest);
			}
		}

		/// <summary>
		/// Ends the current request. The method is UI thread-safe.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		private void OnEndRequestUi(XmlRpcResponse response)
		{
			// Execute the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(this.delegateRequestEnded, new object[] { response });
			else this.OnEndRequest(response);
		}

		/// <summary>
		/// Completes the current request. The method is UI thread-safe.
		/// </summary>
		private void OnCompleteRequestUi()
		{
			// Execute the method on the UI thread.
			if (this.InvokeRequired) this.Invoke(this.delegateRequestCompleted);
			else this.OnCompleteRequest();
		}
	}
}
