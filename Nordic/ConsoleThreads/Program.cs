using System;

namespace ConsoleThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker w = new Worker();
            w.Work();
            Console.WriteLine(w);
            Console.ReadLine();
        }
    }
}
