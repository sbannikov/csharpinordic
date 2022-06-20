using System;
using System.Collections.Generic;

namespace Queens
{
    class Program
    {
        const int Size = 8;

        /// <summary>
        /// Пустая клетка доски
        /// </summary>
        const string Cell = "  ";

        /// <summary>
        /// Положение ферзей по вертикали от 0 до <see cref="Size"/>
        /// </summary>
        static int[] queens = new int[Size];

        /// <summary>
        /// Список решений
        /// </summary>
        static List<int[]> result = new List<int[]>();

        /// <summary>
        /// Проверка, что n-ферзь под ударом одного из предыдущих
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static bool Checked(int n)
        {
            for (int i = 0; i < n; i++)
            {
                // отсекаем комбинации, когда ферзи стоят по одной вертикали
                if (queens[n] == queens[i]) { return true; }

                // отсекаем комбинации, когда ферзи стоят по одной диагонали
                if (Math.Abs(queens[n] - queens[i]) == (n - i)) { return true; }
            }
            return false;
        }

        /// <summary>
        /// Сохранение решения
        /// </summary>
        static void Save()
        {          
            int[] a = new int[Size];
            Array.Copy(queens, a, Size);
            result.Add(a);
        }

        static void Print()
        {
            // Сохранение исходного цвета фона
            ConsoleColor saveBack = Console.BackgroundColor;
            ConsoleColor saveFore = Console.ForegroundColor;          

            // Это формирование всего шахматного поля           
            for (int row = 0; row < Size; row++)
            {
                // Интерполяция строки
                // вместо {row} подставляется строковый эквивалент переменной row
                // то есть неявно вызывается метод row.ToString()
                Console.Write($" {row + 1,2} ");
                // Это формирование одной строки шахматного поля
                for (int col = 0; col < Size; col++)
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

                Console.Write($" {row+1} ");

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Перемещение n-го ферзя
        /// </summary>
        /// <param name="n">Номер ферзя</param>
        static void Move(int n)
        {
            for (int col = 0; col < Size; col++)
            {
                queens[n] = col;
                // Print();

                // Проверка на корректность расположения ферзей
                if (n > 0)
                {
                    if (Checked(n))
                    {
                        continue;
                    }
                }

                if (n < Size - 1)
                {
                    Move(n + 1);
                }
                else
                {                   
                    Print();
                    Save();
                }
            }
        }

        static void Main(string[] args)
        {
            Move(0);

            Console.WriteLine($"Количество решений: {result.Count}");
        }
    }
}
