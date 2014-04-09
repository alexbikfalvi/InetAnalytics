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
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using InetApi.Net.Core.Dns.DynamicUpdate;

namespace InetApi.Net.Core.Dns
{
	/// <summary>
	///   Base class for a dns answer
	/// </summary>
	public abstract class DnsMessageBase
	{
		private List<DnsRecordBase> additionalRecords = new List<DnsRecordBase>();

		#region Protected fields

		protected ushort Flags;

		protected internal List<DnsQuestion> Questions = new List<DnsQuestion>();
		protected internal List<DnsRecordBase> AnswerRecords = new List<DnsRecordBase>();
		protected internal List<DnsRecordBase> AuthorityRecords = new List<DnsRecordBase>();

		#endregion

		#region Public properties

		/// <summary>
		///   Gets or sets the entries in the additional records section
		/// </summary>
		public List<DnsRecordBase> AdditionalRecords
		{
			get { return this.additionalRecords; }
			set { this.additionalRecords = (value ?? new List<DnsRecordBase>()); }
		}

		#endregion

		#region Internal properties

		/// <summary>
		/// Gets whether TCP using is requested.
		/// </summary>
		internal abstract bool IsTcpUsingRequested { get; }
		/// <summary>
		/// Gets whether TCP resending is requested.
		/// </summary>
		internal abstract bool IsTcpResendingRequested { get; }
		/// <summary>
		/// Gets whether TCP next message is waiting.
		/// </summary>
		internal abstract bool IsTcpNextMessageWaiting { get; }

		#endregion

		#region Header

		/// <summary>
		/// Gets or sets the transaction identifier (ID) of the message.
		/// </summary>
		public ushort TransactionID { get; set; }

		/// <summary>
		/// Gets or sets the query (QR) flag.
		/// </summary>
		public bool IsQuery
		{
			get { return (this.Flags & 0x8000) == 0; }
			set
			{
				if (value)
				{
					this.Flags &= 0x7fff;
				}
				else
				{
					this.Flags |= 0x8000;
				}
			}
		}

		/// <summary>
		///   Gets or sets the Operation Code (OPCODE)
		/// </summary>
		public OperationCode OperationCode
		{
			get { return (OperationCode) ((this.Flags & 0x7800) >> 11); }
			set
			{
				ushort clearedOp = (ushort) (this.Flags & 0x8700);
				this.Flags = (ushort) (clearedOp | (ushort) value << 11);
			}
		}

		/// <summary>
		///   Gets or sets the return code (RCODE)
		/// </summary>
		public ReturnCode ReturnCode
		{
			get
			{
				ReturnCode rcode = (ReturnCode) (Flags & 0x000f);

				OptRecord ednsOptions = this.EDnsOptions;
				if (ednsOptions == null)
				{
					return rcode;
				}
				else
				{
					return (rcode | ednsOptions.ExtendedReturnCode);
				}
			}
			set
			{
				OptRecord ednsOptions = this.EDnsOptions;

				if ((ushort) value > 15)
				{
					if (ednsOptions == null)
					{
						throw new ArgumentOutOfRangeException("value", "ReturnCodes greater than 15 only allowed in edns messages");
					}
					else
					{
						ednsOptions.ExtendedReturnCode = value;
					}
				}
				else
				{
					if (ednsOptions != null)
					{
						ednsOptions.ExtendedReturnCode = 0;
					}
				}

				ushort clearedOp = (ushort) (Flags & 0xfff0);
				this.Flags = (ushort) (clearedOp | ((ushort) value & 0x0f));
			}
		}

		#endregion

		#region EDNS

		/// <summary>
		///   Enables or disables EDNS
		/// </summary>
		public bool IsEDnsEnabled
		{
			get
			{
				if (this.additionalRecords != null)
				{
					return this.additionalRecords.Any(record => (record.RecordType == RecordType.Opt));
				}
				else
				{
					return false;
				}
			}
			set
			{
				if (value && !this.IsEDnsEnabled)
				{
					if (this.additionalRecords == null)
					{
						this.additionalRecords = new List<DnsRecordBase>();
					}
					this.additionalRecords.Add(new OptRecord());
				}
				else if (!value && this.IsEDnsEnabled)
				{
					this.additionalRecords.RemoveAll(record => (record.RecordType == RecordType.Opt));
				}
			}
		}

