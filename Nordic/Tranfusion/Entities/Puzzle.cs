using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranfusion.Entities
{
    /// <summary>
    /// Головоломка
    /// </summary>
    public class Puzzle
    {
        /// <summary>
        /// Словарь кувшинов
        /// </summary>
        public Dictionary<int, Jar> Jars = new Dictionary<int, Jar>();
    }
}
