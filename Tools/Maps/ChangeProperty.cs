using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.Tools.Maps
{
    public partial class ChangePropertyViews : Form
    {
        public MapModels MapModel = new MapModels();
        MapsBlocks CurBlock;
        public ChangePropertyViews(MapModels MapModel, MapsBlocks CurBlock)
        {
            InitializeComponent();
            this.MapModel = MapModel;
            this.CurBlock = CurBlock;
            txtMaxRowX.Text = MapModel.MaxRowX.ToString();
            txtMaxRowY.Text = MapModel.MaxRowY.ToString();
            txtSizeX.Text = MapModel.SizeItmes.Width.ToString(); 
            txtSizeY.Text = MapModel.SizeItmes.Height.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Save
            MapsBlocks.configDes = new MapModels()
            {
                SizeItmes = new Size(Convert.ToInt32(txtSizeX.Text), Convert.ToInt32(txtSizeY.Text)),
                MaxRowX = Convert.ToInt32(txtMaxRowX.Text),
                MaxRowY = Convert.ToInt32(txtMaxRowY.Text),
            };
            CurBlock.ChnageConig = true;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Back
            this.Dispose();
        }
    }
}
