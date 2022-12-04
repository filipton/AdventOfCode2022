namespace AdventOfCode;

public class Day3
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("inputs/inputd3.txt");
        // string[] lines = new[] { "" };
        
        int score = 0;
        int score2 = 0;

        foreach (string line in lines)
        {
            ReadOnlySpan<char> c1 = line.Substring(0, (line.Length / 2)).AsSpan();
            ReadOnlySpan<char> c2 = line.Substring(line.Length / 2, line.Length - c1.Length).AsSpan();

            char char2 = c1[c1.IndexOfAny(c2)];
            int val = char2 - 'A' + 1;
            if (val > 26) val -= 32;
            else if (val <= 26) val += 26;

            score += val;
        }

        for (int i = 0; i < lines.Length; i += 3)
        {
            char badgeChar = lines[i + 0]
                .Intersect(lines[i + 1])
                .Intersect(lines[i + 2])
                .First();
            
            int val = badgeChar - 'A' + 1;
            if (val > 26) val -= 32;
            else if (val <= 26) val += 26;

            score2 += val;
        }
        
        Console.WriteLine($"Part one: {score}");
        Console.WriteLine($"Part two: {score2}");
    }
}