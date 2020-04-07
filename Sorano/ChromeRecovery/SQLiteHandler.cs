using System;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ChromeRecovery
{
	// Token: 0x0200004F RID: 79
	public class SQLiteHandler
	{
		// Token: 0x06000263 RID: 611 RVA: 0x00012658 File Offset: 0x00010858
		public SQLiteHandler(string baseName)
		{
			Class34.A1SfXVPz7w9eh();
			this.byte_1 = new byte[]
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
			if (File.Exists(baseName))
			{
				FileSystem.FileOpen(1, baseName, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared, -1);
				string s = Strings.Space((int)FileSystem.LOF(1));
				FileSystem.FileGet(1, ref s, -1L, false);
				FileSystem.FileClose(new int[]
				{
					1
				});
				this.byte_0 = Encoding.Default.GetBytes(s);
				if (Encoding.Default.GetString(this.byte_0, 0, 15).CompareTo("SQLite format 3") != 0)
				{
					throw new Exception("Not a valid SQLite 3 Database File");
				}
				if (this.byte_0[52] > 0)
				{
					throw new Exception("Auto-vacuum capable database is not supported");
				}
				this.ushort_0 = (ushort)this.method_0(16, 2);
				this.ulong_0 = this.method_0(56, 4);
				if (decimal.Compare(new decimal(this.ulong_0), 0m) == 0)
				{
					this.ulong_0 = 1UL;
				}
				this.method_4(100UL);
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0001277C File Offset: 0x0001097C
		private ulong method_0(int int_0, int int_1)
		{
			ulong result;
			if (int_1 > 8 | int_1 == 0)
			{
				result = 0UL;
			}
			else
			{
				ulong num = 0UL;
				int num2 = int_1 - 1;
				for (int i = 0; i <= num2; i++)
				{
					num = (num << 8 | (ulong)this.byte_0[int_0 + i]);
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x000127D4 File Offset: 0x000109D4
		private long method_1(int int_0, int int_1)
		{
			int_1++;
			byte[] array = new byte[8];
			int num = int_1 - int_0;
			bool flag = false;
			long result;
			if (num == 0 | num > 9)
			{
				result = 0L;
			}
			else if (num == 1)
			{
				array[0] = (this.byte_0[int_0] & 127);
				result = BitConverter.ToInt64(array, 0);
			}
			else
			{
				if (num == 9)
				{
					flag = true;
				}
				int num2 = 1;
				int num3 = 7;
				int num4 = 0;
				if (flag)
				{
					array[0] = this.byte_0[int_1 - 1];
					int_1--;
					num4 = 1;
				}
				for (int i = int_1 - 1; i >= int_0; i += -1)
				{
					if (i - 1 >= int_0)
					{
						array[num4] = (byte)(((int)((byte)(this.byte_0[i] >> (num2 - 1 & 7))) & 255 >> num2) | (int)((byte)(this.byte_0[i - 1] << (num3 & 7))));
						num2++;
						num4++;
						num3--;
					}
					else if (!flag)
					{
						array[num4] = (byte)((int)((byte)(this.byte_0[i] >> (num2 - 1 & 7))) & 255 >> num2);
					}
				}
				result = BitConverter.ToInt64(array, 0);
			}
			return result;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0001290C File Offset: 0x00010B0C
		public int GetRowCount()
		{
			return this.struct12_0.Length;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00012924 File Offset: 0x00010B24
		public string[] GetTableNames()
		{
			string[] array = null;
			int num = 0;
			int num2 = this.struct11_0.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (this.struct11_0[i].string_0 == "table")
				{
					array = (string[])Utils.CopyArray(array, new string[num + 1]);
					array[num] = this.struct11_0[i].string_1;
					num++;
				}
			}
			return array;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x000129A0 File Offset: 0x00010BA0
		public string GetValue(int row_num, int field)
		{
			string result;
			if (row_num >= this.struct12_0.Length)
			{
				result = null;
			}
			else if (field >= this.struct12_0[row_num].string_0.Length)
			{
				result = null;
			}
			else
			{
				result = this.struct12_0[row_num].string_0[field];
			}
			return result;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x000129F8 File Offset: 0x00010BF8
		public string GetValue(int row_num, string field)
		{
			int num = -1;
			int num2 = this.string_0.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (this.string_0[i].ToLower().CompareTo(field.ToLower()) == 0)
				{
					num = i;
					IL_3F:
					string result;
					if (num == -1)
					{
						result = null;
					}
					else
					{
						result = this.GetValue(row_num, num);
					}
					return result;
				}
			}
			goto IL_3F;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00012A58 File Offset: 0x00010C58
		private int method_2(int int_0)
		{
			int result;
			if (int_0 > this.byte_0.Length)
			{
				result = 0;
			}
			else
			{
				int num = int_0 + 8;
				for (int i = int_0; i <= num; i++)
				{
					if (i > this.byte_0.Length - 1)
					{
						return 0;
					}
					if ((this.byte_0[i] & 128) != 128)
					{
						return i;
					}
				}
				result = int_0 + 8;
			}
			return result;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00002FA9 File Offset: 0x000011A9
		private bool method_3(long long_0)
		{
			return (long_0 & 1L) == 1L;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00012AC4 File Offset: 0x00010CC4
		private void method_4(ulong ulong_1)
		{
			if (this.byte_0[(int)ulong_1] == 13)
			{
				ushort num = Convert.ToUInt16(decimal.Subtract(new decimal(this.method_0(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 3m)), 2)), 1m));
				int num2 = 0;
				if (this.struct11_0 != null)
				{
					num2 = this.struct11_0.Length;
					this.struct11_0 = (SQLiteHandler.Struct11[])Utils.CopyArray(this.struct11_0, new SQLiteHandler.Struct11[this.struct11_0.Length + (int)num + 1]);
				}
				else
				{
					this.struct11_0 = new SQLiteHandler.Struct11[(int)(num + 1)];
				}
				int num3 = (int)num;
				for (int i = 0; i <= num3; i++)
				{
					ulong num4 = this.method_0(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(ulong_1), 8m), new decimal(i * 2))), 2);
					if (decimal.Compare(new decimal(ulong_1), 100m) != 0)
					{
						num4 += ulong_1;
					}
					int num5 = this.method_2((int)num4);
					this.method_1((int)num4, num5);
					int num6 = this.method_2(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num5), new decimal(num4))), 1m)));
					this.struct11_0[num2 + i].long_0 = this.method_1(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num5), new decimal(num4))), 1m)), num6);
					num4 = Convert.ToUInt64(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num6), new decimal(num4))), 1m));
					num5 = this.method_2((int)num4);
					num6 = num5;
					long value = this.method_1((int)num4, num5);
					long[] array = new long[5];
					int num7 = 0;
					do
					{
						num5 = num6 + 1;
						num6 = this.method_2(num5);
						array[num7] = this.method_1(num5, num6);
						if (array[num7] > 9L)
						{
							if (this.method_3(array[num7]))
							{
								array[num7] = (long)Math.Round((double)(array[num7] - 13L) / 2.0);
							}
							else
							{
								array[num7] = (long)Math.Round((double)(array[num7] - 12L) / 2.0);
							}
						}
						else
						{
							array[num7] = (long)((ulong)this.byte_1[(int)array[num7]]);
						}
						num7++;
					}
					while (num7 <= 4);
					if (decimal.Compare(new decimal(this.ulong_0), 1m) == 0)
					{
						this.struct11_0[num2 + i].string_0 = Encoding.Default.GetString(this.byte_0, Convert.ToInt32(decimal.Add(new decimal(num4), new decimal(value))), (int)array[0]);
					}
					else if (decimal.Compare(new decimal(this.ulong_0), 2m) == 0)
					{
						this.struct11_0[num2 + i].string_0 = Encoding.Unicode.GetString(this.byte_0, Convert.ToInt32(decimal.Add(new decimal(num4), new decimal(value))), (int)array[0]);
					}
					else if (decimal.Compare(new decimal(this.ulong_0), 3m) == 0)
					{
						this.struct11_0[num2 + i].string_0 = Encoding.BigEndianUnicode.GetString(this.byte_0, Convert.ToInt32(decimal.Add(new decimal(num4), new decimal(value))), (int)array[0]);
					}
					if (decimal.Compare(new decimal(this.ulong_0), 1m) == 0)
					{
						this.struct11_0[num2 + i].string_1 = Encoding.Default.GetString(this.byte_0, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0]))), (int)array[1]);
					}
					else if (decimal.Compare(new decimal(this.ulong_0), 2m) == 0)
					{
						this.struct11_0[num2 + i].string_1 = Encoding.Unicode.GetString(this.byte_0, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0]))), (int)array[1]);
					}
					else if (decimal.Compare(new decimal(this.ulong_0), 3m) == 0)
					{
						this.struct11_0[num2 + i].string_1 = Encoding.BigEndianUnicode.GetString(this.byte_0, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0]))), (int)array[1]);
					}
					this.struct11_0[num2 + i].long_1 = (long)this.method_0(Convert.ToInt32(decimal.Add(decimal.Add(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0])), new decimal(array[1])), new decimal(array[2]))), (int)array[3]);
					if (decimal.Compare(new decimal(this.ulong_0), 1m) == 0)
					{
						this.struct11_0[num2 + i].string_3 = Encoding.Default.GetString(this.byte_0, Convert.ToInt32(decimal.Add(decimal.Add(decimal.Add(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0])), new decimal(array[1])), new decimal(array[2])), new decimal(array[3]))), (int)array[4]);
					}
					else if (decimal.Compare(new decimal(this.ulong_0), 2m) == 0)
					{
						this.struct11_0[num2 + i].string_3 = Encoding.Unicode.GetString(this.byte_0, Convert.ToInt32(decimal.Add(decimal.Add(decimal.Add(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0])), new decimal(array[1])), new decimal(array[2])), new decimal(array[3]))), (int)array[4]);
					}
					else if (decimal.Compare(new decimal(this.ulong_0), 3m) == 0)
					{
						this.struct11_0[num2 + i].string_3 = Encoding.BigEndianUnicode.GetString(this.byte_0, Convert.ToInt32(decimal.Add(decimal.Add(decimal.Add(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0])), new decimal(array[1])), new decimal(array[2])), new decimal(array[3]))), (int)array[4]);
					}
				}
			}
			else if (this.byte_0[(int)ulong_1] == 5)
			{
				ushort num8 = Convert.ToUInt16(decimal.Subtract(new decimal(this.method_0(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 3m)), 2)), 1m));
				int num9 = (int)num8;
				for (int j = 0; j <= num9; j++)
				{
					ushort num10 = (ushort)this.method_0(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(ulong_1), 12m), new decimal(j * 2))), 2);
					if (decimal.Compare(new decimal(ulong_1), 100m) == 0)
					{
						this.method_4(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(this.method_0((int)num10, 4)), 1m), new decimal((int)this.ushort_0))));
					}
					else
					{
						this.method_4(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(this.method_0((int)(ulong_1 + (ulong)num10), 4)), 1m), new decimal((int)this.ushort_0))));
					}
				}
				this.method_4(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(this.method_0(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 8m)), 4)), 1m), new decimal((int)this.ushort_0))));
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00013350 File Offset: 0x00011550
		public bool ReadTable(string TableName)
		{
			int num = -1;
			int num2 = this.struct11_0.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (this.struct11_0[i].string_1.ToLower().CompareTo(TableName.ToLower()) == 0)
				{
					num = i;
					IL_48:
					bool result;
					if (num == -1)
					{
						result = false;
					}
					else
					{
						string[] array = this.struct11_0[num].string_3.Substring(this.struct11_0[num].string_3.IndexOf("(") + 1).Split(new char[]
						{
							','
						});
						int num3 = array.Length - 1;
						for (int j = 0; j <= num3; j++)
						{
							array[j] = array[j].TrimStart(Array.Empty<char>());
							int num4 = array[j].IndexOf(" ");
							if (num4 > 0)
							{
								array[j] = array[j].Substring(0, num4);
							}
							if (array[j].IndexOf("UNIQUE") == 0)
							{
								break;
							}
							this.string_0 = (string[])Utils.CopyArray(this.string_0, new string[j + 1]);
							this.string_0[j] = array[j];
						}
						result = this.method_5((ulong)((this.struct11_0[num].long_1 - 1L) * (long)((ulong)this.ushort_0)));
					}
					return result;
				}
			}
			goto IL_48;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x000134C8 File Offset: 0x000116C8
		private bool method_5(ulong ulong_1)
		{
			if (this.byte_0[(int)ulong_1] == 13)
			{
				int num = Convert.ToInt32(decimal.Subtract(new decimal(this.method_0(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 3m)), 2)), 1m));
				int num2 = 0;
				if (this.struct12_0 != null)
				{
					num2 = this.struct12_0.Length;
					this.struct12_0 = (SQLiteHandler.Struct12[])Utils.CopyArray(this.struct12_0, new SQLiteHandler.Struct12[this.struct12_0.Length + num + 1]);
				}
				else
				{
					this.struct12_0 = new SQLiteHandler.Struct12[num + 1];
				}
				int num3 = num;
				for (int i = 0; i <= num3; i++)
				{
					SQLiteHandler.Struct10[] array = null;
					ulong num4 = this.method_0(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(ulong_1), 8m), new decimal(i * 2))), 2);
					if (decimal.Compare(new decimal(ulong_1), 100m) != 0)
					{
						num4 += ulong_1;
					}
					int num5 = this.method_2((int)num4);
					this.method_1((int)num4, num5);
					int num6 = this.method_2(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num5), new decimal(num4))), 1m)));
					this.struct12_0[num2 + i].long_0 = this.method_1(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num5), new decimal(num4))), 1m)), num6);
					num4 = Convert.ToUInt64(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num6), new decimal(num4))), 1m));
					num5 = this.method_2((int)num4);
					num6 = num5;
					long num7 = this.method_1((int)num4, num5);
					long num8 = Convert.ToInt64(decimal.Add(decimal.Subtract(new decimal(num4), new decimal(num5)), 1m));
					int num9 = 0;
					while (num8 < num7)
					{
						array = (SQLiteHandler.Struct10[])Utils.CopyArray(array, new SQLiteHandler.Struct10[num9 + 1]);
						num5 = num6 + 1;
						num6 = this.method_2(num5);
						array[num9].long_1 = this.method_1(num5, num6);
						if (array[num9].long_1 > 9L)
						{
							if (this.method_3(array[num9].long_1))
							{
								array[num9].long_0 = (long)Math.Round((double)(array[num9].long_1 - 13L) / 2.0);
							}
							else
							{
								array[num9].long_0 = (long)Math.Round((double)(array[num9].long_1 - 12L) / 2.0);
							}
						}
						else
						{
							array[num9].long_0 = (long)((ulong)this.byte_1[(int)array[num9].long_1]);
						}
						num8 = num8 + (long)(num6 - num5) + 1L;
						num9++;
					}
					this.struct12_0[num2 + i].string_0 = new string[array.Length - 1 + 1];
					int num10 = 0;
					int num11 = array.Length - 1;
					for (int j = 0; j <= num11; j++)
					{
						if (array[j].long_1 > 9L)
						{
							if (!this.method_3(array[j].long_1))
							{
								if (decimal.Compare(new decimal(this.ulong_0), 1m) == 0)
								{
									this.struct12_0[num2 + i].string_0[j] = Encoding.Default.GetString(this.byte_0, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].long_0);
								}
								else if (decimal.Compare(new decimal(this.ulong_0), 2m) == 0)
								{
									this.struct12_0[num2 + i].string_0[j] = Encoding.Unicode.GetString(this.byte_0, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].long_0);
								}
								else if (decimal.Compare(new decimal(this.ulong_0), 3m) == 0)
								{
									this.struct12_0[num2 + i].string_0[j] = Encoding.BigEndianUnicode.GetString(this.byte_0, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].long_0);
								}
							}
							else
							{
								this.struct12_0[num2 + i].string_0[j] = Encoding.Default.GetString(this.byte_0, Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].long_0);
							}
						}
						else
						{
							this.struct12_0[num2 + i].string_0[j] = Conversions.ToString(this.method_0(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].long_0));
						}
						num10 += (int)array[j].long_0;
					}
				}
			}
			else if (this.byte_0[(int)ulong_1] == 5)
			{
				ushort num12 = Convert.ToUInt16(decimal.Subtract(new decimal(this.method_0(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 3m)), 2)), 1m));
				int num13 = (int)num12;
				for (int k = 0; k <= num13; k++)
				{
					ushort num14 = (ushort)this.method_0(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(ulong_1), 12m), new decimal(k * 2))), 2);
					this.method_5(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(this.method_0((int)(ulong_1 + (ulong)num14), 4)), 1m), new decimal((int)this.ushort_0))));
				}
				this.method_5(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(this.method_0(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 8m)), 4)), 1m), new decimal((int)this.ushort_0))));
			}
			return true;
		}

		// Token: 0x04000121 RID: 289
		private byte[] byte_0;

		// Token: 0x04000122 RID: 290
		private ulong ulong_0;

		// Token: 0x04000123 RID: 291
		private string[] string_0;

		// Token: 0x04000124 RID: 292
		private SQLiteHandler.Struct11[] struct11_0;

		// Token: 0x04000125 RID: 293
		private ushort ushort_0;

		// Token: 0x04000126 RID: 294
		private byte[] byte_1;

		// Token: 0x04000127 RID: 295
		private SQLiteHandler.Struct12[] struct12_0;

		// Token: 0x02000050 RID: 80
		private struct Struct10
		{
			// Token: 0x04000128 RID: 296
			public long long_0;

			// Token: 0x04000129 RID: 297
			public long long_1;
		}

		// Token: 0x02000051 RID: 81
		private struct Struct11
		{
			// Token: 0x0400012A RID: 298
			public long long_0;

			// Token: 0x0400012B RID: 299
			public string string_0;

			// Token: 0x0400012C RID: 300
			public string string_1;

			// Token: 0x0400012D RID: 301
			public string string_2;

			// Token: 0x0400012E RID: 302
			public long long_1;

			// Token: 0x0400012F RID: 303
			public string string_3;
		}

		// Token: 0x02000052 RID: 82
		private struct Struct12
		{
			// Token: 0x04000130 RID: 304
			public long long_0;

			// Token: 0x04000131 RID: 305
			public string[] string_0;
		}
	}
}
