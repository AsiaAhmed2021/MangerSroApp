namespace vSroMultiTool
{
    using SilkroadSecurityApi;
    using System;

    internal class Login
    {
        public static void HandleCharList(Packet packet)
        {
            if (packet.ReadUInt8() == 2)
            {
                if (packet.ReadUInt8() == 1)
                {
                    byte num2 = packet.ReadUInt8();
                    for (int i = 0; i < num2; i++)
                    {
                        uint num8;
                        byte num9;
                        uint num4 = packet.ReadUInt32();
                        string item = packet.ReadAscii();
                        packet.ReadUInt8();
                        packet.ReadUInt8();
                        packet.ReadUInt64();
                        packet.ReadUInt16();
                        packet.ReadUInt16();
                        packet.ReadUInt16();
                        packet.ReadUInt32();
                        packet.ReadUInt32();
                        if (packet.ReadUInt8() == 1)
                        {
                            packet.ReadUInt32();
                        }
                        packet.ReadUInt16();
                        packet.ReadUInt8();
                        byte num6 = packet.ReadUInt8();
                        int num7 = 0;
                        while (num7 < num6)
                        {
                            num8 = packet.ReadUInt32();
                            num9 = packet.ReadUInt8();
                            num7++;
                        }
                        byte num10 = packet.ReadUInt8();
                        for (num7 = 0; num7 < num10; num7++)
                        {
                            num8 = packet.ReadUInt32();
                            num9 = packet.ReadUInt8();
                        }
                        Globals.MainWindow.char_list.Items.Add(item);
                    }
                }
            }
            else if (packet.ReadUInt8() == 1)
            {
                Meldung("Char success", new object[0]);
                Globals.MainWindow.char_list.Items.Clear();
                Packet packet2 = new Packet(0x7007);
                packet2.WriteUInt8((byte) 2);
                Agent.Send(packet2);
            }
            else if (packet.ReadUInt8() == 0x10)
            {
                Meldung("Exist.", new object[0]);
            }
            else if (packet.ReadUInt8() == 4)
            {
                Meldung("[ERROR] You Account is full !", new object[0]);
            }
        }

        private static void Meldung(string msg, params object[] values)
        {
            msg = string.Format(msg, values);
            Globals.MainWindow.listBox1.Items.Add("[" + System.DateTime.Now.ToLongTimeString() + "] " + msg);
            Globals.MainWindow.listBox1.TopIndex = Globals.MainWindow.listBox1.Items.Count - 1;
        }
    }
}

