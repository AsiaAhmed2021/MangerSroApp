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
        public void movetouser(string target)
        {
            Packet movetouser = new Packet(0x7010, true);
            movetouser.WriteUInt16(8);
            movetouser.WriteAscii(target);
            Agent.Send(movetouser);
            this.Meldung("Move to user " + target + " successfully.", new object[0]);
        }
    }
}
