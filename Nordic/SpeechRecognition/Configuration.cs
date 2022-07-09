using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace SpeechRecognition
{
    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    public class Configuration : JsonFile
    {
        /// <summary>
        /// Ключ доступа к API Yandex SpeechKit
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Идентификатор каталога Yandex Cloud
        /// </summary>
        public string FolderID { get; set; }
    }
}
