using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.ExtensionsClass
{
    internal static class Extensions
    {
        public static string Rep(this string Code)
        {
            if (Code == "0")
            {
                return "true";
            }
            else if (Code == "1")
            {
                return "false";
            }

            return Code.Replace("@@@", "\\");
        }

        public static string RepServer(this string Code)
        {
            if (Code.ToLower() == "true")
            {
                return "1";
            }
            else if (Code.ToLower() == "false")
            {
                return "0";
            }


            return Code.Replace("@@@", "\\").Replace("@@@@@@", "@@@");
        }

        public static string RepValue(this string Code)
        {
            return Code.Replace("[name]", Extensions.ConfingModels.ServerName.RepServer())
                       .Replace("[Host]", Extensions.ConfingModels.sql.Host.RepServer())
                       .Replace("[VsroSharad]", Extensions.ConfingModels.tableName.VsroSharad.RepServer())
                       .Replace("[VsroAccount]", Extensions.ConfingModels.tableName.VsroAccount.RepServer())
                       .Replace("[VsroLog]", Extensions.ConfingModels.tableName.VsroLog.RepServer())
                       .Replace("[User]", Extensions.ConfingModels.sql.User.RepServer())
                       .Replace("[PassWorld]", Extensions.ConfingModels.sql.Password.RepServer())
                       .Replace("[ExpRatio]", Extensions.ConfingModels.ExpRatio.RepServer())
                       .Replace("[ExpRatioParty]", Extensions.ConfingModels.ExpRatioParty.RepServer())
                       .Replace("[DropItemRatio]", Extensions.ConfingModels.DropItemRatio.RepServer())
                       .Replace("[DropGoldAmountCoef]", Extensions.ConfingModels.DropGoldAmountCoef.RepServer())
                       .Replace("[SetIP]", Extensions.ConfingModels.IP)
                       .Replace("[IISPort]", Extensions.ConfingModels.Port_IIS)
                       .Replace("[USER_LIMIT]", Extensions.ConfingModels.USER_LIMIT.RepServer())
                       .Replace("[levelCap]", Extensions.ConfingModels.levelCap)
                       .Replace("[petLevelCap]", Extensions.ConfingModels.petLevelCap)
                       .Replace("[masteryCap]", Extensions.ConfingModels.masteryCap)
                       .Replace("[exchangeGoldLimit]", Extensions.ConfingModels.exchangeGoldLimit)

                       .Replace("[disableMsg]", Extensions.ConfingModels.miscini.disableMsg.RepServer())
                       .Replace("[disableLog]", Extensions.ConfingModels.miscini.disableLog.RepServer())
                       .Replace("[disableBsobjMsgbox]", Extensions.ConfingModels.miscini.disableBsobjMsgbox.RepServer())

                       .Replace("[disableDumps]", Extensions.ConfingModels.fixes.disableDumps)
                       .Replace("[fixRates]", Extensions.ConfingModels.fixes.fixRates)
                       .Replace("[disableGreenBook]", Extensions.ConfingModels.fixes.disableGreenBook)

                       .Replace("[AutoEnc]", Extensions.ConfingModels.settingInI.AutoEnc)
                       .Replace("[PathDirMedia]", Extensions.ConfingModels.settingInI.PathDirMedia)
                       .Replace("[Agent]", Extensions.ConfingModels.settingInI.Agent)
                       .Replace("[Cert]", Extensions.ConfingModels.settingInI.Cert)
                       .Replace("[Download]", Extensions.ConfingModels.settingInI.Download)
                       .Replace("[Farm]", Extensions.ConfingModels.settingInI.Farm)
                       .Replace("[GameServer]", Extensions.ConfingModels.settingInI.GameServer)
                       .Replace("[Gateway]", Extensions.ConfingModels.settingInI.Gateway)
                       .Replace("[Global]", Extensions.ConfingModels.settingInI.Global)
                       .Replace("[Machine]", Extensions.ConfingModels.settingInI.Machine)
                       .Replace("[Shard]", Extensions.ConfingModels.settingInI.Shard)
                       .Replace("[SMC]", Extensions.ConfingModels.settingInI.SMC)

                       .Replace("[stallGoldLimit]", Extensions.ConfingModels.stallGoldLimit);


            ;
        }




        public static Confing ConfingModels
        {
            get
            {
                //if (_ConfingModels == null)
                //{
                //    _ConfingModels = ;
                //}
                return confingObject();
            }

        }

        public static Confing confingObject()
        {


            var GetJsonTxt = System.IO.File.ReadAllText("System.json").Replace("\\", "@@@");
            return JsonSerializer.Deserialize<Confing>(GetJsonTxt.Replace("@@@@@@", "@@@"));
        }

        public static string SetIPPrivilegedIP()
        {
            using (var dbacc = new DotNet.VSRO_AccountEntities())
            {
                const long IP1 = 1;
                const long IP2 = 256;
                const long IP3 = 65536;
                const long IP4 = 16777216;

                string[] GetMyIP = ConfingModels.IP.Split('.');

                long _GetMyIP1 = IP1 * Convert.ToInt64(GetMyIP[0]);
                long _GetMyIP2 = IP2 * Convert.ToInt64(GetMyIP[1]);
                long _GetMyIP3 = IP3 * Convert.ToInt64(GetMyIP[2]);
                long _GetMyIP4 = IP4 * Convert.ToInt64(GetMyIP[3]);

                long OutPut = _GetMyIP1 + _GetMyIP2 + _GetMyIP3 + _GetMyIP4;
                var SetValue = ((Convert.ToInt64(GetMyIP[3]) >= 127) ? "-" : "") + OutPut.ToString();
                dbacc.SetIPPrivilegedIP(Convert.ToInt32(SetValue));
                return SetValue;
            }
        }

        internal static void WriteMiltFiles(string[] Data, string[] FilesPaths)
        {
            for (int i = 0; i < FilesPaths.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(FilesPaths[i]))
                {
                    var Paths = FilesPaths[i];
                    string value = Data[i].RepServer();
                    var FullPathing = System.IO.Path.GetFullPath(Paths);
                    if (!System.IO.File.Exists(FullPathing))
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(FullPathing));
                    }
                    System.IO.File.WriteAllText(Paths, value);
                }
            }
        }


        public static void SetFunToolEvent(
                    string Amount = "",
                    string CapeColor = "",
                    string Date = "",
                    string InvSlot = "",
                    string WorldID = "",
                    string ItemCount = "",
                    string ItemPrice = "",
                    string Message = "",
                    string Target = "",
                    string Type = "",
                    string OptLvl = "",
                    int Service = 1,
                    int ID = 0,
                    string PosX = "",
                    string PosY = "",
                    string PosZ = "",
                    string RefItemID = "",
                    string RefMobID = "",
                    string RegionID = "",
                    string StallGreating = "",
                    string StallSlot = "",
                    string StallTitle = ""
            )
        {
            using (var db = new DotNet.VSRO_LOGEntities())
            {
                db.f_AddRecoradILeginTool(
                    amount: string.IsNullOrEmpty(Amount) ? "" : Amount,
                    capeColor: string.IsNullOrEmpty(CapeColor) ? "" : CapeColor,
                    invSlot: string.IsNullOrEmpty(InvSlot) ? "" : InvSlot,
                    type: string.IsNullOrEmpty(Type) ? "" : Type,
                    worldID: string.IsNullOrEmpty(WorldID) ? "" : WorldID,
                    itemCount: string.IsNullOrEmpty(ItemCount) ? "" : ItemCount,
                    itemPrice: string.IsNullOrEmpty(ItemPrice) ? "" : ItemPrice,
                    message: string.IsNullOrEmpty(Message) ? "" : Message,
                    target: string.IsNullOrEmpty(Target) ? "" : Target,
                    optLvl: string.IsNullOrEmpty(OptLvl) ? "" : OptLvl,
                    posX: string.IsNullOrEmpty(PosX) ? "" : PosX,
                    posY: string.IsNullOrEmpty(PosY) ? "" : PosY,
                    posZ: string.IsNullOrEmpty(PosZ) ? "" : PosZ,
                    refItemID: string.IsNullOrEmpty(RefItemID) ? "" : RefItemID,
                    refMobID: string.IsNullOrEmpty(RefMobID) ? "" : RefMobID,
                    regionID: string.IsNullOrEmpty(RegionID) ? "" : RegionID,
                    stallGreating: string.IsNullOrEmpty(StallGreating) ? "" : StallGreating,
                    stallSlot: string.IsNullOrEmpty(StallSlot) ? "" : StallSlot,
                    stallTitle: string.IsNullOrEmpty(StallTitle) ? "" : StallTitle);
            }
        }













        














    }
}
