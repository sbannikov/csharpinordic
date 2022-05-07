using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// Материал
    /// </summary>
    internal class Material
    {
        /// <summary>
        /// Наименование
        /// </summary>
        internal string Name;
        /// <summary>
        /// Цвет в виде объекта
        /// </summary>
        internal Color MaterialColor;
        /// <summary>
        /// Наименование цвета
        /// </summary>
        internal string ColorName;
        /// <summary>
        /// Цена (руб. за м2)
        /// (цена может быть не задана)
        /// </summary>
        internal double? Price;

        /// <summary>
        /// Строковое отображение объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} {MaterialColor}";
        }
    }
}
