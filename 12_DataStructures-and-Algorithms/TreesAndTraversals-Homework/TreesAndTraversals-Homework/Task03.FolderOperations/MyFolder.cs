namespace Task03.FolderOperations
{
    using System.Collections.Generic;
    using System.Linq;

    public class MyFolder
    {
        private ICollection<MyFile> files;
        private ICollection<MyFolder> subFolders;

        public MyFolder(string name)
        {
            this.Name = name;
            this.files = new List<MyFile>();
            this.subFolders = new List<MyFolder>();
        }

        public string Name { get; set; }

        public ICollection<MyFile> Files
        {
            get
            {
                return this.files;
            }
            set
            {
                this.files = value;
            }
        }

        public ICollection<MyFolder> SubFolders
        {
            get
            {
                return this.subFolders;
            }
            set
            {
                this.subFolders = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public long GetSizeOfAllFiles()
        {
            return this.Files.Sum(f => f.Size) + this.SubFolders.Sum(f => f.GetSizeOfAllFiles());
        }
    }
}
