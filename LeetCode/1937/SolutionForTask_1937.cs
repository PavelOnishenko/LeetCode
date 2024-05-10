namespace LeetCode.Problem_1937;

internal class SolutionForTask_1937
{
    public long MaxPoints(int[][] points)
    {
        var rowLength = points[0].Length;
        var rowCount = points.Length;
        var optionsCount = Math.Pow(rowLength, rowCount);
        var result = long.MinValue;
        for (var optionCode = 0; optionCode < optionsCount; optionCode++)
        {
            var optionCounter = optionCode;
            var pointsCount = 0;
            int? previousColumn = null;
            for (var row = 0; row < rowCount; row++)
            {
                var column = optionCounter % rowLength;
                var currentNumber = points[row][column];
                var delta = previousColumn.HasValue ? Math.Abs(column - previousColumn.Value) : 0;
                pointsCount += currentNumber - delta;
                optionCounter /= rowLength;
                previousColumn = column;
            }
            if (pointsCount > result)
            {
                result = pointsCount;
            }
        }
        return result;
    }
}
