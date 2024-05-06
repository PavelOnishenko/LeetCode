namespace LeetCode._120;

internal class SolutionForTask_120
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        var lastRowIndex = triangle.Count - 1;
        for (var row = lastRowIndex - 1; row >= 0; row--)
        {
            for (var indexInRow = 0; indexInRow < triangle[row].Count; indexInRow++)
            {
                triangle[row][indexInRow] += Math.Min(triangle[row + 1][indexInRow], triangle[row + 1][indexInRow + 1]);
            }
        }
        return triangle[0][0];
    }
}
