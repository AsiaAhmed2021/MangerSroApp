using Silkroad.Tools.Bot;
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

        public void QueryExecute(string query)
        {
            try
            { var Query = new SqlCommand(query, Sql.sqlshardlog).ExecuteNonQuery(); }
            catch { Meldung("Error while executing query [Form1].", new object[0]); }
        }
        private void Character_Action_Tick(object sender, EventArgs e)
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
                            if (SlikroadBotAPI.Glabel.Confing.bot.SendNotice == "ON")
                            {
                                try
                                {
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("`", "'");
                                    Gateway.agent.SendNotice(Message);
                                }
                                catch
                                { Meldung("Error while sending notice.", new object[0]); }
                            }
                            break;
                        case "Message":
                            if (SlikroadBotAPI.Glabel.Confing.bot.SendMessage == "ON")
                            {
                                //    try
                                //    {
                                //        string Target = (string)reader["Target"];
                                //        string Message = (string)reader["Message"];
                                //        Message = Message.Replace("'", "`");
                                //        Gateway.agent.send_msg(Target, Message);
                                //    }
                                //    catch
                                //    { Meldung("Error while sending message.", new object[0]); }
                            }
                            break;
                        case "Private":
                            if (SlikroadBotAPI.Glabel.Confing.bot.SendPrivate == "ON")
                            //if (Check_Private.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("`", "'");
                                    Gateway.agent.SendPM(Target, Message);
                                }
                                catch
                                { Meldung("Error while sending private chat.", new object[0]); }
                            }
                            break;
                        case "Public":
                        //  if (SlikroadBotAPI.Glabel.Confing.bot.SendPublic == "ON")
                        //  //if (Check_ChatAll.Checked == true)
                        //  {
                        //      try
                        //      {
                        //          string Message = (string)reader["Message"];
                        //          Message = Message.Replace("`", "'");
                        //          Gateway.agent.send_all(Message);
                        //      }
                        //      catch
                        //      { Meldung("Error while sending public chat.", new object[0]); }
                        //  }
                        //  break;
                        case "Global":
                            if (SlikroadBotAPI.Glabel.Confing.bot.SendGlobal == "ON")
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
                            if (SlikroadBotAPI.Glabel.Confing.bot.MoveToUser == "ON")
                            //if (Check_Movetouser.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    Gateway.agent.Movetouser(Target);
                                }
                                catch
                                { Meldung("Error while movetouser function.", new object[0]); }
                            }
                            break;
                        case "Recalluser":
                            //  if (SlikroadBotAPI.Glabel.Confing.bot.RecallUser == "ON")
                            //  //if (Check_RecallUser.Checked == true)
                            //  {
                            //      try
                            //      {
                            //          string Target = (string)reader["Target"];
                            //          Gateway.agent.recalluser(Target);
                            //      }
                            //      catch
                            //      { Meldung("Error while recalluser function.", new object[0]); }
                            //  }
                            break;
                        case "Recallguild":
                            if (SlikroadBotAPI.Glabel.Confing.bot.RecallGuild == "ON")
                            //if (Check_RecallGuild.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    Gateway.agent.RecallGuild(Target);
                                }
                                catch
                                { Meldung("Error while recallguild function.", new object[0]); }
                            }
                            break;
                        case "Totown":
                            // if (SlikroadBotAPI.Glabel.Confing.bot.ToTown == "ON")
                            // //if (Check_ToTown.Checked == true)
                            // {
                            //     try
                            //     {
                            //         string Target = (string)reader["Target"];
                            //         Gateway.agent.ToTown(Target);
                            //     }
                            //     catch
                            //     { Meldung("Error while totown user function.", new object[0]); }
                            // }
                            break;
                        case "Disconnect":
                            if (SlikroadBotAPI.Glabel.Confing.bot.DcUser == "ON")
                            //if (Check_DcUser.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    Gateway.agent.DCUser(Target);
                                }
                                catch
                                { Meldung("Error while disconnect user function.", new object[0]); }
                            }
                            break;
                        case "Warp":
                            if (SlikroadBotAPI.Glabel.Confing.bot.Warp == "ON")
                            //if (Check_Warp.Checked == true)
                            {
                                try
                                {
                                    string RegionID = (string)reader["RegionID"];
                                    string PosX = (string)reader["PosX"];
                                    string PosY = (string)reader["PosY"];
                                    string PosZ = (string)reader["PosZ"];
                                    string WorldID = (string)reader["WorldID"];
                                    Gateway.agent.MakeWarp(int.Parse(RegionID), double.Parse(PosX), double.Parse(PosY), double.Parse(PosZ));
                                }
                                catch
                                { Meldung("Error while warp region function.", new object[0]); }
                            }
                            break;
                        case "Loadmonster":
                            if (SlikroadBotAPI.Glabel.Confing.bot.LoadMonster == "ON")
                            //if (Check_LoadMonster.Checked == true)
                            {
                                try
                                {
                                    string RefMobID = (string)reader["RefMobID"];
                                    string Amount = (string)reader["Amount"];
                                    Gateway.agent.LoadMonster(int.Parse(RefMobID), int.Parse(Amount));
                                }
                                catch
                                { Meldung("Error while loadmonster function.", new object[0]); }
                            }
                            break;
                        case "Makeitem":
                            if (SlikroadBotAPI.Glabel.Confing.bot.MakeItem == "ON")
                            //if (Check_MakeItem.Checked == true)
                            {
                                try
                                {
                                    string RefItemID = (string)reader["RefItemID"];
                                    string Amount = (string)reader["Amount"];
                                    string OptLvl = (string)reader["OptLvl"];
                                    Gateway.agent.MakeItem(int.Parse(RefItemID), int.Parse(Amount), int.Parse(OptLvl));
                                }
                                catch
                                { Meldung("Error while makeitem function.", new object[0]); }
                            }
                            break;
                        case "Invincible":
                            if (SlikroadBotAPI.Glabel.Confing.bot.Invincible == "ON")
                            //if (Check_Invincible.Checked == true)
                            {
                                try { Gateway.agent.GMInVisibile(); }
                                catch
                                { Meldung("Error while invincible function.", new object[0]); }
                            }
                            break;
                        case "Invisible":
                            if (SlikroadBotAPI.Glabel.Confing.bot.Invisible == "ON")
                            //if (Check_Invisible.Checked == true)
                            {
                                try { Gateway.agent.GMInVisibile(); }
                                catch
                                { Meldung("Error while invisible function.", new object[0]); }
                            }
                            break;
                        case "Gotown":
                            if (SlikroadBotAPI.Glabel.Confing.bot.GoTown == "ON")
                            //if (Check_GoTown.Checked == true)
                            {
                                try { Gateway.agent.Gotown(); }
                                catch
                                { Meldung("Error while gotown function.", new object[0]); }
                            }
                            break;
                        case "GMskill":
                            if (SlikroadBotAPI.Glabel.Confing.bot.GMSkill == "ON")
                            //if (Check_GMSkill.Checked == true)
                            {
                                try { Gateway.agent.GMSkill(); }
                                catch
                                { Meldung("Error while gmskill function.", new object[0]); }
                            }
                            break;
                        case "PvpCape":
                            //if (SlikroadBotAPI.Glabel.Confing.bot.PvpCape == "ON")
                            //if (Check_PvpCape.Checked == true)
                            //{
                            //    try
                            //    {
                            //        string CapeColor = (string)reader["CapeColor"];
                            //        Gateway.agent.OpenCape(Gateway.agent.CapIndex(CapeColor));
                            //    }
                            //    catch
                            //    { Meldung("Error while pvp cape function.", new object[0]); }
                            //}
                            break;
                        case "CreateStall":
                            if (SlikroadBotAPI.Glabel.Confing.bot.StallSystem == "ON")
                            //if (Check_StallCreate.Checked == true)
                            {
                                try
                                {
                                    string Title = (string)reader["StallTitle"];
                                    string Greating = (string)reader["StallGreating"];
                                    Gateway.agent.CreateStall(Title, Greating);
                                }
                                catch
                                { Meldung("Error while create stall function.", new object[0]); }
                            }
                            break;
                        case "AddStallItem":
                            if (SlikroadBotAPI.Glabel.Confing.bot.StallSystem == "ON")
                            //if (Check_StallCreate.Checked == true)
                            {
                                try
                                {
                                    string StallSlot = (string)reader["StallSlot"];
                                    string InvSlot = (string)reader["InvSlot"];
                                    string Count = (string)reader["ItemCount"];
                                    string Price = (string)reader["ItemPrice"];
                                    Gateway.agent.AddItemToStall(StallSlot, InvSlot, Count, Price);
                                }
                                catch
                                { Meldung("Error while add stall item function.", new object[0]); }
                            }
                            break;
                        case "OpenStall":
                            if (SlikroadBotAPI.Glabel.Confing.bot.StallSystem == "ON")
                            //if (Check_StallCreate.Checked == true)
                            {
                                try
                                { Gateway.agent.OpenStall(); }
                                catch
                                { Meldung("Error while opening stall function.", new object[0]); }
                            }
                            break;
                        case "CloseStall":
                            if (SlikroadBotAPI.Glabel.Confing.bot.StallSystem == "ON")
                            //if (Check_StallCreate.Checked == true)
                            {
                                try
                                { Gateway.agent.CloseStall(); }
                                catch
                                { Meldung("Error while closing stall function.", new object[0]); }
                            }
                            break;
                        case "DropItem":
                            //if (SlikroadBotAPI.Glabel.Confing.bot.MakeItem == "ON")
                            // if (true)
                            // //if (Check_MakeItem.Checked == true)
                            // {
                            //     try
                            //     {
                            //         string RefItemID = (string)reader["RefItemID"];
                            //         string Amount = (string)reader["Amount"];
                            //         Gateway.agent.DorpItems(MDorpItems(RefItemID, SlikroadBotAPI.Glabel.Confing.bot.BotName, Amount));
                            //     }
                            //     catch
                            //     { Meldung("Error while DropItem function.", new object[0]); }
                            // }
                            break;
                    }
                    QueryExecute("Update iLegend_Tool Set Service = '0' Where ID = " + ID);
                }
                reader.Close();
            }
            catch { Meldung("Error in [Character_Action] timer, cannot read from database table.", new object[0]); }
        }

    }
}
