using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.OpenWeatherMap
{
    public class OpenWeatherData
    {
        /// <summary>
        /// Время UnixTime
        /// </summary>
        public int dt { get; set; }
        public Main main { get; set; }

        public MeteoData GetData()
        {
            // 1 января 1970 года
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return new MeteoData()
            {
                TimeStamp = epoch.AddSeconds(dt),
                // Преобразование Кельвин -> Цельсий
                Temperature = (int)(main.temp - 273.15),
                // преобразование гПа -> мм.рт.ст.
                Pressure = (int)(main.pressure * 0.75),
                Humidity = (int)main.humidity
            };
        }
    }
}
