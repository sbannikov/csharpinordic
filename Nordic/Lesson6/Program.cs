using System;

namespace Lesson6
{
    class Program
    {
        const char letter = 'о';
        static void Main(string[] args)
        {
            string message = "Над всей Испанией безоблачное небо";

            // Подсчёт количества буквы letter в строке
            // первый вариант - WHILE
            int n = 0;
            int count = 0;
            while (n < message.Length)
            {
                if (message[n] == letter)
                {
                    count++;
                }
                n++;
            }
            Console.WriteLine($"Встречено {count} букв {letter}");

            n = 0;
            count = 0;
            if (message.Length > 0) // так как цикл выполняется минимум 1 раз
            {
                do
                {
                    if (message[n] == letter)
                    {
                        count++;
                    }
                    n++;
                }
                while (n < message.Length);
            }
            Console.WriteLine($"Встречено {count} букв {letter}");

            // Цикл FOR - со счётчиком
            for (n = 0, count = 0; n < message.Length; n++)
            {
                if (message[n] == letter)
                {
                    count++;
                }
            }
            Console.WriteLine($"Встречено {count} букв {letter}");

            count = 0;
            foreach (char c in message)
            {
                if (c == letter)
                {
                    count++;
                }
            }
            Console.WriteLine($"Встречено {count} букв {letter}");
        }
    }
}
