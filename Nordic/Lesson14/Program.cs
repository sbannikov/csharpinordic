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
            var nn = new Number(-1);
        }

        static void Main(string[] args)
        {
            try
            {
                Process();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Принудительная сборка мусора
            // GC.Collect();
            Console.ReadLine();
        }
    }
}
