using System;
using System.IO;

namespace Module_8_HW_3
{
    class Program
    {
        static void Main(string[] args)
        {
            long Size = 0;
            bool Exist = false;
            Console.Write("Enter path to the directory: ");
            string Path = Convert.ToString(Console.ReadLine());
            ShowDirVolume(Path, ref Size, ref Exist);
            long OrigSize = Size;
            if (Exist)
            {
                Console.WriteLine($"Original size of directory: {Size} bytes");
                Program.DeleteDir(Path);
                ShowDirVolume(Path, ref Size, ref Exist);
                Console.WriteLine($"Space cleared: {OrigSize - Size} bytes");
                Console.WriteLine($"Final size of directory: {Size} bytes");
            }
            else
            {
                Console.WriteLine("User, this directory does not exist");
            }

            Console.ReadKey();
        }

        public static void ShowDirVolume(string path, ref long size, ref bool Existence)
        {
            DirectoryInfo dr = new DirectoryInfo(path);
            try
            {
                if (dr.Exists)
                {

                    FileInfo[] files = dr.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        FileInfo f = new FileInfo(file.FullName);
                        size += f.Length;
                    }

                    DirectoryInfo[] direc = dr.GetDirectories();
                    foreach (DirectoryInfo dir in direc)
                    {

                        Program.ShowDirVolume(dir.FullName, ref size, ref Existence);
                    }

                    Existence = true;
                }
                else
                {
                    size = 0;
                    Existence =  false;
                }
            }
            catch (Exception message)
            {
                Console.WriteLine(message);
            }



        }

        public static void DeleteDir(string path)
        {
            try
            {
                DirectoryInfo dr = new DirectoryInfo(path);
                dr.Delete(true);
            }
            catch (Exception message)
            {
                Console.WriteLine(message);
            }
        }


    }
}

