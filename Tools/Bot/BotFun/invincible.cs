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
        public void invincible()
        {
            Packet invincible = new Packet(0x7010);
            invincible.WriteUInt8(0x0F);
            invincible.WriteUInt8(0x00);
            Agent.Send(invincible);
            this.Meldung("Invincible successfully.", new object[0]);
        }
    }
}
