using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NoiseMe.Drags.App.Data.SQLite
{
	// Token: 0x02000011 RID: 17
	public struct ROW
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000DD RID: 221 RVA: 0x000028F8 File Offset: 0x00000AF8
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00002900 File Offset: 0x00000B00
		public long ID { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00002909 File Offset: 0x00000B09
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00002911 File Offset: 0x00000B11
		public string[] RowData { get; set; }

		// Token: 0x0400002E RID: 46
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private long long_0;

		// Token: 0x0400002F RID: 47
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string[] string_0;
	}
}
