using AoCHelper;

namespace advent_of_code_2022
{
    public class Day03 : BaseDay
    {
        private readonly List<string> rucksacks = new();

        public Day03()
        {
            rucksacks = File.ReadAllText(InputFilePath)
                .SplitLines()
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
        }

        private static int PriorityFor(char letter) => letter - (char.IsUpper(letter) ? 38 : 96);

        public override ValueTask<string> Solve_1()
        {
            int sum = 0;
            foreach (var rucksack in rucksacks)
            {
                int midpoint = rucksack.Length / 2;
                char shared = rucksack[..midpoint].Intersect(rucksack[midpoint..]).First();
                sum += PriorityFor(shared);
            }
            return new(sum.ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            int sum = 0;
            foreach (var group in rucksacks.Chunk(3))
            {
                char shared = group[0].Intersect(group[1]).Intersect(group[2]).First();
                sum += PriorityFor(shared);
            }
            return new(sum.ToString());
        }
    }
}