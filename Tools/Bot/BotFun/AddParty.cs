﻿using SilkroadSecurityApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangerSroApp.Tools.Bot
{
    public partial class Bot
    {
        // open stall packet
        public void AddParty(string NameParty)
        {
//[C -> S][7069]
//00 00 00 00                                       ................
//00 00 00 00                                       ................
//05                                                ................
//00                                                ................
//01                                                ................
//64                                                d...............
//02 00                                             ................
//68 69                                             hi..............

/*
[S -> C][3078]
03                                                ................
04                                                ................

[S -> C][3809]
03                                                ................
37                                                7...............

[C -> S][706A]
04 00 00 00                                       ................
00 00 00 00                                       ................
05                                                ................
00                                                ................
01                                                ................
14                                                ................
02 00                                             ................
61 70                                             ap..............


[C -> S][7069]
00 00 00 00                                       ................
00 00 00 00                                       ................
05                                                ................
00                                                ................
01                                                ................
64                                                d...............
23 00                                             #...............
46 6F 72 20 6F 70 65 6E 20 68 75 6E 74 69 6E 67   For.open.hunting
20 6F 6E 20 41 73 69 61 53 72 6F 20 4F 6E 6C 69   .on.AsiaSro.Onli
6E 65 21                                          ne!.............


 

Level 100 to 100
[S -> C][B069]
01                                                ................
05 00 00 00                                       ................
00 00 00 00                                       ................
05                                                ................
00                                                ................
64                                                d...............
64                                                d...............
32 00                                             2...............
6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F   oooooooooooooooo
6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F   oooooooooooooooo
6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F   oooooooooooooooo
6F 6F                                             oo..............

//Quest
[S -> C][B069]
01                                                ................
06 00 00 00                                       ................
00 00 00 00                                       ................
05                                                ................
01                                                ................
32                                                2...............
32                                                2...............
04 00                                             ................
61 61 61 61                                       aaaa............



[C -> S][70B1]
0B 00                                             ................
68 65 6C 6C 6F 20 77 6F 72 6C 64                  hello.world.....

[C -> S][70BA]
06                                                ................
1C 00                                             ................
57 65 6C 63 6F 6D 65 20 74 6F 20 5B 4D 6F 6E 6B   Welcome.to.[Monk
65 64 5D 27 73 20 73 74 61 6C 6C 2E               ed]'s.stall.....

[C -> S][0x70BA]
06                                                ................
01 00                                             ................
61                                                a...............


Level 100 to 100
[S -> C][B069]
01                                                ................
05 00 00 00                                       ................
00 00 00 00                                       ................
05                                                ................
00                                                ................
64                                                d...............
64                                                d...............
32 00                                             2...............
6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F   oooooooooooooooo
6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F   oooooooooooooooo
6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F 6F   oooooooooooooooo
6F 6F   

*/
            // first stall packet typing stall name
            Packet Stall1 = new Packet(0xB069, true);
            Stall1.WriteAscii(NameParty); //stall name
            Agent.Send(Stall1);
            // second stall packet typing stall welcome msg
            //Packet Stall2 = new Packet(0x70BA, true);
            //Stall2.WriteUInt8(0x06); //static
            //Stall2.WriteAscii(StallGreating); //welcome msg
            //Agent.Send(Stall2);
            this.Meldung("Stall created successfully.", new object[0]);
        }
    }
}