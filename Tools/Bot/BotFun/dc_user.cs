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
        // disconnect user packet
        public void dc_user(string target)
        {
            Packet dc_user = new Packet(0x7010);
            dc_user.WriteUInt16(13);
            dc_user.WriteAscii(target);
            Agent.Send(dc_user);
            this.Meldung("Player : " + target + " Disconnect successfully.", new object[0]);
        }
    }
}
