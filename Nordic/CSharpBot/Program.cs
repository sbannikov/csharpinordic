using System;
using Telegram.Bot;

namespace CSharpBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Бот запускается...");
            // Создание клиента
            var client = new TelegramBotClient("<TOKEN>");
            // Запрос информации о самом боте
            var result = client.GetMeAsync();
            Console.WriteLine("Запрос отправлен");
            // Ожидание результата
            result.Wait();
            // Получение результата асинхронного запроса
            var user = result.Result;
            // Вывод сведений о боте
            Console.WriteLine($"Бот {user.Username} отвечает, следовательно, он существует");
            Console.ReadLine();
        }
    }
}
