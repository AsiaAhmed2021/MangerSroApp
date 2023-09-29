// Decompiled with JetBrains decompiler
// Type: SilkroadSecurityApi.PacketReader
// Assembly: Server_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A258EC0-668A-4986-B043-7AD1471BC426
// Assembly location: C:\VsroCap100\Vsro.188_cap100_IronSro.v2_package[TheRock2007]\Server Files\Server_Manager.exe

using System.IO;

namespace SilkroadSecurityApi
{
    internal class PacketReader : BinaryReader
    {
        private byte[] m_input;

        public PacketReader(byte[] input)
          : base((Stream)new MemoryStream(input, false))
        {
            this.m_input = input;
        }

        public PacketReader(byte[] input, int index, int count)
          : base((Stream)new MemoryStream(input, index, count, false))
        {
            this.m_input = input;
        }
    }
}
