using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharpBot
{
    /// <summary>
    /// Состояние бота
    /// </summary>
    public class State
    {
        /// <summary>
        /// Имя файла для сохранения состояния
        /// </summary>
        private const string Name = "State.json";

        /// <summary>
        /// Словарь пользователей
        /// </summary>
        public Dictionary<long, User> Users = new Dictionary<long, User>();

        /// <summary>
        /// Загрузка состояния
        /// </summary>
        /// <returns></returns>
        public static State Load()
        {
            State state;
            if (System.IO.File.Exists(Name)) // проверка файла на существование
            {
                string json = System.IO.File.ReadAllText(Name);
                state = JsonConvert.DeserializeObject<State>(json);
            }
            else
            {
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

        }
    }
}
