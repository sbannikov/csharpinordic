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
            b = random.NextDouble() +1;
            n = random.Next(10000000, 100000000);
        }

        /// <summary>
        /// Интегрирование методом прямоугольников
        /// </summary>
        internal void Work()
        {
            double summa = 0;
            double x = a;
            double delta = (b - a) / n;
            for (int i = 0; i < n; i++)
            {
                summa += f(x) * delta;
                x += delta;
            }
            result = summa;
        }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"a = {a}, b = {b}, N = {n}, интеграл = {result}";
        }
    }
}
