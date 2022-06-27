using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranfusion.Enums
{
    /// <summary>
    /// Тип состояния
    /// </summary>
    public enum StateType
    {
        None,
        /// <summary>
        /// Начальное состояние сосудов
        /// </summary>
        Start,
        /// <summary>
        /// Промежуточное состояние сосудов
        /// </summary>
        Intermediate,
        /// <summary>
        /// Целевое состояние сосудов
        /// </summary>
        Finish
    }
}
