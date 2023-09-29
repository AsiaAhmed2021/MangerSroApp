using MangerSroApp.Tools.Bot;
using SilkroadSecurityApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Extensions
{
    public static class PacketGatwayAPI
    {
        public static void SendToServer(this Gateway gateway, Packet packet)
        {
            if (gateway.gw_security != null)
                gateway.gw_security.Send(packet);
        }


        public static void SendCaptcha(this Gateway gateway, string msg)
        {
            Packet packet = new Packet(0x6323);
            packet.WriteAscii(msg);
            gateway.SendToServer(packet);
        }

        public static void LoginUser(this Gateway gateway, string User, string Passworld)
        {
            Packet packet = new Packet(0x6102);
            packet.WriteUInt8(0x16);
            packet.WriteAscii(User);
            packet.WriteAscii(Passworld);
            packet.WriteUInt16(0x40);
            gateway.SendToServer(packet);
        }

        public static void CaptchaLogin(this Gateway gateway, string Captch)
        {
            Packet packet = new Packet(0x6323);
            packet.WriteAscii(Captch);
            gateway.SendToServer(packet);
        }
 


    }
}
