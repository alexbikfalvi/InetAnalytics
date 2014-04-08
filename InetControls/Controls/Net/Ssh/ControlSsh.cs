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
using InetCommon;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace InetCommon.Controls.Net.Ssh
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

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSsh()
		{
		}

		// Public properties.

		/// <summary>
		/// Gets the current client state.
		/// </summary>
		public ClientState State { get { return this.state; } }

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
			// Create a manual reset event.
			using (ManualResetEvent wait = new ManualResetEvent(false))
			{

				// Disconnect the SSH client.
				lock (this.sync)
				{
					// If there exists an SSH client.
					if (null != this.client)
					{
						// Disconnect the client and wait for the operation to complete.
						try { this.Disconnect(wait, true); }
						catch { }
					}
					else
					{
						wait.Set();
					}
				}

				// Wait on the event.
				wait.WaitOne();
			}

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
		/// <param name="wait">The event wait handle for synchronous operation.</param>
		/// <returns>A wait handle that will signal the completion of the asynchronous operation.</returns>
		protected void Connect(ConnectionInfo info, EventWaitHandle wait = null)
		{
			// Synchronize access to the SSH client.
			lock (this.sync)
			{
				// If the client is not disconnected, throw an exception.
				if (this.state != ClientState.Disconnected)
				{
					// Signal the wait handle.
					if (null != wait) wait.Set();
					// Throw an exception.
					throw new SshException("Cannot connect to the SSH server because the client is not disconnected.");
				}
				// If the client is not null, throw an exception.
				if (this.client != null)
				{
					// Signal the wait handle.
					if (null != wait) wait.Set();
					// Throw an exception.
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

			// Connect to the SSH server on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
			{
				lock (this.sync)
				{
					try
					{
						// Call the connecting action.
						this.OnConnectingInternal(false);

						// Connect to the server.
						this.client.Connect();

						// Call the connect succeeded action.
						this.OnConnectSucceededInternal(false);
					}
					catch (Exception exception)
					{
						// Call the connect failed action.
						this.OnConnectFailedInternal(exception, false);
					}
					finally
					{
						// Signal the wait handle.
						if (null != wait) wait.Set();
					}
				}
			});
		}

		/// <summary>
		/// Disconnects the current client from the SSH server.
		/// </summary>
		/// <param name="wait">The event wait handle for synchronous operation.</param>
		/// <param name="silent">Indicates whether the operation is silent, without displaying a message. If the opeation is silent,
		/// the method must be called on the UI thread.</param>
		protected void Disconnect(EventWaitHandle wait = null, bool silent = false)
		{
			// If the operation is silent, it must be called on the UI thread.
			if (silent && this.InvokeRequired)
			{
				throw new InvalidOperationException("A silent operation must be called on the UI thread.");
			}

			// Synchronize access to the SSH client.
			lock (this.sync)
			{
				// If the client is not connected, throw an exception.
				if (this.state != ClientState.Connected)
				{
					// Signal the wait handle.
					if (null != wait) wait.Set();
					// Throw an exception.
					throw new SshException("Cannot disconnect from the SSH server because the client is not connected.");
				}
				// If the client is null, throw an exception.
				if (this.client == null)
				{
					// Signal the wait handle.
					if (null != wait) wait.Set();
					// Throw an exception.
					throw new SshException("Cannot disconnect from the SSH server because the previous connection has already been released.");
				}
			}

			// Create the disconnect action.
			WaitCallback action = (object state) =>
				{
					lock (this.sync)
					{
						try
						{
							try
							{
								// Call the event handler.
								this.OnDisconnectingInternal(silent);

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
								this.OnDisconnectedInternal(silent);
							}
						}
						finally
						{
							// Signal the wait handle.
							if (null != wait) wait.Set();
						}
					}
				};

			// If silent.
			if (silent)
			{
				action(null);
			}
			else
			{
				// Disconnect from the SSH server on the thread pool.
				ThreadPool.QueueUserWorkItem(action);
			}
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
						false, (int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds,
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
					// Set the stream as blocking.
					command.OutputStream.BlockLastReadBuffer = true;
					// Read the command data.
					using (PipeReader reader = new PipeReader(command.OutputStream))
					{
						// While the command is not completed.
						while (!asyncResult.IsCompleted)
						{
							// Read all current data in a string.
							string data = reader.ReadToEnd();
							// If the string null or empty, continue.
							if (string.IsNullOrEmpty(data))
							{
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
		/// <param name="silent">Indicates whether the operation is silent.</param>
		private void OnConnectingInternal(bool silent)
		{
			// Change the client state to connecting.
			this.state = ClientState.Connecting;
			// Save the client connection info.
			ConnectionInfo info = this.client.ConnectionInfo;
			// If the operation is slient.
			if (silent)
			{
				// Call the event handler.
				this.OnConnecting(info);
			}
			else
			{
				// Show a connecting message.
				this.ShowMessage(
					Resources.ServerBusy_32, "Connecting", "Connecting to the SSH server \'{0}\'".FormatWith(this.client.ConnectionInfo.Host), true, -1,
					(object[] parameters) =>
					{
						// Call the event handler.
						this.OnConnecting(info);
					});
			}
		}

		/// <summary>
		/// An action called when connecting the client has succeeded.
		/// </summary>
		/// <param name="silent">Indicates whether the operation is silent.</param>
		private void OnConnectSucceededInternal(bool silent)
		{
			// Change the client state to connected.
			this.state = ClientState.Connected;
			// Save the client connection info.
			ConnectionInfo info = this.client.ConnectionInfo;
			// If the operation is slient.
			if (silent)
			{
				// Call the event handler.
				this.OnConnectSucceeded(info);
			}
			else
			{
				// Show a message.
				this.ShowMessage(
					Resources.ServerSuccess_32, "Connecting Succeeded", "Connecting to the SSH sever \'{0}\' completed successfully.".FormatWith(this.client.ConnectionInfo.Host),
					false, (int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the event handler.
						this.OnConnectSucceeded(info);
					});
			}
		}

		/// <summary>
		/// An action called when connecting the client has failed.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="silent">Indicates whether the operation is silent.</param>
		private void OnConnectFailedInternal(Exception exception, bool silent)
		{
			// Change the state.
			this.state = ClientState.Disconnected;
			// Save the client connection info.
			ConnectionInfo info = this.client.ConnectionInfo;
			// If the operation is slient.
			if (silent)
			{
				// Call the event handler.
				this.OnConnectFailed(info, exception);
			}
			else
			{
				// Show a message.
				this.ShowMessage(Resources.ServerError_32, "Connecting Failed", "Connecting to the SSH sever \'{0}\' failed. {1}".FormatWith(this.client.ConnectionInfo.Host, exception.Message),
					false, (int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the event handler.
						this.OnConnectFailed(info, exception);
					});
			}
			// Dispose the clinet.
			this.client.Dispose();
			this.client = null;
		}

		/// <summary>
		/// An action called when the client is disconnecting.
		/// </summary>
		/// <param name="silent">Indicates whether the operation is silent.</param>
		private void OnDisconnectingInternal(bool silent)
		{
			// Change the state.
			this.state = ClientState.Disconnecting;
			// Save the client connection info.
			ConnectionInfo info = this.client.ConnectionInfo;
			// If the operation is slient.
			if (silent)
			{
				// Call the event handler.
				this.OnDisconnecting(info);
			}
			else
			{
				// Show a disconnecting message.
				this.ShowMessage(
					Resources.ServerBusy_32, "Disconnecting", "Disconnecting from the SSH server \'{0}\'".FormatWith(this.client.ConnectionInfo.Host), true, -1,
					(object[] parameters) =>
					{
						// Call the event handler.
						this.OnDisconnecting(info);
					});
			}
		}

		/// <summary>
		/// An action called when the client is disconnected.
		/// </summary>
		/// <param name="silent">Indicates whether the operation is silent.</param>
		private void OnDisconnectedInternal(bool silent)
		{
			// Change the state.
			this.state = ClientState.Disconnected;
			// Save the client connection info.
			ConnectionInfo info = this.client.ConnectionInfo;
			// If the operation is slient.
			if (silent)
			{
				// Call the event handler.
				this.OnDisconnected(info);
			}
			else
			{
				// Show a message.
				this.ShowMessage(
					Resources.ServerSuccess_32, "Disconnecting Succeeded", "Disconnecting from the SSH sever \'{0}\' completed successfully.".FormatWith(this.client.ConnectionInfo.Host),
					false, (int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the event handler.
						this.OnDisconnected(info);
					});
			}
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
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					this.OnErrorOccurredInternal(e.Exception);
				});

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
						false, (int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds,
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
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					this.OnHostKeyReceivedInternal(e);
				});
		}

		/// <summary>
		/// An action called when the client begins executing a command.
		/// </summary>
		/// <param name="command">The command.</param>
		private void OnCommandBeginInternal(SshCommand command)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					this.OnCommandBegin(command);
				});
		}

		/// <summary>
		/// An action called when the client receives data for an executing command.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="data">The data.</param>
		private void OnCommandDataInternal(SshCommand command, string data)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					this.OnCommandData(command, data);
				});
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
					// Append the command error, if any.
					if (!string.IsNullOrWhiteSpace(command.Error))
					{
						if (string.IsNullOrWhiteSpace(result))
						{
							result = command.Error;
						}
						else
						{
							result = "{0}{1}{2}".FormatWith(result, Environment.NewLine, command.Error);
						}
					}

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
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					this.OnCommandSucceeded(command, result);
				});
		}

		/// <summary>
		/// An action called when a command failed.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="error">The error.</param>
		private void OnCommandFailedInternal(SshCommand command, string error)
		{
			// Execute the code on the UI thread.
			this.Invoke(() =>
				{
					this.OnCommandFailed(command, error);
				});
		}
	}
}
