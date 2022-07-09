using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace SpeechRecognition
{
    public class Recognizer
    {
        private HttpClient client;

        public Recognizer()
        {
            client = new HttpClient();
        }

        public string Recognize()
        {
            var config = JsonFile.Load<Configuration>();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://stt.api.cloud.yandex.net/speech/v1/stt:recognize");
            HttpResponseMessage response = client.Send(request);
            return response.ReasonPhrase;
        }
    }
}
