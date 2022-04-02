using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Chess!");

            // Это формирование всего шахматного поля 8*8
            for (int row = 1; row <= 8; row = row + 1)
            {
                // Это формирование одной строки шахматного поля
                for (int m = 1; m <= 4; m = m + 1)
                {
                    // Определяем, чётная эта строка или нечётная
                    if (row % 2 == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
