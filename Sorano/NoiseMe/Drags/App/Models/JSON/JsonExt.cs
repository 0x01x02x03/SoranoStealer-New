using System;
using System.IO;

namespace NoiseMe.Drags.App.Models.JSON
{
	// Token: 0x02000006 RID: 6
	public static class JsonExt
	{
		// Token: 0x06000022 RID: 34 RVA: 0x000039F4 File Offset: 0x00001BF4
		public static JsonValue FromJSON(this string json)
		{
			return JsonValue.Load(new StringReader(json));
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003A10 File Offset: 0x00001C10
		public static string ToJSON<T>(this T instance)
		{
			return JsonValue.ToJsonValue<T>(instance);
		}
	}
}
