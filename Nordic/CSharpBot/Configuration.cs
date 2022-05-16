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
    public class Configuration
    {
        /// <summary>
        /// Имя файла для сохранения состояния
        /// </summary>
        private const string Name = "Configuration.json";

        /// <summary>
        /// Протоколирование
        /// </summary>
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Ключ доступа к Telegram
        /// </summary>
        public string Token;

        /// <summary>
        /// Загрузка состояния
        /// </summary>
        /// <returns></returns>
        public static Configuration Load()
        {
            Configuration config;
            try
            {
                string json = System.IO.File.ReadAllText(Name);
                config = JsonConvert.DeserializeObject<Configuration>(json);
            }
            catch (System.IO.FileNotFoundException)
            {
                config = new Configuration();
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                config = new Configuration();
            }
            return config;
        }
    }
}
