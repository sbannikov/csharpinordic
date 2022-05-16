using System;
using System.Collections.Generic;

namespace Lesson14
{
    internal class Program
    {
        static void Process()
        {
            List<Number> list = new List<Number>();
            for (int n = 0; n < 10; n++)
            {
                Console.WriteLine($"n = {n}");
                list.Add(new Number());
            }
        }

        static void Main(string[] args)
        {
            Process();
            // Принудительная сборка мусора
            // GC.Collect();
            Console.ReadLine();
        }
    }
}
