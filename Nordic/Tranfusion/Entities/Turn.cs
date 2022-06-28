using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranfusion.Entities
{
    /// <summary>
    /// Ход (переливание)
    /// </summary>
    public class Turn
    {
        /// <summary>
        /// Номер сосуда, из которого мы переливаем
        /// </summary>
        public int FromJar { get; set; }

        /// <summary>
        /// Номер сосуда, в который мы переливаем
        /// </summary>
        public int ToJar { get; set; }

        /// <summary>
        /// Исходное состояние
        /// </summary>
        public State FromState { get; set; }

        /// <summary>
        /// Новое состояние
        /// </summary>
        public State ToState { get; set; }
    }
}
