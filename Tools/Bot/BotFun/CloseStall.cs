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
        // Stall close packet
        public void CloseStall()
        {
            Packet stall_close = new Packet(0x70B2);
            Agent.Send(stall_close);
            this.Meldung("Stall closed successfully.", new object[0]);
        }
    }
}
