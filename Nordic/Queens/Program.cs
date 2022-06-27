using System;
using System.Collections.Generic;

namespace Queens
{
    class Program
    {


        /// <summary>
        /// Пустая клетка доски
        /// </summary>
        const string Cell = "  ";

        /// <summary>
        /// Список решений
        /// </summary>
        static List<int[]> result = new List<int[]>();

        static void Print(int[] queens)
        {
            // Сохранение исходного цвета фона
            ConsoleColor saveBack = Console.BackgroundColor;
            ConsoleColor saveFore = Console.ForegroundColor;

            // Это формирование всего шахматного поля           
            for (int row = 0; row < queens.Length; row++)
            {
                // Интерполяция строки
                // вместо {row} подставляется строковый эквивалент переменной row
                // то есть неявно вызывается метод row.ToString()
                Console.Write($" {row + 1,2} ");
                // Это формирование одной строки шахматного поля
                for (int col = 0; col < queens.Length; col++)
                {
                    // Определяем, чётная эта строка или нечётная
                    if ((row + col) % 2 == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    if (queens[row] == col)
                    {
                        Console.Write("()");
                    }
                    else
                    {
                        Console.Write(Cell);
                    }
                }
                // Восстановление исходного цвета
                Console.ForegroundColor = saveFore;
                Console.BackgroundColor = saveBack;

                Console.Write($" {row + 1} ");

                Console.WriteLine();
            }
            Console.WriteLine();
        }      

        static void Main(string[] args)
        {
            Solution s = new Solution(8);
            foreach (int[] solution in s.Move(0))
            {
                Print(solution);
                result.Add(solution);
            }

            Console.WriteLine($"Количество решений: {result.Count}");
        }
    }
}
