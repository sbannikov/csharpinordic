using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

namespace Calculator
{
    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    public class Configuration : JsonFile
    {       
        /// <summary>
        /// Строка соединения с базой данных
        /// </summary>
        public string ConnectionString;        
    }
}
