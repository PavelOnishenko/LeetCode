using System;
using System.Collections.Generic;
using System.Linq;
namespace LeetCode.Task_47;

internal class SolutionForTask_47
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var multiset = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var result = PermuteUniqueInternal(multiset, Array.Empty<int>());
        return result;
    }

    private IList<IList<int>> PermuteUniqueInternal(Dictionary<int, int> multiset, IEnumerable<int> start)
    {
        if (!multiset.Any()) return new List<IList<int>> { start.ToList() };
        var result = new List<IList<int>>();
        var possibleChoices = multiset.Keys.ToArray();
        foreach (var choice in possibleChoices)
        {
            var multisetCopy = multiset.ToDictionary(x => x.Key, x => x.Value);
            if (multisetCopy[choice] == 1) multisetCopy.Remove(choice);
            else multisetCopy[choice]--;
            var permutations = PermuteUniqueInternal(multisetCopy, start.Concat(new[] { choice }));
            result.AddRange(permutations);
        }
        return result;
    }
}
