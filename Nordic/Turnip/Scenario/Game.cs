using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Turnip.Scenario
{
    /// <summary>
    /// Сценарий игры
    /// </summary>
    public class Game : JsonFile
    {
        /// <summary>
        /// Начальные предметы
        /// </summary>
        [JsonProperty("inits")]
        public string[] StartThings;

        /// <summary>
        /// Список всех предметов и их категорий
        /// </summary>
        [JsonProperty("classes")]
        public Dictionary<string, string> Things;
    }
}
