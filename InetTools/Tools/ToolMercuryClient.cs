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
using System.Threading;
using System.Windows.Forms;
using DotNetApi.Web;
using InetAnalytics;
using InetCommon.Tools;
using InetTools.Controls.Mercury;
using InetTools.Tools.Mercury;

namespace InetTools.Tools
{
	/// <summary>
	/// A Mercury tool item that uploads topology data to the Mercury web service.
	/// </summary>
	public sealed class ToolMercuryClient : ToolItem
	{
		private readonly MercuryConfig config;
		private readonly ControlMercuryClient control;
		private readonly MercuryRequest request = new MercuryRequest();

		/// <summary>
		/// Creates a new tool instance.
		/// </summary>
		/// <param name="tool">The tool for this tool item.</param>
		/// <param name="api">The tool API.</param>
		public ToolMercuryClient(Tool tool, IToolApi api)
			: base(tool, api)
		{
			// Create the configuration.
			this.config = new MercuryConfig(api);

			// Create the control.
			this.control = new ControlMercuryClient(this.config);

			// Create the tool methods.
			this.Tool.AddMethod(
				new Guid("24FDC1EC-FA12-4A42-B410-3A868B9576D9"),
				Resources.ToolMercuryClientMethodUploadSessionFromPlanetLabName,
				Resources.ToolMercuryClientMethodUploadSessionFromPlanetLabDescription,
				this.UploadSessionFromPlanetLab);
			this.Tool.AddMethod(
				new Guid("5AD386C4-EA86-4C31-A0A1-DCD6CF1107B2"),
				Resources.ToolMercuryClientMethodUploadTracerouteFromPlanetLabName,
				Resources.ToolMercuryClientMethodUploadTracerouteFromPlanetLabDescription,
				this.UploadTracerouteFromPlanetLab);
		}

		// Public properties.

		/// <summary>
		/// Gets the user interface control for this tool.
		/// </summary>
		public override Control Control { get { return this.control; } }

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose the control.
				this.control.Dispose();
			}
			// Call the base clas method.
			base.Dispose(disposing);
		}

		// Private method.

		/// <summary>
		/// Uploads a session information to the Mercury web service.
		/// </summary>
		/// <param name="token">The cancellation token.</param>
		/// <param name="arguments">The method arguments.</param>
		/// <returns>The method result.</returns>
		private object UploadSessionFromPlanetLab(CancellationToken token, params object[] arguments)
		{
			// Check the number of arguments.
			if (arguments.Length != 4) throw new ArgumentException("This method takes only 4 arguments.");

			// Cheeck the arguments type.
			if (!(arguments[0] is Guid)) throw new ArgumentNullException("The session identifier argument is of the wrong type (it must be a GUID).");
			if (!(arguments[1] is string)) throw new ArgumentNullException("The author argument is of the wrong type (it must be a string).");
			if (!(arguments[2] is string)) throw new ArgumentNullException("The description argument is of the wrong type (it must be a string).");
			if (!(arguments[3] is DateTime)) throw new ArgumentNullException("The timestamp argument is of the wrong type (it must be a date-time).");

			// Get the parameters.
			Guid id = (Guid)arguments[0];
			string author = arguments[1] as string;
			string description = arguments[2] as string;
			DateTime timestamp = (DateTime)arguments[3];

			// Check the arguments.
			if (null == author) throw new ArgumentNullException("The author argument is null.");
			if (null == description) throw new ArgumentNullException("The description argument is null.");

			// The success flag.
			bool success = false;
			// The exception.
			Exception exception = null;

			// Create a wait handle.
			using (ManualResetEvent wait = new ManualResetEvent(false))
			{
				// Upload the data to Mercury.
				IAsyncResult asyncResult = this.request.BeginUploadSession(new Uri(this.config.UploadSessionUrl), id, author, description, timestamp, (AsyncWebResult result) =>
				{
					try
					{
						// Complete the request.
						this.request.End(result);
						// Set the success to true.
						success = true;
					}
					catch (Exception ex)
					{
						// Set the exception.
						exception = ex;
					}
					finally
					{
						// Set the wait handle to the signaled state.
						wait.Set();
					}
				});

				// Wait for the request to complete.
				wait.WaitOne();
			}

			// If an exception occurred during the request.
			if (null != exception)
			{
				throw exception;
			}

			// Return the success flag.
			return success;
		}

		/// <summary>
		/// Uploads a traceroute to the Mercury web service.
		/// </summary>
		/// <param name="token">The cancellation token.</param>
		/// <param name="arguments">The method arguments.</param>
		/// <returns>The method result.</returns>
		private object UploadTracerouteFromPlanetLab(CancellationToken token, params object[] arguments)
		{
			// Check the number of arguments.
			if (arguments.Length != 3) throw new ArgumentException("This method takes only 3 arguments.");

			// Cheeck the arguments type.
			if (!(arguments[0] is Guid)) throw new ArgumentNullException("The identifier argument is of the wrong type (it must be a GUID).");
			if (!(arguments[1] is string)) throw new ArgumentNullException("The source hostname argument is of the wrong type (it must be a string).");
			if (!(arguments[2] is string)) throw new ArgumentNullException("The traceroute data argument is of the wrong type (it must be a string).");

			// Get the parameters.
			Guid id = (Guid)arguments[0];
			string sourceHostname = arguments[1] as string;
			string data = arguments[2] as string;

			// Check the arguments.
			if (null == sourceHostname) throw new ArgumentNullException("The source hostname argument is null.");
			if (null == data) throw new ArgumentNullException("The traceroute data argument is null.");

			// Resolve the IP address of the PlanetLab node.
			IPAddress[] sourceIps = Dns.GetHostAddresses(sourceHostname);

			// Create the traceroute.
			MercuryTraceroute traceroute = new MercuryTraceroute(id, sourceHostname, sourceIps.Length > 0 ? sourceIps[0] : null, data);

			// The success flag.
			bool success = false;
			// The exception.
			Exception exception = null;

			// Create a wait handle.
			using (ManualResetEvent wait = new ManualResetEvent(false))
			{
				// Upload the data to Mercury.
				IAsyncResult asyncResult = this.request.BeginUploadTraceroute(new Uri(this.config.UploadTracerouteUrl), traceroute, (AsyncWebResult result) =>
					{
						try
						{
							// Complete the request.
							this.request.End(result);
							// Set the success to true.
							success = true;
						}
						catch (Exception ex)
						{
							// Set the exception.
							exception = ex;
						}
						finally
						{
							// Set the wait handle to the signaled state.
							wait.Set();
						}
					});

				// Wait for the request to complete.
				wait.WaitOne();
			}

			// If an exception occurred during the request.
			if (null != exception)
			{
				throw exception;
			}

			// Return the success flag.
			return success;
		}
	}
}
