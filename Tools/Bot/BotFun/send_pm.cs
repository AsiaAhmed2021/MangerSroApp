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
        public void send_pm(string target, string message)
        {
            Packet pm = new Packet(0x7025);
            pm.WriteUInt8(0x02);
            pm.WriteUInt8(0x00);
            pm.WriteAscii(target);
            pm.WriteAscii(message);
            Agent.Send(pm);
            this.Meldung("Private chat to " + target + " sent successfully.", new object[0]);
        }
    }
}
