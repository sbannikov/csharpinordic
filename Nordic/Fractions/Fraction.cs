﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    public class Fraction
    {
        /// <summary>
        /// Целая часть
        /// </summary>
        public int Number { get; }
        /// <summary>
        /// Числитель
        /// </summary>
        public int Numerator { get; }
        /// <summary>
        /// Знаменатель
        /// </summary>
        public int Denominator { get; }

        /// <summary>
        /// Конструктор дроби
        /// </summary>
        /// <param name="number"></param>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        public Fraction(int number, int numerator, int denominator)
        {
            if (denominator != 0)
            {
                // Поиск общих делителей
                for (int i = 2; i <= Math.Min(numerator, denominator); i++)
                {
                    while ((numerator % i == 0) && (denominator % i == 0))
                    {
                        numerator /= i;
                        denominator /= i;
                    }
                }

                // Преобразование неправильной дроби в правильную
                while (numerator >= denominator)
                {
                    numerator -= denominator;
                    number++;
                }
            }

            // Сохранение данных
            Number = number;
            Numerator = numerator;
            Denominator = denominator;
        }


        /// <summary>
        /// Конструктор правильной дроби
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        public Fraction(int numerator, int denominator) :
            this(0, numerator, denominator)
        { }


        /// <summary>
        /// Сложение натуральных дробей
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator +(Fraction a, Fraction b)
        {
            int numerator;
            int denominator;
            if (a.Denominator == 0)
            {
                numerator = b.Numerator;
                denominator = b.Denominator;
            }
            else if (b.Denominator == 0)
            {
                numerator = a.Numerator;
                denominator = a.Denominator;
            }
            else
            {
                numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
                denominator = a.Denominator * b.Denominator;
            }
            var result = new Fraction(a.Number + b.Number, numerator, denominator);
            return result;
        }

        /// <summary>
        /// Сложение дроби и целого числа
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator +(Fraction a, int b)
        {
            var result = new Fraction(a.Number + b, a.Numerator, a.Denominator);
            return result;
        }

        /// <summary>
        /// Сложение целого числа и дроби
        /// </summary>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction operator +(int b, Fraction a) => a + b;

        public override string ToString()
        {
            string s1 = (Number != 0) ? $"{Number}" : string.Empty;
            string s2 = (Numerator != 0) ? $"{Numerator}/{Denominator}" : string.Empty;
            string s = string.Join(' ', s1, s2);
            return string.IsNullOrWhiteSpace(s) ? "0": s;
        }
    }
}
