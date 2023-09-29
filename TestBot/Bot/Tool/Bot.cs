using Bot.Extensions;
using MangerSroApp.ExtensionsClass;
using Silkroad.Tools.Bot;
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
    //
    //  Block Static 
    //
    using static SlikroadBotAPI.Glabel;

    public partial class Bot
    {
        public delegate void eventApp(string msg);
        public event eventApp BordcastBots;
        public SqlDataReader reader;
        internal Gateway gateWay = new Gateway();
        private Timer Ping;
        private Timer PlayBot;

        public void StopBot()
        {
        }


        public void Meldung(string msg, params object[] values)
        {
            msg = string.Format(msg, values);
            SlikroadBotAPI.Glabel.SetGatewayEvent("Bot", msg);
        }


        /// <summary>
        ///  Init Data
        /// </summary>
        public Bot()
        {
            this.Ping = new Timer();
            this.Ping.Interval = Convert.ToInt32(Confing.bot.TimerDelay);
            this.Ping.Tick += Ping_Tick;
            this.Ping.Enabled = false;
            Ping.Enabled = true;
            Ping.Start();

            EventLogs += Globals_EventLogs;
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
                    int day = reader["Day"].ToString().ConvertWeekToString();// getDayOfWeek();
                    if (day == -1 || day == (int)DateTime.Now.DayOfWeek)
                    {
                        string Query = (string)reader["Query"];
                        int Index = (int)reader["DatabaseIndex"];
                        switch (Index)
                        {
                            case 1: case 4: _ = new SqlCommand(Query, Sql.sqlshardlog).ExecuteNonQuery(); break;
                            case 2: _ = new SqlCommand(Query, Sql.sqlshard).ExecuteNonQuery(); break;
                            case 3: _ = new SqlCommand(Query, Sql.sqlAccount).ExecuteNonQuery(); break;
                        }
                    }
                }

                reader.Close();
            }
            catch { Meldung("Error 01 , report to the developer.", new object[0]); }

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



        private void sqlmsg(string Tag)
        {

        }

        private void msgOpenChar(string Tag)
        {
            if (Tag == "Connect Success, enter you ID & PW now !")
            {
                //Stap 2
                gateWay.LoginUser(Confing.bot.Bot_ID, Confing.bot.Bot_Password);
            }

            if (Tag == "Captcha Is Ready")
            {
                //stap3
                gateWay.CaptchaLogin("");
            }

            //add Charname to List
            if (Tag == "add Charname to List")
            {
                //Stap4
                Gateway.agent.SelectCharAndStartBot(Confing.bot.BotName);
            }

            if (Tag == "Character Spawned successfully !")
            {
                // Stap 5
                if (PlayBot == null)
                {
                    this.PlayBot = new Timer();
                    this.PlayBot.Interval = Convert.ToInt32(Confing.bot.TimerDelay);
                    this.PlayBot.Tick += Character_Action_Tick;
                }
            }

            if (Tag == "Ping is Enbale")
            {

            }
        }



        public void StartBot()
        {
            if (Sql.ConnectSqlServer())
            {
                //Stap 1
                gateWay = new Gateway();
                gateWay.Start(Confing.IP, Confing.bot.ServerPort);
            }
            else
            {
                SetGatewayEvent("ConnectisF", "Connect Sql Is Fil");
            }
        }





        // ping timer
        private void Ping_Tick(object sender, EventArgs e)
        {
            if (Server != ServerEnum.None)
            {
                Packet packet = new Packet(0x2002);
                if (Server == ServerEnum.Gateway)
                {
                    Gateway.SendToServer(packet);
                }
                else if (Server == ServerEnum.Agent)
                {
                    Gateway.agent.Send(packet);
                }
            }
        }



    }
}
