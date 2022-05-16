using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

namespace CSharpBot.Quest
{
    public class Game : JsonFile
    {
        /// <summary>
        /// Словарь комнат
        /// </summary>
        public Dictionary<int, Room> Rooms;
    }
}
