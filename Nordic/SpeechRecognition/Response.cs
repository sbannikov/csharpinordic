using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpeechRecognition
{
    public class Response
    {
        /// <summary>
        /// Результат распознавания
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; }
    }
}
