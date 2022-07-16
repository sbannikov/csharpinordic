using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Weather
{
    public class Worker
    {
        private HttpClient client;
        private string key;
        private System.Timers.Timer timer;

        public Worker()
        {
            client = new HttpClient();

            // Загрузка конфигурации из файла
            // [!] выполняется однократно, при запуске
            // если файл конфигурации поменяется, придётся перезапускать сервис
            var config = JsonFile.Load<Configuration>();
            key = config.ApiKey;

            timer = new System.Timers.Timer(config.IntervalInSeconds * 1000);
            timer.Elapsed += Timer_Elapsed;
        }

        /// <summary>
        /// Основное событие запроса данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timer.Stop();

                UriBuilder uri = new UriBuilder("https://api.weather.yandex.ru/v2/forecast");
                var parameters = HttpUtility.ParseQueryString(string.Empty);
                // Ханты-Мансийск
                parameters["lat"] = "61.003184";
                parameters["lon"] = "69.018911";
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
                    var data = JsonSerializer.Deserialize<Yandex.YandexData>(json);
                    var meteo = data.GetData();
                    json = JsonSerializer.Serialize(meteo);
                    string name = $@"C:\FOLDER\{meteo.TimeStamp.Ticks}.json";
                    System.IO.File.WriteAllText(name, json);
                }
            }
            catch (Exception ex)
            {
                // [!] дописать на досуге
            }
            finally
            {
                timer.Start();
            }
        }

        public void StartService()
        {
            timer.Start();
        }

        public void StopService()
        {
            timer.Stop();
        }

        public void PauseService()
        {
            timer.Stop();
        }

        public void ContinueService()
        {
            timer.Start();
        }
    }