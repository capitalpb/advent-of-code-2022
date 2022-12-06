using AoCHelper;
using System.Reflection.PortableExecutable;

namespace advent_of_code_2022;

public class Day06 : BaseDay
{
    private readonly string dataStream;
    public Day06()
    {
        dataStream = File.ReadAllText(InputFilePath).TrimEnd();
    }

    public override ValueTask<string> Solve_1()
    {
        for (int i = 3; i < dataStream.Length; i++)
        {
            if (new HashSet<char>(dataStream.Substring(i - 3, 4)).Count == 4)
            {
                return new((i + 1).ToString());
            }
        }
        return new("not found");
    }

    public override ValueTask<string> Solve_2()
    {
        for (int i = 13; i < dataStream.Length; i++)
        {
            if (new HashSet<char>(dataStream.Substring(i - 13, 14)).Count == 14)
            {
                return new((i + 1).ToString());
            }
        }
        return new("not found");
    }
}
