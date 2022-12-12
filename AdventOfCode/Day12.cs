using System.Numerics;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day12
{
    private static Vector2 endVec = Vector2.Zero;
    private static Dictionary<Vector2, int> Visited = new();
 
    private static int minClimbing = 9999999;
    
    /*
     * Idk if that algorithm has name, but its basically modified flood fill algorithm
     */
    
    public static void Run()
    {
        string input = File.ReadAllText("inputs/inputd12.txt");

        char[][] inputArray = input.Split(Environment.NewLine)
            .Select(x => x.ToCharArray().ToArray())
            .ToArray();
 
        Vector2 startVec = Vector2.Zero;
        List<Vector2> startVecs = new ();
 
        for(int x = 0; x < inputArray.Length; x++)
        {
            for(int y = 0; y < inputArray[x].Length; y++)
            {
                if(inputArray[x][y] == 'S')
                {
                    startVec = new Vector2(x, y);
                    inputArray[x][y] = 'a';
                }
                else if(inputArray[x][y] == 'E')
                {
                    endVec = new Vector2(x, y);
                    inputArray[x][y] = 'z';
                }
 
                if(inputArray[x][y] == 'a')
                {
                    startVecs.Add(new Vector2(x, y));
                }
            }
        }
 
        SolveRecursive(inputArray, startVec, startVec, 0);
        Console.WriteLine($"Part one: {minClimbing}");
        minClimbing = 99999999;
 
        for (int i = 0; i < startVecs.Count; i++)
        {
            SolveRecursive(inputArray, startVecs[i], startVecs[i], 0);   
        }
 
        Console.WriteLine($"Part two: {minClimbing}");
    }
    
    static void SolveRecursive(char[][] inputArr, Vector2 last, Vector2 curr, int depth)
    {
        if (depth > minClimbing) return;
        if (inputArr[(int)last.X][(int)last.Y] + 1 < inputArr[(int)curr.X][(int)curr.Y]) return;
        if (Visited.ContainsKey(curr) && Visited[curr] <= depth) return;
 
        if(curr == endVec) minClimbing = Math.Min(minClimbing, depth);
        Visited[curr] = depth;
 
        int maxX = inputArr.Length;
        int maxY = inputArr[0].Length;
 
        depth += 1;
        if(curr.X > 0) SolveRecursive(inputArr, curr, new Vector2(curr.X - 1, curr.Y), depth);
        if(curr.X < maxX - 1) SolveRecursive(inputArr, curr, new Vector2(curr.X + 1, curr.Y), depth);
        if(curr.Y > 0) SolveRecursive(inputArr, curr, new Vector2(curr.X, curr.Y - 1), depth);
        if(curr.Y < maxY - 1) SolveRecursive(inputArr, curr, new Vector2(curr.X, curr.Y + 1), depth);
    }
}