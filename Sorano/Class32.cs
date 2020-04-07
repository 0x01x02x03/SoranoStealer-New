using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using ChromeRecovery;

// Token: 0x02000048 RID: 72
internal class Class32
{
	// Token: 0x06000247 RID: 583 RVA: 0x00011964 File Offset: 0x0000FB64
	public byte[] method_0(byte[] byte_0, byte[] byte_1, byte[] byte_2, byte[] byte_3, byte[] byte_4)
	{
		IntPtr intPtr = this.method_2(BCrypt.BCRYPT_AES_ALGORITHM, BCrypt.MS_PRIMITIVE_PROVIDER, BCrypt.BCRYPT_CHAIN_MODE_GCM);
		IntPtr intPtr2;
		IntPtr hglobal = this.method_3(intPtr, byte_0, out intPtr2);
		BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO bcrypt_AUTHENTICATED_CIPHER_MODE_INFO = new BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(byte_1, byte_2, byte_4);
		byte[] array2;
		using (bcrypt_AUTHENTICATED_CIPHER_MODE_INFO)
		{
			byte[] array = new byte[this.method_1(intPtr)];
			int num = 0;
			uint num2 = BCrypt.BCryptDecrypt(intPtr2, byte_3, byte_3.Length, ref bcrypt_AUTHENTICATED_CIPHER_MODE_INFO, array, array.Length, null, 0, ref num, 0);
			if (num2 > 0U)
			{
				throw new CryptographicException(string.Format("BCrypt.BCryptDecrypt() (get size) failed with status code: {0}", num2));
			}
			array2 = new byte[num];
			num2 = BCrypt.BCryptDecrypt(intPtr2, byte_3, byte_3.Length, ref bcrypt_AUTHENTICATED_CIPHER_MODE_INFO, array, array.Length, array2, array2.Length, ref num, 0);
			if (num2 == BCrypt.STATUS_AUTH_TAG_MISMATCH)
			{
				throw new CryptographicException("BCrypt.BCryptDecrypt(): authentication tag mismatch");
			}
			if (num2 > 0U)
			{
				throw new CryptographicException(string.Format("BCrypt.BCryptDecrypt() failed with status code:{0}", num2));
			}
		}
		BCrypt.BCryptDestroyKey(intPtr2);
		Marshal.FreeHGlobal(hglobal);
		BCrypt.BCryptCloseAlgorithmProvider(intPtr, 0U);
		return array2;
	}

	// Token: 0x06000248 RID: 584 RVA: 0x00011A84 File Offset: 0x0000FC84
	private int method_1(IntPtr intptr_0)
	{
		byte[] array = this.oaijRxoMrH(intptr_0, BCrypt.BCRYPT_AUTH_TAG_LENGTH);
		return BitConverter.ToInt32(new byte[]
		{
			array[4],
			array[5],
			array[6],
			array[7]
		}, 0);
	}

	// Token: 0x06000249 RID: 585 RVA: 0x00011AC4 File Offset: 0x0000FCC4
	private IntPtr method_2(string string_0, string string_1, string string_2)
	{
		IntPtr zero = IntPtr.Zero;
		uint num = BCrypt.BCryptOpenAlgorithmProvider(out zero, string_0, string_1, 0U);
		if (num > 0U)
		{
			throw new CryptographicException(string.Format("BCrypt.BCryptOpenAlgorithmProvider() failed with status code:{0}", num));
		}
		byte[] bytes = Encoding.Unicode.GetBytes(string_2);
		num = BCrypt.BCryptSetProperty(zero, BCrypt.BCRYPT_CHAINING_MODE, bytes, bytes.Length, 0);
		if (num > 0U)
		{
			throw new CryptographicException(string.Format("BCrypt.BCryptSetAlgorithmProperty(BCrypt.BCRYPT_CHAINING_MODE, BCrypt.BCRYPT_CHAIN_MODE_GCM) failed with status code:{0}", num));
		}
		return zero;
	}

	// Token: 0x0600024A RID: 586 RVA: 0x00011B3C File Offset: 0x0000FD3C
	private IntPtr method_3(IntPtr intptr_0, byte[] byte_0, out IntPtr intptr_1)
	{
		byte[] value = this.oaijRxoMrH(intptr_0, BCrypt.BCRYPT_OBJECT_LENGTH);
		int num = BitConverter.ToInt32(value, 0);
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		byte[] array = this.method_4(new byte[][]
		{
			BCrypt.BCRYPT_KEY_DATA_BLOB_MAGIC,
			BitConverter.GetBytes(1),
			BitConverter.GetBytes(byte_0.Length),
			byte_0
		});
		uint num2 = BCrypt.BCryptImportKey(intptr_0, IntPtr.Zero, BCrypt.BCRYPT_KEY_DATA_BLOB, out intptr_1, intPtr, num, array, array.Length, 0U);
		if (num2 > 0U)
		{
			throw new CryptographicException(string.Format("BCrypt.BCryptImportKey() failed with status code:{0}", num2));
		}
		return intPtr;
	}

	// Token: 0x0600024B RID: 587 RVA: 0x00011BD0 File Offset: 0x0000FDD0
	private byte[] oaijRxoMrH(IntPtr intptr_0, string string_0)
	{
		int num = 0;
		uint num2 = BCrypt.BCryptGetProperty(intptr_0, string_0, null, 0, ref num, 0U);
		if (num2 > 0U)
		{
			throw new CryptographicException(string.Format("BCrypt.BCryptGetProperty() (get size) failed with status code:{0}", num2));
		}
		byte[] array = new byte[num];
		num2 = BCrypt.BCryptGetProperty(intptr_0, string_0, array, array.Length, ref num, 0U);
		if (num2 > 0U)
		{
			throw new CryptographicException(string.Format("BCrypt.BCryptGetProperty() failed with status code:{0}", num2));
		}
		return array;
	}

	// Token: 0x0600024C RID: 588 RVA: 0x00011C40 File Offset: 0x0000FE40
	public byte[] method_4(params byte[][] arrays)
	{
		int num = 0;
		foreach (byte[] array in arrays)
		{
			if (array != null)
			{
				num += array.Length;
			}
		}
		byte[] array2 = new byte[num - 1 + 1];
		int num2 = 0;
		foreach (byte[] array3 in arrays)
		{
			if (array3 != null)
			{
				Buffer.BlockCopy(array3, 0, array2, num2, array3.Length);
				num2 += array3.Length;
			}
		}
		return array2;
	}

	// Token: 0x0600024D RID: 589 RVA: 0x0000276F File Offset: 0x0000096F
	public Class32()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}
}
