using System;
using System.Reflection;

// Token: 0x02000056 RID: 86
internal class Class33
{
	// Token: 0x0600026F RID: 623 RVA: 0x00013BD0 File Offset: 0x00011DD0
	internal static void xvwfXVPPqXqw3(int typemdt)
	{
		Type type = Class33.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class33.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	// Token: 0x06000270 RID: 624 RVA: 0x0000276F File Offset: 0x0000096F
	public Class33()
	{
		Class34.A1SfXVPz7w9eh();
		base..ctor();
	}

	// Token: 0x06000271 RID: 625 RVA: 0x00002FC1 File Offset: 0x000011C1
	// Note: this type is marked as 'beforefieldinit'.
	static Class33()
	{
		Class34.A1SfXVPz7w9eh();
		Class33.module_0 = typeof(Class33).Assembly.ManifestModule;
	}

	// Token: 0x04000133 RID: 307
	internal static Module module_0;

	// Token: 0x02000057 RID: 87
	// (Invoke) Token: 0x06000273 RID: 627
	internal delegate void Delegate0(object o);
}
