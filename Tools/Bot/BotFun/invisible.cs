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
        // invisible packet
        public void invisible()
        {
            Packet invisible = new Packet(0x7010);
            invisible.WriteUInt8(0x0e);
            invisible.WriteUInt8(0x00);
            Agent.Send(invisible);
            this.Meldung("Invisible successfully.", new object[0]);
        }
    }
}
