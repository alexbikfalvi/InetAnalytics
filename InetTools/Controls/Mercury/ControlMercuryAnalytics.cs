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
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using InetAnalytics;
using InetCrawler.Tools;
using InetCrawler.Status;
using InetTools.Tools.Mercury;
using Renci.SshNet;

namespace InetTools.Controls.Mercury
{
	/// <summary>
	/// A class representing the control for the Mercury analytics tool.
	/// </summary>
	public partial class ControlMercuryAnalytics : NotificationControl
	{
		private readonly IToolApi api;
		private readonly MercuryConfig config;

		private readonly CrawlerStatusHandler status = null;

		private readonly object sync = new object();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		/// <param name="config">The configuration.</param>
		public ControlMercuryAnalytics(IToolApi api, MercuryConfig config)
		{
			// Initialize the component.
			this.InitializeComponent();
			
			// Set the API.
			this.api = api;

			// Set the configuration.
			this.config = config;

			// Load the configuration.
			this.OnLoadConfiguration();

			// Set the status.
			this.status = this.api.Status.GetHandler(this);
			this.status.Send(CrawlerStatus.StatusType.Normal, "Ready.", Resources.Information_16);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a request has started.
		/// </summary>
		private void OnRequestStarted()
		{
			// Set the controls enabled state.
		}

		/// <summary>
		/// An event handler called when a request has finished.
		/// </summary>
		private void OnRequestFinished()
		{
			// Set the controls enabled state.
		}

		/// <summary>
		/// Loads the tool configuration.
		/// </summary>
		private void OnLoadConfiguration()
		{
		}

		/// <summary>
		/// Saves the tool configuration.
		/// </summary>
		private void OnSaveConfiguration()
		{
		}

		/// <summary>
		/// An event handler called when the user clicks on the settings button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSettingsClick(object sender, EventArgs e)
		{
		}

		//ConnectionInfo sshConnectionInfo = new PasswordConnectionInfo("mercury.upf.edu", "abikfalvi", "Usr.Int.Upf.204967");

		//SshClient sshClient = null;
		//ForwardedPortLocal portDb = null;

//		MongoClientSettings dbSettings = new MongoClientSettings();


		/// <summary>
		/// An event handler called when the user clicks on the connect button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConnect(object sender, EventArgs e)
		{
			//try
			//{
			//	this.sshClient = new SshClient(sshConnectionInfo);
			//	this.sshClient.Connect();

			//	this.portDb = new ForwardedPortLocal("127.0.0.1", 27017, "localhost", 27017);

			//	this.sshClient.AddForwardedPort(this.portDb);

			//	this.portDb.Start();

			//			//MongoClientSettings dbSettings = new MongoClientSettings();

			//			//dbSettings.Server = new MongoServerAddress("127.0.0.1", 27017);

			//			//MongoClient dbClient = new MongoClient(dbSettings);

			//			//MongoServer dbServer = dbClient.GetServer();

			//			//MongoDatabase dbMercury = dbServer.GetDatabase("mercury");

			//			//System.Threading.Thread.Sleep(120000);

			//			//var collections = dbMercury.GetCollectionNames();
			//}
			//catch (Exception exception)
			//{
			//	MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}

		/// <summary>
		/// An event handler called when the user clicks on the disconnect button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDisconnect(object sender, EventArgs e)
		{
			//try
			//{
			//	this.portDb.Stop();
			//	this.portDb.Dispose();
			//	this.sshClient.Disconnect();
			//	this.sshClient.Dispose();
			//}
			//catch (Exception exception)
			//{
			//	MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//}
		}
	}
}
