using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x02000029 RID: 41
internal class Class13
{
	// Token: 0x06000153 RID: 339 RVA: 0x0000C4A8 File Offset: 0x0000A6A8
	public static void smethod_0()
	{
		string[] array = Class13.string_0;
		for (int i = 0; i < array.Length; i++)
		{
			Class13.Class14 @class = new Class13.Class14();
			@class.string_0 = array[i];
			if (Process.GetProcesses().Any(new Func<Process, bool>(@class.method_0)))
			{
				Environment.Exit(0);
			}
		}
	}

	// Token: 0x06000154 RID: 340 RVA: 0x0000C4F8 File Offset: 0x0000A6F8
	public static void smethod_1()
	{
		using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
		{
			using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
				{
					string text = managementBaseObject["Manufacturer"].ToString().ToLower();
					if ((text == "microsoft corporation" && managementBaseObject["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) || text.Contains("vmware") || managementBaseObject["Model"].ToString() == "VirtualBox")
					{
						Environment.Exit(0);
					}
				}
			}
		}
	}

	// Token: 0x06000155 RID: 341 RVA: 0x0000C5FC File Offset: 0x0000A7FC
	public static void smethod_2()
	{
		if (Class13.GetModuleHandle("SbieDll.dll").ToInt32() != 0)
		{
			Environment.Exit(0);
		}
	}

	// Token: 0x06000156 RID: 342
	[DllImport("kernel32.dll")]
	public static extern IntPtr GetModuleHandle(string string_1);

	// Token: 0x06000157 RID: 343
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern bool CheckRemoteDebuggerPresent(IntPtr intptr_0, ref bool bool_0);

	// Token: 0x06000158 RID: 344 RVA: 0x0000276F File Offset: 0x0000096F
	public Class13()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x06000159 RID: 345 RVA: 0x0000C628 File Offset: 0x0000A828
	// Note: this type is marked as 'beforefieldinit'.
	static Class13()
	{
		Class34.A1SfXVPz7w9eh();
		Class13.string_0 = new string[]
		{
			"HttpAnalyzer",
			"Dumper",
			"Reflector",
			"Wireshark",
			"WPE",
			"ProcessExplorer",
			"IDA",
			"HTTP Debugger Pro",
			"The Wireshark Network Analyzer",
			"WinDbg",
			"Colasoft Capsa",
			"smsniff",
			"Olly",
			"OllyDbg",
			"WPE PRO",
			"Microsoft Network Monitor",
			"Fiddler",
			"SmartSniff",
			"Immunity Debugger",
			"Process Explorer",
			"PE Tools",
			"AQtime",
			"DS-5 Debug",
			"Dbxtool",
			"Topaz",
			"FusionDebug",
			"NetBeans",
			"Rational Purify",
			".NET Reflector",
			"Cheat Engine",
			"Sigma Engine"
		};
	}

	// Token: 0x04000093 RID: 147
	public static string[] string_0;

	// Token: 0x0200002A RID: 42
	[CompilerGenerated]
	private sealed class Class14
	{
		// Token: 0x0600015A RID: 346 RVA: 0x0000276F File Offset: 0x0000096F
		public Class14()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00002A98 File Offset: 0x00000C98
		internal bool method_0(Process process_0)
		{
			return process_0.ProcessName.ToLower().Contains(this.string_0);
		}

		// Token: 0x04000094 RID: 148
		public string string_0;
	}
}
