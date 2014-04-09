/* 
 * Copyright (C) 2010-2012 Alexander Reinert
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace InetApi.Net.Core.Dns
{
	/// <summary>
	/// <para>Long lived query option.</para> <para>Defined in <see cref="http://files.dns-sd.org/draft-sekar-dns-llq.txt">draft-sekar-dns-llq</see>.</para>
	/// </summary>
	public class LongLivedQueryOption : EDnsOptionBase
	{
		/// <summary>
		/// Long lived query operation codes.
		/// </summary>
		public enum LlqOperationCode : ushort
		{
			/// <summary>
			/// Setup a LLQ.
			/// </summary>
			Setup = 1,
			/// <summary>
			/// Refresh a LLQ.
			/// </summary>
			Refresh = 2,
			/// <summary>
			/// LLQ event.
			/// </summary>
			Event = 3
		}

		/// <summary>
		/// Long lived query error codes.
		/// </summary>
		public enum LlqErrorCode : ushort
		{
			/// <summary>
			/// The LLQ Setup Request was successful.
			/// </summary>
			NoError = 0,
			/// <summary>
			/// The server cannot grant the LLQ request because it is overloaded, or the request exceeds the server's rate limit.
			/// </summary>
			ServerFull = 1,
			/// <summary>
			/// The data for this name and type is not expected to change frequently, and the server therefore does not support the requested LLQ.
			/// </summary>
			Static = 2,
			/// <summary>
			/// The LLQ was improperly formatted.
			/// </summary>
			FormatError = 3,
			/// <summary>
			/// The requested LLQ is expired or non-existent.
			/// </summary>
			NoSuchLlq = 4,
			/// <summary>
			/// The protocol version specified in the client's request is not supported by the server.
			/// </summary>
			BadVersion = 5,
			/// <summary>
			/// The LLQ was not granted for an unknown reason.
			/// </summary>
			UnknownError = 6
		}

		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal LongLivedQueryOption()
			: base(EDnsOptionType.LongLivedQuery) {}

		/// <summary>
		/// Creates a new instance of the LongLivedQueryOption class.
		/// </summary>
		/// <param name="operationCode">Identifies LLQ operation.</param>
		/// <param name="errorCode">Identifies LLQ errors.</param>
		/// <param name="id">Identifier for an LLQ.</param>
		/// <param name="leaseTime">Requested or granted life of LLQ.</param>
		public LongLivedQueryOption(LlqOperationCode operationCode, LlqErrorCode errorCode, ulong id, TimeSpan leaseTime)
			: this(0, operationCode, errorCode, id, leaseTime) {}

		/// <summary>
		/// Creates a new instance of the LongLivedQueryOption class.
		/// </summary>
		/// <param name="version">Version of LLQ protocol implemented.</param>
		/// <param name="operationCode">Identifies LLQ operation.</param>
		/// <param name="errorCode">Identifies LLQ errors.</param>
		/// <param name="id">Identifier for an LLQ.</param>
		/// <param name="leaseTime">Requested or granted life of LLQ.</param>
		public LongLivedQueryOption(ushort version, LlqOperationCode operationCode, LlqErrorCode errorCode, ulong id, TimeSpan leaseTime)
			: this()
		{
			this.Version = version;
			this.OperationCode = operationCode;
			this.ErrorCode = errorCode;
			this.Id = id;
			this.LeaseTime = leaseTime;
		}

		// Public properties.

		/// <summary>
		/// Version of LLQ protocol implemented.
		/// </summary>
		public ushort Version { get; private set; }
		/// <summary>
		/// Identifies LLQ operation.
		/// </summary>
		public LlqOperationCode OperationCode { get; private set; }
		/// <summary>
		/// Identifies LLQ errors.
		/// </summary>
		public LlqErrorCode ErrorCode { get; private set; }
		/// <summary>
		/// Identifier for an LLQ.
		/// </summary>
		public ulong Id { get; private set; }
		/// <summary>
		/// Requested or granted life of LLQ.
		/// </summary>
		public TimeSpan LeaseTime { get; private set; }

		// Internal properties.

		/// <summary>
		/// Gets the data length.
		/// </summary>
		internal override ushort DataLength
		{
			get { return 18; }
		}

		// Internal methods.

		/// <summary>
		/// Parses the data into an option instance.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="startPosition">The start position.</param>
		/// <param name="length">The data length.</param>
		internal override void ParseData(byte[] resultData, int startPosition, int length)
		{
			this.Version = DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.OperationCode = (LlqOperationCode)DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.ErrorCode = (LlqErrorCode)DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.Id = DnsMessageBase.ParseULong(resultData, ref startPosition);
			this.LeaseTime = TimeSpan.FromSeconds(DnsMessageBase.ParseUInt(resultData, ref startPosition));
		}

		/// <summary>
		/// Encodes the option.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="currentPosition">The current position.</param>
		internal override void EncodeData(byte[] messageData, ref int currentPosition)
		{
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, this.Version);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)this.OperationCode);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)this.ErrorCode);
			DnsMessageBase.EncodeULong(messageData, ref currentPosition, this.Id);
			DnsMessageBase.EncodeUInt(messageData, ref currentPosition, (uint)this.LeaseTime.TotalSeconds);
		}
	}
}