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

        public static int Fibonacci(int n)
        {
            // Console.WriteLine($"Fibonacci({n})");
            if (n < 0)
            {
                throw new ArgumentException($"Отрицательные значения n не поддерживаются: {n}");
            }
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                int n1 = Fibonacci(n - 1);
                int n2 = Fibonacci(n - 2);
                return n1 + n2;
            }
        }

        public static int FibonacciD(int n)
        {
            double five = Math.Sqrt(5);
            double d1 = Math.Pow((1 + five) / 2, n);
            double d2 = Math.Pow((1 - five) / 2, n);
            return (int)((d1 - d2) / five);
        }
    }
}
