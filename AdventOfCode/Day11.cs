using System.Numerics;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day11
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("inputs/inputd11.txt");

        Monkey[] monkeys = new Monkey[(lines.Length + 1) / 7];
        
        // parsing
        for(int i = 0; i < lines.Length; i+=7)
        {
            int monkeyIndex = i / 7;
            
            var items = lines[i + 1]
                .Split(": ")[1]
                .Split(',')
                .Select(int.Parse);
            
            monkeys[monkeyIndex] = new Monkey()
            {
                Items = new Queue<int>(items),
                Operation = lines[i + 2].Split("= ")[1],
                TestDivisible = int.Parse(lines[i + 3].Split("by ")[1]),
                IfTrue = int.Parse(lines[i + 4].Split("monkey ")[1]),
                IfFalse = int.Parse(lines[i + 5].Split("monkey ")[1]),
                InspectCount = 0
            };
        }
        
        
        //rounds
        for (int r = 0; r < 20; r++)
        {
            for (int m = 0; m < monkeys.Length; m++)
            {
                while (monkeys[m].Items.TryDequeue(out int val))
                {
                    monkeys[m].InspectCount++;
                    
                    val = DoOperation(val, monkeys[m].Operation);
                    if (val % monkeys[m].TestDivisible == 0)
                    {
                        monkeys[monkeys[m].IfTrue].Items.Enqueue(val);
                    }
                    else
                    {
                        monkeys[monkeys[m].IfFalse].Items.Enqueue(val);
                    }
                }
            }
        }

        var pOne = monkeys.Select(x => x.InspectCount).ToList();
        pOne.Sort();

        
        Console.WriteLine($"Part one: {pOne[^1] * pOne[^2]}");
    }

    static int DoOperation(int input, string operation, int divider = 3)
    {
        string[] operArgs = operation.Split(' ');
        int first = operArgs[0] == "old" ? input : int.Parse(operArgs[0]);
        int second = operArgs[2] == "old" ? input : int.Parse(operArgs[2]);
        
        switch (operArgs[1])
        {
            case "+":
                return (first + second) / divider;
            case "*":
                return (first * second) / divider;
            default:
                throw new Exception("Unknown operation");
        }
    }

    struct Monkey
    {
        public Queue<int> Items;
        public string Operation;
        public int TestDivisible;
        public int IfTrue;
        public int IfFalse;

        public int InspectCount;
    }
}