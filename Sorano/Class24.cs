using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200003D RID: 61
internal class Class24
{
	// Token: 0x060001EF RID: 495 RVA: 0x00002DBC File Offset: 0x00000FBC
	[CompilerGenerated]
	public string method_0()
	{
		return this.string_0;
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x00002DC4 File Offset: 0x00000FC4
	[CompilerGenerated]
	public void method_1(string string_2)
	{
		this.string_0 = string_2;
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00002DCD File Offset: 0x00000FCD
	[CompilerGenerated]
	public string method_2()
	{
		return this.string_1;
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00002DD5 File Offset: 0x00000FD5
	[CompilerGenerated]
	public void method_3(string string_2)
	{
		this.string_1 = string_2;
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x0000FD88 File Offset: 0x0000DF88
	public override string ToString()
	{
		return string.Format("{0} | {1}\r\n \r\n", this.method_2(), this.method_0());
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x0000276F File Offset: 0x0000096F
	public Class24()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x040000D3 RID: 211
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_0;

	// Token: 0x040000D4 RID: 212
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_1;
}
