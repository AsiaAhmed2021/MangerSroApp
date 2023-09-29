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
        // go town gm character packet
        public void gotown()
        {
            Packet gotown = new Packet(0x7010, true);
            gotown.WriteUInt8(02);
            gotown.WriteUInt8(00);
            Agent.Send(gotown);
            this.Meldung("Go town successfully.", new object[0]);
        }
    }
}
