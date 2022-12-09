using System.Numerics;
using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day9
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("inputs/inputd9.txt");

        Vector2 start = Vector2.Zero;
        Vector2 head = start;
        Vector2 tail = start;
        
        List<Vector2> visited = new ();
        visited.Add(tail);

        foreach ((char dir, int count) in lines.Select(x => (x.Split(' ')[0][0], int.Parse(x.Split(' ')[1]))))
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 dirV = ParseMovement(dir);
                if (CheckIfTailShouldMove(head, tail, dirV))
                {
                    tail = head;
                    if(!visited.Contains(tail)) visited.Add(tail);
                }
                
                head += dirV;
            }
        }
        
        Console.WriteLine($"Part one: {visited.Count}");
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

    static bool CheckIfTailShouldMove(Vector2 h, Vector2 t, Vector2 dir)
    {
        h += dir;
        if (h == t) return false;
        
        // check diagonal
        if (Math.Abs(h.Y - t.Y) <= 1 && Math.Abs(h.X - t.X) <= 1) return false;
        return true;
    }
}