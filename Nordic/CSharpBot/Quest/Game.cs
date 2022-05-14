using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

namespace CSharpBot.Quest
{
    public class Game
    {
        /// <summary>
        /// Имя файла для сохранения состояния
        /// </summary>
        private const string Name = "Game.json";

        /// <summary>
        /// Протоколирование
        /// </summary>
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Словарь комнат
        /// </summary>
        public Dictionary<int, Room> Rooms;

        /// <summary>
        /// Загрузка состояния
        /// </summary>
        /// <returns></returns>
        public static Game Load()
        {
            Game game;
            try
            {
                string json = System.IO.File.ReadAllText(Name);
                game = JsonConvert.DeserializeObject<Game>(json);
            }
            catch (System.IO.FileNotFoundException)
            {
                game = new Game();
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                game = new Game();
            }
            return game;
        }
    }
}
