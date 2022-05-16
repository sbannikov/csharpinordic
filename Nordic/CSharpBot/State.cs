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
    public class State : JsonFile
    {
        /// <summary>
        /// Словарь пользователей
        /// </summary>
        public Dictionary<long, User> Users = new Dictionary<long, User>();
    }
}
