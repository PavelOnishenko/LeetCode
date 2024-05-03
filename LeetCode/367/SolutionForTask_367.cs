namespace LeetCode.Task_367;

public class Solution
{
    public bool IsPerfectSquare(int num)
    {
        var sqrt = Math.Sqrt(num);
        return Math.Abs(sqrt - (int)Math.Round(sqrt)) < 0.00001;
    }
}