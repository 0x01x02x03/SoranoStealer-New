using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace NoiseMe.Drags.App.Models.JSON
{
	// Token: 0x02000008 RID: 8
	public class JsonPrimitive : JsonValue
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000024F1 File Offset: 0x000006F1
		public object Value
		{
			get
			{
				return this.object_0;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00003BE8 File Offset: 0x00001DE8
		public override JsonType JsonType
		{
			get
			{
				JsonType result;
				if (this.object_0 == null)
				{
					result = JsonType.String;
				}
				else
				{
					TypeCode typeCode = Type.GetTypeCode(this.object_0.GetType());
					switch (typeCode)
					{
					case TypeCode.Object:
					case TypeCode.Char:
						goto IL_4A;
					case TypeCode.DBNull:
						break;
					case TypeCode.Boolean:
						return JsonType.Boolean;
					default:
						if (typeCode == TypeCode.DateTime || typeCode == TypeCode.String)
						{
							goto IL_4A;
						}
						break;
					}
					return JsonType.Number;
					IL_4A:
					result = JsonType.String;
				}
				return result;
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000024F9 File Offset: 0x000006F9
		public JsonPrimitive(bool value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002512 File Offset: 0x00000712
		public JsonPrimitive(byte value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000252B File Offset: 0x0000072B
		public JsonPrimitive(char value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002544 File Offset: 0x00000744
		public JsonPrimitive(decimal value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000255D File Offset: 0x0000075D
		public JsonPrimitive(double value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002576 File Offset: 0x00000776
		public JsonPrimitive(float value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000258F File Offset: 0x0000078F
		public JsonPrimitive(int value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000025A8 File Offset: 0x000007A8
		public JsonPrimitive(long value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000025C1 File Offset: 0x000007C1
		public JsonPrimitive(sbyte value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000025DA File Offset: 0x000007DA
		public JsonPrimitive(short value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000025F3 File Offset: 0x000007F3
		public JsonPrimitive(string value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002607 File Offset: 0x00000807
		public JsonPrimitive(DateTime value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00002620 File Offset: 0x00000820
		public JsonPrimitive(uint value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002639 File Offset: 0x00000839
		public JsonPrimitive(ulong value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002652 File Offset: 0x00000852
		public JsonPrimitive(ushort value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000266B File Offset: 0x0000086B
		public JsonPrimitive(DateTimeOffset value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002684 File Offset: 0x00000884
		public JsonPrimitive(Guid value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000269D File Offset: 0x0000089D
		public JsonPrimitive(TimeSpan value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000025F3 File Offset: 0x000007F3
		public JsonPrimitive(Uri value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000025F3 File Offset: 0x000007F3
		public JsonPrimitive(object value)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.object_0 = value;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003C44 File Offset: 0x00001E44
		public override void Save(Stream stream, bool parsing)
		{
			JsonType jsonType = this.JsonType;
			if (jsonType != JsonType.String)
			{
				if (jsonType != JsonType.Boolean)
				{
					byte[] bytes = Encoding.UTF8.GetBytes(this.GetFormattedString());
					stream.Write(bytes, 0, bytes.Length);
				}
				else if ((bool)this.object_0)
				{
					stream.Write(JsonPrimitive.XstdncteM, 0, 4);
				}
				else
				{
					stream.Write(JsonPrimitive.byte_0, 0, 5);
				}
			}
			else
			{
				stream.WriteByte(34);
				byte[] bytes2 = Encoding.UTF8.GetBytes(base.EscapeString(this.object_0.ToString()));
				stream.Write(bytes2, 0, bytes2.Length);
				stream.WriteByte(34);
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003CE0 File Offset: 0x00001EE0
		public string GetFormattedString()
		{
			JsonType jsonType = this.JsonType;
			string result;
			if (jsonType != JsonType.String)
			{
				if (jsonType != JsonType.Number)
				{
					throw new InvalidOperationException();
				}
				string text = (this.object_0 is float || this.object_0 is double) ? ((IFormattable)this.object_0).ToString("R", NumberFormatInfo.InvariantInfo) : ((IFormattable)this.object_0).ToString("G", NumberFormatInfo.InvariantInfo);
				if (text == "NaN" || text == "Infinity" || text == "-Infinity")
				{
					result = "\"" + text + "\"";
				}
				else
				{
					result = text;
				}
			}
			else if (this.object_0 is string || this.object_0 == null)
			{
				string text2 = this.object_0 as string;
				if (string.IsNullOrEmpty(text2))
				{
					result = "null";
				}
				else
				{
					result = text2.Trim(new char[]
					{
						'"'
					});
				}
			}
			else
			{
				if (!(this.object_0 is char))
				{
					throw new NotImplementedException("GetFormattedString from value type " + this.object_0.GetType());
				}
				result = this.object_0.ToString();
			}
			return result;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000026B6 File Offset: 0x000008B6
		// Note: this type is marked as 'beforefieldinit'.
		static JsonPrimitive()
		{
			Class34.A1SfXVPz7w9eh();
			JsonPrimitive.XstdncteM = Encoding.UTF8.GetBytes("true");
			JsonPrimitive.byte_0 = Encoding.UTF8.GetBytes("false");
		}

		// Token: 0x0400000A RID: 10
		private object object_0;

		// Token: 0x0400000B RID: 11
		private static readonly byte[] XstdncteM;

		// Token: 0x0400000C RID: 12
		private static readonly byte[] byte_0;
	}
}
