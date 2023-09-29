using Image_Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.Tools.Maps
{
    public partial class MapsBlocks : System.Windows.Forms.Form
    {
        public static MapModels configDes = new MapModels()
        {
            MaxRowX = 26,
            MaxRowY = 50,
            SizeItmes = new System.Drawing.Size(50, 50)
        };

        string FilenameBlockedItems = "System.File.Remove.MAP.txt";


        Converter cs = new Converter();
        byte LineStartLog = 26;
        byte LineEndLog = 252;
        bool IsFristImage = true;
        //int XEn, YEn;
        string[,] File1 = new string[MapsBlocks.configDes.MaxRowX, MapsBlocks.configDes.MaxRowY];//, MapsBlocks.configDes.MaxRowY];


        public MapsBlocks()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            panel1.Controls.Clear();
            File1 = new string[MapsBlocks.configDes.MaxRowX, MapsBlocks.configDes.MaxRowY];
            string PathFolder = @"C:\VsroCap100\Vsro.188_cap100_IronSro.v2_package[TheRock2007]\PK2 Tool\Media\interface\worldmap\map\";
            //@"C:\VsroCap100\Vsro.188_cap100_IronSro.v2_package[TheRock2007]\PK2 Tool\Media\minimap\";

            int CountUI = 0;

            foreach (var item in System.IO.Directory.GetFiles(PathFolder))
            {
                //map_jupiter_a_235x122

                if (CountUI == configDes.MaxRowX * configDes.MaxRowY)
                {
                    break;
                }


                if (File.Exists(FilenameBlockedItems) && System.IO.File.ReadAllText(FilenameBlockedItems).Contains(System.IO.Path.GetFileName(item)))
                {
                    continue;
                }

                //245x109.ddj
                var ex = System.IO.Path.GetExtension(item);//.Split('.')[0].Split("_");

                if (ex != ".ddj" && ex != "ddj")
                {
                    continue;
                }
                CountUI += 1;
                bool OutFromArray = false;
                for (int x = 0; x < MapsBlocks.configDes.MaxRowX; x++)
                {
                    if (OutFromArray)
                        break;

                    for (int y = 0; y < MapsBlocks.configDes.MaxRowY; y++)
                    {
                        if (string.IsNullOrEmpty(File1[x, y]))
                        {
                            OutFromArray = true;
                            File1[x, y] = item;
                            AddImage(x, y, item);
                            break;
                        }
                    }
                }



            }


        }

        void AddImage(int X, int Y, string path)
        {

            int ImageX, ImageY, XEn = 0, YEn = 0;

            if (IsFristImage)
            {
                XEn = X;
                YEn = Y;
                IsFristImage = false;
            }


            ImageX = configDes.SizeItmes.Width * (X - XEn) + 1;
            ImageY = configDes.SizeItmes.Height * (Y - YEn) + 1;



            PictureBox pictureBox = new PictureBox()
            {
                Tag = path,
                Size = new System.Drawing.Size(configDes.SizeItmes.Width, configDes.SizeItmes.Height),
                Image = cs.ConvertBitmap(path),
                Location = new System.Drawing.Point(ImageX, ImageY),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            var Item = new System.Windows.Forms.ContextMenuStrip(this.components);
            var RemoveImage = new System.Windows.Forms.ToolStripMenuItem();
            var ShowItems = new System.Windows.Forms.ToolStripMenuItem();
            RemoveImage.Name = "Remove";
            RemoveImage.Size = new System.Drawing.Size(180, 22);
            RemoveImage.Text = "Remove";
            RemoveImage.Tag = path;
            RemoveImage.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            ShowItems.Name = "Show";
            ShowItems.Size = new System.Drawing.Size(180, 22);
            ShowItems.Text = "Show";
            ShowItems.Tag = path;
            ShowItems.Click += new System.EventHandler(delegate (object sender, EventArgs e)
            {
                if (sender is ToolStripMenuItem Get)
                {
                    MessageBox.Show(Get.Tag.ToString());
                }
            });
            Item.Tag = path;
            Item.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            RemoveImage,ShowItems});
            Item.Name = "Item";
            Item.Size = new System.Drawing.Size(181, 70);
            pictureBox.ContextMenuStrip = Item;
            pictureBox.ContextMenuStrip.Tag = path;
            pictureBox.MoveOnly(panel1);
            pictureBox.MoveOnly();
            panel1.Controls.Add(pictureBox);
        }

        public bool ChnageConig = false;

        private void changeProprtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePropertyViews changePropertyViews = new ChangePropertyViews(configDes, this);
            changePropertyViews.ShowDialog();
            if (ChnageConig)
            {
                LoadData();
                ChnageConig = false;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeProprtyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Sigmar One", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(681, 34);
            this.label3.TabIndex = 69;
            this.label3.Text = "Map Editer";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Sigmar One", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(701, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 34);
            this.label2.TabIndex = 68;
            this.label2.Text = "Back";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 442);
            this.panel1.TabIndex = 73;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeProprtyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 26);
            // 
            // changeProprtyToolStripMenuItem
            // 
            this.changeProprtyToolStripMenuItem.Name = "changeProprtyToolStripMenuItem";
            this.changeProprtyToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.changeProprtyToolStripMenuItem.Text = "ChangeProprty";
            this.changeProprtyToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.changeProprtyToolStripMenuItem.Click += new System.EventHandler(this.changeProprtyToolStripMenuItem_Click);
            // 
            // MapsBlocks
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(797, 502);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Sigmar One", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MapsBlocks";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem Get)
            {
                if (!File.Exists(FilenameBlockedItems))
                {
                    File.CreateText(FilenameBlockedItems).Close();
                }
                List<string> LineBlock = File.ReadAllLines(FilenameBlockedItems).ToList();
                LineBlock.Add(System.IO.Path.GetFileName(Get.Tag.ToString()));
                File.WriteAllLines(FilenameBlockedItems, LineBlock);
            }
        }
    }
}

