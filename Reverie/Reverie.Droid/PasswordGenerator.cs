using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; //apparently not PCL compliant, must use in iOS or Android
using Mono;
using Reverie.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(PasswordGenerator))]
namespace Reverie.Droid
{
	public class PasswordGenerator : Password
	{
		/*
		static readonly char[] consonants = { 'B', 'C', 'D', 'F', 'G',
											'H', 'J', 'K', 'L', 'M',
											'N', 'P', 'R', 'S', 'T',
											'V', 'W', 'Y', 'Z'};
		*/
		static readonly String[] vowelsLowerCase = { "a", "e", "i", "o", "u" };
		static readonly String[] vowelsUpperCase = { "A", "E", "I", "O", "U" };


		protected int passwordLength = 12;

		byte[] hash; //byte array to hold sha512 hash

		//String password = ""; //string to hold password


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
		*/
		protected String AddLowerCase(String s)
		{
			//loop thourgh all 5 vowels
			for (int i = 0; i < passwordLength; i++)
			{
				//replace uppercase vowels with lower case vowels
				s = s.Replace(vowelsUpperCase[i], vowelsLowerCase[i]);
			}

			return s;
		}


		public String GetHash(String s)
		{
			System.Security.Cryptography.SHA512Managed sha512 = new System.Security.Cryptography.SHA512Managed();

			//compute hash value from string, returns a byte array
			hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(s));

			StringBuilder stringBuilder = new StringBuilder();

			foreach (byte b in hash)
			{
				//convert each byte of hash value to string
				stringBuilder.Append(b.ToString("X2"));
			}

			String temp = stringBuilder.ToString(); //convert to string

			String temp1 = temp.Substring(0, passwordLength); //truncate password to desired length

			String password = AddLowerCase(temp1);

			return password;
		}

	}
}
