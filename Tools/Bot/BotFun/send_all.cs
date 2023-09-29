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
        public void send_all(string message)
        {
            Packet send_all = new Packet(0x7025);
            send_all.WriteUInt8(0x03);
            send_all.WriteUInt8(0x00);
            send_all.WriteAscii(message);
            Agent.Send(send_all);
            this.Meldung("Chat to all sent successfully.", new object[0]);
        }
    }
}
