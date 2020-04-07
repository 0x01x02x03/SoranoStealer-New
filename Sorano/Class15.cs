using System;

// Token: 0x0200002B RID: 43
internal class Class15
{
	// Token: 0x0600015C RID: 348 RVA: 0x0000C754 File Offset: 0x0000A954
	public static byte[] smethod_0(byte[] byte_0, byte[] byte_1)
	{
		int[] array = new int[256];
		int[] array2 = new int[256];
		byte[] array3 = new byte[byte_1.Length];
		int i;
		for (i = 0; i < 256; i++)
		{
			array[i] = (int)byte_0[i % byte_0.Length];
			array2[i] = i;
		}
		int num = 0;
		i = 0;
		int num2 = num;
		while (i < 256)
		{
			num2 = (num2 + array2[i] + array[i]) % 256;
			int num3 = array2[i];
			array2[i] = array2[num2];
			array2[num2] = num3;
			i++;
		}
		int num4 = 0;
		i = 0;
		num2 = 0;
		int num5 = num4;
		while (i < byte_1.Length)
		{
			num5++;
			num5 %= 256;
			num2 += array2[num5];
			num2 %= 256;
			int num3 = array2[num5];
			array2[num5] = array2[num2];
			array2[num2] = num3;
			int num6 = array2[(array2[num5] + array2[num2]) % 256];
			array3[i] = (byte)((int)byte_1[i] ^ num6);
			i++;
		}
		return array3;
	}

	// Token: 0x0600015D RID: 349 RVA: 0x0000C848 File Offset: 0x0000AA48
	public static byte[] smethod_1(byte[] byte_0, byte[] byte_1)
	{
		return Class15.smethod_0(byte_0, byte_1);
	}

	// Token: 0x0600015E RID: 350 RVA: 0x0000C860 File Offset: 0x0000AA60
	public static string smethod_2(string string_0)
	{
		string text = "";
		for (int i = 0; i < string_0.Length; i++)
		{
			text += ((char)((int)string_0[i] ^ Class15.int_0)).ToString();
		}
		Console.WriteLine("XOR Encoded string: " + text);
		return text;
	}

	// Token: 0x0600015F RID: 351 RVA: 0x0000276F File Offset: 0x0000096F
	public Class15()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00002AB0 File Offset: 0x00000CB0
	// Note: this type is marked as 'beforefieldinit'.
	static Class15()
	{
		Class34.A1SfXVPz7w9eh();
		Class15.int_0 = 666;
	}

	// Token: 0x04000095 RID: 149
	private static int int_0;
}
