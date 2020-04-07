using System;
using System.Runtime.InteropServices;

// Token: 0x02000003 RID: 3
internal static class Class1
{
	// Token: 0x06000001 RID: 1
	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Unicode)]
	internal static extern IntPtr GetModuleHandle(string string_0);

	// Token: 0x06000002 RID: 2
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool CheckRemoteDebuggerPresent(IntPtr intptr_0, [MarshalAs(UnmanagedType.Bool)] ref bool bool_0);
}
