using CSharpImageLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Image_Converter
{
    public partial class MainWindow : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        string[] ImageFileNames;
        string SaveFilePath;
        DialogResult result;
        Converter cs = new Converter();
        ImageEngineFormat FormatPNG = ImageEngineFormat.PNG;
        ImageEngineFormat FormatJPG = ImageEngineFormat.JPG;
        ImageEngineFormat FormatGIF = ImageEngineFormat.GIF;
        ImageEngineFormat FormatBMP = ImageEngineFormat.BMP;
        ImageEngineFormat FormatTIF = ImageEngineFormat.TIF;




        public MainWindow(string[] args)
        {
            InitializeComponent();
            if (args.Length != 0)
            {
                if (args[0] != "")
                {
                    LoadImage(args);
                }
            }
        }
        public void LoadImage(string[] v)
        {
            Bitmap image = cs.ConvertBitmap(v[0]);
            imageList1.Images.Clear();
            listView1.Items.Clear();
            ImageFileNames = v;
            foreach (string file in ImageFileNames) //.png, bmp, etc.
            {
                imageList1.Images.Add(image);
            }
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(32, 32);
            this.listView1.LargeImageList = this.imageList1;
            for (int j = 0; j < this.imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                this.listView1.Items.Add(item);
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.ddj, *.dds, *.png, *.jpg, *.jpeg *.bmp *.tif) | *.ddj; *.dds; *.png; *.jpg; *.jpeg; *.bmp; *.tif;"; ;
            dialog.RestoreDirectory = true;
            dialog.CheckFileExists = false;
            dialog.Title = "Resim Dosyası Seçiniz..";
            dialog.Multiselect = true;
            result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                imageList1.Images.Clear();
                listView1.Items.Clear();
                pictureBox1.Visible = false;
                listView1.Visible = true;
                ImageFileNames = null;
                ImageFileNames = dialog.FileNames;

                foreach (string file in ImageFileNames) //.png, bmp, etc.
                {
                    Bitmap image = cs.ConvertBitmap(file);
                    imageList1.Images.Add(image);
                }

                this.listView1.View = View.LargeIcon;
                this.imageList1.ImageSize = new Size(32, 32);
                this.listView1.LargeImageList = this.imageList1;
                for (int j = 0; j < this.imageList1.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    this.listView1.Items.Add(item);
                }
            }
            else
            {
                ImageFileNames = null;
            }

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            SaveFilePath = fd.SelectedPath;
            foreach (string file in ImageFileNames)
            {
                string FileNameWithOutExtension = Path.GetFileNameWithoutExtension(file.Split('\\').Last());
                Bitmap bm = cs.ConvertBitmap(file);
                if (dDJToolStripMenuItem.Checked == true)
                {
                    if (cs.GetExtension(file) != ".ddj")
                    {
                        cs.ConvertBitmapToDDJ(file, SaveFilePath);
                    }
                }
                else if (dDSToolStripMenuItem.Checked == true)
                {
                    if (cs.GetExtension(file) != ".dds")
                    {
                        cs.ConvertBitmapToDDS(file, SaveFilePath);
                    }
                }
                else if (pNGToolStripMenuItem.Checked == true)
                {
                    if (cs.GetExtension(file) != ".png")
                    {
                        cs.ConvertBitmapToImage(bm, file, SaveFilePath, FormatPNG, "png");
                    }
                }
                else if (bMPToolStripMenuItem.Checked == true)
                {
                    if (cs.GetExtension(file) != ".bmp")
                    {
                        cs.ConvertBitmapToImage(bm, file, SaveFilePath, FormatBMP, "bmp");
                    }
                }
                else if (jPGToolStripMenuItem.Checked == true)
                {
                    if (cs.GetExtension(file) != ".jpg" || cs.GetExtension(file) != ".jpeg")
                    {
                        cs.ConvertBitmapToImage(bm, file, SaveFilePath, FormatJPG, "jpg");
                    }
                }
                else if (gIFToolStripMenuItem.Checked == true)
                {
                    if (cs.GetExtension(file) != ".gif")
                    {
                        cs.ConvertBitmapToImage(bm, file, SaveFilePath, FormatGIF, "gif");
                    }
                }
                else if (tİFToolStripMenuItem.Checked == true)
                {
                    if (cs.GetExtension(file) != ".tif")
                    {
                        cs.ConvertBitmapToImage(bm, file, SaveFilePath, FormatTIF, "tif");
                    }
                }
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            ImageFileNames = null;

            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                    ImageFileNames = Directory.GetFiles(dialog.SelectedPath, "*.*", SearchOption.AllDirectories);
                else
                    ImageFileNames = null;
            }
            if (result == DialogResult.OK)
            {
                imageList1.Images.Clear();
                listView1.Items.Clear();
                foreach (string file in ImageFileNames) //.png, bmp, etc.
                {
                    Bitmap image = cs.ConvertBitmap(file);
                    imageList1.Images.Add(image);
                }
                this.listView1.View = View.LargeIcon;
                this.imageList1.ImageSize = new Size(32, 32);
                this.listView1.LargeImageList = this.imageList1;
                for (int j = 0; j < this.imageList1.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    this.listView1.Items.Add(item);
                }
            }
        }
        private void dDJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dDJToolStripMenuItem.Checked)
            {
                foreach (ToolStripMenuItem item in formatToolStripMenuItem.DropDownItems)
                {
                    item.Checked = false;
                }
                dDJToolStripMenuItem.Checked = true;
            }

        }
        private void dDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in formatToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            dDSToolStripMenuItem.Checked = true;
        }
        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in formatToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            pNGToolStripMenuItem.Checked = true;
        }
        private void bMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in formatToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            bMPToolStripMenuItem.Checked = true;
        }
        private void jPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in formatToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            jPGToolStripMenuItem.Checked = true;
        }
        private void gIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in formatToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            gIFToolStripMenuItem.Checked = true;
        }
        private void tİFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in formatToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            tİFToolStripMenuItem.Checked = true;
        }
        public int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }
        public void ListViewItem_SetSpacing(ListView listview, short leftPadding, short topPadding)
        {
            const int LVM_FIRST = 0x1000;
            const int LVM_SETICONSPACING = LVM_FIRST + 53;
            SendMessage(listview.Handle, LVM_SETICONSPACING, IntPtr.Zero, (IntPtr)MakeLong(leftPadding, topPadding));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListViewItem_SetSpacing(this.listView1, 30 + 18, 30 + 18);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
