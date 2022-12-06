namespace AdventOfCode;

public class Day6
{
    public static void Run()
    {
        string line = File.ReadAllText("inputs/inputd6.txt");
        // string[] lines = new[] { "" };

        int pone = 4;
        int ptwo = 14;

        while (pone < line.Length || ptwo < line.Length)
        {
            if (pone < line.Length)
            {
                char[] checkArray = line[(pone - 4)..pone].ToCharArray();
                if (checkArray.Distinct().Count() == 4)
                {
                    Console.WriteLine($"Part one: {pone}");
                    pone = line.Length;
                }
                pone++;   
            }

            if (ptwo < line.Length)
            {
                char[] checkArray2 = line[(ptwo - 14)..ptwo].ToCharArray();
                if (checkArray2.Distinct().Count() == 14)
                {
                    Console.WriteLine($"Part two: {ptwo}");
                    ptwo = line.Length;
                }
                ptwo++;   
            }
        }
    }
}