using SilkroadSecurityApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangerSroApp.Tools.Bot
{
    public partial class Bot
    {
        // open stall packet
        protected byte MDorpItems(string ItemID, string charname, string Count)
        {
            var reader = new SqlCommand($@"exec [VSRO_LOG].[dbo].[_BotDorpItemsEvent] '{charname}', {ItemID} , {Count}", Sql.sqlshardlog).ExecuteReader();
            string SlotID = "";
            while (reader.Read())
            {
                if ((string)reader["M"] == "true")
                {
                    SlotID = (string)reader["Slot"];
                }
                else
                {
                    this.Meldung("BotQuery:No Have Slot", new object[0]);
                }
            }

            return byte.Parse(SlotID);
        }
        public static byte ConvertNumberToHex(int Index)
        {
            var MyInt = new byte[]
            {
                0x00,//solt 00
                0x01,//solt 01
                0x02,//solt 02
                0x03,//solt 03
                0x04,//solt 04
                0x05,//solt 05
                0x06,//solt 06
                0x07,//solt 07
                0x08,//solt 08
                0x09,//solt 09
                0x0A,//solt 10
                0x0B,//solt 11
                0x0C,//solt 12
                0x0D,//Solt 01  + 13 solt                     
                0x0E,//Solt 02  + 13 solt              
                0x0F,//Solt 03  + 13 solt                    
                0x10,//Solt 04  + 13 solt              
                0x11,//Solt 05  + 13 solt              
                0x12,//Solt 06  + 13 solt              
                0x13,//Solt 07  + 13 solt              
                0x14,//Solt 08  + 13 solt              
                0x15,//Solt 09  + 13 solt              
                0x16,//Solt 10  + 13 solt               
                0x17,//Solt 11  + 13 solt               
                0x18,//Solt 12  + 13 solt               
                0x19,//Solt 13  + 13 solt               
                0x1A,//Solt 14  + 13 solt              
                0x1B,//Solt 15  + 13 solt               
                0x1C,//Solt 16  + 13 solt               
                0x1D,//Solt 17  + 13 solt               
                0x1E,//Solt 18  + 13 solt               
                0x1F,//Solt 16  + 13 solt               
                0x20,//Solt 17  + 13 solt               
                0x21,//Solt 18  + 13 solt              
                0x22,//Solt 19  + 13 solt              
                0x23,//Solt 20  + 13 solt              
                0x24,//Solt 21  + 13 solt              
                0x25,//Solt 22  + 13 solt              
                0x26,//Solt 23  + 13 solt              
                0x27,//Solt 24  + 13 solt              
                0x28,//Solt 25  + 13 solt              
                0x29,//Solt 26  + 13 solt              
                0x2A,//Solt 27  + 13 solt              
                0x2B,//Solt 28  + 13 solt              
                0x2C,//Solt 29  + 13 solt              
                0x2D,//Solt 30  + 13 solt                    
                0x2E,//Solt 31  + 13 solt                    
                0x2F,//Solt 32  + 13 solt                    
                0x30,//Solt 33  + 13 solt                    
                0x31,//Solt 34  + 13 solt                    
                0x32,//Solt 35  + 13 solt                    
                0x33,//Solt 36  + 13 solt                    
                0x34,//Solt 37  + 13 solt                    
                0x35,//Solt 38  + 13 solt                    
                0x36,//Solt 39  + 13 solt                    
                0x37,//Solt 40  + 13 solt                    
                0x38,//Solt 41  + 13 solt                    
                0x39,//Solt 42  + 13 solt                    
                0x3A,//Solt 43  + 13 solt                    
                0x3B,//Solt 44  + 13 solt                    
                0x3C,//Solt 45  + 13 solt                    
                0x3D,//Solt 46  + 13 solt                    
                0x3E,//Solt 47  + 13 solt                    
                0x3F,//Solt 48  + 13 solt                    
                0x40,//Solt 49  + 13 solt                    
                0x41,//Solt 50  + 13 solt            
                0x42,//Solt 51  + 13 solt            
                0x43,//Solt 52  + 13 solt            
                0x44,//Solt 53  + 13 solt            
                0x45,//Solt 54  + 13 solt            
                0x46,//Solt 55  + 13 solt            
                0x47,//Solt 56  + 13 solt            
                0x48,//Solt 57  + 13 solt            
                0x49,//Solt 58  + 13 solt            
                0x4A,//Solt 59  + 13 solt            
                0x4B,//Solt 60  + 13 solt            
                0x4C,//Solt 61  + 13 solt            
                0x4D,//Solt 62  + 13 solt            
                0x4E,//Solt 63  + 13 solt            
                0x4F,//Solt 64  + 13 solt            
                0x50,//Solt 65  + 13 solt            
                0x51,//Solt 66  + 13 solt            
                0x52,//Solt 67  + 13 solt            
                0x53,//Solt 68  + 13 solt            
                0x54,//Solt 69  + 13 solt            
                0x55,//Solt 70  + 13 solt            
                0x56,//Solt 71  + 13 solt            
                0x57,//Solt 72  + 13 solt            
                0x58,//Solt 73  + 13 solt            
                0x59,//Solt 74  + 13 solt            
                0x5A,//Solt 75  + 13 solt            
                0x5B,//Solt 76  + 13 solt            
                0x5C,//Solt 77  + 13 solt            
                0x5D,//Solt 78  + 13 solt            
                0x5E,//Solt 79  + 13 solt            
                0x5F,//Solt 80  + 13 solt            
                0x60,//Solt 81  + 13 solt            
                0x61,//Solt 82  + 13 solt            
                0x62 //Solt 83  + 13 solt            
            };
            return MyInt[Index];
        }
        public void DorpItems(int ItemsIndex)
        {
            /*            [C -> S][7034]
                          07       
                          xx
            [C -> S][7034] -- Move items
            00                   static
            35              Old Solt            
            4A              Next Solt     
            01 00                static
            [C -> S][7034]
            07       
            xx */

            try
            {
                // Drop Items
                Packet Stall1 = new(0x7034, true);
                Stall1.WriteUInt8(0x07); //static
                Stall1.WriteUInt8(ConvertNumberToHex(ItemsIndex));  //Set index Slot (hax)
                Agent.Send(Stall1);
            }
            catch (Exception ex)
            {
                this.Meldung("{0} / {1} " + $": -> {ex.Message}", "DorpItems.FilesJs", "M:False");
            }



            try
            {
                Packet Stall2 = new Packet(0x7034, false);
                Stall2.WriteUInt8(0x07); 
                Stall2.WriteUInt8(ConvertNumberToHex(ItemsIndex)); 
                Agent.Send(Stall2);
            }
            catch (Exception ex)
            {
                this.Meldung("{0} / {1} " + $": -> {ex.Message}", "DorpItems.FilesJs","M:False");
            }



            this.Meldung("Drop Items successfully.", new object[0]);
        }
    }
}
