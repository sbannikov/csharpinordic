using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    /// <summary>
    /// Требуемые метеолоролические данные
    /// </summary>
    public class MeteoData
    {
        public DateTime TimeStamp { get; set; }
        public int Temperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}
