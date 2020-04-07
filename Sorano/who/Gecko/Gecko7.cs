using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace who.Gecko
{
	// Token: 0x02000036 RID: 54
	public class Gecko7
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00002CB8 File Offset: 0x00000EB8
		public string EntrySalt { get; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001BA RID: 442 RVA: 0x00002CC0 File Offset: 0x00000EC0
		public string OID { get; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00002CC8 File Offset: 0x00000EC8
		public string Passwordcheck { get; }

		// Token: 0x060001BC RID: 444 RVA: 0x0000E3A4 File Offset: 0x0000C5A4
		public Gecko7(string DataToParse)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			int num = int.Parse(DataToParse.Substring(2, 2), NumberStyles.HexNumber) * 2;
			this.EntrySalt = DataToParse.Substring(6, num);
			int num2 = DataToParse.Length - (6 + num + 36);
			this.OID = DataToParse.Substring(6 + num + 36, num2);
			this.Passwordcheck = DataToParse.Substring(6 + num + 4 + num2);
		}

		// Token: 0x040000C0 RID: 192
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly string string_0;

		// Token: 0x040000C1 RID: 193
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private readonly string string_1;

		// Token: 0x040000C2 RID: 194
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly string string_2;
	}
}
