using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    class ElfDirectory
    {
        private string name;
        public string Name { get { return name; } }

        private List<ElfDirectory> directories = new List<ElfDirectory>();
        public List<ElfDirectory> Directories { get { return directories; } }

        private List<ElfFile> files = new List<ElfFile>();
        public List<ElfFile> Files { get { return files; } }

        public int Size { get {
                int size = 0;
                foreach (ElfDirectory dir in directories)
                    size += dir.Size;
                foreach (ElfFile file in files)
                    size += file.Size;
                return size;
        } }

        public ElfDirectory(string name)
        {
            this.name = name;
        }

        public void AddDirectory(string name)
        {
            directories.Add(new ElfDirectory(name));
        }

        public void AddFile(string name, int size)
        {
            files.Add(new ElfFile(name, size));
        }
    }

    class ElfFile
    {
        private string name;
        public string Name { get { return name; } }
        private int size;
        public int Size { get { return size; } }

        public ElfFile(string name, int size)
        {
            this.name = name;
            this.size = size;
        }
    }

    class Day7
    {
        private string CurrentPath = "";
        private ElfDirectory ElfBaseDirectory = new ElfDirectory("/");
        public static Day7 Current = new Day7();
        private int NeededMinSize = 0;
        private List<ElfDirectory> PossibleDirectories = new List<ElfDirectory>();
        
        private Day7()
        {
            StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "../../Data/7 - No Space Left On Device.txt");
             
            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if(line.StartsWith("$"))    //Inputs
                {
                    line = line.Substring(2);
                    if(line.StartsWith("cd"))
                    {
                        line = line.Substring(3);
                        if (line.Equals("/"))
                            CurrentPath = "/";
                        else if (line.StartsWith(".."))
                            CurrentPath = CurrentPath.Substring(0, CurrentPath.LastIndexOf('/'));
                        else
                            CurrentPath += "/" + line;
                    }
                    else if(line.Equals("ls"))
                    {
                        ElfDirectory directory = GetDirectory(CurrentPath);
                        while(!reader.EndOfStream && reader.Peek() != '$')
                        {
                            line = reader.ReadLine();
                            if (line.StartsWith("dir"))
                                directory.AddDirectory(line.Substring(4));
                            else
                            {
                                string[] file = line.Split(' ');
                                directory.AddFile(file[1], int.Parse(file[0]));
                            }
                        }
                    }
                }
            }
            reader.Close();
        }

        private ElfDirectory GetDirectory(string path)
        {
            ElfDirectory result = ElfBaseDirectory;
            string[] splitpath = path.Split('/');
            for(int i = 0; i < splitpath.Length; i++)
            {
                if (splitpath[i] != "")
                {
                    foreach (ElfDirectory dir in result.Directories)
                    {
                        if (dir.Name == splitpath[i])
                        {
                            result = dir;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public string Task1()
        {
            return "Directorysizesums: " + CheckSubDirsTask1(ElfBaseDirectory);
        }

        private int CheckSubDirsTask1(ElfDirectory directory)
        {
            int size = 0;
            foreach(ElfDirectory dir in directory.Directories)
                size += CheckSubDirsTask1(dir);
            if (directory.Size <= 100000)
                size += directory.Size;
            return size;
        }

        public string Task2()
        {
            NeededMinSize = 30000000 - (70000000 - ElfBaseDirectory.Size);
            CheckSubDirsTask2(ElfBaseDirectory);
            return "Clear " + PossibleDirectories.Min(x => x.Size);
        }

        private void CheckSubDirsTask2(ElfDirectory directory)
        {
            foreach (ElfDirectory dir in directory.Directories)
                CheckSubDirsTask2(dir);
            if (directory.Size >= NeededMinSize)
                PossibleDirectories.Add(directory);
        }
    }
}
