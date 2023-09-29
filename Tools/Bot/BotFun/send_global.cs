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
        public void send_global(string message, string global_slot)
        {
            Packet global = new Packet(0x704C, true);
            global.WriteUInt8(global_slot);
            global.WriteUInt8(0xED);
            global.WriteUInt8(0x29);
            global.WriteAscii(message);
            Agent.Send(global);
            this.Meldung("Global sent successfully.", new object[0]);
        }
    }
}
