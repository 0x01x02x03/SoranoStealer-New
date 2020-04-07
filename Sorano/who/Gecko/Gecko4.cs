using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace who.Gecko
{
	// Token: 0x02000033 RID: 51
	public class Gecko4
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00002B6E File Offset: 0x00000D6E
		// (set) Token: 0x06000192 RID: 402 RVA: 0x00002B76 File Offset: 0x00000D76
		public Gecko2 ObjectType { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00002B7F File Offset: 0x00000D7F
		// (set) Token: 0x06000194 RID: 404 RVA: 0x00002B87 File Offset: 0x00000D87
		public byte[] ObjectData { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00002B90 File Offset: 0x00000D90
		// (set) Token: 0x06000196 RID: 406 RVA: 0x00002B98 File Offset: 0x00000D98
		public int ObjectLength { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000197 RID: 407 RVA: 0x00002BA1 File Offset: 0x00000DA1
		// (set) Token: 0x06000198 RID: 408 RVA: 0x00002BA9 File Offset: 0x00000DA9
		public List<Gecko4> Objects { get; set; }

		// Token: 0x06000199 RID: 409 RVA: 0x00002BB2 File Offset: 0x00000DB2
		public Gecko4()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.Objects = new List<Gecko4>();
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000E150 File Offset: 0x0000C350
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			Gecko2 objectType = this.ObjectType;
			switch (objectType)
			{
			case Gecko2.Integer:
			{
				byte[] objectData = this.ObjectData;
				foreach (byte b in objectData)
				{
					stringBuilder2.AppendFormat("{0:X2}", b);
				}
				stringBuilder.Append("\tINTEGER ").Append(stringBuilder2).AppendLine();
				break;
			}
			case Gecko2.BitString:
			case Gecko2.Null:
				break;
			case Gecko2.OctetString:
			{
				byte[] objectData2 = this.ObjectData;
				foreach (byte b2 in objectData2)
				{
					stringBuilder2.AppendFormat("{0:X2}", b2);
				}
				stringBuilder.Append("\tOCTETSTRING ").AppendLine(stringBuilder2.ToString());
				break;
			}
			case Gecko2.ObjectIdentifier:
			{
				byte[] objectData3 = this.ObjectData;
				foreach (byte b3 in objectData3)
				{
					stringBuilder2.AppendFormat("{0:X2}", b3);
				}
				stringBuilder.Append("\tOBJECTIDENTIFIER ").AppendLine(stringBuilder2.ToString());
				break;
			}
			default:
				if (objectType == Gecko2.Sequence)
				{
					stringBuilder.AppendLine("SEQUENCE {");
				}
				break;
			}
			foreach (Gecko4 gecko in this.Objects)
			{
				stringBuilder.Append(gecko.ToString());
			}
			if (this.ObjectType == Gecko2.Sequence)
			{
				stringBuilder.AppendLine("}");
			}
			stringBuilder2.Remove(0, stringBuilder2.Length - 1);
			return stringBuilder.ToString();
		}

		// Token: 0x040000AE RID: 174
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private Gecko2 gecko2_0;

		// Token: 0x040000AF RID: 175
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte[] byte_0;

		// Token: 0x040000B0 RID: 176
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private int int_0;

		// Token: 0x040000B1 RID: 177
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private List<Gecko4> list_0;
	}
}
