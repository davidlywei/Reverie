using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security; //apparently not PCL compliant, must use in iOS or Android
using Mono;

namespace Reverie.iOS
{
	public class PasswordGenerator : Password
	{

		static readonly char[] consonants = { 'B', 'C', 'D', 'F', 'G',
											'H', 'J', 'K', 'L', 'M',
											'N', 'P', 'R', 'S', 'T',
											'V', 'W', 'Y', 'Z'};
		static readonly char[] vowels = { 'a', 'e', 'i', 'o', 'u' };


		String password = "";

		public PasswordGenerator()
		{


		}
/*
		protected byte[] ComputeHash(byte[] data)
		{
			var input = CryptographicBuffer.CreateFromByteArray(data);

			var hasher = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha256);
			var hashedBuf = hasher.HashData(input);

			byte[] result = new byte[hashedBuf.Length];
			CryptographicBuffer.CopyToByteArray(hashedBuf, out result);
			return result;
		}
*/
		public String GetHash(String s)
		{
			//use unicode encoding to covert 
			//UnicodeEncoding UE = new UnicodeEncoding();
			//byte[] unicodeByte = UE.GetBytes(s);

			SHA512Managed sha512 = new SHA512Managed();

			//compute hash value from string, returns a byte array
			byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(s));

			StringBuilder stringBuilder = new StringBuilder();

			//string password = ""; //empty string
			foreach (byte b in hash)
			{
				//convert each byte of hash value to string
				stringBuilder.Append(b.ToString());
			}

			password = stringBuilder.ToString();

			return password;
		}

	}
}
