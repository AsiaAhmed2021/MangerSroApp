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
        // load monster packet
        public void loadmonster(string Mobid, string Amount)
        {
            Packet loadmonster = new Packet(0x7010);
            loadmonster.WriteUInt8((byte)6);
            loadmonster.WriteUInt8((byte)0);
            loadmonster.WriteUInt32(Mobid);
            loadmonster.WriteUInt8(Amount);
            loadmonster.WriteUInt8((byte)3);
            Agent.Send(loadmonster);
        }
    }
}
