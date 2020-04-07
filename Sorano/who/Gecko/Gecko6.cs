using System;
using System.Security.Cryptography;
using System.Text;

namespace who.Gecko
{
	// Token: 0x02000035 RID: 53
	public static class Gecko6
	{
		// Token: 0x060001B8 RID: 440 RVA: 0x0000E320 File Offset: 0x0000C520
		public static string lTRjlt(byte[] key, byte[] iv, byte[] input, PaddingMode paddingMode = PaddingMode.None)
		{
			string @string;
			using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider())
			{
				tripleDESCryptoServiceProvider.Key = key;
				tripleDESCryptoServiceProvider.IV = iv;
				tripleDESCryptoServiceProvider.Mode = CipherMode.CBC;
				tripleDESCryptoServiceProvider.Padding = paddingMode;
				using (ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor(key, iv))
				{
					@string = Encoding.Default.GetString(cryptoTransform.TransformFinalBlock(input, 0, input.Length));
				}
			}
			return @string;
		}
	}
}
