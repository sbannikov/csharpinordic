using System.Text.Json;
using System.Web;

namespace SpeechRecognition
{
    /// <summary>
    /// Синтех речи
    /// </summary>
    public class Syntesizer
    {
        private HttpClient client;

        public Syntesizer()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Синтезировать речь
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public ISound Syntez(string text)
        {
            // Загрузка конфигурации из файла
            var config = JsonFile.Load<Configuration>();

            var parameters = new Dictionary<string, string>
            {
                { "text", text },
                { "lang" , "ru-RU"},
                { "voice", "alena"},
                { "speed", "1.0" },
                { "emotion", "neutral"},
                { "format", "lpcm"},
                { "sampleRateHertz", "8000"},
                { "folderId", config.FolderID}
            };
            // Запрос к облаку
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://tts.api.cloud.yandex.net/speech/v1/tts:synthesize"),
                Content = new FormUrlEncodedContent(parameters)
            };
            // Авторизация запроса к облаку
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Api-Key", config.ApiKey);

            // Выполнение запроса
            HttpResponseMessage response = client.Send(request);

            if (!response.IsSuccessStatusCode)
            {
                var s = response.Content.ReadAsStringAsync();
                throw new Exception(response.ReasonPhrase);
            }

            byte[] sound = response.Content.ReadAsByteArrayAsync().Result;
            var result = new BaseSound(sound, 8000);
            return result;
        }
    }
}
