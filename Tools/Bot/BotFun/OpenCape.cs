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
        // open cape packet
        public void OpenCape(int CapeIndex)
        {
            Packet cape = new Packet(0x7516, true);
            cape.WriteUInt8(CapeIndex);
            Agent.Send(cape);
            this.Meldung("Pvp cape used successfully.", new object[0]);
        }

        // get cape index int value by color name
        public int CapIndex(string Color)
        {
            int Result = 0;
            switch (Color)
            {
                case "Red": Result = 1; break;
                case "Black": Result = 2; break;
                case "Blue": Result = 3; break;
                case "White": Result = 4; break;
                case "Yellow": Result = 5; break;
            }
            return Result;
        }


    }
}
