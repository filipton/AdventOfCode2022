namespace AdventOfCode;

public class Day2
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("inputs/inputd2.txt");

        int score = 0; // PART ONE
        int score2 = 0; // PART TWO

        foreach (string line in lines)
        {
            char[] inps = line.Split(' ').Select(x => x[0]).ToArray();
            int p1Index = inps[0] - 'A';
            int p2Index = inps[1] - 'X';
            
            score += PartOne(p1Index, p2Index);
            score2 += PartTwo(p1Index, p2Index);
        }
        
        Console.WriteLine($"Part one: {score}");
        Console.WriteLine($"Part two: {score2}");
    }

    
    // PART ONE (INSPIRED BY https://github.com/teraa/AoC.2022/blob/master/Day02.a/Program.cs)
    static int PartOne(int p1, int p2)
    {
        // win - sub (mod 0)
        // 0 1 - -1
        // 1 2 - -1
        // 2 0 - 2
        
        // draw - 0 (mod 1)
        
        // lose - sub (mod 2)
        // 0 2 - -2
        // 1 0 - 1
        // 2 1 - 1
        
        int sub = p1 - p2 + 4;
        return (p2 + 1) + (2 - sub % 3) * 3;
    }
    
    
    // PART TWO (INSPIRED BY https://github.com/teraa/AoC.2022/blob/master/Day02.b/Program.cs)
    static int PartTwo(int p1, int p2)
    {
        // win
        // 0 1 - 1
        // 1 2 - 3
        // 2 0 - 2
        
        // lose
        // 0 2 - 2
        // 1 0 - 1
        // 2 1 - 3
        
        // draw

        return (p2 * 3) + (p1 + p2 + 2) % 3 + 1;
    }
}