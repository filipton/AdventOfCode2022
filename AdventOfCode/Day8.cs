using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day8
{
    public static void Run()
    {
        string[] lines = File.ReadAllLines("inputs/inputd8.txt");

        int edgesTrees = (lines.Length * lines[0].Length) - ((lines.Length - 2) * (lines[0].Length - 2));
        int maxVisibility = 0;
        
        for (int y = 1; y < lines[0].Length - 1; y++)
        {
            for (int x = 1; x < lines.Length - 1; x++)
            {
                if (CalculateVisibility(lines, x, y, out int visibility))
                {
                    edgesTrees++;
                    maxVisibility = Math.Max(visibility, maxVisibility);
                }
            }   
        }
        
        Console.WriteLine($"Part one: {edgesTrees}");
        Console.WriteLine($"Part two: {maxVisibility}");
    }

    static bool CalculateVisibility(string[] lines, int x, int y, out int visibilityScore)
    {
        int[] edgesInvisible = new int[4];
        int[] edgesScore = new int[4]{x, lines[0].Length - x - 1, y, lines.Length - y - 1};

        // check X- (left)
        for (int lX = x - 1; lX >= 0; lX--)
        {
            if (lines[y][lX] >= lines[y][x])
            {
                edgesScore[0] = x - lX;
                edgesInvisible[0] = 1;
                break;
            }
        }
        
        // check X+ (right)
        for (int lX = x + 1; lX < lines[0].Length; lX++)
        {
            if (lines[y][lX] >= lines[y][x])
            {
                edgesScore[1] = lX - x;
                edgesInvisible[1] = 1;
                break;
            }
        }
        
        // check Y- (up)
        for (int lY = y - 1; lY >= 0; lY--)
        {
            if (lines[lY][x] >= lines[y][x])
            {
                edgesScore[2] = y - lY;
                edgesInvisible[2] = 1;
                break;
            }
        }
        
        // check Y+ (down)
        for (int lY = y + 1; lY < lines.Length; lY++)
        {
            if (lines[lY][x] >= lines[y][x])
            {
                edgesScore[3] = lY - y;
                edgesInvisible[3] = 1;
                break;
            }
        }

        visibilityScore = edgesScore[0] * edgesScore[1] * edgesScore[2] * edgesScore[3];
        return edgesInvisible.Average() < 1;
    }
}