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
    public partial class App : Office2007Form
    {
        public App()
        {
            Application.AddMessageFilter(new GlobalMouseHandler());
            this.InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        // ping timer
        private void Ping_Tick(object sender, EventArgs e)
        {
            if (Globals.Server != Globals.ServerEnum.None)
            {
                Packet packet = new Packet(0x2002);
                if (Globals.Server == Globals.ServerEnum.Gateway)
                {
                    Gateway.SendToServer(packet);
                }
                else if (Globals.Server == Globals.ServerEnum.Agent)
                {
                    Agent.Send(packet);
                }
            }
        }

        // Close Button and close icon
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("[vSro Multi Tool] will close, Are you sure?", "vSro Multi Tool Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        // Minimize button
        private void MiniMize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        // read - write configuration
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string Directory);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string Directory);
        public string Read_ini(string Archive_ini, string Section, string Key)
        {
            StringBuilder stringBuilder = new StringBuilder(255);
            int privateProfileString = GetPrivateProfileString(Section, Key, "", stringBuilder, 255, this.Directory + "\\" + Archive_ini);
            return stringBuilder.ToString();
        }
        public void Write_ini(string Archive_ini, string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.Directory + "\\" + Archive_ini);
        }
        // Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            Globals.MainWindow = this; Ping.Enabled = true; this.tabControl2.Enabled = false;
            groupBox3.Enabled = false; panelEx38.Enabled = false; groupBox1.Enabled = false; this.panel2.Enabled = false;
            this.Meldung("vSro Multi Tool - by iLegend 2016.", new object[0]);
            this.Meldung("Tool started , connect to sql.", new object[0]);
            string service = null; this.HidePaneles();
            this.Host.Text = this.Read_ini("Config.ini", "SQL", "Host");
            //this.DB_Name.Text = this.Read_ini("Config.ini", "SQL", "Database");
            this.Shard.Text = this.Read_ini("Config.ini", "SQL", "Shard");
            this.Account.Text = this.Read_ini("Config.ini", "SQL", "Account");
            this.Shardlog.Text = this.Read_ini("Config.ini", "SQL", "ShardLog");
            this.HostUser.Text = this.Read_ini("Config.ini", "SQL", "HostUser");
            this.HostPw.Text = this.Read_ini("Config.ini", "SQL", "HostPw");
            this.ip.Text = this.Read_ini("Config.ini", "Server", "IP");
            this.gateport.Text = this.Read_ini("Config.ini", "Server", "Port");
            this.slocale.Text = this.Read_ini("Config.ini", "Server", "Locale");
            this.sversion.Text = this.Read_ini("Config.ini", "Server", "Version");
            this.id.Text = this.Read_ini("Config.ini", "Login", "AccountID");
            this.pw.Text = this.Read_ini("Config.ini", "Login", "AccountPW");
            this.captcha_text.Text = this.Read_ini("Config.ini", "Login", "CaptchaCode");
            this.char_list.Text = this.Read_ini("Config.ini", "Login", "CharName");
            service = this.Read_ini("Config.ini", "Login", "Xtrap");
            if (service == "ON") { this.checkBox1.Checked = true; } else { this.checkBox1.Checked = false; }
            service = this.Read_ini("Config.ini", "Login", "Relog");
            if (service == "ON") { this.Check_AutoRelog.Checked = true; } else { this.Check_AutoRelog.Checked = false; }
            // if (this.Check_AutoRelog.Checked == true) { this.timer1.Enabled = true; this.timer3.Enabled = true; }
            //this.slider1.Value = Convert.ToInt16(this.Read_ini("Config.ini", "Style", "Index"));
            //this.colorPickerButton1.SelectedColor = Color.FromArgb(Convert.ToInt16(this.Read_ini("Config.ini", "Style", "CanvasColor_R")), Convert.ToInt16(this.Read_ini("Config.ini", "Style", "CanvasColor_G")), Convert.ToInt16(this.Read_ini("Config.ini", "Style", "CanvasColor_B")));
            //this.colorPickerButton2.SelectedColor = Color.FromArgb(Convert.ToInt16(this.Read_ini("Config.ini", "Style", "BaseColor_R")), Convert.ToInt16(this.Read_ini("Config.ini", "Style", "BaseColor_G")), Convert.ToInt16(this.Read_ini("Config.ini", "Style", "BaseColor_B")));
        }
        // Tool Logs
        public void Meldung(string msg, params object[] values)
        {
            msg = string.Format(msg, values);
            this.listBox1.Items.Add("[" + System.DateTime.Now.ToLongTimeString() + "] " + msg);
            this.listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        // Execute creating database queries function
        private void QueryExecute(string query)
        {
            try
            { new SqlCommand(query, sqlshardlog).ExecuteNonQuery(); }
            catch { Meldung("Error while executing query [Form1].", new object[0]); }
        }

        // Connect to server :
        //--------------------
        // Buttons functions
        private void SQLConnect_Click(object sender, EventArgs e)
        {
            sqlshardlog = new SqlConnection("Data Source=" + this.Host.Text + ";Initial Catalog=" + this.Shardlog.Text + ";Integrated Security=false; User ID = " + this.HostUser.Text + "; Password = " + this.HostPw.Text + ";MultipleActiveResultSets=true;");
            sqlshard = new SqlConnection("Data Source=" + this.Host.Text + ";Initial Catalog=" + this.Shard.Text + ";Integrated Security=false; User ID = " + this.HostUser.Text + "; Password = " + this.HostPw.Text + ";MultipleActiveResultSets=true;");
            sqlaccount = new SqlConnection("Data Source=" + this.Host.Text + ";Initial Catalog=" + this.Account.Text + ";Integrated Security=false; User ID = " + this.HostUser.Text + "; Password = " + this.HostPw.Text + ";MultipleActiveResultSets=true;");

            try
            {
                sqlshardlog.Open();
                this.Meldung("Database connected.", new object[0]);
                try
                {
                    sqlshard.Open();
                    this.Meldung("Sro Shard connected.", new object[0]);
                    try
                    {
                        sqlaccount.Open();
                        this.Meldung("Sro Account connected.", new object[0]);
                        try
                        {
                            //sqlshardlog.Open();
                            this.Meldung("Sro Shardlog connected.", new object[0]);
                            this.Meldung("Connect to server is available now.", new object[0]);
                            this.Meldung("Execute Schedule is ready to use.", new object[0]);
                            this.Meldung("Useful queries is ready to use.", new object[0]);
                            this.PLSQLRange.Enabled = false;
                            this.groupBox1.Enabled = true;
                            this.panel2.Enabled = true;
                            this.tabControl2.Enabled = true;
                            //new SqlCommand("Exec [dbo].[Form_Load]", sql).ExecuteNonQuery();
                            //if (this.Check_AutoRelog.Checked == true) { this.timer4.Enabled = true; }
                            this.Status.BackColor = System.Drawing.Color.Orange;
                            string service = this.Read_ini("Config.ini", "System", "Schedule");
                            if (service == "ON") { this.checkBox2.Checked = true; } else { this.checkBox2.Checked = false; }
                            //   if(groupBox1.Visible == false) { groupBox1.Visible = true; }
                        }
                        catch (Exception)
                        {
                            this.Meldung("Sro Shardlog Connection failed !", new object[0]);
                            this.Meldung("Reconnect with the correct info.", new object[0]);
                        }
                    }
                    catch (Exception)
                    {
                        this.Meldung("Sro Account Connection failed !", new object[0]);
                        this.Meldung("Reconnect with the correct info.", new object[0]);
                    }
                }
                catch (Exception)
                {
                    this.Meldung("Sro Shard Connection failed !", new object[0]);
                    this.Meldung("Reconnect with the correct info.", new object[0]);
                }
            }
            catch (Exception)
            {
                this.Meldung("Database Connection failed !", new object[0]);
                this.Meldung("Reconnect with the correct info.", new object[0]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var ip = this.Read_ini("Config.ini", "Server", "IP");
            var gateport = this.Read_ini("Config.ini", "Server", "Port");
            ////var GateWay = new Gateway();
            ////GateWay.Start(ip, gateport);
            //ConnectServer(ip, gateport);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Meldung("Write a correct captcha code now.", new object[0]);
            //label1.Enabled = false; id.Enabled = false; button2.Enabled = false;
            //label2.Enabled = false; pw.Enabled = false; pictureBox1.Enabled = true;
            //captcha_text.Enabled = true; button3.Enabled = true;
            //Packet packet = new Packet(0x6102);
            //packet.WriteUInt8((byte)0x16);
            //packet.WriteAscii(this.id.Text);
            //packet.WriteAscii(this.pw.Text);
            //packet.WriteUInt16((ushort)0x40);
            //Gateway.SendToServer(packet);
            ///LoginUser(this.id.Text, this.pw.Text);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //CaptchaLogin(this.captcha_text.Text);
//            Captcha.SendCaptcha(this.captcha_text.Text);
            this.Meldung("Captcha code successfuly sent.", new object[0]);
            //pictureBox1.Enabled = false; captcha_text.Enabled = false; button3.Enabled = false;
            //char_list.Enabled = true; button4.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Packet packet = new Packet(0x7001);
            packet.WriteAscii(this.char_list.Text);
            Agent.Send(packet);
            this.Meldung("Character selected.", new object[0]);
            this.timer8.Enabled = true;
        }



        private void BtnStartChar_Click(object sender, EventArgs e)
        {
            sqlshardlog = new SqlConnection("Data Source=" + this.Host.Text + ";Initial Catalog=" + this.Shardlog.Text + ";Integrated Security=false; User ID = " + this.HostUser.Text + "; Password = " + this.HostPw.Text + ";MultipleActiveResultSets=true;");
            sqlshard = new SqlConnection("Data Source=" + this.Host.Text + ";Initial Catalog=" + this.Shard.Text + ";Integrated Security=false; User ID = " + this.HostUser.Text + "; Password = " + this.HostPw.Text + ";MultipleActiveResultSets=true;");
            sqlaccount = new SqlConnection("Data Source=" + this.Host.Text + ";Initial Catalog=" + this.Account.Text + ";Integrated Security=false; User ID = " + this.HostUser.Text + "; Password = " + this.HostPw.Text + ";MultipleActiveResultSets=true;");
            //sqlshardlog = new SqlConnection("Data Source=" + this.Host.Text + ";Initial Catalog=" + this.Shardlog.Text + ";Integrated Security=false; User ID = " + this.HostUser.Text + "; Password = " + this.HostPw.Text + ";MultipleActiveResultSets=true;");
            try
            {
                sqlshardlog.Open();
                this.Meldung("Database connected.", new object[0]);
                try
                {
                    sqlshard.Open();
                    this.Meldung("Sro Shard connected.", new object[0]);
                    try
                    {
                        sqlaccount.Open();
                        this.Meldung("Sro Account connected.", new object[0]);
                        try
                        {
                            //     sqlshardlog.Open();
                            this.Meldung("Sro Shardlog connected.", new object[0]);
                            this.Meldung("Connect to server is available now.", new object[0]);
                            this.Meldung("Execute Schedule is ready to use.", new object[0]);
                            this.Meldung("Useful queries is ready to use.", new object[0]);
                            //  this.groupBox4.Enabled = false; this.groupBox1.Enabled = true;
                            //  this.panel2.Enabled = true;
                            //  this.tabControl2.Enabled = true;
                            //new SqlCommand("Exec [dbo].[Form_Load]", sqlshardlog).ExecuteNonQuery();
                            //if (this.Check_AutoRelog.Checked == true) { this.timer4.Enabled = true; }
                            this.Status.BackColor = System.Drawing.Color.Orange;
                            string service = this.Read_ini("Config.ini", "System", "Schedule");
                            if (service == "ON") { this.checkBox2.Checked = true; } else { this.checkBox2.Checked = false; }
                        }
                        catch (Exception)
                        {
                            this.Meldung("Sro Shardlog Connection failed !", new object[0]);
                            this.Meldung("Reconnect with the correct info.", new object[0]);
                        }
                    }
                    catch (Exception)
                    {
                        this.Meldung("Sro Account Connection failed !", new object[0]);
                        this.Meldung("Reconnect with the correct info.", new object[0]);
                    }
                }
                catch (Exception)
                {
                    this.Meldung("Sro Shard Connection failed !", new object[0]);
                    this.Meldung("Reconnect with the correct info.", new object[0]);
                }
            }
            catch (Exception)
            {
                this.Meldung("Database Connection failed !", new object[0]);
                this.Meldung("Reconnect with the correct info.", new object[0]);
            }






        }

        private void char_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CharacterImage(int CharObjID, PicCharSel)

            reader = new SqlCommand("Select C.CharID,C.RefObjID,C.NickName16,G.Name,C.CurLevel,C.Strength,C.Intellect,C.RemainGold From _Char As C Inner Join _Guild As G ON G.ID = C.GuildID Where C.CharName16 = '" + this.char_list.Text + "'", sqlshard).ExecuteReader();
            if (reader.Read())
            {
                //this.CharName16.Text = this.comboBox1.Text;
                //this.CharID.Text = reader["CharID"].ToString();
                //this.NickName16.Text = reader["NickName16"].ToString();
                //this.GuildName.Text = reader["Name"].ToString();
                txtCharLevel.Text = "Lv: " + reader["CurLevel"].ToString();
                txtCharName.Text = this.char_list.Text;
                //this.CharStr.Text = reader["Strength"].ToString();
                //this.CharInt.Text = reader["Intellect"].ToString();
                //this.CharGold.Text = reader["RemainGold"].ToString();
                this.CharacterImage((int)reader["RefObjID"], this.PicCharSel);

            }
            else
            {
                //this.panel47.IsOpen = false;
                //MessageBox.Show("Something went wrong please report to the developer.", "Caution");
            }
            reader.Close();

        }

        // Copyright button
        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application name : vSro Multi Tool."
            + Environment.NewLine + Environment.NewLine + "Version : 1.8"
            + Environment.NewLine + Environment.NewLine + "License : Paid."
            + Environment.NewLine + Environment.NewLine + "Creater name : Ramy Saied."
            + Environment.NewLine + Environment.NewLine + "Contact with me : www.facebook.com/designer.ramy.saied", "Copyright © iLegend");
        }
        // Hide button
        private void HideTool_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = true;
            base.Hide();
            this.notifyIcon1.BalloonTipTitle = HideMsg;
            this.notifyIcon1.BalloonTipText = "Your tool window has been minimized to the taskbar.";
            this.notifyIcon1.ShowBalloonTip(3000);
        }
        // contact us
        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/designer.ramy.saied");
        }
        // NotifyIcon double click show
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.Visible = false;
            base.Show();
        }
        // menue - Show Bot
        private void showBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            base.Show();
        }
        // menue - Close Bot
        private void closeBotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        // menue - About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application name : vSro Multi Tool."
            + Environment.NewLine + Environment.NewLine + "Version : 1.8"
            + Environment.NewLine + Environment.NewLine + "License : Paid."
            + Environment.NewLine + Environment.NewLine + "Creater name : Ramy Saied."
            + Environment.NewLine + Environment.NewLine + "Contact with me : www.facebook.com/designer.ramy.saied", "Copyright © iLegend");
        }
        // send notice packet
        public void send_notice(string message)
        {
            Packet notice = new Packet(0x7025);
            notice.WriteUInt8((byte)7);
            notice.WriteUInt8((byte)0);
            notice.WriteAscii(message);
            Agent.Send(notice);
            this.Meldung("Notice sent successfully.", new object[0]);
        }
        // send notice check box
        private void Check_Notice_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Notice.Checked == true)
            {
                this.Meldung("Send notice system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Send notice system disabled.", new object[0]);
            }
        }
        // send message packet
        public void send_msg(string target, string message)
        {
            Packet msg = new Packet(0x7309);
            msg.WriteAscii(target);
            msg.WriteAscii(message);
            Agent.Send(msg);
            this.Meldung("Message sent successfully.", new object[0]);
        }
        // send message checkbox
        private void Check_Msg_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Msg.Checked == true)
            {
                this.Meldung("Send message system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Send message system disabled.", new object[0]);
            }
        }
        // send private chat packet
        public void send_pm(string target, string message)
        {
            Packet pm = new Packet(0x7025);

            pm.WriteUInt8(0x02);
            pm.WriteUInt8(0x00);
            pm.WriteAscii(target);
            pm.WriteAscii(message);
            Agent.Send(pm);
            this.Meldung("Private chat to " + target + " sent successfully.", new object[0]);
        }
        // send private chat checkbox
        private void Check_Private_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Private.Checked == true)
            {
                this.Meldung("Send private chat system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Send private chat system disabled.", new object[0]);
            }
        }
        // send chat all packet
        public void send_all(string message)
        {
            Packet send_all = new Packet(0x7025);
            send_all.WriteUInt8(0x03);
            send_all.WriteUInt8(0x00);
            send_all.WriteAscii(message);
            Agent.Send(send_all);
            this.Meldung("Chat to all sent successfully.", new object[0]);
        }
        // send chat all checkbox
        private void Check_ChatAll_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_ChatAll.Checked == true)
            {
                this.Meldung("Send public chat system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Send public chat system disabled.", new object[0]);
            }
        }
        // send global chat packet
        public void send_global(string message, string global_slot)
        {
            Packet global = new Packet(0x704C, true);
            global.WriteUInt8(global_slot);
            global.WriteUInt8(0xED);
            global.WriteUInt8(0x29);
            global.WriteAscii(message);
            Agent.Send(global);
            this.Meldung("Global sent successfully.", new object[0]);
        }
        // send global chat checkbox
        private void Check_Global_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Global.Checked == true)
            {
                this.Meldung("Send global chat system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Send global chat system disabled.", new object[0]);
            }
        }
        // Incoming global and private chat
        public void Check_Incomechat_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Incomechat.Checked == true)
            {
                this.Meldung("Saving incoming chat enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Saving incoming chat disabled.", new object[0]);
            }
        }
        // Incoming unique logs spawn and kill
        private void UniqueLogBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UniqueLogBox.Checked == true)
            {
                this.Meldung("Saving incoming uniques log enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Saving incoming uniques log disabled.", new object[0]);
            }
        }
        // Move to user packet
        public void movetouser(string target)
        {
            Packet movetouser = new Packet(0x7010, true);
            movetouser.WriteUInt16(8);
            movetouser.WriteAscii(target);
            Agent.Send(movetouser);
            this.Meldung("Move to user " + target + " successfully.", new object[0]);
        }
        // Move to user checkbox
        private void Check_Movetouser_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Movetouser.Checked == true)
            {
                this.Meldung("Move to user system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Move to user system disabled.", new object[0]);
            }
        }
        // recall user packet
        public void recalluser(string target)
        {
            Packet recalluser = new Packet(0x7010);
            recalluser.WriteUInt16(17);
            recalluser.WriteAscii(target);
            Agent.Send(recalluser);
            this.Meldung("Recall user " + target + " successfully.", new object[0]);
        }
        // recall user checkbox
        private void Check_RecallUser_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_RecallUser.Checked == true)
            {
                this.Meldung("Recall user system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Recall user system disabled.", new object[0]);
            }
        }
        // recall guild packet
        public void recallguild(string target)
        {
            Packet recallguild = new Packet(0x7010);
            recallguild.WriteUInt16(18);
            recallguild.WriteAscii(target);
            Agent.Send(recallguild);
            this.Meldung("Recall guild " + target + " successfully.", new object[0]);
        }
        // recall guild checkbox
        private void Check_RecallGuild_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_RecallGuild.Checked == true)
            {
                this.Meldung("Recall guild system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Recall guild system disabled.", new object[0]);
            }
        }
        // totown user packet
        public void totown(string target)
        {
            Packet totown = new Packet(0x7010, true);
            totown.WriteUInt16(3);
            totown.WriteAscii(target);
            Agent.Send(totown);
            this.Meldung("Player : " + target + " to town successfully.", new object[0]);
        }
        // totown user checkbox
        private void Check_ToTown_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_ToTown.Checked == true)
            {
                this.Meldung("Totown user system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Totown user system disabled.", new object[0]);
            }
        }
        // disconnect user packet
        public void dc_user(string target)
        {
            Packet dc_user = new Packet(0x7010);
            dc_user.WriteUInt16(13);
            dc_user.WriteAscii(target);
            Agent.Send(dc_user);
            this.Meldung("Player : " + target + " Disconnect successfully.", new object[0]);
        }
        // disconnect user checkbox
        private void Check_DcUser_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_DcUser.Checked == true)
            {
                this.Meldung("Disconnect user system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Disconnect user system disabled.", new object[0]);
            }
        }
        // warp region packet
        public void warp(string regionid, string posX, string posY, string posZ, string worldid)
        {
            Packet warp = new Packet(0x7010);
            warp.WriteUInt8(0x10);
            warp.WriteUInt8(0);
            warp.WriteInt16(regionid);
            warp.WriteSingle(posX);
            warp.WriteSingle(posY);
            warp.WriteSingle(posZ);
            warp.WriteInt8(worldid);
            warp.WriteUInt8(0);
            Agent.Send(warp);
            this.Meldung("Character warp to R = " + regionid + " X = " + posX + " Y = " + posY + " Z = " + posZ + " done.", new object[0]);
        }
        // warp region checkbox
        private void Check_Warp_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Warp.Checked == true)
            {
                this.Meldung("Warp region system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Warp region system disabled.", new object[0]);
            }
        }
        // load monster packet
        public void loadmonster(string Mobid, string Amount)
        {
            Packet loadmonster = new Packet(0x7010);
            loadmonster.WriteUInt8((byte)6);
            loadmonster.WriteUInt8((byte)0);
            loadmonster.WriteUInt32(Mobid);
            loadmonster.WriteUInt8(Amount);
            loadmonster.WriteUInt8((byte)3);
            Agent.Send(loadmonster);
        }
        // load monster checkbox
        private void Check_LoadMonster_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_LoadMonster.Checked == true)
            {
                this.Meldung("Load monster system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Load monster system disabled.", new object[0]);
            }
        }
        // make item packet
        public void makeitem(string Itemid, string Amount, string optlvl)
        {
            string[] dr = new string[] { Itemid, Amount }; // example
            Packet makeitem = new Packet(0x7010);
            makeitem.WriteUInt8(07);
            makeitem.WriteUInt8(00);
            makeitem.WriteUInt32(dr[0]); // dr[0] item id + count
            makeitem.WriteUInt8(optlvl); // item plus
            Agent.Send(makeitem);
            this.Meldung("Makeitem (" + Itemid + "," + Amount + "," + optlvl + ") successfully.", new object[0]);
        }
        // make item checkbox
        private void Check_MakeItem_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_MakeItem.Checked == true)
            {
                this.Meldung("Make item system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Make item system disabled.", new object[0]);
            }
        }
        // invincible packet
        public void invincible()
        {
            Packet invincible = new Packet(0x7010);
            invincible.WriteUInt8(0x0F);
            invincible.WriteUInt8(0x00);
            Agent.Send(invincible);
            this.Meldung("Invincible successfully.", new object[0]);
        }
        // invincible checkbox 
        private void Check_Invincible_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Invincible.Checked == true)
            {
                this.Meldung("Invincible system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Invincible system disabled.", new object[0]);
            }
        }
        // invisible packet
        public void invisible()
        {
            Packet invisible = new Packet(0x7010);
            invisible.WriteUInt8(0x0e);
            invisible.WriteUInt8(0x00);
            Agent.Send(invisible);
            this.Meldung("Invisible successfully.", new object[0]);
        }
        // invisible checkbox
        private void Check_Invisible_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_Invisible.Checked == true)
            {
                this.Meldung("Invisible system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Invisible system disabled.", new object[0]);
            }
        }
        // go town gm character packet
        public void gotown()
        {
            Packet gotown = new Packet(0x7010, true);
            gotown.WriteUInt8(02);
            gotown.WriteUInt8(00);
            Agent.Send(gotown);
            this.Meldung("Go town successfully.", new object[0]);
        }
        // go town gm character checkbox
        private void Check_GoTown_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_GoTown.Checked == true)
            {
                this.Meldung("Go town system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Go town system disabled.", new object[0]);
            }
        }
        // gm skill packet
        public void gmskill()
        {
            Packet gmskill = new Packet(0x7074, true);
            gmskill.WriteUInt8(01);
            gmskill.WriteUInt8(04);
            gmskill.WriteUInt32(3978);
            gmskill.WriteUInt8(0);
            Agent.Send(gmskill);
            this.Meldung("Gm skill used successfully.", new object[0]);
        }
        // gm skill checkbox
        private void Check_GMSkill_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_GMSkill.Checked == true)
            {
                this.Meldung("Gm skill system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Gm skill system disabled.", new object[0]);
            }
        }
        // open cape packet
        public void OpenCape(int CapeIndex)
        {
            Packet cape = new Packet(0x7516, true);
            cape.WriteUInt8(CapeIndex);
            Agent.Send(cape);
            this.Meldung("Pvp cape used successfully.", new object[0]);
        }
        // open cape checkbox
        private void Check_PvpCape_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_PvpCape.Checked == true)
            {
                this.Meldung("Pvp cape system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Pvp cape system disabled.", new object[0]);
            }
        }
        // get cape index int value by color name
        public int CapIndex(string Color)
        {
            int Result = 0;
            switch (Color)
            {
                case "Red": Result = 1; break;
                case "Black": Result = 2; break;
                case "Blue": Result = 3; break;
                case "White": Result = 4; break;
                case "Yellow": Result = 5; break;
            }
            return Result;
        }
        // open stall packet
        public void CreateStall(string StallName, string StallGreating)
        {
            // first stall packet typing stall name
            Packet Stall1 = new Packet(0x70B1, true);
            Stall1.WriteAscii(StallName); //stall name
            Agent.Send(Stall1);
            // second stall packet typing stall welcome msg
            Packet Stall2 = new Packet(0x70BA, true);
            Stall2.WriteUInt8(0x06); //static
            Stall2.WriteAscii(StallGreating); //welcome msg
            Agent.Send(Stall2);
            this.Meldung("Stall created successfully.", new object[0]);
        }
        // Stall item add packet
        public void AddItemToStall(string StallSlots, string InvSlot, string ItemCount, string GoldCount)
        {
            Packet AddItem = new Packet(0x70BA);
            AddItem.WriteUInt8(0x02); //static
            AddItem.WriteUInt8(StallSlots); //stall slot
            AddItem.WriteUInt8(InvSlot); //Inv slot
            AddItem.WriteUInt16(ItemCount); //item count
            AddItem.WriteUInt64(GoldCount); //Gold
            AddItem.WriteUInt32(0x32); //static
            AddItem.WriteUInt16(0); //static
            Agent.Send(AddItem);
            this.Meldung("Item successfully added to stall.", new object[0]);
        }
        // Stall open packet
        public void OpenStall()
        {
            Packet stall_open = new Packet(0x70BA);
            stall_open.WriteUInt8(0x05);
            stall_open.WriteUInt8(1);
            stall_open.WriteUInt16(0);
            Agent.Send(stall_open);
            this.Meldung("Stall opened successfully.", new object[0]);
        }
        // Stall close packet
        public void CloseStall()
        {
            Packet stall_close = new Packet(0x70B2);
            Agent.Send(stall_close);
            this.Meldung("Stall closed successfully.", new object[0]);
        }
        // stall system checkbox
        private void Check_StallCreate_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_StallCreate.Checked == true)
            {
                this.Meldung("Stall system enabled.", new object[0]);
            }
            else
            {
                this.Meldung("Stall system disabled.", new object[0]);
            }
        }

        // Relog functions :
        //------------------
        // check disconnect
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //   //if (StartRelog.Checked == true && Check_AutoRelog.Checked == true)
        //   //{
        //   //    this.Meldung("Character re-log in 10 seconds.", new object[0]);
        //   //    timer2.Enabled = true;
        //   //    StartRelog.Checked = false;
        //   //}
        //}
        //// restart tool
        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
        //    Environment.Exit(0); //to turn off current app
        //}
        //// connect to sql
        //private void timer3_Tick(object sender, EventArgs e)
        //{
        //    //SQLConnect_Click(this.SQLConnect, e);
        //    timer3.Enabled = false;
        //}
        //// connect to gateway
        //private void timer4_Tick(object sender, EventArgs e)
        //{
        //    //button1_Click(this.button1, e);
        //    timer4.Enabled = false;
        //    timer5.Enabled = true;
        //}
        //// connect to agent
        //private void timer5_Tick(object sender, EventArgs e)
        //{
        //   // button2_Click(this.button2, e);
        //    timer5.Enabled = false;
        //    timer6.Enabled = true;
        //}
        // send captcha
        //private void timer6_Tick(object sender, EventArgs e)
        //{
        // //  if (this.button3.Enabled == true)
        // //  {
        // //      button3_Click(this.button3, e);
        // //      timer6.Enabled = false;
        // //      timer7.Enabled = true;
        // //  }
        // //  else
        // //  {
        // //      timer6.Enabled = false;
        // //      timer7.Enabled = true;
        // //  }
        //}
        // select character
        //private void timer7_Tick(object sender, EventArgs e)
        //{
        //   //button4_Click(this.button4, e);
        //   //timer7.Enabled = false;
        //   //timer8.Enabled = true;
        //}
        // get configuration of systems services
        private void timer8_Tick(object sender, EventArgs e)
        {
            LoadConfig_Click(this.LoadConfig, e);
            timer8.Enabled = false;
            if (this.Check_AutoRelog.Checked == true) { HideTool_Click(this.HideTool, e); }
            this.ToolService.Interval = int.Parse(textBox19.Text);
            ToolService.Enabled = true;
        }
        // refresh delay time when textbox value changed
        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            this.ToolService.Interval = int.Parse(textBox19.Text);
        }
        // save settings
        private void SaveConfig_Click(object sender, EventArgs e)
        {
            string service = null;
            this.Write_ini("Config.ini", "SQL", "Host", this.Host.Text);
            //    this.Write_ini("Config.ini", "SQL", "Database", this.DB_Name.Text);
            this.Write_ini("Config.ini", "SQL", "Shard", this.Shard.Text);
            this.Write_ini("Config.ini", "SQL", "Account", this.Account.Text);
            this.Write_ini("Config.ini", "SQL", "ShardLog", this.Shardlog.Text);
            this.Write_ini("Config.ini", "SQL", "HostUser", this.HostUser.Text);
            this.Write_ini("Config.ini", "SQL", "HostPw", this.HostPw.Text);
            this.Write_ini("Config.ini", "Server", "IP", this.ip.Text);
            this.Write_ini("Config.ini", "Server", "Port", this.gateport.Text);
            this.Write_ini("Config.ini", "Server", "Locale", this.slocale.Text);
            this.Write_ini("Config.ini", "Server", "Version", this.sversion.Text);
            this.Write_ini("Config.ini", "Login", "AccountID", this.id.Text);
            this.Write_ini("Config.ini", "Login", "AccountPW", this.pw.Text);
            this.Write_ini("Config.ini", "Login", "CaptchaCode", this.captcha_text.Text);
            this.Write_ini("Config.ini", "Login", "CharName", this.char_list.Text);
            if (this.checkBox1.Checked == true) { service = "ON"; } else { service = "OFF"; }
            this.Write_ini("Config.ini", "Login", "Xtrap", service);
            if (this.Check_AutoRelog.Checked == true) { service = "ON"; } else { service = "OFF"; }
            this.Write_ini("Config.ini", "Login", "Relog", service);
            //this.Write_ini("Config.ini", "Style", "Index", this.slider1.Value.ToString());
            //this.Write_ini("Config.ini", "Style", "CanvasColor_R", this.colorPickerButton1.SelectedColor.R.ToString());
            //this.Write_ini("Config.ini", "Style", "CanvasColor_G", this.colorPickerButton1.SelectedColor.G.ToString());
            //this.Write_ini("Config.ini", "Style", "CanvasColor_B", this.colorPickerButton1.SelectedColor.B.ToString());
            //this.Write_ini("Config.ini", "Style", "BaseColor_R", this.colorPickerButton2.SelectedColor.R.ToString());
            //this.Write_ini("Config.ini", "Style", "BaseColor_G", this.colorPickerButton2.SelectedColor.G.ToString());
            //this.Write_ini("Config.ini", "Style", "BaseColor_B", this.colorPickerButton2.SelectedColor.B.ToString());
            if (this.panelEx38.Enabled == true)
            {
                if (this.Check_Notice.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "SendNotice", service);
                if (this.Check_Msg.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "SendMessage", service);
                if (this.Check_Private.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "SendPrivate", service);
                if (this.Check_ChatAll.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "SendPublic", service);
                if (this.Check_Global.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "SendGlobal", service);
                if (this.Check_Incomechat.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "SaveChat", service);
                if (this.UniqueLogBox.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "SaveUnique", service);
                if (this.Check_Movetouser.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "MoveToUser", service);
                if (this.Check_RecallUser.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "RecallUser", service);
                if (this.Check_RecallGuild.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "RecallGuild", service);
                if (this.Check_ToTown.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "ToTown", service);
                if (this.Check_DcUser.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "DcUser", service);
                if (this.Check_Warp.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "Warp", service);
                if (this.Check_LoadMonster.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "LoadMonster", service);
                if (this.Check_MakeItem.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "MakeItem", service);
                if (this.Check_Invincible.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "Invincible", service);
                if (this.Check_Invisible.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "Invisible", service);
                if (this.Check_GoTown.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "GoTown", service);
                if (this.Check_GMSkill.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "GMSkill", service);
                if (this.Check_PvpCape.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "PvpCape", service);
                if (this.Check_StallCreate.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "StallSystem", service);
                this.Write_ini("Config.ini", "System", "TimerDelay", this.textBox19.Text);
            }
            if (this.panel2.Enabled == true)
            {
                if (this.checkBox2.Checked == true) { service = "ON"; } else { service = "OFF"; }
                this.Write_ini("Config.ini", "System", "Schedule", service);
            }
            Meldung("Settings saved successfully.", new object[0]);
        }
        // load settings
        public void LoadConfig_Click(object sender, EventArgs e)
        {
            string service = null;
            if (this.groupBox4.Enabled == true)
            {
                this.Host.Text = this.Read_ini("Config.ini", "SQL", "Host");
                this.Shard.Text = this.Read_ini("Config.ini", "SQL", "Shard");
                this.Account.Text = this.Read_ini("Config.ini", "SQL", "Account");
                this.Shardlog.Text = this.Read_ini("Config.ini", "SQL", "ShardLog");
                this.HostUser.Text = this.Read_ini("Config.ini", "SQL", "HostUser");
                this.HostPw.Text = this.Read_ini("Config.ini", "SQL", "HostPw");
            }
            if (this.groupBox1.Enabled == true)
            {
                this.ip.Text = this.Read_ini("Config.ini", "Server", "IP");
                this.gateport.Text = this.Read_ini("Config.ini", "Server", "Port");
                this.slocale.Text = this.Read_ini("Config.ini", "Server", "Locale");
                this.sversion.Text = this.Read_ini("Config.ini", "Server", "Version");
                service = this.Read_ini("Config.ini", "Login", "Xtrap");
                if (service == "ON") { this.checkBox1.Checked = true; } else { this.checkBox1.Checked = false; }
                service = this.Read_ini("Config.ini", "Login", "Relog");
                if (service == "ON") { this.Check_AutoRelog.Checked = true; } else { this.Check_AutoRelog.Checked = false; }
            }
            if (this.groupBox3.Enabled == true)
            {
                this.id.Text = this.Read_ini("Config.ini", "Login", "AccountID");
                this.pw.Text = this.Read_ini("Config.ini", "Login", "AccountPW");
                this.captcha_text.Text = this.Read_ini("Config.ini", "Login", "CaptchaCode");
                this.char_list.Text = this.Read_ini("Config.ini", "Login", "CharName");
            }
            if (this.panelEx38.Enabled == true)
            {
                service = this.Read_ini("Config.ini", "System", "SendNotice");
                if (service == "ON") { this.Check_Notice.Checked = true; } else { this.Check_Notice.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "SendMessage");
                if (service == "ON") { this.Check_Msg.Checked = true; } else { this.Check_Msg.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "SendPrivate");
                if (service == "ON") { this.Check_Private.Checked = true; } else { this.Check_Private.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "SendPublic");
                if (service == "ON") { this.Check_ChatAll.Checked = true; } else { this.Check_ChatAll.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "SendGlobal");
                if (service == "ON") { this.Check_Global.Checked = true; } else { this.Check_Global.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "SaveChat");
                if (service == "ON") { this.Check_Incomechat.Checked = true; } else { this.Check_Incomechat.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "SaveUnique");
                if (service == "ON") { this.UniqueLogBox.Checked = true; } else { this.UniqueLogBox.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "MoveToUser");
                if (service == "ON") { this.Check_Movetouser.Checked = true; } else { this.Check_Movetouser.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "RecallUser");
                if (service == "ON") { this.Check_RecallUser.Checked = true; } else { this.Check_RecallUser.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "RecallGuild");
                if (service == "ON") { this.Check_RecallGuild.Checked = true; } else { this.Check_RecallGuild.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "ToTown");
                if (service == "ON") { this.Check_ToTown.Checked = true; } else { this.Check_ToTown.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "DcUser");
                if (service == "ON") { this.Check_DcUser.Checked = true; } else { this.Check_DcUser.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "Warp");
                if (service == "ON") { this.Check_Warp.Checked = true; } else { this.Check_Warp.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "LoadMonster");
                if (service == "ON") { this.Check_LoadMonster.Checked = true; } else { this.Check_LoadMonster.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "MakeItem");
                if (service == "ON") { this.Check_MakeItem.Checked = true; } else { this.Check_MakeItem.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "Invincible");
                if (service == "ON") { this.Check_Invincible.Checked = true; } else { this.Check_Invincible.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "Invisible");
                if (service == "ON") { this.Check_Invisible.Checked = true; } else { this.Check_Invisible.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "GoTown");
                if (service == "ON") { this.Check_GoTown.Checked = true; } else { this.Check_GoTown.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "GMSkill");
                if (service == "ON") { this.Check_GMSkill.Checked = true; } else { this.Check_GMSkill.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "PvpCape");
                if (service == "ON") { this.Check_PvpCape.Checked = true; } else { this.Check_PvpCape.Checked = false; }
                service = this.Read_ini("Config.ini", "System", "StallSystem");
                if (service == "ON") { this.Check_StallCreate.Checked = true; } else { this.Check_StallCreate.Checked = false; }
                this.textBox19.Text = this.Read_ini("Config.ini", "System", "TimerDelay");
            }
            if (this.panel2.Enabled == true)
            {
                service = this.Read_ini("Config.ini", "System", "Schedule");
                if (service == "ON") { this.checkBox2.Checked = true; } else { this.checkBox2.Checked = false; }
            }
            //this.slider1.Value = Convert.ToInt16(this.Read_ini("Config.ini", "Style", "Index"));
            //this.colorPickerButton1.SelectedColor = Color.FromArgb(Convert.ToInt16(this.Read_ini("Config.ini", "Style", "CanvasColor_R")), Convert.ToInt16(this.Read_ini("Config.ini", "Style", "CanvasColor_G")), Convert.ToInt16(this.Read_ini("Config.ini", "Style", "CanvasColor_B")));
            //this.colorPickerButton2.SelectedColor = Color.FromArgb(Convert.ToInt16(this.Read_ini("Config.ini", "Style", "BaseColor_R")), Convert.ToInt16(this.Read_ini("Config.ini", "Style", "BaseColor_G")), Convert.ToInt16(this.Read_ini("Config.ini", "Style", "BaseColor_B")));
        }
        // system functions timer
        private void ToolService_Tick(object sender, EventArgs e)
        {
            try
            {
                reader = new SqlCommand("Declare @Date Varchar(100) = Getdate() , @DateSub Varchar(100) = Getdate() - '00:01:00'; Select Top 1 * From iLegend_Tool Where Service = '1' and Date Between @DateSub and @Date Order By ID;", sqlshardlog).ExecuteReader();
                while (reader.Read())
                {
                    int ID = (int)reader["ID"];
                    string Type = (string)reader["Type"];
                    switch (Type)
                    {
                        case "Notice":
                            if (Check_Notice.Checked == true)
                            {
                                try
                                {
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("`", "'");
                                    send_notice(Message);
                                }
                                catch
                                { Meldung("Error while sending notice.", new object[0]); }
                            }
                            break;
                        case "Message":
                            if (Check_Msg.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("'", "`");
                                    send_msg(Target, Message);
                                }
                                catch
                                { Meldung("Error while sending message.", new object[0]); }
                            }
                            break;
                        case "Private":
                            if (Check_Private.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("`", "'");
                                    send_pm(Target, Message);
                                }
                                catch
                                { Meldung("Error while sending private chat.", new object[0]); }
                            }
                            break;
                        case "Public":
                            if (Check_ChatAll.Checked == true)
                            {
                                try
                                {
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("`", "'");
                                    send_all(Message);
                                }
                                catch
                                { Meldung("Error while sending public chat.", new object[0]); }
                            }
                            break;
                        case "Global":
                            if (Check_Global.Checked == true)
                            {
                                try
                                {
                                    string Message = (string)reader["Message"];
                                    Message = Message.Replace("`", "'");
                                    reader = new SqlCommand("Select Top 1 I.Slot From [dbo].[_Inventory] As I Inner Join [dbo].[_Char] As C ON I.CharID = C.CharID Inner Join [dbo].[_Items] As T ON I.ItemID = T.ID64 Where C.CharName16 = '" + this.char_list.Text + "' and T.RefItemID = 3851", sqlshard).ExecuteReader();
                                    if (reader.Read())
                                    {
                                        string Slot = reader["Slot"].ToString();
                                        send_global(Message, Slot);
                                    }
                                    else
                                    {
                                        Meldung("Error while sending global chat (character hasn't any global item.", new object[0]);
                                    }
                                }
                                catch
                                { Meldung("Error while sending global chat.", new object[0]); }
                            }
                            break;
                        case "Movetouser":
                            if (Check_Movetouser.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    movetouser(Target);
                                }
                                catch
                                { Meldung("Error while movetouser function.", new object[0]); }
                            }
                            break;
                        case "Recalluser":
                            if (Check_RecallUser.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    recalluser(Target);
                                }
                                catch
                                { Meldung("Error while recalluser function.", new object[0]); }
                            }
                            break;
                        case "Recallguild":
                            if (Check_RecallGuild.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    recallguild(Target);
                                }
                                catch
                                { Meldung("Error while recallguild function.", new object[0]); }
                            }
                            break;
                        case "Totown":
                            if (Check_ToTown.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    totown(Target);
                                }
                                catch
                                { Meldung("Error while totown user function.", new object[0]); }
                            }
                            break;
                        case "Disconnect":
                            if (Check_DcUser.Checked == true)
                            {
                                try
                                {
                                    string Target = (string)reader["Target"];
                                    dc_user(Target);
                                }
                                catch
                                { Meldung("Error while disconnect user function.", new object[0]); }
                            }
                            break;
                        case "Warp":
                            if (Check_Warp.Checked == true)
                            {
                                try
                                {
                                    string RegionID = (string)reader["RegionID"];
                                    string PosX = (string)reader["PosX"];
                                    string PosY = (string)reader["PosY"];
                                    string PosZ = (string)reader["PosZ"];
                                    string WorldID = (string)reader["WorldID"];
                                    warp(RegionID, PosX, PosY, PosZ, WorldID);
                                }
                                catch
                                { Meldung("Error while warp region function.", new object[0]); }
                            }
                            break;
                        case "Loadmonster":
                            if (Check_LoadMonster.Checked == true)
                            {
                                try
                                {
                                    string RefMobID = (string)reader["RefMobID"];
                                    string Amount = (string)reader["Amount"];
                                    loadmonster(RefMobID, Amount);
                                }
                                catch
                                { Meldung("Error while loadmonster function.", new object[0]); }
                            }
                            break;
                        case "Makeitem":
                            if (Check_MakeItem.Checked == true)
                            {
                                try
                                {
                                    string RefItemID = (string)reader["RefItemID"];
                                    string Amount = (string)reader["Amount"];
                                    string OptLvl = (string)reader["OptLvl"];
                                    makeitem(RefItemID, Amount, OptLvl);
                                }
                                catch
                                { Meldung("Error while makeitem function.", new object[0]); }
                            }
                            break;
                        case "Invincible":
                            if (Check_Invincible.Checked == true)
                            {
                                try { invincible(); }
                                catch
                                { Meldung("Error while invincible function.", new object[0]); }
                            }
                            break;
                        case "Invisible":
                            if (Check_Invisible.Checked == true)
                            {
                                try { invisible(); }
                                catch
                                { Meldung("Error while invisible function.", new object[0]); }
                            }
                            break;
                        case "Gotown":
                            if (Check_GoTown.Checked == true)
                            {
                                try { gotown(); }
                                catch
                                { Meldung("Error while gotown function.", new object[0]); }
                            }
                            break;
                        case "GMskill":
                            if (Check_GMSkill.Checked == true)
                            {
                                try { gmskill(); }
                                catch
                                { Meldung("Error while gmskill function.", new object[0]); }
                            }
                            break;
                        case "PvpCape":
                            if (Check_PvpCape.Checked == true)
                            {
                                try
                                {
                                    string CapeColor = (string)reader["CapeColor"];
                                    OpenCape(this.CapIndex(CapeColor));
                                }
                                catch
                                { Meldung("Error while pvp cape function.", new object[0]); }
                            }
                            break;

                        case "CreateStall":
                            if (Check_StallCreate.Checked == true)
                            {
                                try
                                {
                                    string Title = (string)reader["StallTitle"];
                                    string Greating = (string)reader["StallGreating"];
                                    CreateStall(Title, Greating);
                                }
                                catch
                                { Meldung("Error while create stall function.", new object[0]); }
                            }
                            break;
                        case "AddStallItem":
                            if (Check_StallCreate.Checked == true)
                            {
                                try
                                {
                                    string StallSlot = (string)reader["StallSlot"];
                                    string InvSlot = (string)reader["InvSlot"];
                                    string Count = (string)reader["ItemCount"];
                                    string Price = (string)reader["ItemPrice"];
                                    AddItemToStall(StallSlot, InvSlot, Count, Price);
                                }
                                catch
                                { Meldung("Error while add stall item function.", new object[0]); }
                            }
                            break;
                        case "OpenStall":
                            if (Check_StallCreate.Checked == true)
                            {
                                try
                                { OpenStall(); }
                                catch
                                { Meldung("Error while opening stall function.", new object[0]); }
                            }
                            break;
                        case "CloseStall":
                            if (Check_StallCreate.Checked == true)
                            {
                                try
                                { CloseStall(); }
                                catch
                                { Meldung("Error while closing stall function.", new object[0]); }
                            }
                            break;
                    }
                    QueryExecute("Update iLegend_Tool Set Service = '0' Where ID = " + ID);
                }
                reader.Close();
            }
            catch { Meldung("Error in [ToolService] timer, cannot read from database table.", new object[0]); }
        }
        // execute query by a timer
        private void Execute_Tick(object sender, EventArgs e)
        {
            String Now = string.Format("{0:HH:mm:ss}", DateTime.Now);
            try
            {
                reader = new SqlCommand("Select Top 1 Day , DatabaseIndex , Query From [dbo].[ExecQuery] Where Time = '" + Now + "'", sqlshardlog).ExecuteReader();
                if (reader.Read())
                {
                    int day = getDayOfWeek(reader["Day"].ToString());
                    if (day == -1 || day == (int)System.DateTime.Now.DayOfWeek)
                    {
                        string Query = (string)reader["Query"];
                        int Index = (int)reader["DatabaseIndex"];
                        switch (Index)
                        {
                            case 1:
                            case 4:
                                new SqlCommand(Query, sqlshardlog).ExecuteNonQuery();
                                break;
                            case 2:
                                new SqlCommand(Query, sqlshard).ExecuteNonQuery();
                                break;
                            case 3:
                                new SqlCommand(Query, sqlaccount).ExecuteNonQuery();
                                break;
                        }
                    }
                }
                reader.Close();
            }
            catch
            { Meldung("Error 01 , report to the developer.", new object[0]); }

            try
            {
                this.listView1.Items.Clear();
                reader = new SqlCommand("Select * From [dbo].[ExecQuery]", sqlshardlog).ExecuteReader();
                while (reader.Read())
                {
                    string dd = reader["Day"].ToString();
                    int day = getDayOfWeek(dd);
                    int ID = (int)reader["ID"];
                    string ExTime = (string)reader["Time"];
                    int DbIndex = (int)reader["DatabaseIndex"];
                    string Query = (string)reader["Query"];
                    string remaining = null;
                    DateTime TimeNow = Convert.ToDateTime(Now);
                    DateTime Time = Convert.ToDateTime(ExTime);
                    TimeSpan Adding = new TimeSpan(0, 24, 0, 0);

                    if (day == -1 || day == (int)System.DateTime.Now.DayOfWeek)
                    {
                        if (TimeNow < Time)
                        {
                            TimeSpan TimeRemaining = Time - TimeNow;
                            remaining = "0 Day(s) " + Convert.ToString(TimeRemaining);
                        }
                        else if (TimeNow > Time && day == -1)
                        {
                            TimeSpan TimeRemaining = Time - TimeNow + Adding;
                            remaining = "0 Day(s) " + Convert.ToString(TimeRemaining);
                        }
                        else if (TimeNow > Time && day == (int)System.DateTime.Now.DayOfWeek)
                        {
                            TimeSpan TimeRemaining = Time - TimeNow + Adding;
                            remaining = "6 Day(s) " + Convert.ToString(TimeRemaining);
                        }
                        else if (TimeNow == Time)
                        {
                            remaining = "0 Day(s) 00:00:00";
                        }
                    }
                    else
                    {
                        int variable = 0;
                        if (day > (int)System.DateTime.Now.DayOfWeek) { variable = day - (int)System.DateTime.Now.DayOfWeek; }
                        if (day < (int)System.DateTime.Now.DayOfWeek) { variable = day - (int)System.DateTime.Now.DayOfWeek + 7; }
                        if (TimeNow < Time)
                        {
                            TimeSpan TimeRemaining = Time - TimeNow;
                            remaining = variable.ToString() + " Day(s) " + Convert.ToString(TimeRemaining);
                        }
                        else if (TimeNow > Time)
                        {
                            TimeSpan TimeRemaining = Time - TimeNow + Adding;
                            remaining = variable.ToString() + " Day(s) " + Convert.ToString(TimeRemaining);
                        }
                        else if (TimeNow == Time)
                        {
                            remaining = variable.ToString() + " Day(s) 00:00:00";
                        }
                    }
                    ListViewItem lista = new ListViewItem(ID.ToString());
                    lista.SubItems.Add(dd);
                    lista.SubItems.Add(ExTime);
                    lista.SubItems.Add(remaining);
                    lista.SubItems.Add(DbIndex.ToString());
                    lista.SubItems.Add(Query);
                    this.listView1.Items.Add(lista);
                }
                reader.Close();
            }
            catch
            { Meldung("Error 02 , report to the developer.", new object[0]); }
        }
        // select (int)dayofweek by varchar variable
        private static int getDayOfWeek(string text)
        {
            int Return = -1;
            switch (text)
            {
                case "Always":
                    Return = -1;
                    break;
                case "Sunday":
                    Return = 0;
                    break;
                case "Monday":
                    Return = 1;
                    break;
                case "Tuesday":
                    Return = 2;
                    break;
                case "Wednesday":
                    Return = 3;
                    break;
                case "Thursday":
                    Return = 4;
                    break;
                case "Friday":
                    Return = 5;
                    break;
                case "Saturday":
                    Return = 6;
                    break;
            }
            return Return;
        }
        // execute queries service
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked == true)
            {
                this.Execute.Enabled = true;
            }
            else
            {
                this.Execute.Enabled = false;
                this.listView1.Items.Clear();
            }
        }
        // Get user current hash password
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.textBox10.Text))
                {
                    reader = new SqlCommand("Select password From TB_User Where StrUserID = '" + this.textBox10.Text + "'", sqlaccount).ExecuteReader();
                    if (reader.Read())
                    {
                        this.textBox11.Text = (string)reader["password"];
                    }
                    else
                    {
                        MessageBox.Show("This username doesn't exists.", "Caution");
                    }
                    reader.Close();
                }
                else
                { MessageBox.Show("You must enter username first.", "Caution"); }
            }
            catch { }
        }
        // Get user current hash password rest
        private void button15_Click(object sender, EventArgs e)
        {
            this.textBox10.Text = null; this.textBox11.Text = null;
        }
        // Create a new user
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBox1.Text) || string.IsNullOrEmpty(this.textBox2.Text))
                {
                    MessageBox.Show("You must fill username and password fields.", "Caution");
                }
                else if (QueryChecks.containsQuotes(this.textBox1.Text) || QueryChecks.containsQuotes(this.textBox2.Text))
                {
                    MessageBox.Show("Username, or password contains quotes (' or \" symbols). It's not allowed.", "Caution");
                }
                else
                {
                    reader = new SqlCommand("Select * From TB_User Where StrUserID = '" + this.textBox1.Text + "'", sqlaccount).ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("This username already exists.", "Caution");
                    }
                    else
                    {
                        new SqlCommand("insert into TB_User(StrUserID,password,sec_primary,sec_content) values('" + this.textBox1.Text + "','" + Crypt.getMD5(this.textBox2.Text) + "','3','3')", sqlaccount).ExecuteNonQuery();
                        this.textBox1.Text = null; this.textBox2.Text = null;
                        MessageBox.Show("Account successfuly created.", "Sucess");
                    }
                    reader.Close();
                }
            }
            catch { }
        }
        // Edit user information cancel
        private void button14_Click(object sender, EventArgs e)
        {
            this.EditUserPanel.IsOpen = false;
            this.textBox5.Text = null; this.panel34.Enabled = true;
        }
        // Edit user information search
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.textBox5.Text))
                {
                    reader = new SqlCommand("Select * From TB_User Where StrUserID = '" + this.textBox5.Text + "'", sqlaccount).ExecuteReader();
                    if (reader.Read())
                    {
                        this.textBox6.Text = reader["JID"].ToString();
                        this.textBox13.Text = reader["StrUserID"].ToString();
                        this.textBox7.Text = "MD5 Encrypted";
                        this.textBox8.Text = reader["Email"].ToString();
                        this.textBox9.Text = reader["sec_primary"].ToString();
                        this.textBox12.Text = reader["sec_content"].ToString();
                        this.EditUserPanel.IsOpen = true; this.panel34.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("This username doesn't exists.", "Caution");
                    }
                    reader.Close();
                }
                else { MessageBox.Show("You must enter username first.", "Caution"); }
            }
            catch { }
        }
        // Edit user information save changes
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBox13.Text) || string.IsNullOrEmpty(this.textBox7.Text) || string.IsNullOrEmpty(this.textBox9.Text) || string.IsNullOrEmpty(this.textBox12.Text))
                {
                    MessageBox.Show("StrUserID, Passowrd, sec_primary or sec_content mustn't be empty.", "Caution");
                }
                else if (QueryChecks.containsQuotes(this.textBox13.Text) || QueryChecks.containsQuotes(this.textBox7.Text))
                {
                    MessageBox.Show("StrUserID or Password contains quotes (' or \" symbols). It's not allowed.", "Caution");
                }
                else
                {
                    if (this.textBox7.Text == "MD5 Encrypted")
                    {
                        new SqlCommand("Update TB_User Set StrUserID = '" + this.textBox13.Text + "' , Email = '" + this.textBox8.Text + "' , sec_primary = '" + this.textBox9.Text + "' , sec_content = '" + this.textBox12.Text + "' Where StrUserID = '" + this.textBox5.Text + "'", sqlaccount).ExecuteNonQuery();
                        this.EditUserPanel.IsOpen = false;
                        this.textBox5.Text = null; this.panel34.Enabled = true;
                        MessageBox.Show("Account successfuly modified.", "Sucess");
                    }
                    else
                    {
                        new SqlCommand("Update TB_User Set StrUserID = '" + this.textBox13.Text + "' , password = '" + Crypt.getMD5(this.textBox7.Text) + "' , Email = '" + this.textBox8.Text + "' , sec_primary = '" + this.textBox9.Text + "' , sec_content = '" + this.textBox12.Text + "' Where StrUserID = '" + this.textBox5.Text + "'", sqlaccount).ExecuteNonQuery();
                        this.EditUserPanel.IsOpen = false;
                        this.textBox5.Text = null; this.panel34.Enabled = true;
                        MessageBox.Show("Account successfuly modified.", "Sucess");
                    }
                }
            }
            catch { }
        }
        // Add punishment
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (QueryChecks.containsQuotes(this.textBox4.Text))
                {
                    MessageBox.Show("Username field contains ' or \" symbols. It isn't allowed.", "Caution");
                }
                else if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
                {
                    MessageBox.Show("Punishment begin time is bigger as punishment end time. This isn't possible.", "Caution");
                }
                else if (this.textBox4.Text.Length < 1)
                {
                    MessageBox.Show("Username field is empty.");
                }
                else
                {
                    reader = new SqlCommand("Select * From TB_User Where StrUserID = '" + this.textBox4.Text + "'", sqlaccount).ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        reader = new SqlCommand("Declare @JID Int Set @JID = (Select JID From TB_User Where StrUserID = '" + this.textBox4.Text + "') IF Exists (Select * From _Punishment Where UserJID = @JID and Type = 1 and BlockEndTime > Getdate()) Or Exists (Select * From _BlockedUser Where UserJID = @JID and Type = 1 and timeEnd > Getdate()) Begin Select 'True' End", sqlaccount).ExecuteReader();
                        if (reader.Read())
                        {
                            MessageBox.Show("This username already banned.", "Caution");
                        }
                        else
                        {
                            new SqlCommand("Declare @JID Int , @Serial Int Set @JID = (Select JID From TB_User Where StrUserID = '" + this.textBox4.Text + "') Delete From _BlockedUser Where UserJID = @JID and Type = 1 Delete From _Punishment Where UserJID = @JID and Type = 1 Insert Into _Punishment (UserJID,Type,Executor,Shard,CharName,CharInfo,PosInfo,Guide,Description,RaiseTime,PunishTime,BlockStartTime,BlockEndTime,Status) Values (@JID,1,'MultiTool',0,'','','','Blocked by vSro Multi Tool','Blocked by vSro Multi Tool','" + this.dateTimePicker1.Text + "','" + this.dateTimePicker1.Text + "','" + this.dateTimePicker1.Text + "','" + this.dateTimePicker2.Text + "',0) Set @Serial = (Select Top 1 SerialNo From _Punishment Order by SerialNo Desc) Insert Into _BlockedUser Values (@JID,'" + this.textBox4.Text + "',1,@Serial,'" + this.dateTimePicker1.Text + "','" + this.dateTimePicker2.Text + "')", sqlaccount).ExecuteNonQuery();
                            this.textBox4.Text = null;
                            MessageBox.Show("Account successfully banned.", "Success");
                        }
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("This username doesn't exists.", "Caution");
                        reader.Close();
                    }
                }
            }
            catch { }
        }
        // Delete punishment
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (QueryChecks.containsQuotes(this.textBox3.Text))
                {
                    MessageBox.Show("Username field contains ' or \" symbols. It isn't allowed.", "Caution");
                }
                else if (this.textBox3.Text.Length < 1)
                {
                    MessageBox.Show("Username field is empty.");
                }
                else
                {
                    reader = new SqlCommand("Select * From TB_User Where StrUserID = '" + this.textBox3.Text + "'", sqlaccount).ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        reader = new SqlCommand("Declare @JID Int Set @JID = (Select JID From TB_User Where StrUserID = '" + this.textBox3.Text + "') IF Exists (Select * From _Punishment Where UserJID = @JID and Type = 1 and BlockEndTime > Getdate()) Or Exists (Select * From _BlockedUser Where UserJID = @JID and Type = 1 and timeEnd > Getdate()) Begin Select 'True' End", sqlaccount).ExecuteReader();
                        if (reader.Read())
                        {
                            new SqlCommand("Declare @JID Int , @Serial Int Set @JID = (Select JID From TB_User Where StrUserID = '" + this.textBox3.Text + "') Delete From _BlockedUser Where UserJID = @JID and Type = 1 Delete From _Punishment Where UserJID = @JID and Type = 1", sqlaccount).ExecuteNonQuery();
                            this.textBox3.Text = null;
                            MessageBox.Show("Account successfully unbanned.", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Punishment doesn't exists for this username.", "Caution");
                        }
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("This username doesn't exists.", "Caution");
                        reader.Close();
                    }
                }
            }
            catch { }
        }
        // Select users silk list
        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                string kind = null;
                if (this.own1.Checked == true) { kind = "silk_own"; }
                if (this.gift1.Checked == true) { kind = "silk_gift"; }
                if (this.point1.Checked == true) { kind = "silk_point"; }
                if (string.IsNullOrEmpty(kind))
                {
                    MessageBox.Show("You must choose a silk kind to arrange result.", "Caution");
                }
                else
                {
                    this.listView2.Items.Clear();
                    reader = new SqlCommand("Select S.JID,U.StrUserID,S.silk_own,S.silk_gift,S.silk_point From SK_Silk As S Inner Join TB_User As U ON U.JID = S.JID Order by S." + kind + " desc", sqlaccount).ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem lista = new ListViewItem(reader["JID"].ToString());
                        lista.SubItems.Add(reader["StrUserID"].ToString());
                        lista.SubItems.Add(reader["silk_own"].ToString());
                        lista.SubItems.Add(reader["silk_gift"].ToString());
                        lista.SubItems.Add(reader["silk_point"].ToString());
                        this.listView2.Items.Add(lista);
                    }
                    reader.Close();
                }
            }
            catch { }
        }
        // Silk amount numeric writing
        private void textboxNumberic_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
        // Add silk to one user
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                string kind = null;
                string Insert = null;
                if (this.own.Checked == true) { kind = "silk_own"; Insert = this.textBox14.Text + ",0,0"; }
                if (this.gift.Checked == true) { kind = "silk_gift"; Insert = "0," + this.textBox14.Text + ",0"; }
                if (this.point.Checked == true) { kind = "silk_point"; Insert = "0,0," + this.textBox14.Text; }
                if (string.IsNullOrEmpty(kind))
                {
                    MessageBox.Show("You must choose a silk kind before adding silks.", "Caution");
                }
                else if (string.IsNullOrEmpty(this.textBox15.Text) || string.IsNullOrEmpty(this.textBox14.Text))
                {
                    MessageBox.Show("You must fill username and amount fields before adding silks.", "Caution");
                }
                else if (QueryChecks.containsQuotes(this.textBox15.Text))
                {
                    MessageBox.Show("Username field contains ' or \" symbols. It isn't allowed.", "Caution");
                }
                else
                {
                    reader = new SqlCommand("Select * From TB_User Where StrUserID = '" + this.textBox15.Text + "'", sqlaccount).ExecuteReader();
                    if (reader.Read())
                    {
                        string JID = reader["JID"].ToString();
                        DialogResult dialogResult = MessageBox.Show("[" + this.textBox14.Text + " Silk] will be added to [" + this.textBox15.Text + "] , press yes to proceed.", "Confirmation", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            new SqlCommand("IF Exists (Select * From SK_Silk Where JID = " + JID + ") Begin Update SK_Silk Set " + kind + " = " + kind + " + " + this.textBox14.Text + " Where JID = " + JID + " End Else Begin Insert Into SK_Silk Values (" + JID + "," + Insert + ") End", sqlaccount).ExecuteNonQuery();
                            MessageBox.Show(this.textBox14.Text + " silk has been added to " + this.textBox15.Text + ".", "Success");
                            this.textBox14.Text = null; this.textBox15.Text = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("This username doesn't exists.", "Caution");
                    }
                    reader.Close();
                }
            }
            catch { }
        }
        // Add silk amount for all users
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                string kind = null;
                string Insert = null;
                if (this.own.Checked == true) { kind = "silk_own"; Insert = this.textBox14.Text + ",0,0"; }
                if (this.gift.Checked == true) { kind = "silk_gift"; Insert = "0," + this.textBox14.Text + ",0"; }
                if (this.point.Checked == true) { kind = "silk_point"; Insert = "0,0," + this.textBox14.Text; }
                if (string.IsNullOrEmpty(kind))
                {
                    MessageBox.Show("You must choose a silk kind before adding silks.", "Caution");
                }
                else if (string.IsNullOrEmpty(this.textBox14.Text))
                {
                    MessageBox.Show("You must fill silk amount field before adding silks.", "Caution");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("[" + this.textBox14.Text + " Silk] will be added to all users , becareful, Are you sure to proceed?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        new SqlCommand("IF Exists (Select * From SK_Silk) Begin Update SK_Silk Set " + kind + " = " + kind + " + " + this.textBox14.Text + " End Insert Into SK_Silk (JID,silk_own,silk_gift,silk_point) Select U.JID," + Insert + " From TB_User As U Where U.JID Not In (Select S.JID From SK_Silk As S)", sqlaccount).ExecuteNonQuery();
                        MessageBox.Show(this.textBox14.Text + " silk has been added to all users.", "Success");
                        this.textBox14.Text = null; this.textBox15.Text = null;
                    }
                }
            }
            catch { }
        }
        // Subtract silk from user
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                string kind = null;
                if (this.own.Checked == true) { kind = "silk_own"; }
                if (this.gift.Checked == true) { kind = "silk_gift"; }
                if (this.point.Checked == true) { kind = "silk_point"; }
                if (string.IsNullOrEmpty(kind))
                {
                    MessageBox.Show("You must choose a silk kind before subtracting silks.", "Caution");
                }
                else if (string.IsNullOrEmpty(this.textBox15.Text) || string.IsNullOrEmpty(this.textBox14.Text))
                {
                    MessageBox.Show("You must fill username and amount fields before subtracting silks.", "Caution");
                }
                else if (QueryChecks.containsQuotes(this.textBox15.Text))
                {
                    MessageBox.Show("Username field contains ' or \" symbols. It isn't allowed.", "Caution");
                }
                else
                {
                    reader = new SqlCommand("Select * From TB_User Where StrUserID = '" + this.textBox15.Text + "'", sqlaccount).ExecuteReader();
                    if (reader.Read())
                    {
                        string JID = reader["JID"].ToString();
                        reader.Close();
                        reader = new SqlCommand("Select * From SK_Silk Where JID = '" + JID + "' and " + kind + " >= '" + this.textBox14.Text + "'", sqlaccount).ExecuteReader();
                        if (reader.Read())
                        {
                            DialogResult dialogResult = MessageBox.Show("[" + this.textBox14.Text + " Silk] will be subtracted from [" + this.textBox15.Text + "] , press yes to proceed.", "Confirmation", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                new SqlCommand("Update SK_Silk Set " + kind + " = " + kind + " - " + this.textBox14.Text + " Where JID = " + JID, sqlaccount).ExecuteNonQuery();
                                MessageBox.Show(this.textBox14.Text + " silk has been subtracted from " + this.textBox15.Text + ".", "Success");
                                this.textBox14.Text = null; this.textBox15.Text = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("This username doesn't has enough silk for subtract.", "Caution");
                        }
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("This username doesn't exists.", "Caution");
                        reader.Close();
                    }
                }
            }
            catch { }
        }
        // Subtract silk from all users
        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                string kind = null;
                if (this.own.Checked == true) { kind = "silk_own"; }
                if (this.gift.Checked == true) { kind = "silk_gift"; }
                if (this.point.Checked == true) { kind = "silk_point"; }
                if (string.IsNullOrEmpty(kind))
                {
                    MessageBox.Show("You must choose a silk kind before subtracting silks.", "Caution");
                }
                else if (string.IsNullOrEmpty(this.textBox14.Text))
                {
                    MessageBox.Show("You must fill silk amount field before subtracting silks.", "Caution");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("[" + this.textBox14.Text + " Silk] will be subtracted from all users , becareful, Are you sure to proceed?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        reader = new SqlCommand("Select * From SK_Silk Where " + kind + " < '" + this.textBox14.Text + "'", sqlaccount).ExecuteReader();
                        if (reader.Read())
                        {
                            DialogResult dialogResult1 = MessageBox.Show("There are some of users has no enough silks for subtracting, Do you want to set them to 0 silks?", "Confirmation", MessageBoxButtons.YesNo);
                            if (dialogResult1 == DialogResult.Yes)
                            {

                                new SqlCommand("Update SK_Silk Set " + kind + " = '0' Where " + kind + " < '" + this.textBox14.Text + "'", sqlaccount).ExecuteNonQuery();
                                new SqlCommand("Update SK_Silk Set " + kind + " = " + kind + " - '" + this.textBox14.Text + "' Where " + kind + " >= '" + this.textBox14.Text + "'", sqlaccount).ExecuteNonQuery();
                                MessageBox.Show(this.textBox14.Text + " silk has been subtracted from all users.", "Success");
                                this.textBox14.Text = null; this.textBox15.Text = null;
                            }
                            else if (dialogResult1 == DialogResult.No)
                            {
                                new SqlCommand("Update SK_Silk Set " + kind + " = " + kind + " - '" + this.textBox14.Text + "' Where " + kind + " >= '" + this.textBox14.Text + "'", sqlaccount).ExecuteNonQuery();
                                MessageBox.Show(this.textBox14.Text + " silk has been subtracted from all users which has silk >= " + this.textBox14.Text, "Success");
                                this.textBox14.Text = null; this.textBox15.Text = null;
                            }
                        }
                        else
                        {
                            new SqlCommand("Update SK_Silk Set " + kind + " = " + kind + " - '" + this.textBox14.Text + "' Where " + kind + " >= '" + this.textBox14.Text + "'", sqlaccount).ExecuteNonQuery();
                            MessageBox.Show(this.textBox14.Text + " silk has been subtracted from all users.", "Success");
                            this.textBox14.Text = null; this.textBox15.Text = null;
                        }
                        reader.Close();
                    }
                }
            }
            catch { }
        }
        // search user characters
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBox16.Text))
                {
                    MessageBox.Show("You must fill username field before start search.", "Caution");
                }
                else if (QueryChecks.containsQuotes(this.textBox16.Text))
                {
                    MessageBox.Show("Username field contains ' or \" symbols. It isn't allowed.", "Caution");
                }
                else
                {
                    reader = new SqlCommand("Select * From TB_User Where StrUserID = '" + this.textBox16.Text + "'", sqlaccount).ExecuteReader();
                    if (reader.Read())
                    {
                        string JID = reader["JID"].ToString();
                        reader.Close();
                        this.comboBox1.Items.Clear();
                        reader = new SqlCommand("Select C.CharName16 From _Char As C Inner Join _User As U ON U.CharID = C.CharID Where U.UserJID = '" + JID + "'", sqlshard).ExecuteReader();
                        while (reader.Read())
                        {
                            this.comboBox1.Items.Add(reader["CharName16"].ToString());
                        }
                        this.panel45.Enabled = false; this.panel6.IsOpen = true;
                    }
                    else
                    {
                        MessageBox.Show("This username doesn't exists.", "Caution");
                    }
                    reader.Close();
                }
            }
            catch { }
        }
        // another search [reset]
        private void button22_Click(object sender, EventArgs e)
        {
            this.panel45.Enabled = true; this.panel47.IsOpen = false; this.panel6.IsOpen = false;
            this.comboBox1.Items.Clear(); this.comboBox1.Text = null; this.textBox16.Text = null;
        }
        // character information view by combobox index change
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                reader = new SqlCommand("Select C.CharID,C.RefObjID,C.NickName16,G.Name,C.CurLevel,C.Strength,C.Intellect,C.RemainGold From _Char As C Inner Join _Guild As G ON G.ID = C.GuildID Where C.CharName16 = '" + this.comboBox1.Text + "'", sqlshard).ExecuteReader();
                if (reader.Read())
                {
                    this.CharName16.Text = this.comboBox1.Text;
                    this.CharID.Text = reader["CharID"].ToString();
                    this.NickName16.Text = reader["NickName16"].ToString();
                    this.GuildName.Text = reader["Name"].ToString();
                    this.CurrLevel.Text = reader["CurLevel"].ToString();
                    this.CharStr.Text = reader["Strength"].ToString();
                    this.CharInt.Text = reader["Intellect"].ToString();
                    this.CharGold.Text = reader["RemainGold"].ToString();
                    this.CharacterImage((int)reader["RefObjID"], this.pictureBox3);
                    this.panel47.IsOpen = true;
                }
                else
                {
                    this.panel47.IsOpen = false;
                    MessageBox.Show("Something went wrong please report to the developer.", "Caution");
                }
                reader.Close();
            }
            catch { }
        }
        // change image by refobjid
        private void CharacterImage(int CharObjID, PictureBox Target)
        {
           
            if (CharObjID == 1907) { Target.Image =  MangerSroApp.Properties.Resource1._1907; }
            if (CharObjID == 1908) { Target.Image =  MangerSroApp.Properties.Resource1._1908; }
            if (CharObjID == 1909) { Target.Image =  MangerSroApp.Properties.Resource1._1909; }
            if (CharObjID == 1910) { Target.Image =  MangerSroApp.Properties.Resource1._1910; }
            if (CharObjID == 1911) { Target.Image =  MangerSroApp.Properties.Resource1._1911; }
            if (CharObjID == 1912) { Target.Image =  MangerSroApp.Properties.Resource1._1912; }
            if (CharObjID == 1913) { Target.Image =  MangerSroApp.Properties.Resource1._1913; }
            if (CharObjID == 1914) { Target.Image =  MangerSroApp.Properties.Resource1._1914; }
            if (CharObjID == 1915) { Target.Image =  MangerSroApp.Properties.Resource1._1915; }
            if (CharObjID == 1916) { Target.Image =  MangerSroApp.Properties.Resource1._1916; }
            if (CharObjID == 1917) { Target.Image =  MangerSroApp.Properties.Resource1._1917; }
            if (CharObjID == 1918) { Target.Image =  MangerSroApp.Properties.Resource1._1918; }
            if (CharObjID == 1919) { Target.Image =  MangerSroApp.Properties.Resource1._1919; }
            if (CharObjID == 1920) { Target.Image =  MangerSroApp.Properties.Resource1._1920; }
            if (CharObjID == 1921) { Target.Image =  MangerSroApp.Properties.Resource1._1921; }
            if (CharObjID == 1922) { Target.Image =  MangerSroApp.Properties.Resource1._1922; }
            if (CharObjID == 1923) { Target.Image =  MangerSroApp.Properties.Resource1._1923; }
            if (CharObjID == 1924) { Target.Image =  MangerSroApp.Properties.Resource1._1924; }
            if (CharObjID == 1925) { Target.Image =  MangerSroApp.Properties.Resource1._1925; }
            if (CharObjID == 1926) { Target.Image =  MangerSroApp.Properties.Resource1._1926; }
            if (CharObjID == 1927) { Target.Image =  MangerSroApp.Properties.Resource1._1927; }
            if (CharObjID == 1928) { Target.Image =  MangerSroApp.Properties.Resource1._1928; }
            if (CharObjID == 1929) { Target.Image =  MangerSroApp.Properties.Resource1._1929; }
            if (CharObjID == 1930) { Target.Image =  MangerSroApp.Properties.Resource1._1930; }
            if (CharObjID == 1931) { Target.Image =  MangerSroApp.Properties.Resource1._1931; }
            if (CharObjID == 1932) { Target.Image =  MangerSroApp.Properties.Resource1._1932; }
            if (CharObjID == 14875) { Target.Image =  MangerSroApp.Properties.Resource1._14875; }
            if (CharObjID == 14876) { Target.Image =  MangerSroApp.Properties.Resource1._14876; }
            if (CharObjID == 14877) { Target.Image =  MangerSroApp.Properties.Resource1._14877; }
            if (CharObjID == 14878) { Target.Image =  MangerSroApp.Properties.Resource1._14878; }
            if (CharObjID == 14879) { Target.Image =  MangerSroApp.Properties.Resource1._14879; }
            if (CharObjID == 14880) { Target.Image =  MangerSroApp.Properties.Resource1._14880; }
            if (CharObjID == 14881) { Target.Image =  MangerSroApp.Properties.Resource1._14881; }
            if (CharObjID == 14882) { Target.Image =  MangerSroApp.Properties.Resource1._14882; }
            if (CharObjID == 14883) { Target.Image =  MangerSroApp.Properties.Resource1._14883; }
            if (CharObjID == 14884) { Target.Image =  MangerSroApp.Properties.Resource1._14884; }
            if (CharObjID == 14885) { Target.Image =  MangerSroApp.Properties.Resource1._14885; }
            if (CharObjID == 14886) { Target.Image =  MangerSroApp.Properties.Resource1._14886; }
            if (CharObjID == 14887) { Target.Image =  MangerSroApp.Properties.Resource1._14887; }
            if (CharObjID == 14888) { Target.Image =  MangerSroApp.Properties.Resource1._14888; }
            if (CharObjID == 14889) { Target.Image =  MangerSroApp.Properties.Resource1._14889; }
            if (CharObjID == 14890) { Target.Image =  MangerSroApp.Properties.Resource1._14890; }
            if (CharObjID == 14891) { Target.Image =  MangerSroApp.Properties.Resource1._14891; }
            if (CharObjID == 14892) { Target.Image =  MangerSroApp.Properties.Resource1._14892; }
            if (CharObjID == 14893) { Target.Image =  MangerSroApp.Properties.Resource1._14893; }
            if (CharObjID == 14894) { Target.Image =  MangerSroApp.Properties.Resource1._14894; }
            if (CharObjID == 14895) { Target.Image =  MangerSroApp.Properties.Resource1._14895; }
            if (CharObjID == 14896) { Target.Image =  MangerSroApp.Properties.Resource1._14896; }
            if (CharObjID == 14897) { Target.Image =  MangerSroApp.Properties.Resource1._14897; }
            if (CharObjID == 14898) { Target.Image =  MangerSroApp.Properties.Resource1._14898; }
            if (CharObjID == 14899) { Target.Image =  MangerSroApp.Properties.Resource1._14899; }
            if (CharObjID == 14900) { Target.Image =  MangerSroApp.Properties.Resource1._14900; }
        }
        // search for gm users
        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBox17.Text) || string.IsNullOrEmpty(this.textBox18.Text))
                {
                    MessageBox.Show("You must fill sec_primary and sec_content fields before start search.", "Caution");
                }
                else
                {
                    reader = new SqlCommand("Select * From TB_User Where sec_primary = '" + this.textBox17.Text + "' and sec_content = '" + this.textBox18.Text + "'", sqlaccount).ExecuteReader();
                    this.textBox17.Text = null; this.textBox18.Text = null; this.listView3.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem lista = new ListViewItem(reader["JID"].ToString());
                        lista.SubItems.Add(reader["StrUserID"].ToString());
                        lista.SubItems.Add(reader["sec_primary"].ToString());
                        lista.SubItems.Add(reader["sec_content"].ToString());
                        this.listView3.Items.Add(lista);
                    }
                    reader.Close();
                }
            }
            catch { }
        }
        // search charname (manage character statics)
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.CNameSearch.Text))
                {
                    MessageBox.Show("You must fill Character name field before start search.", "Caution");
                }
                else
                {
                    reader = new SqlCommand("Select C.CharID,C.RefObjID,C.CharName16,C.NickName16,J.JobType,J.Level,C.CurLevel,C.MaxLevel,C.RemainGold,C.ExpOffset,C.RemainSkillPoint,C.Strength,C.Intellect,C.RemainStatPoint,C.InventorySize,C.HwanLevel From _Char As C Inner Join _CharTrijob As J ON C.CharID = J.CharID Where C.CharName16 = '" + this.CNameSearch.Text + "'", sqlshard).ExecuteReader();
                    if (reader.Read())
                    {
                        this.CID.Text = reader["CharID"].ToString();
                        this.CName16.Text = reader["CharName16"].ToString();
                        this.NkName16.Text = reader["NickName16"].ToString();
                        this.JobType.Text = reader["JobType"].ToString();
                        this.JobLvl.Text = reader["Level"].ToString();
                        this.CurLvl.Text = reader["CurLevel"].ToString();
                        this.MaxLvl.Text = reader["MaxLevel"].ToString();
                        this.RGold.Text = reader["RemainGold"].ToString();
                        this.Exp.Text = reader["ExpOffset"].ToString();
                        this.Sp.Text = reader["RemainSkillPoint"].ToString();
                        this.CStr.Text = reader["Strength"].ToString();
                        this.CInt.Text = reader["Intellect"].ToString();
                        this.StatPoint.Text = reader["RemainStatPoint"].ToString();
                        this.InvSize.Text = reader["InventorySize"].ToString();
                        this.HwanLvl.Text = reader["HwanLevel"].ToString();
                        this.CharacterImage((int)reader["RefObjID"], this.pictureBox5);
                        this.panel67.Enabled = false; this.panel57.IsOpen = true;
                    }
                    else
                    {
                        this.panel57.IsOpen = false;
                        MessageBox.Show("Character with this name doesn't exists.", "Caution");
                    }
                    reader.Close();
                }
            }
            catch { MessageBox.Show("Error has occurred, report to the developer.", "Caution"); }
        }
        // manage character statics cancel
        private void button26_Click(object sender, EventArgs e)
        {
            this.CNameSearch.Text = null; this.panel67.Enabled = true;
            this.panel57.IsOpen = false; this.pictureBox5.Image = null;
        }
        // manage character statics save changes
        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.CName16.Text) || string.IsNullOrEmpty(this.JobType.Text) || string.IsNullOrEmpty(this.JobLvl.Text) || string.IsNullOrEmpty(this.CurLvl.Text) || string.IsNullOrEmpty(this.MaxLvl.Text) || string.IsNullOrEmpty(this.RGold.Text) || string.IsNullOrEmpty(this.Exp.Text) || string.IsNullOrEmpty(this.Sp.Text) || string.IsNullOrEmpty(this.CStr.Text) || string.IsNullOrEmpty(this.CInt.Text) || string.IsNullOrEmpty(this.StatPoint.Text) || string.IsNullOrEmpty(this.InvSize.Text) || string.IsNullOrEmpty(this.HwanLvl.Text))
                {
                    MessageBox.Show("You must fill these field before save changes :"
                        + Environment.NewLine + "CharName16"
                        + Environment.NewLine + "Job Type"
                        + Environment.NewLine + "Job Level"
                        + Environment.NewLine + "Current Lvl"
                        + Environment.NewLine + "Max Lvl"
                        + Environment.NewLine + "RemainGold"
                        + Environment.NewLine + "Experience"
                        + Environment.NewLine + "Skill Points"
                        + Environment.NewLine + "Strength"
                        + Environment.NewLine + "Intellect"
                        + Environment.NewLine + "Stat Points"
                        + Environment.NewLine + "InventorySize"
                        + Environment.NewLine + "Hwan Level", "Caution");
                }
                else
                {
                    reader = new SqlCommand("Select * From _Char Where CharID != '" + this.CID.Text + "' and (((CharName16 = '" + this.CName16.Text + "' Or CharName16 = '" + this.NkName16.Text + "') and CharName16 != '') Or ((NickName16 = '" + this.CName16.Text + "' Or NickName16 = '" + this.NkName16.Text + "') and NickName16 != ''))", sqlshard).ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("CharName16 or NickName16 not valid or already used, enter another name.", "Caution");
                    }
                    else
                    {
                        new SqlCommand("Declare @CharID Int = '" + this.CID.Text + "' Update _Char Set CharName16 = '" + this.CName16.Text + "',NickName16 = '" + this.NkName16.Text + "',CurLevel = '" + this.CurLvl.Text + "',MaxLevel = '" + this.MaxLvl.Text + "',RemainGold = '" + this.RGold.Text + "',ExpOffset = '" + this.Exp.Text + "',RemainSkillPoint = '" + this.Sp.Text + "',Strength = '" + this.CStr.Text + "',Intellect = '" + this.CInt.Text + "',RemainStatPoint = '" + this.StatPoint.Text + "',InventorySize = '" + this.InvSize.Text + "',HwanLevel = '" + this.HwanLvl.Text + "' Where CharID = @CharID Update _CharTrijob Set JobType = '" + this.JobType.Text + "' , Level = '" + this.JobLvl.Text + "' Where CharID = @CharID", sqlshard).ExecuteNonQuery();
                        this.CNameSearch.Text = null; this.panel67.Enabled = true;
                        this.panel57.IsOpen = false; this.pictureBox5.Image = null;
                        MessageBox.Show("Character statics successfuly modified.", "Success");
                    }
                    reader.Close();
                }
            }
            catch { MessageBox.Show("Error has occurred, report to the developer.", "Caution"); }
        }
        // Collection Book Search
        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.textBox20.Text))
                {
                    MessageBox.Show("You must fill Character name field before start search.", "Caution");
                }
                else
                {
                    reader = new SqlCommand("Select CharID From _Char Where CharName16 = '" + this.textBox20.Text + "'", sqlshard).ExecuteReader();
                    if (reader.Read())
                    {
                        this.panel69.Enabled = false; this.panel60.IsOpen = true;
                        this.Togui.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("Character with this name doesn't exists.", "Caution");
                    }
                    reader.Close();
                }
            }
            catch { }
        }
        // Collection Book Back
        private void button30_Click(object sender, EventArgs e)
        {
            this.panel69.Enabled = true; this.panel60.IsOpen = false;
            this.Togui.Checked = false; this.Flame.Checked = false;
            this.Shipwreck1.Checked = false; this.Shipwreck2.Checked = false;
            this.textBox20.Text = null; this.ThemeName.Text = null;
            this.TalismanName.Text = null; this.TalismanImageClear();
        }
        // Talisman themes changed
        private void ThemeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TalismanName.Items.Clear();
            this.TalismanName.Text = null;
            switch (this.ThemeName.Text)
            {
                case "Togui Village - The Phantom of the Crimson Blood":
                    this.TalismanName.Items.Add("Red tears"); this.TalismanName.Items.Add("Western Scriptures");
                    this.TalismanName.Items.Add("Togui mask"); this.TalismanName.Items.Add("Red talisman");
                    this.TalismanName.Items.Add("Puppet"); this.TalismanName.Items.Add("Dull kitchen knife");
                    this.TalismanName.Items.Add("Spell paper"); this.TalismanName.Items.Add("Elder staff");
                    break;
                case "Flame Mountain - The Burning Abyss":
                    this.TalismanName.Items.Add("Fire flower"); this.TalismanName.Items.Add("Horned cattle");
                    this.TalismanName.Items.Add("Flame of oblivion"); this.TalismanName.Items.Add("Flame paper");
                    this.TalismanName.Items.Add("Hearthstone flame"); this.TalismanName.Items.Add("Enchantress necklace");
                    this.TalismanName.Items.Add("Honghaeah armor"); this.TalismanName.Items.Add("Fire dragon sword");
                    break;
                case "Shipwreck - The Green Abyss":
                    this.TalismanName.Items.Add("Silver pendant"); this.TalismanName.Items.Add("Cobalt emerald");
                    this.TalismanName.Items.Add("Logbook"); this.TalismanName.Items.Add("Love letter");
                    this.TalismanName.Items.Add("Portrait of a Woman"); this.TalismanName.Items.Add("Jewelry box");
                    this.TalismanName.Items.Add("Diamond watch"); this.TalismanName.Items.Add("Mermaid's tears");
                    break;
                case "Shipwreck - The Sea of Resentment":
                    this.TalismanName.Items.Add("Broken key"); this.TalismanName.Items.Add("Large tong");
                    this.TalismanName.Items.Add("Phantom harp"); this.TalismanName.Items.Add("Evil's heart");
                    this.TalismanName.Items.Add("Vindictive spirit's bead"); this.TalismanName.Items.Add("Hook hand");
                    this.TalismanName.Items.Add("Commander's patch"); this.TalismanName.Items.Add("Sereness's tears");
                    break;
            }
        }
        // Talisman theme select (Togui Village)
        private void Togui_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Togui.Checked == true)
                {
                    this.TalismanImageClear();
                    reader = new SqlCommand("Select * From _CharCollectionBook Where ThemeID = 1 and CharID = (Select CharID From _Char Where CharName16 = '" + this.textBox20.Text + "')", sqlshard).ExecuteReader();
                    while (reader.Read())
                    {
                        this.TalismanImage((int)reader["ThemeID"], (int)reader["SlotIndex"]);
                    }
                }
            }
            catch { }
        }
        // Talisman theme select (Flame Mountain)
        private void Flame_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Flame.Checked == true)
                {
                    this.TalismanImageClear();
                    reader = new SqlCommand("Select * From _CharCollectionBook Where ThemeID = 2 and CharID = (Select CharID From _Char Where CharName16 = '" + this.textBox20.Text + "')", sqlshard).ExecuteReader();
                    while (reader.Read())
                    {
                        this.TalismanImage((int)reader["ThemeID"], (int)reader["SlotIndex"]);
                    }
                }
            }
            catch { }
        }
        // Talisman theme select (Shipwreck - The Green Abyss)
        private void Shipwreck1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Shipwreck1.Checked == true)
                {
                    this.TalismanImageClear();
                    reader = new SqlCommand("Select * From _CharCollectionBook Where ThemeID = 3 and CharID = (Select CharID From _Char Where CharName16 = '" + this.textBox20.Text + "')", sqlshard).ExecuteReader();
                    while (reader.Read())
                    {
                        this.TalismanImage((int)reader["ThemeID"], (int)reader["SlotIndex"]);
                    }
                }
            }
            catch { }
        }
        // Talisman theme select (Shipwreck - The Sea of Resentment)
        private void Shipwreck2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Shipwreck2.Checked == true)
                {
                    this.TalismanImageClear();
                    reader = new SqlCommand("Select * From _CharCollectionBook Where ThemeID = 4 and CharID = (Select CharID From _Char Where CharName16 = '" + this.textBox20.Text + "')", sqlshard).ExecuteReader();
                    while (reader.Read())
                    {
                        this.TalismanImage((int)reader["ThemeID"], (int)reader["SlotIndex"]);
                    }
                }
            }
            catch { }
        }
        // clear all talisman images
        private void TalismanImageClear()
        {
            this.pictureBox7.Image = this.pictureBox8.Image = this.pictureBox9.Image = this.pictureBox10.Image =
            this.pictureBox11.Image = this.pictureBox12.Image = this.pictureBox13.Image = this.pictureBox14.Image =
             MangerSroApp.Properties.Resource1._0;
        }
        // change talisman images by reader loop
        private void TalismanImage(int Theme, int Talisman)
        {
            switch (Theme)
            {
                case 1:
                    if (Talisman == 1) { this.pictureBox7.Image =  MangerSroApp.Properties.Resource1._1_1; }
                    if (Talisman == 2) { this.pictureBox8.Image =  MangerSroApp.Properties.Resource1._1_2; }
                    if (Talisman == 3) { this.pictureBox9.Image =  MangerSroApp.Properties.Resource1._1_3; }
                    if (Talisman == 4) { this.pictureBox10.Image =  MangerSroApp.Properties.Resource1._1_4; }
                    if (Talisman == 5) { this.pictureBox11.Image =  MangerSroApp.Properties.Resource1._1_5; }
                    if (Talisman == 6) { this.pictureBox12.Image =  MangerSroApp.Properties.Resource1._1_6; }
                    if (Talisman == 7) { this.pictureBox13.Image =  MangerSroApp.Properties.Resource1._1_7; }
                    if (Talisman == 8) { this.pictureBox14.Image =  MangerSroApp.Properties.Resource1._1_8; }
                    break;
                case 2:
                    if (Talisman == 1) { this.pictureBox7.Image =  MangerSroApp.Properties.Resource1._2_1; }
                    if (Talisman == 2) { this.pictureBox8.Image =  MangerSroApp.Properties.Resource1._2_2; }
                    if (Talisman == 3) { this.pictureBox9.Image =  MangerSroApp.Properties.Resource1._2_3; }
                    if (Talisman == 4) { this.pictureBox10.Image =  MangerSroApp.Properties.Resource1._2_4; }
                    if (Talisman == 5) { this.pictureBox11.Image =  MangerSroApp.Properties.Resource1._2_5; }
                    if (Talisman == 6) { this.pictureBox12.Image =  MangerSroApp.Properties.Resource1._2_6; }
                    if (Talisman == 7) { this.pictureBox13.Image =  MangerSroApp.Properties.Resource1._2_7; }
                    if (Talisman == 8) { this.pictureBox14.Image =  MangerSroApp.Properties.Resource1._2_8; }
                    break;
                case 3:
                    if (Talisman == 1) { this.pictureBox7.Image =  MangerSroApp.Properties.Resource1._3_1; }
                    if (Talisman == 2) { this.pictureBox8.Image =  MangerSroApp.Properties.Resource1._3_2; }
                    if (Talisman == 3) { this.pictureBox9.Image =  MangerSroApp.Properties.Resource1._3_3; }
                    if (Talisman == 4) { this.pictureBox10.Image =  MangerSroApp.Properties.Resource1._3_4; }
                    if (Talisman == 5) { this.pictureBox11.Image =  MangerSroApp.Properties.Resource1._3_5; }
                    if (Talisman == 6) { this.pictureBox12.Image =  MangerSroApp.Properties.Resource1._3_6; }
                    if (Talisman == 7) { this.pictureBox13.Image =  MangerSroApp.Properties.Resource1._3_7; }
                    if (Talisman == 8) { this.pictureBox14.Image =  MangerSroApp.Properties.Resource1._3_8; }
                    break;
                case 4:
                    if (Talisman == 1) { this.pictureBox7.Image =  MangerSroApp.Properties.Resource1._4_1; }
                    if (Talisman == 2) { this.pictureBox8.Image =  MangerSroApp.Properties.Resource1._4_2; }
                    if (Talisman == 3) { this.pictureBox9.Image =  MangerSroApp.Properties.Resource1._4_3; }
                    if (Talisman == 4) { this.pictureBox10.Image =  MangerSroApp.Properties.Resource1._4_4; }
                    if (Talisman == 5) { this.pictureBox11.Image =  MangerSroApp.Properties.Resource1._4_5; }
                    if (Talisman == 6) { this.pictureBox12.Image =  MangerSroApp.Properties.Resource1._4_6; }
                    if (Talisman == 7) { this.pictureBox13.Image =  MangerSroApp.Properties.Resource1._4_7; }
                    if (Talisman == 8) { this.pictureBox14.Image =  MangerSroApp.Properties.Resource1._4_8; }
                    break;
            }
        }
        // Add new talisman
        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.ThemeName.Text) || string.IsNullOrEmpty(this.TalismanName.Text))
                {
                    MessageBox.Show("You have to select theme and talisman that you want to add.", "Caution");
                }
                else
                {
                    reader = new SqlCommand("Select * From _CharCollectionBook Where ThemeID = '" + getThemeID(this.ThemeName.Text) + "' and SlotIndex = '" + getTalismanID(this.TalismanName.Text) + "' and CharID = (Select CharID From _Char Where CharName16 = '" + this.textBox20.Text + "')", sqlshard).ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show("Selected talisman already exists for this character.", "Caution");
                    }
                    else
                    {
                        new SqlCommand("Insert Into _CharCollectionBook (CharID,ThemeID,SlotIndex,RegDate) Select CharID,'" + getThemeID(this.ThemeName.Text) + "','" + getTalismanID(this.TalismanName.Text) + "',Getdate() From _Char Where CharName16 = '" + this.textBox20.Text + "'", sqlshard).ExecuteNonQuery();
                        if (this.Togui.Checked == true) { this.Togui.Checked = false; this.Togui.Checked = true; }
                        if (this.Flame.Checked == true) { this.Flame.Checked = false; this.Flame.Checked = true; }
                        if (this.Shipwreck1.Checked == true) { this.Shipwreck1.Checked = false; this.Shipwreck1.Checked = true; }
                        if (this.Shipwreck2.Checked == true) { this.Shipwreck2.Checked = false; this.Shipwreck2.Checked = true; }
                        MessageBox.Show("Selected talisman has been added to this character.", "Success");
                    }
                }
            }
            catch { }
        }
        // Remove exists talisman
        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.ThemeName.Text) || string.IsNullOrEmpty(this.TalismanName.Text))
                {
                    MessageBox.Show("You have to select theme and talisman that you want to remove.", "Caution");
                }
                else
                {
                    reader = new SqlCommand("Select * From _CharCollectionBook Where ThemeID = '" + getThemeID(this.ThemeName.Text) + "' and SlotIndex = '" + getTalismanID(this.TalismanName.Text) + "' and CharID = (Select CharID From _Char Where CharName16 = '" + this.textBox20.Text + "')", sqlshard).ExecuteReader();
                    if (reader.Read())
                    {
                        new SqlCommand("Delete From _CharCollectionBook Where ThemeID = '" + getThemeID(this.ThemeName.Text) + "' and SlotIndex = '" + getTalismanID(this.TalismanName.Text) + "' and CharID = (Select CharID From _Char Where CharName16 = '" + this.textBox20.Text + "')", sqlshard).ExecuteNonQuery();
                        if (this.Togui.Checked == true) { this.Togui.Checked = false; this.Togui.Checked = true; }
                        if (this.Flame.Checked == true) { this.Flame.Checked = false; this.Flame.Checked = true; }
                        if (this.Shipwreck1.Checked == true) { this.Shipwreck1.Checked = false; this.Shipwreck1.Checked = true; }
                        if (this.Shipwreck2.Checked == true) { this.Shipwreck2.Checked = false; this.Shipwreck2.Checked = true; }
                        MessageBox.Show("Selected talisman has been removed from this character.", "Success");
                    }
                    else
                    {
                        MessageBox.Show("Selected talisman doesn't exists for this character.", "Caution");
                    }
                }
            }
            catch { }
        }
        // convert theme name to database id
        private static string getThemeID(string text)
        {
            string Return = null;
            switch (text)
            {
                case "Togui Village - The Phantom of the Crimson Blood":
                    Return = "1";
                    break;
                case "Flame Mountain - The Burning Abyss":
                    Return = "2";
                    break;
                case "Shipwreck - The Green Abyss":
                    Return = "3";
                    break;
                case "Shipwreck - The Sea of Resentment":
                    Return = "4";
                    break;
            }
            return Return;
        }
        // convert talisman name to database id
        private static string getTalismanID(string text)
        {
            string Return = null;
            switch (text)
            {
                case "Red tears":
                case "Fire flower":
                case "Silver pendant":
                case "Broken key":
                    Return = "1";
                    break;
                case "Western Scriptures":
                case "Horned cattle":
                case "Cobalt emerald":
                case "Large tong":
                    Return = "2";
                    break;
                case "Togui mask":
                case "Flame of oblivion":
                case "Logbook":
                case "Phantom harp":
                    Return = "3";
                    break;
                case "Red talisman":
                case "Flame paper":
                case "Love letter":
                case "Evil's heart":
                    Return = "4";
                    break;
                case "Puppet":
                case "Hearthstone flame":
                case "Portrait of a Woman":
                case "Vindictive spirit's bead":
                    Return = "5";
                    break;
                case "Dull kitchen knife":
                case "Enchantress necklace":
                case "Jewelry box":
                case "Hook hand":
                    Return = "6";
                    break;
                case "Spell paper":
                case "Honghaeah armor":
                case "Diamond watch":
                case "Commander's patch":
                    Return = "7";
                    break;
                case "Elder staff":
                case "Fire dragon sword":
                case "Mermaid's tears":
                case "Sereness's tears":
                    Return = "8";
                    break;
            }
            return Return;
        }
        // style switcher slider
        private void slider1_ValueChanged(object sender, EventArgs e)
        {
            //witch (this.slider1.Value)
            //
            //   case 0:
            //       slider1Inc();
            //       this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue;
            //       break;
            //   case 1:
            //       slider1Inc();
            //       this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver;
            //       break;
            //   case 2:
            //       slider1Inc();
            //       this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black;
            //       break;
            //   case 3:
            //       slider1Inc();
            //       this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass;
            //       break;
            //   case 4:
            //       slider1Inc();
            //       this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver;
            //       break;
            //   case 5:
            //       slider1Inc();
            //       this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            //       break;
            //   case 6:
            //       slider1Inc();
            //       this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black;
            //       break;
            //   case 7:
            //       slider1Inc();
            //       this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Windows7Blue;
            //       break;
            //   case 8:
            //       this.slider1.Size = new System.Drawing.Size(131, 23);
            //       this.colorPickerButton2.Visible = true; this.colorPickerButton1.Visible = true;
            //       this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            //       break;
            //}
        }
        // slider size increase
        private void slider1Inc()
        {
            //   this.colorPickerButton2.Visible = false; this.colorPickerButton1.Visible = false;
            //   this.slider1.Size = new System.Drawing.Size(185, 23);
        }
        // color picker button of canvas color
        private void colorPickerButton1_SelectedColorChanged(object sender, EventArgs e)
        {
            //   this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(this.colorPickerButton1.SelectedColor, this.colorPickerButton2.SelectedColor);
        }
        // color picker button of base color
        private void colorPickerButton2_SelectedColorChanged(object sender, EventArgs e)
        {
            //  this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(this.colorPickerButton1.SelectedColor, this.colorPickerButton2.SelectedColor);
        }
        // expand panels
        private void ShowPanel(DevComponents.DotNetBar.Controls.SlidePanel panel)
        {
            panel.BringToFront();
            panel.IsOpen = true;
        }
        // shortened panels
        private void HidePanel(DevComponents.DotNetBar.Controls.SlidePanel panel)
        {
            panel.IsOpen = false;
        }
        // shortened all panels while form load
        private void HidePaneles()
        {
            this.panel6.IsOpen = false;
            this.panel47.IsOpen = false;
            this.EditUserPanel.IsOpen = false;
            this.panel57.IsOpen = false;
            this.panel60.IsOpen = false;
            // ------------------------
            // ------------------------
            this.MainFun.BringToFront();
            this.CharacterPanel.IsOpen = false;
            this.ManageCharPanel.IsOpen = false;
            this.CollectBookPanel.IsOpen = false;
            this.CharInvPanel.IsOpen = false;
            this.UserPanel.IsOpen = false;
            this.ManageUserPanel.IsOpen = false;
            this.SilkControlPanel.IsOpen = false;
            this.UserCharPanel.IsOpen = false;
            this.TeamUserPanel.IsOpen = false;
            this.NextUpdatePanel.IsOpen = false;
        }
        // characters button
        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.CharacterPanel);
        }
        // characters back button
        private void buttonX13_Click(object sender, EventArgs e)
        {
            this.HidePanel(this.CharacterPanel);
        }
        // manage characters button
        private void buttonX10_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.ManageCharPanel);
        }
        // manage characters back button
        private void buttonX14_Click(object sender, EventArgs e)
        {
            this.HidePanel(this.ManageCharPanel);
        }
        // collection book button
        private void buttonX11_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.CollectBookPanel);
        }
        // collection book back button
        private void buttonX15_Click(object sender, EventArgs e)
        {
            this.HidePanel(this.CollectBookPanel);
        }
        // char inventory button
        private void buttonX12_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.CharInvPanel);
        }
        // char inventory back button
        private void buttonX16_Click(object sender, EventArgs e)
        {
            this.HidePanel(this.CharInvPanel);
        }
        // users button
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.UserPanel);
        }
        // users back button
        private void buttonX17_Click(object sender, EventArgs e)
        {
            this.HidePanel(this.UserPanel);
        }
        // manage users button
        private void buttonX20_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.ManageUserPanel);
        }
        // manage users back button
        private void buttonX22_Click(object sender, EventArgs e)
        {
            this.HidePanel(this.ManageUserPanel);
        }
        // silk control button
        private void buttonX19_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.SilkControlPanel);
        }
        // silk control back button
        private void buttonX23_Click(object sender, EventArgs e)
        {
            this.HidePanel(this.SilkControlPanel);
        }
        // user characters button
        private void buttonX18_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.UserCharPanel);
        }
        // user characters back button
        private void buttonX24_Click(object sender, EventArgs e)
        {
            this.HidePanel(this.UserCharPanel);
        }
        // team users button
        private void buttonX21_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.TeamUserPanel);
        }
        // team users back button
        private void buttonX25_Click(object sender, EventArgs e)
        {
            this.HidePanel(this.TeamUserPanel);
        }
        // items button
        private void buttonX3_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.NextUpdatePanel);
        }
        // fortress war button
        private void buttonX7_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.NextUpdatePanel);
        }
        // monsters button
        private void buttonX8_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.NextUpdatePanel);
        }
        // guild - union button
        private void buttonX5_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.NextUpdatePanel);
        }
        // rates button
        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.NextUpdatePanel);
        }
        // fixing bugs button
        private void buttonX6_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.NextUpdatePanel);
        }
        // database cleaner button
        private void buttonX9_Click(object sender, EventArgs e)
        {
            this.ShowPanel(this.NextUpdatePanel);
        }
        // next update panel back button
        private void buttonX26_Click(object sender, EventArgs e)
        {
            this.HidePanel(this.NextUpdatePanel);
        }

        private void panel57_Load(object sender, EventArgs e)
        {

        }



















    }


    public class GlobalMouseHandler : IMessageFilter
    {
        private const int WM_MOUSEMOVE = 0x0200;
        private System.Drawing.Point previousMousePosition = new System.Drawing.Point();
        public static event EventHandler<MouseEventArgs> MouseMovedEvent = delegate { };

        #region IMessageFilter Members

        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_MOUSEMOVE)
            {
                System.Drawing.Point currentMousePoint = Control.MousePosition;
                if (previousMousePosition != currentMousePoint)
                {
                    previousMousePosition = currentMousePoint;
                    MouseMovedEvent(this, new MouseEventArgs(MouseButtons.None, 0, currentMousePoint.X, currentMousePoint.Y, 0));
                }
            }
            // Always allow message to continue to the next filter control
            return false;
        }

        #endregion
    }

    internal class Crypt
    {
        public static string getMD5(string str)
        {
            MD5 mD = MD5.Create();
            byte[] array = mD.ComputeHash(Encoding.Default.GetBytes(str));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }

    internal class QueryChecks
    {
        public static bool containsQuotes(string query)
        {
            return query.Contains("'") || query.Contains("\"");
        }
    }
}
