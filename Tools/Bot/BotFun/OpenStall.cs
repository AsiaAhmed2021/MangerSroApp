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
        // Stall open packet
        public void OpenStall()
        {
            Packet stall_open = new Packet(0x70BA);
            stall_open.WriteUInt8(0x05);
            stall_open.WriteUInt8(1);
            stall_open.WriteUInt16(0);
            Agent.Send(stall_open);
            this.Meldung("Stall opened successfully.", new object[0]);
        }
    }
}
