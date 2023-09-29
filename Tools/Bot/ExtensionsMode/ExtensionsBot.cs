using SilkroadSecurityApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangerSroApp.Tools.Bot
{
    public partial class Bot
    {
        public void StartBot()
        {
            if (Sql.ConnectSqlServer())
            {
                //Stap 1
                ConnectServer(Globals.Confing.IP, Globals.Confing.bot.ServerPort);
            }
        }

        public static void ConnectServer(string IP, string Port)
        {
            var GateWay = new Gateway();
            GateWay.Start(IP, Port);
        }

        public static void LoginUser(string User, string Passworld)
        {
            Packet packet = new Packet(0x6102);
            packet.WriteUInt8(0x16);
            packet.WriteAscii(User);
            packet.WriteAscii(Passworld);
            packet.WriteUInt16(0x40);
            Gateway.SendToServer(packet);
        }

        public static void CaptchaLogin(string Captch)
        {
            Captcha.SendCaptcha(Captch);
        }

        public static void SelectCharAndStartBot(string Charname)
        {
            if (Globals.ListCharAliveNow.Contains(Charname))
            {
                Packet packet = new Packet(0x7001);
                packet.WriteAscii(Charname);
                Agent.Send(packet);
            }
        }

        // ping timer
        private void Ping_Tick(object sender, EventArgs e)
        {
            Glabels.MainForm.LblStatServices.BackColor =
                Glabels.ServerManager.IsOpenServer ?
                Color.Green :
                Color.Red;

            if (Globals.Server != Globals.ServerEnum.None)
            {
                Packet packet = new Packet(0x2002);
                if (Globals.Server == Globals.ServerEnum.Gateway)
                {
                    Gateway.SendToServer(packet);
                }
                else if (Globals.Server == Globals.ServerEnum.Agent)
                {
                    Agent.Send(packet);
                }
            }
        }

    }
}
