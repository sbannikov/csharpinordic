using System;
using NordicCommon;

namespace Lesson24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int f = Calculation.Factorial(5);
            for (int i = 0; i <= 10; i++)
            {
                DateTime t0 = DateTime.Now;
                int f1 = Calculation.Factorial(i);
                TimeSpan t1 = DateTime.Now - t0;
                t0 = DateTime.Now;
                int f2 = Calculation.FactorialLoop(i);
                TimeSpan t2 = DateTime.Now - t0;
                Console.WriteLine($"{i}! = {f1} {f2}, {t1} {t2}");  
            }
        }
    }
}
