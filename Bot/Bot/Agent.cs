using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangerSroApp.Tools.Bot
{
    using SilkroadSecurityApi;
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Net.Sockets;
    using System.Threading;
    using System.Data.SqlClient;
    using Silkroad.Tools.Bot;

    public class Agent
    {
        public Confing Confing = SlikroadBotAPI.Glabel.Confing;
        private List<Packet> ag_packets = new List<Packet>();
        private TransferBuffer ag_recv_buffer = new TransferBuffer(0x1000, 0, 0);
        internal Security ag_security = new Security();
        private Socket ag_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private uint loginID;
        private Thread loop;
        private string password;
        private string username;

        public SqlDataReader reader;

        public void Agent_thread()
        {
            while (true)
            {
                SocketError success;
                Packet current;
                byte[] bytes;
                ag_recv_buffer.Size = ag_socket.Receive(ag_recv_buffer.Buffer, 0, ag_recv_buffer.Buffer.Length, SocketFlags.None, out success);
                if (success != SocketError.Success)
                {
                    if (success != SocketError.WouldBlock)
                    {
                        this.Meldung("Character Disconnected.", new object[0]);
                        return;
                    }
                }
                else if (ag_recv_buffer.Size > 0)
                {
                    ag_security.Recv(ag_recv_buffer);
                }
                else
                {
                    this.Meldung("Character Disconnected.", new object[0]);
                    return;
                }
                List<Packet> collection = ag_security.TransferIncoming();
                if (collection != null)
                {
                    ag_packets.AddRange(collection);
                }
                if (ag_packets.Count > 0)
                {
                    using (List<Packet>.Enumerator enumerator = ag_packets.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            current = enumerator.Current;
                            bytes = current.GetBytes();

                            // Save incoming chat
                            if (current.Opcode == 0x3026)
                            {
                                string charname; string chat;
                                switch (current.ReadUInt8())
                                {
                                    case 2: // private chat
                                        charname = current.ReadAscii();
                                        chat = current.ReadAscii();

                                        if (Confing.bot.SaveChat == "ON")
                                        {
                                            chat = chat.Replace("'", "''");
                                            try { new SqlCommand("Exec _Add_IncomingChat 1,'" + charname + "','" + chat + "'", Sql.sqlshardlog).ExecuteNonQuery(); }
                                            catch { this.Meldung("Error 03 please report it to the developer.", new object[0]); }
                                        }
                                        break;

                                    case 6: // global chat
                                        charname = current.ReadAscii();
                                        chat = current.ReadAscii();
                                        chat = chat.Replace("'", "''");

                                        if (Confing.bot.SaveChat == "ON")
                                        {
                                            try { new SqlCommand("Exec _Add_IncomingChat 2,'" + charname + "','" + chat + "'", Sql.sqlshardlog).ExecuteNonQuery(); }
                                            catch { this.Meldung("Error 04 please report it to the developer.", new object[0]); }
                                        }
                                        break;
                                }
                            }

                            // Unique spawn and unique kill save logs
                            if (current.Opcode == 0x300C)
                            {
                                string CharName; uint UniqueID;
                                switch (current.ReadUInt8())
                                {
                                    case 5:
                                        current.ReadUInt8Array(1); UniqueID = current.ReadUInt32();
                                        this.Meldung("MobID [" + UniqueID + "] Spawned.", new object[0]);
                                        if (Confing.bot.SaveUnique == "ON")
                                        {
                                            try { new SqlCommand("Execute [dbo].[_Add_UniqueLog] '1'," + UniqueID + ",NULL", Sql.sqlshardlog).ExecuteNonQuery(); }
                                            catch { this.Meldung("Error 05 please report it to the developer.", new object[0]); }
                                        }
                                        break;
                                    case 6:
                                        current.ReadUInt8Array(1); UniqueID = current.ReadUInt32(); CharName = current.ReadAscii();
                                        this.Meldung("[" + CharName + "] has killed MobID [" + UniqueID + "].", new object[0]);
                                        if (Confing.bot.SaveUnique == "ON")
                                        {
                                            try { new SqlCommand("Execute [dbo].[_Add_UniqueLog] '2'," + UniqueID + ",'" + CharName + "'", Sql.sqlshardlog).ExecuteNonQuery(); }
                                            catch { this.Meldung("Error 06 please report it to the developer.", new object[0]); }
                                        }
                                        break;
                                }
                            }

                            // ress pvp or back to town if dead
                            if (current.Opcode == 0x30D2)
                            {
                                Thread.Sleep(1000);
                                Packet pvp_ress = new Packet(0x3053, true);
                                pvp_ress.WriteUInt8(1);
                                this.Send(pvp_ress);
                            }

                            // get stall buyer winner name
                            if (current.Opcode == 0x30B7 && current.ReadUInt8() == 0x03)
                            {
                                uint slot = current.ReadUInt8();
                                string buyer = current.ReadAscii();
                                try { new SqlCommand("Insert Into [dbo].[StallItemBuyers] Values ('" + buyer + "','" + slot + "',Getdate())", Sql.sqlshardlog).ExecuteNonQuery(); }
                                catch { this.Meldung("Error 07 please report it to the developer.", new object[0]); }
                            }

                            //Gateway.SetGatewayEvent
                            // Xtrap packet
                            if (((current.Opcode == 0x2113) && (current.ReadUInt8() == 1)) && Confing.bot.Xtrap == "ON")
                            {
                                this.Meldung("Xtrap packet was sent !", new object[0]);
                                Packet packet = new Packet(0);
                                packet.WriteUInt8((byte)1);
                                packet.WriteUInt8((byte)1);
                                this.Send(packet);
                            }

                            // character spawn packet
                            if (current.Opcode == 0x3013)
                            {
                                this.Meldung("Character Spawned successfully !", new object[0]);
                                //Gateway.SetGatewayEvent("Gateway", "Character Spawned successfully !");
                            }

                            //spawn confirmation packet
                            if (current.Opcode == 0x34B5)
                            {
                                this.SendSpawn();
                            }

                            this.Log("[S->C][{0:X4}][{1} bytes]{2}{3}{4}{5}{6}", new object[] { current.Opcode, bytes.Length, current.Encrypted ? "[Encrypted]" : "", current.Massive ? "[Massive]" : "", Environment.NewLine, Utility.HexDump(bytes), Environment.NewLine });
                            if ((current.Opcode != 0x5000) && (current.Opcode != 0x9000))
                            {
                                Packet packet4;
                                Packet packet5;
                                if (current.Opcode == 0x2001)
                                {
                                    if (current.ReadAscii() == "GatewayServer")
                                    {
                                        OwnerGateway.Server = Gateway.ServerEnum.Gateway;
                                        packet4 = new Packet(0x6100, true, false);
                                        packet4.WriteUInt32(SlikroadBotAPI.Glabel.locale);
                                        packet4.WriteAscii("SR_Client");
                                        packet4.WriteUInt32(SlikroadBotAPI.Glabel.version);
                                        ag_security.Send(packet4);
                                    }
                                    else
                                    {
                                        OwnerGateway.Server = Gateway.ServerEnum.Agent;
                                        packet5 = new Packet(0x6103);
                                        packet5.WriteUInt32(loginID);
                                        packet5.WriteAscii(username);
                                        packet5.WriteAscii(password);
                                        packet5.WriteUInt8((byte)0x16);
                                        packet5.WriteUInt32((uint)0);
                                        packet5.WriteUInt16((ushort)0);
                                        ag_security.Send(packet5);
                                    }
                                }
                                else if (current.Opcode == 0xa103)
                                {
                                    if (current.ReadUInt8() == 1)
                                    {
                                        packet4 = new Packet(0x7007);
                                        packet4.WriteUInt8((byte)2);
                                        ag_security.Send(packet4);
                                    }
                                }
                                else if (current.Opcode == 0xb007)
                                {
                                    this.HandleCharList(current);
                                }
                                else if (current.Opcode == 0x3020)
                                {
                                    packet5 = new Packet(0x3012);
                                    this.Send(packet5);
                                }
                            }
                        }
                    }
                    ag_packets.Clear();
                }
                List<KeyValuePair<TransferBuffer, Packet>> list2 = ag_security.TransferOutgoing();
                if (list2 != null)
                {
                    foreach (KeyValuePair<TransferBuffer, Packet> pair in list2)
                    {
                        TransferBuffer key = pair.Key;
                        current = pair.Value;
                        success = SocketError.Success;
                        while (key.Offset != key.Size)
                        {
                            int num6 = ag_socket.Send(key.Buffer, key.Offset, key.Size - key.Offset, SocketFlags.None, out success);
                            if ((success != SocketError.Success) && (success != SocketError.WouldBlock))
                            {
                                break;
                            }
                            key.Offset += num6;
                            Thread.Sleep(1);
                        }
                        if (success != SocketError.Success)
                        {
                            break;
                        }
                        bytes = current.GetBytes();
                        this.Log("[C->S][{0:X4}][{1} bytes]{2}{3}{4}{5}{6}", new object[] { current.Opcode, bytes.Length, current.Encrypted ? "[Encrypted]" : "", current.Massive ? "[Massive]" : "", Environment.NewLine, Utility.HexDump(bytes), Environment.NewLine });
                    }
                    if (success != SocketError.Success)
                    {
                        return;
                    }
                }
                Thread.Sleep(1);
            }
        }

        public void Log(string msg, params object[] values)
        {
            msg = string.Format(msg, values);
        }



        private void Meldung(string msg, params object[] values)
        {
            msg = string.Format(msg, values);
            SlikroadBotAPI.Glabel.SetGatewayEvent("Agent", msg);
        }




        Gateway OwnerGateway;
        public void Start(string IP, string Port, uint _loginID, string _username, string _password, Gateway OwnerGateway)
        {
            this.OwnerGateway = OwnerGateway;
            loginID = _loginID;
            username = _username;
            password = _password;
            loop = new Thread(new ThreadStart(this.Agent_thread));
            ag_socket.Connect(IP, int.Parse(Port));
            loop.Start();
            ag_socket.Blocking = false;
            ag_socket.NoDelay = true;
        }
    }
}
