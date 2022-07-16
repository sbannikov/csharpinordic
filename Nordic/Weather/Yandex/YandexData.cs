using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Yandex
{
    public class YandexData
    {
        public int now { get; set; }
        public DateTime now_dt { get; set; }
        public Info info { get; set; }
        public Fact fact { get; set; }

        public MeteoData GetData()
        {
            return new MeteoData()
            {
                TimeStamp = now_dt,
                Temperature = (int)fact.temp,
                Pressure = (int) fact.pressure_mm,
                Humidity = (int)fact.humidity
            };
        }
    }
}
