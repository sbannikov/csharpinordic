using System;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using NLog;

namespace CSharpBot
{
    internal class Program
    {
        /// <summary>
        /// Протоколирование
        /// </summary>
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0 && args[0] == "import")
                {
                    var game = Quest.Game.LoadXml("quest.xml");
                    foreach (var room in game.XmlRooms)
                    {
                        game.Rooms.Add(room.Number, room);
                    }
                    game.Save();
                    return;
                }

                log.Info("Бот запускается...");
                Configuration config;
                // Загрузка конфигурации при помощи шаблонного метода
                config = Configuration.Load<Configuration>();
                // Загрузка конфигурации при помощи простого метода
                config = (Configuration)JsonFile.Load(typeof(Configuration));
                // Проверка конфигурации на корректность
                if (string.IsNullOrEmpty(config.Token))
                {
                    throw new BotException("Некорректная конфигурация приложения: нет ключа Telegram");
                }
                // Создание клиента
                var client = new TelegramBotClient(config.Token);
                // Запрос информации о самом боте
                var result = client.GetMeAsync();
                log.Trace("Запрос отправлен");
                // Ожидание результата
                result.Wait();
                // Получение результата асинхронного запроса
                var user = result.Result;
                // Вывод сведений о боте
                log.Info($"Бот {user.Username} отвечает, следовательно, он существует");
                // Начало приёма сообщений
                var handler = new UpdateHandler();
                client.StartReceiving(handler);

                Console.ReadLine();
            }
            catch (BotException ex)
            {
                log.Fatal(ex.Message);
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
            }
        }
    }
}
