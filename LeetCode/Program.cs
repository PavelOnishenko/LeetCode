using LeetCode.Task_1195;

namespace LeetCode;

public class Solution
{
    public static void Main(string[] args)
    {
        int n; 
        var nString = Console.ReadLine();
        if(int.TryParse(nString, out n)) 
        {
            var fizzBuzz = new FizzBuzz(n);
            var threadA = new Thread(() => fizzBuzz.Fizz(() => Console.WriteLine("Fizz")));
            var threadB = new Thread(() => fizzBuzz.Buzz(() => Console.WriteLine("Buzz")));
            var threadC = new Thread(() => fizzBuzz.Fizzbuzz(() => Console.WriteLine("Fizzbuzz")));
            var threadD = new Thread(() => fizzBuzz.Number(i => Console.WriteLine(i)));
            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();
        }
        else
        {
            Console.WriteLine("Incorrent input, need number!");
        }
    }
}