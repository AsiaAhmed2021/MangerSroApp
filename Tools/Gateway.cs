﻿namespace vSroMultiTool
{
    using SilkroadSecurityApi;
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using System.Threading;

    public class Gateway
    {
        private static List<Packet> gw_packets = new List<Packet>();
        private static TransferBuffer gw_recv_buffer = new TransferBuffer(0x1000, 0, 0);
        private static Security gw_security = new Security();
        private static Socket gw_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static uint locale = uint.Parse(Globals.MainWindow.slocale.Text);
        private static Thread loop;
        private static uint version = uint.Parse(Globals.MainWindow.sversion.Text);

        public void Gateway_thread()
        {
            while (true)
            {
                SocketError success;
                byte[] bytes;
                gw_recv_buffer.Size = gw_socket.Receive(gw_recv_buffer.Buffer, 0, gw_recv_buffer.Buffer.Length, SocketFlags.None, out success);
                if (success != SocketError.Success)
                {
                    if (success != SocketError.WouldBlock)
                    {
                        return;
                    }
                }
                else if (gw_recv_buffer.Size > 0)
                {
                    gw_security.Recv(gw_recv_buffer);
                }
                else
                {
                    return;
                }
                List<Packet> collection = gw_security.TransferIncoming();
                if (collection != null)
                {
                    gw_packets.AddRange(collection);
                }
                if (gw_packets.Count > 0)
                {
                    foreach (Packet packet in gw_packets)
                    {
                        Packet packet2;
                        bytes = packet.GetBytes();
                        this.Log("[S->C][{0:X4}][{1} bytes]{2}{3}{4}{5}{6}", new object[] { packet.Opcode, bytes.Length, packet.Encrypted ? "[Encrypted]" : "", packet.Massive ? "[Massive]" : "", Environment.NewLine, Utility.HexDump(bytes), Environment.NewLine });
                        if ((packet.Opcode == 0x5000) || (packet.Opcode == 0x9000))
                        {
                            continue;
                        }
                        if (packet.Opcode == 0x2001)
                        {
                            if (packet.ReadAscii() == "GatewayServer")
                            {
                                Globals.Server = Globals.ServerEnum.Gateway;
                                packet2 = new Packet(0x6100, true, false);
                                packet2.WriteUInt8(locale);
                                packet2.WriteAscii("SR_Client");
                                packet2.WriteUInt32(version);
                                gw_security.Send(packet2);
                                Globals.MainWindow.Ping.Enabled = true;
                            }
                        }
                        else
                        {
                            if (packet.Opcode == 0xa100)
                            {
                                switch (packet.ReadUInt8())
                                {
                                    case 1:
                                        packet2 = new Packet(0x6101, true);
                                        gw_security.Send(packet2);
                                        goto Label_04A2;

                                    case 2:
                                        this.Meldung("The version is incorrect, please restart the programm !", new object[0]);
                                        goto Label_04A2;
                                }
                                return;
                            }
                            if (packet.Opcode == 0xa102)
                            {
                                byte num2 = packet.ReadUInt8();
                                if (num2 == 1)
                                {
                                    uint num3 = packet.ReadUInt32();
                                    string iP = packet.ReadAscii();
                                    ushort num4 = packet.ReadUInt16();
                                    new Agent().Start(iP, num4.ToString(), num3, Globals.MainWindow.id.Text, Globals.MainWindow.pw.Text);
                                    //Globals.MainWindow.pictureBox1.Enabled = false;
                                    //Globals.MainWindow.captcha_text.Enabled = false;
                                    //Globals.MainWindow.button3.Enabled = false;
                                    Globals.MainWindow.char_list.Enabled = true;
                                    Globals.MainWindow.button4.Enabled = true;
                                    this.Meldung("Select your Char now !", new object[0]);
                                    break;
                                }
                                if (num2 == 2)
                                {
                                    switch (packet.ReadUInt8())
                                    {
                                        case 1:
                                            {
                                                byte num6 = packet.ReadUInt8();
                                                byte num7 = packet.ReadUInt8();
                                                byte num8 = packet.ReadUInt8();
                                                byte num9 = packet.ReadUInt8();
                                                byte num10 = packet.ReadUInt8();
                                                this.Meldung(string.Concat(new object[] { "Wrong password  ( ", num10, " / ", num6, " )" }), new object[0]);
                                                break;
                                            }
                                        case 2:
                                            if (packet.ReadUInt8() == 1)
                                            {
                                                this.Meldung("Blocked cause: " + packet.ReadAscii(), new object[0]);
                                            }
                                            break;

                                        case 3:
                                            this.Meldung("Already logged in !", new object[0]);
                                            break;
                                    }
                                }
                            }
                            else if (packet.Opcode == 0x2322)
                            {
                                //uint[] pixels = Captcha.GeneratePacketCaptcha(packet);
                                //Random random = new Random();
                                //Captcha.SaveCaptchaToBMP(pixels, Environment.GetFolderPath////(Environment.SpecialFolder.ApplicationData) + random.Next(0, 0xf423f) + ".bmp");
                            }
                        }
                    Label_04A2:
                        if ((packet.Opcode == 0xa101) && (packet.ReadUInt8() == 1))
                        {
                            byte num12 = packet.ReadUInt8();
                            string str3 = packet.ReadAscii();
                            byte num13 = packet.ReadUInt8();
                            byte num14 = packet.ReadUInt8();
                            ushort num15 = packet.ReadUInt16();
                            string str4 = packet.ReadAscii();
                            ushort num16 = packet.ReadUInt16();
                            ushort num17 = packet.ReadUInt16();
                            byte num18 = packet.ReadUInt8();
                            this.Meldung(string.Concat(new object[] { "Connected to [", str4, "] Online Players(", num16, "/", num17, ")" }), new object[0]);
                            this.Meldung("Connect Success, enter you ID & PW now !", new object[0]);
                            Globals.MainWindow.server_label.Text = str4;
                            Globals.MainWindow.player_label.Text = string.Concat(new object[] { "Online Players (", num16, "/", num17, ")" });
                             Globals.MainWindow.groupBox3.Enabled = true; //Globals.MainWindow.pictureBox1.Enabled = false;
                            //Globals.MainWindow.captcha_text.Enabled = false; Globals.MainWindow.button3.Enabled = false; Globals.MainWindow.char_list.Enabled = false;
                            //Globals.MainWindow.button4.Enabled = false;
                        }
                    }
                    gw_packets.Clear();
                }
                List<KeyValuePair<TransferBuffer, Packet>> list2 = gw_security.TransferOutgoing();
                if (list2 != null)
                {
                    foreach (KeyValuePair<TransferBuffer, Packet> pair in list2)
                    {
                        TransferBuffer key = pair.Key;
                        Packet packet = pair.Value;
                        success = SocketError.Success;
                        while (key.Offset != key.Size)
                        {
                            int num19 = gw_socket.Send(key.Buffer, key.Offset, key.Size - key.Offset, SocketFlags.None, out success);
                            if ((success != SocketError.Success) && (success != SocketError.WouldBlock))
                            {
                                break;
                            }
                            key.Offset += num19;
                            Thread.Sleep(1);
                        }
                        if (success != SocketError.Success)
                        {
                            break;
                        }
                        bytes = packet.GetBytes();
                        this.Log("[C->S][{0:X4}][{1} bytes]{2}{3}{4}{5}{6}", new object[] { packet.Opcode, bytes.Length, packet.Encrypted ? "[Encrypted]" : "", packet.Massive ? "[Massive]" : "", Environment.NewLine, Utility.HexDump(bytes), Environment.NewLine });
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
            Globals.MainWindow.listBox1.Items.Add("[" + System.DateTime.Now.ToLongTimeString() + "] " + msg);
            Globals.MainWindow.listBox1.TopIndex = Globals.MainWindow.listBox1.Items.Count - 1;
        }

        public static void SendToServer(Packet packet)
        {
            gw_security.Send(packet);
        }

        public void Start(string IP, string Port)
        {
            loop = new Thread(new ThreadStart(this.Gateway_thread));
            gw_socket.Connect(IP, int.Parse(Port));
            loop.Start();
            gw_socket.Blocking = false;
            gw_socket.NoDelay = true;
        }
    }
}

