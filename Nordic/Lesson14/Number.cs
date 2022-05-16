using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14
{
    /// <summary>
    /// Случайное целое число
    /// </summary>
    public class Number
    {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private static readonly Random random;

        /// <summary>
        /// Счётчик созданных объектов
        /// </summary>
        public static int counter = 0;

        private int numberField;

        /// <summary>
        /// Целое число
        /// </summary>
        public int number
        {
            get
            {
                return numberField;
            }
            set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Ерунда какая");
                }
                numberField = value;
            }
        }

        public int DoubleNumberLong
        {
            get
            {         
                // свойство не имеет морального права менять состояние объекта
                return numberField * 2;
            }
        }

        public int DoubleNumberShort => numberField * 2;

        public int DoubleNumberMethod()
        {
            // метод имеет право менять состояние объекта
            // например, вот так: numberField++; 
            return numberField * 2;
        }

        public int DoubleNumberMethodShort() => numberField * 2;

        /// <summary>
        /// Статический конструктор
        /// </summary>
        static Number()
        {
            Console.WriteLine("static Number()");
            random = new Random();
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Number() : this(random.Next(0, 1000))
        {
        }

        /// <summary>
        /// Конструктор по заданному числу
        /// </summary>
        /// <param name="n">Натуральное число</param>
        public Number(int n)
        {            
            number = n;
            Console.WriteLine($"+ {number}");
            counter++;
        }

        /// <summary>
        /// Деструктор
        /// </summary>
        ~Number()
        {
            counter--;
            Console.WriteLine($"- {number}, осталось {counter} объектов");
        }
    }
}
