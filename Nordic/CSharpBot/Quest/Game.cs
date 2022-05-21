using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NLog;
using Telegram.Bot;

namespace CSharpBot.Quest
{
    [XmlRoot(Namespace = "http:/quiz.orioner.ru/12floor/quest.xsd")]
    public class Game : JsonFile
    {
        /// <summary>
        /// Словарь комнат
        /// </summary>
        [XmlIgnore()] // не участвует в XML-сериализации
        public Dictionary<int, Room> Rooms = new Dictionary<int, Room>();

        /// <summary>
        /// Массив комнат для чтения из XML-файла
        /// </summary>
        [XmlElement(ElementName = "Location")]
        [JsonIgnore()] // не участвует в JSON-сериализации
        public Room[] XmlRooms;

        /// <summary>
        /// Загрузка сценария игры из XML
        /// </summary>
        /// <param name="name">Имя XML-файла</param>
        /// <returns></returns>
        public static Game LoadXml(string name)
        {
            using (var reader = System.Xml.XmlReader.Create(name))
            {
                var serializer = new XmlSerializer(typeof(Game));
                var game = (Game)serializer.Deserialize(reader);
                return game;
            }
        }

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
