using LeetCode._72;
using LeetCode.Task_1195;

namespace LeetCode;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter word 1:");
        var word1 = Console.ReadLine();
        Console.WriteLine("Enter word 2:");
        var word2 = Console.ReadLine();
        var solution72 = new SolutionForTask_72();
        var result = solution72.MinDistance(word1, word2);
        Console.WriteLine($"Result: [{result}].");
        Console.ReadKey();
    }
}