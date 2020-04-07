using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NoiseMe.Drags.App.Data.SQLite
{
	// Token: 0x02000012 RID: 18
	public struct SZ
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x0000291A File Offset: 0x00000B1A
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00002922 File Offset: 0x00000B22
		public long Size { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x0000292B File Offset: 0x00000B2B
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00002933 File Offset: 0x00000B33
		public long Type { get; set; }

		// Token: 0x04000030 RID: 48
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private long long_0;

		// Token: 0x04000031 RID: 49
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private long long_1;
	}
}
