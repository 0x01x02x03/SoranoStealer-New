using System;
using System.IO;
using System.Text;

// Token: 0x0200001C RID: 28
internal class Class7
{
	// Token: 0x0600012A RID: 298 RVA: 0x00009900 File Offset: 0x00007B00
	public Class7(string string_1)
	{
		Class34.A1SfXVPz7w9eh();
		this.byte_0 = new byte[]
		{
			0,
			1,
			2,
			3,
			4,
			6,
			8,
			8,
			0,
			0
		};
		base..ctor();
		this.byte_1 = File.ReadAllBytes(string_1);
		this.ulong_1 = this.method_5(16, 2);
		this.ulong_0 = this.method_5(56, 4);
		this.method_3(100L);
	}

	// Token: 0x0600012B RID: 299 RVA: 0x0000996C File Offset: 0x00007B6C
	public string method_0(int int_0, int int_1)
	{
		string result;
		try
		{
			if (int_0 >= this.struct3_0.Length)
			{
				result = null;
			}
			else
			{
				result = ((int_1 >= this.struct3_0[int_0].string_0.Length) ? null : this.struct3_0[int_0].string_0[int_1]);
			}
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600012C RID: 300 RVA: 0x000099D4 File Offset: 0x00007BD4
	public int method_1()
	{
		return this.struct3_0.Length;
	}

	// Token: 0x0600012D RID: 301 RVA: 0x000099EC File Offset: 0x00007BEC
	private bool method_2(ulong ulong_2)
	{
		bool result;
		try
		{
			if (this.byte_1[(int)(checked((IntPtr)ulong_2))] == 13)
			{
				ushort num = (ushort)(this.method_5((int)ulong_2 + 3, 2) - 1UL);
				int num2 = 0;
				if (this.struct3_0 != null)
				{
					num2 = this.struct3_0.Length;
					Array.Resize<Class7.Struct3>(ref this.struct3_0, this.struct3_0.Length + (int)num + 1);
				}
				else
				{
					this.struct3_0 = new Class7.Struct3[(int)(num + 1)];
				}
				for (ushort num3 = 0; num3 <= num; num3 += 1)
				{
					ulong num4 = this.method_5((int)ulong_2 + 8 + (int)(num3 * 2), 2);
					if (ulong_2 != 100UL)
					{
						num4 += ulong_2;
					}
					int num5 = this.method_6((int)num4);
					this.method_7((int)num4, num5);
					int num6 = this.method_6((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL));
					this.method_7((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL), num6);
					ulong num7 = num4 + (ulong)((long)num6 - (long)num4 + 1L);
					int num8 = this.method_6((int)num7);
					int num9 = num8;
					long num10 = this.method_7((int)num7, num8);
					Class7.Struct2[] array = null;
					long num11 = (long)(num7 - (ulong)((long)num8) + 1UL);
					int num12 = 0;
					while (num11 < num10)
					{
						Array.Resize<Class7.Struct2>(ref array, num12 + 1);
						int num13 = num9 + 1;
						num9 = this.method_6(num13);
						array[num12].long_1 = this.method_7(num13, num9);
						array[num12].long_0 = (long)((array[num12].long_1 <= 9L) ? ((ulong)this.byte_0[(int)(checked((IntPtr)array[num12].long_1))]) : ((ulong)((!Class7.smethod_0(array[num12].long_1)) ? ((array[num12].long_1 - 12L) / 2L) : ((array[num12].long_1 - 13L) / 2L))));
						num11 = num11 + (long)(num9 - num13) + 1L;
						num12++;
					}
					if (array != null)
					{
						this.struct3_0[num2 + (int)num3].string_0 = new string[array.Length];
						int num14 = 0;
						for (int i = 0; i <= array.Length - 1; i++)
						{
							if (array[i].long_1 > 9L)
							{
								if (!Class7.smethod_0(array[i].long_1))
								{
									if (this.ulong_0 == 1UL)
									{
										this.struct3_0[num2 + (int)num3].string_0[i] = Encoding.Default.GetString(this.byte_1, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].long_0);
									}
									else if (this.ulong_0 == 2UL)
									{
										this.struct3_0[num2 + (int)num3].string_0[i] = Encoding.Unicode.GetString(this.byte_1, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].long_0);
									}
									else if (this.ulong_0 == 3UL)
									{
										this.struct3_0[num2 + (int)num3].string_0[i] = Encoding.BigEndianUnicode.GetString(this.byte_1, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].long_0);
									}
								}
								else
								{
									this.struct3_0[num2 + (int)num3].string_0[i] = Encoding.Default.GetString(this.byte_1, (int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].long_0);
								}
							}
							else
							{
								this.struct3_0[num2 + (int)num3].string_0[i] = Convert.ToString(this.method_5((int)(num7 + (ulong)num10 + (ulong)((long)num14)), (int)array[i].long_0));
							}
							num14 += (int)array[i].long_0;
						}
					}
				}
			}
			else if (this.byte_1[(int)(checked((IntPtr)ulong_2))] == 5)
			{
				ushort num15 = (ushort)(this.method_5((int)(ulong_2 + 3UL), 2) - 1UL);
				for (ushort num16 = 0; num16 <= num15; num16 += 1)
				{
					ushort num17 = (ushort)this.method_5((int)ulong_2 + 12 + (int)(num16 * 2), 2);
					this.method_2((this.method_5((int)(ulong_2 + (ulong)num17), 4) - 1UL) * this.ulong_1);
				}
				this.method_2((this.method_5((int)(ulong_2 + 8UL), 4) - 1UL) * this.ulong_1);
			}
			result = true;
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600012E RID: 302 RVA: 0x00009F18 File Offset: 0x00008118
	private void method_3(long long_0)
	{
		try
		{
			byte b = this.byte_1[(int)(checked((IntPtr)long_0))];
			if (b != 5)
			{
				if (b == 13)
				{
					ulong num = this.method_5((int)long_0 + 3, 2) - 1UL;
					int num2 = 0;
					if (this.struct4_0 != null)
					{
						num2 = this.struct4_0.Length;
						Array.Resize<Class7.Struct4>(ref this.struct4_0, this.struct4_0.Length + (int)num + 1);
					}
					else
					{
						this.struct4_0 = new Class7.Struct4[num + 1UL];
					}
					for (ulong num3 = 0UL; num3 <= num; num3 += 1UL)
					{
						ulong num4 = this.method_5((int)long_0 + 8 + (int)num3 * 2, 2);
						if (long_0 != 100L)
						{
							num4 += (ulong)long_0;
						}
						int num5 = this.method_6((int)num4);
						this.method_7((int)num4, num5);
						int num6 = this.method_6((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL));
						this.method_7((int)(num4 + (ulong)((long)num5 - (long)num4) + 1UL), num6);
						ulong num7 = num4 + (ulong)((long)num6 - (long)num4 + 1L);
						int num8 = this.method_6((int)num7);
						int num9 = num8;
						long num10 = this.method_7((int)num7, num8);
						long[] array = new long[5];
						for (int i = 0; i <= 4; i++)
						{
							int int_ = num9 + 1;
							num9 = this.method_6(int_);
							array[i] = this.method_7(int_, num9);
							array[i] = (long)((array[i] <= 9L) ? ((ulong)this.byte_0[(int)(checked((IntPtr)array[i]))]) : ((ulong)((!Class7.smethod_0(array[i])) ? ((array[i] - 12L) / 2L) : ((array[i] - 13L) / 2L))));
						}
						if (this.ulong_0 == 1UL || this.ulong_0 == 2UL)
						{
						}
						if (this.ulong_0 == 1UL)
						{
							this.struct4_0[num2 + (int)num3].string_0 = Encoding.Default.GetString(this.byte_1, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
						}
						else if (this.ulong_0 == 2UL)
						{
							this.struct4_0[num2 + (int)num3].string_0 = Encoding.Unicode.GetString(this.byte_1, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
						}
						else if (this.ulong_0 == 3UL)
						{
							this.struct4_0[num2 + (int)num3].string_0 = Encoding.BigEndianUnicode.GetString(this.byte_1, (int)(num7 + (ulong)num10 + (ulong)array[0]), (int)array[1]);
						}
						this.struct4_0[num2 + (int)num3].long_0 = (long)this.method_5((int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2]), (int)array[3]);
						if (this.ulong_0 == 1UL)
						{
							this.struct4_0[num2 + (int)num3].string_1 = Encoding.Default.GetString(this.byte_1, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
						}
						else if (this.ulong_0 == 2UL)
						{
							this.struct4_0[num2 + (int)num3].string_1 = Encoding.Unicode.GetString(this.byte_1, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
						}
						else if (this.ulong_0 == 3UL)
						{
							this.struct4_0[num2 + (int)num3].string_1 = Encoding.BigEndianUnicode.GetString(this.byte_1, (int)(num7 + (ulong)num10 + (ulong)array[0] + (ulong)array[1] + (ulong)array[2] + (ulong)array[3]), (int)array[4]);
						}
					}
				}
			}
			else
			{
				ushort num11 = (ushort)(this.method_5((int)long_0 + 3, 2) - 1UL);
				for (int j = 0; j <= (int)num11; j++)
				{
					ushort num12 = (ushort)this.method_5((int)long_0 + 12 + j * 2, 2);
					if (long_0 == 100L)
					{
						this.method_3((long)((this.method_5((int)num12, 4) - 1UL) * this.ulong_1));
					}
					else
					{
						this.method_3((long)((this.method_5((int)(long_0 + (long)((ulong)num12)), 4) - 1UL) * this.ulong_1));
					}
				}
				this.method_3((long)((this.method_5((int)long_0 + 8, 4) - 1UL) * this.ulong_1));
			}
		}
		catch
		{
		}
	}

	// Token: 0x0600012F RID: 303 RVA: 0x0000A448 File Offset: 0x00008648
	public bool method_4(string string_1)
	{
		bool result;
		try
		{
			int num = -1;
			int i = 0;
			while (i <= this.struct4_0.Length)
			{
				if (string.Compare(this.struct4_0[i].string_0.ToLower(), string_1.ToLower(), StringComparison.Ordinal) != 0)
				{
					i++;
				}
				else
				{
					num = i;
					IL_46:
					if (num == -1)
					{
						return false;
					}
					string[] array = this.struct4_0[num].string_1.Substring(this.struct4_0[num].string_1.IndexOf("(", StringComparison.Ordinal) + 1).Split(new char[]
					{
						','
					});
					for (int j = 0; j <= array.Length - 1; j++)
					{
						array[j] = array[j].TrimStart(Array.Empty<char>());
						int num2 = array[j].IndexOf(' ');
						if (num2 > 0)
						{
							array[j] = array[j].Substring(0, num2);
						}
						if (array[j].IndexOf("UNIQUE", StringComparison.Ordinal) != 0)
						{
							Array.Resize<string>(ref this.string_0, j + 1);
							this.string_0[j] = array[j];
						}
					}
					return this.method_2((ulong)((this.struct4_0[num].long_0 - 1L) * (long)this.ulong_1));
				}
			}
			goto IL_46;
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000130 RID: 304 RVA: 0x0000A5BC File Offset: 0x000087BC
	private ulong method_5(int int_0, int int_1)
	{
		ulong result;
		try
		{
			if (int_1 > 8 | int_1 == 0)
			{
				result = 0UL;
			}
			else
			{
				ulong num = 0UL;
				for (int i = 0; i <= int_1 - 1; i++)
				{
					num = (num << 8 | (ulong)this.byte_1[int_0 + i]);
				}
				result = num;
			}
		}
		catch
		{
			result = 0UL;
		}
		return result;
	}

	// Token: 0x06000131 RID: 305 RVA: 0x0000A630 File Offset: 0x00008830
	private int method_6(int int_0)
	{
		int result;
		try
		{
			if (int_0 > this.byte_1.Length)
			{
				result = 0;
			}
			else
			{
				for (int i = int_0; i <= int_0 + 8; i++)
				{
					if (i > this.byte_1.Length - 1)
					{
						return 0;
					}
					if ((this.byte_1[i] & 128) != 128)
					{
						return i;
					}
				}
				result = int_0 + 8;
			}
		}
		catch
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x06000132 RID: 306 RVA: 0x0000A6B0 File Offset: 0x000088B0
	private long method_7(int int_0, int int_1)
	{
		long result;
		try
		{
			int_1++;
			byte[] array = new byte[8];
			int num = int_1 - int_0;
			bool flag = false;
			if (num == 0 | num > 9)
			{
				result = 0L;
			}
			else
			{
				int num2 = num;
				if (num2 != 1)
				{
					if (num2 == 9)
					{
						flag = true;
					}
					int num3 = 1;
					int num4 = 7;
					int num5 = 0;
					if (flag)
					{
						array[0] = this.byte_1[int_1 - 1];
						int_1--;
						num5 = 1;
					}
					for (int i = int_1 - 1; i >= int_0; i += -1)
					{
						if (i - 1 >= int_0)
						{
							array[num5] = (byte)((this.byte_1[i] >> num3 - 1 & 255 >> num3) | (int)this.byte_1[i - 1] << num4);
							num3++;
							num5++;
							num4--;
						}
						else if (!flag)
						{
							array[num5] = (byte)(this.byte_1[i] >> num3 - 1 & 255 >> num3);
						}
					}
					result = BitConverter.ToInt64(array, 0);
				}
				else
				{
					array[0] = (this.byte_1[int_0] & 127);
					result = BitConverter.ToInt64(array, 0);
				}
			}
		}
		catch
		{
			result = 0L;
		}
		return result;
	}

	// Token: 0x06000133 RID: 307 RVA: 0x0000287A File Offset: 0x00000A7A
	private static bool smethod_0(long long_0)
	{
		return (long_0 & 1L) == 1L;
	}

	// Token: 0x04000053 RID: 83
	private readonly byte[] byte_0;

	// Token: 0x04000054 RID: 84
	private readonly ulong ulong_0;

	// Token: 0x04000055 RID: 85
	private readonly byte[] byte_1;

	// Token: 0x04000056 RID: 86
	private readonly ulong ulong_1;

	// Token: 0x04000057 RID: 87
	private string[] string_0;

	// Token: 0x04000058 RID: 88
	private Class7.Struct4[] struct4_0;

	// Token: 0x04000059 RID: 89
	private Class7.Struct3[] struct3_0;

	// Token: 0x0200001D RID: 29
	private struct Struct2
	{
		// Token: 0x0400005A RID: 90
		public long long_0;

		// Token: 0x0400005B RID: 91
		public long long_1;
	}

	// Token: 0x0200001E RID: 30
	private struct Struct3
	{
		// Token: 0x0400005C RID: 92
		public string[] string_0;
	}

	// Token: 0x0200001F RID: 31
	private struct Struct4
	{
		// Token: 0x0400005D RID: 93
		public string string_0;

		// Token: 0x0400005E RID: 94
		public long long_0;

		// Token: 0x0400005F RID: 95
		public string string_1;
	}
}
