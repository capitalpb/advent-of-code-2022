using AoCHelper;

namespace advent_of_code_2022;

public class Day02 : BaseDay
{
    private readonly List<(char, char)> turns = new();

    public Day02()
    {
        string input = File.ReadAllText(InputFilePath);

        foreach (string line in input.SplitLines())
        {
            if (line != "")
            {
                var parts = line.Split(' ');
                turns.Add((char.Parse(parts[0]), char.Parse(parts[1])));
            }
        }
    }

    public override ValueTask<string> Solve_1()
    {
        int score = 0;
        foreach (var turn in turns)
        {
            score += turn switch
            {
                ('A', 'X') => 4,
                ('A', 'Y') => 8,
                ('A', 'Z') => 3,
                ('B', 'X') => 1,
                ('B', 'Y') => 5,
                ('B', 'Z') => 9,
                ('C', 'X') => 7,
                ('C', 'Y') => 2,
                ('C', 'Z') => 6,
                _ => 0
            };
        }
        return new(score.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int score = 0;
        foreach (var turn in turns)
        {
            score += turn switch
            {
                ('A', 'X') => 3,
                ('A', 'Y') => 4,
                ('A', 'Z') => 8,
                ('B', 'X') => 1,
                ('B', 'Y') => 5,
                ('B', 'Z') => 9,
                ('C', 'X') => 2,
                ('C', 'Y') => 6,
                ('C', 'Z') => 7,
                _ => 0
            };
        }
        return new(score.ToString());
    }
}