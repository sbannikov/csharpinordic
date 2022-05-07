using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// Цвет материала
    /// </summary>
    internal class Color
    {
        /// <summary>
        /// Наименование
        /// </summary>
        internal string Name;

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name;
    }
}
