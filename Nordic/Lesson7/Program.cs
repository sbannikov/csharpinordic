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

        /// <summary>
        /// Разделитель слов
        /// </summary>
        const char Delimiter = ',';

        /// <summary>
        /// Добавление строки в конец строкового массива
        /// </summary>
        /// <param name="stringArray">Массив строк</param>
        /// <param name="word">Добавляемое слово</param>
        static void AddToArray(ref string[] stringArray, string word)
        {
            Array.Resize(ref stringArray, stringArray.Length + 1);
            stringArray[stringArray.Length - 1] = word;
        }

        /// <summary>
        /// Вывести результат поиска
        /// </summary>
        /// <param name="format">Строка форматирования</param>
        /// <param name="longWord">Длинное слово</param>
        /// <param name="stringArray">Массив коротких слов</param>
        static void PrintResult(string format, string longWord, string[] stringArray)
        {
            if (stringArray.Length > 0)
            {
                string s = string.Join(Delimiter, stringArray);
                Console.WriteLine(format, longWord, s);
            }
        }

        static void Main(string[] args)
        {

            // Palindrome();

            // ОБОРОНОСПОСОБНОСТЬ
            // СОН +, РОБА -
            // КОКА: КОК +, ОКО -

            Console.Write("Введите длинное слово> ");
            string longWord = Console.ReadLine();
            Console.Write("Введите список коротких слов через запятую> ");
            string shortWordString = Console.ReadLine();

            // Разрезать строку на подстроки по запятой
            string[] shortWords = shortWordString.Split(Delimiter);
            string[] foundWords = new string[0];
            string[] notFoundWords = new string[0];

            foreach (string shortWord in shortWords)
            {
                // Цикл по короткому слову 
                bool found = true;
                string s = longWord;
                // обрабатываем все буквы, отсекая начальные и конечные пробелы
                foreach (char c in shortWord.Trim())
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
                    AddToArray(ref foundWords, shortWord);
                }
                else
                {
                    AddToArray(ref notFoundWords, shortWord);                   
                }
            }

            PrintResult("В слове {0} есть слова {1}", longWord, foundWords);
            PrintResult("В слове {0} нет слов {1}", longWord, notFoundWords);            
        }
    }
}
