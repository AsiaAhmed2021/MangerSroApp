using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangerSroApp.ExtensionsClass
{
    public class SrSpoofPatcher
    {
        public static string SpoofMachineAppIP(string path, string IP)
        {
            string s = IP;
            int num1 = 4194304;
            int num2 = 100;
            try
            {
                FileStream input = File.Open(path, FileMode.Open);
                BinaryReader binaryReader = new BinaryReader((Stream)input);
                long length = binaryReader.BaseStream.Length;
                long num3 = 0;
                binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
                int num4 = 0;
                int num5 = 0;
                for (int index = 0; (long)index < length - 1000L; ++index)
                {
                    try
                    {
                        if (binaryReader.ReadByte() == 82)
                        {
                            if (binaryReader.ReadByte() == 80)
                            {
                                if (binaryReader.ReadByte() == 15)
                                {
                                    if (binaryReader.ReadByte() == 182)
                                    {
                                        if (binaryReader.ReadByte() == 201)
                                        {
                                            if (binaryReader.ReadByte() == (byte)81)
                                            {
                                                if (num4 == 0)
                                                    num4 = (int)binaryReader.BaseStream.Position + num1;
                                                else
                                                    num5 = (int)binaryReader.BaseStream.Position + num1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                if (num4 == 0 || num5 == 0)
                {
                    return "Something went wrong (one or both of addresses of push instructions are 0 !) - signature detection failed ?";
                }
                else
                {
                    binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
                    long num6 = 0;
                    for (int index = 0; (long)index < length - (long)num2; ++index)
                    {
                        if (binaryReader.ReadByte() == (byte)0)
                            ++num6;
                        else
                            num6 = 0L;
                        if (num6 >= (long)num2)
                        {
                            //Console.WriteLine("Free space found at RVA offset [{0} bytes !] {1:X} ", (object)num2, (object)(binaryReader.BaseStream.Position + (long)num1 - (long)num2));
                            num3 = binaryReader.BaseStream.Position + (long)num1 - (long)num2;
                            break;
                        }
                    }
                    binaryReader.Close();
                    input.Close();
                    FileStream output = new FileStream(path, FileMode.Open);
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)output);
                    output.Seek(num3 - (long)num1, SeekOrigin.Begin);
                    foreach (byte num7 in Encoding.ASCII.GetBytes(s))
                        output.WriteByte(num7);
                    //Console.WriteLine("WRITEN new ip bytes to offset {0:X} at free space !\nNow setting push instruction operands !", (object)num3);
                    output.Seek((long)(num4 - num1 + 1), SeekOrigin.Begin);
                    byte[] bytes1 = BitConverter.GetBytes(num3);
                    for (int index = 0; index < 4; ++index)
                        output.WriteByte(bytes1[index]);
                    Console.WriteLine("first push  writen !");
                    output.Seek((long)(num5 - num1 + 1), SeekOrigin.Begin);
                    byte[] bytes2 = BitConverter.GetBytes(num3);
                    for (int index = 0; index < 4; ++index)
                        output.WriteByte(bytes2[index]);
                    //Console.WriteLine("second push  writen !");
                    binaryWriter.Close();
                    output.Close();
                    //Program.comment();

                    //if (num3 == 0L)
                    //    Console.WriteLine("Something went wrong (no free space at PE ?!");

                    return "Patching finished !";


                }
            }
            catch (Exception ex)
            {
                return ex.Message;
                //Console.WriteLine("Something went terribly wrong: {0}", (object)ex.Message);
                //Console.ReadKey();
            }
        }
        public static string SpoofAgentAppIP(string path, string IP)
        {
            try
            {
                BinaryWriter binaryWriter = new BinaryWriter((Stream)new FileStream(path, FileMode.Open));
                byte[] buffer1 = new byte[2] { (byte)250, (byte)39 };
                binaryWriter.Seek(213882, SeekOrigin.Begin);
                binaryWriter.Write(buffer1, 0, 2);
                binaryWriter.Seek(213966, SeekOrigin.Begin);
                binaryWriter.Write(buffer1, 0, 2);
                byte[] buffer2 = new byte[35];
                binaryWriter.Seek(796666, SeekOrigin.Begin);
                binaryWriter.Write(buffer2, 0, 35);
                byte[] bytes = Encoding.ASCII.GetBytes(IP);
                binaryWriter.Seek(796666, SeekOrigin.Begin);
                binaryWriter.Write(bytes, 0, bytes.Length);
                binaryWriter.Close();
                return "Successfully wrote ip address bytes to agent server.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
       
        /// <summary>
        /// GatewayServer
        /// </summary>
        /// <param name="path"></param>
        /// <param name="AllowOffline">
        /// Allow to enter game while service offline
        /// </param>
        /// <param name=""></param>
        /// <returns></returns>
        public static string SpoofGatewayServerAppIP(string path, bool AllowOffline)
        {

            BinaryWriter binaryWriter = new(new FileStream(path, FileMode.Open));
            byte[] buffer1 = new byte[1] { 235 };
            byte[] buffer2 = new byte[1];
            byte[] buffer3 = new byte[43] { 66, 108, 111, 111, 100, 121, 78, 101, 116, 119, 111, 114, 107, 93, 85, 115, 101, 114, 32, 99, 111, 110, 110, 101, 99, 116, 105, 110, 103, 32, 91, 37, 100, 46, 37, 100, 46, 37, 100, 46, 37, 100, 93 };
            byte[] buffer4 = new byte[44];
            if (AllowOffline)
            {
                binaryWriter.Seek(21446, SeekOrigin.Begin);
                binaryWriter.Write(buffer1, 0, 1);
                binaryWriter.Seek(21544, SeekOrigin.Begin);
                binaryWriter.Write(buffer2, 0, 1);
                binaryWriter.Seek(889905, SeekOrigin.Begin);
                binaryWriter.Write(buffer3, 0, 43);
                binaryWriter.Seek(889948, SeekOrigin.Begin);
                binaryWriter.Write(buffer4, 0, 44);
            }
            binaryWriter.Close();
            return "Successfully patched GatewayServer.exe";
        }
        public static List<string> SpoofGamesServerAppVal(string path,
            SpoofOpr ChangeMaxLevel, // TextBox1
            SpoofOpr Changemasterylimit, // TextBox2
            SpoofOpr SpoofIP,//TextBox3
            bool FixRates,
            bool DisableDumpFiles,
            bool DisableGreenBook)
        {

            List<string> ArrayMsg = new List<string>();

            if (Convert.ToInt32(ChangeMaxLevel.Value) > 254)
            {
                ArrayMsg.Add("Level value converting is impossible. Value does not fit in byte type.");
            }
            else if (Convert.ToInt16(Changemasterylimit.Value) > 900)
            {
                ArrayMsg.Add("Mastery limit over 900");
            }
            else
            {
                if (System.IO.File.Exists(path))
                {
                    BinaryWriter binaryWriter = new BinaryWriter((Stream)new FileStream(path, FileMode.Open));
                    byte[] bytes1 = BitConverter.GetBytes(Convert.ToInt16(Changemasterylimit.Value));
                    if (ChangeMaxLevel.Sec)
                    {
                        byte[] buffer1 = new byte[1] { Convert.ToByte(ChangeMaxLevel.Sec) };
                        binaryWriter.Seek(877598, SeekOrigin.Begin);
                        binaryWriter.Write(buffer1, 0, 1);
                        binaryWriter.Seek(938697, SeekOrigin.Begin);
                        binaryWriter.Write(buffer1, 0, 1);
                    }
                    if (DisableGreenBook)
                    {
                        byte[] buffer6 = new byte[12] { 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144 };
                        binaryWriter.Seek(82747, SeekOrigin.Begin);
                        binaryWriter.Write(buffer6, 0, buffer6.Length);
                    }
                    if (Changemasterylimit.Sec)
                    {
                        binaryWriter.Seek(1689063, SeekOrigin.Begin);
                        binaryWriter.Write(bytes1, 0, 2);
                    }
                    if (DisableDumpFiles)
                    {
                        byte[] buffer4 = new byte[4] { 233, 152, 2, 0 };
                        byte[] buffer5 = new byte[1] { 144 };
                        binaryWriter.Seek(5652576, SeekOrigin.Begin);
                        binaryWriter.Write(buffer4, 0, 4);
                        binaryWriter.Seek(5652581, SeekOrigin.Begin);
                        binaryWriter.Write(buffer5, 0, 1);
                    }
                    if (FixRates)
                    {
                        byte[] buffer3 = new byte[1] { 66 };
                        binaryWriter.Seek(160078, SeekOrigin.Begin);
                        binaryWriter.Write(buffer3, 0, 1);
                        binaryWriter.Seek(160247, SeekOrigin.Begin);
                        binaryWriter.Write(buffer3, 0, 1);
                        binaryWriter.Seek(160418, SeekOrigin.Begin);
                        binaryWriter.Write(buffer3, 0, 1);
                        binaryWriter.Seek(160587, SeekOrigin.Begin);
                        binaryWriter.Write(buffer3, 0, 1);
                        binaryWriter.Seek(160716, SeekOrigin.Begin);
                        binaryWriter.Write(buffer3, 0, 1);
                    }
                    byte[] buffer2 = new byte[1] { 182 };
                    binaryWriter.Seek(939125, SeekOrigin.Begin);
                    binaryWriter.Write(buffer2, 0, 1);
                    binaryWriter.Seek(939961, SeekOrigin.Begin);
                    binaryWriter.Write(bytes1, 0, 1);
                    if (SpoofIP.Sec)
                    {
                        byte[] buffer7 = new byte[3] { 32, 142, 173 };
                        binaryWriter.Seek(5465530, SeekOrigin.Begin);
                        binaryWriter.Write(buffer7, 0, 3);
                        binaryWriter.Seek(5465614, SeekOrigin.Begin);
                        binaryWriter.Write(buffer7, 0, 3);
                        byte[] buffer8 = new byte[32];
                        binaryWriter.Seek(7179808, SeekOrigin.Begin);
                        binaryWriter.Write(buffer8, 0, 32);
                        byte[] bytes2 = Encoding.ASCII.GetBytes(SpoofIP.Value);
                        binaryWriter.Seek(7179808, SeekOrigin.Begin);
                        binaryWriter.Write(bytes2, 0, bytes2.Length);
                        ArrayMsg.Add("Wrote spoofed ip bytes");
                    }
                    binaryWriter.Close();
                    ArrayMsg.Add("Successfully patched SR_GameServer.exe.");
                }
                else
                {
                    ArrayMsg.Add("Error opening file (maybe, it's in use ?)");
                }
            }


            return ArrayMsg;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="AccPlayTime_LastUpdate">Bypass AccPlayTime/AccPlayTime_LastUpdate column updating</param>
        /// <returns></returns>
        public static string SpoofGlobalManagerApp(string path, bool AccPlayTime_LastUpdate)
        {

            BinaryWriter binaryWriter = new BinaryWriter((Stream)new FileStream(path, FileMode.Open));
            byte[] buffer1 = new byte[7] { 235, 37, 144, 144, 144, 144, 144 };
            byte[] buffer2 = new byte[3] { 235, 117, 144 };
            if (AccPlayTime_LastUpdate)
            {
                binaryWriter.Seek(81616, SeekOrigin.Begin);
                binaryWriter.Write(buffer1, 0, 7);
                binaryWriter.Seek(81680, SeekOrigin.Begin);
                binaryWriter.Write(buffer2, 0, 3);
            }
            return "Wrote spoofed ip bytes GlobalManager Successfully patched";
        }

        public class SpoofOpr
        {
            public bool Sec { set; get; }
            public string Value { set; get; }
        }

    }
}
