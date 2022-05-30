using System;
using System.Collections.Generic;

namespace ConsoleThreads
{
    internal class Program
    {
        static List<Worker> list = new List<Worker>();
        static int count = 10;

        static void Main(string[] args)
        {
            // Обработка нажатия на Ctrl+C
            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine();
            Console.WriteLine("Нажмите Enter");
            Console.ReadLine();
            // Создание 10 потоков
            for (int i = 0; i < count; i++)
            {
                list.Add(new Worker());
            }
            // Console.WriteLine("Потоки созданы");
            lock (Worker.locker)
            {
                foreach (var w in list)
                {
                    w.thread.Start();
                }
            }
            // Console.WriteLine("Потоки запущены");
            foreach (var w in list)
            {
                w.thread.Join();
            }
            Console.WriteLine();
            foreach (var w in list)
            {
                Console.WriteLine(w);
            }
            Console.ReadLine();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            // list[--count].thread.Abort();
            // Запрет аварийного завершения приложения
            e.Cancel = true;
        }
    }
}
