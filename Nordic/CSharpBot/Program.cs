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
                log.Info("Бот запускается...");
                Configuration config = Configuration.Load<Configuration>();
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
            catch (Exception ex)
            {
                log.Fatal(ex);
            }
        }
    }
}
