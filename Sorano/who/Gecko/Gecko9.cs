using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace who.Gecko
{
	// Token: 0x02000038 RID: 56
	public class Gecko9
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00002D2C File Offset: 0x00000F2C
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x00002D34 File Offset: 0x00000F34
		public string Version { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00002D3D File Offset: 0x00000F3D
		public List<KeyValuePair<string, string>> Keys { get; }

		// Token: 0x060001C9 RID: 457 RVA: 0x0000E674 File Offset: 0x0000C874
		public Gecko9(string FileName)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			List<byte> list = new List<byte>();
			this.Keys = new List<KeyValuePair<string, string>>();
			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(FileName)))
			{
				int i = 0;
				int num = (int)binaryReader.BaseStream.Length;
				while (i < num)
				{
					list.Add(binaryReader.ReadByte());
					i++;
				}
			}
			string value = BitConverter.ToString(this.method_0(list.ToArray(), 0, 4, false)).Replace("-", "");
			string text = BitConverter.ToString(this.method_0(list.ToArray(), 4, 4, false)).Replace("-", "");
			int num2 = BitConverter.ToInt32(this.method_0(list.ToArray(), 12, 4, true), 0);
			if (!string.IsNullOrEmpty(value))
			{
				this.Version = "Berkelet DB";
				if (text.Equals("00000002"))
				{
					this.Version += " 1.85 (Hash, version 2, native byte-order)";
				}
				int num3 = int.Parse(BitConverter.ToString(this.method_0(list.ToArray(), 56, 4, false)).Replace("-", ""));
				int num4 = 1;
				while (this.Keys.Count < num3)
				{
					string[] array = new string[(num3 - this.Keys.Count) * 2];
					for (int j = 0; j < (num3 - this.Keys.Count) * 2; j++)
					{
						array[j] = BitConverter.ToString(this.method_0(list.ToArray(), num2 * num4 + 2 + j * 2, 2, true)).Replace("-", "");
					}
					Array.Sort<string>(array);
					for (int k = 0; k < array.Length; k += 2)
					{
						int num5 = Convert.ToInt32(array[k], 16) + num2 * num4;
						int num6 = Convert.ToInt32(array[k + 1], 16) + num2 * num4;
						int num7 = (k + 2 >= array.Length) ? (num2 + num2 * num4) : (Convert.ToInt32(array[k + 2], 16) + num2 * num4);
						string @string = Encoding.ASCII.GetString(this.method_0(list.ToArray(), num6, num7 - num6, false));
						string value2 = BitConverter.ToString(this.method_0(list.ToArray(), num5, num6 - num5, false));
						if (!string.IsNullOrEmpty(@string))
						{
							this.Keys.Add(new KeyValuePair<string, string>(@string, value2));
						}
					}
					num4++;
				}
			}
			else
			{
				this.Version = "Unknow database format";
			}
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000E924 File Offset: 0x0000CB24
		private byte[] method_0(byte[] byte_0, int int_0, int int_1, bool bool_0)
		{
			byte[] array = new byte[int_1];
			int num = 0;
			for (int i = int_0; i < int_0 + int_1; i++)
			{
				array[num] = byte_0[i];
				num++;
			}
			if (bool_0)
			{
				Array.Reverse(array);
			}
			return array;
		}

		// Token: 0x040000C8 RID: 200
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040000C9 RID: 201
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private readonly List<KeyValuePair<string, string>> list_0;
	}
}
