using MangerSroApp.ExtensionsClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp
{
    public partial class Test : Form
    {

        public Test()
        {
            InitializeComponent();
        }






        private void SoloEvent(object sender, EventArgs e)
        {
            if (sender is Button Gettxt)
            {
                Extensions.SetFunToolEvent(Type: Gettxt.Text);
            }
        }













        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox Cm)
            {

                //14; 99 Loc
                //370; 316 Size

                var Index = Cm.SelectedIndex;

                panel1.Controls.Clear();

                if (Index == 0) // Notice
                    panel1.Controls.AddRange(ControllerViews.BlockMessage(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                else if (Index == 1) // Message
                    panel1.Controls.AddRange(ControllerViews.BlockMessageAndTarget(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                else if (Index == 2) // Private
                    panel1.Controls.AddRange(ControllerViews.BlockMessageAndTarget(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                else if (Index == 3) // Public
                    panel1.Controls.AddRange(ControllerViews.BlockMessage(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                //else if (Index == 4) // Global
                //    comboBox1.SelectedIndex = -1;
                else if (Index == 5) // MoveGMToUser
                    panel1.Controls.AddRange(ControllerViews.BlockTarget(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                else if (Index == 6) // Recalluser
                    panel1.Controls.AddRange(ControllerViews.BlockTarget(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                else if (Index == 7) // Recallguild
                    panel1.Controls.AddRange(ControllerViews.BlockTarget(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                else if (Index == 8) // Totown
                    panel1.Controls.AddRange(ControllerViews.BlockTarget(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                else if (Index == 9) // Disconnect
                    panel1.Controls.AddRange(ControllerViews.BlockTarget(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                //else if (Index == 10) // Warp
                //    comboBox1.SelectedIndex = -1;
                else if (Index == 11) // Loadmonster
                    panel1.Controls.AddRange(ControllerViews.BlockLoadMonster(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                //else if (Index == 12) // Makeitem
                //    comboBox1.SelectedIndex = -1;
                else if (Index == 15) // Gotown
                    panel1.Controls.AddRange(ControllerViews.BlockTarget(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                else if (Index == 16) // GMskill
                    comboBox1.SelectedIndex = -1;
                else if (Index == 17) // PvpCape
                    panel1.Controls.AddRange(ControllerViews.BlockCapPVP(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                else if (Index == 18) // CreateStall
                    panel1.Controls.AddRange(ControllerViews.BlockCreateStall(comboBox1.Text, delegate { CloesSessoin(); }).ToArray());
                //else if (Index == 19) // AddStallItem
                //    comboBox1.SelectedIndex = -1;
                else
                    comboBox1.SelectedIndex = -1;
              
            }
        }

        private void CloesSessoin()
        {
            panel1.Controls.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }
    }
}
