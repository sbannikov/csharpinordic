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
    /// Состояние бота
    /// </summary>
    public class State
    {
        /// <summary>
        /// Протоколирование
        /// </summary>
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Имя файла для сохранения состояния
        /// </summary>
        private const string Name = "State.json";

        /// <summary>
        /// Словарь пользователей
        /// </summary>
        public Dictionary<long, User> Users = new Dictionary<long, User>();

        /// <summary>
        /// Признак необходимости сохранения состояния на диск
        /// </summary>
        internal bool Dirty = false;

        /// <summary>
        /// Загрузка состояния
        /// </summary>
        /// <returns></returns>
        public static State Load()
        {
            State state;
            try
            {
                string json = System.IO.File.ReadAllText(Name);
                state = JsonConvert.DeserializeObject<State>(json);
            }
            catch (System.IO.FileNotFoundException)
            {
                state = new State();
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                state = new State();
            }
            return state;
        }

        /// <summary>
        /// Сохранение состояния
        /// </summary>
        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            System.IO.File.WriteAllText(Name, json);
            Dirty = false;
        }
    }
}
