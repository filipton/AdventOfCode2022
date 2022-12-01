namespace AdventOfCode;

public class Day1
{
    public static async Task Run()
    {
        string[] lines = await File.ReadAllLinesAsync("inputs/inputd1.txt");
        
        List<int> calories = new List<int>();
        calories.Add(0); // without newline

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                calories.Add(0);
                continue;
            }

            calories[^1] += int.Parse(line);
        }

        calories.Sort();
        calories.Reverse();
        
        Console.WriteLine($"Elf max cal: {calories[0]}");
        Console.WriteLine($"3xElf max cal: {calories[0] + calories[1] + calories[2]}");
    }
}