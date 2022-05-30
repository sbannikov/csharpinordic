using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleThreads
{
    internal class Worker
    {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Объект для блокировки
        /// </summary>
        internal static object locker = new object();

        /// <summary>
        /// Счётчик созданных объектов
        /// </summary>
        private static int counter = 0;

        /// <summary>
        /// Поток
        /// </summary>
        internal System.Threading.Thread thread;

        /// <summary>
        /// Нижний предел интегрирования
        /// </summary>
        private double a;
        /// <summary>
        /// Верхний предел интегрирования
        /// </summary>
        private double b;
        /// <summary>
        /// Количество интервало интегрирования
        /// </summary>
        private int n;
        /// <summary>
        /// Номер созданного объекта, начиная с 0
        /// </summary>
        private int number;

        /// <summary>
        /// Время запуска расчета
        /// </summary>
        private DateTime start;

        /// <summary>
        /// Результат интегрирования
        /// </summary>
        private double result;

        /// <summary>
        /// Интегрируемая функция (синус)
        /// </summary>
        /// <param name="x">Аргумент</param>
        /// <returns></returns>
        private double f(double x) => Math.Sin(x);

        internal Worker()
        {
            a = random.NextDouble();
            b = random.NextDouble() + 1;
            n = random.Next(100000000, 500000000);
            thread = new System.Threading.Thread(Work);
            number = counter++;
        }

        /// <summary>
        /// Интегрирование методом прямоугольников
        /// </summary>
        internal void Work()
        {
            // Синхронизация запуска
            lock (locker) { }

            start = DateTime.Now;
            double summa = 0;
            double x = a;
            double delta = (b - a) / n;
            int prevPercent = -1;
            for (int i = 0; i < n; i++)
            {
                summa += f(x) * delta;
                x += delta;
                int percent = (int)((i * 100L) / (n - 1));
                if (prevPercent != percent)
                {
                    // Вывод текущего процента
                    lock (locker)
                    {
                        Console.CursorLeft = number * 6;
                        Console.CursorTop = 0;
                        Console.Write($"{percent}%");
                    }
                    prevPercent = percent;
                }
            }
            result = summa;
        }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"start = {start:HH:mm:ss.ffffff} N = {n}";
        }
    }
}
