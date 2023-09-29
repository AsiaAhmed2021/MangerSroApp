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
        // recall user packet
        public void recalluser(string target)
        {
            Packet recalluser = new Packet(0x7010);
            recalluser.WriteUInt16(17);
            recalluser.WriteAscii(target);
            Agent.Send(recalluser);
            this.Meldung("Recall user " + target + " successfully.", new object[0]);
        }
    }
}
