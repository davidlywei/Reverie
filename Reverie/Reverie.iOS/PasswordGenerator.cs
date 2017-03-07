using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; //apparently not PCL compliant, must use in iOS or Android
using Mono;
using Reverie.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(PasswordGenerator))]
namespace Reverie.iOS
{
	public class PasswordGenerator : Password
	{

		static readonly char[] consonants = { 'B', 'C', 'D', 'F', 'G',
											'H', 'J', 'K', 'L', 'M',
											'N', 'P', 'R', 'S', 'T',
											'V', 'W', 'Y', 'Z'};
		static readonly char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

		//protected int passwordLength = 12;

		byte[] hash; //byte array to hold sha512 hash

		//String input = "Password"; //temperary string
		String password = "";

		public PasswordGenerator() 
		{
		
		}
/*
		public void SetPasswordLength(int length)
		{
			passwordLength = length;
		}

		protected void ComputeHash(String s)
		{
			//s = input; //temporary hash

			System.Security.Cryptography.SHA512Managed sha512 = new System.Security.Cryptography.SHA512Managed();

			//compute hash value from string, returns a byte array
			hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(s));

			StringBuilder stringBuilder = new StringBuilder();

			//string password = ""; //empty string
			foreach (byte b in hash)
			{
				//convert each byte of hash value to string
				stringBuilder.Append(b.ToString());
			}

			password = stringBuilder.ToString();

		}

		protected void parseHash()
		{
			//loop through each byte in hash
			foreach (byte b in hash)
			{
				//convert each byte of hash value to string
				stringBuilder.Append(b.ToString());
			}
			
		}
*/

		public String GetHash(String s)
		{
			
			System.Security.Cryptography.SHA512Managed sha512 = new System.Security.Cryptography.SHA512Managed();

			//compute hash value from string, returns a byte array
			hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(s));

			StringBuilder stringBuilder = new StringBuilder();

			//string password = ""; //empty string
			foreach (byte b in hash)
			{
				//convert each byte of hash value to string
				stringBuilder.Append(b.ToString());
			}

			password = stringBuilder.ToString();


			//password = s;

			return password;
		}

	}
}
