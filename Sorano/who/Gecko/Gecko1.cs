using System;

namespace who.Gecko
{
	// Token: 0x02000030 RID: 48
	public class Gecko1
	{
		// Token: 0x06000186 RID: 390 RVA: 0x0000DE70 File Offset: 0x0000C070
		public static Gecko4 Create(byte[] dataToParse)
		{
			Gecko4 gecko = new Gecko4();
			for (int i = 0; i < dataToParse.Length; i++)
			{
				Gecko2 gecko2 = (Gecko2)dataToParse[i];
				Gecko2 gecko3 = gecko2;
				switch (gecko3)
				{
				case Gecko2.Integer:
				{
					gecko.Objects.Add(new Gecko4
					{
						ObjectType = Gecko2.Integer,
						ObjectLength = (int)dataToParse[i + 1]
					});
					byte[] array = new byte[(int)dataToParse[i + 1]];
					int length = (i + 2 + (int)dataToParse[i + 1] > dataToParse.Length) ? (dataToParse.Length - (i + 2)) : ((int)dataToParse[i + 1]);
					Array.Copy(dataToParse, i + 2, array, 0, length);
					gecko.Objects[gecko.Objects.Count - 1].ObjectData = array;
					i = i + 1 + gecko.Objects[gecko.Objects.Count - 1].ObjectLength;
					break;
				}
				case Gecko2.BitString:
				case Gecko2.Null:
					break;
				case Gecko2.OctetString:
				{
					gecko.Objects.Add(new Gecko4
					{
						ObjectType = Gecko2.OctetString,
						ObjectLength = (int)dataToParse[i + 1]
					});
					byte[] array2 = new byte[(int)dataToParse[i + 1]];
					int length = (i + 2 + (int)dataToParse[i + 1] > dataToParse.Length) ? (dataToParse.Length - (i + 2)) : ((int)dataToParse[i + 1]);
					Array.Copy(dataToParse, i + 2, array2, 0, length);
					gecko.Objects[gecko.Objects.Count - 1].ObjectData = array2;
					i = i + 1 + gecko.Objects[gecko.Objects.Count - 1].ObjectLength;
					break;
				}
				case Gecko2.ObjectIdentifier:
				{
					gecko.Objects.Add(new Gecko4
					{
						ObjectType = Gecko2.ObjectIdentifier,
						ObjectLength = (int)dataToParse[i + 1]
					});
					byte[] array3 = new byte[(int)dataToParse[i + 1]];
					int length = (i + 2 + (int)dataToParse[i + 1] > dataToParse.Length) ? (dataToParse.Length - (i + 2)) : ((int)dataToParse[i + 1]);
					Array.Copy(dataToParse, i + 2, array3, 0, length);
					gecko.Objects[gecko.Objects.Count - 1].ObjectData = array3;
					i = i + 1 + gecko.Objects[gecko.Objects.Count - 1].ObjectLength;
					break;
				}
				default:
					if (gecko3 == Gecko2.Sequence)
					{
						byte[] array4;
						if (gecko.ObjectLength == 0)
						{
							gecko.ObjectType = Gecko2.Sequence;
							gecko.ObjectLength = dataToParse.Length - (i + 2);
							array4 = new byte[gecko.ObjectLength];
						}
						else
						{
							gecko.Objects.Add(new Gecko4
							{
								ObjectType = Gecko2.Sequence,
								ObjectLength = (int)dataToParse[i + 1]
							});
							array4 = new byte[(int)dataToParse[i + 1]];
						}
						int num = (array4.Length > dataToParse.Length - (i + 2)) ? (dataToParse.Length - (i + 2)) : array4.Length;
						Array.Copy(dataToParse, i + 2, array4, 0, array4.Length);
						gecko.Objects.Add(Gecko1.Create(array4));
						i = i + 1 + (int)dataToParse[i + 1];
					}
					break;
				}
			}
			return gecko;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000276F File Offset: 0x0000096F
		public Gecko1()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
		}
	}
}
