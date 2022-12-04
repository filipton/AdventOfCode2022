namespace AdventOfCode;

public class Day4
{
    public static void Run()
    {
        string[][] lines = File.ReadAllLines("inputs/inputd4.txt").Select(x => x.Split(',')).ToArray();
        // string[] lines = new[] { "" };

        int pone = 0;
        int ptwo = 0;

        foreach (var line in lines)
        {
            int[] p1 = line[0].Split('-').Select(int.Parse).ToArray();
            int[] p2 = line[1].Split('-').Select(int.Parse).ToArray();

            if ((p1[0] >= p2[0] && p1[1] <= p2[1]) ||
                (p2[0] >= p1[0] && p2[1] <= p1[1]))
            {
                pone++;
            }

            // that's not optimized at all lmao
            if ((p1[0] >= p2[0] && p1[0] <= p2[1]) ||
                (p1[1] >= p2[0] && p1[1] <= p2[1]) ||
                (p2[0] >= p1[0] && p2[0] <= p1[1]) ||
                (p2[1] >= p1[0] && p2[1] <= p1[1]))
            {
                ptwo++;
            }
        }
        
        Console.WriteLine($"Part one: {pone}");
        Console.WriteLine($"Part two: {ptwo}");
    }
}