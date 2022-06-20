using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NordicCommon
{
    public static class Calculation
    {
        /// <summary>
        /// Факториал методом рекурсии
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException($"Отрицательные значения n не поддерживаются: {n}");
            }
            if (n == 0)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        /// <summary>
        /// Факториал методом цикла
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int FactorialLoop(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException($"Отрицательные значения n не поддерживаются: {n}");
            }
            int factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        /// <summary>
        /// Факториал методом рекурсии
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double FactorialD(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException($"Отрицательные значения n не поддерживаются: {n}");
            }
            if (n == 0)
            {
                return 1;
            }
            return n * FactorialD(n - 1);
        }

        /// <summary>
        /// Факториал методом цикла
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double FactorialLoopD(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException($"Отрицательные значения n не поддерживаются: {n}");
            }
            double factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
