using System;

namespace Lesson7
{
    internal class Program
    {
        /// <summary>
        /// Проверка на палиндром
        /// </summary>
        static void Palindrome()
        {
            // ввести новую строку
            Console.Write("Введите строку> ");
            string origin = Console.ReadLine();

            // приведение исходной строки в корректную форму
            // - удаление пробелов
            // - перевод символов в нижний регистр
            string source = string.Empty;
            for (int i = 0; i < origin.Length; i++)
            {
                if ((origin[i] >= 'а' && origin[i] <= 'я') ||
                    (origin[i] >= 'А' && origin[i] <= 'Я') ||
                    (origin[i] >= 'a' && origin[i] <= 'z') ||
                    (origin[i] >= 'A' && origin[i] <= 'Z'))
                {
                    source += origin[i];
                }
            }
            // Перевод строки в нижний регистр (строчные буквы)
            source = source.ToLower();
            Console.WriteLine($"Исходная нормализованная строка: {source}");

            // напечатать строку в обратном порядке
            string palindrome = null; // пустая строка
            // Console.WriteLine(palindrome.Length);
            for (int i = source.Length - 1; i >= 0; i--)
            {
                palindrome = palindrome + source[i];
            }
            // Два варианта ниже эквиваленты
            Console.WriteLine("Строка в обратном порядке: {0}", palindrome);
            Console.WriteLine($"Строка в обратном порядке: {palindrome}");
            // Это некорректная запись! будет всегда выведено '0'
            Console.WriteLine($"Строка в обратном порядке: {0}", palindrome);

            // Первый вариант
            if (source == palindrome)
            {
                Console.WriteLine("Это палиндром");
            }
            else
            {
                Console.WriteLine("Это не палиндром");
            }

            // Второй, компактный вариант
            string prefix = source == palindrome ? string.Empty : "не ";
            Console.WriteLine($"Это {prefix}палиндром");
        }

        static void Main(string[] args)
        {
            Palindrome();
        }
    }
}
