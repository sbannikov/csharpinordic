using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    /// <summary>
    /// Интерфейс провайдера метеорологической информации
    /// </summary>
    public interface IWeather
    {
        MeteoData? GetData();
    }
}
