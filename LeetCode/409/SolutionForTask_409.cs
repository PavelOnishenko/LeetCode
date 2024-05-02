namespace LeetCode.Task_409;

public class Solution
{
    public int LongestPalindrome(string s)
    {
        var charsAndCounts = s.Distinct()
            .Select(uniqueChar =>
                new {
                    uniqueChar,
                    count = s.Count(stringCharacter =>
                        stringCharacter == uniqueChar)
                }).ToArray();
        var pairsOnly = charsAndCounts.Select(x =>
            new {
                x.uniqueChar,
                count = x.count % 2 == 0 ? x.count : x.count - 1
            });
        var result = pairsOnly.Sum(x => x.count);
        var anyHasOddCount = charsAndCounts.Any(x => x.count % 2 != 0);
        if (anyHasOddCount)
            result++;
        return result;
    }
}
