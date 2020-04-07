using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000016 RID: 22
internal class Class3
{
	// Token: 0x060000EE RID: 238 RVA: 0x0000772C File Offset: 0x0000592C
	public override string ToString()
	{
		return string.Format("{0}\tFALSE\t{1}\t{2}\t{3}\t{4}\t{5}\r\n", new object[]
		{
			this.method_2(),
			this.path,
			this.method_4().ToUpper(),
			this.method_0(),
			this.name,
			this.value
		});
	}

	// Token: 0x060000EF RID: 239 RVA: 0x0000293C File Offset: 0x00000B3C
	[CompilerGenerated]
	public string method_0()
	{
		return this.string_0;
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x00002944 File Offset: 0x00000B44
	[CompilerGenerated]
	public void method_1(string string_6)
	{
		this.string_0 = string_6;
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x0000294D File Offset: 0x00000B4D
	[CompilerGenerated]
	public string method_2()
	{
		return this.string_1;
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x00002955 File Offset: 0x00000B55
	[CompilerGenerated]
	public void method_3(string string_6)
	{
		this.string_1 = string_6;
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000295E File Offset: 0x00000B5E
	// (set) Token: 0x060000F4 RID: 244 RVA: 0x00002966 File Offset: 0x00000B66
	public string name { get; set; }

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x060000F5 RID: 245 RVA: 0x0000296F File Offset: 0x00000B6F
	// (set) Token: 0x060000F6 RID: 246 RVA: 0x00002977 File Offset: 0x00000B77
	public string path { get; set; }

	// Token: 0x060000F7 RID: 247 RVA: 0x00002980 File Offset: 0x00000B80
	[CompilerGenerated]
	public string method_4()
	{
		return this.string_4;
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x00002988 File Offset: 0x00000B88
	[CompilerGenerated]
	public void method_5(string string_6)
	{
		this.string_4 = string_6;
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x060000F9 RID: 249 RVA: 0x00002991 File Offset: 0x00000B91
	// (set) Token: 0x060000FA RID: 250 RVA: 0x00002999 File Offset: 0x00000B99
	public string value { get; set; }

	// Token: 0x060000FB RID: 251 RVA: 0x0000276F File Offset: 0x0000096F
	public Class3()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x04000038 RID: 56
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_0;

	// Token: 0x04000039 RID: 57
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_1;

	// Token: 0x0400003A RID: 58
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_2;

	// Token: 0x0400003B RID: 59
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_3;

	// Token: 0x0400003C RID: 60
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string string_4;

	// Token: 0x0400003D RID: 61
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string string_5;
}
