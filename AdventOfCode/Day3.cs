namespace AdventOfCode;

public class Day3
{
    public static async Task Run()
    {
        string[] lines = await File.ReadAllLinesAsync("inputs/inputd3.txt");
        // string[] lines = new[] { "" };
        
        int score = 0;
        int score2 = 0;

        foreach (string line in lines)
        {
            string c1 = line.Substring(0, (line.Length / 2));
            string c2 = line.Substring(line.Length / 2, line.Length - c1.Length);

            // array to store if type was added to score
            int[] types = new int[58];

            foreach (char char2 in c2)
            {
                if (c1.Contains(char2))
                {
                    if(types[char2 - 'A'] != 0)
                        continue;
                    types[char2 - 'A']++;
                    
                    int val = char2 - 'A' + 1;
                    if (val > 26) val -= 32;
                    else if (val <= 26) val += 26;

                    score += val;
                }
            }
        }

        for (int i = 0; i < lines.Length; i += 3)
        {
            char[] c1 = lines[i + 0].ToCharArray();
            char[] c2 = lines[i + 1].ToCharArray();
            char[] c3 = lines[i + 2].ToCharArray();

            char badgeChar = c1.First(x => c2.Contains(x) && c3.Contains(x));
            int val = badgeChar - 'A' + 1;
            if (val > 26) val -= 32;
            else if (val <= 26) val += 26;

            score2 += val;
        }
        
        Console.WriteLine($"Part one: {score}");
        Console.WriteLine($"Part two: {score2}");
    }
}