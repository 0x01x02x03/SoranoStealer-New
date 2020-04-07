using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace NoiseMe.Drags.App.Models.JSON
{
	// Token: 0x02000004 RID: 4
	public class JavaScriptReader
	{
		// Token: 0x06000003 RID: 3 RVA: 0x0000224C File Offset: 0x0000044C
		public JavaScriptReader(TextReader reader)
		{
			Class34.A1SfXVPz7w9eh();
			this.int_0 = 1;
			base..ctor();
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.textReader_0 = reader;
			this.stringBuilder_0 = new StringBuilder();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002FEC File Offset: 0x000011EC
		public object Read()
		{
			object result = this.method_0();
			this.method_3();
			if (this.method_2() >= 0)
			{
				throw this.method_8("extra characters in JSON input");
			}
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00003024 File Offset: 0x00001224
		private object method_0()
		{
			this.method_3();
			int num = this.method_1();
			if (num < 0)
			{
				throw this.method_8("Incomplete JSON input");
			}
			int num2 = num;
			if (num2 <= 102)
			{
				if (num2 == 34)
				{
					return this.method_5();
				}
				if (num2 != 91)
				{
					if (num2 == 102)
					{
						this.method_7("false");
						return false;
					}
				}
				else
				{
					this.method_2();
					List<object> list = new List<object>();
					this.method_3();
					if (this.method_1() == 93)
					{
						this.method_2();
						return list;
					}
					for (;;)
					{
						object item = this.method_0();
						list.Add(item);
						this.method_3();
						num = this.method_1();
						if (num != 44)
						{
							break;
						}
						this.method_2();
					}
					if (this.method_2() != 93)
					{
						throw this.method_8("JSON array must end with ']'");
					}
					return list.ToArray();
				}
			}
			else
			{
				if (num2 == 110)
				{
					this.method_7("null");
					return null;
				}
				if (num2 == 116)
				{
					this.method_7("true");
					return true;
				}
				if (num2 == 123)
				{
					this.method_2();
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					this.method_3();
					if (this.method_1() == 125)
					{
						this.method_2();
						return dictionary;
					}
					for (;;)
					{
						this.method_3();
						if (this.method_1() == 125)
						{
							break;
						}
						string key = this.method_5();
						this.method_3();
						this.method_6(':');
						this.method_3();
						dictionary[key] = this.method_0();
						this.method_3();
						num = this.method_2();
						if (num != 44 && num == 125)
						{
							goto IL_1C4;
						}
					}
					this.method_2();
					IL_1C4:
					int num3 = 0;
					KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[dictionary.Count];
					foreach (KeyValuePair<string, object> keyValuePair in dictionary)
					{
						array[num3++] = keyValuePair;
					}
					return array;
				}
			}
			if ((48 > num || num > 57) && num != 45)
			{
				throw this.method_8(string.Format("Unexpected character '{0}'", (char)num));
			}
			return this.method_4();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000327C File Offset: 0x0000147C
		private int method_1()
		{
			if (!this.bool_0)
			{
				this.int_2 = this.textReader_0.Read();
				this.bool_0 = true;
			}
			return this.int_2;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000032B4 File Offset: 0x000014B4
		private int method_2()
		{
			int num = this.bool_0 ? this.int_2 : this.textReader_0.Read();
			this.bool_0 = false;
			if (this.bool_1)
			{
				this.int_0++;
				this.int_1 = 0;
				this.bool_1 = false;
			}
			if (num == 10)
			{
				this.bool_1 = true;
			}
			this.int_1++;
			return num;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00003328 File Offset: 0x00001528
		private void method_3()
		{
			for (;;)
			{
				int num = this.method_1();
				if (num - 9 > 1 && num != 13 && num != 32)
				{
					break;
				}
				this.method_2();
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00003360 File Offset: 0x00001560
		private object method_4()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (this.method_1() == 45)
			{
				stringBuilder.Append((char)this.method_2());
			}
			int num = 0;
			bool flag = this.method_1() == 48;
			int num2;
			for (;;)
			{
				num2 = this.method_1();
				if (num2 < 48 || 57 < num2)
				{
					break;
				}
				stringBuilder.Append((char)this.method_2());
				if (flag && num == 1)
				{
					goto IL_27F;
				}
				num++;
			}
			if (num == 0)
			{
				throw this.method_8("Invalid JSON numeric literal; no digit found");
			}
			bool flag2 = false;
			int num3 = 0;
			if (this.method_1() == 46)
			{
				flag2 = true;
				stringBuilder.Append((char)this.method_2());
				if (this.method_1() < 0)
				{
					throw this.method_8("Invalid JSON numeric literal; extra dot");
				}
				for (;;)
				{
					num2 = this.method_1();
					if (num2 < 48 || 57 < num2)
					{
						break;
					}
					stringBuilder.Append((char)this.method_2());
					num3++;
				}
				if (num3 == 0)
				{
					throw this.method_8("Invalid JSON numeric literal; extra dot");
				}
			}
			num2 = this.method_1();
			if (num2 != 101 && num2 != 69)
			{
				if (!flag2)
				{
					int num4;
					if (int.TryParse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out num4))
					{
						return num4;
					}
					long num5;
					if (long.TryParse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out num5))
					{
						return num5;
					}
					ulong num6;
					if (ulong.TryParse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out num6))
					{
						return num6;
					}
				}
				decimal num7;
				if (decimal.TryParse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out num7) && num7 != 0m)
				{
					return num7;
				}
			}
			else
			{
				stringBuilder.Append((char)this.method_2());
				if (this.method_1() < 0)
				{
					throw new ArgumentException("Invalid JSON numeric literal; incomplete exponent");
				}
				int num8 = this.method_1();
				if (num8 != 43)
				{
					if (num8 == 45)
					{
						stringBuilder.Append((char)this.method_2());
					}
				}
				else
				{
					stringBuilder.Append((char)this.method_2());
				}
				if (this.method_1() < 0)
				{
					throw this.method_8("Invalid JSON numeric literal; incomplete exponent");
				}
				for (;;)
				{
					num2 = this.method_1();
					if (num2 < 48 || 57 < num2)
					{
						break;
					}
					stringBuilder.Append((char)this.method_2());
				}
			}
			return double.Parse(stringBuilder.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
			IL_27F:
			throw this.method_8("leading zeros are not allowed");
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000035FC File Offset: 0x000017FC
		private string method_5()
		{
			if (this.method_1() != 34)
			{
				throw this.method_8("Invalid JSON string literal format");
			}
			this.method_2();
			this.stringBuilder_0.Length = 0;
			for (;;)
			{
				int num = this.method_2();
				if (num < 0)
				{
					goto Block_22;
				}
				int num2 = num;
				if (num2 == 34)
				{
					goto IL_202;
				}
				if (num2 != 92)
				{
					this.stringBuilder_0.Append((char)num);
				}
				else
				{
					num = this.method_2();
					if (num < 0)
					{
						goto IL_1DE;
					}
					int num3 = num;
					if (num3 <= 92)
					{
						if (num3 != 34 && num3 != 47 && num3 != 92)
						{
							break;
						}
						this.stringBuilder_0.Append((char)num);
					}
					else if (num3 <= 102)
					{
						if (num3 != 98)
						{
							if (num3 != 102)
							{
								break;
							}
							this.stringBuilder_0.Append('\f');
						}
						else
						{
							this.stringBuilder_0.Append('\b');
						}
					}
					else
					{
						if (num3 != 110)
						{
							switch (num3)
							{
							case 114:
								this.stringBuilder_0.Append('\r');
								continue;
							case 116:
								this.stringBuilder_0.Append('\t');
								continue;
							case 117:
							{
								ushort num4 = 0;
								for (int i = 0; i < 4; i++)
								{
									num4 = (ushort)(num4 << 4);
									if ((num = this.method_2()) < 0)
									{
										goto IL_1F6;
									}
									if (48 <= num && num <= 57)
									{
										num4 += (ushort)(num - 48);
									}
									if (65 <= num && num <= 70)
									{
										num4 += (ushort)(num - 65 + 10);
									}
									if (97 <= num && num <= 102)
									{
										num4 += (ushort)(num - 97 + 10);
									}
								}
								this.stringBuilder_0.Append((char)num4);
								continue;
							}
							}
							break;
						}
						this.stringBuilder_0.Append('\n');
					}
				}
			}
			goto IL_1EA;
			Block_22:
			throw this.method_8("JSON string is not closed");
			IL_1DE:
			throw this.method_8("Invalid JSON string literal; incomplete escape sequence");
			IL_1EA:
			throw this.method_8("Invalid JSON string literal; unexpected escape character");
			IL_1F6:
			throw this.method_8("Incomplete unicode character escape literal");
			IL_202:
			return this.stringBuilder_0.ToString();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00003818 File Offset: 0x00001A18
		private void method_6(char char_0)
		{
			int num;
			if ((num = this.method_2()) != (int)char_0)
			{
				throw this.method_8(string.Format("Expected '{0}', got '{1}'", char_0, (char)num));
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00003854 File Offset: 0x00001A54
		private void method_7(string string_0)
		{
			for (int i = 0; i < string_0.Length; i++)
			{
				if (this.method_2() != (int)string_0[i])
				{
					throw this.method_8(string.Format("Expected '{0}', differed at {1}", string_0, i));
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000038A4 File Offset: 0x00001AA4
		private Exception method_8(string string_0)
		{
			return new ArgumentException(string.Format("{0}. At line {1}, column {2}", string_0, this.int_0, this.int_1));
		}

		// Token: 0x04000001 RID: 1
		private readonly StringBuilder stringBuilder_0;

		// Token: 0x04000002 RID: 2
		private readonly TextReader textReader_0;

		// Token: 0x04000003 RID: 3
		private int int_0;

		// Token: 0x04000004 RID: 4
		private int int_1;

		// Token: 0x04000005 RID: 5
		private int int_2;

		// Token: 0x04000006 RID: 6
		private bool bool_0;

		// Token: 0x04000007 RID: 7
		private bool bool_1;
	}
}
