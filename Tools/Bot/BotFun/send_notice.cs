using SilkroadSecurityApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangerSroApp.Tools.Bot
{
    public partial class Bot
    {
        // send notice packet
        public void send_notice(string message)
        {
            Packet notice = new Packet(0x7025);
            notice.WriteUInt8((byte)7);
            notice.WriteUInt8((byte)0);
            notice.WriteAscii(message);
            Agent.Send(notice);
            this.Meldung("Notice sent successfully.", new object[0]);
        }
    }
}
