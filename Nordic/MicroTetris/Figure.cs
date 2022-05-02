using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTetris
{
    /// <summary>
    /// Фигура тетриса (для начала - одна клетка)
    /// </summary>
    class Figure
    {
        /// <summary>
        /// Размер квадратика
        /// </summary>
        private const int Size = 50;
        /// <summary>
        /// Абсцисса
        /// </summary>
        private int x;
        /// <summary>
        /// Ордината
        /// </summary>
        private int y;
        /// <summary>
        /// Ширина стакана в клетках
        /// </summary>
        private int width;
        /// <summary>
        /// Цвет
        /// </summary>
        private Color color;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        internal Figure(int width)
        {
            // Генератор случайных чисел
            var random = new Random();
            // Генерация координаты нового кубика
            // this используется, так как параметр тоже называется width
            this.width = width / Size;
            x = random.Next(0, this.width);
            y = 0;
            // Генерация нового случайного цвета
            int red = random.Next(0, 255);
            int green = random.Next(0, 255);
            int blue = random.Next(0, 255);
            color = Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// Нарисовать фигуру
        /// </summary>
        internal void Draw(Graphics graphics)
        {
            Brush brush = new SolidBrush(color);
            graphics.FillRectangle(brush, x * Size, y * Size, Size, Size);
        }

        /// <summary>
        /// Уронить фигуру на одну строку вниз
        /// </summary>
        /// <returns>true - если фигура упала на дно</returns>
        internal bool Down(int height)
        {
            if (height < (y + 2) * Size)
            {
                return true; // уже упало
            }
            else
            {
                y++;
                return false; // пока падает
            }
        }

        /// <summary>
        /// Перемещение фигуры влево или вправо
        /// </summary>
        /// <param name="increment">Приращение координаты, по умолчанию - вправо</param>
        /// <returns>true - если надо перерисовать поле</returns>
        private bool Move(int increment = 1)
        {
            int newx = x + increment;
            if (newx >= 0 && newx < width)
            {
                x = newx;
                return true;
            }
            return false;
        }

        internal bool Left()
        {
            return Move(-1);
        }

        internal bool Right() => Move();
    }
}
