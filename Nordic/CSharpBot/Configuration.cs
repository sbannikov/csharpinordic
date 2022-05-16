using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

namespace CSharpBot
{
    /// <summary>
    /// Конфигурация бота
    /// </summary>
    public class Configuration : JsonFile
    {       
        /// <summary>
        /// Ключ доступа к Telegram
        /// </summary>
        public string Token;        
    }
}
