using Aspose.Zip.Rar;
using SlimPK2.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangerSroApp.ExtensionsClass
{
    public class PK2
    {
        public void ExtractedFile(string RarPath, string ExtractedPath)
        {
            using (RarArchive archive = new RarArchive("Sample.rar"))
            {
                // Create a file with Create() method.
                using (var destination = File.Create("Extracted_File1.txt"))
                {
                    // Open an entry from the RAR archive.
                    using (var source = archive.Entries[0].Open())
                    {

                        byte[] buffer = new byte[1024];
                        int bytesRead;
                        // Write extracted data to the file.
                        while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                            destination.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
        public void ExtractedAllFile(string PathRar, string OutPutDir, string PasswrodRar = null)
        {
            // Load input RAR file.
            RarArchive archive = new RarArchive(PathRar);

            // Unrar or extract all files from the archive
            if (PasswrodRar != null)
            {
                archive.ExtractToDirectory(OutPutDir, PasswrodRar);
            }
            else
            {
                archive.ExtractToDirectory(OutPutDir);
            }

        }
        public void ExtractedAllFile()
        {
            // using (RarArchive archive = new RarArchive("Sample.rar"))
            // {
            //     // Create a file with Create() method.
            //     using (var destination = File.Create("Extracted_File1.txt"))
            //     {
            //         // Open an entry from the RAR archive.
            //         using (var source = archive.Entries[0].Open())
            //         {
            //             byte[] buffer = new byte[1024];
            //             int bytesRead;
            //             // Write extracted data to the file.
            //             while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
            //                 destination.Write(buffer, 0, bytesRead);
            //         }
            //     }
            // }
        }
        public static void Create(string name)
        {
            PK2Entry.Create(PK2EntryType.Empty, new PK2Entry(), name);
        }
    }
}