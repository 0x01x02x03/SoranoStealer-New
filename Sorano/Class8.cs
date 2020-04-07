using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000020 RID: 32
internal class Class8
{
	// Token: 0x06000134 RID: 308 RVA: 0x0000A808 File Offset: 0x00008A08
	public override string ToString()
	{
		return string.Format("――――――――――――――――――――――――――――――――――――――――――――\r\nName  | {0}\r\nValue | {1}\r\n", this.Name, this.method_0());
	}

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x06000135 RID: 309 RVA: 0x00002A4D File Offset: 0x00000C4D
	// (set) Token: 0x06000136 RID: 310 RVA: 0x00002A55 File Offset: 0x00000C55
	public string Name { get; set; }

	// Token: 0x06000137 RID: 311 RVA: 0x00002A5E File Offset: 0x00000C5E
	[CompilerGenerated]
	public string method_0()
	{
		return this.string_1;
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00002A66 File Offset: 0x00000C66
	[CompilerGenerated]
	public void method_1(string string_2)
	{
		this.string_1 = string_2;
	}

	// Token: 0x06000139 RID: 313 RVA: 0x0000276F File Offset: 0x0000096F
	public Class8()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x04000060 RID: 96
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_0;

	// Token: 0x04000061 RID: 97
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_1;
}
