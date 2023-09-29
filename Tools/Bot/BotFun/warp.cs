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
        // warp region packet
        public void warp(string regionid, string posX, string posY, string posZ, string worldid)
        {
            Packet warp = new Packet(0x7010);
            warp.WriteUInt8(0x10);
            warp.WriteUInt8(0);
            warp.WriteInt16(regionid);
            warp.WriteSingle(posX);
            warp.WriteSingle(posY);
            warp.WriteSingle(posZ);
            warp.WriteInt8(worldid);
            warp.WriteUInt8(0);
            Agent.Send(warp);
            this.Meldung("Character warp to R = " + regionid + " X = " + posX + " Y = " + posY + " Z = " + posZ + " done.", new object[0]);
        }
    }
}
