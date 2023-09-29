using MangerSroApp.ExtensionsClass;
using MangerSroApp.Tools.Bot;
using MangerSroApp.Tools.Maps;
using Microsoft.Web.Administration;
using Microsoft.Win32;
using Server_Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp
{
    public partial class Form1 : Form
    {
        internal static MangerSroApp.Tools.Bot.Bot bot;

        public Form1()
        {
            InitializeComponent();
            WatcherDumpFiles.Path = System.Environment.CurrentDirectory;
            RefCheckDumpsFiles();
            Glabels.MainForm = this;
            Glabels.ServerManager = new MainControl();

            this.MoveOnly();
            this.MoveOnly(label3);
            //var X = new MoveControl(this);
            //  var Y = new MoveControl(label3, this);
        }

        #region -  -

        private void TopMostApp(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void LblStatServices_MouseEnter(object sender, EventArgs e)
        {
            LblStatServices.BackColor = Glabels.ServerManager.IsOpenServer ? Color.Green : Color.Red;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        #endregion

        #region - Init System Button -

        private void BtnInitializeFilesServer_Click(object sender, EventArgs e)
        {
            InitializeFilesServer();
            InitializeIISFilesAndWebSiteFiles();
            InitializePrivilegedIP();
            InitializeExeSpoof();
        }

        private void InitializeFilesServer()
        {
            try
            {
                Logs.AddLogs($"Initialize Files Server");

                string[] Data = {
                Files.ServerFile.RepValue(),
                Files.CustomCertification_ini_Server_IP.RepValue(),
                Files.CustomCertification_ini_srNodeType.RepValue(),
                Files.CustomCertification_ini_srShard.RepValue(),
                Files.srZor_cfg_misc.RepValue(),
                Files.srZor_cfg_common.RepValue(),
                Files.srZor_cfg_sql.RepValue(),
                Files.srZor_cfg_fixes.RepValue(),
                Files.SMC_smc_updater.RepValue(),
                Files.SMC_ServiceManager.RepValue(),
                Files.settingINI.RepValue(),
                "" };
                string[] Head = {
                "server.cfg" ,
                "CustomCertification\\ini\\Server IP.ini",
                "CustomCertification\\ini\\srNodeType.ini",
                "CustomCertification\\ini\\srShard.ini",
                "srZor\\cfg\\misc.ini",
                "srZor\\cfg\\common.ini",
                "srZor\\cfg\\sql.ini",
                "srZor\\cfg\\fixes.ini",
                "SMC\\smc_updater.cfg",
                "SMC\\ServiceManager.cfg",
                "settings.ini", };

                Extensions.WriteMiltFiles(Data, Head);

                Logs.AddLogs($"Installer Initialize Files Server ..");
            }
            catch (Exception ex)
            {
                Logs.AddLogs(ex.Message);
            }
        }

        private void InitializeIISFilesAndWebSiteFiles()
        {
            //Set Logs
            try
            {
                Logs.AddLogs($"Initialize IIS Setting ..");

                iisClass.initializationFilesIIS("WebStieSroOfflineMode", Extensions.ConfingModels.IP.RepServer(), Extensions.ConfingModels.Port_IIS.RepServer());

                Logs.AddLogs($"Installer IIS Setting ..");
            }
            catch (Exception ex)
            {
                Logs.AddLogs(ex.Message);
            }
        }

        private void InitializePrivilegedIP()
        {
            try
            {
                Logs.AddLogs($"Initialize Privileged IP Setting ..");

                var CodeDBIP = Extensions.SetIPPrivilegedIP();

                Logs.AddLogs($"Privileged IP is {CodeDBIP}");

                Logs.AddLogs($"Installer Privileged IP Setting ..");
            }
            catch (Exception ex)
            {
                Logs.AddLogs(ex.Message);
            }
        }

        private void InitializeExeSpoof()
        {
            try
            {

                Logs.AddLogs("Start InitializeExeSpoof");

                string pathMachine = Extensions.ConfingModels.settingInI.Machine.RepServer(),
                       pathAgent = Extensions.ConfingModels.settingInI.Agent.RepServer(),
                       IP = Extensions.ConfingModels.IP.RepServer();

                Logs.AddLogs(SrSpoofPatcher.SpoofMachineAppIP(pathMachine, IP));
                Logs.AddLogs(SrSpoofPatcher.SpoofAgentAppIP(pathAgent, IP));



            }
            catch (Exception ex)
            {
                Logs.AddLogs(ex.Message);
            }

            Logs.AddLogs("End InitializeExeSpoof");
        }

        #endregion

        #region - Dump Files Logs -

        private void WatcherDumpFiles_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            RefCheckDumpsFiles();
        }

        private void WatcherDumpFiles_Error(object sender, System.IO.ErrorEventArgs e)
        {
            RefCheckDumpsFiles();
        }

        private void WatcherDumpFiles_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            RefCheckDumpsFiles();
        }

        private void RefCheckDumpsFiles()
        {
            try
            {
                var FileCount = 0;
                long FileSize = 0;
                long FileSizeOrg = 0;
                foreach (var item in System.IO.Directory.GetFiles(System.Environment.CurrentDirectory))
                {
                    string[] systemFiles = Path.GetFileName(item).Split(".");
                    FileInfo fileInfo = new FileInfo(item);



                    if (systemFiles.Length > 0)
                    {

                        if (fileInfo.Extension.ToLower() == ".dmp" || fileInfo.Extension.ToLower() == "dmp")
                        {
                            FileCount += 1;
                            FileSize += fileInfo.Length / 1024;
                            FileSizeOrg += fileInfo.Length;
                        }

                    }

                }

                string TypeSize = "KB";

                if (FileSize > 1024)
                {
                    FileSize = FileSizeOrg / (1024 * 1024);
                    TypeSize = "MB";
                }

                string Code = $"Dump File Size: {((FileSize == 0) ? "0 " + TypeSize : FileSize + TypeSize)}";
                lblDumpFile.Text = $"Dump File : {((FileCount > 999) ? "999+" : FileCount)}";
                lblDumpSizeFiles.Text = Code;
                LblErrorinfoDumpFile.Text = "";

            }
            catch (Exception ex)
            {
                LblErrorinfoDumpFile.Text = ex.Message;
            }
        }

        #endregion

        private void BtnFilterTools_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.Show();
        }

        private void BtnConfigApp_Click(object sender, EventArgs e)
        {
            Glabels.ShowFormTask("Config", new ControlUI.ConfigControl() { AutoScroll = true, });
        }

        private void BtnStutsServer_Click(object sender, EventArgs e)
        {
            Glabels.ShowFormTask("Server Manager App", Glabels.ServerManager = new MainControl());
        }

        private void DeleteDumpFiles_Click(object sender, EventArgs e)
        {
            foreach (var item in System.IO.Directory.GetFiles(System.Environment.CurrentDirectory))
            {
                string[] systemFiles = Path.GetFileName(item).Split(".");
                FileInfo fileInfo = new FileInfo(item);
                if (systemFiles.Length > 0)
                {
                    if (fileInfo.Extension.ToLower() == ".dmp" || fileInfo.Extension.ToLower() == "dmp")
                    {
                        fileInfo.Delete();
                    }
                }

            }
        }

        private void CreateEmpiyFileConfiger_Click(object sender, EventArgs e)
        {
            Confing confing = new Confing()
            {
                bot = new Confing.BotAppV1()
                {
                    BotName = "",
                    Bot_ID = "",
                    Bot_Password = "",
                    DcUser = "",
                    GlobalSlot = "",
                    GMSkill = "",
                    GoTown = "",
                    Invisible = "",
                    Invincible = "",
                    LoadMonster = "",
                    Locale = "",
                    MakeItem = "",
                    MoveToUser = "",
                    RecallGuild = "",
                    PvpCape = " ",
                    RecallUser = "",
                    Relog = "",
                    SaveChat = "",
                    SaveUnique = " ",
                    Schedule = "",
                    SendGlobal = " ",
                    SendMessage = "",
                    SendNotice = "",
                    SendPrivate = "",
                    SendPublic = "",
                    ServerPort = "",
                    StallSystem = "",
                    TimerDelay = "",
                    ToTown = "",
                    Version = " ",
                    Warp = "",
                    Xtrap = "",
                },
                DropGoldAmountCoef = "",
                DropItemRatio = "",
                exchangeGoldLimit = "",
                ExpRatio = "",
                ExpRatioParty = "",
                fixes = new Confing.Fixes()
                {
                    disableDumps = " ",
                    disableGreenBook = "",
                    fixRates = "",
                },
                IP = "",
                levelCap = "",
                masteryCap = "",
                MaxPlayerInServer = "",
                miscini = new Confing.Miscini()
                {
                    disableBsobjMsgbox = "",
                    disableLog = "",
                    disableMsg = "",
                },
                petLevelCap = "",
                Port_IIS = "",
                ServerName = "",
                settingInI = new Confing.SettingInI()
                {
                    Agent = "",
                    AutoEnc = "",
                    Cert = "",
                    Download = "",
                    Farm = "",
                    GameServer = "",
                    Gateway = "",
                    Global = "",
                    Machine = "",
                    PathDirMedia = "",
                    Shard = "",
                    SMC = "",
                },
                sql = new Confing.Sql()
                {
                    Host = "",
                    Password = "",
                    User = "",
                },
                stallGoldLimit = "",
                tableName = new Confing.TableName()
                {
                    VsroAccount = "",
                    VsroLog = "",
                    VsroSharad = "",
                },
                USER_LIMIT = "",
                Dirs = new Confing.Dir()
                {
                    DirData = "",
                    DirMap = "",
                    DirMedia = "",
                    DirMusic = "",
                    DirParticles = ""
                },
            };


            var opt = new JsonSerializerOptions() { WriteIndented = true, IncludeFields = true };

            string strJson = JsonSerializer.Serialize(confing, opt);

            if (System.IO.File.Exists("SystemTestModels.json"))
            {
                System.IO.File.Delete("SystemTestModels.json");
            }

            System.IO.File.WriteAllText("SystemTestModels.json", strJson);


        }

        private void Logs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Logs.Items.Count > 0 && Logs.SelectedIndex > -1)
            {
                var GetFristLog = Logs.SelectedItem.ToString().Split(']');
                MessageBox.Show(GetFristLog[1], GetFristLog[0].Replace("[", ""));
            }
        }

        private void BtnTestLib_Click(object sender, EventArgs e)
        {
            DTM.Run i = new DTM.Run();
            i.ChangeData += delegate (string s) { this.Logs.AddLogs(s); };
            i.Start(Extensions.ConfingModels.settingInI.PathDirMedia.RepServer(),
                Extensions.ConfingModels.tableName.VsroSharad.RepServer(),
                Extensions.ConfingModels.sql.Host.RepServer(),
                Extensions.ConfingModels.sql.User.RepServer(),
                Extensions.ConfingModels.sql.Password.RepServer());

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Logs.Items.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (bot != null)
            {
                string MyQuery = @"
INSERT INTO [dbo].[iLegend_Tool] 
( [Service], [Type], [Target], [Message], [RefMobID], 
  [RefItemID], [Amount], [OptLvl], [RegionID], [PosX], 
[PosY], [PosZ], [WorldID], [CapeColor], [StallTitle],
[StallGreating], [StallSlot], [InvSlot], [ItemCount], 
[ItemPrice], [Date])
VALUES ( 1, N'DropItem', NULL, NULL, NULL, N'11', N'1', NULL, NULL, NULL, 
NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1'
, N'null', N'Aug  {0} 2023  {1}PM') ";
                bot.QueryExecute(string.Format(MyQuery, DateTime.Now.Day, DateTime.Now.ToString("hh:mm"), DateTime.Now.ToString("MMM")));
            }
        }

        private void BtnMapEditor_Click(object sender, EventArgs e)
        {
            /*
                         this.Hide();
                        var Pt = ExtensionsClass.Extensions.ConfingModels;
                        AsiaMapEditor.MainForms form1 = new AsiaMapEditor.MainForms(Pt.Dirs.DirMap.RepServer(), Pt.Dirs.DirData.RepServer());
                        form1.ShowDialog();
                        this.Show();
             */

            MapsBlocks maps = new MapsBlocks() { };
            maps.ShowDialog();
        }

        private void BotOn(object sender, EventArgs e)
        {
            try
            {
                Logs.AddLogs($"init Start Bot");
                if (bot == null)
                {
                    bot = new Bot();
                    bot.BordcastBots += new Bot.eventApp(delegate (string ms) { Logs.AddLogs(ms); });
                    bot.StartBot();
                }
                else
                {
                    Logs.AddLogs("Bot is Open");
                }
                Logs.AddLogs($"init End Bot");
            }
            catch (Exception ex)
            {
                Logs.AddLogs(ex.Message);
            }
        }

        private void BotOFF(object sender, EventArgs e)
        {
            try
            {
                if (bot != null)
                    bot = null;
            }
            catch (Exception)
            {
            }
        }

        private void ConfigBot(object sender, EventArgs e)
        {
            try
            {
                Glabels.ShowFormTask("Config", new ControlUI.ConfigControl("PLBotV1") { AutoScroll = true, });
            }
            catch (Exception)
            {
            }
        }
        SilkroadLauncher.CheckUpdate checkUpdate;
        private void StartSoloPlayerSroClinet_Click(object sender, EventArgs e)
        {
            if (checkUpdate == null)
            {
                checkUpdate = new SilkroadLauncher.CheckUpdate();
                checkUpdate.LogsLauncher += delegate (string logs) { Logs.AddLogs(logs); };
                checkUpdate.CheckUpdatesAsync();
            }
            else
            {

            }
        }

        private void clinetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = EnsureUnpacked(System.Environment.CurrentDirectory, "MangerSroApp.Icon1.ico", "File.ico");


            //foreach (var item in System.Reflection.Assembly.GetExecutingAssembly().())
            //{
            //MessageBox.Show(item);
            //}
        }

        private bool isUnpacked = false;

        public async Task EnsureUnpacked(string saveDirectory,string nameOfFiles,string Org)
        {
            if (!this.isUnpacked)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var assemblyDirectory = Path.GetDirectoryName(assembly.Location);
                //foreach (var name in assembly.GetManifestResourceNames())
                //{
                    var stream = assembly.GetManifestResourceStream(nameOfFiles);

                    //var stringBuilder = new StringBuilder();
                    //var parts = name
                    //    .Replace(typeof(Form1).Namespace + ".", string.Empty)
                    //    .Split('.')
                    //    .ToList();
                    //for (int i = 0; i < parts.Count; ++i)
                    //{
                    //    var part = parts[i];
                    //    if (string.Equals(part, string.Empty))
                    //    {
                    //        stringBuilder.Append(".");      // Append '.' in file name.
                    //    }
                    //    else if (i == parts.Count - 2)
                    //    {
                    //        stringBuilder.Append(part);     // Append file name and '.'.
                    //        stringBuilder.Append('.');
                    //    }
                    //    else if (i == parts.Count - 1)
                    //    {
                    //        stringBuilder.Append(part);     // Append file extension.
                    //    }
                    //    else
                    //    {
                    //        stringBuilder.Append(part);     // Append file path.
                    //        stringBuilder.Append('\\');
                    //    }
                    //}

                    var filePath = Path.Combine(saveDirectory, Org);
                    using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }

                this.isUnpacked = true;
            }
   

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

