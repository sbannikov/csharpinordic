using System;

namespace Lesson3
{
    class Program
    {
        /// <summary>
        /// Ширина стакана, без учёта стенок
        /// </summary>
        static int Width = 6;
        /// <summary>
        /// Высота стакана, без учёта донышка
        /// </summary>
        static int Height = 10;
        /// <summary>
        /// Уровень заполнения стакана "жидкостью"
        /// </summary>
        static int Level = 9;

        static void Main(string[] args)
        {
            // Сохранить цвет текста консоли
            ConsoleColor color = Console.ForegroundColor;
            // Кнопка, которую нажимает человек
            ConsoleKeyInfo key;

            do
            {
                // стереть всё на экране
                // Console.Clear();
                // Перемещение курсора в верхний левый угол
                Console.CursorLeft = 0;
                Console.CursorTop = 0;


                // Повторение 10 раз -- формируем строки стакана
                for (int i = Height; i >= 1; i--)
                {
                    // формируем одну строку
                    Console.Write($"{i,2} X");
                    for (int j = 1; j <= Width; j++)
                    {
                        if (i <= Level) // если это уже "жидкость"
                        {
                            // рисуем жидкость разными цветами
                            if (Level > Height * 2 / 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else if (Level > Height / 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            Console.Write(".");
                        }
                        else
                        {
                            Console.Write(" "); // это один пробел
                        }
                    }
                    // Восстановление первоначального цвета текста
                    Console.ForegroundColor = color;
                    // это правая стенка стакана
                    Console.WriteLine("X");
                }
                // формируем последнюю строку - донышко стакана
                Console.Write("   ");
                for (int j = 1; j <= Width + 2; j++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();

                // ожидание нажатия кнопки
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (Level == Height) // проверка на заполнение стакана
                    {
                        Console.Beep();
                    }
                    else
                    {
                        Level++;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (Level >= 1) // проверка на опустошение стакана
                    {
                        Level--;
                    }
                    else
                    {
                        Console.Beep();
                    }
                }
            }
            while (key.KeyChar != 'X');
        }
    }
}