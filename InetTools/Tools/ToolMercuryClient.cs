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
using InetCrawler.Tools;
using InetTools.Controls;
using InetTools.Tools.Mercury;

namespace InetTools.Tools
{
	/// <summary>
	/// A tool that collects the top web sites from the Alexa ranking.
	/// </summary>
	[ToolInfo(
		"704886CD-9F15-444B-A0DF-A5068FE8E775",
		1, 0, 0, 0,
		"Mercury Client",
		"A tool that uploads topology data to the Mercury web service."
		)]
	public sealed class ToolMercuryClient : Tool
	{
		private readonly MercuryConfig config;
		private readonly ControlMercuryClient control;
		private readonly MercuryRequest request = new MercuryRequest();

		/// <summary>
		/// Creates a new tool instance.
		/// </summary>
		/// <param name="api">The tool API.</param>
		/// <param name="toolset">The toolset information.</param>
		public ToolMercuryClient(IToolApi api, ToolsetInfoAttribute toolset)
			: base(api, toolset)
		{
			// Create the configuration.
			this.config = new MercuryConfig(api);

			// Create the control.
			this.control = new ControlMercuryClient(api, this.config);

			// Create the tool methods.
			this.AddMethod(
				new Guid("5AD386C4-EA86-4C31-A0A1-DCD6CF1107B2"),
				Properties.Resources.ToolMercuryClientMethodUploadTracerouteFromPlanetLabName,
				Properties.Resources.ToolMercuryClientMethodUploadTracerouteFromPlanetLabDescription,
				this.UploadTracerouteFromPlanetLab);

			//// Create the Alexa ranking database table.
			//this.dbTableRanking = new DbTableTemplate<AlexaRankDbObject>(new Guid("7D65B301-C4C9-4823-9D64-0EB4E2CA43F4"), "Alexa ranking");
			//this.dbTableHistory = new DbTableTemplate<AlexaHistoryDbObject>(new Guid("BD058EA2-0D75-4671-80A0-5A94A979B7E9"), "Alexa history");

			//// Add the tables to the database.
			//this.Api.DatabaseAddTable(this.dbTableRanking);
			//this.Api.DatabaseAddTable(this.dbTableHistory);

			//this.Api.DatabaseAddRelationship(this.dbTableHistory, this.dbTableRanking, "Timestamp", "Timestamp", true);
			//this.Api.DatabaseAddRelationship(this.dbTableHistory, this.dbTableRanking, "Global", "Global", true);
			//this.Api.DatabaseAddRelationship(this.dbTableHistory, this.dbTableRanking, "Country", "Country", true);
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
				// Remove the tables to the database.
				//this.Api.DatabaseRemoveTable(this.dbTableRanking);
				//this.Api.DatabaseRemoveTable(this.dbTableHistory);

				// Dispose the control.
				this.control.Dispose();
			}
			// Call the base clas method.
			base.Dispose(disposing);
		}

		// Private method.

		/// <summary>
		/// Uploads a traceroute to the Mercury web service.
		/// </summary>
		/// <param name="token">The cancellation token.</param>
		/// <param name="arguments">The method arguments.</param>
		/// <returns>The method result.</returns>
		private object UploadTracerouteFromPlanetLab(CancellationToken token, params object[] arguments)
		{
			// Check the number of arguments.
			if (arguments.Length != 2) throw new ArgumentException("This method takes only 2 arguments.");

			// Get the parameters.
			string sourceHostname = arguments[0] as string;
			string data = arguments[1] as string;

			// Check the arguments.
			if (null == sourceHostname) throw new ArgumentNullException("The source hostname argument is null or of the wrong type.");
			if (null == data) throw new ArgumentNullException("The traceroute data argument is null or of the wrong type.");

			// Resolve the IP address of the PlanetLab node.
			IPAddress[] sourceIps = Dns.GetHostAddresses(sourceHostname);

			// Create the traceroute.
			MercuryTraceroute traceroute = new MercuryTraceroute(sourceHostname, sourceIps.Length > 0 ? sourceIps[0] : null, data);

			// The success flag.
			bool success = false;
			// The exception.
			Exception exception = null;

			// Create a wait handle.
			using (ManualResetEvent wait = new ManualResetEvent(false))
			{
				// Upload the data to Mercury.
				IAsyncResult asyncResult = this.request.Begin(new Uri(this.config.ServerUrl), traceroute, (AsyncWebResult result) =>
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
