using System.Numerics;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day10
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("inputs/inputd10.txt");
        int registerX = 1;
        int cycle = 0;

        int partOne = 0;

        foreach (string line in lines)
        {
            if (line == "noop")
            {
                Cycle(ref cycle, registerX, ref partOne);
                continue;
            }

            for (int i = 0; i < 2; i++)
            {
                Cycle(ref cycle, registerX, ref partOne);
            }
            
            int registerOperation = int.Parse(line.Split(' ')[1]);
            registerX += registerOperation;
        }
        
        Console.WriteLine($"Part one: {partOne}");
    }
    
    static void Cycle(ref int cycle, int registerX, ref int partOne)
    {
        int pixelPos = cycle % 40;
        Console.Write(Math.Abs(registerX - pixelPos) <= 1 ? "#" : ".");
        if (cycle % 40 == 39)
        {
            Console.Write("\n");
        }

        cycle++;
        if (cycle == 20 || (cycle > 20 && (cycle - 20) % 40 == 0))
        {
            partOne += registerX * cycle;
        }
    }
}