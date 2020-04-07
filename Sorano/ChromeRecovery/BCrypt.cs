using System;
using System.Runtime.InteropServices;

namespace ChromeRecovery
{
	// Token: 0x02000049 RID: 73
	public static class BCrypt
	{
		// Token: 0x0600024E RID: 590
		[DllImport("bcrypt.dll")]
		public static extern uint BCryptOpenAlgorithmProvider(out IntPtr phAlgorithm, [MarshalAs(UnmanagedType.LPWStr)] string pszAlgId, [MarshalAs(UnmanagedType.LPWStr)] string pszImplementation, uint dwFlags);

		// Token: 0x0600024F RID: 591
		[DllImport("bcrypt.dll")]
		public static extern uint BCryptCloseAlgorithmProvider(IntPtr hAlgorithm, uint flags);

		// Token: 0x06000250 RID: 592
		[DllImport("bcrypt.dll")]
		public static extern uint BCryptGetProperty(IntPtr hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, byte[] pbOutput, int cbOutput, ref int pcbResult, uint flags);

		// Token: 0x06000251 RID: 593
		[DllImport("bcrypt.dll")]
		internal static extern uint BCryptSetProperty(IntPtr intptr_0, [MarshalAs(UnmanagedType.LPWStr)] string string_0, byte[] byte_0, int int_0, int int_1);

		// Token: 0x06000252 RID: 594
		[DllImport("bcrypt.dll")]
		public static extern uint BCryptImportKey(IntPtr hAlgorithm, IntPtr hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, out IntPtr phKey, IntPtr pbKeyObject, int cbKeyObject, byte[] pbInput, int cbInput, uint dwFlags);

		// Token: 0x06000253 RID: 595
		[DllImport("bcrypt.dll")]
		public static extern uint BCryptDestroyKey(IntPtr hKey);

		// Token: 0x06000254 RID: 596
		[DllImport("bcrypt.dll")]
		public static extern uint BCryptEncrypt(IntPtr hKey, byte[] pbInput, int cbInput, ref BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO pPaddingInfo, byte[] pbIV, int cbIV, byte[] pbOutput, int cbOutput, ref int pcbResult, uint dwFlags);

		// Token: 0x06000255 RID: 597
		[DllImport("bcrypt.dll")]
		internal static extern uint BCryptDecrypt(IntPtr intptr_0, byte[] byte_0, int int_0, ref BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO bcrypt_AUTHENTICATED_CIPHER_MODE_INFO_0, byte[] byte_1, int int_1, byte[] byte_2, int int_2, ref int int_3, int int_4);

		// Token: 0x06000256 RID: 598 RVA: 0x00011CC4 File Offset: 0x0000FEC4
		// Note: this type is marked as 'beforefieldinit'.
		static BCrypt()
		{
			Class34.A1SfXVPz7w9eh();
			BCrypt.BCRYPT_KEY_DATA_BLOB_MAGIC = BitConverter.GetBytes(1296188491);
			BCrypt.BCRYPT_OBJECT_LENGTH = "ObjectLength";
			BCrypt.BCRYPT_CHAIN_MODE_GCM = "ChainingModeGCM";
			BCrypt.BCRYPT_AUTH_TAG_LENGTH = "AuthTagLength";
			BCrypt.BCRYPT_CHAINING_MODE = "ChainingMode";
			BCrypt.BCRYPT_KEY_DATA_BLOB = "KeyDataBlob";
			BCrypt.BCRYPT_AES_ALGORITHM = "AES";
			BCrypt.MS_PRIMITIVE_PROVIDER = "Microsoft Primitive Provider";
			BCrypt.BCRYPT_AUTH_MODE_CHAIN_CALLS_FLAG = 1;
			BCrypt.BCRYPT_INIT_AUTH_MODE_INFO_VERSION = 1;
			BCrypt.STATUS_AUTH_TAG_MISMATCH = 3221266434U;
		}

		// Token: 0x040000FC RID: 252
		public const uint ERROR_SUCCESS = 0U;

		// Token: 0x040000FD RID: 253
		public const uint BCRYPT_PAD_PSS = 8U;

		// Token: 0x040000FE RID: 254
		public const uint BCRYPT_PAD_OAEP = 4U;

		// Token: 0x040000FF RID: 255
		public static readonly byte[] BCRYPT_KEY_DATA_BLOB_MAGIC;

		// Token: 0x04000100 RID: 256
		public static readonly string BCRYPT_OBJECT_LENGTH;

		// Token: 0x04000101 RID: 257
		public static readonly string BCRYPT_CHAIN_MODE_GCM;

		// Token: 0x04000102 RID: 258
		public static readonly string BCRYPT_AUTH_TAG_LENGTH;

		// Token: 0x04000103 RID: 259
		public static readonly string BCRYPT_CHAINING_MODE;

		// Token: 0x04000104 RID: 260
		public static readonly string BCRYPT_KEY_DATA_BLOB;

		// Token: 0x04000105 RID: 261
		public static readonly string BCRYPT_AES_ALGORITHM;

