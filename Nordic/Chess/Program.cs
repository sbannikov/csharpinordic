using System;

namespace Chess
{
    class Program
    {        
        /// <summary>
        /// Клетка доски
        /// </summary>
        const string Cell = "  ";

        /// <summary>
        /// Главная функция - точка входа в приложение
        /// </summary>
        /// <param name="args">Параметры командной строки</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер шахматного поля");

            // Чтение строки из ввода консоли
            string size = Console.ReadLine();

            // Преобразование строки в целое число
            bool correct = int.TryParse(size, out int Size);
            if (!correct)
            {
                Console.WriteLine($"Я просил число, а не вот это всё: {size}");
                // Конец выполнения программы
                return;
            }

            // Сохранение исходного цвета фона
            ConsoleColor saveColor = Console.BackgroundColor;

            Console.WriteLine($"Hello Chess {Size}x{Size}");

            // Формирование буквенного обозначения клеток
            Console.Write($"   ");
            char c = 'A';
            for (int i = 0; i < Size; i++)
            {
                Console.Write($" {c++}");
            }

            /*
            for (int i = 0; i < Size; i++)
            {
                Console.Write($" {label[i]}");
            }
            */

            Console.WriteLine();
            // Это формирование всего шахматного поля 8*8            
            for (int row = Size; row >= 1; row--)
            {
                // Интерполяция строки
                // вместо {row} подставляется строковый эквивалент переменной row
                // то есть неявно вызывается метод row.ToString()
                Console.Write($" {row,2} ");
                // Это формирование одной строки шахматного поля
                for (int m = 1; m <= Size / 2; m++)
                {
                    // Определяем, чётная эта строка или нечётная
                    if (row % 2 == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(Cell);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(Cell);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(Cell);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(Cell);
                    }
                }
                // Восстановление исходного цвета фона
                Console.BackgroundColor = saveColor;

                Console.Write($" {row} ");

                Console.WriteLine();
            }
                      
            Console.WriteLine();

            // Восстановление исходного цвета фона
            Console.BackgroundColor = saveColor;
        }
    }
}
