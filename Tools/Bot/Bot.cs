using SilkroadSecurityApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.Tools.Bot
{
    public partial class Bot
    {
        public delegate void eventApp(string msg);
        public event eventApp BordcastBots;
        public SqlDataReader reader;
        Timer Ping;
        Timer PlayBot;
        Timer Execute;


        public void QueryExecute(string query)
        {
            try
            { var Query = new SqlCommand(query, Sql.sqlshardlog).ExecuteNonQuery(); }
            catch { Meldung("Error while executing query [Form1].", new object[0]); }
        }

        public void StopBot()
        {
        }

        private void ToolService_Tick(object sender, EventArgs e)
        {
            try
            {
                string Query = $"Declare @Date Varchar(100) = '{DateTime.Now:YYYYMMddHHmmss}' , @DateSub Varchar(100) = '{DateTime.Now.AddMinutes(-1):YYYYMMddHHmmss}'; Select Top 1 * From iLegend_Tool Where Service = '1' and Date Between @DateSub and @Date Order By ID;";

                reader = new SqlCommand(Query, Sql.sqlshardlog).ExecuteReader();
                while (reader.Read())
                {
                    int ID = (int)reader["ID"];
                    string Type = (string)reader["Type"];
                    switch (Type)
                    {
                        case "Notice":
                            if (Globals.Confing.bot.SendNotice == "ON")
                            {
                                try
                                {
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("`", "'");
                                    send_notice(Message);
                                }
                                catch
                                { Meldung("Error while sending notice.", new object[0]); }
                            }
                            break;
                        case "Message":
                            if (Globals.Confing.bot.SendMessage == "ON")
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("'", "`");
                                    send_msg(Target, Message);
                                }
                                catch
                                { Meldung("Error while sending message.", new object[0]); }
                            }
                            break;
                        case "Private":
                            if (Globals.Confing.bot.SendPrivate == "ON")
                            //if (Check_Private.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("`", "'");
                                    send_pm(Target, Message);
                                }
                                catch
                                { Meldung("Error while sending private chat.", new object[0]); }
                            }
                            break;
                        case "Public":
                            if (Globals.Confing.bot.SendPublic == "ON")
                            //if (Check_ChatAll.Checked == true)
                            {
                                try
                                {
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("`", "'");
                                    send_all(Message);
                                }
                                catch
                                { Meldung("Error while sending public chat.", new object[0]); }
                            }
                            break;
                        case "Global":
                            if (Globals.Confing.bot.SendGlobal == "ON")
                            //if (Check_Global.Checked == true)
                            {
                                try
                                {
                                    // string Message = (string)reader["Message"];
                                    // Message = Message.Replace("`", "'");
                                    // reader = new SqlCommand("Select Top 1 I.Slot From [dbo].[_Inventory] As I Inner Join [dbo].[_Char] As C ON I.CharID = C.CharID Inner Join [dbo].[_Items] As T ON I.ItemID = T.ID64 Where C.CharName16 = '" + this.char_list.Text + "' and T.RefItemID = 3851", Sql.sqlshard).ExecuteReader();
                                    // if (reader.Read())
                                    // {
                                    //     string Slot = reader["Slot"].ToString();
                                    //     send_global(Message, Slot);
                                    // }
                                    // else
                                    // {
                                    //     Meldung("Error while sending global chat (character hasn't any global item.", new object[0]);
                                    // }
                                }  //
                                catch
                                { Meldung("Error while sending global chat.", new object[0]); }
                            }
                            break;
                        case "Movetouser":
                            if (Globals.Confing.bot.MoveToUser == "ON")
                            //if (Check_Movetouser.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    movetouser(Target);
                                }
                                catch
                                { Meldung("Error while movetouser function.", new object[0]); }
                            }
                            break;
                        case "Recalluser":
                            if (Globals.Confing.bot.RecallUser == "ON")
                            //if (Check_RecallUser.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    recalluser(Target);
                                }
                                catch
                                { Meldung("Error while recalluser function.", new object[0]); }
                            }
                            break;
                        case "Recallguild":
                            if (Globals.Confing.bot.RecallGuild == "ON")
                            //if (Check_RecallGuild.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    recallguild(Target);
                                }
                                catch
                                { Meldung("Error while recallguild function.", new object[0]); }
                            }
                            break;
                        case "Totown":
                            if (Globals.Confing.bot.ToTown == "ON")
                            //if (Check_ToTown.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    totown(Target);
                                }
                                catch
                                { Meldung("Error while totown user function.", new object[0]); }
                            }
                            break;
                        case "Disconnect":
                            if (Globals.Confing.bot.DcUser == "ON")
                            //if (Check_DcUser.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    dc_user(Target);
                                }
                                catch
                                { Meldung("Error while disconnect user function.", new object[0]); }
                            }
                            break;
                        case "Warp":
                            if (Globals.Confing.bot.Warp == "ON")
                            //if (Check_Warp.Checked == true)
                            {
                                try
                                {
                                    string RegionID = (string)reader["RegionID"];
                                    string PosX = (string)reader["PosX"];
                                    string PosY = (string)reader["PosY"];
                                    string PosZ = (string)reader["PosZ"];
                                    string WorldID = (string)reader["WorldID"];
                                    warp(RegionID, PosX, PosY, PosZ, WorldID);
                                }
                                catch
                                { Meldung("Error while warp region function.", new object[0]); }
                            }
                            break;
                        case "Loadmonster":
                            if (Globals.Confing.bot.LoadMonster == "ON")
                            //if (Check_LoadMonster.Checked == true)
                            {
                                try
                                {
                                    string RefMobID = (string)reader["RefMobID"];
                                    string Amount = (string)reader["Amount"];
                                    loadmonster(RefMobID, Amount);
                                }
                                catch
                                { Meldung("Error while loadmonster function.", new object[0]); }
                            }
                            break;
                        case "Makeitem":
                            if (Globals.Confing.bot.MakeItem == "ON")
                            //if (Check_MakeItem.Checked == true)
                            {
                                try
                                {
                                    string RefItemID = (string)reader["RefItemID"];
                                    string Amount = (string)reader["Amount"];
                                    string OptLvl = (string)reader["OptLvl"];
                                    makeitem(RefItemID, Amount, OptLvl);
                                }
                                catch
                                { Meldung("Error while makeitem function.", new object[0]); }
                            }
                            break;
                        case "Invincible":
                            if (Globals.Confing.bot.Invincible == "ON")
                            //if (Check_Invincible.Checked == true)
                            {
                                try { invincible(); }
                                catch
                                { Meldung("Error while invincible function.", new object[0]); }
                            }
                            break;
                        case "Invisible":
                            if (Globals.Confing.bot.Invisible == "ON")
                            //if (Check_Invisible.Checked == true)
                            {
                                try { invisible(); }
                                catch
                                { Meldung("Error while invisible function.", new object[0]); }
                            }
                            break;
                        case "Gotown":
                            if (Globals.Confing.bot.GoTown == "ON")
                            //if (Check_GoTown.Checked == true)
                            {
                                try { gotown(); }
                                catch
                                { Meldung("Error while gotown function.", new object[0]); }
                            }
                            break;
                        case "GMskill":
                            if (Globals.Confing.bot.GMSkill == "ON")
                            //if (Check_GMSkill.Checked == true)
                            {
                                try { gmskill(); }
                                catch
                                { Meldung("Error while gmskill function.", new object[0]); }
                            }
                            break;
                        case "PvpCape":
                            if (Globals.Confing.bot.PvpCape == "ON")
                            //if (Check_PvpCape.Checked == true)
                            {
                                try
                                {
                                    string CapeColor = (string)reader["CapeColor"];
                                    OpenCape(this.CapIndex(CapeColor));
                                }
                                catch
                                { Meldung("Error while pvp cape function.", new object[0]); }
                            }
                            break;

                        case "CreateStall":
                            if (Globals.Confing.bot.StallSystem == "ON")
                            //if (Check_StallCreate.Checked == true)
                            {
                                try
                                {
                                    string Title = (string)reader["StallTitle"];
                                    string Greating = (string)reader["StallGreating"];
                                    CreateStall(Title, Greating);
                                }
                                catch
                                { Meldung("Error while create stall function.", new object[0]); }
                            }
                            break;
                        case "AddStallItem":
                            if (Globals.Confing.bot.StallSystem == "ON")
                            //if (Check_StallCreate.Checked == true)
                            {
                                try
                                {
                                    string StallSlot = (string)reader["StallSlot"];
                                    string InvSlot = (string)reader["InvSlot"];
                                    string Count = (string)reader["ItemCount"];
                                    string Price = (string)reader["ItemPrice"];
                                    AddItemToStall(StallSlot, InvSlot, Count, Price);
                                }
                                catch
                                { Meldung("Error while add stall item function.", new object[0]); }
                            }
                            break;
                        case "OpenStall":
                            if (Globals.Confing.bot.StallSystem == "ON")
                            //if (Check_StallCreate.Checked == true)
                            {
                                try
                                { OpenStall(); }
                                catch
                                { Meldung("Error while opening stall function.", new object[0]); }
                            }
                            break;
                        case "CloseStall":
                            if (Globals.Confing.bot.StallSystem == "ON")
                            //if (Check_StallCreate.Checked == true)
                            {
                                try
                                { CloseStall(); }
                                catch
                                { Meldung("Error while closing stall function.", new object[0]); }
                            }
                            break;
                        case "DropItem":
                            //if (Globals.Confing.bot.MakeItem == "ON")
                            if (true)
                            //if (Check_MakeItem.Checked == true)
                            {
                                try
                                {
                                    string RefItemID = (string)reader["RefItemID"];
                                    string Amount = (string)reader["Amount"];
                                    this.DorpItems(MDorpItems(RefItemID, Globals.Confing.bot.BotName , Amount));
                                }
                                catch
                                { Meldung("Error while DropItem function.", new object[0]); }
                            }
                            break;
                    }
                    QueryExecute("Update iLegend_Tool Set Service = '0' Where ID = " + ID);
                }
                reader.Close();
            }
            catch { Meldung("Error in [ToolService] timer, cannot read from database table.", new object[0]); }
        }

        public void Meldung(string msg, params object[] values)
        {
            msg = string.Format(msg, values);
            //this.listBox1.Items.Add("[" + System.DateTime.Now.ToLongTimeString() + "] " + msg);
            //this.listBox1.TopIndex = listBox1.Items.Count - 1;

            Globals.SetGatewayEvent("Bot", msg);


        }

      
        /// <summary>
        ///  Init Data
        /// </summary>


        public Bot( )
        {
     

            // 
            // Ping
            // 
            this.Ping = new System.Windows.Forms.Timer();
            this.Ping.Enabled = true;
            this.Ping.Interval = 5000;
            this.Ping.Tick += new System.EventHandler(this.Ping_Tick);

            // 
            // Ping
            // 
            this.PlayBot = new System.Windows.Forms.Timer();
            this.PlayBot.Enabled = true;
            this.PlayBot.Interval = Convert.ToInt32(Globals.Confing.bot.TimerDelay);
            this.PlayBot.Tick += new System.EventHandler(this.ToolService_Tick);


            this.Execute = new System.Windows.Forms.Timer();
            this.Execute.Enabled = true;
            this.Execute.Interval = 1000;
            this.Execute.Tick += new System.EventHandler(this.Execute_Tick);


            Globals.EventLogs += Globals_EventLogs;
        }

        private static int getDayOfWeek(string text)
        {
            int Return = -1;
            switch (text)
            {
                case "Always":
                    Return = -1;
                    break;
                case "Sunday":
                    Return = 0;
                    break;
                case "Monday":
                    Return = 1;
                    break;
                case "Tuesday":
                    Return = 2;
                    break;
                case "Wednesday":
                    Return = 3;
                    break;
                case "Thursday":
                    Return = 4;
                    break;
                case "Friday":
                    Return = 5;
                    break;
                case "Saturday":
                    Return = 6;
                    break;
            }
            return Return;
        }

        // execute query by a timer
        private void Execute_Tick(object sender, EventArgs e)
        {
            String Now = string.Format("{0:HH:mm:ss}", DateTime.Now);
            try
            {
                reader = new SqlCommand("Select Top 1 Day , DatabaseIndex , Query From [dbo].[ExecQuery] Where Time = '" + Now + "'", Sql.sqlshardlog).ExecuteReader();
                if (reader.Read())
                {
                    int day = getDayOfWeek(reader["Day"].ToString());
                    if (day == -1 || day == (int)System.DateTime.Now.DayOfWeek)
                    {
                        string Query = (string)reader["Query"];
                        int Index = (int)reader["DatabaseIndex"];
                        switch (Index)
                        {
                            case 1:
                            case 4:
                                new SqlCommand(Query, Sql.sqlshardlog).ExecuteNonQuery();
                                break;
                            case 2:
                                new SqlCommand(Query, Sql.sqlshard).ExecuteNonQuery();
                                break;
                            case 3:
                                new SqlCommand(Query, Sql.sqlAccount).ExecuteNonQuery();
                                break;
                        }
                    }
                }
                reader.Close();
            }
            catch
            { Meldung("Error 01 , report to the developer.", new object[0]); }


            reader.Close();
        }

        private void Globals_EventLogs(string Res, string Tag)
        {
            if (BordcastBots != null)
            {
                BordcastBots.Invoke(Tag);
            }

            if (Res == "Sql")
            {
                sqlmsg(Tag);
                return;
            }

            msgOpenChar(Tag);


        }

        private static void sqlmsg(string Tag)
        {

        }

        private static void msgOpenChar(string Tag)
        {
            if (Tag == "Connect Success, enter you ID & PW now !")
            {
                //Stap 2
                LoginUser(Globals.Confing.bot.Bot_ID, Globals.Confing.bot.Bot_Password);
            }

            if (Tag == "Captcha Is Ready")
            {
                //stap3
                CaptchaLogin("");
            }
            //add Charname to List
            if (Tag == "add Charname to List")
            {
                //Stap4
                SelectCharAndStartBot(Globals.Confing.bot.BotName);
            }

            if (Tag == "Character Spawned successfully !")
            {
                //OkEnd Bot Is Open
            }
        }






    }
}
