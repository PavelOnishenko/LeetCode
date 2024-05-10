namespace LeetCode.Task_80;

internal class SolutionForTask_80
{
    public int RemoveDuplicates(int[] nums)
    {
        var frequencies = new Dictionary<int, int>();
        int? prevNumber = null;
        frequencies.Add(nums[0], 1);
        foreach (var num in nums)
        {
            if (prevNumber.HasValue)
                if (prevNumber.Value == num)
                {
                    var frequency = frequencies[num];
                    if (frequency != 2) frequencies[num] = frequency + 1;
                }
                else
                {
                    frequencies.Add(num, 1);
                }
            prevNumber = num;
        }
        var resultArrayCounter = 0;
        foreach (var frequency in frequencies)
        {
            var iterationsCount = Math.Min(frequency.Value, 2);
            for (var i = 0; i < iterationsCount; i++)
            {
                nums[resultArrayCounter] = frequency.Key;
                resultArrayCounter++;
            }
        }
        return resultArrayCounter;
    }
}