// _RefEventZone 
// _RefRegionBindAssocServer -> add in app 
// _RefRegion
// _RefGame_World
// _RefGame_World_Config
// 1    277 GROUP_TEMPLE_HARO   ENTER_GATE_TARGAET_X	8240	FLOAT32
// 1	 278	GROUP_TEMPLE_HARO	ENTER_GATE_TARGAET_Y	102	FLOAT32
// 1	279	GROUP_TEMPLE_HARO	ENTER_GATE_TARGAET_Z	37	FLOAT32
// 1	280	GROUP_TEMPLE_HARO	LEAVE_GATE_REGION	-32754	INT32
// 1	281	GROUP_TEMPLE_HARO	LEAVE_GATE_X	7986	FLOAT32
// 1	282	GROUP_TEMPLE_HARO	LEAVE_GATE_Y	128	FLOAT32
// 1	283	GROUP_TEMPLE_HARO	LEAVE_GATE_Z	25	FLOAT32
// 1	284	GROUP_TEMPLE_HARO	LEAVE_GATE_TARGAET_REGION	-32752	INT32
// 1	285	GROUP_TEMPLE_HARO	LEAVE_GATE_TARGAET_X	7696	FLOAT32
// 1	286	GROUP_TEMPLE_HARO	LEAVE_GATE_TARGAET_Y	112	FLOAT32
// 1	287	GROUP_TEMPLE_HARO	LEAVE_GATE_TARGAET_Z	26	FLOAT32
// 1	317	GROUP_TEMPLE_HARO	USER_COUNTING_ON_TEMPLE_ASSOCIATION	ON	STRING
// 0	324	GROUP_TEMPLE_HARO	TRADE_CONFLICT_GENERAL_STATE_EXP_RATIO	1	FLOAT32
// 1	370	GROUP_TEMPLE_HARO	FAILED_ENTER_WORLD_TO_SPECIAL_TARGET_SWITCH	ON	STRING
// 1	371	GROUP_TEMPLE_HARO	FAILED_ENTER_WORLD_TO_SPECIAL_TARGET_GAMEWORLD_THIEF	INS_DEFAULT	STRING

