using AoCHelper;

namespace advent_of_code_2022;

public class Day04 : BaseDay
{
    private readonly List<(Range, Range)> assignments = new();

    public Day04()
    {
        foreach (string line in File.ReadAllText(InputFilePath).SplitLines())
        {
            if (line != "")
            {
                var indivudualAssignments = line.Split(',');
                var range1 = indivudualAssignments[0].Split('-');
                var range2 = indivudualAssignments[1].Split('-');
                assignments.Add((
                    int.Parse(range1[0])..(int.Parse(range1[1])),
                    int.Parse(range2[0])..(int.Parse(range2[1]))
                ));
            }
        }
    }

    public override ValueTask<string> Solve_1()
    {
        int fullyContained = 0;
        foreach (var assignmentPair in assignments)
        {
            if (assignmentPair.Item1.Contains(assignmentPair.Item2) || assignmentPair.Item2.Contains(assignmentPair.Item1))
            {
                fullyContained++;
            }
        }
        return new(fullyContained.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int overlaps = 0;
        foreach (var assignmentPair in assignments)
        {
            if (assignmentPair.Item1.Overlaps(assignmentPair.Item2))
            {
                overlaps++;
            }
        }
        return new(overlaps.ToString());
    }
}

public static class RangeExtensions
{
    public static bool Contains(this Range range1, Range range2)
    {
        return range1.Start.Value <= range2.Start.Value
            && range1.End.Value >= range2.End.Value;
    }

    public static bool Overlaps(this Range range1, Range range2)
    {
        return range1.Start.Value <= range2.End.Value
            && range2.Start.Value <= range1.End.Value;
    }
}