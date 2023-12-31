﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MangerSroApp {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Files {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Files() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MangerSroApp.Files", typeof(Files).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [Server]
        ///IP = [SetIP]
        ///ShardNameSupportChinese = BetaTest....
        /// </summary>
        internal static string CustomCertification_ini_Server_IP {
            get {
                return ResourceManager.GetString("CustomCertification_ini_Server IP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [global]
        ///Count = 1
        ///[entry0]
        ///id = 335
        ///operation_type = 22
        ///name=SRO Vietnam TestLocal
        ///wip=[SetIP]
        ///nip=[SetIP]
        ///machine_manager_node_id = 699.
        /// </summary>
        internal static string CustomCertification_ini_srNodeType {
            get {
                return ResourceManager.GetString("CustomCertification_ini_srNodeType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [global]
        ///Count = 1
        ///[entry0]
        ///id = 64
        ///global_operation_id = 20
        ///operation_type = 22
        ///name =[name]
        ///query=DRIVER={SQL Server};SERVER=[Host];DSN=[VsroSharad];UID=[User];PWD=[PassWorld];DATABASE=[VsroSharad]
        ///query_log=DRIVER={SQL Server};SERVER=[Host];DSN=[VsroLog];UID=[User];PWD=[PassWorld];DATABASE=[VsroLog]
        ///capacity = 1000
        ///shard_manager_node_id = 705
        ///u1 = 240
        ///u2 = 208
        ///u3 = 17
        ///u4 = 1
        ///u5 = 0
        ///u6 = 0
        ///u7 = 0
        ///.
        /// </summary>
        internal static string CustomCertification_ini_srShard {
            get {
                return ResourceManager.GetString("CustomCertification_ini_srShard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Common {
        ///	debug_option_debugger_present {
        ///		DEBUG_OPTION_ASSERT_SHOW_MESSAGEBOX_OKCANCEL,
        ///		DEBUG_OPTION_ASSERT_ADVANCE_BREAK,
        ///		DEBUG_OPTION_ASSERT_CANCEL_EXIT
        ///	}
        ///	debug_option_stand_alone {			
        ///		DEBUG_OPTION_ASSERT_DONOT_SHOW_MESSAGEBOX ,
        ///		DEBUG_OPTION_ASSERT_WRITE_MINIDUMP
        ///	}
        ///	netengine_debug_option_debugger_present	{
        ///		DEBUG_OPTION_ASSERT_DONOT_SHOW_MESSAGEBOX ,
        ///		DEBUG_OPTION_ASSERT_WRITE_MINIDUMP
        ///	}
        ///	netengine_debug_option_stand_alone	{
        ///		DEBUG_OPTION_ASSERT_DONOT_SHOW_MESSAGEBOX ,
        ///		 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ServerFile {
            get {
                return ResourceManager.GetString("ServerFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///*/
        ///
        ///SMC {	
        ///DivisionManager &quot;[SetIP]&quot;,15880
        ///}
        ///
        ///ModulePatch
        ///{
        ///	SrcPath	&quot;.\Patch_Internal&quot;
        ///	DestPath &quot;.\Patch_Internal_Comp&quot;
        ///}.
        /// </summary>
        internal static string ServiceManager {
            get {
                return ResourceManager.GetString("ServiceManager", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [CONNECTION]
        ///Host=[Host]
        ///User=[User]
        ///Pass=[PassWorld]
        ///Db=[VsroSharad]
        ///[SKILLDATA]
        ///AutoEnc=[AutoEnc]
        ///[BASECODE]
        ///PathDirMedia=[PathDirMedia]
        ///[Server]
        ///Cert=[Cert]
        ///Global=[Global]
        ///Machine=[Machine]
        ///Download=[Download]
        ///Gateway=[Gateway]
        ///Farm=[Farm]
        ///Agent=[Agent]
        ///Shard=[Shard]
        ///GameServer=[GameServer]
        ///SMC=[SMC]
        ///
        ///.
        /// </summary>
        internal static string settingINI {
            get {
                return ResourceManager.GetString("settingINI", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///*/
        ///
        ///SMC {	
        ///DivisionManager &quot;[SetIP]&quot;,15880
        ///}
        ///
        ///ModulePatch
        ///{
        ///	SrcPath	&quot;.\Patch_Internal&quot;
        ///	DestPath &quot;.\Patch_Internal_Comp&quot;
        ///}.
        /// </summary>
        internal static string SMC_ServiceManager {
            get {
                return ResourceManager.GetString("SMC_ServiceManager", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GatewayServer {
        ///
        ///	&quot;[SetIP]&quot;	
        ///	
        ///}.
        /// </summary>
        internal static string SMC_smc_updater {
            get {
                return ResourceManager.GetString("SMC_smc_updater", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [common]
        ///levelCap=[levelCap]
        ///petLevelCap=[petLevelCap]
        ///masteryCap=[masteryCap]
        ///enableDynamicEuroMastery=1
        ///
        ///[rates]
        ///customSPrate=50
        ///jobExpRate=10
        ///thiefGoldRateMultiplier=20
        ///
        ///[user]
        ///exchangeGoldLimit=[exchangeGoldLimit]
        ///stallGoldLimit=[stallGoldLimit]
        ///
        ///[arenaRewards]
        ///rewardItemCode=ITEM_ETC_ARENA_COIN
        ///rewardItemParam1=0
        ///rewardItemParam2=0
        ///rewardItemParam3=1
        ///rewardItemParam4=0
        ///rewardItemParam5=0
        ///rewardItemParam6=0
        ///rewardItemParam7=0
        ///rewardItemParam8=1
        ///guildJobArenaWin=7
        ///guildJobArenaL [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string srZor_cfg_common {
            get {
                return ResourceManager.GetString("srZor_cfg_common", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [fixes]
        ///disableDumps = [disableDumps]
        ///fixRates = [fixRates]
        ///disableGreenBook = [disableGreenBook].
        /// </summary>
        internal static string srZor_cfg_fixes {
            get {
                return ResourceManager.GetString("srZor_cfg_fixes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [misc]
        ///disableMsg = [disableMsg]
        ///disableLog = [disableLog]
        ///disableBsobjMsgbox=[disableBsobjMsgbox]
        ///
        ///[spoof]
        ///spoofIP = 0
        ///spoofIPaddr = [SetIP]
        ///.
        /// </summary>
        internal static string srZor_cfg_misc {
            get {
                return ResourceManager.GetString("srZor_cfg_misc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [query]
        ///query=update tb_user set password=&apos;&apos; where struserid=&apos;&apos;.
        /// </summary>
        internal static string srZor_cfg_query {
            get {
                return ResourceManager.GetString("srZor_cfg_query", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [sqlAcc]
        ///sqlHostDB=[Host]@[VsroAccount]
        ///accDB=[VsroAccount]
        ///sqlUser=[User]
        ///sqlPass=[PassWorld]
        ///
        ///[sqlShard]
        ///sqlHostDB=[Host]@[VsroSharad]
        ///shardDB=[VsroSharad]
        ///sqlUser=[User]
        ///sqlPass=[PassWorld].
        /// </summary>
        internal static string srZor_cfg_sql {
            get {
                return ResourceManager.GetString("srZor_cfg_sql", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to //setting both reward and amount 0 will make user get nothing from specific unique.
        /////you can add your own unique reward blocks in this file
        ///[unique]
        ///enableUniqueReward = 1
        ///
        ///[MOB_CH_TIGERWOMAN]
        ///reward=3795
        ///amount=1
        ///silk=0
        ///
        ///[MOB_OA_URUCHI]
        ///reward=0
        ///amount=0
        ///silk=0
        ///
        ///[MOB_KK_ISYUTARU]
        ///reward=0
        ///amount=0
        ///silk=0
        ///
        ///[MOB_TK_BONELORD]
        ///reward=0
        ///amount=0
        ///silk=0
        ///
        ///[MOB_RM_TAHOMET]
        ///reward=0
        ///amount=0
        ///silk=0
        ///
        ///[MOB_EU_KERBEROS]
        ///reward=0
        ///amount=0
        ///silk=0
        ///
        ///[MOB_AM_IVY]
        ///reward=0
        ///amount=0
        ///sil [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string srZor_cfg_unique {
            get {
                return ResourceManager.GetString("srZor_cfg_unique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [sqlAcc]
        ///sqlHostDB=[Host]@[VsroAccount]
        ///accDB=[VsroAccount]
        ///sqlUser=[User]
        ///sqlPass=[PassWorld]
        ///
        ///[sqlShard]
        ///sqlHostDB=[Host]@[VsroSharad]
        ///shardDB=[VsroSharad]
        ///sqlUser=[User]
        ///sqlPass=[PassWorld].
        /// </summary>
        internal static string srZor_sql {
            get {
                return ResourceManager.GetString("srZor_sql", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {
        ///  &quot;ServerName&quot;: &quot;AsiaSro&quot;,
        ///  &quot;IP&quot;: &quot;192.168.1.9&quot;,
        ///  &quot;Port_IIS&quot;: &quot;4282&quot;,
        ///  &quot;ExpRatio&quot;: &quot;5000&quot;,
        ///  &quot;ExpRatioParty&quot;: &quot;5000&quot;,
        ///  &quot;DropItemRatio&quot;: &quot;5000&quot;,
        ///  &quot;DropGoldAmountCoef&quot;: &quot;6000&quot;,
        ///  &quot;USER_LIMIT&quot;: &quot;100&quot;,
        ///  &quot;levelCap&quot;: &quot;100&quot;,
        ///  &quot;petLevelCap&quot;: &quot;100&quot;,
        ///  &quot;masteryCap&quot;: &quot;300&quot;,
        ///  &quot;exchangeGoldLimit&quot;: &quot;10000000000&quot;,
        ///  &quot;stallGoldLimit&quot;: &quot;10000000000&quot;,
        ///  &quot;MaxPlayerInServer&quot;:&quot;2000&quot;,
        ///  &quot;sql&quot;: {
        ///    &quot;Host&quot;: &quot;DESKTOP-5H87KA2@@@SQLEXPRESS&quot;,
        ///    &quot;Password&quot;: &quot;amir2011.&quot;,
        ///    &quot;User&quot;: &quot;TheRock&quot;
        ///  },
        ///  &quot;ta [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SystemJsonDef {
            get {
                return ResourceManager.GetString("SystemJsonDef", resourceCulture);
            }
        }
    }
}
