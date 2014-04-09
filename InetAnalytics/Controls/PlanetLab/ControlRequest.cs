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
using DotNetApi;
using DotNetApi.Web;
using DotNetApi.Web.XmlRpc;
using DotNetApi.Windows.Controls;
using InetCommon;
using InetCrawler;
using PlanetLab.Requests;

namespace InetAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// The base control that displays PlanetLab information.
	/// </summary>
	public class ControlRequest : NotificationControl
	{
		/// <summary>
		/// An enumeration representing the request status.
		/// </summary>
		protected enum RequestStatus
		{
			Success = 0,
			Warning = 1,
			Error = 2,
			Busy = 3
		}

		/// <summary>
		/// A class representing the request state.
		/// </summary>
		protected class RequestState
		{
			/// <summary>
			/// Creates a new request state instance.
			/// </summary>
			/// <param name="actionRequestStarted">The request started action.</param>
			/// <param name="actionRequestResult">The request result action.</param>
			/// <param name="actionRequestCanceled">The request canceled action.</param>
			/// <param name="actionRequestException">The request exception action.</param>
			/// <param name="actionRequestFinished">The request finished action.</param>
			public RequestState(
				Action<RequestState> actionRequestStarted,
				Action<XmlRpcResponse, RequestState> actionRequestResult,
				Action<RequestState> actionRequestCanceled,
				Action<Exception, RequestState> actionRequestException,
				Action<RequestState> actionRequestFinished
				)
			{
				this.ActionRequestStarted = actionRequestStarted;
				this.ActionRequestResult = actionRequestResult;
				this.ActionRequestCanceled = actionRequestCanceled;
				this.ActionRequestException = actionRequestException;
				this.ActionRequestFinished = actionRequestFinished;
				this.Success = false;
			}

			/// <summary>
			/// Gets the request started action.
			/// </summary>
			public Action<RequestState> ActionRequestStarted { get; private set; }
			/// <summary>
			/// Gets the request result action.
			/// </summary>
			public Action<XmlRpcResponse, RequestState> ActionRequestResult { get; private set; }
			/// <summary>
			/// Gets the request canceled action.
			/// </summary>
			public Action<RequestState> ActionRequestCanceled { get; private set; }
			/// <summary>
			/// Gets the request exception action.
			/// </summary>
			public Action<Exception, RequestState> ActionRequestException { get; private set; }
			/// <summary>
			/// Gets the request finished action.
			/// </summary>
			public Action<RequestState> ActionRequestFinished { get; private set; }
			/// <summary>
			/// Indicates whether the request has been successful.
			/// </summary>
			public bool Success { get; set; }
		}

		private readonly object sync = new object();

		private PlRequest request = null;
		private IAsyncResult result = null;

		private PlRequest pendingRequest = null;
		private string pendingUsername = null;
		private SecureString pendingPassword = null;
		private object[] pendingParameters = null;
		private RequestState pendingState = null;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlRequest()
		{
		}

		// Protected methods.

		/// <summary>
		/// Begins an asynchrnous PlanetLab request using the pending values.
		/// </summary>
		protected void BeginRequest()
		{
			// Check that all required pending values are not null.
			if (null == this.pendingRequest) return;
			if (null == this.pendingUsername) return;
			if (null == this.pendingPassword) return;

			// Begin a normal requets using the pending values.
			this.BeginRequest(
				this.pendingRequest,
				this.pendingUsername,
				this.pendingPassword,
				this.pendingParameters,
				this.pendingState);
		}

		/// <summary>
		/// Begins a new asynchronous PlanetLab request.
		/// </summary>
		/// <param name="request">The PlanetLab request.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <param name="parameter">The request parameter.</param>
		/// <param name="state">The request state.</param>
		protected void BeginRequest(PlRequest request, string username, SecureString password, object parameter = null, RequestState state = null)
		{
			this.BeginRequest(
				request,
				username,
				password,
				parameter != null ? new object[] { parameter } : null,
				state);
		}

		/// <summary>
		/// Begins a new asynchronous PlanetLab request.
		/// </summary>
		/// <param name="request">The PlanetLab request.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <param name="parameters">The request parameters.</param>
		/// <param name="state">The request state.</param>
		protected void BeginRequest(PlRequest request, string username, SecureString password, object[] parameters, RequestState state = null)
		{
			// Set the pending values to null.
			this.pendingRequest = null;
			this.pendingUsername = null;
			this.pendingPassword = null;
			this.pendingParameters = null;
			this.pendingState = null;

			lock (this.sync)
			{
				// If a request is already in progress.
				if (null != this.request)
				{
					// Set the pending values.
					this.pendingRequest = request;
					this.pendingUsername = username;
					this.pendingPassword = password;
					this.pendingParameters = parameters;
					this.pendingState = state;
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
						"Refreshing the PlanetLab information...",
						true,
						-1,
						(object[] param) =>
							{
								this.OnRequestStarted(state);
							});

					// If the parameter is not null.
					if (null != parameters)
					{
						// Begin the request with a parameter.
						this.result = request.Begin(
							username,
							password,
							parameters,
							this.OnCallback,
							state
							);
					}
					else
					{
						// Begin the request without a parameter.
						this.result = request.Begin(
							username,
							password,
							this.OnCallback,
							state
							);
					}
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
						"Refreshing the PlanetLab information failed. {0}".FormatWith(exception.Message),
						false,
						(int)ApplicationConfig.MessageCloseDelay.TotalMilliseconds,
						(object[] param) =>
							{
								// Call the request exception event handler.
								this.OnRequestException(exception, state);
								// Call the request finished event handler.
								this.OnRequestFinished(state);
							});
				}
			}
		}

		/// <summary>
		/// Cancels the current request, if any.
		/// </summary>
		protected void CancelRequest()
		{
			lock (sync)
			{
				// If there is no current request, do nothing.
				if (null == this.request) return;
				// Cancel the current request
				this.request.Cancel(this.result);
				// Set the pending values to null.
				this.pendingRequest = null;
				this.pendingUsername = null;
				this.pendingPassword = null;
				this.pendingParameters = null;
				this.pendingState = null;
			}
		}

		/// <summary>
		/// An event handler called when the current request starts, and the notification box is displayed.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected virtual void OnRequestStarted(RequestState state)
		{
			// If the request state is not null.
			if (null != state)
			{
				// If the delegate for this method is not null.
				if (null != state.ActionRequestStarted)
				{
					// Call the delegate.
					state.ActionRequestStarted(state);
				}
			}
		}

		/// <summary>
		/// An event handler called when the control completes an asynchronous request for a PlanetLab resource.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		/// <param name="state">The request state.</param>
		protected virtual void OnRequestResult(XmlRpcResponse response, RequestState state)
		{
			// If the request state is not null.
			if (null != state)
			{
				// If the delegate for this method is not null.
				if (null != state.ActionRequestResult)
				{
					// Call the delegate.
					state.ActionRequestResult(response, state);
				}
			}
		}

		/// <summary>
		/// An event handler called when an asynchronous request for a PlanetLab resource was canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected virtual void OnRequestCanceled(RequestState state)
		{
			// If the request state is not null.
			if (null != state)
			{
				// If the delegate for this method is not null.
				if (null != state.ActionRequestCanceled)
				{
					// Call the delegate.
					state.ActionRequestCanceled(state);
				}
			}
		}

		/// <summary>
		/// An event handler called when the current request throws an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		protected virtual void OnRequestException(Exception exception, RequestState state)
		{
			// If the request state is not null.
			if (null != state)
			{
				// If the delegate for this method is not null.
				if (null != state.ActionRequestException)
				{
					// Call the delegate.
					state.ActionRequestException(exception, state);
				}
			}
		}

		/// <summary>
		/// An event handler called when the current request finishes, and the notification box is hidden.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected virtual void OnRequestFinished(RequestState state)
		{
			// If the request state is not null.
			if (null != state)
			{
				// If the delegate for this method is not null.
				if (null != state.ActionRequestFinished)
				{
					// Call the delegate.
					state.ActionRequestFinished(state);
				}
			}
		}

		// Private methods.

		/// <summary>
		/// A callback method called when the control completes an asynchrnous request for a PlanetLab resource.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		private void OnCallback(AsyncWebResult result)
		{
			lock (this.sync)
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
							(int)ApplicationConfig.MessageCloseDelay.TotalMilliseconds,
							(object[] parameters) =>
								{
									// Call the complete request event handler.
									this.OnRequestResult(response, asyncResult.AsyncState as RequestState);
									// Call the end request event handler.
									this.OnRequestFinished(asyncResult.AsyncState as RequestState);
								});
					}
					else
					{
						// Display an error notification message.
						this.ShowMessage(
							Resources.GlobeWarning_48,
							"PlanetLab Error",
							"Refreshing the PlanetLab information has failed (RPC code {0} {1})".FormatWith(response.Fault.FaultCode, response.Fault.FaultString),
							false,
							(int)ApplicationConfig.MessageCloseDelay.TotalMilliseconds,
							(object[] paremeters) =>
								{
									// Call the complete request event handler.
									this.OnRequestResult(response, asyncResult.AsyncState as RequestState);
									// Call the end request event handler.
									this.OnRequestFinished(asyncResult.AsyncState as RequestState);
								});
					}
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
						this.HideMessage((object[] parameters) =>
							{
								// Call the cancel request handler.
								this.OnRequestCanceled(result.AsyncState as RequestState);
								// Call the end request handler.
								this.OnRequestFinished(result.AsyncState as RequestState);
							});
						// Begin a pending request, if any.
						this.BeginRequest();
					}
					else
					{
						// Display an error notification message.
						this.ShowMessage(
							Resources.GlobeError_48,
							"PlanetLab Update",
							"Refreshing the PlanetLab information has failed. {0}".FormatWith(exception.Message),
							false,
							(int)ApplicationConfig.MessageCloseDelay.TotalMilliseconds,
							(object[] parameters) =>
								{
									// Call the exception handler.
									this.OnRequestException(exception, result.AsyncState as RequestState);
									// Call the request finished event handler.
									this.OnRequestFinished(result.AsyncState as RequestState);
								});
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
						"Refreshing the PlanetLab information has failed. {0}".FormatWith(exception.Message),
						false,
						(int)ApplicationConfig.MessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
							{
								// Call the exception handler.
								this.OnRequestException(exception, result.AsyncState as RequestState);
								// Call the request finished event handler.
								this.OnRequestFinished(result.AsyncState as RequestState);
							});
				}
			}
		}
	}
}
