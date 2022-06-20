using System;
using NordicCommon;

namespace Lesson24
{
    internal class Program
    {
        static void Factorials()
        {
            // int f = Calculation.Factorial(5);
            for (int i = 0; i <= 200; i++)
            {
                DateTime t0 = DateTime.Now;
                double f1 = Calculation.FactorialD(i);
                TimeSpan t1 = DateTime.Now - t0;
                t0 = DateTime.Now;
                double f2 = Calculation.FactorialLoopD(i);
                TimeSpan t2 = DateTime.Now - t0;
                Console.WriteLine($"{i}! = {f1} {f2}, {t1.TotalMilliseconds} {t2.TotalMilliseconds}");
            }
        }

        static void Main(string[] args)
        {
           // int f = Calculation.Fibonacci(20);

            for (int i = 0; i < 30; i++)
            {
                DateTime t0 = DateTime.Now;
                int f1 = Calculation.Fibonacci(i);
                TimeSpan t1 = DateTime.Now - t0;
                t0 = DateTime.Now;
                int f2 = Calculation.FibonacciD(i);
                TimeSpan t2 = DateTime.Now - t0; 
                Console.WriteLine($"F({i,2}) = {f1,10:0} {f2,10:0} {t1.TotalMilliseconds} {t2.TotalMilliseconds}");
            }
        }
    }
}
