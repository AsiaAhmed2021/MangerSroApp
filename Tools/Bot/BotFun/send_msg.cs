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
        public void send_msg(string target, string message)
        {
            Packet msg = new Packet(0x7309);
            msg.WriteAscii(target);
            msg.WriteAscii(message);
            Agent.Send(msg);
            this.Meldung("Message sent successfully.", new object[0]);
        }
    }
}
