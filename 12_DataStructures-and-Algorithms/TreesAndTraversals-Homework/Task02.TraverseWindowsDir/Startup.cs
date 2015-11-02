namespace Task02.TraverseWindowsDir
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            TraverseDir("C:\\Windows");
        }

        public static void TraverseDir(string directoryPath)
        {
            TraverseDir(new DirectoryInfo(directoryPath), 0);
        }

        private static void TraverseDir(DirectoryInfo dir, int offset)
        {
            try
            {
                var files = Directory.GetFiles(dir.FullName, "*.exe");
                foreach (var item in files)
                {
                    Console.WriteLine(new string('-', offset) + item);
                }

                DirectoryInfo[] children = dir.GetDirectories();
                foreach (DirectoryInfo child in children)
                {
                    TraverseDir(child, offset + 2);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Sorry The App does not have access to the given directory!");
            }            
        }
    }
}
