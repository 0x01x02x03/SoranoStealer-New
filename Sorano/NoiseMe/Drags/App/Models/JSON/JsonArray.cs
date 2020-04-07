using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace NoiseMe.Drags.App.Models.JSON
{
	// Token: 0x02000005 RID: 5
	public class JsonArray : JsonValue, IList<JsonValue>, ICollection<JsonValue>, IEnumerable<JsonValue>, IEnumerable
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002283 File Offset: 0x00000483
		public override int Count
		{
			get
			{
				return this.xfPinNwiA.Count;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002290 File Offset: 0x00000490
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000003 RID: 3
		public sealed override JsonValue this[int index]
		{
			get
			{
				return this.xfPinNwiA[index];
			}
			set
			{
				this.xfPinNwiA[index] = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000022A2 File Offset: 0x000004A2
		public override JsonType JsonType
		{
			get
			{
				return JsonType.Array;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022A5 File Offset: 0x000004A5
		public JsonArray(params JsonValue[] items)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.xfPinNwiA = new List<JsonValue>();
			this.AddRange(items);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000022C4 File Offset: 0x000004C4
		public JsonArray(IEnumerable<JsonValue> items)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			this.xfPinNwiA = new List<JsonValue>(items);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000022EE File Offset: 0x000004EE
		public void Add(JsonValue item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			this.xfPinNwiA.Add(item);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000230D File Offset: 0x0000050D
		public void AddRange(IEnumerable<JsonValue> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			this.xfPinNwiA.AddRange(items);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000232C File Offset: 0x0000052C
		public void AddRange(params JsonValue[] items)
		{
			if (items != null)
			{
				this.xfPinNwiA.AddRange(items);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002340 File Offset: 0x00000540
		public void Clear()
		{
			this.xfPinNwiA.Clear();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000234D File Offset: 0x0000054D
		public bool Contains(JsonValue item)
		{
			return this.xfPinNwiA.Contains(item);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000235B File Offset: 0x0000055B
		public void CopyTo(JsonValue[] array, int arrayIndex)
		{
			this.xfPinNwiA.CopyTo(array, arrayIndex);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000038F8 File Offset: 0x00001AF8
		public int IndexOf(JsonValue item)
		{
			return this.xfPinNwiA.IndexOf(item);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000236A File Offset: 0x0000056A
		public void Insert(int index, JsonValue item)
		{
			this.xfPinNwiA.Insert(index, item);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002379 File Offset: 0x00000579
		public bool Remove(JsonValue item)
		{
			return this.xfPinNwiA.Remove(item);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002387 File Offset: 0x00000587
		public void RemoveAt(int index)
		{
			this.xfPinNwiA.RemoveAt(index);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003914 File Offset: 0x00001B14
		public override void Save(Stream stream, bool parsing)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			stream.WriteByte(91);
			for (int i = 0; i < this.xfPinNwiA.Count; i++)
			{
				JsonValue jsonValue = this.xfPinNwiA[i];
				if (jsonValue != null)
				{
					jsonValue.Save(stream, parsing);
				}
				else
				{
					stream.WriteByte(110);
					stream.WriteByte(117);
					stream.WriteByte(108);
					stream.WriteByte(108);
				}
				if (i < this.Count - 1)
				{
					stream.WriteByte(44);
					stream.WriteByte(32);
				}
			}
			stream.WriteByte(93);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000039B4 File Offset: 0x00001BB4
		IEnumerator<JsonValue> IEnumerable<JsonValue>.GetEnumerator()
		{
			return this.xfPinNwiA.GetEnumerator();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000039D4 File Offset: 0x00001BD4
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.xfPinNwiA.GetEnumerator();
		}

		// Token: 0x04000008 RID: 8
		private List<JsonValue> xfPinNwiA;
	}
}
