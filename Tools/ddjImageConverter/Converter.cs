using CSharpImageLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Converter
{
    class Converter
    {
        byte[] Header = { 0x4A, 0x4D, 0x58, 0x56, 0x44, 0x44, 0x4A, 0x20, 0x31, 0x30, 0x30, 0x30, 0x88, 0x80, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00 };
        ImageEngineFormat FormatDDS = ImageEngineFormat.DDS_ARGB_8;

        public void ConvertBitmapToDDJ(string FilePath, string SaveFilePath)
        {
            bool var = false;
            if (File.Exists(SaveFilePath + "\\" + Path.GetFileNameWithoutExtension(FilePath.Split('\\').Last()) + ".dds"))
            {
                var = true;
            }
            ImageEngineImage ImageEngine = new ImageEngineImage(FilePath);
            ImageFormats.ImageEngineFormatDetails ImageFormat = new ImageFormats.ImageEngineFormatDetails((FormatDDS));
            Task ts = ImageEngine.Save(SaveFilePath + "\\" + Path.GetFileNameWithoutExtension(FilePath.Split('\\').Last()) + ".dds", ImageFormat, MipHandling.Default, 0, 0, false);
            ImageEngine.Dispose();
            ts.ContinueWith(task =>
            {
                byte[] data = File.ReadAllBytes(SaveFilePath + "\\" + Path.GetFileNameWithoutExtension(FilePath.Split('\\').Last()) + ".dds");

                using (FileStream file = new FileStream(SaveFilePath + "\\" + Path.GetFileNameWithoutExtension(FilePath.Split('\\').Last()) + ".ddj", FileMode.OpenOrCreate))
                {
                    file.Write(Header, 0, 20);
                    file.Write(data, 0, data.Length);
                    file.Close();
                }
                if (!var)
                {
                    File.Delete(SaveFilePath + "\\" + Path.GetFileNameWithoutExtension(FilePath.Split('\\').Last()) + ".dds");
                }
            });
        }
        public void ConvertBitmapToDDS(string FilePath, string SaveFilePath)
        {
            ImageEngineImage ImageEngine = new ImageEngineImage(FilePath);
            if (GetExtension(FilePath) != ".ddj")
            {
                ImageFormats.ImageEngineFormatDetails ImageFormat = new ImageFormats.ImageEngineFormatDetails((FormatDDS));
                Task ts = ImageEngine.Save(SaveFilePath + "\\" + Path.GetFileNameWithoutExtension(FilePath.Split('\\').Last()) + ".dds", ImageFormat, MipHandling.KeepExisting, 0, 0, false);
                ImageEngine.Dispose();
            }
            else
            {
                byte[] data = File.ReadAllBytes(FilePath);
                using (FileStream file = new FileStream(SaveFilePath + "\\" + Path.GetFileNameWithoutExtension(FilePath.Split('\\').Last()) + ".dds", FileMode.OpenOrCreate))
                {
                    file.Write(data, 20, data.Length - 20);
                    file.Close();
                }
            }
        }
        public void ConvertBitmapToImage(Bitmap bm, string FilePath, string SaveFilePath, ImageEngineFormat Format, string NewExtension)
        {
            ImageEngineImage ImageEngine = new ImageEngineImage(ImageToByte(bm));
            ImageFormats.ImageEngineFormatDetails ImageFormat = new ImageFormats.ImageEngineFormatDetails((Format));
            if (Format == ImageEngineFormat.BMP)
                ImageEngine.Save(SaveFilePath + "\\" + Path.GetFileNameWithoutExtension(FilePath.Split('\\').Last()) + "." + NewExtension, ImageFormat, MipHandling.KeepExisting);
            else
                ImageEngine.Save(SaveFilePath + "\\" + Path.GetFileNameWithoutExtension(FilePath.Split('\\').Last()) + "." + NewExtension, ImageFormat, MipHandling.KeepExisting, 0, 0, true);

            ImageEngine.Dispose();
        }
        public byte[] ImageToByte(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public Bitmap ConvertBitmap(string FilePath)
        {
            Bitmap bm;
            string Extension = Path.GetExtension(FilePath.Split('\\').Last()).ToLower();
            if (Extension == ".ddj")
            {
                bm = CovertDDJToBitmap(FilePath);
            }
            else if (Extension == ".dds")
            {
                bm = ConvertDDSToBitmap(FilePath);
            }
            else
            {
                bm = new Bitmap(FilePath);
            }
            return new Bitmap(bm);
        }
        private Bitmap ConvertDDSToBitmap(string FilePath)
        {
            Bitmap bm = GDImageLibrary._DDS.LoadImage(FilePath);
            return new Bitmap(bm);
        }
        private Bitmap CovertDDJToBitmap(string FilePath)
        {
            bool var = false;

            byte[] data = File.ReadAllBytes(FilePath);
            string DDsPath = FilePath.Replace(Path.GetExtension(FilePath.Split('\\').Last()), ".dds");
            if (File.Exists(DDsPath))
            {
                var = true;
            }
            using (FileStream file = new FileStream(DDsPath, FileMode.OpenOrCreate))
            {
                file.Write(data, 20, data.Length - 20);
                file.Close();
            }

            Bitmap bm = GDImageLibrary._DDS.LoadImage(DDsPath);
            if (!var)
            {
                File.Delete(DDsPath);
            }
            return new Bitmap(bm);
        }
        public string GetExtension(string FilePath)
        {
            return Path.GetExtension(FilePath.Split('\\').Last()).ToLower();
        }
  
    }
}
