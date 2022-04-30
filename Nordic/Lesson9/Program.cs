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
        /// Преобразовать строку в число, а плохую строку - в 0
        /// </summary>
        /// <param name="s">Исходная строка</param>
        /// <returns>Целое число</returns>
        static int Parse(string s)
        {
            /*
             * развернутая запись
            int n;
            if (int.TryParse(s, out n))
            {
                return n;
            }
            else
            {
                return 0;
            }
            */

            return int.TryParse(s, out int n) ? n : 0;
        }

        /// <summary>
        /// Счётчик количества сравнений
        /// </summary>
        static int CompareCounter = 0;

        /// <summary>
        /// Сравнение двух строк с учётом цифровой составляющей
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        static int Compare(string s1, string s2)
        {
            // Счетчик вызовов
            CompareCounter++;

            // Шаблон для регулярного выражения
            const string pattern = @"^(.*?)(\d*)$";
            // вася1
            // вася1бис2
            // 123

            // Поиск по шаблону в строках
            var match1 = System.Text.RegularExpressions.Regex.Match(s1, pattern);
            var match2 = System.Text.RegularExpressions.Regex.Match(s2, pattern);

            // Проверка на корректность поиска
            if (!match1.Success || !match2.Success)
            {
                throw new ApplicationException("Что-то пошло не так с шаблоном");
            }

            // Сравнение буквенной части строк
            int n = match1.Groups[1].Value.CompareTo(match2.Groups[1].Value);
            if (n != 0) // Если буквенная часть не одинаковая
            {
                return n; // Это и есть результат
            }

            // Преобразование строк в натуральные числа
            int n1 = Parse(match1.Groups[2].Value);
            int n2 = Parse(match2.Groups[2].Value);

            // Сравнение натуральных чисел
            return n1.CompareTo(n2);
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
                    // * PrintList(i, j, list);
                    // Сравнение двух элементов списка - по возрастанию
                    if (Compare(list[i], list[j]) > 0)
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
            try
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

                // Копия списка
                var copy = new List<string>();

                /*
                 * Что делает AddRange внутри себя
                foreach (var s in list)
                {
                    copy.Add(s);
                }
                */

                copy.AddRange(list);

                // Стандартная сортировка списка по стандартному возрастанию
                // list.Sort();

                // Наша сортировка с нашим (нестандартным) сравнением
                int save = CompareCounter;
                DateTime now = DateTime.Now;
                ListSort(list);
                double ms = (DateTime.Now - now).TotalMilliseconds;
                Console.WriteLine($"Нестандартная сортировка: {CompareCounter - save} сравнений, {ms} миллисекунд");

                // Сортировка стандартным методом, но с нестандартным сравнением
                save = CompareCounter;
                now = DateTime.Now;
                copy.Sort(Compare);
                ms = (DateTime.Now - now).TotalMilliseconds;
                Console.WriteLine($"Стандартная сортировка: {CompareCounter - save} сравнений, {ms} миллисекунд");

                // Вывод списка
                foreach (string item in list)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
