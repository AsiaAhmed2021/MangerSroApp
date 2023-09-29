using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using vSroMultiTool;

namespace Clientless_login
{
    public static class extensionsMethod
    {
        //public class Confing
        //{

        //    public string ServerName { set; get; }
        //    public string IP { set; get; }
        //    public string Port_IIS { set; get; }
        //    public string ExpRatioParty { set; get; }
        //    public string ExpRatio { set; get; }
        //    public string DropItemRatio { set; get; }
        //    public string DropGoldAmountCoef { set; get; }
        //    public string USER_LIMIT { set; get; }
        //    public string levelCap { set; get; }
        //    public string petLevelCap { set; get; }
        //    public string masteryCap { set; get; }
        //    public string exchangeGoldLimit { set; get; }
        //    public string stallGoldLimit { set; get; }
        //    public string MaxPlayerInServer { set; get; }

        //    //-------------------------------------------------------
        //    //public ModulePatch  modulePatch { set; get; }
        //    public Sql sql { set; get; }
        //    public TableName tableName { set; get; }
        //    public Fixes fixes { set; get; }
        //    public Miscini miscini { set; get; }
        //    public SettingInI settingInI { set; get; }
        //    //-------------------------------------------------------

        //    public class ModulePatch
        //    {
        //        public string SrcPath { set; get; }
        //        public string DestPath { set; get; }
        //    }
        //    public class Sql
        //    {
        //        public string Host { set; get; }
        //        public string Password { set; get; }
        //        public string User { set; get; }
        //    }
        //    public class TableName
        //    {
        //        public string VsroSharad { set; get; }
        //        public string VsroAccount { set; get; }
        //        public string VsroLog { set; get; }
        //    }
        //    public class Fixes
        //    {
        //        public string disableDumps { set; get; }
        //        public string fixRates { set; get; }
        //        public string disableGreenBook { set; get; }
        //    }
        //    public class Miscini
        //    {
        //        public string disableMsg { set; get; }
        //        public string disableLog { set; get; }
        //        public string disableBsobjMsgbox { set; get; }
        //    }
        //    public class SettingInI
        //    {
        //        public string AutoEnc { set; get; }
        //        public string PathDirMedia { set; get; }
        //        public string Cert { set; get; }
        //        public string Global { set; get; }
        //        public string Machine { set; get; }
        //        public string Download { set; get; }
        //        public string Gateway { set; get; }
        //        public string Farm { set; get; }
        //        public string Agent { set; get; }
        //        public string Shard { set; get; }
        //        public string GameServer { set; get; }
        //        public string SMC { set; get; }

        //    }
        //}

        //public static Confing ConfingModels
        //{
        //    get
        //    {
        //        //if (_ConfingModels == null)
        //        //{
        //        //    _ConfingModels = ;
        //        //}
        //        return confingObject();
        //    }

        //}

        //public static Confing confingObject()
        //{ 
        //    var GetJsonTxt = System.IO.File.ReadAllText("System.json").Replace("\\", "@@@");
        //    return JsonSerializer.Deserialize<Confing>(GetJsonTxt.Replace("@@@@@@", "@@@"));
        //}

     // public static bool ConnectSqlServer(this vSroMultiTool.App Home)
     // {
     //    string Host = Home.Read_ini("Config.ini", "SQL", "Host");
     //    string DB_Name = Home.Read_ini("Config.ini", "SQL", "Database");
     //    string Shard = Home.Read_ini("Config.ini", "SQL", "Shard");
     //    string Account = Home.Read_ini("Config.ini", "SQL", "Account");
     //    string Shardlog = Home.Read_ini("Config.ini", "SQL", "ShardLog");
     //    string HostUser = Home.Read_ini("Config.ini", "SQL", "HostUser");
     //    string HostPw = Home.Read_ini("Config.ini", "SQL", "HostPw");
     //
     //     App.sqlshardlog = new SqlConnection("Data Source=" + Host + ";Initial Catalog=" + DB_Name + ";Integrated Security=false; User ID = " + HostUser + "; //Password = " + HostPw + ";MultipleActiveResultSets=true;");
     //     App.sqlshard = new SqlConnection("Data Source=" + Host + ";Initial Catalog=" + Shard + ";Integrated Security=false; User ID = " + HostUser + "; Password// = " + HostPw + ";MultipleActiveResultSets=true;");
     //     App.sqlaccount = new SqlConnection("Data Source=" + Host + ";Initial Catalog=" + Account + ";Integrated Security=false; User ID = " + HostUser + "; //Password = " + HostPw + ";MultipleActiveResultSets=true;");
     //     App.sqlshardlog = new SqlConnection("Data Source=" + Host + ";Initial Catalog=" + Shardlog + ";Integrated Security=false; User ID = " + HostUser + "; //Password = " + HostPw + ";MultipleActiveResultSets=true;");
     //     try
     //     {
     //         App.sqlshardlog.Open();
     //         Home.Meldung("Database connected.", new object[0]);
     //         try
     //         {
     //             App.sqlshard.Open();
     //             Home.Meldung("Sro Shard connected.", new object[0]);
     //             try
     //             {
     //                 App.sqlaccount.Open();
     //                 Home.Meldung("Sro Account connected.", new object[0]);
     //                 try
     //                 {
     //                   
     //                     Home.Meldung("Sro Shardlog connected.", new object[0]);
     //                //     Home.Meldung("Connect to server is available now.", new object[0]);
     //                  //   Home.Meldung("Execute Schedule is ready to use.", new object[0]);
     //                  //   Home.Meldung("Useful queries is ready to use.", new object[0]); 
     //                     new SqlCommand("Exec [dbo].[Form_Load]", App.sqlshardlog).ExecuteNonQuery(); 
     //                 }
     //                 catch (Exception)
     //                 {
     //                     Home.Meldung("Sro Shardlog Connection failed !", new object[0]);
     //                     Home.Meldung("Reconnect with the correct info.", new object[0]);
     //                 return false;
     //                 }
     //                 return true;
     //             }
     //             catch (Exception)
     //             {
     //                 Home.Meldung("Sro Account Connection failed !", new object[0]);
     //                 Home.Meldung("Reconnect with the correct info.", new object[0]);
     //                 return false;
     //             }
     //     
     //         }
     //         catch (Exception)
     //         {
     //             Home.Meldung("Sro Shard Connection failed !", new object[0]);
     //             Home.Meldung("Reconnect with the correct info.", new object[0]);
     //             return false;
     //         }
     //     }
     //     catch (Exception)
     //     {
     //         Home.Meldung("Database Connection failed !", new object[0]);
     //         Home.Meldung("Reconnect with the correct info.", new object[0]);
     //         return false;
     //     }
     //
     //
     // }
    }
}