		// Token: 0x04000106 RID: 262
		public static readonly string MS_PRIMITIVE_PROVIDER;

		// Token: 0x04000107 RID: 263
		public static readonly int BCRYPT_AUTH_MODE_CHAIN_CALLS_FLAG;

		// Token: 0x04000108 RID: 264
		public static readonly int BCRYPT_INIT_AUTH_MODE_INFO_VERSION;

		// Token: 0x04000109 RID: 265
		public static readonly uint STATUS_AUTH_TAG_MISMATCH;

		// Token: 0x0200004A RID: 74
		public struct BCRYPT_PSS_PADDING_INFO
		{
			// Token: 0x06000257 RID: 599 RVA: 0x00002F55 File Offset: 0x00001155
			public BCRYPT_PSS_PADDING_INFO(string pszAlgId, int cbSalt)
			{
				Class34.A1SfXVPz7w9eh();
				this.pszAlgId = pszAlgId;
				this.cbSalt = cbSalt;
			}

			// Token: 0x0400010A RID: 266
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pszAlgId;

			// Token: 0x0400010B RID: 267
			public int cbSalt;
		}

		// Token: 0x0200004B RID: 75
		public struct BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO : IDisposable
		{
			// Token: 0x06000258 RID: 600 RVA: 0x00011D44 File Offset: 0x0000FF44
			public BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(byte[] iv, byte[] aad, byte[] tag)
			{
				Class34.A1SfXVPz7w9eh();
				this = default(BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO);
				this.dwInfoVersion = BCrypt.BCRYPT_INIT_AUTH_MODE_INFO_VERSION;
				this.cbSize = Marshal.SizeOf(typeof(BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO));
				if (iv != null)
				{
					this.cbNonce = iv.Length;
					this.pbNonce = Marshal.AllocHGlobal(this.cbNonce);
					Marshal.Copy(iv, 0, this.pbNonce, this.cbNonce);
				}
				if (aad != null)
				{
					this.cbAuthData = aad.Length;
					this.pbAuthData = Marshal.AllocHGlobal(this.cbAuthData);
					Marshal.Copy(aad, 0, this.pbAuthData, this.cbAuthData);
				}
				if (tag != null)
				{
					this.cbTag = tag.Length;
					this.pbTag = Marshal.AllocHGlobal(this.cbTag);
					Marshal.Copy(tag, 0, this.pbTag, this.cbTag);
					this.cbMacContext = tag.Length;
					this.pbMacContext = Marshal.AllocHGlobal(this.cbMacContext);
				}
			}

			// Token: 0x06000259 RID: 601 RVA: 0x00011E30 File Offset: 0x00010030
			public void Dispose()
			{
				if (this.pbNonce != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.pbNonce);
				}
				if (this.pbTag != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.pbTag);
				}
				if (this.pbAuthData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.pbAuthData);
				}
				if (this.pbMacContext != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.pbMacContext);
				}
			}

			// Token: 0x0400010C RID: 268
			public int cbSize;

			// Token: 0x0400010D RID: 269
			public int dwInfoVersion;

			// Token: 0x0400010E RID: 270
			public IntPtr pbNonce;

			// Token: 0x0400010F RID: 271
			public int cbNonce;

			// Token: 0x04000110 RID: 272
			public IntPtr pbAuthData;

			// Token: 0x04000111 RID: 273
			public int cbAuthData;

			// Token: 0x04000112 RID: 274
			public IntPtr pbTag;

			// Token: 0x04000113 RID: 275
			public int cbTag;

			// Token: 0x04000114 RID: 276
			public IntPtr pbMacContext;

			// Token: 0x04000115 RID: 277
			public int cbMacContext;

			// Token: 0x04000116 RID: 278
			public int cbAAD;

			// Token: 0x04000117 RID: 279
			public long cbData;

			// Token: 0x04000118 RID: 280
			public int dwFlags;
		}

		// Token: 0x0200004C RID: 76
		public struct BCRYPT_KEY_LENGTHS_STRUCT
		{
			// Token: 0x04000119 RID: 281
			public int dwMinLength;

			// Token: 0x0400011A RID: 282
			public int dwMaxLength;

			// Token: 0x0400011B RID: 283
			public int dwIncrement;
		}

		// Token: 0x0200004D RID: 77
		public struct BCRYPT_OAEP_PADDING_INFO
		{
			// Token: 0x0600025A RID: 602 RVA: 0x00002F6A File Offset: 0x0000116A
			public BCRYPT_OAEP_PADDING_INFO(string alg)
			{
				Class34.A1SfXVPz7w9eh();
				this.pszAlgId = alg;
				this.pbLabel = IntPtr.Zero;
				this.cbLabel = 0;
			}

			// Token: 0x0400011C RID: 284
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pszAlgId;

			// Token: 0x0400011D RID: 285
			public IntPtr pbLabel;

			// Token: 0x0400011E RID: 286
			public int cbLabel;
		}
	}
}
