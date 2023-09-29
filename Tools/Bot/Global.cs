using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangerSroApp.Tools.Bot
{
    using System;

    internal class Globals
    {
        public static Confing Confing = MangerSroApp.ExtensionsClass.Extensions.ConfingModels;
        public static bool GatewayIsReadyNow { set; get; }
        public static bool ServerIsReady { set; get; }
        public static uint version = uint.Parse(Confing.bot.Version);
        public static uint locale = uint.Parse(Confing.bot.Locale);

        public enum ServerStuts
        {
            ServerIsReady,
            InitServer,
        }

        public delegate void eventApp(string Res, string Tag);
        public static event eventApp EventLogs;
        public static void SetGatewayEvent(string Res, string Tag)
        {
            if (EventLogs != null)
            {
                EventLogs.Invoke(Res, Tag);
            }
        }

        public static List<string> ListCharAliveNow = new List<string>();
        //public static App MainWindow;
        public static ServerEnum Server = ServerEnum.None;

        public enum ServerEnum
        {
            None,
            Gateway,
            Agent
        }

        public static string GetnVersionFromDB()
        {
            //select top 1 MAx(nVersion) as 'Version' from VSRO_Account.dbo._ModuleVersion
            var sqlCommand = new System.Data.SqlClient.SqlCommand(
                "select top 1 MAx(nVersion) as 'Version' from VSRO_Account.dbo._ModuleVersion",
                Sql.sqlAccount)
                .ExecuteReader();

            string DefVsro = Confing.bot.Version;

            while (sqlCommand.Read())
            {
                DefVsro = (string)sqlCommand["Version"];
            }

            return DefVsro;
        }


    }
}
