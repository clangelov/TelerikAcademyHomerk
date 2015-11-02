namespace Task03.FolderOperations
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            const string StartFolder = "../../";

            var root = new MyFolder(StartFolder);

            FillFolderWithFiles(new DirectoryInfo(StartFolder), root);

            PrintFromFolder(root, 0);

            Console.WriteLine("Total size is {0} bytes", root.GetSizeOfAllFiles());
        }

        public static void FillFolderWithFiles(DirectoryInfo dir, MyFolder folder)
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                folder.Files.Add(new MyFile(file.Name, file.Length));
            }

            foreach (var subDir in dir.GetDirectories())
            {
                var subFolder = new MyFolder(subDir.Name);
                folder.SubFolders.Add(subFolder);
                FillFolderWithFiles(subDir, subFolder);
            }
        }

        private static void PrintFromFolder(MyFolder folder, int offset)
        {
            Console.Write(new string('-', offset) + folder.Name);

            if (offset == 0)
            {
                Console.Write(" <- (root)");
            }

            Console.WriteLine();

            foreach (var subfolder in folder.SubFolders)
            {
                PrintFromFolder(subfolder, offset + 2);
            }

            foreach (var file in folder.Files)
            {
                Console.WriteLine(new string('-', offset) + file.Name);
            }
        }
    }
}
