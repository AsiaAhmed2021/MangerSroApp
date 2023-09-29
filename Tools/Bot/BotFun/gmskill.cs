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
        // gm skill packet
        public void gmskill()
        {
            Packet gmskill = new Packet(0x7074, true);
            gmskill.WriteUInt8(01);
            gmskill.WriteUInt8(04);
            gmskill.WriteUInt32(3978);
            gmskill.WriteUInt8(0);
            Agent.Send(gmskill);
            this.Meldung("Gm skill used successfully.", new object[0]);
        }
    }
}
