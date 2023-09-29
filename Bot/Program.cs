using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Bot
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            MangerSroApp.Tools.Bot.Bot bot = new MangerSroApp.Tools.Bot.Bot();
            bot.BordcastBots += Bot_BordcastBots;
            bot.StartBot();

       

            Console.ReadLine();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Silkroad.AddPage());
            Application.Run(new Form1());
        }

        private static void Bot_BordcastBots(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
