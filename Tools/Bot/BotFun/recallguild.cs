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
        public void recallguild(string target)
        {
            Packet recallguild = new Packet(0x7010);
            recallguild.WriteUInt16(18);
            recallguild.WriteAscii(target);
            Agent.Send(recallguild);
            this.Meldung("Recall guild " + target + " successfully.", new object[0]);
        }
    }
}
