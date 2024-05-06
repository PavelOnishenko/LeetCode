namespace LeetCode.Task_66;

internal class SolutionForTask_66
{
    public int[] PlusOne(int[] digits)
    {
        var resultList = new List<int>(digits);
        var lastIndex = resultList.Count - 1;
        resultList[lastIndex]++;
        var i = lastIndex;
        while (resultList[i] == 10)
        {
            resultList[i] = 0;
            if (i == 0)
            {
                resultList = new[] { 0 }.Concat(resultList).ToList();
                i++;
            }
            resultList[i - 1]++;
            i--;
        }
        return resultList.ToArray();
    }
}
