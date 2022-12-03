namespace advent_of_code_2022.Extensions;

public static class StringExtensions
{
    public static List<string> SplitLines(this string str)
    {
        return str.Split(Environment.NewLine).ToList();
    }
}
