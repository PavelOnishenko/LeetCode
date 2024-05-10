using LeetCode.Task_47;

namespace LeetCode;

public class Solution
{
    public static void Main(string[] args)
    {
        var solution = new SolutionForTask_47();
        var permutations = solution.PermuteUnique(new[] { 1, 2, 3, 3, 3, 4 });
        foreach (var permutation in permutations) 
        {
            Console.Write("[");
            var numsJoined = string.Join(", ", permutation);
            Console.Write(numsJoined);
            Console.Write("]\n");
        }
    }
}