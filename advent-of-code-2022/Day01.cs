using advent_of_code_2022.Extensions;
using AoCHelper;

namespace advent_of_code_2022;

public class Day01 : BaseDay
{
    private readonly List<int> caloriesPerElf = new();

    public Day01()
    {
        string input = File.ReadAllText(InputFilePath);
        int sum = 0;

        foreach (string line in input.SplitLines())
        {
            if (line != "")
            {
                sum += int.Parse(line);
            }
            else
            {
                caloriesPerElf.Add(sum);
                sum = 0;
            }
        }
    }

    public override ValueTask<string> Solve_1() =>
        new(caloriesPerElf.Max().ToString());

    public override ValueTask<string> Solve_2() =>
        new(caloriesPerElf.OrderDescending().Take(3).Sum().ToString());
}