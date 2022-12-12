using System.Numerics;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day11b
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
                .Select(BigInteger.Parse);
            
            monkeys[monkeyIndex] = new Monkey()
            {
                Items = new Queue<BigInteger>(items),
                Operation = lines[i + 2].Split("= ")[1],
                TestDivisible = int.Parse(lines[i + 3].Split("by ")[1]),
                IfTrue = int.Parse(lines[i + 4].Split("monkey ")[1]),
                IfFalse = int.Parse(lines[i + 5].Split("monkey ")[1]),
                InspectCount = 0
            };
        }
        
        
        //rounds
        for (int r = 0; r < 10000; r++)
        {
            for (int m = 0; m < monkeys.Length; m++)
            {
                while (monkeys[m].Items.TryDequeue(out BigInteger val))
                {
                    monkeys[m].InspectCount++;
                    
                    val = DoOperation(val, monkeys[m].Operation, 1);
                    // if(val > ulong.MaxValue) Console.WriteLine(val);
                    
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
            
            Console.WriteLine(r);
        }

        var pTwo = monkeys.Select(x => x.InspectCount).ToList();
        pTwo.Sort();

        
        Console.WriteLine($"Part two: {pTwo[^1] * pTwo[^2]}");
    }

    static BigInteger DoOperation(BigInteger input, string operation, int divider = 3)
    {
        string[] operArgs = operation.Split(' ');
        BigInteger first = operArgs[0] == "old" ? input : int.Parse(operArgs[0]);
        BigInteger second = operArgs[2] == "old" ? input : int.Parse(operArgs[2]);

        // BigInteger first = input;
        // BigInteger second = input;
        
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
        public Queue<BigInteger> Items;
        public string Operation;
        public BigInteger TestDivisible;
        public int IfTrue;
        public int IfFalse;

        public long InspectCount;
    }
}