using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Weather.Yandex
{
    public class YandexWeather : IWeather
    {
        private HttpClient client;

        private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public YandexWeather()
        {
            client = new HttpClient();
        }

        public MeteoData? GetData()
        {
            var config = JsonFile.Load<Configuration>();

            UriBuilder uri = new UriBuilder("https://api.weather.yandex.ru/v2/forecast");
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            // Инвариантные региональные настройки
            IFormatProvider format = System.Globalization.CultureInfo.InvariantCulture;
            parameters["lat"] = config.Latitude.ToString(format);
            parameters["lon"] = config.Longitude.ToString(format);
            parameters["lang"] = "ru_RU";
            parameters["limit"] = "7";
            parameters["hours"] = "true";
            parameters["extra"] = "true";
            uri.Query = parameters.ToString();

            // Запрос к облаку
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri.ToString())
            };

            // Авторизация запроса 
            request.Headers.Add("X-Yandex-API-Key", config.YandexKey);

            // Выполнение запроса
            HttpResponseMessage response = client.Send(request);

            string result;
            if (!response.IsSuccessStatusCode)
            {
                result = response.ReasonPhrase ?? string.Empty;
                log.Warn($"{uri}: {result}");

                return null;
            }
            else
            {
                string json = response.Content.ReadAsStringAsync().Result;
                var data = JsonSerializer.Deserialize<Yandex.YandexData>(json);
                if (data == null)
                {
                    log.Warn($"Ошибка десериализации: {json}");
                    return null;
                }
                var meteo = data.GetData();
                return meteo;
            }
        }
    }
}
