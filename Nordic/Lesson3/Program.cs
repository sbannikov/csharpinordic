﻿using System;

namespace Lesson3
{
    class Program
    {

        /// <summary>
        /// Запрос числа у пользователя с контролем значений
        /// </summary>
        /// <param name="prompt">Экранная подсказка</param>
        /// <param name="max">Максимальное допустимое число (если 0, то контроль не выполняется)</param>
        /// <returns>Натуральное число</returns>
        static int ReadNumber(string prompt, int max, int defaultValue)
        {
            bool correct;
            int number;
            do
            {
                if (max == 0)
                {
                    prompt = $"{prompt} (от 1) [по умолчанию: {defaultValue}] > ";
                }
                else
                {
                    prompt = $"{prompt} (от 1 до {max}) [по умолчанию: {defaultValue}]> ";
                }
                Console.Write(prompt);

                // Чтение строки из ввода консоли
                string s = Console.ReadLine();
                // Проверка на пустую строку, если пустая - значение по умолчанию
                if (string.IsNullOrEmpty(s))
                {
                    number = defaultValue;
                    break;
                }

                // Преобразование строки в целое число
                correct = int.TryParse(s, out number);
                if (!correct)
                {
                    Console.WriteLine($"Я просил число, а не вот это всё: {s}");
                }
                // Проверка числа на корректность
                if (number <= 0)
                {
                    correct = false;
                    Console.WriteLine($"Я просил натуральное число (больше 0), а не вот это всё: {s}");
                }
                else if (number > max && max != 0)
                {
                    correct = false;
                    Console.WriteLine($"Я просил число не больше {max}, а не вот это всё: {s}");
                }
            } while (!correct);
            return number;
        }

        /// <summary>
        /// Расчет цвета жидкости
        /// </summary>
        /// <param name="ratio">Коэффициент заполнения от 0 до 1</param>
        /// <returns></returns>
        static ConsoleColor GetColor(double ratio)
        {
            ConsoleColor result;
            if (ratio > 2.0 / 3) // важно, что деление вещественное
            {
                result = ConsoleColor.Red;
            }
            else if (ratio > 1.0 / 3) // важно, что деление вещественное
            {
                result = ConsoleColor.DarkGreen;
            }
            else
            {
                result = ConsoleColor.Blue;
            }
            return result;
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Список параметров</param>
        static void Main(string[] args)
        {
            // Ширина стакана, без учёта стенок
            int Width;
            // Высота стакана, без учёта донышка
            int Height;
            /// Уровень заполнения стакана "жидкостью"
            int Level;

            Width = ReadNumber("Введите ширину стакана", Console.WindowWidth, 10);
            Height = ReadNumber("Введите высоту стакана", Console.WindowHeight, 12);
            Level = ReadNumber("Введите уровень жидкости", Height, 5);
            // Сохранить цвет текста консоли
            ConsoleColor color = Console.ForegroundColor;
            // Кнопка, которую нажимает человек
            ConsoleKeyInfo key;
            // стереть всё на экране
            Console.Clear();

            bool finish = false; // признак завершения программы
            do
            {
                // Перемещение курсора в верхний левый угол
                Console.CursorLeft = 0;
                Console.CursorTop = 0;

                // Один раз вычисляем цвет жидкости
                ConsoleColor waterColor = GetColor(Level / (double)Height);
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
                            Console.ForegroundColor = waterColor;
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

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Level == Height) // проверка на заполнение стакана
                        {
                            Console.Beep();
                        }
                        else
                        {
                            Level++;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (Level >= 1)// проверка на опустошение стакана
                        {
                            Level--;
                        }
                        else
                        {
                            Console.Beep();
                        }
                        break;

                    case ConsoleKey.X: // выход из программы
                        // пример использования строк
                        // finish = key.KeyChar.ToString().ToLower() == "x";

                        // пример проверки символов непосредственно
                        if (key.KeyChar == 'X' || key.KeyChar == 'x')
                        {
                            finish = true;
                        }                        
                        break;

                    default: // неизвестная кнопка
                        Console.Beep();
                        break;
                }
            }
            while (!finish);
        }
    }
}