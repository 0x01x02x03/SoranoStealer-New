using System;

namespace NoiseMe.Drags.App.Models.LocalModels.Extensions.Nulls
{
	// Token: 0x0200000E RID: 14
	public static class IsNullExtension
	{
		// Token: 0x060000B0 RID: 176 RVA: 0x0000280A File Offset: 0x00000A0A
		public static bool IsNotNull<T>(this T data)
		{
			return data != null;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00005308 File Offset: 0x00003508
		public static string IsNull(this string value, string defaultValue)
		{
			string result;
			if (!string.IsNullOrEmpty(value))
			{
				result = value;
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002815 File Offset: 0x00000A15
		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00005328 File Offset: 0x00003528
		public static bool IsNull(this bool? value, bool def)
		{
			bool result;
			if (value != null)
			{
				result = value.Value;
			}
			else
			{
				result = def;
			}
			return result;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000534C File Offset: 0x0000354C
		public static T IsNull<T>(this T value) where T : class
		{
			T result;
			if (value == null)
			{
				result = Activator.CreateInstance<T>();
			}
			else
			{
				result = value;
			}
			return result;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00005370 File Offset: 0x00003570
		public static T IsNull<T>(this T value, T def) where T : class
		{
			T result;
			if (value != null)
			{
				result = value;
			}
			else if (def == null)
			{
				result = Activator.CreateInstance<T>();
			}
			else
			{
				result = def;
			}
			return result;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000053A4 File Offset: 0x000035A4
		public static int IsNull(this int? value, int def)
		{
			int result;
			if (value != null)
			{
				result = value.Value;
			}
			else
			{
				result = def;
			}
			return result;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000053C8 File Offset: 0x000035C8
		public static long IsNull(this long? value, long def)
		{
			long result;
			if (value != null)
			{
				result = value.Value;
			}
			else
			{
				result = def;
			}
			return result;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000053EC File Offset: 0x000035EC
		public static double IsNull(this double? value, double def)
		{
			double result;
			if (value != null)
			{
				result = value.Value;
			}
			else
			{
				result = def;
			}
			return result;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00005410 File Offset: 0x00003610
		public static DateTime IsNull(this DateTime? value, DateTime def)
		{
			DateTime result;
			if (value != null)
			{
				result = value.Value;
			}
			else
			{
				result = def;
			}
			return result;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00005434 File Offset: 0x00003634
		public static Guid IsNull(this Guid? value, Guid def)
		{
			Guid result;
			if (value != null)
			{
				result = value.Value;
			}
			else
			{
				result = def;
			}
			return result;
		}
	}
}
