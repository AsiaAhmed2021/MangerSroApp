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
        // make item packet
        public void makeitem(string Itemid, string Amount, string optlvl)
        {
            string[] dr = new string[] { Itemid, Amount }; // example
            Packet makeitem = new Packet(0x7010);
            makeitem.WriteUInt8(07);
            makeitem.WriteUInt8(00);
            makeitem.WriteUInt32(dr[0]); // dr[0] item id + count
            makeitem.WriteUInt8(optlvl); // item plus
            Agent.Send(makeitem);
            this.Meldung("Makeitem (" + Itemid + "," + Amount + "," + optlvl + ") successfully.", new object[0]);
        }
    }
}
