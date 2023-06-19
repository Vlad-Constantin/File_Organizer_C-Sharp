using System;

namespace Organizator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Menu();
            Console.WriteLine("Valid path...");
            CreateDirsForExtensions(path);
            Console.WriteLine("Folders created successfully!");
            





        }
        static string[] Dir_types = {
            "Pictures", "Videos", "PDF_files", "Music", "TXT_files", "Word_files", "Excel_files", "Exe_files", "Archived_files", 
        };
        static string[][] File_ext = {
            new string[] { ".jpg", ".jpeg", ".png", ".JPG" },
            new string[] { ".mp4", ".mov", ".MOV", ".avi" },
            new string[] { ".pdf", ".PDF" },
            new string[] { ".mp3" },
            new string[] { ".txt" },
            new string[] { ".doc", ".docx" },
            new string[] { ".csv", ".xlsx", ".xls" },
            new string[] { ".exe" },
            new string[] { ".zip", ".7z" }
        };
        static string Menu()
        {
            Console.WriteLine("Insert the path or press EXIT: ");
            string path = Console.ReadLine();
            while (!Valid_path(path))
            {

                if (path.ToUpper() == "EXIT")
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Insert the path or press EXIT: ");
                path = Console.ReadLine();
            }
            return path;
        }
        static bool Valid_path(string path)
        {
            return Directory.Exists(path);
        }

        static void CreateDirsForExtensions(string path)
        {
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                string fileExtension = Path.GetExtension(file);
                string destinationFolder = GetDestinationFolder(fileExtension);

                if (destinationFolder != null)
                {
                    string dirPath = Path.Combine(path, destinationFolder);
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                }
            }
        }


        static string GetDestinationFolder(string fileExtension)
        {
            for (int i = 0; i < File_ext.Length; i++)
            {
                string[] supportedExtensions = File_ext[i];

                foreach (string extension in supportedExtensions)
                {
                    if (string.Equals(extension, fileExtension, StringComparison.OrdinalIgnoreCase))
                    {
                        return Dir_types[i];
                    }
                }
            }

            return null;
        }


    }
}