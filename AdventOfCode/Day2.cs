namespace AdventOfCode;

public class Day2
{
    public static async Task Run()
    {
        string[] lines = await File.ReadAllLinesAsync("inputs/inputd2.txt");

        int score = 0; // PART ONE
        int score2 = 0; // PART TWO

        foreach (string line in lines)
        {
            string[] inps = line.Split(' ');
            
            // PART ONE
            switch (inps[1])
            {
                case "X":
                    score += 1;
                    break;
                case "Y":
                    score += 2;
                    break;
                case "Z":
                    score += 3;
                    break;
            }

            
            // PART TWO
            score2 += GetPartTwoScore(inps[0], inps[1]);
            
            // PART ONE
            score += CheckRound(inps[0], inps[1]);
        }
        
        Console.WriteLine($"Elf score: {score}");
        Console.WriteLine($"Elf score 2: {score2}");
    }

    
    // PART ONE
    static int CheckRound(string p1, string p2)
    {
        //draw
        if ((p1 == "A" && p2 == "X") ||
            (p1 == "B" && p2 == "Y") ||
            (p1 == "C" && p2 == "Z")) return 3;
        
        // loss
        if ((p1 == "A" && p2 == "Z") ||
            (p1 == "B" && p2 == "X") ||
            (p1 == "C" && p2 == "Y")) return 0;
        
        // win
        if ((p1 == "A" && p2 == "Y") ||
            (p1 == "B" && p2 == "Z") ||
            (p1 == "C" && p2 == "X")) return 6;

        return 0;
    }
    
    
    // PART TWO
    static int GetPartTwoScore(string p1, string p2)
    {
        switch (p2)
        {
            // lose
            case "X":
                if (p1 == "A") return 3 + 0;
                if (p1 == "B") return 1 + 0;
                if (p1 == "C") return 2 + 0;
                break;
            
            // draw
            case "Y":
                if (p1 == "A") return 1 + 3;
                if (p1 == "B") return 2 + 3;
                if (p1 == "C") return 3 + 3;
                break;
            
            // win
            case "Z":
                if (p1 == "A") return 2 + 6;
                if (p1 == "B") return 3 + 6;
                if (p1 == "C") return 1 + 6;
                break;
        }
        
        return 0;
    }
}