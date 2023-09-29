// Decompiled with JetBrains decompiler
// Type: Server_Manager.Properties.Resources
// Assembly: Server_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A258EC0-668A-4986-B043-7AD1471BC426
// Assembly location: C:\VsroCap100\Vsro.188_cap100_IronSro.v2_package[TheRock2007]\Server Files\Server_Manager.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Server_Manager.Properties
{
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Server_Manager.Properties.Resources.resourceMan == null)
          Server_Manager.Properties.Resources.resourceMan = new ResourceManager("Server_Manager.Properties.Resources", typeof (Server_Manager.Properties.Resources).Assembly);
        return Server_Manager.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Server_Manager.Properties.Resources.resourceCulture;
      set => Server_Manager.Properties.Resources.resourceCulture = value;
    }
  }
}
