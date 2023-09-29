using MangerSroApp.Tools.Bot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestBot.Model;

namespace TestBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MangerSroApp.Tools.Bot.Bot bot = new MangerSroApp.Tools.Bot.Bot();
            bot.BordcastBots += Bot_BordcastBots;
            bot.StartBot();
        }

        private void Bot_BordcastBots(string msg)
        {
            string Msg = msg;
            SetText(Msg + "\n");
        }


        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.Text = text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Sql.ConnectSqlServer())
            {
                var query = $"insert ref_Bot_Info values ('{txtCharname.Text}','{txtUserID.Text}','{txtPasswrod.Text}','User');";
                _ = new SqlCommand(query, Sql.sqlshardlog).ExecuteNonQuery();
            }
        }

        private void CharSelDropDown_DropDown(object sender, EventArgs e)
        {
            if (Sql.ConnectSqlServer())
            {

                string Query = "select*from ref_Bot_Info";
                List<InfoBot> infos = new List<InfoBot>();
                var reader = new SqlCommand(Query, Sql.sqlshardlog).ExecuteReader();
                while (reader.Read())
                {
                    infos.Add(new InfoBot()
                    {
                        // Charname,UserID,Passwrod,allyUser
                        AllyUser = (string)reader["allyUser"],
                        UserId = (string)reader["UserID"],
                        Passwrod = (string)reader["Passwrod"],
                        Charname = (string)reader["Charname"]
                    });
                }
                CharSelDropDown.DataSource = infos;
                CharSelDropDown.DisplayMember = "StrDli";
                CharSelDropDown.ValueMember = "Charname";
            }
        }
    }
}
