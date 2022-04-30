using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Anagramm
{
    internal class Program
    {
        /// <summary>
        /// Формирование словаря из строки
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns></returns>
        static Dictionary<char, int> ParseString(string s)
        {
            var dict = new Dictionary<char, int>();
            // CultureInfo culture = CultureInfo.GetCultureInfo("ru-RU");
            foreach (char c in s.ToUpperInvariant())
            {                
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            return dict;
        }

        static char Function(char key)
        {
            return key;
        }

        /// <summary>
        /// Вывод словаря на экран
        /// </summary>
        /// <param name="dict">Словарь</param>
        static void WriteDict(Dictionary<char, int> dict)
        {
            foreach (char c in dict.Keys.OrderBy(c => c))
            {
                Console.WriteLine($"{c} = {dict[c]}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите два слова");
            string word1 = Console.ReadLine();
            string word2 = Console.ReadLine();

            var dict1 = ParseString(word1);
            WriteDict(dict1);
            Console.WriteLine();

            var dict2 = ParseString(word2);
            WriteDict(dict2);

            if (dict1.Count != dict2.Count)
            {
                Console.WriteLine("Слова - не анаграммы");
                return;
            }

            // Цикл по буквам первого словаря           
            foreach (var c in dict1.Keys)
            {
                /*
                if (!dict2.ContainsKey(c))
                {
                    Console.WriteLine("Слова - не анаграммы");
                    return;
                }
                if (dict1[c] != dict2[c])
                {
                    Console.WriteLine("Слова - не анаграммы");
                    return;
                }
                */

                if (!dict2.TryGetValue(c, out int count) || count != dict1[c])
                {
                    Console.WriteLine("Слова - не анаграммы");
                    return;
                }
            }            

            Console.WriteLine("Слова - анаграммы");
        }
    }
}
