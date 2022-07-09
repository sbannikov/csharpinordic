using System.Text.Json;
using System.Web;

namespace SpeechRecognition
{
    public class Recognizer
    {
        private HttpClient client;

        public Recognizer()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Распознать записанный звук
        /// </summary>
        /// <param name="recorder"></param>
        /// <returns></returns>
        public string Recognize(Recorder recorder)
        {
            // Загрузка конфигурации из файла
            var config = JsonFile.Load<Configuration>();

            UriBuilder uri = new UriBuilder("https://stt.api.cloud.yandex.net/speech/v1/stt:recognize");
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["lang"] = "ru-RU";
            parameters["format"] = "lpcm";
            parameters["sampleRateHertz"] = recorder.SampleRate.ToString();
            parameters["folderId"] = config.FolderID;
            uri.Query = parameters.ToString();

            // Содержимое запроса в виде файла
            var content = new ByteArrayContent(recorder.Sound());
            // Необязательно для данного случая, но полезно
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/vnd.wave");
          
            // Запрос к облаку
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri.ToString()),
                Content = content
            };

            // Авторизация запроса к облаку
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Api-Key", config.ApiKey);

            // Выполнение запроса
            HttpResponseMessage response = client.Send(request);

            string result;
            if (!response.IsSuccessStatusCode)
            {
                result = response.ReasonPhrase;
            }
            else
            {
                string json = response.Content.ReadAsStringAsync().Result;
                result = JsonSerializer.Deserialize<Response>(json).Result;
            }
            return result;
        }
    }
}
