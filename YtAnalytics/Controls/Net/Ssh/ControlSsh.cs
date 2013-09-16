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
using DotNetApi.Windows.Controls;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace YtAnalytics.Controls.Net.Ssh
{
	/// <summary>
	/// A control for connecting to a remote server using Secure Shell (SSH).
	/// </summary>
	public class ControlSsh : NotificationControl
	{
		// Client state.
		protected enum ClientState
		{
			Disconnected = 0,
			Connecting = 1,
			Connected = 2,
			Disconnecting = 3
		}

		private readonly object sync = new object();

		private ClientState state = ClientState.Disconnected;
		private SshClient client = null;
		private SshCommand command = null;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSsh()
		{
		}

		// Protected properties.

		/// <summary>
		/// An object used for synchronizing access to the SSH data structures.
		/// </summary>
		protected object Sync { get { return this.sync; } }
		/// <summary>
		/// Gets the state of the SSH client.
		/// </summary>
		protected ClientState State { get { return this.state; } }
		/// <summary>
		/// Gets the current SSH client.
		/// </summary>
		protected SshClient Client { get { return this.client; } }

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected override void Dispose(bool disposing)
		{
			// Call the base class methid.
			base.Dispose(disposing);
		}

		/// <summary>
		/// Connects the client to the SSH server specified in the connection info.
		/// </summary>
		/// <param name="info">The connection info.</param>
		protected void Connect(ConnectionInfo info)
		{
			// Synchronize access to the SSH client.
			lock (this.sync)
			{
				// If the client is not disconnected, throw an exception.
				if (this.State != ClientState.Disconnected)
				{
					throw new SshException("Cannot connect to the SSH server because the client is not disconnected.");
				}
				// If the client is not null, throw an exception.
				if (this.client != null)
				{
					throw new SshException("Cannot connect to the SSH server because a previous connection has not been released.");
				}

				// Create the SSH client.
				this.client = new SshClient(info);

				// Set the client event handlers.
				this.client.ErrorOccurred += this.SshErrorOccurred;
				this.client.HostKeyReceived += this.SshHostKeyReceived;
			}
		}

		/// <summary>
		/// An event handler called when connecting to an SSH server.
		/// </summary>
		protected virtual void OnConnecting()
		{
		}

		/// <summary>
		/// An event handler called when connected to an SSH server.
		/// </summary>
		protected virtual void OnConnected()
		{
		}

		/// <summary>
		/// An event handler called when disconnecting from an SSH server.
		/// </summary>
		protected virtual void OnDisconnecting()
		{
		}

		/// <summary>
		/// An event handler called when disconnected from an SSH server.
		/// </summary>
		protected virtual void OnDisconnected()
		{
		}

		/// <summary>
		/// An event handler called when an error occurres on an SSH server connection.
		/// </summary>
		/// <param name="exception">The error exception.</param>
		protected virtual void OnErrorOccurred(Exception exception)
		{
		}

		// Private methods.

		private void OnConnectingInternal()
		{
		}

		private void OnConnectedInternal()
		{
		}

		private void OnDisconnectingInternal()
		{
			// Change the state.
			this.state = ClientState.Disconnecting;
			// Call the event handler.
			this.OnDisconnecting();
		}

		private void OnDisconnectedInternal()
		{
			// Change the state.
			this.state = ClientState.Disconnected;
			// Call the event handler.
			this.OnDisconnected();
			// Dispose the clinet.
			this.client.Dispose();
			this.client = null;
		}

		/// <summary>
		/// An event handler called when an error occurred on the current SSH connection.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void SshErrorOccurred(object sender, ExceptionEventArgs e)
		{
			// Synchronize access to the SSH client.
			lock (this.sync)
			{
				// Call the event handler.
				this.OnErrorOccurred(e.Exception);

				// If there is no current SSH client, ignore the error.
				if (null == this.client) return;

				// If the current state is disconnected, ignore the error.
				if (ClientState.Disconnected == this.State) return;

				// If the client is no longer connected.
				if (!this.client.IsConnected)
				{
					// Call the disconnecting event handler.
					this.OnDisconnecting();
					// Call the disconnected event handler.
					this.OnDisconnected();
				}
			}
		}

		/// <summary>
		/// An event handler called when the host key was received for the current SSH connection.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void SshHostKeyReceived(object sender, HostKeyEventArgs e)
		{
		}
	}
}
