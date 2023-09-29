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
        // open stall packet
        public void CreateStall(string StallName, string StallGreating)
        {
            // first stall packet typing stall name
            Packet Stall1 = new Packet(0x70B1, true);
            Stall1.WriteAscii(StallName); //stall name
            Agent.Send(Stall1);
            // second stall packet typing stall welcome msg
            Packet Stall2 = new Packet(0x70BA, true);
            Stall2.WriteUInt8(0x06); //static
            Stall2.WriteAscii(StallGreating); //welcome msg
            Agent.Send(Stall2);
            this.Meldung("Stall created successfully.", new object[0]);
        }
    }
}
