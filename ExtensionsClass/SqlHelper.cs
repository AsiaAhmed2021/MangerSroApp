using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangerSroApp.ExtensionsClass
{
    internal static class SqlHelper
    {
        internal static IEnumerable<string> ListLocalSqlInstances()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                using (var hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    foreach (string item in ListLocalSqlInstances(hive))
                    {
                        yield return item;
                    }
                }

                using (var hive = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                {
                    foreach (string item in ListLocalSqlInstances(hive))
                    {
                        yield return item;
                    }
                }
            }
            else
            {
                foreach (string item in ListLocalSqlInstances(Registry.LocalMachine))
                {
                    yield return item;
                }
            }
        }
        private static IEnumerable<string> ListLocalSqlInstances(RegistryKey hive)
        {
            const string keyName = @"Software\Microsoft\Microsoft SQL Server";
            const string valueName = "InstalledInstances";
            const string defaultName = "MSSQLSERVER";

            using (var key = hive.OpenSubKey(keyName, false))
            {
                if (key == null) return Enumerable.Empty<string>();

                var value = key.GetValue(valueName) as string[];
                if (value == null) return Enumerable.Empty<string>();

                for (int index = 0; index < value.Length; index++)
                {
                    if (string.Equals(value[index], defaultName, StringComparison.OrdinalIgnoreCase))
                    {
                        value[index] = ".";
                    }
                    else
                    {
                        value[index] = @".\" + value[index];
                    }
                }

                return value;
            }
        }

        internal static string[,] GetUsers()
        {
            using (var db = new DotNet.VSRO_SHARDEntities())
            {
                var OutList = new string[db.C_Char.Count(), 2];
                var GetAllUsers = db.C_Char.Where(a => a.Deleted == 0).ToArray();
                for (int i = 0; i < GetAllUsers.Length; i++)
                {
                    OutList[i, 0] = GetAllUsers[i].CharID.ToString();
                    OutList[i, 1] = GetAllUsers[i].CharName16;
                }

                return OutList;
            }
        }

        internal static List<Mask_CharTbl> GetUsersByModels()
        {
            using (var db = new DotNet.VSRO_SHARDEntities())
            {
                var OutList = new List<Mask_CharTbl>();
                var GetAllUsers = db.C_Char.Where(a => a.Deleted == 0).ToArray();
                for (int i = 0; i < GetAllUsers.Length; i++)
                {
                    OutList.Add(new Mask_CharTbl()
                    {
                        ID = GetAllUsers[i].CharID.ToString(),
                        name = GetAllUsers[i].CharName16
                    });
                }

                return OutList;
            }
        }

        internal class Mask_CharTbl
        {
            public string ID { set; get; }
            public string name { set; get; }
        }



        /// <summary>
        /// <para>1) Call Files and Copy from any path</para>
        /// <para>2) Open EntityFramewok Class </para>
        /// <para>3) Set Query</para>
        /// <para>4) Check DataBase</para>
        /// </summary>
        internal class InitializeDataBaseQuery
        {
            public string DataBaseName;

            public const string StrCheckLogin = "SELECT name FROM sys.login_token";
            /// <summary>
            /// Microsoft SQL Server 2019 (RTM) - 15.0.2000.5 (X64)   Sep 24 2019 13:48:23   Copyright (C) 2019 Microsoft Corporation  Express Edition (64-bit) on Windows 10 Pro 10.0 <X64> (Build 19042: ) 
            /// </summary>
            public const string StrCheckVersionSQLSERVER = "SELECT @@Version as 'var' ";

            SQLConn sqlClass;

            internal InitializeDataBaseQuery()
            {
                this.DataBaseName = DataBaseName;

                sqlClass = new SQLConn(
                    Extensions.ConfingModels.sql.Host,
                    Extensions.ConfingModels.tableName.VsroSharad,
                    Extensions.ConfingModels.sql.User,
                    Extensions.ConfingModels.sql.Password);
                
                sqlClass.ExecuteReader(new Action<SqlCommand, SqlConnection>((_SqlCommand, _SqlConnection) =>
                {
                    if (!sqlClass.Open())
                        _SqlConnection.Open();

                    var SQL_SqlCommand = new SqlCommand(StrCheckVersionSQLSERVER, _SqlConnection).ExecuteReader();

                    while (SQL_SqlCommand.Read())
                    {
                        var data = (string)SQL_SqlCommand["var"];
                        if (data.Contains("Microsoft SQL Server 2019"))
                        {

                        }
                    }

                    if (sqlClass.Open())
                        _SqlConnection.Close();

                }));
            }

            bool CheckDBVer()
            {


                return true;
            }

            public void exportDatabase()
            {
                if (!string.IsNullOrEmpty(DataBaseName))
                {
                    //
                }
            }
        }


        internal class SQLConn
        {
            public string ConnectString = "";

            //    reader = new SqlCommand("Select C.CharID,C.RefObjID,C.NickName16,G.Name,C.CurLevel,C.Strength,C.Intellect,C.RemainGold From _Char As C Inner Join _Guild As G ON G.ID = C.GuildID Where C.CharName16 = '" + this.char_list.Text + "'", sqlshard).ExecuteReader();
            //            if (reader.Read())

            SqlConnection sql;

            public SQLConn(string Host, string DateBaseNaem, string Userlogin, string Passwrod = "")
            {
                try
                {
                    var strConnectString = $"" +
                        $"Data Source={Host};" +
                        $"Initial Catalog={DateBaseNaem};" +
                        $"Integrated Security=false;" +
                        $"User ID ={Userlogin};" +
                        (!string.IsNullOrEmpty(Passwrod) ? $"Password={Passwrod};" : "") +
                        $"MultipleActiveResultSets=true;";

                    this.ConnectString = strConnectString;

                    sql = new SqlConnection(this.ConnectString);
                    sql.Open();
                    sql.Close();
                }
                catch (Exception)
                {
                }
            }

            public bool Open()
            {
                return sql.State == System.Data.ConnectionState.Open;
            }

            public void CloseConnecting()
            {
                if (sql.State == System.Data.ConnectionState.Open)
                    sql.Close();
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="action">  </param>
            public void ExecuteReader(Action<SqlCommand, SqlConnection> action)
            {
                var Reader = new SqlCommand();

                if (action != null)
                    action.Invoke(Reader, sql);
            }
        }



    }
}