		/// <summary>
		///   Gets or set the OptRecord for the EDNS options
		/// </summary>
		public OptRecord EDnsOptions
		{
			get
			{
				if (this.additionalRecords != null)
				{
					return (OptRecord)this.additionalRecords.Find(record => (record.RecordType == RecordType.Opt));
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (value == null)
				{
					this.IsEDnsEnabled = false;
				}
				else if (this.IsEDnsEnabled)
				{
					int pos = this.additionalRecords.FindIndex(record => (record.RecordType == RecordType.Opt));
					this.additionalRecords[pos] = value;
				}
				else
				{
					if (this.additionalRecords == null)
					{
						this.additionalRecords = new List<DnsRecordBase>();
					}
					this.additionalRecords.Add(value);
				}
			}
		}

		/// <summary>
		/// <para>Gets or sets the DNSSEC answer OK (DO) flag.</para>
		/// <para>Defined in <see cref="http://tools.ietf.org/html/rfc4035">RFC 4035</see> and <see cref="http://tools.ietf.org/html/rfc3225">RFC 3225</see>.</para>
		/// </summary>
		public bool IsDnsSecOk
		{
			get
			{
				OptRecord ednsOptions = this.EDnsOptions;
				return (ednsOptions != null) && ednsOptions.IsDnsSecOk;
			}
			set
			{
				OptRecord ednsOptions = this.EDnsOptions;
				if (ednsOptions == null)
				{
					if (value)
					{
						throw new ArgumentOutOfRangeException("value", "Setting DO flag is allowed in edns messages only");
					}
				}
				else
				{
					ednsOptions.IsDnsSecOk = value;
				}
			}
		}

		#endregion

		#region TSig

		/// <summary>
		/// Gets or set the TSigRecord for the tsig signed messages.
		/// </summary>
		public TSigRecord TSigOptions { get; set; }

		/// <summary>
		/// Creates a DNS message.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="isRequest">If <b>true</b> the message is a request.</param>
		/// <param name="tsigKeySelector">The transaction signature key selector.</param>
		/// <param name="originalMac">The original MAC.</param>
		/// <returns>The DNS message.</returns>
		internal static DnsMessageBase Create(byte[] resultData, bool isRequest, DnsServer.SelectTsigKey tsigKeySelector, byte[] originalMac)
		{
			int flagPosition = 2;
			ushort flags = DnsMessageBase.ParseUShort(resultData, ref flagPosition);

			DnsMessageBase res;

			switch ((OperationCode) ((flags & 0x7800) >> 11))
			{
				case OperationCode.Update:
					res = new DnsUpdateMessage();
					break;

				default:
					res = new DnsMessage();
					break;
			}

			res.Parse(resultData, isRequest, tsigKeySelector, originalMac);

			return res;
		}

		/// <summary>
		/// Parses byte array data into a DNS message.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="isRequest">If <b>true</b> the message is a request.</param>
		/// <param name="tsigKeySelector">The transaction signature key selector.</param>
		/// <param name="originalMac">The original MAC.</param>
		internal void Parse(byte[] resultData, bool isRequest, DnsServer.SelectTsigKey tsigKeySelector, byte[] originalMac)
		{
			int currentPosition = 0;

			this.TransactionID = DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			this.Flags = DnsMessageBase.ParseUShort(resultData, ref currentPosition);

			int questionCount = DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			int answerRecordCount = DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			int authorityRecordCount = DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			int additionalRecordCount = DnsMessageBase.ParseUShort(resultData, ref currentPosition);

			this.ParseQuestions(resultData, ref currentPosition, questionCount);
			DnsMessageBase.ParseSection(resultData, ref currentPosition, AnswerRecords, answerRecordCount);
			DnsMessageBase.ParseSection(resultData, ref currentPosition, AuthorityRecords, authorityRecordCount);
			DnsMessageBase.ParseSection(resultData, ref currentPosition, this.additionalRecords, additionalRecordCount);

			if (this.additionalRecords.Count > 0)
			{
				int tSigPos = this.additionalRecords.FindIndex(record => (record.RecordType == RecordType.TSig));
				if (tSigPos == (this.additionalRecords.Count - 1))
				{
					this.TSigOptions = (TSigRecord)this.additionalRecords[tSigPos];

					this.additionalRecords.RemoveAt(tSigPos);

					this.TSigOptions.ValidationResult = this.ValidateTSig(resultData, tsigKeySelector, originalMac);
				}
			}

			this.FinishParsing();
		}

		/// <summary>
		/// Validates the transaction signature.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="tsigKeySelector">The transaction signature key selector.</param>
		/// <param name="originalMac"></param>
		/// <returns>The original MAC.</returns>
		private ReturnCode ValidateTSig(byte[] resultData, DnsServer.SelectTsigKey tsigKeySelector, byte[] originalMac)
		{
			byte[] keyData;
			if ((this.TSigOptions.Algorithm == TSigAlgorithm.Unknown) || (tsigKeySelector == null) || ((keyData = tsigKeySelector(this.TSigOptions.Algorithm, this.TSigOptions.Name)) == null))
			{
				return ReturnCode.BadKey;
			}
			else if (((this.TSigOptions.TimeSigned - this.TSigOptions.Fudge) > DateTime.Now) || ((this.TSigOptions.TimeSigned + this.TSigOptions.Fudge) < DateTime.Now))
			{
				return ReturnCode.BadTime;
			}
			else if ((this.TSigOptions.Mac == null) || (this.TSigOptions.Mac.Length == 0))
			{
				return ReturnCode.BadSig;
			}
			else
			{
				this.TSigOptions.KeyData = keyData;

				// maxLength for the buffer to validate: Original (unsigned) dns message and encoded TSigOptions
				// because of compression of keyname, the size of the signed message can not be used
				int maxLength = this.TSigOptions.StartPosition + this.TSigOptions.MaximumLength;
				if (originalMac != null)
				{
					// add length of mac on responses. MacSize not neccessary, this field is allready included in the size of the tsig options
					maxLength += originalMac.Length;
				}

				byte[] validationBuffer = new byte[maxLength];

				int currentPosition = 0;

				// original mac if neccessary
				if ((originalMac != null) && (originalMac.Length > 0))
				{
					EncodeUShort(validationBuffer, ref currentPosition, (ushort) originalMac.Length);
					EncodeByteArray(validationBuffer, ref currentPosition, originalMac);
				}

				// original unsiged buffer
				Buffer.BlockCopy(resultData, 0, validationBuffer, currentPosition, this.TSigOptions.StartPosition);

				// update original transaction id and ar count in message
				DnsMessageBase.EncodeUShort(validationBuffer, currentPosition, this.TSigOptions.OriginalID);
				DnsMessageBase.EncodeUShort(validationBuffer, currentPosition + 10, (ushort)this.additionalRecords.Count);
				currentPosition += this.TSigOptions.StartPosition;

				// TSig Variables
				DnsMessageBase.EncodeDomainName(validationBuffer, 0, ref currentPosition, this.TSigOptions.Name, false, null);
				DnsMessageBase.EncodeUShort(validationBuffer, ref currentPosition, (ushort)this.TSigOptions.RecordClass);
				DnsMessageBase.EncodeInt(validationBuffer, ref currentPosition, (ushort)this.TSigOptions.TimeToLive);
				DnsMessageBase.EncodeDomainName(validationBuffer, 0, ref currentPosition, TSigAlgorithmHelper.GetDomainName(this.TSigOptions.Algorithm), false, null);
				TSigRecord.EncodeDateTime(validationBuffer, ref currentPosition, this.TSigOptions.TimeSigned);
				DnsMessageBase.EncodeUShort(validationBuffer, ref currentPosition, (ushort)this.TSigOptions.Fudge.TotalSeconds);
				DnsMessageBase.EncodeUShort(validationBuffer, ref currentPosition, (ushort)this.TSigOptions.Error);
				DnsMessageBase.EncodeUShort(validationBuffer, ref currentPosition, (ushort)this.TSigOptions.OtherData.Length);
				DnsMessageBase.EncodeByteArray(validationBuffer, ref currentPosition, this.TSigOptions.OtherData);

				// Validate MAC
				KeyedHashAlgorithm hashAlgorithm = TSigAlgorithmHelper.GetHashAlgorithm(this.TSigOptions.Algorithm);
				hashAlgorithm.Key = keyData;
				return (hashAlgorithm.ComputeHash(validationBuffer, 0, currentPosition).SequenceEqual(this.TSigOptions.Mac)) ? ReturnCode.NoError : ReturnCode.BadSig;
			}
		}

		#endregion

		#region Parsing

		/// <summary>
		/// A method called when the parsing of a message has finished.
		/// </summary>
		protected virtual void FinishParsing() {}

		#region Methods for parsing answer

		/// <summary>
		/// Parses an answer message section.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="sectionList">The section list.</param>
		/// <param name="recordCount">The record count.</param>
		private static void ParseSection(byte[] resultData, ref int currentPosition, List<DnsRecordBase> sectionList, int recordCount)
		{
			for (int i = 0; i < recordCount; i++)
			{
				sectionList.Add(DnsMessageBase.ParseRecord(resultData, ref currentPosition));
			}
		}

		/// <summary>
		/// Parses a message record.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <returns>The record.</returns>
		private static DnsRecordBase ParseRecord(byte[] resultData, ref int currentPosition)
		{
			int startPosition = currentPosition;

			string name = DnsMessageBase.ParseDomainName(resultData, ref currentPosition);
			RecordType recordType = (RecordType)DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			DnsRecordBase record = DnsRecordBase.Create(recordType, resultData, currentPosition + 6);
			record.StartPosition = startPosition;
			record.Name = name;
			record.RecordType = recordType;
			record.RecordClass = (RecordClass)DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			record.TimeToLive = DnsMessageBase.ParseInt(resultData, ref currentPosition);
			record.RecordDataLength = DnsMessageBase.ParseUShort(resultData, ref currentPosition);

			if (record.RecordDataLength > 0)
			{
				record.ParseRecordData(resultData, currentPosition, record.RecordDataLength);
				currentPosition += record.RecordDataLength;
			}

			return record;
		}

		/// <summary>
		/// Parses a message questions.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="recordCount">The record count.</param>
		private void ParseQuestions(byte[] resultData, ref int currentPosition, int recordCount)
		{
			for (int i = 0; i < recordCount; i++)
			{
				DnsQuestion question = new DnsQuestion { Name = ParseDomainName(resultData, ref currentPosition), RecordType = (RecordType) ParseUShort(resultData, ref currentPosition), RecordClass = (RecordClass) ParseUShort(resultData, ref currentPosition) };

				Questions.Add(question);
			}
		}

		#endregion

		#region Helper methods for parsing records

		/// <summary>
		/// Parses a text record.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <returns>The text value.</returns>
		internal static string ParseText(byte[] resultData, ref int currentPosition)
		{
			int length = resultData[currentPosition++];

			string res = Encoding.ASCII.GetString(resultData, currentPosition, length);
			currentPosition += length;

			return res;
		}

		/// <summary>
		/// Parses a domain name record.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <returns>The domain name value.</returns>
		internal static string ParseDomainName(byte[] resultData, ref int currentPosition)
		{
			StringBuilder sb = new StringBuilder();

			DnsMessageBase.ParseDomainName(resultData, ref currentPosition, sb);

			return (sb.Length == 0) ? String.Empty : sb.ToString(0, sb.Length - 1);
		}

		/// <summary>
		/// Parses an unsigned short value.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <returns>The unsigned short value.</returns>
		internal static ushort ParseUShort(byte[] resultData, ref int currentPosition)
		{
			ushort res;

			if (BitConverter.IsLittleEndian)
			{
				res = (ushort) ((resultData[currentPosition++] << 8) | resultData[currentPosition++]);
			}
			else
			{
				res = (ushort) (resultData[currentPosition++] | (resultData[currentPosition++] << 8));
			}

			return res;
		}

		/// <summary>
		/// Parses an integer value.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <returns>The integer value.</returns>
		internal static int ParseInt(byte[] resultData, ref int currentPosition)
		{
			int res;

			if (BitConverter.IsLittleEndian)
			{
				res = ((resultData[currentPosition++] << 24) | (resultData[currentPosition++] << 16) | (resultData[currentPosition++] << 8) | resultData[currentPosition++]);
			}
			else
			{
				res = (resultData[currentPosition++] | (resultData[currentPosition++] << 8) | (resultData[currentPosition++] << 16) | (resultData[currentPosition++] << 24));
			}

			return res;
		}

		/// <summary>
		/// Parses an unsigned integer value.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <returns>The unsigned integer value.</returns>
		internal static uint ParseUInt(byte[] resultData, ref int currentPosition)
		{
			uint res;

			if (BitConverter.IsLittleEndian)
			{
				res = (((uint) resultData[currentPosition++] << 24) | ((uint) resultData[currentPosition++] << 16) | ((uint) resultData[currentPosition++] << 8) | resultData[currentPosition++]);
			}
			else
			{
				res = (resultData[currentPosition++] | ((uint) resultData[currentPosition++] << 8) | ((uint) resultData[currentPosition++] << 16) | ((uint) resultData[currentPosition++] << 24));
			}

			return res;
		}

		/// <summary>
		/// Parses an unsigned long record.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <returns>The unsigned long value.</returns>
		internal static ulong ParseULong(byte[] resultData, ref int currentPosition)
		{
			ulong res;

			if (BitConverter.IsLittleEndian)
			{
				res = ((ulong) ParseUInt(resultData, ref currentPosition) << 32) | ParseUInt(resultData, ref currentPosition);
			}
			else
			{
				res = ParseUInt(resultData, ref currentPosition) | ((ulong) ParseUInt(resultData, ref currentPosition) << 32);
			}

			return res;
		}

		/// <summary>
		/// Parses a domain name record using the given string builder.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="sb">The string builder.</param>
		private static void ParseDomainName(byte[] resultData, ref int currentPosition, StringBuilder sb)
		{
			while (true)
			{
				byte currentByte = resultData[currentPosition++];
				if (currentByte == 0)
				{
					// end of domain, RFC1035
					return;
				}
				else if (currentByte >= 192)
				{
					// Pointer, RFC1035
					int pointer;
					if (BitConverter.IsLittleEndian)
					{
						pointer = (ushort) (((currentByte - 192) << 8) | resultData[currentPosition++]);
					}
					else
					{
						pointer = (ushort) ((currentByte - 192) | (resultData[currentPosition++] << 8));
					}

					ParseDomainName(resultData, ref pointer, sb);

					return;
				}
				else if (currentByte == 65)
				{
					// binary EDNS label, RFC2673, RFC3363, RFC3364
					int length = resultData[currentPosition++];
					if (length == 0)
						length = 256;

					sb.Append(@"\[x");
					string suffix = "/" + length + "]";

					do
					{
						currentByte = resultData[currentPosition++];
						if (length < 8)
						{
							currentByte &= (byte) (0xff >> (8 - length));
						}

						sb.Append(currentByte.ToString("x2"));

						length = length - 8;
					} while (length > 0);

					sb.Append(suffix);
				}
				else if (currentByte >= 64)
				{
					// extended dns label RFC 2671
					throw new NotSupportedException("Unsupported extended DNS label");
				}
				else
				{
					// append additional text part
					sb.Append(Encoding.ASCII.GetString(resultData, currentPosition, currentByte));
					sb.Append(".");
					currentPosition += currentByte;
				}
			}
		}

		/// <summary>
		/// Parses a byte data record.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="length">The byte data length.</param>
		/// <returns>The byte data value.</returns>
		internal static byte[] ParseByteData(byte[] resultData, ref int currentPosition, int length)
		{
			if (length == 0)
			{
				return new byte[] { };
			}
			else
			{
				byte[] res = new byte[length];
				Buffer.BlockCopy(resultData, currentPosition, res, 0, length);
				currentPosition += length;
				return res;
			}
		}

		#endregion

		#endregion

		#region Serializing

		/// <summary>
		/// A method called when preparing the encoding.
		/// </summary>
		protected virtual void PrepareEncoding() {}

		/// <summary>
		/// Encodes the current message to a message data.
		/// </summary>
		/// <param name="addLengthPrefix">If <b>true</b> the message adds the length prefix.</param>
		/// <param name="messageData">The message data.</param>
		/// <returns>The current position.</returns>
		internal int Encode(bool addLengthPrefix, out byte[] messageData)
		{
			byte[] newTSigMac;

			return Encode(addLengthPrefix, null, false, out messageData, out newTSigMac);
		}

		/// <summary>
		/// Encodes the current message to a message data.
		/// </summary>
		/// <param name="addLengthPrefix">If <b>true</b> the message adds the length prefix.</param>
		/// <param name="originalTsigMac">The original transaction signature MAC.</param>
		/// <param name="messageData">The message data.</param>
		/// <returns>The current position.</returns>
		internal int Encode(bool addLengthPrefix, byte[] originalTsigMac, out byte[] messageData)
		{
			byte[] newTSigMac;

			return Encode(addLengthPrefix, originalTsigMac, false, out messageData, out newTSigMac);
		}

		/// <summary>
		/// Encodes the current message to a message data.
		/// </summary>
		/// <param name="addLengthPrefix">If <b>true</b> the message adds the length prefix.</param>
		/// <param name="originalTsigMac">The original transaction signature MAC.</param>
		/// <param name="isSubSequentResponse">Indicates whether there exists a subsequent response.</param>
		/// <param name="messageData">The message data.</param>
		/// <param name="newTSigMac">The new transaction signature MAC.</param>
		/// <returns>The current position.</returns>
		internal int Encode(bool addLengthPrefix, byte[] originalTsigMac, bool isSubSequentResponse, out byte[] messageData, out byte[] newTSigMac)
		{
			this.PrepareEncoding();

			int offset = 0;
			int messageOffset = offset;
			int maxLength = addLengthPrefix ? 2 : 0;

			originalTsigMac = originalTsigMac ?? new byte[] { };

			if (this.TSigOptions != null)
			{
				if (!IsQuery)
				{
					offset += 2 + originalTsigMac.Length;
					maxLength += 2 + originalTsigMac.Length;
				}

				maxLength += this.TSigOptions.MaximumLength;
			}

			#region Get Message Length
			maxLength += 12;
			maxLength += this.Questions.Sum(question => question.MaximumLength);
			maxLength += this.AnswerRecords.Sum(record => record.MaximumLength);
			maxLength += this.AuthorityRecords.Sum(record => record.MaximumLength);
			maxLength += this.additionalRecords.Sum(record => record.MaximumLength);
			#endregion

			messageData = new byte[maxLength];
			int currentPosition = offset;

			Dictionary<string, ushort> domainNames = new Dictionary<string, ushort>();

			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, TransactionID);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, Flags);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)Questions.Count);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)AnswerRecords.Count);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)AuthorityRecords.Count);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)this.additionalRecords.Count);

			foreach (DnsQuestion question in Questions)
			{
				question.Encode(messageData, offset, ref currentPosition, domainNames);
			}
			foreach (DnsRecordBase record in AnswerRecords)
			{
				record.Encode(messageData, offset, ref currentPosition, domainNames);
			}
			foreach (DnsRecordBase record in AuthorityRecords)
			{
				record.Encode(messageData, offset, ref currentPosition, domainNames);
			}
			foreach (DnsRecordBase record in this.additionalRecords)
			{
				record.Encode(messageData, offset, ref currentPosition, domainNames);
			}

			if (this.TSigOptions == null)
			{
				newTSigMac = null;
			}
			else
			{
				if (!IsQuery)
				{
					DnsMessageBase.EncodeUShort(messageData, messageOffset, (ushort)originalTsigMac.Length);
					Buffer.BlockCopy(originalTsigMac, 0, messageData, messageOffset + 2, originalTsigMac.Length);
				}

				DnsMessageBase.EncodeUShort(messageData, offset, this.TSigOptions.OriginalID);

				int tsigVariablesPosition = currentPosition;

				if (isSubSequentResponse)
				{
					TSigRecord.EncodeDateTime(messageData, ref tsigVariablesPosition, this.TSigOptions.TimeSigned);
					DnsMessageBase.EncodeUShort(messageData, ref tsigVariablesPosition, (ushort)this.TSigOptions.Fudge.TotalSeconds);
				}
				else
				{
					DnsMessageBase.EncodeDomainName(messageData, offset, ref tsigVariablesPosition, this.TSigOptions.Name, false, null);
					DnsMessageBase.EncodeUShort(messageData, ref tsigVariablesPosition, (ushort)this.TSigOptions.RecordClass);
					DnsMessageBase.EncodeInt(messageData, ref tsigVariablesPosition, (ushort)this.TSigOptions.TimeToLive);
					DnsMessageBase.EncodeDomainName(messageData, offset, ref tsigVariablesPosition, TSigAlgorithmHelper.GetDomainName(this.TSigOptions.Algorithm), false, null);
					TSigRecord.EncodeDateTime(messageData, ref tsigVariablesPosition, this.TSigOptions.TimeSigned);
					DnsMessageBase.EncodeUShort(messageData, ref tsigVariablesPosition, (ushort)this.TSigOptions.Fudge.TotalSeconds);
					DnsMessageBase.EncodeUShort(messageData, ref tsigVariablesPosition, (ushort)this.TSigOptions.Error);
					DnsMessageBase.EncodeUShort(messageData, ref tsigVariablesPosition, (ushort)this.TSigOptions.OtherData.Length);
					DnsMessageBase.EncodeByteArray(messageData, ref tsigVariablesPosition, this.TSigOptions.OtherData);
				}

				KeyedHashAlgorithm hashAlgorithm = TSigAlgorithmHelper.GetHashAlgorithm(this.TSigOptions.Algorithm);
				//byte[] mac;
				if ((hashAlgorithm != null) && (this.TSigOptions.KeyData != null) && (this.TSigOptions.KeyData.Length > 0))
				{
					hashAlgorithm.Key = this.TSigOptions.KeyData;
					newTSigMac = hashAlgorithm.ComputeHash(messageData, messageOffset, tsigVariablesPosition);
				}
				else
				{
					newTSigMac = new byte[] { };
				}

				DnsMessageBase.EncodeUShort(messageData, offset, TransactionID);
				DnsMessageBase.EncodeUShort(messageData, offset + 10, (ushort)(this.additionalRecords.Count + 1));

				this.TSigOptions.Encode(messageData, offset, ref currentPosition, domainNames, newTSigMac);

				if (!IsQuery)
				{
					Buffer.BlockCopy(messageData, offset, messageData, messageOffset, (currentPosition - offset));
					currentPosition -= (2 + originalTsigMac.Length);
				}
			}

			if (addLengthPrefix)
			{
				Buffer.BlockCopy(messageData, 0, messageData, 2, currentPosition);
				DnsMessageBase.EncodeUShort(messageData, 0, (ushort)(currentPosition));
				currentPosition += 2;
			}

			return currentPosition;
		}

		/// <summary>
		/// Encodes an unsigned short value.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="value">The value.</param>
		internal static void EncodeUShort(byte[] buffer, int currentPosition, ushort value)
		{
			EncodeUShort(buffer, ref currentPosition, value);
		}

		/// <summary>
		/// Encodes an unsigned short value.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="value">The value.</param>
		internal static void EncodeUShort(byte[] buffer, ref int currentPosition, ushort value)
		{
			if (BitConverter.IsLittleEndian)
			{
				buffer[currentPosition++] = (byte) ((value >> 8) & 0xff);
				buffer[currentPosition++] = (byte) (value & 0xff);
			}
			else
			{
				buffer[currentPosition++] = (byte) (value & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 8) & 0xff);
			}
		}

		/// <summary>
		/// Encodes an integer value.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="value">The value.</param>
		internal static void EncodeInt(byte[] buffer, ref int currentPosition, int value)
		{
			if (BitConverter.IsLittleEndian)
			{
				buffer[currentPosition++] = (byte) ((value >> 24) & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 16) & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 8) & 0xff);
				buffer[currentPosition++] = (byte) (value & 0xff);
			}
			else
			{
				buffer[currentPosition++] = (byte) (value & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 8) & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 16) & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 24) & 0xff);
			}
		}

		/// <summary>
		/// Encodes an unsigned integer value.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="value">The value.</param>
		internal static void EncodeUInt(byte[] buffer, ref int currentPosition, uint value)
		{
			if (BitConverter.IsLittleEndian)
			{
				buffer[currentPosition++] = (byte) ((value >> 24) & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 16) & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 8) & 0xff);
				buffer[currentPosition++] = (byte) (value & 0xff);
			}
			else
			{
				buffer[currentPosition++] = (byte) (value & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 8) & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 16) & 0xff);
				buffer[currentPosition++] = (byte) ((value >> 24) & 0xff);
			}
		}

		/// <summary>
		/// Encodes an unsigned long value.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="value">The value.</param>
		internal static void EncodeULong(byte[] buffer, ref int currentPosition, ulong value)
		{
			if (BitConverter.IsLittleEndian)
			{
				DnsMessageBase.EncodeUInt(buffer, ref currentPosition, (uint) ((value >> 32) & 0xffffffff));
				DnsMessageBase.EncodeUInt(buffer, ref currentPosition, (uint)(value & 0xffffffff));
			}
			else
			{
				DnsMessageBase.EncodeUInt(buffer, ref currentPosition, (uint)(value & 0xffffffff));
				DnsMessageBase.EncodeUInt(buffer, ref currentPosition, (uint)((value >> 32) & 0xffffffff));
			}
		}

		/// <summary>
		/// Encodes a domain name value.
		/// </summary>
		/// <param name="messageData">The buffer.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="name">The name.</param>
		/// <param name="isCompressionAllowed">If <b>true</b> compression is allowed.</param>
		/// <param name="domainNames">The list of domain names.</param>
		internal static void EncodeDomainName(byte[] messageData, int offset, ref int currentPosition, string name, bool isCompressionAllowed, Dictionary<string, ushort> domainNames)
		{
			if (String.IsNullOrEmpty(name) || (name == "."))
			{
				messageData[currentPosition++] = 0;
				return;
			}

			ushort pointer;
			if (isCompressionAllowed && domainNames.TryGetValue(name, out pointer))
			{
				DnsMessageBase.EncodeUShort(messageData, ref currentPosition, pointer);
				return;
			}

			int labelLength = name.IndexOf('.');
			if (labelLength == -1)
				labelLength = name.Length;

			if (isCompressionAllowed)
				domainNames[name] = (ushort) ((currentPosition | 0xc000) - offset);

			messageData[currentPosition++] = (byte) labelLength;
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, Encoding.ASCII.GetBytes(name.ToCharArray(0, labelLength)));

			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, labelLength == name.Length ? "." : name.Substring(labelLength + 1), isCompressionAllowed, domainNames);
		}

		/// <summary>
		/// Encodes a text value.
		/// </summary>
		/// <param name="messageData">The buffer.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="text">The value.</param>
		internal static void EncodeText(byte[] messageData, ref int currentPosition, string text)
		{
			byte[] textData = Encoding.ASCII.GetBytes(text.ToCharArray());

			for (int i = 0; i < textData.Length; i += 255)
			{
				int blockLength = Math.Min(255, (textData.Length - i));
				messageData[currentPosition++] = (byte) blockLength;

				Buffer.BlockCopy(textData, i, messageData, currentPosition, blockLength);
				currentPosition += blockLength;
			}
		}

		/// <summary>
		/// Encodes a byte array value.
		/// </summary>
		/// <param name="messageData">The buffer.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="data">The value.</param>
		internal static void EncodeByteArray(byte[] messageData, ref int currentPosition, byte[] data)
		{
			if (data != null)
			{
				DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, data, data.Length);
			}
		}

		/// <summary>
		/// Encodes a byte array value of specified length.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="data">The value.</param>
		/// <param name="length">The length.</param>
		internal static void EncodeByteArray(byte[] messageData, ref int currentPosition, byte[] data, int length)
		{
			if ((data != null) && (length > 0))
			{
				Buffer.BlockCopy(data, 0, messageData, currentPosition, length);
				currentPosition += length;
			}
		}

		#endregion
	}
}