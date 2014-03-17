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
using System.Net.NetworkInformation;

namespace ARSoft.Tools.Net.Dns
{
	/// <summary>
	/// <para>EDNS0 Owner Option.</para> <para>Defined in <see cref="http://files.dns-sd.org/draft-sekar-dns-llq.txt">draft-cheshire-edns0-owner-option</see>.</para>
	/// </summary>
	public class OwnerOption : EDnsOptionBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal OwnerOption()
			: base(EDnsOptionType.Owner) {}

		/// <summary>
		/// Creates a new instance of the OwnerOption class
		/// </summary>
		/// <param name="sequence">The sequence number.</param>
		/// <param name="primaryMacAddress">The primary MAC address.</param>
		public OwnerOption(byte sequence, PhysicalAddress primaryMacAddress)
			: this(0, sequence, primaryMacAddress, null) {}

		/// <summary>
		/// Creates a new instance of the OwnerOption class
		/// </summary>
		/// <param name="version">The version.</param>
		/// <param name="sequence">The sequence number.</param>
		/// <param name="primaryMacAddress">The primary MAC address.</param>
		public OwnerOption(byte version, byte sequence, PhysicalAddress primaryMacAddress)
			: this(version, sequence, primaryMacAddress, null) {}

		/// <summary>
		/// Creates a new instance of the OwnerOption class
		/// </summary>
		/// <param name="sequence">The sequence number.</param>
		/// <param name="primaryMacAddress">The primary MAC address.</param>
		/// <param name="wakeupMacAddress">The wakeup MAC address.</param>
		public OwnerOption(byte sequence, PhysicalAddress primaryMacAddress, PhysicalAddress wakeupMacAddress)
			: this(0, sequence, primaryMacAddress, wakeupMacAddress) {}

		/// <summary>
		/// Creates a new instance of the OwnerOption class
		/// </summary>
		/// <param name="version">The version.</param>
		/// <param name="sequence">The sequence number.</param>
		/// <param name="primaryMacAddress">The primary MAC address.</param>
		/// <param name="wakeupMacAddress">The wakeup MAC address.</param>
		public OwnerOption(byte version, byte sequence, PhysicalAddress primaryMacAddress, PhysicalAddress wakeupMacAddress)
			: this(version, sequence, primaryMacAddress, wakeupMacAddress, null) {}

		/// <summary>
		/// Creates a new instance of the OwnerOption class
		/// </summary>
		/// <param name="sequence">The sequence number.</param>
		/// <param name="primaryMacAddress">The primary MAC address.</param>
		/// <param name="wakeupMacAddress">The wakeup MAC address.</param>
		/// <param name="password">The password, should be empty, 4 bytes long or 6 bytes long.</param>
		public OwnerOption(byte sequence, PhysicalAddress primaryMacAddress, PhysicalAddress wakeupMacAddress, byte[] password)
			: this(0, sequence, primaryMacAddress, wakeupMacAddress, password) {}

		/// <summary>
		/// Creates a new instance of the OwnerOption class
		/// </summary>
		/// <param name="version">The version.</param>
		/// <param name="sequence">The sequence number.</param>
		/// <param name="primaryMacAddress">The primary MAC address.</param>
		/// <param name="wakeupMacAddress">The wakeup MAC address.</param>
		/// <param name="password">The password, should be empty, 4 bytes long or 6 bytes long.</param>
		public OwnerOption(byte version, byte sequence, PhysicalAddress primaryMacAddress, PhysicalAddress wakeupMacAddress, byte[] password)
			: this()
		{
			Version = version;
			Sequence = sequence;
			PrimaryMacAddress = primaryMacAddress;
			WakeupMacAddress = wakeupMacAddress;
			Password = password;
		}

		// Public properties.

		/// <summary>
		/// The version
		/// </summary>
		public byte Version { get; private set; }
		/// <summary>
		/// The sequence number
		/// </summary>
		public byte Sequence { get; private set; }
		/// <summary>
		/// The primary MAC address
		/// </summary>
		public PhysicalAddress PrimaryMacAddress { get; private set; }
		/// <summary>
		/// The Wakeup MAC address
		/// </summary>
		public PhysicalAddress WakeupMacAddress { get; private set; }
		/// <summary>
		/// The password, should be empty, 4 bytes long or 6 bytes long
		/// </summary>
		public byte[] Password { get; private set; }

		// Internal properties.

		/// <summary>
		/// Gets the data length.
		/// </summary>
		internal override ushort DataLength
		{
			get { return (ushort)(8 + (this.WakeupMacAddress != null ? 6 : 0) + (this.Password != null ? this.Password.Length : 0)); }
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
			this.Version = resultData[startPosition++];
			this.Sequence = resultData[startPosition++];
			this.PrimaryMacAddress = new PhysicalAddress(DnsMessageBase.ParseByteData(resultData, ref startPosition, 6));
			if (length > 8)
				this.WakeupMacAddress = new PhysicalAddress(DnsMessageBase.ParseByteData(resultData, ref startPosition, 6));
			if (length > 14)
				this.Password = DnsMessageBase.ParseByteData(resultData, ref startPosition, length - 14);
		}

		/// <summary>
		/// Encodes the option.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="currentPosition">The current position.</param>
		internal override void EncodeData(byte[] messageData, ref int currentPosition)
		{
			messageData[currentPosition++] = this.Version;
			messageData[currentPosition++] = this.Sequence;
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.PrimaryMacAddress.GetAddressBytes());
			if (this.WakeupMacAddress != null)
				DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.WakeupMacAddress.GetAddressBytes());
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.Password);
		}
	}
}