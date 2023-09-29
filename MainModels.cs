using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangerSroApp
{
    public class Confing
    {

        public string ServerName { set; get; }
        public string IP { set; get; }
        public string Port_IIS { set; get; }
        public string ExpRatioParty { set; get; }
        public string ExpRatio { set; get; }
        public string DropItemRatio { set; get; }
        public string DropGoldAmountCoef { set; get; }
        public string USER_LIMIT { set; get; }
        public string levelCap { set; get; }
        public string petLevelCap { set; get; }
        public string masteryCap { set; get; }
        public string exchangeGoldLimit { set; get; }
        public string stallGoldLimit { set; get; }
        public string MaxPlayerInServer { set; get; }

        //-------------------------------------------------------
        public Sql sql { set; get; }
        public TableName tableName { set; get; }
        public Fixes fixes { set; get; }
        public Miscini miscini { set; get; }
        public SettingInI settingInI { set; get; }
        public BotAppV1 bot { set; get; }
        public Dir Dirs { set; get; }
        //-------------------------------------------------------

        public class Sql
        {
            public string Host { set; get; }
            public string Password { set; get; }
            public string User { set; get; }
        }
        public class TableName
        {
            public string VsroSharad { set; get; }
            public string VsroAccount { set; get; }
            public string VsroLog { set; get; }
        }
        public class Fixes
        {
            public string disableDumps { set; get; }
            public string fixRates { set; get; }
            public string disableGreenBook { set; get; }
        }
        public class Miscini
        {
            public string disableMsg { set; get; }
            public string disableLog { set; get; }
            public string disableBsobjMsgbox { set; get; }
        }
        public class SettingInI
        {
            public string PathDirMedia { set; get; }
            public string AutoEnc { set; get; }
            public string Cert { set; get; }
            public string Global { set; get; }
            public string Machine { set; get; }
            public string Download { set; get; }
            public string Gateway { set; get; }
            public string Farm { set; get; }
            public string Agent { set; get; }
            public string Shard { set; get; }
            public string GameServer { set; get; }
            public string SMC { set; get; }

        }
        public class BotAppV1 {

            //Bot
            public string ServerPort { set; get; } // -> int
            public string Bot_ID { set; get; } // -> String
            public string Bot_Password { set; get; } // -> String
            public string BotName { set; get; } // -> String
            public string Locale { set; get; } // -> String
            public string Version { set; get; } // -> String
            public string Xtrap { set; get; } // -> ON
            public string Relog { set; get; } //-> ON

            //Bot
            public string TimerDelay { set; get; }  // -> Bool
            public string GlobalSlot { set; get; }  // -> Bool
            public string SendNotice { set; get; }  // -> Bool
            public string SendMessage { set; get; } // -> Bool
            public string SendPrivate { set; get; } // -> Bool
            public string SendPublic { set; get; }  // -> Bool
            public string SendGlobal { set; get; }  // -> Bool
            public string SaveChat { set; get; }    // -> Bool
            public string SaveUnique { set; get; }  // -> Bool
            public string MoveToUser { set; get; }  // -> Bool
            public string RecallUser { set; get; }  // -> Bool
            public string RecallGuild { set; get; } // -> Bool
            public string ToTown { set; get; }      // -> Bool
            public string DcUser { set; get; }      // -> Bool
            public string Warp { set; get; }        // -> Bool
            public string LoadMonster { set; get; } // -> Bool
            public string MakeItem { set; get; }    // -> Bool
            public string Invincible { set; get; }  // -> Bool
            public string Invisible { set; get; }   // -> Bool
            public string GoTown { set; get; }      // -> Bool
            public string GMSkill { set; get; }     // -> Bool
            public string PvpCape { set; get; }     // -> Bool
            public string StallSystem { set; get; } // -> Bool
            public string Schedule { set; get; }    // -> Bool
        }
        public class Dir
        {
            public string DirData      { set; get; }
            public string DirMap       { set; get; }
            public string DirMusic     { set; get; }
            public string DirMedia     { set; get; }
            public string DirParticles { set; get; }
        }

    }
}



