﻿/* 
 * Copyright (C) 2014 Alex Bikfalvi
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
using System.Net.Sockets;
using System.Threading;

using DotNetApi.Concurrent.Generic;

using InetApi.Net.Core.Protocols;

namespace InetApi.Net.Core
{
    /// <summary>
    /// A class for packet capture.
    /// </summary>
    public sealed class PacketCapture : IDisposable
    {
        private const byte bufferCount = 16;
        private const ushort bufferSize = 1500;

        private readonly Socket socket;

        private readonly byte[][] buffer = new byte[PacketCapture.bufferCount][];
        private readonly ManualResetEvent bufferWait = new ManualResetEvent(true);
        private readonly Queue<int> bufferQueue = new Queue<int>(PacketCapture.bufferCount);

        private readonly ConcurrentList<PacketCaptureHandler> handlers = new ConcurrentList<PacketCaptureHandler>();

        private readonly object sync = new object();

        private readonly CancellationToken cancel;

        /// <summary>
        /// Creates a new packet capture instance for the specified local end-point.
        /// </summary>
        /// <param name="localAddress">The local address.</param>
        /// <param name="cancel">The cancellation token.</param>
        public PacketCapture(IPAddress localAddress, CancellationToken cancel)
        {
            // Initialize the receiving buffers.
            for (int index = 0; index < PacketCapture.bufferCount; index++)
            {
                this.buffer[index] = new byte[PacketCapture.bufferSize];
            	this.bufferQueue.Enqueue(index);
            }

            // Set the cancellation token.
            this.cancel = cancel;

            // Create the receiving socket.
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

            // Bind the socket to the local address.
            this.socket.Bind(new IPEndPoint(localAddress, 0));

            // Indicate the IP header included by the application.
            this.socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

            // Set the control code for receiving all packets.
            this.socket.IOControl(IOControlCode.ReceiveAll, new byte[4] { 1, 0, 0, 0 }, new byte[4] { 1, 0, 0, 0 });

            // Wait for packets on a different thread.
            ThreadPool.QueueUserWorkItem((object state) =>
                {
                    this.ReceivePackets();
                });
        }

        #region Public methods

        /// <summary>
        /// Disposes the current object.
        /// </summary>
        public void Dispose()
        {
            // Close the socket.
            this.socket.Close();
            // Suppress the finalizer.
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Internal methods

        /// <summary>
        /// Adds a packet capture handler.
        /// </summary>
        /// <param name="handler">The handler.</param>
        internal void AddHandler(PacketCaptureHandler handler)
        {
            this.handlers.Add(handler);
        }

        /// <summary>
        /// Removes a packet capture handler.
        /// </summary>
        /// <param name="handler">The handler.</param>
        internal void RemoveHandler(PacketCaptureHandler handler)
        {
            this.handlers.Remove(handler);
        }

        #endregion


        #region Private methods

        /// <summary>
        /// Requests a receiving buffer. The method blocks until a buffer is available or until the cancellation is requested.
        /// </summary>
        /// <returns>The buffer index.</returns>
        private int RequestBuffer()
        {
            // The buffer index.
            int bufferIndex = -1;

            do
            {
                // Wait for a buffer to become available.
                this.bufferWait.WaitOne();

                lock (this.sync)
                {
                    // If the buffer queue is not empty.
                    if (this.bufferQueue.Count > 0)
                    {
                        // Get the first buffer index.
                        bufferIndex = this.bufferQueue.Dequeue();

                        // If the queue is empty, reset the buffer wait handle.
                        if (this.bufferQueue.Count == 0) this.bufferWait.Reset();
                    }
                }
            }
            while ((bufferIndex == -1) && (!this.cancel.IsCancellationRequested));

            // Return the buffer index.
            return bufferIndex;
        }

        /// <summary>
        /// Releases the specified buffer.
        /// </summary>
        /// <param name="bufferIndex">The buffer index.</param>
        private void ReleaseBuffer(int bufferIndex)
        {
            // Release the buffer.
            lock (this.sync)
            {
                // If the buffer queue is empty, set the buffer wait handle.
                if (this.bufferQueue.Count == 0) this.bufferWait.Set();

                // Add the buffer index to the queue.
                this.bufferQueue.Enqueue(bufferIndex);
            }
        }

        /// <summary>
        /// Receives all packets in a loop.
        /// </summary>
        private void ReceivePackets()
        {
            // The remote end-point.
            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

            // While a cancellation is not requested.
            while (!this.cancel.IsCancellationRequested)
            {
                // Request a buffer.
                int bufferIndex = this.RequestBuffer();

                // If the operation was canceled, return.
                if (this.cancel.IsCancellationRequested) return;

                try
                {
                    // Receive a packet.
                    int length = socket.ReceiveFrom(this.buffer[bufferIndex], 0, this.buffer[bufferIndex].Length, SocketFlags.None, ref endPoint);

                    // Process the packet on a different thread.
                    ThreadPool.QueueUserWorkItem((object state) =>
                        {
                            // Get the buffer index.
                            int index = (int)state;

                            try
                            {
                                this.PacketSuccess(this.buffer[index], length);
                            }
                            catch (Exception) { }

                            // Release the buffer.
                            this.ReleaseBuffer(index);
                        }, bufferIndex);
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
                catch (Exception)
                {
                    // Release the buffer
                    this.ReleaseBuffer(bufferIndex);
                }
            }
        }

        /// <summary>
        /// Processes a received packet.
        /// </summary>
        /// <param name="buffer">The data buffer.</param>
        /// <param name="length">The data length.</param>
        private void PacketSuccess(byte[] buffer, int length)
        {
            // Set the buffer index.
            int index = 0;
            // The packets.

            ProtoPacketIp ip = null;

            this.handlers.Lock();
            try
            {
                foreach (PacketCaptureHandler handler in this.handlers)
                {
                    if ((null != ip) && (handler.Matches(ip)))
                    {
                        handler.Success(buffer, length, ip);
                    }
                    else if (handler.Parse(buffer, ref index, length, out ip))
                    {
                        handler.Success(buffer, length, ip);
                    }
                }
            }
            finally
            {
                this.handlers.Unlock();
            }
        }

        /// <summary>
        /// Processes a failed packet.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="exception">The exception.</param>
        private void PacketError(byte[] buffer, Exception exception)
        {
            this.handlers.Lock();
            try
            {
                foreach (PacketCaptureHandler handler in this.handlers)
                {
                    handler.Error(buffer, exception);
                }
            }
            finally
            {
                this.handlers.Unlock();
            }

        }
        #endregion
    }
}
