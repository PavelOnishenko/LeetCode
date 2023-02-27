namespace LeetCode.Task_1195;

public class FizzBuzz
{
    private int n;
    private int i = 1;

    const int stepMs = 10;

    public FizzBuzz(int n)
    {
        this.n = n;
    }

    // printFizz() outputs "fizz".
    public void Fizz(Action printFizz)
    {
        while (i <= n)
        {
            Thread.Sleep(3 * stepMs);
            if (i % 3 == 0 && i % 5 != 0 && i <= n)
            {
                printFizz();
                i++;
            }
        }
    }

    // printBuzzz() outputs "buzz".
    public void Buzz(Action printBuzz)
    {
        while (i <= n)
        {
            Thread.Sleep(5 * stepMs);
            if (i % 5 == 0 && i % 3 != 0 && i <= n)
            {
                printBuzz();
                i++;
            }
        }
    }

    // printFizzBuzz() outputs "fizzbuzz".
    public void Fizzbuzz(Action printFizzBuzz)
    {
        while (i <= n)
        {
            Thread.Sleep(15 * stepMs);
            if (i <= n)
            {
                printFizzBuzz();
                i++;
            }
        }
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Number(Action<int> printNumber)
    {
        while (i <= n)
        {
            Thread.Sleep(stepMs);
            if (i % 3 != 0 && i % 5 != 0 && i <= n)
            {
                printNumber(i);
                i++;
            }
        }
    }
}
