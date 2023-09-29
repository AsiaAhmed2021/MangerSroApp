using MangerSroApp.ExtensionsClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangerSroApp.Tools.Bot
{
    internal static class Sql
    {

        /// <summary>
        /// Log and Main APP BOT DB
        /// </summary>
        public static SqlConnection sqlshardlog;
        public static SqlConnection sqlshard;
        public static SqlConnection sqlAccount;

 

        public static bool ConnectSqlServer()
        {
            string Host = Globals.Confing.sql.Host.RepServer();  //Read_ini("Config.ini", "SQL", "Host");
            string DB_Name = Globals.Confing.tableName.VsroLog.RepServer(); //Read_ini("Config.ini", "SQL", "Database");
            string Shard = Globals.Confing.tableName.VsroSharad.RepServer(); //Read_ini("Config.ini", "SQL", "Shard");
            string Account = Globals.Confing.tableName.VsroAccount.RepServer();   //Read_ini("Config.ini", "SQL", "Account");
            string Shardlog = Globals.Confing.tableName.VsroLog.RepServer();//Read_ini("Config.ini", "SQL", "ShardLog");
            string User = Globals.Confing.sql.User.RepServer();  //Read_ini("Config.ini", "SQL", "HostUser");
            string HostPw = Globals.Confing.sql.Password.RepServer();  //Read_ini("Config.ini", "SQL", "HostPw");

            sqlshardlog = new SqlConnection("Data Source=" + Host + ";Initial Catalog=" + DB_Name + ";Integrated Security=false; User ID = " + User + "; Password = " + HostPw + ";MultipleActiveResultSets=true;");
            sqlshard = new SqlConnection("Data Source=" + Host + ";Initial Catalog=" + Shard + ";Integrated Security=false; User ID = " + User + "; Password = " + HostPw + ";MultipleActiveResultSets=true;");
            sqlAccount = new SqlConnection("Data Source=" + Host + ";Initial Catalog=" + Account + ";Integrated Security=false; User ID = " + User + "; Password = " + HostPw + ";MultipleActiveResultSets=true;");
            // App.sqlshardlog = new SqlConnection("Data Source=" + Host + ";Initial Catalog=" + Shardlog + ";Integrated Security=false; User ID = " + HostUser + "; Password = " + HostPw + ";MultipleActiveResultSets=true;");
            try
            {
                sqlshardlog.Open();
                Meldung("Sro Shardlog connected.");
                try
                {
                    sqlshard.Open();
                    Meldung("Sro Shard connected.");
                    try
                    {
                        sqlAccount.Open();
                        Meldung("Sro Account connected.");
                        try
                        {
                            Meldung("Connect to server is available now.");
                            Meldung("Execute Schedule is ready to use.");
                            Meldung("Useful queries is ready to use.");
                            _ = new SqlCommand("Exec [dbo].[starterBot]", sqlshardlog).ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            Meldung("Sro Shardlog Connection failed !");
                            Meldung("Reconnect with the correct info.");
                            return false;
                        }
                        return true;
                    }
                    catch (Exception)
                    {
                        Meldung("Sro Account Connection failed !");
                        Meldung("Reconnect with the correct info.");
                        return false;
                    }

                }
                catch (Exception)
                {
                    Meldung("Sro Shard Connection failed !");
                    Meldung("Reconnect with the correct info.");
                    return false;
                }
            }
            catch (Exception)
            {
                Meldung("SRO Log Connection failed !");
                Meldung("Reconnect with the correct info.");
                return false;
            }


        }

        private static void Meldung(string msg, params object[] values)
        {
            msg = string.Format(msg, values);
            //Globals.MainWindow.listBox1.Items.Add("[" + System.DateTime.Now.ToLongTimeString() + "] " + msg);
            //Globals.MainWindow.listBox1.TopIndex = Globals.MainWindow.listBox1.Items.Count - 1;

            Globals.SetGatewayEvent("Sql", msg);
        }

    }
}
