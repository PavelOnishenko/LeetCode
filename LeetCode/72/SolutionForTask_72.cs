using System.Text;

namespace LeetCode._72;

// Not finished.
public class SolutionForTask_72
{

    private int Result { get; set; } = 0;

    public int MinDistance(string word1, string word2)
    {
        var builder = new StringBuilder(word1);
        var error = GetError(builder, word2);
        Console.WriteLine($"Initial error: [{error}].");
        while (error > 0)
        {
            var possibleChanges = GetPossibleChanges(builder, word2).ToArray();
            var usefulChanges = possibleChanges.Where(x => x.ResultingError < error).ToArray();
            var optimalChange = usefulChanges.OrderBy(x => x.ResultingError).First();
            Apply(builder, optimalChange);
            Console.WriteLine($"Applied operation: [{optimalChange}].");
            Result++;
            error = GetError(builder, word2);
        }

        return Result;
    }

    private void Apply(StringBuilder builder, Change change)
    {
        if (change.Type == ChangeType.Insert)
        {
            builder.Insert(change.Index, change.Character);
        }
        else if (change.Type == ChangeType.Delete)
        {
            builder.Remove(change.Index, 1);
        }
        else if (change.Type == ChangeType.Replace)
        {
            if (builder[change.Index] != change.Character)
                builder[change.Index] = change.Character;
        }
    }

    private IEnumerable<Change> GetPossibleChanges(StringBuilder builder, string target)
    {
        var possibleChanges = new List<Change>();
        possibleChanges.AddRange(GetPossibleInsertions(builder, target));
        possibleChanges.AddRange(GetPossibleReplacements(builder, target));
        possibleChanges.AddRange(GetPossibleDeletions(builder, target));
        return possibleChanges;
    }

    private IEnumerable<Change> GetPossibleInsertions(StringBuilder builder, string target)
    {
        var changes = new List<Change>();
        var placesCount = builder.Length + 1;
        var targetDistinct = target.Distinct().ToArray();
        var missingCharacters = targetDistinct.Except(builder.ToString().Distinct()).ToArray();
        var charactersForInsertion = missingCharacters.Any() ? missingCharacters : targetDistinct;
        for (int index = 0; index < placesCount; index++)
        {
            foreach (var character in charactersForInsertion)
            {
                var newChange = new Change
                {
                    Type = ChangeType.Insert,
                    Index = index,
                    Character = character,
                };
                var builderCopy = new StringBuilder(builder.ToString());
                Apply(builderCopy, newChange);
                var error = GetError(builderCopy, target);
                newChange.ResultingError = error;
                changes.Add(newChange);
            }
        }
        return changes;
    }

    private IEnumerable<Change> GetPossibleReplacements(StringBuilder builder, string target)
    {
        var changes = new List<Change>();
        var targetDistinct = target.Distinct().ToArray();
        var missingCharacters = targetDistinct.Except(builder.ToString().Distinct()).ToArray();
        var charactersForReplacement = missingCharacters.Any() ? missingCharacters : targetDistinct;
        for (int index = 0; index < builder.Length; index++)
        {
            foreach (var character in charactersForReplacement)
            {
                if (builder[index] == character) continue;
                var builderCopy = new StringBuilder(builder.ToString());
                var newChange = new Change
                {
                    Type = ChangeType.Replace,
                    Index = index,
                    Character = character
                };
                Apply(builderCopy, newChange);
                var error = GetError(builderCopy, target);
                newChange.ResultingError = error;
                changes.Add(newChange);
            }
        }
        return changes;
    }

    private IEnumerable<Change> GetPossibleDeletions(StringBuilder builder, string target)
    {
        var changes = new List<Change>();
        for (int index = 0; index < builder.Length; index++)
        {
            var builderCopy = new StringBuilder(builder.ToString());
            var newChange = new Change
            {
                Type = ChangeType.Delete,
                Index = index
            };
            Apply(builderCopy, newChange);
            var error = GetError(builderCopy, target);
            newChange.ResultingError = error;
            changes.Add(newChange);
        }
        return changes;
    }

    private class Change
    {
        public ChangeType Type { get; init; }
        public int Index { get; init; }
        public char Character { get; init; }
        public int ResultingError { get; set; }

        public override string ToString()
        {
            return $"{Type} of {Character} at {Index} resulting in {ResultingError} error.";
        }
    }

    private enum ChangeType { Insert, Delete, Replace };

    private int GetError(StringBuilder builder, string target)
    {
        var result = 0;
        result += Math.Abs(builder.Length - target.Length) * LengthDiffFactor;
        var lcs = GetLCS(builder, target);
        var lcsError = Math.Abs(builder.Length - lcs.Length);
        result += lcsError * LcsDiffFactor;
        result += GetPositionalDifference(builder, target) * PositionalDiffFactor;
        return result;
    }

    private int GetPositionalDifference(StringBuilder builder, string target)
    {
        var counter = 0;
        var minLength = Math.Min(builder.Length, target.Length);
        for(var i = 0; i < minLength; i++) 
        {
            if (builder[i] != target[i]) counter++;
        }
        return counter;
    }

    static string GetLCS(StringBuilder s1, string s2)
    {
        int[,] dp = new int[s1.Length + 1, s2.Length + 1];

        int i, j;

        for (i = 1; i <= s1.Length; i++)
        {
            for (j = 1; j <= s2.Length; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        i = s1.Length;
        j = s2.Length;
        string lcs = "";

        while (i > 0 && j > 0)
        {
            if (s1[i - 1] == s2[j - 1])
            {
                lcs = s1[i - 1] + lcs;
                i--;
                j--;
            }
            else if (dp[i - 1, j] > dp[i, j - 1])
                i--;
            else
                j--;
        }

        return lcs;
    }

    private const int LengthDiffFactor = 10;
    private const int LcsDiffFactor = 30;
    private const int PositionalDiffFactor = 2;
}
