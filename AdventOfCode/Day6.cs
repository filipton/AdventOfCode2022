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
                int[] checkArray = line[(pone - 4)..pone].ToCharArray().Select(x => (int)x).ToArray();
                if (checkArray.Distinct().Count() == 4)
                {
                    Console.WriteLine($"Part one: {pone}");
                    pone = line.Length;
                }
                pone++;   
            }

            if (ptwo < line.Length)
            {
                int[] checkArray2 = line[(ptwo - 14)..ptwo].ToCharArray().Select(x => (int)x).ToArray();
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