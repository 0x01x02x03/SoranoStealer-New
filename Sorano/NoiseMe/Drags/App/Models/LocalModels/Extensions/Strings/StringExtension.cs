using System;
using System.Globalization;
using System.Text;
using NoiseMe.Drags.App.Models.LocalModels.Extensions.Nulls;

namespace NoiseMe.Drags.App.Models.LocalModels.Extensions.Strings
{
	// Token: 0x0200000D RID: 13
	public static class StringExtension
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x00004F74 File Offset: 0x00003174
		public static T ForceTo<T>(this object @this)
		{
			return (T)((object)Convert.ChangeType(@this, typeof(T)));
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004F98 File Offset: 0x00003198
		public static string Remove(this string input, string strToRemove)
		{
			string result;
			if (input.IsNullOrEmpty())
			{
				result = null;
			}
			else
			{
				result = input.Replace(strToRemove, "");
			}
			return result;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00004FC0 File Offset: 0x000031C0
		public static string Left(this string input, int minusRight = 1)
		{
			string result;
			if (input.IsNullOrEmpty() || input.Length <= minusRight)
			{
				result = null;
			}
			else
			{
				result = input.Substring(0, input.Length - minusRight);
			}
			return result;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00004FFC File Offset: 0x000031FC
		public static CultureInfo ToCultureInfo(this string culture, CultureInfo defaultCulture)
		{
			CultureInfo result;
			if (!culture.IsNullOrEmpty())
			{
				result = defaultCulture;
			}
			else
			{
				result = new CultureInfo(culture);
			}
			return result;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00005020 File Offset: 0x00003220
		public static string ToCamelCasing(this string value)
		{
			string result;
			if (!string.IsNullOrEmpty(value))
			{
				result = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
			}
			else
			{
				result = value;
			}
			return result;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00005060 File Offset: 0x00003260
		public static double? ToDouble(this string value, string culture = "en-US")
		{
			double? result;
			try
			{
				result = new double?(double.Parse(value, new CultureInfo(culture)));
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000050A0 File Offset: 0x000032A0
		public static bool? ToBoolean(this string value)
		{
			bool value2 = false;
			bool? result;
			if (bool.TryParse(value, out value2))
			{
				result = new bool?(value2);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000050D0 File Offset: 0x000032D0
		public static int? ToInt32(this string value)
		{
			int value2 = 0;
			int? result;
			if (int.TryParse(value, out value2))
			{
				result = new int?(value2);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00005100 File Offset: 0x00003300
		public static long? ToInt64(this string value)
		{
			long value2 = 0L;
			long? result;
			if (long.TryParse(value, out value2))
			{
				result = new long?(value2);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00005138 File Offset: 0x00003338
		public static string AddQueyString(this string url, string queryStringKey, string queryStringValue)
		{
			string text = (url.Split(new char[]
			{
				'?'
			}).Length <= 1) ? "?" : "&";
			return string.Concat(new string[]
			{
				url,
				text,
				queryStringKey,
				"=",
				queryStringValue
			});
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00005194 File Offset: 0x00003394
		public static string FormatFirstLetterUpperCase(this string value, string culture = "en-US")
		{
			return CultureInfo.GetCultureInfo(culture).TextInfo.ToTitleCase(value);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000051B4 File Offset: 0x000033B4
		public static string FillLeftWithZeros(this string value, int decimalDigits)
		{
			if (!string.IsNullOrEmpty(value))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(value);
				string[] array = value.Split(new char[]
				{
					','
				});
				for (int i = array[array.Length - 1].Length; i < decimalDigits; i++)
				{
					stringBuilder.Append("0");
				}
				value = stringBuilder.ToString();
			}
			return value;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000521C File Offset: 0x0000341C
		public static string FormatWithDecimalDigits(this string value, bool removeCurrencySymbol, bool returnZero, int? decimalDigits)
		{
			string result;
			if (value.IsNullOrEmpty())
			{
				result = value;
			}
			else
			{
				if (!value.IndexOf(",").Equals(-1))
				{
					string[] array = value.Split(new char[]
					{
						','
					});
					if (array.Length.Equals(2) && array[1].Length > 0)
					{
						value = array[0] + "," + array[1].Substring(0, (array[1].Length >= decimalDigits.Value) ? decimalDigits.Value : array[1].Length);
					}
				}
				if (decimalDigits == null)
				{
					result = value;
				}
				else
				{
					result = value.FillLeftWithZeros(decimalDigits.Value);
				}
			}
			return result;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000052DC File Offset: 0x000034DC
		public static string FormatWithoutDecimalDigits(this string value, bool removeCurrencySymbol, bool returnZero, int? decimalDigits, CultureInfo culture)
		{
			if (removeCurrencySymbol)
			{
				value = value.Remove(culture.NumberFormat.CurrencySymbol).Trim();
			}
			return value;
		}
	}
}
