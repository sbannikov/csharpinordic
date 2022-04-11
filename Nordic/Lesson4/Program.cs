using System;

namespace Lesson4
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

        static void Main(string[] args)
        {
            int Size = ReadNumber("Введите размер массива", 1000, 10);
            var Numbers = new double[Size];

            double number = 1;
            // Инициализация всех элементов массива
            for (int n = 0; n < Numbers.Length; n++)
            {
                Numbers[n] = number;
                number *= 2;
            }

            // Вычисление статистики массива
            double summa = 0;
            for (int n = 0; n < Numbers.Length; n++)
            {
                summa += Numbers[n];
            }
            double avg = summa / Numbers.Length;
            Console.WriteLine($"Среднее по больнице: {avg}");
        }
    }
}
