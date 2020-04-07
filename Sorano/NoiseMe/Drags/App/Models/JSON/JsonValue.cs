using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using NoiseMe.Drags.App.Models.LocalModels.Extensions.Nulls;

namespace NoiseMe.Drags.App.Models.JSON
{
	// Token: 0x0200000A RID: 10
	public abstract class JsonValue : IEnumerable
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000026E5 File Offset: 0x000008E5
		public virtual int Count
		{
			get
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000055 RID: 85
		public abstract JsonType JsonType { get; }

		// Token: 0x1700000F RID: 15
		public virtual JsonValue this[int index]
		{
			get
			{
				throw new InvalidOperationException();
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x17000010 RID: 16
		public virtual JsonValue this[string key]
		{
			get
			{
				throw new InvalidOperationException();
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003E24 File Offset: 0x00002024
		public static JsonValue Load(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			return JsonValue.Load(new StreamReader(stream, true));
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003E50 File Offset: 0x00002050
		public static JsonValue Load(TextReader textReader)
		{
			if (textReader == null)
			{
				throw new ArgumentNullException("textReader");
			}
			return JsonValue.ToJsonValue<object>(new JavaScriptReader(textReader).Read());
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000026EC File Offset: 0x000008EC
		private static IEnumerable<KeyValuePair<string, JsonValue>> smethod_0(IEnumerable<KeyValuePair<string, object>> ienumerable_0)
		{
			JsonValue.<ToJsonPairEnumerable>d__12 <ToJsonPairEnumerable>d__ = new JsonValue.<ToJsonPairEnumerable>d__12(-2);
			<ToJsonPairEnumerable>d__.<>3__kvpc = ienumerable_0;
			return <ToJsonPairEnumerable>d__;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000026FC File Offset: 0x000008FC
		private static IEnumerable<JsonValue> smethod_1(IEnumerable ienumerable_0)
		{
			JsonValue.<ToJsonValueEnumerable>d__13 <ToJsonValueEnumerable>d__ = new JsonValue.<ToJsonValueEnumerable>d__13(-2);
			<ToJsonValueEnumerable>d__.<>3__arr = ienumerable_0;
			return <ToJsonValueEnumerable>d__;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003E80 File Offset: 0x00002080
		public static JsonValue ToJsonValue<T>(T ret)
		{
			JsonValue result;
			T t;
			string value10;
			Uri value18;
			if (ret == null)
			{
				result = null;
			}
			else if ((t = ret) is bool)
			{
				result = new JsonPrimitive((bool)((object)t));
			}
			else if ((t = ret) is byte)
			{
				byte value = (byte)((object)t);
				result = new JsonPrimitive(value);
			}
			else if ((t = ret) is char)
			{
				char value2 = (char)((object)t);
				result = new JsonPrimitive(value2);
			}
			else if ((t = ret) is decimal)
			{
				decimal value3 = (decimal)((object)t);
				result = new JsonPrimitive(value3);
			}
			else if ((t = ret) is double)
			{
				double value4 = (double)((object)t);
				result = new JsonPrimitive(value4);
			}
			else if ((t = ret) is float)
			{
				float value5 = (float)((object)t);
				result = new JsonPrimitive(value5);
			}
			else if ((t = ret) is int)
			{
				int value6 = (int)((object)t);
				result = new JsonPrimitive(value6);
			}
			else if ((t = ret) is long)
			{
				long value7 = (long)((object)t);
				result = new JsonPrimitive(value7);
			}
			else if ((t = ret) is sbyte)
			{
				sbyte value8 = (sbyte)((object)t);
				result = new JsonPrimitive(value8);
			}
			else if ((t = ret) is short)
			{
				short value9 = (short)((object)t);
				result = new JsonPrimitive(value9);
			}
			else if ((value10 = (ret as string)) != null)
			{
				result = new JsonPrimitive(value10);
			}
			else if ((t = ret) is uint)
			{
				uint value11 = (uint)((object)t);
				result = new JsonPrimitive(value11);
			}
			else if ((t = ret) is ulong)
			{
				ulong value12 = (ulong)((object)t);
				result = new JsonPrimitive(value12);
			}
			else if ((t = ret) is ushort)
			{
				ushort value13 = (ushort)((object)t);
				result = new JsonPrimitive(value13);
			}
			else if ((t = ret) is DateTime)
			{
				DateTime value14 = (DateTime)((object)t);
				result = new JsonPrimitive(value14);
			}
			else if ((t = ret) is DateTimeOffset)
			{
				DateTimeOffset value15 = (DateTimeOffset)((object)t);
				result = new JsonPrimitive(value15);
			}
			else if ((t = ret) is Guid)
			{
				Guid value16 = (Guid)((object)t);
				result = new JsonPrimitive(value16);
			}
			else if ((t = ret) is TimeSpan)
			{
				TimeSpan value17 = (TimeSpan)((object)t);
				result = new JsonPrimitive(value17);
			}
			else if ((value18 = (ret as Uri)) != null)
			{
				result = new JsonPrimitive(value18);
			}
			else
			{
				IEnumerable<KeyValuePair<string, object>> enumerable = ret as IEnumerable<KeyValuePair<string, object>>;
				if (enumerable != null)
				{
					result = new JsonObject(JsonValue.smethod_0(enumerable));
				}
				else
				{
					IEnumerable enumerable2 = ret as IEnumerable;
					if (enumerable2 == null)
					{
						if (!(ret is IEnumerable))
						{
							PropertyInfo[] properties = ret.GetType().GetProperties();
							Dictionary<string, object> dictionary = new Dictionary<string, object>();
							PropertyInfo[] array = properties;
							foreach (PropertyInfo propertyInfo in array)
							{
								dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(ret, null).IsNull("null"));
							}
							if (dictionary.Count > 0)
							{
								return new JsonObject(JsonValue.smethod_0(dictionary));
							}
						}
						throw new NotSupportedException(string.Format("Unexpected parser return type: {0}", ret.GetType()));
					}
					result = new JsonArray(JsonValue.smethod_1(enumerable2));
				}
			}
			return result;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000042C0 File Offset: 0x000024C0
		public static JsonValue Parse(string jsonString)
		{
			if (jsonString == null)
			{
				throw new ArgumentNullException("jsonString");
			}
			return JsonValue.Load(new StringReader(jsonString));
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000026E5 File Offset: 0x000008E5
		public virtual bool ContainsKey(string key)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000270C File Offset: 0x0000090C
		public virtual void Save(Stream stream, bool parsing)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			this.Save(new StreamWriter(stream), parsing);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000272C File Offset: 0x0000092C
		public virtual void Save(TextWriter textWriter, bool parsing)
		{
			if (textWriter == null)
			{
				throw new ArgumentNullException("textWriter");
			}
			this.method_0(textWriter, parsing);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000042EC File Offset: 0x000024EC
		private void method_0(TextWriter textWriter_0, bool bool_0)
		{
			switch (this.JsonType)
			{
			case JsonType.String:
				if (bool_0)
				{
					textWriter_0.Write('"');
				}
				textWriter_0.Write(this.EscapeString(((JsonPrimitive)this).GetFormattedString()));
				if (bool_0)
				{
					textWriter_0.Write('"');
					return;
				}
				return;
			case JsonType.Object:
			{
				textWriter_0.Write('{');
				bool flag = false;
				foreach (KeyValuePair<string, JsonValue> keyValuePair in ((JsonObject)this))
				{
					if (flag)
					{
						textWriter_0.Write(", ");
					}
					textWriter_0.Write('"');
					textWriter_0.Write(this.EscapeString(keyValuePair.Key));
					textWriter_0.Write("\": ");
					if (keyValuePair.Value == null)
					{
						textWriter_0.Write("null");
					}
					else
					{
						keyValuePair.Value.method_0(textWriter_0, bool_0);
					}
					flag = true;
				}
				textWriter_0.Write('}');
				return;
			}
			case JsonType.Array:
			{
				textWriter_0.Write('[');
				bool flag2 = false;
				foreach (JsonValue jsonValue in ((IEnumerable<JsonValue>)((JsonArray)this)))
				{
					if (flag2)
					{
						textWriter_0.Write(", ");
					}
					if (jsonValue != null)
					{
						jsonValue.method_0(textWriter_0, bool_0);
					}
					else
					{
						textWriter_0.Write("null");
					}
					flag2 = true;
				}
				textWriter_0.Write(']');
				return;
			}
			case JsonType.Boolean:
				textWriter_0.Write(this ? "true" : "false");
				return;
			}
			textWriter_0.Write(((JsonPrimitive)this).GetFormattedString());
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000044B0 File Offset: 0x000026B0
		public string ToString(bool saving = true)
		{
			StringWriter stringWriter = new StringWriter();
			this.Save(stringWriter, saving);
			return stringWriter.ToString();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000026E5 File Offset: 0x000008E5
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000044D4 File Offset: 0x000026D4
		private bool method_1(string string_0, int int_0)
		{
			char c = string_0[int_0];
			return c < ' ' || c == '"' || c == '\\' || (c >= '\ud800' && c <= '\udbff' && (int_0 == string_0.Length - 1 || string_0[int_0 + 1] < '\udc00' || string_0[int_0 + 1] > '\udfff')) || (c >= '\udc00' && c <= '\udfff' && (int_0 == 0 || string_0[int_0 - 1] < '\ud800' || string_0[int_0 - 1] > '\udbff')) || c == '\u2028' || c == '\u2029' || (c == '/' && int_0 > 0 && string_0[int_0 - 1] == '<');
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000045AC File Offset: 0x000027AC
		public string EscapeString(string src)
		{
			string result;
			if (src == null)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < src.Length; i++)
				{
					if (this.method_1(src, i))
					{
						StringBuilder stringBuilder = new StringBuilder();
						if (i > 0)
						{
							stringBuilder.Append(src, 0, i);
						}
						return this.method_2(stringBuilder, src, i);
					}
				}
				result = src;
			}
			return result;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004608 File Offset: 0x00002808
		private string method_2(StringBuilder stringBuilder_0, string string_0, int int_0)
		{
			int num = int_0;
			for (int i = int_0; i < string_0.Length; i++)
			{
				if (this.method_1(string_0, i))
				{
					stringBuilder_0.Append(string_0, num, i - num);
					char c = string_0[i];
					if (c <= '"')
					{
						switch (c)
						{
						case '\b':
							stringBuilder_0.Append("\\b");
							break;
						case '\t':
							stringBuilder_0.Append("\\t");
							break;
						case '\n':
							stringBuilder_0.Append("\\n");
							break;
						case '\v':
							goto IL_BD;
						case '\f':
							stringBuilder_0.Append("\\f");
							break;
						case '\r':
							stringBuilder_0.Append("\\r");
							break;
						default:
							if (c != '"')
							{
								goto IL_BD;
							}
							stringBuilder_0.Append("\\\"");
							break;
						}
					}
					else if (c != '/')
					{
						if (c != '\\')
						{
							goto IL_BD;
						}
						stringBuilder_0.Append("\\\\");
					}
					else
					{
						stringBuilder_0.Append("\\/");
					}
					IL_100:
					num = i + 1;
					goto IL_104;
					IL_BD:
					stringBuilder_0.Append("\\u");
					stringBuilder_0.Append(((int)string_0[i]).ToString("x04"));
					goto IL_100;
				}
				IL_104:;
			}
			stringBuilder_0.Append(string_0, num, string_0.Length - num);
			return stringBuilder_0.ToString();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004748 File Offset: 0x00002948
		public static implicit operator JsonValue(bool value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004760 File Offset: 0x00002960
		public static implicit operator JsonValue(byte value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004778 File Offset: 0x00002978
		public static implicit operator JsonValue(char value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004790 File Offset: 0x00002990
		public static implicit operator JsonValue(decimal value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000047A8 File Offset: 0x000029A8
		public static implicit operator JsonValue(double value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000047C0 File Offset: 0x000029C0
		public static implicit operator JsonValue(float value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000047D8 File Offset: 0x000029D8
		public static implicit operator JsonValue(int value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000047F0 File Offset: 0x000029F0
		public static implicit operator JsonValue(long value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004808 File Offset: 0x00002A08
		public static implicit operator JsonValue(sbyte value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004820 File Offset: 0x00002A20
		public static implicit operator JsonValue(short value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00004838 File Offset: 0x00002A38
		public static implicit operator JsonValue(string value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004850 File Offset: 0x00002A50
		public static implicit operator JsonValue(uint value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004868 File Offset: 0x00002A68
		public static implicit operator JsonValue(ulong value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004880 File Offset: 0x00002A80
		public static implicit operator JsonValue(ushort value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00004898 File Offset: 0x00002A98
		public static implicit operator JsonValue(DateTime value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000048B0 File Offset: 0x00002AB0
		public static implicit operator JsonValue(DateTimeOffset value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000048C8 File Offset: 0x00002AC8
		public static implicit operator JsonValue(Guid value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000048E0 File Offset: 0x00002AE0
		public static implicit operator JsonValue(TimeSpan value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000048F8 File Offset: 0x00002AF8
		public static implicit operator JsonValue(Uri value)
		{
			return new JsonPrimitive(value);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002747 File Offset: 0x00000947
		public static implicit operator bool(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToBoolean(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00004910 File Offset: 0x00002B10
		public static implicit operator byte(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToByte(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00004948 File Offset: 0x00002B48
		public static implicit operator char(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToChar(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00004980 File Offset: 0x00002B80
		public static implicit operator decimal(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToDecimal(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000049B8 File Offset: 0x00002BB8
		public static implicit operator double(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToDouble(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000049F0 File Offset: 0x00002BF0
		public static implicit operator float(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToSingle(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004A28 File Offset: 0x00002C28
		public static implicit operator int(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToInt32(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004A60 File Offset: 0x00002C60
		public static implicit operator long(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToInt64(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00004A98 File Offset: 0x00002C98
		public static implicit operator sbyte(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToSByte(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00004AD0 File Offset: 0x00002CD0
		public static implicit operator short(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToInt16(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004B08 File Offset: 0x00002D08
		public static implicit operator string(JsonValue value)
		{
			return (value != null) ? value.ToString(true) : null;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004B24 File Offset: 0x00002D24
		public static implicit operator uint(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToUInt32(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004B5C File Offset: 0x00002D5C
		public static implicit operator ulong(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToUInt64(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004B94 File Offset: 0x00002D94
		public static implicit operator ushort(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return Convert.ToUInt16(((JsonPrimitive)value).Value, NumberFormatInfo.InvariantInfo);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00004BCC File Offset: 0x00002DCC
		public static implicit operator DateTime(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (DateTime)((JsonPrimitive)value).Value;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00004BFC File Offset: 0x00002DFC
		public static implicit operator DateTimeOffset(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (DateTimeOffset)((JsonPrimitive)value).Value;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00004C2C File Offset: 0x00002E2C
		public static implicit operator TimeSpan(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (TimeSpan)((JsonPrimitive)value).Value;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004C5C File Offset: 0x00002E5C
		public static implicit operator Guid(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (Guid)((JsonPrimitive)value).Value;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004C8C File Offset: 0x00002E8C
		public static implicit operator Uri(JsonValue value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return (Uri)((JsonPrimitive)value).Value;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000276F File Offset: 0x0000096F
		protected JsonValue()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
		}
	}
}
