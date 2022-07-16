using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Weather
{
    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    public class Configuration : JsonFile
    {
        /// <summary>
        /// Ключ доступа к API Yandex Погода
        /// </summary>
        public string YandexKey { get; set; }

        /// <summary>
        /// Широта
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Интервал в секундах
        /// </summary>       
        public int IntervalInSeconds { get; set; } = 1;
    }
}
