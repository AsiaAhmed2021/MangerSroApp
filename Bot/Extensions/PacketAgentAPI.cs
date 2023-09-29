using MangerSroApp.Tools.Bot;
using SilkroadSecurityApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silkroad.Tools.Bot
{
    internal static class PacketAgentAPI
    {
        public static void RecallChar(this Agent agent, string Charname)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt8((byte)0x11);
                packet.WriteUInt8((byte)0);
                packet.WriteAscii(Charname);
                agent.Send(packet);
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }
        }
        public static void Exit(this Agent agent)
        {
            try
            {

                Packet exit = new Packet(0x7005);
                exit.WriteUInt8(0x01);
                agent.Send(exit);
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }

        }
        public static void LoadMonster(this Agent agent, int UniqueID, int Quantity)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt8((byte)6);
                packet.WriteUInt8((byte)0);
                packet.WriteUInt32(UniqueID);
                packet.WriteUInt8(Quantity);
                packet.WriteUInt8((byte)3);
                agent.Send(packet);
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }

        }
        public static void ToTownuser(this Agent agent, string Charname)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt16((ushort)3);
                packet.WriteAscii(Charname);
                agent.Send(packet);
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }



        }
        public static void Gotown(this Agent agent)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt8((byte)2);
                packet.WriteUInt8((byte)0);
                agent.Send(packet);
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }
        }
        public static void GMVinsibile(this Agent agent)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt8((byte)14);
                packet.WriteUInt8((byte)0);
                agent.Send(packet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void GMInVisibile(this Agent agent)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt8((byte)14);
                packet.WriteUInt8((byte)0);
                agent.Send(packet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public static void MakeItem(this Agent agent, int Amount, int ItemID, int OptLvl)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt8((byte)7);
                packet.WriteUInt8((byte)0);
                packet.WriteUInt32(ItemID);
                packet.WriteUInt32(Amount);
                packet.WriteUInt8(OptLvl);
                agent.Send(packet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void Movetouser(this Agent agent, string Charname)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt16((ushort)8);
                packet.WriteAscii(Charname);
                agent.Send(packet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public static void RecallGuild(this Agent agent, string guildname)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt16((ushort)0x12);
                packet.WriteAscii(guildname);
                agent.Send(packet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void DCUser(this Agent agent, string Charname)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt16((ushort)13);
                packet.WriteAscii(Charname);
                agent.Send(packet);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public static void GMSkill(this Agent agent)
        {
            try
            {
                Packet packet = new Packet(0x7074);
                packet.WriteUInt8((byte)1);
                packet.WriteUInt8((byte)4);
                packet.WriteUInt32((uint)0xf8a);
                packet.WriteUInt8((byte)0);
                agent.Send(packet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void MakeWarp(this Agent agent, int RegionID, double x, double y, double z)
        {
            try
            {
                Packet packet = new Packet(0x7010);
                packet.WriteUInt8((byte)0x10);
                packet.WriteUInt8((byte)0);
                packet.WriteInt16(RegionID);
                packet.WriteSingle(x);
                packet.WriteSingle(y);
                packet.WriteSingle(z);
                packet.WriteInt8(1);
                packet.WriteUInt8((byte)0);
                agent.Send(packet);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void Walk(this Agent agent, byte byte_0, uint uint_0, uint uint_1, uint uint_2, uint uint_3)
        {

            Packet Walk = new Packet(0x7021);
            Walk.WriteUInt8(byte_0);
            Walk.WriteUInt32(uint_0);
            Walk.WriteUInt32(uint_1);
            Walk.WriteUInt32(uint_2);
            Walk.WriteUInt32(uint_3);
            agent.Send(Walk);
        }
        public static void Trace(this Agent agent, uint UniqeID)
        {
            Packet Trace = new Packet(0x7074);
            Trace.WriteUInt8(1);
            Trace.WriteUInt8(3);
            Trace.WriteUInt8(1);
            Trace.WriteUInt32(UniqeID);
            agent.Send(Trace);
        }
        public static void SetDown(this Agent agent)
        {
            Packet SetDown = new Packet(0x704f);
            SetDown.WriteUInt8(4);
            agent.Send(SetDown);
        }
        public static void UpDown(this Agent agent)
        {
            Packet SetDown = new Packet(0x704f);
            SetDown.WriteUInt8(4);
            agent.Send(SetDown);
        }
        public static void WakeUpFromDeath(this Agent agent)
        {
            Packet WakeUpFromDeath = new Packet(0x3053);
            WakeUpFromDeath.WriteUInt8(1);
            agent.Send(WakeUpFromDeath);
        }
        public static void CreateStall(this Agent agent, string StallName, string StallGreating)
        {
            Packet Stall1 = new Packet(0x70B1, true);
            Stall1.WriteAscii(StallName); //stall name
            agent.Send(Stall1);
            Packet Stall2 = new Packet(0x70BA, true);
            Stall2.WriteUInt8(0x06); //static
            Stall2.WriteAscii(StallGreating); //welcome msg
            agent.Send(Stall2);
        }
        public static void AddItemToStall(this Agent agent, string StallSlots, string InvSlot, string ItemCount, string GoldCount)
        {
            Packet AddItem = new Packet(0x70BA);
            AddItem.WriteUInt8(0x02); //static
            AddItem.WriteUInt8(StallSlots); //stall slot
            AddItem.WriteUInt8(InvSlot); //Inv slot
            AddItem.WriteUInt16(ItemCount); //item count
            AddItem.WriteUInt64(GoldCount); //Gold
            AddItem.WriteUInt32(0x32); //static
            AddItem.WriteUInt16(0); //static
            agent.Send(AddItem);
        }
        public static void OpenStall(this Agent agent)
        {
            Packet stall_open = new Packet(0x70BA);
            stall_open.WriteUInt8(0x05);
            stall_open.WriteUInt8(1);
            stall_open.WriteUInt16(0);
            agent.Send(stall_open);
        }
        public static void CloseStall(this Agent agent)
        {
            Packet stall_close = new Packet(0x70B2);
            agent.Send(stall_close);
        }
        public static void MakePT(this Agent agent, string NamePT)
        {
            try
            {
                Packet LPN = new Packet(28777);
                LPN.WriteUInt32(0u);
                LPN.WriteUInt32(0u);
                LPN.WriteInt16(5);
                LPN.WriteInt8(0);
                LPN.WriteInt8(1);
                LPN.WriteInt16(90);
                LPN.WriteInt16(8704);
                LPN.WriteAscii(NamePT);
                agent.Send(LPN);
            }
            catch
            {
            }
        }
        public static void DeletePT(this Agent agent)
        {
            try
            {
                Packet DeletePT = new Packet(28779);
                DeletePT.WriteUInt8(0);
                agent.Send(DeletePT);
            }
            catch
            {
            }
        }
        public static void CheckPT(this Agent agent)
        {
            try
            {
                Packet CheckPT = new Packet(0x706C);
                CheckPT.WriteUInt8((byte)0);
                CheckPT.WriteUInt8((byte)0);
                agent.Send(CheckPT);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public static void RepairGMitems(this Agent agent)
        {
            try
            {
                Packet RepairGMitems = new Packet(28748, true, false);
                RepairGMitems.WriteUInt8(13);
                RepairGMitems.WriteUInt16(16108);
                agent.Send(RepairGMitems);
            }
            catch
            {
            }
        }
        public static void OpenCape(this Agent agent, int CapeColorNo)//1-Red 2-Black 3-Blue 4-White 5-Yellow

        {
            Packet cape = new Packet(0x7516, true);
            cape.WriteUInt8(CapeColorNo);
            agent.Send(cape);
        }
        public static void SendNotice(this Agent agent, string Message)
        {


            try
            {
                Packet packet = new Packet(0x7025);
                packet.WriteUInt8((byte)7);
                packet.WriteUInt8((byte)0);
                packet.WriteAscii(Message);
                agent.Send(packet);
            }





            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }
        }
        public static void SendGlobal(this Agent agent, string Message, int GlobalSlot)
        {
            try
            {

                Packet packet = new Packet((ushort)0x704C, true);
                packet.WriteUInt8(GlobalSlot); //here is the global slot
                packet.WriteUInt8((byte)0xED);
                packet.WriteUInt8((byte)0x29);
                packet.WriteAscii(Message);
                agent.Send(packet);
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }

        }
        public static void SendPM(this Agent agent, string Charname, string Message)
        {
            try
            {
                Packet packet = new Packet(0x7025);
                packet.WriteUInt8((byte)2);
                packet.WriteUInt8((byte)0);
                packet.WriteAscii(Charname);
                packet.WriteAscii(Message);
                agent.Send(packet);


            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }
        }

      
        public static void SendSpawn(this Agent agent)
        {
            Packet packet4 = new Packet(0x34b6);
            agent.Send(packet4);
        }
        public static void Send(this Agent agent, Packet packet)
        {
            agent.ag_security.Send(packet);
        }



        public static void HandleCharList(this Agent agent,Packet packet)
        {
            if (packet.ReadUInt8() == 2)
            {
                if (packet.ReadUInt8() == 1)
                {

                    byte num2 = packet.ReadUInt8();

                    SlikroadBotAPI.Glabel.ListCharAliveNow = new List<string>();

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
                        SlikroadBotAPI.Glabel.ListCharAliveNow.Add(item);
                    }
                    Meldung("add Charname to List", new object[0]);
                }
            }
            else if (packet.ReadUInt8() == 1)
            {
                Meldung("Char success", new object[0]);
                SlikroadBotAPI.Glabel.ListCharAliveNow.Clear();
                Packet packet2 = new Packet(0x7007);
                packet2.WriteUInt8((byte)2);
                agent.Send(packet2);
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


        public static void SelectCharAndStartBot(this Agent agent, string Charname)
        {
            if (SlikroadBotAPI.Glabel.ListCharAliveNow.Contains(Charname))
            {
                Packet packet = new Packet(0x7001);
                packet.WriteAscii(Charname);
                agent.Send(packet);
            }
        }

        private static void Meldung(string msg, params object[] values)
        {
            msg = string.Format(msg, values);
            //Globals.MainWindow.listBox1.Items.Add("[" + System.DateTime.Now.ToLongTimeString() + "] " + msg);
            //Globals.MainWindow.listBox1.TopIndex = Globals.MainWindow.listBox1.Items.Count - 1;
            SlikroadBotAPI.Glabel.SetGatewayEvent("Login", msg);
        }

    }
}
