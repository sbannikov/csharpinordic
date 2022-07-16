using System.Text.Json;
using System.Web;

namespace Weather.OpenWeatherMap
{
    public class OpenWeather : IWeather
    {
        private HttpClient client;

        private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

        public OpenWeather()
        {
            client = new HttpClient();
        }

        public MeteoData? GetData()
        {
            var config = JsonFile.Load<Configuration>();

            UriBuilder uri = new UriBuilder("https://api.openweathermap.org/data/2.5/weather");
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            // Инвариантные региональные настройки
            IFormatProvider format = System.Globalization.CultureInfo.InvariantCulture;
            parameters["lat"] = config.Latitude.ToString(format);
            parameters["lon"] = config.Longitude.ToString(format);
            parameters["appid"] = config.OpenWeatherKey;
           
            uri.Query = parameters.ToString();

            // Запрос к облаку
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri.ToString())
            };

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
                var data = JsonSerializer.Deserialize<OpenWeatherData>(json);
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
