using System;
using System.Collections.Generic;

namespace Lesson9
{
    internal class Program
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

        static void PrintList(int i, int j, List<string> list)
        {
            for (int n = 0; n < list.Count; n++)
            {
                if (n == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (n == j)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write($"{list[n]} ");
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

        /// <summary>
        /// Сортировка списка методом модифицированного пузырька
        /// </summary>
        /// <param name="list">Список</param>
        static void ListSort(List<string> list)
        {
            // С первого по предпоследний
            for (int i = 0; i < list.Count - 1; i++)
            {
                // Со следующего за i-м по последний
                for (int j = i + 1; j < list.Count; j++)
                {
                    // Вывод промежуточного состояния списка
                    PrintList(i, j, list);
                    // Сравнение двух элементов списка
                    if (list[i].CompareTo(list[j]) < 0)
                    {
                        // Обмен между двумя элементами списка
                        string s = list[i];
                        list[i] = list[j];
                        list[j] = s;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Вводите строки, пустая строка для завершения");

            // описание и создание списка
            var list = new List<string>();

            // Ввод списка до первой пустой строки
            string s;
            do
            {
                // ввод строки и обрезка начальных и конечных пробелов
                s = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(s))
                {
                    list.Add(s);
                }
            } while (!string.IsNullOrEmpty(s));

            // Сортировка списка по возрастанию
            // list.Sort();
            ListSort(list);

            // Вывод списка
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
