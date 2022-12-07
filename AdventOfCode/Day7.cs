using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day7
{
    public static long FsSize = 70000000;
    static readonly List<FileSystem> Smallest = new ();
    static readonly List<long> Sizes = new ();
    
    public static void Run()
    {
        string[] lines = File.ReadAllLines("inputs/inputd7.txt");

        FileSystem fs = new FileSystem("/", 0, null, new List<FileSystem>());
        FileSystem currDir = fs;
        
        for (int i = 1; i < lines.Length; i++)
        {
            if(lines[i] == "$ ls") continue;
            if (lines[i].StartsWith("$ cd "))
            {
                string relativePath = lines[i][5..];
                
                if(relativePath == "..")
                {
                    if(currDir.Parent == null) continue;
                    currDir = currDir.Parent;
                }
                else
                {
                    currDir = currDir.Children.First(x => x.RelativePath == relativePath);
                }
                
                continue;
            }
            
            if (lines[i].Contains("dir"))
            {
                string relativePath = lines[i][4..];
                currDir.Children.Add(new FileSystem(relativePath, 0, currDir, new List<FileSystem>()));
                continue;
            }
            
            // parse files
            string[] split = lines[i].Split(" ");
            long size = long.Parse(split[0]);
            string name = split[1];
            
            currDir.Children.Add(new FileSystem(name, size, currDir, new List<FileSystem>()));
        }

        CalculateDirSize(ref fs);
        Sizes.Sort();
        long spaceNeeded = 30000000 - (FsSize - fs.Size);
        
        Console.WriteLine($"Part one: {Smallest.Select(x => x.Size).Sum()}");
        Console.WriteLine($"Part two: {Sizes.First(x => x >= spaceNeeded)}");
    }

    static void CalculateDirSize(ref FileSystem fs)
    {
        if (fs.Children.Count == 0)return;
        
        for (int i = 0; i < fs.Children.Count; i++)
        {
            FileSystem tfs = fs.Children[i];
            CalculateDirSize(ref tfs);
        }
            
        fs.Size = fs.Children.Select(x => x.Size).Sum();
        Sizes.Add(fs.Size);
        
        if (fs.Size <= 100000)
        {
            Smallest.Add(fs);
        }
    }

    public class FileSystem
    {
        public string RelativePath;
        public long Size;

        public FileSystem Parent;
        public List<FileSystem> Children;
        
        public FileSystem(string relativePath, long size, FileSystem parent, List<FileSystem> children)
        {
            RelativePath = relativePath;
            Size = size;
            Parent = parent;
            Children = children;
        }
    }
}