using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SpectrumV1.Utilities.Common
{
	public static class SystemUtilities
	{
		public static IPasswordHasher PasswordHasher { get; set; }

		// Added encrypt password to read from database
		public static string Base64Encode(string plainText)
		{
			var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(plainTextBytes);
		}

		public static string Base64Decode(string base64EncodedData)
		{
			var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(base64EncodedBytes);
		}


		// MD5
		public static string CreateMd5(string input)
		{
			// Use input string to calculate MD5 hash
			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.ASCII.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				//return Convert.ToHexString(hashBytes); // .NET 5 +

				// Convert the byte array to hexadecimal string prior to .NET 5
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("X2"));
				}
				return sb.ToString();
			}
		}

		// SHA256
		public static string HashString(string text, string salt = "")
		{
			if (String.IsNullOrEmpty(text))
			{
				return String.Empty;
			}

			// Uses SHA256 to create the hash
			using (var sha = new SHA256Managed())
			{
				// Convert the string to a byte array first, to be processed
				byte[] textBytes = Encoding.UTF8.GetBytes(text + salt);
				byte[] hashBytes = sha.ComputeHash(textBytes);

				// Convert back to a string, removing the '-' that BitConverter adds
				string hash = BitConverter
					.ToString(hashBytes)
					.Replace("-", String.Empty);

				return hash;
			}
		}

		//SHA512
		public static string HashString512(string text, string salt = "")
		{
			if (String.IsNullOrEmpty(text))
			{
				return String.Empty;
			}

			// Uses SHA256 to create the hash
			using (var sha = new SHA512Managed())
			{
				// Convert the string to a byte array first, to be processed
				byte[] textBytes = Encoding.UTF8.GetBytes(text + salt);
				byte[] hashBytes = sha.ComputeHash(textBytes);

				// Convert back to a string, removing the '-' that BitConverter adds
				string hash = BitConverter
					.ToString(hashBytes)
					.Replace("-", String.Empty);

				return hash;
			}
		}


		// PasswordHasher
		public static string PasswordHasher5(string password)
		{
			RandomNumberGenerator rng = RandomNumberGenerator.Create();
			const KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
			const int Pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
			const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits
			const int SaltSize = 128 / 8; // 128 bits

			// Produce a version 2 (see comment above) text hash.
			byte[] salt = new byte[SaltSize];
			rng.GetBytes(salt);
			byte[] subkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

			var outputBytes = new byte[1 + SaltSize + Pbkdf2SubkeyLength];
			outputBytes[0] = 0x00; // format marker
			Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
			Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, Pbkdf2SubkeyLength);

			return Convert.ToBase64String(outputBytes);

			//return hashed;
		}

		public static bool VerifyHashedPassword(string hashedPassword, string password)
		{
			if (hashedPassword == null)
				return false;
			if (password == null)
				throw new ArgumentNullException(nameof(password));
			byte[] src = Convert.FromBase64String(hashedPassword);
			if (src.Length != 49 || src[0] != (byte)0)
				return false;
			byte[] numArray1 = new byte[16];
			Buffer.BlockCopy((Array)src, 1, (Array)numArray1, 0, 16);
			byte[] numArray2 = new byte[32];
			Buffer.BlockCopy((Array)src, 17, (Array)numArray2, 0, 32);
			byte[] bytes;
			using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, numArray1, 1000))
				bytes = rfc2898DeriveBytes.GetBytes(32);
			return ByteArraysEqual(numArray2, bytes);
		}
		private static bool ByteArraysEqual(byte[] a, byte[] b)
		{
			if (a == b)
				return true;
			if (a == null || b == null || a.Length != b.Length)
				return false;
			bool flag = true;
			for (int index = 0; index < a.Length; ++index)
				flag &= (int)a[index] == (int)b[index];
			return flag;
		}

	}
}
