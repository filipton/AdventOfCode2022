namespace AdventOfCode;

public class Day5
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("inputs/inputd5.txt");
        // string[] lines = new[] { "" };

        int firstMoves = lines.ToList().FindIndex(string.IsNullOrEmpty);
        
        List<List<char>> stack = new List<List<char>>();
        List<List<char>> stackTwo = new List<List<char>>();

        for (int i = 0; i < firstMoves - 1; i++)
        {
            for (int s = 1; s < lines[i].Length; s+=4)
            {
                int stackIndex = (s - 1) / 4;

                if (stack.Count <= stackIndex)
                {
                    stack.Add(new List<char>());
                    stackTwo.Add(new List<char>());
                }

                if (lines[i][s] != ' ')
                {
                    stack[stackIndex].Insert(0, lines[i][s]);
                    stackTwo[stackIndex].Insert(0, lines[i][s]);
                }
            }
        }

        for (int i = firstMoves + 1; i < lines.Length; i++)
        {
            string[] tArgs = lines[i].Split(' ');
            int move = int.Parse(tArgs[1]);
            int from = int.Parse(tArgs[3]);
            int to = int.Parse(tArgs[5]);
            
            Move(move, from, to, ref stack);
            MoveStackTwo(move, from, to, ref stackTwo);
            Console.WriteLine(i);
        }
        
        
        Console.WriteLine($"Part one: {string.Join('\0', stack.Select(x => x[^1]))}");
        Console.WriteLine($"Part two: {string.Join('\0', stackTwo.Select(x => x[^1]))}");
    }

    static void Move(int count, int from, int to, ref List<List<char>> stack)
    {
        for (int i = 0; i < count; i++)
        {
            stack[to - 1].Add(stack[from - 1][^1]);
            stack[from - 1].RemoveAt(stack[from - 1].Count - 1);
        }
    }
    
    static void MoveStackTwo(int count, int from, int to, ref List<List<char>> stack)
    {
        var crates = stack[from - 1].TakeLast(count).ToArray();
        stack[from - 1].RemoveRange(stack[from - 1].Count - crates.Count(), crates.Count());
        stack[to - 1].AddRange(crates);
    }
}