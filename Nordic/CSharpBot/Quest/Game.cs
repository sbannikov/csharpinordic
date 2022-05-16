using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using Telegram.Bot;

namespace CSharpBot.Quest
{
    public class Game : JsonFile
    {
        /// <summary>
        /// Словарь комнат
        /// </summary>
        public Dictionary<int, Room> Rooms;

        /// <summary>
        /// Поиск комнаты по номеру
        /// </summary>
        /// <param name="сlient">Клиент Telegram</param>
        /// <param name="id">Идентификатор чата</param>
        /// <param name="roomNumber">Номер комнаты</param>
        /// <returns></returns>
        public Room FindRoom(ITelegramBotClient сlient, long id, int roomNumber)
        {
            Quest.Room room = Rooms.SingleOrDefault(x => x.Value.Number == roomNumber).Value;
            // Проверка на существование комнаты
            if (room == null)
            {
                сlient.SendTextMessageAsync(id, $"Комната {roomNumber} отсутствует в игре");
            }
            return room;
        }
    }
}
