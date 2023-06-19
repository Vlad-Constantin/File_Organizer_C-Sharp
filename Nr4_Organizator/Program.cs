using System;

namespace Organizator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Menu();
            Console.WriteLine("Valid path...");
            Create_Dirs(path);
        }
        static string[] Dir_types = {
                "Pictures","PDF","Txt","Exe"
        };
        static string[][] File_ext = {
            new string[] {".jpg",".jpeg",".png",".JPG"},
            new string[] {".pdf",".PDF"},
            new string[] {".txt",".TXT"},
            new string[] {".exe"}
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

        static void Create_Dirs(string path)
        {
            foreach(string dir in Dir_types)
            {
                string dir_patch = Path.Combine(path, dir);
                if (!Directory.Exists(dir_patch))
                {
                    Directory.CreateDirectory(dir_patch);
                }
            }   

        }

    }
}