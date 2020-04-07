using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200003A RID: 58
internal class Class21
{
	// Token: 0x060001CF RID: 463 RVA: 0x00002D45 File Offset: 0x00000F45
	[CompilerGenerated]
	public string method_0()
	{
		return this.string_0;
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x00002D4D File Offset: 0x00000F4D
	[CompilerGenerated]
	public void method_1(string string_6)
	{
		this.string_0 = string_6;
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x060001D1 RID: 465 RVA: 0x00002D56 File Offset: 0x00000F56
	// (set) Token: 0x060001D2 RID: 466 RVA: 0x00002D5E File Offset: 0x00000F5E
	public string name { get; set; }

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x060001D3 RID: 467 RVA: 0x00002D67 File Offset: 0x00000F67
	// (set) Token: 0x060001D4 RID: 468 RVA: 0x00002D6F File Offset: 0x00000F6F
	public string value { get; set; }

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x060001D5 RID: 469 RVA: 0x00002D78 File Offset: 0x00000F78
	// (set) Token: 0x060001D6 RID: 470 RVA: 0x00002D80 File Offset: 0x00000F80
	public string path { get; set; }

	// Token: 0x060001D7 RID: 471 RVA: 0x00002D89 File Offset: 0x00000F89
	[CompilerGenerated]
	public string method_2()
	{
		return this.string_4;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00002D91 File Offset: 0x00000F91
	[CompilerGenerated]
	public void method_3(string string_6)
	{
		this.string_4 = string_6;
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x00002D9A File Offset: 0x00000F9A
	[CompilerGenerated]
	public string method_4()
	{
		return this.string_5;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x00002DA2 File Offset: 0x00000FA2
	[CompilerGenerated]
	public void method_5(string string_6)
	{
		this.string_5 = string_6;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0000EBEC File Offset: 0x0000CDEC
	public override string ToString()
	{
		return string.Format("{0}\tFALSE\t{1}\t{2}\t{3}\t{4}\t{5}\r\n", new object[]
		{
			this.method_0(),
			this.path,
			this.method_4().ToUpper(),
			this.method_2(),
			this.name,
			this.value
		});
	}

	// Token: 0x060001DC RID: 476 RVA: 0x0000276F File Offset: 0x0000096F
	public Class21()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x040000CB RID: 203
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_0;

	// Token: 0x040000CC RID: 204
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_1;

	// Token: 0x040000CD RID: 205
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_2;

	// Token: 0x040000CE RID: 206
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_3;

	// Token: 0x040000CF RID: 207
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_4;

	// Token: 0x040000D0 RID: 208
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_5;
}
