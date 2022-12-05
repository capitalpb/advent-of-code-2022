using AoCHelper;

namespace advent_of_code_2022;

public class Day05 : BaseDay
{
    private readonly List<Stack<char>> stacks = new();
    private readonly List<(int, int, int)> instructions = new();

    public Day05()
    {
        var inputParts = File.ReadAllText(InputFilePath).Split("\r\n\r\n");

        // read stacks
        var stackLines = inputParts[0].Split('\n');
        for (var i = stackLines.Length - 1; i >= 0; i--)
        {
            if (i == stackLines.Length - 1)
            {
                char count = stackLines[i].TrimEnd().Last();
                for (var j = 0; j < int.Parse(count.ToString()); j++)
                {
                    stacks.Add(new());
                }
            }
            else
            {
                var chunks = stackLines[i].Chunk(4).Select(c => new string(c)).ToList();
                for (var j = 0; j < chunks.Count; j++)
                {
                    if (chunks[j][1] != ' ')
                    {
                        stacks[j].Push(chunks[j][1]);
                    }
                }
            }
        }

        // read instruction set
        foreach (var instruction in inputParts[1].Split('\n'))
        {
            if (instruction != "")
            {
                var parts = instruction.Split(' ');
                instructions.Add((int.Parse(parts[1]), int.Parse(parts[3]), int.Parse(parts[5])));
            }
        }
    }

    private List<Stack<char>> CopyStacks()
    {
        List<Stack<char>> newStacks = new();
        stacks.ForEach(stack =>
        {
            newStacks.Add(new Stack<char>(new Stack<char>(stack)));
        });
        return newStacks;
    }

    public override ValueTask<string> Solve_1()
    {
        string stackTops = "";
        List<Stack<char>> localStacks = CopyStacks();
        
        foreach (var instruction in instructions)
        {
            for (var i = 0; i < instruction.Item1; i++)
            {
                localStacks[instruction.Item3 - 1].Push(localStacks[instruction.Item2 - 1].Pop());
            }
        }

        foreach (var stack in localStacks)
        {
            stackTops += stack.Peek();
        }

        return new(stackTops);
    }

    public override ValueTask<string> Solve_2()
    {
        string stackTops = "";
        List<Stack<char>> localStacks = CopyStacks();

        foreach (var instruction in instructions)
        {
            List<char> temp = new();

            for (var i = 0; i < instruction.Item1; i++)
            {
                temp.Add(localStacks[instruction.Item2 - 1].Pop());
            }

            temp.Reverse();
            foreach (var tempItem in temp)
            {
                localStacks[instruction.Item3 - 1].Push(tempItem);
            }
        }

        foreach (var stack in localStacks)
        {
            stackTops += stack.Peek();
        }

        return new(stackTops);
    }
}