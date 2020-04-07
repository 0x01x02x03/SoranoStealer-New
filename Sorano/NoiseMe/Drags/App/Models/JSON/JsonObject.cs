using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NoiseMe.Drags.App.Models.JSON
{
	// Token: 0x02000007 RID: 7
	public class JsonObject : JsonValue, IDictionary<string, JsonValue>, ICollection<KeyValuePair<string, JsonValue>>, IEnumerable<KeyValuePair<string, JsonValue>>, IEnumerable
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002395 File Offset: 0x00000595
		public override int Count
		{
			get
			{
				return this.sortedDictionary_0.Count;
			}
		}

		// Token: 0x17000006 RID: 6
		public sealed override JsonValue this[string key]
		{
			get
			{
				return this.sortedDictionary_0[key];
			}
			set
			{
				this.sortedDictionary_0[key] = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000023B1 File Offset: 0x000005B1
		public override JsonType JsonType
		{
			get
			{
				return JsonType.Object;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000023B4 File Offset: 0x000005B4
		public ICollection<string> Keys
		{
			get
			{
				return this.sortedDictionary_0.Keys;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000023C1 File Offset: 0x000005C1
		public ICollection<JsonValue> Values
		{
			get
			{
				return this.sortedDictionary_0.Values;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002290 File Offset: 0x00000490
		bool ICollection<KeyValuePair<string, JsonValue>>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000023CE File Offset: 0x000005CE
		public JsonObject(params KeyValuePair<string, JsonValue>[] items)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			this.sortedDictionary_0 = new SortedDictionary<string, JsonValue>(StringComparer.Ordinal);
			if (items != null)
			{
				this.AddRange(items);
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000023F8 File Offset: 0x000005F8
		public JsonObject(IEnumerable<KeyValuePair<string, JsonValue>> items)
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			this.sortedDictionary_0 = new SortedDictionary<string, JsonValue>(StringComparer.Ordinal);
			this.AddRange(items);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003A48 File Offset: 0x00001C48
		public IEnumerator<KeyValuePair<string, JsonValue>> GetEnumerator()
		{
			return this.sortedDictionary_0.GetEnumerator();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003A68 File Offset: 0x00001C68
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.sortedDictionary_0.GetEnumerator();
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000242D File Offset: 0x0000062D
		public void Add(string key, JsonValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this.sortedDictionary_0.Add(key, value);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000244D File Offset: 0x0000064D
		public void Add(KeyValuePair<string, JsonValue> pair)
		{
			this.Add(pair.Key, pair.Value);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003A88 File Offset: 0x00001C88
		public void AddRange(IEnumerable<KeyValuePair<string, JsonValue>> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			foreach (KeyValuePair<string, JsonValue> keyValuePair in items)
			{
				this.sortedDictionary_0.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002463 File Offset: 0x00000663
		public void AddRange(params KeyValuePair<string, JsonValue>[] items)
		{
			this.AddRange(items);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x0000246C File Offset: 0x0000066C
		public void Clear()
		{
			this.sortedDictionary_0.Clear();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002479 File Offset: 0x00000679
		bool ICollection<KeyValuePair<string, JsonValue>>.Contains(KeyValuePair<string, JsonValue> item)
		{
			return ((ICollection<KeyValuePair<string, JsonValue>>)this.sortedDictionary_0).Contains(item);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002487 File Offset: 0x00000687
		bool ICollection<KeyValuePair<string, JsonValue>>.Remove(KeyValuePair<string, JsonValue> item)
		{
			return ((ICollection<KeyValuePair<string, JsonValue>>)this.sortedDictionary_0).Remove(item);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002495 File Offset: 0x00000695
		public override bool ContainsKey(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return this.sortedDictionary_0.ContainsKey(key);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000024B4 File Offset: 0x000006B4
		public void CopyTo(KeyValuePair<string, JsonValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<string, JsonValue>>)this.sortedDictionary_0).CopyTo(array, arrayIndex);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000024C3 File Offset: 0x000006C3
		public bool Remove(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return this.sortedDictionary_0.Remove(key);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003AF4 File Offset: 0x00001CF4
		public override void Save(Stream stream, bool parsing)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			stream.WriteByte(123);
			foreach (KeyValuePair<string, JsonValue> keyValuePair in this.sortedDictionary_0)
			{
				stream.WriteByte(34);
				byte[] bytes = Encoding.UTF8.GetBytes(base.EscapeString(keyValuePair.Key));
				stream.Write(bytes, 0, bytes.Length);
				stream.WriteByte(34);
				stream.WriteByte(44);
				stream.WriteByte(32);
				if (keyValuePair.Value == null)
				{
					stream.WriteByte(110);
					stream.WriteByte(117);
					stream.WriteByte(108);
					stream.WriteByte(108);
				}
				else
				{
					keyValuePair.Value.Save(stream, parsing);
				}
			}
			stream.WriteByte(125);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000024E2 File Offset: 0x000006E2
		public bool TryGetValue(string key, out JsonValue value)
		{
			return this.sortedDictionary_0.TryGetValue(key, out value);
		}

		// Token: 0x04000009 RID: 9
		private SortedDictionary<string, JsonValue> sortedDictionary_0;
	}
}
