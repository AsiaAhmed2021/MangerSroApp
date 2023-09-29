using MangerSroApp.ExtensionsClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.ControlUI
{
    public partial class ConfigControl : UserControl
    {
        public delegate void ChangePath(TextBox TargetBox);
        public event ChangePath EventChangePath;
        public ConfigControl()
        {
            try
            {
                InitializeComponent();
                RefreshData();

                //PLBotV1

            }
            catch (Exception)
            {
            }
        }

        public ConfigControl(string DataRL)
        {
            try
            {
                InitializeComponent();
                RefreshData();

             if (!string.IsNullOrEmpty(DataRL))
                    ChangeUIPL(DataRL);
            }
            catch (Exception)
            {
            }
        }

        public void Save()
        {
            var OutObj = new Confing()
            {
                DropGoldAmountCoef = txtDropGoldAmountCoef.Text.RepServer(),
                ExpRatio = txtExpRatio.Text.RepServer(),
                DropItemRatio = txtDropItemRatio.Text.RepServer(),
                exchangeGoldLimit = txtDropGoldAmountCoef.Text.RepServer(),
                ExpRatioParty = txtDropGoldAmountCoef.Text.RepServer(),
                IP = txtIP.Text.RepServer(),
                levelCap = txtlevelCap.Text.RepServer(),
                masteryCap = txtMasteryCap.Text.RepServer(),
                MaxPlayerInServer = txtMaxPlayerInServer.Text.RepServer(),
                petLevelCap = txtPetLevelCap.Text.RepServer(),
                Port_IIS = txtPort.Text.RepServer(),
                ServerName = txtServerName.Text.RepServer(),
                stallGoldLimit = txtStallGoldLimit.Text.RepServer(),
                USER_LIMIT = txtUSER_LIMIT.Text.RepServer(),
                fixes = new Confing.Fixes()
                {
                    disableDumps = txtdisableDumps.Text.RepServer(),
                    disableGreenBook = txtdisableGreenBook.Text.RepServer(),
                    fixRates = txtFixRates.Text.RepServer(),
                },
                miscini = new Confing.Miscini()
                {
                    disableBsobjMsgbox = txtDisableBsobjMsgbox.Text.RepServer(),
                    disableLog = txtdisableLog.Text.RepServer(),
                    disableMsg = txtdisableMsg.Text.RepServer(),
                },
                tableName = new Confing.TableName()
                {
                    VsroAccount = txtVsroAccount.Text.RepServer(),
                    VsroLog = txtVsroLog.Text.RepServer(),
                    VsroSharad = txtVsroSharad.Text.RepServer(),
                },
                sql = new Confing.Sql()
                {
                    Host = txtHost.Text.RepServer(),
                    Password = txtPassword.Text.RepServer(),
                    User = txtUser.Text.RepServer(),
                },
                settingInI = new Confing.SettingInI()
                {
                    Agent = txtAgent.Text.RepServer(),
                    AutoEnc = txtAutoEnc.Text.RepServer(),
                    Cert = txtCert.Text.RepServer(),
                    Download = txtDownload.Text.RepServer(),
                    Farm = txtFarm.Text.RepServer(),
                    GameServer = txtGameServer.Text.RepServer(),
                    Gateway = txtGateway.Text.RepServer(),
                    Global = txtGlobal.Text.RepServer(),
                    Machine = txtMachine.Text.RepServer(),
                    PathDirMedia = txtPathDirMedia.Text.RepServer(),
                    Shard = txtShard.Text.RepServer(),
                    SMC = txtSMC.Text.RepServer(),
                },
                bot = new Confing.BotAppV1()
                {
                    BotName = txtBotName.Text.RepServer(),
                    Bot_ID = txtBot_ID.Text.RepServer(),
                    Bot_Password = txtBot_Password.Text.RepServer(),
                    DcUser = txtDcUser.Text.RepServer(),
                    GlobalSlot = txtGlobalSlot.Text.RepServer(),
                    GMSkill = txtGMSkill.Text.RepServer(),
                    GoTown = txtGoTown.Text.RepServer(),
                    Invisible = txtInvisible.Text.RepServer(),
                    Invincible = txtInvincible.Text.RepServer(),
                    LoadMonster = txtLoadMonster.Text.RepServer(),
                    Locale = txtLocale.Text.RepServer(),
                    MakeItem = txtMakeItem.Text.RepServer(),
                    MoveToUser = txtMoveToUser.Text.RepServer(),
                    RecallGuild = txtRecallGuild.Text.RepServer(),
                    RecallUser = txtRecallUser.Text.RepServer(),
                    PvpCape = txtPvpCape.Text.RepServer(),
                    Relog = txtRelog.Text.RepServer(),
                    SaveChat = txtSaveChat.Text.RepServer(),
                    SaveUnique = txtSaveUnique.Text.RepServer(),
                    Schedule = txtSchedule.Text.RepServer(),
                    SendGlobal = txtSendGlobal.Text.RepServer(),
                    SendMessage = txtSendMessage.Text.RepServer(),
                    SendNotice = txtSendNotice.Text.RepServer(),
                    SendPrivate = txtSendPrivate.Text.RepServer(),
                    SendPublic = txtSendPublic.Text.RepServer(),
                    ServerPort = txtServerPort.Text.RepServer(),
                    StallSystem = txtStallSystem.Text.RepServer(),
                    TimerDelay = txtTimerDelay.Text.RepServer(),
                    ToTown = txtToTown.Text.RepServer(),
                    Version = txtVersion.Text.RepServer(),
                    Warp = txtWarp.Text.RepServer(),
                    Xtrap = txtXtrap.Text.RepServer(),
                },
                Dirs = new Confing.Dir()
                {
                    DirData = txtDirData.Text.RepServer(),
                    DirMap = txtDirMap.Text.RepServer(),
                    DirParticles = txtDirParticles.Text.RepServer(),
                    DirMedia = txtDirMedia.Text.RepServer(),
                    DirMusic = txtDirMusic.Text.RepServer(),
                },
            };

            var opt = new JsonSerializerOptions() { WriteIndented = true, IncludeFields = true };

            string strJson = JsonSerializer.Serialize(OutObj, opt);

            if (System.IO.File.Exists("System.json"))
            {
                System.IO.File.Delete("System.json");
            }

            System.IO.File.WriteAllText("System.json", strJson);
        }

        public void RefreshData()
        {
            var OutOjb = Extensions.ConfingModels;
            txtdisableDumps.Text = OutOjb.fixes.disableDumps.Rep(); //Fixes
            txtFixRates.Text = OutOjb.fixes.fixRates.Rep();
            txtdisableGreenBook.Text = OutOjb.fixes.disableGreenBook.Rep();
            txtdisableMsg.Text = OutOjb.miscini.disableMsg.Rep(); //miscini
            txtdisableLog.Text = OutOjb.miscini.disableLog.Rep();
            txtDisableBsobjMsgbox.Text = OutOjb.miscini.disableBsobjMsgbox.Rep();
            txtHost.Text = OutOjb.sql.Host.Rep();  //Sql
            txtUser.Text = OutOjb.sql.User.Rep();
            txtPassword.Text = OutOjb.sql.Password.Rep();
            txtVsroAccount.Text = OutOjb.tableName.VsroAccount.Rep();  //Tables
            txtVsroLog.Text = OutOjb.tableName.VsroLog.Rep();
            txtVsroSharad.Text = OutOjb.tableName.VsroSharad.Rep();
            txtAgent.Text = OutOjb.settingInI.Agent.Rep();  //settingInI
            txtAutoEnc.Text = OutOjb.settingInI.AutoEnc.Rep();
            txtCert.Text = OutOjb.settingInI.Cert.Rep();
            txtDownload.Text = OutOjb.settingInI.Download.Rep();
            txtFarm.Text = OutOjb.settingInI.Farm.Rep();
            txtGameServer.Text = OutOjb.settingInI.GameServer.Rep();
            txtGateway.Text = OutOjb.settingInI.Gateway.Rep();
            txtGlobal.Text = OutOjb.settingInI.Global.Rep();
            txtMachine.Text = OutOjb.settingInI.Machine.Rep();
            txtPathDirMedia.Text = OutOjb.settingInI.PathDirMedia.Rep();
            txtShard.Text = OutOjb.settingInI.Shard.Rep();
            txtSMC.Text = OutOjb.settingInI.SMC.Rep();
            txtExpRatio.Text = OutOjb.ExpRatio.Rep();  //Normal
            txtIP.Text = OutOjb.IP.Rep();
            txtPort.Text = OutOjb.Port_IIS.Rep();
            txtServerName.Text = OutOjb.ServerName.Rep();
            txtExpRatioParty.Text = OutOjb.ExpRatioParty.Rep();
            txtDropItemRatio.Text = OutOjb.DropItemRatio.Rep();
            txtDropGoldAmountCoef.Text = OutOjb.DropGoldAmountCoef.Rep();
            txtUSER_LIMIT.Text = OutOjb.USER_LIMIT.Rep();
            txtlevelCap.Text = OutOjb.levelCap.Rep();
            txtPetLevelCap.Text = OutOjb.petLevelCap.Rep();
            txtMasteryCap.Text = OutOjb.masteryCap.Rep();
            txtExchangeGoldLimit.Text = OutOjb.exchangeGoldLimit.Rep();
            txtStallGoldLimit.Text = OutOjb.stallGoldLimit.Rep();
            txtMaxPlayerInServer.Text = OutOjb.MaxPlayerInServer.Rep();

            txtDirData.Text = OutOjb.Dirs.DirData.Rep();
            txtDirMap.Text = OutOjb.Dirs.DirMap.Rep();
            txtDirParticles.Text = OutOjb.Dirs.DirParticles.Rep();
            txtDirMedia.Text = OutOjb.Dirs.DirMedia.Rep();
            txtDirMusic.Text = OutOjb.Dirs.DirMusic.Rep();

            txtBotName.Text = OutOjb.bot.BotName.Rep();
            txtBot_ID.Text = OutOjb.bot.Bot_ID.Rep();
            txtBot_Password.Text = OutOjb.bot.Bot_Password.Rep();
            txtDcUser.Text = OutOjb.bot.DcUser.Rep();
            txtGlobalSlot.Text = OutOjb.bot.GlobalSlot.Rep();
            txtGMSkill.Text = OutOjb.bot.GMSkill.Rep();
            txtGoTown.Text = OutOjb.bot.GoTown.Rep();
            txtInvisible.Text = OutOjb.bot.Invisible.Rep();
            txtInvincible.Text = OutOjb.bot.Invincible.Rep();
            txtLoadMonster.Text = OutOjb.bot.LoadMonster.Rep();
            txtLocale.Text = OutOjb.bot.Locale.Rep();
            txtMakeItem.Text = OutOjb.bot.MakeItem.Rep();
            txtMoveToUser.Text = OutOjb.bot.MoveToUser.Rep();
            txtRecallGuild.Text = OutOjb.bot.RecallGuild.Rep();
            txtRecallUser.Text = OutOjb.bot.RecallUser.Rep();
            txtPvpCape.Text = OutOjb.bot.PvpCape.Rep();
            txtRelog.Text = OutOjb.bot.Relog.Rep();
            txtSaveChat.Text = OutOjb.bot.SaveChat.Rep();
            txtSaveUnique.Text = OutOjb.bot.SaveUnique.Rep();
            txtSchedule.Text = OutOjb.bot.Schedule.Rep();
            txtSendGlobal.Text = OutOjb.bot.SendGlobal.Rep();
            txtSendMessage.Text = OutOjb.bot.SendMessage.Rep();
            txtSendNotice.Text = OutOjb.bot.SendNotice.Rep();
            txtSendPrivate.Text = OutOjb.bot.SendPrivate.Rep();
            txtSendPublic.Text = OutOjb.bot.SendPublic.Rep();
            txtServerPort.Text = OutOjb.bot.ServerPort.Rep();
            txtStallSystem.Text = OutOjb.bot.StallSystem.Rep();
            txtTimerDelay.Text = OutOjb.bot.TimerDelay.Rep();
            txtToTown.Text = OutOjb.bot.ToTown.Rep();
            txtVersion.Text = OutOjb.bot.Version.Rep();
            txtWarp.Text = OutOjb.bot.Warp.Rep();
            txtXtrap.Text = OutOjb.bot.Xtrap.Rep();

        }

        private void SelApp(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                label1.Text = $" *** {txt.PlaceholderText} ***";



                if (EventChangePath != null)
                {
                    EventChangePath.Invoke(txt);
                }

                if (txt.Tag.ToString().ToLower() == "isdir".ToLower())
                {
                    OpenDir(txt);
                }
                else if (txt.Tag.ToString().ToLower() == "isfile".ToLower())
                {
                    OpenDir(txt);
                }

            }
        }

        void OpenDir(TextBox txt)
        {
            using (var od = new FolderBrowserDialog() { ShowNewFolderButton = true, Description = txt.PlaceholderText, UseDescriptionForTitle = true, AutoUpgradeEnabled = true, RootFolder = Environment.SpecialFolder.DesktopDirectory, })
            {
                if (od.ShowDialog() == DialogResult.OK || od.ShowDialog() == DialogResult.Yes)
                {
                    txt.Text = od.SelectedPath;
                }
            }
        }






        private void button1_Click(object sender, EventArgs e)
        {
            string _IP = LocalIP.GetLocalIPAddress();
            txtIP.Text = _IP;
            //Logs.AddLogs("Your IP is " + _IP);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label1.Text = "*** Refresh Config ***";
            //RefreshData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Text = "*** Save Config ***";
            Save();


        }

        public void ChangeUIPL(string NameControl)
        {
            // List<Panel> panels = new List<Panel>() { PLBaseConnecting, PLFixes, PLMiscini, PLNomalData, PLSettingInI, PLSQL, PLTableName };

            foreach (Panel item in PLHOME.Controls)
            {
                if (item.Name == NameControl)
                {
                    item.Dock = DockStyle.Fill;
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                    item.Dock = DockStyle.None;
                }
            }

            //var GetControl = panels.Where(a => a.Name == NameControl).FirstOrDefault();
            //
            //if (GetControl != null)
            //{
            //    GetControl.Dock = DockStyle.Fill;
            //    GetControl.Visible = true;
            //}


        }

        private void OpenPL(object sender, EventArgs e)
        {
            if (sender is Button GetBtn)
                ChangeUIPL(GetBtn.Tag.ToString());
        }

        private void PLHOME_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
