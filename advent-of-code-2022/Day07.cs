using AoCHelper;
using System.Security.Cryptography.X509Certificates;

namespace advent_of_code_2022;

public class Day07 : BaseDay
{
    private readonly Dictionary<string, int> directories = new(){ { "{root}", 0 } };

    public Day07()
    {
        string currentDirectory = "";

        foreach (var line in File.ReadAllLines(InputFilePath).Where(s => !string.IsNullOrWhiteSpace(s)))
        {
            var parts = line.Split(' ');

            if (parts[1] == "cd")
            {
                if (parts[2] == "/")
                {
                    currentDirectory = "{root}";
                }
                else if (parts[2] == "..")
                {
                    currentDirectory = currentDirectory[..currentDirectory.LastIndexOf('/')];
                }
                else
                {
                    currentDirectory += $"/{parts[2]}";
                    directories.Add(currentDirectory, new());
                }
            }
            else if (parts[1] == "ls" || parts[0] == "dir")
            {
                continue;
            }
            else
            {
                directories[currentDirectory] += int.Parse(parts[0]);
            }
        }
    }

    public override ValueTask<string> Solve_1()
    {
        int sum = 0;

        foreach (var dir in directories.Keys)
        {
            int dirSize = 0;

            foreach (var subdir in directories.Where(kvp => kvp.Key.StartsWith(dir)))
            {
                dirSize += subdir.Value;
            }

            if (dirSize <= 100_000)
            {
                sum += dirSize;
            }
        }

        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int spaceRequired = 30_000_000 - (70_000_000 - directories.Values.Sum());
        List<int> possibleDeletions = new();

        foreach (var dir in directories.Keys)
        {
            int dirSize = 0;

            foreach (var subdir in directories.Where(kvp => kvp.Key.StartsWith(dir)))
            {
                dirSize += subdir.Value;
            }

            if (dirSize >= spaceRequired)
            {
                possibleDeletions.Add(dirSize);
            }
        }

        return new(possibleDeletions.Min().ToString());
    }
}