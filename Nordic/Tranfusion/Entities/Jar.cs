using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranfusion.Entities
{
    /// <summary>
    /// Сосуд - кувшин
    /// </summary>
    public class Jar
    {
        /// <summary>
        /// Номер кувшина, начиная с 1
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Емкость кувшина
        /// </summary>
        public int Size { get; set; }
    }
}
