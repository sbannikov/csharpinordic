using System.Net.Http;
using System.Text.Json;
using System.Web;

namespace Weather
{
    public class Worker
    {
        private readonly System.Timers.Timer timer;

        private string key;

        private HttpClient client;

        public Worker(int seconds)
        {
            timer = new System.Timers.Timer(seconds * 1000)
            {
                AutoReset = true
            };
            timer.Elapsed += Timer_Elapsed;

            // Загрузка конфигурации из файла
            var config = JsonFile.Load<Configuration>();
            key = config.ApiKey;

            client = new HttpClient();
        }

        public void Start() { timer.Start(); }
        public void Stop() { timer.Stop(); }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timer.Stop();

                UriBuilder uri = new UriBuilder("https://api.weather.yandex.ru/v2/forecast");
                var parameters = HttpUtility.ParseQueryString(string.Empty);
                parameters["lang"] = "ru_RU";
                parameters["lat"] = "55.778739";
                parameters["lon"] = "37.640650";
                parameters["limit"] = "7";
                parameters["hours"] = "true";
                parameters["extra"] = "true";
                uri.Query = parameters.ToString();

                // Запрос к облаку
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(uri.ToString()),
                };

                // Авторизация запроса к облаку
                request.Headers.Add("X-Yandex-API-Key", key);

                // Выполнение запроса
                HttpResponseMessage response = client.Send(request);

                string result;
                if (!response.IsSuccessStatusCode)
                {
                    result = response.ReasonPhrase ?? string.Empty;
                }
                else
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    var data = JsonSerializer.Deserialize<Response>(json);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                timer.Start();
            }
        }
    }
}
