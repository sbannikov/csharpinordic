using System;
/*
 * Это многострочный комментарий 
 */
namespace DemoApp
{
    class Program
    {
        /// <summary>
        /// Главная функция - точка входа в приложение
        /// </summary>
        /// <param name="args">Параметры командной строки</param>
        static void Main(string[] args)
        {
            double a, b;
            double number; // вещественное число 
            double summa; // вещественное число
            bool flag; // логическое значение
            string name; // строковое значение
            string s;
            char c; // символьное значение

            a = 1;
            b = 0;
            number = a + b;

            summa = Math.PI;
            flag = number > 0.0;

            name = "Это моя программа";
            s = "!!!!";
            name = name + s;
            c = '@';

            Console.WriteLine(number);
            Console.WriteLine(summa);
            Console.WriteLine(flag);
            Console.WriteLine(name);
            Console.WriteLine(name.Length);
            Console.WriteLine(c);

            // Пример применения операторов инкремента
            int n = 10, m = 10;
            Console.WriteLine(n++);
            Console.WriteLine(++m);
            Console.WriteLine(n);
            Console.WriteLine(m);
            Console.WriteLine();

            // Пример работы с массивами
            int[] days = new int[10] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31 };
            Console.WriteLine($"Размер массива: {days.Length}");
            Array.Resize(ref days, 12);
            Console.WriteLine($"Размер массива: {days.Length}");
            days[10] = 30;
            days[11] = 31;
            Array.Resize(ref days, 10);
            Console.WriteLine($"Размер массива: {days.Length}");
        }
    }
}
