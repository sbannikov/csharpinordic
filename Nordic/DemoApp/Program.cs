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
        }
    }
}
