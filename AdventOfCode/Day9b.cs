using System.Numerics;
using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day9b
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("inputs/inputd9.txt");

        Vector2 start = Vector2.Zero;
        Vector2[] snake = Enumerable.Repeat(start, 10).ToArray();

        HashSet<Vector2> visited = new ();
        foreach ((char dir, int count) in lines.Select(x => (x.Split(' ')[0][0], int.Parse(x.Split(' ')[1]))))
        {
            Vector2 dirV = ParseMovement(dir);
            
            for (int i = 0; i < count; i++)
            {
                snake[0] += dirV;

                for(int j = 1; j < snake.Length; j++)
                {
                    Vector2 tmpDV = snake[j - 1] - snake[j];

                    if (tmpDV.Length() >= 2) snake[j] += Vector2.Clamp(tmpDV, -Vector2.One, Vector2.One);
                }

                visited.Add(snake[^1]);
            }
        }
        
        Console.WriteLine($"Part two: {visited.Count}");
    }

    static Vector2 ParseMovement(char m)
    {
        return m switch
        {
            'R' => new Vector2(1, 0),
            'L' => new Vector2(-1, 0),
            'U' => new Vector2(0, 1),
            'D' => new Vector2(0, -1),
            _ => Vector2.Zero
        };
    }
}