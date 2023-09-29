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
        // Stall item add packet
        public void AddItemToStall(string StallSlots, string InvSlot, string ItemCount, string GoldCount)
        {
            Packet AddItem = new Packet(0x70BA);
            AddItem.WriteUInt8(0x02); //static
            AddItem.WriteUInt8(StallSlots); //stall slot
            AddItem.WriteUInt8(InvSlot); //Inv slot
            AddItem.WriteUInt16(ItemCount); //item count
            AddItem.WriteUInt64(GoldCount); //Gold
            AddItem.WriteUInt32(0x32); //static
            AddItem.WriteUInt16(0); //static
            Agent.Send(AddItem);
            this.Meldung("Item successfully added to stall.", new object[0]);
        }
    }
}
