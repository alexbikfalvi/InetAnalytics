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
using System.IO;
using System.Linq;
using System.Threading;
using DotNetApi;
using DotNetApi.Concurrent.Generic;
using DotNetApi.Windows.Controls;
using YtCrawler;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace YtAnalytics.Controls.Net.Ssh
{
	/// <summary>
	/// A control for connecting to a remote server using Secure Shell (SSH).
	/// </summary>
	public class ControlSsh : NotificationControl
	{
		/// <summary>
		/// An enumeration representing the client state.
		/// </summary>
		public enum ClientState
		{
			Disconnected = 0,
			Connecting = 1,
			Connected = 2,
			Disconnecting = 3
		}

		private readonly object sync = new object();

		private ClientState state = ClientState.Disconnected;
		private SshClient client = null;
		private readonly ConcurrentList<SshCommand> commands = new ConcurrentList<SshCommand>();

		private Action<Exception> actionErrorOccurred;
		private Action<HostKeyEventArgs> actionHostKeyReceived;
		private Action<SshCommand> actionCommandBegin;
		private Action<SshCommand, string> actionCommandData;
		private Action<SshCommand, string> actionCommandSucceeded;
		private Action<SshCommand, string> actionCommandFailed;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSsh()
		{
			// Create the delegates.
			this.actionErrorOccurred = new Action<Exception>(this.OnErrorOccurredInternal);
			this.actionHostKeyReceived = new Action<HostKeyEventArgs>(this.OnHostKeyReceivedInternal);
			this.actionCommandBegin = new Action<SshCommand>(this.OnCommandBeginInternal);
			this.actionCommandData = new Action<SshCommand, string>(this.OnCommandDataInternal);
			this.actionCommandSucceeded = new Action<SshCommand, string>(this.OnCommandSucceededInternal);
			this.actionCommandFailed = new Action<SshCommand, string>(this.OnCommandFailedInternal);
		}

		// Public properties.

		/// <summary>
		/// Gets the current client state.
		/// </summary>
		public ClientState State { get { lock (this.sync) { return this.state; } } }

		// Protected properties.

		/// <summary>
		/// Gets the info for the current connection, or <b>null</b> if the client is not connected.
		/// </summary>
		protected ConnectionInfo Info { get { return this.client != null ? this.client.ConnectionInfo : null; } }
		/// <summary>
		/// Returns the number of commands in execution on the current SSH connection.
		/// </summary>
		protected ConcurrentList<SshCommand> Commands { get { return this.commands; } }
		/// <summary>
		/// Returns <b>true</b> if the SSH session is disconnected.
		/// </summary>
		protected bool IsDisconnected { get { lock (this.sync) { return this.state == ClientState.Disconnected; } } }

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected override void Dispose(bool disposing)
		{
			// The disconnection wait handle.
			WaitHandle wait = null;
			// Disconnect the SSH client.
			lock (this.sync)
			{
				// If there exists an SSH client.
				if (null != this.client)
				{
					// Disconnect the client and wait for the operation to complete.
					try { wait = this.Disconnect(); }
					catch { }
				}
			}

			// If disconnecting, wait for the operation to complete.
			if (null != wait) wait.WaitOne();

			// Dispose the SSH client.
			lock (this.sync)
			{
				if (null != this.client)
				{
					// Dispose of the client.
					this.client.Dispose();
				}
			}		
			// Call the base class methid.
			base.Dispose(disposing);
		}

		/// <summary>
		/// Connects the client to the SSH server specified in the connection info.
		/// </summary>
		/// <param name="info">The connection info.</param>
		/// <returns>A wait handle that will signal the completion of the asynchronous operation.</returns>
		protected WaitHandle Connect(ConnectionInfo info)
		{
			// Synchronize access to the SSH client.
			lock (this.sync)
			{
				// If the client is not disconnected, throw an exception.
				if (this.state != ClientState.Disconnected)
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

				// Set the client properties.
				this.client.KeepAliveInterval = new TimeSpan(0, 0, 10);

				// Set the client event handlers.
				this.client.ErrorOccurred += this.OnSshErrorOccurred;
				this.client.HostKeyReceived += this.OnSshHostKeyReceived;
			}

			// Create a manual reset event.
			ManualResetEvent wait = new ManualResetEvent(false);

			// Connect to the SSH server on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
			{
				lock (this.sync)
				{
					try
					{
						// Call the connecting action.
						this.OnConnectingInternal();

						// Connect to the server.
						this.client.Connect();

						// Call the connect succeeded action.
						this.OnConnectSucceededInternal();
					}
					catch (Exception exception)
					{
						// Call the connect failed action.
						this.OnConnectFailedInternal(exception);
					}
					finally
					{
						// Signal the wait handle.
						wait.Set();
					}
				}
			});

			return wait;
		}

		/// <summary>
		/// Disconnects the current client from the SSH server.
		/// </summary>
		/// <returns>A wait handle that will signal the completion of the asynchronous operation.</returns>
		protected WaitHandle Disconnect()
		{
			// Synchronize access to the SSH client.
			lock (this.sync)
			{
				// If the client is not connected, throw an exception.
				if (this.state != ClientState.Connected)
				{
					throw new SshException("Cannot disconnect from the SSH server because the client is not connected.");
				}
				// If the client is null, throw an exception.
				if (this.client == null)
				{
					throw new SshException("Cannot disconnect from the SSH server because the previous connection has already been released.");
				}
			}

			// Create a manual reset event.
			ManualResetEvent wait = new ManualResetEvent(false);

			// Disconnect from the SSH server on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
			{
				lock (this.sync)
				{
					try
					{
						try
						{
							// Call the event handler.
							this.OnDisconnectingInternal();

							// Lock the commands.
							this.commands.Lock();

							try
							{
								// Cancel all executing commands.
								foreach (SshCommand command in this.commands)
								{
									// Try and cancel all asynchronous commands.
									try
									{
										command.CancelAsync();
									}
									catch (Exception exception)
									{
										this.OnCommandFailedInternal(command, exception.Message);
									}
								}
								// Clear the commands.
								this.commands.Clear();
							}
							finally
							{
								this.commands.Unlock();
							}

							// Disconnect the client.
							this.client.Disconnect();
						}
						finally
						{
							// Call the event handler.
							this.OnDisconnectedInternal();
						}
					}
					finally
					{
						// Signal the wait handle.
						wait.Set();
					}
				}
			});

			return wait;
		}

		/// <summary>
		/// Begins to execute the specified command asynchronously.
		/// </summary>
		/// <param name="text">The command text.</param>
		/// <returns>The SSH command.</returns>
		protected SshCommand BeginCommand(string text)
		{
			lock (this.sync)
			{
				// If the client is not connected, throw an exception.
				if (this.state != ClientState.Connected)
				{
					throw new SshException("Cannot execute the command on the SSH server because the client is not connected.");
				}
				// If the current client is null, do nothing.
				if (null == this.client)
				{
					throw new SshException("Cannot execute the command on the SSH server because the previous connection has already been released.");
				};
				// If the current client is not connected, disconnect the client.
				if (!this.client.IsConnected)
				{
					// Change the state.
					this.state = ClientState.Disconnected;
					// Show a disconnected message.
					this.ShowMessage(
						Resources.ServerBusy_32, "Connection Failed", "The connection to the SSH server \'{0}\' failed unexpectedly.".FormatWith(this.client.ConnectionInfo.Host),
						false, (int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
						{
							// Call the disconnecting event handler.
							this.OnDisconnecting(this.client.ConnectionInfo);
							// Call the disconnected event handler.
							this.OnDisconnected(this.client.ConnectionInfo);
						});
					// Dispose the clinet.
					this.client.Dispose();
					this.client = null;
					// Throw an exception.
					throw new SshException("Cannot execute the command on the SSH server because the connection failed.");
				}

				// Create a new command for the current text.
				SshCommand command = this.client.CreateCommand(text);

				// Call the event handler.
				this.OnCommandBeginInternal(command);

				// Add a new command info object to the commands set.
				this.commands.Add(command);

				// Beginn execute the command asynchronously.
				IAsyncResult asyncResult = command.BeginExecute(this.OnEndCommand, command);

				// Get the command data.
				ThreadPool.QueueUserWorkItem((object state) =>
				{
					// Get the command output stream.
					PipeStream stream = command.OutputStream as PipeStream;
					// Set the stream as blocking.
					stream.BlockLastReadBuffer = true;
					// Read the command data.
					using (PipeReader reader = new PipeReader(stream))
					{
						// While the command is not completed.
						while (!asyncResult.IsCompleted)
						{
							// Read all current data in a string.
							string data = reader.ReadToEnd();
							// If the string null or empty, continue.
							if (string.IsNullOrEmpty(data))
							{
								this.OnCommandDataInternal(command, "!");
								continue;
							}
							// Call the event handler event handler.
							this.OnCommandDataInternal(command, data);
						}
					}
				});

				// Return the command.
				return command;
			}
		}

		/// <summary>
		/// An event handler called when connecting to an SSH server.
		/// </summary>
		/// <param name="info">The connection info.</param>
		protected virtual void OnConnecting(ConnectionInfo info)
		{
		}

		/// <summary>
		/// An event handler called when connecting to an SSH server succeeded.
		/// </summary>
		/// <param name="info">The connection info.</param>
		protected virtual void OnConnectSucceeded(ConnectionInfo info)
		{
		}

		/// <summary>
		/// An event handler called when connecting to an SSH server failed.
		/// </summary>
		/// <param name="info">The connection info.</param>
		/// <param name="exception">The exception.</param>
		protected virtual void OnConnectFailed(ConnectionInfo info, Exception exception)
		{
		}

		/// <summary>
		/// An event handler called when disconnecting from an SSH server.
		/// </summary>
		/// <param name="info">The connection info.</param>
		protected virtual void OnDisconnecting(ConnectionInfo info)
		{
		}

		/// <summary>
		/// An event handler called when disconnected from an SSH server.
		/// </summary>
		/// <param name="info">The connection info.</param>
		protected virtual void OnDisconnected(ConnectionInfo info)
		{
		}

		/// <summary>
		/// An event handler called when an error occurres on an SSH server connection.
		/// </summary>
		/// <param name="info">The connection info.</param>
		/// <param name="exception">The error exception.</param>
		protected virtual void OnErrorOccurred(ConnectionInfo info, Exception exception)
		{
		}

		/// <summary>
		/// An event handler called when receiving a key from the remote host.
		/// </summary>
		/// <param name="info">The connection info.</param>
		/// <param name="args">The event arguments.</param>
		protected virtual void OnHostKeyReceived(ConnectionInfo info, HostKeyEventArgs args)
		{
		}

		/// <summary>
		/// An event handler called when the client begins executing a command.
		/// </summary>
		/// <param name="command">The command.</param>
		protected virtual void OnCommandBegin(SshCommand command)
		{
		}

		/// <summary>
		/// An event handler called when the client receives data for an executing command.
		/// </summary>
		/// <param name="info">The connection info.</param>
		/// <param name="command">The command.</param>
		/// <param name="data">The received data.</param>
		protected virtual void OnCommandData(SshCommand command, string data)
		{
		}

		/// <summary>
		/// An event handler called when a client command completed successfully.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="result">The result.</param>
		protected virtual void OnCommandSucceeded(SshCommand command, string result)
		{
		}

		/// <summary>
		/// An event handler called when a client command has failed.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="error">The error.</param>
		protected virtual void OnCommandFailed(SshCommand command, string error)
		{
		}

		// Private methods.

		/// <summary>
		/// An action called when connecting the client.
		/// </summary>
		private void OnConnectingInternal()
		{
			// Change the client state to connecting.
			this.state = ClientState.Connecting;
			// Save the client connection info.
			ConnectionInfo info = this.client.ConnectionInfo;
			// Show a connecting message.
			this.ShowMessage(
				Resources.ServerBusy_32, "Connecting", "Connecting to the SSH server \'{0}\'".FormatWith(this.client.ConnectionInfo.Host), true, -1,
				(object[] parameters) =>
				{
					// Call the event handler.
					this.OnConnecting(info);
				});
		}

		/// <summary>
		/// An action called when connecting the client has succeeded.
		/// </summary>
		private void OnConnectSucceededInternal()
		{
			// Change the client state to connected.
			this.state = ClientState.Connected;
			// Save the client connection info.
			ConnectionInfo info = this.client.ConnectionInfo;
			// Show a message.
			this.ShowMessage(
				Resources.ServerSuccess_32, "Connecting Succeeded", "Connecting to the SSH sever \'{0}\' completed successfully.".FormatWith(this.client.ConnectionInfo.Host),
				false, (int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
				(object[] parameters) =>
				{
					// Call the event handler.
					this.OnConnectSucceeded(info);
				});
		}

		/// <summary>
		/// An action called when connecting the client has failed.
		/// </summary>
		/// <param name="exception">The exception.</param>
		private void OnConnectFailedInternal(Exception exception)
		{
			// Change the state.
			this.state = ClientState.Disconnected;
			// Save the client connection info.
			ConnectionInfo info = this.client.ConnectionInfo;
			// Show a message.
			this.ShowMessage(Resources.ServerError_32, "Connecting Failed", "Connecting to the SSH sever \'{0}\' failed. {1}".FormatWith(this.client.ConnectionInfo.Host, exception.Message),
				false, (int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
				(object[] parameters) =>
				{
					// Call the event handler.
					this.OnConnectFailed(info, exception);
				});
			// Dispose the clinet.
			this.client.Dispose();
			this.client = null;
		}

		/// <summary>
		/// An action called when the client is disconnecting.
		/// </summary>
		private void OnDisconnectingInternal()
		{
			// Change the state.
			this.state = ClientState.Disconnecting;
			// Save the client connection info.
			ConnectionInfo info = this.client.ConnectionInfo;
			// Show a disconnecting message.
			this.ShowMessage(
				Resources.ServerBusy_32, "Disconnecting", "Disconnecting from the SSH server \'{0}\'".FormatWith(this.client.ConnectionInfo.Host), true, -1,
				(object[] parameters) =>
				{
					// Call the event handler.
					this.OnDisconnecting(info);
				});
		}

		/// <summary>
		/// An action called when the client is disconnected.
		/// </summary>
		private void OnDisconnectedInternal()
		{
			// Change the state.
			this.state = ClientState.Disconnected;
			// Save the client connection info.
			ConnectionInfo info = this.client.ConnectionInfo;
			// Show a message.
			this.ShowMessage(
				Resources.ServerSuccess_32, "Disconnecting Succeeded", "Disconnecting from the SSH sever \'{0}\' completed successfully.".FormatWith(this.client.ConnectionInfo.Host),
				false, (int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
				(object[] parameters) =>
				{
					// Call the event handler.
					this.OnDisconnected(info);
				});
			// Dispose the clinet.
			this.client.Dispose();
			this.client = null;
		}

		/// <summary>
		/// An action called when a client error has occurred.
		/// </summary>
		/// <param name="exception">The exception.</param>
		private void OnErrorOccurredInternal(Exception exception)
		{
			// Call the event handler.
			this.OnErrorOccurred(this.client.ConnectionInfo, exception);
		}

		/// <summary>
		/// An action called when receiving the key from the remote host.
		/// </summary>
		/// <param name="args">The arguments.</param>
		private void OnHostKeyReceivedInternal(HostKeyEventArgs args)
		{
			// Call the event handler.
			this.OnHostKeyReceived(this.client.ConnectionInfo, args);
		}

		/// <summary>
		/// An event handler called when an error occurred on the current SSH connection.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSshErrorOccurred(object sender, ExceptionEventArgs e)
		{
			// Call the event handler on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.actionErrorOccurred, new object[] { e.Exception });
			}
			else
			{
				this.OnErrorOccurredInternal(e.Exception);
			}

			// Synchronize access to the SSH client.
			lock (this.sync)
			{
				// If there is no current SSH client, ignore the error.
				if (null == this.client) return;

				// If the current state is disconnected, ignore the error.
				if (ClientState.Disconnected == this.state) return;

				// Save the client connection info.
				ConnectionInfo info = this.client.ConnectionInfo;

				// If the client is no longer connected.
				if (!this.client.IsConnected)
				{
					// Lock the commands.
					this.commands.Lock();
					try
					{
						// Cancel all executing commands.
						foreach (SshCommand command in this.commands)
						{
							// Try and cancel all asynchronous commands.
							try
							{
								command.CancelAsync();
							}
							catch (Exception exception)
							{
								this.OnCommandFailedInternal(command, exception.Message);
							}
						}
						// Clear the commands.
						this.commands.Clear();
					}
					finally
					{
						this.commands.Unlock();
					}

					// Change the state.
					this.state = ClientState.Disconnected;
					// Show a disconnected message.
					this.ShowMessage(
						Resources.ServerBusy_32, "Connection Failed", "The connection to the SSH server \'{0}\' failed.".FormatWith(this.client.ConnectionInfo.Host),
						false, (int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
						{
							// Call the disconnecting event handler.
							this.OnDisconnecting(info);
							// Call the disconnected event handler.
							this.OnDisconnected(info);
						});
					// Dispose the clinet.
					this.client.Dispose();
					this.client = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when the host key was received for the current SSH connection.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSshHostKeyReceived(object sender, HostKeyEventArgs e)
		{
			// Call the event handler on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.actionHostKeyReceived, new object[] { e });
			}
			else
			{
				this.OnHostKeyReceivedInternal(e);
			}
		}

		/// <summary>
		/// An action called when the client begins executing a command.
		/// </summary>
		/// <param name="command">The command.</param>
		private void OnCommandBeginInternal(SshCommand command)
		{
			// Call the event handler on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.actionCommandBegin, new object[] { command });
			}
			else
			{
				this.OnCommandBegin(command);
			}
		}

		/// <summary>
		/// An action called when the client receives data for an executing command.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="data">The data.</param>
		private void OnCommandDataInternal(SshCommand command, string data)
		{
			// Call the event handler on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.actionCommandData, new object[] { command, data });
			}
			else
			{
				this.OnCommandData(command, data);
			}
		}

		/// <summary>
		/// An callback method called when completing an asynchronous SSH command.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		private void OnEndCommand(IAsyncResult asyncResult)
		{
			// Get the command.
			SshCommand command = asyncResult.AsyncState as SshCommand;

			try
			{
				// End the command execution.
				string result = command.EndExecute(asyncResult);

				if (command.ExitStatus == 0)
				{
					// Call the event handler.
					this.OnCommandSucceededInternal(command, result);
				}
				else
				{
					// Call the event handler.
					this.OnCommandFailedInternal(command, command.Error);
				}
			}
			catch (Exception exception)
			{
				// Call the event handler.
				this.OnCommandFailedInternal(command, exception.Message);
			}

			
			lock (this.sync)
			{
				// Remove the command from the commands list.
				this.commands.Remove(command);
				// Dispose the command.
				command.Dispose();
			}
		}

		/// <summary>
		/// An action called when a command completed successfully.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="result">The result.</param>
		private void OnCommandSucceededInternal(SshCommand command, string result)
		{
			// Call the event handler on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.actionCommandSucceeded, new object[] { command, result });
			}
			else
			{
				this.OnCommandSucceeded(command, result);
			}
		}

		/// <summary>
		/// An action called when a command failed.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="error">The error.</param>
		private void OnCommandFailedInternal(SshCommand command, string error)
		{
			// Call the event handler on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.actionCommandFailed, new object[] { command, error });
			}
			else
			{
				this.OnCommandFailed(command, error);
			}
		}
	}
}
