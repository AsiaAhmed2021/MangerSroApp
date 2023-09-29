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
        public void totown(string target)
        {
            Packet totown = new Packet(0x7010, true);
            totown.WriteUInt16(3);
            totown.WriteAscii(target);
            Agent.Send(totown);
            this.Meldung("Player : " + target + " to town successfully.", new object[0]);
        }
    }
}
