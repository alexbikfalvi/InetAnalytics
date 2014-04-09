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
using System.Security.Cryptography;

namespace InetApi.Net.Core.Dns
{
	/// <summary>
	/// A helper class for transaction signature algorithms.
	/// </summary>
	internal class TSigAlgorithmHelper
	{
		// Public methods.

		/// <summary>
		/// Gets the domain name of the specified algorithm.
		/// </summary>
		/// <param name="algorithm">The algorithm.</param>
		/// <returns>The domain name.</returns>
		public static string GetDomainName(TSigAlgorithm algorithm)
		{
			switch (algorithm)
			{
				case TSigAlgorithm.Md5:
					return "hmac-md5.sig-alg.reg.int";
				case TSigAlgorithm.Sha1:
					return "hmac-sha1";
				case TSigAlgorithm.Sha256:
					return "hmac-sha256";
				case TSigAlgorithm.Sha384:
					return "hmac-sha384";
				case TSigAlgorithm.Sha512:
					return "hmac-sha512";
				default:
					return null;
			}
		}

		/// <summary>
		/// Gets the algorithm for the specfied domain name.
		/// </summary>
		/// <param name="name">The domain name.</param>
		/// <returns>The algorithm.</returns>
		public static TSigAlgorithm GetAlgorithmByName(string name)
		{
			switch (name.ToLower())
			{
				case "hmac-md5.sig-alg.reg.int":
					return TSigAlgorithm.Md5;
				case "hmac-sha1":
					return TSigAlgorithm.Sha1;
				case "hmac-sha256":
					return TSigAlgorithm.Sha256;
				case "hmac-sha384":
					return TSigAlgorithm.Sha384;
				case "hmac-sha512":
					return TSigAlgorithm.Sha512;
				default:
					return TSigAlgorithm.Unknown;
			}
		}

		/// <summary>
		/// Gets a hash algorithm instance of the specified type.
		/// </summary>
		/// <param name="algorithm">The algorithm type.</param>
		/// <returns>The algorithm instance.</returns>
		public static KeyedHashAlgorithm GetHashAlgorithm(TSigAlgorithm algorithm)
		{
			switch (algorithm)
			{
				case TSigAlgorithm.Md5:
					return new HMACMD5();
				case TSigAlgorithm.Sha1:
					return new HMACSHA1();
				case TSigAlgorithm.Sha256:
					return new HMACSHA256();
				case TSigAlgorithm.Sha384:
					return new HMACSHA384();
				case TSigAlgorithm.Sha512:
					return new HMACSHA512();
				default:
					return null;
			}
		}

		/// <summary>
		/// Gets the hash size of the specified algorithm.
		/// </summary>
		/// <param name="algorithm">The algorithm.</param>
		/// <returns>The hash size.</returns>
		internal static int GetHashSize(TSigAlgorithm algorithm)
		{
			switch (algorithm)
			{
				case TSigAlgorithm.Md5:
					return 16;
				case TSigAlgorithm.Sha1:
					return 20;
				case TSigAlgorithm.Sha256:
					return 32;
				case TSigAlgorithm.Sha384:
					return 48;
				case TSigAlgorithm.Sha512:
					return 64;
				default:
					return 0;
			}
		}
	}
}