// Decompiled with JetBrains decompiler
// Type: SilkroadSecurityApi.Utility
// Assembly: Server_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5A258EC0-668A-4986-B043-7AD1471BC426
// Assembly location: C:\VsroCap100\Vsro.188_cap100_IronSro.v2_package[TheRock2007]\Server Files\Server_Manager.exe

using System;
using System.Text;

namespace SilkroadSecurityApi
{
  public class Utility
  {
    public static string HexDump(byte[] buffer) => HexDump(buffer, 0, buffer.Length);

    public static string HexDump(byte[] buffer, int offset, int count)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      int num = count;
      if (num % 16 != 0)
        num += 16 - num % 16;
      for (int index = 0; index <= num; ++index)
      {
        if (index % 16 == 0)
        {
          if (index > 0)
          {
            stringBuilder1.AppendFormat("  {0}{1}", (object) stringBuilder2.ToString(), (object) Environment.NewLine);
            stringBuilder2.Clear();
          }
          if (index != num)
            stringBuilder1.AppendFormat("{0:d10}   ", (object) index);
        }
        if (index < count)
        {
          stringBuilder1.AppendFormat("{0:X2} ", (object) buffer[offset + index]);
          char c = (char) buffer[offset + index];
          if (!char.IsControl(c))
            stringBuilder2.AppendFormat("{0}", (object) c);
          else
            stringBuilder2.Append(".");
        }
        else
        {
          stringBuilder1.Append("   ");
          stringBuilder2.Append(".");
        }
      }
      return stringBuilder1.ToString();
    }
  }
}
