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
            // Palindrome();

            // ОБОРОНОСПОСОБНОСТЬ
            // СОН +, РОБА -
            // КОКА: КОК +, ОКО -

            Console.Write("Введите длинное слово> ");
            string longWord = Console.ReadLine();
            Console.Write("Введите короткое слово> ");
            string shortWord = Console.ReadLine();

            // Цикл по короткому слову 
            bool found = true;
            string s = longWord;
            foreach (char c in shortWord)
            {
                int position = s.IndexOf(c);
                if (position < 0) // не нашли
                {
                    found = false;
                    break;
                }
                else
                {
                    s = s.Remove(position, 1);
                }
            }

            if (found)
            {
                Console.WriteLine("В слове {0} есть слово {1}", longWord, shortWord);
            }
            else
            {
                Console.WriteLine("В слове {0} нет слова {1}", longWord, shortWord);
            }
        }
    }
}
