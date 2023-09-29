using MangerSroApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlikroadBotAPI
{
    internal static class Glabel
    {
        public static Confing Confing = MangerSroApp.ExtensionsClass.Extensions.ConfingModels;

        public static string FolderServerDef
        {
            get
            {

                var MyPathMain = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SilkroadServerFiles");
                 MyPathMain = System.IO.Path.Combine(MyPathMain, "system.json");

                return MyPathMain;
            }

        }

        public static bool GatewayIsReadyNow { set; get; }
        public static bool ServerIsReady { set; get; }
        public static uint version { set; get; } = uint.Parse(SlikroadBotAPI.Glabel.Confing.bot.Version);
        public static uint locale { set; get; } = uint.Parse(SlikroadBotAPI.Glabel.Confing.bot.Locale);

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

    }
}
