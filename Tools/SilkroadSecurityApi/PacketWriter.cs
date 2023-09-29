// Decompiled with JetBrains decompiler
// Type: SilkroadSecurityApi.PacketWriter
// Assembly: Server_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A258EC0-668A-4986-B043-7AD1471BC426
// Assembly location: C:\VsroCap100\Vsro.188_cap100_IronSro.v2_package[TheRock2007]\Server Files\Server_Manager.exe

using System.IO;

namespace SilkroadSecurityApi
{
  internal class PacketWriter : BinaryWriter
  {
    private MemoryStream m_ms;

    public PacketWriter()
    {
      this.m_ms = new MemoryStream();
      this.OutStream = (Stream) this.m_ms;
    }

    public byte[] GetBytes() => this.m_ms.ToArray();
  }
}
