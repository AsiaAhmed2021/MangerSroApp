using DevComponents.DotNetBar;
using SilkroadSecurityApi;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace vSroMultiTool
{
    partial class App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Propertys
        public int IsConnected = 0;
        public static SqlConnection sqlshardlog;
        public static SqlConnection sqlshard;
        public static SqlConnection sqlaccount;
        public SqlDataReader reader;
        public string Directory = Environment.CurrentDirectory;
        public string HideMsg = "Tool SRO";
        public Timer Ping;
        private Timer t1 = new Timer();
        public NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showBotToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem closeBotToolStripMenuItem;
        public ListBox listBox1;
        public TextBox server_label;
        public TextBox player_label;
        public TextBox label16;
        public Button SaveConfig;
        public Button LoadConfig;
        private Button MiniMize;
        private Button button5;
        public Timer Execute;
        private PictureBox pictureBox5;
        private Label label102;
        private Label label108;
        private Label label107;
        private Label label26;
        private Label label106;
        private Label label105;
        private Label label98;
        public TextBox HwanLvl;
        private Label label109;
        private Label label104;
        public TextBox RGold;
        public TextBox InvSize;
        public TextBox StatPoint;
        public TextBox MaxLvl;
        public TextBox CurLvl;
        private Label label94;
        public TextBox CInt;
        private Label label93;
        public TextBox CStr;
        public TextBox JobLvl;
        public TextBox Sp;
        public TextBox JobType;
        public TextBox Exp;
        public TextBox NkName16;
        private Label label101;
        public TextBox CName16;
        private Label label96;
        private Label label97;
        public TextBox CID;
        public TextBox CNameSearch;
        private Label label99;
        private Label label36;
        private Label label92;
        private RadioButton Shipwreck2;
        private RadioButton Shipwreck1;
        private RadioButton Flame;
        private RadioButton Togui;
        private PictureBox pictureBox14;
        private PictureBox pictureBox13;
        private PictureBox pictureBox12;
        private PictureBox pictureBox11;
        private PictureBox pictureBox10;
        private PictureBox pictureBox9;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        public TextBox textBox20;
        private Label label110;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        public TextBox textBox3;
        public TextBox textBox4;
        private Label label56;
        private Label label54;
        private Label label27;
        private Label label55;
        public TextBox textBox12;
        private Label label67;
        public TextBox textBox9;
        private Label label65;
        public TextBox textBox8;
        private Label label64;
        public TextBox textBox7;
        private Label label63;
        public TextBox textBox13;
        private Label label68;
        public TextBox textBox6;
        private Label label60;
        private Label label61;
        public TextBox textBox5;
        public TextBox textBox11;
        public TextBox textBox10;
        private Label label66;
        public TextBox textBox2;
        public TextBox textBox1;
        private Label label52;
        private Label label50;
        public ListView listView2;
        private ColumnHeader JID;
        private ColumnHeader StrUserID;
        private ColumnHeader SilkOwn;
        private ColumnHeader SilkGift;
        private ColumnHeader SilkPoint;
        private Label label71;
        private RadioButton own1;
        private RadioButton point1;
        private RadioButton gift1;
        private Label label75;
        private RadioButton own;
        private RadioButton point;
        private RadioButton gift;
        public TextBox textBox14;
        private Label label69;
        public TextBox textBox15;
        private Label label70;
        private PictureBox pictureBox3;
        private Label label85;
        public TextBox CharGold;
        private Label label84;
        public TextBox CharInt;
        private Label label83;
        public TextBox CharStr;
        private Label label82;
        public TextBox CurrLevel;
        private Label label81;
        public TextBox GuildName;
        private Label label79;
        public TextBox NickName16;
        private Label label80;
        public TextBox CharID;
        private Label label78;
        public TextBox textBox16;
        private Label label74;
        public ListView listView3;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader7;
        public TextBox textBox18;
        public TextBox textBox17;
        private Label label87;
        private Label label86;
        public CheckBox checkBox2;
        public ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private TextBox textBox19;
        private Label label89;
        private Label label90;
        private CheckBox Check_Movetouser;
        private CheckBox Check_RecallGuild;
        private CheckBox Check_ToTown;
        private CheckBox Check_RecallUser;
        private CheckBox Check_DcUser;
        private CheckBox Check_MakeItem;
        private CheckBox Check_GoTown;
        private CheckBox Check_LoadMonster;
        private CheckBox Check_Invincible;
        private CheckBox Check_Warp;
        private CheckBox Check_GMSkill;
        private CheckBox Check_Invisible;
        public CheckBox Check_Incomechat;
        public CheckBox UniqueLogBox;
        private SuperTabControlPanel tabPage1;
        private SuperTabItem superTabItem1;
        private SuperTabControlPanel superTabControlPanel1;
        private SuperTabItem tabPage4;
        private SuperTabControlPanel tabPage3;
        private SuperTabItem superTabItem3;
        public StyleManager styleManager1;
        private Panel MainPanel;
        private Label label103;
        private ButtonX HideTool;
        private SuperTabControl tabControl1;
        public PanelEx panel67;
        private ButtonX button25;
        private Label label42;
        private PanelEx panelEx14;
        private PanelEx panel69;
        private Label label39;
        private ButtonX button28;
        private PanelEx panel62;
        private PanelEx panel63;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ThemeName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx TalismanName;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private PanelEx panel61;
        private ButtonX button27;
        private ButtonX button30;
        private ButtonX button29;
        private PanelEx panelEx16;
        private Label label43;
        private PanelEx panelEx17;
        private ButtonX button24;
        private PanelEx panelEx18;
        private Label label44;
        private PanelEx panel44;
        private PanelEx panel48;
        private PanelEx panel54;
        private PanelEx panel53;
        private PanelEx panel50;
        private PanelEx panel52;
        private PanelEx panel51;
        private PanelEx panel49;
        private PanelEx panel45;
        private ButtonX button21;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBox1;
        private ButtonX button22;
        private PanelEx CharName16;
        private PanelEx panelEx19;
        private Label label45;
        private PanelEx panelEx20;
        private Label label57;
        private PanelEx panel39;
        private PanelEx panel36;
        private PanelEx panel40;
        private ButtonX button19;
        private PanelEx panel38;
        private PanelEx panel43;
        private PanelEx panel42;
        private ButtonX button18;
        private ButtonX button20;
        private ButtonX button17;
        private ButtonX button16;
        private PanelEx panelEx21;
        private PanelEx panelEx22;
        private ButtonX button8;
        private PanelEx panelEx23;
        private ButtonX button12;
        private ButtonX button15;
        private PanelEx panel32;
        private PanelEx panelEx24;
        private ButtonX button9;
        private PanelEx panel28;
        private ButtonX button10;
        private PanelEx panelEx27;
        private PanelEx panel34;
        private ButtonX button13;
        private ButtonX button11;
        private ButtonX button14;
        private ExpandablePanel expandablePanel1;
        private Label label58;
        private Label label72;
        private Label label62;
        private Label label59;
        private Label label53;
        private Label label73;
        private Label label37;
        private Label label76;
        private Label label95;
        private Label label77;
        private Label label100;
        private Label label111;
        public Label label6;
        public TextBox Shard;
        public TextBox Account;
        public TextBox Shardlog;
        public TextBox HostPw;
        public Label label8;
        public TextBox Host;
        public Label label9;
        public TextBox HostUser;
        public Label label12;
        public Label label20;
        public Label label46;
        private Label label23;
        private Label label25;
        private SuperTabControlPanel superTabControlPanel18;
        private SuperTabItem superTabItem21;
        private Panel tabControl2;
        private Panel MainFun;
        private ButtonX buttonX8;
        private ButtonX buttonX7;
        private ButtonX buttonX9;
        private ButtonX buttonX6;
        private ButtonX buttonX4;
        private ButtonX buttonX5;
        private ButtonX buttonX3;
        private ButtonX buttonX2;
        private ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.SlidePanel CharacterPanel;
        private PanelEx panelEx29;
        private ButtonX buttonX12;
        private ButtonX buttonX11;
        private ButtonX buttonX10;
        private ButtonX buttonX13;
        private DevComponents.DotNetBar.Controls.SlidePanel ManageCharPanel;
        private ButtonX buttonX14;
        private DevComponents.DotNetBar.Controls.SlidePanel CollectBookPanel;
        private PanelEx panelEx31;
        private ButtonX buttonX15;
        private DevComponents.DotNetBar.Controls.SlidePanel CharInvPanel;
        private PanelEx panelEx32;
        private ButtonX buttonX16;
        private Label label35;
        private DevComponents.DotNetBar.Controls.SlidePanel UserPanel;
        private PanelEx panelEx33;
        private ButtonX buttonX17;
        private ButtonX buttonX18;
        private ButtonX buttonX19;
        private ButtonX buttonX20;
        private ButtonX buttonX21;
        private DevComponents.DotNetBar.Controls.SlidePanel ManageUserPanel;
        private PanelEx panelEx34;
        private ButtonX buttonX22;
        private DevComponents.DotNetBar.Controls.SlidePanel SilkControlPanel;
        private PanelEx panelEx35;
        private ButtonX buttonX23;
        private DevComponents.DotNetBar.Controls.SlidePanel UserCharPanel;
        private PanelEx panelEx36;
        private ButtonX buttonX24;
        private DevComponents.DotNetBar.Controls.SlidePanel TeamUserPanel;
        private PanelEx panelEx37;
        private ButtonX buttonX25;
        private DevComponents.DotNetBar.Controls.SlidePanel panel6;
        private DevComponents.DotNetBar.Controls.SlidePanel panel47;
        private DevComponents.DotNetBar.Controls.SlidePanel EditUserPanel;
        private PanelEx panelEx25;
        private DevComponents.DotNetBar.Controls.SlidePanel panel57;
        private DevComponents.DotNetBar.Controls.SlidePanel panel60;
        private DevComponents.DotNetBar.Controls.SlidePanel NextUpdatePanel;
        private PanelEx panelEx26;
        private ButtonX buttonX26;
        private Label label14;
        private Label label13;
        private Panel panelEx38;
        private CheckBox Check_Notice;
        private CheckBox Check_Msg;
        private CheckBox Check_ChatAll;
        private CheckBox Check_Private;
        private CheckBox Check_Global;
        private SuperTabControlPanel tabPage2;
        private PanelEx panel1;
        public Panel groupBox3;
        public Label label1;
        public TextBox id;
        public TextBox captcha_text;
        public PictureBox pictureBox1;
        public Label label2;
        public TextBox pw;
        public DevComponents.DotNetBar.Controls.ComboBoxEx char_list;
        public ButtonX button3;
        public ButtonX button4;
        public TextBox slocale;
        public CheckBox Check_AutoRelog;
        public Label label3;
        public TextBox ip;
        public CheckBox checkBox1;
        public Label label4;
        public Label label7;
        public TextBox gateport;
        public TextBox sversion;
        public Label label5;
        private SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem1;
        private Separator separator1;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem2;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem3;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem4;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem5;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem6;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem7;
        private Separator separator2;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem8;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem9;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem10;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem11;
        private DevComponents.DotNetBar.Controls.SideNavItem sideNavItem12;
        public CheckBox Check_StallCreate;
        public CheckBox Check_PvpCape;
        public DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
        private ColumnHeader CharName;
        private ColumnHeader CharUniqueID;
        public Panel Status;
        private Panel panel5;
        public Label txtCharLevel;
        public Label txtCharName;
        private PictureBox PicCharSel;
        private Button button26;
        private Panel groupBox4;
        private Panel PLSQLRange;
        private Button SQLConnect;
        private Panel groupBox1;
        private Button button1;
        private Button button23;
        private Panel panel7;
        public CheckBox StartRelog;
        private Button button2;
        private Timer timer8;
        private Panel panel2;
        public Timer ToolService;
        #endregion

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabControlBoxStateColorTable superTabControlBoxStateColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabControlBoxStateColorTable();
            this.Ping = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolService = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.server_label = new System.Windows.Forms.TextBox();
            this.player_label = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.TextBox();
            this.SaveConfig = new System.Windows.Forms.Button();
            this.LoadConfig = new System.Windows.Forms.Button();
            this.MiniMize = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Execute = new System.Windows.Forms.Timer(this.components);
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.CharGold = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.CharInt = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.CharStr = new System.Windows.Forms.TextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.CurrLevel = new System.Windows.Forms.TextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.GuildName = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.NickName16 = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.CharID = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.JID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StrUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SilkOwn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SilkGift = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SilkPoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label71 = new System.Windows.Forms.Label();
            this.own1 = new System.Windows.Forms.RadioButton();
            this.point1 = new System.Windows.Forms.RadioButton();
            this.gift1 = new System.Windows.Forms.RadioButton();
            this.label75 = new System.Windows.Forms.Label();
            this.own = new System.Windows.Forms.RadioButton();
            this.point = new System.Windows.Forms.RadioButton();
            this.gift = new System.Windows.Forms.RadioButton();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.panelEx14 = new DevComponents.DotNetBar.PanelEx();
            this.label39 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.Shipwreck2 = new System.Windows.Forms.RadioButton();
            this.Shipwreck1 = new System.Windows.Forms.RadioButton();
            this.Flame = new System.Windows.Forms.RadioButton();
            this.Togui = new System.Windows.Forms.RadioButton();
            this.panel69 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX15 = new DevComponents.DotNetBar.ButtonX();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label110 = new System.Windows.Forms.Label();
            this.button28 = new DevComponents.DotNetBar.ButtonX();
            this.label103 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.CName16 = new System.Windows.Forms.TextBox();
            this.label108 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.NkName16 = new System.Windows.Forms.TextBox();
            this.label106 = new System.Windows.Forms.Label();
            this.Exp = new System.Windows.Forms.TextBox();
            this.label105 = new System.Windows.Forms.Label();
            this.JobType = new System.Windows.Forms.TextBox();
            this.HwanLvl = new System.Windows.Forms.TextBox();
            this.Sp = new System.Windows.Forms.TextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.JobLvl = new System.Windows.Forms.TextBox();
            this.label104 = new System.Windows.Forms.Label();
            this.CStr = new System.Windows.Forms.TextBox();
            this.RGold = new System.Windows.Forms.TextBox();
            this.label93 = new System.Windows.Forms.Label();
            this.InvSize = new System.Windows.Forms.TextBox();
            this.CInt = new System.Windows.Forms.TextBox();
            this.StatPoint = new System.Windows.Forms.TextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.MaxLvl = new System.Windows.Forms.TextBox();
            this.CurLvl = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.CID = new System.Windows.Forms.TextBox();
            this.panel67 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX14 = new DevComponents.DotNetBar.ButtonX();
            this.CNameSearch = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.button25 = new DevComponents.DotNetBar.ButtonX();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.Check_Movetouser = new System.Windows.Forms.CheckBox();
            this.Check_RecallGuild = new System.Windows.Forms.CheckBox();
            this.Check_ToTown = new System.Windows.Forms.CheckBox();
            this.Check_RecallUser = new System.Windows.Forms.CheckBox();
            this.Check_DcUser = new System.Windows.Forms.CheckBox();
            this.Check_MakeItem = new System.Windows.Forms.CheckBox();
            this.Check_GoTown = new System.Windows.Forms.CheckBox();
            this.Check_LoadMonster = new System.Windows.Forms.CheckBox();
            this.Check_Invincible = new System.Windows.Forms.CheckBox();
            this.Check_Warp = new System.Windows.Forms.CheckBox();
            this.Check_GMSkill = new System.Windows.Forms.CheckBox();
            this.Check_Invisible = new System.Windows.Forms.CheckBox();
            this.Check_Incomechat = new System.Windows.Forms.CheckBox();
            this.UniqueLogBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.tabPage3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelEx38 = new System.Windows.Forms.Panel();
            this.Check_StallCreate = new System.Windows.Forms.CheckBox();
            this.Check_Private = new System.Windows.Forms.CheckBox();
            this.Check_PvpCape = new System.Windows.Forms.CheckBox();
            this.Check_Msg = new System.Windows.Forms.CheckBox();
            this.Check_Notice = new System.Windows.Forms.CheckBox();
            this.Check_Global = new System.Windows.Forms.CheckBox();
            this.Check_ChatAll = new System.Windows.Forms.CheckBox();
            this.superTabItem3 = new DevComponents.DotNetBar.SuperTabItem();
            this.tabPage1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.groupBox4 = new System.Windows.Forms.Panel();
            this.PLSQLRange = new System.Windows.Forms.Panel();
            this.SQLConnect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Host = new System.Windows.Forms.TextBox();
            this.HostPw = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Shardlog = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Account = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Shard = new System.Windows.Forms.TextBox();
            this.HostUser = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.slocale = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Check_AutoRelog = new System.Windows.Forms.CheckBox();
            this.sversion = new System.Windows.Forms.TextBox();
            this.gateport = new System.Windows.Forms.TextBox();
            this.ip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCharLevel = new System.Windows.Forms.Label();
            this.txtCharName = new System.Windows.Forms.Label();
            this.PicCharSel = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.captcha_text = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pw = new System.Windows.Forms.TextBox();
            this.char_list = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button3 = new DevComponents.DotNetBar.ButtonX();
            this.button4 = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.label58 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.CharName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CharUniqueID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel18 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabControl2 = new System.Windows.Forms.Panel();
            this.MainFun = new System.Windows.Forms.Panel();
            this.buttonX8 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX7 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX9 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.ManageCharPanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.label42 = new System.Windows.Forms.Label();
            this.panel57 = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.button23 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.CollectBookPanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.panelEx31 = new DevComponents.DotNetBar.PanelEx();
            this.panel60 = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.panel61 = new DevComponents.DotNetBar.PanelEx();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.panel63 = new DevComponents.DotNetBar.PanelEx();
            this.ThemeName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.TalismanName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button29 = new DevComponents.DotNetBar.ButtonX();
            this.button27 = new DevComponents.DotNetBar.ButtonX();
            this.button30 = new DevComponents.DotNetBar.ButtonX();
            this.panel62 = new DevComponents.DotNetBar.PanelEx();
            this.CharInvPanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.panelEx32 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX16 = new DevComponents.DotNetBar.ButtonX();
            this.label35 = new System.Windows.Forms.Label();
            this.CharacterPanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.panelEx29 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX13 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX12 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX11 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX10 = new DevComponents.DotNetBar.ButtonX();
            this.ManageUserPanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.panelEx34 = new DevComponents.DotNetBar.PanelEx();
            this.panel34 = new DevComponents.DotNetBar.PanelEx();
            this.button11 = new DevComponents.DotNetBar.ButtonX();
            this.EditUserPanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.button14 = new DevComponents.DotNetBar.ButtonX();
            this.button13 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx27 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx21 = new DevComponents.DotNetBar.PanelEx();
            this.panel28 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx25 = new DevComponents.DotNetBar.PanelEx();
            this.button9 = new DevComponents.DotNetBar.ButtonX();
            this.button10 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx22 = new DevComponents.DotNetBar.PanelEx();
            this.button8 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx23 = new DevComponents.DotNetBar.PanelEx();
            this.panel32 = new DevComponents.DotNetBar.PanelEx();
            this.button15 = new DevComponents.DotNetBar.ButtonX();
            this.button12 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx24 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX22 = new DevComponents.DotNetBar.ButtonX();
            this.SilkControlPanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.panelEx35 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX23 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx20 = new DevComponents.DotNetBar.PanelEx();
            this.label57 = new System.Windows.Forms.Label();
            this.panelEx19 = new DevComponents.DotNetBar.PanelEx();
            this.label45 = new System.Windows.Forms.Label();
            this.panel39 = new DevComponents.DotNetBar.PanelEx();
            this.panel40 = new DevComponents.DotNetBar.PanelEx();
            this.button19 = new DevComponents.DotNetBar.ButtonX();
            this.panel36 = new DevComponents.DotNetBar.PanelEx();
            this.panel43 = new DevComponents.DotNetBar.PanelEx();
            this.panel38 = new DevComponents.DotNetBar.PanelEx();
            this.panel42 = new DevComponents.DotNetBar.PanelEx();
            this.button16 = new DevComponents.DotNetBar.ButtonX();
            this.button17 = new DevComponents.DotNetBar.ButtonX();
            this.button20 = new DevComponents.DotNetBar.ButtonX();
            this.button18 = new DevComponents.DotNetBar.ButtonX();
            this.UserCharPanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.panelEx36 = new DevComponents.DotNetBar.PanelEx();
            this.panel44 = new DevComponents.DotNetBar.PanelEx();
            this.panel6 = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.button22 = new DevComponents.DotNetBar.ButtonX();
            this.comboBox1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panel45 = new DevComponents.DotNetBar.PanelEx();
            this.button21 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX24 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx18 = new DevComponents.DotNetBar.PanelEx();
            this.label44 = new System.Windows.Forms.Label();
            this.panel47 = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.CharName16 = new DevComponents.DotNetBar.PanelEx();
            this.panel50 = new DevComponents.DotNetBar.PanelEx();
            this.panel48 = new DevComponents.DotNetBar.PanelEx();
            this.panel49 = new DevComponents.DotNetBar.PanelEx();
            this.panel54 = new DevComponents.DotNetBar.PanelEx();
            this.panel51 = new DevComponents.DotNetBar.PanelEx();
            this.panel53 = new DevComponents.DotNetBar.PanelEx();
            this.panel52 = new DevComponents.DotNetBar.PanelEx();
            this.TeamUserPanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.panelEx37 = new DevComponents.DotNetBar.PanelEx();
            this.panelEx17 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX25 = new DevComponents.DotNetBar.ButtonX();
            this.button24 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx16 = new DevComponents.DotNetBar.PanelEx();
            this.label43 = new System.Windows.Forms.Label();
            this.UserPanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.panelEx33 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX17 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX21 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX18 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX19 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX20 = new DevComponents.DotNetBar.ButtonX();
            this.NextUpdatePanel = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.panelEx26 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX26 = new DevComponents.DotNetBar.ButtonX();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.superTabItem21 = new DevComponents.DotNetBar.SuperTabItem();
            this.tabPage2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panel1 = new DevComponents.DotNetBar.PanelEx();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.StartRelog = new System.Windows.Forms.CheckBox();
            this.HideTool = new DevComponents.DotNetBar.ButtonX();
            this.sideNavItem1 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.separator1 = new DevComponents.DotNetBar.Separator();
            this.sideNavItem2 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem3 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem4 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem5 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem6 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem7 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.separator2 = new DevComponents.DotNetBar.Separator();
            this.sideNavItem8 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem9 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem10 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem11 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.sideNavItem12 = new DevComponents.DotNetBar.Controls.SideNavItem();
            this.Status = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.timer8 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panelEx14.SuspendLayout();
            this.panel69.SuspendLayout();
            this.panel67.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panelEx38.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.PLSQLRange.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCharSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.superTabControlPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            this.superTabControlPanel18.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.MainFun.SuspendLayout();
            this.ManageCharPanel.SuspendLayout();
            this.panel57.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.CollectBookPanel.SuspendLayout();
            this.panelEx31.SuspendLayout();
            this.panel60.SuspendLayout();
            this.panel61.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel63.SuspendLayout();
            this.panel62.SuspendLayout();
            this.CharInvPanel.SuspendLayout();
            this.panelEx32.SuspendLayout();
            this.CharacterPanel.SuspendLayout();
            this.panelEx29.SuspendLayout();
            this.ManageUserPanel.SuspendLayout();
            this.panelEx34.SuspendLayout();
            this.panel34.SuspendLayout();
            this.EditUserPanel.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panelEx22.SuspendLayout();
            this.panel32.SuspendLayout();
            this.SilkControlPanel.SuspendLayout();
            this.panelEx35.SuspendLayout();
            this.panelEx20.SuspendLayout();
            this.panelEx19.SuspendLayout();
            this.panel39.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel38.SuspendLayout();
            this.UserCharPanel.SuspendLayout();
            this.panelEx36.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panelEx18.SuspendLayout();
            this.panel47.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel50.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel49.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panel51.SuspendLayout();
            this.panel53.SuspendLayout();
            this.panel52.SuspendLayout();
            this.TeamUserPanel.SuspendLayout();
            this.panelEx37.SuspendLayout();
            this.panelEx17.SuspendLayout();
            this.panelEx16.SuspendLayout();
            this.UserPanel.SuspendLayout();
            this.panelEx33.SuspendLayout();
            this.NextUpdatePanel.SuspendLayout();
            this.panelEx26.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ping
            // 
            this.Ping.Enabled = true;
            this.Ping.Interval = 5000;
            this.Ping.Tick += new System.EventHandler(this.Ping_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "vSro Multi Tool";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showBotToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.closeBotToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 70);
            // 
            // showBotToolStripMenuItem
            // 
            this.showBotToolStripMenuItem.Name = "showBotToolStripMenuItem";
            this.showBotToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.showBotToolStripMenuItem.Text = "Show Tool";
            this.showBotToolStripMenuItem.Click += new System.EventHandler(this.showBotToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // closeBotToolStripMenuItem
            // 
            this.closeBotToolStripMenuItem.Name = "closeBotToolStripMenuItem";
            this.closeBotToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.closeBotToolStripMenuItem.Text = "Close Tool";
            this.closeBotToolStripMenuItem.Click += new System.EventHandler(this.closeBotToolStripMenuItem_Click);
            // 
            // ToolService
            // 
            this.ToolService.Tick += new System.EventHandler(this.ToolService_Tick);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(24, 503);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(678, 147);
            this.listBox1.TabIndex = 0;
            // 
            // server_label
            // 
            this.server_label.BackColor = System.Drawing.Color.Black;
            this.server_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.server_label.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.server_label.ForeColor = System.Drawing.Color.White;
            this.server_label.Location = new System.Drawing.Point(171, 24);
            this.server_label.Name = "server_label";
            this.server_label.ReadOnly = true;
            this.server_label.Size = new System.Drawing.Size(160, 20);
            this.server_label.TabIndex = 13;
            this.server_label.Text = "Server";
            this.server_label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // player_label
            // 
            this.player_label.BackColor = System.Drawing.Color.Black;
            this.player_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player_label.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.player_label.ForeColor = System.Drawing.Color.White;
            this.player_label.Location = new System.Drawing.Point(171, 38);
            this.player_label.Name = "player_label";
            this.player_label.ReadOnly = true;
            this.player_label.Size = new System.Drawing.Size(160, 20);
            this.player_label.TabIndex = 13;
            this.player_label.Text = "Online Players (0/0)";
            this.player_label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(171, 52);
            this.label16.Name = "label16";
            this.label16.ReadOnly = true;
            this.label16.Size = new System.Drawing.Size(160, 20);
            this.label16.TabIndex = 13;
            this.label16.Text = "Not Connected";
            this.label16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SaveConfig
            // 
            this.SaveConfig.BackColor = System.Drawing.Color.Black;
            this.SaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.SaveConfig.ForeColor = System.Drawing.Color.White;
            this.SaveConfig.Location = new System.Drawing.Point(12, 27);
            this.SaveConfig.Name = "SaveConfig";
            this.SaveConfig.Size = new System.Drawing.Size(59, 33);
            this.SaveConfig.TabIndex = 58;
            this.SaveConfig.Text = "Save";
            this.SaveConfig.UseVisualStyleBackColor = false;
            this.SaveConfig.Click += new System.EventHandler(this.SaveConfig_Click);
            // 
            // LoadConfig
            // 
            this.LoadConfig.BackColor = System.Drawing.Color.Black;
            this.LoadConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LoadConfig.ForeColor = System.Drawing.Color.White;
            this.LoadConfig.Location = new System.Drawing.Point(87, 27);
            this.LoadConfig.Name = "LoadConfig";
            this.LoadConfig.Size = new System.Drawing.Size(59, 33);
            this.LoadConfig.TabIndex = 57;
            this.LoadConfig.Text = "Load";
            this.LoadConfig.UseVisualStyleBackColor = false;
            this.LoadConfig.Click += new System.EventHandler(this.LoadConfig_Click);
            // 
            // MiniMize
            // 
            this.MiniMize.BackColor = System.Drawing.Color.Black;
            this.MiniMize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MiniMize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MiniMize.ForeColor = System.Drawing.Color.Aqua;
            this.MiniMize.Location = new System.Drawing.Point(24, 15);
            this.MiniMize.Name = "MiniMize";
            this.MiniMize.Size = new System.Drawing.Size(57, 33);
            this.MiniMize.TabIndex = 53;
            this.MiniMize.Text = "_";
            this.MiniMize.UseVisualStyleBackColor = false;
            this.MiniMize.Click += new System.EventHandler(this.MiniMize_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(98, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(57, 33);
            this.button5.TabIndex = 54;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Execute
            // 
            this.Execute.Interval = 1000;
            this.Execute.Tick += new System.EventHandler(this.Execute_Tick);
            // 
            // listView3
            // 
            this.listView3.AutoArrange = false;
            this.listView3.BackColor = System.Drawing.Color.White;
            this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader10,
            this.columnHeader7});
            this.listView3.ForeColor = System.Drawing.Color.Black;
            this.listView3.FullRowSelect = true;
            this.listView3.GridLines = true;
            this.listView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(18, 78);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(382, 197);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "JID";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "StrUserID";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "sec_primary";
            this.columnHeader10.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "sec_content";
            this.columnHeader7.Width = 90;
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.Color.White;
            this.textBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox18.ForeColor = System.Drawing.Color.Black;
            this.textBox18.Location = new System.Drawing.Point(99, 44);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(89, 20);
            this.textBox18.TabIndex = 5;
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox18.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.White;
            this.textBox17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox17.ForeColor = System.Drawing.Color.Black;
            this.textBox17.Location = new System.Drawing.Point(99, 16);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(89, 20);
            this.textBox17.TabIndex = 4;
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox17.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BackColor = System.Drawing.Color.Transparent;
            this.label87.ForeColor = System.Drawing.Color.Black;
            this.label87.Location = new System.Drawing.Point(18, 47);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(72, 13);
            this.label87.TabIndex = 0;
            this.label87.Text = "sec_content :";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.ForeColor = System.Drawing.Color.Black;
            this.label86.Location = new System.Drawing.Point(18, 19);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(69, 13);
            this.label86.TabIndex = 0;
            this.label86.Text = "sec_primary :";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.BackColor = System.Drawing.Color.Transparent;
            this.label85.ForeColor = System.Drawing.Color.Black;
            this.label85.Location = new System.Drawing.Point(5, 9);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(71, 13);
            this.label85.TabIndex = 0;
            this.label85.Text = "RemainGold :";
            // 
            // CharGold
            // 
            this.CharGold.BackColor = System.Drawing.Color.White;
            this.CharGold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CharGold.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CharGold.ForeColor = System.Drawing.Color.Black;
            this.CharGold.Location = new System.Drawing.Point(83, 6);
            this.CharGold.Name = "CharGold";
            this.CharGold.ReadOnly = true;
            this.CharGold.Size = new System.Drawing.Size(103, 20);
            this.CharGold.TabIndex = 0;
            this.CharGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.ForeColor = System.Drawing.Color.Black;
            this.label84.Location = new System.Drawing.Point(5, 9);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(50, 13);
            this.label84.TabIndex = 0;
            this.label84.Text = "Intellect :";
            // 
            // CharInt
            // 
            this.CharInt.BackColor = System.Drawing.Color.White;
            this.CharInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CharInt.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CharInt.ForeColor = System.Drawing.Color.Black;
            this.CharInt.Location = new System.Drawing.Point(83, 6);
            this.CharInt.Name = "CharInt";
            this.CharInt.ReadOnly = true;
            this.CharInt.Size = new System.Drawing.Size(103, 20);
            this.CharInt.TabIndex = 0;
            this.CharInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.BackColor = System.Drawing.Color.Transparent;
            this.label83.ForeColor = System.Drawing.Color.Black;
            this.label83.Location = new System.Drawing.Point(5, 9);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(53, 13);
            this.label83.TabIndex = 0;
            this.label83.Text = "Strength :";
            // 
            // CharStr
            // 
            this.CharStr.BackColor = System.Drawing.Color.White;
            this.CharStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CharStr.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CharStr.ForeColor = System.Drawing.Color.Black;
            this.CharStr.Location = new System.Drawing.Point(83, 6);
            this.CharStr.Name = "CharStr";
            this.CharStr.ReadOnly = true;
            this.CharStr.Size = new System.Drawing.Size(103, 20);
            this.CharStr.TabIndex = 0;
            this.CharStr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.BackColor = System.Drawing.Color.Transparent;
            this.label82.ForeColor = System.Drawing.Color.Black;
            this.label82.Location = new System.Drawing.Point(5, 9);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(64, 13);
            this.label82.TabIndex = 0;
            this.label82.Text = "Current Lvl :";
            // 
            // CurrLevel
            // 
            this.CurrLevel.BackColor = System.Drawing.Color.White;
            this.CurrLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrLevel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CurrLevel.ForeColor = System.Drawing.Color.Black;
            this.CurrLevel.Location = new System.Drawing.Point(83, 6);
            this.CurrLevel.Name = "CurrLevel";
            this.CurrLevel.ReadOnly = true;
            this.CurrLevel.Size = new System.Drawing.Size(103, 20);
            this.CurrLevel.TabIndex = 0;
            this.CurrLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.BackColor = System.Drawing.Color.Transparent;
            this.label81.ForeColor = System.Drawing.Color.Black;
            this.label81.Location = new System.Drawing.Point(5, 9);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(68, 13);
            this.label81.TabIndex = 0;
            this.label81.Text = "Guild Name :";
            // 
            // GuildName
            // 
            this.GuildName.BackColor = System.Drawing.Color.White;
            this.GuildName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GuildName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.GuildName.ForeColor = System.Drawing.Color.Black;
            this.GuildName.Location = new System.Drawing.Point(83, 6);
            this.GuildName.Name = "GuildName";
            this.GuildName.ReadOnly = true;
            this.GuildName.Size = new System.Drawing.Size(103, 20);
            this.GuildName.TabIndex = 0;
            this.GuildName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.ForeColor = System.Drawing.Color.Black;
            this.label79.Location = new System.Drawing.Point(5, 9);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(66, 13);
            this.label79.TabIndex = 0;
            this.label79.Text = "Nick Name :";
            // 
            // NickName16
            // 
            this.NickName16.BackColor = System.Drawing.Color.White;
            this.NickName16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NickName16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.NickName16.ForeColor = System.Drawing.Color.Black;
            this.NickName16.Location = new System.Drawing.Point(83, 6);
            this.NickName16.Name = "NickName16";
            this.NickName16.ReadOnly = true;
            this.NickName16.Size = new System.Drawing.Size(103, 20);
            this.NickName16.TabIndex = 0;
            this.NickName16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.ForeColor = System.Drawing.Color.Black;
            this.label80.Location = new System.Drawing.Point(5, 9);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(73, 13);
            this.label80.TabIndex = 0;
            this.label80.Text = "Character ID :";
            // 
            // CharID
            // 
            this.CharID.BackColor = System.Drawing.Color.White;
            this.CharID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CharID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CharID.ForeColor = System.Drawing.Color.Black;
            this.CharID.Location = new System.Drawing.Point(83, 6);
            this.CharID.Name = "CharID";
            this.CharID.ReadOnly = true;
            this.CharID.Size = new System.Drawing.Size(103, 20);
            this.CharID.TabIndex = 0;
            this.CharID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.ForeColor = System.Drawing.Color.Black;
            this.label78.Location = new System.Drawing.Point(9, 14);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(43, 13);
            this.label78.TabIndex = 0;
            this.label78.Text = "Result :";
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.White;
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox16.ForeColor = System.Drawing.Color.Black;
            this.textBox16.Location = new System.Drawing.Point(76, 11);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(107, 20);
            this.textBox16.TabIndex = 4;
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.Color.Transparent;
            this.label74.ForeColor = System.Drawing.Color.Black;
            this.label74.Location = new System.Drawing.Point(9, 14);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(61, 13);
            this.label74.TabIndex = 0;
            this.label74.Text = "Username :";
            // 
            // listView2
            // 
            this.listView2.AutoArrange = false;
            this.listView2.BackColor = System.Drawing.Color.White;
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.JID,
            this.StrUserID,
            this.SilkOwn,
            this.SilkGift,
            this.SilkPoint});
            this.listView2.ForeColor = System.Drawing.Color.Black;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(12, 86);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(311, 196);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // JID
            // 
            this.JID.Text = "JID";
            // 
            // StrUserID
            // 
            this.StrUserID.Text = "StrUserID";
            this.StrUserID.Width = 69;
            // 
            // SilkOwn
            // 
            this.SilkOwn.Text = "silk_own";
            // 
            // SilkGift
            // 
            this.SilkGift.Text = "silk_gift";
            // 
            // SilkPoint
            // 
            this.SilkPoint.Text = "silk_point";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.Color.Transparent;
            this.label71.ForeColor = System.Drawing.Color.Black;
            this.label71.Location = new System.Drawing.Point(5, 6);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(64, 13);
            this.label71.TabIndex = 0;
            this.label71.Text = "Arrange by :";
            // 
            // own1
            // 
            this.own1.AutoSize = true;
            this.own1.ForeColor = System.Drawing.Color.Black;
            this.own1.Location = new System.Drawing.Point(8, 26);
            this.own1.Name = "own1";
            this.own1.Size = new System.Drawing.Size(66, 17);
            this.own1.TabIndex = 10;
            this.own1.TabStop = true;
            this.own1.Text = "silk_own";
            this.own1.UseVisualStyleBackColor = true;
            // 
            // point1
            // 
            this.point1.AutoSize = true;
            this.point1.ForeColor = System.Drawing.Color.Black;
            this.point1.Location = new System.Drawing.Point(146, 26);
            this.point1.Name = "point1";
            this.point1.Size = new System.Drawing.Size(69, 17);
            this.point1.TabIndex = 12;
            this.point1.TabStop = true;
            this.point1.Text = "silk_point";
            this.point1.UseVisualStyleBackColor = true;
            // 
            // gift1
            // 
            this.gift1.AutoSize = true;
            this.gift1.ForeColor = System.Drawing.Color.Black;
            this.gift1.Location = new System.Drawing.Point(79, 26);
            this.gift1.Name = "gift1";
            this.gift1.Size = new System.Drawing.Size(60, 17);
            this.gift1.TabIndex = 11;
            this.gift1.TabStop = true;
            this.gift1.Text = "silk_gift";
            this.gift1.UseVisualStyleBackColor = true;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.BackColor = System.Drawing.Color.Transparent;
            this.label75.ForeColor = System.Drawing.Color.Black;
            this.label75.Location = new System.Drawing.Point(7, 6);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(66, 13);
            this.label75.TabIndex = 11;
            this.label75.Text = "Choose kind";
            // 
            // own
            // 
            this.own.AutoSize = true;
            this.own.ForeColor = System.Drawing.Color.Black;
            this.own.Location = new System.Drawing.Point(6, 29);
            this.own.Name = "own";
            this.own.Size = new System.Drawing.Size(66, 17);
            this.own.TabIndex = 7;
            this.own.TabStop = true;
            this.own.Text = "silk_own";
            this.own.UseVisualStyleBackColor = true;
            // 
            // point
            // 
            this.point.AutoSize = true;
            this.point.ForeColor = System.Drawing.Color.Black;
            this.point.Location = new System.Drawing.Point(6, 75);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(69, 17);
            this.point.TabIndex = 9;
            this.point.TabStop = true;
            this.point.Text = "silk_point";
            this.point.UseVisualStyleBackColor = true;
            // 
            // gift
            // 
            this.gift.AutoSize = true;
            this.gift.ForeColor = System.Drawing.Color.Black;
            this.gift.Location = new System.Drawing.Point(6, 52);
            this.gift.Name = "gift";
            this.gift.Size = new System.Drawing.Size(60, 17);
            this.gift.TabIndex = 8;
            this.gift.TabStop = true;
            this.gift.Text = "silk_gift";
            this.gift.UseVisualStyleBackColor = true;
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.Color.White;
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox14.ForeColor = System.Drawing.Color.Black;
            this.textBox14.Location = new System.Drawing.Point(80, 46);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(116, 20);
            this.textBox14.TabIndex = 2;
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox14.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.ForeColor = System.Drawing.Color.Black;
            this.label69.Location = new System.Drawing.Point(14, 48);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(49, 13);
            this.label69.TabIndex = 0;
            this.label69.Text = "Amount :";
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.Color.White;
            this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox15.ForeColor = System.Drawing.Color.Black;
            this.textBox15.Location = new System.Drawing.Point(80, 18);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(116, 20);
            this.textBox15.TabIndex = 1;
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.ForeColor = System.Drawing.Color.Black;
            this.label70.Location = new System.Drawing.Point(14, 20);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(61, 13);
            this.label70.TabIndex = 0;
            this.label70.Text = "Username :";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd  ss:mm:HH";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(53, 71);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(143, 20);
            this.dateTimePicker2.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd  ss:mm:HH";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(53, 41);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(143, 20);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(76, 153);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 15;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            this.textBox4.Location = new System.Drawing.Point(76, 11);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(120, 20);
            this.textBox4.TabIndex = 11;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.ForeColor = System.Drawing.Color.Black;
            this.label56.Location = new System.Drawing.Point(10, 73);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(32, 13);
            this.label56.TabIndex = 0;
            this.label56.Text = "End :";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.ForeColor = System.Drawing.Color.Black;
            this.label54.Location = new System.Drawing.Point(10, 43);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(35, 13);
            this.label54.TabIndex = 0;
            this.label54.Text = "Start :";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(10, 156);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(61, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "Username :";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.Location = new System.Drawing.Point(10, 13);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(61, 13);
            this.label55.TabIndex = 0;
            this.label55.Text = "Username :";
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.White;
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox12.ForeColor = System.Drawing.Color.Black;
            this.textBox12.Location = new System.Drawing.Point(88, 146);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(108, 20);
            this.textBox12.TabIndex = 24;
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.ForeColor = System.Drawing.Color.Black;
            this.label67.Location = new System.Drawing.Point(10, 149);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(72, 13);
            this.label67.TabIndex = 0;
            this.label67.Text = "sec_content :";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.White;
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox9.ForeColor = System.Drawing.Color.Black;
            this.textBox9.Location = new System.Drawing.Point(88, 119);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(108, 20);
            this.textBox9.TabIndex = 23;
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.ForeColor = System.Drawing.Color.Black;
            this.label65.Location = new System.Drawing.Point(10, 122);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(69, 13);
            this.label65.TabIndex = 0;
            this.label65.Text = "sec_primary :";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.White;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox8.ForeColor = System.Drawing.Color.Black;
            this.textBox8.Location = new System.Drawing.Point(54, 92);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(142, 20);
            this.textBox8.TabIndex = 22;
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.ForeColor = System.Drawing.Color.Black;
            this.label64.Location = new System.Drawing.Point(10, 94);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(38, 13);
            this.label64.TabIndex = 0;
            this.label64.Text = "Email :";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.White;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.ForeColor = System.Drawing.Color.Black;
            this.textBox7.Location = new System.Drawing.Point(74, 65);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(122, 20);
            this.textBox7.TabIndex = 21;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.ForeColor = System.Drawing.Color.Black;
            this.label63.Location = new System.Drawing.Point(10, 68);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(59, 13);
            this.label63.TabIndex = 0;
            this.label63.Text = "Password :";
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.White;
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox13.ForeColor = System.Drawing.Color.Black;
            this.textBox13.Location = new System.Drawing.Point(74, 38);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(122, 20);
            this.textBox13.TabIndex = 20;
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.ForeColor = System.Drawing.Color.Black;
            this.label68.Location = new System.Drawing.Point(10, 41);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(59, 13);
            this.label68.TabIndex = 0;
            this.label68.Text = "StrUserID :";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.White;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.ForeColor = System.Drawing.Color.Black;
            this.textBox6.Location = new System.Drawing.Point(74, 11);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(122, 20);
            this.textBox6.TabIndex = 19;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.ForeColor = System.Drawing.Color.Black;
            this.label60.Location = new System.Drawing.Point(12, 13);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(61, 13);
            this.label60.TabIndex = 0;
            this.label60.Text = "Username :";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.ForeColor = System.Drawing.Color.Black;
            this.label61.Location = new System.Drawing.Point(10, 14);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(54, 13);
            this.label61.TabIndex = 0;
            this.label61.Text = "User JID :";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.ForeColor = System.Drawing.Color.Black;
            this.textBox5.Location = new System.Drawing.Point(79, 9);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(117, 20);
            this.textBox5.TabIndex = 17;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.White;
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox11.ForeColor = System.Drawing.Color.Black;
            this.textBox11.Location = new System.Drawing.Point(11, 78);
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(183, 54);
            this.textBox11.TabIndex = 12;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.White;
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox10.ForeColor = System.Drawing.Color.Black;
            this.textBox10.Location = new System.Drawing.Point(74, 14);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(120, 20);
            this.textBox10.TabIndex = 7;
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.ForeColor = System.Drawing.Color.Black;
            this.label66.Location = new System.Drawing.Point(9, 17);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(61, 13);
            this.label66.TabIndex = 0;
            this.label66.Text = "Username :";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(74, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(74, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.ForeColor = System.Drawing.Color.Black;
            this.label52.Location = new System.Drawing.Point(9, 39);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(59, 13);
            this.label52.TabIndex = 0;
            this.label52.Text = "Password :";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(9, 13);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(61, 13);
            this.label50.TabIndex = 0;
            this.label50.Text = "Username :";
            // 
            // panelEx14
            // 
            this.panelEx14.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx14.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx14.Controls.Add(this.label39);
            this.panelEx14.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx14.Location = new System.Drawing.Point(15, 15);
            this.panelEx14.Name = "panelEx14";
            this.panelEx14.Size = new System.Drawing.Size(238, 28);
            this.panelEx14.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx14.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx14.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx14.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx14.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx14.Style.GradientAngle = 90;
            this.panelEx14.TabIndex = 6;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(10, 6);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(220, 17);
            this.label39.TabIndex = 7;
            this.label39.Text = "Edit characters collection book";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(8, 45);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(55, 13);
            this.label36.TabIndex = 33;
            this.label36.Text = "Talisman :";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.ForeColor = System.Drawing.Color.Black;
            this.label92.Location = new System.Drawing.Point(8, 14);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(46, 13);
            this.label92.TabIndex = 32;
            this.label92.Text = "Theme :";
            // 
            // Shipwreck2
            // 
            this.Shipwreck2.AutoSize = true;
            this.Shipwreck2.ForeColor = System.Drawing.Color.Black;
            this.Shipwreck2.Location = new System.Drawing.Point(8, 76);
            this.Shipwreck2.Name = "Shipwreck2";
            this.Shipwreck2.Size = new System.Drawing.Size(197, 17);
            this.Shipwreck2.TabIndex = 7;
            this.Shipwreck2.TabStop = true;
            this.Shipwreck2.Text = "Shipwreck - The Sea of Resentment";
            this.Shipwreck2.UseVisualStyleBackColor = true;
            this.Shipwreck2.CheckedChanged += new System.EventHandler(this.Shipwreck2_CheckedChanged);
            // 
            // Shipwreck1
            // 
            this.Shipwreck1.AutoSize = true;
            this.Shipwreck1.ForeColor = System.Drawing.Color.Black;
            this.Shipwreck1.Location = new System.Drawing.Point(8, 53);
            this.Shipwreck1.Name = "Shipwreck1";
            this.Shipwreck1.Size = new System.Drawing.Size(166, 17);
            this.Shipwreck1.TabIndex = 6;
            this.Shipwreck1.TabStop = true;
            this.Shipwreck1.Text = "Shipwreck - The Green Abyss";
            this.Shipwreck1.UseVisualStyleBackColor = true;
            this.Shipwreck1.CheckedChanged += new System.EventHandler(this.Shipwreck1_CheckedChanged);
            // 
            // Flame
            // 
            this.Flame.AutoSize = true;
            this.Flame.ForeColor = System.Drawing.Color.Black;
            this.Flame.Location = new System.Drawing.Point(8, 30);
            this.Flame.Name = "Flame";
            this.Flame.Size = new System.Drawing.Size(198, 17);
            this.Flame.TabIndex = 5;
            this.Flame.TabStop = true;
            this.Flame.Text = "Flame Mountain - The Burning Abyss";
            this.Flame.UseVisualStyleBackColor = true;
            this.Flame.CheckedChanged += new System.EventHandler(this.Flame_CheckedChanged);
            // 
            // Togui
            // 
            this.Togui.AutoSize = true;
            this.Togui.ForeColor = System.Drawing.Color.Black;
            this.Togui.Location = new System.Drawing.Point(8, 7);
            this.Togui.Name = "Togui";
            this.Togui.Size = new System.Drawing.Size(259, 17);
            this.Togui.TabIndex = 4;
            this.Togui.TabStop = true;
            this.Togui.Text = "Togui Village - The Phantom of the Crimson Blood";
            this.Togui.UseVisualStyleBackColor = true;
            this.Togui.CheckedChanged += new System.EventHandler(this.Togui_CheckedChanged);
            // 
            // panel69
            // 
            this.panel69.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel69.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel69.Controls.Add(this.buttonX15);
            this.panel69.Controls.Add(this.textBox20);
            this.panel69.Controls.Add(this.label110);
            this.panel69.Controls.Add(this.button28);
            this.panel69.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel69.Location = new System.Drawing.Point(15, 49);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(231, 91);
            this.panel69.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel69.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel69.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel69.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel69.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel69.Style.GradientAngle = 90;
            this.panel69.TabIndex = 31;
            // 
            // buttonX15
            // 
            this.buttonX15.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX15.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX15.Location = new System.Drawing.Point(122, 47);
            this.buttonX15.Name = "buttonX15";
            this.buttonX15.Size = new System.Drawing.Size(94, 29);
            this.buttonX15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX15.TabIndex = 33;
            this.buttonX15.Text = "Back";
            this.buttonX15.Click += new System.EventHandler(this.buttonX15_Click);
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.Color.White;
            this.textBox20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox20.ForeColor = System.Drawing.Color.Black;
            this.textBox20.Location = new System.Drawing.Point(79, 14);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(137, 20);
            this.textBox20.TabIndex = 13;
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.BackColor = System.Drawing.Color.Transparent;
            this.label110.ForeColor = System.Drawing.Color.Black;
            this.label110.Location = new System.Drawing.Point(13, 17);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(61, 13);
            this.label110.TabIndex = 11;
            this.label110.Text = "Charname :";
            // 
            // button28
            // 
            this.button28.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button28.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button28.Location = new System.Drawing.Point(14, 47);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(94, 29);
            this.button28.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button28.TabIndex = 32;
            this.button28.Text = "Search";
            this.button28.Click += new System.EventHandler(this.button28_Click);
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.BackColor = System.Drawing.Color.Black;
            this.label103.ForeColor = System.Drawing.Color.White;
            this.label103.Location = new System.Drawing.Point(242, 233);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(70, 13);
            this.label103.TabIndex = 0;
            this.label103.Text = "Hwan Level :";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.BackColor = System.Drawing.Color.Black;
            this.label98.ForeColor = System.Drawing.Color.White;
            this.label98.Location = new System.Drawing.Point(28, 72);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(75, 13);
            this.label98.TabIndex = 0;
            this.label98.Text = "CharName16 :";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.BackColor = System.Drawing.Color.Black;
            this.label102.ForeColor = System.Drawing.Color.White;
            this.label102.Location = new System.Drawing.Point(241, 206);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(77, 13);
            this.label102.TabIndex = 0;
            this.label102.Text = "InventorySize :";
            // 
            // CName16
            // 
            this.CName16.BackColor = System.Drawing.Color.Black;
            this.CName16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CName16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CName16.ForeColor = System.Drawing.Color.White;
            this.CName16.Location = new System.Drawing.Point(110, 68);
            this.CName16.Name = "CName16";
            this.CName16.Size = new System.Drawing.Size(118, 20);
            this.CName16.TabIndex = 6;
            this.CName16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.BackColor = System.Drawing.Color.Black;
            this.label108.ForeColor = System.Drawing.Color.White;
            this.label108.Location = new System.Drawing.Point(242, 179);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(64, 13);
            this.label108.TabIndex = 0;
            this.label108.Text = "Stat Points :";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.BackColor = System.Drawing.Color.Black;
            this.label96.ForeColor = System.Drawing.Color.White;
            this.label96.Location = new System.Drawing.Point(28, 97);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(75, 13);
            this.label96.TabIndex = 0;
            this.label96.Text = "NickName16 :";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.BackColor = System.Drawing.Color.Black;
            this.label107.ForeColor = System.Drawing.Color.White;
            this.label107.Location = new System.Drawing.Point(28, 233);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(71, 13);
            this.label107.TabIndex = 0;
            this.label107.Text = "RemainGold :";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.BackColor = System.Drawing.Color.Black;
            this.label101.ForeColor = System.Drawing.Color.White;
            this.label101.Location = new System.Drawing.Point(242, 98);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(64, 13);
            this.label101.TabIndex = 0;
            this.label101.Text = "Skill Points :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Black;
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(28, 125);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(57, 13);
            this.label26.TabIndex = 0;
            this.label26.Text = "Job Type :";
            // 
            // NkName16
            // 
            this.NkName16.BackColor = System.Drawing.Color.Black;
            this.NkName16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NkName16.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.NkName16.ForeColor = System.Drawing.Color.White;
            this.NkName16.Location = new System.Drawing.Point(110, 95);
            this.NkName16.Name = "NkName16";
            this.NkName16.Size = new System.Drawing.Size(118, 20);
            this.NkName16.TabIndex = 7;
            this.NkName16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.BackColor = System.Drawing.Color.Black;
            this.label106.ForeColor = System.Drawing.Color.White;
            this.label106.Location = new System.Drawing.Point(242, 71);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(66, 13);
            this.label106.TabIndex = 0;
            this.label106.Text = "Experience :";
            // 
            // Exp
            // 
            this.Exp.BackColor = System.Drawing.Color.Black;
            this.Exp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Exp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Exp.ForeColor = System.Drawing.Color.White;
            this.Exp.Location = new System.Drawing.Point(324, 69);
            this.Exp.Name = "Exp";
            this.Exp.Size = new System.Drawing.Size(118, 20);
            this.Exp.TabIndex = 13;
            this.Exp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Exp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.BackColor = System.Drawing.Color.Black;
            this.label105.ForeColor = System.Drawing.Color.White;
            this.label105.Location = new System.Drawing.Point(242, 152);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(50, 13);
            this.label105.TabIndex = 0;
            this.label105.Text = "Intellect :";
            // 
            // JobType
            // 
            this.JobType.BackColor = System.Drawing.Color.Black;
            this.JobType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JobType.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.JobType.ForeColor = System.Drawing.Color.White;
            this.JobType.Location = new System.Drawing.Point(110, 122);
            this.JobType.Name = "JobType";
            this.JobType.Size = new System.Drawing.Size(118, 20);
            this.JobType.TabIndex = 8;
            this.JobType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.JobType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // HwanLvl
            // 
            this.HwanLvl.BackColor = System.Drawing.Color.Black;
            this.HwanLvl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HwanLvl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.HwanLvl.ForeColor = System.Drawing.Color.White;
            this.HwanLvl.Location = new System.Drawing.Point(324, 231);
            this.HwanLvl.Name = "HwanLvl";
            this.HwanLvl.Size = new System.Drawing.Size(118, 20);
            this.HwanLvl.TabIndex = 19;
            this.HwanLvl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HwanLvl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // Sp
            // 
            this.Sp.BackColor = System.Drawing.Color.Black;
            this.Sp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Sp.ForeColor = System.Drawing.Color.White;
            this.Sp.Location = new System.Drawing.Point(324, 96);
            this.Sp.Name = "Sp";
            this.Sp.Size = new System.Drawing.Size(118, 20);
            this.Sp.TabIndex = 14;
            this.Sp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Sp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.BackColor = System.Drawing.Color.Black;
            this.label109.ForeColor = System.Drawing.Color.White;
            this.label109.Location = new System.Drawing.Point(28, 152);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(59, 13);
            this.label109.TabIndex = 0;
            this.label109.Text = "Job Level :";
            // 
            // JobLvl
            // 
            this.JobLvl.BackColor = System.Drawing.Color.Black;
            this.JobLvl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.JobLvl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.JobLvl.ForeColor = System.Drawing.Color.White;
            this.JobLvl.Location = new System.Drawing.Point(110, 149);
            this.JobLvl.Name = "JobLvl";
            this.JobLvl.Size = new System.Drawing.Size(118, 20);
            this.JobLvl.TabIndex = 9;
            this.JobLvl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.JobLvl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.BackColor = System.Drawing.Color.Black;
            this.label104.ForeColor = System.Drawing.Color.White;
            this.label104.Location = new System.Drawing.Point(242, 125);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(53, 13);
            this.label104.TabIndex = 0;
            this.label104.Text = "Strength :";
            // 
            // CStr
            // 
            this.CStr.BackColor = System.Drawing.Color.Black;
            this.CStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CStr.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CStr.ForeColor = System.Drawing.Color.White;
            this.CStr.Location = new System.Drawing.Point(324, 123);
            this.CStr.Name = "CStr";
            this.CStr.Size = new System.Drawing.Size(118, 20);
            this.CStr.TabIndex = 15;
            this.CStr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CStr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // RGold
            // 
            this.RGold.BackColor = System.Drawing.Color.Black;
            this.RGold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RGold.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RGold.ForeColor = System.Drawing.Color.White;
            this.RGold.Location = new System.Drawing.Point(110, 230);
            this.RGold.Name = "RGold";
            this.RGold.Size = new System.Drawing.Size(118, 20);
            this.RGold.TabIndex = 12;
            this.RGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RGold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.BackColor = System.Drawing.Color.Black;
            this.label93.ForeColor = System.Drawing.Color.White;
            this.label93.Location = new System.Drawing.Point(28, 179);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(64, 13);
            this.label93.TabIndex = 0;
            this.label93.Text = "Current Lvl :";
            // 
            // InvSize
            // 
            this.InvSize.BackColor = System.Drawing.Color.Black;
            this.InvSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InvSize.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.InvSize.ForeColor = System.Drawing.Color.White;
            this.InvSize.Location = new System.Drawing.Point(324, 204);
            this.InvSize.Name = "InvSize";
            this.InvSize.Size = new System.Drawing.Size(118, 20);
            this.InvSize.TabIndex = 18;
            this.InvSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InvSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // CInt
            // 
            this.CInt.BackColor = System.Drawing.Color.Black;
            this.CInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CInt.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CInt.ForeColor = System.Drawing.Color.White;
            this.CInt.Location = new System.Drawing.Point(324, 150);
            this.CInt.Name = "CInt";
            this.CInt.Size = new System.Drawing.Size(118, 20);
            this.CInt.TabIndex = 16;
            this.CInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CInt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // StatPoint
            // 
            this.StatPoint.BackColor = System.Drawing.Color.Black;
            this.StatPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatPoint.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.StatPoint.ForeColor = System.Drawing.Color.White;
            this.StatPoint.Location = new System.Drawing.Point(324, 177);
            this.StatPoint.Name = "StatPoint";
            this.StatPoint.Size = new System.Drawing.Size(118, 20);
            this.StatPoint.TabIndex = 17;
            this.StatPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.BackColor = System.Drawing.Color.Black;
            this.label94.ForeColor = System.Drawing.Color.White;
            this.label94.Location = new System.Drawing.Point(28, 206);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(50, 13);
            this.label94.TabIndex = 0;
            this.label94.Text = "Max Lvl :";
            // 
            // MaxLvl
            // 
            this.MaxLvl.BackColor = System.Drawing.Color.Black;
            this.MaxLvl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaxLvl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.MaxLvl.ForeColor = System.Drawing.Color.White;
            this.MaxLvl.Location = new System.Drawing.Point(110, 203);
            this.MaxLvl.Name = "MaxLvl";
            this.MaxLvl.Size = new System.Drawing.Size(118, 20);
            this.MaxLvl.TabIndex = 11;
            this.MaxLvl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaxLvl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // CurLvl
            // 
            this.CurLvl.BackColor = System.Drawing.Color.Black;
            this.CurLvl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurLvl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CurLvl.ForeColor = System.Drawing.Color.White;
            this.CurLvl.Location = new System.Drawing.Point(110, 176);
            this.CurLvl.Name = "CurLvl";
            this.CurLvl.Size = new System.Drawing.Size(118, 20);
            this.CurLvl.TabIndex = 10;
            this.CurLvl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CurLvl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.BackColor = System.Drawing.Color.Black;
            this.label97.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label97.ForeColor = System.Drawing.Color.White;
            this.label97.Location = new System.Drawing.Point(24, 36);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(76, 13);
            this.label97.TabIndex = 0;
            this.label97.Text = "CharacterID";
            // 
            // CID
            // 
            this.CID.BackColor = System.Drawing.Color.Black;
            this.CID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.CID.ForeColor = System.Drawing.Color.White;
            this.CID.Location = new System.Drawing.Point(109, 34);
            this.CID.Name = "CID";
            this.CID.ReadOnly = true;
            this.CID.Size = new System.Drawing.Size(119, 20);
            this.CID.TabIndex = 4;
            this.CID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel67
            // 
            this.panel67.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel67.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel67.Controls.Add(this.buttonX14);
            this.panel67.Controls.Add(this.CNameSearch);
            this.panel67.Controls.Add(this.label99);
            this.panel67.Controls.Add(this.button25);
            this.panel67.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel67.Location = new System.Drawing.Point(18, 59);
            this.panel67.Name = "panel67";
            this.panel67.Size = new System.Drawing.Size(231, 91);
            this.panel67.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel67.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel67.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel67.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel67.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel67.Style.GradientAngle = 90;
            this.panel67.TabIndex = 0;
            // 
            // buttonX14
            // 
            this.buttonX14.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX14.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX14.Location = new System.Drawing.Point(122, 47);
            this.buttonX14.Name = "buttonX14";
            this.buttonX14.Size = new System.Drawing.Size(94, 29);
            this.buttonX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX14.TabIndex = 6;
            this.buttonX14.Text = "Back";
            this.buttonX14.Click += new System.EventHandler(this.buttonX14_Click);
            // 
            // CNameSearch
            // 
            this.CNameSearch.BackColor = System.Drawing.Color.White;
            this.CNameSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CNameSearch.ForeColor = System.Drawing.Color.Black;
            this.CNameSearch.Location = new System.Drawing.Point(79, 14);
            this.CNameSearch.Name = "CNameSearch";
            this.CNameSearch.Size = new System.Drawing.Size(137, 20);
            this.CNameSearch.TabIndex = 4;
            this.CNameSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.BackColor = System.Drawing.Color.Transparent;
            this.label99.ForeColor = System.Drawing.Color.Black;
            this.label99.Location = new System.Drawing.Point(13, 17);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(61, 13);
            this.label99.TabIndex = 0;
            this.label99.Text = "Charname :";
            // 
            // button25
            // 
            this.button25.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button25.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button25.Location = new System.Drawing.Point(14, 47);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(94, 29);
            this.button25.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button25.TabIndex = 5;
            this.button25.Text = "Search";
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Black;
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(14, 35);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(95, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Active Service";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(14, 58);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(548, 264);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Every(Day)";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Execute Time";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Remaining Time";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Index";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 40;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Query";
            this.columnHeader9.Width = 500;
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.Color.Black;
            this.textBox19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox19.ForeColor = System.Drawing.Color.White;
            this.textBox19.Location = new System.Drawing.Point(129, 16);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(71, 20);
            this.textBox19.TabIndex = 8;
            this.textBox19.Text = "100";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox19.TextChanged += new System.EventHandler(this.textBox19_TextChanged);
            this.textBox19.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.BackColor = System.Drawing.Color.Black;
            this.label89.ForeColor = System.Drawing.Color.White;
            this.label89.Location = new System.Drawing.Point(206, 19);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(66, 13);
            this.label89.TabIndex = 0;
            this.label89.Text = "milli seconds";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.BackColor = System.Drawing.Color.Black;
            this.label90.ForeColor = System.Drawing.Color.White;
            this.label90.Location = new System.Drawing.Point(13, 18);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(111, 13);
            this.label90.TabIndex = 0;
            this.label90.Text = "Service timer interval :";
            // 
            // Check_Movetouser
            // 
            this.Check_Movetouser.AutoSize = true;
            this.Check_Movetouser.ForeColor = System.Drawing.Color.White;
            this.Check_Movetouser.Location = new System.Drawing.Point(25, 127);
            this.Check_Movetouser.Name = "Check_Movetouser";
            this.Check_Movetouser.Size = new System.Drawing.Size(127, 17);
            this.Check_Movetouser.TabIndex = 11;
            this.Check_Movetouser.Text = "Active Move To User";
            this.Check_Movetouser.UseVisualStyleBackColor = true;
            this.Check_Movetouser.CheckedChanged += new System.EventHandler(this.Check_Movetouser_CheckedChanged);
            // 
            // Check_RecallGuild
            // 
            this.Check_RecallGuild.AutoSize = true;
            this.Check_RecallGuild.ForeColor = System.Drawing.Color.White;
            this.Check_RecallGuild.Location = new System.Drawing.Point(353, 173);
            this.Check_RecallGuild.Name = "Check_RecallGuild";
            this.Check_RecallGuild.Size = new System.Drawing.Size(116, 17);
            this.Check_RecallGuild.TabIndex = 12;
            this.Check_RecallGuild.Text = "Active Recall Guild";
            this.Check_RecallGuild.UseVisualStyleBackColor = true;
            this.Check_RecallGuild.CheckedChanged += new System.EventHandler(this.Check_RecallGuild_CheckedChanged);
            // 
            // Check_ToTown
            // 
            this.Check_ToTown.AutoSize = true;
            this.Check_ToTown.ForeColor = System.Drawing.Color.White;
            this.Check_ToTown.Location = new System.Drawing.Point(197, 196);
            this.Check_ToTown.Name = "Check_ToTown";
            this.Check_ToTown.Size = new System.Drawing.Size(127, 17);
            this.Check_ToTown.TabIndex = 14;
            this.Check_ToTown.Text = "Active To Town User";
            this.Check_ToTown.UseVisualStyleBackColor = true;
            this.Check_ToTown.CheckedChanged += new System.EventHandler(this.Check_ToTown_CheckedChanged);
            // 
            // Check_RecallUser
            // 
            this.Check_RecallUser.AutoSize = true;
            this.Check_RecallUser.ForeColor = System.Drawing.Color.White;
            this.Check_RecallUser.Location = new System.Drawing.Point(353, 150);
            this.Check_RecallUser.Name = "Check_RecallUser";
            this.Check_RecallUser.Size = new System.Drawing.Size(114, 17);
            this.Check_RecallUser.TabIndex = 13;
            this.Check_RecallUser.Text = "Active Recall User";
            this.Check_RecallUser.UseVisualStyleBackColor = true;
            this.Check_RecallUser.CheckedChanged += new System.EventHandler(this.Check_RecallUser_CheckedChanged);
            // 
            // Check_DcUser
            // 
            this.Check_DcUser.AutoSize = true;
            this.Check_DcUser.ForeColor = System.Drawing.Color.White;
            this.Check_DcUser.Location = new System.Drawing.Point(197, 127);
            this.Check_DcUser.Name = "Check_DcUser";
            this.Check_DcUser.Size = new System.Drawing.Size(138, 17);
            this.Check_DcUser.TabIndex = 15;
            this.Check_DcUser.Text = "Active Disconnect User";
            this.Check_DcUser.UseVisualStyleBackColor = true;
            this.Check_DcUser.CheckedChanged += new System.EventHandler(this.Check_DcUser_CheckedChanged);
            // 
            // Check_MakeItem
            // 
            this.Check_MakeItem.AutoSize = true;
            this.Check_MakeItem.ForeColor = System.Drawing.Color.White;
            this.Check_MakeItem.Location = new System.Drawing.Point(353, 196);
            this.Check_MakeItem.Name = "Check_MakeItem";
            this.Check_MakeItem.Size = new System.Drawing.Size(109, 17);
            this.Check_MakeItem.TabIndex = 18;
            this.Check_MakeItem.Text = "Active Make Item";
            this.Check_MakeItem.UseVisualStyleBackColor = true;
            this.Check_MakeItem.CheckedChanged += new System.EventHandler(this.Check_MakeItem_CheckedChanged);
            // 
            // Check_GoTown
            // 
            this.Check_GoTown.AutoSize = true;
            this.Check_GoTown.ForeColor = System.Drawing.Color.White;
            this.Check_GoTown.Location = new System.Drawing.Point(353, 127);
            this.Check_GoTown.Name = "Check_GoTown";
            this.Check_GoTown.Size = new System.Drawing.Size(103, 17);
            this.Check_GoTown.TabIndex = 21;
            this.Check_GoTown.Text = "Active Go Town";
            this.Check_GoTown.UseVisualStyleBackColor = true;
            this.Check_GoTown.CheckedChanged += new System.EventHandler(this.Check_GoTown_CheckedChanged);
            // 
            // Check_LoadMonster
            // 
            this.Check_LoadMonster.AutoSize = true;
            this.Check_LoadMonster.ForeColor = System.Drawing.Color.White;
            this.Check_LoadMonster.Location = new System.Drawing.Point(197, 150);
            this.Check_LoadMonster.Name = "Check_LoadMonster";
            this.Check_LoadMonster.Size = new System.Drawing.Size(124, 17);
            this.Check_LoadMonster.TabIndex = 17;
            this.Check_LoadMonster.Text = "Active Load Monster";
            this.Check_LoadMonster.UseVisualStyleBackColor = true;
            this.Check_LoadMonster.CheckedChanged += new System.EventHandler(this.Check_LoadMonster_CheckedChanged);
            // 
            // Check_Invincible
            // 
            this.Check_Invincible.AutoSize = true;
            this.Check_Invincible.ForeColor = System.Drawing.Color.White;
            this.Check_Invincible.Location = new System.Drawing.Point(25, 173);
            this.Check_Invincible.Name = "Check_Invincible";
            this.Check_Invincible.Size = new System.Drawing.Size(104, 17);
            this.Check_Invincible.TabIndex = 20;
            this.Check_Invincible.Text = "Active Invincible";
            this.Check_Invincible.UseVisualStyleBackColor = true;
            this.Check_Invincible.CheckedChanged += new System.EventHandler(this.Check_Invincible_CheckedChanged);
            // 
            // Check_Warp
            // 
            this.Check_Warp.AutoSize = true;
            this.Check_Warp.ForeColor = System.Drawing.Color.White;
            this.Check_Warp.Location = new System.Drawing.Point(25, 150);
            this.Check_Warp.Name = "Check_Warp";
            this.Check_Warp.Size = new System.Drawing.Size(122, 17);
            this.Check_Warp.TabIndex = 16;
            this.Check_Warp.Text = "Active Warp Region";
            this.Check_Warp.UseVisualStyleBackColor = true;
            this.Check_Warp.CheckedChanged += new System.EventHandler(this.Check_Warp_CheckedChanged);
            // 
            // Check_GMSkill
            // 
            this.Check_GMSkill.AutoSize = true;
            this.Check_GMSkill.ForeColor = System.Drawing.Color.White;
            this.Check_GMSkill.Location = new System.Drawing.Point(197, 173);
            this.Check_GMSkill.Name = "Check_GMSkill";
            this.Check_GMSkill.Size = new System.Drawing.Size(98, 17);
            this.Check_GMSkill.TabIndex = 22;
            this.Check_GMSkill.Text = "Active GM Skill";
            this.Check_GMSkill.UseVisualStyleBackColor = true;
            this.Check_GMSkill.CheckedChanged += new System.EventHandler(this.Check_GMSkill_CheckedChanged);
            // 
            // Check_Invisible
            // 
            this.Check_Invisible.AutoSize = true;
            this.Check_Invisible.ForeColor = System.Drawing.Color.White;
            this.Check_Invisible.Location = new System.Drawing.Point(25, 196);
            this.Check_Invisible.Name = "Check_Invisible";
            this.Check_Invisible.Size = new System.Drawing.Size(97, 17);
            this.Check_Invisible.TabIndex = 19;
            this.Check_Invisible.Text = "Active Invisible";
            this.Check_Invisible.UseVisualStyleBackColor = true;
            this.Check_Invisible.CheckedChanged += new System.EventHandler(this.Check_Invisible_CheckedChanged);
            // 
            // Check_Incomechat
            // 
            this.Check_Incomechat.AutoSize = true;
            this.Check_Incomechat.ForeColor = System.Drawing.Color.White;
            this.Check_Incomechat.Location = new System.Drawing.Point(353, 58);
            this.Check_Incomechat.Name = "Check_Incomechat";
            this.Check_Incomechat.Size = new System.Drawing.Size(209, 17);
            this.Check_Incomechat.TabIndex = 9;
            this.Check_Incomechat.Text = "Save Incoming [ Private - Global Chat ]";
            this.Check_Incomechat.UseVisualStyleBackColor = true;
            this.Check_Incomechat.CheckedChanged += new System.EventHandler(this.Check_Incomechat_CheckedChanged);
            // 
            // UniqueLogBox
            // 
            this.UniqueLogBox.AutoSize = true;
            this.UniqueLogBox.ForeColor = System.Drawing.Color.White;
            this.UniqueLogBox.Location = new System.Drawing.Point(25, 81);
            this.UniqueLogBox.Name = "UniqueLogBox";
            this.UniqueLogBox.Size = new System.Drawing.Size(160, 17);
            this.UniqueLogBox.TabIndex = 10;
            this.UniqueLogBox.Text = "Save Incoming Uniques Log";
            this.UniqueLogBox.UseVisualStyleBackColor = true;
            this.UniqueLogBox.CheckedChanged += new System.EventHandler(this.UniqueLogBox_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tabControl1.ControlBox.MenuBox.Name = "";
            this.tabControl1.ControlBox.Name = "";
            this.tabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabControl1.ControlBox.MenuBox,
            this.tabControl1.ControlBox.CloseBox});
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.superTabControlPanel18);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.superTabControlPanel1);
            this.tabControl1.ForeColor = System.Drawing.Color.White;
            this.tabControl1.Location = new System.Drawing.Point(12, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.ReorderTabsEnabled = false;
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(853, 399);
            this.tabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
            this.tabControl1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.tabControl1.TabHorizontalSpacing = 10;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2,
            this.superTabItem3,
            this.tabPage4,
            this.superTabItem21});
            superTabControlBoxStateColorTable1.Background = System.Drawing.Color.Black;
            superTabColorTable1.ControlBoxDefault = superTabControlBoxStateColorTable1;
            this.tabControl1.TabStripColor = superTabColorTable1;
            this.tabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            this.tabControl1.TabVerticalSpacing = 20;
            this.tabControl1.Text = "New Useful";
            this.tabControl1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panelEx38);
            this.tabPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage3.Location = new System.Drawing.Point(142, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(711, 399);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.TabItem = this.superTabItem3;
            // 
            // panelEx38
            // 
            this.panelEx38.BackColor = System.Drawing.Color.Black;
            this.panelEx38.Controls.Add(this.textBox19);
            this.panelEx38.Controls.Add(this.Check_StallCreate);
            this.panelEx38.Controls.Add(this.label90);
            this.panelEx38.Controls.Add(this.Check_Warp);
            this.panelEx38.Controls.Add(this.label89);
            this.panelEx38.Controls.Add(this.Check_GoTown);
            this.panelEx38.Controls.Add(this.Check_Incomechat);
            this.panelEx38.Controls.Add(this.Check_Movetouser);
            this.panelEx38.Controls.Add(this.Check_Private);
            this.panelEx38.Controls.Add(this.Check_GMSkill);
            this.panelEx38.Controls.Add(this.Check_PvpCape);
            this.panelEx38.Controls.Add(this.Check_RecallGuild);
            this.panelEx38.Controls.Add(this.Check_Invisible);
            this.panelEx38.Controls.Add(this.Check_LoadMonster);
            this.panelEx38.Controls.Add(this.UniqueLogBox);
            this.panelEx38.Controls.Add(this.Check_ToTown);
            this.panelEx38.Controls.Add(this.Check_Msg);
            this.panelEx38.Controls.Add(this.Check_DcUser);
            this.panelEx38.Controls.Add(this.Check_Notice);
            this.panelEx38.Controls.Add(this.Check_Global);
            this.panelEx38.Controls.Add(this.Check_RecallUser);
            this.panelEx38.Controls.Add(this.Check_Invincible);
            this.panelEx38.Controls.Add(this.Check_MakeItem);
            this.panelEx38.Controls.Add(this.Check_ChatAll);
            this.panelEx38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx38.Location = new System.Drawing.Point(0, 0);
            this.panelEx38.Name = "panelEx38";
            this.panelEx38.Size = new System.Drawing.Size(711, 399);
            this.panelEx38.TabIndex = 4;
            // 
            // Check_StallCreate
            // 
            this.Check_StallCreate.AutoSize = true;
            this.Check_StallCreate.ForeColor = System.Drawing.Color.White;
            this.Check_StallCreate.Location = new System.Drawing.Point(197, 58);
            this.Check_StallCreate.Name = "Check_StallCreate";
            this.Check_StallCreate.Size = new System.Drawing.Size(116, 17);
            this.Check_StallCreate.TabIndex = 9;
            this.Check_StallCreate.Text = "Active Stall System";
            this.Check_StallCreate.UseVisualStyleBackColor = true;
            this.Check_StallCreate.CheckedChanged += new System.EventHandler(this.Check_StallCreate_CheckedChanged);
            // 
            // Check_Private
            // 
            this.Check_Private.AutoSize = true;
            this.Check_Private.ForeColor = System.Drawing.Color.White;
            this.Check_Private.Location = new System.Drawing.Point(25, 104);
            this.Check_Private.Name = "Check_Private";
            this.Check_Private.Size = new System.Drawing.Size(112, 17);
            this.Check_Private.TabIndex = 3;
            this.Check_Private.Text = "Send Private Chat";
            this.Check_Private.UseVisualStyleBackColor = true;
            this.Check_Private.CheckedChanged += new System.EventHandler(this.Check_Private_CheckedChanged);
            // 
            // Check_PvpCape
            // 
            this.Check_PvpCape.AutoSize = true;
            this.Check_PvpCape.ForeColor = System.Drawing.Color.White;
            this.Check_PvpCape.Location = new System.Drawing.Point(26, 58);
            this.Check_PvpCape.Name = "Check_PvpCape";
            this.Check_PvpCape.Size = new System.Drawing.Size(139, 17);
            this.Check_PvpCape.TabIndex = 10;
            this.Check_PvpCape.Text = "Active Pvp Cape (Color)";
            this.Check_PvpCape.UseVisualStyleBackColor = true;
            this.Check_PvpCape.CheckedChanged += new System.EventHandler(this.Check_PvpCape_CheckedChanged);
            // 
            // Check_Msg
            // 
            this.Check_Msg.AutoSize = true;
            this.Check_Msg.ForeColor = System.Drawing.Color.White;
            this.Check_Msg.Location = new System.Drawing.Point(353, 81);
            this.Check_Msg.Name = "Check_Msg";
            this.Check_Msg.Size = new System.Drawing.Size(97, 17);
            this.Check_Msg.TabIndex = 4;
            this.Check_Msg.Text = "Send Message";
            this.Check_Msg.UseVisualStyleBackColor = true;
            this.Check_Msg.CheckedChanged += new System.EventHandler(this.Check_Msg_CheckedChanged);
            // 
            // Check_Notice
            // 
            this.Check_Notice.AutoSize = true;
            this.Check_Notice.ForeColor = System.Drawing.Color.White;
            this.Check_Notice.Location = new System.Drawing.Point(197, 81);
            this.Check_Notice.Name = "Check_Notice";
            this.Check_Notice.Size = new System.Drawing.Size(85, 17);
            this.Check_Notice.TabIndex = 2;
            this.Check_Notice.Text = "Send Notice";
            this.Check_Notice.UseVisualStyleBackColor = true;
            this.Check_Notice.CheckedChanged += new System.EventHandler(this.Check_Notice_CheckedChanged);
            // 
            // Check_Global
            // 
            this.Check_Global.AutoSize = true;
            this.Check_Global.ForeColor = System.Drawing.Color.White;
            this.Check_Global.Location = new System.Drawing.Point(353, 104);
            this.Check_Global.Name = "Check_Global";
            this.Check_Global.Size = new System.Drawing.Size(287, 17);
            this.Check_Global.TabIndex = 5;
            this.Check_Global.Text = "Send Global Chat - ITEM_MALL_GLOBAL_CHATTING";
            this.Check_Global.UseVisualStyleBackColor = true;
            this.Check_Global.CheckedChanged += new System.EventHandler(this.Check_Global_CheckedChanged);
            // 
            // Check_ChatAll
            // 
            this.Check_ChatAll.AutoSize = true;
            this.Check_ChatAll.ForeColor = System.Drawing.Color.White;
            this.Check_ChatAll.Location = new System.Drawing.Point(197, 104);
            this.Check_ChatAll.Name = "Check_ChatAll";
            this.Check_ChatAll.Size = new System.Drawing.Size(108, 17);
            this.Check_ChatAll.TabIndex = 7;
            this.Check_ChatAll.Text = "Send Public Chat";
            this.Check_ChatAll.UseVisualStyleBackColor = true;
            this.Check_ChatAll.CheckedChanged += new System.EventHandler(this.Check_ChatAll_CheckedChanged);
            // 
            // superTabItem3
            // 
            this.superTabItem3.AttachedControl = this.tabPage3;
            this.superTabItem3.GlobalItem = false;
            this.superTabItem3.Name = "superTabItem3";
            this.superTabItem3.Text = "System Services";
            this.superTabItem3.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(142, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(711, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.TabItem = this.superTabItem1;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Black;
            this.groupBox4.Controls.Add(this.PLSQLRange);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(711, 399);
            this.groupBox4.TabIndex = 4;
            // 
            // PLSQLRange
            // 
            this.PLSQLRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PLSQLRange.Controls.Add(this.SQLConnect);
            this.PLSQLRange.Controls.Add(this.label6);
            this.PLSQLRange.Controls.Add(this.Host);
            this.PLSQLRange.Controls.Add(this.HostPw);
            this.PLSQLRange.Controls.Add(this.label46);
            this.PLSQLRange.Controls.Add(this.label8);
            this.PLSQLRange.Controls.Add(this.label20);
            this.PLSQLRange.Controls.Add(this.Shardlog);
            this.PLSQLRange.Controls.Add(this.label12);
            this.PLSQLRange.Controls.Add(this.Account);
            this.PLSQLRange.Controls.Add(this.label9);
            this.PLSQLRange.Controls.Add(this.Shard);
            this.PLSQLRange.Controls.Add(this.HostUser);
            this.PLSQLRange.Location = new System.Drawing.Point(12, 11);
            this.PLSQLRange.Name = "PLSQLRange";
            this.PLSQLRange.Size = new System.Drawing.Size(387, 166);
            this.PLSQLRange.TabIndex = 32;
            // 
            // SQLConnect
            // 
            this.SQLConnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SQLConnect.BackColor = System.Drawing.Color.Black;
            this.SQLConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SQLConnect.ForeColor = System.Drawing.Color.White;
            this.SQLConnect.Location = new System.Drawing.Point(279, 71);
            this.SQLConnect.Name = "SQLConnect";
            this.SQLConnect.Size = new System.Drawing.Size(100, 78);
            this.SQLConnect.TabIndex = 9;
            this.SQLConnect.Text = "Connect SQL";
            this.SQLConnect.UseVisualStyleBackColor = false;
            this.SQLConnect.Click += new System.EventHandler(this.SQLConnect_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sql host :";
            // 
            // Host
            // 
            this.Host.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Host.BackColor = System.Drawing.Color.Black;
            this.Host.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Host.ForeColor = System.Drawing.Color.White;
            this.Host.Location = new System.Drawing.Point(84, 13);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(295, 20);
            this.Host.TabIndex = 2;
            this.Host.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HostPw
            // 
            this.HostPw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HostPw.BackColor = System.Drawing.Color.Black;
            this.HostPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HostPw.ForeColor = System.Drawing.Color.White;
            this.HostPw.Location = new System.Drawing.Point(279, 42);
            this.HostPw.Name = "HostPw";
            this.HostPw.PasswordChar = '●';
            this.HostPw.Size = new System.Drawing.Size(100, 20);
            this.HostPw.TabIndex = 4;
            this.HostPw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Black;
            this.label46.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label46.Location = new System.Drawing.Point(6, 131);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(74, 13);
            this.label46.TabIndex = 0;
            this.label46.Text = "Sro Shardlog :";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(6, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sql user :";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label20.Location = new System.Drawing.Point(6, 103);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Sro Account :";
            // 
            // Shardlog
            // 
            this.Shardlog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Shardlog.BackColor = System.Drawing.Color.Black;
            this.Shardlog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Shardlog.ForeColor = System.Drawing.Color.White;
            this.Shardlog.Location = new System.Drawing.Point(84, 129);
            this.Shardlog.Name = "Shardlog";
            this.Shardlog.Size = new System.Drawing.Size(189, 20);
            this.Shardlog.TabIndex = 8;
            this.Shardlog.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(6, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Sro Shard :";
            // 
            // Account
            // 
            this.Account.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Account.BackColor = System.Drawing.Color.Black;
            this.Account.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Account.ForeColor = System.Drawing.Color.White;
            this.Account.Location = new System.Drawing.Point(84, 101);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(189, 20);
            this.Account.TabIndex = 7;
            this.Account.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(197, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Sql password :";
            // 
            // Shard
            // 
            this.Shard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Shard.BackColor = System.Drawing.Color.Black;
            this.Shard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Shard.ForeColor = System.Drawing.Color.White;
            this.Shard.Location = new System.Drawing.Point(84, 73);
            this.Shard.Name = "Shard";
            this.Shard.Size = new System.Drawing.Size(190, 20);
            this.Shard.TabIndex = 6;
            this.Shard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HostUser
            // 
            this.HostUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HostUser.BackColor = System.Drawing.Color.Black;
            this.HostUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HostUser.ForeColor = System.Drawing.Color.White;
            this.HostUser.Location = new System.Drawing.Point(84, 41);
            this.HostUser.Name = "HostUser";
            this.HostUser.Size = new System.Drawing.Size(96, 20);
            this.HostUser.TabIndex = 3;
            this.HostUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.slocale);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Check_AutoRelog);
            this.groupBox1.Controls.Add(this.sversion);
            this.groupBox1.Controls.Add(this.gateport);
            this.groupBox1.Controls.Add(this.ip);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 199);
            this.groupBox1.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(193, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Server Connect";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(48, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Server IP :";
            // 
            // slocale
            // 
            this.slocale.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.slocale.BackColor = System.Drawing.Color.Black;
            this.slocale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.slocale.ForeColor = System.Drawing.Color.White;
            this.slocale.Location = new System.Drawing.Point(271, 73);
            this.slocale.Name = "slocale";
            this.slocale.Size = new System.Drawing.Size(61, 20);
            this.slocale.TabIndex = 4;
            this.slocale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slocale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(48, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Version :";
            // 
            // Check_AutoRelog
            // 
            this.Check_AutoRelog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Check_AutoRelog.AutoSize = true;
            this.Check_AutoRelog.BackColor = System.Drawing.Color.Black;
            this.Check_AutoRelog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Check_AutoRelog.Location = new System.Drawing.Point(51, 133);
            this.Check_AutoRelog.Name = "Check_AutoRelog";
            this.Check_AutoRelog.Size = new System.Drawing.Size(109, 17);
            this.Check_AutoRelog.TabIndex = 6;
            this.Check_AutoRelog.Text = "Active auto re-log";
            this.Check_AutoRelog.UseVisualStyleBackColor = false;
            // 
            // sversion
            // 
            this.sversion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sversion.BackColor = System.Drawing.Color.Black;
            this.sversion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sversion.ForeColor = System.Drawing.Color.White;
            this.sversion.Location = new System.Drawing.Point(114, 100);
            this.sversion.Name = "sversion";
            this.sversion.Size = new System.Drawing.Size(218, 20);
            this.sversion.TabIndex = 5;
            this.sversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sversion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // gateport
            // 
            this.gateport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gateport.BackColor = System.Drawing.Color.Black;
            this.gateport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gateport.ForeColor = System.Drawing.Color.White;
            this.gateport.Location = new System.Drawing.Point(114, 72);
            this.gateport.Name = "gateport";
            this.gateport.Size = new System.Drawing.Size(70, 20);
            this.gateport.TabIndex = 3;
            this.gateport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gateport.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxNumberic_KeyPress);
            // 
            // ip
            // 
            this.ip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ip.BackColor = System.Drawing.Color.Black;
            this.ip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ip.ForeColor = System.Drawing.Color.White;
            this.ip.Location = new System.Drawing.Point(114, 44);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(218, 20);
            this.ip.TabIndex = 2;
            this.ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(48, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Login port :";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Black;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(48, 203);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Enable X-Trap";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(190, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Server locale :";
            // 
            // groupBox3
            // 
            this.groupBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.txtCharLevel);
            this.groupBox3.Controls.Add(this.txtCharName);
            this.groupBox3.Controls.Add(this.PicCharSel);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.id);
            this.groupBox3.Controls.Add(this.captcha_text);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.pw);
            this.groupBox3.Controls.Add(this.char_list);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(405, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 371);
            this.groupBox3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(25, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 32);
            this.button2.TabIndex = 19;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCharLevel
            // 
            this.txtCharLevel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCharLevel.BackColor = System.Drawing.Color.Black;
            this.txtCharLevel.ForeColor = System.Drawing.Color.White;
            this.txtCharLevel.Location = new System.Drawing.Point(34, 339);
            this.txtCharLevel.Name = "txtCharLevel";
            this.txtCharLevel.Size = new System.Drawing.Size(93, 18);
            this.txtCharLevel.TabIndex = 18;
            this.txtCharLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCharName
            // 
            this.txtCharName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCharName.ForeColor = System.Drawing.Color.White;
            this.txtCharName.Location = new System.Drawing.Point(140, 219);
            this.txtCharName.Name = "txtCharName";
            this.txtCharName.Size = new System.Drawing.Size(125, 148);
            this.txtCharName.TabIndex = 17;
            // 
            // PicCharSel
            // 
            this.PicCharSel.BackColor = System.Drawing.Color.Black;
            this.PicCharSel.Image = global:: MangerSroApp.Properties.Resource1._300px_Guild1;
            this.PicCharSel.Location = new System.Drawing.Point(28, 220);
            this.PicCharSel.Name = "PicCharSel";
            this.PicCharSel.Size = new System.Drawing.Size(107, 148);
            this.PicCharSel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicCharSel.TabIndex = 16;
            this.PicCharSel.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account id :";
            // 
            // id
            // 
            this.id.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.id.BackColor = System.Drawing.Color.Black;
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id.ForeColor = System.Drawing.Color.White;
            this.id.Location = new System.Drawing.Point(98, 8);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(167, 20);
            this.id.TabIndex = 9;
            this.id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // captcha_text
            // 
            this.captcha_text.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.captcha_text.BackColor = System.Drawing.Color.Black;
            this.captcha_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.captcha_text.ForeColor = System.Drawing.Color.White;
            this.captcha_text.Location = new System.Drawing.Point(27, 171);
            this.captcha_text.Name = "captcha_text";
            this.captcha_text.Size = new System.Drawing.Size(135, 20);
            this.captcha_text.TabIndex = 12;
            this.captcha_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(27, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Account pw :";
            // 
            // pw
            // 
            this.pw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pw.BackColor = System.Drawing.Color.Black;
            this.pw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pw.ForeColor = System.Drawing.Color.White;
            this.pw.Location = new System.Drawing.Point(98, 34);
            this.pw.Name = "pw";
            this.pw.PasswordChar = '●';
            this.pw.Size = new System.Drawing.Size(167, 20);
            this.pw.TabIndex = 10;
            this.pw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // char_list
            // 
            this.char_list.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.char_list.DisplayMember = "Text";
            this.char_list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.char_list.ForeColor = System.Drawing.Color.Black;
            this.char_list.FormattingEnabled = true;
            this.char_list.ItemHeight = 14;
            this.char_list.Location = new System.Drawing.Point(27, 194);
            this.char_list.Name = "char_list";
            this.char_list.Size = new System.Drawing.Size(135, 20);
            this.char_list.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.char_list.TabIndex = 14;
            this.char_list.SelectedIndexChanged += new System.EventHandler(this.char_list_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button3.Location = new System.Drawing.Point(168, 171);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 20);
            this.button3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button3.TabIndex = 13;
            this.button3.Text = "Send Captcha";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button4.Location = new System.Drawing.Point(168, 194);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 18);
            this.button4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button4.TabIndex = 15;
            this.button4.Text = "Select Character";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.tabPage1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "Main";
            this.superTabItem1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.panel2);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(142, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(711, 399);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.tabPage4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.expandablePanel1);
            this.panel2.Controls.Add(this.listViewEx1);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(711, 399);
            this.panel2.TabIndex = 4;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Black;
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(22, 342);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(630, 13);
            this.label23.TabIndex = 1;
            this.label23.Text = "* This system allows you to execute any query or procedure by a timer, just add q" +
    "uery and time into database table [dbo].[ExecQuery]";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Black;
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(54, 359);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(572, 13);
            this.label25.TabIndex = 2;
            this.label25.Text = "* Caution : Cannot execute more than one query per a second. so don\'t set two row" +
    "s or more with a same time into table.";
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.label58);
            this.expandablePanel1.Controls.Add(this.label72);
            this.expandablePanel1.Controls.Add(this.label62);
            this.expandablePanel1.Controls.Add(this.label59);
            this.expandablePanel1.Controls.Add(this.label95);
            this.expandablePanel1.Controls.Add(this.label111);
            this.expandablePanel1.Controls.Add(this.label100);
            this.expandablePanel1.Controls.Add(this.label77);
            this.expandablePanel1.Controls.Add(this.label76);
            this.expandablePanel1.Controls.Add(this.label53);
            this.expandablePanel1.Controls.Add(this.label73);
            this.expandablePanel1.Controls.Add(this.label37);
            this.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel1.Expanded = false;
            this.expandablePanel1.ExpandedBounds = new System.Drawing.Rectangle(444, 27, 242, 247);
            this.expandablePanel1.Location = new System.Drawing.Point(444, 27);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(242, 26);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.Color = System.Drawing.Color.Black;
            this.expandablePanel1.Style.BackColor2.Color = System.Drawing.Color.Black;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.Color = System.Drawing.Color.White;
            this.expandablePanel1.Style.ForeColor.Color = System.Drawing.Color.White;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 4;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "System Guide";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.ForeColor = System.Drawing.Color.White;
            this.label58.Location = new System.Drawing.Point(12, 69);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(154, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "[ which tool objects created in ]";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.BackColor = System.Drawing.Color.Transparent;
            this.label72.ForeColor = System.Drawing.Color.White;
            this.label72.Location = new System.Drawing.Point(4, 126);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(152, 13);
            this.label72.TabIndex = 1;
            this.label72.Text = "- ShardLog database index = 4";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.BackColor = System.Drawing.Color.Transparent;
            this.label62.ForeColor = System.Drawing.Color.White;
            this.label62.Location = new System.Drawing.Point(4, 107);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(146, 13);
            this.label62.TabIndex = 1;
            this.label62.Text = "- Account database index = 3";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.Transparent;
            this.label59.ForeColor = System.Drawing.Color.White;
            this.label59.Location = new System.Drawing.Point(4, 88);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(134, 13);
            this.label59.TabIndex = 1;
            this.label59.Text = "- Shard database index = 2";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(4, 207);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(0, 13);
            this.label95.TabIndex = 1;
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.BackColor = System.Drawing.Color.Transparent;
            this.label111.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label111.ForeColor = System.Drawing.Color.White;
            this.label111.Location = new System.Drawing.Point(7, 207);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(175, 13);
            this.label111.TabIndex = 1;
            this.label111.Text = "\'Wednesday\' , \' Thursday\' or \'Friday\'";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.BackColor = System.Drawing.Color.Transparent;
            this.label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.ForeColor = System.Drawing.Color.White;
            this.label100.Location = new System.Drawing.Point(7, 189);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(213, 13);
            this.label100.TabIndex = 1;
            this.label100.Text = "\'Saturday\' , \'Sunday\' , \'Monday\' , \'Tuesday\' ,";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.BackColor = System.Drawing.Color.Transparent;
            this.label77.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.White;
            this.label77.Location = new System.Drawing.Point(7, 225);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(106, 13);
            this.label77.TabIndex = 1;
            this.label77.Text = "For daily use \'Always\'";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.ForeColor = System.Drawing.Color.White;
            this.label76.Location = new System.Drawing.Point(4, 169);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(229, 13);
            this.label76.TabIndex = 1;
            this.label76.Text = "Use a varchar values in [Day] column as below";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.ForeColor = System.Drawing.Color.White;
            this.label53.Location = new System.Drawing.Point(4, 51);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(127, 13);
            this.label53.TabIndex = 1;
            this.label53.Text = "- Tool database index = 1";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.BackColor = System.Drawing.Color.Transparent;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.White;
            this.label73.Location = new System.Drawing.Point(4, 150);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(114, 13);
            this.label73.TabIndex = 1;
            this.label73.Text = "Specific days  system :";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(4, 32);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(87, 13);
            this.label37.TabIndex = 1;
            this.label37.Text = "Database index :";
            // 
            // listViewEx1
            // 
            this.listViewEx1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CharName,
            this.CharUniqueID});
            this.listViewEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx1.ForeColor = System.Drawing.Color.Black;
            this.listViewEx1.GridLines = true;
            this.listViewEx1.HideSelection = false;
            this.listViewEx1.Location = new System.Drawing.Point(568, 58);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(120, 264);
            this.listViewEx1.TabIndex = 14;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            // 
            // CharName
            // 
            this.CharName.Text = "CharName";
            this.CharName.Width = 62;
            // 
            // CharUniqueID
            // 
            this.CharUniqueID.Text = "UniqueID";
            this.CharUniqueID.Width = 80;
            // 
            // tabPage4
            // 
            this.tabPage4.AttachedControl = this.superTabControlPanel1;
            this.tabPage4.GlobalItem = false;
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Text = "Execute Schedule";
            this.tabPage4.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // superTabControlPanel18
            // 
            this.superTabControlPanel18.Controls.Add(this.tabControl2);
            this.superTabControlPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel18.Location = new System.Drawing.Point(142, 0);
            this.superTabControlPanel18.Name = "superTabControlPanel18";
            this.superTabControlPanel18.Size = new System.Drawing.Size(711, 399);
            this.superTabControlPanel18.TabIndex = 0;
            this.superTabControlPanel18.TabItem = this.superTabItem21;
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.Black;
            this.tabControl2.Controls.Add(this.MainFun);
            this.tabControl2.Controls.Add(this.ManageCharPanel);
            this.tabControl2.Controls.Add(this.CollectBookPanel);
            this.tabControl2.Controls.Add(this.CharInvPanel);
            this.tabControl2.Controls.Add(this.CharacterPanel);
            this.tabControl2.Controls.Add(this.ManageUserPanel);
            this.tabControl2.Controls.Add(this.SilkControlPanel);
            this.tabControl2.Controls.Add(this.UserCharPanel);
            this.tabControl2.Controls.Add(this.TeamUserPanel);
            this.tabControl2.Controls.Add(this.UserPanel);
            this.tabControl2.Controls.Add(this.NextUpdatePanel);
            this.tabControl2.Location = new System.Drawing.Point(-1, -1);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Size = new System.Drawing.Size(713, 400);
            this.tabControl2.TabIndex = 0;
            // 
            // MainFun
            // 
            this.MainFun.BackColor = System.Drawing.Color.Black;
            this.MainFun.Controls.Add(this.buttonX8);
            this.MainFun.Controls.Add(this.buttonX7);
            this.MainFun.Controls.Add(this.buttonX4);
            this.MainFun.Controls.Add(this.buttonX9);
            this.MainFun.Controls.Add(this.buttonX6);
            this.MainFun.Controls.Add(this.buttonX1);
            this.MainFun.Controls.Add(this.buttonX5);
            this.MainFun.Controls.Add(this.buttonX2);
            this.MainFun.Controls.Add(this.buttonX3);
            this.MainFun.ForeColor = System.Drawing.Color.White;
            this.MainFun.Location = new System.Drawing.Point(8, 8);
            this.MainFun.Name = "MainFun";
            this.MainFun.Size = new System.Drawing.Size(696, 381);
            this.MainFun.TabIndex = 1;
            // 
            // buttonX8
            // 
            this.buttonX8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX8.AntiAlias = true;
            this.buttonX8.BackColor = System.Drawing.Color.Black;
            this.buttonX8.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX8.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.buttonX8.Image = global:: MangerSroApp.Properties.Resource1.Sea_Monster___2007_TMNT_film;
            this.buttonX8.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX8.ImageTextSpacing = 1;
            this.buttonX8.Location = new System.Drawing.Point(504, 22);
            this.buttonX8.Name = "buttonX8";
            this.buttonX8.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonX8.Size = new System.Drawing.Size(148, 125);
            this.buttonX8.SplitButton = true;
            this.buttonX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX8.SymbolSize = 1F;
            this.buttonX8.TabIndex = 23;
            this.buttonX8.Text = "Monster";
            this.buttonX8.TextColor = System.Drawing.Color.White;
            this.buttonX8.Click += new System.EventHandler(this.buttonX8_Click);
            // 
            // buttonX7
            // 
            this.buttonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX7.AntiAlias = true;
            this.buttonX7.BackColor = System.Drawing.Color.Black;
            this.buttonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX7.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.buttonX7.Image = global:: MangerSroApp.Properties.Resource1.Oriental_fortress;
            this.buttonX7.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX7.ImageTextSpacing = 1;
            this.buttonX7.Location = new System.Drawing.Point(395, 22);
            this.buttonX7.Name = "buttonX7";
            this.buttonX7.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonX7.Size = new System.Drawing.Size(103, 125);
            this.buttonX7.SplitButton = true;
            this.buttonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX7.SymbolSize = 1F;
            this.buttonX7.TabIndex = 22;
            this.buttonX7.Text = "Fortress War";
            this.buttonX7.TextColor = System.Drawing.Color.White;
            this.buttonX7.Click += new System.EventHandler(this.buttonX7_Click);
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.AntiAlias = true;
            this.buttonX4.BackColor = System.Drawing.Color.Black;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX4.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.buttonX4.Image = global:: MangerSroApp.Properties.Resource1.kpi_icons_04_320x320;
            this.buttonX4.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX4.ImageTextSpacing = 1;
            this.buttonX4.Location = new System.Drawing.Point(177, 152);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonX4.Size = new System.Drawing.Size(103, 125);
            this.buttonX4.SplitButton = true;
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.SymbolSize = 1F;
            this.buttonX4.TabIndex = 25;
            this.buttonX4.Text = "Rates";
            this.buttonX4.TextColor = System.Drawing.Color.White;
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX9
            // 
            this.buttonX9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX9.AntiAlias = true;
            this.buttonX9.BackColor = System.Drawing.Color.Black;
            this.buttonX9.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX9.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.buttonX9.Image = global:: MangerSroApp.Properties.Resource1.database_with_broom;
            this.buttonX9.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX9.ImageTextSpacing = 1;
            this.buttonX9.Location = new System.Drawing.Point(395, 152);
            this.buttonX9.Name = "buttonX9";
            this.buttonX9.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonX9.Size = new System.Drawing.Size(103, 125);
            this.buttonX9.SplitButton = true;
            this.buttonX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX9.SymbolSize = 1F;
            this.buttonX9.TabIndex = 27;
            this.buttonX9.Text = "Database Cleaner";
            this.buttonX9.TextColor = System.Drawing.Color.White;
            this.buttonX9.Click += new System.EventHandler(this.buttonX9_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.AntiAlias = true;
            this.buttonX6.BackColor = System.Drawing.Color.Black;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX6.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.buttonX6.Image = global:: MangerSroApp.Properties.Resource1.repair;
            this.buttonX6.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX6.ImageTextSpacing = 1;
            this.buttonX6.Location = new System.Drawing.Point(286, 152);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonX6.Size = new System.Drawing.Size(103, 125);
            this.buttonX6.SplitButton = true;
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.SymbolSize = 1F;
            this.buttonX6.TabIndex = 26;
            this.buttonX6.Text = "Fixing Bugs";
            this.buttonX6.TextColor = System.Drawing.Color.White;
            this.buttonX6.Click += new System.EventHandler(this.buttonX6_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.AntiAlias = true;
            this.buttonX1.BackColor = System.Drawing.Color.Black;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX1.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.buttonX1.Image = global:: MangerSroApp.Properties.Resource1.user_edit_512;
            this.buttonX1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX1.ImageTextSpacing = 1;
            this.buttonX1.Location = new System.Drawing.Point(43, 21);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonX1.Size = new System.Drawing.Size(128, 125);
            this.buttonX1.SplitButton = true;
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.SymbolSize = 1F;
            this.buttonX1.TabIndex = 19;
            this.buttonX1.Text = "Character";
            this.buttonX1.TextColor = System.Drawing.Color.White;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.AntiAlias = true;
            this.buttonX5.BackColor = System.Drawing.Color.Black;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX5.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.buttonX5.Image = global:: MangerSroApp.Properties.Resource1._300px_Guild1;
            this.buttonX5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX5.ImageTextSpacing = 1;
            this.buttonX5.Location = new System.Drawing.Point(43, 152);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonX5.Size = new System.Drawing.Size(128, 125);
            this.buttonX5.SplitButton = true;
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.SymbolSize = 1F;
            this.buttonX5.TabIndex = 24;
            this.buttonX5.Text = "Guild - Union";
            this.buttonX5.TextColor = System.Drawing.Color.White;
            this.buttonX5.Click += new System.EventHandler(this.buttonX5_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.AntiAlias = true;
            this.buttonX2.BackColor = System.Drawing.Color.Black;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX2.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.buttonX2.Image = global:: MangerSroApp.Properties.Resource1.edit_group;
            this.buttonX2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX2.ImageTextSpacing = 1;
            this.buttonX2.Location = new System.Drawing.Point(177, 22);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonX2.Size = new System.Drawing.Size(103, 125);
            this.buttonX2.SplitButton = true;
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.SymbolSize = 1F;
            this.buttonX2.TabIndex = 20;
            this.buttonX2.Text = "User";
            this.buttonX2.TextColor = System.Drawing.Color.White;
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.AntiAlias = true;
            this.buttonX3.BackColor = System.Drawing.Color.Black;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX3.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.buttonX3.Image = global:: MangerSroApp.Properties.Resource1.RiGy5xLoT;
            this.buttonX3.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX3.ImageTextSpacing = 1;
            this.buttonX3.Location = new System.Drawing.Point(286, 22);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.buttonX3.Size = new System.Drawing.Size(103, 125);
            this.buttonX3.SplitButton = true;
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.SymbolSize = 1F;
            this.buttonX3.TabIndex = 21;
            this.buttonX3.Text = "Items";
            this.buttonX3.TextColor = System.Drawing.Color.White;
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // ManageCharPanel
            // 
            this.ManageCharPanel.BackColor = System.Drawing.Color.Black;
            this.ManageCharPanel.Controls.Add(this.label42);
            this.ManageCharPanel.Controls.Add(this.panel57);
            this.ManageCharPanel.Controls.Add(this.panel67);
            this.ManageCharPanel.ForeColor = System.Drawing.Color.White;
            this.ManageCharPanel.Location = new System.Drawing.Point(8, 8);
            this.ManageCharPanel.Name = "ManageCharPanel";
            this.ManageCharPanel.Size = new System.Drawing.Size(696, 384);
            this.ManageCharPanel.SlideOutButtonVisible = false;
            this.ManageCharPanel.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Bottom;
            this.ManageCharPanel.TabIndex = 3;
            this.ManageCharPanel.Text = "slidePanel2";
            this.ManageCharPanel.UsesBlockingAnimation = false;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Black;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.White;
            this.label42.Location = new System.Drawing.Point(20, 30);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(153, 17);
            this.label42.TabIndex = 0;
            this.label42.Text = "Edit character statics";
            // 
            // panel57
            // 
            this.panel57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel57.Controls.Add(this.label97);
            this.panel57.Controls.Add(this.CID);
            this.panel57.Controls.Add(this.button23);
            this.panel57.Controls.Add(this.button26);
            this.panel57.Controls.Add(this.label103);
            this.panel57.Controls.Add(this.pictureBox5);
            this.panel57.Controls.Add(this.label98);
            this.panel57.Controls.Add(this.label102);
            this.panel57.Controls.Add(this.CName16);
            this.panel57.Controls.Add(this.label107);
            this.panel57.Controls.Add(this.label108);
            this.panel57.Controls.Add(this.label96);
            this.panel57.Controls.Add(this.label101);
            this.panel57.Controls.Add(this.label106);
            this.panel57.Controls.Add(this.label26);
            this.panel57.Controls.Add(this.NkName16);
            this.panel57.Controls.Add(this.Exp);
            this.panel57.Controls.Add(this.label105);
            this.panel57.Controls.Add(this.CurLvl);
            this.panel57.Controls.Add(this.JobType);
            this.panel57.Controls.Add(this.MaxLvl);
            this.panel57.Controls.Add(this.HwanLvl);
            this.panel57.Controls.Add(this.label94);
            this.panel57.Controls.Add(this.Sp);
            this.panel57.Controls.Add(this.StatPoint);
            this.panel57.Controls.Add(this.label109);
            this.panel57.Controls.Add(this.CInt);
            this.panel57.Controls.Add(this.JobLvl);
            this.panel57.Controls.Add(this.InvSize);
            this.panel57.Controls.Add(this.label104);
            this.panel57.Controls.Add(this.label93);
            this.panel57.Controls.Add(this.CStr);
            this.panel57.Controls.Add(this.RGold);
            this.panel57.Location = new System.Drawing.Point(18, 59);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(639, 294);
            this.panel57.SlideOutButtonVisible = false;
            this.panel57.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
            this.panel57.TabIndex = 10;
            this.panel57.Text = "slidePanel1";
            this.panel57.UsesBlockingAnimation = false;
            this.panel57.Load += new System.EventHandler(this.panel57_Load);
            // 
            // button23
            // 
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Location = new System.Drawing.Point(256, 25);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(109, 29);
            this.button23.TabIndex = 39;
            this.button23.Text = "Save Changes";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // button26
            // 
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.Location = new System.Drawing.Point(371, 25);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(109, 29);
            this.button26.TabIndex = 38;
            this.button26.Text = "Cancel";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Location = new System.Drawing.Point(472, 74);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(151, 205);
            this.pictureBox5.TabIndex = 31;
            this.pictureBox5.TabStop = false;
            // 
            // CollectBookPanel
            // 
            this.CollectBookPanel.Controls.Add(this.panelEx31);
            this.CollectBookPanel.Location = new System.Drawing.Point(8, 8);
            this.CollectBookPanel.Name = "CollectBookPanel";
            this.CollectBookPanel.Size = new System.Drawing.Size(696, 384);
            this.CollectBookPanel.SlideOutButtonVisible = false;
            this.CollectBookPanel.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Bottom;
            this.CollectBookPanel.TabIndex = 4;
            this.CollectBookPanel.Text = "slidePanel1";
            this.CollectBookPanel.UsesBlockingAnimation = false;
            // 
            // panelEx31
            // 
            this.panelEx31.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx31.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx31.Controls.Add(this.panel60);
            this.panelEx31.Controls.Add(this.panel69);
            this.panelEx31.Controls.Add(this.panelEx14);
            this.panelEx31.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx31.Location = new System.Drawing.Point(14, 14);
            this.panelEx31.Name = "panelEx31";
            this.panelEx31.Size = new System.Drawing.Size(669, 357);
            this.panelEx31.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx31.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx31.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx31.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx31.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx31.Style.GradientAngle = 90;
            this.panelEx31.TabIndex = 0;
            // 
            // panel60
            // 
            this.panel60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel60.Controls.Add(this.panel61);
            this.panel60.Controls.Add(this.panel63);
            this.panel60.Controls.Add(this.panel62);
            this.panel60.Location = new System.Drawing.Point(15, 49);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(639, 256);
            this.panel60.SlideOutButtonVisible = false;
            this.panel60.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
            this.panel60.TabIndex = 42;
            this.panel60.Text = "slidePanel1";
            this.panel60.UsesBlockingAnimation = false;
            // 
            // panel61
            // 
            this.panel61.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel61.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel61.Controls.Add(this.pictureBox14);
            this.panel61.Controls.Add(this.pictureBox7);
            this.panel61.Controls.Add(this.pictureBox13);
            this.panel61.Controls.Add(this.pictureBox8);
            this.panel61.Controls.Add(this.pictureBox12);
            this.panel61.Controls.Add(this.pictureBox9);
            this.panel61.Controls.Add(this.pictureBox11);
            this.panel61.Controls.Add(this.pictureBox10);
            this.panel61.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel61.Location = new System.Drawing.Point(321, 17);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(302, 223);
            this.panel61.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel61.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel61.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel61.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel61.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel61.Style.GradientAngle = 90;
            this.panel61.TabIndex = 33;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox14.Image = global:: MangerSroApp.Properties.Resource1._0;
            this.pictureBox14.Location = new System.Drawing.Point(228, 114);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(68, 102);
            this.pictureBox14.TabIndex = 38;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Image = global:: MangerSroApp.Properties.Resource1._0;
            this.pictureBox7.Location = new System.Drawing.Point(6, 6);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(68, 102);
            this.pictureBox7.TabIndex = 31;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox13.Image = global:: MangerSroApp.Properties.Resource1._0;
            this.pictureBox13.Location = new System.Drawing.Point(154, 114);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(68, 102);
            this.pictureBox13.TabIndex = 37;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox8.Image = global:: MangerSroApp.Properties.Resource1._0;
            this.pictureBox8.Location = new System.Drawing.Point(80, 6);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(68, 102);
            this.pictureBox8.TabIndex = 32;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox12.Image = global:: MangerSroApp.Properties.Resource1._0;
            this.pictureBox12.Location = new System.Drawing.Point(80, 114);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(68, 102);
            this.pictureBox12.TabIndex = 36;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox9.Image = global:: MangerSroApp.Properties.Resource1._0;
            this.pictureBox9.Location = new System.Drawing.Point(154, 6);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(68, 102);
            this.pictureBox9.TabIndex = 33;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox11.Image = global:: MangerSroApp.Properties.Resource1._0;
            this.pictureBox11.Location = new System.Drawing.Point(6, 114);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(68, 102);
            this.pictureBox11.TabIndex = 35;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox10.Image = global:: MangerSroApp.Properties.Resource1._0;
            this.pictureBox10.Location = new System.Drawing.Point(228, 6);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(68, 102);
            this.pictureBox10.TabIndex = 34;
            this.pictureBox10.TabStop = false;
            // 
            // panel63
            // 
            this.panel63.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel63.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel63.Controls.Add(this.label92);
            this.panel63.Controls.Add(this.label36);
            this.panel63.Controls.Add(this.ThemeName);
            this.panel63.Controls.Add(this.TalismanName);
            this.panel63.Controls.Add(this.button29);
            this.panel63.Controls.Add(this.button27);
            this.panel63.Controls.Add(this.button30);
            this.panel63.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel63.Location = new System.Drawing.Point(15, 124);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(300, 116);
            this.panel63.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel63.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel63.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel63.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel63.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel63.Style.GradientAngle = 90;
            this.panel63.TabIndex = 33;
            // 
            // ThemeName
            // 
            this.ThemeName.DisplayMember = "Text";
            this.ThemeName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ThemeName.ForeColor = System.Drawing.Color.Black;
            this.ThemeName.FormattingEnabled = true;
            this.ThemeName.ItemHeight = 14;
            this.ThemeName.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4});
            this.ThemeName.Location = new System.Drawing.Point(67, 11);
            this.ThemeName.Name = "ThemeName";
            this.ThemeName.Size = new System.Drawing.Size(221, 20);
            this.ThemeName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ThemeName.TabIndex = 34;
            this.ThemeName.SelectedIndexChanged += new System.EventHandler(this.ThemeName_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "Togui Village - The Phantom of the Crimson Blood";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "Flame Mountain - The Burning Abyss";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "Shipwreck - The Green Abyss";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "Shipwreck - The Sea of Resentment";
            // 
            // TalismanName
            // 
            this.TalismanName.DisplayMember = "Text";
            this.TalismanName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.TalismanName.ForeColor = System.Drawing.Color.Black;
            this.TalismanName.FormattingEnabled = true;
            this.TalismanName.ItemHeight = 14;
            this.TalismanName.Location = new System.Drawing.Point(67, 42);
            this.TalismanName.Name = "TalismanName";
            this.TalismanName.Size = new System.Drawing.Size(221, 20);
            this.TalismanName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TalismanName.TabIndex = 35;
            // 
            // button29
            // 
            this.button29.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button29.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button29.Location = new System.Drawing.Point(8, 75);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(90, 24);
            this.button29.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button29.TabIndex = 36;
            this.button29.Text = "Add";
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button27
            // 
            this.button27.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button27.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button27.Location = new System.Drawing.Point(104, 75);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(90, 24);
            this.button27.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button27.TabIndex = 37;
            this.button27.Text = "Remove";
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // button30
            // 
            this.button30.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button30.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button30.Location = new System.Drawing.Point(200, 75);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(88, 24);
            this.button30.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button30.TabIndex = 38;
            this.button30.Text = "<- Back";
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // panel62
            // 
            this.panel62.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel62.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel62.Controls.Add(this.Shipwreck2);
            this.panel62.Controls.Add(this.Togui);
            this.panel62.Controls.Add(this.Shipwreck1);
            this.panel62.Controls.Add(this.Flame);
            this.panel62.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel62.Location = new System.Drawing.Point(15, 17);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(300, 101);
            this.panel62.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel62.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel62.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel62.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel62.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel62.Style.GradientAngle = 90;
            this.panel62.TabIndex = 32;
            // 
            // CharInvPanel
            // 
            this.CharInvPanel.Controls.Add(this.panelEx32);
            this.CharInvPanel.Location = new System.Drawing.Point(8, 8);
            this.CharInvPanel.Name = "CharInvPanel";
            this.CharInvPanel.Size = new System.Drawing.Size(696, 384);
            this.CharInvPanel.SlideOutButtonVisible = false;
            this.CharInvPanel.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Bottom;
            this.CharInvPanel.TabIndex = 5;
            this.CharInvPanel.Text = "slidePanel1";
            this.CharInvPanel.UsesBlockingAnimation = false;
            // 
            // panelEx32
            // 
            this.panelEx32.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx32.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx32.Controls.Add(this.buttonX16);
            this.panelEx32.Controls.Add(this.label35);
            this.panelEx32.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx32.Location = new System.Drawing.Point(14, 14);
            this.panelEx32.Name = "panelEx32";
            this.panelEx32.Size = new System.Drawing.Size(669, 357);
            this.panelEx32.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx32.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx32.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx32.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx32.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx32.Style.GradientAngle = 90;
            this.panelEx32.TabIndex = 0;
            // 
            // buttonX16
            // 
            this.buttonX16.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX16.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX16.Location = new System.Drawing.Point(293, 178);
            this.buttonX16.Name = "buttonX16";
            this.buttonX16.Size = new System.Drawing.Size(82, 30);
            this.buttonX16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX16.TabIndex = 4;
            this.buttonX16.Text = "Back";
            this.buttonX16.Click += new System.EventHandler(this.buttonX16_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(219, 149);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(221, 13);
            this.label35.TabIndex = 3;
            this.label35.Text = "Inventory editing system is under construction";
            // 
            // CharacterPanel
            // 
            this.CharacterPanel.Controls.Add(this.panelEx29);
            this.CharacterPanel.Location = new System.Drawing.Point(8, 8);
            this.CharacterPanel.Name = "CharacterPanel";
            this.CharacterPanel.Size = new System.Drawing.Size(696, 384);
            this.CharacterPanel.SlideOutButtonVisible = false;
            this.CharacterPanel.TabIndex = 2;
            this.CharacterPanel.Text = "slidePanel1";
            this.CharacterPanel.UsesBlockingAnimation = false;
            // 
            // panelEx29
            // 
            this.panelEx29.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx29.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx29.Controls.Add(this.buttonX13);
            this.panelEx29.Controls.Add(this.buttonX12);
            this.panelEx29.Controls.Add(this.buttonX11);
            this.panelEx29.Controls.Add(this.buttonX10);
            this.panelEx29.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx29.Location = new System.Drawing.Point(14, 14);
            this.panelEx29.Name = "panelEx29";
            this.panelEx29.Size = new System.Drawing.Size(669, 357);
            this.panelEx29.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx29.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx29.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx29.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx29.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx29.Style.GradientAngle = 90;
            this.panelEx29.TabIndex = 0;
            // 
            // buttonX13
            // 
            this.buttonX13.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX13.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX13.Location = new System.Drawing.Point(31, 179);
            this.buttonX13.Name = "buttonX13";
            this.buttonX13.Size = new System.Drawing.Size(128, 31);
            this.buttonX13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX13.TabIndex = 1;
            this.buttonX13.Text = "Back";
            this.buttonX13.Click += new System.EventHandler(this.buttonX13_Click);
            // 
            // buttonX12
            // 
            this.buttonX12.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX12.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX12.Image = global:: MangerSroApp.Properties.Resource1.levebag_by_akirawr_d6pqlhf;
            this.buttonX12.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX12.Location = new System.Drawing.Point(299, 30);
            this.buttonX12.Name = "buttonX12";
            this.buttonX12.Size = new System.Drawing.Size(128, 126);
            this.buttonX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX12.TabIndex = 0;
            this.buttonX12.Text = "Character Inventory";
            this.buttonX12.Click += new System.EventHandler(this.buttonX12_Click);
            // 
            // buttonX11
            // 
            this.buttonX11.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX11.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX11.Image = global:: MangerSroApp.Properties.Resource1._3a628ad4b5737681af41c6b2208eb0;
            this.buttonX11.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX11.Location = new System.Drawing.Point(165, 30);
            this.buttonX11.Name = "buttonX11";
            this.buttonX11.Size = new System.Drawing.Size(128, 126);
            this.buttonX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX11.TabIndex = 0;
            this.buttonX11.Text = "Collection Book";
            this.buttonX11.Click += new System.EventHandler(this.buttonX11_Click);
            // 
            // buttonX10
            // 
            this.buttonX10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX10.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX10.Image = global:: MangerSroApp.Properties.Resource1.teamwork_pie_chart;
            this.buttonX10.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX10.Location = new System.Drawing.Point(31, 30);
            this.buttonX10.Name = "buttonX10";
            this.buttonX10.Size = new System.Drawing.Size(128, 126);
            this.buttonX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX10.TabIndex = 0;
            this.buttonX10.Text = "Manage Character";
            this.buttonX10.Click += new System.EventHandler(this.buttonX10_Click);
            // 
            // ManageUserPanel
            // 
            this.ManageUserPanel.Controls.Add(this.panelEx34);
            this.ManageUserPanel.Location = new System.Drawing.Point(8, 8);
            this.ManageUserPanel.Name = "ManageUserPanel";
            this.ManageUserPanel.Size = new System.Drawing.Size(696, 384);
            this.ManageUserPanel.SlideOutButtonVisible = false;
            this.ManageUserPanel.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Bottom;
            this.ManageUserPanel.TabIndex = 7;
            this.ManageUserPanel.Text = "slidePanel1";
            this.ManageUserPanel.UsesBlockingAnimation = false;
            // 
            // panelEx34
            // 
            this.panelEx34.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx34.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx34.Controls.Add(this.panel34);
            this.panelEx34.Controls.Add(this.EditUserPanel);
            this.panelEx34.Controls.Add(this.panelEx27);
            this.panelEx34.Controls.Add(this.panelEx21);
            this.panelEx34.Controls.Add(this.panel28);
            this.panelEx34.Controls.Add(this.panelEx22);
            this.panelEx34.Controls.Add(this.panelEx23);
            this.panelEx34.Controls.Add(this.panel32);
            this.panelEx34.Controls.Add(this.panelEx24);
            this.panelEx34.Controls.Add(this.buttonX22);
            this.panelEx34.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx34.Location = new System.Drawing.Point(14, 14);
            this.panelEx34.Name = "panelEx34";
            this.panelEx34.Size = new System.Drawing.Size(669, 357);
            this.panelEx34.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx34.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx34.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx34.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx34.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx34.Style.GradientAngle = 90;
            this.panelEx34.TabIndex = 0;
            // 
            // panel34
            // 
            this.panel34.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel34.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel34.Controls.Add(this.label60);
            this.panel34.Controls.Add(this.textBox5);
            this.panel34.Controls.Add(this.button11);
            this.panel34.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel34.Location = new System.Drawing.Point(444, 47);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(211, 74);
            this.panel34.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel34.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel34.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel34.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel34.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel34.Style.GradientAngle = 90;
            this.panel34.TabIndex = 10;
            // 
            // button11
            // 
            this.button11.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button11.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button11.Location = new System.Drawing.Point(79, 38);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(117, 23);
            this.button11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button11.TabIndex = 18;
            this.button11.Text = "Edit";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // EditUserPanel
            // 
            this.EditUserPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditUserPanel.Controls.Add(this.label61);
            this.EditUserPanel.Controls.Add(this.button14);
            this.EditUserPanel.Controls.Add(this.button13);
            this.EditUserPanel.Controls.Add(this.textBox12);
            this.EditUserPanel.Controls.Add(this.label64);
            this.EditUserPanel.Controls.Add(this.textBox6);
            this.EditUserPanel.Controls.Add(this.textBox7);
            this.EditUserPanel.Controls.Add(this.label67);
            this.EditUserPanel.Controls.Add(this.textBox8);
            this.EditUserPanel.Controls.Add(this.label68);
            this.EditUserPanel.Controls.Add(this.label63);
            this.EditUserPanel.Controls.Add(this.textBox9);
            this.EditUserPanel.Controls.Add(this.label65);
            this.EditUserPanel.Controls.Add(this.textBox13);
            this.EditUserPanel.Location = new System.Drawing.Point(444, 125);
            this.EditUserPanel.Name = "EditUserPanel";
            this.EditUserPanel.Size = new System.Drawing.Size(211, 215);
            this.EditUserPanel.SlideOutButtonVisible = false;
            this.EditUserPanel.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Bottom;
            this.EditUserPanel.TabIndex = 46;
            this.EditUserPanel.Text = "slidePanel1";
            this.EditUserPanel.UsesBlockingAnimation = false;
            // 
            // button14
            // 
            this.button14.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button14.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button14.Location = new System.Drawing.Point(124, 175);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(72, 27);
            this.button14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button14.TabIndex = 29;
            this.button14.Text = "Cancel";
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button13.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button13.Location = new System.Drawing.Point(13, 175);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(102, 27);
            this.button13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button13.TabIndex = 28;
            this.button13.Text = "Save changes";
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // panelEx27
            // 
            this.panelEx27.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx27.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx27.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx27.Location = new System.Drawing.Point(444, 15);
            this.panelEx27.Name = "panelEx27";
            this.panelEx27.Size = new System.Drawing.Size(127, 30);
            this.panelEx27.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx27.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx27.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx27.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx27.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx27.Style.GradientAngle = 90;
            this.panelEx27.TabIndex = 9;
            this.panelEx27.Text = "Edit user information";
            // 
            // panelEx21
            // 
            this.panelEx21.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx21.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx21.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx21.Location = new System.Drawing.Point(15, 15);
            this.panelEx21.Name = "panelEx21";
            this.panelEx21.Size = new System.Drawing.Size(116, 30);
            this.panelEx21.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx21.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx21.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx21.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx21.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx21.Style.GradientAngle = 90;
            this.panelEx21.TabIndex = 1;
            this.panelEx21.Text = "Create a new user";
            // 
            // panel28
            // 
            this.panel28.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel28.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel28.Controls.Add(this.panelEx25);
            this.panel28.Controls.Add(this.textBox3);
            this.panel28.Controls.Add(this.label27);
            this.panel28.Controls.Add(this.button9);
            this.panel28.Controls.Add(this.button10);
            this.panel28.Controls.Add(this.dateTimePicker2);
            this.panel28.Controls.Add(this.label55);
            this.panel28.Controls.Add(this.label56);
            this.panel28.Controls.Add(this.dateTimePicker1);
            this.panel28.Controls.Add(this.textBox4);
            this.panel28.Controls.Add(this.label54);
            this.panel28.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel28.Location = new System.Drawing.Point(227, 47);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(211, 225);
            this.panel28.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel28.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel28.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel28.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel28.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel28.Style.GradientAngle = 90;
            this.panel28.TabIndex = 7;
            // 
            // panelEx25
            // 
            this.panelEx25.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx25.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx25.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx25.Location = new System.Drawing.Point(-2, 140);
            this.panelEx25.Name = "panelEx25";
            this.panelEx25.Size = new System.Drawing.Size(215, 1);
            this.panelEx25.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx25.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx25.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx25.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx25.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx25.Style.GradientAngle = 90;
            this.panelEx25.TabIndex = 21;
            // 
            // button9
            // 
            this.button9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button9.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button9.Location = new System.Drawing.Point(13, 102);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(183, 27);
            this.button9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button9.TabIndex = 15;
            this.button9.Text = "Register Punishment";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button10.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button10.Location = new System.Drawing.Point(13, 182);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(183, 29);
            this.button10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button10.TabIndex = 17;
            this.button10.Text = "Remove Punishment";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // panelEx22
            // 
            this.panelEx22.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx22.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx22.Controls.Add(this.label50);
            this.panelEx22.Controls.Add(this.textBox2);
            this.panelEx22.Controls.Add(this.textBox1);
            this.panelEx22.Controls.Add(this.label52);
            this.panelEx22.Controls.Add(this.button8);
            this.panelEx22.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx22.Location = new System.Drawing.Point(15, 47);
            this.panelEx22.Name = "panelEx22";
            this.panelEx22.Size = new System.Drawing.Size(206, 111);
            this.panelEx22.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx22.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx22.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx22.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx22.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx22.Style.GradientAngle = 90;
            this.panelEx22.TabIndex = 2;
            // 
            // button8
            // 
            this.button8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button8.Location = new System.Drawing.Point(11, 67);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(183, 31);
            this.button8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button8.TabIndex = 7;
            this.button8.Text = "Create";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // panelEx23
            // 
            this.panelEx23.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx23.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx23.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx23.Location = new System.Drawing.Point(15, 164);
            this.panelEx23.Name = "panelEx23";
            this.panelEx23.Size = new System.Drawing.Size(176, 30);
            this.panelEx23.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx23.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx23.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx23.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx23.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx23.Style.GradientAngle = 90;
            this.panelEx23.TabIndex = 3;
            this.panelEx23.Text = "Get user current hash password";
            // 
            // panel32
            // 
            this.panel32.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel32.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel32.Controls.Add(this.textBox11);
            this.panel32.Controls.Add(this.label66);
            this.panel32.Controls.Add(this.button15);
            this.panel32.Controls.Add(this.button12);
            this.panel32.Controls.Add(this.textBox10);
            this.panel32.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel32.Location = new System.Drawing.Point(15, 196);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(206, 144);
            this.panel32.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel32.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel32.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel32.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel32.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel32.Style.GradientAngle = 90;
            this.panel32.TabIndex = 4;
            // 
            // button15
            // 
            this.button15.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button15.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button15.Location = new System.Drawing.Point(122, 42);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(72, 27);
            this.button15.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button15.TabIndex = 11;
            this.button15.Text = "Reset";
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button12
            // 
            this.button12.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button12.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button12.Location = new System.Drawing.Point(11, 43);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(105, 26);
            this.button12.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button12.TabIndex = 10;
            this.button12.Text = "Select Password";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // panelEx24
            // 
            this.panelEx24.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx24.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx24.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx24.Location = new System.Drawing.Point(227, 15);
            this.panelEx24.Name = "panelEx24";
            this.panelEx24.Size = new System.Drawing.Size(211, 30);
            this.panelEx24.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx24.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx24.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx24.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx24.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx24.Style.GradientAngle = 90;
            this.panelEx24.TabIndex = 5;
            this.panelEx24.Text = "Register - Remove [User Punishment]";
            // 
            // buttonX22
            // 
            this.buttonX22.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX22.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX22.Location = new System.Drawing.Point(240, 290);
            this.buttonX22.Name = "buttonX22";
            this.buttonX22.Size = new System.Drawing.Size(183, 35);
            this.buttonX22.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX22.TabIndex = 45;
            this.buttonX22.Text = "Back";
            this.buttonX22.Click += new System.EventHandler(this.buttonX22_Click);
            // 
            // SilkControlPanel
            // 
            this.SilkControlPanel.Controls.Add(this.panelEx35);
            this.SilkControlPanel.Location = new System.Drawing.Point(8, 8);
            this.SilkControlPanel.Name = "SilkControlPanel";
            this.SilkControlPanel.Size = new System.Drawing.Size(696, 384);
            this.SilkControlPanel.SlideOutButtonVisible = false;
            this.SilkControlPanel.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Bottom;
            this.SilkControlPanel.TabIndex = 8;
            this.SilkControlPanel.Text = "slidePanel1";
            this.SilkControlPanel.UsesBlockingAnimation = false;
            // 
            // panelEx35
            // 
            this.panelEx35.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx35.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx35.Controls.Add(this.buttonX23);
            this.panelEx35.Controls.Add(this.panelEx20);
            this.panelEx35.Controls.Add(this.panelEx19);
            this.panelEx35.Controls.Add(this.panel39);
            this.panelEx35.Controls.Add(this.panel36);
            this.panelEx35.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx35.Location = new System.Drawing.Point(14, 14);
            this.panelEx35.Name = "panelEx35";
            this.panelEx35.Size = new System.Drawing.Size(668, 357);
            this.panelEx35.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx35.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx35.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx35.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx35.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx35.Style.GradientAngle = 90;
            this.panelEx35.TabIndex = 0;
            // 
            // buttonX23
            // 
            this.buttonX23.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX23.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX23.Location = new System.Drawing.Point(552, 16);
            this.buttonX23.Name = "buttonX23";
            this.buttonX23.Size = new System.Drawing.Size(103, 26);
            this.buttonX23.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX23.TabIndex = 18;
            this.buttonX23.Text = "Back";
            this.buttonX23.Click += new System.EventHandler(this.buttonX23_Click);
            // 
            // panelEx20
            // 
            this.panelEx20.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx20.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx20.Controls.Add(this.label57);
            this.panelEx20.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx20.Location = new System.Drawing.Point(319, 15);
            this.panelEx20.Name = "panelEx20";
            this.panelEx20.Size = new System.Drawing.Size(117, 28);
            this.panelEx20.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx20.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx20.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx20.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx20.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx20.Style.GradientAngle = 90;
            this.panelEx20.TabIndex = 1;
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.Transparent;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.Color.Black;
            this.label57.Location = new System.Drawing.Point(10, 6);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(98, 17);
            this.label57.TabIndex = 0;
            this.label57.Text = "Users silk list";
            // 
            // panelEx19
            // 
            this.panelEx19.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx19.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx19.Controls.Add(this.label45);
            this.panelEx19.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx19.Location = new System.Drawing.Point(15, 15);
            this.panelEx19.Name = "panelEx19";
            this.panelEx19.Size = new System.Drawing.Size(155, 28);
            this.panelEx19.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx19.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx19.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx19.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx19.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx19.Style.GradientAngle = 90;
            this.panelEx19.TabIndex = 1;
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.Black;
            this.label45.Location = new System.Drawing.Point(10, 6);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(136, 17);
            this.label45.TabIndex = 0;
            this.label45.Text = "Manage users silks";
            // 
            // panel39
            // 
            this.panel39.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel39.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel39.Controls.Add(this.panel40);
            this.panel39.Controls.Add(this.listView2);
            this.panel39.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel39.Location = new System.Drawing.Point(319, 49);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(335, 294);
            this.panel39.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel39.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel39.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel39.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel39.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel39.Style.GradientAngle = 90;
            this.panel39.TabIndex = 2;
            // 
            // panel40
            // 
            this.panel40.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel40.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel40.Controls.Add(this.label71);
            this.panel40.Controls.Add(this.point1);
            this.panel40.Controls.Add(this.own1);
            this.panel40.Controls.Add(this.gift1);
            this.panel40.Controls.Add(this.button19);
            this.panel40.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel40.Location = new System.Drawing.Point(12, 17);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(311, 55);
            this.panel40.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel40.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel40.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel40.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel40.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel40.Style.GradientAngle = 90;
            this.panel40.TabIndex = 4;
            // 
            // button19
            // 
            this.button19.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button19.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button19.Location = new System.Drawing.Point(221, 23);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(79, 23);
            this.button19.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button19.TabIndex = 4;
            this.button19.Text = "Search";
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // panel36
            // 
            this.panel36.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel36.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel36.Controls.Add(this.panel43);
            this.panel36.Controls.Add(this.panel38);
            this.panel36.Controls.Add(this.label70);
            this.panel36.Controls.Add(this.label69);
            this.panel36.Controls.Add(this.textBox15);
            this.panel36.Controls.Add(this.textBox14);
            this.panel36.Controls.Add(this.panel42);
            this.panel36.Controls.Add(this.button16);
            this.panel36.Controls.Add(this.button17);
            this.panel36.Controls.Add(this.button20);
            this.panel36.Controls.Add(this.button18);
            this.panel36.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel36.Location = new System.Drawing.Point(15, 49);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(296, 294);
            this.panel36.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel36.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel36.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel36.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel36.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel36.Style.GradientAngle = 90;
            this.panel36.TabIndex = 3;
            // 
            // panel43
            // 
            this.panel43.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel43.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel43.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel43.Location = new System.Drawing.Point(0, 188);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(198, 26);
            this.panel43.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel43.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel43.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel43.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel43.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel43.Style.GradientAngle = 90;
            this.panel43.TabIndex = 9;
            this.panel43.Text = "Subtract silks from users";
            // 
            // panel38
            // 
            this.panel38.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel38.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel38.Controls.Add(this.point);
            this.panel38.Controls.Add(this.own);
            this.panel38.Controls.Add(this.gift);
            this.panel38.Controls.Add(this.label75);
            this.panel38.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel38.Location = new System.Drawing.Point(214, 18);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(82, 104);
            this.panel38.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel38.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel38.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel38.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel38.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel38.Style.GradientAngle = 90;
            this.panel38.TabIndex = 7;
            // 
            // panel42
            // 
            this.panel42.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel42.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel42.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel42.Location = new System.Drawing.Point(0, 81);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(198, 26);
            this.panel42.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel42.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel42.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel42.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel42.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel42.Style.GradientAngle = 90;
            this.panel42.TabIndex = 8;
            this.panel42.Text = "Add silks for users";
            // 
            // button16
            // 
            this.button16.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button16.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button16.Location = new System.Drawing.Point(17, 116);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(179, 24);
            this.button16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button16.TabIndex = 10;
            this.button16.Text = "Add amount for username";
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button17.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button17.Location = new System.Drawing.Point(17, 149);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(179, 24);
            this.button17.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button17.TabIndex = 10;
            this.button17.Text = "Add amount for all users";
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button20
            // 
            this.button20.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button20.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button20.Location = new System.Drawing.Point(17, 222);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(179, 24);
            this.button20.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button20.TabIndex = 10;
            this.button20.Text = "Subtract amount from username";
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button18
            // 
            this.button18.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button18.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button18.Location = new System.Drawing.Point(17, 254);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(179, 24);
            this.button18.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button18.TabIndex = 10;
            this.button18.Text = "Subtract amount from all users";
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // UserCharPanel
            // 
            this.UserCharPanel.Controls.Add(this.panelEx36);
            this.UserCharPanel.Location = new System.Drawing.Point(8, 8);
            this.UserCharPanel.Name = "UserCharPanel";
            this.UserCharPanel.Size = new System.Drawing.Size(696, 384);
            this.UserCharPanel.SlideOutButtonVisible = false;
            this.UserCharPanel.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Bottom;
            this.UserCharPanel.TabIndex = 9;
            this.UserCharPanel.Text = "slidePanel1";
            this.UserCharPanel.UsesBlockingAnimation = false;
            // 
            // panelEx36
            // 
            this.panelEx36.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx36.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx36.Controls.Add(this.panel44);
            this.panelEx36.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx36.Location = new System.Drawing.Point(14, 14);
            this.panelEx36.Name = "panelEx36";
            this.panelEx36.Size = new System.Drawing.Size(669, 357);
            this.panelEx36.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx36.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx36.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx36.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx36.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx36.Style.GradientAngle = 90;
            this.panelEx36.TabIndex = 0;
            // 
            // panel44
            // 
            this.panel44.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel44.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel44.Controls.Add(this.panel6);
            this.panel44.Controls.Add(this.panel45);
            this.panel44.Controls.Add(this.panelEx18);
            this.panel44.Controls.Add(this.panel47);
            this.panel44.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel44.Location = new System.Drawing.Point(15, 15);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(640, 328);
            this.panel44.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel44.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel44.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel44.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel44.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel44.Style.GradientAngle = 90;
            this.panel44.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.button22);
            this.panel6.Controls.Add(this.comboBox1);
            this.panel6.Controls.Add(this.label78);
            this.panel6.Location = new System.Drawing.Point(12, 158);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(195, 76);
            this.panel6.SlideOutButtonVisible = false;
            this.panel6.TabIndex = 36;
            this.panel6.Text = "slidePanel1";
            this.panel6.UsesBlockingAnimation = false;
            // 
            // button22
            // 
            this.button22.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button22.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button22.Location = new System.Drawing.Point(11, 41);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(172, 23);
            this.button22.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button22.TabIndex = 11;
            this.button22.Text = "Another Search";
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.Color.Black;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 14;
            this.comboBox1.Location = new System.Drawing.Point(58, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 20);
            this.comboBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel45
            // 
            this.panel45.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel45.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel45.Controls.Add(this.textBox16);
            this.panel45.Controls.Add(this.label74);
            this.panel45.Controls.Add(this.button21);
            this.panel45.Controls.Add(this.buttonX24);
            this.panel45.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel45.Location = new System.Drawing.Point(12, 44);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(195, 104);
            this.panel45.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel45.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel45.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel45.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel45.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel45.Style.GradientAngle = 90;
            this.panel45.TabIndex = 9;
            // 
            // button21
            // 
            this.button21.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button21.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button21.Location = new System.Drawing.Point(11, 41);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(172, 23);
            this.button21.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button21.TabIndex = 10;
            this.button21.Text = "Search";
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // buttonX24
            // 
            this.buttonX24.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX24.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX24.Location = new System.Drawing.Point(11, 70);
            this.buttonX24.Name = "buttonX24";
            this.buttonX24.Size = new System.Drawing.Size(172, 23);
            this.buttonX24.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX24.TabIndex = 23;
            this.buttonX24.Text = "Back";
            this.buttonX24.Click += new System.EventHandler(this.buttonX24_Click);
            // 
            // panelEx18
            // 
            this.panelEx18.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx18.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx18.Controls.Add(this.label44);
            this.panelEx18.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx18.Location = new System.Drawing.Point(11, 10);
            this.panelEx18.Name = "panelEx18";
            this.panelEx18.Size = new System.Drawing.Size(282, 28);
            this.panelEx18.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx18.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx18.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx18.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx18.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx18.Style.GradientAngle = 90;
            this.panelEx18.TabIndex = 7;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(10, 6);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(263, 17);
            this.label44.TabIndex = 7;
            this.label44.Text = "Showing all the characters in the user";
            // 
            // panel47
            // 
            this.panel47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel47.Controls.Add(this.pictureBox3);
            this.panel47.Controls.Add(this.CharName16);
            this.panel47.Controls.Add(this.panel50);
            this.panel47.Controls.Add(this.panel48);
            this.panel47.Controls.Add(this.panel49);
            this.panel47.Controls.Add(this.panel54);
            this.panel47.Controls.Add(this.panel51);
            this.panel47.Controls.Add(this.panel53);
            this.panel47.Controls.Add(this.panel52);
            this.panel47.Location = new System.Drawing.Point(220, 44);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(405, 269);
            this.panel47.SlideOutButtonVisible = false;
            this.panel47.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Right;
            this.panel47.TabIndex = 46;
            this.panel47.Text = "slidePanel1";
            this.panel47.UsesBlockingAnimation = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Location = new System.Drawing.Point(235, 53);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(151, 205);
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // CharName16
            // 
            this.CharName16.CanvasColor = System.Drawing.SystemColors.Control;
            this.CharName16.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CharName16.DisabledBackColor = System.Drawing.Color.Empty;
            this.CharName16.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.CharName16.Location = new System.Drawing.Point(235, 15);
            this.CharName16.Name = "CharName16";
            this.CharName16.Size = new System.Drawing.Size(151, 27);
            this.CharName16.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.CharName16.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.CharName16.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.CharName16.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.CharName16.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.CharName16.Style.GradientAngle = 90;
            this.CharName16.TabIndex = 11;
            // 
            // panel50
            // 
            this.panel50.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel50.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel50.Controls.Add(this.CharID);
            this.panel50.Controls.Add(this.label80);
            this.panel50.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel50.Location = new System.Drawing.Point(20, 10);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(195, 32);
            this.panel50.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel50.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel50.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel50.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel50.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel50.Style.GradientAngle = 90;
            this.panel50.TabIndex = 8;
            // 
            // panel48
            // 
            this.panel48.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel48.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel48.Controls.Add(this.label85);
            this.panel48.Controls.Add(this.CharGold);
            this.panel48.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel48.Location = new System.Drawing.Point(20, 226);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(195, 32);
            this.panel48.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel48.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel48.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel48.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel48.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel48.Style.GradientAngle = 90;
            this.panel48.TabIndex = 8;
            // 
            // panel49
            // 
            this.panel49.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel49.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel49.Controls.Add(this.NickName16);
            this.panel49.Controls.Add(this.label79);
            this.panel49.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel49.Location = new System.Drawing.Point(20, 46);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(195, 32);
            this.panel49.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel49.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel49.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel49.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel49.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel49.Style.GradientAngle = 90;
            this.panel49.TabIndex = 8;
            // 
            // panel54
            // 
            this.panel54.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel54.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel54.Controls.Add(this.label84);
            this.panel54.Controls.Add(this.CharInt);
            this.panel54.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel54.Location = new System.Drawing.Point(20, 190);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(195, 32);
            this.panel54.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel54.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel54.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel54.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel54.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel54.Style.GradientAngle = 90;
            this.panel54.TabIndex = 8;
            // 
            // panel51
            // 
            this.panel51.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel51.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel51.Controls.Add(this.label81);
            this.panel51.Controls.Add(this.GuildName);
            this.panel51.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel51.Location = new System.Drawing.Point(20, 82);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(195, 32);
            this.panel51.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel51.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel51.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel51.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel51.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel51.Style.GradientAngle = 90;
            this.panel51.TabIndex = 8;
            // 
            // panel53
            // 
            this.panel53.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel53.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel53.Controls.Add(this.label83);
            this.panel53.Controls.Add(this.CharStr);
            this.panel53.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel53.Location = new System.Drawing.Point(20, 154);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(195, 32);
            this.panel53.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel53.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel53.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel53.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel53.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel53.Style.GradientAngle = 90;
            this.panel53.TabIndex = 8;
            // 
            // panel52
            // 
            this.panel52.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel52.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel52.Controls.Add(this.label82);
            this.panel52.Controls.Add(this.CurrLevel);
            this.panel52.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel52.Location = new System.Drawing.Point(20, 118);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(195, 32);
            this.panel52.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel52.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel52.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel52.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel52.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel52.Style.GradientAngle = 90;
            this.panel52.TabIndex = 8;
            // 
            // TeamUserPanel
            // 
            this.TeamUserPanel.Controls.Add(this.panelEx37);
            this.TeamUserPanel.Location = new System.Drawing.Point(8, 8);
            this.TeamUserPanel.Name = "TeamUserPanel";
            this.TeamUserPanel.Size = new System.Drawing.Size(696, 384);
            this.TeamUserPanel.SlideOutButtonVisible = false;
            this.TeamUserPanel.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Bottom;
            this.TeamUserPanel.TabIndex = 10;
            this.TeamUserPanel.Text = "slidePanel1";
            this.TeamUserPanel.UsesBlockingAnimation = false;
            // 
            // panelEx37
            // 
            this.panelEx37.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx37.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx37.Controls.Add(this.panelEx17);
            this.panelEx37.Controls.Add(this.panelEx16);
            this.panelEx37.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx37.Location = new System.Drawing.Point(14, 14);
            this.panelEx37.Name = "panelEx37";
            this.panelEx37.Size = new System.Drawing.Size(669, 357);
            this.panelEx37.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx37.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx37.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx37.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx37.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx37.Style.GradientAngle = 90;
            this.panelEx37.TabIndex = 0;
            // 
            // panelEx17
            // 
            this.panelEx17.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx17.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx17.Controls.Add(this.buttonX25);
            this.panelEx17.Controls.Add(this.label86);
            this.panelEx17.Controls.Add(this.listView3);
            this.panelEx17.Controls.Add(this.textBox17);
            this.panelEx17.Controls.Add(this.textBox18);
            this.panelEx17.Controls.Add(this.label87);
            this.panelEx17.Controls.Add(this.button24);
            this.panelEx17.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx17.Location = new System.Drawing.Point(15, 49);
            this.panelEx17.Name = "panelEx17";
            this.panelEx17.Size = new System.Drawing.Size(420, 294);
            this.panelEx17.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx17.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx17.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx17.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx17.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx17.Style.GradientAngle = 90;
            this.panelEx17.TabIndex = 7;
            // 
            // buttonX25
            // 
            this.buttonX25.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX25.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX25.Location = new System.Drawing.Point(310, 22);
            this.buttonX25.Name = "buttonX25";
            this.buttonX25.Size = new System.Drawing.Size(90, 36);
            this.buttonX25.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX25.TabIndex = 14;
            this.buttonX25.Text = "Back";
            this.buttonX25.Click += new System.EventHandler(this.buttonX25_Click);
            // 
            // button24
            // 
            this.button24.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button24.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button24.Location = new System.Drawing.Point(205, 22);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(90, 36);
            this.button24.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button24.TabIndex = 8;
            this.button24.Text = "Search";
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // panelEx16
            // 
            this.panelEx16.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx16.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx16.Controls.Add(this.label43);
            this.panelEx16.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx16.Location = new System.Drawing.Point(15, 16);
            this.panelEx16.Name = "panelEx16";
            this.panelEx16.Size = new System.Drawing.Size(231, 28);
            this.panelEx16.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx16.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx16.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx16.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx16.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx16.Style.GradientAngle = 90;
            this.panelEx16.TabIndex = 6;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(10, 6);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(212, 17);
            this.label43.TabIndex = 7;
            this.label43.Text = "Showing all existing GM users";
            // 
            // UserPanel
            // 
            this.UserPanel.Controls.Add(this.panelEx33);
            this.UserPanel.Location = new System.Drawing.Point(8, 8);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(696, 384);
            this.UserPanel.SlideOutButtonVisible = false;
            this.UserPanel.TabIndex = 6;
            this.UserPanel.Text = "slidePanel1";
            this.UserPanel.UsesBlockingAnimation = false;
            // 
            // panelEx33
            // 
            this.panelEx33.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx33.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx33.Controls.Add(this.buttonX17);
            this.panelEx33.Controls.Add(this.buttonX21);
            this.panelEx33.Controls.Add(this.buttonX18);
            this.panelEx33.Controls.Add(this.buttonX19);
            this.panelEx33.Controls.Add(this.buttonX20);
            this.panelEx33.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx33.Location = new System.Drawing.Point(14, 14);
            this.panelEx33.Name = "panelEx33";
            this.panelEx33.Size = new System.Drawing.Size(669, 357);
            this.panelEx33.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx33.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx33.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx33.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx33.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx33.Style.GradientAngle = 90;
            this.panelEx33.TabIndex = 0;
            // 
            // buttonX17
            // 
            this.buttonX17.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX17.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX17.Location = new System.Drawing.Point(31, 179);
            this.buttonX17.Name = "buttonX17";
            this.buttonX17.Size = new System.Drawing.Size(128, 31);
            this.buttonX17.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX17.TabIndex = 1;
            this.buttonX17.Text = "Back";
            this.buttonX17.Click += new System.EventHandler(this.buttonX17_Click);
            // 
            // buttonX21
            // 
            this.buttonX21.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX21.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX21.Image = global:: MangerSroApp.Properties.Resource1.usertype;
            this.buttonX21.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX21.Location = new System.Drawing.Point(433, 30);
            this.buttonX21.Name = "buttonX21";
            this.buttonX21.Size = new System.Drawing.Size(128, 126);
            this.buttonX21.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX21.TabIndex = 0;
            this.buttonX21.Text = "Team Users";
            this.buttonX21.Click += new System.EventHandler(this.buttonX21_Click);
            // 
            // buttonX18
            // 
            this.buttonX18.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX18.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX18.Image = global:: MangerSroApp.Properties.Resource1.logo_login2;
            this.buttonX18.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX18.Location = new System.Drawing.Point(299, 30);
            this.buttonX18.Name = "buttonX18";
            this.buttonX18.Size = new System.Drawing.Size(128, 127);
            this.buttonX18.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX18.TabIndex = 0;
            this.buttonX18.Text = "User Characters";
            this.buttonX18.Click += new System.EventHandler(this.buttonX18_Click);
            // 
            // buttonX19
            // 
            this.buttonX19.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX19.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX19.Image = global:: MangerSroApp.Properties.Resource1.zolotie_monetki;
            this.buttonX19.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX19.Location = new System.Drawing.Point(165, 30);
            this.buttonX19.Name = "buttonX19";
            this.buttonX19.Size = new System.Drawing.Size(128, 126);
            this.buttonX19.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX19.TabIndex = 0;
            this.buttonX19.Text = "Silk Control";
            this.buttonX19.Click += new System.EventHandler(this.buttonX19_Click);
            // 
            // buttonX20
            // 
            this.buttonX20.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX20.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX20.Image = global:: MangerSroApp.Properties.Resource1.sign_up;
            this.buttonX20.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonX20.Location = new System.Drawing.Point(31, 30);
            this.buttonX20.Name = "buttonX20";
            this.buttonX20.Size = new System.Drawing.Size(128, 126);
            this.buttonX20.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX20.TabIndex = 0;
            this.buttonX20.Text = "Manage User";
            this.buttonX20.Click += new System.EventHandler(this.buttonX20_Click);
            // 
            // NextUpdatePanel
            // 
            this.NextUpdatePanel.Controls.Add(this.panelEx26);
            this.NextUpdatePanel.Location = new System.Drawing.Point(8, 8);
            this.NextUpdatePanel.Name = "NextUpdatePanel";
            this.NextUpdatePanel.Size = new System.Drawing.Size(696, 384);
            this.NextUpdatePanel.SlideOutButtonVisible = false;
            this.NextUpdatePanel.TabIndex = 11;
            this.NextUpdatePanel.Text = "slidePanel1";
            this.NextUpdatePanel.UsesBlockingAnimation = false;
            // 
            // panelEx26
            // 
            this.panelEx26.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx26.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx26.Controls.Add(this.buttonX26);
            this.panelEx26.Controls.Add(this.label14);
            this.panelEx26.Controls.Add(this.label13);
            this.panelEx26.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx26.Location = new System.Drawing.Point(14, 14);
            this.panelEx26.Name = "panelEx26";
            this.panelEx26.Size = new System.Drawing.Size(669, 357);
            this.panelEx26.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx26.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx26.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx26.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx26.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx26.Style.GradientAngle = 90;
            this.panelEx26.TabIndex = 0;
            // 
            // buttonX26
            // 
            this.buttonX26.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX26.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX26.Location = new System.Drawing.Point(293, 184);
            this.buttonX26.Name = "buttonX26";
            this.buttonX26.Size = new System.Drawing.Size(82, 30);
            this.buttonX26.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX26.TabIndex = 7;
            this.buttonX26.Text = "Back";
            this.buttonX26.Click += new System.EventHandler(this.buttonX26_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(123, 142);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(410, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "This tab doesn\'t added yet, You can suggest queries that you want to use by this " +
    "tool.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(153, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(353, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Leave your suggestions in the topic of this tool, next version will be added";
            // 
            // superTabItem21
            // 
            this.superTabItem21.AttachedControl = this.superTabControlPanel18;
            this.superTabItem21.GlobalItem = false;
            this.superTabItem21.Name = "superTabItem21";
            this.superTabItem21.Text = "Useful Queries";
            this.superTabItem21.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage2.Location = new System.Drawing.Point(142, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(711, 399);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.TabItem = this.superTabItem2;
            // 
            // panel1
            // 
            this.panel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 391);
            this.panel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panel1.Style.GradientAngle = 90;
            this.panel1.TabIndex = 0;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.tabPage2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.superTabItem2.Text = "Server Connection";
            this.superTabItem2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.superTabItem2.Visible = false;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77))))));
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Black;
            this.MainPanel.Controls.Add(this.player_label);
            this.MainPanel.Controls.Add(this.panel7);
            this.MainPanel.Controls.Add(this.server_label);
            this.MainPanel.Controls.Add(this.SaveConfig);
            this.MainPanel.Controls.Add(this.label16);
            this.MainPanel.Controls.Add(this.LoadConfig);
            this.MainPanel.Controls.Add(this.StartRelog);
            this.MainPanel.Controls.Add(this.listBox1);
            this.MainPanel.Controls.Add(this.HideTool);
            this.MainPanel.Controls.Add(this.tabControl1);
            this.MainPanel.ForeColor = System.Drawing.Color.White;
            this.MainPanel.Location = new System.Drawing.Point(6, 6);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(875, 686);
            this.MainPanel.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.MiniMize);
            this.panel7.Controls.Add(this.button5);
            this.panel7.Location = new System.Drawing.Point(690, 11);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(175, 65);
            this.panel7.TabIndex = 90;
            // 
            // StartRelog
            // 
            this.StartRelog.AutoSize = true;
            this.StartRelog.BackColor = System.Drawing.Color.Black;
            this.StartRelog.ForeColor = System.Drawing.Color.White;
            this.StartRelog.Location = new System.Drawing.Point(619, 630);
            this.StartRelog.Name = "StartRelog";
            this.StartRelog.Size = new System.Drawing.Size(79, 17);
            this.StartRelog.TabIndex = 0;
            this.StartRelog.Text = "Start Relog";
            this.StartRelog.UseVisualStyleBackColor = false;
            this.StartRelog.Visible = false;
            // 
            // HideTool
            // 
            this.HideTool.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.HideTool.BackColor = System.Drawing.Color.White;
            this.HideTool.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.HideTool.Location = new System.Drawing.Point(718, 611);
            this.HideTool.Name = "HideTool";
            this.HideTool.Size = new System.Drawing.Size(124, 39);
            this.HideTool.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.HideTool.TabIndex = 52;
            this.HideTool.Text = "Hide Tool";
            this.HideTool.Click += new System.EventHandler(this.HideTool_Click);
            // 
            // sideNavItem1
            // 
            this.sideNavItem1.Name = "sideNavItem1";
            this.sideNavItem1.PopupSide = DevComponents.DotNetBar.ePopupSide.Left;
            this.sideNavItem1.Symbol = "";
            this.sideNavItem1.SymbolColor = System.Drawing.Color.White;
            this.sideNavItem1.Text = "Menu";
            // 
            // separator1
            // 
            this.separator1.FixedSize = new System.Drawing.Size(3, 1);
            this.separator1.Name = "separator1";
            this.separator1.Padding.Bottom = 2;
            this.separator1.Padding.Left = 6;
            this.separator1.Padding.Right = 6;
            this.separator1.Padding.Top = 2;
            this.separator1.SeparatorOrientation = DevComponents.DotNetBar.eDesignMarkerOrientation.Vertical;
            // 
            // sideNavItem2
            // 
            this.sideNavItem2.Name = "sideNavItem2";
            this.sideNavItem2.SplitButton = true;
            this.sideNavItem2.Symbol = "";
            this.sideNavItem2.Text = "Sql Connection";
            // 
            // sideNavItem3
            // 
            this.sideNavItem3.Checked = true;
            this.sideNavItem3.Name = "sideNavItem3";
            this.sideNavItem3.Symbol = "58123";
            this.sideNavItem3.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.sideNavItem3.Text = "Server Connection";
            // 
            // sideNavItem4
            // 
            this.sideNavItem4.Name = "sideNavItem4";
            this.sideNavItem4.Symbol = "";
            this.sideNavItem4.Text = "System Services";
            // 
            // sideNavItem5
            // 
            this.sideNavItem5.Name = "sideNavItem5";
            this.sideNavItem5.Symbol = "59480";
            this.sideNavItem5.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.sideNavItem5.Text = "sideNavItem5";
            // 
            // sideNavItem6
            // 
            this.sideNavItem6.Name = "sideNavItem6";
            this.sideNavItem6.Symbol = "";
            this.sideNavItem6.Text = "Useful Queries";
            // 
            // sideNavItem7
            // 
            this.sideNavItem7.Name = "sideNavItem7";
            this.sideNavItem7.Symbol = "";
            this.sideNavItem7.Text = "Menu";
            // 
            // separator2
            // 
            this.separator2.FixedSize = new System.Drawing.Size(3, 1);
            this.separator2.Name = "separator2";
            this.separator2.Padding.Bottom = 2;
            this.separator2.Padding.Left = 6;
            this.separator2.Padding.Right = 6;
            this.separator2.Padding.Top = 2;
            this.separator2.SeparatorOrientation = DevComponents.DotNetBar.eDesignMarkerOrientation.Vertical;
            // 
            // sideNavItem8
            // 
            this.sideNavItem8.Name = "sideNavItem8";
            this.sideNavItem8.Symbol = "";
            this.sideNavItem8.Text = "Sql Connection";
            // 
            // sideNavItem9
            // 
            this.sideNavItem9.Name = "sideNavItem9";
            this.sideNavItem9.Symbol = "58144";
            this.sideNavItem9.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.sideNavItem9.Text = "Server Connection";
            // 
            // sideNavItem10
            // 
            this.sideNavItem10.Name = "sideNavItem10";
            this.sideNavItem10.Symbol = "";
            this.sideNavItem10.Text = "System Services";
            // 
            // sideNavItem11
            // 
            this.sideNavItem11.Checked = true;
            this.sideNavItem11.Name = "sideNavItem11";
            this.sideNavItem11.Symbol = "57745";
            this.sideNavItem11.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.sideNavItem11.Text = "Execute Schedule";
            // 
            // sideNavItem12
            // 
            this.sideNavItem12.Name = "sideNavItem12";
            this.sideNavItem12.Symbol = "";
            this.sideNavItem12.Text = "Useful Queries";
            // 
            // Status
            // 
            this.Status.BackColor = System.Drawing.Color.Red;
            this.Status.Location = new System.Drawing.Point(2, 2);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(883, 693);
            this.Status.TabIndex = 88;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.MainPanel);
            this.panel5.Controls.Add(this.Status);
            this.panel5.Location = new System.Drawing.Point(-2, -2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(889, 699);
            this.panel5.TabIndex = 88;
            // 
            // timer8
            // 
            this.timer8.Tick += new System.EventHandler(this.timer8_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.ClientSize = new System.Drawing.Size(888, 695);
            this.Controls.Add(this.panel5);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vSro Multi Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelEx14.ResumeLayout(false);
            this.panel69.ResumeLayout(false);
            this.panel69.PerformLayout();
            this.panel67.ResumeLayout(false);
            this.panel67.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panelEx38.ResumeLayout(false);
            this.panelEx38.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.PLSQLRange.ResumeLayout(false);
            this.PLSQLRange.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicCharSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.superTabControlPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.superTabControlPanel18.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.MainFun.ResumeLayout(false);
            this.ManageCharPanel.ResumeLayout(false);
            this.panel57.ResumeLayout(false);
            this.panel57.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.CollectBookPanel.ResumeLayout(false);
            this.panelEx31.ResumeLayout(false);
            this.panel60.ResumeLayout(false);
            this.panel61.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel63.ResumeLayout(false);
            this.panel63.PerformLayout();
            this.panel62.ResumeLayout(false);
            this.panel62.PerformLayout();
            this.CharInvPanel.ResumeLayout(false);
            this.panelEx32.ResumeLayout(false);
            this.panelEx32.PerformLayout();
            this.CharacterPanel.ResumeLayout(false);
            this.panelEx29.ResumeLayout(false);
            this.ManageUserPanel.ResumeLayout(false);
            this.panelEx34.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel34.PerformLayout();
            this.EditUserPanel.ResumeLayout(false);
            this.EditUserPanel.PerformLayout();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.panelEx22.ResumeLayout(false);
            this.panelEx22.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.SilkControlPanel.ResumeLayout(false);
            this.panelEx35.ResumeLayout(false);
            this.panelEx20.ResumeLayout(false);
            this.panelEx19.ResumeLayout(false);
            this.panel39.ResumeLayout(false);
            this.panel40.ResumeLayout(false);
            this.panel40.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panel38.ResumeLayout(false);
            this.panel38.PerformLayout();
            this.UserCharPanel.ResumeLayout(false);
            this.panelEx36.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel45.ResumeLayout(false);
            this.panel45.PerformLayout();
            this.panelEx18.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel50.ResumeLayout(false);
            this.panel50.PerformLayout();
            this.panel48.ResumeLayout(false);
            this.panel48.PerformLayout();
            this.panel49.ResumeLayout(false);
            this.panel49.PerformLayout();
            this.panel54.ResumeLayout(false);
            this.panel54.PerformLayout();
            this.panel51.ResumeLayout(false);
            this.panel51.PerformLayout();
            this.panel53.ResumeLayout(false);
            this.panel53.PerformLayout();
            this.panel52.ResumeLayout(false);
            this.panel52.PerformLayout();
            this.TeamUserPanel.ResumeLayout(false);
            this.panelEx37.ResumeLayout(false);
            this.panelEx17.ResumeLayout(false);
            this.panelEx17.PerformLayout();
            this.panelEx16.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            this.panelEx33.ResumeLayout(false);
            this.NextUpdatePanel.ResumeLayout(false);
            this.panelEx26.ResumeLayout(false);
            this.panelEx26.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }


    }
}